<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_ClientList_Setting_View.aspx.cs"
    Inherits="KNet_Sales_ClientList_Setting_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>产品设置</title>
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 45%;
            height: 107px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>市场 > <a class="hdrLink" href="Order_BasisSetting_Class.aspx">产品设置</a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
                        <br>
                        <hr noshade size="1">
                        <table id="_ctl0_WorkForm_dlList" cellspacing="0" border="0" style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td style="width: 45%;">
                                    <div onclick="location.href='/Web/BasicCode/PB_Basic_Code_List.aspx?id=779'" style="cursor: pointer">
                                        <h5>1.项目设置</h5>
                                        <p class="gray">
                                            对您公司项目进行设置用于研发领用项目等。
                                        </p>
                                    </div>
                                </td>
                                <td style="width: 45%;">
                                    <div onclick="location.href='/Web/BasicCode/PB_Basic_Code_List.aspx?id=779'" style="cursor: pointer">
                                        <h5></h5>
                                        <p class="gray">
                                            
                                        </p>
                                    </div>
                                </td>
                            </tr>
                   
                        </table>
                    </div>
                    <div class="grid">
                    </div>
                </td>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
