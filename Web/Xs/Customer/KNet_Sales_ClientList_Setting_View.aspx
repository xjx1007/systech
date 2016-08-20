<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_ClientList_Setting_View.aspx.cs"
    Inherits="KNet_Sales_ClientList_Setting_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>市场设置</title>
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>市场 > <a class="hdrLink" href="Order_BasisSetting_Class.aspx">市场设置</a>
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
                                    <div onclick="location.href='Xs_Sales_BasisSetting_Class.aspx?id=2'" style="cursor: pointer">
                                        <h5>1.业务类型</h5>
                                        <p class="gray">
                                            对您公司客户的业务类型进行设置，如遥控器、代理、物联网等。
                                        </p>
                                    </div>
                                </td>
                                <td style="width: 45%;">
                                    <div onclick="location.href='Xs_Sales_BasisSetting_Class.aspx?id=1'" style="cursor: pointer">
                                        <h5>2.营销渠道</h5>
                                        <p class="gray">
                                            对营销渠道属性设置，系统默认有“零售、运营商、配套厂家等”。
                                        </p>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <div onclick="location.href='Xs_Sales_BasisSetting_Class.aspx?id=3'" style="cursor: pointer">
                                        <h5>3.客户行业</h5>
                                        <p class="gray">
                                            对客户行业设置，系统有“零售、数字/物联网电视(广电)、数字/物联网电视(电信)、、数字/物联网电视(其他)、物联网(智能家居)、物联网(广电)、物联网(电信)”。
                                        </p>
                                    </div>
                                </td>
                                <td class="auto-style1">
                                    <div onclick="location.href='Xs_Sales_BasisSetting_Class.aspx?id=4'" style="cursor: pointer">
                                        <h5>4.客户来源</h5>
                                        <p class="gray">
                                            客户来源，系统有“展会/会议认识、客户主动联系、陌生开发、客户/朋友介绍、其他”。
                                        </p>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 45%;">
                                    <div onclick="location.href='/Web/BasicCode/PB_Basic_Code_List.aspx?id=112'" style="cursor: pointer">
                                        <h5>5.客户级别</h5>
                                        <p class="gray">
                                            客户级别，系统有“1星、2星、3星、4星、5星”。
                                        </p>
                                    </div>
                                </td>
                                <td style="width: 45%;">
                                    <div onclick="location.href='/Web/BasicCode/PB_Basic_Code_List.aspx?id=114'" style="cursor: pointer">
                                        <h5>6.客户类型</h5>
                                        <p class="gray">
                                            客户类型,系统有“客户、竞争者、投资商、合作伙伴、代理商、其他”。
                                        </p>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 45%;">
                                    <div onclick="location.href='/Web/BasicCode/PB_Basic_Code_List.aspx?id=113'" style="cursor: pointer">
                                        <h5>7.客户状态</h5>
                                        <p class="gray">
                                            客户状态，系统有“潜在、未成交、有意向、已成交”。
                                        </p>
                                    </div>
                                </td>
                                <td style="width: 45%;">
                                    <div onclick="location.href='/Web/BasicCode/PB_Basic_Code_List.aspx?id=115'" style="cursor: pointer">
                                        <h5>8.联系人称呼</h5>
                                        <p class="gray">
                                            联系人称呼，系统有“总经理、先生、小姐、台长等”。
                                        </p>
                                    </div>
                                </td>
                            </tr>
                        
                            <tr>
                                <td style="width: 45%;">
                                    <div onclick="location.href='/Web/BasicCode/PB_Basic_Code_List.aspx?id=765'" style="cursor: pointer">
                                        <h5>9.联系人负责事务</h5>
                                        <p class="gray">
                                            客户状态，系统有“采购、收货、业务、区域经理等”。
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
