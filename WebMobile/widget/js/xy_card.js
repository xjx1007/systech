/*Creat at 2013-05-23 for c3crm v3.0 by xiao*/

/*上传图片*/
var ulopid = 2000;
var ulObj = null;
var inCompress = '2'; //压缩等级
var xyCard = function(ulUrl, type, actCb, susCb){
	this.url = ulUrl;
	this.type = type;
	this.actCb = actCb;
	this.susCb = susCb;
	ulObj = this;
	logs('xyUpload()-->type='+type+', ulUrl='+ulUrl);
	return this;
}

var cardData = null;
xyCard.prototype = {
	upSelect:function(){
		var self = this;
		uexWindow.cbActionSheet = function(opId, dataType, data){
			var cmd = parseInt(data);
			if(cmd<2) self.upMethod(cmd);
		}
		
		var value = ["拍照","相册选择"];
		uexWindow.actionSheet('请选择', '取消', value);
	},
	upMethod:function(cmd){
		var self = this;
		if(cmd==1){
			uexImageBrowser.cbPick = function(opCode, dataType, data) {
				self.uploadImg(data);
			}
			uexImageBrowser.pick();
		}
		else{
			uexCamera.cbOpen = function(opCode, dataType, data) {
				self.uploadImg(data);
			}
			uexCamera.open();
		}
	},
	
	uploadImg:function(src){
	$('#cardPhoto').attr("src",src);
		var self = this;
		var opid = ulopid + '';
		self.src = src;
		if(self.actCb) self.actCb(false);
		uexWindow.toast('1', '5', '正在上传并识别中，请稍等。。。', "");
//		uexUploaderMgr.cbCreateUploader = cbCreateUploader;
//		uexUploaderMgr.createUploader(opid, self.url);
//		ulopid++;
		var httpId = 998; //file：上传文件路径
//
	   uexXmlHttpMgr.onData = function(inOpCode,inStatus,inResult){
	   	 uexWindow.closeToast();
	     if(inStatus == 1){
		   alert('i back');
		   uexLog.sendLog('[POST] '+inResult);
	       uexXmlHttpMgr.close(httpId);
		   var data = JSON.parse(inResult);
		   $('#cardInfo').html(data.accountname+' '+data.keycontact);
		   cardData = inResult;
		   openCardPage();
		   //var data =JSON.parse(inResult);
		   //document.write(data.accountname);
	       
//		   VCF.parse(inResult, function(vc) {
//           	uexLog.sendLog(JSON.stringify(vc));
//          });
	     }
	   }
	   //alert(self.url);
	   //开始一个跨域异步请求
	   uexXmlHttpMgr.open(httpId,'post',self.url,20000);
	   if(self.src){
	     uexXmlHttpMgr.setPostData(httpId,'1','file',self.src);
	   }
	   uexXmlHttpMgr.send(httpId);
	},
}
  
function cbCreateUploader(opCode, dataType, data) {
	var self = ulObj;
	var d = parseInt(data);
	if (d == 0) {
		var flag = 'attach';
		if (self.type=='thread' || self.type=='reply' || self.type=='avatar') flag = 'Filedata';
		uexUploaderMgr.onStatus = onUploadStatus;
		logs('cbCreateUploader()-->inCompress1='+inCompress);
		uexUploaderMgr.uploadFile(opCode, self.src, 'file', inCompress);
	} else {
		uexWindow.toast('0', '5', "上传失败", 2000);
		if(self.actCb) self.actCb(true);
		uexUploaderMgr.closeUploader(opCode);
	}
}


function onUploadStatus(opCode, fileSize, percent, inResult, status) {
	var str = '';
	var self = ulObj;
	switch (status) {
	case 0:
		str = '已上传：'+percent+'%';
		break;
	case 1:
	alert('come on');
		uexWindow.closeToast();
		uexUploaderMgr.closeUploader(opCode);
		//document.write(inResult);
		logs('onUploadStatus()-->serverPath='+inResult);
		uexLog.sendLog('[POST] '+inResult);
		   //VCF.parse(inResult, function(vc) {
           	var data = JSON.parse(inResult);
			$('#cardInfo').html(data.accountname+' '+data.keycontact);
			openCardPage();
//			//openCreatePage('account','');
         // });
		break;
	default:
		uexWindow.closeToast();
		str = '上传失败';
		uexUploaderMgr.closeUploader(opCode);
		break;
	}
	if(str) uexWindow.toast('0', '5', str, 2000);
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */