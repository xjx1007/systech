<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_WareHouseList_Print.aspx.cs"
    Inherits="Web_SalesQuotes_Xs_Sales_Quotes_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="alternate icon" type="image/png" href="../../../images/ʿ��.png"/>
    <link rel="stylesheet" type="text/css" href="../../../themes/images/style_cn.css">
    <style type="text/css">

TABLE.print {vertical-align: middle;BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BORDER-COLLAPSE: collapse

}

TABLE.print TD {

	BORDER-RIGHT: #000000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #000000 1px solid; PADDING-LEFT: 5px; FONT-SIZE: 12px; BORDER-LEFT: #000000 1px solid; LINE-HEIGHT: 20px; BORDER-BOTTOM: #000000 1px solid;

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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <table class="ke-zeroborder" border="0" cellspacing="0" cellpadding="0" width="100%"
                align="center">
                <tbody>
                    <tr>
                        <td width="96%">
                            <div align="center">
                                <span class="STYLE1"><strong>�� �� �� �� ��FAX QUOTATION��</strong></span></div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table class="ke-zeroborder" border="0" cellspacing="2" cellpadding="0" width="100%"
                align="center">
                <tbody>
                    <tr>
                        <hr align="center" size="1" width="100%" noshade="noshade" />
                    </tr>
                </tbody>
            </table>
            <br />
            <div id="zoom" class="init_font">
                <table id="table_1" class="table_1 ke-zeroborder" border="0" cellspacing="0" cellpadding="0"
                    width="100%" align="center">
                    <tbody>
                        <tr>
                            <td width="10%" align="left">
                                ���۵����:</td>
                            <td width="30%" align="left">
                               <asp:Label ID="Lbl_Code" runat="server"></asp:Label></td>
                            <td width="10%" align="left">
                                &nbsp;</td>
                            <td width="30%" align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="163">
                                TO:</td>
                            <td width="284">
                                <%=s_CustomerName%>&nbsp;&nbsp;<%=s_LinkMan%></td>
                            <td width="163">
                                FROM:</td>
                            <td width="365">
                                <%=s_Company%>&nbsp;&nbsp;<%=s_DutypersonName%></td>
                        </tr>
                        <tr>
                            <td width="163">
                                FAX:</td>
                            <td width="284">
                            <asp:Label ID="Lbl_LinkManFax" runat="server"></asp:Label></td>
                            <td width="163">
                                FAX:</td>
                            <td width="365">
                               <asp:Label ID="Lbl_DutyPersonFax" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="163">
                                TEL:</td>
                            <td width="284">
                                <asp:Label ID="Lbl_LinkManTel" runat="server"></asp:Label></td>
                            <td width="163">
                                TEL:</td>
                            <td width="365">
                            <asp:Label ID="Lbl_DutyPersonTel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="163">
                                E-MAIL:</td>
                            <td width="284">
                                <asp:Label ID="Lbl_LinkManEmail" runat="server"></asp:Label></td>
                            <td width="163">
                                E-MAIL:</td>
                            <td width="365">
                                <asp:Label ID="Lbl_DutyPersonEmail" runat="server"></asp:Label></td>
                        </tr>
                    </tbody>
                </table>
                <p>
                    &nbsp; �𾴵�<span style="line-height: normal; font-family: Arial, Helvetica, sans-serif;"><%=s_LinkMan%></span>�����ã���л����<%=s_Company%>�����κ�֧�֣����Ǹ��������ṩ�Ĳ���Ϊ�������±��ۣ�</p>
                <table id="table_2" class="print ke-zeroborder" border="0" cellspacing="0" cellpadding="0"
                    width="100%" align="center">
                    <tbody>
                        <tr>
                            <td width="8%" align="center">
                                ���</td>
                            <td width="22%" align="center">
                                ��Ʒ����</td>
                            <td width="25%" align="center">
                                ����ͺ�</td>
                            <td width="10%" align="center">
                                ������λ</td>
                            <td width="10%" align="center">
                                ����</td>
                            <td width="10%" align="center">
                                ���</td>
                            <td width="15%" align="center">
                                ��ע</td>
                        </tr>
                        <%=s_Table %>
                    </tbody>
                </table>
                <br />
                <table id="table_3" class="table_1 ke-zeroborder" border="0" cellspacing="0" cellpadding="0"
                    width="100%" align="center">
                    <tbody>
                        <tr>
                            <td>
                                ��ע��<br />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <p>
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
