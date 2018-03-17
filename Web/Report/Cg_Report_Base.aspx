<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cg_Report_Base.aspx.cs" Inherits="Web_Report_Cg_Report_Base" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>采购报表</title>
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <body>
        <form id="form1" runat="server">
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购报表 > <a class="hdrLink" href="Cg_Report_Base.aspx">采购报表</a>
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
                                                <table style="height: 312px; width: 898px">
                                                    
                                                    <tr>
                                                        <td  width="33%">
                                                            <font color="red" size="2">采购</font>
                                                        </td>
                                                        <td  width="33%">
                                                            <font color="red" size="2">供应商</font>
                                                        </td>
                                                        <td  width="33%">
                                                            <font color="red" size="2">报表</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="33%" valign="top">
                                                            <ul> 
                                                                <li><a href="../Report_Cg/Order/Report_Order.aspx">杭州士腾订单汇总表</a></li>
                                                                    <li><a href="../Report_Cg/Order/Report_OrderList.aspx">杭州士腾订单明细表</a></li>
                                                                    <li><a href="../Report_Cg/OrderIn/Report_OrderIn.aspx">采购入库明细</a></li>
                                                                    <li><a href="../Report_CG/Report_CkDetails.aspx">客户出货明细表</a></li>
                                                                    <li><a href="../Report_CG/Report_CkDetails.aspx">采购统计汇总</a></li>
                                                                    <li><a href="../Report_CG/Report_ProductsDetails.aspx">产品明细</a></li>
                                                                    <li><a href="../Report_CG/Report_ProductsBom.aspx">产品Bom表</a></li>
                                                                    <li><a href="../Report_CG/Fright/Report_Fright.aspx">运费承担明细</a></li>
                                                                    <li><a href="../Report_CG/Check/Report_Fright.aspx">采购对账明细</a></li>
                                                                    <li><a href="../Report_CG/Time/Report_Time.aspx">物料准时率报表</a></li>
                                                                    <li><a href="../Report_Xs/Report_CkDetails3.aspx">成品调拨明细</a></li>
                                                            </ul>
                                                        </td>
                                                        <td width="33%" valign="top">
                                                            <ul>
                                                                <li><a href="../Report_Cg/CgPrice/Report_SuppPrice.aspx">供应商报价表</a></li>
                                                                <li><a href="../Report_Cg/MonthOrder/Report_Order.aspx">供应商月采购金额</a></li>
                                                                <li><a href="../Report_Cg/ChartMonthOrder/Report_Order.aspx">供应商月采购金额图表</a></li>
                                                                <li><a href="../Report_Cg/Supp/Report_Fright.aspx">合格供应商名录</a></li>
                                                            </ul>

                                                            </td>
                                                        <td valign="top" width="33%">
                                                            <ul>
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
