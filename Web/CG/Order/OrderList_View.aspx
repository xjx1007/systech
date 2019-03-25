<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderList_View.aspx.cs" Inherits="OrderList_View" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png"/>
    <title>杭州士腾科技芯片订单</title>
    <style type="text/css">
body {
 background: #FFFFFF;
 color: #000;
 font: normal normal 12px Verdana, Geneva, Arial, Helvetica, sans-serif;
 margin: 10px;
 padding: 0;
 overflow-y:hidden;
}
table, td, a {
 color: #000;
 font: normal normal 12px Verdana, Geneva, Arial, Helvetica, sans-serif
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
thead.fixedHeader th {
 border-left: 0px solid #EB8;
 border-right: 0px solid #B74;
 border-top: 0px solid #EB8;
 font-weight: normal;
 padding: 4px 3px;
 text-align: center
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
 height: 262px;
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

    </style>
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
		LODOP.PRINT_INIT("杭州士腾科技芯片订单");
		LODOP.SET_PRINT_STYLE("FontSize",18);
		LODOP.SET_PRINT_STYLE("Bold",1);

		LODOP.ADD_PRINT_TABLE(130, 0,"100%","100%",document.getElementById("tMater").innerHTML);
	};	   
	function OutToFileMoreSheet(){
		LODOP=getLodop(document.getElementById('LODOP_OB'),document.getElementById('LODOP_EM'));  
		LODOP.PRINT_INIT("");
		LODOP.ADD_PRINT_TABLE(130, 0,"100%","100%",document.getElementById("tMater").innerHTML);
		LODOP.SET_SAVE_MODE("PAGE_TYPE",1);
		LODOP.SET_SAVE_MODE("centerHeader","页眉");
		LODOP.SET_SAVE_MODE("centerFooter","第&P页");
		LODOP.SET_SAVE_MODE("Caption","杭州士腾科技芯片订单");					
		LODOP.SET_SAVE_MODE("RETURN_FILE_NAME",1);
		LODOP.SAVE_TO_FILE("杭州士腾科技芯片订单.xls");		
	};	       
</script> 
<link rel="stylesheet" href="../../css/Report.css" type="text/css">
<script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
<script language="JavaScript" src="../../Js/Report.js" type="text/javascript"></script>
<script language="javascript" src="../../Js/LodopFuncs.js"></script>
<object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width=0 height=0> 
	<embed id="LODOP_EM" type="application/x-print-lodop" width=0 height=0 pluginspage="install_lodop.exe"></embed>
</object> 
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="table-layout: fixed; word-spacing: 0px;
            text-transform: none; width: 626pt; text-indent: 0px; font-family: Simsun; letter-spacing: normal;
            border-collapse: collapse; orphans: 2; widows: 2; webkit-text-size-adjust: auto;
            webkit-text-stroke-width: 0px" width="835">
            <colgroup>
                <col style="width: 626pt" width="835" />
            </colgroup>
            <tr height="19" style="height: 14.25pt">
                <td class="xl1522424" height="19" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 12pt; padding-bottom: 0px; vertical-align: middle; width: 626pt; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 14.25pt;
                    text-decoration: none" width="835">
                    TO:张晓慧<span> <span class="Apple-converted-space">&nbsp;</span></span>88212494</td>
            </tr>
            <tr height="19" style="height: 14.25pt">
                <td class="xl6622424" height="19" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 12pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 14.25pt;
                    text-align: right; text-decoration: none">
                </td>
            </tr>
            <tr height="19" style="height: 14.25pt">
                <td align="left" height="19" style="height: 14.25pt" valign="top">
                    <span style="margin-top: 1px; z-index: 1; margin-left: 6px; width: 617px; position: absolute;
                        height: 29px">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="0" width="0">
                                </td>
                                <td width="153">
                                </td>
                                <td width="232">
                                </td>
                                <td width="232">
                                </td>
                            </tr>
                            <tr>
                                <td height="9">
                                </td>
                                <td colspan="2">
                                </td>
                                <td align="left" rowspan="2" valign="top">
                                    <img alt="logo中1-2" height="29" src="../../../images/士兰微芯片订单_22424_image003.png" v:shapes="Picture_x0020_5"
                                        width="232" /></td>
                            </tr>
                            <tr>
                                <td height="20">
                                </td>
                                <td align="left" valign="top">
                                    <img alt="logo英1-2" height="20" src="../../../images/士兰微芯片订单_22424_image004.png" v:shapes="Picture_x0020_3"
                                        width="153" /></td>
                            </tr>
                        </table>
                    </span><span>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="xl6622424" height="19" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                                    font-size: 12pt; padding-bottom: 0px; vertical-align: middle; width: 626pt; color: windowtext;
                                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 14.25pt;
                                    text-align: right; text-decoration: none" width="835">
                                </td>
                            </tr>
                        </table>
                    </span>
                </td>
            </tr>
            <tr height="20" style="height: 15pt">
                <td class="xl7022424" height="20" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 12pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    border-top-style: none; padding-top: 0px; border-bottom: windowtext 1pt solid;
                    font-style: normal; font-family: 宋体; border-right-style: none; white-space: nowrap;
                    border-left-style: none; height: 15pt; text-align: right; text-decoration: none">
                </td>
            </tr>
            <tr height="19" style="height: 14.25pt">
                <td class="xl1522424" height="19" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 12pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 14.25pt;
                    text-decoration: none">
                </td>
            </tr>
            <tr height="19" style="height: 14.25pt">
                <td class="xl1522424" height="19" style="padding: 0px; font-weight: 400;
                    font-size: 12pt; vertical-align: middle; color: windowtext;
                    font-style: normal; font-family: 宋体; white-space: nowrap; height: 14.25pt;
                    text-decoration: none; text-align: right;">
                <asp:Label runat="server" ID="OrderNo"></asp:Label> </td>
            </tr>
            <tr height="49" style="height: 36.75pt">
                <td class="xl6322424" height="49" style="padding-right: 0px; padding-left: 0px; font-weight: 700;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 36.75pt;
                    text-align: center; text-decoration: none">
                    关于SC51P1316SH1芯片烧录程序说明</td>
            </tr>
            <tr height="19" style="height: 14.25pt">
                <td class="xl1522424" height="19" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 12pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 14.25pt;
                    text-decoration: none">
                </td>
            </tr>
            <tr height="42" style="height: 31.5pt">
                <td class="xl6422424" height="42" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 31.5pt;
                    text-align: justify; text-decoration: none">
                                        <%=s_SuppName %>：</td>
            </tr>
            <tr height="66" style="height: 49.5pt">
                <td class="xl6522424" height="66" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 'Times New Roman', serif;
                    white-space: nowrap; height: 49.5pt; text-align: justify; text-decoration: none">
                    <span>&nbsp; &nbsp; &nbsp; &nbsp; <span class="Apple-converted-space">&nbsp;</span></span><font
                        class="font722424" style="font-weight: 400; font-size: 15pt; color: windowtext;
                        font-style: normal; font-family: 宋体; text-decoration: none">关于</font><font class="font522424"
                            style="font-weight: 400; font-size: 15pt; color: windowtext; font-style: normal;
                            font-family: 'Times New Roman', serif; text-decoration: none"><%=s_Type %></font><font
                                class="font722424" style="font-weight: 400; font-size: 15pt; color: windowtext;
                                font-style: normal; font-family: 宋体; text-decoration: none">芯片，请贵司尽快安排烧录</font><font
                                    class="font522424" style="font-weight: 400; font-size: 15pt; color: windowtext;
                                    font-style: normal; font-family: 'Times New Roman', serif; text-decoration: none"> <%=s_Number %></font><font
                                        class="font722424" style="font-weight: 400; font-size: 15pt; color: windowtext;
                                        font-style: normal; font-family: 宋体; text-decoration: none"> 数量的芯片，烧录程序为</font><font
                                            class="font522424" style="font-weight: 400; font-size: 15pt; color: windowtext;
                                            font-style: normal; font-family: 'Times New Roman', serif; text-decoration: none"><%=s_ProductsPattern %></font><font
                                                class="font722424" style="font-weight: 400; font-size: 15pt; color: windowtext;
                                                font-style: normal; font-family: 宋体; text-decoration: none">。要求到货日期为：<%=s_PlanDate %>，如有疑问请回复交货日期，谢谢！</font></td>
            </tr>
            <tr height="19" style="height: 14.25pt">
                <td class="xl1522424" height="19" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 12pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 14.25pt;
                    text-decoration: none">
                </td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6422424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: justify; text-decoration: none">
                                        <%=s_Address %></td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6422424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: justify; text-decoration: none">
                                        <%=s_Company %></td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6422424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: justify; text-decoration: none">
                                        <%=s_Person %><span> &nbsp; <span class="Apple-converted-space">&nbsp;</span></span></td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6422424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: justify; text-decoration: none">
                                        <%=s_Telphone %></td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6422424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: justify; text-decoration: none">
                </td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6922424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 700;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: justify; text-decoration: none">
                                        （注：请不要用优速快递，<%=s_Remarks %>）</td>
            </tr>
            <tr height="29" style="height: 21.75pt">
                <td class="xl6422424" height="29" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 21.75pt;
                    text-align: justify; text-decoration: none">
                </td>
            </tr>
            <tr height="29" style="height: 21.75pt">
                <td class="xl6422424" height="29" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 21.75pt;
                    text-align: justify; text-decoration: none">
                </td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6722424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: right; text-decoration: none">
                                        杭州士腾科技有限公司</td>
            </tr>
            <tr height="37" style="height: 27.75pt">
                <td class="xl6822424" height="37" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 27.75pt;
                    text-align: right; text-decoration: none">
                                        <%=s_Time %></td>
            </tr>
            <tr height="32" style="height: 24pt">
                <td class="xl6422424" height="32" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 24pt;
                    text-align: justify; text-decoration: none">
                </td>
            </tr>
            <tr height="35" style="height: 26.25pt">
                <td class="xl6422424" height="35" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 26.25pt;
                    text-align: justify; text-decoration: none">
                                        采购部：武秋峰<span> <span class="Apple-converted-space">&nbsp;</span></span>15988156229</td>
            </tr>
            <tr height="35" style="height: 26.25pt">
                <td class="xl6422424" height="35" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 26.25pt;
                    text-align: justify; text-decoration: none">
                                        联系电话： 88210386</td>
            </tr>
            <tr height="35" style="height: 26.25pt">
                <td class="xl6422424" height="35" style="padding-right: 0px; padding-left: 0px; font-weight: 400;
                    font-size: 15pt; padding-bottom: 0px; vertical-align: middle; color: windowtext;
                    padding-top: 0px; font-style: normal; font-family: 宋体; white-space: nowrap; height: 26.25pt;
                    text-align: justify; text-decoration: none">
                                        传真： 88216187</td>
            </tr>
        </table>
    </form>
</body>
</html>