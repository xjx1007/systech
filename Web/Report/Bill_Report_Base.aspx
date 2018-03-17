<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bill_Report_Base.aspx.cs" Inherits="Web_Report_Bill_Report_Base" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>单据报表</title>
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
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
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>单据报表 > <a class="hdrLink" href="Bill_Report_Base.aspx">单据报表</a>
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
                                                <table " width="100%">
                                                    
                                                    <tr>
                                                        <td  width="33%">
                                                            <font color="red" size="2">原材料</font>
                                                        </td>
                                                        <td  width="33%">
                                                            <font color="red" size="2">成品</font>
                                                        </td>
                                                        <td  width="33%">
                                                            <font color="red" size="2">报表</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="33%"  valign="top">
                                                            <ul>
                                                                <li><a href="../Report_Bill/Rk/Report_Order.aspx">原材料入库明细和汇总</a></li>
                                                                <li><a href="../Report_SC/ScDetails/Report_Xh.aspx">原材料耗料明细和汇总</a></li>
                                                                <li><a href="../Report_Bill/ScLl/Report_CkDetails2.aspx">原材料部门领料明细</a></li>
                                                                <li><a href="../Report_Bill/ScDetails/Report_Xh.aspx">原材料生产领料明细</a></li>
                                                                <li><a href="../Report_Bill/Db/Report_CkDetails3.aspx">原材料调拨明细</a></li>
                                                                <li><a href="../Reprot_KC/KC/Report_Kc.aspx?Type=1">库存报表</a></li>
                                                                <li><a href="../Report_Bill/Details/Report_Details.aspx">存货收发结存表(原材料)</a></li>
                                                            </ul>
                                                        </td>
                                                        <td width="33%" valign="top">
                                                            <ul>
                                                                <li><a href="../Report_Bill/ScIn/Report_OrderIn.aspx">成品直接入库明细</a></li>
                                                                <li><a href="../Report_Bill/ScInD/Report_OrderIn.aspx">成品生产入库明细</a></li>
                                                                <li><a href="../Report_Bill/ScLlDetails/Report_CkDetails2.aspx">成品领料明细</a></li>
                                                                <li><a href="../Report_Bill/XsOut/Report_CkDetails.aspx">销售出库明细</a></li>
                                                                <li><a href="../Report_Bill/DBCP/Report_CkDetails3.aspx">成品调拨明细</a></li>
                                                                <li><a href="../Report_Bill/DBCPWw/Report_CkDetails3.aspx">成品委外明细</a></li>

                                                                <li><a href="../Report_Bill/CPDetailsNew/Report_Details.aspx">存货收发结存表(成品)</a></li>

                                                               <!--      <li><a href="../Report_Bill/CPDetails/Report_Details.aspx">存货收发结存表(成品)</a></li>-->

                                                                
                                                          <!--      <li><a href="../Report_Sc/ScCb/Report_OrderIn.aspx">生产成本</a></li>-->
                                                            </ul>

                                                            </td>
                                                        <td valign="top" width="33%">
                                                            <ul>
                                                                <li><a href="../Report_Bill/Report_CustomerPayTime.aspx">客户帐期统计</a></li>
                                                                
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
