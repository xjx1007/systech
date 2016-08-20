set_input_msg();
function SalesobjectObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      SalesobjectObj.prototype[attr] = Module.prototype[attr];
	};
	this.method = 'handleRequest';
	this.object_type = '';
	this.inJQ = true;
};

SalesobjectObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.object_type = getstorage("object_type");  
	var startDate = getstorage("startDate");
	var endDate = getstorage("endDate");
	var fanweisel = getstorage("fanweisel");
	this.action = "get_entry_list";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
		'"object_type":"' + this.object_type + '",' +
		'"startDate":"' + startDate + '",' +
        '"endDate":"' + endDate + '",' +
        '"fanweisel":"'+fanweisel+'"}]';
	this.RequestServer();
}; 

SalesobjectObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	var employeeItem = RES_PERFORMANCES_LISTITEM;
		forumObj += '<div class="ub ub-f1 c-gra4">';
		forumObj += '<div class="ub ub-f1 t-bla c-wh b-gra umar-t uc-t uba">'; 
		forumObj += '<div class="ub-f1 tx-c ub-con ubr uinn7 t-blu2 b-gra">人员</div>';
		forumObj += '<div class="ub-f1 tx-c ub-con ubr uinn7 t-blu2 b-gra">目标</div>';
		forumObj += '<div class="ub-f1 tx-c ub-con ubr uinn7 t-gre b-gra">完成</div>';
		forumObj += '<div class="ub-f1 tx-c ub-con uinn7 t-org1 b-gra">%</div>';
		forumObj += '</div></div>';
	if (data !== undefined) {
		var employeeList = data;
		for (var i = 0; i < employeeList.length; i++) {
			var employee = employeeList[i];
			forumObj += '<div class="ub t-bla c-wh ubb b-gra">'; 
		      forumObj += '<div class="ub-f1 tx-c ub-con ubr uinn7 t-bla b-gra long_hide">' + employee.last_name + '</div>';
			  forumObj += '<div class="ub-f1 tx-c ub-con ubr uinn7 b-gra t-blu2">'+employee.object_value+'</div>';
			  forumObj += '<div class="ub-f1 tx-c ub-con ubr uinn7 b-gra t-gre">'+employee.actual_value+'</div>';
			  forumObj += '<div class="ub-f1 tx-c ub-con uinn7 b-gra t-org1">'+employee.persent_value+'%</div>';
			forumObj += '</div>'; 
		}
		if (employeeList.length == 0) {
			forumObj += showNotRecordDiv();
		}else{
			var crmChart = new Crm_Chart(employeeList);
			crmChart.inverted_flag = true;
			crmChart.legend_flag = true;
			crmChart.name = "人员";
			crmChart.showChart('container1','bar');
		}
	}
	setHtml("record_list", forumObj);
}

SalesobjectObj.prototype.GetFanWeiFromServer=function(){  //获取范围(实例方法)
	this.method = 'get_fanwei_list';
	this.action = 'get_fanwei_list';
	this.inJQ = false;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
            '"module_name":"Salesobjects"}';
	this.RequestServer();
}; 

SalesobjectObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(this.action){
		case 'get_entry_list':
			this.ShowList(data);
			break;
		case 'get_fanwei_list':
			setHtml("fanweisel", data);
			selectValue("fanweisel",getstorage("fanweisel"));
			break;
	}
};  

SalesobjectObj.prototype.ReturnSuccess = function(data){ //
	
}

var lastFold = '';
function zy_fold_sfa(e, col){
	var a = e.currentTarget.nextElementSibling;
	if (lastFold != "" && lastFold != a) {
		if (lastFold.className.indexOf(' col-c') < 0) {
			lastFold.className += ' col-c';
		}
	}
    if (a.nodeName == "DIV") {
        if (a.className.indexOf(' col-c') < 0) {
			a.className += ' col-c';
		}else {
			a.className = a.className.replace(" col-c", "");
		}
    }
	lastFold = a;
}

/**
 * 图表对象
 * @param {Object} data 传入的数据
 */
function Crm_Chart(data){
	this.inverted_flag = false; //左右显示，默认上下正向。假如设置为true，则横纵坐标调换位置
	this.stackLabels_flag = false;//是否显示y轴坐标值
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
	var object_total = 0;
	var actual_total = 0;
	var object_value_data = [];
	var actual_value_data = [];
	for (var i = 0; i < data.length; i++) {
		var employee = data[i];
		this.categories.push(employee.last_name);
		object_total += Number(employee.object_value);
		actual_total += Number(employee.actual_value);
		object_value_data.push(Number(employee.object_value));
		actual_value_data.push(Number(employee.actual_value));
	}
	this.categories.push("总计");
	object_value_data.push(object_total);
	actual_value_data.push(actual_total);
	this.series = [{
			name:"完成",
			color:colors[3],
		 	data:actual_value_data
		},{
			name:"目标",
			color:colors[0],
		 	data:object_value_data
		}
	]
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
						softConnector: true
					},
					neckWidth: '20%',
					neckHeight: '10%'
				}		
	        },
            legend: {
                enabled: this.legend_flag
            },
            credits: {
                enabled: false
            },
            series: this.series
    });
}