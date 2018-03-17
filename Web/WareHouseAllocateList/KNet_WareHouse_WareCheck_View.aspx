<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_WareHouse_WareCheck_View.aspx.cs" Inherits="Web_KNet_WareHouse_WareCheck_View" %>

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
                                     
                                                             <asp:Button ID="btn_Chcek1" runat="server" class="crmbutton small edit" Text="暂存"
                                                                 OnClick="btn_Chcek1_Click1" Width="54px" />
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
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Tbx_OrderNo" runat="server"></asp:Label></td>
                                            </td>
                                            <td class="dvtCellLabel">调拨类型:
                                            </td>
                                            <td class="dvtCellInfo">
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
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>

                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">

                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                    </table>
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="4" class="dvInnerHeader">
                                    <b>维修品调拨</b>
                                </td>
                            </tr>
                            
                            <tr>
                                <td colspan="4">
                              <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" pagesize="10" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                                    <Columns>

                                        <asp:TemplateField HeaderText="调拨单号" SortExpression="AllocateNo" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <a href="KNet_WareHouse_WareCheck_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "AllocateNo") %>"  target="_blank"><%# DataBinder.Eval(Container.DataItem, "AllocateNo").ToString()%></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="生产单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <a href="/Web/Cg/Order/Knet_Procure_OpenBilling_View_ForSc.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWA_OrderNo") %>" target="_blank">
                                                    <%# DataBinder.Eval(Container.DataItem, "KWA_OrderNo") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="调拨维修品" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# GetDbState(DataBinder.Eval(Container.DataItem, "AllocateNo").ToString(),0)%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="维修品数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# GetDbState(DataBinder.Eval(Container.DataItem, "AllocateNo").ToString(),1)%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="调拨日期" DataField="AllocateDateTime" SortExpression="AllocateDateTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="调出仓库" SortExpression="HouseNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo_int").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="调出入库" SortExpression="HouseNo_int" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.Base_GetHouseName("131429356506502002")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="调拨产品" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# GetDirectInProductsPatten(DataBinder.Eval(Container.DataItem, "AllocateNo").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="调拨总数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# GetDirectInNumbers(DataBinder.Eval(Container.DataItem, "AllocateNo").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="经手人" SortExpression="AllocateStaffNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "AllocateStaffNo").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="仓库确认" SortExpression="AllocateNo" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>

                                                <%# GetCheck(DataBinder.Eval(Container.DataItem, "AllocateNo").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="审核" SortExpression="AllocateCheckYN" HeaderStyle-Font-Size="12px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <%# GetOrderCheckYN(DataBinder.Eval(Container.DataItem, "AllocateNo"))%>
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
                    <img src="../../themes/softed/images/showPanelTopRight.gif"></td>

        </tr>
        </table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

