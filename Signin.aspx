<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signin.aspx.cs" Inherits="Signin" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=0"/>
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
    <title>杭州士腾科技有限公司</title>
</head>
    
<body class="login">
    <div class="logo">
        <img src="assets/img/logo.gif" alt="logo" />
        <strong>士腾科技</strong> </div>
    <div class="box">
        <div class="content">
            <form class="form-vertical login-form" id="form1" runat="server">
                <h3 class="form-title">登录</h3>
                <div class="alert fade in alert-danger" style="display: none;"><i class="icon-remove close" data-dismiss="alert"></i>请输入用户名和密码. </div>
                <asp:Label ID="BackMess" CssClass="alert fade in alert-danger" runat="server" Text="" Visible="false"></asp:Label>
                <div class="form-group">
                    <div class="input-icon"><i class="icon-user"></i>
                        <!--<input type="text" name="username" class="form-control" placeholder="用户名" autofocus="autofocus" data-rule-required="true" data-msg-required="请输入用户名." />-->
                        <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="用户名" Text="" data-rule-required="true" data-msg-required="请输入用户名." ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="input-icon"><i class="icon-lock"></i>
                        <!--<input type="password" name="password" class="form-control" placeholder="密码" data-rule-required="true" data-msg-required="请输入密码." />-->
                        <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" Text="" placeholder="密码" data-rule-required="true" data-msg-required="请输入密码."></asp:TextBox>
                    </div>
                </div>
                <div class="form-actions">                    
                    <!--<label class="checkbox pull-left">
                        <input type="checkbox" class="uniform" name="remember">
                        记住我</label>-->
                    <!--<button type="submit" class="submit btn btn-primary pull-right">登录 <i class="icon-angle-right"></i></button>-->
                    <asp:Button ID="btnSignIn" CssClass="submit btn btn-primary pull-right" runat="server" Text="登录 >>" OnClick="btnSignIn_Click" />
                </div>
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
    
</body>
</html>
