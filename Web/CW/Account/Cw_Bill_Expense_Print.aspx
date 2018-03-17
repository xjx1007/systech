<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Bill_Expense_Print.aspx.cs"
    Inherits="CG_Payment_For_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>�ÿ������ӡ</title>
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

	font-family: "����";

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
                                <span class="STYLE1"><strong>�ÿ�����</strong></span></div>
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
                                �ÿ���:
                               <asp:Label ID="Lbl_Code" runat="server"></asp:Label></td>
                            <td width="10%" align="right">
                                �ÿ����ڣ�
                               <asp:Label ID="Lbl_STime" runat="server"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                <table id="table_2" class="print ke-zeroborder" border="0" cellspacing="0" cellpadding="0"
                    width="100%" align="center">
                    <tbody>
                        <tr>
                            <td width="15%" align="right">
                                �ÿ���;</td>
                            <td width="25%" align="left">
                               <asp:Label ID="Lbl_Used" runat="server"></asp:Label></td>
                            <td width="15%" align="right">
                                �ÿʽ</td>
                            <td width="15%" align="left">
                                <asp:Label ID="Lbl_UseType" runat="server"></asp:Label>&nbsp;</td>
                            <td width="15%" align="right">
                                ��������</td>
                            <td width="15%" align="left">
                                <asp:Label ID="Lbl_Currency" runat="server"></asp:Label> &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">�ÿ���
                                </td>
                            <td align="left" colspan="3">(��д)
                               <asp:Label ID="Lbl_ChineseMoney" runat="server"></asp:Label></td>
                            <td   colspan="2" align="left">(Сд)
                                <asp:Label ID="Lbl_Money" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">�ÿ��
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_Depart" runat="server"></asp:Label></td>
                            <td width="15%" align="right">������
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">Ҫ������
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_YTime" runat="server"></asp:Label></td>
                            <td width="15%" align="right">����ǩ��
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_CwPerson" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">�տλȫ��
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_SuppName" runat="server"></asp:Label></td>
                            <td width="15%" align="right">�ܾ���ǩ��
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_ZPerson" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">�˺�
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_BankAccount" runat="server"></asp:Label></td>
                            <td width="15%" align="right">������
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_Bank" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">ʡ
                                </td>
                            <td align="left" colspan="2">
                               <asp:Label ID="Lbl_Shen" runat="server"></asp:Label></td>
                            <td width="15%" align="right">��
                                </td>
                            <td   colspan="2" align="left">
                                <asp:Label ID="Lbl_Shi" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr runat="server" id="Tr_Image">
                            <td  align="right">������Ϣ
                                </td>
                            <td align="left" colspan="5">
                                                <asp:Image ID="Lbl_Image" runat="server" Width="95px" Height="75px" />
                                </td>
                        </tr>
                        <tr>
                            <td width="15%" align="right">��ע
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
