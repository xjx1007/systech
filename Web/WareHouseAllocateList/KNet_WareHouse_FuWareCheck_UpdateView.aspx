<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_WareHouse_FuWareCheck_UpdateView.aspx.cs" Inherits="Web_WareHouseAllocateList_KNet_WareHouse_FuWareCheck_UpdateView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <title>库间调拨添加</title>
  
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>仓库 > <a class="hdrLink" href="KNet_WareHouse_AllocateList_Manage.aspx">调拨单添加</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_SuppNo" runat="server" Style="display: none"></asp:TextBox>
                </td>
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
                        <br>
                        <hr noshade size="1">

                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>调拨单信息
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
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;调拨单号:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="AllocateNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="调拨单号不能为空"
                                                    ControlToValidate="AllocateNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">调拨日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="AllocateDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="调拨日期非空"
                                                    ControlToValidate="AllocateDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;调出仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="HouseNo_out" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="调出仓库不能为空" ControlToValidate="HouseNo_out" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">调入仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="HouseNo_int" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="调入仓库不能为空" ControlToValidate="HouseNo_int" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">调拨类型:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Type" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="调拨类型不能为空" ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">生产订单号:
                                            </td>
                                            <td class="dvtCellInfo">

                                                <asp:TextBox ID="Tbx_OrderNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="150px" ></asp:TextBox><%--Enabled="false"--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">按耗料调拨:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:CheckBox runat="server" ID="Chk_Type" AutoPostBack="true"  />
                                            </td>
                                            <td class="dvtCellLabel">消耗库存:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:CheckBox runat="server" ID="Chk_KC" AutoPostBack="true"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">调拨原因:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="AllocateCause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        runat="server" ControlToValidate="AllocateCause" ValidationExpression="^(\s|\S){0,500}$"
                                                        ErrorMessage="调拨原因太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="dvtCellLabel">上传送货单:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="KPS_InvoiceUrl1" runat="server" Text="" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="KPS_Invoice1" runat="server" Text="" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:Label runat="server" ID="Lbl_Details1"></asp:Label><input id="uploadFile2"
                                                    type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button2" type="button"
                                                        value="上传" runat="server" class="crmbutton small save" onserverclick="button2_OnServerClick" causesvalidation="false" />
                                                (<font color="red">*</font>)
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">备注说明:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:TextBox ID="AllocateRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                        runat="server" ControlToValidate="AllocateCause" ValidationExpression="^(\s|\S){0,500}$"
                                                        ErrorMessage="调拨原因太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                            <%-- <td class="dvtCellLabel">消耗库存:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:CheckBox runat="server" ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="Chk_Type_CheckedChanged" />
                                            </td>--%>
                                        </tr>
                                        <tr runat="server" id="Tr_Order" visible="false">
                                            <td colspan="4" class="dvInnerHeader">
                                                <b>订单明细</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="Tbx_Number1" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                <table id="myTableMail" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                    class="crmTable" style="height: 28px">
                                                    <asp:Label runat="server" ID="Lbl_DetailsMail"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="dvInnerHeader">
                                                <b>产品详细信息</b>
                                            </td>
                                        </tr>

                                    </table>
                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="KWAD_DirectOutNo" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="TextBox1" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                        class="crmTable" style="height: 28px">
                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                    </table>
                                    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                        <!-- Add Product Button -->
                                      
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">&nbsp;
                                <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClick="Btn_Save_OnClick" Style="width: 55px; height: 33px;" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                        type="button" name="button" value="取 消" style="width: 55px; height: 33px;"><%--OnClientClick="return Submitcheck();"--%>
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>