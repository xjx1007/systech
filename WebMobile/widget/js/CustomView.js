//获取视图列表
function getViews(module){
	setHtml("view_sel_div", '');
	var forumObj = '';
	var AjaxUrl = getstorage("CurrentServerAddress");
	var CurrentUserId = getstorage("SugarSessionId");
	var rest_data = '{"session":"' + CurrentUserId + '",' +
            '"module":"'+module+'"}';
	var m =[{"key":"rest_data","type":"0","value":rest_data},
		{"key":"method","type":"0","value":"get_view_list"},
		{"key":"input_type","type":"0","value":"JSON"},
		{"key":"response_type","type":"0","value":"JSON"}];
   var url=AjaxUrl+'/rest.php?callback=?&request='+encodeURIComponent(rest_data)+'&method=get_view_list';
   $.getJSON(url,
		function(data){
			if (data !== undefined) {
				if (data === "Invalid Session ID") {
					uexWindow.toast(0, 5, "ID异常,请重新登陆...", 3000);
				}
				var viewsList = data.viewArr;
				if (viewsList !== undefined) {
					var intView = 0;
					var view;
					var bar_radius = "";
					forumObj += '<div class="ub ulev-1 t-blu3">';
					if (viewsList.length <= 3) {
						if (viewsList.length > 0) {
							for (intView = 0; intView < viewsList.length; intView++) {
								view = viewsList[intView];
								//bar_radius = "ubr_my";
//								if (intView == 0) 
//									bar_radius += " uba uc-l1";
//								if (intView == viewsList.length - 1) 
//									bar_radius += " uc-r1";
								forumObj += '<input class="uhide" type="radio" name="viewmenu" id="view' + intView + '" value="' + view.cvid + '" >';
								//forumObj += '<div class="ub-con1 b-blu3 ub-f1 tx-c tp-view long_hide uof ' + bar_radius + '" ontouchstart="zy_touch(\'focuss\')" onclick="viewSelected(' + intView + ');">' + view.viewname + '</div>';
								forumObj += '<div class="ub-con1 b-gra ub-f1 tx-c tp-view long_hide uof ubb1" ontouchstart="zy_touch(\'focuss\')" onclick="viewSelected(' + intView + ');">' + view.viewname + '</div>';
							}
						}else{
							forumObj += '<input class="uhide" type="radio" name="viewmenu" >';
							forumObj += '<div class="ub-con ubb1 b-blu3 long_hide ub-f1 tx-c tp-view">您还没有创建视图。。</div>';
						}
						
					}else{
						for (intView = 0; intView < 2; intView++) {
							view = viewsList[intView];
//							bar_radius = "ubr_my";
//							if(intView==0)bar_radius="uba uc-l1";
							forumObj += '<input class="uhide" type="radio" name="viewmenu" id="view' + intView + '" value="'+ view.cvid +'">';
							forumObj += '<div class="ub-con1 b-gra ub-f1 tx-c tp-view long_hide uof ubb1 " ontouchstart="zy_touch(\'focuss\')" onclick="viewSelected(' + intView + ');">' + view.viewname + '</div>';
						}
						//bar_radius="ubr_my uc-r1";
						view = viewsList[intView];
						forumObj += '<input class="uhide" type="radio" name="viewmenu" id="view' + intView + '" value="viewSel">';
						forumObj += '<div class="ub-con1 b-gra ub-f1 tx-c tp-view long_hide uof ubb1" ontouchstart="zy_touch(\'focuss\')" onclick="viewSelected(' + intView + ');">';
						forumObj += '<div class="ub-f1 ub sel">';
						forumObj += '<div class="ub-f1 ulim-1 tx-c ">' + view.viewname + '</div>';
						forumObj += '<div class="lis-sw-4"><i class="icon ion-arrow-down-b"></i></div>';
						forumObj += '<select name="sel0" id="viewSel" onchange="zy_selectmenu(this.id);changeViewSel()">';
						for (intView=2; intView < viewsList.length; intView++) {
							var view = viewsList[intView];
							forumObj += '<option value='+ view.cvid +'>' + view.viewname + '</option>';
						}
						forumObj += '</select>';
						forumObj += '</div></div>';
					}
				}
				forumObj += '</div>';
				setHtml("view_sel_div", forumObj);
				//added by ligangze on 2014/09/29
			    var viewstr = module.toLowerCase();
				if(module!="SalesOrder"){
					var viewpre = viewstr.substring(0,viewstr.length-1);
				}else{
					var viewpre = viewstr;
				}	
				setViewMenuSelected(getstorage(viewpre+'_viewId'));				
				getListByView(getstorage(viewpre+'_viewId'));
				//end...
			}
		},"json",//返回类型为json　
		function(err){//处理提交异
		   uexWindow.toast(0, 5, "连接服务器异常,请检查网络...", 3000);
		},"POST",//以POST方式提交, 
	m,true);//提交的参数键值对对象 
}

//选中视图
function viewSelected(i){
	var viewId = radioSelect('view'+i);
	if (viewId != 'notChange') {
		if(viewId == 'viewSel'){
			viewId = $$('viewSel').value;
		}
		getListByView(viewId);
	}
}

//修改试图范围
function changeViewSel(){
	var viewId = $$('viewSel').value;
	getListByView(viewId);
} 

//设置视图选中项
function setViewMenuSelected(currViewId){
	var modulename = getstorage('thePage').toLowerCase();
	if(currViewId=='' || currViewId == $$('view0').value  ){
		$$('view0').checked = true;
		setstorage(modulename+'_viewId', $$('view0').value);
		return;	
	}else if(currViewId == $$('view1').value){
		$$('view1').checked = true;
		setstorage(modulename+'_viewId', $$('view1').value);
		return;
	}else{
		$$('view2').checked = true;
		selectValue('viewSel',currViewId);
		setstorage(modulename+'_viewId', $$('view2').value);
		return 
	}
}

