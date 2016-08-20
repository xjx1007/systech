/**
 * 销售自动化
 */
set_input_msg();
function SFAObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      SFAObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
	this.CurrentSfaId = 0;
};

SFAObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_entry_list':
			this.ShowList(data);
			break;
		case 'get_entry':
			this.ShowDetail(data);
			break;
		case 'set_entry_save':
			this.SaveReturn(data);
			break;
		case 'jump_run_event':
			this.SaveReturn(data);
			break;
		case 'do_run_event':
			this.SaveReturn(data);
			break;
		case 'do_againRun_event':
			this.SaveReturn(data);
			break;
	}
};  

SFAObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
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

SFAObj.prototype.ShowList = function(data){ //显示列表(实例方法)
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
				forumObj +='<ul onclick="openSfaDetail('+theBill.id+',\'\');" class="ubb ub b-gra ub-ac lis act-wh '+whitebg+'">';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub li_1">';
				forumObj +='<div class="ub-f2">'+theBill.name_value_list.name.value+'</div>';  
				forumObj +='<div class="ub-f1"><span class="li_3" style="float:right"><i class="icon-calendar"></i>&nbsp;'+theBill.name_value_list.datestart.value+'</span></div></li>';
				forumObj +='<li class="ub li_3"><i class="icon-home"></i>&nbsp;'+theBill.name_value_list.accountname.value +'</li>';       //客户名称     
				forumObj +='<li class="ub li_3">'+theBill.name_value_list.zxdz.value +'</li>';  
				forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
			}
		}
		if(listObj.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("sfa_list", forumObj);
		if(listObj.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', listObj.lastpg);
			uexWindow.evaluatePopoverScript('SfaListPage','pop_nav',"setPageSel()");
		}
	}
}

SFAObj.prototype.setDetailsInfo=function(){  //获取详细(实例方法)
	this.CurrentSfaId = getstorage("CurrentSfaId");   //id
	this.method = 'get_entry';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentSfaId + '"}';
	this.RequestServer();
}; 

SFAObj.prototype.ShowDetail = function(data){ //显示 详细(实例方法)
	var detailObj = data;
	var module_name = this.name;
	if ((detailObj !== undefined) && (detailObj.entry_list !== undefined)) {
		var order = detailObj.entry_list;
		var accountid = order[0]['name_value_list']['accountid'];
		var accountname = order[0]['name_value_list']['accountname'];
		var accountLinkObj = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openDetailTab(\'Accounts\','+accountid+',\'\',\'\');" class="uinn4 t-blu3 tx_bold ">'+accountname+'</div>';
		setHtml('sfa_accountname',accountLinkObj);
		setHtml('SFA_fa',order[0]['name_value_list']['sfasettingname']);  // 执行方案
		setHtml('SFA_xl',order[0]['name_value_list']['sfalistname']);   //执行序列
		setHtml('SFA_sj',order[0]['name_value_list']['sj']);  //方案
		var zt = order[0]['name_value_list']['zt']; //状态
		var change = false;
		if(zt == '未执行' || zt == '再次执行'){
			change = true;
		}
		var datestart = order[0]['name_value_list']['datestart'];//开始日期 
		var forumObj = '';
		var id = order[0]['id']; 
		
		forumObj += '<input class="uhide" id=\"' + module_name + '_id\" name="sfa_id" placeholder=""  type="text" readonly value="' + id + '">';
		if (change) {
			forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setDateMore(\'' + module_name + '_datestart\')" class="ub-f1 uc-a1 uinput b-gra uba us-i1 uinn4 ub ub-rev">';
			forumObj += '<div class="umh1 umw1 tx-c t-blu3 umar-a"><i class="icon-calendar"></i>&nbsp;</div><div class="ub-f1"><input id=\"' + module_name + '_datestart\" name="datestart" placeholder=""  type="text" class=\"' + module_name + 'Box\" readonly value="' + datestart + '"></div>';
			forumObj += '</div>';
		}else{
			forumObj += '<input id=\"' + module_name + '_datestart\" name="datestart" placeholder=""  type="text" class=\"' + module_name + 'Box\" readonly value="' + datestart + '">';
		}
		setHtml('SFA_datestart',forumObj);
		var dateend = order[0]['name_value_list']['dateend'];   //结束日期
		forumObj = '';
		if (change) {
			forumObj += '<div ontouchstart="zy_touch(\'btn-act\');" onmousedown="zy_touch(\'btn-act\');" onclick="setDateMore(\'' + module_name + '_dateend\')" class="ub-f1 uc-a1 uinput b-gra uba us-i1 uinn4 ub ub-rev">';
			forumObj += '<div class="umh1 umw1 tx-c t-blu3 umar-a"><i class="icon-calendar"></i>&nbsp;</div><div class="ub-f1"><input id=\"' + module_name + '_dateend\" name="dateend" placeholder=""  type="text" class=\"' + module_name + 'Box\" readonly value="' + dateend + '"></div>';
			forumObj += '</div>';
		}else{
			forumObj += '<input id=\"' + module_name + '_dateend\" name="dateend" placeholder=""  type="text" class=\"' + module_name + 'Box\" readonly value="' + dateend + '">';
		}
		setHtml('SFA_dateend',forumObj);
		var zxdz = order[0]['name_value_list']['zxdz']; //执行动作
		forumObj = '';
		if(zxdz != '无'){
			forumObj += '<div class="ubb b-gra uinn uc-t">';
			forumObj += '<div class="ub t-bla ulab ub-ac">';
			forumObj += '<div class="inlab_3" >执行动作</div>';
			forumObj += '<div class="ub-f1 ilogin uinn4 detail_li_text"><span id="SFA__zxdz" class="detail_li_text">'+zxdz+'</span></div>';
			forumObj += '</div></div>';
		}else{
			var at = order[0]['name_value_list']['at']; 
			forumObj += '<input class="uhide" id=\"' + module_name + '_at\" name="sfa_at" placeholder=""  type="text" readonly value="' + at + '">';
			if(at == 'manual'){
				var autoact_manual_sm = order[0]['name_value_list']['autoact_manual_sm']; 
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >具体事务</div>';
				forumObj += '<div class="ub-f1 ilogin uinn4">手动执行</div>';
				forumObj += '</div></div>';
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >事务明细</div>';
				forumObj += '<div class="ub-f1 c-wh uba uc-a1 b-gra uinput uinn4 ub ub-ver">';
				forumObj += '<textarea rows=5 id="autoact_manual_sm" placeholder="事务明细" name="autoact_manual_sm" '+input_msg +' type="text" class=\"' + module_name + 'Box\" >'+autoact_manual_sm+'</textarea>';
				forumObj += '</div>';
				forumObj += '</div></div>';
			}else if(at == 'sms'){
				var autoact_sms_sm = order[0]['name_value_list']['autoact_sms_sm']; 
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >发短信</div>';
				var actauto_sms = order[0]['name_value_list']['actauto_sms']; 
				forumObj += '<div class="ub ub-ac ub-pc c-gra c-m2 t-gra1 ulev-1 uc-a1 uba us ilogin b-gra uinn5" style="width:40%">';
				if(actauto_sms == '1'){
					forumObj += '<input class="uhide" type="radio" name="actauto_sms" id="menu1" checked="true"  value="1">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta ut-s" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu1\')">自动</div>';
					forumObj += '<input class="uhide" type="radio" name="actauto_sms" id="menu2" value="0">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu2\')">手动</div>';
				}else{
					forumObj += '<input class="uhide" type="radio" name="actauto_sms" id="menu1" value="1">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta ut-s" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu1\')">自动</div>';
					forumObj += '<input class="uhide" type="radio" name="actauto_sms" id="menu2" checked="true" value="0">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu2\')">手动</div>';
				}
				forumObj += '</div>';
				forumObj += '</div></div>';
				var autoact_sms_tt_arr = order[0]['name_value_list']['autoact_sms_tt_arr']; 
				var autoact_sms_tt = order[0]['name_value_list']['autoact_sms_tt']; 
				if(autoact_sms_tt == ""){
					autoact_sms_tt = autoact_sms_tt_arr[0];
				}
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >发送时间</div>';
				forumObj += '<div class="ilogin uinn4">开始日期当天的</div>';
				forumObj += '<div class="b-gra c-blu3 tx-c tp-view uof uinn">';
				forumObj += '<div class="ub sel">';
				forumObj += '<div class="ulim-1">' + autoact_sms_tt + '</div>';
				forumObj += '<div class="ub-img lis-sw-4 res3"></div>';
				forumObj += '<select name="sel0" id="autoact_sms_tt" onchange="zy_selectmenu(this.id);">';
				for (var i=0; i < autoact_sms_tt_arr.length; i++) {
					var timeslot = autoact_sms_tt_arr[i];
					forumObj += '<option value='+ timeslot +'>' + timeslot + '</option>';
				}
				forumObj += '</select>';
				forumObj += '</div></div></div></div>';
				
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >短信内容</div>';
				forumObj += '<div class="ub-f1 c-wh uba uc-a1 b-gra uinput uinn4 ub ub-ver">';
				forumObj += '<textarea rows=6 id="autoact_sms_sm" placeholder="短信内容" name="autoact_sms_sm" '+input_msg +' type="text" class=\"' + module_name + 'Box\" >'+autoact_sms_sm+'</textarea>';
				forumObj += '</div>';
				forumObj += '</div></div>';
			}else if(at == 'email'){
				var autoact_email_bt = order[0]['name_value_list']['autoact_email_bt']; 
				var autoact_email_sm = order[0]['name_value_list']['autoact_email_sm']; 
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >发邮件</div>';
				var actauto_email = order[0]['name_value_list']['actauto_email']; 
				forumObj += '<div class="ub ub-ac ub-pc c-gra c-m2 t-gra1 ulev-1 uc-a1 uba us b-gra uinn5" style="margin-left: .4em;width:40%">';
				if(actauto_email == '1'){
					forumObj += '<input class="uhide" type="radio" name="actauto_email" id="menu1" checked="true"  value="1">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta ut-s" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu1\')">自动</div>';
					forumObj += '<input class="uhide" type="radio" name="actauto_email" id="menu2" value="0">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu2\')">手动</div>';
				}else{
					forumObj += '<input class="uhide" type="radio" name="actauto_email" id="menu1" value="1">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta ut-s" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu1\')">自动</div>';
					forumObj += '<input class="uhide" type="radio" name="actauto_email" id="menu2" checked="true" value="0">';
					forumObj += '<div class="ub-con ub-f1 tx-c dis-sta" ontouchstart="zy_touch(\'focuss\')" onclick="radioSelect(\'menu2\')">手动</div>';
				}
				forumObj += '</div>';
				forumObj += '</div></div>';
				
				var autoact_email_cc = order[0]['name_value_list']['autoact_email_cc']; 
				var auto_cc_checked = '';
				if(autoact_email_cc == '1'){
					auto_cc_checked = 'checked="checked"';
				}
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >抄送</div>';
				forumObj += '<input type="checkbox" name="autoact_email_cc" id="autoact_email_cc" class="uhide" '+auto_cc_checked+'>'; 
					forumObj += '<div onclick="zy_for(event)" ontouchstart="zy_touch(\'btn-act\')" class="ub uc-a1 uba c-gra c-m2 b-gra t-bla uinn5 " style="margin-left: .4em;">';	 
					forumObj += '<div class="che-icon ub-img umw1"></div>';    
				forumObj += '<div class="ub-f1 ut-s tx-l" >抄送自己</div>';	  
				forumObj += '</div>';
				forumObj += '</div></div>';
				
				var mailfromselected = order[0]['name_value_list']['mailfromselected']; 
				var mailfromsobj = order[0]['name_value_list']['mailfromsobj']; 
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >发件人</div>';
				forumObj += '<div class="ub-f1 ub uc-a1 b-gra sel">';
				forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l">'+mailfromselected+'</div>';
				forumObj += '<div class="umw2 ub ub-pc uc-r ub-ac uc-r1">';  
				forumObj += '<div class="ub-img umw1 umh1 res8"></div>';   
				forumObj += '</div>';
				forumObj += mailfromsobj;
				forumObj += '</div>';
				forumObj += '</div></div>';
				
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >邮件标题</div>';
				forumObj += '<div class="ub-f1 ilogin uinn4">';
				forumObj += '<input id="autoact_email_bt" name="autoact_email_bt" placeholder="邮件标题"  type="text" class=\"' + module_name + 'Box\" value="' + autoact_email_bt + '">';
				forumObj += '</div>';
				forumObj += '</div></div>';
		
				forumObj += '<div class="ubb b-gra uinn uc-t">';
				forumObj += '<div class="ub t-bla ulab ub-ac">';
				forumObj += '<div class="detail_bt t-gra1" >邮件内容</div>';
				forumObj += '<div class="ub-f1 c-wh uba uc-a1 b-gra uinput uinn4 ub ub-ver">';
				forumObj += '<textarea rows=5 id="autoact_email_sm" placeholder="邮件内容" name="autoact_email_sm" '+input_msg +' type="text" class=\"' + module_name + 'Box\" >'+autoact_email_sm+'</textarea>';
				forumObj += '</div>';
				forumObj += '</div></div>';
			}
			//forumObj += '<input id=\"' + module_name + '_zxdz\" name="zxdz" placeholder="" type="text" class=\"' + module_name + 'Box\" readonly value="' + zxdz + '">';
		}
		setHtml('SFA_zxdz',forumObj);
		setHtml('SFA_zxsm',order[0]['name_value_list']['zxsm']);  //执行说明
		setHtml('SFA_zxjg',order[0]['name_value_list']['zxjg']);  //执行结果
		if (zt == '未执行' || zt == '再次执行') {
			$$('buttondiv').style.display = 'block';
		}
		if (zt == '执行失败') {
			$$('buttondiv2').style.display = 'block';
		}
		if (zt == '跳过') {
			$$('buttondiv3').style.display = 'block';
		}
	}
}

SFAObj.prototype.SaveRunEvent=function(){//修改事件
	var sfa_at = $$('Sfas_at').value;
	var datestart = $$('Sfas_datestart').value;
	var dateend = $$('Sfas_dateend').value;
	var select_fields = '';
	if (datestart != '') {
		select_fields += "&datestart=" + datestart;
		select_fields += "&dateend=" + dateend;
	}
	if(sfa_at == 'manual'){   //具体事务
		var autoact_manual_sm = $$('autoact_manual_sm').value; 
		select_fields += "&autoact_manual_sm="+autoact_manual_sm;
	}else if(sfa_at == 'sms'){  //发信息
		var actauto_sms = getRadioCheckedValue('actauto_sms'); 
		select_fields += "&actauto_sms="+actauto_sms;
		var autoact_sms_tt = $$('autoact_sms_tt').value; 
		select_fields += "&autoact_sms_tt="+autoact_sms_tt;
		var autoact_sms_sm = $$('autoact_sms_sm').value; 
		select_fields += "&autoact_sms_sm="+autoact_sms_sm;
	}else if(sfa_at == 'email'){   //发邮件
		var actauto_email = getRadioCheckedValue('actauto_email');
		select_fields += "&actauto_email="+actauto_email;
		var autoact_email_bt = $$('autoact_email_bt').value; 
		select_fields += "&autoact_email_bt="+autoact_email_bt;
		var autoact_email_sm = $$('autoact_email_sm').value; 
		select_fields += "&autoact_email_sm="+autoact_email_sm;
		var autoact_email_cc = 0;
		if($$('autoact_email_cc').checked){
			autoact_email_cc = 1;
		}
		select_fields += "&autoact_email_cc="+autoact_email_cc;
		var mailfrom = $$('mailfrom').value; 
		select_fields += "&mailfrom="+mailfrom;
	}
	this.method = 'set_entry_save';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"select_fields":"'+encodeURIComponent(select_fields)+'",' +
		'"link_name_to_fields_array":"",'+
		'"id":"' + this.CurrentSfaId + '"}';
	this.tip = 0;
	this.RequestServer();
}

SFAObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.toast(0, 5, "操作成功!!", 3000);
		var thePage = getstorage('thePage');
		if (thePage == "Account") {
			uexWindow.evaluateScript('AccountRelativePage', '0', "refreshRelative()");
		}else {
			uexWindow.evaluateScript('SfaListPage', '0', "searchList()");
		}
		uexWindow.evaluateScript('SfaDetailsPage', '0', 'closeWin()');
	}else if(data.result === "FAIL"){
		uexWindow.toast(0, 5, "操作失败!!", 3000);
	}
}; 

SFAObj.prototype.JumpRunEvent=function(){//跳过事件
	this.method = 'jump_run_event';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentSfaId + '"}';
	this.tip = 0;
	this.RequestServer();
}

SFAObj.prototype.DoRunEvent=function(){//执行事件
	this.method = 'do_run_event';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentSfaId + '"}';
	this.RequestServer();
}

SFAObj.prototype.DoAgainRunEvent=function(){//再次执行事件
	this.method = 'do_againRun_event';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",' +
		'"id":"' + this.CurrentSfaId + '"}';
	this.tip = 0;
	this.RequestServer();
}

function openSfaDetail(id,res){//打开事件详细页面
	setstorage('CurrentSfaId', id);
	openwin('SfaDetailsPage',res);
}

function checkTime(){//检查开始时间/结束时间
	var date_start = $$('Sfas_datestart').value;
	var due_date = $$('Sfas_dateend').value;
	if(due_date == ''){
		return false;
	}
	var arrStartDate = date_start.split("-");   
	var arrDueDate = due_date.split("-");    
	var allStartDate = new Date(arrStartDate[0],arrStartDate[1]-1,arrStartDate[2]); 
	var allEndDate = new Date(arrDueDate[0],arrDueDate[1]-1,arrDueDate[2]); 
	if(allStartDate.getTime()>allEndDate.getTime()){   
         return false;   
    }
	return true;   
}

function setNewDate(id){// 设置新的日期/时间 
	if (id == 'Sfas_datestart') {
		$$('Sfas_dateend').value = $$('Sfas_datestart').value;
	}else{
		$$('Sfas_datestart').value = $$('Sfas_dateend').value;
	}
}

