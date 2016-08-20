<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Material_MoneyChange_Add.aspx.cs"
    Inherits="Cw_Material_MoneyChange_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/../themes/softed/style.css" type="text/css">
    <title>采购发票</title>
    <script type="text/javascript" src="/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" >
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>财务 > <a class="hdrLink" href="Cw_Material_MoneyChange_List.aspx">原材料调整单</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_FID" runat="server" Style="display: none"></asp:TextBox>
                    
                </td>
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
                    <div class="small" style="padding: 10px">
                    </div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>原材料调整单信息
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
                                <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">编号:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编号不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker();ChangePayMent()"></asp:TextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td class="dvtCellLabel">金额:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Money" AllowEmpty="false" ValidError="票据金额不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px" onchange="ChangePayMent()"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>描述信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">备注:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="4">
                                                        <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px" Height="40px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">&nbsp;
                                        <br />
                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                    class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                &nbsp;<input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                    type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </td>
            <td valign="top">
                <img src="/../themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
