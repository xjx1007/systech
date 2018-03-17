<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=0" />

    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <link href="assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" href="themes/softed/style.css" type="text/css" />
    <link rel="stylesheet" href="themes/softed/index.css" type="text/css" />
    <link rel="stylesheet" href="assets/css/fontawesome/font-awesome.min.css">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700' rel='stylesheet' type='text/css'>
    <script type="text/javascript" src="assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="plugins/jquery-ui/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/libs/lodash.compat.min.js"></script>
    <script type="text/javascript" src="plugins/touchpunch/jquery.ui.touch-punch.min.js"></script>
    <script type="text/javascript" src="plugins/event.swipe/jquery.event.move.js"></script>
    <script type="text/javascript" src="plugins/event.swipe/jquery.event.swipe.js"></script>
    <script type="text/javascript" src="assets/js/libs/breakpoints.js"></script>
    <script type="text/javascript" src="plugins/respond/respond.min.js"></script>
    <script type="text/javascript" src="plugins/cookie/jquery.cookie.min.js"></script>
    <script type="text/javascript" src="plugins/slimscroll/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="plugins/slimscroll/jquery.slimscroll.horizontal.min.js"></script>
    <!--[if lt IE 9]><script type="text/javascript" src="plugins/flot/excanvas.min.js"></script><![endif]-->
    <script type="text/javascript" src="plugins/sparkline/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="plugins/daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="plugins/daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="plugins/blockui/jquery.blockUI.min.js"></script>
    <script type="text/javascript" src="plugins/fullcalendar/fullcalendar.min.js"></script>
    <script type="text/javascript" src="plugins/uniform/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="assets/js/app.js"></script>
    <script type="text/javascript" src="assets/js/plugins.js"></script>
    <script type="text/javascript" src="assets/js/plugins.form-components.js"></script>
    
    <script type="text/javascript" src="themes/js/tree.js" ></script>
    <script type="text/javascript" src="themes/js/treeview.js" ></script>
    <script>$(document).ready(function () { App.init(); Plugins.init(); FormComponents.init() });</script>
    
    <title>杭州士腾科技有限公司</title>
</head>
<body class="theme-bright breakpoint-1200">
    <form runat="server">
    <header class="header navbar navbar-fixed-top" role="banner">
        <div class="container">
            <ul class="nav navbar-nav">
                <li class="nav-toggle"><a href="javascript:void(0);" title=""><i class="icon-reorder"></i></a></li>
            </ul>
            <a class="navbar-brand" href="inc/NewDesk.aspx" target="main">
                <img src="assets/img/logo.png" alt="logo">
                <strong>SYSTEM</strong> </a><a href="#" class="toggle-sidebar bs-tooltip" data-placement="bottom" data-original-title="关闭左边菜单"><i class="icon-reorder"></i></a>
            <ul class="nav navbar-nav navbar-left hidden-xs hidden-sm">
                <li><a href="inc/NewDesk.aspx" target="main">工作台 </a></li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                
                <asp:TextBox runat="server" ID="Tbx_UserID" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox runat="server" ID="Tbx_CompanyName" CssClass="Custom_Hidden"></asp:TextBox>
       
                <li class="dropdown user"><a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="icon-male"></i><span class="username"><%=s_Person %></span> <i class="icon-caret-down small"></i></a>
                    <ul class="dropdown-menu">
                        <li><a href="inc/UpdatePassword.aspx" target="main"><i class="icon-user"></i>修改密码</a></li>
                        <li><a href="Web/PhoneMessage/System_PhoneMessage_Manage.aspx" target="main"><i class="icon-phone"></i>手机短信</a></li>
                        <li><a href="Web/Message/System_Message_List.aspx?Type=unread" target="main"><i class="icon-envelope"></i>短消息</a></li>
                        <li class="divider"></li>
                        <li><asp:LinkButton runat="server" ID="LogOut" Text="退出" OnClick="LogOut_Click"></asp:LinkButton></li>
                    </ul>
                </li>
            </ul>
        </div>
        <div id="project-switcher" class="container project-switcher" style="position: relative; margin-top: 0px; display: none;">
            <div id="scrollbar">
                <div class="handle"></div>
            </div>
            <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: 100%; height: auto;">
                <div id="frame" style="overflow: hidden; width: 100%; height: auto;">
                    <ul class="project-list" style="width: 2712px;">
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-desktop"></i></span><span class="title">Lorem ipsum dolor</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-compass"></i></span><span class="title">Dolor sit invidunt</span> </a></li>
                        <li class="current"><a href="javascript:void(0);"><span class="image"><i class="icon-male"></i></span><span class="title">Consetetur sadipscing elitr</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-thumbs-up"></i></span><span class="title">Sed diam nonumy</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-female"></i></span><span class="title">At vero eos et</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-beaker"></i></span><span class="title">Sed diam voluptua</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-desktop"></i></span><span class="title">Lorem ipsum dolor</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-compass"></i></span><span class="title">Dolor sit invidunt</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-male"></i></span><span class="title">Consetetur sadipscing elitr</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-thumbs-up"></i></span><span class="title">Sed diam nonumy</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-female"></i></span><span class="title">At vero eos et</span> </a></li>
                        <li><a href="javascript:void(0);"><span class="image"><i class="icon-beaker"></i></span><span class="title">Sed diam voluptua</span> </a></li>
                    </ul>
                </div>
                <div class="slimScrollBar ui-draggable" style="height: 5px; position: absolute; bottom: 1px; opacity: 0.2; display: block; border-radius: 5px; z-index: 99; background: rgb(255, 255, 255);"></div>
                <div class="slimScrollRail" style="width: 100%; height: 5px; position: absolute; bottom: 1px; display: none; border-radius: 5px; opacity: 0.2; z-index: 90; background: rgb(51, 51, 51);"></div>
            </div>
        </div>
    </header>

    <div id="container" class="fixed-header">
        <div id="sidebar" class="sidebar-fixed">
            <div id="sidebar-content">
                <ul id="nav">                    
                    <%=s_LeftMenu %>
                </ul>
            </div>
            <div id="divider" class="resizeable"></div>
        </div>
        <div id="content" >
            
        <iframe style="width: 100%;height: 100%; min-height:582px" id="main" name="main" marginheight="0"
            src="inc/NewDesk.aspx" frameborder="0"></iframe>

        </div>
    </div>
    <footer class="bottom navbar-fixed-bottom">
        
    <script type="text/javascript" src="themes/js/jquery/jquery.ui.autocomplete.min.js"></script>
    <script type="text/javascript" src="themes/js/jquery/jquery.effects.bounce.min.js"></script>
    <script type="text/javascript" src="themes/js/jquery/jquery.plugins.js"></script>
    <script type="text/javascript" src="themes/js/index.js"></script>
    <script>
        //var bTabStyle = true;
        //var menuExpand = "";
        //var shortcutArray = Array(1,4,147,8,130,5,131,9,16,15,76,62);
        //var logoutText = "轻轻的您走了，正如您轻轻的来……";
        //var ispirit = "";
        var monInterval = 1;
        var show_ip = 1;
        var loginUser = <%=loginUser %>;
        var unit_name = '士腾科技';
        var newSmsHtml = "<div onclick='show_sms();' title='点击查看短信'><img src='/images/sms1.gif'A border='0' height='12'> 新短信</div>";
        var onlineTree = null;
        var statusTextScroll = 60;
        var monInterval = { online: 120, sms: 60 };
        var orgTree = new Tree("orgTree", 'themes/js/attachment/AllUserXML.ashx');
        var newSmsSoundHtml = "<object id='sms_sound' classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='themes/swflash.cab' width='0' height='0'><param name='movie' value='themes/wav/1.swf'><param name=quality value=high><embed id='sms_sound' src='themes/wav/1.swf' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>";
    </script>
            <div id="south">
            <table>
                <tr>
                    <td class="left">
                        <div onclick="ViewOnlineUser()">
                            共<span id="user_count"><asp:Label runat="server" ID="Lbl_UserCount"></asp:Label></span>人在线
                        </div>
                    </td>
                    <td class="left">
                        <div id="new_sms">
                        </div>
                        <span id="new_sms_sound" style="width: 1px; height: 1px;"></span>
                    </td>
                    <td class="center">
                        <div id="status_text">
                            <br>
                        </div>
                    </td>
                    <td  class="right">
                        <div onclick="show_feedback()"  title="将问题提交给技术进行解决">
                          <a href="#">问题反馈</a>  
                        </div>
                    </td>
                    <script language="javascript">
                        
                        function show_feedback() {
                            mytop = (screen.availHeight - 430) / 4;
                            myleft = (screen.availWidth - 600) / 4;
                            window.open("Web/feedback/feedback_Add.aspx", "", "height=700,width=900,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top=" + mytop + ",left=" + myleft + ",resizable=yes");
                        }
                    </script>
                    <td class="right">
                        <a id="smsbox" class="ipanel_tab" href="javascript:;" panel="smsbox_panel" title="短信箱"
                            hidefocus="hidefocus"></a><a id="org" class="ipanel_tab" href="javascript:;" panel="org_panel"
                                title="组织" hidefocus="hidefocus"></a>
                    </td>
                </tr>
            </table>
        </div>

             <div id="start_menu_panel">
            <div class="panel-head">
            </div>
            <!-- 登录用户信息 -->
            <div class="panel-user">
                <div class="avatar">
                    <img src="/images/avatar/0.gif" align="absmiddle" />
                    <div class="status_icon status_icon_1">
                    </div>
                    <div id="on_status">
                        <a href="javascript:;" status="1" class="on_status_1" hidefocus="hidefocus">在线</a>
                        <a href="javascript:;" status="2" class="on_status_2" hidefocus="hidefocus">忙碌</a>
                        <a href="javascript:;" status="3" class="on_status_3" hidefocus="hidefocus">离开</a>
                    </div>
                </div>
                <div class="name" title="部门：研发中心
角色：OA 管理员">
                    系统管理员
                </div>
                <div class="tools">
                    <a class="logout" href="javascript:;" onclick="logout();" hidefocus="hidefocus" title="注销"></a><a class="exit" href="javascript:;" onclick="exit();" hidefocus="hidefocus" title="退出"></a>
                </div>
            </div>
            <div class="panel-menu">
                <!-- 一级菜单 -->
                <div id="first_panel">
                    <div class="scroll-up">
                    </div>
                    <ul id="first_menu">
                    </ul>
                    <div class="scroll-down">
                    </div>
                </div>
                <!-- 二级级菜单 -->
                <div id="second_panel">
                    <div class="second-panel-head">
                    </div>
                    <div class="second-panel-menu">
                        <ul id="second_menu">
                        </ul>
                    </div>
                    <div class="second-panel-foot">
                    </div>
                </div>
            </div>
            <div class="panel-foot">
            </div>
        </div>
        <div id="overlay_startmenu">
        </div>
        <!-- 短信提醒 -->
        <div id="new_sms_mask">
        </div>
        <div id="new_sms_panel">
            <div class="buttonMsn">
                <a class="btn-white-big" href="javascript:;" onclick="ViewNewSms();" hidefocus="hidefocus">打开</a>&nbsp;&nbsp; <a class="btn-white-big" href="javascript:;" onclick="CloseRemind();"
                    hidefocus="hidefocus">关闭</a>
            </div>
        </div>
        <!-- 短信箱 -->
        <div id="smsbox_panel" class="dialog">
            <div class="head">
                <div class="head-left">
                </div>
                <div class="head-center">
                    <div class="head-title">
                        短信箱
                    </div>
                    <div class="head-close">
                    </div>
                </div>
                <div class="head-right">
                </div>
            </div>
            <div class="center">
                <div class="center-left">
                    <div class="center-group">
                        <a href="javascript:;" id="group_by_name" class="active" hidefocus="hidefocus">按姓名分组</a>
                        <a href="javascript:;" id="group_by_type" hidefocus="hidefocus">按类型分组</a>
                    </div>
                    <div id="smsbox_scroll_up">
                    </div>
                    <div id="smsbox_list">
                        <div id="smsbox_list_container" class="list-container">
                        </div>
                    </div>
                    <div id="smsbox_scroll_down">
                    </div>
                    <div id="smsbox_op_all">
                        <a href="javascript:;" id="smsbox_read_all" hidefocus="hidefocus">全部已阅</a> <a href="javascript:;"
                            id="smsbox_detail_all" hidefocus="hidefocus">全部详情</a> <a href="javascript:;" id="smsbox_delete_all"
                                hidefocus="hidefocus">全部删除</a>
                    </div>
                </div>
                <div class="center-right">
                    <div class="center-toolbar">
                        <a href="javascript:;" id="smsbox_toolbar_read" hidefocus="hidefocus" title="已阅以下短信">已阅</a> <a href="javascript:;" id="smsbox_toolbar_detail" hidefocus="hidefocus" title="查看以下短信详情">详情</a> <a href="javascript:;" id="smsbox_toolbar_delete" hidefocus="hidefocus" title="删除以下短信">删除</a>
                    </div>
                    <div id="smsbox_msg_container" class="center-chat">
                    </div>
                    <div class="center-reply">
                        <textarea id="smsbox_textarea"></textarea>
                        <a id="smsbox_send_msg" href="javascript:;" hidefocus="hidefocus">发送</a>
                    </div>
                </div>
                <div id="smsbox_tips" class="center-tips">
                </div>
                <div id="no_sms">
                    <div class="no-msg" title="暂无新短信">
                        <a class="btn-white-big" href="javascript:;" onclick="jQuery('#smsbox').click();"
                            hidefocus="hidefocus">关闭</a>&nbsp;&nbsp; <a class="btn-white-big" href="javascript:;"
                                onclick="send_sms('', '');jQuery('#smsbox').click();" hidefocus="hidefocus">写短信</a>
                    </div>
                </div>
            </div>
            <div class="foot">
                <div class="foot-left">
                </div>
                <div class="foot-center">
                </div>
                <div class="foot-right">
                </div>
            </div>
            <div class="corner">
            </div>
        </div>
        <!-- 组织机构 -->
        <div id="org_panel" class="ipanel">
            <div class="head">
                <div class="left">
                    <a href="javascript:;" onclick="ActiveUserTab(this)" id="user_online_tab" class="active"
                        hidefocus="hidefocus"><span>
                            <img src="web/images/user_list3/user.png" align="absMiddle">
                            在线</span></a>
                </div>
                <div class="right">
                    <a href="javascript:;" onclick="ActiveUserTab(this)" id="user_all_tab" hidefocus="hidefocus"><span>
                        <img src="web/images/user_list3/group.png" align="absMiddle">
                        全部</span></a>
                </div>
            </div>
            <div class="center">
                <div class="top">
                    <div id="user_online">
                        <div id="onlineTree">
                        </div>
                    </div>
                    <div id="user_all" style="display: none;">
                        <div id="orgTree">
                        </div>
                    </div>
                </div>
                <div class="bottom">
                    <a class="btn-white-b" href="javascript:;" onclick="SearchUser();" hidefocus="hidefocus">人员查询</a>&nbsp;&nbsp; <a class="btn-white-b" href="javascript:;" onclick="jQuery('#org').click();"
                        hidefocus="hidefocus">关闭</a>
                </div>
            </div>
            <div class="foot">
                <div class="left">
                </div>
                <div class="right">
                </div>
            </div>
            <div class="corner">
            </div>
        </div>
        <div id="overlay">
        </div>
    </footer>
        </form>
</body>
</html>
