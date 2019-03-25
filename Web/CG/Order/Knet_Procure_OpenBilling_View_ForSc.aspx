<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_OpenBilling_View_ForSc.aspx.cs" Inherits="Knet_Procure_OpenBilling_View_ForSc" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png"/>
    <title>查看生产订单</title>
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <link rel="stylesheet" href="/Web/css/ihwy-2012.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="/Web/cssjquery.listnav-2.1.css" type="text/css" media="screen" charset="utf-8" />
    <script type="text/javascript" src="/Web/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.cookie.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.idTabs.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.listnav-2.1.js" charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            if (top.location.href.toLowerCase() == self.location.href.toLowerCase()) $('#docLink').show();
            $("#tabNav ul").idTabs("tab1");
        });
        $("Btn_Save").click(function(){    $(this).attr("disabled","disabled");    });
    </script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            border: 1px solid #DDDDDD;
            padding: 5px;
            background: #dddcdd url('/themes/softed/images/inner.gif') repeat-x 50% bottom;
            color: #000000;
            height: 27px;
        }
    </style>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购 > 
	<a class="hdrLink" href="Knet_Procure_OpenBilling_Manage.aspx">查看生产订单</a>
                </td>
                <td width="100%" nowrap>
                    <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif"/>
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px"></div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">

                                    <tr>
                                        <td>&nbsp;</td>
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
                                                        <asp:Label runat="server" ID="Lbl_homeNum"></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="Lbl_Link"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="LBl_Link2"></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="Lbl_Link1"></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="LBl_Link3"></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="LBl_Link4"></asp:Label>&nbsp;

                                                    </td>
                                                </tr>--%>

                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="LBl_Link5"></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="LBl_Link6"></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="Pan_Order" runat="server">

                                                <div class="demoWrapper">

                                                    <div id="tabNav">
                                                        <ul>
                                                            <li><a href="#tab1">基本信息</a></li>
                                                            <li><a href="#tab2">相关采购单</a></li>
                                                            <li><a href="#tab5">相关调拨单</a></li>
                                                            <li><a href="#tab3">入库单信息</a></li>
                                                            <li><a href="#tab4">物料计划</a></li>
                                                        </ul>
                                                        <div class="clr"></div>
                                                    </div>
                                                    <div id="tabs">
                                                        <!--基本信息-->
                                                        <div id="tab1" class="tab">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                                <tr>
                                                                    <td valign="top" align="left" colspan="4">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" id="Table_Btn" runat="server">
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('Knet_Procure_OpenBilling.aspx?Sampling=Sampling&&ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;" style="height: 26px; width: 60px"/>
                                                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" style="height: 26px; width: 60px"/>
                                                                                    <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Procure_OpenBilling_Manage.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" style="height: 26px; width: 80px"/>
                                                                                    <asp:Button ID="Button1" runat="server" class="crmbutton small edit" Text="生成" OnClick="Button1_Click" Visible="false" Style="height: 26px; width: 60px" />
                                                                                    &nbsp;<asp:Button ID="Button3" runat="server" class="crmbutton small edit" Text="订单关闭" OnClick="Button3_Click" Style="height: 26px; width: 80px" />
                                                                                    &nbsp;
                                                    <asp:Button ID="Button4" runat="server" class="crmbutton small edit" Text="重新生成PDF" OnClick="Button4_Click" Style="height: 26px; width: 100px" />&nbsp;
                                                        &nbsp;<asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批" OnClick="btn_Chcek_Click" Style="height: 26px; width: 60px" />
                                                                                    &nbsp;<asp:Button ID="btn_Sc" runat="server" class="crmbutton small edit" Text="暂停生产" OnClick="btn_Sc_Click" Style="height: 26px; width: 60px" />
                                                                                    &nbsp;<asp:Button ID="Btn_Change" runat="server" class="crmbutton small edit" Text="更换OEM" OnClick="Btn_Change_Click" Style="height: 26px; width: 60px" />&nbsp;
                                                                                     &nbsp;<asp:Button ID="Button5" runat="server" class="crmbutton small edit" Text="创建烧录审核" OnClick="Button5_OnClick" Style="height: 26px; width: 120px" />

                                                                                </td>
                                                                                <td align="right">
                                                                                    <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create" onclick="PageGo('Knet_Procure_OpenBilling.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')" name="Duplicate" value="复制" style="height: 26px; width: 60px"/>&nbsp;
                                                                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除" style="height: 26px; width: 60px"/>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">采购单号:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Code" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="dvtCellLabel">采购日期:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="dvtCellLabel">预到日期:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_PreTime" runat="server" Width="150px"></asp:Label>&nbsp;</td>
                                                                    <td class="dvtCellLabel">供应商:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Supp" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">入库状态:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="lbl_isRuk" runat="server" Width="150px"></asp:Label>&nbsp;</td>
                                                                    <td class="dvtCellLabel">付款单状态:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_IsPayMent" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="17%" class="dvtCellLabel">成品订单:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_ParentOrderNo" runat="server" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                                    </td>

                                                                    <td class="dvtCellLabel">合同订单:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_ContractNo" runat="server" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">价格需确认:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_PriceState" runat="server"></asp:Label>&nbsp;</td>

                                                                    <td class="dvtCellLabel">采购部门:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Depart" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="dvtCellLabel">采购类型:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_OrderType" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="dvtCellLabel">订单状态:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_State" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>

                                                                    <td class="dvtCellLabel">选择收货供应商:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_SelectSupp" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="dvtCellLabel">收货仓库:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_HouseNo" runat="server"></asp:Label>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">送货地址:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_Address" runat="server"></asp:Label>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">备注说明:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">生产说明:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_ScDetails" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">PDF:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_PDF" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">操作人:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Creator" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="dvtCellLabel">操作时间:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_CTime" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="dvInnerHeader">
                                                                        <b>产品详细信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%" colspan="4">
                                                                        <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                                            class="ListDetails">

                                                                            <tr valign="top">
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>选择</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>物料库存</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>产品名称</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>料号</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>版本号</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>数量</b></td>
                                                                                <td class="ListHead" colspan="2" nowrap>
                                                                                    <b>单价</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>金额</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>未入库数量</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>备注</b></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="ListHead" nowrap>
                                                                                    <b>材料</b></td>
                                                                                <td class="ListHead" nowrap>
                                                                                    <b>加工费</b></td>
                                                                            </tr>
                                                                            <%=s_MyTable_Detail %>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>

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
                                                        </div>
                                                        <!--基本信息-->
                                                        <div id="tab2" class="tab">
                                                            <cc1:MyGridView ID="GridView1" runat="server" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10" BorderColor="#4974C2" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关生产订单记录</B><br/><br/></font></div>">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="采购单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <a href="Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>"><%# DataBinder.Eval(Container.DataItem, "OrderNo") %></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="合同编号" SortExpression="ContractNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <a href="#" onclick="javascript:window.open('/Web/Xs/Sales/Xs_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="采购日期" DataField="OrderDateTime" SortExpression="OrderDateTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="预计到货日期" DataField="OrderPreToDate" SortExpression="OrderPreToDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="采购类型" SortExpression="OrderType" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.base_GetProcureTypeNane(DataBinder.Eval(Container.DataItem, "OrderType").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="供应商" SortExpression="SuppNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetSupplierName(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="采购产品类型" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetOrderDetailProductsPatten(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="总数量" DataField="OrderAmount" SortExpression="OrderAmount"
                                                                        HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="入库" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%#base.Base_GetBasicCodeName("126",DataBinder.Eval(Container.DataItem, "RkState").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="未入" DataField="wrkNumber" SortExpression="wrkNumber"
                                                                        HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="状态" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.GetKDSateName(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="操作时间" DataField="SystemDateTimes" SortExpression="SystemDateTimes" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <HeaderStyle CssClass='colHeader' />
                                                                <RowStyle CssClass='listTableRow' />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass='Custom_DgPage' />
                                                            </cc1:MyGridView>
                                                        </div>
                                                        <div id="tab5" class="tab">
                                                            <cc1:MyGridView ID="MyGridView4" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录，或没有受权使用相关仓库</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="调拨单号" SortExpression="AllocateNo" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                        <ItemTemplate>
                                                                            <a href="/Web/WareHouseAllocateList/KNet_WareHouse_WareCheck_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "AllocateNo") %>"><%# DataBinder.Eval(Container.DataItem, "AllocateNo").ToString()%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField HeaderText="调拨日期" DataField="AllocateDateTime" SortExpression="AllocateDateTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="调出仓库" SortExpression="HouseNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="调出入库" SortExpression="HouseNo_int" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo_int").ToString())%>
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
                                                        </div>
                                                        <div id="tab3" class="tab">
                                                            <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true"
                                                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>" AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="采购入库编号" SortExpression="WareHouseNo" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                        <ItemTemplate>
                                                                            <a href="/Web/Cg/OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "WareHouseNo") %>"><%# DataBinder.Eval(Container.DataItem, "WareHouseNo").ToString()%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="供应商名称" SortExpression="SuppNo" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="center">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="仓库" SortExpression="HouseNo" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="center">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="发货时间" DataField="WareHouseDateTime" SortExpression="WareHouseDateTime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="收货时间" DataField="KPO_CheckTime" SortExpression="KPO_CheckTime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="入库产品" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="220px"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# Base_GetOrderInProductsPattern(DataBinder.Eval(Container.DataItem, "WareHouseNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# Base_GetOrderInProductsNUmbers(DataBinder.Eval(Container.DataItem, "WareHouseNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="快递" DataField="KPO_KDName" SortExpression="KPO_KDName"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="单号" DataField="KPO_KDCode" SortExpression="KPO_KDCode"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="快递状态" SortExpression="KPO_State" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.GetKDSateNameByWareHouse(DataBinder.Eval(Container.DataItem, "WareHouseNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="确认状态" SortExpression="KPO_QRState" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# GetPrint(DataBinder.Eval(Container.DataItem, "WareHouseNo").ToString(), int.Parse(DataBinder.Eval(Container.DataItem, "KPO_QRState").ToString()))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="入库人" SortExpression="WareHouseStaffNo" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="center">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "WareHouseStaffNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass='colHeader' />
                                                                <RowStyle CssClass='listTableRow' />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass='Custom_DgPage' />
                                                            </cc1:MyGridView>

                                                            <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                                                IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="消耗编号" SortExpression="SEM_ID" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left">
                                                                        <ItemTemplate>
                                                                            <a href="../../ScExpend/Sc_Expend_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "SEM_ID")%>">
                                                                                <%# DataBinder.Eval(Container.DataItem, "SEM_ID").ToString()%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="供应商" SortExpression="SER_ProductsBarCode" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SEM_SuppNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="产品" SortExpression="SEM_SuppNo" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "SER_ProductsBarCode").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="数量" DataField="SER_ScNumber" SortExpression="SER_ScNumber"
                                                                        DataFormatString="{0:f0}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="消耗日期" DataField="SEM_Stime" SortExpression="SEM_Stime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="原材料入库日期" DataField="SEM_Rktime" SortExpression="SEM_Rktime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="入库人" SortExpression="SEM_RkPerson" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "SEM_RkPerson").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="原材料委外日期" DataField="SEM_Wwtime" SortExpression="SEM_Wwtime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="委外人" SortExpression="SEM_WwPerson" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "SEM_WwPerson").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="生产人" SortExpression="SEM_Creator" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "SEM_Creator").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="操作日期" DataField="SEM_Ctime" SortExpression="SEM_Ctime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <HeaderStyle CssClass='colHeader' />
                                                                <RowStyle CssClass='listTableRow' />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass='Custom_DgPage' />
                                                            </cc1:MyGridView>
                                                        </div>
                                                        <div id="tab4" class="tab">

                                                            <iframe runat="server" style="width: 100%; height: 800px" name="Iframe1" id="Iframe1" src="" marginheight="0" frameborder="0"></iframe>

                                                        </div>



                                                    </div>
                                                </div>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                </table>

                                <asp:Panel ID="Pan_Sc" runat="server" Visible="false">

                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">


                                        <tr>
                                            <td colspan="2" class="dvInnerHeader">
                                                <b>产品详细信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">发件人：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_SendEmail" CssClass="detailedViewTextBox" Width="400px"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">收货地点：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:TextBox ID="Tbx_Address" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Height="50px" TextMode="MultiLine"
                                                    Width="400px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">

                                                <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                    class="ListDetails">

                                                    <tr valign="top">
                                                        <td class="ListHead" nowrap>
                                                            <b>类别</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>供应商</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>料号</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>版本号</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>数量</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>单价</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>要求日期</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>总缺料</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>OEM缺料</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>操作</b></td>
                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_SDetail"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="center" style="height: 30px" colspan="2">
                                                  <asp:TextBox runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:Button ID="Btn_Save" runat="server" Text="执行" AccessKey="S" title="执行 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Click" Style="width: 55px; height: 30px;" />
                                                <asp:Button ID="Button2" runat="server" Text="取消" AccessKey="S" title="取消 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Button2_Click" Style="width: 55px; height: 30px;" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>

                </td>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif"/>
                </td>
            </tr>
        </table>


    </form>
</body>
</html>

