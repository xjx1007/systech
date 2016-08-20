 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="bot.aspx.cs" Inherits="Bot_bot" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <title></title>

    <script type="text/javascript" src="../Web/js/Global.js"></script>
    <script type="text/javascript" src="../Web/Js/ajax_func.js"></script>
    <script type="text/javascript" src="../Web/KDialog/lhgdialog.js"></script>
    <script type="text/javascript">
     //if(window != window.parent) 
     //{ var P = window.parent, D = P.loadinndlg(); }
    </script>

    <script type="text/javascript">
var seed=0;

function FlashMessage()
{
    var objMessage = document.getElementById("Img_Message");
    if(objMessage.style.display != "none")
    {
        HideObj(objMessage);
    }
    else
    {
        ShowObj(objMessage);
    }
}

function GetNewMessage()
    {
        var rand = Math.random()*10000 + 1;
        var url="../Web/Js/MessageHandler.ashx?random=" + rand;
        send_request("GET",url,null,"text",populateClass);
    }
    
var isFlashing = 0; 
function populateClass(){
if(http_request.readyState==4){
        if(http_request.status==200){
	        var result=http_request.responseText;
	        if(result == "True")
	        {
	            if(isFlashing == 0)
	            {
	                seed = setInterval("FlashMessage()", 500);
	                document.getElementById("lnk_ViewMessage").style.display="block";
	                isFlashing = 1;	                
	            }
	        }
	        else
	        {
	            clearInterval(seed);
	            var objMessage = document.getElementById("Img_Message");
	            ShowObj(objMessage);
	            document.getElementById("lnk_ViewMessage").style.display="none";
	            isFlashing = 0;
	        }
        }else{
	        //alert("您所请求的页面有异常.");
        }
}
}
setInterval("GetNewMessage()", 1000);
</script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">

    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td bgcolor="#6598D0" height="4">
                </td>
            </tr>
        </tbody>
    </table>
    <table height="28" cellspacing="0" cellpadding="0" width="100%" bgcolor="#3a6592"
        border="0">
        <tbody>
            <tr>
                <td width="20%" style="height: 29px">
                    &nbsp;&nbsp;&nbsp;<font color="#FFFFFF"><b><asp:Label ID="CompanyName" runat="server"
                        Text=""></asp:Label></b></font></td>
                <td align="left" style="height: 29px; width: 73%;">
                    <font color="#FFFFFF">欢迎 <font color="#FF6600">
                        <asp:Label ID="HouseName" runat="server" Text=""></asp:Label></font> 登陆系统，您已登 <font
                            color="#FF6600">
                            <asp:Label ID="LoginNum" runat="server" Text=""></asp:Label></font> 次，上次登陆时间:<font
                                color="#FF6600"><asp:Label ID="LastLoginDate" runat="server" Text=""></asp:Label></font>，上次IP:<font
                                    color="#FF6600"><asp:Label ID="LogIP" runat="server" Text=""></asp:Label></font>,本次IP:<font
                                        color="#FF6600"><asp:Label ID="LogIPLast" runat="server" Text=""></asp:Label>
                                    </font></font>
                </td>
                <td style="text-align: left; position:relative;" width="7%">
                    <asp:Image ID="Img_Message" runat="server" Height="12px" ImageUrl="~/images/07.gif"
                        Width="21px" />
                    <a href="#" onclick="lhgdialog.opendlg('短消息: <font color=Red></font>', '../Message/System_Message_Detail.aspx', 780, 400,false,false);" style="display:block; position:absolute; width:21px; height:12px; top:7px;" id="lnk_ViewMessage"></a>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
