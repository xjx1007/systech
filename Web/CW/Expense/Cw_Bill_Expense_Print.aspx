<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Bill_Expense_Print.aspx.cs"
    Inherits="CG_Payment_For_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用款申请打印</title>
    <style type="text/css" id="style1">

TABLE.print {vertical-align: middle;BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BORDER-COLLAPSE: collapse

}

TABLE.print TD {

	BORDER-RIGHT: #000000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #000000 1px solid; PADDING-LEFT: 5px; FONT-SIZE: 13px; BORDER-LEFT: #000000 1px solid; LINE-HEIGHT: 30px; BORDER-BOTTOM: #000000 1px solid;

}

TABLE.print .right {

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

	FONT-SIZE: 12px;

	BORDER-LEFT: #000000 0px solid;

	LINE-HEIGHT: 20px;

	BORDER-BOTTOM: #000000 0px solid;

	padding-bottom: 0px;

}.STYLE1 {

	font-family: "黑体";

	line-height: 30px;

	font-size: 20px;

}</style>
    <meta name="GENERATOR" content="MSHTML 6.00.6000.16735">
    
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript">
        function printPage() {
            var bdhtml = window.document.body.innerHTML;
    

            var strBodyStyle = "<style>" + document.getElementById("style1").innerHTML + "</style>";
            var strFormHtml = strBodyStyle + "<body>" + document.getElementById("tableContainer").innerHTML + "</body>";
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));

            document.all.TextBox1.value = strFormHtml;
            //LODOP.SET_SAVE_MODE("PaperSize", 9);
            //LODOP.SET_SAVE_MODE("centerHorizontally", true);
            LODOP.SET_PRINT_MODE("PRINT_PAGE_PERCENT", "90%");
            LODOP.ADD_PRINT_HTM(0, 0, 800, 500, strFormHtml);
            //LODOP.PREVIEW();
            LODOP.PRINT();
            // window.print();
            window.close();
        }
    </script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="/Web/Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="/Web/Js/LodopFuncs.js"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0"
        height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" id="Body1"  onload="printPage()">
    <form id="form1" runat="server">
    
        <div id="tableContainer">
            <br />
            <table class="ke-zeroborder" border="0" cellspacing="0" cellpadding="0" width="100%"
                align="center">
                <tbody>
                    <tr>
                        <td width="96%">
                            <div align="center">
                                <span class="STYLE1"><strong>用款申请</strong></span></div>
                            <asp:TextBox runat="server" ID="TextBox1" CssClass="Custom_Hidden"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="zoom" class="init_font">
                <table id="table_1" class="table_1 ke-zeroborder" border="0" cellspacing="0" cellpadding="0"
                    width="100%" align="center">
                    <tbody>
                        <tr>
                            <td width="10%" align="left">
                                用款单编号:
                               <asp:Label ID="Lbl_Code" runat="server"></asp:Label></td>
                            <td width="10%" align="right">
                                用款日期：
                               <asp:Label ID="Lbl_STime" runat="server"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                <table id="table_2" class="print ke-zeroborder" border="0" cellspacing="0" cellpadding="0"
                    width="100%" align="center">
                    <tbody>
                        <tr>
                            <td width="15%" align="right">
                                用款用途</td>
                            <td width="25%" align="left">
                               <asp:Label ID="Lbl_Used" runat="server"></asp:Label></td>
                            <td width="15%" align="right">
                                用款方式</td>
                            <td width="15%" align="left">
                                <asp:Label ID="Lbl_UseType" runat="server"></asp:Label>&nbsp;</td>
                            <td width="15%" align="right">
                                货币种类</td>
                            <td width="15%" align="left">
                                <asp:Label ID="Lbl_Currency" runat="server"></asp:Label> &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">用款金额
                                </td>
                            <td align="left" colspan="3">(大写)
                               <asp:Label ID="Lbl_ChineseMoney" runat="server"></asp:Label></td>
                            <td   colspan="2" align="left">(小写)
                                <asp:Label ID="Lbl_Money" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">用款部门
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_Depart" runat="server"></asp:Label></td>
                            <td width="15%" align="right">申请人
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">要求日期
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_YTime" runat="server"></asp:Label></td>
                            <td width="15%" align="right">财务签批
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_CwPerson" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">收款单位全称
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_SuppName" runat="server"></asp:Label></td>
                            <td width="15%" align="right">总经理签批
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_ZPerson" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">账号
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_BankAccount" runat="server"></asp:Label></td>
                            <td width="15%" align="right">开户行
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_Bank" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">省
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_Shen" runat="server"></asp:Label></td>
                            <td width="15%" align="right">市
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_Shi" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr runat="server" id="Tr_Image">
                            <td  align="right">附件信息
                                </td>
                            <td align="left" colspan="5">
                                                <asp:Image ID="Lbl_Image" runat="server" Width="95px" Height="75px" />
                                </td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">备注
                                </td>
                            <td align="left" colspan="5">
                               <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <!--

.STYLE1 {

font-size: 16; font-weight: bold;

}

-->
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
