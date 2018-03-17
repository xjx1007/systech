/**
*日报/下级日报
*/
set_input_msg();
function DAObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      DAObj.prototype[attr] = Module.prototype[attr];
	};
	this.LowLvDailylogsList;
	this.CurrentLowLvUserId = 0;
	this.thePage = '';
};

DAObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_lowlv_entry_list':
			this.ShowLowLvList(data);
			break;
		case 'get_entry_list':
			if (this.thePage == 'Myself') {
				this.ShowList(data);
			}else {
				this.ShowLowLvDetail(data);
			}
			break;
		case 'set_entry_save':
			this.SaveReturn(data);
			break;
	}
};  

DAObj.prototype.GetListFromServer=function(){  //获取下级列表(实例方法)
	this.thePage = 'Myself';
	var dailyLogsDate = getstorage("dailyLogsDate");
	this.method = 'get_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
                '"query":"'+dailyLogsDate+'",' +
                '"offset":"0",' +
                '"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}; 

DAObj.prototype.ShowList = function(data){ //显示下级列表(实例方法)
	var forumObj = '';
	var dailylogList = data;
	var setype ='';
	if ((dailylogList !== undefined) && (dailylogList.entry_list !== undefined)) {
		var entrylist = dailylogList.entry_list;
		if (entrylist.currentuser_list && entrylist.currentuser_list != '') {//已经有日报
			var currentuser_list = entrylist.currentuser_list;
			if (currentuser_list.status.value == "1") {//看日报
				statustext = RES_DAILYLOGS_LOOK;
				setype = "otherlook";
				lookhead = currentuser_list.smownername.value + " " + RES_DAILYLOGS_LABEL;
				forumObj += '<div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
					forumObj += '<div class="umar-b uinn1 ub-f1 tx-c">' + lookhead + '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-f1 c-wh ubl ubr b-gra">';
				forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
					forumObj += '<div class="detail_bt t-gra1">' + RES_DAILYLOGS_DESCRI + '</div>';
			 			forumObj += '<div class="ub-f1 detail_nr ub">'+currentuser_list.descri.value+'</div>';
					forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ubt_my c-wh uc-b1 b-gra  ub-f1">';
				forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
					forumObj += '<div class="detail_bt t-gra1">' + RES_DAILYLOGS_CURPLAN + '</div>';
			 			forumObj += '<div class="ub-f1 detail_nr ub">'+currentuser_list.curplan.value+'</div>';
					forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<br /><div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
					forumObj += '<div class="umar-b uinn1 ub-f1 tx-c">' + RES_DAILYLOGS_REPLIES + '</div>';
				forumObj += '</div>';
				if (entrylist.reply_value_list && entrylist.reply_value_list != undefined) {
					var replyList = entrylist.reply_value_list;
					var replylength = replyList.length;
					if (replylength > 0) {
						for (var i = 0; i < replylength; i++) {
							if(i != replylength-1){
								forumObj += '<div class="ub ub-f1  c-wh ubl ubr b-gra">';
							}else{
								forumObj += '<div class="ub ub-f1 c-wh ubt_my uc-b1 b-gra">';
							}
							forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
							forumObj += '<ul class="c-m2 ub b-gra t-bla ub-ac lis">';
							forumObj += '<ul class="ub-f1 ub ub-ver"><li class="detail_li_text umh4 ">' + replyList[i].description + '</li><li class="detail_ul_text">' + replyList[i].last_name + ' at ' + replyList[i].createdtime + '</li>';
							forumObj += '</ul></ul>';
							forumObj += '</div>';
							forumObj += '</div>';
						}
					}
				}
				forumObj += '<br /><div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
					forumObj += '<div class="umar-b uinn1 tx-c ub-f1">' + RES_DAILYLOGS_SAVEREPLIES + '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-f1 ubt_my uc-b1 b-gra">';
				forumObj += '<div class="ub-f1 c-wh b-gra uc-b1 uinput uinn4 ub uc-b1 ub-ver">';
				forumObj += '<textarea rows=3 '+input_msg +' id=\"replydescriBox\" placeholder=\"'+RES_DAILYLOGS_SAVEREPLIES+'\" name=\"replydescri\" type=\"text\"  class=\"DailylogsBox\"></textarea>';
				forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub"><div class="ub-f1 uinn">';
				forumObj += '<div ontouchstart="zy_touch(btn-act);" onmousedown="zy_touch(\'btn-act\', function(){daobj.savereplydescri_click(\''+currentuser_list.dailylogsid.value+'\');});" class="btn uinn5 c-blu3 uc-a1 t-wh"><i class="icon-ok"></i>&nbsp;'+RES_DAILYLOGS_SUBMIT+'</div>';
				forumObj += '</div></div>';
			}
			else {
				statustext = RES_DAILYLOGS_CREATE;
				setype = "submit";
				forumObj += '<div class="ub ub-f1 uinn-top ubt_my c-wh uc-t1 b-gra">';
					forumObj += '<div class="umar-b uinn1">' + RES_DAILYLOGS_VIEWTEXT1 + '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-fh uba uc-b1 b-gra">';
				forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
		 			forumObj += '<div class="detail_bt t-gra1">' + RES_DAILYLOGS_TODAYPLANS + '</div>';
				if (currentuser_list.yesterday.value == "") {
					currentuser_list.yesterday.value = "无";	
				}
					forumObj += '<div class="ub-f1 detail_nr ub">'+currentuser_list.yesterday.value+'</div>';
					forumObj += '</div>';
				forumObj += '</div>';
				
				forumObj += '<br /><div class="ub ub-fh uinn-top uba c-gra uc-t1 b-gra">';
					forumObj += '<div class="umar-b uinn1">' + RES_DAILYLOGS_DESCRI + '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-fh uba uc-b1 b-gra">';
				forumObj += '<div class="ub-f1 c-wh b-gra uinput uinn4 ub uc-b1 ub-ver">';
				forumObj += '<textarea id=\"descriptionBox\" rows=3 '+input_msg +' placeholder=\"'+RES_DAILYLOGS_DESCRI+'\" name=\"description\" type=\"text\"  class=\"DailylogsBox\">' + currentuser_list.descri.value + '</textarea>';
				forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<br /><div class="ub ub-fh uinn-top uba c-gra uc-t1 b-gra">';
					forumObj += '<div class="umar-b uinn1">' + RES_DAILYLOGS_CURPLAN + '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-fh uba uc-b1 b-gra">';
				forumObj += '<div class="ub-f1 c-wh b-gra uinput uinn4 ub uc-b1 ub-ver">';
				forumObj += '<textarea id=\"curplanBox\" rows=3 '+input_msg +' placeholder=\"'+RES_DAILYLOGS_CURPLAN+'\" name=\"curplan\" type=\"text\"  class=\"DailylogsBox\">' + currentuser_list.curplan.value + '</textarea>';
				forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub">';
				forumObj += '<div class="ub-f1 uinn"><div ontouchstart="zy_touch(btn-act);" onmousedown="zy_touch(\'btn-act\', function(){daobj.saveDailylogs_click(\'Submit\',\''+currentuser_list.dailylogsid.value+'\');});" class="btn uinn5 c-blu3 uc-a1 t-wh"><i class="icon-ok"></i>&nbsp;'+RES_DAILYLOGS_SUBMIT+'</div></div>';
				forumObj += '<div class="ub-f1 uinn"><div ontouchstart="zy_touch(btn-act);" onmousedown="zy_touch(\'btn-act\', function(){daobj.saveDailylogs_click(\'Temporary\',\''+currentuser_list.dailylogsid.value+'\');});" class="btn uinn5 c-org1 uc-a1 t-wh"><i class="icon-external-link"></i>&nbsp;'+RES_DAILYLOGS_TEMPORARY+'</div></div>';
				forumObj += '</div>';
			}
		}
		else {
			forumObj += '<div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
				forumObj += '<div class="umar-b uinn1 ub-f1 tx-c">' + RES_DAILYLOGS_WRITE + RES_DAILYLOGS_LABEL + '</div>';
			forumObj += '</div>';
			forumObj += '<div class="ub ub-f1 c-wh ubt_my uc-b1 b-gra">';
			forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
	 			forumObj += '<div class="detail_bt">' + RES_DAILYLOGS_TODAYPLANS + ':</div>';
			if (entrylist == "") {
				entrylist = "无";	
			}
				forumObj += '<div class="ub-f1 detail_nr ub">'+entrylist+'</div>';
				forumObj += '</div>';
			forumObj += '</div>';
			forumObj += '<br /><div class="ub ub-f1  uinn-top uba c-wh uc-t1 b-gra ub-ac">';
				forumObj += '<div class="umar-b uinn1 ub-f1 tx-c">' + RES_DAILYLOGS_DESCRI + '</div>';
			forumObj += '</div>';
			forumObj += '<div class="ub ub-f1 ubt_my uc-b1 b-gra">';
			forumObj += '<div class="ub-f1 c-wh b-gra uinput uinn4 ub uc-b1 ub-ver">';
			forumObj += '<textarea rows=3 '+input_msg +' id=\"descriptionBox\" name=\"description\" placeholder=\"'+RES_DAILYLOGS_DESCRI+'\" type=\"text\"  class=\"DailylogsBox\"></textarea>';
			forumObj += '</div>';
			forumObj += '</div>';
			
			forumObj += '<br /><div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
				forumObj += '<div class="umar-b uinn1 ub-f1 tx-c">' + RES_DAILYLOGS_CURPLAN + '</div>';
			forumObj += '</div>';
			forumObj += '<div class="ub ub-f1 ubt_my uc-b1 b-gra">';
			forumObj += '<div class="ub-f1 c-wh b-gra uinput uinn4 ub uc-b1 ub-ver">';
			forumObj += '<textarea rows=3 '+input_msg +' id=\"curplanBox\" name=\"curplan\" placeholder=\"'+RES_DAILYLOGS_CURPLAN+'\" type=\"text\"  class=\"DailylogsBox\"></textarea>';
			forumObj += '</div>';
			forumObj += '</div>';
			forumObj += '<div class="ub">';
			forumObj += '<div class="ub-f1 uinn"><div ontouchstart="zy_touch(btn-act);" onmousedown="zy_touch(\'btn-act\', function(){daobj.saveDailylogs_click(\'Submit\',\'0\');});" class="btn uinn5 c-blu3 uc-a1 t-wh"><i class="icon-ok"></i>&nbsp;'+RES_DAILYLOGS_SUBMIT+'</div></div>';
			forumObj += '<div class="ub-f1 uinn"><div ontouchstart="zy_touch(btn-act);" onmousedown="zy_touch(\'btn-act\', function(){daobj.saveDailylogs_click(\'Temporary\',\'0\');});" class="btn uinn5 c-org1 uc-a1 t-wh"><i class="icon-external-link"></i>&nbsp;'+RES_DAILYLOGS_TEMPORARY+'</div></div>';
			forumObj += '</div>';
		}
		setHtml("dailylogs_list", forumObj);
	}
}

DAObj.prototype.GetLowLvListFromServer=function(){  //获取下级列表(实例方法)
	var dailyLogsDate = getstorage("dailyLogsDate");
	this.method = 'get_lowlv_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
                '"query":"'+dailyLogsDate+'",' +
                '"offset":"0",' +
                '"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}; 

DAObj.prototype.ShowLowLvList = function(data){ //显示下级列表(实例方法)
	var forumObj = '';
	var dailylogList = data;
	if ((dailylogList !== undefined) && (dailylogList.entry_list !== undefined)) {
		var entrylist = dailylogList.entry_list;
		this.LowLvDailylogsList = entrylist;
		var intLowLv = 0;
		for (intLowLv = 0; intLowLv < entrylist.length; intLowLv++) {
			if (entrylist[intLowLv] !== undefined) {
				var lowlv = entrylist[intLowLv];
				var whitebg = "c-wh";
				if(intLowLv%2==0)
					whitebg = "";
				if (lowlv.dailylogsid == '') {
					forumObj += '<div ontouchstart="zy_touch(\'col-active\')" onmousedown="zy_touch(\'col-active\')" onclick="openLowLvDaliylogsDetail('+lowlv.userid+',\''+lowlv.name+'\',\'\');" class="col uc-n t-bla ub ubb  b-gra1 uinn58 ub-ac  ulev-0 umh4 '+whitebg+'">';
					forumObj += '<div class="ub-f1 ut-s"><h5>' + lowlv.name + '</h5></div>';
					//forumObj += '<div class="res_rat2 lis-sw-1 ub-img"></div>';
					forumObj += '<div class="res8 lis-sw ub-img"></div></div>';
				}else{
					forumObj += '<div ontouchstart="zy_touch(\'col-active\')" onmousedown="zy_touch(\'col-active\')" onclick="openLowLvDaliylogsDetail('+lowlv.userid+',\''+lowlv.name+'\',\'\');" class="col uc-n t-bla ub ubb  b-gra1 uinn58 ub-ac ulev-0 umh4 '+whitebg+'">';
					forumObj += '<div class="ub-f1 ut-s"><h5>' + lowlv.name + '</h5></div>';
					forumObj += '<div class="res_rat lis-sw-1 ub-img"></div>';
					forumObj += '<div class="res8 lis-sw ub-img"></div></div>';
				}
			}
		}
		if(forumObj == ''){
			forumObj += '<div class="uinn">'
			forumObj +='<ul class="ub b-gra ub-ac lis us uinn ">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">没有您的相关下属!...</li>';  
			forumObj +='</ul></ul>';
			forumObj += '</div>';
		}
		setHtml("dailylogs_list", forumObj);
	}
}

DAObj.prototype.SearchLowLvDailylogsList = function(data){ // 搜索下级列表(实例方法)
	var forumObj = '';
	var searchtext = getstorage("searchtext");
	var entrylist = this.LowLvDailylogsList;
	var intLowLv = 0;
	for (intLowLv = 0; intLowLv < entrylist.length; intLowLv++) {
		if (entrylist[intLowLv] !== undefined) {
			var lowlv = entrylist[intLowLv];
			if (checkMatch(lowlv.name,searchtext)) {
				if (lowlv.dailylogsid == '') {
					forumObj += '<div ontouchstart="zy_touch(\'col-active\')" onmousedown="zy_touch(\'col-active\')" onclick="openLowLvDaliylogsDetail('+lowlv.userid+',\''+lowlv.name+'\',\'\');" class="col uc-n t-bla ub ubb  b-gra1 uinn58 ub-ac c-m22 c-gra ulev-0 umh4">';
					forumObj += '<div class="ub-f1 ut-s"><h5>' + lowlv.name + '</h5></div>';
					forumObj += '<div class="res_rat2 lis-sw-1 ub-img"></div>';
					forumObj += '<div class="res8 lis-sw ub-img"></div></div>';
				}
				else {
					forumObj += '<div ontouchstart="zy_touch(\'col-active\')" onmousedown="zy_touch(\'col-active\')" onclick="openLowLvDaliylogsDetail('+lowlv.userid+',\''+lowlv.name+'\',\'\');" class="col uc-n t-bla ub ubb  b-gra1 uinn58 ub-ac c-m22 c-gra ulev-0 umh4">';
					forumObj += '<div class="ub-f1 ut-s"><h5>' + lowlv.name + '</h5></div>';
					forumObj += '<div class="res_rat lis-sw-1 ub-img"></div>';
					forumObj += '<div class="res8 lis-sw ub-img"></div></div>';
				}
			}
			if(forumObj == ''){
				forumObj += '<div class="uinn">'
				forumObj +='<ul class="ub b-gra ub-ac lis us uinn ">';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">没有您的相关下属!...</li>';  
				forumObj +='</ul></ul>';
				forumObj += '</div>';
			}
		}
	}
	setHtml("dailylogs_list", forumObj);
}

DAObj.prototype.GetLowLvDailylogsInfo=function(){  //获取下级日报详细(实例方法)
	this.thePage = 'LowLv';
	this.CurrentLowLvUserId = getstorage("CurrentLowLvUserId");   //id
	var dailyLogsDate = getstorage("dailyLogsDate");
	this.method = 'get_entry_list';
	this.rest_data = '{"lowsession":"' + this.CurrentLowLvUserId + '",' +
            '"module_name":"'+this.name+'",' +
            '"query":"'+dailyLogsDate+'",' +
            '"offset":"0",' +
            '"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}; 

DAObj.prototype.ShowLowLvDetail = function(data){ //显示 详细(实例方法)
	var forumObj = '';
	var dailylogList = data;
	if ((dailylogList !== undefined) && (dailylogList.entry_list !== undefined)) {
		forumObj += '<div class="uinn">'
		forumObj +='<ul class="ub b-gra ub-ac lis c-wh uc-a1 uba uinn ">';
		forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1 tx-c">未提交日报!...</li>';  
		forumObj +='</ul></ul>';
		forumObj += '</div>';
		//setHtml('DailylogsDayH1', dailylogList.entry_list.days);
		var entrylist = dailylogList.entry_list;
		if (entrylist.currentuser_list && entrylist.currentuser_list != '') {//已经有日报
			var currentuser_list = entrylist.currentuser_list;
			if (currentuser_list.status.value == "1") {//看日报
				var forumObj = '';
				statustext = RES_DAILYLOGS_LOOK;
				setype = "otherlook";
				lookhead = currentuser_list.smownername.value + " " + RES_DAILYLOGS_LABEL;
				forumObj += '<div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
					forumObj += '<div class="umar-b uinn1 tx-c ub-f1">' + lookhead + '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-f1 c-wh ubl ubr b-gra">';
				forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
					forumObj += '<div class="detail_bt t-gra1">' + RES_DAILYLOGS_DESCRI + '</div>';
			 			forumObj += '<div class="ub-f1 detail_nr ub">'+currentuser_list.descri.value+'</div>';
					forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-f1 c-wh uba uc-b1 b-gra">';
				forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
					forumObj += '<div class="detail_bt t-gra1">' + RES_DAILYLOGS_CURPLAN + '</div>';
			 			forumObj += '<div class="ub-f1 detail_nr ub">'+currentuser_list.curplan.value+'</div>';
					forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<br /><div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
					forumObj += '<div class="umar-b uinn1 ub-f1 tx-c">' + RES_DAILYLOGS_REPLIES + '</div>';
				forumObj += '</div>';
				if (entrylist.reply_value_list && entrylist.reply_value_list != undefined) {
					var replyList = entrylist.reply_value_list;
					var replylength = replyList.length;
					if (replylength > 0) {
						for (var i = 0; i < replylength; i++) {
							if(i != replylength-1){
								forumObj += '<div class="ub ub-f1 c-wh ubl ubr b-gra">';
							}else{
								forumObj += '<div class="ub ub-f1 c-wh ubt_my uc-b1 b-gra">';
							}
							forumObj += '<div class="ub uinn t-bla ulab ub-ac ub-f1">';
							forumObj += '<ul class="c-m2 ub b-gra t-bla ub-ac lis">';
							forumObj += '<ul class="ub-f1 ub ub-ver"><li class="detail_li_text umh4 ">' + replyList[i].description + '</li><li class="detail_ul_text">' + replyList[i].last_name + ' at ' + replyList[i].createdtime + '</li>';
							forumObj += '</ul></ul>';
							forumObj += '</div>';
							forumObj += '</div>';
						}
					}
				}
				forumObj += '<br /><div class="ub ub-f1 uinn-top uba c-wh uc-t1 b-gra ub-ac">';
					forumObj += '<div class="umar-b uinn1 ub-f1 tx-c">' + RES_DAILYLOGS_SAVEREPLIES + '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub ub-f1 c-wh ubt_my uc-b1 b-gra">';
				forumObj += '<div class="ub-f1 c-wh b-gra uc-b1 uinput uinn4 ub uc-b1 ub-ver">';
				forumObj += '<textarea rows=3 '+input_msg +' id=\"replydescriBox\" placeholder=\"'+RES_DAILYLOGS_SAVEREPLIES+'\" name=\"replydescri\" type=\"text\"  class=\"DailylogsBox\"></textarea>';
				forumObj += '</div>';
				forumObj += '</div>';
				forumObj += '<div class="ub"><div class="ub-f1 uinn">';
				forumObj += '<div ontouchstart="zy_touch(btn-act);" onmousedown="zy_touch(\'btn-act\', function(){daobj.savereplydescri_click(\''+currentuser_list.dailylogsid.value+'\');});" class="btn uinn5 c-blu3 uc-a1 t-wh"><i class="icon-ok"></i>&nbsp;'+RES_DAILYLOGS_SUBMIT+'</div>';
				forumObj += '</div></div>';
			}
		}
	}
	setHtml("dailylogs_list", forumObj);
}

DAObj.prototype.saveDailylogs_click=function(setype,record){  //保存(实例方法)
	var select_fields = "&setype="+setype+"";
	if($$('descriptionBox').value == ''){
		myalert(RES_DAILYLOGS_NOTWRITETODAY);
		return false;
	}else{
		select_fields += "&description="+$$('descriptionBox').value+"";
	}
	var dailyLogsDate = getstorage("dailyLogsDate");
	if($$('curplanBox').value != ''){
		select_fields += "&curplan="+$$('curplanBox').value+"";
	}else{
		select_fields += "&curplan=";
	}
	this.rest_data = '{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","link_name_to_fields_array":"'+dailyLogsDate+
			'","record":"' +record +'"}';
	this.method = 'set_entry_save';
	this.tip = 0;
	this.RequestServer();
}; 

DAObj.prototype.savereplydescri_click=function(record){  //保存(实例方法)
	var select_fields = "";
	if($$('replydescriBox').value == ''){
		myalert(RES_DAILYLOGS_NOTREPLIES);return false;
	}else{
		select_fields += "&description="+$$('replydescriBox').value+"";
	}
	select_fields += "&setype=reply";
	this.rest_data = '{"session":"' + this.CurrentUserId +
			'","module_name":"' +this.name +
			'","select_fields":"' +encodeURIComponent(select_fields) +
			'","link_name_to_fields_array":"","record":"' +record +'"}';
	this.method = 'set_entry_save';
	this.tip = 0;
	this.RequestServer();
}; 

DAObj.prototype.SaveReturn=function(data){  //完成保存(实例方法)
	if (this.thePage == 'Myself') {
		this.GetListFromServer();
	}else{
		this.GetLowLvDailylogsInfo();
	}
}; 

function openLowLvDaliylogsDetail(userid,username,res){//  打开下级日报页面
	setstorage('CurrentLowLvUserId', userid);
	setstorage('CurrentLowLvUserName', username);
	uexWindow.evaluateScript('LowLvDailylogsListPage','0',"refreshDailyLogsDate()");
	openwin('LowLvDailylogsDetailPage',res);
}