<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products_HandMoney.aspx.cs" Inherits="Web_Report_Bill_Products_HandMoney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>人工费用报表</title>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('SuppNoSelectValue').value = ss[0];
                document.all('SuppNo').value = ss[1];
            }
            else {
                document.all('SuppNoSelectValue').value = "";
                document.all('SuppNo').value = "";
            }
        }

        function OnClick() {
            var Tbx_Time = document.all('Tbx_Time').value;


            var s_URL = 'List_Products_HandMoney.aspx?';
            s_URL += '&Tbx_Time=' + Tbx_Time + '';
            window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>人工费用报表 > <a class="hdrLink" href="Products_HandMoney.aspx">人工费用报表</a>
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
                                <td align="right" valign="top">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr style="height: 28px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Div2');">
                                            <!-- windLayerHeadingTr -->
                                            <td colspan="4" align="left" valign="middle">&nbsp;&nbsp;计算&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 30px; width: 30px;" onclick="detail_info_click('Div2');">
                                                <img align="absmiddle" id="Div2_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                            </span>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4">
                                                <div id="Div2" style="display: none;">
                                                    <table width="100%" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="16%" align="right" class="dvtCellLabel">年月:
                                                            </td>
                                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                                <asp:TextBox ID="Tbx_Year" runat="server"></asp:TextBox>&nbsp;<asp:TextBox
                                                                    ID="Tbx_Month" runat="server"></asp:TextBox>
                                                                <asp:Button ID="Button2" type="button" runat="server" Text="计算" class="crmbutton small save" OnClick="Button2_OnClick"
                                                                    Style="width: 55px; height: 30px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>查询条件:</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">选择日期:
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <%-- <asp:TextBox ID="Tbx_Customer"  CssClass="detailedViewTextBox" Width="200px"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>--%>
                                                <asp:TextBox ID="Tbx_Time" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>
                                        </tr>

                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <input id="Button1" type="button" runat="server" value="确定" class="crmbutton small save"
                                                    onclick="OnClick()" style="width: 55px; height: 30px" />&nbsp;&nbsp;
            <input type="button" class="crmbutton small cancel" value="返回"  onclick="window.history.back()" style="width: 55px; height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td align="right" valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
        </td>
    </form>
</body>
</html>
