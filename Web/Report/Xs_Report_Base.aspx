<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Report_Base.aspx.cs" Inherits="Web_Report_Xs_Report_Base" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>

    <title>销售报表</title>
</head>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <body>


        <form id="form2" runat="server">
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售报表 > <a class="hdrLink" href="Xs_Report_Base.aspx">销售报表</a>
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
                                                        <td valign="top" width="33%">
                                                            <ul>
                                                                <li><a href="../Report_Xs/OrderList/Report_OrderList.aspx">订单执行情况表</a></li>
                                                                 <li><a href="../Report_Xs/OrderList/Accounting_Payment_List.aspx">开票情况表</a></li>
                                                                <li><a href="../Report_Xs/Report_CustomerOrderDetails.aspx">客户合同出货明细表</a></li>
                                                                <li><a href="../Report_Xs/OrderDetails/Report_OrderIn.aspx">订单评审明细</a></li>
                                                                <li><a href="../Report_Xs/Report_XsDetails.aspx">销售发货明细</a></li>
                                                                <li><a href="../Report_Xs/Report_CkDetails.aspx">销售出库明细</a></li>
                                                                <li><a href="../Report_Xs/Price/Report_Price.aspx">产品销售价格明细</a></li>
                                                                <li><a href="../Report_Xs/Report_OrderListChart.aspx">产品销量统计表</a></li>
                                                                <li><a href="../Report_Xs/Report_CustomerChart.aspx">渠道销量统计表</a></li>
                                                                <li><a href="../Report_Xs/Report_CustomerOrderChart.aspx">客户销售排名统计表</a></li>
                                                                <li><a href="../Report_Xs/MonthChart/Report_OrderListChart.aspx">重点机顶盒厂销售趋势图</a></li>
                                                                <li><a href="../Report_Xs/MonthAareChart/Report_OrderListChart.aspx">重点区域销售趋势图</a></li>
                                                            </ul>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <ul>
                                                                <li><a href="../Report_Xs/Receive/Report_Recceive.aspx">客户应收款</a></li>
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

