﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PB_Mail_Setting_Add.aspx.cs"
    Inherits="PB_Mail_Setting_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>发件人添加</title>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                工作台 > <a class="hdrLink" href="PB_Basic_Menu_List.aspx">发件人</a>
            </td>
            <td width="100%" nowrap>
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
                <div class="small" style="padding: 20px">
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">
                    
                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>
                                            &nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            发件人
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
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        SMTP服务器：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <pc:PTextBox ID="Tbx_Sever" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String"></pc:PTextBox>
                                                    </td>
                                                </tr>     
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        SMTP端口：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <pc:PTextBox ID="Tbx_Port" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Text="25" Width="400px" ValidType="String"></pc:PTextBox>
                                                    </td>
                                                </tr>     
                                               
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        EMail：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <pc:PTextBox ID="Tbx_Email" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String"></pc:PTextBox>
                                                    </td>
                                                </tr>     
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        密码：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <pc:PTextBox ID="Tbx_Password" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String"></pc:PTextBox>
                                                    </td>
                                                </tr>    
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        需要验证：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <asp:CheckBox runat="server" ID="Chk_Verification"  Enabled="false" Checked/>
                                                    </td>
                                                </tr>    
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        发送邮件：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <pc:PTextBox ID="Tbx_SendEmail" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String"></pc:PTextBox>
                                                    </td>
                                                </tr>   
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        发送人：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <pc:PTextBox ID="Tbx_SendPerson" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String"></pc:PTextBox>
                                                    </td>
                                                </tr>   
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        发送间隔：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <pc:PTextBox ID="Tbx_Seconds" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Text="5" Width="400px" ValidType="String"></pc:PTextBox>
                                                    </td>
                                                </tr>   
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" style="height: 30px">
                                            <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Btn_Send_Click" style="height: 30px;width: 70px"/>
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="height: 30px;width: 70px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Code" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_FileUrl" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_User" runat="server"  Visible="false"></asp:TextBox>
                    <asp:TextBox ID="Tbx_UserPassWord" runat="server" Visible="false"></asp:TextBox>
                    
            </td>
        </tr>
    </table>
    </td>
    <td align="right" valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif" />
    </td>
    </tr> </table>
    </form>
</body>
</html>
