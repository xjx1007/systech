<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PB_Basic_Express_Print.aspx.cs" Inherits="Web_PB_Basic_Express_Print" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="/Web/css/Report.css" type="text/css">
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="/Web/Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="/Web/Js/LodopFuncs.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>杭州士腾科技发货通知单</title>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0" height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
    <script language="javascript" type="text/javascript">
        var LODOP; //声明为全局变量 
        function CreatePrintPage(s_ID) {
            var Response = Web_PB_Basic_Express_Print.GetDetails(s_ID);
            var ss = Response.value.split(",");
            if (ss[0] == "顺丰快递") {
                GetPrint1(s_ID)
            }
        };
        function GetPrint1(s_ID) {
            var Response = Web_PB_Basic_Express_Print.GetDetails(s_ID);
            var v_top = -35;
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INITA(0, 0, 853, 305, "顺丰快递");
            LODOP.ADD_PRINT_SETUP_BKIMG("<img border='0' src='../PrintImage/顺丰快递3.jpg'>");
            LODOP.SET_PRINT_PAGESIZE(2, 800, 2250, "");
            LODOP.SET_PREVIEW_WINDOW(2, 0, 0, 853, 305, "顺丰快递");
            LODOP.SET_SHOW_MODE("BKIMG_IN_PREVIEW", 1);
            LODOP.SET_SHOW_MODE("LANDSCAPE_DEFROTATED", 1);
            LODOP.ADD_PRINT_TEXT(142 + parseInt(v_top), 273, 233, 25, s_UseName);
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
            LODOP.ADD_PRINT_TEXT(60 + parseInt(v_top), 351, 59, 22, number2num1(s_Year));
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
            LODOP.ADD_PRINT_TEXT(60 + parseInt(v_top), 436, 40, 22, number2num1(s_Month));
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
            LODOP.ADD_PRINT_TEXT(60 + parseInt(v_top), 494, 40, 22, number2num1(s_Day));
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
            LODOP.ADD_PRINT_TEXT(78 + parseInt(v_top), 290, 188, 24, s_PayeeName);
            LODOP.ADD_PRINT_TEXT(110 + parseInt(v_top), 309, 312, 30, s_ChineseMoney);
            for (var i = 0; i < 12; i++) {
                LODOP.ADD_PRINT_TEXT(115 + parseInt(v_top), 788 - i * 15, 15, 23, GetMoney(s_Money, i));
            }
            //附表格
            LODOP.ADD_PRINT_TEXT(110 + parseInt(v_top), 40, 155, 62, s_Remarks);
            LODOP.ADD_PRINT_TEXT(179 + parseInt(v_top), 87, 34, 19, s_Year);
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
            LODOP.ADD_PRINT_TEXT(179 + parseInt(v_top), 129, 21, 19, s_Month);
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
            LODOP.ADD_PRINT_TEXT(179 + parseInt(v_top), 164, 21, 19, s_Day);
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
            LODOP.ADD_PRINT_TEXT(200 + parseInt(v_top), 86, 110, 20, s_PayeeName);
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
            LODOP.ADD_PRINT_TEXT(216 + parseInt(v_top), 86, 110, 20, s_Money);
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
            LODOP.ADD_PRINT_TEXT(235 + parseInt(v_top), 86, 110, 20, s_UseName);
            LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
            //LODOP.PRINT_DESIGN();
            LODOP.PREVIEW();
            //LODOP.PRINT_SETUP();
            //LODOP.Print();
            window.close();
        }
        window.onload = function () {
            CreatePrintPage('<%=s_ID%>')
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
