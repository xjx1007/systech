<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signin.aspx.cs" Inherits="Signin" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/main.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/login.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="assets/css/fontawesome/font-awesome.min.css">
    <!--[if IE 7]><link rel="stylesheet" href="assets/css/fontawesome/font-awesome-ie7.min.css"><![endif]-->
    <!--[if IE 8]><link href="assets/css/ie8.css" rel="stylesheet" type="text/css"/><![endif]-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700' rel='stylesheet' type='text/css'>
    <script type="text/javascript" src="assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/libs/lodash.compat.min.js"></script>
    <!--[if lt IE 9]><script src="assets/js/libs/html5shiv.js"></script><![endif]-->
    <script type="text/javascript" src="plugins/uniform/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="plugins/validation/jquery.validate.min.js"></script>
    <script type="text/javascript" src="plugins/nprogress/nprogress.js"></script>

    <script type="text/javascript">

        window.onload = function () {
            debugger; 
                $.ajax({
                    url: 'http://192.168.0.47/Verification_IP.ashx',
                    type: 'Get',
                    data: {
                        id: "Verification"
                    },
                    success: function (mes) {
                        //alert(mes);
                        if (mes === "Verification_True") {
                            document.all("Verification").value = "true";
                            document.getElementById("Weixin").style.display = "none";
                        } else {
                            document.all("Verification").value = "false";
                            document.getElementById("Weixin").style.display = "block";
                        }
                    },
                    error: function (mes) {
                        //console.log(mes);
                        document.all("Verification").value = "false";
                        document.getElementById("Weixin").style.display = "block";
                    }
                });
            }

        //function but_ip() {
        //    document.all("Verification").value = "false";
        //    document.getElementById("Weixin").style.display = "block";
        //    return true;
        //}
        
        function browserRedirect() {
            debugger;
            var sUserAgent = navigator.userAgent.toLowerCase();
            var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
            var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
            var bIsMidp = sUserAgent.match(/midp/i) == "midp";
            var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
            var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
            var bIsAndroid = sUserAgent.match(/android/i) == "android";
            var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
            var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
            if (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM) {
                document.all("tbx").value = "1";
            } else {
            }
        }
        var countdown = 60;
        function settime(val) {
            debugger;
            if (document.all("username").value == "") {
                alert("用户名不能为空");
                return;
            } else {

            }
            if (countdown == 0) {
                val.removeAttribute("disabled");
                val.value = "发  送";

            } else {
                val.setAttribute("disabled", true);
                val.value = "重新发送(" + countdown + ")";
                countdown--;
                setTimeout(function () {
                        settime(val);
                    },
                    1000);
            }

        }
        //history.pushState(null, null, document.URL);
        //window.addEventListener('popstate', function () {
        //    history.pushState(null, null, document.URL);
        //});
        function checkpassword() {
            var numasc = 0;
            var charasc = 0;
            var otherasc = 0;
            var v = document.all("password").value;
            if (0 == v.length) {
                alert("密码不能为空");
                return false;
            } else if (v.length < 8 || v.length > 30) {
                alert("密码错误！请重新登录！！");
                return false;
            } else {
                for (var i = 0; i < v.length; i++) {
                    var asciiNumber = v.substr(i, 1).charCodeAt();
                    if (asciiNumber >= 48 && asciiNumber <= 57) {
                        numasc += 1;
                    }
                    if ((asciiNumber >= 65 && asciiNumber <= 90) || (asciiNumber >= 97 && asciiNumber <= 122)) {
                        charasc += 1;
                    }
                    if ((asciiNumber >= 33 && asciiNumber <= 47) || (asciiNumber >= 58 && asciiNumber <= 64) || (asciiNumber >= 91 && asciiNumber <= 96) || (asciiNumber >= 123 && asciiNumber <= 126)) {
                        otherasc += 1;
                    }
                }
                if (0 == numasc) {
                    alert("密码错误！请重新登录！！");
                    return false;
                } else if (0 == charasc) {
                    alert("密码错误！请重新登录！！");
                    return false;
                } else if (0 == otherasc) {
                    alert("密码错误！请重新登录！！");
                    return false;
                } else {
                    return true;
                }
            }
        };
    </script>
    <title>杭州士腾科技有限公司</title>
</head>

<body class="login">
    <div class="logo">
        <img src="assets/img/logo.gif" alt="logo" />
        <strong>士腾科技</strong>
    </div>

    <div class="box">
        <div class="content">
            <form id="form1" runat="server">
                <%-- <table border="0" cellspacing="0" cellpadding="0" id="form1" runat="server">--%>
                <h3 class="form-title">登录</h3>
                <div class="alert fade in alert-danger" style="display: none;"><i class="icon-remove close" data-dismiss="alert"></i>请输入用户名和密码. </div>
                <asp:Label ID="BackMess" CssClass="alert fade in alert-danger" runat="server" Text="" Visible="false"></asp:Label>
                <input type="text" runat="server" id="Verification" style="display: none" value="false" />
                <div class="form-group">
                    <div class="input-icon">
                        <i class="icon-user"></i>
                        <!--<input type="text" name="username" class="form-control" placeholder="用户名" autofocus="autofocus" data-rule-required="true" data-msg-required="请输入用户名." />-->
                        <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="用户名" Text="" data-rule-required="true" data-msg-required="请输入用户名."></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-icon">
                        <i class="icon-lock"></i>
                        <!--<input type="password" name="password" class="form-control" placeholder="密码" data-rule-required="true" data-msg-required="请输入密码." />-->
                        <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" Text="" placeholder="密码" data-rule-required="true" data-msg-required="请输入密码."></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" runat="server" id="Weixin" style="display: block">
                    <asp:TextBox ID="Tbx_Weixin" Text="" placeholder="获取微信验证码" runat="server" Width="150px"></asp:TextBox>&nbsp;&nbsp;
                            <asp:Button ID="Button2" type="button" runat="server" Text="获  取" class="crmbutton small save"
                                Style="width: 90px; height: 30px"  OnClick="Button2_OnClick" />
                </div>
                <div class="form-actions">

                    <input type="hidden" class="uniform" runat="server" id="tbx" name="tbx" />
                    <input id="hiddenTest" type="hidden" value="<%= GetToken() %>" name="hiddenTestN" />
                    <!--<label class="checkbox pull-left">
                        <input type="checkbox" class="uniform" name="remember">
                        记住我</label>-->
                    <!--<button type="submit" class="submit btn btn-primary pull-right">登录 <i class="icon-angle-right"></i></button>-->
                    <asp:Button ID="btnSignIn" CssClass="submit btn btn-primary pull-right" runat="server" Text="登录 >>" OnClientClick="return checkpassword()" OnClick="btnSignIn_Click" />
                </div>
                <%--</table>--%>
            </form>
        </div>
        <div class="inner-box">
            <div class="content">
                杭州士腾科技有限公司
                <!--<i class="icon-remove close hide-default"></i>&nbsp;
                <a href="#" class="forgot-password-link">忘记密码？</a>
                <form class="form-vertical forgot-password-form hide-default" action="login.html" method="post">
                    <div class="form-group">
                        <div class="input-icon"><i class="icon-envelope"></i>
                            <input type="text" name="email" class="form-control" placeholder="Enter email address" data-rule-required="true" data-rule-email="true" data-msg-required="Please enter your email." />
                        </div>
                    </div>
                    <button type="submit" class="submit btn btn-default btn-block">重置密码 </button>
                </form>
                <div class="forgot-password-done hide-default"><i class="icon-ok success-icon"></i><span>Great. We have sent you an email.</span> </div>
            </div>-->
            </div>
        </div>
        <!--<div class="footer"><a href="#" class="sign-up"> <strong>现在注册</strong></a> </div>
        
        <script>$(document).ready(function () { Login.init() });</script>
        -->
    </div>
</body>
</html>
