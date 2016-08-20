<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sc_Report_Base.aspx.cs" Inherits="Web_Report_Cg_Report_Base" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>生产报表</title>
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <body>
        <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                   生产报表 > <a class="hdrLink" href="Cg_Report_Base.aspx">生产报表</a>
                </td>
                <td width="100%" nowrap>
                </td>
            </tr>
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
            <tr>
                <td valign="top" width="1%" >
                    <img src="../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td width="98%" >
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td class="showPanelBg" valign="top" width="100%">
                                <br>
                                <hr noshade size="1">
                                
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <ul>
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
                                                                            <li><a href="../Report_Sc/ScIn/Report_OrderIn.aspx">生产入库明细</a></li>
                                                                            <li><a href="../Report_Sc/ScInPrint/Report_OrderIn.aspx">生产入库单</a></li>
                                                                            <li><a href="../Report_Sc/ScDetails/Report_Xh.aspx">生产耗料明细</a></li>
                                                                            <li><a href="../Report_Sc/ScDetailsPrint/Report_Xh.aspx">生产耗料明细单</a></li>
                                                                            <li><a href="../Report_Sc/ScSum/Report_OrderIn.aspx">产品出货统计表</a></li>
                                                                            
                                                                        </ul>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                <td valign="top"  width="1%">
                    <img src="../../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
        </form>
    </body>
</html>
