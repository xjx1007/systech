<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KnetWarehouse_add.aspx.cs"
    Inherits="Knet_Web_System_KnetWarehouse_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>仓库管理</title>
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
                document.all('OrderNo').value = ss[2];
            }
            else {
                document.all('SuppNoSelectValue').value = "";
                document.all('SuppNo').value = "";
                document.all('OrderNo').value = "";
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                仓库管理 > <a class="hdrLink" href="KnetWarehouse.aspx">仓库管理</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
        <tr>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td class="showPanelBg" valign="top" width="100%">
                <div class="small" style="padding: 10px">
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">
                    
                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>
                                            &nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            出库单信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                    <tr>
                                        <td class="dvtCellLabel">
                                            仓库名称:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="HouseName1" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="250px"></asp:TextBox>(<font
                                                    color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ErrorMessage="仓库名称不能为空！" ControlToValidate="HouseName1" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            联系电话:
                                        </td>
                                        <td class="dvtCellInfo">
                                            &nbsp;<asp:TextBox ID="HouseTel1" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="250px"></asp:TextBox><asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator4" runat="server" ErrorMessage="电话号码不正确!" ControlToValidate="HouseTel1"
                                                    ValidationExpression="^(\(\d{3,4}\)|\d{3,4}-)?\d{7,11}$" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            联 系 人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            &nbsp;<asp:TextBox ID="HouseMan1" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="250px"></asp:TextBox>(<font
                                                    color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                        ErrorMessage="联系人不能为空！" ControlToValidate="HouseMan1" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            仓库地址:
                                        </td>
                                        <td class="dvtCellInfo">
                                            &nbsp;<asp:TextBox ID="HouseAddress1" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="250px"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="仓库地址不能为空！" ControlToValidate="HouseAddress1"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            是否开库:
                                        </td>
                                        <td class="dvtCellInfo">
                                            &nbsp;<asp:CheckBox ID="HouseYN1" runat="server" /><font color="gray">（开库请选勾）</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            仓库类型:
                                        </td>
                                        <td class="dvtCellInfo">
                                            &nbsp;<asp:DropDownList runat="server" ID="Ddl_Type">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                runat="server" ErrorMessage="联系人不能为空！" ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            供应商:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <input type="hidden" name="SuppNoSelectValue" id="SuppNoSelectValue" runat="server" />
                                            <asp:TextBox ID="SuppNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="250px" MaxLength="48"></asp:TextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            建库时间:
                                        </td>
                                        <td class="dvtCellInfo">
                                            &nbsp;<asp:TextBox ID="HouseDate1" MaxLength="30" runat="server" CssClass="Wdate"
                                                onClick="WdatePicker()"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            备注:
                                        </td>
                                        <td class="dvtCellInfo">
                                            &nbsp;<asp:TextBox ID="Remarks1" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="250px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            &nbsp;
                                            <br />
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
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
