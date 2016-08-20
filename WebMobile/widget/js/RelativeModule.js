/*
 * 此Js 为加载相关链接模块的信息
 */
//打开相关模块
function openDetailTab(module,record,title,res){
	if(module == 'Accounts'){
		setstorage('CurrentAccountId', record);
		openwin('AccountDetailsPage',"../Accounts/");
	}else if(module == 'Contacts'){
		setstorage('CurrentContactId', record);
		openwin('ContactDetailsPage',"../Contacts/");
	}else if(module == 'SalesOrder'){
		setstorage('CurrentSalesOrderId', record);
		openwin('SalesOrderDetailsPage',"../SalesOrder/");
	}else if(module == 'Potentials'){
		setstorage('CurrentPotentialId', record);
		openwin('PotentialDetailsPage',"../Potentials/");
	}else{
		setstorage('RelativeModule', module);
		setstorage('RelativeRecord', record);
		setstorage('RelativeTitle', title);
		openwin('RelativeDetailsPage',res+'RelativePage/');
	}
}

//相关模块详细信息
function setRelativeDetailsInfo(){
	showPageLoadingMsg(RES_DATA_LOADING);
	var forumObj = '';
	var module_name = "ApproveStatus";
	var AjaxUrl = getstorage("CurrentServerAddress");
	var CurrentUserId = getstorage("SugarSessionId");
	var RelativeModule = getstorage("RelativeModule");
	var RelativeRecord = getstorage("RelativeRecord");
	var rest_data = '{"session":"' + CurrentUserId + '","module_name":"ApproveStatus","approveModule":"' + RelativeModule + '","record":"' + RelativeRecord + '"}';
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
				var forumObj = '';
				if(data.islook !== undefined && data.islook == 'no'){
					forumObj += showNotPermittedDiv();
					setHtml("relativedetails_list", forumObj);
					return false;
				}
				var detailObj = data;
				if ((detailObj !== undefined) && (detailObj.entry_list !== undefined)) {
					var order = detailObj.entry_list;
					var listlen = order.length;
					var subname =  order[0].field[0].value;
//					forumObj += '<div class="uinn">';
//					forumObj += '<div class="ub ub-fh bb_line">';
//						forumObj += '<div class="umar-b">'+subname+'</div>';
//					forumObj += '</div>';
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
								field[j].value = '<div ontouchstart="zy_touch(\'btn-act\')" onclick="openwebsite(\'' + field[j].value + '\');" class="uinn4  t-blu3 tx_bold ">'+field[j].value+'</div>';
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
								forumObj += '<div class="detail_bt">' + j + ':</div>';
								forumObj += '<div class="ub-f1 detail_nr ub">' + field[i][j] + '</div>';
								forumObj += '</div>';
							}
							forumObj += '</div>';
						}
						forumObj += '</div>';
					}
					forumObj += '</div>';
					setHtml("relativedetails_list", forumObj);
			}
		}
	},"json",//返回类型为json　
	function(err){//处理提交异
	   $$("loading").style.display='none';
	　 uexWindow.toast(0, 5, "连接服务器异常,请检查网络...", 3000);//myalert("Failed to connect to server");
	},"POST",//以POST方式提交, 
	m,false);//提交的参数键值对对象 
}
