var db;
//初始化所有模块
var moduleArr =  [{'index':1,'name':'客户','show':1},
				  {'index':2,'name':'联系人','show':1},
				  {'index':3,'name':'联系记录','show':0},
				  {'index':4,'name':'日报','show':1},
				  {'index':5,'name':'下级日报','show':0},
				  {'index':6,'name':'库存余额','show':1},
				  {'index':7,'name':'审批中心','show':1},
				  {'index':10,'name':'应收款','show':0},
				  {'index':11,'name':'合同订单','show':0},
				  {'index':12,'name':'销售机会','show':1},
				  {'index':16,'name':'短消息','show':0},
				  {'index':18,'name':'费用报销','show':0},
				  {'index':19,'name':'客户池','show':0},
				  {'index':20,'name':'销售目标','show':1},
				  {'index':21,'name':'统计图表','show':1},
				  {'index':22,'name':'公告','show':1},
				];  
			
//读取数据库中的模块布局并初始化
function setSliderContent(){
    try {
		if (!window.openDatabase) { //检测浏览器是否支持cs-db                
			alert('not supported cs-db!');
		}
		else {
		    //myalert('support');         
			var shortName = 'yikecrmDB';
			var version = '1.0';
			var displayName = 'yikecrm database';
			var maxSize = 65536; //创建一个数据库    
			var sqlss;            
			mydb = window.openDatabase(shortName, version, displayName, maxSize);
			mydb.transaction(function(transaction){
			    //myalert('create table');  
			    transaction.executeSql(" CREATE TABLE IF NOT EXISTS mokuai (id integer primary key AutoIncrement,name varchar(40),show int(1) DEFAULT 1,sort int(5),xb int(5),unique (name,xb))");
			    for (var k = 0; k < moduleArr.length; k++) {

			        //alert(moduleArr[k].name);
					sqlss = 'insert OR IGNORE into mokuai(name,show,sort,xb) values("' + moduleArr[k].name + '","' + moduleArr[k].show + '",' + moduleArr[k].index + ',' + moduleArr[k].index + ')';
					transaction.executeSql(sqlss);
			    }
				sqlss = 'SELECT * from mokuai WHERE show=1 order by sort'; //首页中的模块show=1
				transaction.executeSql(sqlss, [], dataHandler1);
				sqlss = 'SELECT * from mokuai WHERE show=0 order by sort desc';//其他模块show=0
				transaction.executeSql(sqlss, [], dataHandler2);
			});
		}
	} 
	catch (e) { //尝试捕获错误        
		if (e == 2) {
			myalert('Invalid database version.');
		}
		else {
			myalert("Unknown error " + e + ".");
		}
	}
}

function dataHandler(transaction, results) {
    var moduleSort = [];
    moduleSort = results.rows;
    var len = moduleSort.length;
    for (var i = 0; i < len; i++) {
        addDivToMain(moduleSort.item(i)['xb'], moduleSort.item(i)['name']);
    }
}
function dataHandler1(transaction, results){
	var moduleSort = [];
	moduleSort = results.rows;
	var len = moduleSort.length;
	for (var i = 0; i < len; i++) {
		addDivToMain(moduleSort.item(i)['xb'],moduleSort.item(i)['name']);
	}
}
var ss = '';
function addDivToMain(xb,name){
	ss = '<div class="mainPage umar-a uba uc-a1 b-gra ub ub-rev" style="background-color:#FBFCFF" >'+
	 		'<input class="uhide" value="'+xb+'">'+ 
			'<input class="uhide" value="'+name+'">'+ 
			'<ul class=" b-gra myleft"><li class="ub-img8  res-myleft"></li></ul>'+
	 		'<ul class=" ub b-gra t-bla ub-ac lis myone uinn ub-f1" >'+     
				'<ul class="ub-f1 ub ub-ver umar-a">'+
					'<li class="ub ub-f1 myfont">'+name+'</li>'+
				'</ul>'+
				'<li class="lis-icon ub-img res_module'+xb+'" ></li>'+ 
				//'<li class="res8 lis-sw ub-img"></li>'+   
			'</ul>'+
			'<div class="daren-tc">'+
			 	'<div class="ub ub-fv">'+
			 		'<div class="ub-f1 ub-con tx-c t-wh b-gra ubr daren-tc-tab">'+
			 			'<div class="daren-tc-tab-cell ul-top"><i class="icon ion-arrow-up-c"></i>&nbsp;&nbsp;置顶</div>'+
					'</div>'+
					'<div class="ub-f1 ub-con tx-c t-wh b-gra ubr daren-tc-tab">'+
						'<div class="daren-tc-tab-cell ul-delete"><i class="icon ion-ios7-trash"></i>&nbsp;&nbsp;移出首页</div>'+
					'</div>'+
			 	'</div>'+ 
			 '</div>'+  
			'</div>';
	$('.myadd').parent().before(ss);
}

function dataHandler2(transaction, results){
	var moduleSort = [];
	moduleSort = results.rows;
	var len = moduleSort.length;
	var ss = '';
	for (var i = 0; i < len; i++) {
		addDivToOther(moduleSort.item(i)['xb'],moduleSort.item(i)['name']);
		addDivToAddPage(moduleSort.item(i)['xb'],moduleSort.item(i)['name']);
	}
}

function addDivToOther(xb,name){
	ss = '<div class="home_module">'+
			'<input class="uhide" value="'+xb+'">'+ 
			'<input class="uhide" value="'+name+'">'+ 
			'<div class="ub ub-ver otherPage">' +
				'<div class="ub ub-f1 ub-ver uinn module_img_div">' +
				'<div class="ub-f1 ub-img7 res_module' +
				xb +
				'"></div>' +
				'</div>' +
				'<div class="daren-tc daren-tc1">' +
					'<div class="tx-c"><i class="icon ion-plus-round"></i>添加</div>' +
				'</div>'+
				'<div class="daren-tc daren-tc2">' +
					'<div class="tx-c"><i class="icon ion-arrow-left-c"></i>前移</div>' +
				'</div>'+
			'</div>' +
				'<div class="li_2_text t-bla tx-c">' +
				name +
				'</div>' +
		  '</div>';
	$('#otherModules').prepend(ss);
}

function addDivToAddPage(xb,name){
	ss = '<div class="mainPage uba ub b-gra c-wh uc-a1 umar-a" >'+
	 		'<input class="uhide" value="'+xb+'">'+ 
			'<input class="uhide" value="'+name+'">'+ 
	 		'<ul class="ub ub-f1 t-bla ub-ac lis act-wh myone_2 uinn"  >'+     
				'<li class="lis-icon ub-img res_module'+xb+'" ></li>'+ 
				'<ul class="ub-f1 ub ub-ver umar-a">'+
					'<li class="ub ub-f1 myfont">'+name+'</li>'+
				'</ul>'+
			'</ul>'+
			'<div class="ub act-wh">'+
				'<div class="ub ub-f1 ub-ac umar-t umar-b daren-tc3">'+
					'<div class="tx-c ub-f1 uinn"><div class="res-homeplus ub-img umh3 umw3"></div></div>'+
					'</div>'+  
				'</div>'+  
			'</div>';
	$('#addPage').prepend(ss);
	//alert(ss);
}

// tap 首页中的模块    按tap
$('.myone,.myone_2').live('click', function (event) {
	//if (!ifscroll) {//如果不是上下滚动
		var xb = $(this).parent().children('input').eq(0).val();
		openModuleWin(xb);
	//}
	//ifscroll = false;
	
});
// longTap 首页中的模块  长按
//$('.myone').live('longTap',function(event){
$('.myleft').live('tap',function(event){
	//if (!ifscroll) {//如果不是上下滚动
		$('.daren-tc').hide(); //隐藏其他的.daren-tc div 
		$(this).next('ul').next('div').show();//显示当前的.daren-tc div
		event.stopPropagation();
	//}
	//ifscroll = false;
});
//tap 置顶项
$('.ul-top').live('tap',function(){
  $('.daren-tc').hide();
  if ($(this).parents('.daren-tc').parent().prev().length == 1) {
  	var xb = $(this).parents('.daren-tc').parent().children('input').eq(0).val(); //获取当前模块的xb值
  	mydb.transaction(function(transaction){
  		sqlss = 'update mokuai set sort=sort+1 WHERE sort<(select sort from mokuai WHERE xb=' + xb + ')';
  		transaction.executeSql(sqlss);
  		var sqlss = 'update mokuai set sort=1 WHERE xb=' + xb;
  		transaction.executeSql(sqlss);
  	});
  	$('#mainPage').prepend($(this).parents('.daren-tc').parent()); //移动位置
  }
});
//tap 移除首页
$('.ul-delete').live('tap',function(){
  $('.daren-tc').hide();
  var xb = $(this).parents('.daren-tc').parent().children('input').eq(0).val();
  var name = $(this).parents('.daren-tc').parent().children('input').eq(1).val();
  mydb.transaction(      
	function(transaction){
			var sqlss = 'update mokuai set sort=sort+1 WHERE sort<(select sort from mokuai WHERE xb='+xb+')';
			transaction.executeSql(sqlss);            
			sqlss = 'update mokuai set show=0,sort=1 WHERE xb='+xb;
			transaction.executeSql(sqlss);  
	});	
   $(this).parents('.daren-tc').parent().remove();
   addDivToOther(xb,name);
   addDivToAddPage(xb,name);
});

$(document).tap(function(){
	$(".daren-tc").hide();
});

//tap 其他模块中的添加
$('.daren-tc1,.daren-tc3').live('tap',function(event){
	var xb = $(this).parent().parent().children('input').eq(0).val();
    var name = $(this).parent().parent().children('input').eq(1).val();
	var max = moduleArr.length+1;
    mydb.transaction(      
		function(transaction){
			var sqlss = 'update mokuai set sort=sort-1 WHERE sort>(select sort from mokuai WHERE xb='+xb+')';
			transaction.executeSql(sqlss);            
			sqlss = 'update mokuai set show=1,sort='+max+' WHERE xb='+xb;
			transaction.executeSql(sqlss);  
	});	
	var div_index = $('.daren-tc3').index(this);
	$('#otherModules').children().eq(div_index).remove();
	$('#addPage').children().eq(div_index).remove();
	addDivToMain(xb,name);
	event.stopPropagation();
});
// tap 其他模块中的模块div
$('.module_img_div').live('tap',function(event){
	if (!ifscroll2) {
		var xb = $(this).parent().parent().children('input').eq(0).val();
		openModuleWin(xb);
	}
	ifscroll2 = false;
});
//longTap 其他模块中的模块div
$('.otherPage').live('longTap',function(event){
	if (!ifscroll2) {
		$('.daren-tc').hide();
		$(this).children('.daren-tc2').show();
		event.stopPropagation();
	}
	ifscroll2 = false;
});
//tap 前移
$('.daren-tc2').live('tap',function(event){
	if ($(this).parent().parent().index() > 0) {
		var xb = $(this).parent().parent().children('input').eq(0).val();
		var prev_xb = $(this).parent().parent().prev().children('input').eq(0).val();
		$(this).parent().parent().prev().before($(this).parent().parent());
		mydb.transaction(      
		function(transaction){
			var sqlss = "SELECT sort,xb FROM mokuai where xb in("+xb+","+prev_xb+")";
			transaction.executeSql(sqlss, [],dataHandler3); 
		});	
	}
	event.stopPropagation();
});

function dataHandler3(transaction, results){
	var moduleSort = [];
	moduleSort = results.rows;
	var sqlss = 'update mokuai set sort='+moduleSort.item(1)['sort']+' WHERE xb=' + moduleSort.item(0)['xb'];
	transaction.executeSql(sqlss);
	
	var sqlss = 'update mokuai set sort='+moduleSort.item(0)['sort']+' WHERE xb=' + moduleSort.item(1)['xb'];
	transaction.executeSql(sqlss);
}

function openModuleWin(index){
//		db.transaction(      
//			function(transaction){           
//				var sqlss = 'update mokuai set sort=sort+1 WHERE xb='+index;
//				transaction.executeSql(sqlss);   
//		});	
		switch(Number(index)){
			case 1:openwin('AccountsListPage','modules/Accounts/');
				break;
			case 2:openwin('ContactsListPage','modules/Contacts/');
				break;
			case 3:openwin('NotesListPage','modules/Notes/');
				break;
			case 4:openwin('DailylogsListPage','modules/Dailylogs/');
				break;
			case 5:openwin('LowLvDailylogsListPage','modules/Dailylogs/');
				break;
			case 6:openwin('BalancesListPage','modules/Warehouses/');
				break;
			case 7:openwin('ApprovesListPage','modules/ApproveStatus/');
				break;
			case 8:openwin('PerformancesListPage','modules/Performances/');
				break;
			case 9:openwin('CalendarsListPage','modules/Calendars/');
				break;
			case 10:openwin('GathersListPage','modules/Gathers/');
				break;
			case 11:openwin('SalesOrderListPage','modules/SalesOrder/');
				break;
			case 12:openwin('PotentialsListPage','modules/Potentials/');
				break;
			case 13:openwin('SalesFunnelListPage','modules/SalesFunnel/');
				break;
			case 14:openwin('SfaListPage','modules/Sfa/');
				break;
			case 15:openwin('KnowlesListPage','modules/Knowledgebases/');
				break;
			case 16:openwin('PMListPage','modules/PM/');
				break;
			case 17:openwin('WorkMap','modules/WorkMaps/');
				break;
			case 18:openwin('ExpenseListPage','modules/Expenses/');
				break;
			case 19:openwin('PoolListPage','modules/Pools/');
				break;
			case 20:openwin('SalesobjectsListPage','modules/Salesobjects/');
				break;
			case 21:openwin('Ureport','modules/Ureports/');
				break;
			case 22:openwin('AnnouncementsListPage','modules/Announcements/');
				break;
			case 23:openwin('AccountrecordssListPage','modules/Accountrecordss/');
				break;
		}
	}