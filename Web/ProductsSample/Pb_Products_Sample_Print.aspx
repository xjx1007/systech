<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pb_Products_Sample_Print.aspx.cs" Inherits="Knet_Sales_Ship_Manage_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../themes/softed/style_cn.css" type="text/css" />
<style type="text/css">
TABLE.print {vertical-align: middle;BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BORDER-COLLAPSE: collapse
}
TABLE.print TD {
	BORDER-RIGHT: #000000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #000000 1px solid; PADDING-LEFT: 5px; FONT-SIZE: 15px; BORDER-LEFT: #000000 1px solid; LINE-HEIGHT: 20px; BORDER-BOTTOM: #000000 1px solid;
}
TABLE.print .right {
	TEXT-ALIGN: right
}
TABLE.print1 {vertical-align: middle;BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 0px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BORDER-COLLAPSE: collapse
}
TABLE.print1 TD {
	BORDER-RIGHT: #000000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #000000 0px solid; PADDING-LEFT: 5px; FONT-SIZE: 15px; BORDER-LEFT: #000000 1px solid; LINE-HEIGHT: 20px; BORDER-BOTTOM: #000000 1px solid;
}
TABLE.print1 .right {
	TEXT-ALIGN: right
}
.init_font {
	FONT-SIZE: 12px
}
.table_1 {
	BORDER-RIGHT: #000000 0px solid;
	PADDING-RIGHT: 0px;
	BORDER-TOP: #000000 0px solid;
	PADDING-LEFT: 0px;
	FONT-SIZE: 13px;
	BORDER-LEFT: #000000 0px solid;
	LINE-HEIGHT: 20px;
	BORDER-BOTTOM: #000000 0px solid;
	padding-bottom: 0px;
}.STYLE1 {
	font-family: "黑体";
	line-height: 30px;
	font-size: 20px;
}</style>
<title>查看样品领用申请单</title>	

    <script language="javascript" type="text/javascript">   
        var LODOP; //声明为全局变量 
	function prn1_preview() {	
		CreateOneFormPage();	
		LODOP.PREVIEW();	
	};
	function prn1_print() {		
		CreateOneFormPage();
		LODOP.PRINT();	
	};
	function prn1_printA() {		
		CreateOneFormPage();
		LODOP.PRINTA(); 	
	};	
	function CreateOneFormPage(){
		LODOP=getLodop(document.getElementById('LODOP_OB'),document.getElementById('LODOP_EM'));
		LODOP.PRINT_INIT("样品领用申请单");
		LODOP.SET_PRINT_STYLE("FontSize",18);
		LODOP.SET_PRINT_STYLE("Bold",1);
		LODOP.ADD_PRINT_HTM(130, 0,"100%","100%",document.getElementById("tMater").innerHTML);
	};	   
	function OutToFileMoreSheet(){
		LODOP=getLodop(document.getElementById('LODOP_OB'),document.getElementById('LODOP_EM'));  
		LODOP.PRINT_INIT("");
		LODOP.ADD_PRINT_HTM(0,0,"100%","100%",document.documentElement.innerHTML);
		LODOP.SET_SAVE_MODE("PAGE_TYPE",1);
		LODOP.SET_SAVE_MODE("centerHeader","页眉");
		LODOP.SET_SAVE_MODE("centerFooter","第&P页");
		LODOP.SET_SAVE_MODE("Caption", "样品领用申请单");					
		LODOP.SET_SAVE_MODE("RETURN_FILE_NAME",1);
		LODOP.SAVE_TO_FILE("样品领用申请单.xls");		
	};	       
</script> 
<script language="javascript" src="../Js/LodopFuncs.js"></script>
<object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width=0 height=0> 
	<embed id="LODOP_EM" type="application/x-print-lodop" width=0 height=0 pluginspage="install_lodop.exe"></embed>
</object> 
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <DIV>
<TABLE border=0 cellSpacing=0 cellPadding=0 width="98%" align=center>
  <TBODY>
  <TR>
    <TD height=3></TD></TR></TBODY></TABLE>
<TABLE 
style="BORDER-BOTTOM: #3399cc 0px solid; BORDER-LEFT: #3399cc 0px solid; BORDER-TOP: #3399cc 0px solid; BORDER-RIGHT: #3399cc 0px solid" 
border=0 cellSpacing=0 cellPadding=0 width="99%" align=center>
  <TBODY>
  <TR>
    <TD>
      <DIV id=printdiv>
      <TABLE border=0 cellSpacing=0 cellPadding=0 width=822 align=center>
        <TBODY>
        <TR>
          <TD height=47 vAlign=top align=center>
            <DIV id=TopPrinterDo>
            <TABLE border=0 cellSpacing=0 cellPadding=0 width=820 bgColor=white 
            align=center height=57>
              <TBODY>
              <TR>
                <TD 
                style="BORDER-BOTTOM: #000000 0px solid; BORDER-LEFT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid" 
                width="69%" align=center><STRONG><FONT size=3>样 品 领 用 申 请 单</TD></TR></TBODY></TABLE>
            <TABLE border=0 cellSpacing=0 cellPadding=0 width=820 bgColor=white 
            align=center height=30>
              <TBODY>
              <TR>
                <TD 
                style="BORDER-LEFT: #000000 1px solid; BORDER-RIGHT: #000000 0px solid" 
                height=30 vAlign=top width="100%" align=center>
                  <TABLE style="FONT-FAMILY: 宋体; FONT-SIZE: 12px" border=0 
                  cellSpacing=0 cellPadding=0 width="100%" align=center>
                    <TBODY>
                    <TR>
                      <TD 
                      style="BORDER-BOTTOM: #000000 1px solid; BORDER-TOP: #000000 1px solid;BORDER-LEFT: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                      height=25 width="16%" align=right>申请部门:</TD>
                      <TD style="BORDER-BOTTOM: #000000 1px solid;BORDER-TOP: #000000 1px solid;BORDER-LEFT: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                        align=left><asp:Label runat="server" ID="Lbl_Dept"></asp:Label></TD>
                      <TD 
                      style="BORDER-BOTTOM: #000000 1px solid;  BORDER-TOP: #000000 1px solid;BORDER-LEFT: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                      width="10%" align=right><FONT face=Verdana>编号:</FONT></TD>
                      <TD 
                      style="BORDER-BOTTOM: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-RIGHT: #000000 1px solid" 
                      align=left><asp:Label runat="server" ID="Lbl_Code"></asp:Label></TD></TR>
                    <TR>
                      <TD 
                      style="BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                      height=25 width="16%" align=right>申请人:</TD>
                      <TD style="BORDER-BOTTOM: #000000 1px solid" 
                        align=left><asp:Label runat="server" ID="Lbl_Person"></asp:Label></TD>
                      <TD 
                      style="BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                      align=right>申请时间<FONT face=Verdana>:</FONT></TD>
                      <TD 
                      style="BORDER-BOTTOM: #000000 1px solid; BORDER-RIGHT: #000000 1px solid" 
                      align=left><asp:Label runat="server" ID="Lbl_Stime"></asp:Label></TD></TR>
                    <TR>
                      <TD 
                      style="BORDER-BOTTOM: #000000 0px solid; BORDER-LEFT: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                      height=25 colSpan=4 
                        align=left>&nbsp;&nbsp;申请如下样品：</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></DIV></TD></TR></TBODY></TABLE>
      <TABLE border=0 cellSpacing=0 cellPadding=0 width=822 align=center>
        <TBODY>
        <TR>
          <TD vAlign=top align=center>
            <TABLE 
            border=0 cellSpacing=0 cellPadding=0 width=820 bgColor=white 
            align=center>
              <TBODY>
              <TR>
                <TD vAlign=top align=center><!--GridView-->
                  <DIV>
                  <TABLE style="WIDTH: 100%; BORDER-COLLAPSE: collapse" 
                  id=GridView2 border=1 rules=all cellSpacing=0 
                  borderColor=#000000>
                    <TBODY>
                    <TR style="HEIGHT: 25px; FONT-SIZE: 12px" align=left>
                      <TH scope=col>序号</TH>
                      <TH scope=col>产品名称</TH>
                      <TH scope=col>产品型号</TH>
                      <TH scope=col>数量</TH>
                      <TH scope=col>样品用途</TH>
                      <TH scope=col>备注</TH>
                      <TH scope=col>是否返回</TH>
                        </TR>
                    <TR style="HEIGHT: 25px; FONT-SIZE: 12px" align=left>
                      <TD>1</TD>
                      <TD><asp:Label runat="server" ID="Lbl_ProductsName"></asp:Label></TD>
                      <TD><asp:Label runat="server" ID="Lbl_ProductsEdition"></asp:Label></TD>
                      <TD><asp:Label runat="server" ID="Lbl_Number"></asp:Label></TD>
                      <TD><asp:Label runat="server" ID="Lbl_Use"></asp:Label></TD>
                      <TD><asp:Label runat="server" ID="Lbl_Remarks"></asp:Label></TD>
                      <TD><asp:Label runat="server" ID="Lbl_IsBack"></asp:Label></TD>
                        </TR></TBODY></TABLE></DIV><!--GridView-->
                  </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <TABLE border=0 cellSpacing=0 cellPadding=0 width=822 align=center>
        <TBODY>
        <TR>
          <TD height=47 vAlign=top align=center>
            <DIV id=BotPrinter>
            <TABLE border=0 cellSpacing=0 cellPadding=0 width=820 bgColor=white 
            align=center height=30>
              <TBODY>
              <TR>
                <TD 
                style="BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-TOP: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                height=30 width="10%" align=right>申请人:</TD>
                <TD 
                style="BORDER-BOTTOM: #000000 1px solid; BORDER-TOP: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                width="40%" align=left><asp:Label runat="server" ID="Lbl_SqPerson"></asp:Label>&nbsp;</TD>
                <TD 
                style="BORDER-BOTTOM: #000000 1px solid; BORDER-LEFT: #000000 0px solid; BORDER-TOP: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                height=30 width="10%" align=right>市场销售部经理:</TD>
                <TD 
                style="BORDER-BOTTOM: #000000 1px solid; BORDER-TOP: #000000 0px solid; BORDER-RIGHT: #000000 1px solid" 
                width="40%" align=left><asp:Label runat="server" ID="Lbl_ShPerson"></asp:Label>&nbsp;</TD></TR>
                </TBODY></TABLE></DIV></TD></TR></TBODY></TABLE></DIV>
      <!--分页--></TD></TR></TBODY></TABLE></DIV>

    </form>
</body>
</html>

