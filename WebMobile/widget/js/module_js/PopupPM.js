/**
 * 短消息
 */
function PMObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      PMObj.prototype[attr] = Module.prototype[attr];
	};
	this.pageArr = ['',1,1,1];
	this.pageLastArr = ['',1,1,1];
	this.pageName = 1;
	this.delType = 3;
};

PMObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_entry_list':
			this.ShowList(data);
			break;
		case 'getReceivers':
			this.ShowReceiveOpts(data);
			break;
		case 'sendNewPM':
			this.SendPMReturn(data);
			break;
		case 'get_entry':
			this.ShowDetail(data);
			break;
		case 'replyPM':
			this.ReplyPMReturn(data);
			break;
		case 'deletePM':
			this.DeletePMReturn(data);
			break;
	}
}; 

PMObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	var viewsel = this.pageName;   //
	this.method = 'get_entry_list';
	this.tip = 1;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"query":"'+searchtext+'",' +
        '"offset":' + this.pageArr[this.pageName] + ',' +
        '"max_results":' + RowsPerPageInListViews + ',' +
        '"sel":"'+viewsel+'"}';
	this.RequestServer();
}; 

PMObj.prototype.GetListDataFromServer=function(){  //获取列表(实例方法)
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	var viewsel = 1;   //
	this.method = "get_entry_list";
	//alert(getstorage("SugarSessionId"));
	//this.CurrentUserId
	var userid = getstorage("SugarSessionId");
	this.rest_data = '{"session":"' + userid + '",' +
        '"module_name":"'+this.name+'",' +
        '"query":"'+searchtext+'",' +
        '"offset":' + page_pm_offset + ',' +
        '"max_results":' + RowsPerPageInListViews + ',' +
        '"sel":"'+viewsel+'"}';
	var url = this.AjaxUrl+'/rest.php?callback=?&rest_data='+encodeURIComponent(this.rest_data)+'&method='+this.method;
	//this.ShowLoadTips(); 
	$('#refreshPmIcon').show();
	$.getJSON(url,ShowPmList);
}; 

function ShowPmList(data){ //显示列表(实例方法)
	//uexWindow.closeToast();
	$('#refreshPmIcon').hide();
	var forumObj = '';
	var listObj = data;
	//$('#morepm').before(JSON.stringify(listObj));
	
	//alert(JSON.stringify(listObj));
	if ((listObj !== undefined) && (listObj.entry_list !== undefined)) {
		var i = 0;
		for (i = 0; i < listObj.entry_list.length; i++) {
			var whitebg = "c-wh";
			if(i%2==0)
				whitebg = "c-gra4";
			if (listObj.entry_list[i] !== undefined) {
				var theBill = listObj.entry_list[i];
				var theBillPText = '';
				var tStyle = "ub ub-f1 b-gra ub-ac lis";
				if(theBill.name_value_list.received.value == 0){
					tStyle = "ub ub-f1 b-gra ub-ac lis tx_bold";
				}
				forumObj += '<div class="ub ubb b-gra ">';
					forumObj +='<div class="ub-f1  b-gra pmli '+whitebg+'" style="z-index:2;"><ul class="'+tStyle+'">';
						forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub">';
						forumObj +='<div class="ub-f1">'+theBill.name_value_list.sender.value+'</div>';  
						forumObj +='<div class="ub-f1"><span class="li_3" style="float:right;color: #999999;">'+theBill.name_value_list.stamp.value+'</span></div></li>';
						forumObj +='<li class="ub li_1_1 ">'+theBill.name_value_list.message.value +'</li>';
					forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
					forumObj += '<input value="'+theBill.id+'" class="uhide">';
					forumObj += '<input value="'+theBill.name_value_list.received.value+'" class="uhide">';
					forumObj +='</div>';
					forumObj += '<div class="ub ub-ac ub-pc c-wh t-red deletepm" style="position:absolute;width:2em;font-size:1.5em;height:100%;left:0;z-index:1" onclick="deletediv(event);"><i class="icon ion-ios7-minus"></i></div>';
				forumObj +='</div>';
			}
		}
		if(page_pm_offset == 1){
			$('.pmli').parent().remove();
		}
		$('#morepm').before(forumObj);
		page_pm_last = listObj.lastpg;
		if(page_pm_offset<page_pm_last){
			$('#morepm').show();
		}else{
			$('#morepm').hide();
		}
		page_pm_offset++;
	}
}
	
PMObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	var listObj = data;
	if ((listObj !== undefined) && (listObj.entry_list !== undefined)) {
		var i = 0;
		for (i = 0; i < listObj.entry_list.length; i++) {
			var whitebg = "c-wh";
			if(i%2==0)
				whitebg = "";
			if (listObj.entry_list[i] !== undefined) {
				var theBill = listObj.entry_list[i];
				var theBillPText = '';
				var tStyle = "ub ub-f1 b-gra ub-ac lis";
				if(theBill.name_value_list.received.value == 0){
					tStyle = "ub ub-f1 b-gra ub-ac lis tx_bold";
				}
				forumObj += '<div class="ub ubb b-gra '+whitebg+'">';
					forumObj += '<input type="checkbox" name="check_Pm" value="'+theBill.id+'" class="uhide b-gra">';
					forumObj += '<div onclick="zy_for_sop(event)" ontouchstart="zy_touch(\'btn-act\')" class="ub b-gra uinn3" style="width:6%">';	 
					forumObj += '<div class="che-icon ub-img umw1"></div></div>';
					
					forumObj +='<div class="ub-f1"><ul onclick="readPM(event,'+theBill.id+')" class="'+tStyle+'">';
						forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub">';
						forumObj +='<div class="ub-f1">'+theBill.name_value_list.sender.value+'</div>';  
						forumObj +='<div class="ub-f1"><span class="li_3" style="float:right;color: #999999;">'+theBill.name_value_list.stamp.value+'</span></div></li>';
						forumObj +='<li class="ub li_1_1 ">'+theBill.name_value_list.message.value +'</li>';
					forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
					forumObj += '<input type="text" value="'+theBill.name_value_list.received.value+'" class="uhide b-gra">';
					forumObj +='</div>';
				forumObj +='</div>';
			}
		}
		var cContent = $$('list'+this.pageName);
		if(this.pageArr[this.pageName] == 1){
			cContent.innerHTML='<div></div>';
			if(listObj.entry_list.length == 0){
				forumObj += showNotRecordDiv();  
			}
		}
		var node = document.createElement("div");
		node.innerHTML = forumObj;
		cContent.insertBefore(node,cContent.lastElementChild);
		this.pageLastArr[this.pageName] = listObj.lastpg;
		if(this.pageArr[this.pageName]<this.pageLastArr[this.pageName]){
			$$('more').className='c-gra';
		}else{
			$$('more').className='uhide';
		}
	}
	this.pageArr[this.pageName]++;
}

PMObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentPMId = getstorage("CurrentPMId");  //id
	this.method = 'get_entry';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentPMId + '"}';
	this.RequestServer();
}; 

PMObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var detailObj = data;
	var forumObj = '';
	var entry_list = data;
	if (entry_list !== undefined) {
		var i = 0;
		if(entry_list[0].name_value_list.sender.value != 'System'){
			uexWindow.evaluateScript('PMDetailsPage','0','showHuifu()');
		}
		for (i = 0; i < entry_list.length; i++) {
			if (entry_list[i] !== undefined) {
				var theBill = entry_list[i];
				var theBillPText = '';
				var sender = theBill.name_value_list.sender.value;
				if (theBill.name_value_list.isMe.value == 1) {	
					forumObj += '<div class="chatItem me">';
				}else{
					forumObj += '<div class="chatItem you">';
					//sender = "他/她";
				}
				if (theBill.name_value_list.userPhoto.value == '') {
					theBill.name_value_list.userPhoto.value = "../../css/images/avatar_default1299eb.png";
				}
				forumObj += '<div class="time ulev-1 tx-c">';
				forumObj += theBill.name_value_list.stamp.value+'</div>';
				forumObj += '<div class="chatItemContent">';
					//forumObj += '<div class="avatar tx-c t-gra ulev-1 long_hide">'+sender+'</div>';
					forumObj += '<div class="avatar1"><div class="ub-f1 ub-ver"><div class="avatar"><img src=\"'+theBill.name_value_list.userPhoto.value+'\" style="width:3.4em;height:3.4em"/></div><div class="ub-f1 tx-c t-gra ulev-1 uinn long_hide">'+sender+'</div></div></div>';
					forumObj += '<div class="cloud cloudText">';
						forumObj += '<div class="cloudPannel">';
							forumObj += '<div class="cloudBody">';
								forumObj += '<div class="cloudContent">';
									forumObj += '<span style="white-space:pre-wrap">'+theBill.name_value_list.message.value+'</span>';
								forumObj += '</div>';
							forumObj += '</div>';
							forumObj += '<div class="cloudArrow"></div>';
						forumObj += '</div>';
					forumObj += '</div>';
				forumObj += '</div></div>';
			}
		}
		var cContent = $$('details_list');
		cContent.innerHTML='<div></div>';
		var node = document.createElement("div");
		node.innerHTML = forumObj;
		cContent.insertBefore(node,cContent.lastElementChild);
	}
}

PMObj.prototype.changeList = function(n){  //切换列表(实例方法)
  	$$('list1').className="c-wh uhide";
	$$('list2').className="c-wh uhide";
	$$('list3').className="c-wh uhide";
	$$('more').className="c-gra uhide";
	$$('list'+n).className="c-wh";	
	this.pageName = n;
	this.searchList();
}

PMObj.prototype.getList = function(n){  //获取列表(实例方法)
	uexWindow.resetBounceView('0');
	this.pageName = n;
	this.GetListFromServer();
}; 

PMObj.prototype.searchList = function(){  //搜索列表(实例方法)
	uexWindow.resetBounceView('0');
	this.pageArr[pmobj.pageName] = 1;
	this.pageLastArr[pmobj.pageName] = 1;
	this.GetListFromServer();
}; 

PMObj.prototype.receivePM = function(id){ //读短消息(实例方法)
	this.method = 'receivePM';
	this.tip = 2;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"record":"'+id+'"}';
	this.RequestServer();
}; 

PMObj.prototype.receivePM_home = function(id){ //读短消息(实例方法)
	this.method = 'receivePM';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"record":"'+id+'"}';
	var url = this.AjaxUrl+'/rest.php?callback=?&rest_data='+encodeURIComponent(this.rest_data)+'&method='+this.method;
	$.getJSON(url,receivePm_result);
}; 

function receivePm_result(data){
	
}

PMObj.prototype.SendPM = function(){ // 发送短消息(实例方法)
	var recipient = receiverid.join(',');
	$$("text").value = removeHTMLTag($$("text").value);
	if (recipient == '') {
		uexWindow.toast('0', '5', "接收者不能为空", '1500');
		return false;
	}
	var message = $$("text").value;
	if (message == '') {
		uexWindow.toast('0', '5', "内容不能为空", '1500');
		return false;
	}
	this.method = 'sendNewPM';
	this.tip = 0;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"recipient":"'+recipient+'",' +
        '"message":"'+encodeURIComponent(message)+'"}';
	this.RequestServer();
}; 

PMObj.prototype.SendPMReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		closeWin();
		uexWindow.evaluateScript('PMListPage','0','ppobj.searchPM()');
	}else if(data.result === "FAIL"){
		uexWindow.toast(0, 5, "发送失败", 2000);
	}
}; 

PMObj.prototype.ReplyPM = function(){ // 回复短消息(实例方法)
	var message = removeHTMLTag(tt)
	if (message == '') {
		uexWindow.toast('0', '5', "内容不能为空", '1500');
		return false;
	}
	this.CurrentPMId = getstorage("CurrentPMId");  //id
	this.method = 'replyPM';
	this.tip = 0;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"record":"'+this.CurrentPMId+'",' +
        '"message":"'+encodeURIComponent(message)+'"}';
	this.RequestServer();
}; 

PMObj.prototype.ReplyPMReturn=function(data){  //回复保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.evaluatePopoverScript('PMDetailsPage','content','pmobj.setDetailsInfo()');
		uexWindow.evaluateScript('PMListPage','0','ppobj.searchPM()');
	}else if(data.result === "FAIL"){
		uexWindow.toast(0, 5, "回复失败", 2000);
	}
}; 

PMObj.prototype.DeletePM = function(type){ // 删除短消息(实例方法)
	this.method = 'deletePM';
	this.tip = 0;
	var ids = '';
	if(type == 1){   //删除所选择的
		ids = getCheckBoxValue();
	}
	if(type == 2){   //删除全部
		ids = getAllCheckBoxValue();;
	}
	if(type == 3){   //删除当前正在看的
		this.CurrentPMId = getstorage("CurrentPMId");  //id
		ids = this.CurrentPMId;
	}
	this.delType = type;
	if(ids == ''){
		return;
	}
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"record":"'+ids+'"}';
	this.RequestServer();
}; 

PMObj.prototype.DeletePM_home = function(id){ // 删除短消息(实例方法)
	this.method = 'deletePM';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"record":"'+id+'"}';
		alert(this.rest_data);
	var url = this.AjaxUrl+'/rest.php?callback=?&rest_data='+encodeURIComponent(this.rest_data)+'&method='+this.method;
	$.getJSON(url,deletePM_result);
}; 

function deletePM_result(data){
	alert('ssss');
}

PMObj.prototype.DeletePMReturn=function(data){  //删除后返回(实例方法)
	if (data.result === "SUCCESS") {
		if (this.delType == 3) {
			uexWindow.evaluateScript('PMListPage', '0', 'ppobj.searchPM()');
			back();
		}else{
			uexWindow.evaluateScript('PMListPage', '0', 'ppobj.searchPM()');
		}
	}else if(data.result === "FAIL"){
		uexWindow.toast(0, 5, "删除失败", 2000);
	}
}; 

function readPM(e,id){
	setstorage('CurrentPMId', id);
	openwin('PMDetailsPage','');
	var a = e.currentTarget.nextElementSibling;
	if(a.value == 0){
		e.currentTarget.className = 'ub b-gra ub-ac lis';
		a.value = 1;
		pmobj.receivePM(id);
	}
}

function zy_fold_sfa(e, col){
    var a = e.currentTarget.nextElementSibling;
    if (a.nodeName == "DIV") {
        if (col) 
			a.className = a.className.replace("col-c", "");
        else 
			a.className += 'col-c';
    }
}

//勾选复选框
function zy_for_sop(e) {
	var ch = e.currentTarget.previousElementSibling;
	if (ch.nodeName == "INPUT") {
		if (ch.type == "checkbox")
			ch.checked = !ch.checked;
	}
}

function getCheckBoxValue(){
	var check_Pms = '';
	var arr = document.getElementsByName("check_Pm");
	for (var n = 0; n < arr.length; n++) {
		if (arr[n].type == 'checkbox' && arr[n].checked) {
			check_Pms += arr[n].value+','; 
		}
	}
	return check_Pms;
}

function getAllCheckBoxValue(){
	var check_Pms = '';
	var arr = document.getElementsByName("check_Pm");
	for (var n = 0; n < arr.length; n++) {
		if (arr[n].type == 'checkbox') {
			check_Pms += arr[n].value+','; 
		}
	}
	return check_Pms;
}

