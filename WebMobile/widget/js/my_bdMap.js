/*Creat at 2013-08-01 for c3crm v3.0 by xiao*/
function initMap(){
	map = new BMap.Map("content"); 
	var point = new BMap.Point(121.453873,31.194788);// 创建点坐标
	map.centerAndZoom(point,19);                     // 初始化地图,设置中心点坐标和地图级别。
	map.enableScrollWheelZoom();   
	//map.enableAutoResize();
	//map.enablePinchToZoom();
	//map.enableHighResolution();
	//map.setMaxZoom(23);
	map.addControl(new BMap.NavigationControl({anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL}));  //右上角，仅包含平移和缩放按钮 
}

/**
 * 普通标注
 * @param {Object} lng  经度
 * @param {Object} lat  纬度
 * @param {Object} content 点击显示的内容
 */
function map_overlay_common(lng,lat,title,content,showLabel){
	map.removeOverlay(myMark);  //清除原有标注
	var point = new BMap.Point(lng,lat);
	var marker1 = new BMap.Marker(point);  // 创建标注
	map.addOverlay(marker1);              // 将标注添加到地图中
	var opts = {
	  width : 200,     // 信息窗口宽度
	  height: 10,     // 信息窗口高度
	  title : title , // 信息窗口标题
	  enableMessage:false//设置允许信息窗发送短息
	}
	var sContent ="<p style='line-height:1.5;font-size:0.8em;text-indent:1.5em'>"+content+"</p>";
	//创建信息窗口
	var infoWindow1 = new BMap.InfoWindow(sContent,opts);
	marker1.addEventListener("click", function(){this.openInfoWindow(infoWindow1);});
	
	var showLabel = arguments[3] || false;
	if (showLabel) {
		var label = new BMap.Label(title, {
			offset: new BMap.Size(20, -10)
		});
		//map.centerAndZoom(point, 18);
		marker1.setLabel(label);
	}
		
}

/**
 * 文本标注
 * @param {Object} lng  经度
 * @param {Object} lat  纬度
 * @param {Object} content  文本显示的内容
 */
function map_overlay(lng,lat,content){
	var point = new BMap.Point(lng,lat);
	var opts = {
	  position : point,    // 指定文本标注所在的地理位置
	  offset   : new BMap.Size(5, -5)    //设置文本偏移量
	}
	var label = new BMap.Label(content, opts);  // 创建文本标注对象
	label.setStyle({
		 color : "black",
		 fontSize : "12px",
		 height : "20px",
		 lineHeight : "20px",
		 fontFamily:"微软雅黑"
	 });
	map.addOverlay(label);   
}

/**
 * 搜索位置
 * @param {Object} value 搜索内容
 */
function searchAddress(value){
	map.clearOverlays();
	var local = new BMap.LocalSearch(map, {
		onSearchComplete: function(result){
		  if (local.getStatus() == BMAP_STATUS_SUCCESS){
		      var res = result.getPoi(0);
			  getAddressByPoint(res.point);
		      map.centerAndZoom(res.point, 15);
		    }
		  },renderOptions: {  //结果呈现设置，
		    map: map,  
			//panel : "content2",
		    autoViewport: true,  
		    selectFirstResult: true 
		  } ,onInfoHtmlSet:function(poi,html){//标注气泡内容创建后的回调函数，有了这个，可以简单的改一下返回的html内容了。
		     //alert(html.innerHTML)
		  }//这一段可以不要，只不过是为学习更深层次应用而加入的。
	});
	local.search(value);
}

/**
 * 获取当前位置
 */
function getLocation(){
	var geolocation = new BMap.Geolocation();
	geolocation.getCurrentPosition(function(r){
		if(this.getStatus() == BMAP_STATUS_SUCCESS){
			var mk = new BMap.Marker(r.point);
			map.addOverlay(mk);              // 将标注添加到地图中
		    map.panTo(r.point);
			var gc = new BMap.Geocoder();
			gc.getLocation(r.point, function(rs){
				var addComp = rs.addressComponents;
				var address = addComp.city + addComp.district + addComp.street + addComp.streetNumber+'('+addComp.province+')';
				saveLocation(r.point.lng,r.point.lat,address);
		    });
	    }else {
	        myalert('failed'+this.getStatus());
	    }        
	},{enableHighAccuracy: true});
}

/**
 * 根据poi获取地址
 * @param {Object} point
 */
function getAddressByPoint(point){
	var gc = new BMap.Geocoder();
	gc.getLocation(point, function(rs){
		var addComp = rs.addressComponents;
		var address = addComp.city + addComp.district + addComp.street + addComp.streetNumber+'('+addComp.province+')';
		setHtml('cityname',addComp.city);
		$$('new_lng').value = point.lng;
		$$('new_lat').value = point.lat;
		setHtml('new_address',address);
		getAddressBypoint_callBack();
    });
}

function saveLocation(lng,lat,address){
	switch(workmap.markType){
		case 'user':workmap.markUser(lng,lat,address);
					break;
		case 'account':workmap.markAccount(lng,lat,address);
					break;
		default:break;
	}
}

var EARTH_RADIUS = 6378137.0;    //单位M
var PI = Math.PI;

function getRad(d){
    return d*PI/180.0;
}

/**
 * 根据经纬度计算地球上的两点距离
 * @param {Object} lat1  纬度1
 * @param {Object} lng1  经度1
 * @param {Object} lat2  纬度2
 * @param {Object} lng2  经度2
 */
function getFlatternDistance(lat1,lng1,lat2,lng2){
    var f = getRad((Number(lat1) + Number(lat2))/2);
    var g = getRad((Number(lat1) - Number(lat2))/2);
    var l = getRad((Number(lng1) - Number(lng2))/2);
	if(g==0 && l==0){ //若传入的两点经纬度都相等
		return 0;
	}
    var sg = Math.sin(g);
    var sl = Math.sin(l);
    var sf = Math.sin(f);
    var s,c,w,r,d,h1,h2;
    var a = EARTH_RADIUS;
    var fl = 1/298.257;
    
    sg = sg*sg;
    sl = sl*sl;
    sf = sf*sf;
    s = sg*(1-sl) + (1-sf)*sl;
    c = (1-sg)*(1-sl) + sf*sl;
    w = Math.atan(Math.sqrt(s/c));
    r = Math.sqrt(s*c)/w;
    d = 2*w*a;
    h1 = (3*r -1)/2/c;
    h2 = (3*r +1)/2/s;
	var distance = d*(1 + fl*(h1*sf*(1-sg) - h2*(1-sf)*sg));
    return Math.round(distance);
}

function paintCircleByPoint(lng,lat,raidus){
	var point = new BMap.Point(lng,lat);// 创建点坐标
	var circle = new BMap.Circle(point,raidus,{fillColor:"blue", strokeWeight: 1 ,fillOpacity: 0.3, strokeOpacity: 0.3});
	map.addOverlay(circle);
}

function translateCallback(point) { 
	map.removeOverlay(myMark);
	myMark = new BMap.Marker(point);
	map.addOverlay(myMark);              // 将标注添加到地图中
	var label = new BMap.Label('我的位置', {
		offset: new BMap.Size(20, -10)
	});
	myMark.setLabel(label);
    map.panTo(point);
	var gc = new BMap.Geocoder();
	gc.getLocation(point, function(rs){
		var addComp = rs.addressComponents;
		var address = addComp.city + addComp.district + addComp.street + addComp.streetNumber+'('+addComp.province+')';
		//setHtml('cityname',addComp.city);
		$$('new_lng').value = point.lng;
		$$('new_lat').value = point.lat;
		setHtml('new_address',address);
		uexWindow.closeToast();
		uexWindow.toast("0","5","获取成功…","2000");
		lbs_to_location_Callback();
    });
}
	
//获取经纬度
function locationRequestCallBack(inLatitude,inLongitude){
	uexWindow.toast("1","5","开始获取您的位置…","0");
	uexLocation.closeLocation();
	lat = inLatitude;
	lng = inLongitude;
	//logs('lng->'+lng);
//	if (getstorage('platform') == 1) {
//		var point = new BMap.Point(lng,lat);// 创建点坐标
//		translateCallback(point);
//	}else {
	var platform = getstorage('platform');
	//alert(platform);
	if(platform==1){
		translateCallback(new BMap.Point(lng, lat));
	}else{
		BMap.Convertor.translate(new BMap.Point(lng, lat), 2, translateCallback);
	}
	
	//}
	//logs('lat->'+lat);
//	var dataobj = JSON.parse(data);
//	logs(data);
//	var point = new BMap.Point(dataobj.longitude,dataobj.latitude);// 创建点坐标
//	map.removeOverlay(myMark);
//	//var myIcon = new BMap.Icon("res://icon.png", new BMap.Size(300,157));
//	//var myMark = new BMap.Marker(point,{icon:myIcon});  // 创建标注
//	//map.addOverlay(myMark);              // 将标注添加到地图中
//	myMark = new BMap.Marker(point);
//	map.addOverlay(myMark);              // 将标注添加到地图中
//	var label = new BMap.Label('我的位置', {
//		offset: new BMap.Size(20, -10)
//	});
//	myMark.setLabel(label);
//    map.panTo(point);
//	var gc = new BMap.Geocoder();
//	gc.getLocation(point, function(rs){
//		var addComp = rs.addressComponents;
//		var address = addComp.city + addComp.district + addComp.street + addComp.streetNumber+'('+addComp.province+')';
//		//setHtml('cityname',addComp.city);
//		$$('new_lng').value = point.lng;
//		$$('new_lat').value = point.lat;
//		setHtml('new_address',address);
//		uexWindow.closeToast();
//		uexWindow.toast("0","5","获取成功…","2000");
//		lbs_to_location_Callback();
//    });
}

//定位到当前位置
function lbs_to_location(){
	uexLocation.openLocation();
	//uexBaiduMap.getCurrentLocation();
//	uexWindow.toast("1","5","开始获取您的位置…","0");
//	var geolocation = new BMap.Geolocation();
//	geolocation.getCurrentPosition(function(r){
//		if(this.getStatus() == BMAP_STATUS_SUCCESS){
//			//var point = new BMap.Point(121.453873,31.194788);// 创建点坐标
//			var point = r.point;
//			map.removeOverlay(myMark);
//			myMark = new BMap.Marker(point);
//			map.addOverlay(myMark);              // 将标注添加到地图中
//			var label = new BMap.Label('我的位置', {
//				offset: new BMap.Size(20, -10)
//			});
//			myMark.setLabel(label);
//		    map.panTo(point);
//			var gc = new BMap.Geocoder();
//			gc.getLocation(point, function(rs){
//				var addComp = rs.addressComponents;
//				var address = addComp.city + addComp.district + addComp.street + addComp.streetNumber+'('+addComp.province+')';
//				//setHtml('cityname',addComp.city);
//				$$('new_lng').value = point.lng;
//				$$('new_lat').value = point.lat;
//				setHtml('new_address',address);
//				uexWindow.closeToast();
//				uexWindow.toast("0","5","获取成功…","2000");
//				lbs_to_location_Callback();
//		    });
//	    }else {
//			uexWindow.closeToast();
//			uexWindow.toast("0","5","获取失败…","2000");
//	        myalert('failed'+this.getStatus());
//	    }        
//	},{enableHighAccuracy: true});
}

// 定义一个控件类,即function
function ZoomControl(){
  // 默认停靠位置和偏移量
  this.defaultAnchor = BMAP_ANCHOR_BOTTOM_RIGHT;
  this.defaultOffset = new BMap.Size(10, 20);
}

// 通过JavaScript的prototype属性继承于BMap.Control
ZoomControl.prototype = new BMap.Control();

// 自定义控件必须实现自己的initialize方法,并且将控件的DOM元素返回
// 在本方法中创建个div元素作为控件的容器,并将其添加到地图容器中
ZoomControl.prototype.initialize = function(map){
  var div = document.createElement("div");// 创建一个DOM元素
  div.appendChild(document.createTextNode("定位到我的位置"));// 添加文字说明 
  div.style.cursor = "pointer";// 设置样式
  div.style.border = "1px solid gray";
  div.style.backgroundColor = "#FF9966";
  div.style.color = "#336699";
  div.style.padding = "2px";
  div.onclick = function(e){
  	lbs_to_location();
  }
  // 添加DOM元素到地图中
  map.getContainer().appendChild(div);
  // 将DOM元素返回
  return div;
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */