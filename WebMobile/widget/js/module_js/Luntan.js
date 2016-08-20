/**
 * 论坛
 */
function LunTanObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      LunTanObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 0;
	this.page1 = 0;
	this.max_page1 = 0;
	this.page2 = 0;
	this.max_page2 = 0;
	this.pageName = 1;
	this.bkid = '';
	this.articleid = '';
	this.sortby = 1;
};

LunTanObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_bk_list':
			this.showBKList(data);
			break;
		case 'get_article_list':
			this.showArticleList(data);
			break;
		case 'get_bkarticle_list':
			this.showBKArticleList(data);
			break;
		case 'get_article_details':
			this.showArticle(data);
			break;
		case 'get_article_comments':
			this.showComments(data);
			break;
		case 'replyPM':
			this.CommentArticleReturn(data);
			break;
		case 'publishArticle':
			this.postfbReturn(data);
			break;
		case 'getReceivers':
			this.ShowReceiveOpts(data);
			break;
		case 'get_edit_field':
			this.ShowEditPage(data);
			break;
	}
}; 
 
LunTanObj.prototype.changeList = function(n){  //切换列表(实例方法)
  	$$('list1').className="c-wh uhide";
	$$('list2').className="c-wh uhide";
	$$('list3').className="c-wh uhide";
	$$('list4').className="c-wh uhide";
	$$('more').className="c-gra uhide";
	$$('list'+n).className="c-wh";	
	this.pageName = n;
	if(n==1 && this.page1<this.max_page2){
		$$('more').className="c-gra";
	}
	if(n==2 && this.page2<this.max_page2){
		$$('more').className="c-gra";
	}
}

LunTanObj.prototype.getList = function(n){  //获取列表(实例方法)
	uexWindow.resetBounceView('0');
	this.sortby = n;
	this.getArticleList();
	this.pageName = n;
}; 

LunTanObj.prototype.getBKList =function(){  //获取板块列表(实例方法)
	this.method = 'get_bk_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
				'"module_name":"'+this.name+'"}';
	this.RequestServer();
}; 

LunTanObj.prototype.showBKList=function(data){  //返回数据(实例方法)
	//document.write(data);
	var bk_list_1 = data;
	var i = 0;
	var j = 0;
	var forumObj = '';
	var bk_list_2;
	for (i = 0; i < bk_list_1.length; i++) {
		bk_list_2 = bk_list_1[i].list;
		if (bk_list_2.length > 0) {
			for (j = 0; j < bk_list_2.length; j++) {
				forumObj += '<div ontouchstart="zy_touch(\'btn-act1\')" onmousedown="zy_touch(\'btn-act1\')"  onclick="openList(\''+bk_list_2[j].id+'\',\''+bk_list_2[j].name+'\');" class="ub umar-a ub-ac uc-a1 uinn3 uba b-gra c-wh">';
	        		forumObj += '<div class="ub ub-f1 t-wh ub-ver uinn3 cattype">';	
					var ss = bk_list_1[i].name.substr(0, 1);
						forumObj += '<div class="tx-c cattxt">'+ss+'</div>';
					forumObj += '</div>';
					forumObj += '<div class="c-wh ub-f9 uinn3" style="width:76%;">';
						forumObj += '<div class="tx-l uinn long_hide">'+bk_list_2[j].name+'</div>';
					forumObj += '</div>';
					
					forumObj += '<div class="ub-f1 uinn3 uc-r1 tx-c t-bla" style="width:12%;font-weight:bold">';
						forumObj += '<div class="tx-c uinn long_hide">'+bk_list_2[j].postsnum+'</div>';
					forumObj += '</div>';
				forumObj += '</div>';
			}
		}
	}
	if(forumObj == ''){
		forumObj += '<div class="uinn">'
		forumObj +='<ul class="ub b-gra ub-ac lis us uinn c-wh">';
		forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">一个版块都没有,快去创建一个吧...</li>';  
		forumObj +='</ul></ul>';
		forumObj += '</div>';
	}
	var cContent = $$('list1');
	var node = document.createElement("div");
	cContent.innerHTML='<div></div>';
	node.innerHTML = forumObj;
	cContent.insertBefore(node,cContent.lastElementChild);
}; 

LunTanObj.prototype.getBKArticleList = function(){ //获取板块文章列表(实例方法)
	if(this.bkid == '')return; 
	this.offset++;
	this.method = 'get_bkarticle_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
				'"module_name":"'+this.name+'",'+
				'"bkid":"'+this.bkid+'",'+
				'"sortby":' + this.sortby + ',' +
				'"offset":' + this.offset + ',' +
       			'"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}

LunTanObj.prototype.getArticleList = function(){ //获取文章列表(实例方法)
	if(this.pageName == 1){
		this.page1++;
		this.offset = this.page1;
	}else{
		this.page2++;
		this.offset = this.page2;
	}
	this.method = 'get_article_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
				'"module_name":"'+this.name+'",'+
				'"sortby":' + this.sortby + ',' +
				'"offset":' + this.offset + ',' +
       			'"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}

LunTanObj.prototype.showArticleList=function(data){  //显示文章列表(实例方法)
	var forumObj = '';
	var lists = data.list;
	for(var i=0;i<lists.length;i++){
		if (lists[i].userPhoto == '') {
			lists[i].userPhoto = "../../css/images/avatar_default1299eb.png";
		}
		var grabg = "";
		if(i%2!=0)
			grabg = "c-gra4";
		forumObj+='<div ontouchstart="zy_touch(\'list-act\')" onclick="openArticle('+lists[i].id+',\''+lists[i].isencrypt+'\',\''+lists[i].base_pwd+'\',\''+lists[i].adminrole+'\')" class="ubb ub b-gra c-m2 t-bla umh4 lis3 '+grabg+'">';
			forumObj+='<div class="avatar"><img src=\"'+lists[i].userPhoto+'\"  /></div>';
			forumObj+='<div class="ub-f1 ub ub-ver lis3">';	
				var state = '';
				if(lists[i].isencrypt == 1){
					 state+='<span style="color:#5197ce"><i class="ion-locked"></i></span>&nbsp;';
				} 
				if(lists[i].haveImg == 1){
					 //state+='<span style="float:right">&nbsp;<i class="icon-picture"></i></span>';
					 state+='<div class="res_pic ub-img umw13 umh1"></div>&nbsp;';
				} 
				forumObj+='<div class="ulev0 ut-s umar-b ub "><div class="ub ub-f1"><div class="text_hide_1 ub ub-f1">'+state+lists[i].name+'</div></div></div>';
				forumObj+='<div class="ub ub-ac t-gra ulev-2 ub-f1 ub-con">';
					forumObj+='<div class="ub-f1 ub-con">'+lists[i].author+'</div>';
					forumObj+='<div class="ub-f1 ub-con"><span><i class="ion-chatbubble-working"></i></span>'+lists[i].replies+'&nbsp;<span><i class="ion-eye"></i></span>'+lists[i].views+'</div>';
					forumObj+='<div class="umar-r">'+lists[i].modifiedtime+'</div>';
				forumObj+='</div>';
			forumObj+='</div>';
		forumObj+='</div>';
	}	
	if(forumObj == ''){
		forumObj += '<div class="uinn">'
		forumObj +='<ul class="ub b-gra ub-ac lis us uinn c-wh">';
		forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">没有相关文章!...</li>';  
		forumObj +='</ul></ul>';
		forumObj += '</div>';
	}
	var cContent = $$('list'+this.pageName);
	var node = document.createElement("div");
	node.innerHTML = forumObj;
	if(this.offset>1){
		cContent.insertBefore(node,cContent.lastElementChild);
	}else{
		cContent.innerHTML='<div></div>';
		cContent.insertBefore(node,cContent.firstElementChild);
	}
	if(this.pageName == 2){
		this.max_page2 = data.lastpg;
	}else{
		this.max_page1 = data.lastpg;
	}
	if(this.offset < data.lastpg){
		$$('more').className="c-gra";
	}else{
		$$('more').className='uhide';
	}
}; 

LunTanObj.prototype.showBKArticleList=function(data){  //显示文章列表(实例方法)
	var forumObj = '';
	var lists = data.list;
	var permitObj = data.permit;
	if(permitObj.create.value == 'yes'){  // 发帖权限
		uexWindow.evaluateScript('sczm', '0', 'showFaTieBt()');
	}
	for(var i=0;i<lists.length;i++){
		if (lists[i].userPhoto == '') {
			lists[i].userPhoto = "../../css/images/avatar_default1299eb.png";
		}
		var grabg = "";
		if(i%2!=0)
			grabg = "c-gra4";
		forumObj+='<div ontouchstart="zy_touch(\'list-act\')" onclick="openArticle('+lists[i].id+',\''+lists[i].isencrypt+'\',\''+lists[i].base_pwd+'\',\''+lists[i].adminrole+'\')" class="ubb ub b-gra c-m2 t-bla umh4 lis3 '+grabg+'">';
			forumObj+='<div class="avatar"><img src=\"'+lists[i].userPhoto+'\"/></div>';
			forumObj+='<div class="ub-f1 ub ub-ver lis3">';	
				var state = '';
				if(lists[i].isencrypt == 1){
					 state+='<span style="color:#5197ce" >&nbsp;<i class="ion-locked"></i></span>';
				} 
				if(lists[i].haveImg == 1){
					// state+='<span style="float:right">&nbsp;<i class="icon-picture"></i></span>';
					 state+='<div class="res_pic ub-img umw13 umh1"></div>&nbsp;';
				} 
				forumObj+='<div class="ulev0 ut-s umar-b ub "><div class="ub ub-f1"><div class="text_hide_1 ub ub-f1">'+state+lists[i].name+'</div></div></div>';
				forumObj+='<div class="ub ub-ac t-gra ulev-2 ub-f1 ub-con">';
					forumObj+='<div class="ub-f1 ub-con">'+lists[i].author+'</div>';
					forumObj+='<div class="ub-f1 ub-con"><span><i class="ion-chatbubble-working"></i></span>'+lists[i].replies+'&nbsp;<span><i class="ion-eye"></i></span>'+lists[i].views+'</div>';
					forumObj+='<div class="umar-r">'+lists[i].modifiedtime+'</div>';
				forumObj+='</div>';
			forumObj+='</div>';
		forumObj+='</div>';
	}	
	if(forumObj == ''){
		if(forumObj == ''){
			forumObj += '<div class="uinn c-gra4">'
			forumObj +='<ul class="ub b-gra ub-ac lis us uinn c-wh">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">没有相关文章!...</li>';  
			forumObj +='</ul></ul>';
			forumObj += '</div>';
		}
	}
	var cContent = $$('list');
	var node = document.createElement("div");
	node.innerHTML = forumObj;
	if(this.offset>1){
		cContent.insertBefore(node,cContent.lastElementChild);
	}else{
		cContent.innerHTML='<div></div>';
		cContent.insertBefore(node,cContent.firstElementChild);
	}
	if(this.offset < data.lastpg){
		$$('more').className="c-gra";
	}else{
		$$('more').className='uhide';
	}
}; 

//LunTanObj.prototype.showBKArticleList=function(data){  //显示文章列表(实例方法)
//	var forumObj = '';
//	var lists = data.list;
//	for(var i=0;i<lists.length;i++){
//		forumObj+='<div ontouchstart="zy_touch(\'list-act\')" onclick="openArticle('+lists[i].id+',\''+lists[i].isencrypt+'\',\''+lists[i].base_pwd+'\',\''+lists[i].adminrole+'\')" class="ubb ub b-gra c-m2 t-bla umh4 lis2">';
//			forumObj+='<div class="res-jt lis-sw1 ub-img umar-a3"></div>';
//			forumObj+='<div class="ub-f1 ub ub-ver">';	
//				var state = '';
//				if(lists[i].isencrypt == 1){
//					 state+='<span style="float:right"><i class="icon-lock"></i></span>';
//				} 
//				if(lists[i].haveImg == 1){
//					 state+='<span style="float:right"><i class="icon-picture"></i></span>';
//				} 
//				forumObj+='<div class="ulev0 ut-s umar-b">'+lists[i].name+state+'</div>';
//				forumObj+='<div class="ub ub-ac t-gra ulev-2">';
//					forumObj+='<div class="ub-f1">作者:'+lists[i].author+'</div>';
//					forumObj+='<div class="ub-f1">回复/浏览:'+lists[i].replies+'/'+lists[i].views+'</div>';
//					
//				forumObj+='</div>';
//			forumObj+='</div>';
//		forumObj+='</div>';
//	}	
//	var cContent = $$('list');
//	var node = document.createElement("div");
//	node.innerHTML = forumObj;
//	if(this.offset>1){
//		cContent.insertBefore(node,cContent.lastElementChild);
//	}else{
//		cContent.innerHTML='<div></div>';
//		cContent.insertBefore(node,cContent.firstElementChild);
//	}
//	if(this.offset < data.lastpg){
//		$$('more').className="c-gra";
//	}else{
//		$$('more').className='uhide';
//	}
//}; 

LunTanObj.prototype.changeBKArticleSort= function(type){
	this.offset = 0;
	this.sortby = type;
	this.getBKArticleList();
}

LunTanObj.prototype.setArticleDetails = function(){ //获取文章详细(实例方法)
	if(this.articleid == '')return; 
	this.offset=1;
	this.method = 'get_article_details';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
				'"module_name":"'+this.name+'",'+
				'"articleid":"'+this.articleid+'",'+
       			'"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}

LunTanObj.prototype.showArticle = function(data){  //显示文章(实例方法)
	var article = data.article;
	setstorage('theArticle', JSON.stringify(article));
	setHtml('title',article.basesname);
	setHtml('author',article.smownername);
	setHtml('tztext',article.content);
	if (article.isstick == '0') {
		$$('isstick').className='t-red';
	}
	if (article.isessence == '1') {
		$$('isessence').className='t-red';
	}
	if (article.ismajor == '1') {
		$$('ismajor').className='t-red';
	}
	if (article.islock == '1') {
		$$('islock').className='t-red';
	}
	if (article.userPhoto != '') {
		$$('avatar_pic').src = article.userPhoto;
	}
	
	setHtml('modifiedtime',article.modifiedtime);
	var forumObj = '';
	for(var i=0;i<data.accounts.length;i++){
		forumObj +='<a onclick="openDetailTab(\'Accounts\',\''+data.accounts[i].id+'\',\'\',\'../\');return false;" href="">【'+data.accounts[i].name+'】</a>';
	}
	if(forumObj != ''){
		$$('relativeAcc_div').className = "c-wh ub t-bla umar-t uinn";
		setHtml('relativeAcc',forumObj);
	}
	forumObj = '';
	for(var j=0;j<data.attachments.length;j++){
		forumObj +='<a onclick="openAttachment(\''+data.attachments[j].id+'\');return false;" href="">【'+data.attachments[j].name+'】</a>';
	}
	if (forumObj != '' && permitObj.atta.value == 'yes') { //下载权限
		$$('relativeAtt_div').className = "c-wh ub t-bla umar-t uinn";
		setHtml('relativeAtt', forumObj);
	}
	onloadimg();
	this.showComments(data.comments);
	var permitObj = data.permit;
	if(permitObj.common.value == 'yes'){  //评论权限
		uexWindow.evaluateScript('theme-yd', '0', 'showHuiFuDiv()');
	}
}

function openAttachment(id){
	setstorage('attachid',id);
	openwin('attachment','');
}
/*
function isExitfile(opId,dataType,data){
	if(dataType==2){
		if(data==1)return true;
		if(data==0)return false;
	}
}

function downloadFile(fileurl,filename){
	myalert(fileurl);
	fileurl = getstorage("CurrentServerAddress")+'/'+fileurl+filename;
	myalert(fileurl);
	var savepath = 'wgt://data/down/'+filename;
	uexFileMgr.openFile(5,savepath,1);
	var fileExist = false;
	uexFileMgr.explorer('');
	uexDownloaderMgr.onStatus = function(opId,fileSize, percent, status){
		myalert('333');
		if(status == 0){
			var str = '下载进度：'+percent+'%';
			if(fileSize==-1) str = '下载中，请稍候...';
			uexWindow.toast('1','5', str,'');
		}else if (status == 1){
			uexWindow.closeToast();
			myalert("下载完成");
			uexDownloaderMgr.closeDownloader('14');
			uexFileMgr.explorer();
			//uexFileMgr.openFile(1,savepath,1);
		}else{
			uexWindow.closeToast();
			uexWindow.toast('0','5','下载失败','2000');
			uexDownloaderMgr.closeDownloader('14');
		}
	}
	uexDownloaderMgr.cbCreateDownloader = function(opId,dataType,data){
		if(data == 0){
			myalert('2222');
			uexDownloaderMgr.download('14', fileurl, savepath, '0');
		}else{
			uexWindow.toast('0','5','下载失败','2000');
		}
	}
	
	uexFileMgr.cbDeleteFileByID = function(opId, dataType, data){
		myalert('1111');
		if (dataType == 2 && data == 0) {
			myalert("删除成功");
			uexDownloaderMgr.createDownloader("14");	
		}
	}
	
	uexWindow.cbConfirm = function ConfirmSuccess(opId, dataType, data){
		if (data == 1) {
			myalert('4444');
			if(fileExist == true){
				myalert('delete');
				uexFileMgr.deleteFileByID(5);
				uexFileMgr.closeFile;
				myalert('why');
			}else{
				uexDownloaderMgr.createDownloader("14");	
			}
		}
	}	
	
	uexFileMgr.cbIsFileExistById = function(opId, dataType, data){
		if (dataType == 2) {
			var tips = "您确定要下载吗?";
			if (data == 1) {
				tips ="您确定要重新下载吗?";
				fileExist = true;
			}
			var mycars=['取消', '下载'];
			uexWindow.confirm('', tips, mycars);
		}
	}
	
	uexFileMgr.isFileExistByID(5);
}
*/

LunTanObj.prototype.getComments = function(){ //获取评论(实例方法)
	if(this.articleid == '')return; 
	this.offset++;
	this.method = 'get_article_comments';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",'+
				'"module_name":"'+this.name+'",'+
				'"articleid":"'+this.articleid+'",'+
				'"offset":' + this.offset + ',' +
       			'"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}

LunTanObj.prototype.showComments = function(data){  //显示评论
	var forumObj = '';
	var lists = data.list;
	
	for(var i=0;i<lists.length;i++){
		if (lists[i].userPhoto == '') {
			lists[i].userPhoto = "../../css/images/avatar_default1299eb.png";
		}
		forumObj +='<div class="ub t-bla umh4 lis3">';
		forumObj +='<div class="avatar">';
			forumObj +='<img src=\"'+lists[i].userPhoto+'\"/>';
		forumObj +='</div>';
		forumObj +='<div class="ub-f1 ub ub-ver lis3">';	
			forumObj +='<div class="ub ub-hor umar-b">'; 
				forumObj +='<div class="ub-f1 ub-hor ufl ulev-1 tx_bold">'; 
					forumObj +='<div class="umar-l">';
						forumObj +='<span>'+lists[i].smownername+'</span>';
					forumObj +='</div>'; 
				forumObj +='</div>'; 
				forumObj +='<div class="ub ub-hor ufr ulev-2">'; 
				forumObj +='<div class="umar-r">';
					forumObj +='<span class="t-gra" >'+(i+2*this.offset)+'楼</span>';
				forumObj +='</div>';
			forumObj +='</div>'; 	  
			forumObj +='</div>';	 
			forumObj +='<div class="ub ub-ac t-gra ulev-2 umar-t">'; 
				forumObj +='<div class="ub-f1 ub ub-hor ufl">'; 
					forumObj +='发表于<div class="umar-l">'+lists[i].modifiedtime+'</div>';
				forumObj +='</div>'; 
				forumObj +='<div class="ub ub-hor ufr">'; 
					forumObj +='<div class="umar-r"><span onclick="replyTo(\''+lists[i].smownername+'\')" style="color:#0066CC">回复<span></div>';
				forumObj +='</div>'; 
			forumObj +='</div>';	 
		forumObj +='</div>'; 
		forumObj +='</div>';  
		 
		forumObj +='<div class="ub ub-ver">'; 
		forumObj +='<div class="umar-a linh2 ulev0" >';
			forumObj +='<div class="arrow_box uc-a1 uinn" >'+lists[i].commenttext+'</div>';
		forumObj +='</div>';
		forumObj +='</div>';
	}
	if(forumObj == ''){
//		forumObj +='<ul class="ub b-gra ub-ac lis">';
//		forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c uba b-gra">还没有人回复哦!快来抢沙发...</li>';  
//		forumObj +='</ul></ul>';
	}
	var cContent = $$('comlist');
	var node = document.createElement("div");
	node.innerHTML = forumObj;
	if(this.offset > 1){
		cContent.insertBefore(node,cContent.lastElementChild);
	}else{
		cContent.innerHTML='<div></div>';
		cContent.insertBefore(node,cContent.firstElementChild);
	}
	if(this.offset < data.lastpg){
		$$('more').className="ub ub-hor c-gra ubt b-gra";
		setHtml('synum','剩余'+data.residue+'楼  加载更多... ');
	}else{
		$$('more').className='uhide';
	}
}

function replyTo(sname){
	uexWindow.evaluateScript('theme-yd','0','replyToSb("'+sname+'")');
}

LunTanObj.prototype.CommentArticle = function(){ //  评论文章(实例方法)
	var message = removeHTMLTag(tt)
	if (message == '') {
		uexWindow.toast('0', '5', "内容不能为空", '1500');
		return false;
	}
	if(toSb != ''){
		message = toSb +' '+message;
	}
	this.articleid = getstorage('CurrentArticleId');  //id
	this.method = 'replyPM';
	this.tip = 0;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"record":"'+this.articleid+'",' +
        '"message":"'+message+'"}';
	this.RequestServer();
}; 

LunTanObj.prototype.CommentArticleReturn=function(data){  //回复保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.evaluatePopoverScript('theme-yd','themecontent1','ltobj.setArticleDetails()');
		uexWindow.evaluatePopoverScript('sczm','sczmcontent','refreshList()');
	}else if(data.result === "FAIL"){
		uexWindow.toast(0, 5, "回复失败", 2000);
	}
}; 

LunTanObj.prototype.postfb = function(){ //发表文章(实例方法)
	this.bkid = getstorage('bkid');
	if(this.bkid == '')return false; 
	$$("title").value = removeHTMLTag($$("title").value);
	$$("text").value = removeHTMLTag($$("text").value);
	var title = $$('title').value;
	var text = $$('text').value;
	var permittype = $$('permittype').value;
	var reciver_user = receiverid.join(',');
	var accountids = accountid.join(',');
	var isencrypt = $$('isencrypt').value;
	var bases_pwd = $$('bases_pwd').value;
	if (title == '') {
		uexWindow.toast('0', '5', "标题不能为空", '1500');
		return false;
	}
	title = encodeURIComponent(title);	
	
	if (text == '') {
		uexWindow.toast('0', '5', "内容不能为空", '1500');
		return false;
	}
	for(var k=0;k<attachnew.length;k++){
		text +='<img src="'+attachnew[k]+'"></img>';
	}
	var uploaddel = '';
	for (var m = 0; m < attachdel.length; m++) {
		uploaddel += '[img]'+attachdel[m];
	}
	if($$('region').innerHTML != ''){
		text +='<br/><br/></br><p>地理位置:'+$$('region').innerHTML+'</p>';
	}
	text = encodeURIComponent(text);
	this.method = 'publishArticle';
	this.tip = 0;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"bkid":"'+this.bkid+'",' +
		'"permittype":"'+permittype+'",' +
		'"reciver_user":"'+reciver_user+'",' +
		'"isencrypt":"'+isencrypt+'",' +
		'"bases_pwd":"'+bases_pwd+'",' +
		'"title":"'+title+'",' +
		'"uploaddel":"'+uploaddel+'",' +
		'"accountids":"'+accountids+'",' +
        '"basescontent":"'+text+'"}';
	this.RequestServer();
}

LunTanObj.prototype.setEditPageBind=function(){  //编辑(实例方法)
	this.theWindow = 'EditPage';
	this.articleid = getstorage("CurrentArticleId");
	this.method = 'get_edit_field';
	this.rest_data = '{"session":"' + this.CurrentUserId + 
		'","module_name":"'+this.name+'",'+
		'"module_id":"' + this.articleid + '"}';
	this.RequestServer();
}; 

LunTanObj.prototype.ShowEditPage = function(data){ //显示编辑表单(实例方法)
	myalert(data);
}

LunTanObj.prototype.postfbReturn=function(data){  //回复保存(实例方法)
	if (data.result === "SUCCESS") {
		uexWindow.toast(0, 5, "发表成功", 2000);
		setstorage('CurrentArticleId', data.record);
		openwin('theme-yd', '');
		uexWindow.evaluatePopoverScript('sczm', 'sczmcontent', 'refreshList()');
		uexWindow.evaluateScript('fb-theme','0','closeWin()');
	}else if(data.result === "FAIL"){
		myalert('发表失败');
	}
}; 

LunTanObj.prototype.getBKSCList =function(){  //获取板块收藏列表(实例方法)
	this.page2++;
	var list = "我是板块收藏"+this.page2+'<br>';
	if(this.page2<10){
		$$('more').className='c-gra';
	}else{
		$$('more').className='uhide';
	}
	var cContent = $$('list2');
	var node = document.createElement("div");
	node.innerHTML = list;
	if(this.page2>1){
		cContent.insertBefore(node,cContent.lastElementChild);
	}else{
		cContent.innerHTML='<div></div>';
		cContent.insertBefore(node,cContent.firstElementChild);
	}
};

LunTanObj.prototype.getTZSCList =function(){  //获取帖子收藏列表(实例方法
	this.page3++;
	var list = "我是帖子收藏"+this.page3+'<br>';
	if(this.page3<10){
		$$('more').className='c-gra';
	}else{
		$$('more').className='uhide';
	}
	var cContent = $$('list3');
	var node = document.createElement("div");
	node.innerHTML = list;
	if(this.page3>1){
		cContent.insertBefore(node,cContent.lastElementChild);
	}else{
		cContent.innerHTML='<div></div>';
		cContent.insertBefore(node,cContent.firstElementChild);
	}
};

LunTanObj.prototype.getZJLLList =function(){  //获取最近浏览列表(实例方法)
	setHtml('list4','最近浏览');
};

function zy_fold_sfa(e, col){
    var a = e.currentTarget.nextElementSibling;
    if (a.nodeName == "DIV") {
        if (col) 
            a.className += 'col-c';
        else 
			a.className = a.className.replace("col-c", "");
    }
}

function openList(id,name){
	setstorage('bkid',id);
	setstorage('title',name);
	openwin('sczm','');
}

//打开文章
function openArticle(id,isencrypt,base_pwd,adminrole){
	uexWindow.cbPrompt = function(opId, dataType, data){
		var obj = eval('('+data+')');
		if(obj.num == 1){
			if (obj.value == base_pwd) {  //密码正确
				setstorage('CurrentArticleId', id);
				openwin('theme-yd', '');  //密码错误
			}else{
				uexWindow.toast('0', '5', '抱歉,您输入的密码有误!!', '2000');
			}
		}
	}
	if(isencrypt==1 && base_pwd!='' && adminrole!='yes'){ //如果没有需要输入密码才能查看
		var mycars=['取消','确定'];
		uexWindow.prompt("查看密码","请输入","",mycars);
	}else{
		setstorage('CurrentArticleId', id);
		openwin('theme-yd', '');
	}
}

function addNewThread(){
	openwin('fb-theme','');
}

function onloadimg(){
	var ee = document.getElementsByTagName("img");
	var imgsrc = '';
	for(var key in ee)
	{
		var eimage = ee[key];
		imgsrc = eimage.src;
		showpic[ii]=eimage.src;
		if(imgsrc && imgsrc.indexOf('http://')==0 && imgsrc.indexOf('.gif')<0 && !eimage.id)
		{
			var id = "img_"+ii;
			//if(imd==1){
			//	eimage.src = '../../css/images/default.png';
			//}else{
				picshow[ii]=1;
			//}
			eimage.id = id;	
			
			var pattern = /&src=(.*?)&/i; 
        	var imgs = pattern.exec(imgsrc); 
			if(imgs && imgs[1]) imgs = imgs[1];
			else{
				imgs = imgsrc.split('&src=');
				if(imgs && imgs[1]) imgs = imgs[1];
				else imgs = imgsrc;
			}
			imglists[ii] = imgs;
			//dis_imgcache(id,imgsrc,imgsrc,imgLoadSucSrc,imgLoadErrSrc,null,'');
			ii++;
		}
	}
}

function viewimage(e){
	if (getstorage('platform') == 1) {
		return false;
	}
	var istr = e.id.substring(4);
	//logs('viewimage--->str='+imglists[istr]);
	//logs('viewimage--->str='+showpic[istr]);
	if(!isDefine(picshow[istr])){
		//if(e) e.src = 'css/images/loading.gif';
		picshow[istr]=1;
		//logs(e.id);
		
		var e = $$(e.id);
		if (e){
			e.src = showpic[istr];
			uexWindow.toast('0','5','图片努力加载中...','2000');
		}
		//zy_imgcache(e.id,showpic[istr],showpic[istr],imgLoadSucSrc,imgLoadErrSrc,null,'');
	}else if(picshow[istr]==1){
		uexImageBrowser.open(imglists, istr, 0);
	}
}
