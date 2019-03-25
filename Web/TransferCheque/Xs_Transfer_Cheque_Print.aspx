<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Transfer_Cheque_Print.aspx.cs" Inherits="Web_Sales_Xs_Transfer_Cheque_Print" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../css/Report.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="../Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="../Js/LodopFuncs.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>支出管理</title>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0" height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
    <script language="javascript" type="text/javascript">
        var LODOP; //声明为全局变量 
        function CreatePrintPage(s_Type, s_Remarks, s_Year, s_Month, s_Day, s_PayeeName, s_ChineseMoney, s_Money, s_UseName, s_Account, s_BankName, s_BankNo, s_ReceProvice, s_RecePlace) {
            if (s_Type == "民生银行转账支票") {
                GetPrint1(s_Remarks, s_Year, s_Month, s_Day, s_PayeeName, s_ChineseMoney, s_Money, s_UseName, s_Account, s_BankName, s_BankNo, s_ReceProvice, s_RecePlace)
            }
            else if (s_Type == "民生银行电汇凭证") {
                GetPrint2(s_Remarks, s_Year, s_Month, s_Day, s_PayeeName, s_ChineseMoney, s_Money, s_UseName, s_Account, s_BankName, s_BankNo, s_ReceProvice, s_RecePlace)
            }
            else if (s_Type == "民生银行进账单") {
                GetPrint3(s_Remarks, s_Year, s_Month, s_Day, s_PayeeName, s_ChineseMoney, s_Money, s_UseName, s_Account, s_BankName, s_BankNo, '<%=s_BillType %>', '<%=s_BillNumber %>')
            }
};
function GetPrint1(s_Remarks, s_Year, s_Month, s_Day, s_PayeeName, s_ChineseMoney, s_Money, s_UseName, s_Account, s_BankName, s_BankNo, s_ReceProvice, s_RecePlace) {
    var v_top = -35;
    LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
    LODOP.PRINT_INITA(0, 0, 853, 305, "民生转账支票");
    LODOP.SET_PRINT_PAGESIZE(2, 800, 2250, "");
    LODOP.SET_PREVIEW_WINDOW(2, 0, 0, 853, 305, "民生转账支票");
    LODOP.SET_SHOW_MODE("BKIMG_IN_PREVIEW", 1);
    LODOP.SET_SHOW_MODE("LANDSCAPE_DEFROTATED", 1);
    LODOP.ADD_PRINT_TEXT(142 + parseInt(v_top), 273, 233, 25, s_UseName);
    LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
    LODOP.ADD_PRINT_TEXT(60 + parseInt(v_top), 351, 59, 22, number2num1(s_Year));
    LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
    LODOP.ADD_PRINT_TEXT(60 + parseInt(v_top), 430, 59, 22, number2num1(s_Month));
    LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
    LODOP.ADD_PRINT_TEXT(60 + parseInt(v_top), 489, 59, 22, number2num1(s_Day));
    LODOP.SET_PRINT_STYLEA(0, "FontSize", 8);
    LODOP.ADD_PRINT_TEXT(78 + parseInt(v_top), 290, 188, 24, s_PayeeName);

    if (s_PayeeName.length > 15) {
        LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
    }
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


function GetPrint2(s_Remarks, s_Year, s_Month, s_Day, s_PayeeName, s_ChineseMoney, s_Money, s_UseName, s_Account, s_BankName, s_BankNo, s_ReceProvice, s_RecePlace) {

    var v_top = -26;
    var v_left = 0;
    LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
    LODOP.PRINT_INITA(0, 0, 853, 305, "民生电汇");
    LODOP.SET_PRINT_PAGESIZE(2, 850, 1740, "");
    LODOP.SET_PREVIEW_WINDOW(2, 0, 0, 853, 305, "民生电汇");
    LODOP.SET_SHOW_MODE("BKIMG_IN_PREVIEW", 1);
    LODOP.SET_SHOW_MODE("LANDSCAPE_DEFROTATED", 1);
    //LODOP.ADD_PRINT_TEXT(52, 289, 33, 22, s_Year);
    //LODOP.ADD_PRINT_TEXT(52, 344, 33, 22, s_Month);
    //LODOP.ADD_PRINT_TEXT(52, 388, 33, 22, s_Day);
    LODOP.ADD_PRINT_TEXT(78 + parseInt(v_top), 413 + parseInt(v_left), 218, 24, s_PayeeName);

    if (s_PayeeName.length > 15) {
        LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
    }
    //第一行
    LODOP.ADD_PRINT_TEXT(165 + parseInt(v_top), 120 + parseInt(v_left), 312, 25, s_ChineseMoney);
    LODOP.ADD_PRINT_TEXT(78 + parseInt(v_top), 120 + parseInt(v_left), 218, 24, "杭州士腾科技有限公司");
    //第二行
    LODOP.ADD_PRINT_TEXT(94 + parseInt(v_top), 120 + parseInt(v_left), 218, 24, "6744170003402");
    LODOP.ADD_PRINT_TEXT(94 + parseInt(v_top), 413 + parseInt(v_left), 218, 24, s_BankNo);
    //第三行

    LODOP.ADD_PRINT_TEXT(115 + parseInt(v_top), 124 + parseInt(v_left), 47, 24, "浙江");
    LODOP.ADD_PRINT_TEXT(115 + parseInt(v_top), 200 + parseInt(v_left), 47, 24, "杭州");
    LODOP.ADD_PRINT_TEXT(115 + parseInt(v_top), 509 + parseInt(v_left), 47, 24, s_RecePlace);
    LODOP.ADD_PRINT_TEXT(115 + parseInt(v_top), 421 + parseInt(v_left), 47, 24, s_ReceProvice);
    LODOP.ADD_PRINT_TEXT(137 + parseInt(v_top), 120 + parseInt(v_left), 211, 24, "民生银行西湖支行");
    LODOP.ADD_PRINT_TEXT(137 + parseInt(v_top), 413 + parseInt(v_left), 211, 24,s_BankName);
    if (s_BankName.length > 15) {
        LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
    }
    for (var i = 0; i < 12; i++) {
        LODOP.ADD_PRINT_TEXT(173 + parseInt(v_top), 608 - i * 15.8 + parseInt(v_left), 15, 23, GetMoney(s_Money, i));
    }
    LODOP.ADD_PRINT_TEXT(235 + parseInt(v_top), 344 + parseInt(v_left), 281, 45, s_UseName);
    //LODOP.PRINT_DESIGN();
    LODOP.PREVIEW();
    //LODOP.PRINT_SETUP();
    //LODOP.Print();
    window.close();
}
function GetPrint3(s_Remarks, s_Year, s_Month, s_Day, s_PayeeName, s_ChineseMoney, s_Money, s_UseName, s_Account, s_BankName, s_BankNo, s_BillType, s_BillNumber) {

    var v_top = -33;
    var v_left = -10;
    LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
    LODOP.PRINT_INITA(0, 0, 853, 305, "民生银行进账单");
    LODOP.SET_PRINT_PAGESIZE(2, 850, 1740, "");
    LODOP.SET_PREVIEW_WINDOW(2, 0, 0, 853, 305, "民生银行进账单");
    LODOP.SET_SHOW_MODE("BKIMG_IN_PREVIEW", 1);
    LODOP.SET_SHOW_MODE("LANDSCAPE_DEFROTATED", 1);
    //第一行
    LODOP.ADD_PRINT_TEXT(78 + parseInt(v_top), 120 + parseInt(v_left), 218, 24, "杭州士腾科技有限公司");
    LODOP.ADD_PRINT_TEXT(78 + parseInt(v_top), 398 + parseInt(v_left), 218, 24, s_PayeeName);
    if (s_PayeeName.length > 15) {
        LODOP.SET_PRINT_STYLEA(0, "FontSize", 7);
    }
    //第二行
    LODOP.ADD_PRINT_TEXT(103 + parseInt(v_top), 120 + parseInt(v_left), 218, 24, "6744170003402");
    LODOP.ADD_PRINT_TEXT(103 + parseInt(v_top), 398 + parseInt(v_left), 218, 24, s_BankNo);
    //第三行
    LODOP.ADD_PRINT_TEXT(129 + parseInt(v_top), 120 + parseInt(v_left), 218, 24, "民生银行西湖支行");
    LODOP.ADD_PRINT_TEXT(129 + parseInt(v_top), 398 + parseInt(v_left), 218, 24, s_BankName);

    LODOP.ADD_PRINT_TEXT(165 + parseInt(v_top), 110 + parseInt(v_left), 312, 25, s_ChineseMoney);

    LODOP.ADD_PRINT_TEXT(190 + parseInt(v_top), 125 + parseInt(v_left), 85, 24, s_BillType);
    LODOP.ADD_PRINT_TEXT(190 + parseInt(v_top), 280 + parseInt(v_left), 42, 24, s_BillNumber);
    for (var i = 0; i < 12; i++) {
        LODOP.ADD_PRINT_TEXT(165 + parseInt(v_top), 599 - i * 15 + parseInt(v_left), 15, 23, GetMoney(s_Money, i));
    }
    LODOP.ADD_PRINT_TEXT(249 + parseInt(v_top), 82 + parseInt(v_left), 239, 45, s_Remarks);
    //LODOP.PRINT_DESIGN();
    LODOP.PREVIEW();
    //LODOP.PRINT_SETUP();
    //LODOP.Print();
    window.close();
}
function GetMoney(s_Money, i_Num) {
    var v_Return = "";
    var v_NewMoney = parseFloat(s_Money)* 100;
    v_NewMoney = v_NewMoney.toFixed(0) + "" //分
    if (v_NewMoney.length == i_Num) {
        v_Return = "¥";
    }
    else if (i_Num < v_NewMoney.length) {
        v_Return = v_NewMoney.substr(v_NewMoney.length - 1 - i_Num, 1)
    }
    return v_Return;
};

function number2num1(strg) {
    var number = Math.round(strg * 100) / 100;
    number = number.toString(10).split('.');
    var a = number[0];
    if (a.length > 12)
        return "数值超出范围！支持的最大数值为 999999999999.99";
    var e = "零壹贰叁肆伍陆柒捌玖";
    var num1 = "";
    var len = a.length - 1;
    for (var i = 0 ; i <= len; i++)
        num1 += e.charAt(parseInt(a.charAt(i)));
    if (strg.length == "2") {
        //月日
        var s_Ten = num1.substring(0, 1);
        var s_Gen = num1.substring(1, 2);
        if (s_Ten != "零") {
            num1 = s_Ten + "拾" + s_Gen;
        }
        if (s_Gen == "零") {
            num1 = s_Gen + s_Ten + "拾";
        }
    }
    else if (strg.length == "1") {

        num1 = "零" + num1;
    }
    return num1;
};
window.onload = function () {
    CreatePrintPage('<%=s_Type%>', '<%=s_Remarks %>', '<%=s_Year %>', '<%=s_Month %>', '<%=s_Day %>', '<%=s_PayeeName %>', '<%=s_ChineseMoney %>', '<%=s_Money %>', '<%=s_UseName %>', '<%=s_Account %>', '<%=s_BankName %>', '<%=s_BankNo %>', '<%=s_ReceProvice %>', '<%=s_RecePlace %>')
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    </form>
</body>
</html>
