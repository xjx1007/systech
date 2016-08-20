/**
* 库存余额
*/
function WAObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      WAObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
	this.warehouseId = '';
	this.catalogId = '';
};

WAObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_products_entry_list':
			this.ShowList(data);
			break;
		case 'get_category_list':
			this.ShowProductClasses(data);
			break;
	}
};  

WAObj.prototype.GetListFromServer=function(){  //获取列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	this.warehouseId = getstorage("warehouseId");
	this.catalogId = getstorage("catalogId");
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	this.method = 'get_products_entry_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
				'"warehouseId":"'+this.warehouseId+'",' +
				'"catalogId":"'+this.catalogId+'",' +
                '"query":"'+searchtext+'",' +
                '"offset":' + this.offset + ',' +
                '"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}; 

WAObj.prototype.ShowList = function(data){ //显示列表(实例方法)
	var forumObj = '';
	var balancesList = data;
	if ((balancesList !== undefined) && (balancesList.entry_list !== undefined)) {
		var intProduct = 0;
		for (intProduct = 0; intProduct < balancesList.entry_list.length; intProduct++) {
			if (balancesList.entry_list[intProduct] !== undefined) {
				var balances = balancesList.entry_list[intProduct];
				forumObj += '<div class="uba uc-a1 umar-a c-wh b-gra">';
				
				forumObj += '<div class="b-gra uinn3 ubb">';	
				forumObj += '<div class="title_ul_text uinn3 tx-l">'+balances.productname.value + '</div>';
				forumObj += '</div>';
				
				//forumObj += '<div class="b-gra">';	
				forumObj += '<div class="ub ulev0 ubb b-gra t-bla">';
				forumObj += '<div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+balances.productcode.name +'</div><div class="ub-f1 ub-con uinn13">'+ balances.productcode.value+'</div></div>';
				forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+balances.serialno.name +'</div><div class="ub-f1 ub-con uinn13">'+ balances.serialno.value+'</div></div>';
				forumObj += '</div>';

				forumObj += '<div class="ub ulev0 ubb b-gra t-bla">';
				//forumObj += '<div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+balances.unit_price.name +'</div><div class="ub-f1 ub-con uinn13">'+balances.unit_price.value+'</div></div>';
				forumObj += '<div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+balances.qtyinstock.name +'</div><div class="ub-f1 ub-con uinn13">'+ balances.qtyinstock.value+'</div></div>';
				forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+balances.outputnum.name+'</div><div class="ub-f1 ub-con uinn13">'+ balances.outputnum.value+'</div></div>';
				forumObj += '</div>';

				forumObj += '<div class="ub ulev0 ubb b-gra t-bla">';
				forumObj += '<div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+ balances.socknum.name +'</div><div class="ub-f1 ub-con uinn13">'+ balances.socknum.value+'</div></div>';
				forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">'+balances.onnum.name +'</div><div class="ub-f1 ub-con uinn13">'+ balances.onnum.value+'</div></div>';
				forumObj += '</div>';

//				forumObj += '<div class="ub ulev0 ubb b-gra t-bla">';
//				forumObj += '<div class="ub ub-f1 ub-con ubr b-gra"><div class="ub-f1 ub-con uinn12 t-gra1">'+balances.outputnum.name+'</div><div class="ub-f1 ub-con uinn13">'+ balances.outputnum.value+'</div></div>';
//				forumObj += '<div class="ub ub-f1 ub-con"><div class="ub-f1 ub-con uinn12 t-gra1">&nbsp;</div><div class="ub-f1 ub-con uinn13">&nbsp;</div></div>';
//				forumObj += '</div>';
				
				forumObj +='</div>';
			}
		}
		if(balancesList.entry_list.length == 0){
			forumObj += showNotRecordDiv();
		}
		setHtml("balances_list", forumObj);
		if(balancesList.lastpg > 0){
			setstorage('currPage', this.offset);
			setstorage('lastPage', balancesList.lastpg);
			uexWindow.evaluatePopoverScript('BalancesListPage','pop_nav',"setPageSel()");
		}
	}	
}

WAObj.prototype.GetProductClasses=function(){  //获取产品种类(实例方法)
	this.method = 'get_category_list';
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'"}';
	this.cacheFlag = false;
	this.RequestServer();
}; 

WAObj.prototype.ShowProductClasses = function(data){ //显示种类列表(实例方法)
	var forumObj = '';
	var warehousesList = data.warehouse;
	var catalogList = data.catalog;
	setstorage("warehousesList",JSON.stringify(warehousesList));  //  存
	forumObj +='<div class="ub ub-f1 t-bla" >';
	forumObj +='<div class="ub ub-f1 sel ub-pc ub-ac">';  
	forumObj +='<div class="ulim ub-f1 ut-s uinn tx-l">'+catalogList[0].name+'</div>';
	forumObj +=' <div class="umh1 umw1" style="right:0.2em;"><i class="icon ion-arrow-down-b"></i></div>';
	forumObj +='<select name="catalogname" selectedindex="0" id="catalogname" onchange="zy_selectmenu(this.id);changCatalog();">';
	var intCatalog = 0;
	for (intCatalog = 0; intCatalog < catalogList.length; intCatalog++) {
		var catalog = catalogList[intCatalog];
		forumObj +='<option value="'+catalog.id+'">'+catalog.name+'</option>';
	}
	forumObj +='</select></div></div>';
	setHtml("catalogSel", forumObj);
}

function changCatalog(){  //修改种类
	setstorage('catalogId', $$("catalogname").value);
	searchList();
}
