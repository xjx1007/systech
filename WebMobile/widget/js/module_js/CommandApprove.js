/**
 *  指令-审批
 */
function CMObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      CMObj.prototype[attr] = Module.prototype[attr];
	};
	this.method = 'handleRequest';
	this.itemid = '';
	this.offset = 0;
};
var item_type_status = [
			{
				'type': '任务',
				'status':['执行中','已完成','已取消']
			},
			{
				'type': '审批',
				'status':['待审批','同意','已取消','不同意']
			}
		];
CMObj.prototype.setCommandDetails = function(){ //获取文章详细(实例方法)
	if(this.itemid == '')return; 
	this.offset=1;
	this.action = 'get_command_details';
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",'+
				'"module_name":"'+this.name+'",'+
				'"action":"'+this.action+'",'+
				'"itemid":"'+this.itemid+'",'+
       			'"max_results":' + RowsPerPageInListViews + '}]';
	this.RequestServer();
}

CMObj.prototype.GetListDataFromServer=function(){  //获取列表(实例方法)
	var searchtext = getstorage("searchtext");  //搜索条件
	this.CurrentUserId = getstorage("SugarSessionId");  //当前用户ID
	if(!searchtext) searchtext = '';
	var viewsel = getRadioCheckedValue('list_item_type');   //
	this.action = "get_entry_list";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
        '"query":"'+searchtext+'",' +
        '"offset":' + page_cm_offset + ',' +
        '"max_results":' + RowsPerPageInListViews + ',' +
        '"item_type":"'+viewsel+'"}]';
	var url = this.AjaxUrl+'/rest.php?callback=?&method='+this.method+'&rest_data='+encodeURIComponent(this.rest_data);
	//this.ShowLoadTips(); 
	$('#refreshCmIcon').show();
	$('#morecm').removeClass('morecm_btn');
	$('#morecm .myfont').html('加载中...');
	var currobj = this;
	$.getJSON(url,this.ShowCmList);
}; 

CMObj.prototype.SendComment = function(handerFlag){ // 发送 处理、回复(实例方法)
	if(this.itemid == '')return; 
	$$('description').value = removeHTMLTag($$('description').value);
	var description = $$('description').value;
	if ('' == description) {
		uexWindow.toast('0', '5', "请输入内容", 2000);
		return false;
	}
	var operate_idx = -1;
	if (handerFlag) {
		operate_idx = curr_status;	
	}
	this.action = "sendComment";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
		'"itemid":"'+this.itemid+'",'+
		'"operate_idx":"'+operate_idx+'",' +
        '"description":"'+encodeURIComponent(description)+'"}]';
	this.RequestServer();
}

CMObj.prototype.DeleteItem = function(handerFlag){ // 发送 处理、回复(实例方法)
	if(this.itemid == '')return; 
	this.action = "deleteItem";
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
		'"itemid":"'+this.itemid+'"}]';
	this.RequestServer();
}

CMObj.prototype.SendCommand = function(){ // 发送 指令、审批(实例方法)
	$$('description').value = removeHTMLTag($$('description').value);
	var description = $$('description').value;
	if ('' == description) {
		uexWindow.toast('0', '5', "请输入内容", 2000);
		return false;
	}
	var item_type = $$('item_type').value;
	if(reciver_user_ids.length == 0){
		uexWindow.toast('0', '5', "请选择"+$$('reciver_user_title').innerHTML, 2000);
		return false;
	}
	var work_end_date = $$('date').innerHTML;
	var work_end_time = $$('time').innerHTML;
	var imglist = '';
	for(var k=0;k<attachnew.length;k++){
		imglist += '[img]'+attachnew[k].src;
	}
	var imgdellist = '';
	for (var m = 0; m < attachdel.length; m++) {
		imgdellist += '[img]'+attachdel[m];
	}
	var reciver_user = reciver_user_ids.join(',');
	var cc_user = cc_user_ids.join(',');
	this.action = "sendNewCommand";
	this.tip = 0;
	var lng='';
	var lat='';
	var address = '';
	if($$('adr_div').className != 'uhide' && $$('new_lng').value != ''){
		lng = $$('new_lng').value;
		lat = $$('new_lat').value;
		address = $$('new_address').innerHTML;
	}
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
		'"action":"'+this.action+'",'+
		'"item_type":"'+item_type+'",' +
        '"reciver_user":"'+reciver_user+'",' +
		'"cc_user":"'+cc_user+'",' +
		'"work_end_date":"'+work_end_date+'",' +
		'"work_end_time":"'+work_end_time+'",' +
		'"imglist":"'+imglist+'",' +
		'"imgdellist":"'+imgdellist+'",' +
		'"lng":"'+lng+'",'+
		'"lat":"'+lat+'",'+
		'"address":"'+address+'",'+
        '"description":"'+encodeURIComponent(description)+'"}]';
	this.RequestServer();
}; 

CMObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(this.action){
		case 'sendNewCommand':
			if (data.result === "SUCCESS") {
				uexWindow.toast(0, 5, "发表成功", 2000);
				openCommandDetail(data.record,'');
				uexWindow.evaluateScript('root', '0', 'refrashCm()');
				uexWindow.evaluateScript('fb-command','0','closeWin()');
			}else if(data.result === "FAIL"){
				myalert('发表失败');
			}
			break;
		case 'get_command_details':
			this.showCommand(data);
			break;
		case 'sendComment':
			if (data.result == 'SUCCESS'){
				this.showCommand(data.newitem);
			}
			break;
		case 'deleteItem':
			if (data.result == 'SUCCESS'){
				uexWindow.toast(0, 5, "删除成功", 2000);
				uexWindow.evaluateScript('root', '0', 'refrashCm()');
				uexWindow.evaluateScript('CommandDetailsPage','0','closeWin()');
			}
			break;
	}
}; 

CMObj.prototype.showCommand=function(data){
	var theBill = data.item;
	setHtml('author',theBill.smownername);
	if (theBill.smownerpho != '') {
		$$('avatar_pic').src = theBill.smownerpho;
	} 
	var pitem = '';
	if(theBill.item_type == 0){//如果是指令
		if(theBill.item_status == 0){//未执行
			pitem +='该任务由<span class="t-blu4">'+theBill.reciver_user+'</span>执行，应于'+theBill.work_end_date+' '+theBill.work_end_time+'  前完成';
			var d1= new Date();//取今天的日期  
			var arrDueDate = theBill.work_end_date.split("-");   
			var arrEndTime = theBill.work_end_time.split(":");   
			var d2 = new Date(arrDueDate[0],arrDueDate[1]-1,arrDueDate[2],arrEndTime[0],arrEndTime[1]);
			if(d1.getTime()>d2.getTime()){   //超时了
				pitem +='，<span class="t-red">该任务已超时。</span>';
			}else{
				pitem +='，执行中。';
			}
		}else if(theBill.item_status == 1){//已完成
			pitem +='该任务由<span class="t-blu4">'+theBill.reciver_user+'</span>执行，已于'+theBill.modifiedtime+'  <span class="t-green">完成</span>';
		}else if(theBill.item_status == 2){//已取消
			pitem +='该任务由<span class="t-blu4">'+theBill.reciver_user+'</span>执行，应于'+theBill.work_end_date+' '+theBill.work_end_time+'  前完成，该任务已取消。';
		}
	}else if(theBill.item_type == 1){//如果是审批
		if(theBill.item_status == 0){//待审批
			pitem +='已提交，待<span class="t-blu4">'+theBill.reciver_user+'</span>审批';
		}else if(theBill.item_status == 1){//已同意
			pitem+='由<span class="t-blu4">'+theBill.reciver_user+'</span>审批，已于'+theBill.modifiedtime+'  <span class="t-green">同意</span>';
		}else if(theBill.item_status == 3){//不同意
			pitem+='由<span class="t-blu4">'+theBill.reciver_user+'</span>审批，已于'+theBill.modifiedtime+'  <span class="t-red">不同意</span>';
		}
	}
	
	setHtml('item_type',item_type_status[theBill.item_type].type);
	setHtml('pitem',pitem);
	setHtml('item_status',item_type_status[theBill.item_type].status[theBill.item_status]);
	setHtml('tztext',theBill.content);
	//显示图片
	var imglists = theBill.imglist.split('[img]');
	var img_html = '';
	if(imglists.length>1 && imglists[imglists.length-1] != ''){//是否有图片
		img_html = '<div class="ub ub-ver umar-t uinn">'
		+'<div style="width:5.5em;position:relative;" onclick="showImg(\''+theBill.imglist+'\')" id="item_imgs">'
			+'<img src="'+cmobj.AjaxUrl+'/'+imglists[1]+'" style="width:100%;min-height:5.5em;"/>'
			+'<div style="position:absolute;bottom:0;width:100%;background-color:rgba(0,0,0,0.7);" class="tx-c t-wh">'+(imglists.length-1)+'张</div>'
		+'</div></div>';
	}
	if (img_html != '') {
		setHtml('imglist_div', img_html);
	}
	//显示抄送范围
	var cc_user_num = theBill.cc_users.length;
	if(cc_user_num>1){
		var cc_user_names=[]; 
		for(var k=0;k<cc_user_num;k++){
			cc_user_names.push(theBill.cc_users[k].name);
		}
		var cc_user_html = '<div class="ub ub-ver umar-t uinn t-gra ulev-1"><i class="icon ion-android-earth assertive tx_bold ulev0"></i>&nbsp;抄送'+cc_user_num+'个同事('+cc_user_names.join(',')+')</div>';
		setHtml('cc_user_div', cc_user_html);
	}
	if(theBill.address != ''){
		var address = '<div class="ub ub-ver umar-t uinn t-gra" ulev-1><i class="icon ion-ios7-location-outline positive ulev0 tx_bold"></i>&nbsp;'+theBill.address+'</div>';
		setHtml('address_div', address);
	}
	setHtml('createtime_div', '发表于&nbsp;'+theBill.createdtime);
	var keycomments_html = '';
	var keycomments = theBill.keycomments;
	if(keycomments.length>0){
		keycomments_html+='<div class="uc-a1 uba b-gra " style="background-color:rgba(28,184,65,0.5);"><div class="uinn ulev-1">以下为关键节点的回复:</div>';
		for (var i = 0; i < keycomments.length; i++) {
			
			if (keycomments[i].replypho == '') {
				keycomments[i].replypho = "../../css/images/avatar_default1299eb.png";
			}
			keycomments_html += '<div class="ub t-bla umh4 lis3" style="border-top: 1px dashed #fff;">';
			keycomments_html += '<div class="avatar">';
			keycomments_html += '<img src=\"' + keycomments[i].replypho + '\"/>';
			keycomments_html += '</div>';
			keycomments_html += '<div class="ub-f1 ub ub-ver lis3">';
			keycomments_html += '<div class="ub ub-hor umar-b">';
			keycomments_html += '<div class="ub-f1 ub-hor ufl ulev-1 tx_bold">';
				keycomments_html += '<div class="umar-l">';
				keycomments_html += '<span>' + keycomments[i].smownername + '</span>';
				keycomments_html += '</div>';
			keycomments_html += '</div>';
					keycomments_html +='<div class="ub ub-hor ufr ulev-1 tx_bold">'; 
						keycomments_html +='<div class="umar-r">';
							keycomments_html +='<span class="t-blu4" >'+item_type_status[theBill.item_type].status[keycomments[i].item_status]+'</span>';
						keycomments_html +='</div>';
					keycomments_html +='</div>'; 	
			keycomments_html += '</div>';
			keycomments_html += '<div class="ub ub-ac t-gra ulev-2 umar-t">';
			keycomments_html += '<div class="ub-f1 ub ub-hor ufl">';
			keycomments_html += '发表于<div class="umar-l">' + keycomments[i].modifiedtime + '</div>';
			keycomments_html += '</div>';
			keycomments_html += '</div>';
			keycomments_html += '</div>';
			keycomments_html += '</div>';
			
			keycomments_html += '<div class="ub ub-ver">';
			keycomments_html += '<div class="umar-a linh2 ulev0" >';
			keycomments_html += '<div class="arrow_box uc-a1 uinn" >' + keycomments[i].commenttext + '</div>';
			keycomments_html += '</div>';
			keycomments_html += '</div>';
		}
		keycomments_html+='</div>';
	}
	setHtml('keycomlist_div', keycomments_html);
	if(theBill.opt_item == 0){
		curr_status = -1;
		$$('handlediv').style.display = "none";
	}else if(theBill.opt_item == 1){
		curr_status = 0;
		$$('buttondiv2').style.display = "none";
		$$('buttondiv1').style.display = "block";
		$$('handlediv').style.display = "block";
	}else if(theBill.opt_item == 2){
		curr_status = 3;
		$$('buttondiv1').style.display = "none";
		$$('buttondiv2').style.display = "block";
		$$('handlediv').style.display = "block";
	}
	
	uexWindow.evaluateScript('CommandDetailsPage', '0', 'showDeleteBtn('+theBill.del_item+')');
	this.showComments(theBill.comments);
}

CMObj.prototype.showComments = function(lists){  //显示评论
	var forumObj = '';
	
	for(var i=0;i<lists.length;i++){
		if (lists[i].replypho == '') {
			lists[i].replypho = "../../css/images/avatar_default1299eb.png";
		}
		forumObj +='<div class="ub t-bla umh4 lis3">';
		forumObj +='<div class="avatar">';
			forumObj +='<img src=\"'+lists[i].replypho+'\"/>';
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
					forumObj +='<span class="t-gra" >'+(i+1)+'楼</span>';
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
	setHtml('comlist',forumObj);
}

//打开详细页面
function openCommandDetail(itemid,res){
	setstorage('CurrentCommandId', itemid);
	openwin('CommandDetailsPage',res);
}

CMObj.prototype.CommentCommand = function(){ //  评论文章(实例方法)
	var message = removeHTMLTag(tt)
	if (message == '') {
		uexWindow.toast('0', '5', "内容不能为空", '1500');
		return false;
	}
	if(toSb != ''){
		message = toSb +' '+message;
	}
	this.itemid = getstorage('CurrentCommandId');  //id
	this.method = 'commentCommand';
	this.tip = 0;
	this.rest_data = '[{"session":"' + this.CurrentUserId + '",' +
        '"module_name":"'+this.name+'",' +
        '"itemid":"'+this.itemid+'",' +
        '"message":"'+message+'"}]';
	this.RequestServer();
}; 


CMObj.prototype.ShowCmList=function(data){
//function ShowCmList(data){ //显示列表(实例方法)
	//uexWindow.closeToast();
	$('#refreshCmIcon').hide();
	var forumObj = '';
	var listObj = data;
	
	if ((listObj !== undefined) && (listObj.entry_list !== undefined)) {
		var i = 0;
		for (i = 0; i < listObj.entry_list.length; i++) {
			if (listObj.entry_list[i] !== undefined) {
				var theBill = listObj.entry_list[i];
				if (theBill.smownerpho == '') {
					theBill.smownerpho = "css/images/avatar_default1299eb.png";
				}
				var pitem = '';
				if(theBill.item_type == 0){//如果是指令
					if(theBill.item_status == 0){//未执行
						pitem +='该任务由<span class="t-blu4">'+theBill.reciver_user+'</span>执行，应于'+theBill.work_end_date+' '+theBill.work_end_time+'  前完成';
						var d1= new Date();//取今天的日期  
						var arrDueDate = theBill.work_end_date.split("-");   
   						var arrEndTime = theBill.work_end_time.split(":");   
						var d2 = new Date(arrDueDate[0],arrDueDate[1]-1,arrDueDate[2],arrEndTime[0],arrEndTime[1]);
						if(d1.getTime()>d2.getTime()){   //超时了
							pitem +='，<span class="t-red">该任务已超时。</span>';
						}else{
							pitem +='，执行中。';
						}
					}else if(theBill.item_status == 1){//已完成
						pitem +='该任务由<span class="t-blu4">'+theBill.reciver_user+'</span>执行，已于'+theBill.modifiedtime+'  <span class="t-green">完成</span>';
					}else if(theBill.item_status == 2){//已取消
						pitem +='该任务由<span class="t-blu4">'+theBill.reciver_user+'</span>执行，应于'+theBill.work_end_date+' '+theBill.work_end_time+'  前完成，该任务已取消。';
					}
				}else if(theBill.item_type == 1){//如果是审批
					if(theBill.item_status == 0){//待审批
						pitem +='已提交，待<span class="t-blu4">'+theBill.reciver_user+'</span>审批';
					}else if(theBill.item_status == 1){//已同意
						pitem+='由<span class="t-blu4">'+theBill.reciver_user+'</span>审批，已于'+theBill.modifiedtime+'  <span class="t-green">同意</span>';
					}else if(theBill.item_status == 3){//不同意
						pitem+='由<span class="t-blu4">'+theBill.reciver_user+'</span>审批，已于'+theBill.modifiedtime+'  <span class="t-red">不同意</span>';
					}
				}
				var imglists = theBill.imglist.split('[img]');
				var img_html = '';
				if(imglists.length>1 && imglists[imglists.length-1] != ''){//是否有图片
					img_html = '<div class="uinn3 ub-f1 ub">'
					+'<input type="hidden" class="item_imglist" value='+theBill.imglist+'>'
					+'<div style="width:5.5em;position:relative;">'
						+'<img src="'+cmobj.AjaxUrl+'/'+imglists[1]+'" class="item_imgs" style="width:100%;min-height:5.5em;-webkit-border-radius: 0.2em;border-radius:0.2em;"/>'
						+'<div style="position:absolute;bottom:0;width:100%;background-color:rgba(0,0,0,0.7);-webkit-border-radius: 0.2em;border-radius:0.2em;" class="tx-c t-wh">'+(imglists.length-1)+'张</div>'
					+'</div></div>';
				}
				//显示抄送范围
				var cc_user_html = '';
				var cc_user_num = theBill.cc_users.length;
				if(cc_user_num>1){
					var cc_user_names=[]; 
					for(var k=0;k<cc_user_num;k++){
						cc_user_names.push(theBill.cc_users[k].name);
					}
					cc_user_html = '<div class="uinn3 ub-f1 ub t-gra ulev-1"><i class="icon ion-android-earth assertive tx_bold"></i>&nbsp;抄送'+cc_user_num+'个同事('+cc_user_names.join(',')+')</div>';
				}
				var address = theBill.address==''?'':'<div class="uinn3 ub-f1 ub t-gra ulev-1"><i class="icon ion-ios7-location-outline positive tx_bold"></i>&nbsp;'+theBill.address+'</div>';
				var replynum = '';
				if(theBill.replynum>0){
					replynum = '('+theBill.replynum+')';
				}
				forumObj += '<input type="hidden" class="item_id" value='+theBill.id+'><div class="ub umar-t ub-f1 cmlist_item  b-gra uba uc-a1 c-wh">'
					 	   	+'<div class="ub ub-f1 ub-ver cmli">'
						 		+'<div class="ub ub-f1 uinn3">'
									+'<div class="avatar">'
										+'<img src="'+theBill.smownerpho+'"/>'
									+'</div>'
									+'<div class="ub  ub-f1 umar-l ub-ver" >'
										+'<div class="ub t-blu4">'
											+'<div>'+theBill.smownername+'</div>'
											+'<div class="ub-f1 tx-r ulev-1 t-gra1">'+item_type_status[theBill.item_type].type+'&nbsp;-&nbsp;'+item_type_status[theBill.item_type].status[theBill.item_status]+'</div>'
										+'</div>'
										+'<div class="ulev-1 t-gra1 umar-t">'+pitem+'</div>'
									+'</div>'
								+'</div>'
								+'<div class="ub ub-f1 uinn3" >'+theBill.content+'</div>'
								+img_html+cc_user_html+address
								+'<div class="ub ub-f1 ub-ac uinn t-gra1 ulev-1">'
									+'<div class="ub-f1 ub ub-hor ufl">' 
									+'发表于<div class="umar-l">'+theBill.createdtime+'</div>'
									+'</div>' 
									+'<div class="ub ub-hor ufr">'
										+'<div class="umar-r"><span class="t-blu4" >[回复'+replynum+']</span></div>'
									+'</div>'
								+'</div>'
//								+'<div class="ub ub-f1 ubt umar-t b-gra">'
//									+'<div class="ub-f1 uinn ulev-1 t-gra ubr b-gra tx-c"><i class="icon ion-ios7-undo-outline umar-r"></i>回复</div>'
//									+'<div class="ub-f1 uinn ulev-1 t-gra tx-c"><i class="icon ion-ios7-heart-outline umar-r"></i>赞</div>'
//								+'</div>'
							+'</div>'
						+'</div>';
			}
		}
		if(page_cm_offset == 1){
			$('.cmli').parent().remove();
		}
		$('#morecm').before(forumObj);
		page_cm_last = listObj.lastpg;
		if(page_cm_offset<page_cm_last){
			$('#morecm .myfont').html('加载更多...');
			$('#morecm').addClass('morecm_btn');
		}else{
			$('#morecm .myfont').html('已全部显示');
			$('#morecm').removeClass('morecm_btn');
		}
		page_cm_offset++;
	}
};