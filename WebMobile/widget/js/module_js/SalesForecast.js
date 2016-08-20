/**
 * 销售预测 
 */
function SFTObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      SFTObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
};

SFTObj.prototype.CalForecastFromServer=function(){  //计算销售预测值(实例方法)
	var startDate = $$("startDate").value;
	var endDate = $$("endDate").value;
	var probability = $$('probability').value;
	setstorage('startDate',startDate);
	setstorage('endDate',endDate);
	setstorage('probability',probability);
	this.method = 'get_performances_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"SalesForecast",' +
		'"startDate":"' + startDate + '",' +
    	'"endDate":"' + endDate + '",' +
		'"fanweisel":"' + probability + '"}';
	this.RequestServer();
}; 

SFTObj.prototype.GetSalesForecastListFromServer = function(){  //获取预测具体数据(实例方法)
	this.offset = getstorage("currPage");
	var searchtext = getstorage("searchtext");
	if(!searchtext) searchtext = '';
	var startDate = getstorage('startDate');
	var endDate = getstorage('endDate');
	var probability = getstorage('probability');
	this.method = 'get_detail_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
            '"module_name":"'+this.name+'",' +
            '"query":"'+searchtext+'",' +
            '"offset":' + this.offset + ',' +
            '"max_results":' + RowsPerPageInListViews + ',' +
        	'"startDate":"' + startDate + '",' +
	    	'"endDate":"' + endDate + '",' +
			'"sel":"' + probability + '"}';
	this.RequestServer();
}; 

SFTObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_performances_entry_list':
			$$('amountTotal').value = FormatNumber(String(data.entry_list.amountTotal));
			$$('count').value = data.entry_list.count;
			break;
		case 'get_detail_list':
			this.ShowList(data);
			break;
	}
};  

SFTObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	var listObj = data;
	if ((listObj !== undefined) && (listObj.entry_list !== undefined)) {
		if ((listObj.next_offset === 0) || (listObj.result_count === 0)) {
			myalert('There are no more records in that direction');
		}else {
			var i = 0;
			for (i = 0; i < listObj.entry_list.length; i++) {			
				if(i%2!=0)
					whitebg = "c-wh";
				else
					whitebg = '';		
				if (listObj.entry_list[i] !== undefined) {
					var theBill = listObj.entry_list[i];
					var theBillPText = '';
					forumObj +='<ul onclick="openPotentialDetail('+theBill.id+',\'../Potentials/\');" class="ub ub-ac lis act-wh '+whitebg+' ">';
					forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub li_1">';
					forumObj +='<div class="ub-f2">'+theBill.name_value_list.name.value+'</div>';     
					forumObj +='<div class="ub-f1"><span class="li_3" style="float:right">'+theBill.name_value_list.contactname.value+'</span></div></li>';
					forumObj +='<li class="ub li_3">';
					forumObj +='<div class="ub-f1">预期:<span class="li_3_2">'+theBill.name_value_list.closingdate.value +'</span></div>';
					forumObj +='<div class="ub-f1 tx-c"><span class="li_3_2">￥'+theBill.name_value_list.probableamount.value +'</span></div>';  
					forumObj +='<div class="ub-f1 tx-c"><span class="li_3_2">'+theBill.name_value_list.probability.value +'%</span></div></li>';
					forumObj +='<li class="ub li_3">'+theBill.name_value_list.accountname.value +'</li>';       //客户名称     
					forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
				}
			}
			if(listObj.entry_list.length == 0){
				forumObj += showNotRecordDiv();
			}
			setHtml("salesforecast_list", forumObj);
			if(listObj.lastpg > 0){
				setstorage('currPage', this.offset);
				setstorage('lastPage', listObj.lastpg);
				uexWindow.evaluatePopoverScript('SalesForecastListPage','pop_nav',"setPageSel()");
			}
		}
	}
}

//检查开始时间/结束时间
function checkTime(){
	var date_start = $$('startDate').value;
	var due_date = $$('endDate').value;
	if(!date_start)
		date_start = $$('startDate').innerHTML;
	if(!due_date)
		due_date = $$('endDate').innerHTML;
		
	var arrStartDate = date_start.split("-");   
	var arrDueDate = due_date.split("-");    
	var allStartDate = new Date(arrStartDate[0],arrStartDate[1]-1,arrStartDate[2]); 
	var allEndDate = new Date(arrDueDate[0],arrDueDate[1]-1,arrDueDate[2]); 
	if(allStartDate.getTime()>allEndDate.getTime()){   
         return false;   
    }
	return true;   
}

// 设置新的日期/时间 
function setNewDate(id){
	if (id == 'startDate') {
		if($$('startDate').value){
			$$('endDate').value = $$('startDate').value;
		}else{
			$$('endDate').innerHTML = $$('startDate').innerHTML;
		}	
	}else{
		if($$('endDate').value){
			$$('startDate').value = $$('endDate').value;
		}else{
			$$('startDate').innerHTML = $$('endDate').innerHTML;
		}
		
	}
}

//打开销售机会详细
function openPotentialDetail(id,res){
	setstorage('CurrentPotentialId', id);
	openwin('PotentialDetailsPage',res);
}

