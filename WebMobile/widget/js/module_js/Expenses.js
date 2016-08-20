set_input_msg();
function ExpenseObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      ExpenseObj.prototype[attr] = Module.prototype[attr];
	};
	this.method = 'handleRequest';
	this.offset = 1;
	this.CurrentExpenseId = 0;
	this.CurrentAccountId = 0;
	this.CurrentPotentialId = 0;
	this.reType = '';
	this.mode = '';
	this.theWindow = '';
	this.products = [];  //新产品信息
	this.pro_isChange = 0; //确定编辑次数 
};

ExpenseObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	var viewsel = getstorage("expense_viewId");   //视图id
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

ExpenseObj.prototype.ShowList = function(data){ //显示列表(实例方法)
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
			var whitebg = "c-wh";
			if(i%2==0)
				whitebg = "";
			if (listObj.entry_list[i] !== undefined) {
				var theBill = listObj.entry_list[i];
				var theBillPText = '';
								
				forumObj +='<ul onclick="openExpenseDetail('+theBill.id+',\''+theBill.expensestatus+'\',\'\');" class="ub ub-ac lis act-wh '+whitebg+'">';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub ub-f1"><div class="li_2_2 ub-f1"><i class="icon-home"></i>&nbsp;<span class="li_2_text">'+theBill.expensename+'</span></div></li>';
				forumObj +='<li class="li_2_2"><i class="icon-user"></i>&nbsp;'+theBill.smownerid+'</li>';  
				forumObj +='</ul><div class="ufr li_4">'+theBill.expensestatus+'</div></ul>';
		
			}
		}
		if(listObj.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("record_list", forumObj);
		if(listObj.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', listObj.lastpg);
			uexWindow.evaluatePopoverScript('ExpenseListPage','pop_nav',"setPageSel()");
		}
	}
}

ExpenseObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentExpenseId = getstorage("CurrentExpenseId");   //id
	this.action = 'get_entry';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
		'"id":"' + this.CurrentExpenseId + '"}]';
	this.RequestServer();
}; 

ExpenseObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var forumObj = '';
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){
		forumObj += showNotPermittedDiv();
		setHtml("details_list", forumObj);
		return false;
	}
	if(data.isedit == 'yes' && getstorage('edit') != 'false'){
		uexWindow.evaluateScript('ExpenseDetailsPage', '0', "showEditButton()");
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
				var div_class = 'class="ub ub-f1 t-bla ulab ub-ac uinn3 ubb b-gra"';
				if (nn == notNulls) {
					div_class = 'class="ub ub-f1 t-bla ulab ub-ac uinn3"';
				}
				if (field[j].name == "电话" || field[j].name == '办公电话'|| field[j].name == '手机') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="phonedial(\'' + field[j].value + '\');" class="uinn4 t-blu3 tx_bold">'+field[j].value+'</div>';
				}else if (field[j].name == 'Email') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="mailsend(\'' + field[j].value + '\');" class="uinn4 t-blu3 tx_bold ">'+field[j].value+'</div>';
				}else if (field[j].name == '网站') {
					field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openwebsite(\'' + field[j].value + '\');" class="uinn4 t-blu3 tx_bold">'+field[j].value+'</div>';
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
			forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">'+otherInfo.title+'</div>';
			forumObj += '</div>';
			
			div_class = 'class="ub ub-f1 t-bla ulab ub-ac uinn3"';
			var field = otherInfo.field;
			var fieldlen = field.length;
			for (var i = 0; i < fieldlen; i++) {
				forumObj += '<div class="ub ub-ver umar-a uc-a1 b-gra uba">';
				for (var j in field[i]) {
					if (!isDefine(field[i][j])) 
						continue;
					forumObj += '<div ' + div_class + '>';
					forumObj += '<div class="detail_bt t-gra1">' + j + '</div>';
					forumObj += '<div class="ub-f1 detail_nr ub">' + field[i][j] + '</div>';
					forumObj += '</div>';
				}
				forumObj += '</div>';
			}
			forumObj += '</div>';
		}
		forumObj += '</div>';
		setHtml("details_list", forumObj);
		$$("relative").style.display='block';
	}
}

ExpenseObj.prototype.setCreatePageBind=function(){  //创建(实例方法)
	this.theWindow = 'CreateNewPage';
	this.cacheFlag = false;
	var thePage = getstorage('thePage');
	var record = 0;
	var setype = "";
	if (thePage == "Potential") {
		this.cacheFlag = false;
		this.CurrentPotentialId = getstorage("CurrentPotentialId");
		setype = 'Potential';
		record = this.CurrentPotentialId;
	}else if(thePage == "Account") {
		this.cacheFlag = false;
		this.CurrentAccountId = getstorage("CurrentAccountId");
		setype = 'Account';
		record = this.CurrentAccountId;
	}
	this.action = 'get_create_field';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
		'"setype":"'+this.setype+'",'+
		'"record":"' + record + '"}]';
	this.RequestServer();
}; 

var mxopts;
ExpenseObj.prototype.ShowCreatePage = function(data){ //显示创建表单(实例方法)
	setstorage("shopCar", '');
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
							forumObj += '<input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=\"' + field[j].value + '\" ' + input_msg + ' onchange="checkIsPositiveNumble(this)" type="numble" class=\"' + module_name + 'Box\">';
						}else {
							var fieldValue = '';
							if(field[j].name == "expensename"){
								fieldValue = data.defaultSubject;
							}
							forumObj += '<input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=\"' + field[j].value + '\" ' + input_msg + ' type="text" class=\"' + module_name + 'Box\" value=\"'+fieldValue+'\">';
						}
						forumObj += '</div>';
					}
				forumObj += '</div>';
			}
			forumObj += '</div>';
		}
		mxopts = data.mxopts;
			forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">费用明细</div>';
			forumObj += '</div>';	

		forumObj += '<div class="ub ub-f1 ubb ulab ub-ac uinn3 b-gra">';
		forumObj += '<div class="detail_bt t-gra1">明细栏 </div><span id="productNum" class="ilogin">'+this.products.length+'</span>';
		forumObj += '<div class="ub-f1 ilogin uinn3" ontouchstart="zy_touch(\'btn-act\');" onclick="createobj.LookShopCar();">';
		forumObj += '<div class="uinn3 ufr"><div class="umw2 ub ub-pc uc-r ub-ac uc-r1"><div class="ub-img umw1 umh1 res8"></div></div></div>';
		forumObj += '</div>'; 
		forumObj += '</div></div>'; 
		setHtml("createform", forumObj);	
		if(this.CurrentAccountId > 0){
			var accInfo = {
				'id':data.account['id'],
				'name':data.account['name'],
				'contacts':data.account['contact']
			}
			setAccInfo(accInfo);
		}	
		if(this.CurrentPotentialId > 0){
			var accInfo = {
				'id':data.account['id'],
				'name':data.account['name'],
				'contacts':data.account['contact'],
				'contactid':data.account['contactid']
			}
			var potInfo = {
				'potentialid':data.account['potentialid'],
				'potentialname':data.account['potentialname']
			}
			setConInfo(accInfo);
			setPotInfo(potInfo);
		}	
		$$("buttondiv").style.display='block';	
	}
}

ExpenseObj.prototype.setEditPageBind=function(){  //编辑(实例方法)
	this.theWindow = 'EditPage';
	this.CurrentExpenseId = getstorage("CurrentExpenseId");
	this.action = 'get_edit_field';
	this.rest_data = '[{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"record":"' + this.CurrentExpenseId + '"}]';
	this.RequestServer();
}; 

ExpenseObj.prototype.ShowEditPage = function(data){ //显示编辑表单(实例方法)
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
					forumObj += '<div id="contact_div" class="ub-f1 ub c-wh uc-a1 b-gra sel">';
					forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l"></div>';
					forumObj += '<div class="umw2 ub ub-pc uc-r ub-ac uc-r1">';  
						forumObj += '<div class="ub-img umw1 umh1 res8"></div>'; 
					forumObj += '</div>';
					forumObj += '<select id="contactid" name=\"'+field[j].name+'\" selectedindex="0" onchange="zy_selectmenu(this.id)" class=\"'+module_name+'Box\">';
					forumObj += '</select>';
					forumObj += '</div>';
				}else if(field[j].fieldtype == "potentialid"){
					forumObj += '<div class="ub-f1 ilogin uinn4">';
					forumObj += '<input id="potentialid" name=\"' + field[j].name +'\" value=\"'+field[j].fieldid+'\" readonly="" type="text" style="display:none" class=\"' + module_name + 'Box\">';
					forumObj += '<input id="potentialname" name="potentialname" placeholder=\"'+field[j].value+'\" value=\"'+field[j].fieldvalue+'\" readonly="" onclick="openSelectPage(\'potential\',\'\')" type="text">';
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
		mxopts = data.mxopts;
		this.products = data.products;
//		forumObj += '<div class="ub ub-fh c-gra b-gra ubb uinn-top">';
//			forumObj += '<div class="umar-b uinn1">费用明细</div>';
//		forumObj += '</div>';
		forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
		forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
		forumObj += '<div class="umar-a ub-f1 tx-c">费用明细</div>';
		forumObj += '</div>';	
		
		forumObj += '<div class="ub ub-f1 ubb ulab ub-ac uinn3 b-gra">';
		forumObj += '<div class="detail_bt t-gra1">明细栏 </div><span id="productNum" class="ilogin">'+data.products.length+'</span>';
		forumObj += '<div class="ub-f1 ilogin uinn3" ontouchstart="zy_touch(\'btn-act\');" onclick="createobj.LookShopCar();" >';
		forumObj += '<div class="uinn3 ufr"><div class="umw2 ub ub-pc uc-r ub-ac uc-r1"><div class="ub-img umw1 umh1 res8"></div></div></div>';
		forumObj += '</div>'; 
		forumObj += '</div></div>'; 
		setHtml("createform", forumObj);	
		setstorage("shopCar", JSON.stringify(this.products));
		$$("buttondiv").style.display='block';	
	}
}

ExpenseObj.prototype.ChangeProducts = function(){ //修改了产品详细(实例方法)
	this.products = JSON.parse(getstorage("shopCar"));
	setHtml("productNum",this.products.length);
	this.pro_isChange++;
}

ExpenseObj.prototype.LookShopCar = function(){ // 进入购物车
	setstorage('mxopts',JSON.stringify(mxopts));
	if (this.pro_isChange == 0) {
		
	}else{
		setstorage("shopCar", JSON.stringify(this.products));
	}
	openwin('EditProductPage','modules/Expenses/');
}

ExpenseObj.prototype.SaveNew=function(){  //保存(实例方法)
	var validInput = this.ValidateCheck();
    if (validInput) {
		if(this.products.length == 0){
			myalert("费用明细不能为空!");
			return false;
		}
		var inputs = getElementsByClassName(this.name + "Box");
		var inputlen = inputs.length;
		var select_fields = '';
		for (var i = 0; i < inputlen; i++) {
			inputs[i].value = removeHTMLTag(inputs[i].value);
			select_fields += "&" + inputs[i].name + "=" + inputs[i].value;
		} 
		this.action = 'set_entry_save';
		this.rest_data = '[{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","action":"' +this.action +
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","record":"' +this.CurrentExpenseId +
			'","products":'+getstorage("shopCar")+'}]';
		this.tip = 0;
		this.RequestServer();
	}
}; 

ExpenseObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.toast(0, 5, "添加成功", 2000);
		setstorage("shopCar",'');
		openExpenseDetail(data.record,'已创建',"modules/Expenses/");
		var thePage = getstorage('thePage');
		if (thePage == "Account") {
			uexWindow.evaluateScript('AccountRelativePage', '0', "refreshRelative()");
		}else if(thePage == "Home") {
			
		}else {
			uexWindow.evaluateScript('ExpenseListPage', '0', "searchList()");
		}
		uexWindow.evaluateScript(this.theWindow, '0', 'closeWin()');
		uexWindow.evaluateScript('EditProductPage', '0', 'closeWin()');
	}else{
		myalert(data.record);
	}
}; 

ExpenseObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(this.action){
		case 'get_entry':
			this.ShowDetail(data);
			break;
		case 'get_entry_list':
			this.ShowList(data);
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
		case 'get_relatedlists_list':
			this.ShowReModuleList(data);
			break;
	}
};  

function openExpenseDetail(id,status,res){  // 打开详细
	setstorage('CurrentExpenseId', id);
	if(status == '待批' || status == '已创建'){
		setstorage('edit', 'true');
	}else{
		setstorage('edit', 'false');
	}
	openwin('ExpenseDetailsPage',res);
}


