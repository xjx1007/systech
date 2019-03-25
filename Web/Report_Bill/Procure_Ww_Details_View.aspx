<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_Ww_Details_View.aspx.cs"
    Inherits="Procure_Ww_Details_View" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title>原材料委外加工发料明细</title>
    <style type="text/css" id="style1">
body {
 background: #FFF;
 color: #000;
 font: normal normal 14px Verdana, Geneva, Arial, Helvetica, sans-serif;
 margin: 10px;
 padding: 0;
 overflow-y:hidden;
}
table, td, a {
 color: #000;
 font: normal normal 14px Verdana, Geneva, Arial, Helvetica, sans-serif
}
.td
  {
 nowrap:'true';
  }
div.tableContainer {
 clear: both;
 border: 1px solid #963;
 height:551px;
 overflow: auto;
 width: 100%;
}
/html div.tableContainer {
 padding: 0 16px 0 0
}
html>body div.tableContainer {
 height: auto;
 padding: 0;
 width: 90%
}
head:first-child+body div[class].tableContainer {
 height: 100%;
 overflow: hidden;
 width: 100%
}
div.tableContainer table {
 float: left;
 width: 100%
}
/html div.tableContainer table {
 margin: 0 -16px 0 0
}
html>body div.tableContainer table {
 float: none;
 margin: 0;
 width: 100%;
}
head:first-child+body div[class].tableContainer table {
 width: 100%;
}
thead.fixedHeader tr {
 position: relative;
 top: expression(document.getElementById("tableContainer").scrollTop)
}

head:first-child+body thead[class].fixedHeader tr {
 display: block
}
.thstyle{
 background: #C96;
 border-left: 0px solid #EB8;
 border-right: 0px solid #B74;
 border-top: 0px solid #EB8;
 font-weight: normal;
 padding: 4px 3px;
 text-align: center
}
.thstyleleft
{
 background: #FFFFFF;
 border-left: 0px solid #EB8;
 border-right: 0px solid #B74;
 border-top: 0px solid #EB8;
 font-weight: normal;
 padding: 4px 3px;
 text-align:left;
}
.thstyleRight
{
 background: #FFFFFF;
 border-left: 0px solid #EB8;
 border-right: 0px solid #B74;
 border-top: 0px solid #EB8;
 font-weight: normal;
 padding: 4px 3px;
 text-align:right;
}
.thstyleLeftDetails
{
 BORDER-BOTTOM:#000000 0px solid;
 BORDER-LEFT: #000000 0px solid;
 BORDER-TOP: #000000 1px solid;
 BORDER-RIGHT: #000000 1px solid;
}
.scrollTable
{
 BORDER-BOTTOM:#000000 1px solid;
}
.thsTitle{
 background: #FFFFFF;
 border-left: 0px solid #EB8;
 border-right: 0px solid #B74;
 border-top: 0px solid #EB8;
 font-weight: normal;
 padding: 4px 3px;
}
thead.fixedHeader a, thead.fixedHeader a:link, thead.fixedHeader a:visited {
 color: #FFF;
 display: block;
 text-decoration: none;
 width: 100%
}
thead.fixedHeader a:hover {
 color: #FFF;
 display: block;
 text-decoration: underline;
 width: 100%
}
head:first-child+body tbody[class].scrollContent {
 display: block;
 height: auto;
 overflow: auto;
 width: 100%
}    */
tbody.scrollContent td, tbody.scrollContent tr.normalRow td {
 background: #FFF;
 border-bottom: 0px solid #EEE;
 border-left: 0px solid #EEE;
 border-right: 0px solid #AAA;
 border-top: 0px solid #AAA;
 padding: 2px 3px
}
tbody.scrollContent tr.alternateRow td {
 background: #EEE;
 border-bottom: 1px solid #EEE;
 border-left: 1px solid #EEE;
 border-right: 1px solid #AAA;
 border-top: 1px solid #AAA;
 padding: 2px 3px
}
head:first-child+body thead[class].fixedHeader th {
 width: 200px;
}
head:first-child+body thead[class].fixedHeader th + th {
 width: 250px
}
head:first-child+body thead[class].fixedHeader th + th + th {
 border-right: none;
 padding: 4px 4px 4px 3px;
 width: 316px
}
head:first-child+body tbody[class].scrollContent td {
 width: 200px
}
head:first-child+body tbody[class].scrollContent td + td {
 width: 250px
}
head:first-child+body tbody[class].scrollContent td + td + td {
 border-right: none;
 padding: 2px 4px 2px 3px;
 width: 300px;
 top: expression(document.getElementById("tableContainer").scrollTop)
}
      
.rr{background-color:#FFFFEE}
.gg{background-color:#dee2f2}
  .MaterTitle
	    {
	    font-family:方正姚体;
	    white-space:nowrap;
	    color:windowtext;
	    font-weight:700;
	    font-style:normal;
	    text-decoration:none;
	    text-align:center;
	    vertical-align:middle;
        background: #FFFFFF;
	    border:none;}
	    
	
.Custom_Hidden
{
	display:none;	
}
</style>
    <script language="javascript" type="text/javascript">   
        var LODOP; //声明为全局变量 
	function prn1_preview() {
	    CreateOneFormPage();
	    LODOP.SET_PRINT_MODE("PRINT_PAGE_PERCENT", "Auto-Width");
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
		LODOP.PRINT_INIT("原材料委外加工发料明细");
		LODOP.SET_PRINT_STYLE("FontSize",18);
		LODOP.SET_PRINT_STYLE("Bold",1);
	  //  LODOP.ADD_PRINT_HTM(30, 0, "100%", "100%","<table width=\"100%\"><tr><td class=\"ListHeadDetails\" align=\"center\"><font color ='black' size ='6'>士腾与供应商对账确认单</font></td></tr></table>"); 
	    //LODOP.ADD_PRINT_HTM(90, 0, "100%", "100%","<table width=\"100%\"><tr><td align=\"left\"><%=s_HouseName %></td><td align=\"right\"><%=s_Time %></td></tr></table>"); 
		var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
		var strFormHtml = strBodyStyle + "<body>" +  document.getElementById("tableContainer").innerHTML + "</body>";

		strFormHtml = strFormHtml.replace("<THEAD class=fixedHeader>", "");
		strFormHtml = strFormHtml.replace("</THEAD> ", "");
		LODOP.ADD_PRINT_TABLE(0, 0, "100%", "100%", strFormHtml);
	};
	function OutToFileMoreSheet() {
	    var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
	    var strFormHtml = strBodyStyle + "<body>" + document.getElementById("tableContainer").innerHTML + "</body>";

	    strFormHtml = strFormHtml.replace("<THEAD class=fixedHeader>", "");
	    strFormHtml = strFormHtml.replace("</THEAD> ", "");
		LODOP=getLodop(document.getElementById('LODOP_OB'),document.getElementById('LODOP_EM'));  
		LODOP.PRINT_INIT("");
		LODOP.ADD_PRINT_TABLE(130, 0, "100%", "100%", strFormHtml);
		LODOP.SET_SAVE_MODE("PAGE_TYPE",1);
		LODOP.SET_SAVE_MODE("centerHeader","页眉");
		LODOP.SET_SAVE_MODE("centerFooter","第&P页");
		LODOP.SET_SAVE_MODE("Caption", "原材料委外加工发料明细");					
		LODOP.SET_SAVE_MODE("RETURN_FILE_NAME",1);
		LODOP.SAVE_TO_FILE("原材料委外加工发料明细.xls");		
	};	       
    </script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="../Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="../Js/LodopFuncs.js"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="打印预览" onclick="javascript:prn1_preview()" id="Button1" />
        <input type="button" value="导出Excel" onclick="javascript:OutToFileMoreSheet()" id="Button2" />
        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
    </div>
    <asp:TextBox  runat="server" ID="Tbx_Title" CssClass="Custom_Hidden"></asp:TextBox>
    <asp:TextBox  runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
    </form>
</body>
</html>
