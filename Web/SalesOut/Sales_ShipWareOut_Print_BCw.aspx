<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_ShipWareOut_Print_BCw.aspx.cs"
    Inherits="Sales_ShipWareOut_Print_BCw" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="../Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="../Js/LodopFuncs.js"></script>
    <title>成品领料单</title>
    <script language="javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            window.document.body.innerHTML = bdhtml;
        }

        var LODOP; //声明为全局变量 
        function prn1_preview() {
            CreateOneFormPage();
            LODOP.PREVIEW();
        }

        function CreateOneFormPage() {

            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("成品领料单");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", prnhtml);
        };

        function OutToFileMoreSheet() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("");
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", prnhtml);
            LODOP.SET_SAVE_MODE("PAGE_TYPE", 1);
            LODOP.SET_SAVE_MODE("centerHeader", "页眉");
            LODOP.SET_SAVE_MODE("centerFooter", "第&P页");
            LODOP.SET_SAVE_MODE("Caption", "成品领料单");
            LODOP.SET_SAVE_MODE("RETURN_FILE_NAME", 1);
            LODOP.SAVE_TO_FILE("成品领料单.xls");
        };
        function printPage() {
            var bdhtml = window.document.body.innerHTML;
            var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
            var strFormHtml = strBodyStyle + "<body>" + bdhtml + "</body>";
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.SET_SAVE_MODE("PaperSize", 9);
            LODOP.SET_SAVE_MODE("Zoom", 90);
            LODOP.SET_SAVE_MODE("centerHorizontally", true); 
            LODOP.ADD_PRINT_HTM(0, 0, 210, 500, strFormHtml);
            LODOP.PREVIEW();
            //  LODOP.PRINT();
            // window.print();
            //window.close();
        }
    </script>
    <style type="text/css" id="style1">
        .font7
        {
            color: windowtext;
            font-size: 18.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
        }
        .font0
        {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
        }
        .font8
        {
            color: windowtext;
            font-size: 14.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: right;
        }
        ruby
        {
            ruby-align: left;
        }
        ruby
        {
            ruby-align: left;
        }
        rt
        {
            color: windowtext;
            font-size: 9.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            display: none;
        }
        .style2
        {
            height: 24pt;
            color: windowtext;
            font-size: 10.5pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style3
        {
            width: 737pt;
            height: 42pt;
            color: windowtext;
            font-size: 18.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            padding: 0px;
        }
        .style4
        {
            width: 54pt;
            height: 28.5pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style5
        {
            width: 141pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style7
        {
            width: 113pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style8
        {
            width: 77pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style9
        {
            width: 123pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style10
        {
            width: 125pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 2.0pt double windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style13
        {
            width: 54pt;
            height: 36pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style14
        {
            width: 683pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style46
        {
            width: 104pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
    </style>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
    <OBJECT classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" height=0 id=wb name=wb width=0></OBJECT>  
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0" id="Body1" onload="printPage()">
    <form id="form1" runat="server">
    <!--startprint-->
    <table border="0" cellpadding="0" cellspacing="0" id="Table" width="96%">
        <colgroup>
            <col span="2" style="width: 54pt" width="72" />
            <col style="width: 87pt; mso-width-source: userset; mso-width-alt: 3712" width="116" />
            <col style="width: 104pt; mso-width-source: userset; mso-width-alt: 4416" width="138" />
            <col style="width: 113pt; mso-width-source: userset; mso-width-alt: 4800" width="150" />
            <col style="width: 77pt; mso-width-source: userset; mso-width-alt: 3296" width="103" />
            <col style="width: 123pt; mso-width-source: userset; mso-width-alt: 5248" width="164" />
            <col style="width: 125pt; mso-width-source: userset; mso-width-alt: 5344" width="167" />
            <col span="2" style="width: 54pt" width="72" />
        </colgroup>
        <tr height="20">
            <td colspan="9" height="20">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="0" width="0">
                        </td>
                        <td width="150">
                        </td>
                        <td width="600">
                        </td>
                        <td width="200">
                        </td>
                    </tr>
                    <tr>
                        <td height="9">
                        </td>
                        <td colspan="2">
                        </td>
                        <td align="left" rowspan="2" valign="top">
                            <img alt="logo中1-2" height="29" src="../../images/士兰微芯片订单_22424_image003.png" v:shapes="Picture_x0020_5" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                        </td>
                        <td align="left" valign="top">
                            <img alt="logo英1-2" height="20" src="../../images/士兰微芯片订单_22424_image004.png" v:shapes="Picture_x0020_3" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr height="25">
            <td class="style2" colspan="9" height="32" style="mso-ignore: colspan">
                地址：杭州西湖科技园西园九路7号综合楼四楼 - 310012<span style="mso-spacerun: yes"> </span>电话：0571-88210386<span
                    style="mso-spacerun: yes"> </span>传真：0571-87672166<span style="mso-spacerun: yes">
                </span>领料人：<asp:Label ID="Lbl_FPerson" runat="server"></asp:Label>
                &nbsp;电话：88210386<span style="mso-spacerun: yes"> </span>
            </td>
        </tr>
        <tr height="5">
            <td colspan="9" height="14">
            </td>
        </tr>
        <tr height="26">
            <td class="style3" colspan="9" height="16">
                成品领料单 <font class="font7">
                    <br />
                </font>
                <ruby><font 
                    class="font13"><rt class="font13"></rt></font></ruby>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="left" height="30">
                客户名称：<asp:Label ID="Lbl_CustomName" runat="server"></asp:Label>
            </td>
            <td colspan="3" align="left">
                成品领料单号：<asp:Label ID="Lbl_Code" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="left" height="30">
                收货人：<asp:Label ID="Lbl_LinkMan" runat="server"></asp:Label>
            </td>
            <td colspan="3" align="left">
                领料日期：<asp:Label ID="Lbl_CKTime" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" align="left" height="30">
                客户地址：<asp:Label ID="Lbl_Address" runat="server"></asp:Label>
            </td>
            <td colspan="3" align="left">
                领料仓库：成品库
            </td>
        </tr>
        <tr height="48">
            <td class="style13" height="30">
                项次
            </td>
            <td class="style5">
                品名
            </td>
            <td class="style7">
                型号
            </td>
            <td class="style9">
                数量
            </td>
            <td class="style10" colspan="5">
                备注
            </td>
        </tr>
        <asp:Label ID="Lbl_Details" runat="server"></asp:Label>
        <tr height="38">
            <td class="style4" height="30">
                备注
            </td>
            <td class="style14" colspan="9">
                <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>
            </td>
        </tr>
        <tr height="14">
            <td colspan="9" height="14">
            </td>
        </tr>
        <tr height="38">
            <td>
            </td>
            <td align="center" nowrap>
                收货单位
            </td>
            <td colspan="1">
            </td>
            <td align="center" nowrap>
                审核
            </td>
            <td colspan="2">
            </td>
            <td align="center" nowrap>
                市场部
            </td>
            <td>
            </td>
            <td align="center" nowrap>
                仓管
            </td>
        </tr>
        <tr height="30">
            <td>
            </td>
            <td align="center" class="style46" nowrap>
                &nbsp; <u style="visibility: hidden; mso-ignore: visibility"></u>
            </td>
            <td colspan="1">
            </td>
            <td align="center" class="style46" nowrap>
                黄景江 <u style="visibility: hidden; mso-ignore: visibility"></u>
            </td>
            <td colspan="2">
            </td>
            <td align="center" class="style46" nowrap>
                <asp:Label ID="Lbl_Person" runat="server"></asp:Label>
                <u style="visibility: hidden; mso-ignore: visibility"></u>
            </td>
            <td>
            </td>
            <td align="center" class="style46" nowrap>
                <asp:Label ID="Lbl_CkPerson" runat="server"></asp:Label>
                <u style="visibility: hidden; mso-ignore: visibility"></u>
            </td>
        </tr>
    </table>
    <!--endprint-->
    <asp:TextBox runat="server" ID="Tbx_ID" Style="display: none"></asp:TextBox>
    <asp:TextBox runat="server" ID="Tbx_DID" Style="display: none"></asp:TextBox>
    <asp:TextBox runat="server" ID="Tbx_Number" Style="display: none" Text="0"></asp:TextBox>
    </form>
</body>
</html>
