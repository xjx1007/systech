<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CG_Account_Bill_View.aspx.cs"
    Inherits="Web_CG_Account_Bill_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png"/>
    <title>发票管理</title>
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
                采购 > <a class="hdrLink" href="CG_Account_Bill_List.aspx">发票管理</a>
            </td>
            <td width="100%" nowrap>
                <asp:Label ID="Lbl_ID" runat="server" Style="display: none"></asp:Label>&nbsp;
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
                <img src="../../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td class="showPanelBg" valign="top" width="100%">
                <div class="small" style="padding: 10px">
                </div>
                <span class="lvtHeaderText">
                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
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
                                        期初金额信息
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
                                                        onclick="PageGo('CG_Account_Bill_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('CG_Account_Bill_List.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                    <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="反审批" OnClick="btn_Chcek_Click" /></td>

                                                </td>
                                                <td align="right">&nbsp;<input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                        onclick="PageGo('CG_Account_Bill_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel" width="15%">
                                                    编号:
                                                </td>
                                                <td class="dvtCellInfo" width="35%" colspan="3">
                                                    <asp:Label runat="server" ID="Lbl_Code"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="17%" class="dvtCellLabel">
                                                    供应商:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_CustomerName" runat="server" Width="200px" ReadOnly="true"></asp:Label>&nbsp;
                                                </td>
                                                <td width="17%" class="dvtCellLabel">
                                                    对账单号:
                                                </td>
                                                <td class="dvtCellInfo" >
                                                    <asp:Label ID="Lbl_CheckNo" runat="server" Width="200px" ReadOnly="true"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    付款方式:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                    <asp:Label runat="server" ID="Lbl_PayMent"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    票据类型:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_BillType" runat="server">
                                                    </asp:Label>&nbsp;
                                                </td>
                                                <td class="dvtCellLabel">
                                                    开票日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_STime" runat="server"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    责任人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label runat="server" ID="Lbl_DutyPerson">
                                                    </asp:Label>&nbsp;
                                                </td>
                                                <td class="dvtCellLabel">
                                                    票据金额:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label runat="server" ID="Lbl_Money" AllowEmpty="false"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    发票号码:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label runat="server" ID="Lbl_BillNumber"></asp:Label>&nbsp;
                                                </td>
                                                <td class="dvtCellLabel">
                                                    经手人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label runat="server" ID="Lbl_Brokerage"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>帐期</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                        <%=s_Return%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>描述信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    备注:
                                                </td>
                                                <td class="dvtCellInfo" colspan="4">
                                                    <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>产品详细信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" >
                                                    <asp:Label runat="server" ID="Lbl_Detail"></asp:Label>
                                        <asp:TextBox runat="server" ID="Lbl_Detail1" CssClass="Custom_Hidden"></asp:TextBox>
                                                </td>
                                            </tr>
                                                <tr>
                                                    <td colspan="4">

                                                        <table id="myTable" width="100%" border="0" align="center" cellpadding="2" cellspacing="0" class="ListDetails" style="height: 28px">
                                                            <tr valign="top">
                                                                <td class="ListHead" nowrap>
                                                                    <b>单号</b></td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>日期</b></td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>金额</b></td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>备注</b></td>
                                                            </tr>                                                                           
                                                            <tr >
                                                                <td class="ListHeadDetails" nowrap>
                                                                    
                                                        <pc:PTextBox runat="server" ID="Tbx_Code"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                                </td>
                                                                <td class="ListHeadDetails" nowrap>
                                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker();ChangePayMent()"></asp:TextBox>

                                                                </td>
                                                                <td class="ListHeadDetails" nowrap>
                                                        <pc:PTextBox runat="server" ID="Tbx_Money"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox></td>
                                                                <td class="ListHeadDetails" nowrap>
                                                        <pc:PTextBox runat="server" ID="Tbx_Remarks"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox></td>
                                                            </tr>                                         
                                                            </table>
                                                        </td>
                                                    </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <img src="../../../themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
<%--收货单信息  结束--%>
