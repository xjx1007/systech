<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_OrderListChart.aspx.cs" Inherits="Web_Report_Xs_Report_OrderList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>产品销售统计表</title>
        <script language="javascript" >
        function OnClick() {
            var StartDate = document.all('StartDate').value;
            var EndDate = document.all('EndDate').value;
            var ProductsType = document.all('Tbx_Type').value;
            var CustomerTypes = document.all('Tbx_CustomerTypes').value;
            var CustomerClass = document.all('CustomerClass').value;
            var CustomerName = document.all('Tbx_CustomerName').value;
            var s_URL = 'List_OrderListChart.aspx?StartDate=' + StartDate + '&EndDate=' + EndDate + '';
            s_URL += '&CustomerName=' + CustomerName + '';
            s_URL += '&ProductsType=' + ProductsType + '';
            s_URL += '&CustomerTypes=' + CustomerTypes + '';
            s_URL += '&CustomerClass=' + CustomerClass + '';
            window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">


            <div>
                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                    <tr>
                        <td style="height: 2px"></td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售报表 > <a class="hdrLink" href="Report_OrderListChart.aspx">产品销售统计表</a>
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
                            <div class="small" style="padding: 20px">
                                <span class="lvtHeaderText">
                                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                                <br>
                                <hr noshade size="1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                    <tr>
                                        <td class="dvtCellLabel">日期：</td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td width="17%" height="25" align="right" class="dvtCellLabel">客户名称:</td>
                                        <td align="left" class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_CustomerName" runat="Server"></asp:TextBox></td>
                                        <td align="right" class="dvtCellLabel">产品型号:</td>
                                        <td align="left" class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_Type" runat="Server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td width="17%" height="25" align="right" class="dvtCellLabel">客户类别:</td>
                                        <td align="left" class="dvtCellInfo">
                                            <asp:DropDownList ID="Tbx_CustomerTypes" runat="server">
                                            </asp:DropDownList></td>
                                        <td width="17%" height="25" align="right" class="dvtCellLabel">渠道:</td>
                                        <td align="left" class="dvtCellInfo">
                                            <asp:DropDownList ID="CustomerClass" runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" style="height: 30px">
                                            <input id="Button1" type="button" runat="server" value="确定" class="crmbutton small save" onclick="OnClick()"
                                                style="width: 55px; height: 30px" />&nbsp;&nbsp;
                                                <input type="button" class="crmbutton small cancel" value="返回" style="width: 55px; height: 30px"
                                                    onclick="PageGo('../Report/Xs_Report_Base.aspx')">
                                        </td>
                                    </tr>
                                </table>
                </td>
                <td align="right" valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif" />
                </td>
                    </tr>
                </table>
            </div>
    </form>
</body>
</html>
