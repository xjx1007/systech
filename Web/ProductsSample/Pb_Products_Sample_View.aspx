<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pb_Products_Sample_View.aspx.cs"
    Inherits="Web_Pb_Products_Sample_View" %>

<%@ Register Src="../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
<%@ Register Src="../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title>样品申请查看</title>
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>样品申请 > <a class="hdrLink" href="Pb_Products_Sample_List.aspx">样品申请</a>
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
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;</td>
                                        <td <%=s_OrderStyle%> align="center" nowrap><a href="Pb_Products_Sample_View.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">样品申请信息</a></td>
                                        <td class="dvtTabCache" style="width: 10px">&nbsp;</td>
                                        <td <%=s_DetailsStyle%> align="center" nowrap>
                                            <a href="Pb_Products_Sample_View.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">相关信息</a></td>
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
                                            <table border="0" cellspacing="0" cellpadding="0" id="Table_Btn" runat="server" width="100%">
                                                <tr>
                                                    <td>
                                                        <input title="设计修改 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                            onclick="PageGo('Pb_Products_Sample_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=0')"
                                                            name="Edit" value="&nbsp;设计修改&nbsp;">&nbsp;
                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                        onclick="PageGo('Pb_Products_Sample_Add.aspx?ID=<%= Request.QueryString["ID"].ToString()%>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('Pb_Products_Sample_List.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                            onclick="PageGo('Pb_Products_Sample_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
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
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="genHeaderSmall">操作
                                                    </td>
                                                </tr>
                                                <!-- Module based actions starts -->
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <a href="../ProductsModel/KnetProductsSetting_Add.aspx" class="webMnu">创建样品</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <a href="../CG/Order/Knet_Procure_OpenBilling.aspx" class="webMnu">创建采购单</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <a href="../ProductsTry/Zl_Project_ProductsTry_Add.aspx?SampleID=<%= Request.QueryString["ID"].ToString()%>" class="webMnu">创建产品试制</a>
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
                                                            <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">样品主题:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Name" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">申请日期:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="17%" class="dvtCellLabel">申请人:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_DutyPeson" runat="server" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">需要日期:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_NeedTime" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">客户:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_CustomerValue" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">联系人:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_LinkMan" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">产品:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_ProductsBar" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>样品要求</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">外壳:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Shell" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">外形:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Appearance" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">导电胶:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Resin" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">导电胶材料:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_ResinMaterial" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">芯片:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Chip" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">数量:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Number" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">申请状态:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <b>
                                                                <asp:Label ID="Lbl_Dept" runat="server"></asp:Label>&nbsp;</b>
                                                        </td>
                                                        <td class="dvtCellLabel">产品:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_ProductsBarCode" CssClass="Custom_Hidden" runat="server"></asp:TextBox>
                                                            <asp:Label runat="server" ID="Lbl_Products"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">样品要求:
                                                        </td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:Label ID="Lbl_Requirement" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">样品用途:
                                                        </td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:Label ID="Lbl_Use" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>上传信息</b>
                                                        </td>
                                                    </tr>
                                                    <asp:TextBox ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                    <tr id="AddPic" runat="server">
                                                        <td class="dvtCellInfo" colspan="4">
                                                            <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="ListDetails" style="height: 28px">
                                                                <!-- Header for the Product Details -->
                                                                <tr valign="top">
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>名称</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>资料</b>
                                                                    </td>
                                                                </tr>
                                                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                            </table>
                                                        </td>
                                                    </tr>

                                                    <asp:Panel runat="server" ID="Pan_Products">

                                                        <tr>
                                                            <td colspan="4" class="detailedViewHeader">
                                                                <b>产品BOM信息</b>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                                <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="0" class="ListDetails"
                                                                    cellspacing="0">
                                                                    <tr id="tr3">
                                                                        <td align="center" class="ListHead">序号
                                                                        </td>
                                                                        <td align="center" class="ListHead">类别
                                                                        </td>
                                                                        <td align="center" class="ListHead">供应商
                                                                        </td>
                                                                        <td align="center" class="ListHead">规格
                                                                        </td>
                                                                        <td align="center" class="ListHead">数量
                                                                        </td>
                                                                        <td align="center" class="ListHead">参考价格
                                                                        </td>
                                                                        <td align="center" class="ListHead">备注
                                                                        </td>
                                                                    </tr>
                                                                    <%=s_ProductsTable_BomDetail %>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>描述信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">备注:
                                                        </td>
                                                        <td valign="top" class="dvtCellInfo" colspan="4">
                                                            <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>
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

                                            </asp:Panel>

                                            <asp:Panel ID="Pan_Detail" runat="server">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td class="detailedViewHeader">
                                                            <b>确认信息</b>
                                                            <asp:Label ID="Label1" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellInfo">
                                                            <table id="Table1" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="ListDetails" style="height: 28px">
                                                                <tr valign="top">
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>序号</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>确认人</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>确认日期</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>备注</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>名称</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" colspan="2" nowrap>
                                                                        <b>资料</b>
                                                                    </td>
                                                                </tr>
                                                                <asp:Label runat="server" ID="Lbl_QrDetails"></asp:Label>
                                                            </table>
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
