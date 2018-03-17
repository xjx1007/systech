function Module(name){					//定义构造函数
	this.name = name;
	this.AjaxUrl = getstorage("CurrentServerAddress");  //请求url地址
	this.CurrentUserId = getstorage("SugarSessionId");  //当前用户ID
	this.inJQ = false;   //是否引入jquery
	this.cacheFlag = false;   //是否使用缓存
	this.method = '';     //调用方法名
	this.rest_data = '';  //参数
	this.tip = 1;
}                                    

Module.prototype.RequestServer = function() {	//添加RequestServer方法
    var m =[{"key":"rest_data","type":"0","value":this.rest_data},
		{"key":"method","type":"0","value":this.method},
		{"key":"input_type","type":"0","value":"JSON"},
		{"key":"response_type","type":"0","value":"JSON"}];
    var url = this.AjaxUrl + '/rest.php?callback=?&request_method=' + this.method + '&request=' + encodeURIComponent(this.rest_data);
	var currObj = this;
	var jApp = this.dealConflict();
	this.ShowLoadTips();   //显示加载提示
	jApp.getJSON(url,    //请求数据
	function(data){
		currObj.HideLoadTips();  //关闭加载提示
		if (data === "Invalid Session ID") {
		//	Windows.toast(0, 5, "ID异常,请重新登陆...", 3000);
		}
		currObj.ShowResultToClient(currObj.method,data); //处理结果
	},"json",//返回类型为json　
	function(err){//处理提交异常
	    //currObj.HideLoadTips();
	    // Windows.toast(0, 5, "连接服务器异常,请检查网络...", 3000);
	},"POST",//以POST方式提交, 
	m,currObj.cacheFlag);//提交的参数键值对对象 
};  

Module.prototype.ShowLoadTips = function(){  //显示加载提示
	//$$("loading").style.display='block';
	var msg = '';
	if(this.tip == 1){
		msg = '获取信息中，请稍候...';
	}else if(this.tip == 0){
		msg = '信息提交中，请稍候...';
	} 
	if (msg != '') {
		Windows.toast(1, 5, msg, 0);
	}
	//showPageLoadingMsg(RES_DATA_LOADING);
}

Module.prototype.HideLoadTips = function(){  //关闭加载提示
	Windows.closeToast();
	//$$("loading").style.display='none';
	//showPageLoadingMsg(RES_DATA_LOADING);
}

Module.prototype.dealConflict = function(){  //jquery冲突处理
	if(this.inJQ){
		return  jApp;
	}
	return $;
}

Module.prototype.ValidateCheck=function(){  //是否已填必填信息(实例方法)
	var inputs = getElementsByClassName("MandatoryBox");
	var inputlen = inputs.length;
	var select_fields = '';
	var mandatory_field;
	for(var i=0;i<inputlen;i++){
		mandatory_field = inputs[i].name.substring(10);
		if(mandatory_field == 'account_id'){
			var account_id = $$("accountid");
			if(account_id.value == ""){
				myalert(inputs[i].value+"不能为空!");
			    return false;
			}
		}else if(mandatory_field == 'contact_id'){
			var contact_id = $$("contactid");
			if(contact_id.value == ""){
				myalert(inputs[i].value+"不能为空!");
			    return false;
			}
		}else{
			if($$(this.name+mandatory_field).value == ""){
				myalert(inputs[i].value+"不能为空!");
			    return false;
			}
		}
	}
	return true;
};




       

 
