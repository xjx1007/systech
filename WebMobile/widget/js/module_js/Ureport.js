set_input_msg();
function UreportObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      UreportObj.prototype[attr] = Module.prototype[attr];
	};
	this.method = 'handleRequest';
	this.startDate = '';
	this.endDate = '';
	this.object_type = '';
	this.inJQ = true;
};

UreportObj.prototype.GetChartDataFromServer=function(){  //获取列表(实例方法)
	this.action = "get_chart_data";
	this.reType = getstorage('reType');
	this.startDate = getstorage("startDate");
	this.endDate = getstorage("endDate");
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",' +
		'"startDate":"' + this.startDate + '",' +
        '"endDate":"' + this.endDate + '",' +
		'"type":"'+this.reType+'"}]';
	this.RequestServer();
}; 

UreportObj.prototype.GetWeekDataFromServer=function(){  //获取列表(实例方法)
	this.action = "get_week_data";
	//this.inJQ = false;
	this.CurrentUserId = getstorage("SugarSessionId");
	
	//alert(userid);
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'"}]';
//alert(this.rest_data);
	var url = this.AjaxUrl+'/rest.php?callback=?&rest_data='+encodeURIComponent(this.rest_data)+'&method='+this.method;
	$.getJSON(url,ShowWeekReports);
}; 

UreportObj.prototype.ShowChart = function(data){ //显示 图表(实例方法)
	var forumObj = '<div class="uinn umar-l">'+
					'<ul class="ub ub-ac lis uc-a1 " style="background-color:rgba(0,0,0,0.7);">'+
						'<li class="tx-c t-wh ub-f1" >正在绘制中,请稍后...</li>'+
					'</ul>'+
					'</div>';
	setHtml("container1", forumObj);
	var crmChart = new Crm_Chart(data);
	var arrDate = this.startDate.split("-");  
	switch(this.reType){
		case 'account_type':
			crmChart.title = "客户类型统计";
			crmChart.name = "类型";
			crmChart.yAxis_text = '数值(个)';
			crmChart.showChart('container1','column');
			crmChart.title = "客户类型统计(饼图)";
			crmChart.legend_flag = true;
			crmChart.seriesLabels_flag = true;
			crmChart.showChart('container2','pie');
			break;
		case 'salesorder_smowner':
			crmChart.inverted_flag = true;
			crmChart.yAxis_text = ' 签约额(元)';
			crmChart.title = "合同订单签约额人员分布";
			crmChart.subtitle = arrDate[0]+"年"+arrDate[1]+"月";
			crmChart.name = "人员";
			crmChart.showChart('container1','column');
			break;
		case 'huikuan_day':
			crmChart.stackLabels_flag = false;
			crmChart.yAxis_text = '回款额(元)';
			crmChart.title = "回款趋势/天";
			crmChart.subtitle = arrDate[0]+"年"+arrDate[1]+"月";
			var newCategories = [];
			for(var k=1;k<=crmChart.categories.length;k++){
				if(k%5 == 0){
					newCategories.push(k);
				}else{
					newCategories.push('');
				}
			}
			crmChart.categories = newCategories;
			crmChart.showChart('container1','column');
			break;
		case 'qianyue_day':
			crmChart.stackLabels_flag = false;
			crmChart.yAxis_text = '签约额(元)';
			crmChart.title = "签约趋势/天";
			crmChart.subtitle = arrDate[0]+"年"+arrDate[1]+"月";
			var newCategories = [];
			for(var k=1;k<=crmChart.categories.length;k++){
				if(k%5 == 0){
					newCategories.push(k);
				}else{
					newCategories.push('');
				}
			}
			crmChart.categories = newCategories;
			crmChart.showChart('container1','column');
			break;
		case 'huikuan_month':
			crmChart.stackLabels_flag = false;
			crmChart.yAxis_text = '回款额(元)';
			crmChart.title = "回款趋势/月";
			crmChart.subtitle = arrDate[0]+"年";
			var newCategories = [];
			for(var k=1;k<=crmChart.categories.length;k++){
				newCategories.push(k);
			}
			crmChart.categories = newCategories;
			crmChart.showChart('container1','column');
			break;
		case 'qianyue_month':
			crmChart.stackLabels_flag = false;
			crmChart.yAxis_text = '签约额(元)';
			crmChart.title = "签约趋势/月";
			crmChart.subtitle = arrDate[0]+"年";
			var newCategories = [];
			for(var k=1;k<=crmChart.categories.length;k++){
				newCategories.push(k);
			}
			crmChart.categories = newCategories;
			crmChart.showChart('container1','column');
			break;
		case 'salesfunnel_count':
			crmChart.title = "各阶段机会数量";
			crmChart.marginRight = 120;
			crmChart.seriesLabels_flag = true;
			$$('dataTotal').style.display = "block";
			crmChart.showChart('container1','funnel');
			setHtml('dataTotal','<b>总计</b>:'+crmChart.dataTotal);
			break;
		case 'salesfunnel_amount':
			crmChart.title = "各阶段机会金额";
			crmChart.marginRight = 120;
			crmChart.seriesLabels_flag = true;
			$$('dataTotal').style.display = "block";
			crmChart.showChart('container1','funnel');
			setHtml('dataTotal','<b>总计</b>:'+fmoney(crmChart.dataTotal,3));
			break;
	}
}

UreportObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(this.action){
		case 'get_chart_data':
			//document.write(JSON.stringify(data));
			this.ShowChart(data);
			break;
		case 'get_week_data':
			document.write(JSON.stringify(data));
			//this.ShowWeekReports(data);
			break;
	}
};  

/**
 * 图表对象
 * @param {Object} data 传入的数据
 */
function Crm_Chart(data){
	this.inverted_flag = false; //左右显示，默认上下正向。假如设置为true，则横纵坐标调换位置
	this.stackLabels_flag = true;//是否显示y轴坐标值
	this.legend_flag = false;  //是否显示X轴分类
	this.seriesLabels_flag = false;
	this.title = '';   // 标题
	this.subtitle = '';   // 标题1
	this.name = '';    //X轴分类名
	this.yAxis_text = '';
	this.datas = [];   //y轴具体数据
	this.categories = []; //x轴数据
	this.marginRight = 0;
	this.dataTotal = 0;
	var colors = Highcharts.getOptions().colors;
	var i=0;
    for (var property in data) {
		this.categories.push(property);
		this.dataTotal += data[property];
		this.datas.push({
			name:property,
			y: data[property],
			color:colors[i]
		});
		i++;
	}
}

/**
 * 显示图表
 * @param {Object} renderTo 图表显示的Div id
 * @param {Object} showtype 图表类型
 */
Crm_Chart.prototype.showChart = function(renderTo,showtype){ //显示结果(实例方法)
	var chart;
	chart = new Highcharts.Chart({
        chart: {
            renderTo: renderTo,
			type:showtype,
			marginRight: this.marginRight,
			inverted: this.inverted_flag  //左右显示，默认上下正向。假如设置为true，则横纵坐标调换位置
        },
        title: {
            text: this.title
        },
		subtitle: {
            text: this.subtitle
        },
        xAxis: {
            categories: this.categories,
			x: -50,
			labels: {
                rotation: 0      //坐标值显示的倾斜度    
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: this.yAxis_text
            },
			stackLabels: {
                enabled: this.stackLabels_flag,
                style: {
                    color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                }
            }
        },
		plotOptions: {
  			column: {
                stacking: 'normal',
                dataLabels: {
                    enabled: false,
                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                }
            },
			pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    color: '#000000',
                    connectorColor: '#000000',
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                },
				showInLegend: true
            },
			series: {
				dataLabels: {
					enabled: this.seriesLabels_flag,
					format: '<b>{point.name}</b>: {point.percentage:.1f} %',
					color: 'black',
            		animation: false,  
					softConnector: true
				},
				neckWidth: '20%',
				neckHeight: '10%'
			}		
        },
		legend: {
        	enabled: this.legend_flag
        },
        tooltip: {
            formatter: function() {
                var s;
                if (showtype == 'pie') {// the pie chart
                    s = ''+
						this.point.name + ': '+ this.y;
                } else {
                    s = ''+
                        this.point.name  +': '+ this.y;
                }
                return s;
            }
        },
       series: [{
			name: this.name,
            data: this.datas
       }]
    });
}


