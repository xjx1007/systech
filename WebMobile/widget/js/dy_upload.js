/*Creat at 2013-05-23 for c3crm v3.0 by xiao*/

/*上传图片*/
var ulopid = 2000;
var ulObj = null;
var inCompress = '3'; //压缩等级
var disUpload = function(ulUrl, type, actCb, susCb){
	this.url = ulUrl;
	this.type = type;
	this.actCb = actCb;
	this.susCb = susCb;
	ulObj = this;
	logs('disUpload()-->type='+type+', ulUrl='+ulUrl);
	return this;
}

disUpload.prototype = {
	upSelect:function(){
		var self = this;
		uexWindow.cbActionSheet = function(opId, dataType, data){
			var cmd = parseInt(data);
			if(cmd<2) self.upMethod(cmd);
		}
		
		var value = ["拍名片","相册选择"];
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
		var self = this;
		var opid = ulopid + '';
		self.src = src;
		if(self.actCb) self.actCb(false);
		uexWindow.toast('1', '5', '正在上传...', "");
		uexUploaderMgr.cbCreateUploader = cbCreateUploader;
		uexUploaderMgr.createUploader(opid, self.url);
		ulopid++;
	}
}

function cbCreateUploader(opCode, dataType, data) {
	var self = ulObj;
	var d = int(data);
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


function onUploadStatus(opCode, fileSize, percent, serverPath, status) {
	var str = '';
	var self = ulObj;
	switch (status) {
	case 0:
		str = '已上传：'+percent+'%';
		break;
	case 1:
		uexWindow.closeToast();
		uexUploaderMgr.closeUploader(opCode);
		str = "上传成功";
		logs('onUploadStatus()-->serverPath='+serverPath);
		if(self.susCb) self.susCb(serverPath);
		if(self.actCb) self.actCb(true);
		break;
	default:
		uexWindow.closeToast();
		str = '上传失败';
		uexUploaderMgr.closeUploader(opCode);
		if(self.actCb) self.actCb(true);
		break;
	}
	if(str) uexWindow.toast('0', '5', str, 2000);
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */