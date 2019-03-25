<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SC_Product_HomeNum.aspx.cs" Inherits="Web_SC_SC_Product_HomeNum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <link rel="stylesheet" href="/Web/css/ihwy-2012.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="/Web/cssjquery.listnav-2.1.css" type="text/css" media="screen" charset="utf-8" />
    <script type="text/javascript" src="/Web/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.cookie.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.idTabs.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.listnav-2.1.js" charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            if (top.location.href.toLowerCase() == self.location.href.toLowerCase()) $('#docLink').show();
            $("#tabNav ul").idTabs("tab1");
        });

    </script>
    <title>临时物料库存表</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品 > <a class="hdrLink" href="KnetProductsSetting.aspx"></a>
                        <a href="BOM.aspx">BOM</a>
                    </td>
                    <td width="100%" nowrap>
                        <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
                        <asp:Label ID="Tbx_BomNumber" runat="server" Style="display: none"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                <tr>
                    <td valign="top">
                        <img src="../../themes/softed/images/showPanelTopLeft.gif" />
                    </td>
                    <td class="showPanelBg" valign="top" width="100%">
                        <div class="small" style="padding: 10px">
                        </div>
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">

                            <tr>
                                <td colspan="4" class="detailedViewHeader">
                                    <b>
                                        <asp:Label runat="server" ID="Lbl_BomTitle"></asp:Label>:</b>
                                    <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:Button runat="server" ID="Btn_Excel" Text="导出Excel" OnClick="Btn_Excel_OnClick" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                    <asp:Label runat="server" ID="Lbl_BomDetails1"></asp:Label>
                                </td>
                            </tr>
                            <asp:TextBox runat="server" ID="Tbx_Bom" CssClass="Custom_Hidden"></asp:TextBox>
                        </table>
                    </td>
                    <td valign="top">
                        <img src="../../themes/softed/images/showPanelTopRight.gif" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
