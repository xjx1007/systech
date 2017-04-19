﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_WareHouse_WareCheck_View.aspx.cs" Inherits="Web_KNet_WareHouse_WareCheck_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>查看库存调拨</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>库存 > 
	<a class="hdrLink" href="KNet_WareHouse_AllocateList_Manage.aspx">库存调拨</a>
                </td>
                <td width="100%" nowrap>
                    <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopLeft.gif"></td>
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;</td>

                                            <td <%=s_OrderStyle%> align="center" nowrap>
                                                <a href="KNet_WareHouse_WareCheck_View.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">库存调拨单信息</a>
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;</td>
                                            <td <%=s_DetailsStyle%> align="center" nowrap>
                                                <a href="KNet_WareHouse_WareCheck_View.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">相关信息</a>
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">

                                        <tr>
                                            <td valign="top" align="left">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" id="Table_Btn" runat="server">
                                                    <tr>
                                                        <td>
                                                            <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('KNet_WareHouse_AllocateList_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;">&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('KNet_WareHouse_AllocateList_Manage.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                      <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批"
                                          OnClick="btn_Chcek_Click" Width="54px" /></td>

                                                        <td align="right">
                                                            <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create" onclick="PageGo('KNet_WareHouse_AllocateList_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')" name="Duplicate" value="复制">&nbsp;
                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px" rowspan="2">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="genHeaderSmall">操作</td>
                                                    </tr>
                                                    <!-- Module based actions starts -->

                                                    <tr>
                                                        <td align="left" style="padding-left: 10px; border-bottom: 1px dotted #CCCCCC;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <a href="../CustomerContent/Xs_Sales_Content_Add.aspx?CustomerValue=<%=s_CustomerValue %>&LinkMan=<%=s_LinkMan %>&OppID=<%=s_OppID %>" class="webMnu">创建合同评审</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <span class="genHeaderSmall">工具</span><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" />
                                                            <a href="javascript: document.DetailView.return_module.value='Quotes';document.DetailView.return_action.value='DetailView';document.DetailView.module.value='Quotes'; document.DetailView.action.value='CreatePDF';document.DetailView.record.value='1742'; document.DetailView.return_id.value='1742';document.DetailView.submit();" class="webMnu">导出Excel</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="absmiddle" />
                                                            <a href="index.php?module=Quotes&action=CreatePDFPrint&record=1742" target="_blank" class="webMnu">打
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Pan_Order" runat="server">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr>
                                                            <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">调拨单号:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_Code" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="dvtCellLabel">调拨日期:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        
                                        <tr>
                                            <td class="dvtCellLabel">生产订单号:
                                            </td>
                                            <td class="dvtCellInfo" >
                                                                <asp:Label ID="Tbx_OrderNo" runat="server"></asp:Label></td>

                                            </td>
                                            <td class="dvtCellLabel">调拨类型:
                                            </td>
                                            <td class="dvtCellInfo" >
                                                                <asp:Label ID="Chk_Type" runat="server"></asp:Label></td>

                                            </td>
                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">调出仓库:</td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:Label ID="Lbl_HouseNo" runat="server" Style="display: none"></asp:Label>
                                                                <asp:Label ID="Lbl_House_Out" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">调入仓库:</td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:Label ID="Lbl_House_int" runat="server"></asp:Label>
                                                                <asp:Label ID="Lbl_House_int0" runat="server" CssClass="Custom_Hidden"></asp:Label></td>

                                                        </tr>

                                                        <tr>
                                                            <td class="dvtCellLabel">生产订单号:</td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:Label ID="Lbl_OrderNo" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" class="detailedViewHeader"><b>描述信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">原因:</td>
                                                            <td valign="top" class="dvtCellInfo" colspan="3">
                                                                <asp:Label ID="Lbl_Case" runat="server"></asp:Label>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">备注:</td>
                                                            <td valign="top" class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>&nbsp;</td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="4" class="dvInnerHeader">
                                                                <b>产品详细信息</b>
                                                                <asp:CheckBox Visible="false" runat="server" ID="Chk_IsDetails" Checked="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>

                                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">

                                                        <tr valign="top">
                                                            <td class="ListHead" nowrap><b>序号</b></td>
                                                            <td class="ListHead" nowrap><b>BOM序号</b></td>
                                                            <td class="ListHead" nowrap><b>产品名称</b></td>
                                                            <td class="ListHead" nowrap><b>产品编码</b></td>
                                                            <td class="ListHead" nowrap><b>型号</b></td>
                                                            <td class="ListHead" nowrap><b>上级型号</b></td>
                                                            <td class="ListHead" nowrap><b>最小包装</b></td>
                                                            <td class="ListHead" nowrap><b>包数</b></td>
                                                            <td class="ListHead" nowrap><b>调拨数量</b></td>
                                                            <td class="ListHead" nowrap><b>士腾不良品</b></td>
                                                            <td class="ListHead" nowrap><b>加工厂不良品</b></td>
                                                            <td class="ListHead" nowrap><b>确认数量</b></td>
                                                            <td class="ListHead" nowrap><b>缺料数量</b></td>
                                                            <td class="ListHead" nowrap><b>差额数量</b></td>
                                                            <td class="ListHead" nowrap><b>单价</b></td>
                                                            <td class="ListHead" nowrap><b>金额</b></td>
                                                            <td class="ListHead" nowrap><b>备注</b></td>
                                                        </tr>
                                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                    </table>

                                                    <asp:Panel ID="Panel_SCDetails" runat="server" Visible="false">
                                                        <hr noshade size="1">
                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                            <tr>
                                                                <td>
                                                                    <caption>
                                                                        <span class="lvtHeaderText">原材料消耗和委外生成</span>
                                                                    </caption>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" class="detailedViewHeader">
                                                                    <b>成品入库</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BorderColor="#4974C2" CssClass="Custom_DgMain" OnRowDataBound="GridView1_DataRowBinding"
                                                                        EmptyDataText="&lt;div align=center&gt;&lt;font color=red&gt;&lt;br/&gt;&lt;br/&gt;&lt;B&gt;没有找到明细记录&lt;/B&gt;&lt;br/&gt;&lt;br/&gt;&lt;/font&gt;&lt;/div&gt;"
                                                                        PageSize="100" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="Chbk" runat="server" Checked="true" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="产品名称" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                                    <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()%>'></asp:TextBox>
                                                                                    <asp:TextBox ID="Tbx_DID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="版本号" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="数量" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" OnBlur="ChangPrice(this.value);this.className='detailedViewTextBox'"
                                                                                        Width="150px" OnFocus="this.className='detailedViewTextBoxOn'" Text='<%#DataBinder.Eval(Container.DataItem, "AllocateAmount").ToString() %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="单价" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="Tbx_Price" runat="server" CssClass="detailedViewTextBox" OnBlur="this.className='detailedViewTextBox'"
                                                                                        Width="150px" OnFocus="this.className='detailedViewTextBoxOn'" Text='<%#DataBinder.Eval(Container.DataItem, "AllocateUnitPrice").ToString() %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="入库仓库" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList runat="server" ID="Ddl_House">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnBlur="this.className='detailedViewTextBox'"
                                                                                        OnFocus="this.className='detailedViewTextBoxOn'" Width="100px"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="colHeader" />
                                                                        <RowStyle CssClass="listTableRow" />
                                                                        <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                        <PagerStyle CssClass="Custom_DgPage" />
                                                                    </cc1:MyGridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" class="detailedViewHeader">
                                                                    <b>成品委外和消耗</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="dvtCellLabel" height="25" width="17%">入库日期:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_RkTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                        Width="150px"></asp:TextBox>
                                                                    (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                                                        runat="server" ControlToValidate="Tbx_RkTime" Display="Dynamic" ErrorMessage="入库日期非空"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel" height="25" width="17%">入库人员:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:DropDownList ID="Ddl_RkPerson" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="dvtCellLabel" height="25" width="17%">委外日期:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_WwTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                        Width="150px"></asp:TextBox>
                                                                    (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                                        runat="server" ControlToValidate="Tbx_WwTime" Display="Dynamic" ErrorMessage="委外日期非空"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel" height="25" width="17%">委外人员:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:DropDownList ID="Ddl_WwPerson" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="Td1" runat="server" class="dvtCellInfo" colspan="4">
                                                                    <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BorderColor="#4974C2" CssClass="Custom_DgMain" EmptyDataText="&lt;div align=center&gt;&lt;font color=red&gt;&lt;br/&gt;&lt;br/&gt;&lt;B&gt;没有找到相关消耗明细记录&lt;/B&gt;&lt;br/&gt;&lt;br/&gt;&lt;/font&gt;&lt;/div&gt;"
                                                                        PageSize="100" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox runat="server" ID="Chbk_ID" Checked="true" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="物料名称" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) + "(" + base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) + ")"%>
                                                                                    <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()%>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="成品" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "XPP_FaterBarCode").ToString())%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="供应商" ItemStyle-HorizontalAlign="Left" SortExpression="XPP_SuppNo">
                                                                                <ItemTemplate>
                                                                                    <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "XPP_SuppNo").ToString()) %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="XPP_Number" DataFormatString="{0:f0}" HeaderText="比例"
                                                                                HtmlEncode="false" SortExpression="XPP_Number">
                                                                                <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                                <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="XPP_Price" DataFormatString="{0:f3}" HeaderText="单价" HtmlEncode="false"
                                                                                SortExpression="XPP_Price">
                                                                                <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                                <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="消耗数量" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" OnBlur="this.className='detailedViewTextBox'"
                                                                                        OnFocus="this.className='detailedViewTextBoxOn'" Text='<%# DataBinder.Eval(Container.DataItem, "Number").ToString() %>'
                                                                                        Width="100px"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left"
                                                                                HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnBlur="this.className='detailedViewTextBox'"
                                                                                        OnFocus="this.className='detailedViewTextBoxOn'" Width="100px"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="colHeader" />
                                                                        <RowStyle CssClass="listTableRow" />
                                                                        <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                        <PagerStyle CssClass="Custom_DgPage" />
                                                                    </cc1:MyGridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" align="center" style="height: 30px">
                                                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                                        class="crmbutton small save" OnClick="Btn_SaveOnClick" />
                                                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                                        type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </asp:Panel>

                                                <asp:Panel ID="Pan_Detail" runat="server">
                                                    成品入库单：
                                <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                    AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%"><Columns><asp:TemplateField HeaderText="入库单号" SortExpression="SEM_ID" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left"><ItemTemplate><a href="../Store/CK_Store_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SEM_ID")%>"></a></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="出库单号" SortExpression="SEM_DirectOutNo" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate><a href="Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SEM_DirectOutNo")%>"
                                                    target="_self"></a></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="加工厂" SortExpression="SEM_DirectOutNo" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="数量" DataField="SER_ScNumber" SortExpression="SER_ScNumber"
                                            DataFormatString="{0:f0}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField HeaderText="消耗日期" DataField="SEM_Stime" SortExpression="SEM_Stime"
                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField HeaderText="原材料入库日期" DataField="SEM_Rktime" SortExpression="SEM_Rktime"
                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="入库人" SortExpression="SEM_RkPerson" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="原材料委外日期" DataField="SEM_Wwtime" SortExpression="SEM_Wwtime"
                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="委外人" SortExpression="SEM_WwPerson" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="生产人" SortExpression="SEM_Creator" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="操作日期" DataField="SEM_Ctime" SortExpression="SEM_Ctime"
                                            DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="发货单" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left"><ItemTemplate><a href="Sales_ShipWareOut_Print_Cw.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SEM_DirectOutNo")%>"
                                                    target="_blank"><asp:Image ID="Image2" runat="server" ImageUrl="../images/Printer.gif" border="0"
                                                        ToolTip="打印" /></a></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="成品入库单" SortExpression="SEM_Creator" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate><a href="../Report_Bill/Procure_RC_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SEM_DirectOutNo")%>"
                                                    target="_blank"><asp:Image ID="Image1" runat="server" ImageUrl="../images/Printer.gif" border="0"
                                                        ToolTip="打印" /></a></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="委外加工耗料单" SortExpression="SEM_Creator" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate><a href="../Report_Bill/Procure_Xh_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SEM_DirectOutNo")%>"
                                                    target="_blank"><asp:Image ID="Image3" runat="server" ImageUrl="../images/Printer.gif" border="0"
                                                        ToolTip="打印" /></a></ItemTemplate></asp:TemplateField></Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif"></td>

            </tr>
        </table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

