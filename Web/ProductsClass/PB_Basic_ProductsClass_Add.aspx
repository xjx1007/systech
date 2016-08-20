<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PB_Basic_ProductsClass_Add.aspx.cs"
    Inherits="PB_Basic_ProductsClass_Add" %>
    
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="pc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <title>产品分类信息</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
        <tr>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td>
            <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                <tr> 
                    <td class="showPanelBg" valign="top" width="100%">
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
                                                产品分类信息
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
                                    <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td>
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>基本信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="17%" height="25" align="right" class="dvtCellLabel">
                                                            上级分类:</td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="Tbx_FaterID" runat="server" CssClass="Custom_Hidden" ></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_FaterName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="48"></asp:TextBox>
                                                            <img src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetReturnValue_onclick()" /></td>
                                                    <tr>
                                                        <td class="dvtCellLabel">
                                                            编码:
                                                        </td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编码不能为空"
                                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">
                                                分类名称:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <pc:PTextBox runat="server" ID="Tbx_Name" AllowEmpty="false" ValidError="名称不能为空"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                (<font color="red">*</font>)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel" >
                                                排序:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <pc:PTextBox runat="server" ID="Tbx_Order" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                 <span style="color: red">数字越小，位置越靠前</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel" >
                                                默认采购到货天数:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <pc:PTextBox runat="server" ID="Tbx_OrderDays" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel" >
                                                缺料提醒天数:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <pc:PTextBox runat="server" ID="Tbx_Days" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            </td>
                                        </tr>
             
                            <tr>
                                <td colspan="4" align="center">
                                    &nbsp;
                                    <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClick="Btn_SaveOnClick"  style="width: 55px;height: 33px;" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                        type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                </td>
                            </tr>
                        </table>
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
