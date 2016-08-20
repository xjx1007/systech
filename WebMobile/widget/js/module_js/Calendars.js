/**
 * 日程安排
 */
set_input_msg();
function CALObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      CALObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
	this.CurrentActivityId = 0;
	this.CurrentAccountId = 0;
	this.reType = '';
	this.mode = '';
	this.theWindow = '';
};

CALObj.prototype.GetFanWeiFromServer=function(){  //获取范围(实例方法)
	this.method = 'get_fanwei_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
            '"module_name":"Mycalendars"}';
	this.RequestServer();
}; 

CALObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_entry':
			this.ShowDetail(data);
			break;
		case 'get_performances_entry_list':
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
		case 'get_fanwei_list':
			setHtml("fanweisel", data);
			selectValue("fanweisel","current_user");
			break;
	}
};  

CALObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	var startDate = getstorage("startDate");
	var endDate = getstorage("endDate");
	var fanweisel = getstorage("fanweisel");
	this.method = 'get_performances_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"startDate":"' + startDate + '",' +
        '"endDate":"' + endDate + '",' +
		'"fanweisel":"' + fanweisel + '"}';
	this.RequestServer();
}; 

CALObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	var listObj = data;
	//alert(JSON.stringify(data.entry_list));
	if (data !== undefined && data.entry_list !== undefined) {
		var calendarList = data.entry_list;
		for (var i = 0; i < calendarList.length; i++) {
			var calendar = calendarList[i].entries;
			var whitebg = "c-wh";
			if(i%2==0)
				whitebg ='';
			forumObj += '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openCalendarDetail('+calendarList[i].mycalendarsid+',\'\');"class="ubb b-gra '+whitebg+'">';	
			
			forumObj += '<div class="b-gra uinn3">';	
			forumObj += '<div class="ub t-bla ulab ub-ac">';
			forumObj += '<div class="ub-f1 ilogin detail_li_text">'+ calendar.date_start.value.replace(/-/g,'/')+' - '+calendar.due_date.value.replace(/-/g,'/')+'</div>';
			forumObj += '</div></div>';
			
			forumObj +='<div class="ub ub-ac"><div class="ub-f1">';
			forumObj += '<div class="b-gra uinn3">';	
			forumObj += '<div class="ub t-bla ulab ub-ac">';
			forumObj += '<div class="wd_wh detail_ul_text t-gra1">' + calendar.subject.name + '</div>';
			forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.subject.value+'</div>';
			forumObj += '</div></div>';
			
			forumObj += '<div class="b-gra uinn3">';	
			forumObj += '<div class="ub t-bla ulab ub-ac">';
			forumObj += '<div class="wd_wh detail_ul_text t-gra1">' + calendar.priority.name + '</div>';
			forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.priority.value+'</div>';
			forumObj += '</div></div>';
			
			forumObj += '<div class="b-gra uinn3">';	
			forumObj += '<div class="ub t-bla ulab ub-ac">';
			forumObj += '<div class="wd_wh detail_ul_text t-gra1">' + calendar.eventstatus.name + '</div>';
			forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.eventstatus.value+'</div>';
			forumObj += '</div></div>';
			
			forumObj += '<div class="b-gra uinn3">';	
			forumObj += '<div class="ub t-bla ulab ub-ac">';
			forumObj += '<div class="wd_wh detail_ul_text t-gra1">' + calendar.user_name.name + '</div>';
			forumObj += '<div class="ub-f1 ilogin detail_li_text">'+calendar.user_name.value+'</div>';
			forumObj += '</div></div>';
			forumObj +='</div><div class="res8 lis-sw ub-img"></div></div>';
			forumObj +='</div>';
		}
		if(calendarList.length == 0){
			forumObj += showNotRecordDiv();
		}
	}
	setHtml("calendars_list", forumObj);
}

CALObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentActivityId = getstorage("CurrentActivityId");  //id
	this.method = 'get_entry';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentActivityId + '"}';
	this.RequestServer();
}; 

CALObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){
		forumObj += showNotPermittedDiv();
		setHtml("calendardetails_list", forumObj);
		return false;
	}
	if(data.isedit == 'yes'){
		uexWindow.evaluateScript('CalendarDetailsPage', '0', "showEditButton()");
	}
	var detailObj = data.details;
	if ((detailObj !== undefined) && (detailObj.entry_list !== undefined)) {
		var order = detailObj.entry_list;
		var listlen = order.length;
		var subname =  order[0].field[0].value;
//		forumObj += '<div class="uinn">';
//		forumObj += '<div class="ub ub-fh bb_line">';
//			forumObj += '<div class="umar-b">'+subname+'</div>';
//		forumObj += '</div>';
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
				var div_class = 'class="ub ub-f1 t-bla ulab ub-ac uinn3 ubb b-gra"';
				if (nn == notNulls) {
					div_class = 'class="ub ub-f1 t-bla ulab ub-ac uinn3"';
				}
				if (field[j].name == "电话" || field[j].name == '办公电话'|| field[j].name == '手机') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="phonedial(\'' + field[j].value + '\');" class="uinn4  t-blu3 tx_bold ">'+field[j].value+'</div>';
				}else if (field[j].name == 'Email') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="mailsend(\'' + field[j].value + '\');" class="uinn4  t-blu3 tx_bold ">'+field[j].value+'</div>';
				}else if (field[j].name == '网站') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openwebsite(\'' + field[j].value + '\');" class="uinn4 t-blu3 tx_bold ">'+field[j].value+'</div>';
				}else if (field[j].link == 1) {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openDetailTab(\''+field[j].re_module+'\',\''+field[j].link_id+'\',\''+field[j].link_modulename+'\',\'../\');" class="uinn4 t-blu3 tx_bold">'+field[j].value+'</div>';
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
					forumObj += '<div class="detail_bt">' + j + ':</div>';
					forumObj += '<div class="ub-f1 detail_nr ub">' + field[i][j] + '</div>';
					forumObj += '</div>';
				}
				forumObj += '</div>';
			}
		}
		forumObj += '</div>';
		setHtml("calendardetails_list", forumObj);
	}
}

CALObj.prototype.setCreatePageBind=function(){  //创建(实例方法)
	this.theWindow = 'CreateNewPage';
	this.method = 'get_create_field';
	this.cacheFlag = true;
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

CALObj.prototype.ShowCreatePage = function(data){ //显示创建表单(实例方法)
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
					}else if (field[j].fieldtype == "potentialid") {
						forumObj += '<div class="ub-f1 ilogin uinn4">';
						forumObj += '<input id="potentialid" name=\"' + field[j].name + '\" readonly="" type="text" style="display:none" class=\"' + module_name + 'Box\">';
						forumObj += '<input id="potentialname" name="potentialname" placeholder=\"' + field[j].value + '\" readonly="" onclick="openSelectPage(\'potential\',\'\')" type="text">';
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
						forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setDateMore(\'' + module_name + field[j].name + '\')" class="ub-f1 uc-a1 uinput b-gra uba us-i1 uinn4 ub ub-rev">';
						forumObj += '<div class="umh1 umw1 tx-c t-blu3 umar-a"><i class="icon-calendar"></i>&nbsp;</div><div class="ub-f1"><input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=""  type="text" class=\"' + module_name + 'Box\" readonly value="' + theDate + '"></div>';
						forumObj += '</div>';
					//forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setDateMore(\''+ module_name + field[j].name + '\')" class="btn uba b-bla uinn5 c-blu c-m2 uc-a1 t-wh">选择</div>';						
					}else if(field[j].fieldtype == "time"){
						var theTime = currTime;
						if(field[j].name == "time_end")theTime = endTime;
						forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setTimeMore(\''+ module_name + field[j].name + '\')" class="ub-f1 uc-a1 uinput b-gra uba us-i1 uinn4 ub ub-rev">';
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
			forumObj += '</div>';
		}
		setHtml("createform", forumObj);	
		if(this.CurrentAccountId > 0){
			var accInfo = {
				'id':data.account['id'],
				'name':data.account['name'],
				'contacts':data.account['contact']
			}
			setAccInfo(accInfo);
		}
		//$$("buttondiv").style.display='block';	
	}
}

CALObj.prototype.setEditPageBind=function(){  //编辑(实例方法)
	this.theWindow = 'EditPage';
	this.CurrentActivityId = getstorage("CurrentActivityId");
	this.method = 'get_edit_field';
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'",'+
		'"module_id":"' + this.CurrentActivityId + '"}';
	this.RequestServer();
}; 

CALObj.prototype.ShowEditPage = function(data){ //显示编辑表单(实例方法)
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
				if (field[j].name == "assigned_user_id") {
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
				}else if (field[j].fieldtype == "potentialid") {
					forumObj += '<div class="ub-f1 ilogin uinn4">';
					forumObj += '<input id="potentialid" name=\"' + field[j].name + '\" readonly="" type="text" style="display:none" class=\"' + module_name + 'Box\">';
					forumObj += '<input id="potentialname" name="potentialname" placeholder=\"' + field[j].value + '\" readonly="" onclick="openSelectPage(\'potential\',\'\')" type="text">';
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
		var accInfo = {
			'id':data.account['id'],
			'name':data.account['name'],
			'contacts':data.account['contact'],
			'contactid':data.account['contactid']
		}
		setConInfo(accInfo);
		//$$("buttondiv").style.display='block';	
	}
}

CALObj.prototype.SaveNew=function(){  //保存(实例方法)
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
		this.rest_data = '{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","link_name_to_fields_array":"","record":"' +this.CurrentActivityId +'"}';
		this.method = 'set_entry_save';
		this.tip = 0;
		this.RequestServer();
	}
}; 

CALObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		var thePage = getstorage('thePage');
		uexWindow.toast(0, 5, "操作成功", 2000);
		openCalendarDetail(data.record,"modules/Calendars/");
		if (thePage == "Account") {
			uexWindow.evaluateScript('AccountRelativePage', '0', "refreshRelative()");
		}else if(thePage == "Home") {
			
		}else {
			uexWindow.evaluateScript('CalendarsListPage','0',"getPageNewInfo()");
		}
		uexWindow.evaluateScript(this.theWindow, '0', 'closeWin()');
	}else{
		myalert(data.record);
	}
}; 

function openCalendarDetail(activityid,res){//打开详细页面
	setstorage('CurrentActivityId', activityid);
	openwin('CalendarDetailsPage',res);
}

function checkTime(){//检查开始时间/结束时间
	var date_start = $$('mobileCalendarsdate_start').value;
	var time_start = $$('mobileCalendarstime_start').value;
	var due_date = $$('mobileCalendarsdue_date').value;
	var time_end = $$('mobileCalendarstime_end').value;
	var arrStartDate = date_start.split("-");   
    var arrStartTime = time_start.split(":");   
	var arrDueDate = due_date.split("-");   
    var arrEndTime = time_end.split(":");   
	var allStartDate = new Date(arrStartDate[0],arrStartDate[1]-1,arrStartDate[2],arrStartTime[0],arrStartTime[1]); 
	var allEndDate = new Date(arrDueDate[0],arrDueDate[1]-1,arrDueDate[2],arrEndTime[0],arrEndTime[1]); 
	if(allStartDate.getTime()>allEndDate.getTime()){   
         return false;   
    }
	return true;   
}

function setNewDate(id){// 设置新的日期/时间
	if (id == 'mobileCalendarsdate_start' || id == 'mobileCalendarstime_start') {
		var date_start = $$('mobileCalendarsdate_start').value;
		var time_start = $$('mobileCalendarstime_start').value;
		var endDateObj = getNextHours(date_start, time_start);
		var endDate = formatDate(endDateObj);
		var endTime = getFullFormat(endDateObj.getHours()) + ':' + getFullFormat(endDateObj.getMinutes());
		$$('mobileCalendarsdue_date').value = endDate;
		$$('mobileCalendarstime_end').value = endTime;
	}else{
		var due_date = $$('mobileCalendarsdue_date').value;
		var time_end = $$('mobileCalendarstime_end').value;
		var startDateObj = getLastHours(due_date, time_end);
		var startDate = formatDate(startDateObj);
		var startTime = getFullFormat(startDateObj.getHours()) + ':' + getFullFormat(startDateObj.getMinutes());
		$$('mobileCalendarsdate_start').value = startDate;
		$$('mobileCalendarstime_start').value = startTime;
	}
}