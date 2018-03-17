
/*
 *  此Js为登陆页面所需的方法
?({"id":"37","currentuser":"\u8001\u677f(\u603b\u7ecf\u7406)","companyname":"\u4e0a\u6d77\u745e\u7b56\u8f6f\u4ef6\u6709\u9650\u516c\u53f8","userphoto":"http:\/\/app.c3crm.com\/\/getpic.php?mode=show&attachmentsid=2451","service_version":"20141128"})
?({"id":"129785817148286979","currentuser":"129785817148286979","companyname":"%e7%a0%94%e5%8f%91%e4%b8%ad%e5%bf%83","userphoto":"","service_version":"20150101"})
 */

// 绑定登录信息
var result = false;
function LoginInfo_bind(){
	result = false;
	var logindata = getstorage('crmloginInfo');
	//alert(logindata);
	if(isDefine(logindata))
	{
		var dataobj = JSON.parse(logindata);
		if(isDefine(dataobj) && dataobj.username)
		{
			$("#SettingsPagec3crmUsername").val(dataobj.username);
			$("#SettingsPagec3crmPassword").val(dataobj.password);
			$("#SettingsPagec3crmServerAddress").val(dataobj.urlstring);
			if(dataobj.record=="1")
			{
				$("#crmcheckbox_rem").attr("checked","true");
			}
			if(dataobj.autologin=="1")
			{
				result = true;
				$("#crmcheckbox_rem").attr("checked","true");
				$("#crmcheckbox_auto").attr("checked","true");
				showLoginPrompt = 0;
				goLogin(dataobj.username,dataobj.password,dataobj.urlstring,1);
				//LoginUser();
			}
		}
	}
	if (!result) {
		openLoginPage();
	}
}

//检测url是否正确
function IsURL(str_url){
    var strRegex = "^((https|http|ftp|rtsp|mms)?://)" 
    + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //ftp的user@ 
    + "(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP形式的URL- 199.194.52.184 
    + "|" // 允许IP和DOMAIN（域名）
    + "([0-9a-z_!~*'()-]+\.)*" // 域名- www. 
    + "([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]\." // 二级域名 
    + "[a-z]{2,6})" // first level domain- .com or .museum 
    + "(:[0-9]{1,5})?" // 端口- :80 
    + "((/?)|" // a slash isn't required if there is no file name 
    + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$"; 
    var re=new RegExp(strRegex);
    if (re.test(str_url)){
        return true; 
     }else{ 
        return false; 
     }
} 

var remeberPwd = 1;
var autoLogin = 1;
var showLoginPrompt = 1;
//用户登录
function LoginUser() {
    var enteredUsername = $$('SettingsPagec3crmUsername').value;
    var enteredPassword = $$('SettingsPagec3crmPassword').value;
	var l_auto = $$("crmcheckbox_auto");
	if(enteredUsername.length == 0){
		myalert(RES_INPUT_USERNAME);return false;
	}
	if(enteredPassword.length == 0){
		myalert(RES_INPUT_PASSWORD);return false;
	}
	var urlstring = '';

	if(crmmobiletype == '2'){
		urlstring = $$('SettingsPagec3crmServerAddress').value;
		urlstring = trimStr(urlstring);
		urlstring = urlstring.toLowerCase();  //大写转换成小写
		if (urlstring.indexOf("http://") == -1 && urlstring.indexOf("https://") == -1) {
			urlstring = "http://"+urlstring;
		}
		$$('SettingsPagec3crmServerAddress').value = urlstring;
		//urlstring = urlstring.replace(/^http:\/\//i, '');  //替换http://为''
		if(!IsURL(urlstring)){
			myalert(RES_INPUT_CRMADDRESS);return false;
		}
	}else{
		return false;
	}

	remeberPwd = 1;
	autoLogin = 1;
	var l_remeber = $$("crmcheckbox_rem");
	if (!l_remeber.checked) {
		remeberPwd = 0;
	}
	var l_autologin = $$("crmcheckbox_auto");
	if (!l_autologin.checked) {
		autoLogin = 0;
	}
	goLogin(enteredUsername,enteredPassword,urlstring,0);
}

function rsa_pwd(content){
	//十六进制公钥 
	var rsa_n = "B96B93CB01491CEA12D557E63033B31B8A65568077B311548D28A7A75BCFE5D06E547418224E3B7B79BC7C66FECB0B3FD8AA9286B22227306BB5D42AE4E6F04403B79A31BF8836A8E0A2C231FCD2D596EA86E663D4C155F0832433140EE5C03AC3E1AC4E6123EC72ECEDC8A21E6BD60B5043E2A89AD7CA0E198A504B32A0A305";
	setMaxDigits(131); //131 => n的十六进制位数/2+3 
	var key = new RSAKeyPair("10001", '', rsa_n); //10001 => e的十六进制 
	content_rsa = encryptedString(key, content); //不支持汉字 
	return content_rsa;
}

function goLogin(username,password,urlstring,isLoginPage) {
	var service_version = '20150101';
	if (showLoginPrompt) {
		showPageLoadingMsg2(RES_LOADING);
	}
	CurrentServerAddress = urlstring;
	var rsa_password = hex_md5(password);
	var rest_data = '{"password":"' + rsa_password + '","user_name":"' + username + '","platform":"'+getstorage('platform')+'","deviceToken":"'+getstorage('deviceToken')+'"}';
	var method = "login";
	var url = CurrentServerAddress + '/webmobile/login.ashx?callback=?&rest_data=' + encodeURIComponent(rest_data) + '&method=' + method;
	//$$('SettingsPagec3crmUsername').value = url;
	$.ajax({
		type: 'getJSON',
		url: url,
		success: function(data){
			$$("loading").style.display = 'none';
			if (data !== "") {
				result = true;
				if (data == "Login failed") {
					result = false;
					myalert(RES_LOADINGFAIL);
				}else if (data == "you can not use the mobile CRM") {
					result = false;
					myalert("您没有权限使用移动版登陆,请联系电子平台管理员给您开启权限!");
				}else {
					if (data.service_version == undefined || data.service_version != service_version) {
					    myalert('您的移动客户端与服务端版本不同,请联系电子平台管理员升级电子平台!');
					}
					var savePwd = remeberPwd ? password : "";
					var pstr = '{"username":"' + username + '","password":"' + savePwd + '","urlstring":"' + urlstring + '","record":"'+remeberPwd+'","autologin":"' + autoLogin + '","currentuser":"' + data.currentuser + '","companyname":"' + data.companyname + '","userphoto":"' + data.userphoto + '"}';
					setstorage('crmloginInfo', pstr);
					setstorage("CurrentServerAddress", CurrentServerAddress);
					setstorage("SugarSessionId", data.id);
					isTimeRefresh(); //是否清除缓存中的数据
					closeLoginPage();
				}
			}else {
				result = false;
				myalert('An unexpected error occurred logging in.');
			}
			if (!result) {
				openLoginPage();
			}
		},
		error:function (){
			//$$("loading").style.display = 'none';
		    myalert('连接服务器异常,请检查电子平台以及设备网络是否正常...');
			openLoginPage();
		}
	});
//	var j =[{"key":"rest_data","type":"0","value":rest_data},
//			{"key":"method","type":"0","value":"login"},
//			{"key":"input_type","type":"0","value":"JSON"},
//			{"key":"response_type","type":"0","value":"JSON"}];
//	var url=CurrentServerAddress+'/rest.php?callback=?';
//	$.getJSON(url,
//		function(data){
//			$$("loading").style.display='none';
//			if (data !== "") {
//			  	if(data == "Login failed"){
//					myalert(RES_LOADINGFAIL);
//					if(isLoginPage)openwin('login','');
//				}else if(data == "you can not use the mobile CRM"){
//					myalert("您没有权限使用移动版登陆,请联系CRM系统管理员给您开启权限!");
//					if(isLoginPage)openwin('login','');
//				}else{
//					if( data.service_version == undefined || data.service_version != service_version){
//						myalert('您的移动客户端与服务端版本不同,请联系CRM系统管理员升级CRM!');
//					}
//					var savePwd = remeberPwd ? password : "";
//					var pstr = '{"username":"' + username + '","password":"'+savePwd+'","urlstring":"' + urlstring +'","record":"0","autologin":"'+autoLogin+'","currentuser":"' + data.currentuser +'","companyname":"' + data.companyname +'","userphoto":"' + data.userphoto +'"}';
//					setstorage('crmloginInfo', pstr);
//					setstorage("CurrentServerAddress",CurrentServerAddress);
//					setstorage("SugarSessionId",data.id);
//					isTimeRefresh(); //是否清除缓存中的数据
//					openwin('home','');
//				}
//	        }else{
//				myalert('An unexpected error occurred logging in.');
//				if(isLoginPage)openwin('login','');
//	        }
//		},"json",//返回类型为json　
//		function(err){//处理提交异
//		   //logs(JSON.stringify(err));
//		   $$("loading").style.display='none';
//		   myalert('连接服务器异常,请检查CRM地址以及设备网络是否正常...');
//		   if(isLoginPage)openwin('login','');
//		　 //uexWindow.toast(0, 5, "连接服务器异常,请检查CRM地址以及设备网络是否正常...", 3000);//myalert("Failed to connect to server");
//		},"POST",//以POST方式提交, 
//	j,false);//提交的参数键值对对象 
}

function testToLogin(){
//	$$('SettingsPagec3crmUsername').value = "admin";
//	$$('SettingsPagec3crmPassword').value = "admin";
	$$('SettingsPagec3crmUsername').value = "boss";
	$$('SettingsPagec3crmPassword').value = "888888";
	//$$('SettingsPagec3crmUsername').value = "chenyi";
	//$$('SettingsPagec3crmPassword').value = "198943";
    //$$('SettingsPagec3crmServerAddress').value = "192.168.1.118/crm41";
    //http://localhost:88
	$$('SettingsPagec3crmServerAddress').value = "http://app.c3crm.com";
	//$$('SettingsPagec3crmServerAddress').value = "bjxinzhao.wicp.net";
	LoginUser();
}
	
//是否选中记住密码复选框
function zy_for_rem(e) {
	var ch = e.currentTarget.previousElementSibling;
	if (ch.nodeName == "INPUT") {
		if (ch.type == "checkbox")
			ch.checked = !ch.checked;
		if (!ch.checked) {
			var a = $$("crmcheckbox_auto");
			a.checked = false;
		}
	}
}

function zy_for_auto(e) {
	var ch = e.currentTarget.previousElementSibling;
	if (ch.nodeName == "INPUT") {
		if (ch.type == "checkbox")
			ch.checked = !ch.checked;
		if (ch.checked) {
			var a = $$("crmcheckbox_rem");
			a.checked = true;
		}
	}
}