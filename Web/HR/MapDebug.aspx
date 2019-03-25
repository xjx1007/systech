<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapDebug.aspx.cs" Inherits="Web_HR_MapDebug" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=Xm6AEwD6v36WQgUhi2wPE5kYCdG6XErU"></script>
    <title>地图显示</title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <style type="text/css">
        body, html, #map {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
            background-color: #fff;
            font-family: "微软雅黑";
            color: #101010;
        }
    </style>
</head>
<body>

    <div id="map">
    </div>

</body>
</html>
<script type="text/javascript">
    window.onload = function () {
        var pointArray = new Array();
        debugger;
        var points = [{ "lat": 29.320054, "lng": 118.220204, "nam": 'B1' },
            { "lat": 29.328644, "lng": 118.235204, "nam": 'B2' },
            { "lat": 29.334564, "lng": 118.220204, "nam": 'B3' },
            { "lat": 29.302024, "lng": 118.238204, "nam": 'B4' },
            { "lat": 29.330034, "lng": 118.252204, "nam": 'B5' },
            { "lat": 29.232674, "lng": 118.203304, "nam": 'B6' },
            { "lat": 29.331254, "lng": 118.224404, "nam": 'B7' },
            { "lat": 29.330084, "lng": 118.235504, "nam": 'B8' }];
        var opts = {
            width: 200,     // 信息窗口宽度    
            height: 100,     // 信息窗口高度    
            title: "Hello"  // 信息窗口标题   
        }
        // 打开信息窗口
        //根据各个点自适应显示地图
        var map = new BMap.Map("map");
        var view = map.getViewport(points);
        var mapZoom = view.zoom;
        var centerPoint = view.center;
        map.centerAndZoom(centerPoint, mapZoom);//初始化地图，设置中心点坐标和地图级别
        map.enableScrollWheelZoom(true);//滚动鼠标对地图进行放大放小
        //添加多个点
        for (var i = 0; i < points.length; i++) {
            var item = points[i];
            var p = new BMap.Point(item.lng, item.lat);
            //pointArray[i] = p;
            //自定义点图标
            //var iconUrl = "point.jpg";
            //var myIcon = new BMap.Icon(iconUrl, new BMap.Size(40, 80));
            var infoWindow = new BMap.InfoWindow("World", item.nam);  // 创建信息窗口对象               
            var marker = new BMap.Marker(p);
            map.openInfoWindow(infoWindow, map.getCenter());
            map.addOverlay(marker);
        }

        //function myFun(result) {
        //    var cityName = result.name;
        //    map.setCenter(cityName);
        //    //alert("当前定位城市:" + cityName);
        //}
        //var myCity = new BMap.LocalCity();
        //myCity.get(myFun);
        //添加折线
        //var polyline = new BMap.Polyline(pointArray, { strokeColor: "#5298FF", strokeWeight: 6, strokeOpacity: 1.0 });  
        //map.addOverlay(polyline);  
    };
</script>

<%--<script type="text/javascript">
    var map = new BMap.Map("map");//创建map实例
    map.addControl(new BMap.NavigationControl());//添加地图控件
    map.enableScrollWheelZoom(true);//滚动鼠标对地图进行放大放小
    map.centerAndZoom(new BMap.Point(116.331398, 39.897445), 12);//初始化地图，设置中心点坐标和地图级别
    var mk = new BMap.Marker(new BMap.Point(121.500547, 31.23039));//创建注标

    function myFun(result) {
        var cityName = result.name;
        map.setCenter(cityName);
        //alert("当前定位城市:" + cityName);
    }
    var myCity = new BMap.LocalCity();
    myCity.get(myFun);
    map.addOverlay(mk);//在地图上显示坐标
    //map.addOverlay(mk1);//在地图上显示坐标
    //map.addOverlay(mk2);//在地图上显示坐标
</script>--%>
