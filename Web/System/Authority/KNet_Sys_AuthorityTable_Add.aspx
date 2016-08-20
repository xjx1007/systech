<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="KNet_Sys_AuthorityTable_Add.aspx.cs"
    Inherits="KNet_Sys_AuthorityTable_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>权限注册页面</title>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="KNet_Sys_AuthorityTable_List.aspx">权限注册页面</a>
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>权限注册页面
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                            <tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="14%" valign="top">
                                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                                    <tr>
                                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                                        </td>
                                                        <td id="catalog_tab" class="dvtSelectedCell" align="center" nowrap>
                                                            <a href="javascript:showProductCatalog()">菜单分类</a>
                                                        </td>
                                                        <td class="dvtTabCache" style="width: 100%">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer"
                                                                NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"
                                                                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                                                <ParentNodeStyle Font-Bold="False" />
                                                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False"
                                                                    HorizontalPadding="0px" VerticalPadding="0px" />
                                                            </asp:TreeView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="85%" align="left" valign="top" style="border-left: 2px dashed #cccccc;">
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">

                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">权限模块：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <asp:DropDownList runat="server" ID="Ddl_Model" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Model_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">功能名：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <asp:DropDownList runat="server" ID="Ddl_Function" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Function_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">权限注册页面标题：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <pc:PTextBox ID="Tbx_Title" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String"></pc:PTextBox><font
                                                                    color="red">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">相关页面：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <asp:CheckBoxList ID="Chk_AboutPages" runat="server">
                                                            </asp:CheckBoxList>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <asp:Panel runat="server" ID="Pan_OterPages">
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">同时其他页面添加：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <asp:CheckBoxList ID="Chk_OtherPages" runat="server">
                                                            </asp:CheckBoxList>&nbsp;
                                                        </td>
                                                    </tr>
                                                    </asp:Panel>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">用户组：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <asp:CheckBoxList ID="Chk_UserGroup" runat="server">
                                                            </asp:CheckBoxList>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" align="center" style="height: 30px">
                                                            <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                                class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                                type="button" name="button" value="取 消" style="height: 30px; width: 70px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_AuthorityValue" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
