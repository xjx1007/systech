<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login-Old.aspx.cs" Inherits="KnetWork_DefaultLoging" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>进销存系统</title>
    <style>
 body,td{font-size: 12px;}
.myput{BORDER-TOP-WIDTH:1px;BORDER-LEFT-WIDTH:1px;BORDER-BOTTOM-WIDTH:2px;BORDER-RIGHT-WIDTH:2px;height: 20px; color:#000000;font-size:15px;}

body {
	background-color:#EBEBEB; 
}
</style>
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <link rel="stylesheet" href="css/common.css" />
    <script src="Web/js/jQuery.js" type="text/javascript"></script>
    <script src="Web/js/Global.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(document).ready(function(){
      initInput();
      $("#UserName").blur(function(event){
        $("#UserName").offsetParent().removeClass("blurred");
        });
      $("#Password").blur(function(event){
        $("#Password").offsetParent().removeClass("blurred");
        });
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="head"><h1></h1></div>
        <br />
        <table width="373" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 363px; width: 360px;">
                    <div style="background: url(images/bgLogin.png); width: 360px; height: 363px;">
                        <div style="height: 363px;">
                            <table width="100%" height="363" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td align="right" style="width: 50px;" rowspan="7">
                                            &nbsp;</td>
                                        <td align="left" colspan="2" style="height: 90px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" style="height: 30px" valign="bottom">
                                            登录名:</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="height: 50px">
                                            <div class="input_pack">
                                                <label for="UserName">
                                                    登 录 名</label>
                                                <asp:TextBox ID="UserName" runat="server" Text=""></asp:TextBox></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" style="height: 30px" valign="bottom">
                                            密&nbsp;&nbsp;码:</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" style="height: 50px">
                                            <div class="input_pack">
                                                <label for="Password">
                                                    密&nbsp;码</label>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Text=""></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" valign="top" style="height: 35px">
                                            <asp:Label ID="BackMess" runat="server" ForeColor="Red"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2" rowspan="1" style="height: 70px" valign="top">
                                            <div style="height: 41px; width: 105px; margin-left: 160px; margin-top:15px;">
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/btnLoginOff.gif"
                                                    OnClick="ImageButton1_Click" onmouseover="this.src='images/btnLoginOn.gif'" onmouseout="this.src='images/btnLoginOff.gif'" /></div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <script>if($("#UserName").val() == "")
    {
        $("#UserName").offsetParent().removeClass("filled");
    }
    else
    {
        $("#UserName").offsetParent().addClass("filled");
    }
     if($("#Password").val() == "")
    {
        $("#Password").offsetParent().removeClass("filled");
    }
    else
    {
        $("#Password").offsetParent().addClass("filled");
    }</script>
    </form>
</body>
</html>
