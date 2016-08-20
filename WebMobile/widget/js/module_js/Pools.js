set_input_msg();
function PoolObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      PoolObj.prototype[attr] = Module.prototype[attr];
	};
	this.method = 'handleRequest';
	this.offset = 1;
	this.CurrentAccountId = 0;
	this.reType = '';
	this.mode = '';
	this.theWindow = '';
	this.assignType = '';
	this.optType = '';
};

PoolObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	this.assignType = getstorage("assignType");   //
	var viewsel = getstorage("pool_viewId");   //视图id
	this.action = "get_entry_list";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
        '"query":"'+searchtext+'",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + ',' +
		'"assignType":"' + this.assignType + '",' +
        '"sel":"'+viewsel+'"}]';
	this.RequestServer();
}; 

PoolObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	if(data.islook !== undefined && data.islook == 'no'){//列表加权限 added by ligangze on 2014/8/22
		forumObj += showNotPermittedDiv();
		setHtml("record_list", forumObj);
		return false;
	}
	var accountsList = data;
	if ((accountsList !== undefined) && (accountsList.entry_list !== undefined)) {		
		var intAccount = 0;
		for (intAccount = 0; intAccount < accountsList.entry_list.length; intAccount++) {
			var bgcolor="c-gra4";
			if(intAccount%2!=0)
				bgcolor = "c-wh";
			if (accountsList.entry_list[intAccount] !== undefined) {
				var account = accountsList.entry_list[intAccount];
				forumObj+='<input type="checkbox" class="uhide">'+
				'<div class="col uc-n t-bla ub ubb b-gra ub-ac ulev-0 umh4">';
				forumObj +='<ul ontouchstart="zy_touch(\'col-active\')" onmousedown="zy_touch(\'col-active\')" onclick="zy_fold_sfa(event);" class="ub ub-f1 b-gra ub-ac lis '+bgcolor+'" style="z-index:2">';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="ub ub-f1"><div class="li_2_2 ub-f1"><i class="icon-home"></i>&nbsp;<span class="li_2_text">'+account.name_value_list.name.value+'</span></div><div class="ufr li_4">'+account.name_value_list.rating.value +'</div></li>';
				var keyContact = '';
				if(isDefine(account.name_value_list.keycontact.value)){  //如果设置了首要联系人
					keyContact += '<i class="icon-user"></i>&nbsp;<span class="li_2_text">'+account.name_value_list.keycontact.value+'</span>:';
					if(isDefine(account.name_value_list.keycontact.value)){  //首要联系人设置了手机
						keyContact += '<i class="icon-phone"></i>&nbsp;'+account.name_value_list.keymobile.value;
					}
					if(isDefine(account.name_value_list.keyqq.value)){   //首要联系人设置了QQ
						keyContact += '<i class="icon-qq"></i>&nbsp;'+account.name_value_list.keyqq.value;
					}
				}
				forumObj +='<li class="li_2_2">'+keyContact+'</li>';  
				if (isDefine(account.name_value_list.latestnote.value)) {
					forumObj += '<li class="li_2_2"><i class="icon-calendar"></i>&nbsp;' + account.name_value_list.latestnote.value + '</li>';
				}
				if (this.assignType == 'assigned') {
					forumObj += '<li class="li_2_2"><i class="icon-lock"></i>&nbsp;' + account.name_value_list.startdate.value.replace(/-/g,'/')+ '-' + account.name_value_list.enddate.value.replace(/-/g,'/')+ '</li>';
				}
				var col_cc = ' color="#008800"';
				forumObj +='</ul></ul>';
				if (this.assignType == 'unassigned') {
					forumObj+='<div class="ub ub-ac c-blu act-blu" style="position: absolute;right:0;width:18%;height:95%;margin-top:2px;z-index:1;"><div onclick="LQAccount(\'' + account.id + '\')" class="uinn tx-c t-wh ub-f1">领取</div></div>';
				}else{
					forumObj+='<div class="ub ub-ac c-blu act-blu" style="position: absolute;right:0;width:18%;height:95%;margin-top:2px;z-index:1;"><div onclick="SFAccount(\'' + account.id + '\')" class="uinn tx-c t-wh ub-f1">释放</div></div>';
				}
				forumObj +='</div>';
			}
		}
		if(accountsList.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("record_list", forumObj);
		if(accountsList.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', accountsList.lastpg);
			uexWindow.evaluatePopoverScript('PoolListPage','pop_nav',"setPageSel()");
		}
	}else{
		var forumObj = '';
		forumObj += '<div class="uinn">'
		forumObj +='<ul class="ub b-gra ub-ac lis us uinn ">';
		forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">'+data+'</li>';  
		forumObj +='</ul></ul>';
		forumObj += '</div>';
		setHtml("record_list", forumObj);
	}
}

PoolObj.prototype.PoolAccDraw=function(){  //获取列表(实例方法)
	this.action = "PoolAccDraw";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
        '"userid":' + receiverid + ',' +
        '"accountid":' + this.CurrentAccountId + '}]';
	this.RequestServer();
}; 

PoolObj.prototype.PoolRelease=function(){  //获取列表(实例方法)
	this.action = "PoolRelease";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
        '"accountid":' + this.CurrentAccountId + '}]';
	this.RequestServer();
}; 

PoolObj.prototype.PoolExtension=function(){  //获取列表(实例方法)
	this.action = "PoolExtension";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
		'"extensionday":' + extensionday + ',' +
        '"accountid":' + this.CurrentAccountId + '}]';
	this.RequestServer();
}; 

PoolObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(this.action){
		case 'get_entry_list':
			this.ShowList(data);
			break;
		case 'PoolAccDraw':
			uexWindow.toast("0","5",data.record,"2000");
			if (data.result == 'SUCCESS') {
				uexWindow.evaluateScript('PoolListPage','0',"searchList()");
			}
			break;
		case 'PoolRelease':
			uexWindow.toast("0","5",data.record,"2000");
			if (data.result == 'SUCCESS') {
				uexWindow.evaluateScript('PoolListPage','0',"searchList()");
			}
			break;
		case 'PoolExtension':
			uexWindow.toast("0","5",data.record,"2000");
			if (data.result == 'SUCCESS') {
				uexWindow.evaluateScript('PoolListPage','0',"searchList()");
			}
			break;
	}
};  

PoolObj.prototype.ReturnSuccess = function(data){ //
	
}

var lastFold = '';
function zy_fold_sfa(e, col){
	var a = e.currentTarget;
	if (lastFold != "" && lastFold != a) {
		if (lastFold.className.indexOf(' animotion') < 0) {
			
		}else{
            lastFold.className = lastFold.className.replace(" animotion", " ooanimotion");
        }
	}
    if (a.nodeName == "UL") {
        if (a.className.indexOf(' animotion') < 0) {
			a.className = a.className.replace(" ooanimotion", "");
            a.className += ' animotion';
		}else {
			a.className = a.className.replace(" animotion", " ooanimotion");
		}
    }
	lastFold = a;
}

