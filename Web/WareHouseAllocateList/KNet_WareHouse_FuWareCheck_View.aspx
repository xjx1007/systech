<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_WareHouse_FuWareCheck_View.aspx.cs" Inherits="Web_WareHouseAllocateList_KNet_WareHouse_FuWareCheck_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>查看入库申请</title>
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>申请 > 
	<a class="hdrLink" href="KNet_WareHouse_AllocateList_Manage.aspx">入成品库申请</a>
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
                                                            <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('KNet_WareHouse_FuWareCheck_UpdateView.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;">
                                                        &nbsp;
                                   
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
                                                            <%--<a href="../CustomerContent/Xs_Sales_Content_Add.aspx?CustomerValue=<%=s_CustomerValue %>&LinkMan=<%=s_LinkMan %>&OppID=<%=s_OppID %>" class="webMnu">调入士腾仓</a>--%>
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
                                                                <asp:Label ID="Tbx_OrderNo1" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                                <asp:Label ID="Tbx_OrderNo" runat="server"></asp:Label>
                                                            </td>
                                                   
                                            </td>
                                            <td class="dvtCellLabel">调拨类型:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:Label ID="Chk_Type1" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                <asp:Label ID="Chk_Type" runat="server"></asp:Label>
                                            </td>
                                      
                                </td>
                            </tr>
                            <tr>
                                <td class="dvtCellLabel">调出仓库:</td>
                                <td class="dvtCellInfo">
                                    <asp:Label ID="Lbl_HouseNo" runat="server" Style="display: none"></asp:Label>
                                    <asp:Label ID="Lbl_House_Out" runat="server"></asp:Label></td>
                                <td class="dvtCellLabel">送货单附件:</td>
                                <td class="dvtCellInfo">
                                    <asp:Label ID="KWA_UploadName" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                    <asp:Label ID="KWA_UploadUrl1" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                    <asp:Label ID="KWA_UploadUrl" runat="server"></asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="dvtCellLabel">调入仓库:</td>
                                <td class="dvtCellInfo">
                                    <asp:Label ID="Lbl_House_int" runat="server"></asp:Label>
                                    <asp:Label ID="Lbl_House_int0" runat="server" CssClass="Custom_Hidden"></asp:Label></td>
                                <td class="dvtCellLabel">是否实物:</td>
                                <td class="dvtCellInfo">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>

                            </tr>

                            <tr>
                                <td class="dvtCellLabel">生产订单号:</td>
                                <td class="dvtCellInfo" colspan="3">
                                    <asp:Label ID="KSP_SID" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                    <asp:Label ID="KWA_IsEntity" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                    <asp:Label ID="Lbl_OrderNo" runat="server"></asp:Label>
                                </td>
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
                                <td colspan="4" align="center">&nbsp;
                                <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="确认入库" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClick="Btn_Save_OnClick" Style="width: 70px; height: 33px;" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                        type="button" name="button" value="返回列表" style="width: 70px; height: 33px;">
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
