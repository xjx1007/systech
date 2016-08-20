<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Accounting_Pay_View.aspx.cs" Inherits="Web_Cw_Accounting_Pay" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
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
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>应付款 > 
	<a class="hdrLink" href="Cw_Accounting_Pay_List.aspx">应付款</a>
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
                                        <td class="dvtSelectedCell" align="center" nowrap>应付款信息</td>
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
                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('Cw_Accounting_Pay_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;">&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Cw_Accounting_Pay_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;</td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create" onclick="PageGo('Cw_Accounting_Pay_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')" name="Duplicate" value="复制">&nbsp;
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
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <asp:Label runat="server" ID="Lbl_Link"></asp:Label>&nbsp;

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
                                                    <td class="dvtCellLabel">编码:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_ID" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">供应商/客户:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_Customer" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td class="dvtCellLabel">付款类型:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Lbl_Type" runat="server"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">应付日期:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_YTime" runat="server"></asp:Label>&nbsp;</td>
                                                    <td class="dvtCellLabel">应付金额:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_YMoney" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">实付日期:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_STime" runat="server"></asp:Label>&nbsp;</td>
                                                    <td class="dvtCellLabel">实付金额:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_SMoney" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <tr>
                                                        <td class="dvtCellLabel">票据单号:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Tbx_YFBillCode"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">到期日期:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Tbx_YFOutDate"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <td width="17%" class="dvtCellLabel">备注:</td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Lbl_Details" runat="server" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                    </td>

                                                </tr>
                                                <asp:Panel runat="server" ID="Pan_Bill" Visible="false">
                                                    <tr>
                                                        <td class="detailedViewHeader" colspan="4">
                                                            <b>现有票据信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <asp:TextBox ID="BillNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                        <asp:TextBox ID="BillID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                            <table id="BillTable" width="100%" border="0" align="center" cellpadding="0"
                                                                cellspacing="0" class="ListDetails">
                                                                <tr id="tr3">
                                                                    <td align="center" class="ListHead">操作
                                                                    </td>
                                                                    <td align="center" class="ListHead">票据单号
                                                                    </td>
                                                                    <td align="center" class="ListHead">票据日期
                                                                    </td>
                                                                    <td align="center" class="ListHead">到期日期
                                                                    </td>
                                                                    <td align="center" class="ListHead">票据金额
                                                                    </td>
                                                                    <td align="center" class="ListHead">摘要
                                                                    </td>
                                                                    <td align="center" class="ListHead">来源
                                                                    </td>
                                                                </tr>
                                                                <asp:Label runat="server" ID="Lbl_Details1"></asp:Label>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="detailedViewHeader" colspan="4">
                                                            <b>添加票据信息</b>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right" class="dvtCellInfo" colspan="4">

                                                            <asp:TextBox ID="Tbx_NewBillNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

                                                            <table cellpadding="2" class="dvtCellInfo" id="newBill" align="center" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td class="ListHead">删除</td>
                                                                    <td class="ListHead">单号</td>
                                                                    <td class="ListHead">票据日期</td>
                                                                    <td class="ListHead">到期日期</td>
                                                                    <td class="ListHead">票据金额</td>
                                                                    <td class="ListHead">摘要</td>
                                                                    <td class="ListHead">来源</td>
                                                                </tr>
                                                                <asp:Label runat="server" ID="Lbl_Details2"></asp:Label>

                                                            </table>

                                                        </td>
                                                    </tr>
                                                </asp:Panel>
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

