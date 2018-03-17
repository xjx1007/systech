/**
 * 客户
 */
set_input_msg();
function ACObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      ACObj.prototype[attr] = Module.prototype[attr];
	};
	
	this.offset = 1;
	this.CurrentAccountId = 0;
	this.reType = '';
	this.mode = '';
	this.theWindow = '';
};

ACObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	var viewscope = getstorage("viewscope");//查看范围 1我的客户 2 所有客户 3 下属客户
	var viewsel = getstorage("account_viewId");   //视图id
	this.method = 'get_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"query":"'+searchtext+'",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + ',' +
        '"sel":"'+viewsel+'", '+
		'"viewscope":"'+viewscope+'"}';
	this.RequestServer();
}; 

ACObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	if(data.entry_list.islook !== undefined && data.entry_list.islook == 'no'){//列表加权限 added by ligangze on 2014/8/22
		forumObj += showNotPermittedDiv();
		setHtml("account_list", forumObj);
		return false;
	}else{
		uexWindow.evaluateScript('AccountsListPage', '0', "showCreateButton()");
	}
	//alert(JSON.stringify(data.entry_list));
	var accountsList = data;
	//alert(accountsList.entry_list);
	var whitebg = '';
	if ((accountsList !== undefined) && (accountsList.entry_list !== undefined)) {		
		var intAccount = 0;
		for (intAccount = 0; intAccount < accountsList.entry_list.length; intAccount++) {
			if(intAccount%2!=0)
				whitebg = "c-wh";
			else
				whitebg = '';	
			if (accountsList.entry_list[intAccount] !== undefined) {
				var account = accountsList.entry_list[intAccount];
				forumObj +='<ul onclick="openAccountDetail('+account.id+',\'\');" class="ub ub-ac lis act-wh '+whitebg+'">';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub ub-f1"><div class="li_2_2 ub-f1"><i class="icon-home"></i>&nbsp;<span class="li_2_text">'+account.name_value_list.name.value+'</span></div></li>';
				var keyContact = '';
				if(isDefine(account.name_value_list.keycontact.value)){  //如果设置了首要联系人
					keyContact += '<i class="icon-user"></i>&nbsp;<span >'+account.name_value_list.keycontact.value+'</span>:';
					if(isDefine(account.name_value_list.keycontact.value)){  //首要联系人设置了手机
						keyContact += '<i class="icon-phone"></i>&nbsp;'+account.name_value_list.keymobile.value;
					}
					if(isDefine(account.name_value_list.keyqq.value)){   //首要联系人设置了QQ
						keyContact += '<i class="icon-qq"></i>&nbsp;'+account.name_value_list.keyqq.value;
					}
				}
				forumObj +='<li class="li_2_2">'+keyContact+'</li>';  
				if (isDefine(account.name_value_list.latestnote.value)) {
					forumObj += '<li class="li_2_2"><i class="icon-calendar"></i>&nbsp;' + account.name_value_list.latestnote.value + '</li>';
				}
				forumObj +='</ul><div class="ufr li_4">'+account.name_value_list.rating.value+'</div></ul>';
			}
		}
		if(accountsList.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("account_list", forumObj);
		if(accountsList.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', accountsList.lastpg);
			uexWindow.evaluatePopoverScript('AccountsListPage','pop_nav',"setPageSel()");
		}
	}	
}

ACObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentAccountId = getstorage("CurrentAccountId");   //客户id
	this.method = 'get_entry';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentAccountId + '"}';
	this.RequestServer();
}; 

ACObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){
		forumObj += showNotPermittedDiv();
		setHtml("accountdetails_list", forumObj);
		return false;
	}

	if(data.isedit == 'yes'){
		uexWindow.evaluateScript('AccountDetailsPage', '0', "showEditButton()");
	}
	var detailObj = data.details;
	if ((detailObj !== undefined) && (detailObj.entry_list !== undefined)) {
		var order = detailObj.entry_list;
		var listlen = order.length;
		var subname =  order[0].field[0].value;
		currAccObj = {
			id:getstorage("CurrentAccountId"),
			name:subname
		}
		for(var i=0;i<listlen;i++){
			var field = order[i].field;
			var fieldlen = field.length;
			var notNulls = 0; 
			for (var k = 0; k < fieldlen; k++) {
				if (!isDefine(field[k].value)) {
					continue;
				}
				notNulls++;
			}
			if(notNulls==0)continue;
			forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">' + order[i].title + '</div>';
			forumObj += '</div>';
			var nn = 0;
			for (var j = 0; j < fieldlen; j++) {
				if (!isDefine(field[j].value)){
					continue;
				}
				nn++;
				var div_class = 'class="ub ub-f1 t-bla ulab ub-ac lis ubb b-gra"';
				if (nn == notNulls) {
					div_class = 'class="ub ub-f1 t-bla ulab ub-ac lis"';
				}
				if (field[j].name == "电话" || field[j].name == '办公电话'|| field[j].name == '手机') {
					field[j].value = '<div onclick="phonedial(\'' + field[j].value + '\');" class="uinn4 c-wh c-m2 t-blu3">'+field[j].value+'</div>';
				}else if (field[j].name == 'Email') {
					field[j].value = '<div onclick="mailsend(\'' + field[j].value + '\');" class="uinn4 c-wh c-m2 t-blu3 ">'+field[j].value+'</div>';
				}else if (field[j].name == '网站') {
					field[j].value = '<div onclick="openwebsite(\'' + field[j].value + '\');" class="uinn4 c-wh c-m2 t-blu3">'+field[j].value+'</div>';
				}else if (field[j].link == 1) {
					field[j].value = '<div onclick="openDetailTab(\''+field[j].re_module+'\',\''+field[j].link_id+'\',\''+field[j].link_modulename+'\',\'../\');" class="uinn4 c-wh c-m2 t-blu3">'+field[j].value+'</div>';
				}
				forumObj += '<div ' + div_class + '>';
				forumObj += '<div class="detail_bt t-gra1">' + field[j].name + ' </div>';
				forumObj += '<div class="ub-f1 detail_nr ub">' + field[j].value + '</div>';
				forumObj += '</div>';
			}
			forumObj += '</div>';
		}
		var otherInfo = detailObj.other_list;

		if (otherInfo.title !== undefined) {
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">'+otherInfo.title+'</div>';
			forumObj += '</div>';
			div_class = 'class="ub ub-f1 t-bla ulab ub-ac uinn3"';
			var field = otherInfo.field;
			var fieldlen = field.length;
			for (var i = 0; i < fieldlen; i++) {
				forumObj += '<div class="ub ub-ver umar-t uc-a1 b-gra uba c-gra2 c-m22" >';
				for (var j in field[i]) {
					if (!isDefine(field[i][j])) 
						continue;
					forumObj += '<div ' + div_class + '>';
					forumObj += '<div class="detail_bt t-gra1">' + j + ':</div>';
					forumObj += '<div class="ub-f1 detail_nr ub">' + field[i][j] + '</div>';
					forumObj += '</div>';
				}
				forumObj += '</div>';
			}
		}
		forumObj += '</div>';
		setHtml("accountdetails_list", forumObj);
		var saleordernum = "";
		var contactnum = "";
		var notenum =  "";
		var potentialnum =  "";
		var mycalendarnum ="";
		var sfanum =  "";//
		var commentnum =  "";//
		
		if(data.relatedlistcount['Sales Order']!=0 && data.relatedlistcount['Sales Order']!= undefined){
			saleordernum = data.relatedlistcount['Sales Order'];
			if(saleordernum>99)
				saleordernum = 99;
				saleordernum = '<li class="related-count" >'+saleordernum+'</li>';
			
		}
		if(data.relatedlistcount['Contacts']!=0 && data.relatedlistcount['Contacts']!= undefined){
			contactnum = data.relatedlistcount['Contacts'];
			if(contactnum>99)
				contactnum = 99;
			contactnum = '<li class="related-count" >'+contactnum+'</li>';
			
		}
		if(data.relatedlistcount['Notes']!=0 && data.relatedlistcount['Notes']!= undefined){
			notenum = data.relatedlistcount['Notes'];
			if(notenum>99)
				notenum = 99;
			notenum = '<li class="related-count" >'+notenum+'</li>';
		}
		if(data.relatedlistcount['Potentials']!=0 && data.relatedlistcount['Potentials']!= undefined){
			potentialnum = data.relatedlistcount['Potentials'];
			if(potentialnum>99)
				potentialnum = 99;
			potentialnum = '<li class="related-count" >'+potentialnum+'</li>';
		}
		if(data.relatedlistcount['Mycalendars']!=0 && data.relatedlistcount['Mycalendars']!= undefined){
			mycalendarnum = data.relatedlistcount['Mycalendars'];
			if(mycalendarnum>99)
				mycalendarnum = 99;
			mycalendarnum = '<li class="related-count" >'+mycalendarnum+'</li>';
		}
		if(data.relatedlistcount['sfa']!=0 && data.relatedlistcount['sfa']!= undefined){
			sfanum = data.relatedlistcount['sfa'];
			if(sfanum>99)
				sfanum = 99;
			sfanum = '<li class="related-count" >'+sfanum+'</li>';
		}
		if(data.relatedlistcount['comment']!=0 && data.relatedlistcount['comment']!= undefined){
			commentnum = data.relatedlistcount['comment'];
			if(commentnum>99)
				commentnum = 99;
			commentnum = '<li class="related-count" >'+commentnum+'</li>';
		}
		
		relatedObj ='<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3"><div class="umar-a ub-f1 tx-c"> 相关信息</div></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'comment\')" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1"> 相关点评</li>'+commentnum+'<li class="res8 lis-sw ub-img"></li></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'contact\');" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1"> 联系人</li>'+contactnum+'<li class="res8 lis-sw ub-img"></li></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'contactRecord\');" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1"> 联系记录</li>'+notenum+'<li class="res8 lis-sw ub-img"></li></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'salesOrder\');" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1">合同订单</li>'+saleordernum+'<li class="res8 lis-sw ub-img"></li></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'potential\');" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1"> 销售机会</li>'+potentialnum+'<li class="res8 lis-sw ub-img"></li></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'mycalendar\');" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1">工作日程</li>'+mycalendarnum+'<li class="res8 lis-sw ub-img"></li></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'sfa\');" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1"> 销售自动化</li>'+sfanum+'<li class="res8 lis-sw ub-img"></li></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'markAccount\');" class="ub ub-f1 act-wh t-bla ulab ub-ac  lis">';
			relatedObj+=' <li class="ub-f1 ut-s t-gra1">标记/拜访</li><li class="res8 lis-sw ub-img"></li></div>';

		setHtml("relative",relatedObj);
		$$("relative").style.display='block';
	}
}

ACObj.prototype.setReModuleBind=function(){  //获取客户相关信息(实例方法)
	this.CurrentAccountId = getstorage("CurrentAccountId");   //客户id
	this.method = 'get_relatedlists_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"module_id":"' + this.CurrentAccountId + '",'+
		'"link_field_name":"'+this.reModule+'"}';
	this.RequestServer();
}; 

ACObj.prototype.ShowReModuleList = function(data){ //显示相关信息列表(实例方法)
	var forumObj = '';
	this.reType = getstorage('reType');
	switch(this.reType){
		case 'contact':
			forumObj += setAccountContactsBind(data);
			break;
		case 'contactRecord':
			forumObj += setAccountContactRecordsBind(data);
			break;
		case 'salesOrder':
			forumObj += setAccountSalesOrderBind(data);
			break;
		case 'potential':
			forumObj += setAccountPotentialBind(data);
			break;
		case 'mycalendar':
			forumObj += setAccountCalendarBind(data);
			break;
		case 'sfa':
			forumObj += setAccountSfaBind(data);
			break;
	}
	if(forumObj == ''){
		forumObj += showNotRecordDiv();
	}
	setHtml("records_list", forumObj);
}

ACObj.prototype.saveStartSfaList=function(sfasettingsid){  //保存要执行的SFA序列(实例方法)
	this.CurrentAccountId = getstorage("CurrentAccountId");   //客户id
	this.method = 'save_startsfalist';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"sfasettingsid":"' + sfasettingsid + '",'+
		'"accountid":"'+this.CurrentAccountId+'"}';
	this.RequestServer();
}; 

ACObj.prototype.setCreatePageBind=function(){  //创建(实例方法)
	this.theWindow = 'CreateNewPage';
	this.method = 'get_create_field';
	this.cacheFlag = true;
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'","select_fields":"","link_name_to_fields_array":""}';
	this.RequestServer();
}; 

ACObj.prototype.ShowCreatePage = function(data){ //显示创建表单(实例方法)
	var currDate = formatDate(myDate);
	var currTime = getFullFormat(myDate.getHours())+':'+getFullFormat(myDate.getMinutes());
	var endDateObj = getNextHours(currDate,currTime);
	var endDate = formatDate(endDateObj);
	var endTime = getFullFormat(endDateObj.getHours())+':'+getFullFormat(endDateObj.getMinutes());
	var forumObj = '';
	var module_name = this.name;
	var createFields = data.field;
	if ((createFields !== undefined) && (createFields.relationship_list !== undefined)) {
		var accopts = createFields.entry_list[0];
		var acclist = createFields.relationship_list;
		var acclistlen = acclist.length;
		for (var i = 0; i < acclistlen; i++) {
			forumObj += '<div class=" uc-a1 umar-a ubb_my b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">'+acclist[i].title+'</div>';
			forumObj += '</div>';
			var field = acclist[i].field;
			var fieldlen = field.length;
			for (var j = 0; j < fieldlen; j++) {
				if (field[j].display == "none") {
					continue;
				}
				if (field[j].name == "subject" || field[j].name == "assigned_user_id") {
					continue;
				}
				if (field[j].name == "customernum") {
					continue;
				}
				if (field[j].mandatory == "1") {
					var em = '<input name=\"Mandatory_' + field[j].name + '\" value=\"' + field[j].value + '\" readonly="" type="text" style="display:none" class=\"MandatoryBox\"><font color="red">*</font>';
				}else {
					var em = '';
				}
				forumObj += '<div class="ub ub-f1 ubb ulab ub-ac uinn3 b-gra">';
					forumObj += '<div class="detail_bt t-gra1">'+ em +field[j].value+'</div>';
					if (field[j].fieldtype == "accountid") {
						forumObj += '<div class="ub-f1 ilogin uinn4">';
						forumObj += '<input id="accountid" name=\"' + field[j].name + '\" readonly="" type="text" style="display:none" class=\"' + module_name + 'Box\">';
						forumObj += '<input id="accountname" name="accountname" placeholder=\"' + field[j].value + '\" readonly="" onclick="openSelectPage(\'account\',\'\')" type="text">';
						forumObj += '</div>';
					}
					else if (field[j].fieldtype == "contactid") {
						forumObj += '<div id="contact_div" class="ub-f1 ub  c-wh uc-a1 b-gra sel">';
						forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l"></div>';
						forumObj += '<div class="umw2 ub ub-pc uc-r ub-ac uc-r1">';
						forumObj += '<div class="ub-img umw1 umh1 res8"></div>';
						forumObj += '</div>';
						forumObj += '<select id="contactid" name=\"' + field[j].name + '\" selectedindex="0" onchange="zy_selectmenu(this.id)" class=\"' + module_name + 'Box\">';
						forumObj += '</select>';
						forumObj += '</div>';
					}else if (field[j].fieldtype == "opts") {
						var optsarr = accopts[field[j].name].value;
						var optsarrlen = optsarr.length;
						forumObj += '<div class="ub-f1 ub  c-wh uc-a1 b-gra sel">';
						forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l">' + optsarr[0].text + '</div>';
						forumObj += '<div class="umw2 ub ub-pc uc-r ub-ac uc-r1">';
						forumObj += '<div class="ub-img umw1 umh1 res8"></div>';
						forumObj += '</div>';
						forumObj += '<select id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" selectedindex="0" onchange="zy_selectmenu(this.id)" class=\"' + module_name + 'Box\">';
						for (var k = 0; k < optsarrlen; k++) {
							forumObj += '<option value="' + optsarr[k].value + '">' + optsarr[k].text + '</option>';
						}
						forumObj += '</select>';
						forumObj += '</div>';
					}else if (field[j].fieldtype == "date") {
						var theDate = currDate;
						if(field[j].name == "due_date")theDate = endDate;
						forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setDateMore(\'' + module_name + field[j].name + '\')" class="ub-f1 uc-a1 uinput uinn4 b-gra uba us-i1 ub ub-rev">';
						forumObj += '<div class="umh1 umw1 tx-c t-blu3 umar-a"><i class="icon-calendar"></i>&nbsp;</div><div class="ub-f1"><input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=""  type="text" class=\"' + module_name + 'Box\" readonly value="' + theDate + '"></div>';
						forumObj += '</div>';					
					}else if(field[j].fieldtype == "time"){
						var theTime = currTime;
						if(field[j].name == "time_end")theTime = endTime;
						forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setTimeMore(\''+ module_name + field[j].name + '\')" class="ub-f1 uc-a1 uinput uinn4 b-gra uba us-i1 ub ub-rev">';
						forumObj += '<div class="umh1 umw1 tx-c t-red umar-a"><i class="icon-time"></i>&nbsp;</div><div class="ub-f1"><input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=""  type="text" class=\"' + module_name + 'Box\" readonly value="' + theTime + '"></div>';
						forumObj += '</div>';
					}else if (field[j].fieldtype == "textarea") {
						forumObj += '<div class="ub-f1 c-wh uba uc-a1 b-gra uinput uinn4 ub ub-ver">';		
						forumObj += '<textarea rows=3 id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder="" ' + input_msg + ' type="text" class=\"' + module_name + 'Box\"></textarea>';
						forumObj += '</div>';
					}else {
						forumObj += '<div class="ub-f1 ilogin uinn4">';
						if (field[j].name == 'ordernum' || field[j].name == 'ordertotal') {
							forumObj += '<input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=\"' + field[j].value + '\" ' + input_msg + ' onchange="checkIsPositiveNumble(this)" type="text" class=\"' + module_name + 'Box\">';
						}
						else {
							forumObj += '<input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=\"' + field[j].value + '\" ' + input_msg + ' type="text" class=\"' + module_name + 'Box\">';
						}
						forumObj += '</div>';
					}
				forumObj += '</div>';
			}
			forumObj +='</div>';
		}
		setHtml("createform", forumObj);
		if(getstorage('cardData')!=''){
			var data = JSON.parse(getstorage('cardData'));
			$$(module_name+'accountname').value = data.accountname;
			$$(module_name+'bill_pobox').value = data.email;
			$$(module_name+'keycontact').value = data.keycontact;
			$$(module_name+'keymobile').value = data.phone;
			$$(module_name+'phone').value = data.phone2;
			$$(module_name+'bill_street').value = data.bill_street;
			window.localStorage.removeItem('cardData');
		}
		//$$("buttondiv").style.display = 'block'; noted by ligangze on 2014-08-27
	}
}

ACObj.prototype.setEditPageBind=function(){  //编辑(实例方法)
	this.theWindow = 'EditPage';
	this.CurrentAccountId = getstorage("CurrentAccountId");
	this.method = 'get_edit_field';
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'",'+
		'"module_id":"' + this.CurrentAccountId + '"}';
	this.RequestServer();
}; 

ACObj.prototype.ShowEditPage = function(data){ //显示编辑表单(实例方法)
	var theDate = formatDate(myDate);
	var forumObj = '';
	var module_name = this.name;
	var createFields = data.field;
	if ((createFields !== undefined) && (createFields.relationship_list !== undefined)) {
		var accopts = createFields.entry_list[0];
		var acclist = createFields.relationship_list;
		var acclistlen = acclist.length;
		for (var i = 0; i < acclistlen; i++) {
				forumObj += '<div class=" uc-a1 umar-a ubb_my b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">'+acclist[i].title+'</div>';
			forumObj += '</div>';
			var field = acclist[i].field;
			var fieldlen = field.length;
			for (var j = 0; j < fieldlen; j++) {
				if (field[j].display == "none") {
					continue;
				}
				if (field[j].name == "subject" || field[j].name == "assigned_user_id") {
					continue;
				}
				if (field[j].name == "customernum") {
					continue;
				}
				if (field[j].mandatory == "1") {
					var em = '<input name=\"Mandatory_' + field[j].name + '\" value=\"' + field[j].value + '\" readonly="" type="text" style="display:none" class=\"MandatoryBox\"><font color="red">*</font>';
				}else {
					var em = '';
				}
				if(!isDefine(field[j].fieldvalue))field[j].fieldvalue = '';
				forumObj += '<div class="ub ub-f1 ubb ulab ub-ac uinn3 b-gra">';
					forumObj += '<div class="detail_bt t-gra1">'+ em +field[j].value+'</div>';
					if(field[j].fieldtype == "accountid"){
					forumObj += '<div class="ub-f1 ilogin uinn4">';
					forumObj += '<input id="accountid" name=\"' + field[j].name +'\" value=\"'+field[j].fieldid+'\" readonly="" type="text" style="display:none" class=\"' + module_name + 'Box\">';
					forumObj += '<input id="accountname" name="accountname" placeholder=\"'+field[j].value+'\" value=\"'+field[j].fieldvalue+'\" readonly="" onclick="openSelectPage(\'account\',\'\')" type="text">';
					forumObj += '</div>';
				}else if(field[j].fieldtype == "contactid"){
					forumObj += '<div id="contact_div" class="ub-f1 ub  c-wh uc-a1 b-gra sel">';
					forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l"></div>';
					forumObj += '<div class="umw2 ub ub-pc uc-r ub-ac uc-r1">';  
						forumObj += '<div class="ub-img umw1 umh1 res8"></div>'; 
					forumObj += '</div>';
					forumObj += '<select id="contactid" name=\"'+field[j].name+'\" selectedindex="0" onchange="zy_selectmenu(this.id)" class=\"'+module_name+'Box\">';
					forumObj += '</select>';
					forumObj += '</div>';
				}else if(field[j].fieldtype == "opts"){
					var optsarr = accopts[field[j].name].value;
					var optsarrlen = optsarr.length;
					var optValue = optsarr[0].text;
					for(var k=0;k<optsarrlen;k++){
						if(optsarr[k].selected == 'selected'){
							optValue = optsarr[k].value;
						}
					}
					forumObj += '<div class="ub-f1 ub  c-wh uc-a1 b-gra sel">';
					forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l">'+optValue+'</div>';
					forumObj += '<div class="umw2 ub ub-pc uc-r ub-ac uc-r1">';  
						forumObj += '<div class="ub-img umw1 umh1 res8"></div>'; 
					forumObj += '</div>';
					forumObj += '<select id=\"'+module_name+field[j].name+'\" name=\"'+field[j].name+'\" selectedindex="0" onchange="zy_selectmenu(this.id)" class=\"'+module_name+'Box\">';
					for(var k=0;k<optsarrlen;k++){
						forumObj += '<option value="'+optsarr[k].value+'" '+optsarr[k].selected+'>'+optsarr[k].text+'</option>';
					}
					forumObj += '</select>';
					forumObj += '</div>';
				}else if(field[j].fieldtype == "date"){
					forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setDateMore(\'' + module_name + field[j].name + '\')" class="ub-f1 uc-a1 uinput uinn4 b-gra uba us-i1 ub ub-rev">';
					forumObj += '<div class="umh1 umw1 tx-c t-blu3 umar-a"><i class="icon-calendar"></i>&nbsp;</div><div class="ub-f1"><input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=""  value=\"'+field[j].fieldvalue+'\" type="text" class=\"' + module_name + 'Box\" readonly"></div>';
					forumObj += '</div>';
				}else if(field[j].fieldtype == "time"){
					forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setTimeMore(\''+ module_name + field[j].name + '\')" class="ub-f1 uc-a1 uinput uinn4 b-gra uba us-i1 ub ub-rev">';
					forumObj += '<div class="umh1 umw1 tx-c t-red umar-a"><i class="icon-time"></i>&nbsp;</div><div class="ub-f1"><input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder="" value=\"'+field[j].fieldvalue+'\" type="text" class=\"' + module_name + 'Box\" readonly></div>';
					forumObj += '</div>';
				}else if (field[j].fieldtype == "textarea") {
					forumObj += '<div class="ub-f1 c-wh uba uc-a1 b-gra uinput uinn4 ub ub-ver">';
					forumObj += '<textarea rows=3 id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name +'\" placeholder="" '+input_msg +' type="text" class=\"' + module_name + 'Box\">'+field[j].fieldvalue+'</textarea>';
					forumObj += '</div>';
				}else {
					forumObj += '<div class="ub-f1 ilogin uinn4">';
					if (field[j].name == 'ordernum' || field[j].name == 'ordertotal') {
						forumObj += '<input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=\"' + field[j].value + '\" value=\"'+field[j].fieldvalue+'\" ' + input_msg + ' onchange="checkIsPositiveNumble(this)" type="text" class=\"' + module_name + 'Box\">';
					}else {
						forumObj += '<input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=\"' + field[j].value + '\" value=\"'+field[j].fieldvalue+'\" ' + input_msg + ' type="text" class=\"' + module_name + 'Box\">';
					}
					forumObj += '</div>';
				}
				forumObj += '</div>';
			}
			forumObj += '</div>';
		}
		setHtml("createform", forumObj);	
		//$$("buttondiv").style.display='block';	by ligangze on 2014-08-27
	}
}

ACObj.prototype.SaveNew=function(){  //保存(实例方法)
	var validInput = this.ValidateCheck();
    if (validInput) {
		var inputs = getElementsByClassName(this.name + "Box");
		var inputlen = inputs.length;
		var select_fields = '';
		for (var i = 0; i < inputlen; i++) {
			inputs[i].value = removeHTMLTag(inputs[i].value);
			//if (inputs[i].value != '') {
				select_fields += "&" + inputs[i].name + "=" + inputs[i].value;
			//}
		} 
		logs(select_fields);
		this.rest_data = '{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","link_name_to_fields_array":"","record":"' +this.CurrentAccountId +'"}';
		this.method = 'set_entry_save';
		this.tip = 0;
		this.RequestServer();
	}
}; 

ACObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.toast(0, 5, "操作成功", 2000);	
		openAccountDetail(data.record,"modules/Accounts/");
		var thePage = getstorage('thePage');
		if (thePage == "Account") {
			uexWindow.evaluateScript('AccountsListPage', '0', "searchList()");
		}else if(thePage == "Home") {
			
		}
		uexWindow.evaluateScript(this.theWindow, '0', 'closeWin()');
	
	}else if(data.result === "FAIL"){
		myalert(data.record);
	}
}; 

ACObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_entry':
			this.ShowDetail(data);
			break;
		case 'get_entry_list':
			this.ShowList(data);
			break;
		case 'get_relatedlists_list':
			this.ShowReModuleList(data);
			break;
		case 'save_startsfalist':
			if (data.result === "SUCCESS") {
				uexWindow.toast(0, 5, "操作成功", 2000);
				uexWindow.evaluateScript('AccountRelativePage', '0', "refreshRelative()");
			}else if(data.result === "FAIL"){
				myalert(data.record);
			}
			break;
		case 'get_create_field':
			this.ShowCreatePage(data);
			break;
		case 'get_edit_field':
			this.ShowEditPage(data);
			break;
		case 'set_entry_save':
			this.SaveReturn(data);
			break;
	}
};  

//打开详细页面
function openAccountDetail(accountid,res){
	setstorage('CurrentAccountId', accountid);
	openwin('AccountDetailsPage',res);
}

//客户联系人
function setAccountContactsBind(data){
	var forumObj = '';
	var listObj = data;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		var theBill = listObj[i];
		if(theBill.name_value_list != ''){
			var contacts = theBill.name_value_list;
			var contactname = contacts.name.value;
			if(contacts.title.value && contacts.title.value != ""){
				contactname += "&nbsp;("+contacts.title.value+")";
			}
			forumObj +='<ul onclick="openContactDetail('+theBill.id+',\'../Contacts/\');" class="c-m2 ubb ub b-gra t-bla ub-ac lis '+whitebg+'">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_2_2"><i class="icon-user"></i>&nbsp;<span class="li_2_text">'+contactname+'</span></li>';
			var contactPText = '';
			if(contacts.mobile.value != ''){  //手机
				contactPText += '<i class="icon-phone"></i>&nbsp;'+contacts.mobile.value+'&nbsp;&nbsp;';
			}
			if(contacts.email.value != ''){    //Email
				contactPText += '<i class="icon-envelope"></i>&nbsp;'+contacts.email.value +'&nbsp;&nbsp;';
			}
			forumObj +='<li class="li_2_2">' + contactPText + '</li>';     
			forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';	
		}
	}
	return forumObj;
}

//客户联系记录
function setAccountContactRecordsBind(data){
	var forumObj = '';
	var listObj = data;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		var theBill = listObj[i];
		if(theBill.name_value_list != ''){
			var notes = theBill.name_value_list;
			forumObj +='<ul onclick="openNoteDetail('+theBill.id+',\'../Notes/\');" class="c-m2 ubb ub b-gra t-bla ub-ac lis '+whitebg+'">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><div class="li_2_2 ub-f1"><i class="icon-notebook"></i>&nbsp;<span class="li_2_text">'+notes.title.value +'</span><div></li>';
			forumObj +='<li class="li_2_2"><i class="icon-quill"></i>&nbsp;' + notes.notetype.value + '<span class="ufr"><i class="icon-calendar"></i>&nbsp;' + notes.contact_date.value + '</span></li>'; 
			if (isDefine(notes.notecontent.value)) {
				forumObj += '<li class="li_2_2">' + notes.notecontent.value + '</li>';
			}
			forumObj +='<li class="li_2">'+notes.accountname.value +'</li>';       //客户名称
			forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';	
		}
	}
	return forumObj;
}

//客户合同订单
function setAccountSalesOrderBind(data){
	var forumObj = '';
	var listObj = data;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		var theBill = listObj[i];
		if (theBill.name_value_list != '') {
			var theBillPText = '';
			
			forumObj +='<ul onclick="openSalesOrderDetail('+theBill.id+',\''+theBill.name_value_list.sostatus.value+'\',\'../SalesOrder/\');" class="ubb ub b-gra ub-ac lis act-wh '+whitebg+'">';

			forumObj +='<li class="ub " style="width:30%"><ul class="ub-f1 ub ub-ver tx-c "><li class="ub-f1 ulev2 t-gre tx-c tx_bold"><div>'+
				theBill.name_value_list.sostatus.value +'</div></li><li class="ub-f1 ulev-1 t-gra1 tx-c"><div>'+
				theBill.name_value_list.duedate.value+'</div></li></ul></li>';
			forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub li_1_1">';
			forumObj +='<div class="ub-f2 li_2_text">'+theBill.name_value_list.subject.value+'</div>';     
			forumObj +='</li>';
			forumObj +='<li class="ub li_3">';
			forumObj +='<div class="ub-f1"><span class="li_3_2 t-org1 ulev1 tx_bold">￥'+theBill.name_value_list.total.value+'</span></div>';  
				forumObj +='<li class="ub li_3 t-gra2">'+theBill.name_value_list.accountname.value +'</li>'; //客户名称          
			forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
				
		}
	}
	return forumObj;
}

//客户销售机会
function setAccountPotentialBind(data){
	var forumObj = '';
	var listObj = data;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		var theBill = listObj[i];
		if (theBill.name_value_list != '') {
			var theBillPText = '';
//				forumObj +='<ul onclick="openPotentialDetail('+theBill.id+',\'../Potentials/\');" class="ubb ub b-gra ub-ac lis act-wh '+whitebg+'">';
//				forumObj +='<li class="ub " style="width:25%"><ul class="ub-f1 ub ub-ver tx-c "><li class="ub-f1 ulev2 tx-c t-gre tx_bold"><div class="uinn3">'+
//				theBill.name_value_list.probability.value +'%</div></li><li class="ub-f1 ulev-1 c-blu2 c-m2 tx-c"><div class="uinn3">'+theBill.name_value_list.potentstatus.value +'</div></li></ul></li>';
//				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub li_1_1">';
//				forumObj +='<div class="ub-f2 li_2_text">'+theBill.name_value_list.name.value+'</div>';     
//				forumObj +='<div class="li_3" style="float:right">'+theBill.name_value_list.contactname.value+'</div></li>';
//				forumObj +='<li class="ub li_3">';
//				forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-calendar"></i>&nbsp;'+theBill.name_value_list.closingdate.value +'</span></div>';
//				forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-coin"></i>&nbsp;'+theBill.name_value_list.probableamount.value +'</span></div>';  
//				forumObj +='<li class="ub li_3"><i class="icon-home"></i>&nbsp;'+theBill.name_value_list.accountname.value +'</li>';       //客户名称     
//				forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
				
				forumObj +='<ul onclick="openPotentialDetail('+theBill.id+',\'../Potentials/\');" class="ubb ub b-gra ub-ac lis act-wh '+whitebg+'">';
				forumObj +='<li class="ub " style="width:25%"><ul class="ub-f1 ub ub-ver tx-c "><li class="ub-f1 ulev2 tx-c t-gre tx_bold"><div class="uinn3">'+
				theBill.name_value_list.probability.value +'%</div></li><li class="ub-f1 ulev2 t-gre tx-c tx_bold"><div>'+
				theBill.name_value_list.potentstatus.value +'</div></li><li class="ub-f1 ulev-1 t-gra1 tx-c"><div>'+
				theBill.name_value_list.closingdate.value+'</div></li></ul></li>';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub li_1_1">';
				forumObj +='<div class="ub-f2 li_2_text">'+theBill.name_value_list.name.value+'</div>'; 
				forumObj +='</li>';
				forumObj +='<li class="ub li_3">';
				forumObj +='<div class="ub-f1"><span class="li_3_2 t-org1 ulev1 tx_bold">￥'+theBill.name_value_list.probableamount.value +'</span></div>';
				if(theBill.name_value_list.contactname.value)
					forumObj +='<li class="ub li_3 t-gra1">'+theBill.name_value_list.accountname.value +'(<div class="li_3">'+theBill.name_value_list.contactname.value+'</div>)</li>';       //客户名称
				else
					forumObj +='<li class="ub li_3 t-gra1">'+theBill.name_value_list.accountname.value +'</li>'; //客户名称          
				forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
		}
	}
	return forumObj;
}

//客户工作日程
function setAccountCalendarBind(data){
	var forumObj = '';
	var listObj = data;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		var theBill = listObj[i];
		var calendar = theBill.entries;
		forumObj += '<div onclick="openCalendarDetail('+theBill.activityid+',\'../Calendars/\');"class="ubb b-gra '+whitebg+'">';	
		
		forumObj += '<div class="b-gra uinn3">';	
		forumObj += '<div class="ub t-bla ulab ub-ac">';
		forumObj += '<div class="ub-f1 ilogin detail_li_text">'+ calendar.date_start.value +' - '+calendar.due_date.value+'</div>';
		forumObj += '</div></div>';
		
		forumObj += '<div class="b-gra uinn3">';	
		forumObj += '<div class="ub t-bla ulab ub-ac">';
		forumObj += '<div class="wd_wh detail_ul_text">' + calendar.subject.name + ':</div>';
		forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.subject.value+'</div>';
		forumObj += '</div></div>';
		
		forumObj += '<div class="b-gra uinn3">';	
		forumObj += '<div class="ub t-bla ulab ub-ac">';
		forumObj += '<div class="wd_wh detail_ul_text">' + calendar.priority.name + ':</div>';
		forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.priority.value+'</div>';
		forumObj += '</div></div>';
		
		forumObj += '<div class="b-gra uinn3">';	
		forumObj += '<div class="ub t-bla ulab ub-ac">';
		forumObj += '<div class="wd_wh detail_ul_text">' + calendar.eventstatus.name + ':</div>';
		forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.eventstatus.value+'</div>';
		forumObj += '</div></div>';
		
		forumObj += '<div class="b-gra uinn3">';	
		forumObj += '<div class="ub t-bla ulab ub-ac">';
		forumObj += '<div class="wd_wh detail_ul_text">' + calendar.user_name.name + ':</div>';
		forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.user_name.value+'</div>';
		forumObj += '</div></div>';
		
		forumObj +='</div>';
	}
	return forumObj;
}

//客户销售自动化
function setAccountSfaBind(data){
	var forumObj = '';
	forumObj += '<div class="c-gra ub t-bla uinn">';
  	forumObj += '<div class="uinn" >启动SFA序列:</div>';
  	forumObj += '<div class="btn c-blu2 uc-a1 ub t-wh ub-ac sel" style="width:35%">';
  	forumObj += '<div class="ub-f1 tx-c">无</div>';
  	forumObj += '<div class="umh1 umw1 ub-img res3 uc-a" style="right:0.2em"></div>';
	forumObj += '<select name="sfasettingsid" selectedindex="0" id="sfasettingsid" onchange="zy_selectmenu(this.id);"><option value="0" selected>无</option>'+data.sfasettingshtml+'</select>';
	forumObj += '</div>';
	forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onclick="StartSfaList();" class="ub-f1 c-org uc-a1 tx-c uinn t-wh umar-r" style="left:0.5em;font-size: 1.2em font-weight:bold;">开始</div>';
	forumObj += '</div>'; 
	forumObj +='<div class="uc-n" id="list1">';
	var listObj = data.output_list;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var theBill = listObj[i];
		if (theBill.name_value_list != '') {
			var theBillPText = '';
			forumObj+='<input type="checkbox" class="uhide">'+
				'<div ontouchstart="zy_touch(\'col-active\')" onmousedown="zy_touch(\'col-active\')" onclick="zy_for(event,zy_fold_sfa);" class="col uc-n t-bla ub ubb  b-gra1 uinn58 ub-ac c-m22 c-gra ulev-0 umh4">'+	 
					'<div class="ub-f1 ut-s">'+theBill.name_value_list.sfalistname.value+'(<font color=\"#666666\">'+theBill.name_value_list.name.value+'</font>)</div>'+
					'<div class="umh1 umw1 ub-img res8_1"></div>'+
				'</div>'+
				'<div class="uinn59 t-bla us-i c-grey ubb b-gra1">';
			var eventsList = theBill.events;
			for(var j=0;j<eventsList.length;j++){
				var col_cc = '';
				if(eventsList[j].bjzt =='正在执行期内'){
					col_cc = ' color="#008800"';
				}else if(eventsList[j].bjzt =='过期未执行的'){
					col_cc = ' color="#ff0000"';
				}else if(eventsList[j].bjzt =='正常的'){
					//col_cc = ' color="#ffffcc"';
				}
				var bottom_border = ' style="border-bottom: 1px dotted #DDD;"';
				if(j == eventsList.length-1){
					bottom_border = '';
				}
				forumObj+='<div ontouchstart="zy_touch(\'btn-act1\')" onmousedown="zy_touch(\'btn-act1\')" onclick="openSfaDetail('+eventsList[j].id+',\'../Sfa/\');"'+bottom_border+'>'+
							'<div class="ub t-bla ub-ac umh4 lis2">'+
							'<div class="ub-f1 ut-s"><font'+col_cc+'>'+eventsList[j].sj+'</font></div>';
				forumObj+='<div class="tx-r t-blu2 ulev-1">'+eventsList[j].zt+'</div>';
				var tt = '具体事务';
				if(eventsList[j].at == 'sms'){
					tt = '&nbsp;&nbsp;发短信';
				}else if(eventsList[j].at == 'email'){
					tt = '&nbsp;&nbsp;发邮件';
				}
				forumObj+='</div><div class="tx-r t-blu ulev-1">'+eventsList[j].datestart+' -- '+eventsList[j].dateend+' '+tt+'</div></div>';
			}
			forumObj+='</div>';			   
		}
	}
	forumObj+='</div>';	
	if(listlen == 0){
		forumObj += showNotRecordDiv();
	}else{
		forumObj+='<div class="ulev-1 uinn tx-c c-gra"style="padding-top:2em"><div>■正常的|<font color="#008800">■</font>正在执行期内|<font color="#ff0000">■</font>过期未执行</div>';
	} 
	return forumObj;
}

//开启SFA序列
function StartSfaList(){
	var sfasettingsid = $$("sfasettingsid").value;
	if(sfasettingsid == 0){
		myalert("请先选择方案！");
		return false;
	} 
	uexWindow.cbConfirm = function ConfirmSuccess(opId, dataType, data){
		if (data == 0) {
			acobj.saveStartSfaList(sfasettingsid);//保存要执行的SFA序列
		}
	}
	uexWindow.confirm('', '请确认真的要启动此SFA序列吗?', ['确定','取消']);	
}

function zy_fold_sfa(e, col){
    var a = e.currentTarget.nextElementSibling;
    if (a.nodeName == "DIV") {
        if (col) 
            a.className += ' col-c';
        else 
			a.className = a.className.replace("col-c", "");
    }
}