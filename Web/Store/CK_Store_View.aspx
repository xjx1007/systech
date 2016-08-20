<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CK_Store_View.aspx.cs" Inherits="Web_CK_Store_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
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
                成品出库生成 > <a class="hdrLink" href="CK_Store_View.aspx">成品出库生成</a>
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
                                    <td class="dvtSelectedCell" align="center" nowrap>
                                        成品出库生成信息
                                    </td>
                                    <td class="dvtTabCache" style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td class="dvtUnSelectedCell" align="center" nowrap>
                                        <a href="#">相关信息</a>
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
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td>
                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                        onclick="PageGo('Sc_Expend_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('CK_ProductsIn_Manage.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                </td>
                                                <td align="right">
                                                    <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                        onclick="PageGo('Sc_Expend_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
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
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>基本信息</b>
                                                    <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    编号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_BCode" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    入库日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    供应商:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_SuppNo" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    客户:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_CustomerName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="17%" class="dvtCellLabel">
                                                    负责人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_DutyPerson" runat="server" Width="178px" ReadOnly="true"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    产品型号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_ProductsEdition" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>遥控器入库信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" >
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr valign="top">
                                                            <td class="ListHead" nowrap>
                                                                <b>产品名称</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>产品编码</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>型号</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>数量</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>单价</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>金额</b>
                                                            </td>
                                                        </tr>
                                                <%=s_MyTable_Detail %>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>原材料委外加工发料信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" >
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr valign="top">
                                                            <td class="ListHead" nowrap>
                                                                <b>产品名称</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>产品编码</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>型号</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>仓库</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>类型</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>入库人</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>入库时间</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>数量</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>单价</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>金额</b>
                                                            </td>
                                                        </tr>
                                                <%=s_MyTable_Detail1 %>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>原材料委外加工耗料信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" >
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr valign="top">
                                                            <td class="ListHead" nowrap>
                                                                <b>产品名称</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>产品编码</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>型号</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>仓库</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>类型</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>入库人</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>入库时间</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>数量</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>单价</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>金额</b>
                                                            </td>
                                                        </tr>
                                                <%=s_MyTable_Detail2 %>
                                                    </table>
                                                </td>
                                            </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table> </td>
        <td valign="top">
            <img src="../../themes/softed/images/showPanelTopRight.gif">
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
<%--收货单信息  结束--%>
