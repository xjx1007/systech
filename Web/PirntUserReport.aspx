<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PirntUserReport.aspx.cs" Inherits="Web_PirntUserReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../themes/softed/style.css" type="text/css">
    <script language="javascript" src="Js/LodopFuncs.js"></script>
    <title>用户报告</title>
    <style type="text/css" id="style1">
        .ListDetails {
            BORDER-COLLAPSE: collapse;
            border-color: #666666;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            color: #000000;
            border-top: 1px solid #666666;
            border-left: 1px solid #666666;
            border-right: 1px solid #666666;
        }
        .ListDetails_Print {
            BORDER-COLLAPSE: collapse;
            border-color: #666666;
            font-family: SimSun;
            font-size: 16px;
            color: #000000;
            border-top: 1px solid #666666;
            border-left: 1px solid #666666;
            border-right: 1px solid #666666;
            width:700px
        }

        .ListHead {
            border-top: 0px solid #666666;
            border-left: 1px solid #666666;
            border-right: 0px solid #666666;
            border-bottom: 1px solid #666666;
            font-weight: bold;
            background: #f6f6f6 url(images/mailSubHeaderBg-grey.gif) bottom repeat-x;
            vertical-align: middle;
            text-align: center;
        }

        .ListHeadLeft {
            border-top: 0px solid #666666;
            border-left: 1px solid #666666;
            border-right: 0px solid #666666;
            border-bottom: 1px solid #666666;
            font-weight: bold;
            background: #f6f6f6 url(images/mailSubHeaderBg-grey.gif) bottom repeat-x;
            vertical-align: middle;
            text-align: left;
        }

        .ListHeadDetails {
            padding-left: 2px;
            border-bottom: 1px solid #666666;
            border-right: 0px solid #666666;
            border-left: 1px solid #666666;
            border-top: 0px solid #666666;
            letter-spacing:1px;
           line-height:30px; 
        }
        
        
        .ListHeadDetails2 {
            padding-left: 2px;
        }
        .ListHeadDetails1 {
            padding-left: 2px;
            border-bottom: 1px solid #666666;
            border-right: 0px solid #666666;
            border-left: 1px solid #666666;
            border-top: 0px solid #666666;
        }
        div.tableContainer {
        }
    </style>
    <script language="javascript" type="text/javascript">
        var LODOP; //声明为全局变量 
        function printPage() {
            var bdhtml = window.document.body.innerHTML;

            var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
            var strFormHtml = strBodyStyle + "<body>" + document.getElementById("tableContainer").innerHTML + "</body>";

            /*
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            //LODOP.SET_SAVE_MODE("PaperSize", 9);
            //LODOP.SET_SAVE_MODE("centerHorizontally", true);
            LODOP.SET_PRINT_MODE("PRINT_PAGE_PERCENT", "98%");
            LODOP.ADD_PRINT_HTM("2%", "1%", "80%", "70%", strFormHtml);
            //LODOP.PREVIEW();
            LODOP.PRINT();
            //alert("1")
            // window.print();
            */
            document.body.innerHTML = strFormHtml
            window.print();
            window.close();
        }
    </script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>
<body onload="printPage()">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Lbl_Details" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
