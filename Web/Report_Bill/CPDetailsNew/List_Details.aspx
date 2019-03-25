<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_Details.aspx.cs"
    Inherits="Web_List_Details" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>存货收发结存表（成品）</title>
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <style type="text/css" id="style1">
        body {
            background: #FFF;
            color: #000;
            font: normal normal 14px Verdana, Geneva, Arial, Helvetica, sans-serif;
            margin: 10px;
            padding: 0;
            overflow-y: hidden;
        }
        table, td, a {
            color: #000;
            font: normal normal 14px Verdana, Geneva, Arial, Helvetica, sans-serif;
        }

        .td {
            nowrap: 'true';
        }

        div.tableContainer {
            
            overflow-y: scroll;
            overflow-x: scroll;
            margin-top: 5px;
            margin-left: 12px;
            padding-top: -2px;
            padding-bottom: 5px;

            background: none repeat scroll 0 0 #8F8F9A;
            border-spacing: 1px;
            margin: 0;
            clear: both;
            border: 1px solid #963;
            height: 551px;
            overflow: auto;
            width: 100%;
        }

        .tr_Head {
          position: relative;  
        }

        .thstyle {
            background: #C96;
            font-weight: normal;
            padding: 4px 1px;
            text-align: center;
            BORDER-BOTTOM: #000000 0px solid;
            BORDER-LEFT: #000000 0px solid;
            BORDER-TOP: #000000 1px solid;
            BORDER-RIGHT: #000000 1px solid;
            position: relative;
            z-index: 1;
        }

        .thstyleleft {
            background: #FFFFFF;
            border-left: 0px solid #EB8;
            border-right: 0px solid #B74;
            border-top: 0px solid #EB8;
            font-weight: normal;
            padding: 4px 3px;
            text-align: left;
            position: relative;
            z-index: 1;
        }

        .thstyleRight {
            background: #FFFFFF;
            border-left: 0px solid #EB8;
            border-right: 0px solid #B74;
            border-top: 0px solid #EB8;
            font-weight: normal;
            padding: 4px 3px;
            text-align: right;
            position: relative;
            z-index: 1;
        }

        .thstyleLeftDetails {
            BORDER-BOTTOM: #000000 0px solid;
            BORDER-LEFT: #000000 0px solid;
            BORDER-TOP: #000000 1px solid;
            BORDER-RIGHT: #000000 1px solid;
            height: auto;
        }


        .thsTitle {
            background: #FFFFFF;
            border-left: 0px solid #EB8;
            border-right: 0px solid #B74;
            border-top: 0px solid #EB8;
            font-weight: normal;
            padding: 4px 3px;
        }

        .rr {
            background-color: #FFFFEE;
        }

        .red1 {
            background-color: #FF4500;
        }

        .red {
            background-color: #FF00FF;
        }

        .gg {
            background-color: #dee2f2;
        }

        .MaterTitle {
            font-family: 方正姚体;
            white-space: nowrap;
            color: windowtext;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            text-align: center;
            vertical-align: middle;
            background: #FFFFFF;
            border: none;
        }

        .Custom_Hidden {
            display: none;
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
        function CreateOneFormPage() {
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("存货收发结存表");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            //  LODOP.ADD_PRINT_HTM(30, 0, "100%", "100%","<table width=\"100%\"><tr><td class=\"ListHeadDetails\" align=\"center\"><font color ='black' size ='6'>博脉与供应商对账确认单</font></td></tr></table>"); 
            //LODOP.ADD_PRINT_HTM(90, 0, "100%", "100%","<table width=\"100%\"><tr><td align=\"left\"><%=s_HouseName %></td><td align=\"right\"><%=s_Time %></td></tr></table>"); 
            var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
            var strFormHtml = strBodyStyle + "<body>" + document.getElementById("tableContainer").innerHTML + "</body>";

            LODOP.ADD_PRINT_TABLE(0, 0, "100%", "100%", strFormHtml);
        };
        function OutToFileMoreSheet() {
            var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
            var strFormHtml = strBodyStyle + "<body>" + document.getElementById("tableContainer").innerHTML + "</body>";

            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("");
            LODOP.ADD_PRINT_TABLE(130, 0, "100%", "100%", strFormHtml);
            LODOP.SET_SAVE_MODE("PAGE_TYPE", 1);
            LODOP.SET_SAVE_MODE("centerHeader", "页眉");
            LODOP.SET_SAVE_MODE("centerFooter", "第&P页");
            LODOP.SET_SAVE_MODE("Caption", "存货收发结存表");
            LODOP.SET_SAVE_MODE("RETURN_FILE_NAME", 1);
            LODOP.SAVE_TO_FILE("存货收发结存表.xls");
        };
    </script>
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="../../Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="../../Js/LodopFuncs.js"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" value="打印预览" onclick="javascript: prn1_preview()" id="Button1" Style="width: 55px; height: 30px;" />
            <input type="button" value="导出Excel" onclick="javascript: OutToFileMoreSheet()" id="Button2" Style="width: 55px; height: 30px;" />

            <asp:Button ID="Btn_Save" runat="server" Text="修改" AccessKey="S" title="修改[Alt+S]" Style="width: 55px; height: 30px;"
                class="crmbutton small save" OnClick="Btn_SaveOnClick" />
            <asp:Button ID="Button3" runat="server" Text="显示仓库" AccessKey="S" title="修改[Alt+S]" Style="width: 55px; height: 30px;"
                class="crmbutton small save" OnClick="Btn_SaveOnClick1" />
            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
            <asp:Label runat="server" ID="Lbl_Link"></asp:Label>
        </div>
        <asp:TextBox runat="server" ID="Tbx_Title" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="Tbx_Num" CssClass="Custom_Hidden"></asp:TextBox>
    </form>
</body>
</html>
