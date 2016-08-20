/**
 * 销售漏斗 
 */
function SFObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      SFObj.prototype[attr] = Module.prototype[attr];
	};
};

SFObj.prototype.GetFanWeiFromServer=function(){  //获取范围(实例方法)
	this.method = 'get_fanwei_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
            '"module_name":"Funnels"}';
	this.RequestServer();
}; 

SFObj.prototype.GetSalesFunnelFromServer = function(){  //获取漏斗数据(实例方法)
	var fanweisel = getstorage("fanweisel");
	this.method = 'get_performances_entry_list';
	this.inJQ = true;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"SalesFunnel",' +
		'"startDate":"",' +
        '"endDate":"",' +
		'"fanweisel":"' + fanweisel + '"}';
	this.RequestServer();
}; 

SFObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_fanwei_list':
			setHtml("fanweisel", data);
			selectValue("fanweisel","all_to_me");
			break;
		case 'get_performances_entry_list':
			var seriesArr = data.entry_list;
			getSalesFunnel(seriesArr);
			break;
	}
};  

function getSalesFunnel(seriesArr){   //highchart绘制销售漏斗
	var countData = [];
	var amountData = [];
	var countTotal = 0;
	var amountTotal = 0;
	for(var i=0;i<seriesArr.length;i++){
		countData.push([seriesArr[i].name, seriesArr[i].value.count]);
		countTotal += seriesArr[i].value.count;
		amountData.push([seriesArr[i].name, seriesArr[i].value.amount]);
		amountTotal += seriesArr[i].value.amount;
	}
	$(function(){
		var chart;
		$(document).ready(function(){
			chart = new Highcharts.Chart({
				chart: {
					renderTo: 'container1',
					type: 'funnel',
					marginRight: 120
				},
				credits: {
					enabled: false//是否显示版权及链接，布尔型，默认为显示
				},
				title: {
					text: '各阶段销售机会数量',
					x: -50
				},
				plotOptions: {
					series: {
						dataLabels: {
							enabled: true,
							format: '<b>{point.name}</b>: {point.percentage:.1f} %',
							color: 'black',
							softConnector: true
						},
						neckWidth: '20%',
						neckHeight: '10%'
					
						//-- Other available options
						// height: pixels or percent
					}
				},
				legend: {
					enabled: false
				},
				series: [{
					name: '数量',
					data: countData
		}]
			});
			chart = new Highcharts.Chart({
				chart: {
					renderTo: 'container2',
					type: 'funnel',
					marginRight: 120
				},
				credits: {
					enabled: false//是否显示版权及链接，布尔型，默认为显示
				},
				title: {
					text: '各阶段销售机会金额',
					x: -50
				},
				plotOptions: {
					series: {
						dataLabels: {
							enabled: true,
							format: '<b>{point.name}</b>: {point.percentage:.1f} %',
							color: 'black',
							softConnector: true
						},
						neckWidth: '20%',
						neckHeight: '10%'
					
						//-- Other available options
						// height: pixels or percent
					}
				},
				legend: {
					enabled: false
				},
				series: [{
					name: '金额',
					data: amountData
				}]
			});
		});
	});
	setHtml('countTotal','<b>总计</b>:'+countTotal);
	setHtml('amountTotal','<b>总计</b>:'+FormatNumber(String(amountTotal)));
}