<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewMain.aspx.cs" Inherits="Knetwork_Admin_NewMain" %>

<html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
         <link rel="stylesheet" href="css/ui-tab.css">
        <link rel="stylesheet" href="dist/css/ionic1.css">
		<link rel="stylesheet" href="css/ui-input.css">
		<link rel="stylesheet" href="css/ui-base.css">
		<link rel="stylesheet" href="css/ui-list.css">
        <link rel="stylesheet" href="css/ui-box.css">
        <link rel="stylesheet" href="css/my-color.css">
		<link rel="stylesheet" href="css/ui-img.css">
		<link rel="stylesheet" href="css/ui-res.css">
		<link rel="stylesheet" href="css/style.css" />
        <script src="js/zy_control.js"></script>
        <script src="js/zy_click.js"></script>
		<script src="js/zepto_js/zepto.min.js"></script>
		<script src="js/iscroll-lite.js"></script>
		<script src="js/zepto_js/zepto.touchwipe.js"></script>
		<script src="js/zepto_js/zepto.tabwipe.js"></script>
		<script src="js/zepto_js/zepto.touch.js"></script>
		<script src="js/zepto_js/zepto.event.js"></script>
		<script src="js/init.js"></script>
		<script type="text/javascript" src="js/Application.js"></script>
		<script type="text/javascript"  src="js/home_modules.js"  charset="utf-8"></script>
            <script  type="text/javascript">
                function func() {
                    //goToPage(1);
                    //    LoginInfo_bind();
                    tabins = $('#slider').tabwipe({
                        done_process: 0.5, //移动超过50%则跳转
                        ani_time: 200, //动画切换时间n
                        max_speed: 800, //滑屏速度超过800dip跳转
                        is_circle: true, //循环滚动
                        callback: function (index) { //切换回调
                            if (index == 2) {
                                index = 0;
                            } else {
                                index++;
                            }
                            $('.gcdt-list-curo span').removeClass('t-org').eq(index).addClass('t-org');//刷新当前是第几页
                        }
                    });// 若要自动切换可在后面加上 .interval(3000)
                    setSliderContent();
                    //检查软件是否更新
                    // initAndCheckUpdate();

                }
                window.Onload = func();
            </script>
<style type="text/css"> 
.userphoto{
	width:4em;
	height:4em;
	-moz-border-radius: 50%;
	-webkit-border-radius: 50%;
	border-radius:50%;
}

.userphoto:hover{
	box-shadow: 0 0 1em rgba(255,255,153,.6), inset 0 0 1em rgba(255,255,255,1);
}

.photo1:{
	border-radius: 0.5em;
}

.photo1:hover{
	box-shadow: 0 0 1em rgba(255,255,153,.6), inset 0 0 1em rgba(255,255,255,1);
}

.photo:hover{
	box-shadow: 0 0 1em rgba(255,255,153,.6), inset 0 0 1em rgba(255,255,255,1);
}

.photo1:{
	border-radius: 0.5em;
}

.photo1:hover{
	box-shadow: 0 0 1em rgba(255,255,153,.6), inset 0 0 1em rgba(255,255,255,1);
}

.ub-img7
{
	width:100%;
	height:100%;
	-webkit-background-size:auto 100%;
	background-size:auto 100%;
	background-repeat:no-repeat;
	background-position:center;
}

.home_module{
	width:4em;
	float:left;
	margin: 0.3em;
}

.otherPage{
	width:100%;
	height:4em;
	text-align:center;
	/*background-color:rgba(0,153,102,1);
	border-radius: 0.3em;*/
}

.daren-tc1{
	border-radius: 0.3em;
	line-height:4em;
}

.daren-tc2{
	border-radius: 0.3em;
	line-height:4em;
}

.li_2_text{
	color:#777777;
	white-space: nowrap;
	overflow: hidden; 
	font-size:0.85em; 
	max-width: 100%;
	margin:3px 3px; !important;
	font-weight: normal;
}

.myfont2{
	color: #20BCA6;
    font-family: "Helvetica",Helvetica,Geneva,Arial,sans-serif;
    font-size: 1.2em;
    font-weight: bold;
}

.myadd:active,.myone:active,.weekdata:active,.myleft:active{
	background-color: #f5f5f5
}

.daren-tc{
	width:100%;
	height:100%;
	background-color: black;
	position: absolute;
	top: 0px;
	left: 0px;
	opacity: 0.9;
	-ms-filter: "alpha(opacity=90)";
	filter: alpha(opacity=90);
	zoom: 1;
	background: #ED7D00;
	z-index:1;
	display:none;
}

.daren-tc-tab{
	display:table;
	width:50%;
}

.daren-tc-tab-cell{
	display:table-cell; 
	margin:3px 3px;
	vertical-align:middle;
}

.delete {
position: absolute;
right: 5%;
top: 50%;
margin-top: -13px;
background: orangered;
padding: 4px 8px;
color: #fff;
}

#zoomUpDiv{   
    position: absolute;  
    top: 200%;  
    left: 0;    
    width: 100%;   
    height: 100%;  
    z-index: 5;  
}
.lis-sw-2	
{
	width:1.5em;
	height:1.5em;
	margin-left:0.4em;
}	

/*x轴平移-20%*/
.animotion{
-webkit-transform: translateX(2.5em);
-webkit-transition-property:all;
-webkit-transition-duration:0.5s;
-webkit-transition-delay:0;
-webkit-transition-timing-function:ease;
}
/*x轴平移会原位置*/
.ooanimotion{
-webkit-transform: translateX(0px);
-webkit-transition-property:all;
-webkit-transition-duration:0.3s;
-webkit-transition-delay:0;
-webkit-transition-timing-function:ease;
}


.fir_animation{
-webkit-animation:fadeInRightBig .3s .2s ease both;
-moz-animation:fadeInRightBig .3s .2s ease both;}
@-webkit-keyframes fadeInRightBig{
0%{opacity:0;
-webkit-transform:translateX(100%)}
100%{opacity:1;
-webkit-transform:translateX(0)}
}
@-moz-keyframes fadeInRightBig{
0%{opacity:0;
-moz-transform:translateX(100%)}
100%{opacity:1;
-moz-transform:translateX(0)}
}

.for_animation{
-webkit-animation:fadeOutRightBig .3s .2s ease both;
-moz-animation:fadeOutRightBig .3s .2s ease both;}
@-webkit-keyframes fadeOutRightBig{
0%{opacity:1;
-webkit-transform:translateX(0)}
100%{opacity:0;
-webkit-transform:translateX(100%)}
}
@-moz-keyframes fadeOutRightBig{
0%{opacity:1;
-moz-transform:translateX(0)}
100%{opacity:0;
-moz-transform:translateX(100%)}
}

input[type="radio"]+div.ip-sta{
	display:none !important;
}
input[type="radio"]:checked+div.ip-sta{	
	display:block !important;
}
</style>
        <title></title>
        </head>
    
    <body class="um-vp uof" style="height:100%;overflow:hidden;" ontouchstart  onload="func()">
        <!--content开始-->
		<!--工作台-->
		<input class="uhide" type="radio" name="headers" id="ihd0" checked="true">
        <div class="ub-img3 res_homebj3 has-tabs ip-sta" tabindex="0" style="top:0; width:100%; position: absolute;">
        	<!--header开始-->
			<div class="ub ub-ver ub-fv">
				<div class="t-wh ub ub-ver ub-ac uinn3" style="height:8em;">
					<div class="uinn3" style="background-color:#3B607C;border-radius:50%;width:4em;height:4em">
						<!--img src="css/images/image-2.jpg" class="userphoto" id="userphoto" onclick="openwin('fb-command','')"/-->
						<img src="css/images/image-2.jpg" class="userphoto" id="userphoto"/>
					</div>
					<div class="ub-f1 ub ub-fh ub-ver umar-b umar-t" >
						<div class="ub-ac ub-f1 tx-c ub-ver" style="margin:0 2.5em">
							<div class="" id="currentuser"><asp:Label runat="server" ID="Lbl_User"></asp:Label></div>
							<div class="" id="companyname"><asp:Label runat="server" ID="Lbl_Companyname"></asp:Label></div>
						</div>
						<!--div class="tx-r" style="z-index:2;position:absolute;top:0.2em;right:0.5em;height:100%">
							<img src="css/images/user-card.png" style="max-width:2.5em;border-radius: 0.5em;" onclick="getpic(1)" />
						</div-->
					</div>
		        </div>
				<!--header结束-->
	        	<div class="ub-f1 ub t-bla c-gra4 uof" style="-webkit-background-size:100%;" >
					<div id="slider" class="ub-con ub t-wh">
						
						<div class="ub-fh " id="picFlip">
							<!--列表开始-->
							<div class="" > 
							  <div class="umar-a uba uc-a1 b-gra" style="background-color:#FBFCFF">
								 <ul class="ub b-gra c-m2 t-bla ub-ac lis myadd uinn">    
								 	<li class="lis-icon res-homeadd ub-img"></li>     
								 	<li class="ub-f1 ut-s tx-l myfont t-gra1 umar-l">添加</li>         
								 </ul>    
							  </div> 
							</div>
							<!--列表结束-->
						</div>
						
						<div class="ub-fh" id="picFlip2">
							<div class="ub ub-ver">
				    			<div style="margin: auto;padding:0.6em;overflow:auto;zoom:1;" id="otherModules">
								</div>
							</div>
						</div>
						
						<div class="ub-fh  ub-ver b-gra" id="picFlip3">
							<div class="ub ub-ver">
								<div class="ub" id="mainPage">
									<div class="ub ub-ver ub-f1 uc-a1 c-wh ub-con t-bla uinn3 b-gra uba umar-a weekdata">
										<div class="uhide weekdata_type"></div>
										<div class="ub-f1 ub">
											<div class="ub-f1 ulev-1 t-gra1 tx-l ut-s weekdata_title">订单成交量</div>
											<div class="ub-f1 ulev-2  tx-r ut-s t-org1 weekdata_updown">较上周&#8593;</div>		
										</div>
										<div class="ub-f1 myfont2 tx-c weekdata_total" style="color:#FA8564">50</div>
									</div>
									<div class="ub ub-ver ub-f1 uc-a1 c-wh ub-con t-bla uinn3 b-gra uba umar-a weekdata">
										<div class="uhide weekdata_type"></div>
										<div class="ub-f1 ub">
											<div class="ub-f1 ulev-1 t-gra1 tx-l ut-s weekdata_title">订单成交量</div>
											<div class="ub-f1 ulev-2 t-gre tx-r ut-s weekdata_updown">较上周&#8593;</div>
										</div>
										<div class="ub-f1 myfont2 tx-c weekdata_total">50</div>
									</div>
								</div>
								<div class="ub">
									<div class="ub ub-ver ub-f1 uc-a1 ub-con c-wh t-bla uinn3 b-gra uba umar-l umar-r weekdata">
										<div class="uhide weekdata_type"></div>
										<div class="ub-f1 ub">
											<div class="ub-f1 ulev-1 t-gra1 tx-l ut-s weekdata_title">订单成交量</div>
											<div class="ub-f1 ulev-2 t-gre tx-r ut-s weekdata_updown">较上周&#8593;</div>
										</div>
										<div class="ub-f1 myfont2 tx-c weekdata_total">50</div>
									</div>
									<div class="ub ub-ver ub-f1 uc-a1 ub-con c-wh t-bla uinn3 b-gra uba umar-l umar-r weekdata">
										<div class="uhide weekdata_type"></div>
										<div class="ub-f1 ub">
											<div class="ub-f1 ulev-1 t-gra1 tx-l ut-s weekdata_title">订单成交量</div>
											<div class="ub-f1 ulev-2 t-gre tx-r ut-s weekdata_updown">较上周&#8593;</div>
										</div>
										<div class="ub-f1 myfont2 tx-c weekdata_total">50</div>
									</div>
								</div>
								<div class="ub">
									<div class="ub ub-ver ub-f1 uc-a1 ub-con c-wh c-wh t-bla uinn3 b-gra uba umar-a weekdata">
										<div class="uhide weekdata_type"></div>
										<div class="ub-f1 ub">
											<div class="ub-f1 ulev-1 t-gra1 tx-l ut-s weekdata_title">订单成交量</div>
											<div class="ub-f1 ulev-2 t-org1 tx-r ut-s weekdata_updown">较上周&#8593;</div>
										</div>
										<div class="ub-f1 myfont2 tx-c weekdata_total" style="color:#FA8564">50</div>
									</div>
									<div class="ub ub-ver ub-f1 uc-a1 ub-con  t-bla uinn3 b-gra  umar-a weekdata">
										<div class="uhide weekdata_type"></div>
										<div class="ub-f1 myfont2 tx-c weekdata_total"></div>
										<div class="ub-f1 ub">
											<div class="ub-f1 ulev-1 t-gra tx-l ut-s weekdata_title"></div>
											<div class="ub-f1 ulev-2 t-gra tx-r ut-s weekdata_updown"></div>
										</div>
									</div>
								</div>
								
							<!--</div>-->
							<div class="ub-f1 umar-a uba b-gra uc-a1"id="container">
							</div>
							<div id="zoomUpDiv">
								<div class="res5 lis-sw-2 ub-img" id="closeChart" style="position: absolute;top:.2em;right: .2em;z-index:6"></div>
								<div class="ub ub-fh ub-fv">
									<div class="ub-f1 umar-a"id="bigContainer">
									</div>
								</div>
							</div>  
						</div></div>
					</div>
				</div>
				<div class="uf t-wh c-gra">
			       <div class="ub-f1 tx-c gcdt-list-curo" style="margin:2px 0px; !important;">
			       		<span>&bull;</span>
						<span class="t-org">&bull;</span>
						<span>&bull;</span>
					</div>
			    </div>
	        </div> 
		</div>
		<!--消息-->
		<input class="uhide" type="radio" name="headers" id="ihd1">
		<div class="has-tabs ip-sta" tabindex="0" style="top:0; width:100%; position: absolute;">
			<div class="ub ub-ver ub-fv">
				<div class="uh bar bar-header bar-blue pos-relative">
					<button class="button button-icon icon ion-plus t-wh" id="newpm" onclick="openwin('SendNewPM','modules/PM/');"></button>
			    	<div class="h1 title"><i class="icon ion-loading-a" id="refreshPmIcon"></i>最新消息</div>
					<button class="button button-icon icon ion-compose t-wh" onclick="showDelete()" id="editpm"></button>
				</div>
			
				<div class="ub-f1 t-bla c-gra" id="pmcontent">
					<!--列表开始-->
					<div class="c-gra4" id="pmlist"> 
						<div id="morepm">
						 <ul class="ub b-gra c-m2 t-bla ub-ac lis uinn">    
						 	<li class="lis-icon" style="width:0em"></li>     
						 	<li class="ub-f1 ut-s tx-c myfont c-wh">加载更多...</li>         
						 </ul>    
					  </div> 
					</div>
					<!--列表结束-->
				</div>
			</div>
		</div>
		<!--指令/审批-->
		<input class="uhide" type="radio" name="headers" id="ihd2">
		<div class="has-tabs ip-sta" tabindex="0" style="top:0; width:100%; position: absolute;">
			<div class="ub ub-ver ub-fv">
			<div id="header" class="c-wh" style="padding-bottom:.1em">
				<div class="ub bar bar-header bar-blue pos-relative">
					<button class="button button-icon icon ion-loading-a t-wh" id="refreshCmIcon"></button>	
					<div class="h1 title" >任务列表</div>
					<button class="button button-icon icon ion-plus t-wh" onclick="openwin('fb-command','modules/CommandApprove/');" style="right:5px;"></button>
				</div>
					
				<div class="c-wh uinn7 t-wh">
					<div class="ub ulev-1 t-blu3" >
						<input class="uhide" type="radio" name="list_item_type" id="item_type1" value="0">
						<div class="ub-con1 ubb1 ub-f1 ub-f1 tx-c tp-view uof" ontouchstart="zy_touch('focuss')" onclick="setTypeCommandList(1);" >任务</div>
						<input class="uhide" type="radio" name="list_item_type" checked="true" id="item_type2" value="-1" >
						<div class="ub-con1 ubb1  ub-f1 tx-c tp-view uof" ontouchstart="zy_touch('focuss')" onclick="setTypeCommandList(2);">全部</div>
						<input class="uhide" type="radio" name="list_item_type" id="item_type3" value="1">
						<div class="ub-con1  ubb1  ub-f1 tx-c tp-view uof" ontouchstart="zy_touch('focuss')" onclick="setTypeCommandList(3);" >审批 </div>
					</div>
				</div>
			</div>
				
				<div class="ub-f1 t-bla c-gra4" id="cmcontent">
					<!--列表开始-->
					<div class="c-gra4 uinn" style="padding-top:0;" id="cmlist">
				
						<div id="morecm">
						 <div class="ub umar-t umar-b">
						 	<div class="ub-f1 uinn b-gra uba uc-a1 c-wh t-bla tx-c myfont">加载中...</div>       
						 </div>    
					  </div> 
					</div>
					<!--列表结束-->
				</div>
			</div>
		</div>
		<!--更多-->
		<input class="uhide" type="radio" name="headers" id="ihd3">
		<div class="has-tabs ip-sta c-gra4" tabindex="0" style="top:0; width:100%; position: absolute;">
			<div class="ub ub-ver ub-fv">
				<div class="uh bar bar-header bar-blue pos-relative">
			    	<div class="h1 title">更多操作</div>
				</div>
				<div class="c-gra4 ub-f1 ub" id="moreContent"> 
					<div class="ub ub-f1 ub-ver" >
						<div class="ub-f1 t-bla c-gra4">
							<div class="ub-fh ub-fv ub-ver ub c-gra4">
								<div class="umar-a uc-a1 uba c-wh b-wh" style="margin-top:1.5em">
									<ul class="ub b-gra t-bla uc-a1 act-wh ub-ac lis uinn" onclick="clearCache()">  
										<li class="ub-f1 tx-c myfont">清除缓存数据</li>  
									</ul>
								</div>
								<div class="umar-a uba b-wh c-wh uc-a1" style="margin-top:1.5em">
									<ul class="ub ubb b-gra uc-t1 act-wh t-bla ub-ac lis uinn" onclick="openwin('tsjy','')">  
										<li class="ub-f1 myfont">提交建议</li>
										<li class="res8 lis-sw ub-img"></li>   
									</ul>
									<ul class="ub b-gra uc-b1 act-wh t-bla ub-ac lis uinn" onclick="openwin('about','')">  
										<li class="ub-f1 myfont">关于</li>
										<li class="res8 lis-sw ub-img"></li>   
									</ul>
								</div>
							</div>
						</div>
						<div class="c-gra ub-ac uinn">
							<div class="ub-f1 b-red uc-a1 c-red act-red t-wh" onclick="openpop_logout()">
								<ul class="ub uc-a1 ub-ac lis uinn" >  
									<li class="ub-f1 tx-c myfont">退出当前账号</li>  
								</ul>
							</div>
						</div>
					</div>
				</div>
	         </div>
		</div>
		<!--添加-->
		<div class="ip-sta c-gra4" style="top:0;width:100%;height:100%; position: absolute;display:none;z-index:6">
			<div class="ub ub-ver ub-fv">
				<div class="uh bar bar-header bar-blue pos-relative">
					<button class="button button-icon icon ion-chevron-left t-wh" onclick="closeAddPage()"></button>
			    	<div class="h1 title">添加</div>
				</div>
	        	<div class="ub-f1 ub t-bla c-gra4 uof" style="-webkit-background-size:100%;">
					<div class="ub-fh " id="addPageContent">
						<div id="addPage"></div>
					</div>
				</div>
			</div>
		</div>
		

		
		<!--添加-->
		<div class="ip-sta c-wh" style="top:0;width:100%;height:100%; position: absolute;display:none;z-index:6">
			<div class="ub ub-ver ub-fv">
				<div class="uh bar bar-header bar-dark pos-relative">
					<button class="button button-icon icon ion-chevron-left" onclick="closeCardPage()"></button>
			    	<div class="h1 title">从名片添加客户</div>
					<button class="button button-icon icon ion-help-circled" onclick="openwin('aboutCamcard','');"></button>
				</div>
				<!--列表开始-->
				<div class="c-gra ub-f1 ub" id="cardPageContent"> 
					<div class="ub-f1 ub ub-ver c-wh" id="cardPage">
						<div class="uinn tx-c" id="cardInfo">xxx公司  xx姓名</div>
						<div class="ub-f1 ub ub-ac ub-pc">
							<img src="" id="cardPhoto" style="position: absolute;left:0;top:0;max-width:100%;max-height:100%"/>
						</div>
						<!--块容器开始-->
						<div class="ub">
							<div class="ub-f1 uinn">
							<!--按钮开始-->
							<div ontouchstart="zy_touch('btn-act');" onclick="goToAddPage('account')" id="asCompanyAccount" class="btn uinn5 uc-a1 uba t-wh tx-c outline-positive">添加为客户</div>
							<!--按钮结束-->
							</div>
							<div class="ub-f1 uinn">
							<!--按钮开始-->
							<div ontouchstart="zy_touch('btn-act');" onclick="goToAddPage('contact')" id="asAccountContact" class="btn uinn5 uc-a1 uba t-wh tx-c outline-positive">添加为联系人</div>
							<!--按钮结束-->
							</div>
						</div>
						<!--块容器结束-->
					</div>
				</div>
				<!--列表结束-->
			</div>
		</div>
		<!--content结束--> 

	   <!--footer开始-->
	   <!--iPhone导航条开始-->
	   <div class="tabs ">
	<div class=" ub c-wh  tab ub-fh t-gra" style="padding:0;height:3em">	
	 	<input class="uhide" type="radio" name="tabSwitch" checked="true">
		<div ontouchstart="zy_touch('',zy_for)" onclick="goToPage(0);" class="ub-f1 ub ub-ver tab-act" style="padding-top:.2em;">
				<div class="ub-f1 ub-img5 tp-menuhome"></div><div class="uinn3 ulev-2 tx-c">工作台</div></div>
	 <input class="uhide" type="radio" name="tabSwitch">
		<div ontouchstart="zy_touch('',zy_for)" onclick="goToPage(1);" class="ub-f1 ub ub-ver tab-act" style="padding-top:.2em;">
			<div class="ub-f1 ub-img5 tp-menunews"></div><div class="uinn3 ulev-2 tx-c">消息</div></div>
		<input class="uhide" type="radio" name="tabSwitch">
		<div ontouchstart="zy_touch('',zy_for)" onclick="openpop();" class="ub-f1 ub ub-ver tab-act c-blu3" style="padding:.3em">
			<div class="ub-f1  tp-menuplus ub-img5"></div><div class="uinn3 tx-c"></div></div>
		<input class="uhide" type="radio" name="tabSwitch">
		<div ontouchstart="zy_touch('',zy_for)" onclick="goToPage(2);" class="ub-f1 ub ub-ver tab-act" style="padding-top:.2em;">
			<div class="ub-f1 ub-img5 tp-menumy"></div>
			<div class="uinn3 ulev-2 tx-c">协同</div></div>
		<input class="uhide" type="radio" name="tabSwitch">
		<div ontouchstart="zy_touch('',zy_for)" onclick="goToPage(3);" class="ub-f1 ub ub-ver tab-act" style="padding-top:.2em;">
			<div class="ub-f1 ub-img5 tp-menumore"></div>
			<div class="uinn3 ulev-2 tx-c">更多</div></div>
	</div>
</div>
    </body>
<script type="text/javascript">
    var ifscroll = false;
    var ifscroll2 = false;
</script>
<script src="js/dy_upload.js"></script>
<!--script src="js/vcard.js"></script>
<script src="js/vcf.js"></script-->
<script>
    zy_init();
    var myCard = null;
    var cardData = null;
    var attachdel = [];
    var oldsrc = '';

    function goToAddPage(type) {
        if (isDefine(cardData) && type == 'account') {
            setstorage('cardData', cardData);
            openCreatePage('account', '');
        } else if (isDefine(cardData) && type == 'contact') {
            setstorage('thePage', 'Home');
            setstorage('cardData', cardData);
            openCreatePage('contact', '');
        } else {
            myalert('识别的信息有误啊，没有客户名称或者联系人名称');
        }
    }

    function actCb(val) {
        //logs('actCb()-->val='+val);
    }

    function susCb(val) {
        if (oldsrc != '') {
            attachdel.push(oldsrc);
        }
        oldsrc = val;
        $$('thepic').src = myUpload.src;
    }

    function viewImg() {
        var array = [];
        array[0] = $$('thepic').src;
        uexImageBrowser.open(array);
    }

    var tabins;
    //设置可滚动
    var flag1 = "";
    var flag4 = '';
    var flag8 = '';
    var s1 = new iScroll("picFlip", { "onScrollMove": function () { }, "onScrollEnd": function () { ifscroll = true } });
    var s2 = new iScroll("picFlip2", { "onScrollMove": function () { }, "onScrollEnd": function () { ifscroll2 = true } });
    var s3 = new iScroll("picFlip3", { "onScrollMove": function () { }, "onScrollEnd": function () { } });
    var s4 = new iScroll("pmcontent", {
        "onScrollMove": function () {
            if (this.y > 60) {
                flag4 = "up";
            }
        },
        "onScrollEnd": function () {
            if (flag4 == "up") {
                page_pm_offset = 1;
                //pmobj.GetListDataFromServer();
            }
            flag4 = "";
        }
    });
    var s5 = new iScroll("addPageContent", { "onScrollMove": function () { }, "onScrollEnd": function () { } });
    var s7 = new iScroll("moreContent", { "onScrollMove": function () { }, "onScrollEnd": function () { } });
    var s8 = new iScroll("cmcontent", {
        "onScrollMove": function () {
            if (this.y > 60) {
                flag8 = "up";
            }
        }, "onScrollEnd": function () {
            if (flag8 == "up") {
                page_cm_offset = 1;
               // cmobj.GetListDataFromServer();
            }
            flag8 = "";
        }
    });

    function refrashCm() {
        page_cm_offset = 1;
       // cmobj.GetListDataFromServer();
    }

    //function openHomePage(){//ligangze
    //	var logindata = getstorage('crmloginInfo');
    //	if (isDefine(logindata)) {
    //		var dataobj = JSON.parse(logindata);
    //		
    //		//alert($$('currentuser'));
    //		$('#currentuser').html(dataobj.currentuser);
    //		$('#companyname').html(dataobj.companyname);
    //		if (dataobj.userphoto != '') {
    //			$('#userphoto').attr("src",dataobj.userphoto);
    //		}
    //	}
    //}

</script>
</html>
