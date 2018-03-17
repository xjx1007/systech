        <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Accounting_Payment_View.aspx.cs"
    Inherits="Web_Cw_Accounting_Payment" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>应付款</title>
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
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                应付款 > <a class="hdrLink" href="Cw_Accounting_Payment_List.aspx">应付款</a>
            </td>
            <td width="100%" nowrap>
                <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
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
                                    <td class="dvtTabCache" style="width: 10px" nowrap>
                                        &nbsp;
                                    </td>
                                    <td class="dvtSelectedCell" align="center" nowrap>
                                        应付款信息
                                    </td>
                                    <td class="dvtTabCache" style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td class="dvtUnSelectedCell" align="center" nowrap>
                                        <a href="#">相关信息</a>
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
                                    <td valign="top" align="left">
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td>
                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                        onclick="PageGo('Cw_Accounting_Payment_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('Cw_Accounting_Payment_List.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                    <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批"
                                                        OnClick="btn_Chcek_Click" />
                                                </td>
                                                <td align="right">
                                                    <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                        onclick="PageGo('Cw_Accounting_Payment_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
                                                        name="Duplicate" value="复制">&nbsp;
                                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                        onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                        rowspan="2">
                                        <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="genHeaderSmall">
                                                    操作
                                                </td>
                                            </tr>
                                            <!-- Module based actions starts -->
                                            <tr>
                                                <td align="left" style="padding-left: 10px; border-bottom: 1px dotted #CCCCCC;">
                                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                    <a href="../Rece/Cw_Accounting_Pay_Add.aspx?PayMentID=<%=s_ID %>" class="webMnu" target="_blank">创建收款单</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding-left: 10px; border-bottom: 1px dotted #CCCCCC;">
                                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                    <a href="../Bill/Cw_Account_Bill_Add.aspx?ReceiveID=<%=s_ID %>" class="webMnu" target="_blank">创建发票</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>基本信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    编码:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_ID" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    供应商/客户:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_Customer" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    付款类型:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_PayMent" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    开票客户:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_KCustomer" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    应付日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_YTime" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    应付金额:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_YMoney" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    是否开发票:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_IsFp" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    开票类型:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_FpType" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    负责人:
                                                </td>
                                                <td class="dvtCellInfo" >
                                                    <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    创建人:
                                                </td>
                                                <td class="dvtCellInfo" >
                                                    <asp:Label ID="Lbl_Creator" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="17%" class="dvtCellLabel">
                                                    备注:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                    <asp:Label ID="Lbl_Details" runat="server" Width="178px" ReadOnly="true"></asp:Label>
                                                </td>
                                            </tr>

                                            
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>出库单信息</b>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="4">
                            <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                PageSize="10" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="出库单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发货通知单号" SortExpression="CAP_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="DirectOutDateTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                    <asp:TemplateField HeaderText="产品" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-HorizontalAlign="left">
                                        <ItemTemplate>
                                            <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="数量" DataField="CAPD_Number" SortExpression="CAPD_Number" DataFormatString="{0:f0}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="单价" DataField="CAPD_Price" SortExpression="CAPD_Price"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="金额" DataField="CAPD_Money" SortExpression="CAPD_Money"  DataFormatString="{0:f2}"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                     <asp:BoundField  HeaderText="备注"  DataField="CAPD_Details"  SortExpression="CAPD_Details"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass='colHeader' />
                                <RowStyle CssClass='listTableRow' />
                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>调整单</b>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="4">
                                                    
                                                        <cc1:MyGridView ID="MyGridView4" runat="server" AllowPaging="True" AllowSorting="True"
                                                            IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关出库单记录</B><br/><br/></font></div>"
                                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
                                                            <Columns>
                                                    <asp:TemplateField HeaderText="出库单号" SortExpression="KWD_Custmoer">
                                                        <ItemTemplate>
                                                            <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>"
                                                                target="_self">
                                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="通知单号" SortExpression="KWD_Custmoer">
                                                                    <ItemTemplate>
                                                                        <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo")%>"
                                                                            target="_self">
                                                                            <%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="客户名称" SortExpression="KWD_Custmoer">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetShipDetailProductsPatten(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="总数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetShipDetailNumbers(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                                                    SortExpression="DirectOutDateTime">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="出库仓库" SortExpression="HouseNo">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="出库人" SortExpression="DirectOutStaffBranch">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DirectOutStaffNo").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="快递" SortExpression="KDName" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#base.GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString(), DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="状态" SortExpression="DirectOutNo" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# GetKDSateName(DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="发货单" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="center"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <a href="#" onclick="javascript:window.open('../SalesOut/Sales_ShipWareOut_Print.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo")%>&DID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');">
                                                                            <asp:Image ID="Image5" runat="server" ImageUrl="../../images/View.gif" border="0"
                                                                                ToolTip="查看发货详细信息" /></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-Width="28px"
                                                                    ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <a href="#" onclick="javascript:window.open('../SalesOut/Xs_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');">
                                                                            <asp:Image ID="Image3" runat="server" ImageUrl="../../images/View.gif" border="0"
                                                                                ToolTip="查看发货详细信息" /></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass='colHeader' />
                                                            <RowStyle CssClass='listTableRow' />
                                                            <AlternatingRowStyle BackColor="#E3EAF2" />
                                                            <PagerStyle CssClass='Custom_DgPage' />
                                                        </cc1:MyGridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>收款信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                        IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                        PageSize="10" Width="100%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="收款单号" SortExpression="CAA_Code" ItemStyle-HorizontalAlign="center"
                                                                HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <a href="Cw_Accounting_Pay_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAA_ID") %>">
                                                                        <%# DataBinder.Eval(Container.DataItem, "CAA_Code").ToString()%></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="收款金额" DataField="CAY_PayMoney" SortExpression="CAA_PayMoney"
                                                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="收款日期" DataField="CAA_Paytime" SortExpression="CAA_Paytime"
                                                                DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="账户" SortExpression="CAA_Account" ItemStyle-HorizontalAlign="center"
                                                                HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <%#base.Base_GetBankName(DataBinder.Eval(Container.DataItem, "CAA_Account").ToString())%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="客户/供应商" SortExpression="CAA_CustomerValue" ItemStyle-HorizontalAlign="center"
                                                                HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <%#base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "CAA_CustomerValue").ToString())%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="负责人" SortExpression="CAA_DutyPerson" ItemStyle-HorizontalAlign="center"
                                                                HeaderStyle-HorizontalAlign="center">
                                                                <ItemTemplate>
                                                                    <%#base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "CAA_DutyPerson").ToString())%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="创建日期" DataField="CAA_CTime" SortExpression="CAA_CTime"
                                                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle CssClass='colHeader' />
                                                        <RowStyle CssClass='listTableRow' />
                                                        <AlternatingRowStyle BackColor="#E3EAF2" />
                                                        <PagerStyle CssClass='Custom_DgPage' />
                                                    </cc1:MyGridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>开票信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">  <cc1:MyGridView ID="MyGridView3" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true"  
            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
<Columns>

        
         <asp:TemplateField HeaderText="编号"  SortExpression="CAB_Code" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <a href="Cw_Account_Bill_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAB_ID") %>"><%# DataBinder.Eval(Container.DataItem, "CAB_Code").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  HeaderText="开票内容"  DataField="CAB_Content"  SortExpression="CAB_Content"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
      <asp:TemplateField HeaderText="客户名称"  SortExpression="CAB_CustomerValue" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "CAB_CustomerValue").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="票据类型"  SortExpression="CAB_BillType" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("203", DataBinder.Eval(Container.DataItem, "CAB_BillType").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="开票金额"  DataField="CAB_Money"  SortExpression="CAB_Money"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="负责人"  SortExpression="CAB_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "CAB_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="开票日期"  DataField="CAB_Stime"  SortExpression="CAB_Stime" DataFormatString="{0:yyyy-MM-dd}"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="创建人"  DataField="CAB_CTime"  SortExpression="CAB_CTime" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
</Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
</cc1:MyGridView>
                                                </td>
                                            </tr>
                                        </table>
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
<%--收货单信息  结束--%>
