﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="IM_Project_Manage_Details_Add.aspx.cs"
    Inherits="IM_Project_Manage_Details_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/dom-drag.js"></script>
    <title>项目</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_CustomerID').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
            }
            else {

            }
        }

        function btnGetPerson_onclick() {
            var today, seconds;
            today = new Date();
            var v_Receive = document.all('Tbx_ReceiveID').value;
            var v_ReceiveName = document.all('Tbx_ReceiveName').value;
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Common/SelectDeptPerson.aspx?ID=" + v_Receive + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=600px;dialogHeight=500px");
            if (temp == undefined) {
                temp = window.returnValue;
            }
            if (temp != undefined) {
                var ss, s_Receive;
                ss = temp.split("|");
                document.all('Tbx_ReceiveID').value = ss[0];
                document.all('Tbx_ReceiveName').value = ss[1];
            }
            else {
                document.all('Tbx_ReceiveID').value = "";
                document.all('Tbx_ReceiveName').value = "";
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>研发 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">项目</a>
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
                    <img src="/../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>
                                                <asp:Label runat="server" ID="Lbl_Title"></asp:Label>
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>

                                            <pc:PTextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="200px" ValidType="String" Visible="false"></pc:PTextBox>

                                            <td width="16%" align="right" class="dvtCellLabel">名称：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Name" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px" ValidType="String"></pc:PTextBox></td>
                                            <td width="16%" align="right" class="dvtCellLabel">类型：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PDropdownList runat="server" ID="Ddl_Type" CodeNum="227" Width="200px" AllowSelect="false"></pc:PDropdownList>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">项目阶段：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_FID" Width="200px"></asp:DropDownList>
                                            </td>

                                            <td width="16%" height="25" align="right" class="dvtCellLabel">负责人:</td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="Tbx_ReceiveID" CssClass="Custom_Hidden" Width="200px"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_ReceiveName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="180px"></asp:TextBox>
                                                <img tabindex="8" src="/../themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetPerson_onclick()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">前置任务：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PDropdownList runat="server" ID="Ddl_FTaskID" AllowSelect="false" Width="200px"></pc:PDropdownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">工期：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Days" Width="200px" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></pc:PTextBox>
                                                (<font color="red">*</font>)<asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="工期不能为空" ControlToValidate="Tbx_Days"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">延隔时长：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_FloatingDays" Width="200px" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Text="0"></pc:PTextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td height="25" align="right" class="dvtCellLabel">简介：
                                            </td>
                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_Remarks" runat="server" TextMode="MultiLine" Height="50px" Width="500px"></asp:TextBox>
             
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Save_Click" Style="height: 30px; width: 70px" />
                                                &nbsp;<input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="height: 30px; width: 70px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_NID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_FID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_IPMID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Level" runat="server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="/../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
