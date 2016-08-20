<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_ContractList_View.aspx.cs"
    Inherits="Web_KNet_Sales_ContractList_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>查看订单评审</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
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
                订单评审 > <a class="hdrLink" href="KNet_Sales_ContractList_List.aspx">订单评审</a>
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
                                    <td <%=s_OrderStyle%> align="center" nowrap>
                                        <a href="KNet_Sales_ContractList_View.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">
                                            订单评审信息</a>
                                    </td>
                                    <td class="dvtTabCache" style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td <%=s_DetailsStyle%> align="center" nowrap>
                                        <a href="KNet_Sales_ContractList_View.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">
                                            相关信息</a>
                                    </td>
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
                            <table border="0" cellspacing="0" cellpadding="0" id="Table_Btn" runat="server" width="100%">
                                <tr>
                                    <td>
                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                            onclick="PageGo('KNet_Sales_ContractList_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                            name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                            value="&nbsp;共享&nbsp;">&nbsp;
                                        <input title="" class="crmbutton small edit" onclick="PageGo('KNet_Sales_ContractList_List.aspx')"
                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                        <input title="查看" class="crmbutton small edit" type="button" name="Share" onclick="PageGo('KNet_Sales_ContractList_Manage_PrinterListSettingPrinterPage.aspx?ContractNo=<%= Request.QueryString["ID"].ToString() %>&PrinterModel=128898695453437500')"
                                            value="&nbsp;查看&nbsp;">&nbsp;
                                        <asp:Button  Text="审核" CssClass="crmbutton small edit"  ID="Btn_Sh" runat="server" OnClick="Btn_Sh_Click"  ></asp:Button>
                                    </td>
                                    <td align="right">
                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                            onclick="PageGo('KNet_Sales_ContractList_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
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
                                        <a href="../SalesShip/Knet_Sales_Ship_Manage_Add.aspx?ContractNo=<%=Request.QueryString["ID"].ToString()%>" class="webMnu">创建发货通知单</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-left: 10px;">
                                        <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                        <a href="../Receive/Cw_Accounting_Payment_List.aspx?ContractNo=<%=Request.QueryString["ID"].ToString()%>" class="webMnu">创建应收款</a>
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
                                            订单单号:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ContractNo" runat="server"></asp:Label>
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
                                            日期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Stime" runat="server"></asp:Label>
                                        </td>
                                        <td class="dvtCellLabel">
                                            客户:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="CustomerName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            联系人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ContractPerson" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            电话:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_Telephone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="17%" class="dvtCellLabel">
                                            地址:
                                        </td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:Label ID="ContractToAddress" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            交货日期:
                                        </td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:Label ID="ContractToDeliDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>结算信息</b>
                                            <asp:Label ID="Label1" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            订单分类:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ContractClass" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            结算方式:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Drop_Payment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            交货方式:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ContractDeliveMethods" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            付款方式:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ContractToPayment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            运输方式:
                                        </td>
                                        <td class="dvtCellInfo" colspan="3">
                                            常规：<asp:Label ID="Drop_RoutineTransport" runat="server"></asp:Label>
                                            应急：<asp:Label ID="Drop_WorryTransport" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>其他说明</b>
                                            <asp:Label ID="Label2" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            发货说明:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Lbl_ContractShip" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            图片:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Visible="false">
                                                <asp:Image ID="Image1" runat="server" Width="28" Height="24" Visible="false" /></asp:HyperLink>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            技术要求:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_TechnicalRequire" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            产品包装:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_ProductPackaging" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            质量要求:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_QualityRequire" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            质保期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_WarrantyPeriod" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            备货要求:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_DeliveryRequire" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            备注说明:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ContractRemarks" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                                 <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>订单档案</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    档案编号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Tbx_OrderNo" runat="server" 
                                                        Width="150px" Text=""></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    订单原件:
                                                </td>
                                                <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                </td>
                                            </tr>
                                                 <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>合同档案</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    档案编号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_FaterCode" runat="server" 
                                                        Width="150px" Text=""></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    档案类型:
                                                </td>
                                                <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Lbl_Type"></asp:Label>
                                                </td>
                                            </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            创建人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Lbl_Creator" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            创建时间:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Lbl_CTime" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                                                        <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>产品明细</b>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="ListDetails">
                                    <%=s_MyTable_Detail %>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="Pan_Detail" runat="server">
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                
                                    <tr>
                                        <td>
                                            发货通知单：
                                            <asp:GridView ID="GridView_Ship" Width="99%" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="发货单号" SortExpression="OutWareNo" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-Width="28px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                        <ItemTemplate>
                                                            <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>"
                                                                target="_self">
                                                                <%# DataBinder.Eval(Container.DataItem, "OutWareNo").ToString()%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="发货日期" DataField="OutWareDateTime" SortExpression="OutWareDateTime"
                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="预计到货日期" DataField="KSO_PlanOutWareDateTime" SortExpression="KSO_PlanOutWareDateTime"
                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="出库日期" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# GetCk(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="客户名称" SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                        <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
               <%# base.Base_GetOutWareProductsPatten(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
               <%# base.Base_GetOutWareDetailNumbers(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="发货跟踪情况" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass='colHeader' />
                                                <RowStyle CssClass='listTableRow' />
                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                <PagerStyle CssClass='Custom_DgPage' />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            评审记录：
                                            <asp:GridView ID="GridView1" Width="99%" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="审核人" SortExpression="KSF_ShPerson" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSF_ShPerson").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="所在部门" SortExpression="StaffDepart" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "StaffDepart").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="职位" SortExpression="Position" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetBasicCodeName("105",DataBinder.Eval(Container.DataItem, "Position").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="审核时间" DataField="KSF_Date" ItemStyle-Width="70px" SortExpression="KSF_Date">
                                                        <ItemStyle HorizontalAlign="center" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="center" Font-Size="12px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="审核状态" SortExpression="KSF_State" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# GetFlowName(DataBinder.Eval(Container.DataItem, "KSF_State").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="审核意见" DataField="KSF_Detail" ItemStyle-Width="115px"
                                                        SortExpression="KSF_Detail">
                                                        <ItemStyle HorizontalAlign="center" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="center" Font-Size="12px" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <HeaderStyle CssClass='colHeader' />
                                                <RowStyle CssClass='listTableRow' />
                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                <PagerStyle CssClass='Custom_DgPage' />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            采购单记录：
                                            <asp:GridView ID="GridView_Order" Width="99%" runat="server" AllowSorting="True"
                                                EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="采购单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <a href="../Order/Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>">
                                                                <%# DataBinder.Eval(Container.DataItem, "OrderNo") %></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="采购日期" DataField="OrderDateTime" SortExpression="OrderDateTime"
                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="到货日期" DataField="OrderPreToDate" SortExpression="OrderPreToDate"
                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="采购类型" SortExpression="OrderType" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.base_GetProcureTypeNane(DataBinder.Eval(Container.DataItem, "OrderType").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="供应商" SortExpression="SuppNo" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetSupplierName(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="采购产品类型" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetOrderDetailProductsPatten(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="采购总数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetOrderDetailNumbers(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="入库" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetBasicCodeName("126", DataBinder.Eval(Container.DataItem, "KPO_RkState").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="操作时间" DataField="SystemDateTimes" SortExpression="SystemDateTimes"
                                                        HtmlEncode="false">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="审核人" SortExpression="OrderStaffNo" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "OrderCheckStaffNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass='colHeader' />
                                                <RowStyle CssClass='listTableRow' />
                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                <PagerStyle CssClass='Custom_DgPage' />
                                            </asp:GridView>
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
    </tr> </table>
    </form>
</body>
</html>
<%--收货单信息  结束--%>
