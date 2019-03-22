<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePassword.aspx.cs" Inherits="UpdatePassword" Title="" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <script type="text/javascript">
        //if(window != window.parent) 
        //{ var P = window.parent, D = P.loadinndlg(); }
        function checkpassword() {
            var numasc = 0;
            var charasc = 0;
            var otherasc = 0;
            var v = document.all("NewWsp2").value;
            if (0 == v.length) {
                alert("密码不能为空");
                return false;
            }
            else if (document.all("NewWsp2").value !== document.all("NewWsp1").value) {
                alert("密码不一致，请重新输入");
                return false;
            }
            else if (v.length < 8 || v.length > 30) {
                alert("密码至少8个字符,最多30个字符");
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
                    alert("密码必须含有数字");
                    return false;
                } else if (0 == charasc) {
                    alert("密码必须含有字母");
                    return false;
                } else if (0 == otherasc) {
                    alert("密码必须含有特殊字符");
                    return false;
                } else {
                    return true;
                }
            }
        };

    </script>

    <title></title>
    <style type="text/css">
        .Div11 {
            background-image: url(../images/btna.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }

        .Div22 {
            background-image: url(../images/btna2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }

        .style1 {
            height: 29px;
        }
    </style>

</head>
<script type="text/javascript" src="../Web/KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="5"></td>
                </tr>
            </table>
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td background="../images/ktxt1.gif" style="background-color: #F5F5F5; height: 28px; width: 130px; padding-left: 20px;">
                        <div class="TP2">欢迎登陆系统</div>
                    </td>
                    <td background="../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;">&nbsp;</td>
                    <td width="173" background="../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;"></td>
                </tr>
            </table>
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="1"></td>
                </tr>
                <tr>
                    <td height="24" bgcolor="#E6F0F9" style="border-bottom: #3399CC 1px solid;">欢迎 <font color="#FF6600"><b>
                        <asp:Label ID="StaffName" runat="server" Text="Label"></asp:Label></b></font> 登陆系统，您目前拥有管理的仓库列表:<font color="#FF6600"><b><asp:Label ID="Warehouse_Name" runat="server" Text=""></asp:Label></b></font></td>
                </tr>
            </table>


            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left" valign="top" style="border-bottom: #3399CC 1px solid; border-right: #3399CC 1px solid; border-left: #3399CC 1px solid; border-top: #3399CC 1px solid;">
                        <%--工作区A2A --%>
                        <%--工作区A2A --%>

                        <%--工作区B2B --%>
                        <%--工作区B2B --%>

                        <%--工作区C2C --%>
                        <table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" id="C2C" runat="server">
                            <tr>
                                <td height="20" align="left">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="4%" align="center" height="25" style="border-bottom: #0099CC 1px solid">
                                                <img src="../images/109.gif" width="22" height="22"></td>
                                            <td width="96%" align="left" style="font-size: 14px; color: #000099; border-bottom: #0099CC 1px solid">&nbsp;<strong>修改密码</strong></td>
                                        </tr>
                                        <tr>
                                            <td height="30" valign="top" colspan="4">

                                                <!--修改密码-->
                                                <table width="98%" runat="server" border="0" align="center" cellpadding="3" cellspacing="3">
                                                    <tr>
                                                        <td height="29" align="right">重置新密码:</td>
                                                        <td height="29" align="left">
                                                            <asp:TextBox ID="NewWsp1" runat="server" TextMode="Password" Width="200px" CssClass="Boxx"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="Req2" runat="server" ErrorMessage="请输入新密码！" ControlToValidate="NewWsp1"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="style1">确认新密码: </td>
                                                        <td align="left" class="style1">
                                                            <asp:TextBox ID="NewWsp2" runat="server" TextMode="Password" Width="200px" CssClass="Boxx"></asp:TextBox>
                                                            <asp:CompareValidator ID="Com1" runat="server" ErrorMessage="两次输入密码不一样!" ControlToValidate="NewWsp2" ControlToCompare="NewWsp1"></asp:CompareValidator></td>

                                                    </tr>
                                                    <tr>
                                                        <td height="30" align="right">&nbsp;</td>
                                                        <td height="30" align="left">&nbsp;<asp:Button ID="Button4" runat="server" Text="确定修改" CssClass="Btt" OnClientClick="return checkpassword()" OnClick="Button4_Click" /></td>
                                                    </tr>
                                                </table>
                                                <!--修改密码--->


                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%--工作区C2C --%>

                        <%--工作区D2D --%>
                        <%--工作区D2D --%>



                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
