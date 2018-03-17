<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="KnetWork_DefaultLoging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
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
    <script type="text/javascript" src="js/Application.js"></script>
</head>
<body class="um-vp uof" style="height: 100%; overflow: hidden;" ontouchstart>
    <form runat="server">
        <!--登陆页面-->
        <div class="c-gra4" style="top: 0; width: 100%; height: 100%; position: absolute; z-index: 11">
            <div class="ub ub-ver ub-fv">
                <div class="uh bar bar-header bar-blue pos-relative">
                    <div class="h1 title">士腾电子工作平台</div>
                </div>
                <div class="ub-f1 ub " id="loginContent">
                    <div id="loading" style="display: none;"></div>
                    <div class="ub-f1 tx-l c-gra4 uinn t-bla">
                        <!--块容器开始-->
                        <div class="ub ub-ver uba b-gra uc-a1 t-gra1 c-wh ">
                            <div class="ubb b-gra ub uinn ulab ub-ac uc-t1">
                                账号&nbsp;
								<!--文本开始-->
                                <div class="ub-f1 uinput uinn4">
                                    <asp:TextBox ID="UserName" runat="server" CssClass="uc-a1" Text="Xiangz" placeholder="用户名"></asp:TextBox>
                                </div>
                                <!--文本结束-->
                            </div>
                            <div class="ubb b-gra ub uinn ulab ub-ac ">
                                密码&nbsp;
								<div class="ub-f1 uinput uinn4">
                                    <asp:TextBox ID="Password" TextMode="Password" runat="server" CssClass="uc-a1" Text="111222" placeholder="密码"></asp:TextBox>

                                </div>
                            </div>
                            <div class="uinn uc-b1 ub ulab ub-ac ">
                                链接&nbsp;
								<div class="ub-f1 uinput uinn4">
                                    <asp:TextBox ID="Address" runat="server" CssClass="uc-a1" Text="http://115.238.88.226:88" placeholder="地址"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <!--块容器结束-->

                        <div class="ub ">
                                <!--复选框开始-->
                                <asp:CheckBox runat="server" ID="crmcheckbox_rem" />
                                    <span id="Settingsisremember_pwd">记住密码</span>
                                <!--复选框结束-->
                                <!--复选框开始-->
                                <asp:CheckBox runat="server" ID="crmcheckbox_auto"  />
                                    <span id="Settingsisautologin">自动登录</span>
                                <!--复选框结束-->
                        </div>
                        <asp:Label ID="BackMess" runat="server" ForeColor="Red"></asp:Label>
                        <a class="btnLogin">
                            <asp:Button ID="ImageButton1" runat="server" ImageUrl="~/images/x.gif"
                                OnClick="ImageButton1_Click" Style="background-color: #5097CD; top: 0px; left: 0px; height: 55px; width: 100%;" CssClass="button button-block button-positive" Text="登录" /></a>

                    </div>
                </div>
                <div class="uf">
                    <div class="ub-f1 ut tx-c ulev-1" tabindex="0" style="color: #676e74">
                        版权所有
			            <br />
                        Copyright ©2015-2017 杭州士腾软件有限公司
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
