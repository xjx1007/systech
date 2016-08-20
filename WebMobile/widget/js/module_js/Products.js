/**
* 产品
*/
function PROObj(name){			//构造函数伪装，把Obj实例伪装成Module实例，来继承Module的属性
	Module.call(this,name); 
	for(var attr in Module.prototype){
	      PROObj.prototype[attr] = Module.prototype[attr];
	};
	this.offset = 1;
	this.catalogId = getstorage("catalogId");
	this.warehouseId = '';
};

PROObj.prototype.ShowResultToClient=function(method,data){  //显示结果(实例方法)
	switch(method){
		case 'get_category_list':
			this.ShowCategoryList(data);
			break;
		case 'get_products_entry_list':
			this.ShowProductsList(data);
			break;
	}
};  

PROObj.prototype.GetCategoryListFromServer=function(){  //获取分类列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	this.method = 'get_category_list';
	this.inJQ = true;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'"}';
	this.RequestServer();
}; 

PROObj.prototype.ShowCategoryList = function(data){ //显示分类列表(实例方法)
	var forumObj = '';
	var categories = data.category[0].category;
	var hasNext = 0;
	for(var i=0;i<categories.length;i++){
		hasNext = categories[i].category.length;
		var whitebg = "c-wh";
		if(i%2==0)
			whitebg = "";
	   	forumObj +='<div class="acc_trigger '+whitebg+'">';
		forumObj +='<ul onclick="openClasses(\''+categories[i].id+'\',\''+categories[i].name+'\','+hasNext+');" class="ub ub-ac lis">';
		forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1">'+categories[i].name+'</li></ul>';  
		if (hasNext > 0) {
			forumObj += '<li class="res_cata lis-sw-1 ub-img"></li>';
		}
		forumObj +='</ul></div>';
		forumObj +='<div class="acc_container" id="container_"'+categories[i].id+'>';
		if(hasNext >0 ){
			categories1 = categories[i].category;
			forumObj +='<ul onclick="openClasses(\''+categories[i].id+'\',\''+categories[i].name+'\',0);" class="ubb ub b-gra ub-ac lis act-wh">';
			forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1_1">全部</li>';  
			forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
			for (var j = 0; j < categories1.length; j++) {
				forumObj +='<ul onclick="openClasses(\''+categories1[j].id+'\',\''+categories1[j].name+'\',0);" class="ubb ub b-gra ub-ac lis act-wh">';
				forumObj +='<ul class="ub-f1 ub ub-ver"><li class="li_1_1">'+categories1[j].name+'</li>';  
				forumObj +='</ul><li class="res8 lis-sw ub-img"></li></ul>';
			}
		}
		forumObj +='</div>';
	}
	setHtml("category_list", forumObj);
	$('.acc_trigger').click(function(){     //用于点击显示二级板块
		 if( $(this).next().is(':hidden') ) { 
			  $('.acc_trigger').removeClass('active').next().slideUp(); 
			  $(this).toggleClass('active').next().slideDown(); 
		 }else{
		 	$(this).next().slideUp();
		 }
		 return false; 
	});
}

PROObj.prototype.GetProductsListByCataId=function(){  //获取产品列表(实例方法)
	this.offset = getstorage("currPage");     // 页码
	var searchtext = getstorage("searchtext");  //搜索条件
	if(!searchtext) searchtext = '';
	this.method = 'get_products_entry_list';
	this.inJQ = true;
	this.rest_data = '{"session":"' + this.CurrentUserId + '",' +
                '"module_name":"'+this.name+'",' +
				'"warehouseId":"'+this.warehouseId+'",' +
				'"catalogId":"'+this.catalogId+'",' +
                '"query":"'+searchtext+'",' +
                '"offset":' + this.offset + ',' +
                '"max_results":' + RowsPerPageInListViews + '}';
	this.RequestServer();
}; 

PROObj.prototype.ShowProductsList = function(data){ //显示产品列表(实例方法)
	var outNewsObj = $("#products_list");
	var productsList = data;
	if ((productsList !== undefined) && (productsList.entry_list !== undefined)) {
		if ((productsList.next_offset === 0) || (productsList.result_count === 0)) {
			myalert('There are no more records in that direction');
		}else {
			var intProduct = 0;
			for (intProduct = 0; intProduct < productsList.entry_list.length; intProduct++) {
					var whitebg = "c-wh";
					if(intProduct%2==0)
						whitebg = "";
				if (productsList.entry_list[intProduct] !== undefined) {
					var forumObj = '';
					var product = productsList.entry_list[intProduct];
					forumObj += '<div class="ubb b-gra '+whitebg+'">';
					forumObj += '<input type="checkbox" id="sopro_'+product.productid.value+'" name="so_products" value=\''+JSON.stringify(product)+'\' class="uhide b-gra">';
					forumObj += '<div onclick="zy_for_sop(event)" ontouchstart="zy_touch(\'btn-act\')" class="ub b-gra uinn3 ">';	 
					forumObj += '<div class="che-icon ub-img umw1"></div>';
					forumObj += '<div class="li_1">'+product.productname.value + '</div>';
					forumObj += '</div><sop_ll>';
					
					forumObj += '<div class="uinn3">';	
					forumObj += '<div class="ub t-bla ulab ub-ac">';
					forumObj += '<div class="wd_wh detail_ul_text">' + product.productcode.name+':</div><div class="wd_wh2 detail_li_text">'+product.productcode.value + '</div>';
					forumObj += '<div class="wd_wh detail_ul_text">' + product.serialno.name+':</div><div class="wd_wh2 detail_li_text">'+product.serialno.value + '</div>';
					forumObj += '</div></div>';
					
					forumObj += '<div class="b-gra uinn3">';	
						forumObj += '<div class="ub t-bla ulab ub-ac">';
						forumObj += '<div class="wd_wh detail_ul_text">' + product.unit_price.name+':</div><div class="wd_wh2 detail_li_text">'+product.unit_price.value + '</div>';
						forumObj += '<div class="wd_wh detail_ul_text">' + product.qtyinstock.name+':</div><div class="wd_wh2 detail_li_text">'+product.qtyinstock.value + '</div>';
						forumObj += '</div></div>';
					forumObj += '</sop_ll></div>';
					outNewsObj.append(forumObj);
				}
			}
		}
	}
	if(productsList.lastpg > 0){
		setstorage('currPage', this.offset);
		setstorage('lastPage', productsList.lastpg);
		setpagenum();
		if (parseInt($$("currPage").innerHTML) == parseInt($$("lastPage").innerHTML)) {
			setHtml("pullUpLabel", '已全部加载完毕');
		}else {
			setHtml("pullUpLabel", '显示更多...');
		}
	}
	if(productsList.entry_list.length == 0){
		setHtml("pullUpLabel", '还没有记录哦!!');
	}
}

function openClasses(categoryId,categoryName,hasNext){//按类别打开产品列表
	if (hasNext == 0) {
		setstorage('catalogId',categoryId);
		setstorage('categoryName',categoryName);
		openwin('Products','');
	}
}
