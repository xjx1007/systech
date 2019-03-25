<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order_BasisSetting_Class.aspx.cs"
    Inherits="Order_BasisSetting_Class" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <title>采购设置</title>
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>

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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">采购设置</a>
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
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
                        <br>
                        <hr noshade size="1">

                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">

                            <tr>
                                <td>
                                    <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td>
                                                <table id="_ctl0_WorkForm_dlList" cellspacing="0" border="0" style="width: 100%; border-collapse: collapse;">
                                                    <tr>
                                                        <td style="width: 45%;">
                                                            <div onclick="location.href='Xs_Sales_BasisSetting_Class.aspx?id=2'" style="cursor: pointer">
                                                                <h5>1.采购类型</h5>
                                                                <p class="gray">
                                                                    对您公司客户的采购类型进行设置，如成品采购、塑壳、其他等。
                                                                </p>
                                                            </div>
                                                        </td>
                                                        <td style="width: 45%;">

                                                            <div onclick="location.href='../BasicCode/PB_Basic_Code_List.aspx?id=250'" style="cursor: pointer">
                                                                <h5>2.未达成原因设置</h5>
                                                                <p class="gray">
                                                                    对未达成原因设置设置，如品种多，单个数量小，换模具时间长。
                                                                </p>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                    </div>
                    <div class="grid">
                    </div>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
