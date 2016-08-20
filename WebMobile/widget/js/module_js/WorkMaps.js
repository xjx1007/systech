/**
 * 地图操作
 */
set_input_msg();
function WorkMapObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      WorkMapObj.prototype[attr] = Module.prototype[attr];
	};
	this.method = 'handleRequest';
	this.offset = 1;
};

WorkMapObj.prototype.getAccountAddressInfo=function(accountid){  //获取 客户地址信息
	this.action = 'getAccountAddressInfo';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"accountid":"'+accountid+'"}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.markUser=function(lng,lat,address){  //标记用户位置
	this.action = 'markUser';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"lng":"'+lng+'",'+
		'"lat":"'+lat+'",'+
		'"address":"'+address+'"}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.markAccount=function(lng,lat,address,accountid){  //标记客户位置
	this.action = 'markAccount';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"lng":"'+lng+'",'+
		'"lat":"'+lat+'",'+
		'"address":"'+address+'",'+
		'"accountid":'+accountid+'}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.getAccountMark=function(lng,lat,distance){  //搜索附近客户
	this.action = 'getAccountMark';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"lng":"'+lng+'",'+
		'"lat":"'+lat+'",'+
		'"distance":"'+distance+'"}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.getKQD=function(){  //获取已设置的考勤点
	this.action = 'getKQD';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'"}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.markUserKQ=function(){  //标记用户位置
	this.action = 'markUserKQ';
	var lng = $$('new_lng').value;
	var lat = $$('new_lat').value;
	var address = $$('new_address').innerHTML;
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"lng":"'+lng+'",'+
		'"lat":"'+lat+'",'+
		'"address":"'+address+'",'+
		'"kqdid":"'+currentKqd_id+'"}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.getMarkVisitList = function(){//  获取拜访客户列表
	this.action = "getMarkVisitList";
	this.rest_data = '[{"session":"'+ this.CurrentUserId +'",'+
		'"module_name":"'+ this.name +'",'+
		'"action":"'+this.action+'",'+
		'"query":"",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + '}]';
	this.RequestServer();
}

WorkMapObj.prototype.getLocationShootingList = function(){//  获取实景照片列表
	this.action = "getLocationShootingList";
	this.rest_data = '[{"session":"'+ this.CurrentUserId +'",'+
		'"module_name":"'+ this.name +'",'+
		'"action":"'+this.action+'",'+
		'"query":"",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + '}]';
	this.RequestServer();
}

WorkMapObj.prototype.getKQList = function(){//  获取考勤历史列表
	this.action = "getKQList";
	this.rest_data = '[{"session":"'+ this.CurrentUserId +'",'+
		'"module_name":"'+ this.name +'",'+
		'"action":"'+this.action+'",'+
		'"query":"",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + '}]';
	this.RequestServer();
}

WorkMapObj.prototype.getQJList = function(){//  获取请假历史列表
	this.action = "getQJList";
	this.rest_data = '[{"session":"'+ this.CurrentUserId +'",'+
		'"module_name":"'+ this.name +'",'+
		'"action":"'+this.action+'",'+
		'"query":"",' +
        '"offset":' + this.offset + ',' +
        '"max_results":' + RowsPerPageInListViews + '}]';
	this.RequestServer();
}

WorkMapObj.prototype.locationShooting = function(){  // 实景拍照
	this.action = 'locationShooting';
	var pic = oldsrc;
	if (pic == '') {
		uexWindow.toast('0', '5', "照片不能为空,先拍个照吧", '1500');
		return false;
	}
	var text = $$('text').value;
	if (text == '') {
		uexWindow.toast('0', '5', "描述不能为空,随便描述一下吧", '1500');
		return false;
	}
	var address = $$('new_address').innerHTML;
	if(address == ''){
		uexWindow.toast('0', '5', "位置没有确定,先定位一下吧", '1500');
		return false;
	}
	var lng = $$('new_lng').value;
	var lat = $$('new_lat').value;
	var uploaddel = '';
	for (var m = 0; m < attachdel.length; m++) {
		uploaddel += '[img]'+attachdel[m];
	}
	var accountid = $$('accountid').value;
	text = encodeURIComponent(text);
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
        '"pic":"'+pic+'",' +
		'"text":"'+text+'",' +
		'"lng":"'+lng+'",' +
		'"lat":"'+lat+'",' +
		'"address":"'+address+'",' +
		'"accountid":"'+accountid+'",' +
		'"uploaddel":"'+uploaddel+'"}]';
	this.RequestServer();
}

WorkMapObj.prototype.markVisit=function(){  //拜访客户
	this.action = 'markVisit';
	var lng = $$('new_lng').value;
	var lat = $$('new_lat').value;
	var address = $$('new_address').innerHTML;
	if(address=="" && !address){
		//uexWindow.toast('0', '5', "位置没有确定,先定位一下吧", '1500');
		myalert("请先获取您的位置！");	
		return false;
	}
	var currentAccountid = $$('accountid').value;//ligangze
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"lng":"'+lng+'",'+
		'"lat":"'+lat+'",'+
		'"address":"'+address+'",'+
		'"text":"'+tt+'",'+
		'"accountid":"'+currentAccountid+'"}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.sendQJ=function(){  //发送请假申请
	this.action = 'sendQJ';
	if (receiverid == '') {
		uexWindow.toast('0', '5', "接收者不能为空", '1500');
		return false;
	}
	var text = $$("text").value;
	if (text == '') {
		uexWindow.toast('0', '5', "原因不能为空", '1500');
		return false;
	}
	var sendmsg = 0;
	if ($$('sendmsg_check').checked) {
		sendmsg = 1;
	}
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
		'"module_name":"'+this.name+'",'+
		'"action":"'+this.action+'",'+
		'"receiverid":"'+receiverid+'",'+
		'"sendmsg":"'+sendmsg+'",'+
		'"text":"'+text+'"}]';
	this.RequestServer();
}; 

WorkMapObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(this.action){
		case 'setAttendance':
			myalert('签到成功');
			break;
		case 'markAccount':
			uexWindow.toast('0', '5', '标记成功!!', '2000');
			$$('lbs_lat').value = $$('new_lat').value;
			$$('lbs_lng').value = $$('new_lng').value;
			setHtml('lbs_address',$$('new_address').innerHTML);
			break;
		case 'getAccountMark':
			this.ShowAccountMark(data);
			break;
		case 'getKQD':
			kqds = data;
			for (var i = 0; i < kqds.length; i++) {
				map_overlay_common(kqds[i].lng,kqds[i].lat,kqds[i].kqdname,kqds[i].address,true);
				paintCircleByPoint(kqds[i].lng,kqds[i].lat,kqds[i].range);
			}
			lbs_to_location();
			break;
		case 'getAccountAddressInfo':
			this.ShowAccountAddressInfo(data);
			break;
		case 'markUserKQ':
			this.ReturnSuccess(data);
			openwin('KQListPage','');
			break;
		case 'markVisit':
			this.ReturnSuccess(data);
			openwin('MarkVisitListPage','');
			break;
		case 'getMarkVisitList':
			this.ShowMarkVisitList(data);
			break;
		case 'locationShooting':
			this.ReturnSuccess(data);
			openwin('LocationShootListPage','');
			closeWin();
			break;
		case 'getLocationShootingList':
			this.ShowLocationShootingList(data);
			break;
		case 'getKQList':
			this.ShowKQList(data);
			break;
		case 'sendQJ':
			if(data.result=='SUCCESS'){
				uexWindow.toast("0","5","提交成功","2000");
//				if ($$('sendmsg_check').checked) {
//					uexSMS.send('13621989792', data.msg);
//				}
			}
			openwin('QJListPage','');
			closeWin();
			break;
		case 'getQJList':
			this.ShowQJList(data);
			break;
	}
};  

WorkMapObj.prototype.ShowLocationShootingList = function(data){
	var forumObj = '';
	var lists = data.entry_list;
	for(var i=0;i<lists.length;i++){
		var lbsInfo = [
			{'lng': lists[i].lng,
			 'lat': lists[i].lat,
			 'address': lists[i].address,
			 'type':'point',
			 'label':'我的位置'}];
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		forumObj+='<input id="lbsInfo_' + lists[i].shootid + '" value=\'' + JSON.stringify(lbsInfo) + '\' class="uhide b-gra">';
		forumObj+='<div class="ubb ub b-gra c-m2 t-bla umh4 lis3 '+whitebg+'">';
		forumObj+='<div class="ub-f1 ub ub-ver lis3">';	
			forumObj+='<div class="ulev0 ut-s umar-b ub "><div class="ub ub-f1"><div class="ub-f1">'+lists[i].text+'</div><div class="umar-r ulev-1"><a style="color: #0066CC;" onclick="openLookLbs(\''+lists[i].shootid+'\')">定位</a></div></div></div>';
			forumObj+='<div class="ub ub-ac t-gra ulev-2 uinn7">';
				if (lists[i].accountname != '') {
					forumObj += '<div class="ub-f1"><i class="icon-home"></i>&nbsp;<a style="color: #0000FF;" onclick="openDetailTab(\'Accounts\',\''+lists[i].accountid+'\',\'\',\'../\');"">' + lists[i].accountname + '</a></div>';
				}else{
					forumObj += '<div class="ub-f1"></div>';
				}
				forumObj+='<div class="umar-r">'+lists[i].smownerid+'</div>';
			forumObj+='</div>';
			forumObj+='<div class="ub-f1 uinn"><img src="'+lists[i].pic+'" onerror="javascript:this.src=\'../../css/images/default.png\',this.onerror=null" onclick="viewImg(this);" style="min-width:70%;height:6em"/></div>';
			forumObj+='<div class="ub ub-ac t-gra ulev-2 uinn7">';
				forumObj+='<div class="ub-f1"><i class="icon-map-marker"></i>&nbsp;'+lists[i].address+'</div>';
				forumObj+='<div class="umar-r">'+lists[i].createdtime+'</div>';
			forumObj+='</div>';
		forumObj+='</div>';
		forumObj+='</div>';
	}
	var cContent = $$('list1');
	if(this.offset == 1){
		cContent.innerHTML='<div></div>';
		if(lists.length == 0){
			forumObj += showNotRecordDiv();  
		}
	}
	var node = document.createElement("div");
	node.innerHTML = forumObj;
	cContent.insertBefore(node,cContent.lastElementChild);
	if(this.offset<data.lastpg){
		$$('more').className='c-gra';
	}else{
		$$('more').className='uhide';
	}
	this.offset++;
}

WorkMapObj.prototype.ShowMarkVisitList = function(data){
	var forumObj = '';
	var lists = data.entry_list;
	for(var i=0;i<lists.length;i++){
		var lbsInfo = [
			{'lng': lists[i].lng,
			 'lat': lists[i].lat,
			 'address': lists[i].address,
			 'type':'point',
			 'label':'我的位置'},
			{'lng': lists[i].acc_lng,
			 'lat': lists[i].acc_lat,
			 'address': lists[i].acc_address,
			 'type':'point',
			 'label':lists[i].accountname}];
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		forumObj+='<input id="lbsInfo_' + lists[i].ulbsid + '" value=\'' + JSON.stringify(lbsInfo) + '\' class="uhide b-gra">';
		forumObj+='<div class="ubb ub b-gra c-m2 t-bla umh4 lis3 '+whitebg+'">';
		forumObj+='<div class="ub-f1 ub ub-ver lis3">';	
			forumObj+='<div class="ulev0 ut-s umar-b ub "><div class="ub ub-f1"><div class="ub-f1">'+lists[i].title+'</div><div class="umar-r ulev-1"><a style="color: #0066CC;" onclick="openLookLbs(\''+lists[i].ulbsid+'\')">定位</a></div></div></div>';
			forumObj+='<div class="ub ub-ac t-gra ulev-2 uinn7">';
				if (lists[i].accountname != '') {
					forumObj += '<div class="ub-f1"><i class="icon-home"></i>&nbsp;<a style="color: #0000FF;" onclick="openDetailTab(\'Accounts\',\''+lists[i].accountid+'\',\'\',\'../\');">' + lists[i].accountname + '</a></div>';
				}else{
					forumObj += '<div class="ub-f1"></div>';
				}
				forumObj+='<div class="umar-r">'+lists[i].smownerid+'</div>';
			forumObj+='</div>';
			forumObj+='<div class="ub ub-ac t-gra ulev-2 uinn7">';
				forumObj+='<div class="ub-f1"><i class="icon-map-marker"></i>&nbsp;'+lists[i].address+'</div>';
				forumObj+='<div class="umar-r">'+lists[i].lbstime+'</div>';
			forumObj+='</div>';
		forumObj+='</div>';
		forumObj+='</div>';
	}
	var cContent = $$('list1');
	if(this.offset == 1){
		cContent.innerHTML='<div></div>';
		if(lists.length == 0){
			forumObj += showNotRecordDiv();  
		}
	}
	var node = document.createElement("div");
	node.innerHTML = forumObj;
	cContent.insertBefore(node,cContent.lastElementChild);
	if(this.offset<data.lastpg){
		$$('more').className='c-gra';
	}else{
		$$('more').className='uhide';
	}
	this.offset++;
}

WorkMapObj.prototype.ShowKQList = function(data){
	var forumObj = '';
	var lists = data.entry_list;
	for(var i=0;i<lists.length;i++){
		var lbsInfo = [
			{'lng': lists[i].lng,
			 'lat': lists[i].lat,
			 'address': lists[i].address,
			 'type':'point',
			 'label':'我的位置'},
			{'lng': lists[i].kqd_lng,
			 'lat': lists[i].kqd_lat,
			 'address': lists[i].kqd_address,
			 'type':'circle',
			 'range':lists[i].range,
			 'label':lists[i].kqdname}];
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		forumObj+='<input id="lbsInfo_' + lists[i].ulbsid + '" value=\'' + JSON.stringify(lbsInfo) + '\' class="uhide b-gra">';
		forumObj+='<div class="ubb ub b-gra c-m2 t-bla umh4 lis3 '+whitebg+'">';
		forumObj+='<div class="ub-f1 ub ub-ver lis3">';	
			forumObj+='<div class="ulev0 ut-s umar-b ub "><div class="ub ub-f1"><div class="ub-f1">'+lists[i].lbstime+'</div><div class="umar-r ulev-1"><a style="color: #0066CC;" onclick="openLookLbs(\''+lists[i].ulbsid+'\')">定位</a></div></div></div>';
			forumObj+='<div class="ub ub-ac t-gra ulev-2 uinn7">';
				forumObj += '<div class="ub-f1"><i class="icon-map-marker"></i>&nbsp;' + lists[i].kqdname + '</div>';
				forumObj+='<div class="umar-r">'+lists[i].smownerid+'</div>';
			forumObj+='</div>';
		forumObj+='</div>';
		forumObj+='</div>';
	}
	var cContent = $$('list1');
	if(this.offset == 1){
		cContent.innerHTML='<div></div>';
		if(lists.length == 0){
			forumObj += showNotRecordDiv();  
		}
	}
	var node = document.createElement("div");
	node.innerHTML = forumObj;
	cContent.insertBefore(node,cContent.lastElementChild);
	if(this.offset<data.lastpg){
		$$('more').className='c-gra';
	}else{
		$$('more').className='uhide';
	}
	this.offset++;
}

WorkMapObj.prototype.ShowQJList = function(data){
	var forumObj = '';
	var lists = data.entry_list;
	for(var i=0;i<lists.length;i++){
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
		forumObj+='<div class="ubb ub b-gra c-m2 t-bla umh4 lis3 '+whitebg+'">';
		forumObj+='<div class="ub-f1 ub ub-ver lis3">';	
			forumObj+='<div class="ulev0 ut-s umar-b ub "><div class="ub ub-f1">';
				forumObj += '<div class="ub-f1">'+lists[i].time+'</div>';
				forumObj+='<div class="umar-r"><i class="icon-share"></i>&nbsp;'+lists[i].receiverid+'</div>';
			forumObj+='</div></div>';	
			forumObj+='<div class="ub ub-ac t-gra ulev-2 uinn7">';
				forumObj += '<div class="ub-f1"><i class="icon-hand-right"></i>&nbsp;' + lists[i].reason + '</div>';
				forumObj+='<div class="umar-r"><i class="icon-user"></i>&nbsp;'+lists[i].smownerid+'</div>';
			forumObj+='</div>';
		forumObj+='</div>';
		forumObj+='</div>';
	}
	var cContent = $$('list1');
	if(this.offset == 1){
		cContent.innerHTML='<div></div>';
		if(lists.length == 0){
			forumObj += showNotRecordDiv();  
		}
	}
	var node = document.createElement("div");
	node.innerHTML = forumObj;
	cContent.insertBefore(node,cContent.lastElementChild);
	if(this.offset<data.lastpg){
		$$('more').className='c-gra';
	}else{
		$$('more').className='uhide';
	}
	this.offset++;
}

WorkMapObj.prototype.ShowAccountMark = function(data){ //显示 范围内标记的客户(实例方法)
	var marks = data;
	var title = '';
	var content = '';
	for (var i = 0; i < marks.length; i++) {
		title = '<a style="color:#0000FF" onclick="openDetailTab(\'Accounts\',\''+marks[i].accountid+'\',\'\',\'../\');">'+marks[i].accountname+'</a>';
		content = marks[i].address;
		map_overlay_common(marks[i].lng,marks[i].lat,title,content,true);
	}
}

WorkMapObj.prototype.ShowAccountAddressInfo = function(data){ //显示 客户地址信息(实例方法)
//	if (data.lbs_address != '') {
//		$$('tip_btn').innerHTML = '<i class="icon-pushpin"></i>&nbsp;重新标记';
//	}
//	else {
//		$$('tip_btn').innerHTML = '<i class="icon-pushpin"></i>&nbsp;标记';
//	}
	//$$('tip_btn').style.display = 'block';
	setHtml('address', data.bill_street);
	setHtml('bill_city', data.bill_city);
	//if (data.lbs_address != '') {
		//$$('lbs_lat').value = data.lbs_lat;
		//$$('lbs_lng').value = data.lbs_lng;
		//setHtml('lbs_address', data.lbs_address);
		//map_overlay_common(data.lbs_lng,data.lbs_lat,$$('accountname').innerHTML,data.lbs_address,true);
		//var point = new BMap.Point(data.lbs_lng,data.lbs_lat);// 创建点坐标
		//map.panTo(point);
		//$$('visit_btn').style.display = 'block';
	//}else{
		//$$('lbs_lat').value = '';
		//$$('lbs_lng').value = '';
		//setHtml('lbs_address', '');
		//$$('visit_btn').style.display = 'none';
	//}
}

WorkMapObj.prototype.ShowKQD = function (){  //计算出最近的考勤点,并显示其信息
	var msg = '';
	var mylng = $$('new_lng').value;
	var mylat = $$('new_lat').value;
	if (kqds.length > 0) {
		var distance = getFlatternDistance(mylat,mylng,kqds[0].lat,kqds[0].lng); //计算距离
		var minKqd = kqds[0]; //最小值赋值
		var minDistance = distance;   
		for (var i = 1; i < kqds.length; i++) {
			distance = getFlatternDistance(mylat,mylng,kqds[i].lat,kqds[i].lng);  //计算距离
			if(distance < minDistance){   //给最小值重新赋值
				minKqd = kqds[i];
				minDistance = distance;
			}
		}
		currentKqd_id = minKqd.kqdid;
		if(minDistance<minKqd.range){
			kqFlag = true;
			$$('tip_btn').style.display = 'block';
			msg = '已在考勤点['+minKqd.kqdname+']有效范围内,距离是'+(minDistance)+'米,可以打考勤啦!!!';
		}else{
			kqFlag = false;
			$$('tip_btn').style.display = 'none';
			msg = '距离最近的考勤点['+minKqd.kqdname+']还差'+(minDistance-minKqd.range)+'米就可以打考勤啦!!!';
		}
	}else{    //如果没有设置考勤点
		kqFlag = false;
		$$('tip_btn').style.display = 'none';
		msg = '您还没有设置考勤点';
	}
	setHtml('kqdInfo',msg);
}

WorkMapObj.prototype.ReturnSuccess = function(data){ //
	if(data == 'SUCCESS'){
		uexWindow.toast("0","5","保存成功","2000");
	}
}

function openLookLbs(lid){
	setstorage("lbsInfo",$$('lbsInfo_'+lid).value);
	openwin('LookLBS','');
}
