<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_OrderListChart.aspx.cs" Inherits="Web_Report_Xs_List_OrderList" %>

<%@ Register Assembly="Container" Namespace="FanG" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <title>重点机顶盒厂销售趋势图</title>
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
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("重点机顶盒厂销售趋势图");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", document.getElementById("tMater").innerHTML);
        };
        function OutToFileMoreSheet() {
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("");
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", document.getElementById("tMater").innerHTML);
            LODOP.SET_SAVE_MODE("PAGE_TYPE", 1);
            LODOP.SET_SAVE_MODE("centerHeader", "页眉");
            LODOP.SET_SAVE_MODE("centerFooter", "第&P页");
            LODOP.SET_SAVE_MODE("Caption", "重点机顶盒厂销售趋势图");
            LODOP.SET_SAVE_MODE("RETURN_FILE_NAME", 1);
            LODOP.SAVE_TO_FILE("重点机顶盒厂销售趋势图.xls");
        };
    </script>
    <link rel="stylesheet" href="/Web/css/Report.css" type="text/css">
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
            <input type="button" value="打印预览" onclick="javascript: prn1_preview()" id="Button1" />
            <input type="button" value="导出Excel" onclick="javascript: OutToFileMoreSheet()" id="Button2" />
            <table width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="center"></td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                            <tr>
                                <td style="height: 16px" align="left">
                                    <asp:Label runat="server" ID="Lbl_Time"></asp:Label></td>
                                <td style="height: 16px" align="left">
                                    <asp:Label runat="server" ID="Lbl_Person"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <cc1:Chartlet ID="Chartlet1" runat="server" Width="90%"></cc1:Chartlet>
                    </td>
                </tr>

                <tr>
                    <td align="center" width="80%">
                        <asp:Label ID="Lbl_Details" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbl_End" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
