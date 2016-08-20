set_input_msg();
/*
* 审批中心
*/
function GetApprovesListFromServer() {
	setHtml("approves_list", "");
	showPageLoadingMsg(RES_DATA_LOADING);
	var forumObj = '';
        /* Show the loading panel */
		var AjaxUrl = getstorage("CurrentServerAddress");
		var CurrentUserId = getstorage("SugarSessionId");
		var offset = getstorage("currPage");
		var approveSel = "unremind";
		var searchtext = '';
		var rest_data = '{"session":"' + CurrentUserId + '",' +
            '"module_name":"ApproveStatus",' +
            '"query":"'+searchtext+'",' +
            '"offset":' + offset + ',' +
            '"max_results":' + RowsPerPageInListViews + ',' +
            '"sel":"'+approveSel+'"}';
		var m =[{"key":"rest_data","type":"0","value":rest_data},
			{"key":"method","type":"0","value":"get_entry_list"},
			{"key":"input_type","type":"0","value":"JSON"},
			{"key":"response_type","type":"0","value":"JSON"}];
	   var url=AjaxUrl+'/rest.php?callback=?&request_method=get_create_field&request='+encodeURIComponent(rest_data);
       $.getJSON(url,
		function(data){
			$$("loading").style.display='none';
			if (data !== undefined) {
				if (data === "Invalid Session ID") {
					uexWindow.toast(0, 5, "ID异常,请重新登陆...", 3000);
				}
				var approvesList = data;
				if ((approvesList !== undefined) && (approvesList.entry_list !== undefined)) {
					if ((approvesList.next_offset === 0) || (approvesList.result_count === 0)) {
						myalert('There are no more records in that direction');
					}
					else {
						var i = 0;
						for (i = 0; i < approvesList.entry_list.length; i++) {
							if (approvesList.entry_list[i] !== undefined) {
								var approve = approvesList.entry_list[i];
								forumObj += '<div class="ub ub-f1 umar-t uinn uba c-wh uc-t1 b-gra us" ontouchstart="zy_touch(\'btn-act\')"  onclick="openApproveDetail(\''+approve.module+'\','+approve.record+',\'\');">';
								forumObj += '<div class="ub-f1 detail_nr ub t-bla">' + approve.entityname.value + '</div>';
								forumObj +='<div class="res8 lis-sw ub-img"></div>';
								forumObj += '</div>';
								forumObj += '<div class="ub ub-f1 ub-ver uc-b1 b-gra ubl ubr ubb c-wh us" ontouchstart="zy_touch(\'btn-act\')" onclick="openApproveDetail(\''+approve.module+'\','+approve.record+',\'\');" >';
								
								forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
								forumObj += '<div class="detail_bt">' + approve.approvename.name + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + approve.approvename.value + '</div>';
								forumObj += '</div>';
								
								forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
								forumObj += '<div class="detail_bt">' + approve.stepname.name + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + approve.stepname.value + '</div>';
								forumObj += '</div>';
								
								forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
								forumObj += '<div class="detail_bt">' + approve.user_name.name + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + approve.user_name.value + '</div>';
								forumObj += '</div>';
								
								forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
								forumObj += '<div class="detail_bt">' + approve.resultstr.name + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + approve.resultstr.value + '</div>';
								forumObj += '</div>';
								
								forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
								forumObj += '<div class="detail_bt">' + approve.memo.name + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + approve.memo.value + '</div>';
								forumObj += '</div>';
								
								forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3">';
								forumObj += '<div class="detail_bt">' + approve.updated_at.name + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + approve.updated_at.value + '</div>';
								forumObj += '</div>';
								forumObj +="</div>";
							}
						}
						if(approvesList.entry_list.length == 0){
							forumObj += showNotRecordDiv();
						}
						setHtml("approves_list", forumObj);
						if(approvesList.lastpg > 0){
							setstorage('currPage', offset);
							setstorage('lastPage', approvesList.lastpg);
							uexWindow.evaluatePopoverScript('ApprovesListPage','pop_nav',"setPageSel()");
						}
					}
				}
			}
		},"json",//返回类型为json　
		function(err){//处理提交异
		   $$("loading").style.display='none';
		   
		　 uexWindow.toast(0, 5, "连接服务器异常,请检查网络...", 3000);//myalert("Failed to connect to server");
		},"POST",//以POST方式提交, 
		m,false);//提交的参数键值对对象 
}

function openApproveDetail(module,record,res){
	setstorage('CurrentApproveModule', module);
	setstorage('CurrentApproveRecord', record);
	openwin('ApproveDetailsPage',res);
}

/**
 * Set Approve DetailView
 */
function setApproveDetailsInfo(){
	showPageLoadingMsg(RES_DATA_LOADING);
	var AjaxUrl = getstorage("CurrentServerAddress");
	var CurrentUserId = getstorage("SugarSessionId");
	var CurrentApproveModule = getstorage("CurrentApproveModule");
	var CurrentApproveRecord = getstorage("CurrentApproveRecord");
	var rest_data = '{"session":"' + CurrentUserId + '","module_name":"ApproveStatus","approveModule":"' + CurrentApproveModule + '","record":"' + CurrentApproveRecord + '"}';
	var m =[{"key":"rest_data","type":"0","value":rest_data},
			{"key":"method","type":"0","value":"get_appstatus_entry"},
			{"key":"input_type","type":"0","value":"JSON"},
			{"key":"response_type","type":"0","value":"JSON"}];
	var url=AjaxUrl+'/rest.php?callback=?&request_method=get_create_field&request='+encodeURIComponent(rest_data);
	$.getJSON(url,
		function(data){
			$$("loading").style.display='none';
			if (data !== undefined) {
				if (data === "Invalid Session ID") {
					uexWindow.toast(0, 5, "ID异常,请重新登陆...", 3000);//setstorage("crmloginInfo",'');
					//uexWindow.open("root","0","../../index.html","2","0","0","0");//uexWindow.open("LoginWin","0","../../index.html","2","0","0","0");
				}
				if(data.islook !== undefined && data.islook == 'no'){
					forumObj += showNotPermittedDiv();
					setHtml("relativedetails_list", forumObj);
					return false;
				}
				var detailObj = data;
				var forumObj = '';
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
								field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="phonedial(\'' + field[j].value + '\');" class="uinn4 t-blu3">'+field[j].value+'</div>';
							}else if (field[j].name == 'Email') {
								field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="mailsend(\'' + field[j].value + '\');" class="uinn4 t-blu3 ">'+field[j].value+'</div>';
							}else if (field[j].name == '网站') {
								field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openwebsite(\'' + field[j].value + '\');" class="uinn4 t-blu3 ">'+field[j].value+'</div>';
							}else if (field[j].link == 1) {
								field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openDetailTab(\''+field[j].re_module+'\',\''+field[j].link_id+'\',\''+field[j].link_modulename+'\',\'../\');" class="uinn4 t-blu3">'+field[j].value+'</div>';
							}
							forumObj += '<div ' + div_class + '>';
							forumObj += '<div class="detail_bt t-gra1">' + field[j].name + '&nbsp;</div>';
							forumObj += '<div class="ub-f1 detail_nr ub">' + field[j].value + '</div>';
							forumObj += '</div>';
						}
						forumObj += '</div>';
					}
					var otherInfo = detailObj.other_list;
					if (otherInfo.title !== undefined) {
//						forumObj += '<div class="ub ub-fh bb_line uinn-top">';
//							forumObj += '<div class="umar-b">'+otherInfo.title+'</div>';
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
								forumObj += '<div class="detail_bt">' + j + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + field[i][j] + '</div>';
								forumObj += '</div>';
							}
							forumObj += '</div>';
						}
						forumObj += '</div>';
					}
					forumObj += '</div>';
					setHtml("approvedetails_list", forumObj);
			}
		}
	},"json",//返回类型为json　
	function(err){//处理提交异
	   $$("loading").style.display='none';
	　 uexWindow.toast(0, 5, "连接服务器异常,请检查网络...", 3000);//myalert("Failed to connect to server");
	},"POST",//以POST方式提交, 
	m,false);//提交的参数键值对对象 
}

function setCreateApprovePageBind(){
	showPageLoadingMsg(RES_DATA_LOADING);
	var forumObj = '';
	var module_name = "ApproveStatus";
	var AjaxUrl = getstorage("CurrentServerAddress");
	var CurrentUserId = getstorage("SugarSessionId");
	var CurrentApproveModule = getstorage("CurrentApproveModule");
	var CurrentApproveRecord = getstorage("CurrentApproveRecord");
	var rest_data = '{"session":"' + CurrentUserId + '","module_name":"' + module_name + '","approveModule":"' + CurrentApproveModule + '","record":"' + CurrentApproveRecord + '"}';
	var m =[{"key":"rest_data","type":"0","value":rest_data},
			{"key":"method","type":"0","value":"get_create_approve"},
			{"key":"input_type","type":"0","value":"JSON"},
			{"key":"response_type","type":"0","value":"JSON"}];
	var url=AjaxUrl+'/rest.php?callback=?&request_method=get_create_field&request='+encodeURIComponent(rest_data);
	$.getJSON(url,
		function(data){
			$$("loading").style.display='none';
			if (data === "Invalid Session ID") {
				uexWindow.toast(0, 5, "ID异常,请重新登陆...", 3000);
			}
			if (data.approve_title != '') {
				setHtml('approve_title', data.approve_title);
				var approveResultArr = data.approveResultArr;
				var forumObj = '';
				if(data.approve_others != ''){
					var approve_others = data.approve_others;
    				forumObj += '<input type="hidden" id="userselected" name="userselected" value="'+approve_others.userselected+'" class=\"'+module_name+'Box\">';
					forumObj += '<input type="hidden" id="approveid" name="approveid" value="'+approve_others.approveid+'" class=\"'+module_name+'Box\">';
					forumObj += '<input type="hidden" id="stepid" name="stepid" value="'+approve_others.stepid+'" class=\"'+module_name+'Box\">';
				}
				
				forumObj += '<div class="t-bla">';
				forumObj += '<div class="uinn ulim">' + data.approveResult + '</div>';
				forumObj += '<div class="list">';
				var listlen = approveResultArr.length;
				for (var i = 0; i < listlen; i++) {
					var checked = '';
					if (approveResultArr[i].checked !== undefined) {
						checked = 'checked="checked"';
					}
					
					forumObj += '<label  class="item item-radio ub">';
					forumObj += '<input type="radio" name="approvestatus" class="uhide"' + checked + ' value="' + approveResultArr[i].value + '">';
					//forumObj += '<div class="rdi-icon ub-img  umw1" ></div>';
					
					if (approveResultArr[i].selObj !== undefined) {
						var selName = approveResultArr[i].selObj.name
						var selArr = approveResultArr[i].selObj.arr;
						forumObj += '<div class="item-content ub ub-ver ub-f1">';
						forumObj += '<div>'+approveResultArr[i].name+'</div>';
						forumObj += '<div class="ub t-bla">';
						forumObj += '<div class="uinn1_5 ub ub-ac" id="thenextusersel">';
						forumObj += '<div class="ub ub-f1 t-bla" >&nbsp;';
						forumObj += '<div class="ub ub-f1 uba c-gra1 b-gra uc-a1 sel ub-pc ub-ac">';
						//forumObj += '<div class="ub c-wh b-gra us-i sel">';
						if (selName == 'approveid') { //审批流程下拉框
							forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l">' + selArr[0].approvename + '</div>';
							forumObj += '<div class="umh1 umw1" style="right:0.2em;color:#B7B8B8"><i class="icon ion-chevron-right"></i></div>';
							forumObj += '<select name="approveidsel" selectedindex="0" id="approveidsel" onchange="zy_selectmenu(this.id);" class=\"'+module_name+'Box\">';
							for (var j = 0; j < selArr.length; j++) {
								forumObj += '<option value="' + selArr[j].approveid + '">' + selArr[j].name + '</option>';
							}
							forumObj += '</select>';
						}else if (selName == 'nextstep') { //下一步骤下拉框
							forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l">' + selArr[0].name + '</div>';
							forumObj += '<div class="umh1 umw1" style="right:0.2em;color:#B7B8B8"><i class="icon ion-chevron-right"></i></div>';
							forumObj += '<select name="nextstep" selectedindex="0" id="nextstep" onchange="zy_selectmenu(this.id);approveSelectChange();" class=\"'+module_name+'Box\">';
							for (var j = 0; j < selArr.length; j++) {
								forumObj += '<option value="' + selArr[j].id + '">' + selArr[j].name + '</option>';
							}
							forumObj += '</select>';
						}
						forumObj += '</div></div></div></div>';
						var nextApprover = approveResultArr[i].nextApprover;
						var user_arr = nextApprover.user_arr;
						if(nextApprover != ""){   //下一个审批人
							forumObj += '<div>'+nextApprover.title+'</div>';
							forumObj += '<div class="uinn ub ub-ac" id="thenextusersel">';
							forumObj += '<div class="ub ub-f1 t-bla" >&nbsp;';
							forumObj += '<div class="ub ub-f1 uba c-gra1 b-gra uc-a1 sel ub-pc ub-ac">';
							forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l">'+user_arr[0].temp_user_arr[0].value+'</div>';
							forumObj += '<div class="umh1 umw1" style="right:0.2em;color:#B7B8B8"><i class="icon ion-chevron-right"></i></div>';
							forumObj += '<select name="nextuserid" selectedindex="0" id="nextuserid" onchange="zy_selectmenu(this.id);" class=\"'+module_name+'Box\">';
							for(var k=0;k<user_arr.length;k++){
								forumObj += '<optgroup label="'+user_arr[k].groupname+'">';
								var temp_user_arr = user_arr[k].temp_user_arr;
								for(var n=0;n<temp_user_arr.length;n++){
									forumObj += '<option value="' + temp_user_arr[n].id + '">' + temp_user_arr[n].value + '</option>';
								}
							}
							forumObj += '</select>';
							forumObj += '</div></div></div>';
						}
						forumObj += '</div><div class="radio-icon icon ion-checkmark"></div>';
					}else{
						forumObj += '<div class="item-content ub ub-ac ub-f1 ub-fv"><div>' + approveResultArr[i].name + '</div></div><div class="radio-icon icon ion-checkmark"></div>';
					}
					forumObj += '</label>';
				}
				if (data.approveRejectReason !== undefined) {  //添加备注文本框
					forumObj += '<br>&nbsp;'+data.approveRejectReason+':';
					forumObj += '<div class="uinn "><div class="ub-f1 c-wh uba uc-a1 b-gra uinput uinn4 ub ub-ver">';
					forumObj += '<textarea rows=3 '+input_msg +' id=\"description\" name=\"description\" type=\"text\"  class=\"'+module_name+'Box\"></textarea>';
					forumObj += '</div></div>';
				}
				if(data.approveFlow !== undefined) {  //保存审批流程
					setstorage('approveFlow', JSON.stringify(data.approveFlow));
				}else{
					setstorage('approveFlow', '');
				}
				if(data.approvehistory !== undefined) {  //保存审批历史
					setstorage('approvehistory', JSON.stringify(data.approvehistory));
				}else{
					setstorage('approvehistory', '');
				}
				forumObj += '</div></div>';
				setHtml("createform", forumObj);
				$$("buttondiv").style.display='block';	
		}
	},"json",//返回类型为json　
	function(err){//处理提交异
	   $$("loading").style.display='none';
	　 uexWindow.toast(0, 5, "连接服务器异常,请检查网络...", 3000);//myalert("Failed to connect to server");
	},"POST",//以POST方式提交, 
	m,false);//提交的参数键值对对象 
}

//改变审批步骤是更新审批人框
function approveSelectChange(){
	var forumObj = '';
	var module_name = "ApproveStatus";
	var AjaxUrl = getstorage("CurrentServerAddress");
	var CurrentUserId = getstorage("SugarSessionId");
	var CurrentApproveRecord = getstorage("CurrentApproveRecord");
	var rest_data = '{"session":"' + CurrentUserId + '","module_name":"' + module_name + '","stepid":"' + $$('nextstep').value + '","record":"' + CurrentApproveRecord + '"}';
	var m =[{"key":"rest_data","type":"0","value":rest_data},
			{"key":"method","type":"0","value":"approveSelectChange"},
			{"key":"input_type","type":"0","value":"JSON"},
			{"key":"response_type","type":"0","value":"JSON"}];
	var url=AjaxUrl+'/rest.php?callback=?&request_method=get_create_field&request='+encodeURIComponent(rest_data);
	$.getJSON(url,
		function(data){
			$$("loading").style.display='none';
			if (data === "Invalid Session ID") {
				uexWindow.toast(0, 5, "ID异常,请重新登陆...", 3000);//setstorage("crmloginInfo",'');
				//uexWindow.open("root","0","../../index.html","2","0","0","0");//uexWindow.open("LoginWin","0","../../index.html","2","0","0","0");
			}
			var user_arr = data.user_arr;
			forumObj += '<div class="ub t-bla" >&nbsp;&nbsp;&nbsp;';
			forumObj += '<div class="ub c-wh b-gra us-i sel">';
			forumObj += '<div class="ub-f1 ut-s uinn ulev-1 tx-l">'+user_arr[0].temp_user_arr[0].value+'</div>';
			forumObj += '<div class="ubl b-gra c-bla c-m2 umw2 ub ub-pc ub-ac">';
			forumObj += '<div class="ub-img umw1 umh1 res3"></div>';
			forumObj += '</div>';
			forumObj += '<select name="nextuserid" selectedindex="0" id="nextuserid" onchange="zy_selectmenu(this.id);" class=\"'+module_name+'Box\">';
			for(var m=0;m<user_arr.length;m++){
				forumObj += '<optgroup label="'+user_arr[m].groupname+'">';
				var temp_user_arr = user_arr[m].temp_user_arr;
				for(var l=0;l<temp_user_arr.length;l++){
					forumObj += '<option value="' + temp_user_arr[l].id + '">' + temp_user_arr[l].value + '</option>';
				}
			}
			forumObj += '</select>';
			forumObj += '</div></div>';
			setHtml("thenextusersel", forumObj);
	},"json",//返回类型为json　
	function(err){//处理提交异
	   $$("loading").style.display='none';
	　 uexWindow.toast(0, 5, "连接服务器异常,请检查网络...", 3000);//myalert("Failed to connect to server");
	},"POST",//以POST方式提交, 
	m,false);//提交的参数键值对对象 
}

//提交审批
function submitApprove(){
	showPageLoadingMsg(RES_DATA_SUBMITTING);
	var module_name = "ApproveStatus";
	var AjaxUrl = getstorage("CurrentServerAddress");
	var CurrentUserId = getstorage("SugarSessionId");
	var CurrentApproveModule = getstorage("CurrentApproveModule");
	var CurrentApproveRecord = getstorage("CurrentApproveRecord");
	var select_fields = '';
	var status = getRadioCheckedValue("approvestatus"); //审批结果
	select_fields += '&status='+status;
	var inputs = getElementsByClassName(module_name+'Box');
	var inputlen = inputs.length;
	for(var i=0;i<inputlen;i++){
		select_fields += "&"+inputs[i].name+"="+inputs[i].value;
	}
	var rest_data = '{"session":"' + CurrentUserId + '","module_name":"' + module_name + '","approveModule":"' + CurrentApproveModule + '","record":"' + CurrentApproveRecord + '","select_fields":"'+encodeURIComponent(select_fields)+'"}';
	var m =[{"key":"rest_data","type":"0","value":rest_data},
			{"key":"method","type":"0","value":"set_approve_save"},
			{"key":"input_type","type":"0","value":"JSON"},
			{"key":"response_type","type":"0","value":"JSON"}];
	var url=AjaxUrl+'/rest.php?callback=?&request_method=get_create_field&request='+encodeURIComponent(rest_data);
	$.getJSON(url,
		function(data){
			$$("loading").style.display='none';
			if (data === "Invalid Session ID") {
				uexWindow.toast(0, 5, "ID异常,请重新登陆...", 3000);//setstorage("crmloginInfo",'');
				//uexWindow.open("root","0","../../index.html","2","0","0","0");//uexWindow.open("LoginWin","0","../../index.html","2","0","0","0");
			}
			if(data == "SUCCESS"){
				myalert(RES_APPROVE_SUCCESS);
			}else if(data == "ALREADY_APPROVED"){
				myalert(RES_ALREADY_APPROVED);
			}
			uexWindow.evaluateScript('ApprovesListPage','0','getPageNewInfo()');
			//uexWindow.evaluateScript('ApprovePage','0','backHome()');
			uexWindow.evaluateScript('ApprovePage','0','closeWin()');
			uexWindow.evaluateScript('ApproveDetailsPage','0','closeWin()');
	},"json",//返回类型为json　
	function(err){//处理提交异
	   $$("loading").style.display='none';
	　 uexWindow.toast(0, 5, "连接服务器异常,请检查网络...", 3000);//myalert("Failed to connect to server");
	},"POST",//以POST方式提交, 
	m,false);//提交的参数键值对对象
}

function getApproveFlow(){
	var forumObj ='';
	var approveFlow = JSON.parse(getstorage("approveFlow"));
	if(approveFlow != ''){
		var flowItem = RES_APPROVE_FLOWITEM;
		for (var i = 0; i < approveFlow.length; i++) {
			forumObj += '<div class="ub ub-f1 ub-ver uc-a1 c-wh umar-t b-gra uba" >';
			forumObj +='<div class="ub ub-f1 t-bla ulab ub-ac uinn3"><div class="detail_bt">' + flowItem[0] +':</div><div class="ub-f1 detail_nr ub">'+approveFlow[i].label+'</div></div>';  //步骤名称
			forumObj +='<div class="ub ub-f1 t-bla ulab ub-ac uinn3"><div class="detail_bt">' + flowItem[1] +':</div><div class="ub-f1 detail_nr ub">'+approveFlow[i].sequence+'</div></div>';  //序列
			forumObj +='<div class="ub ub-f1 t-bla ulab ub-ac uinn3"><div class="detail_bt">' + flowItem[2] +':</div><div class="ub-f1 detail_nr ub">'+approveFlow[i].users+'</div></div>';  //审批人
			forumObj +='<div class="ub ub-f1 t-bla ulab ub-ac uinn3"><div class="detail_bt">' + flowItem[3] +':</div><div class="ub-f1 detail_nr ub">'+approveFlow[i].ended+'</div></div>';  //是否结束
			forumObj +='<div class="ub ub-f1 t-bla ulab ub-ac uinn3"><div class="detail_bt">' + flowItem[4] +':</div><div class="ub-f1 detail_nr ub">'+approveFlow[i].nextstep+'</div></div>';  //下一步
			forumObj +='</div></div>';
			if(i < approveFlow.length-1){
				forumObj += '<div class="umar-t tx-c"><i class="icon-arrow-down"></i></div>'
			}
		}
		setHtml("otherlists", forumObj);
	}
}

function getApproveHistory(){
	var forumObj ='';
	var approveHistory = JSON.parse(getstorage("approvehistory"));
	if(approveHistory != ''){
		var historyItem = RES_APPROVE_HISTORYITEM;
		for (var i = 0; i < approveHistory.entries.length; i++) {
			forumObj += '<div class="ub ub-f1 ub-ver uc-a1 c-wh umar-t b-gra uba" >';
			for (var j = 0; j < historyItem.length; j++) {
				forumObj += '<div class="ub ub-f1 t-bla ulab ub-ac uinn3"><div class="detail_bt">' + historyItem[j] + ':</div><div class="ub-f1 detail_nr ub">' + approveHistory.entries[i][j] + '</div></div>';
			}
			forumObj +='</div></div>';
			if(i < approveHistory.entries.length-1){
				forumObj += '<div class="tx-c umar-t"><i class="icon-long-arrow-down"></i></div>'
			} 
		}
		if(approveHistory.entries.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("otherlists", forumObj);
	}
}