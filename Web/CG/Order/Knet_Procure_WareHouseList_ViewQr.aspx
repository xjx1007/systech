<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_WareHouseList_ViewQr.aspx.cs" Inherits="Web_Knet_Procure_WareHouseList_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png"/>
    <title>采购跟踪</title>
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购 > 
	<a class="hdrLink" href="Knet_Procure_WareHouseList_List.aspx">采购跟踪</a>
                </td>
                <td width="100%" nowrap>
                    <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
                    <asp:Label ID="Tbx_HouseNo" runat="server" Style="display: none"></asp:Label>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>采购入库信息</td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;</td>
                                            <td class="dvtUnSelectedCell" align="center" nowrap>
                                                <a href="#">相关信息</a></td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">

                                        <tr>
                                            <td colspan="4">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>1.交期确认和发货登记</b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="TextBox1" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <table id="Table1" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">

                                                    <!-- Header for the Product Details -->
                                                    <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>2.未确认入库单详细信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel" width="13%">仓库:</td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:Label ID="Lbl_Dept" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">

                                                    <!-- Header for the Product Details -->
                                                    <tr valign="top">
                                                        <td class="ListHead" nowrap><b>入库单号</b></td>
                                                        <td class="ListHead" nowrap><b>材料订单号</b></td>
                                                        <td class="ListHead" nowrap><b>OEM订单号</b></td>
                                                        <td class="ListHead" nowrap><b>发货日期</b></td>
                                                        <td class="ListHead" nowrap><b>送货供应商</b></td>
                                                        <td class="ListHead" nowrap><b>产品名称</b></td>
                                                        <td class="ListHead" nowrap><b>产品编码</b></td>
                                                        <td class="ListHead" nowrap><b>型号</b></td>
                                                        <td class="ListHead" nowrap><b>数量</b></td>
                                                        <td class="ListHead" nowrap><b>备料</b></td>
                                                        <td class="ListHead" nowrap><b>备注</b></td>
                                                        <td class="ListHead" nowrap><b>确认数量</b></td>
                                                    </tr>
                                                    <%=s_MyTable_Detail %>
                                                </table>
                                            </td>
                                        </tr>
                                        <asp:Panel runat="server" ID="Pan_Kc" Visible="false">
                                        <tr>
                                            <td colspan="4">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>3.库存信息</b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="TextBox3" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <table id="Table3" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">

                                                    <!-- Header for the Product Details -->
                                                    <tr valign="top">
                                                        <td class="ListHead" nowrap><b>产品名称</b></td>
                                                        <td class="ListHead" nowrap><b>产品编码</b></td>
                                                        <td class="ListHead" nowrap><b>型号</b></td>
                                                        <td class="ListHead" nowrap><b>库存数量</b></td>
                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_KCDetails"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                            </asp:Panel>
                                        <tr>
                                            <td class="dvtCellLabel" align="right">文件：
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:Label runat="server" ID="Lbl_Upload"></asp:Label>
                                                <input id="uploadFile" type="file" runat="server" />

                                                <asp:Button
                                                    ID="save" runat="server" Text="上传" CssClass="crmbutton small save"
                                                    OnClick="save_Click" Height="30px" />
                                                <asp:Button ID="Btn_Serch" runat="server" class="crmbutton small cancel" OnClick="Btn_Serch_Click" Text="匹配" title="匹配 [Alt+S]" Height="30px" />
                                                <asp:Button ID="Btn_Save" runat="server" AccessKey="S" class="crmbutton small save" OnClick="Btn_Save_Click" Text="保存" Height="30px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" height="31px"></td>
                                        </tr>
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
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:TextBox ID="Tbx_URL" runat="server" CssClass="Custom_Hidden" Width="0px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">

                                    <cc1:MyGridView ID="GridView_Comment" runat="server" AllowPaging="True" AllowSorting="True"
                                        IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                        PageSize="10" Width="100%">
                                        <Columns>
                                            <asp:BoundField HeaderText="名称" DataField="PBA_Name" SortExpression="PBA_Name"
                                                HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="附件" SortExpression="PBA_URL" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <a target="_blank" href="<%#DataBinder.Eval(Container.DataItem, "PBA_URL").ToString()%>"><%# DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="描述" DataField="PBA_Remarks" SortExpression="PBA_Remarks"
                                                HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="200px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="创建人" SortExpression="PBA_Creator" HeaderStyle-Font-Size="12px"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "PBA_Creator").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="上传时间" DataField="PBA_Ctime" SortExpression="PBA_Ctime"
                                                HtmlEncode="false">
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
                        </table>
                </td>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif"></td>

            </tr>
        </table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

