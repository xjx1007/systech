<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_ClientList_View.aspx.cs"
    Inherits="Web_KNet_Sales_ClientList_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register Src="../../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看客户</title>
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
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>市场 > <a class="hdrLink" href="KNet_Sales_ClientList_Manger.aspx">客户</a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
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
                                    <tr valign="bottom">
                                        <td style="height: 44px">
                                            <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                                <tr>
                                                    <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                                    </td>
                                                    <td <%=s_OrderStyle%> align="center" nowrap>
                                                        <a href="KNet_Sales_ClientList_View.aspx?Type=0&CustomerValue=<%= Request.QueryString["CustomerValue"].ToString() %>">客户信息</a>
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
                                            <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                                <tr>
                                                    <td valign="top" align="left"></td>
                                                    <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                                        rowspan="2">
                                                        <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                            <tr>
                                                                <td>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="genHeaderSmall">操作
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="padding-left: 10px;">
                                                                    <img src="/themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                                    <a href="#" onclick="window.open('/Web/Xs/Contract/Xs_Contract_Manage_Add.aspx?CustomerValue=<%= Request.QueryString["CustomerValue"].ToString() %>','Attachments','top=100, left=100,width=1000,height=800');"
                                                                        class="webMnu">创建合同评审</a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="padding-left: 10px;">
                                                                    <img src="/themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                                    <a href="#" onclick="window.open('/Web/Xs/SalesContract/KNet_Sales_ContractList_Add.aspx?CustomerValue=<%= Request.QueryString["CustomerValue"].ToString() %>','Attachments','top=100, left=100,width=1000,height=800');"
                                                                        class="webMnu">创建订单评审</a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="padding-left: 10px;">
                                                                    <img src="/themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                                    <a href="#" onclick="window.open('/Web/Receive/Cw_Accounting_Payment_Add.aspx?CustomerValue=<%= Request.QueryString["CustomerValue"].ToString() %>','Attachments','top=100, left=100,width=1000,height=800');"
                                                                        class="webMnu">创建开票通知</a>
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
                                                                        <li><a href="#tab2">联系人</a></li>
                                                                        <li><a href="#tab3">联系记录</a></li>
                                                                        <li><a href="#tab4">销售机会</a></li>
                                                                        <li><a href="#tab50">订单信息</a></li>
                                                                        <li><a href="#tab5">采购单信息</a></li>
                                                                        <li><a href="#tab6">发货通知单</a></li>
                                                                        <li><a href="#tab7">发货出库单</a></li>
                                                                    </ul>
                                                                    <div class="clr"></div>
                                                                </div>

                                                                <div id="tabs">
                                                                    <!--基本信息-->
                                                                    <div id="tab1" class="tab">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <table border="0" cellspacing="0" cellpadding="0" id="Table_Btn" runat="server" width="100%">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                                                                    onclick="PageOpen('KNet_Sales_ClientList_Add.aspx?ID=<%= Request.QueryString["CustomerValue"].ToString()%>')"
                                                                                                    name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageOpen('KNet_Sales_ClientList_Manger.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                                                            </td>
                                                                                            <td align="right">
                                                                                                <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                                                                    onclick="PageOpen('KNet_Sales_ClientList_Add.aspx?ID=<%= Request.QueryString["CustomerValue"].ToString() %>&Type=1')"
                                                                                                    name="Duplicate" value="复制">&nbsp;
                                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                        onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>基本信息</b>
                                                                                    <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">客户名称:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerName" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td class="dvtCellLabel">简称:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="Tbx_SampleName" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>

                                                                                <td class="dvtCellLabel">客户编号:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerValue" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>

                                                                                <td class="dvtCellLabel">渠道信息:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerClass" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td class="dvtCellLabel">客户类型:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerTypes" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">客户行业:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerTrade" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">客户来源:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerSource" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">所在省份:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerProvinces" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">所在城区:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerCity" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">负 责 人:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerContact" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">是否保护客户:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerProtect" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">移动电话:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerMobile" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">固定电话:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerTel" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">客户网址:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerWebsite" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">电子邮箱:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerEmail" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">联系QQ号:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerQQ" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">联系Msn号:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerMsn" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">通信地址:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerAddress" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">邮政编码:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerZipCode" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">客户积分:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerIntegral" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">加入日期:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="CustomerAddtime" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">付款方式:
                                                                                </td>
                                                                                <td class="dvtCellInfo" >
                                                                                    <asp:Label ID="Lbl_PayMent" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td class="dvtCellLabel">开票方式:
                                                                                </td>
                                                                                <td class="dvtCellInfo" >
                                                                                    <asp:Label ID="Lbl_KPType" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">代理费单价:
                                                                                </td>
                                                                                <td class="dvtCellInfo" >
                                                                                    <asp:Label ID="Lbl_DlPrice" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">销售负责人1:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">销售负责人2:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="Lbl_DutyPerson1" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">市场负责人1:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="Lbl_Auxiliary" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                                <td width="17%" class="dvtCellLabel">市场负责人2:
                                                                                </td>
                                                                                <td class="dvtCellInfo">
                                                                                    <asp:Label ID="Lbl_Auxiliary1" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="dvtCellLabel">客户简介:
                                                                                </td>
                                                                                <td class="dvtCellInfo" colspan="4">
                                                                                    <asp:Label ID="CustomerIntroduction" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>生产要求</b>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                    <table id="FHTable" width="100%" border="0" align="left" cellpadding="0" cellspacing="0" class="ListDetails">
                                                                                        <tr id="tr3">
                                                                                            <td class="ListHead" align="center" >序号
                                                                                            </td>
                                                                                            <td class="ListHead" align="center" >名称
                                                                                            </td>
                                                                                            <td class="ListHead" align="left">发货说明
                                                                                            </td>
                                                                                        </tr>
                                                                                        <asp:Label ID="Lbl_FhDetails" runat="server"></asp:Label>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>销售产品</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <asp:TextBox ID="Xs_MaterID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                    <table id="myTable" width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                                                        <tr id="tr1">
                                                                                            <td align="center" class="ListHead">序号
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">产品编码
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">产品名称
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">产品型号
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%=s_MyTable_Detail %>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                               <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>代理客户</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <asp:TextBox ID="Tbx_CustomerNum" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                    <table id="Table1" width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                                                        <tr id="tr2">
                                                                                            <td align="center" class="ListHead">序号
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">客户
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%=s_MyTable_Detail1 %>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                               <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>代理费</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                    <table id="Table2" width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                                                        <tr id="tr4">
                                                                                            <td align="center" class="ListHead">序号
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">最小
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">=<值<=
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">最大
                                                                                            </td>
                                                                                            <td align="center" class="ListHead">到期日期
                                                                                            </td>
                                                                                        </tr>          
                                                                                        <%=s_MyTable_Detail2 %>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <uc1:CommentList ID="CommentList1" runat="server" CommentFID="0" CommentType="-1" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <!--联系人-->
                                                                    <div id="tab2" class="tab">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <b>联系人</b>
                                                                                </td>
                                                                                <td colspan="2" align="right">
                                                                                    <input accesskey="E" class="crmbutton small create" name="Edit" onclick="PageOpen('KNet_Sales_LinkMan_Add.aspx?CustomerValue=<%= Request.QueryString["CustomerValue"].ToString() %>')" title="新增联系人" type="button" value="&nbsp;新增联系人&nbsp;">&nbsp; </input>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <cc1:MyGridView ID="GridView_LinkMan" runat="server"  AllowSorting="True" AutoGenerateColumns="False" CssClass="Custom_DgMain" IsShowEmptyTemplate="true" Width="100%"><Columns><asp:TemplateField HeaderStyle-HorizontalAlign="center" HeaderText="姓名" ItemStyle-HorizontalAlign="Left" SortExpression="XOL_Name"><ItemTemplate><a href='KNet_Sales_LinkMan_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XOL_ID") %>' target="_blank"><%# DataBinder.Eval(Container.DataItem, "XOL_Name") %></a></ItemTemplate></asp:TemplateField><asp:BoundField DataField="XOL_Code" HeaderText="编码" SortExpression="XOL_Code"><ItemStyle Font-Size="12px" HorizontalAlign="Left" /><HeaderStyle Font-Size="12px" HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="XOL_Mail" HeaderText="Email" SortExpression="XOL_Mail"><ItemStyle Font-Size="12px" HorizontalAlign="Left" /><HeaderStyle Font-Size="12px" HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="XOL_phone" HeaderStyle-HorizontalAlign="center" HeaderText="电话" ItemStyle-HorizontalAlign="Left" SortExpression="XOL_phone"><ItemStyle Font-Size="12px" HorizontalAlign="Left" /><HeaderStyle Font-Size="12px" HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="XOL_Responsible" HeaderText="负责事务" SortExpression="XOL_Responsible"><ItemStyle Font-Size="12px" HorizontalAlign="Left" /><HeaderStyle Font-Size="12px" HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="XOL_Duty" HeaderText="部门" SortExpression="XOL_Duty"><ItemStyle Font-Size="12px" HorizontalAlign="Left" /><HeaderStyle Font-Size="12px" HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="XOL_Address" HeaderText="地址" SortExpression="XOL_Address"><ItemStyle Font-Size="12px" Width="200px" HorizontalAlign="Left" /><HeaderStyle Font-Size="12px" HorizontalAlign="Left" /></asp:BoundField></Columns><HeaderStyle CssClass="colHeader" /><RowStyle CssClass="listTableRow" /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass="Custom_DgPage" /></cc1:MyGridView>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>组织结构</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4">
                                                                                    <%= s_Structure %>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <!--联系记录-->
                                                                    <div id="tab3" class="tab">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                            <tr>
                                                                                <td colspan="2" align="left">
                                                                                    <b>联系记录</b>：
                                                                                </td>
                                                                                <td colspan="2" align="right">
                                                                                    <input title="新增联系记录" type="button" accesskey="E" class="crmbutton small create"
                                                                                        onclick="PageOpen('/Web/Xs/CustomerContent/Xs_Sales_Content_Add.aspx?CustomerValue=<%= Request.QueryString["CustomerValue"].ToString() %>')"
                                                                                        name="Edit" value="&nbsp;新增联系记录&nbsp;">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                  
                                                                                      <cc1:MyGridView ID="GridView_Contenct" runat="server" AllowPaging="True" PageSize="5"  AllowSorting="True"
                                                            IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                            Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="主题" SortExpression="XSC_Topic" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <a href="../CustomerContent/Xs_Sales_Content_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSC_ID") %>" target="_blank">
                                                                            <%# DataBinder.Eval(Container.DataItem, "XSC_Topic").ToString()%></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="客户名称" SortExpression="XSC_CustomerValue" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "XSC_CustomerValue").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="联系人" SortExpression="XSC_LinkMan" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetLinkManValue(DataBinder.Eval(Container.DataItem, "XSC_LinkMan").ToString(),"XOL_Name")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="联系类型" SortExpression="XSC_Types" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetBasicCodeName("117",DataBinder.Eval(Container.DataItem, "XSC_Types").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="联系日期" DataField="XSC_Stime" SortExpression="XSC_Stime"
                                                                    DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="负责人" SortExpression="XSC_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSC_DutyPerson").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="创建人" SortExpression="XSC_Creator" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSC_Creator").ToString())%>
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

                                                                    </div>
                                                                    <!--销售机会-->
                                                                    <div id="tab4" class="tab">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                                            <tr>
                                                                                <td colspan="2" align="left">
                                                                                    <b>销售机会</b>：
                                                                                </td>
                                                                                <td colspan="2" align="right">
                                                                                    <input title="新增销售机会" type="button" accesskey="E" class="crmbutton small create"
                                                                                        onclick="PageOpen('/Web/Xs/SalesOpp/Xs_Sales_Opp_Add.aspx?CustomerValue=<%= Request.QueryString["CustomerValue"].ToString() %>')"
                                                                                        name="Edit" value="&nbsp;新增销售机会&nbsp;">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">

                                                                                    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                            IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='/themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="销售机会名称" SortExpression="XSO_Name" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <a href="../SalesOpp/Xs_Sales_Opp_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSO_DID") %>" target="_blank">
                                                            <%# DataBinder.Eval(Container.DataItem, "XSO_Name").ToString()%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="客户名称" SortExpression="XSO_CustomerValue" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "XSO_CustomerValue").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="销售阶段" SortExpression="XSO_SalesStep" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("118", DataBinder.Eval(Container.DataItem, "XSO_SalesStep").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="可能性" SortExpression="XSO_Precent" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("154", DataBinder.Eval(Container.DataItem, "XSO_Precent").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="销售过程" SortExpression="XSO_SalesType" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("202", DataBinder.Eval(Container.DataItem, "XSO_SalesType").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="联系人" SortExpression="XSO_LinkMan" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetLinkManValue(DataBinder.Eval(Container.DataItem, "XSO_LinkMan").ToString(),"XOL_Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="时间结点" DataField="XSO_PlanDealDate" SortExpression="XSO_PlanDealDate"
                                                    DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="下一步" DataField="XSO_NextPlan" SortExpression="XSO_NextPlan"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="负责人" SortExpression="XSO_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSO_DutyPerson").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="辅助人" SortExpression="XSO_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSO_FDutyPerson").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="操作时间" HeaderStyle-HorizontalAlign="center" SortExpression="XSO_CTime">
                                                    <ItemTemplate>
                                                        <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "XSO_MTime").ToString()).ToString()%>
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

                                                                    </div>
                                                                    
                                                                    <div id="tab50" class="tab">
                                                                        
                                                                        
                                                        
                            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5"  AllowSorting="True"
                                IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='/themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                AutoGenerateColumns="False" Width="100%" >
                                <Columns>
                                    <asp:TemplateField HeaderText="合同编号" SortExpression="ContractNo" HeaderStyle-Font-Size="12px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <a href="/Web/Xs/SalesContract/KNet_Sales_ContractList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>" target="_blank">
                                                <%# DataBinder.Eval(Container.DataItem, "ContractNo").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="责任人" SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="合同分类" SortExpression="ContractClass" HeaderStyle-Font-Size="12px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "ContractClass").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="产品类型" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetContractProductsPatten(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField HeaderText="数量" DataField="V_ContractAmount" SortExpression="v_OutWareAmount"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="备品" DataField="V_ContractBAmount" SortExpression="v_OutWareAmount"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="通知数量" DataField="v_OutWareAmount" SortExpression="v_OutWareAmount"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="出库数量" DataField="v_DirectOutAmount" SortExpression="v_DirectOutAmount"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="操作日期" DataField="SystemDateTimes" SortExpression="SystemDateTimes"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="状态" SortExpression="ContractCheckYN" HeaderStyle-Font-Size="12px"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# base.GetContractState(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                            </Columns>
                                <HeaderStyle CssClass='colHeader' />
                                <RowStyle CssClass='listTableRow' />
                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
                                                                        </div>
                                                                    <!--采购单信息-->
                                                                    <div id="tab5" class="tab">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                            <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>采购单信息</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                           <cc1:MyGridView ID="GridView_Order" Width="99%" runat="server" AllowSorting="True" AllowPaging="True" PageSize="5" 
                                                            EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                            GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="采购单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <a href="/Web/CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>" target="_blank">
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
                                                                <asp:TemplateField HeaderText="产品类型" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetOrderDetailProductsPatten(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
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
                            </cc1:MyGridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                    <!--发货通知单-->
                                                                    <div id="tab6" class="tab">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                            <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>发货通知单</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">


                            <cc1:MyGridView ID="GridView_Ship" Width="99%" runat="server" AllowSorting="True" pageSize="5" AllowPaging="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                            GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false" HeaderStyle-Height="25px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="发货单号" SortExpression="OutWareNo" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-Width="28px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <a href="/Web/Xs/SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>"
                                                                            target="_blank">
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
                                                        </cc1:MyGridView >
                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>

                                                                    <!--发货出库单-->
                                                                    <div id="tab7" class="tab">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                            <tr>
                                                                                <td colspan="4" class="detailedViewHeader">
                                                                                    <b>发货出库单</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                          <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关的出库单</B><br/><br/></font></div>"
                                AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%" ><Columns>


                                    <asp:TemplateField HeaderText="出库单号" SortExpression="DirectOutNo">
                                        <ItemTemplate>
                                            <a href="/Web/Xs/SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>"
                                                target="_blank">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="通知单号" SortExpression="KWD_Custmoer">
                                        <ItemTemplate>
                                            <a href="/Web/SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo")%>"
                                                target="_self">
                                                <%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="类型" SortExpression="KWD_Custmoer">
                                        <ItemTemplate>
                                                <%# GetShipType(DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString())%>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
               <%# base.Base_GetShipDetailProductsPatten(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
               <%# base.Base_GetShipDetailNumbers(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="DirectOutDateTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="账务日期" DataField="Kwd_CwOutTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="Kwd_CwOutTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="仓库" SortExpression="HouseNo" ItemStyle-Width="50px" >
                                            <itemtemplate>
               <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="出库人" SortExpression="DirectOutStaffBranch">
                                            <itemtemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DirectOutStaffNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="物流部"  HeaderStyle-Font-Size="12px" ItemStyle-Width="130px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
           <%# GetDirectOutListfollowup( DataBinder.Eval(Container.DataItem, "DirectOutNo"), DataBinder.Eval(Container.DataItem, "DirectOutCheckYN"))%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="销售部"  HeaderStyle-Font-Size="12px" ItemStyle-Width="90px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
           <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "KWD_ShipNo"))%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态" SortExpression="DirectOutNo" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
           <%# GetKDSateName(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="审核" SortExpression="DirectOutCheckYN" HeaderStyle-Font-Size="12px"
                                             ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <itemtemplate>
               <%# GetOrderCheckYN(DataBinder.Eval(Container.DataItem, "DirectOutNo"))%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="应收款" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <itemtemplate>
               <%# base.Base_GetBasicCodeName("212", DataBinder.Eval(Container.DataItem, "v_State").ToString(), "/Web/Receive/Cw_Accounting_Payment_Add.aspx?OutWareNo=" + DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                                                                                                 </Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>   
                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
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
<%--收货单信息  结束--%>
