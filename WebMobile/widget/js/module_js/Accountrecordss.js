set_input_msg();
function AccountrecordsObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      AccountrecordsObj.prototype[attr] = Module.prototype[attr];
	};
	this.method = 'handleRequest';
	this.offset = 1;
	this.CurrentAccountrecords = 0;
	this.reType = '';
	this.mode = '';
	this.theWindow = '';
	this.optType = '';
};

AccountrecordsObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	var viewsel = getstorage("accountrecords_viewId");   //视图id  ============waiting=======
	this.action = "get_entry_list";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
        '"query":"'+searchtext+'",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + ',' +
        '"sel":"'+viewsel+'"}]';
	this.RequestServer();
}; 

AccountrecordsObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){//列表加权限 added by ligangze on 2014/8/22
		forumObj += showNotPermittedDiv();
		setHtml("record_list", forumObj);
		return false;
	}
	
	var listObj = data;
	if ((listObj !== undefined) && (listObj.entry_list !== undefined)) {
		var i = 0;
		for (i = 0; i < listObj.entry_list.length; i++) {
			if (listObj.entry_list[i] !== undefined) {
				
				var theBill = listObj.entry_list[i];
				var theBillPText = '';
				if (theBill.userPhoto == '') {
					theBill.userPhoto = "../../css/images/avatar_default1299eb.png";
				}
				if(i%2!=0)
					whitebg = "c-wh";
				else
					whitebg = '';
				forumObj+='<div ontouchstart="zy_touch(\'list-act\')" onclick="openAccountrecordssDetail('+theBill.id+',\'\');" class="ubb ub b-gra t-bla umh4 lis3 '+whitebg+'">';
					forumObj+='<div class="avatar"><img src=\"'+theBill.userPhoto+'\" style="width:100%;height:100%" class="uc-a1"/></div>';
					forumObj+='<div class="ub-f1 ub ub-ver lis3">';	
						var state = '';
						if(theBill.haveImg == 1){
							 state+='<span style="float:right">&nbsp;<i class="icon-picture"></i></span>';
						} 
						forumObj+='<div class="ulev0 ut-s umar-b ub "><div class="ub ub-f1"><div class="text_hide_1 ub-f1">'+theBill.name_value_list.name.value+'</div></div><div>'+state+'</div></div>';
						forumObj+='<div class="ub ub-ac t-gra ulev-2">';
							forumObj+='<div class="ub-f1"><i class="icon-user t-blu"></i>&nbsp;'+theBill.name_value_list.smownername.value+'</div>';
							forumObj+='<div class="ub-f1"><i class="icon-calendar t-blu"></i>&nbsp;'+theBill.name_value_list.starDate.value+'</div>';
							forumObj+='<div class="umar-r"></div>';
						forumObj+='</div>';
					forumObj+='</div>';
				forumObj+='</div>';
			}
		}
		
		if(listObj.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("record_list", forumObj);
		if(listObj.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', listObj.lastpg);
			uexWindow.evaluatePopoverScript('AcountrecordssListPage','pop_nav',"setPageSel()");
		}
	}
}

AccountrecordsObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentAccountrecordsId = getstorage("CurrentAccountrecordsId");  //id
	this.action = "get_entry";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
        '"id":"' + this.CurrentAccountrecordsId + '"}]';
	this.RequestServer();
}; 

AccountrecordsObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){
		forumObj += showNotPermittedDiv();
		setHtml("accountrecordssdetails_list", forumObj);
		return false;
	}
	if(data.isedit == 'yes'){
		uexWindow.evaluateScript('AccountrecordssDetailsPage', '0', "showEditButton()");
	}
	var detailObj = data.details;
	if ((detailObj !== undefined) && (detailObj.entry_list !== undefined)) {
		var order = detailObj.entry_list;
		var listlen = order.length;
		var subname = order[0].field[0].value;
		for (var i = 0; i < listlen; i++) {
			var field = order[i].field;
			var fieldlen = field.length;
			var notNulls = 0;
			for (var k = 0; k < fieldlen; k++) {
				if (!isDefine(field[k].value)) {
					continue;
				}
				notNulls++;
			}
			if (notNulls == 0) 
				continue;
			forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">' + order[i].title + '</div>';
			forumObj += '</div>';
			var nn = 0;
			for (var j = 0; j < fieldlen; j++) {
				if (!isDefine(field[j].value)) {
					continue;
				}
				nn++;
				var div_class = 'class="ub ub-f1 t-bla ulab ub-ac lis ubb b-gra"';
				if (nn == notNulls) {
					div_class = 'class="ub ub-f1 t-bla ulab ub-ac lis"';
				}
				if (field[j].link == 1) {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openDetailTab(\'' + field[j].re_module + '\',\'' + field[j].link_id + '\',\'' + field[j].link_modulename + '\',\'../\');" class="uinn4 c-wh  t-blu3 tx_bold ">' + field[j].value + '</div>';
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
			forumObj += '<div class="umar-b">' + otherInfo.title + '</div>';
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
					forumObj += '<div class="detail_bt">' + j + ':</div>';
					forumObj += '<div class="ub-f1 detail_nr ub">' + field[i][j] + '</div>';
					forumObj += '</div>';
				}
				forumObj += '</div>';
			}
		}
		forumObj += '</div>';
		setHtml("accountrecordssdetails_list", forumObj);
		
		var commentnum =  "";//
		if(data.relatedlistcount['comment']!=0 && data.relatedlistcount['comment']!= undefined){
			commentnum = data.relatedlistcount['comment'];
			if(commentnum>99)
				commentnum = 99;
			commentnum = '<li class="related-count" >'+commentnum+'</li>';
		}	 
		relatedObj ='<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3"><div class="umar-a ub-f1 tx-c"> 相关信息</div></div>';
		relatedObj+='<div ontouchstart="" onclick="lookRelative(\'comment\')" class="ub ub-f1 act-wh t-bla ulab ub-ac  ubb b-gra lis">';
			relatedObj+='<li class="ub-f1 ut-s t-gra1"> 相关点评</li>'+commentnum+'<li class="res8 lis-sw ub-img"></li></div>';
		setHtml("relative",relatedObj);
			
		$$("relative").style.display='block';
	}
}

AccountrecordsObj.prototype.setCreatePageBind=function(){  //创建(实例方法)
	this.theWindow = 'CreateNewPage';
	this.action = 'get_create_field';
	this.cacheFlag = false;
	this.rest_data = '[{"session":"' + this.CurrentUserId +'",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"select_fields":"","link_name_to_fields_array":""}]';
	this.RequestServer();
}; 

AccountrecordsObj.prototype.setEditPageBind=function(){  //编辑(实例方法)
	this.theWindow = 'EditPage';
	this.CurrentAccountrecordsId = getstorage("CurrentAccountrecordsId");
	this.action = 'get_edit_field';
	this.rest_data = '[{"session":"' + this.CurrentUserId +'",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"module_id":"' + this.CurrentAccountrecordsId + '"}]';
	this.RequestServer();
}; 

AccountrecordsObj.prototype.ShowEditPage = function(data){ //显示编辑表单(实例方法)
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
				if (field[j].name == "accountrecordsname") {
					field[j].value = "服务主题";
					field[j].mandatory = 1;
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
				}else if (field[j].fieldtype == "switch") {	
					var checked = ''
					if(field[j].fieldvalue == 1){
						checked= "checked = true";
					}
					forumObj += '<input type="checkbox" id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" '+checked+' style="display:none" class=\"' + module_name + 'Box\">';	
					forumObj += '<div class="swi uc-a1 uba b-gra umar-l"  ontouchstart="zy_touch(\'\',zy_for)">';
						forumObj += '<div class="uabs swi-btn us"></div>';
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
		//setAnnouncementReceiverInfo(data.userArr);
		$$("buttondiv").style.display='block';	
		setstorage('theMode','editAccountrecords');
	}
}

AccountrecordsObj.prototype.ShowCreatePage = function(data){ //显示创建表单(实例方法)
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
				if (field[j].name == "assigned_user_id") {
					continue;
				}
				if (field[j].name == "accountrecordsname") {
					field[j].value = "服务主题";
					field[j].mandatory = 1;
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
					}else if (field[j].fieldtype == "contactid") {
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
					}else if (field[j].fieldtype == "switch") {	
						forumObj += '<input type="checkbox" id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" value="" style="display:none" class=\"' + module_name + 'Box\">';	
						forumObj += '<div class="swi uc-a1 uba b-gra umar-l"  ontouchstart="zy_touch(\'\',zy_for)">';
							forumObj += '<div class="uabs swi-btn us"></div>';
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
			forumObj += '</div>';
		}
		setHtml("createform", forumObj);
		$$("buttondiv").style.display='block';	
		setstorage('theMode','addAccountrecords');
	}	
}

AccountrecordsObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(this.action){
		case 'get_entry_list':
			this.ShowList(data);
			break;
		case 'get_entry':
			this.ShowDetail(data);
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

AccountrecordsObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.toast(0, 5, "操作成功", 2000);
		openAccountrecordssDetail(data.record,"modules/Accountrecordss/");
		uexWindow.evaluateScript('AccountrecordssListPage', '0', "searchList()");
		uexWindow.evaluateScript(this.theWindow, '0', 'closeWin()');
	}else{
		myalert(data.record);
	}
}; 

AccountrecordsObj.prototype.SaveNew=function(){  //保存(实例方法)
	var validInput = this.ValidateCheck();
    if (validInput) {
		var inputs = getElementsByClassName(this.name + "Box");
		var inputlen = inputs.length;
		var select_fields = '';
		for (var i = 0; i < inputlen; i++) {
			inputs[i].value = removeHTMLTag(inputs[i].value);
			if(inputs[i].type=='checkbox' && inputs[i].checked){
				inputs[i].value = 1;
			}
			select_fields += "&" + inputs[i].name + "=" + inputs[i].value;
		}
		this.tip = 0;
		this.action = 'set_entry_save';
		this.rest_data = '[{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","action":"'+this.action+
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","link_name_to_fields_array":"","record":"' +this.CurrentAccountrecordsId +'"}]';
		this.RequestServer();
	}
}; 

var receiverid = [];
function openAccountrecordssDetail(id,res){  //打开详细页面
	setstorage('CurrentAccountrecordsId', id);
	openwin('AccountrecordssDetailsPage',res);
}

function openSelectUserPage(){
	openwin('userlist','modules/',10,0);
}

function setAnnouncementReceiverInfo(userArr){
	var userInfo;
	for(var i=0;i<userArr.length;i++){
		userInfo = {
			'id':userArr[i]['id'],
			'user_name':userArr[i]['user_name']
		}
		addReceiver(userInfo);	
	}
}
//添加共享人
function addReceiver(userInfo){
	var userInfo = arguments[0] || JSON.parse(getstorage('selInfo')); 
	if (isDefine(userInfo.id) && !receiverid.in_array(userInfo.id)) {  //如果客户没有在关联列表
		receiverid.push(userInfo.id);
		var forumObj = $$('recevier_name').innerHTML;
		var douhao = '';
		if(forumObj != ''){
			 douhao = ',';
		}
		forumObj += '<a onclick="openpop_user(\'' + userInfo.id + '\');return false;" id="user_'+userInfo.id+'" href="">'+douhao + userInfo.user_name + '</a>';
		setHtml('recevier_name', forumObj);
		$$('mobileAnnouncementsannouncement981').value = removeHTMLTag($$('recevier_name').innerHTML);
	}
}; 

//共享人pop
function openpop_user(id){
	uexWindow.cbActionSheet = function(opId, dataType, data){
		if (data == "0") {
			removeNode('user_'+id);
			for (var k in receiverid) {
				if (receiverid[k] == id) {
					receiverid.splice(k, 1);
					break;
				}
			}
		}
	}
	var value = ["删除"];
	uexWindow.actionSheet('', '取消', value);
}
