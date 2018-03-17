<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewMain.aspx.cs" Inherits="Knetwork_Admin_NewMain" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>杭州士腾科技有限公司</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="themes/softed/style.css" type="text/css" />
    <link rel="stylesheet" href="themes/softed/index.css" type="text/css" />
    <script type="text/javascript" src="themes/js/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="themes/js/jquery/jquery-ui.custom.min.js"></script>
    <script type="text/javascript" src="themes/js/jquery/jquery.ui.autocomplete.min.js"></script>
    <script type="text/javascript" src="themes/js/jquery/jquery.effects.bounce.min.js"></script>
    <script type="text/javascript" src="themes/js/jquery/jquery.plugins.js"></script>
    <script language="javascript" type="text/javascript" src="include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="include/scriptaculous/dom-drag.js"></script>
    <script language="text/javascript" type="text/javascript" src="themes/js/index.js" charset="gb2312"></script>
    <script language="text/javascript" type="text/javascript" src="themes/js/tree.js" charset="gb2312"></script>
    <script language="text/javascript" type="text/javascript" src="themes/js/treeview.js" charset="gb2312"></script>
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
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="hdrNameBg">
                <tr>
                    <td valign="top"  height="30">
                        <a href="http://www.systech.com.cn/" target="_blank">
                          </a>
                    </td>
                    <td width="100%" align="center"></td>
                    <td class="small" nowrap>
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td id="Td3" style="padding-left: 10px; padding-right: 10px" class="small" nowrap>
                                    <a href="inc/UpdatePassword.aspx" target="main">修改密码</a>
                                </td>
                                <td id="Td2" style="padding-left: 10px; padding-right: 10px" class="small" nowrap>
                                    <a href="Web/PhoneMessage/System_PhoneMessage_Manage.aspx" target="main">手机短信</a>
                                </td>
                                <td id="Td1" style="padding-left: 10px; padding-right: 10px" class="small" nowrap>
                                    <a href="Web/Message/System_Message_List.aspx?Type=unread" target="main">短消息</a>
                                </td>
                                <td style="padding-left: 10px; padding-right: 10px" class="small" nowrap>
                                    <asp:LinkButton runat="server" ID="LogOut" Text="退出" OnClick="LogOut_Click"></asp:LinkButton>
                                    (<%=s_Person %>)
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="hdrTabBg">
            <tr>
                <td class="Menu">&nbsp;
                <asp:TextBox runat="server" ID="Tbx_UserID" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox runat="server" ID="Tbx_CompanyName" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td class="Menu" nowrap>
                    <%=s_FirstMenu%>
                </td>
                <td align="right" class="Menu" style="padding-right: 10px">
                    <table border="0" cellspacing="0" cellpadding="0" id="search" style="border: 1px solid #999999; background-color: white">
                        <tr>
                            <form name="UnifiedSearch" method="post" action="NewMain.aspx" style="margin: 0px">
                                <td style="height: 19px; background-color: #ffffef">
                                    <input type="hidden" name="action" value="UnifiedSearch" style="margin: 0px"><!--AccountSearch-->
                                    <input type="hidden" name="module" value="Home" style="margin: 0px">
                                    <input type="text" name="query_string" id="query_string" value="支持客户名称..." class="searchBox"
                                        onfocus="this.value=''">
                                </td>
                                <td style="background-color: #cccccc">
                                    <input type="button" onclick="parent.main.location.href='web/Customer/KNet_Sales_ClientList_Manger.aspx?KeyWords='+document.all('query_string').value;" class="searchBtn" value="客户查找" alt="客户查询支持客户名称、完整的客户编号、手机号码、电话号码、传真号码、Email和QQ"
                                        title="客户查询支持客户名称、完整的客户编号、手机号码、电话号码、传真号码、Email和QQ">
                                </td>
                            </form>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%=s_SenMenu %>
        <%=s_DropMenu%>
        <iframe style="width: 100%; height: 37px" id="top" name="top" marginheight="0" src="NewTop.aspx"
            frameborder="0"></iframe>
        <iframe style="width: 100%;" id="ShowMain" name="main" marginheight="0"
            src="inc/NewDesk.aspx" frameborder="0"></iframe>
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
                    <script language="javascript">
                        function show_feedback() {
                            mytop = (screen.availHeight - 430) / 4;
                            myleft = (screen.availWidth - 600) / 4;
                            window.open("Web/feedback/feedback_Add.aspx", "", "height=700,width=900,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top=" + mytop + ",left=" + myleft + ",resizable=yes");
                        }
                    </script>
                    <td style="cursor: hand;" class="right">
                        <div onclick="show_feedback()" title="将问题提交给技术进行解决">
                            问题反馈
                        </div>
                    </td>
                    <td class="right">
                        <a id="smsbox" class="ipanel_tab" href="javascript:;" panel="smsbox_panel" title="短信箱"
                            hidefocus="hidefocus"></a><a id="org" class="ipanel_tab" href="javascript:;" panel="org_panel"
                                title="组织" hidefocus="hidefocus"></a>
                    </td>
                </tr>
            </table>
        </div>
        <!-- 导航菜单 -->
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
        <!-- 短信提醒 -->        '
        <div id="new_sms_mask">   
        </div>
        <div id="new_sms_panel">
            <div id="new_sms_container">
                <div class="buttonMsn">
                    <a class="btn-white-big" href="javascript:;" onclick="ViewNewSms();" hidefocus="hidefocus">打开</a>&nbsp;&nbsp; <a class="btn-white-big" href="javascript:;" onclick="CloseRemind();"
                        hidefocus="hidefocus">关闭</a>
                </div>
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
    </form>
</body>
<script language="text/javascrip" type="text/javascript" src="include/js/general.js"></script>
</html>
