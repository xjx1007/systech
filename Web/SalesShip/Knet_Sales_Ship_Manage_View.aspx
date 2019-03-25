<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Sales_Ship_Manage_View.aspx.cs"
    Inherits="Web_Knet_Sales_Ship_Manage_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title></title>
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
                发货通知 > <a class="hdrLink" href="Knet_Sales_Ship_Manage_Manage.aspx">发货通知</a>
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
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                            <tr>
                                                <td class="dvtTabCache" style="width: 10px" nowrap>
                                                    &nbsp;
                                                </td>
                                                <td <%=s_OrderStyle%> align="center" nowrap>
                                                    <a href="Knet_Sales_Ship_Manage_View.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">
                                                        发货通知单信息</a>
                                                </td>
                                                <td class="dvtTabCache" style="width: 10px">
                                                    &nbsp;
                                                </td>
                                                <td <%=s_DetailsStyle%> align="center" nowrap>
                                                    <a href="Knet_Sales_Ship_Manage_View.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">
                                                        相关信息</a>
                                                </td>
                                                <td class="dvtTabCache" style="width: 100%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
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
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" id="Table_Btn" runat="server">
                                            <tr>
                                                <td>
                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                        onclick="PageGo('Knet_Sales_Ship_Manage_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Sales_Ship_Manage_Manage.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                </td>
                                                <td align="right">
                                                    <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                        onclick="PageGo('Knet_Sales_Ship_Manage_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
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
                                                <td align="left" style="padding-left: 10px;">
                                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                    <a href="../SalesOut/Sales_ShipWareOut_Add.aspx?ShipNo=<%=s_ID1 %>" class="webMnu">创建出库单</a>
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
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                        <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发货单号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="OutWareNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        责任人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="DutyPerson" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发货日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="OutWareDateTime" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        预计到货日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="PlanTime" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        结算客户:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="CustomerName" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="17%" class="dvtCellLabel">
                                                        合同编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="ContractNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        收货客户:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_SCutomer" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        发货类型:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_Type" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发货联系人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="ContectPerson" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="17%" class="dvtCellLabel">
                                                        收货联系人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="RePerson" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        联系电话:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Phone" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="17%" class="dvtCellLabel">
                                                        交货地点:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Address" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        交货方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="ContractDeliveMethods" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        状态:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Step" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        客户型号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_ShipType" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        计划单号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_PlanNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发货说明:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Lbl_FhDetails" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        备注说明:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Remarks" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        创建人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_Creator" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        创建时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_CTime" runat="server"></asp:Label>
                                                    </td>
                                                </tr>       <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>产品详细信息</b>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="ListDetails">
                                         
                                                <!-- Header for the Product Details -->
                                                <tr valign="center" align="center">
                                                    <td class="ListHead" >
                                                        <b>合同编号</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>产品名称</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>产品编码</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>型号</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>数量</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>备品只数</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>销售单价</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>金额</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>计划单号</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>订单号</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>客户料号</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>客户型号</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>是否随货</b>
                                                    </td>
                                                    <td class="ListHead" >
                                                        <b>备注</b>
                                                    <td class="ListHead" >
                                                        <b>电池</b>
                                                    </td>
                                                </tr>
                                                <%=s_MyTable_Detail %>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Pan_Detail" runat="server">
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                <tr>
                                                    <td>
                                                        <b>相关出库单</b>
                                                        <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
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
                                                    <td>
                                                        <b>相关短信发送记录</b>
                                                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                            EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                                            GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                                            ShowHeader="true" HeaderStyle-Height="25px">
                                                            <Columns>
                                                                <asp:BoundField DataField="SPM_ReceiveName" HeaderText="收信人" ControlStyle-Width="120px">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SPM_ReceivePhone" HeaderText="收信人" ControlStyle-Width="120px">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SPM_Detail" HeaderText="内容">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="500px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="发送人" ItemStyle-Width="7%" ItemStyle-Height="25px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "SPM_SenderID").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="SPM_SendTime" HeaderText="发送时间" ControlStyle-CssClass="Boxx"
                                                                    ControlStyle-Width="120px" SortExpression="HouseName">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <a href="#" onclick="javascript:window.open('System_Message_Detail.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SPM_ID")%>','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=800,height=650');">
                                                                            <asp:Image ID="Image2" runat="server" ImageUrl="../../images/View.gif" border="0"
                                                                                ToolTip="查看详细信息" /></a>
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
                                            </table>
                                        </asp:Panel>
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
