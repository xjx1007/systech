<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Report_Base.aspx.cs" Inherits="Web_Report_Bill_Report_Base" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>财务报表</title>
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
<link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <body>
        <form id="form1" runat="server">
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>财务报表 > <a class="hdrLink" href="Cw_Report_Base.aspx">单据报表</a>
                    </td>
                    <td width="100%" nowrap></td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>



            <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                <tr>
                    <td valign="top">
                        <img src="../../themes/softed/images/showPanelTopLeft.gif">
                    </td>
                    <td class="showPanelBg" valign="top" width="100%">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">

                                        <tr>
                                            <td colspan="4" align="left">

                                                <table>
                                                    <tr>
                                                        <td>
                                                            <font color="red" size="4">报表</font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <ul>
                                                                <li><a href="../Report_Cw/Bank/Report_Bank.aspx">银行日记账</a></li>
                                                                <li><a href="../Report_Cw/Money/Report_Bank.aspx">现金日记账</a></li>
                                                                <li><a href="../Report_Cw/Bill/Report_Bank.aspx">票据往来账</a></li>
                                                                <li><a href="../Report_Cw/TransferCheque/Report_Details.aspx">支出明细</a></li>
                                                                <li><a href="../Report_Cw/Pay/Report_Reveive.aspx">收款单明细表</a></li>
                                                                <li><a href="../Report_Cw/Receive/Report_Reveive.aspx">应收款结存表</a></li>
                                                                <li><a href="../Report_Cw/YS/Report_Reveive.aspx">应收帐款明细</a></li>
                                                                <li><a href="../Report_Cw/Report_DlkDetails.aspx">代理费明细</a></li>
                                                                <li><a href="../Report_Cw/Bond/Report_Bank.aspx">保证金</a></li>

                                                                <li><a href="../Report_Cw/Products/Report_Kc.aspx">成品最新成本明细</a></li>
                                                            </ul>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <img src="../../themes/softed/images/showPanelTopRight.gif">
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
