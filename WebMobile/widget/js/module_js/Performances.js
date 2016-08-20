/**
* 库存余额
*/
function PEObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      PEObj.prototype[attr] = Module.prototype[attr];
	};
	this.comment = true;
};

PEObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_performances_entry_list':
			this.ShowList(data);
			break;
		case 'getPerformanceDetails':
			this.ShowDetail(data);
			break;
		case 'get_performances_comments':
			this.ShowCommentsList(data);
			break;
		case 'saveComments':
			this.SaveCommentReturn(data);
			break;
	}
};  

PEObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	var startDate = getstorage("startDate");
	var endDate = getstorage("endDate");
	this.method = 'get_performances_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
				'"startDate":"' + startDate + '",' +
        		'"endDate":"' + endDate + '"}';
	this.RequestServer();
}; 

PEObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	var employeeItem = RES_PERFORMANCES_LISTITEM;
	if (data !== undefined && data.entry_list !== undefined) {
		var employeeList = data.entry_list;
		var employeeTotal = [0,0,0,0,0,0,0,0,0,0,0,0,0,0];
		for (var i = 0; i < employeeList.length; i++) {
			var employee = employeeList[i];
			forumObj += '<div class="umar-a c-wh uc-a1 uba b-gra">';
			forumObj += '<div class="ub ub-f1 umar-t uinn3 ubb  b-gra">';
			forumObj +='<div class="ub ub-f1 "><div class="ub-f1 uinn3">' + employee.last_name + '</div><div class="ub-f1 uinn3 ufr tx-r t-gra1">'+ employee.groupname + '</div></div>';
			forumObj += '</div>';
			forumObj += '<div class="ub ub-ver b-gra c-wh" >';
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[0] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.oldAccountNum+'</div></div>';//老客户

				employeeTotal[0] += int(employee.oldAccountNum);
				if(employee.newAccountNum == 0){
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[1] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.newAccountNum+'</div></div></div>';//新客户
				}else{
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[1] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Accounts\','+employee.id+',\''+employeeItem[1]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.newAccountNum+'</a></div></div></div>';//新客户
				}		
				employeeTotal[1] += int(employee.newAccountNum);
				
				if(employee.completeTaskNum == 0){
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[2] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.completeTaskNum+'</div></div>';//日程安排	

				}else{
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[2] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Calendar\','+employee.id+',\''+employeeItem[2]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.completeTaskNum+'</a></div></div>';//日程安排	
					
				}				
				employeeTotal[2] += int(employee.completeTaskNum);
				
				if(employee.newNoteNum == 0){
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[3] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.newNoteNum+'</div></div></div>';//联系记录	
				
				}else{
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[3] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Notes\','+employee.id+',\''+employeeItem[3]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.newNoteNum+'</a></div></div></div>';//联系记录	
				
				}	
				employeeTotal[3] += int(employee.newNoteNum);
							
				if(employee.newPotentialNum == 0){
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[4] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.newPotentialNum+'</div></div>';//销售机会
					
				}else{
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[4] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Potentials\','+employee.id+',\''+employeeItem[4]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.newPotentialNum+'</a></div></div>';//销售机会	
				}	
				employeeTotal[4] += int(employee.newPotentialNum);
							
				if(employee.newPotentialPrice == 0){
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[5] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.newPotentialPrice+'</div></div></div>';//机会金额	
				}else{
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[5] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Potentials\','+employee.id+',\''+employeeItem[4]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.newPotentialPrice+'</a></div></div></div>';//机会金额	
				}	
				employeeTotal[5] += int(employee.newPotentialPrice);
							
				if(employee.newQuoteNum == 0){
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[6] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.newQuoteNum+'</div></div>';//报价单

				}else{
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[6] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Quotes\','+employee.id+',\''+employeeItem[6]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.newQuoteNum+'</a></div></div>';//报价单
					
				}	
				employeeTotal[6] += int(employee.newQuoteNum);
				
				if(employee.newQuotePrice == 0){
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[7] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.newQuotePrice+'</div></div></div>';//报价金额	
				}else{
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[7] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Quotes\','+employee.id+',\''+employeeItem[8]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.newQuotePrice+'</a></div></div></div>';//报价金额	
			
				}	
				employeeTotal[7] += int(employee.newQuotePrice);
								
				if(employee.newSONum == 0){
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[8] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.newSONum+'</div></div>';//合同订单
				}else{
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[8] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'SalesOrder\','+employee.id+',\''+employeeItem[8]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.newSONum+'</a></div></div>';//合同订单

				}	
				employeeTotal[8] += int(employee.newSONum);
				
				if(employee.salesAmountNum == 0){
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[9] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.salesAmountNum+'</div></div></div>';//销售额
				}else{
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[9] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'SalesOrder\','+employee.id+',\''+employeeItem[8]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.salesAmountNum+'</a></div></div></div>';//销售额
			
				}	
				employeeTotal[9] += int(employee.salesAmountNum);
					
				if(employee.gatheredNum == 0){
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[10] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.gatheredNum+'</div></div>';//已收款
			
				}else{
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[10] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Gathers\','+employee.id+',\''+employeeItem[10]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.gatheredNum+'</a></div></div>';//已收款
				}
				employeeTotal[10] += int(employee.gatheredNum);
				
				//added by ligangze on 2014-4-14
				if(employee.ungatheredNum == 0){
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[11] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.salesAmountNum+'</div></div></div>';//未收款
				}else{
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[11] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'UnGathers\','+employee.id+',\''+employeeItem[11]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.ungatheredNum+'</a></div></div></div>';//未收款
			
				}
				employeeTotal[11] += int(employee.ungatheredNum);
				
				if(employee.billingAmount == 0){
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[12] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.billingAmount+'</div></div>';//发票金额
			
				}else{
					forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[12] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'Billings\','+employee.id+',\''+employeeItem[12]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.billingAmount+'</a></div></div>';//发票金额
				}
				employeeTotal[12] += int(employee.billingAmount);
				//added by ligangze on 2014-06-17
				if(employee.saleCommissionAccount == 0){
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[13] +'</div><div class="ub-f1 ub-con uinn13">'+ employee.saleCommissionAccount+'</div></div></div>';//销售提成金额
				}else{
					forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[13] +'</div><div class="ub-f1 ub-con uinn13"><a onclick="openDetailTab(\'SalesCommisionTotal\','+employee.id+',\''+employeeItem[13]+'\',\''+employee.last_name+'\',\'\');return false;" href="">'+ employee.saleCommissionAccount+'</a></div></div></div>';//销售提成金额
				}
				employeeTotal[13] += int(employee.saleCommissionAccount);
				//forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">&nbsp;</div><div class="ub-f1 ub-con uinn13">&nbsp;</div></div></div>';//空
				
			forumObj += '</div></div>';
		}
		forumObj +='</div>';
		if (employeeList.length == 0) {
			forumObj += showNotRecordDiv();
		}else {
			forumObj +='<div class="umar-a uc-a1 uba c-wh b-gra">';
			forumObj += '<div class="ub ub-f1 umar-t uinn3 ubb b-gra">';
			forumObj += '<div class="ub-f1 detail_nr ub t-bla">&nbsp;<span class="li_2_text ub-f1">总计<span></div>';
			forumObj += '</div>';
			forumObj += '<div class="ub ub-ver b-gra" style="background-color:#FFFFCC">';
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[0] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[0]+'</div></div>';//老客户
			forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[1] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[1]+'</div></div></div>';//新客户
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[2] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[2]+'</div></div>';//日程安排	
			forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[3] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[3]+'</div></div></div>';//联系记录	
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[4] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[4]+'</div></div>';//销售机会
			forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[5] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[5]+'</div></div></div>';//机会金额
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[6] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[6]+'</div></div>';//报价单
			forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[7] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[7]+'</div></div></div>';//报价金额
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[8] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[8]+'</div></div>';//合同订单
			forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[9] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[9]+'</div></div></div>';//销售额
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[10] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[10]+'</div></div>';//已收款
			forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[11] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[11]+'</div></div></div>';//未收款
			forumObj += '<div class="ub ulev0 ubb b-gra t-bla"><div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[12] +'</div><div class="ub-f1 ub-con uinn13">'+ employeeTotal[12]+'</div></div>';//发票金额
			forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+employeeItem[13]+'</div><div class="ub-f1 ub-con uinn13">'+employeeTotal[13]+'</div></div></div>';//销售提成金额
			forumObj += '</div></div></div>';
		}
	}
	
	setHtml("performances_list", forumObj);
}

PEObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	var CurrentPerformanceModule = getstorage("CurrentPerformanceModule");
	var CurrentPerformanceRecord = getstorage("CurrentPerformanceRecord");
	var startDate = getstorage("startDate");
	var endDate = getstorage("endDate");
	this.method = 'getPerformanceDetails';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"performanceModule":"'+CurrentPerformanceModule+'",' +
		'"record":"'+CurrentPerformanceRecord+'",' +
		'"offset":"","max_results":"' + RowsPerPageInListViews +'",' +
		'"startDate":"'+startDate+'",' +
		'"endDate":"' + endDate + '"}';
	if(CurrentPerformanceModule == 'Quotes' || CurrentPerformanceModule == 'SalesOrder' || CurrentPerformanceModule == 'Gathers'|| CurrentPerformanceModule == 'Calendar' || CurrentPerformanceModule == 'UnCalendar'){
		this.comment = false;
	}
	this.RequestServer();
}; 

PEObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var forumObj = '';
	var detailObj = data;
	//document.write(data);
	for (var i = 0; i < detailObj.length; i++) {
		var entries = detailObj[i].entries;
		forumObj += '<div class="ub ub-f1 umar-t uinn3 uba c-wh uc-t1 b-gra">';
			forumObj += '<div class="ub-f1 detail_nr ub t-bla">' + entries[0].value + '</div>';
		forumObj += '</div>';
		forumObj += '<div class="ub ub-ver uc-b1 b-gra ubl ubr ubb c-wh" >';
		
		for(var j = 1; j < entries.length; j++) {
			if(entries[j].value == null){
				entries[j].value = '';
			}
			forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
			forumObj += '<div class="detail_bt t-gra1">' + entries[j].name + '</div>';
			forumObj += '<div class="ub-f1 detail_nr ub">' + entries[j].value + '</div>';
			forumObj += '</div>';
		}
		forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
		forumObj += '<div class="detail_bt t-gra1">点评</div>';
		forumObj += '<div class="detail_nr"><div ontouchstart="zy_touch(\'btn-act\')" onclick="openCommentPage(\''+detailObj[i].crmid+'\');" class="uinn4 t-blu3 tx_bold">查看/添加点评</div></div>';
		forumObj += '</div>';
		forumObj += '</div>';
	}
	setHtml("performancedetails_list", forumObj);
}

PEObj.prototype.GetComments=function(){  //获取评论(实例方法)
	var crmid = getstorage("commentCrmid");
	this.method = 'get_performances_comments';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
				'"crmid":"' + crmid + '"}';
	this.RequestServer();
}; 

PEObj.prototype.ShowCommentsList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	var headerArr = data.header;
	var entries_list = data.entries;
	setHtml('CommentDescriptionP', data.modulestr);
	for (var i = 0; i < entries_list.length; i++) {
		var entries = entries_list[i];
		if (entries.userPhoto == '') {
			entries.userPhoto = "../../css/images/avatar_default1299eb.png";
		}
		forumObj +='<div class="ub t-bla umh4 lis3">';
		forumObj +='<div class="avatar">';
			forumObj +='<img src=\"'+entries.userPhoto+'\"/>';
		forumObj +='</div>';
		forumObj +='<div class="ub-f1 ub ub-ver lis3">';	
			forumObj +='<div class="ub ub-hor umar-b">'; 
				forumObj +='<div class="ub-f1 ub-hor ufl ulev-1 tx_bold">'; 
					forumObj +='<div class="umar-l">';
						forumObj +='<span>'+entries.username+'</span>';
					forumObj +='</div>'; 
				forumObj +='</div>'; 
				forumObj +='<div class="ub ub-hor ufr ulev-2">'; 
				forumObj +='<div class="umar-r">';
					forumObj +='<span class="t-gra" >'+entries.seq+'</span><span >#</span>';
				forumObj +='</div>';
			forumObj +='</div>'; 	  
			forumObj +='</div>';	 
			forumObj +='<div class="ub ub-ac t-gra ulev-2 umar-t">'; 
				forumObj +='<div class="ub-f1 ub ub-hor ufl">'; 
					forumObj +='评论于<div class="umar-l">'+entries.createdtime+'</div>';
				forumObj +='</div>'; 
			forumObj +='</div>';	 
		forumObj +='</div>'; 
		forumObj +='</div>';  
		 
		forumObj +='<div class="ub ub-ver">'; 
		forumObj +='<div class="umar-a linh2 ulev0" >';
			forumObj +='<div class="arrow_box uc-a1 uinn" >'+entries.content+'</div>';
		forumObj +='</div>';
		forumObj +='</div>';
		forumObj += '</div>';
	}
	if(entries_list.length == 0){
		forumObj +='<div class="uinn">'
		forumObj +='<ul class="ub b-gra ub-ac lis c-wh uc-a1 uba  uinn ">';
		forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">还没有一个人评论啊!...</li>';  
		forumObj +='</ul></ul>';
		forumObj +='</div>';
	}
	setHtml("otherlists", forumObj);
}

PEObj.prototype.SaveComment=function(){  //添加评论(实例方法)
	var crmid = getstorage("commentCrmid");
	var content = removeHTMLTag(tt)
	if (content == '') {
		uexWindow.toast('0', '5', "评论内容不能为空", '1500');
		return false;
	}
	this.method = 'saveComments';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
				'"crmid":"'+crmid+'",' +
				'"content":"'+content+'"}';
	this.tip = 0;
	this.RequestServer();
}; 

PEObj.prototype.SaveCommentReturn=function(data){  //完成保存(实例方法)
	uexWindow.toast(0, 5, "评论成功", 2000);
	uexWindow.evaluatePopoverScript("CommentPage", "content", "setRelativeBind()");
}; 

function openDetailTab(module,record,item,employeename,res){
	setstorage('CurrentPerformanceModule', module);
	setstorage('CurrentPerformanceRecord', record);
	setstorage('CurrentPerformanceItem', item,false);
	setstorage('CurrPerfEmplName', employeename);
	openwin('PerformanceDetailsPage',res);
}

function openCommentPage(crmid){
	setstorage('commentCrmid', crmid);
	openwin('CommentPage','');
}
