<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="top_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <title></title>
    <style type="text/css">
		body{margin:0;background-color:#a9c9ee;}
		*{font-family:"宋体", Arial;font-size:12px;}
        a{color:#000000;text-decoration:none;}
        a:hover{color:#FFFFFF;background-color:#ff6600;}
        img{border:0;}
        .border{ border:#6493c8 solid 1px;}
        .top_menu{ color:#2867b1; font-weight:bold; text-align:center;}
        .online{ color:#FFFFFF;}
        .online a{ color:#FFFFFF;}
	</style>

    <script language="javascript" type="text/javascript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
    </script>

    <script language="JavaScript">
<!--
function tick() {
var hours, minutes, seconds;
var intHours, intMinutes, intSeconds;
var today;
today = new Date();
intHours = today.getHours();
intMinutes = today.getMinutes();
intSeconds = today.getSeconds();

if (intHours == 0) {
hours = "00:";
} else if (intHours < 10) { 
hours = "0" + intHours+":";
} else {
hours = intHours + ":";
}

if (intMinutes < 10) {
minutes = "0"+intMinutes+":";
} else {
minutes = intMinutes+":";
}
if (intSeconds < 10) {
seconds = "0"+intSeconds+" ";
} else {
seconds = intSeconds+" ";
} 
timeString = hours+minutes+seconds;
Clock.innerHTML = timeString;
window.setTimeout("tick();", 1000);
}

window.onload = tick;
//-->
    </script>

</head>
<body leftmargin="0" topmargin="0" rightmargin="0" >
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17%" height="39" align="left" valign="top" background="../images/topback.jpg">
                        <asp:Image ID="toplogo" runat="server" Height="60px" BorderStyle="none" /></td>
                    <td width="83%" valign="top" background="../images/topback.jpg">
                        <table width="100%" height="48" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="25%" align="center" style="color: #FFFFFF">
                                    <div id="sssss" style="margin-bottom: 4px">

                                        <script language="javascript">
                                   

                                        var today = new Date();  
                                        var week; var date;  
                                        if(today.getDay()==0) week="星期日";  
                                        if(today.getDay()==1) week="星期一";  
                                        if(today.getDay()==2) week="星期二";  
                                        if(today.getDay()==3) week="星期三";  
                                        if(today.getDay()==4) week="星期四";  
                                        if(today.getDay()==5) week="星期五";  
                                        if(today.getDay()==6) week="星期六";  
                                        date=(today.getYear())+"年"+(today.getMonth()+1)+"月"+today.getDate()+"日"+" ";  
                                        document.write(date+week);  
                                      
                                        </script>

                                        &nbsp;&nbsp;<span id="Clock"></span>&nbsp;&nbsp;</div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="94" height="31" align="center" background="../images/top_menubg.gif" class="top_menu">
                                                <a href="Home.aspx" target="main">我的桌面</a></td>
                                            <td width="94" height="31" align="center" background="../images/top_menubg.gif" class="top_menu">
                                                <a href="../Web/Message/System_Message_List.aspx" target="main">短消息</a></td>
                                            <td width="116" background="../images/top_menu2.gif" class="top_menu">
                                                <a href="../inc/Logout.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('TopLogout','','../images/logoutB.gif',1)"
                                                    target="_top">退出系统</a></td>
                                               
                                            <td width="94" height="31" align="center" background="../images/top_menubg.gif" class="top_menu">
                                                <a  href="#" onclick="javascript:window.parent.location.href='../newMain.aspx';">新版</a></td>
                                            <td width="74%">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
