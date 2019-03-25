<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Reveive.aspx.cs" Inherits="Web_Report_Reveive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <title>应收款结存表</title>
    <script language="JAVASCRIPT">

        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

            if (tempd == undefined) {
                tempd = window.returnValue;
            }
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
            }
            else {
                document.all('Tbx_CustomerValue').value = "";
                document.all('Tbx_CustomerName').value = "";
            }
        }

        function btnGetProductsTypeValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsTypeNo').value = ss[0];
                document.all('Tbx_ProductsTypeName').value = ss[1];
            }
            else {
                document.all('Tbx_ProductsTypeNo').value = "";
                document.all('Tbx_ProductsTypeName').value = "";
            }
        }
        function OnClick() {
            var StartDate = document.all('StartDate').value;
            var EndDate = document.all('EndDate').value;
            var CustomerName = document.all('Tbx_CustomerValue').value;
            var Ddl_Have = document.all('Ddl_Have').value;
            var s_URL = 'List_Reveive.aspx?StartDate=' + StartDate + '&EndDate=' + EndDate + '';
            s_URL += '&CustomerValue=' + CustomerName + '';
            s_URL += '&Have=' + Ddl_Have + '';
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>财务报表 > 
                    <a class="hdrLink" href="Procure_ShipCheck_List.aspx">应收款结存表</a>
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
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                            <tr>
                                <td align="right" valign="top">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">日期:
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox
                                                    ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">客户:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                    style="width: 150px" />
                                                <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" MaxLength="48" Width="200px"></asp:TextBox>
                                                <img tabindex="8" src="../../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="客户不能为空"
                                                    ControlToValidate="Tbx_CustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">是否包含核销:
                                            </td>
                                            <td class="dvtCellInfo" align="left" >
                                                <asp:DropDownList ID="Ddl_Have" CssClass="detailedViewTextBox" Width="200px"
                                                    runat="server">
                                                    <asp:ListItem Value="0" Text="是"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="否"></asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <input id="Button1" type="button" runat="server" value="确定" class="crmbutton small save"
                                                    onclick="OnClick()" style="width: 55px; height: 30px" />&nbsp;&nbsp;
                                <input type="button" class="crmbutton small cancel" value="返回" style="width: 55px; height: 30px"
                                    onclick="window.history.back()">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td align="right" valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
        </td>
    </form>
</body>
</html>
