<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_ShipCheck_CView.aspx.cs" Inherits="Web_Sales_Procure_ShipCheck_CView" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register Src="../../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="../../KDialog/lhgdialog.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <div id="AutoCreateChargesdiv" class="layerPopup" style="display: none; width: 520px; left: 250px;">
            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
                <tr>
                    <td class="layerPopupHeading" align="left" width="80%" style="cursor: move">创建应付款</td>
                    <td>&nbsp;</td>
                    <td align="right" width="40%">
                        <img onclick="fninvsh('AutoCreateChargesdiv');" title="关闭" alt="关闭" style="cursor: pointer;" src="themes/softed/images/close.gif" align="absmiddle" border="0"></td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="5" width="95%" align="center">
                <tr>
                    <td class="small">
                        <div id="serialinfodiv">
                            <table class=" small" width="100%" cellspacing="1" cellpadding="3" border="0">
                                <tr class="lvtColData" height="25px;">
                                    <td colspan="2">①自动创建应付款</td>
                                </tr>
                                <tr height="25px;">
                                    <td width="20px;">&nbsp;</td>
                                    <td>应收日期:  
                                        <asp:TextBox ID="Tbx_YTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                        &nbsp;
							应收金额:<asp:Label runat="server" ID="Lbl_YMoney"></asp:Label>
                                    </td>
                                </tr>
                                <tr height="25px;">
                                    <td>&nbsp;</td>
                                    <td style="color: #CC0066;">确认后，将自动创建期数为1的应付款，应付金额为订单金额，<br>
                                        负责人、供应商与当前订单信息一致
                                    </td>
                                </tr>
                                <tr height="25px;">
                                    <td>&nbsp;</td>
                                    <td style="color: #CC0066;">
                                        <input type="button" name="button" class="crmbutton small edit" value=" 确认 " onclick="AutoCrCharges_click(1809);">
                                        <input type="button" name="button" class="crmbutton small cancel" value=" 取消 " onclick="location.href='index.php?module=PurchaseOrder&action=DetailView&record=1809';fninvsh('AutoCreateChargesdiv');">
                                    </td>
                                </tr>
                                <tr class="lvtColData" height="25px;">
                                    <td colspan="2">②手动创建应付款</td>
                                </tr>
                                <tr height="25px;">
                                    <td>&nbsp;</td>
                                    <td style="color: #CC0066;">
                                        <a href="" onclick="ManualCrCharges_click();return false;">打开 创建应付款界面</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>



        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购对账单 > 
	<a class="hdrLink" href="Procure_ShipCheck_List.aspx">采购对账单</a>
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
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif"></td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px"></div>
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
                                        <td <%=s_OrderStyle%> align="center" nowrap><a href="Procure_ShipCheck_List.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">采购对账单信息</a></td>
                                        <td class="dvtTabCache" style="width: 10px">&nbsp;</td>
                                        <td <%=s_DetailsStyle%> align="center" nowrap>
                                            <a href="Procure_ShipCheck_List.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">相关信息</a></td>
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
                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('Procure_ShipCheck_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;">&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Procure_ShipCheck_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                    <asp:Button ID="Button4" runat="server" class="crmbutton small edit" Text="重新生成PDF" OnClick="Button4_Click" Style="height: 26px; width: 100px" />&nbsp;
                                    <asp:Button ID="Button5" runat="server" class="crmbutton small edit" Text="重新生成Excel" OnClick="Button5_Click" Style="height: 26px; width: 100px" />&nbsp;
                                    <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批" OnClick="btn_Chcek_Click" /></td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create" onclick="PageGo('Procure_ShipCheck_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')" name="Duplicate" value="复制">&nbsp;
                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px" rowspan="3">
                                            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="genHeaderSmall">操作</td>
                                                </tr>
                                                <!-- Module based actions starts -->

                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="Lbl_Link"></asp:Label>

                                                    </td>
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
                                                        <td class="dvtCellLabel">对账单号:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Code" runat="server" Width="150px"></asp:Label>
                                                        </td>
                                                        <td class="dvtCellLabel">对账日期:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">日期:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_PreTime" runat="server" Width="150px"></asp:Label></td>
                                                        <td class="dvtCellLabel">对账类型:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Type" runat="server" Width="150px"></asp:Label>
                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">供应商:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_Supp" runat="server" Width="150px"></asp:Label></td>
                                                            <td class="dvtCellLabel">仓库:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_House" runat="server" Width="150px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">付款单状态:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_IsPayMent" runat="server" Width="150px"></asp:Label>
                                                            </td>
                                                            <td class="dvtCellLabel">发票状态:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_IsFp" runat="server" Width="150px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">审核状态:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_CheckYN" runat="server" Width="150px"></asp:Label>
                                                            </td>
                                                            <td class="dvtCellLabel">审核人:</td>
                                                            <td class="dvtCellInfo">
                                                                <asp:Label ID="Lbl_Check" runat="server" Width="150px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">备注说明:</td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:Label ID="Lbl_Remarks" runat="server" Width="150px"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" class="dvInnerHeader">
                                                                <b>对账详细信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellInfo" colspan="4">
                                                                <table id="myTable" width="98%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                                    class="ListDetails" style="height: 28px">

                                                                    <!-- Header for the Product Details -->
                                                                    <tr valign="top">
                                                                        <td class="ListHead" nowrap>
                                                                            <b>发生单号</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>订单号</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>发生日期</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>客户/供应商</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>产品</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>产品编码</b></td>
                                                                        <td class="ListHead">
                                                                            <b>版本号</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>数量</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>对账</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>备品</b></td>
                                                                         <td class="ListHead" nowrap>
                                                                            <b>入库数量</b></td>
                                                                          <td class="ListHead" nowrap>
                                                                            <b>报废数量</b></td>
                                                                         <td class="ListHead" nowrap>
                                                                            <b>报废单价</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>单价</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>加单</b></td>
                                                                         <td class="ListHead" nowrap>
                                                                            <b>额外扣除</b></td>
                                                                         <td class="ListHead" nowrap>
                                                                            <b>额外金额</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>应付金额</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>备注</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>发票状态</b></td>
                                                                        <td class="ListHead" nowrap>
                                                                            <b>确认状态</b></td>
                                                                    </tr>
                                                                    <%=s_MyTable_Detail %>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td colspan="4" class="dvInnerHeader">
                                                                <b>需开票明细</b>
                                                            </td>
                                                        </tr>
                                                    
                                                        <tr>
                                                            <td class="dvtCellInfo" colspan="4">
                                                                <asp:Label runat="server" id="Lbl_KpDetails"></asp:Label>
                                                                <table id="Table1" width="98%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                                    class="ListDetails" style="height: 28px">
                                                                    <%=s_Details %>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" class="dvInnerHeader">
                                                                <b>发票信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellInfo" colspan="4">

                                                                <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true"
                                                                    AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="编号" SortExpression="CAB_Code" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemTemplate>
                                                                                <a href="../Bill/CG_Account_Bill_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAB_ID") %>"><%# DataBinder.Eval(Container.DataItem, "CAB_Code").ToString()%></a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="供应商" SortExpression="CAB_SuppNo" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemTemplate>
                                                                                <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "CAB_SuppNo").ToString())%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="票据类型" SortExpression="CAB_BillType" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemTemplate>
                                                                                <%# base.Base_GetBasicCodeName("203", DataBinder.Eval(Container.DataItem, "CAB_BillType").ToString())%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="开票金额" DataField="CAB_Money" SortExpression="CAB_Money" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="发票编号" DataField="CAB_FpCode" SortExpression="CAB_FpCode" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="负责人" SortExpression="CAB_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemTemplate>
                                                                                <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "CAB_DutyPerson").ToString())%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="开票日期" DataField="CAB_Stime" SortExpression="CAB_Stime" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="创建人" DataField="CAB_CTime" SortExpression="CAB_CTime">
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

                                                       <%-- <tr>
                                                            <td colspan="4">
                                                                <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />
                                                            </td>
                                                        </tr>
                                                        
                                                <tr>
                                                    <td colspan="4">
                                                        <uc3:CommentList ID="CommentList1" runat="server" CommentFID="0" CommentType="-1" />
                                                    </td>
                                                </tr>--%>
                                                    <tr>
                                                        <td colspan="4">
                                                            
                                                            <cc1:MyGridView ID="MyGridView3" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                                                BorderColor="#4974C2"
                                                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="ID" SortExpression="PBM_Code" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <a href="../../mail/PB_Basic_Mail_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PBM_ID") %>">
                                                                                <%# DataBinder.Eval(Container.DataItem, "PBM_Code")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="发送邮件" DataField="PBM_SendEmail" SortExpression="PBM_SendEmail" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="接收邮件" DataField="PBM_ReceiveEmail" SortExpression="PBM_ReceiveEmail" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>

                                                                    <asp:BoundField HeaderText="主题" DataField="PBM_Title" SortExpression="PBM_Title"
                                                                        HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="状态" SortExpression="PBM_State" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# GetState(DataBinder.Eval(Container.DataItem, "PBM_State").ToString()) %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="操作时间" DataField="PBM_CTime" SortExpression="PBM_CTime" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    
                                                                </Columns>
                                                                <HeaderStyle CssClass='colHeader' />
                                                                <RowStyle CssClass='listTableRow' />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass='Custom_DgPage' />
                                                            </cc1:MyGridView>
                                                            <table>

                                                                <tr>
                                                                    <td align="center" style="height: 30px"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </asp:Panel>

                                            <asp:Panel ID="Pan_Detail" runat="server">

                                                <table border="0" cellspacing="0" cellpadding="0" class="small">
                                                    <tr>
                                                        <td style="height: 50px">&nbsp;
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
                    <img src="../../../themes/softed/images/showPanelTopRight.gif"></td>

            </tr>
        </table>


        <table border="0" cellspacing="0" cellpadding="0" class="small">
            <tr>
                <td style="height: 50px">&nbsp;
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<%--收货单信息  结束--%>

