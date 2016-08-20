/**
* 应收款
*/
function GATObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      GATObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
	this.startDate = formatDate(myDate);
	this.endDate = formatDate(new Date(myDate.getTime()+30*24*60*60*1000));//30天以内
};

GATObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_gathers_entry_list':
			this.ShowList(data);
			break;
	}
};  

GATObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = 1;
	if(searchtext == '2'){//本月初到今日
		this.startDate = formatDate(new Date(myDate.getFullYear(),myDate.getMonth(), 1));
		this.endDate = formatDate(myDate);
		dateSel = 2;
	}else if(searchtext == '3'){//上月
		var month = myDate.getMonth()-1;
		var year = myDate.getFullYear();
		if(month == -1) {
	        year = year-1;
	        month = 11;
	    }
		var startDate = new Date(year,month, 1);
		var monthEndDate = new Date(startDate);
		monthEndDate.setMonth(startDate.getMonth()+1);
		monthEndDate.setDate(0);
		this.startDate = formatDate(startDate);
		this.endDate = formatDate(monthEndDate);
		dateSel = 2;
	}else{
		this.startDate = formatDate(myDate);
		this.endDate = formatDate(new Date(myDate.getTime()+30*24*60*60*1000));//30天以内
		dateSel = 1;
	}
	this.method = 'get_gathers_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
				'"startDate":"'+this.startDate+'",' +
				'"endDate":"'+this.endDate+'",' +
                '"query":"'+dateSel+'",' +
                '"offset":' + this.offset + ',' +
                '"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}; 

GATObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	if(data.entry_list.islook !== undefined && data.entry_list.islook == 'no'){//列表加权限 added by ligangze on 2014/8/22
		forumObj += showNotPermittedDiv();
		setHtml("gathers_list", forumObj);
		return false;
	}
	
	if (data !== undefined && data.entry_list !== undefined) {
		var gatherList = data.entry_list;
		for (var i = 0; i < gatherList.length; i++) {	
			var gather = gatherList[i].entries;
			forumObj += '<div class="ub ub-f1 umar-t uinn3 uba c-wh uc-t1 b-gra">';
			forumObj += '<div class="ub-f1 ub t-bla">' + gather.gathername.value + '</div>';
			forumObj += '</div>';
			forumObj += '<div class="ub ub-ver uc-b1 b-gra ubl ubr ubb c-wh" >';
			
			forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
			forumObj += '<div class="detail_bt t-gra1">' + gather.plandate.name + '</div>';
			forumObj += '<div class="ub-f1 detail_nr ub">' + gather.plandate.value + '</div>';
			forumObj += '</div>';
			
			forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
			forumObj += '<div class="detail_bt t-gra1">' + gather.planamount.name + '</div>';
			forumObj += '<div class="ub-f1 detail_nr ub">' + gather.planamount.value + '</div>';
			forumObj += '</div>';
			
			forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
			forumObj += '<div class="detail_bt t-gra1">' + gather.gatherstatus.name + '</div>';
			forumObj += '<div class="ub-f1 detail_nr ub">' + gather.gatherstatus.value + '</div>';
			forumObj += '</div>';
			
//			forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
//			forumObj += '<div class="detail_bt t-gra1">' + gather.isinvoice.name + '</div>';
//			forumObj += '<div class="ub-f1 detail_nr ub">' + gather.isinvoice.value + '</div>';
//			forumObj += '</div>';
			
			forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
			forumObj += '<div class="detail_bt t-gra1">' + gather.accountname.name + '</div>';
			forumObj += '<div class="ub-f1 detail_nr ub">' + gather.accountname.value + '</div>';
			forumObj += '</div>';
			
			forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
			forumObj += '<div class="detail_bt t-gra1">' + gather.user_name.name + '</div>';
			forumObj += '<div class="ub-f1 detail_nr ub">' + gather.user_name.value + '</div>';
			forumObj += '</div>';
			forumObj += '</div>';
		}
	}
	if(gatherList.length == 0){
		forumObj += showNotRecordDiv();
	}
	setHtml("gathers_list", forumObj);
	var patotal = 0;
	if(data.patotal){
		patotal = data.patotal;
	}
	uexWindow.evaluateScript('GathersListPage','0',"setpatotal(\'"+patotal+"\')");
	if(data.lastpg > 0){
		setstorage('currPage', this.offset);
		setstorage('lastPage', data.lastpg);
		uexWindow.evaluatePopoverScript('GathersListPage','pop_nav',"setPageSel()");
	}
}
