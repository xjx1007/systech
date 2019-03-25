<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_ShipWareOut_View.aspx.cs" Inherits="Web_Sales_Xs_ShipWareOut_View" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>杭州士腾科技发货通知单</title>
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
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
		LODOP.PRINT_INIT("杭州士腾科技发货通知单");
		LODOP.SET_PRINT_STYLE("FontSize",18);
		LODOP.SET_PRINT_STYLE("Bold",1);
	  //  LODOP.ADD_PRINT_HTM(30, 0, "100%", "100%","<table width=\"100%\"><tr><td class=\"ListHeadDetails\" align=\"center\"><font color ='black' size ='6'>杭州士腾科技发货通知单</font></td></tr></table>"); 
	    //LODOP.ADD_PRINT_HTM(90, 0, "100%", "100%","<table width=\"100%\"><tr><td align=\"left\"><%=s_HouseName %></td><td align=\"right\"><%=s_Time %></td></tr></table>"); 

		LODOP.ADD_PRINT_TABLE(130, 0,"100%","100%",document.getElementById("tMater").innerHTML);
	};	   
	function OutToFileMoreSheet(){
		LODOP=getLodop(document.getElementById('LODOP_OB'),document.getElementById('LODOP_EM'));  
		var v_html=document.getElementById("tMater").innerHTML;
		LODOP.PRINT_INIT("");
		LODOP.ADD_PRINT_TABLE(130, 0, "100%", "100%", v_html);
		LODOP.SET_SAVE_MODE("PAGE_TYPE",1);
		LODOP.SET_SAVE_MODE("centerHeader","页眉");
		LODOP.SET_SAVE_MODE("centerFooter","第&P页");
		LODOP.SET_SAVE_MODE("Caption","杭州士腾科技发货通知单");					
		LODOP.SET_SAVE_MODE("RETURN_FILE_NAME",1);
		LODOP.SAVE_TO_FILE("杭州士腾科技发货通知单.xls");		
	};	       
</script> 
<style type="text/css" id="Style1">
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
<link rel="stylesheet" href="/Web/css/Report.css" type="text/css">
<script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
<script language="JavaScript" src="/Web/Js/Report.js" type="text/javascript"></script>
<script language="javascript" src="/Web/Js/LodopFuncs.js"></script>
<object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width=0 height=0> 
	<embed id="LODOP_EM" type="application/x-print-lodop" width=0 height=0 pluginspage="install_lodop.exe"></embed>
</object> 
</head>
<body>
    <form id="form1" runat="server">
    <div  > 
    <input type="button" value="打印预览" onclick="javascript:prn1_preview()" id="Button1"  class="button"/>
    <input type="button" value="导出Excel" onclick="javascript:OutToFileMoreSheet()" id="Button2" />
    <table  width="100%" cellspacing="0" cellpadding="0" ID="tMater" class="pTable">
    	<tr><td  a>
    	<asp:Label runat="server" ID="Lbl_Details"></asp:Label>
    	</td></tr>
    </table>
    
    </div>
    </form>
</body>
</html>