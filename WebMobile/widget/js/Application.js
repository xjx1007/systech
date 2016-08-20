/**
* 此Js包含也写公用的变量和方法
*/
var platform = 2;
var crmmobiletype = '2';//1 浏览器 2 客户端
var SugarSessionId = '';
var deviceToken = '';
var RowsPerPageInListViews = 10;  //  每页显示条数
var myDate = new Date(); //  获取当前日期
var serviceUpdate = true;// 服务端sevice是否需要更新
var input_msg = '';
function showNotRecordDiv(){
	var forumObj = '';
	forumObj += '<div class="uinn">'
	forumObj +='<ul class="ub b-gra ub-ac uc-a1 c-wh uba lis uinn ">';
	forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">还没有相关记录哦!...</li>';  
	forumObj +='</ul></ul>';
	forumObj += '</div>';
	return forumObj;
}

function showNotPermittedDiv(){
	var forumObj = '';
	forumObj += '<div class="uinn">'
	forumObj +='<ul class="ub b-gra ub-ac lis us uinn ">';
	forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c" style="color:#EB0000;">您没有权限执行这个操作!</li>';  
	forumObj +='</ul></ul>';
	forumObj += '</div>';
	return forumObj;
}

//自定义输入框
function openinput(obj){
	var id = obj.getAttribute("id");
	var tt = $$(id).value;
	uexControl.cbInputCompleted=function(opId,dataType,data){
		if(dataType==0){
			$$(id).value = data;
		}
	}
	uexControl.openInputDialog("0",tt,"确定");
}

//公用搜索
function searchRecord(obj){
	var tt = "";
	uexControl.cbInputCompleted = function(opId,dataType,data){
		tt = data;
		if(tt == ''){
			myalert('搜索内容不能为空！');
			return false;
		}
		var id = obj.getAttribute("id");
		$$(id).value = tt;
		searchList();	
	}
	uexControl.openInputDialog("0",tt,"搜索");
}

	

//检查是不是正数
function checkIsPositiveNumble(obj){
	var id = obj.getAttribute("id");
	var amount = $$(id).value;
	if(!checkIsNum(amount) || amount<0){
		myalert('输入有误,请重新输入');
		$$(id).value = '';
	}
}

//(解决android输入法将页面挤小的问题)
function set_input_msg(){
	if (getstorage('platform') == 1) {
		input_msg = 'readonly="readonly" onclick="openinput(this)"';
	}
}

//弹出框
function myalert(msg) {
    alert(msg);
}

//测试日志
function logs(s){
	//uexLog.sendLog(s);
}

//设置innerHTML
function setHtml(id, html) {
	if ("string" == typeof(id)) {
		var ele = $$(id);
		if (ele != null) {
			ele.innerHTML = html == null ? "" : html;
		}
	} else if (id != null) {
		id.innerHTML = html == null ? "" : html;
	}
}

//设置storage
function setstorage(objName,objValue){ 
	var storage = window.localStorage;
	if(window.localStorage){
		storage.setItem(objName,objValue);
	}else{
		 logs('setstorage-->This browser does NOT support localStorage');
		 addCookie(objName,objValue);
	}
}

//获取storage中的值
function getstorage(objName){ 
	var storage = window.localStorage;
	var result = '';
	if(window.localStorage){
		for(var i=0;i<storage.length;i++){
			if(storage.key(i)==objName)
				result = storage.getItem(storage.key(i));
		 }
	}else{
		 logs('getstorage-->This browser does NOT support localStorage');
		 getCookie(objName);
	}
	return result;
}

//清除localstorage
function clearstorage(){  
	var storage = window.localStorage;
	logs('clearstorage-->clear all localStorage data ~ ~ ~');
	if(window.localStorage){
		localStorage.clear();
	}else{
		 logs('clearstorage-->This browser does NOT support localStorage');
		 clearCookie();
	}
}

//清除缓存
function clearCache(){
	var notClearArr =['SugarSessionId','crmloginInfo','CurrentServerAddress'];
	var needClearArr = [];
	var storage = window.localStorage;
	var j=0;
	if(window.localStorage){
		for(var i=0;i<storage.length;i++){
			if(!notClearArr.in_array(storage.key(i))){
				needClearArr[j++] = storage.key(i);
			}
		 }
	}
	for (var m = 0; m < j; m++) {
		storage.removeItem(needClearArr[m]);
	}
	window.toast(0, 5, "缓存清除成功!", 3000);
	setstorage('refreshTime',myDate.getTime()+24*60*60*1000);// 第二天刷新缓存
}

// 是否应该清除缓存了
function isTimeRefresh(){
	var time1 = myDate.getTime();
	var time2 = getstorage('refreshTime');
	if(parseInt(time1)> parseInt(time2)){
		clearCache();
	}
}

//登陆页面
function indexcontentpageonload(){	
	setHtml("UsernameLabel", RES_USERNAME_LABEL);
	setHtml("PasswordLabel", RES_PASSWORD_LABEL);
	//setHtml("LoginDescriptionParagraph", RES_LOGIN_MESSAGE);
	setHtml("LoginFormLoginButton", RES_LOGIN_TITLE);
	setHtml("SettingsPagec3crmServerAddressLabel", RES_SETTINGS_SERVER_ADDRESS_LABEL);
	setHtml("loginservertitleLabel", LOGIN_SERVERURL_TITLE);
	setHtml("SettingsPagec3crmProtocol", RES_SETTINGS_PROTOCOL_SELECTION_LABEL);
	setHtml("Settingsisremember_pwd", RES_SETTINGS_ISREMEMBERPWD_LABEL);
	setHtml("Settingsisautologin",RES_SETTINGS_ISAUTOLOGIN_LABEL);
}

//主页
function homepageonload(){
	setHtml("MainMenuButton", RES_MAIN_MENU_LABEL);
	setHtml("AddNewButton", RES_ADD_BUTTON);
	setHtml("LogoutButton", RES_LOGOUT_LABEL);
	setHtml("ExitButton", RES_EXIT_LABEL);
	setHtml("HomePageTitle",RES_HOME_LABEL);
	setHtml("AboutApplication", RES_ABOUT_APPLICATION_MENU_ITEM);
	setHtml("AccountsListPageLinkLabel", RES_ACCOUNTS_LABEL);
	setHtml("ContactsListPageLinkLabel", RES_CONTACTS_LABEL);
	setHtml("NotesListPageLinkLabel", RES_NOTES_LABEL);
	setHtml("DailylogsListPageLinkLabel", RES_DAILYLOGS_LABEL);
	setHtml("LowLvDailylogsListPageLinkLabel",RES_LOWLVDAILYLOGS_LABEL);
	setHtml("WarehouseBalancesListPageLinkLabel",RES_WAREHOUSEBALANCES_LABEL);
	setHtml("ApprovesListPageLinkLabel",RES_APPROVE_LABEL);
	setHtml("PerformancesListPageLinkLabel",RES_PERFORMANCES_LABEL);
	setHtml("CalendarsListPageLinkLabel",RES_CALENDARS_LABEL);
	setHtml("GathersListPageLinkLabel",RES_GATHERS_LABEL);
	setHtml("SaleOrderListPageLinkLabel",RES_SALEORDERS_LABEL);
	setHtml("PotentialsListPageLinkLabel",RES_POTENTIALS_LABEL);
	
}

//关于
function aboutpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("ViewAboutApplicationPageTitle", RES_ABOUT_APPLICATION_HEADER);
	setHtml("comp_introduce",RES_INTRODUCE);
	setHtml("appVersionLabel",RES_VERSION_LABEL);
	setHtml("appVersion", RES_CURRENT_VERSION_NUMBER);
	setHtml("companyWebsiteLabel", RES_COMPANY_WEBSITE_LABEL);
	setHtml("companyWebsite", RES_COMPANY_WEBSITE);
	setHtml("companyPhoneLabel", RES_COMPANY_PHONE_LABEL);
	setHtml("companyPhone", RES_COMPANY_PHONE);
}

//客户列表
function accountslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("AccountsListPageTitle", RES_ACCOUNTS_LABEL);
}

//客户详细信息
function accountdetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewAccountDetailsPageTitle", RES_ACCOUNT_LABEL + " " + RES_DETAILS_LABEL);
}

//新增客户
function createaccountpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("CreatePageTitle", RES_NEW_ACCOUNT_PAGE_TITLE);
}

//新增联系人
function createcontactpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("CreatePageTitle", REPLACEMENT_TEXT);
}

//新增联系记录
function createContactRecordPageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("CreatePageTitle", CRESTENOTE_TEXT);
}

//新增合同订单
function createSalesOrderPageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("CreatePageTitle", '新增合同订单');
}

//新增合同订单
function createPotentialPageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("CreatePageTitle", '新增销售机会');
}

//联系人列表
function contactslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("ContactsListPageTitle", RES_CONTACTS_LABEL);
}

//联系人详细信息
function contactdetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewContactDetailsPageTitle", RES_CONTACT_LABEL + " " + RES_DETAILS_LABEL);
}

//联系记录列表
function noteslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("NotesListPageTitle", RES_NOTES_LABEL);
}

//联系记录详细信息
function notedetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewNoteDetailsPageTitle", RES_TASKS_LABEL + " " + RES_DETAILS_LABEL);
}

//日报列表
function dailylogslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("DailylogsListPageTitle", RES_DAILYLOGS_LABEL);
	setHtml("DateLabel", RES_DATE_LABEL);
	setHtml("SettingsDateLabel", RES_SETTINGS_TDATE_LABEL);
}

//下级日报
function lowlvdailylogslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("LowLvDailylogsListPageTitle", RES_LOWLVDAILYLOGS_LABEL);
	setHtml("DateLabel", RES_DATE_LABEL);
	setHtml("SettingsDateLabel", RES_SETTINGS_TDATE_LABEL);
}

//库存余额
function warehousebalanceslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("WarehouseBalancesListPageTitle", RES_WAREHOUSEBALANCES_LABEL);
}

//我的审批中心
function approvelistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("approvesListPageTitle", RES_APPROVE_LABEL);
}

//审批单详细信息
function approvedetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewApproveDetailsPageTitle", RES_APPROVEDETAIL_LABEL);
	setHtml("approve", RES_APPROVE);
}

//审批页面信息
function approvepageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewApprovePageTitle", RES_APPROVE);
	setHtml("lookapproveFlow", RES_LOOK_APPROVEFLOW);
	setHtml("lookapproveHistory", RES_LOOK_APPROVEHISTORY);
}

//审批流程信息/审批历史
function approveotherpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
}

//员工绩效
function performanceslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("performancesListPageTitle", RES_PERFORMANCES_LABEL);	
	setHtml("dayLabel", RES_DAY_LABEL);
	setHtml("weekLabel", RES_WEEK_LABEL);
	setHtml("monthLabel", RES_MONTH_LABEL);
}

//绩效详细
function performancedetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewPerformanceDetailsPageTitle", RES_PERFORMANCEDETAIL_LABEL);
}

//绩效考核 查看点评/添加点评
function commentpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
}

//日程安排
function calendarslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("calendarsListPageTitle", RES_CALENDARS_LABEL);	
	setHtml("FanWeiLabel", RES_FANWEI_LABEL);
	setHtml("dayLabel", RES_DAY_LABEL);
	setHtml("weekLabel", RES_WEEK_LABEL);
	setHtml("monthLabel", RES_MONTH_LABEL);
}

//新增日程安排
function createCalendarPageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("CreatePageTitle", RES_ADD_BUTTON+RES_CALENDARS_LABEL);
}

//日程安排详细信息
function calendardetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewCalendarDetailsPageTitle", RES_CALENDARS_LABEL + " " + RES_DETAILS_LABEL);
}

// 应收款
function gatherslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("GathersListPageTitle", RES_30DAYS_GATHERS_LABEL);
	setHtml("patotal_label",RES_PATOTAL_LABEL);
}

// 合同订单列表
function salesorderlistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("SalesOrderListPageTitle", '合同订单');
}

//合同订单详细信息
function salesorderdetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewSalesOrderDetailsPageTitle", '合同订单' + " " + RES_DETAILS_LABEL);
}

//销售机会
function potentialslistpageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("PotentialsListPageTitle", RES_POTENTIALS_LABEL);
}

//销售机会详细信息
function potentialdetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewPotentialDetailsPageTitle", RES_POTENTIALS_LABEL + " " + RES_DETAILS_LABEL);
}salesforecastlistPageonload

//销售预测
function salesforecastlistPageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewSaleForecastTitle", '销售预测');
}

//销售自动化详细信息
function sfadetailspageonload(){
	setHtml("BackLabel", RES_BACKBUTTON_LABEL);
	setHtml("BackHomeLabel", RES_BACKHOMEBUTTON_LABEL);
	setHtml("ViewSfaDetailsPageTitle", '销售自动化' + " " + RES_DETAILS_LABEL);
}

//打开新窗口  name->要打开的html的名字,res->路径
function openwin(name,res,aniID,flag){
    var url = res + name + '.html';
    alert(url);
	//var inAniID = arguments[2] || 2; //ligangze
	var inAniID = arguments[2] || 0; 
	var inFlag = arguments[3] || 0x4; 
	//myalert(inFlag);
	window.open(name, '0', url, inAniID, '0', '0', inFlag, 0);
	//window.open(inWndName,inDataType,inData,inAniID,inWidth,inHeight,inFlag[,animDuration])
	/*参数说明：
　　inWndName: 窗口的名字。可为空，不可命名为"root"。当Window栈中已经存在名为inWindowName的window时，open函数将直接跳转至此 window，并用此window执行相关操作。
　　inDataType: 指定窗口载入的数据的类型,0表示url方式载入；1表示html内容方式载入，2表示既有url方式，又有html内容方式
　　inData:载入数据
　　inAniID: 动画ID，symbian,WP7不支持此效果，查看常量表的Window Animi ID
　　inWidth: 窗口宽度。接受不含小数的整数,百分数,可为空,默认为屏幕的宽度，symbian为全屏
　　inHeight: 窗口高度。接受不含小数的整数,百分数,可为空,默认为屏幕的高度，symbian为全屏
　　inFlag: 详见常量表中Window Flags。
　　　　　　如果此窗口有多重功能，即对应有多个Window Flags中的值，那么此参数可写为"1|2|4",或者"7"(1+2+4)
　　animDuration:动画持续时长，单位为毫秒，默认250毫秒*/
}

//返回
function back(){
	
	window.close("-1");
}

function closeWin(){
	window.close();
}

//窗口返回
function windowBack(){
	window.windowBack(13,'');
}
//注销
function logout(){
	setstorage("crmloginInfo",'');
	window.evaluateScript('home', '0', 'closeWin()');
	open('login','');
	//window.close("-1");
	//window.open('root','0','index.html',2,'0','0',0x0);
}

//返回主页
function backHome(){
	openwin('index','../../','2','0x0');
}

//打开新增页面
function openCreatePage(type,res){ 
	setstorage("CreateNewType",type);
	openwin('CreateNewPage',res);
}

//打开编辑页面
function openEditPage(type,res){
	setstorage("CreateNewType",type);
	openwin('EditPage',res);
}

//调用手机拨号界面
function phonedial(num){
	uexCall.dial(num,false);
}

//调用手机邮箱发email
function mailsend(email_temp){
    uexEmail.open(email_temp, '请输入主题', '请输入内容', '');
}

//调用浏览器打开网址
function openwebsite(website){
	var platform = getstorage('platform');
	if (platform == 0) {
		uexWidget.loadApp('', '', 'http://' + website); //苹果上面       相关API :uexWidget.loadApp	
	}else if (platform == 1){
		uexWidget.loadApp("android.intent.action.VIEW", "text/html", "http://" + website); //安卓上面
	}
	//window.open(website,'0',url,2,'0','8',0x0);    //window.open(inWndName,inDataType,inData,inAniID,inWidth,inHeight,inFlag[,animDuration])
	//注意inFlag参数，当这个设为8时的情况！(标记被open的window当中的任何url都将调用系统浏览打开)
}

//选择客户
function selectAccount(){
	openwin('SelectAccount','modules/Accounts/');
}

//选择销售机会
function selectPotential(){
	openwin('SelectPotential','modules/Potentials/');
}

function openSelectPage(mode,res){
	setstorage('selectMode',mode);
	openwin('SelectPage',res);
}

//显示页面加载提示div
function showPageLoadingMsg(info) {
   $$('loading').style.height = document.body.scrollHeight+'px';
   var loadingHtml = '<div id="circular">'+
   						'<div id="circular_1" class="circular"></div>'+
						'<div id="circular_2" class="circular"></div>'+
						'<div id="circular_3" class="circular"></div>'+
						'<div id="circular_4" class="circular"></div>'+
						'<div id="circular_5" class="circular"></div>'+
						'<div id="circular_6" class="circular"></div>'+
						'<div id="circular_7" class="circular"></div>'+
						'<div id="circular_8" class="circular"></div>'+
						'<div class="clearfix"></div>'+
						'<span class="loadingTip">'+info+'...</span>'+
					'</div>';
   setHtml("loading", loadingHtml);
   $$("loading").style.display='block';
}

//显示页面加载提示div
function showPageLoadingMsg2(info) {
   $('#loading').css('height','100%');
   var loadingHtml = '<div id="circular">'+
   						'<div id="circular_1" class="circular"></div>'+
						'<div id="circular_2" class="circular"></div>'+
						'<div id="circular_3" class="circular"></div>'+
						'<div id="circular_4" class="circular"></div>'+
						'<div id="circular_5" class="circular"></div>'+
						'<div id="circular_6" class="circular"></div>'+
						'<div id="circular_7" class="circular"></div>'+
						'<div id="circular_8" class="circular"></div>'+
						'<div class="clearfix"></div>'+
						'<span class="loadingTip">'+info+'...</span>'+
					'</div>';
   $("#loading").html(loadingHtml);
   $("#loading").show();
}

//是否定义
function isDefine(para) {
	if (typeof para == 'undefined' || para == "" ||para == "&nbsp;" || para == null
			|| para == 'undefined' || isNull(para)|| isNull(removeHTMLTag(para))) {
		return false;
	} else {
		return true;
	}
}
//是否为空
function isNull(str){
	var re=/^[　\s]*$/;
	return re.test(str);
} 

// 如果输入的为空或者不是数字
function checkIsNum(x){
	if (isNaN(x) || x == "") {  
		 return false;
	}
	return true;
}

//获取html中class="n"的所有元素
function getElementsByClassName(n) {
    var classElements = [],allElements = document.getElementsByTagName('*');
    for (var i=0; i< allElements.length; i++ ){
		if (allElements[i].className == n) {
			classElements[classElements.length] = allElements[i];
		}
    }
  	return classElements;
}

//获取radio的选择值
function getRadioCheckedValue(id){
	var temp = document.getElementsByName(id);
  	for (var i=0;i<temp.length;i++){
		if(temp[i].checked){ //遍历Radio
			return temp[i].value;
		}
  	}
}

//设置select的选中值
function selectValue(sId,value){  
    var s = document.getElementById(sId);  
    var ops = s.options;  
    for(var i=0;i<ops.length; i++){  
        var tempValue = ops[i].value;  
        if(tempValue == value){ 
            ops[i].selected = true;  
			zy_selectmenu(sId);
        }  
    }  
} 

//选中radio菜单的某项
function radioSelect(id){
	var e = $$(id);
	if(e && !e.checked){
		e.checked = true;
		return e.value;
	}
	return 'notChange';
}

//判断数组中是否存在某值
Array.prototype.in_array = function(e){  
	for(i=0;i<this.length;i++){  
		if(this[i] == e) return true;  
	}  
	return false;  
} 

//加载footer位置分页窗口
function setNavDiv(){
	var s = window.getComputedStyle($$('header'), null);
	var em = int(s.fontSize);
	var x = 0;
	var y = int(window.innerHeight) - int(2.2 * em);
	var w = int(s.width);
	var h = int(2.2 * em);
	window.openPopover('pop_nav', "0", '../../pop_nav.html', "", x, y, w, h, em, "0");
}

//有分页窗口时切换横竖屏时自适应
function orientationChange_havNav(){  //横竖屏切换时自适应
	var s = window.getComputedStyle($$('header'), null);
	var em = int(s.fontSize);
	var x = 0;
	var y = int($$("header").offsetHeight);
	var w = int(s.width);
	var h = int(window.innerHeight) - int($$("header").offsetHeight)-int(2.2*em);
	window.setPopoverFrame("content",x, y, w, h);
	var x = 0;
	var y = int(window.innerHeight) - int(2.2 * em);
	var w = int(s.width);
	var h = int(2.2 * em);
	window.setPopoverFrame('pop_nav', x, y, w, h, em);
}

//刷新列表(搜索/新增后)
function searchList(){
	var theMainWindow = getstorage('theMainWindow');
	setstorage('currPage', 1);
	setstorage('searchtext', $$("searchtext").value);
	window.evaluatePopoverScript(theMainWindow, "pop_nav", "setNewRefresh()");
	getPageNewInfo();
}

//取消搜索(刷新搜索)
function cancelSearch(){
	var theMainWindow = getstorage('theMainWindow');
	setstorage('currPage', 1);
	$$("searchtext").value = "";
	setstorage('searchtext', "");
	window.evaluatePopoverScript(theMainWindow, "pop_nav", "setNewRefresh()");
	getPageNewInfo();
}


//用js格式化数字(可用于金额的处理)
function FormatNumber(s){  
	if(/[^0-9\.]/.test(s)) return "invalid value";
    s=s.replace(/^(\d*)$/,"$1.");
    s=(s+"00").replace(/(\d*\.\d\d)\d*/,"$1");
    s=s.replace(".",",");
    var re=/(\d)(\d{3},)/;
    while(re.test(s))
            s=s.replace(re,"$1,$2");
    s=s.replace(/,(\d\d)$/,".$1");
    return "￥" + s.replace(/^\./,"0.")
}

//过滤html tag及多余空白
function removeHTMLTag(str) {
	if((typeof str=='string')&&str.constructor==String) {
		str = str.replace(/(^\s*)|(\s*$)/g,""); //去除首尾空白
		str = str.replace(/<\/?[^>]*>/g,''); //去除HTML tag
		str = str.replace(/[ | ]*\n/g,'\n'); //去除行尾空白
		//str = str.replace(/\n[\s| | ]*\r/g,'\n'); //去除多余空行
		//str=str.replace(/&nbsp;/ig,'');//去掉&nbsp;
	}
	return str;
}

//去掉首尾空格
function trimStr(str){
	return str.replace(/(^\s*)|(\s*$)/g,"");
}
//包含js文件
function load_js(filename){
	var head = document.getElementsByTagName('head');
	var testScript = document.createElement('script');
	testScript.src = filename+".js";
	testScript.type = 'text/javascript';
	head[0].appendChild(testScript);
} 

// 设置默认客户信息
function setAccInfo(accInfo){
	var accInfo = arguments[0] || JSON.parse(getstorage('selInfo')); 
	$$('accountid').value = accInfo.id;
	$$('accountname').value = accInfo.name;
	var userarr = accInfo.contacts;
	var optsarrlen = userarr.length;
	var forumObj = '';
	forumObj += '<option value=""></option>';
	for(var k=0;k<optsarrlen;k++){
		forumObj += '<option value="'+userarr[k].contactid+'">'+userarr[k].lastname+'</option>';
	}
	setHtml('contactid',forumObj);
	selectValue('contactid','');
}

// 设置默认联系人信息
function setConInfo(accInfo){
	var accInfo = arguments[0] || JSON.parse(getstorage('selInfo')); 
	$$('accountid').value = accInfo.id;
	$$('accountname').value = accInfo.name;
	var userarr = accInfo.contacts;
	var optsarrlen = userarr.length;
	var forumObj = '';
	forumObj += '<option value=""></option>';
	for(var k=0;k<optsarrlen;k++){
		forumObj += '<option value="'+userarr[k].contactid+'">'+userarr[k].lastname+'</option>';
	}
	setHtml('contactid',forumObj);
	selectValue('contactid',accInfo.contactid);
}

// 设置默认销售机会信息
function setPotInfo(potInfo){
	var selInfo = arguments[0] || JSON.parse(getstorage('selInfo')); 
	$$('potentialid').value = selInfo.potentialid;
	$$('potentialname').value = selInfo.potentialname;
}

function showEditButton(){
	$$('editButton').style.display = 'block';
}

function showCreateButton(){
	$$('createButton').style.display = 'block';
}

function removeNode(id){
	var e = $$(id);
	if(e) e.parentElement.removeChild(e);
}

function fmoney(s, n)   
{   
   n = n > 0 && n <= 20 ? n : 2;   
   s = parseFloat((s + "").replace(/[^\d\.-]/g, "")).toFixed(n) + "";   
   var l = s.split(".")[0].split("").reverse(),   
   r = s.split(".")[1];   
   t = "";   
   for(i = 0; i < l.length; i ++ )   
   {   
      t += l[i] + ((i + 1) % 3 == 0 && (i + 1) != l.length ? "," : "");   
   }   
   return t.split("").reverse().join("") + "." + r;   
}

function addCookie(name,value,expires,path,domain){ 
    var str=name+"="+escape(value); 
    if(expires!=""){ 
        var date=new Date(); 
        date.setTime(date.getTime()+expires*24*3600*1000);//expires单位为天 
        str+=";expires="+date.toGMTString(); 
    } 
    if(path!=""){ 
        str+=";path="+path;//指定可访问cookie的目录 
    } 
    if(domain!=""){ 
        str+=";domain="+domain;//指定可访问cookie的域 
    } 
    document.cookie=str; 
} 
//取得cookie 
function getCookie(name){ 
    var str=document.cookie.split(";") 
    for(var i=0;i<str.length;i++){ 
        var str2=str[i].split("="); 
        if(str2[0]==name)return unescape(str2[1]); 
    } 
} 
//删除cookie 
function delCookie(name) {
    var date = new Date();
    date.setTime(date.getTime() - 10000);
    document.cookie = name + "=n;expire=" + date.toGMTString();
}

