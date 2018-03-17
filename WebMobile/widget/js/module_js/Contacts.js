/**
 * 联系人
 */
set_input_msg();
function CONObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      CONObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
	this.CurrentContactId = 0;
	this.CurrentAccountId = 0;
	this.reType = '';
	this.mode = '';
	this.theWindow = '';
};

CONObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
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

CONObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	this.method = 'get_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"query":"'+searchtext+'",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}; 

CONObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	if(data.entry_list.islook !== undefined && data.entry_list.islook == 'no'){//列表加权限 added by ligangze on 2014/8/22
		forumObj += showNotPermittedDiv();
		setHtml("contact_list", forumObj);
		return false;
	}
	var contactsList = data;
	if ((contactsList !== undefined) && (contactsList.entry_list !== undefined)) {
		var intContact = 0;
		for (intContact = 0; intContact < contactsList.entry_list.length; intContact++) {
			if(intContact%2!=0)
				whitebg = "c-wh";
			else
				whitebg = '';		
			if (contactsList.entry_list[intContact] !== undefined) {
				var contact = contactsList.entry_list[intContact];
				var contactPText = '';
				if(isDefine(contact.name_value_list.mobile.value)){  //手机
					contactPText += '<i class="icon-phone"></i>&nbsp;'+contact.name_value_list.mobile.value+'&nbsp;&nbsp;';
				}
				if(isDefine(contact.name_value_list.qq.value)){    //QQ
					contactPText += '<i class="icon-qq"></i>&nbsp;'+contact.name_value_list.qq.value+'&nbsp;&nbsp;';
				}
                
				forumObj +='<ul onclick="openContactDetail('+contact.id+',\'\');" class="ub ub-ac lis act-wh '+whitebg+'">';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_2_2"><i class="icon-user"></i>&nbsp;<span class="li_2_text">'+contact.name_value_list.lastname.value+'</span></li>';
				forumObj +='<li class="li_2_2">' + contactPText + '</li>'; 
				if(isDefine(contact.name_value_list.email.value)){   //email
					forumObj +='<li class="li_2_2"><i class="icon-envelope"></i>&nbsp;'+contact.name_value_list.email.value+'</li>';      
				} 
				forumObj +='<li class="li_2">'+contact.name_value_list.accountname.value +'</li>';       //客户名称
				forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
			}
		}
		if(contactsList.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("contact_list", forumObj);
		if(contactsList.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', contactsList.lastpg);
			uexWindow.evaluatePopoverScript('ContactsListPage','pop_nav',"setPageSel()");
		}
	}
}

CONObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentContactId = getstorage("CurrentContactId");  //客户id
	this.method = 'get_entry';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentContactId + '"}';
	this.RequestServer();
}; 

CONObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
//document.write(JSON.stringify(data.details));return ;
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){
		forumObj += showNotPermittedDiv();
		setHtml("contactdetails_list", forumObj);
		return false;
	}
	if(data.isedit == 'yes'){
		uexWindow.evaluateScript('ContactDetailsPage', '0', "showEditButton()");
	}
	var detailObj = data.details;
	if ((detailObj !== undefined) && (detailObj.entry_list !== undefined)) {
		var order = detailObj.entry_list;
		var listlen = order.length;
		var subname =  order[0].field[0].value;
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
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="phonedial(\'' + field[j].value + '\');" class="uinn4  t-blu3 ">'+field[j].value+'</div>';
				}else if (field[j].name == 'Email') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="mailsend(\'' + field[j].value + '\');" class="uinn4 t-blu3 ">'+field[j].value+'</div>';
				}else if (field[j].name == '网站') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openwebsite(\'' + field[j].value + '\');" class="uinn4 t-blu3">'+field[j].value+'</div>';
				}else if (field[j].name == '联系人照片') {
					field[j].value = '<img src="'+field[j].value+'" class="uc-a1 edpic2"  onclick="viewImg(this);"/>';
				}else if (field[j].link == 1) {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openDetailTab(\''+field[j].re_module+'\',\''+field[j].link_id+'\',\''+field[j].link_modulename+'\',\'../\');" class="uinn4 t-blu3">'+field[j].value+'</div>';
				}
				forumObj += '<div ' + div_class + '>';
				forumObj += '<div class="detail_bt t-gra1">' + field[j].name + '</div>';
				forumObj += '<div class="ub-f1 detail_nr ub">' + field[j].value + '</div>';
				forumObj += '</div>';
			}
			forumObj += '</div>';
		}
		var otherInfo = detailObj.other_list;
		if (otherInfo.title !== undefined) {
			forumObj += '<div class="ub ub-fh bb_line uinn-top">';
				forumObj += '<div class="umar-b">'+otherInfo.title+'</div>';
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
		setHtml("contactdetails_list", forumObj);
		
		var notenum = "";
		if(data.relatedlistcount['Notes']!=0 && data.relatedlistcount['Notes']!= undefined){
			notenum = data.relatedlistcount['Notes'];
			if(notenum>99)
				notenum = 99;
			notenum = '<li class="related-count" >'+notenum+'</li>';
		}
		
	relatedObj = '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3"><div class="umar-a ub-f1 tx-c">相关信息</div></div>';
	relatedObj += '<div ontouchstart="" onclick="lookRelative(\'contactRecord\');" class="ub ub-f1 t-bla ulab ub-ac uinn3 lis">';
		relatedObj += '<li class="ub-f1 ut-s t-gra1">联系记录</li>'+notenum+'<li class="res8 lis-sw ub-img"></li></div>';
		
		setHtml("relative",relatedObj);
		$$("relative").style.display='block';
	}
}

CONObj.prototype.setReModuleBind=function(){  //获取相关信息(实例方法)
	this.CurrentContactId = getstorage("CurrentContactId");   //id
	this.method = 'get_relatedlists_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"module_id":"' + this.CurrentContactId + '",'+
		'"link_field_name":"'+this.reModule+'"}';
	this.RequestServer();
}; 

CONObj.prototype.ShowReModuleList = function(data){ //显示相关信息列表(实例方法)
	var forumObj = '';
	switch(this.reType){
		case 'contactRecord':
			forumObj += setContactRecordsBind(data);
			break;
	}
	if(forumObj == ''){
		forumObj += showNotRecordDiv();
	}
	setHtml("records_list", forumObj);
}

CONObj.prototype.setCreatePageBind=function(){  //创建(实例方法)
	this.theWindow = 'CreateNewPage';
	this.method = 'get_create_field';
	this.cacheFlag = false;
	var thePage = getstorage('thePage');
	if(thePage == 'Account'){
		this.cacheFlag = false;
		this.CurrentAccountId = getstorage("CurrentAccountId");
	}
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'","select_fields":"","link_name_to_fields_array":"","setype":"Account",'+
		'"record":"' + this.CurrentAccountId + '"}';
	this.RequestServer();
}; 

CONObj.prototype.ShowCreatePage = function(data){ //显示创建表单(实例方法)
//document.write(JSON.stringify(data.field.relationship_list));return ;
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
//			forumObj += '<div class="ub ub-fh ubb c-gra b-gra uinn-top">';
//				forumObj += '<div class="umar-b uinn1">'+acclist[i].title+'</div>';
//			forumObj += '</div>';
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
					//forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setDateMore(\''+ module_name + field[j].name + '\')" class="btn uba b-bla uinn5 c-blu c-m2 uc-a1 t-wh">选择</div>';						
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
					}else if (field[j].fieldtype == "image") {
						forumObj += '<input id="imagename" name=\"' + field[j].name +'\" value=\"'+field[j].fieldid+'\" readonly="" type="text" style="display:none" class=\"' + module_name + 'Box\">';
						forumObj += '<div class="ub uinn3" ><img src="css/images/default.png" class="uc-a1 edpic2"  onclick="viewImg();" id="thepic"/></div>';		
						forumObj +='<div class="umh2 btn-l umw25 umar-r" ontouchstart="zy_touch(\'\')" onclick="getpic(0)" style="width:2.2em;height:2.2em;">';    
							forumObj +='<div class="ub-img7 res-camera umh2 umw2"></div></div>';
						forumObj +='<div class="umh2 btn-l umw25 umar-r" ontouchstart="zy_touch(\'\')" onclick="getpic(1)" style="width:2.2em;height:2.2em;">';    
							forumObj +='<div class="ub-img7 res-img1 umh2 umw2"></div></div>';
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
			forumObj += '</div>';
		}
		setHtml("createform", forumObj);
		if(this.CurrentAccountId > 0){
			$$('accountid').value = data.account['id'];
			$$('accountname').value = data.account['name'];
		}	
		if(getstorage('cardData')!=''){
			var data = JSON.parse(getstorage('cardData'));
			$$(module_name+'lastname').value = data.keycontact;
			$$(module_name+'mobile').value = data.phone;
			$$(module_name+'phone').value = data.phone2;
			window.localStorage.removeItem('cardData');
		}	
		$$("buttondiv").style.display='block';	
	}	
}

CONObj.prototype.setEditPageBind=function(){  //编辑(实例方法)
	this.theWindow = 'EditPage';
	this.CurrentContactId = getstorage("CurrentContactId");
	this.method = 'get_edit_field';
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'",'+
		'"module_id":"' + this.CurrentContactId + '"}';
	this.RequestServer();
}; 

CONObj.prototype.ShowEditPage = function(data){ //显示编辑表单(实例方法)
//document.write(JSON.stringify(data.field));return ;
	var theDate = formatDate(myDate);
	var forumObj = '';
	var module_name = this.name;
	var createFields = data.field;
	if ((createFields !== undefined) && (createFields.relationship_list !== undefined)) {
		var accopts = createFields.entry_list[0];
		var acclist = createFields.relationship_list;
		var acclistlen = acclist.length;
		for (var i = 0; i < acclistlen; i++) {
//			forumObj += '<div class="ub ub-fh ubb c-gra b-gra uinn-top">';
//				forumObj += '<div class="umar-b uinn1">'+acclist[i].title+'</div>';
//			forumObj += '</div>';
			
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
				}else if (field[j].fieldtype == "image") {
					forumObj += '<input id="imagename" name=\"' + field[j].name +'\" value=\"'+field[j].fieldvalue+'\" readonly="" type="text" style="display:none" class=\"' + module_name + 'Box\">';
					forumObj += '<div class="ub uinn3" ><img src="'+field[j].fieldsrc+'" class="uc-a1 edpic2"  onclick="viewImg();" id="thepic"/></div>';		
					forumObj +='<div class="umh2 btn-l umw25 umar-r" ontouchstart="zy_touch(\'\')" onclick="getpic(0)" style="width:2.2em;height:2.2em;">';    
						forumObj +='<div class="ub-img7 res-camera umh2 umw2"></div></div>';
					forumObj +='<div class="umh2 btn-l umw25 umar-r" ontouchstart="zy_touch(\'\')" onclick="getpic(1)" style="width:2.2em;height:2.2em;">';    
						forumObj +='<div class="ub-img7 res-img1 umh2 umw2"></div></div>';
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
		$$("buttondiv").style.display='block';	
	}
}

CONObj.prototype.SaveNew=function(){  //保存(实例方法)
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
		if(oldsrc != ''){
			var index = oldsrc.lastIndexOf("=");
			select_fields += "&new_attachmentid=" + oldsrc.substring(index+1,100);
		}
		var uploaddel = '';
		for (var m = 0; m < attachdel.length; m++) {
			uploaddel += '[img]'+attachdel[m];
		}
		this.rest_data = '{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","link_name_to_fields_array":"'+uploaddel+'","record":"' +this.CurrentContactId +'"}';
		this.method = 'set_entry_save';
		this.tip = 0;
		this.RequestServer();
	}
}; 

CONObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.toast(0, 5, "操作成功", 2000);
		openContactDetail(data.record,"modules/Contacts/");
		var thePage = getstorage('thePage');
		if (thePage == "Account") {
			uexWindow.evaluateScript('AccountRelativePage', '0', "refreshRelative()");
		}else if(thePage == "Home") {
			
		}else{
			uexWindow.evaluateScript('ContactsListPage', '0', "searchList()");
		}
		uexWindow.evaluateScript(this.theWindow, '0', 'closeWin()');
	}else if(data.result === "FAIL"){
		myalert(data.record);
	}
}; 


function openContactDetail(contactid,res){ //打开详细页面
	setstorage('CurrentContactId', contactid);
	openwin('ContactDetailsPage',res);
}

function setContactRecordsBind(data){ //联系人联系记录
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
			forumObj +='<ul onclick="openNoteDetail('+theBill.id+',\'../Notes/\');" class="ubb ub b-gra ub-ac lis act-wh '+whitebg+'">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><div class="li_2_2 ub-f1"><span class="li_2_text">'+notes.title.value +'</span><div></li>';
			var theContact = '';
			if(isDefine(notes.name)){
				theContact = '<i class="icon-user"></i>&nbsp;' + notes.name.value;
			}
			forumObj +='<li class="li_2_2">' + theContact + '<span class="ufr"><i class="icon-calendar"></i>&nbsp;'+ notes.contact_date.value + '</span></li>';     
			forumObj +='<li class="li_2">'+notes.accountname.value +'</li>';   //客户名称
			forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';	
			
			
		}
	}
	return forumObj;
}