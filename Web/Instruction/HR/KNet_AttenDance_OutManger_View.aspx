<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_AttenDance_OutManger_View.aspx.cs"
    Inherits="Web_Sales_KNet_AttenDance_OutManger_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <title>考勤明细</title>
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
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                考勤 > <a class="hdrLink" href="KNet_AttenDance_OutManger.aspx">考勤</a>
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
                                        <a href="Knet_Procure_OpenBilling_View.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">
                                            考勤信息</a>
                                    </td>
                                    <td class="dvtTabCache" style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td <%=s_DetailsStyle%> align="center" nowrap>
                                        <a href="Knet_Procure_OpenBilling_View.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">
                                            相关信息</a>
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
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" id="Table_Btn" runat="server">
                                            <tr>
                                                <td>
                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                        onclick="PageGo('KNet_AttenDance_OutManger_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('KNet_AttenDance_OutManger.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('inc/KNet_AttenDance_OutManger_Do.aspx')"
                                                        type="button" name="ListView" value="&nbsp;审核&nbsp;">&nbsp;
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                            onclick="PageGo('KNet_AttenDance_OutManger_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
                                                            name="Duplicate" value="复制">&nbsp;
                                                        <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                            onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                    </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                        rowspan="3">
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
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        考勤单:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        状态:<asp:Label ID="ThisState" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        申请人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="StaffName" runat="server" Text=""></asp:Label>
                                                        &nbsp;卡号:<asp:Label ID="StaffCard" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        类型:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="ThisKings" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        申请时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="AddDatetime" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        所在部门:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="StaffDepart" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        公司:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="StaffBranch" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" class="dvtCellLabel">
                                                        开始时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="StartDateTime" runat="server" Width="178px" ReadOnly="true"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        结束时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="EndDatetime" runat="server" Width="178px" ReadOnly="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        审批人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="ApprovalStaffNo" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        审批时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="ApprovalDatetime" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        目的地:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="thisExtendA" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        请假类型:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_Type" runat="server" Width="150px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        拜访客户\供应商:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                        <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr id="tr1">
                                                                <td align="center" class="dvtCellInfo">
                                                                    客户编号
                                                                </td>
                                                                <td align="center" class="dvtCellInfo">
                                                                    客户名称
                                                                </td>
                                                                <td align="center" class="dvtCellInfo">
                                                                    联系记录
                                                                </td>
                                                            </tr>
                                                            <%=s_MyTable_Detail %>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        请假原因:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="OutJustificate" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr  runat="server" id="Tr_Reports">
                                                    <td class="dvtCellLabel">
                                                        出差报告:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                            <asp:TextBox ID="Tbx_Remarks" runat="server" TextMode="MultiLine" Width="100%"
                                                 CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                                        <asp:Label ID="Lbl_Remarks" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                                <tr  runat="server" id="Tr_Save">
                                                    <td colspan="4" align="center" style="height: 30px">
                                                        <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                            class="crmbutton small save" onclick="Btn_Save_Click"/>
                                                        <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                            type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Pan_Detail" runat="server">
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
