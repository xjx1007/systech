<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_ShipCheck_View.aspx.cs" Inherits="Web_Sales_Xs_ShipWareOut_View" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <title>士腾与供应商对账确认单</title>
    
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
        function CreateOneFormPage() {
            var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
            var strFormHtml = strBodyStyle + "<body>" + document.getElementById("tableContainer").innerHTML;

            strFormHtml += "</body>";

            strFormHtml = strFormHtml.replace("<THEAD class=fixedHeader>", "");
            strFormHtml = strFormHtml.replace("</THEAD> ", "");
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("士腾与供应商对账确认单");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            //  LODOP.ADD_PRINT_HTM(30, 0, "100%", "100%","<table width=\"100%\"><tr><td class=\"ListHeadDetails\" align=\"center\"><font color ='black' size ='6'>士腾与供应商对账确认单</font></td></tr></table>"); 
            //LODOP.ADD_PRINT_HTM(90, 0, "100%", "100%","<table width=\"100%\"><tr><td align=\"left\"><%=s_HouseName %></td><td align=\"right\"><%=s_Time %></td></tr></table>");
    	    LODOP.ADD_PRINT_TABLE(0, 0, "100%", "100%", strFormHtml);
	};
	function OutToFileMoreSheet() {
	    var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
	    var strFormHtml = strBodyStyle + "<body>" + document.getElementById("tableContainer").innerHTML + "</body>";
	    strFormHtml = strFormHtml.replace("<THEAD class=fixedHeader>", "");
	    strFormHtml = strFormHtml.replace("</THEAD> ", "");

	    LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
	    LODOP.PRINT_INIT("");
	    LODOP.ADD_PRINT_TABLE(0, 0, "100%", "100%", strFormHtml);
	    LODOP.SET_SAVE_MODE("PAGE_TYPE", 1);
	    LODOP.SET_SAVE_MODE("centerHeader", "页眉");
	    LODOP.SET_SAVE_MODE("centerFooter", "第&P页");
	    LODOP.SET_SAVE_MODE("Caption", "士腾与供应商对账确认单");
	    LODOP.SET_SAVE_MODE("RETURN_FILE_NAME", 1);
	    var v_Name = "<%=s_ExcelName%>";
	    LODOP.SAVE_TO_FILE(v_Name);
	};
    </script>
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="../../Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="../../Js/LodopFuncs.js"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0" height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
        </div>
    </form>
</body>
</html>
