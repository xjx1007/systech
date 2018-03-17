/*
 * 此JS 包含分页窗口的一些变量和方法
 */
var refreshPageInfo = true;
var theMainWindow = getstorage('theMainWindow');
//设置页码选择下拉列表
function setPageSel(){
	if (refreshPageInfo) {
		var currpage = getstorage("currPage");
		var lastpage = getstorage("lastPage");
		var formobj = "";
		if (lastpage > 1) {
			formobj += '<div class="ub-f1 ub sel">';
			formobj += '<div class="ub-f1 tx-c">' + currpage + '/' + lastpage + '</div>';
			formobj += '<div class="lis-sw-4"><i class="icon ion-arrow-down-b"></i></div>';
			formobj += '<select selectedindex="0" id="thePage" onchange="zy_selectmenu(this.id);jumpPage1();">';
			for (var i = 1; i <= lastpage; i++) {
				formobj += '<option value="' + i + '">' + i + '/' + lastpage + '</option>';
			}
			formobj += '</select></div>';
		}
		else {
			formobj += '<span class="t-wh">1/1</span>';
		}
		setHtml('pageSel', formobj);
		refreshPageInfo = false;
		setHtml("currPage", currpage);//记录当前页数和最大页数
		setHtml("lastPage", lastpage);
	}
}

//跳转页面
function jumpPage1(){
	setstorage("currPage",$$('thePage').value);
	setHtml("currPage", $$('thePage').value);
	uexWindow.evaluateScript(theMainWindow, "0", "getPageNewInfo()");
}

//前进,后退,搜索
function turnpage(offset)
{
	var offsetPage = 1;
	switch(offset){
		case -1:   //上一页
			if(parseInt($$("currPage").innerHTML) == 1){
				return false;
			}
			offsetPage = parseInt($$("currPage").innerHTML)-parseInt(1);
			break;
		case 0:   //首页
			if(parseInt($$("currPage").innerHTML) == 1){
				return false;
			}
			offsetPage = 1;
			break;
		case 1:   //下一页
			if(parseInt($$("currPage").innerHTML) == parseInt($$("lastPage").innerHTML)){
				return false;
			}
			offsetPage = parseInt($$("currPage").innerHTML)+parseInt(1);
			break;
		case 2:   //末页
			if(parseInt($$("currPage").innerHTML) == parseInt($$("lastPage").innerHTML)){
				return false;
			}
			offsetPage = parseInt($$("lastPage").innerHTML);
			break;
		case 3:    //搜索
			offsetPage = 1;
			refreshPageInfo = true;
			setstorage("searchtext",$$("searchtext").value);
			break;
	}
	setHtml("currPage", offsetPage);
	setstorage("currPage",offsetPage);
	if(!refreshPageInfo)
		selectValue('thePage',offsetPage);
	uexWindow.evaluateScript(theMainWindow, "0", "getPageNewInfo()");
}

//刷新分页窗口页码
function setNewRefresh(){
	refreshPageInfo = true;
}