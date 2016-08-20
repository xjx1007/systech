var isSML = 0;
if(window.navigator.platform=='Win32'){
	isSML = 1;
}	

var page_pm = true;
var page_cm = true;
var page_pm_offset = 1;
var page_pm_last = 1;
var page_cm_offset = 1;
var page_cm_last = 1;
var oldPage_index = 0;
//var pmobj = new PMObj('mobilePM');
//var cmobj = new CMObj('commandApprove');
//切换页面
function goToPage(page_index){
	if (page_index != oldPage_index) {
		var j = page_index<2?page_index:page_index+1;
//		$('.tab-item').removeClass('active').eq(j).addClass('active');
		radioSelect('ihd'+page_index);  
		//$('.ip-sta').eq(page_index).css('z-index','20');//刷新当前是第几页
		//$('.ip-sta').eq(oldPage_index).css('z-index','10');//刷新当前是第几页
		oldPage_index = page_index;
		if(page_index == 1 && page_pm){
			//pmobj.AjaxUrl = getstorage("CurrentServerAddress");
			page_pm_offset = 1;
			//pmobj.GetListDataFromServer();
			//page_pm = false;//ligangze
			$('.pmli').live('click',readThePm);
			$('#morepm').live('click',loadMorePm);
			$('.deletepm').live('click',deleteThePm);
		}
		if(page_index == 2 && page_cm){
			//cmobj.AjaxUrl = getstorage("CurrentServerAddress");
			page_cm_offset = 1;
			//cmobj.GetListDataFromServer();
			//page_cm = false;//ligangze
			//$('.pmli').live('click',readThePm);
			$('.morecm_btn').live('click',loadMoreCm);
			//$('.deletepm').live('click',deleteThePm);
		}
	}
}

/*---------最新消息---------*/
//最新消息页面中 <编辑>按钮
function showDelete(){
//	if ($('#editpm').html() == '完成') {
//		$('.pmli').animate({
//               '-webkit-transform': 'translate3d(0, 0, 0)'
//        	}, 0.5, 'linear');
//		$('#editpm').html('编辑');
//		$('#newpm').show();
//		$('.pmli').live('click',readThePm);
//		$('#morepm').live('click',loadMorePm);
//	}else {
//		$('.pmli').animate({
//               '-webkit-transform': 'translate3d('+$('.deletepm').width()+'px, 0, 0)'
//        	}, 0.5, 'linear');
//		$('#editpm').html('完成');
//		$('#newpm').hide();
//		$('.pmli').die();
//		$('#morepm').die();
//	}
	
	if($('#editpm').hasClass('ion-checkmark-round')){
		$('.pmli').animate({
			'-webkit-transform':'translate3d(0,0,0)'
		},0.5,'linear');
		$('#editpm').removeClass('ion-checkmark-round');
		$('#editpm').addClass('ion-compose');
		$('#newpm').show();
		$('.pmli').live('click',readThePm);
		$('#morepm').live('click',loadMorePm);
	}else{
		$('.pmli').animate({
               '-webkit-transform': 'translate3d('+$('.deletepm').width()+'px, 0, 0)'
        	}, 0.5, 'linear');
		$('#editpm').removeClass('ion-compose');
		$('#editpm').addClass('ion-checkmark-round');
		$('#newpm').hide();
		$('.pmli').die();
		$('#morepm').die();
		
	}
	
}

//读取消息
function readThePm(){
	var pid = $(this).children('input').eq(0).val();
	var read = $(this).children('input').eq(1);
	if(read.val() == 0){
		$(this).children('ul').eq(0).removeClass('tx_bold');
		read.val(1);
		//pmobj.receivePM_home(pid);
	}
	setstorage('CurrentPMId', pid);
	openwin('PMDetailsPage','modules/PM/');
}

//加载更多消息
function loadMorePm(){
//	pmobj.GetListDataFromServer();
}

//删除消息
function deleteThePm(){
	var pid = $(this).prev('div').children('input').eq(0).val();
	$(this).parent().remove();
	//pmobj.DeletePM_home(pid);
}

/*---------登陆页面---------*/
//打开登陆页面
function openLoginPage(){
	//$('.ip-sta').eq(5).show().removeClass('for_animation').addClass('fir_animation');//noted by ligangze on 2014-09-02 iphone
	openwin('Login','');//安卓
}

//打开pop
function openpop_logout(){
	var arr = new Array(1);
	arr[0]= '确认退出';
	uexWindow.cbActionSheet = function(opId, dataType, data){
		var index = parseInt(data);
		if (index == 0) {
			//取消自动登录
			var logindata = getstorage('crmloginInfo');
			if (isDefine(logindata)) {
				var dataobj = JSON.parse(logindata);
				dataobj.autologin = 0;
				var str = JSON.stringify(dataobj);
				setstorage('crmloginInfo', str);
				//alert(str);
			}//ligangze
			openLoginPage();
		}
	};
	uexWindow.actionSheet('请选择',RES_CANCEL_BUTTON,arr);
}

//关闭登陆页面
function closeLoginPage(){
	//$('.myadd').live('click',openAddPage);
	
	//安卓	
	uexWindow.close(this);//added by ligangze on 2014-09-10
	uexWindow.evaluateScript("root",0,"openHomePage()");
	uexWindow.evaluateScript("root",0,"goToPage(0)"); 
	//安卓--
	//openHomePage();//ipone
	//goToPage(0);//iphone
	//$('.ip-sta').eq(5).removeClass('fir_animation').addClass('for_animation');//ligangze iphone
	setTimeout(function(){
		//$('.ip-sta').eq(5).hide();//ligangze iphone
		//ureportobj.AjaxUrl = getstorage("CurrentServerAddress");
		//ureportobj.GetWeekDataFromServer();//加载列表
	}, 300);
}

/*---------指令页面---------*/
function setTypeCommandList(i){
	if (radioSelect('item_type' + i) !== 'notChange') {
		page_cm_offset = 1;
		$('.cmli').parent().remove();
		s8._resize();
		//cmobj.GetListDataFromServer();
	}
}

//点击指令-审批列表
$('.cmlist_item').live('click',function(event){
	if (event.target.className != 'item_imgs') {
		var item_id = $(this).prev().val();
		openCommandDetail(item_id,'modules/CommandApprove/');
	}else{//预览图片
		var imglist = $(this).find('.item_imglist').eq(0).val();
		var array = imglist.split('[img]');
		array.shift();
		for (var i = 0; i < array.length; i++) {
			//array[i] = cmobj.AjaxUrl + '/' + array[i];
		}
		uexImageBrowser.open(array);
	}
});

function loadMoreCm(){
	//cmobj.GetListDataFromServer();
}

/*---------home页面---------*/
//var ureportobj = new UreportObj('mobileUreports');
//打开home页面
function openHomePage(){
	var logindata = getstorage('crmloginInfo');
	if (isDefine(logindata)) {
		var dataobj = JSON.parse(logindata);
		
		//alert(JSON.stringify(dataobj));
		$('#currentuser').html(dataobj.currentuser);
		$('#companyname').html(dataobj.companyname);
		if (dataobj.userphoto != '') {
			$('#userphoto').attr("src",dataobj.userphoto);
		}
	}
}

//打开pop
function openpop(){
	var arr = new Array(3);
	arr[0]= RES_ACCOUNT_LABEL;
	arr[1]= RES_SALEORDERS_LABEL;
	arr[2]= '销售机会';
	uexWindow.cbActionSheet = actionSheetSuccess;
	uexWindow.actionSheet(RES_SELECT_NEW_TYPE,RES_CANCEL_BUTTON,arr);
}
	
var actionSheetSuccess = function(opId, dataType, data){
    var index = parseInt(data);
	setstorage('thePage', 'Home');
    if(index == 0){
		openCreatePage('account','');
    }
	if(index == 1){
		openCreatePage('salesorder','');
    }
	if(index == 2){
		openCreatePage('potential','');
    }
}

$('.myadd').live('click',openAddPage);
//打开添加页面
function openAddPage(){
	$('.myadd').die();//解除<添加>绑定事件
	$('.ip-sta').eq(4).show().removeClass('for_animation').addClass('fir_animation');
	event.stopPropagation();
}

//切换图表显示的数据
$('.weekdata').live('click',function(){
	var newweekdata_type = $(this).children('.weekdata_type').html();
	if(weekdata_type != newweekdata_type){
		weekdata_type = newweekdata_type;
		showChart();
	};
});

//关闭大图
$('#closeChart').live('tap',function(){
	//$('#zoomUpDiv').css('top', "100%");
	$("#zoomUpDiv").animate({
         top: '200%'
     }, 200);
});

var weekReportsData;
var weekdata_type ;
//显示周报告
function ShowWeekReports(data){
	var k = 0;
	var updown_icon=[];
	weekReportsData = data;
	//balanced
	updown_icon['U']='<i class="icon  ion-arrow-up-c"></i>';
	updown_icon['D']='<i class="icon assertive ion-arrow-down-c"></i>';
	for (var property in data) {
		$('.weekdata_total').eq(k).html(data[property].total);
		$('.weekdata_type').eq(k).html(property);
		$('.weekdata_title').eq(k).html(data[property].title);
		$('.weekdata_updown').eq(k).html(updown_icon[data[property].updown]+'&nbsp;'+data[property].percent);
		k++;
	}
	weekdata_type = $('.weekdata_type').eq(0).html();
	showChart();
}

//显示报告图表
function showChart(){
	var datas = [];   //y轴具体数据
	var categories = []; //x轴数据
	var chatData = weekReportsData[weekdata_type].weekdata;
	for (var property in chatData) {
		categories.push(property);
		datas.push(chatData[property]);
	}
	var chartObj;
	chartObj = new Highcharts.Chart({
			chart: {
				animation: true,
				renderTo: 'container',
				defaultSeriesType: 'line'
			},
			plotOptions: {
				series: {
					animation: true,
					states: {
						hover: {
							enabled: false
						}
					}
				},
				line: {
		           events: {
	                legendItemClick: function (e) {
							e.preventDefault();
	                    }
	                }
		        }
			},
			title: {
				text: weekReportsData[weekdata_type].chartTitle
			},
			xAxis: {
				categories: categories
			},
			yAxis: {
				title: {
					text: '数值'
				},
				plotLines: [{
					value: 0,
					width: 1,
					color: '#A2A2A2'
				}]
			},
			tooltip: {
				formatter: function() {
		                return false;
				}
			},
			series: [{
				name: '周起始日期',
				data: datas
			}]
		});
	chartObj.container.onclick = function(){
		$("#zoomUpDiv").animate({
         top: '0'
     }, 200);
	};
	var chartObj1 = new Highcharts.Chart({
			chart: {
				animation: true,
				renderTo: 'bigContainer',
				defaultSeriesType: 'line'
			},
			plotOptions: {
				series: {
					animation: true,
					states: {
						hover: {
							enabled: false
						}
					}
				}
			},
			title: {
				text: weekReportsData[weekdata_type].chartTitle
			},
			xAxis: {
				categories: categories
			},
			yAxis: {
				title: {
					text: '数值'
				},
				plotLines: [{
					value: 0,
					width: 1,
					color: '#A2A2A2'
				}]
			},
			tooltip: {
				formatter: function() {
		                return '<b>'+ this.series.name +'</b>'+
						this.x +': '+ this.y;
				}
			},
			series: [{
				name: '周起始日期',
				data: datas
			}]
		});
}

/*---------添加页面---------*/
//关闭添加页面
function closeAddPage(){
	$('.myadd').live('click',openAddPage);//给<添加>绑定事件
	$('.ip-sta').eq(4).removeClass('fir_animation').addClass('for_animation');
	setTimeout(function(){
		$('.ip-sta').eq(4).hide();
	}, 300);
}

/*--------名片添加客户------*/
function openCardPage(){
	$('.ip-sta').eq(6).show().removeClass('for_animation').addClass('fir_animation');
	event.stopPropagation();
}

function closeCardPage(){
	$('.ip-sta').eq(6).removeClass('fir_animation').addClass('for_animation');
	setTimeout(function(){
		$('.ip-sta').eq(6).hide();
	}, 300);
}

//检查软件是否更新
function initAndCheckUpdate(){
	uexWindow.onKeyPressed = function(keyCode){
		uexWidgetOne.exit();
	}
	
	uexDevice.cbGetInfo = function(opCode,dataType,data){
		var device = eval('('+data+')');
		var network = device.connectStatus;
		deviceToken = device.deviceToken;
		logs(deviceToken);
		if (isDefine(deviceToken)) {
			setstorage('deviceToken', deviceToken);
		}
		
		if(network == -1 && network != undefine){
			uexWindow.closeToast();
			uexWindow.myalert("ERROR","网络异常，请检查是否连接网络！","返回");
		}
	}
	uexWidgetOne.cbError = function(opCode,errorCode,errorInfo){
		myalert("errorCode:" + errorCode + "\n"+"errorInfo:" + errorInfo);
	}
	uexDevice.getInfo('13');  //检查网络
	//绑定当前用户信息到AppCan推送服务器
	
	setdeviceToken();
	//获取当前应用的DeviceToken
	uexDevice.getInfo('11');
	pushlt();
	getInfor(); // 获取app信息
	if (!isSML) {
		checkWidgetUpdate();
	}
	uexWindow.setReportKey("1","1"); //拦截左键
	uexWindow.setReportKey('0', '1');//拦截返回键
}

function getInfor(){
	var an = getstorage('appname');
	uexWidgetOne.cbGetCurrentWidgetInfo = function (opId,dataType,data){
		//logs('getInfor()-->'+dataType+', '+data);
		if (dataType == 1) {
			var obj = eval('('+data+')');
			//myalert(obj.name);
			//myalert(obj.appId);
			setstorage('appname',obj.name);
			setstorage('appid',obj.appId);
		}
	}
	if(!an) uexWidgetOne.getCurrentWidgetInfo();
	if(isSML) setstorage('appname','c3crm');
}

//检查更新
function checkWidgetUpdate(){
	var updateurl = '';
	var savePath = '';
	var appid = getstorage('appid');
	if(!appid) appid = 'appcanapp';
	var filepath2 = '/sdcard/'+appid+'.apk';
	uexDownloaderMgr.onStatus = function(opId,fileSize, percent, status){
		if(status == 0){
			var str = '下载进度：'+percent+'%';
			if(fileSize==-1) str = '下载中，请稍候...';
			uexWindow.toast('1','5', str,'');
		}else if (status == 1){
			uexWindow.closeToast();
			uexDownloaderMgr.closeDownloader('14');
			uexWidget.installApp(filepath2);
		}else{
			uexWindow.closeToast();
			uexWindow.toast('0','5','下载失败','2000');
			uexDownloaderMgr.closeDownloader('14');
		}
	}
	uexDownloaderMgr.cbCreateDownloader = function(opId,dataType,data){
		if(data == 0){
			logs('updateurl='+updateurl);
			uexDownloaderMgr.download('14', updateurl, filepath2, '0');
		}else{
			uexWindow.toast('0','5','下载失败','2000');
		}
	}
	uexWindow.cbConfirm = function ConfirmSuccess(opId, dataType, data){
		if (data == 1) {
			if(serviceUpdate){
				myalert('服务端sevice也需要更新哦!');
				clearCache();
			}
			if(platform==0){
				uexWidget.loadApp("", "", updateurl);
			}else if(platform==1) {
				uexDownloaderMgr.createDownloader("14");	
		
			}
		}
	}
	uexWidget.cbCheckUpdate = function (opCode, dataType, jsonData){
		var obj = eval('('+jsonData+')');
		var tips = '';
		if(obj.result == 0){
			tips = "更新地址是：" + obj.url + "<br>文件名：" + obj.name + "<br>文件大小：" + obj.size + "<br>版本号：" + obj.version;
			updateurl = obj.url;
			savePath = obj.name;
			var mycars=['稍后', '更新'];
			uexWindow.confirm('', '当前有新版本，是否更新?', mycars);		
		}else if(obj.result == 1){
			tips = "Current version is the newest";
		}else if(obj.result == 2){
			tips = "Unknow error";
		}else if(obj.result == 3){
			tips = "Params error";
		}
		//myalert(tips);
		logs('cbCheckUpdate()-->tips='+tips);
	}
	uexFileMgr.cbIsFileExistByPath = function(opCode,dataType,data){
		if(data == 1){
			uexWidget.checkUpdate();
		}
	}
	uexWidgetOne.cbGetPlatform = function(opId,dataType,data){
		platform = data;
		if(data==0){ //iphone
			uexWidget.checkUpdate();
		}else if(data==1){ //android
			uexFileMgr.isFileExistByPath('/sdcard/');
		}
		setstorage('platform', data);
	}
	uexWidgetOne.getPlatform();
}

function pushlt(){
	uexWidget.setPushNotifyCallback("getNpush");
	uexWidget.cbGetPushInfo = pushInfoCallback;
	uexWidget.getPushInfo();
}

function getNpush(){
	uexWidget.getPushInfo();
}

function pushInfoCallback(id,dataType,data){
	var json = JSON.parse(data);
	switch (parseInt(json.TypeID)) {
		
	}
}

function setdeviceToken(){
	//绑定用户UID和用户昵称到AppCan后台服务器
	 uexWidget.setPushInfo("windeidolon","");
}
