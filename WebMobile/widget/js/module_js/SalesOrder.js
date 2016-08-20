set_input_msg();
function SOObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      SOObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
	this.CurrentSalesOrderId = 0;
	this.CurrentAccountId = 0;
	this.CurrentPotentialId = 0;
	this.reType = '';
	this.mode = '';
	this.theWindow = '';
	this.products = [];  //新产品信息
	this.list = [];   //原产品信息
	this.so_total = 0;  //总计
	this.so_adjustment = 0; //调整值
	this.pro_isChange = 0; //确定编辑次数 
};

SOObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	var viewsel = getstorage("salesorder_viewId");   //视图id
	this.method = 'get_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"query":"'+searchtext+'",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + ',' +
        '"sel":"'+viewsel+'"}';
	this.RequestServer();
}; 

SOObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	if(data.entry_list.islook !== undefined && data.entry_list.islook == 'no'){//列表加权限 added by ligangze on 2014/8/22
		forumObj += showNotPermittedDiv();
		setHtml("salesorder_list", forumObj);
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
				forumObj +='<ul onclick="openSalesOrderDetail('+theBill.id+',\''+theBill.name_value_list.sostatus.value+'\',\'\');" class="ubb ub b-gra ub-ac lis act-wh '+whitebg+'">';
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
		if(listObj.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("salesorder_list", forumObj);
		if(listObj.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', listObj.lastpg);
			uexWindow.evaluatePopoverScript('SalesOrderListPage','pop_nav',"setPageSel()");
		}
	}
}

SOObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentSalesOrderId = getstorage("CurrentSalesOrderId");   //id
	this.method = 'get_entry';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentSalesOrderId + '"}';
	this.RequestServer();
}; 

SOObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){
		forumObj += showNotPermittedDiv();
		setHtml("salesorderdetails_list", forumObj);
		return false;
	}
	if(data.isedit == 'yes' && getstorage('edit') != 'false'){
		uexWindow.evaluateScript('SalesOrderDetailsPage', '0', "showEditButton()");
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
			forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">'+otherInfo.title+'</div>';
			forumObj += '</div>';
			
			div_class = 'class="ub ub-f1 t-bla ulab ub-ac uinn3"';
			var field = otherInfo.field;
			var fieldlen = field.length;
			for (var i = 0; i < fieldlen; i++) {
				forumObj += '<div class="ub ub-ver umar-a uc-a1 b-gra uba" >';
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
		forumObj += '<div class="ub ub-f1 umar-a uinn3 uba c-wh uc-a1 b-gra">';
			forumObj += '<div class="ub-f1 detail_nr ub t-bla">调整:<span class="li_4 ulev0">'+data.so_adjustment+'</span></div>';
			forumObj += '<div class="ub-f1 detail_nr ub t-bla">总计:<span class="li_4 ulev0">'+data.so_total+'</span></div>';
		forumObj += '</div>';
		forumObj += '</div>';
		setHtml("salesorderdetails_list", forumObj);
		
		var commentnum ="";
		var gather ="";
		var billings ="";
		
		if(data.relatedlistcount['Gathers']!=0 && data.relatedlistcount['Gathers']!= undefined){
			gather = data.relatedlistcount['Gathers'];
			if(gather>99)
				gather = 99;
			gather = '<li class="related-count" >'+gather+'</li>';
			
		}
		if(data.relatedlistcount['Billings']!=0 && data.relatedlistcount['Billings']!= undefined){
			billings = data.relatedlistcount['Billings'];
			if(billings>99)
				billings = 99;
			billings = '<li class="related-count" >'+billings+'</li>';
			
		}
		if(data.relatedlistcount['comment']!=0 && data.relatedlistcount['comment']!= undefined){
			commentnum = data.relatedlistcount['comment'];
			if(commentnum>99)
				commentnum = 99;
			commentnum = '<li class="related-count" >'+commentnum+'</li>';
			
		}
		relatedObj = '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3"><div class="umar-a ub-f1 tx-c"> 相关信息</div></div>';
		relatedObj +='<div ontouchstart="" onclick="lookRelative(\'comment\')" class="ub ub-f1 t-bla ulab ub-ac uinn3 ubb b-gra lis">';
           relatedObj += '<li class="ub-f1 ut-s"> 相关点评</li>'+commentnum+'<li class="res8 lis-sw ub-img"> </li></div>';       
        relatedObj+=' <div ontouchstart="" onclick="lookRelative(\'gather\');" class="ub ub-f1 t-bla ulab ub-ac uinn3 ubb b-gra lis">';
           relatedObj+='<li class="ub-f1 ut-s">  应收款 </li>'+gather+'<li class="res8 lis-sw ub-img"></li></div>';
        relatedObj+='<div ontouchstart="" onclick="lookRelative(\'billing\');" class="ub ub-f1 t-bla ulab ub-ac uinn3 lis">';
           relatedObj+='<li class="ub-f1 ut-s">发票</li>'+billings+'<li class="res8 lis-sw ub-img"></li></div>';
				
		setHtml("relative",relatedObj);			


		$$("relative").style.display='block';
	}
}

SOObj.prototype.setCreatePageBind=function(){  //创建(实例方法)
	this.theWindow = 'CreateNewPage';
	this.method = 'get_create_field';
	this.cacheFlag = true;
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
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'","select_fields":"","link_name_to_fields_array":"","setype":"' + setype + '",'+
		'"record":"' + record + '"}';
	this.RequestServer();
}; 

SOObj.prototype.ShowCreatePage = function(data){ //显示创建表单(实例方法)
	setstorage("shopCar", '');
	setstorage("so_total", '');
	setstorage("so_adjustment", '');
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
					}else {
						forumObj += '<div class="ub-f1 ilogin uinn4">';
						if (field[j].name == 'ordernum' || field[j].name == 'ordertotal') {
							forumObj += '<input id=\"' + module_name + field[j].name + '\" name=\"' + field[j].name + '\" placeholder=\"' + field[j].value + '\" ' + input_msg + ' onchange="checkIsPositiveNumble(this)" type="numble" class=\"' + module_name + 'Box\">';
						}
						else {
							var fieldValue = '';
							if(field[j].name == "subject"){
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
			forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
			forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
				forumObj += '<div class="umar-a ub-f1 tx-c">产品信息</div>';
			forumObj += '</div>';		
		forumObj += '<div class="ub ub-f1 ubb ulab ub-ac uinn3 b-gra">';
		forumObj += '<div class="detail_bt t-gra1">购物车 </div><span id="productNum" class="ilogin">'+this.products.length+'</span>';
		forumObj += '<div class="ub-f1 ilogin uinn3" ontouchstart="zy_touch(\'btn-act\');" onclick="createobj.LookShopCar();" >';
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
		//$$("buttondiv").style.display='block';	
	}
}

SOObj.prototype.setEditPageBind=function(){  //编辑(实例方法)
	this.theWindow = 'EditPage';
	this.CurrentSalesOrderId = getstorage("CurrentSalesOrderId");
	this.method = 'get_edit_field';
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'",'+
		'"module_id":"' + this.CurrentSalesOrderId + '"}';
	this.RequestServer();
}; 

SOObj.prototype.ShowEditPage = function(data){ //显示编辑表单(实例方法)
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
		this.list = data.products['list'];
		this.so_total = Number(data.products['so_total']);
		this.so_adjustment = Number(data.products['so_adjustment']);
		forumObj += '<div class=" uc-a1 umar-a uba b-gra c-wh">';
		forumObj += '<div class="ub ub-f1 ubb ulab b-gra ub-ac uinn3">';
		forumObj += '<div class="umar-a ub-f1 tx-c">产品信息</div>';
		forumObj += '</div>';
		forumObj += '<div class="ub ub-f1 ubb ulab ub-ac uinn3 b-gra">';
		forumObj += '<div class="detail_bt t-gra1">购物车</div><span id="productNum" class="ilogin">'+data.products['list'].length+'</span>';
		forumObj += '<div class="ub-f1 ilogin uinn3" ontouchstart="zy_touch(\'btn-act\');" onclick="createobj.LookShopCar();">';
		forumObj += '<div class="uinn3 ufr"><div class="umw2 ub ub-pc uc-r ub-ac uc-r1"><div class="ub-img umw1 umh1 res8"></div></div></div>';
		forumObj += '</div>'; 
		forumObj += '</div>'; 
		setHtml("createform", forumObj);	
		this.PutProListToShopCar();
		//$$("buttondiv").style.display='block';	
	}
}

SOObj.prototype.ChangeProducts = function(){ //修改了产品详细(实例方法)
	this.products = JSON.parse(getstorage("shopCar"));
	setHtml("productNum",this.products.length);
	this.so_total = getstorage("so_total");
	this.so_adjustment = getstorage("so_adjustment");
	this.pro_isChange++;
}

SOObj.prototype.PutProListToShopCar = function(){ // 编辑订单时将产品加入购物车(实例方法)
	var product;
	var arrValue = [];
	for (var i = 0; i < this.list.length; i++) {
		product = this.list[i];
		arrValue[i] = {
			'id': product.productid,
			'code': product.productcode,
			'serialno': product.serialno,
			'name': product.productname,
			'price': product.unit_price,
			'num': product.quantity,
			'decri': ''
		};
	}
	setstorage("shopCar", JSON.stringify(arrValue));
	setstorage('so_total',Number(this.so_total));
	setstorage('so_adjustment',Number(this.so_adjustment));
	this.products = arrValue;
}

SOObj.prototype.LookShopCar = function(){ // 进入购物车
	if (this.pro_isChange == 0) {
		
	}else{
		setstorage("shopCar", JSON.stringify(this.products));
		setstorage("so_total", this.so_total);
		setstorage("so_adjustment", this.so_adjustment);
	}
	openwin('EditProductPage','modules/SalesOrder/');
}

SOObj.prototype.SaveNew=function(){  //保存(实例方法)
	var validInput = this.ValidateCheck();
    if (validInput) {
		if(this.products.length == 0){
			myalert("产品信息不能为空!");
			return false;
		}
		var inputs = getElementsByClassName(this.name + "Box");
		var inputlen = inputs.length;
		var select_fields = '';
		for (var i = 0; i < inputlen; i++) {
			inputs[i].value = removeHTMLTag(inputs[i].value);
			//if (inputs[i].value != '') {
				select_fields += "&" + inputs[i].name + "=" + inputs[i].value;
			//}
		} 
		var products = '';
		select_fields += "&txtAdjustment="+this.so_adjustment;
		select_fields += "&hdnGrandTotal="+this.so_total;
		var arrValue = this.products;
		products += "&totalProductCount="+arrValue.length;
		for (j = 0; j < arrValue.length; j++) {
			products += "&hdnProductId"+j+"="+arrValue[j].id;
			products += "&qty"+j+"="+arrValue[j].num;
			products += "&listPrice"+j+"="+arrValue[j].price;
			products += "&comment"+j+"="+arrValue[j].decri;
		}
		
		this.rest_data = '{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","link_name_to_fields_array":"","record":"' +this.CurrentSalesOrderId +
			'","products":'+getstorage("shopCar")+'}';
		this.method = 'set_entry_save';
		this.tip = 0;
		this.RequestServer();
	}
}; 

SOObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.toast(0, 5, "添加成功", 2000);
		setstorage("shopCar",'');
		setstorage("so_adjustment",'');
		setstorage("so_total",'');
		openSalesOrderDetail(data.record,'已创建',"modules/SalesOrder/");
		var thePage = getstorage('thePage');
		if (thePage == "Account") {
			uexWindow.evaluateScript('AccountRelativePage', '0', "refreshRelative()");
		}else if(thePage == "Home") {
			
		}else {
			uexWindow.evaluateScript('SalesOrderListPage', '0', "searchList()");
		}
		uexWindow.evaluateScript(this.theWindow, '0', 'closeWin()');
		uexWindow.evaluateScript('EditProductPage', '0', 'closeWin()');
	}else{
		myalert(data.record);
	}
}; 

SOObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
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

SOObj.prototype.setReModuleBind=function(){  //获取相关信息(实例方法)
	this.CurrentSalesOrderId = getstorage("CurrentSalesOrderId");   //id
	this.method = 'get_relatedlists_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"module_id":"' + this.CurrentSalesOrderId + '",'+
		'"link_field_name":"'+this.reModule+'"}';
	this.RequestServer();
}; 

SOObj.prototype.ShowReModuleList = function(data){ //显示相关信息列表(实例方法)
	var forumObj = '';
	this.reType = getstorage('reType');
	switch(this.reType){
		case 'gather':
			forumObj += setSaleOrderGathersBind(data);
			break;
		case 'billing':
			forumObj += setSaleOrderBillingsBind(data);
			break;
	}
	if(forumObj == ''){
		forumObj += showNotRecordDiv();
	}
	setHtml("records_list", forumObj);
}

//合同订单 应收款
function setSaleOrderGathersBind(data){
	var forumObj = '';
	var listObj = data;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var theBill = listObj[i];
		if(theBill.name_value_list != ''){
			forumObj +='<ul onclick="openDetailTab(\'Gathers\',\''+theBill.id+'\',\'应收款\',\'../\');" class="ubb ub b-gra ub-ac lis act-wh">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub li_1">';
			forumObj +='<div class="ub-f2">'+theBill.name_value_list.gathername.value+'</div>';
			forumObj +='<div class="ub-f1"><span class="li_3" style="float:right"><i class="icon-calendar"></i>&nbsp;'+theBill.name_value_list.plandate.value+'</span></div></li>';
			forumObj +='<li class="ub li_3">';
			forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-paper-clip"></i>&nbsp;'+theBill.name_value_list.gatherstatus.value +'</span></div>';
			forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-coin"></i>&nbsp;'+theBill.name_value_list.planamount.value +'</span></div>';
			forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-user"></i>&nbsp;'+theBill.name_value_list.user_name.value +'</span></div></li>';      
			forumObj +='<li class="ub li_3"><i class="icon-home"></i>&nbsp;'+theBill.name_value_list.accountname.value +'</li>';       //客户名称
			forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
		}
	}
	return forumObj;
}

//合同订单 发票
function setSaleOrderBillingsBind(data){
	var forumObj = '';
	var listObj = data;
	var listlen = listObj.length;
	for(var i=0;i<listlen;i++){
		var theBill = listObj[i];
		if(theBill.name_value_list != ''){
			forumObj +='<ul onclick="openDetailTab(\'Billings\',\''+theBill.id+'\',\'发票\',\'../\');" class="ubb ub b-gra ub-ac lis act-wh">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub li_1">';
			forumObj +='<div class="ub-f2">'+theBill.name_value_list.billingname.value+'</div>';
			forumObj +='<div class="ub-f1"><span class="li_3" style="float:right"><i class="icon-calendar"></i>&nbsp;'+theBill.name_value_list.billingdate.value+'</span></div></li>';
			forumObj +='<li class="ub li_3">';
			forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-paper-clip"></i>&nbsp;'+theBill.name_value_list.billingno.value +'</span></div>';
			forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-coin"></i>&nbsp;'+theBill.name_value_list.billingamount.value +'</span></div>';
			forumObj +='<div class="ub-f1"><span class="li_3_2"><i class="icon-user"></i>&nbsp;'+theBill.name_value_list.user_name.value +'</span></div></li>';      
			forumObj +='<li class="ub li_3"><i class="icon-home"></i>&nbsp;'+theBill.name_value_list.accountname.value +'</li>';       //客户名称
			forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
		}
	}
	return forumObj;
}


function openSalesOrderDetail(id,sostatus,res){  // 打开详细
	setstorage('CurrentSalesOrderId', id);
	if(sostatus == '待批准' || sostatus == '已创建'){
		setstorage('edit', 'true');
	}else{
		setstorage('edit', 'false');
	}
	openwin('SalesOrderDetailsPage',res);
}


