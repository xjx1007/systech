<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="Knetwork_Admin_Main"   %>
<SCRIPT language=JavaScript>
<!--
function switchSysBar(){
if (switchPoint.innerText==3){
switchPoint.innerText=4
document.all("frmTitle").style.display="none"
}else{
switchPoint.innerText=3
document.all("frmTitle").style.display=""
}}
//-->
</SCRIPT>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title></title>
<%--<link rel="shortcut icon" href="../images/favicon.ico" /> --%>
<link rel="alternate icon" type="image/png" href="images/Ê¿ÌÚ.png"/>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0" >
<form id="form1" runat="server"> 
    <TABLE height="100%" cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TBODY>
  <TR>
    <TD colSpan=3><IFRAME  style="WIDTH:100%;HEIGHT: 56px" name=Explorer_Tool marginWidth=0 marginHeight=0  src="inc/top.aspx" frameBorder=0 noResize scrolling=no bordercolor="threedface"></IFRAME></TD></TR>
  <TR>
    <TD id=frmTitle align="center"  width=145  style="height:100%">
	<IFRAME style="WIDTH: 145px; HEIGHT: 100%"  id=BoardLeft name=BoardLeft marginWidth=0  marginHeight=0 src="inc/Home_left.aspx" frameBorder=0 noResize></IFRAME></TD>
    <TD width=3 bgcolor="#6598D0" style="HEIGHT: 100%" onclick=switchSysBar()><FONT  style="FONT-SIZE: 12px;cursor:pointer; cursor:hand;COLOR: #000000; FONT-FAMILY:Webdings"><SPAN  id=switchPoint>3</SPAN></FONT></TD>
    <TD height="100%"><IFRAME  style="WIDTH: 100%; HEIGHT: 100%" 
     id=main name=main   marginheight=0  src="inc/Newhome.aspx" 
      frameBorder=0></IFRAME></TD></TR>
<TR>
<TD colSpan=3><IFRAME style="Z-INDEX:1;WIDTH: 100%; HEIGHT: 26px" 
name=Explorer_Tool marginWidth=0 marginHeight=0 
src="inc/bot.aspx" frameBorder=0 noResize scrolling=no bordercolor="threedface"></IFRAME></TD></TR>
</TBODY></TABLE>
</form>
</body>
</html>
