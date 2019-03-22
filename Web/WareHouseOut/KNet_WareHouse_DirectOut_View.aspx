<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_WareHouse_DirectOut_View.aspx.cs" Inherits="Web_KNet_WareHouse_DirectOut_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>查看出库单</title>
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>库存出库 > 
	<a class="hdrLink" href="KNet_WareHouse_AllocateList_Manage.aspx">库存出库</a>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>库存出库信息</td>
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
                                            <td valign="top" align="left">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td>
                                                            <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('KNet_WareHouse_DirectOut_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;">&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('KNet_WareHouse_DirectOut_Manage.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                       <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="财务审批" OnClick="btn_Chcek_Click" />

                                                        </td>

                                                        <td align="right">
                                                            <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create" onclick="PageGo('KNet_WareHouse_DirectOut_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')" name="Duplicate" value="复制">&nbsp;
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

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="absmiddle" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">出库单号:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Code" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="dvtCellLabel">出库日期:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="dvtCellLabel">出库仓库:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_House" runat="server"></asp:Label></td>
                                                        <td class="dvtCellLabel">项目:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Project" runat="server"></asp:Label></td>
                                                    </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">领用用途:</td>
                                            <td class="dvtCellInfo">
                                                <asp:Label ID="Lbl_LyTYpe" runat="server"></asp:Label></td>
                                            <td class="dvtCellLabel">附件:</td>
                                            <td class="dvtCellInfo">
                                                <asp:Label ID="KWD_Upload" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">供应商承担:</td>
                                            <td class="dvtCellInfo">
                                                <asp:Label ID="Lbl_IsSuppNo" runat="server"></asp:Label></td>
                                            <td class="dvtCellLabel">OEM:</td>
                                            <td class="dvtCellInfo">
                                                <asp:Label ID="Lbl_OEM" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">客户:</td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:Label ID="Lbl_Customer" runat="server"></asp:Label></td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">联系人:</td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:Label ID="Lbl_ContentPerson" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">主产品:</td>
                                            <td class="dvtCellInfo">
                                                <asp:Label ID="Lbl_MailProducts" runat="server"></asp:Label></td>
                                            <td class="dvtCellLabel">数量:</td>
                                            <td class="dvtCellInfo">
                                                <asp:Label ID="Lbl_MailProductsNumber" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader"><b>描述信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">备注:</td>
                                            <td valign="top" class="dvtCellInfo" colspan="4">
                                                <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="dvInnerHeader">
                                                <b>产品详细信息</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">

                                        <tr valign="top">
                                            <td class="ListHead" nowrap><b>序号</b></td>
                                            <td class="ListHead" nowrap><b>BOM序号</b></td>
                                            <td class="ListHead" nowrap><b>产品名称</b></td>
                                            <td class="ListHead" nowrap><b>产品编码</b></td>
                                            <td class="ListHead" nowrap><b>型号</b></td>
                                            <td class="ListHead" nowrap><b>出库数量</b></td>
                                            <td class="ListHead" nowrap><b>出库单价</b></td>
                                            <td class="ListHead" nowrap><b>出库金额</b></td>
                                             <td class="ListHead" nowrap><b>出库报价</b></td>
                                            <td class="ListHead" nowrap><b>真实金额</b></td>
                                            <td class="ListHead" nowrap><b>计算单价</b></td>
                                            <td class="ListHead" nowrap><b>计算金额</b></td>
                                            <td class="ListHead" nowrap><b>备注</b></td>
                                        </tr>
                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                    </table>
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

