<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CG_ApplicationPayment_For_View.aspx.cs" Inherits="Web_CG_Payment_For_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>月度用款申请</title>
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>月度用款申请 > 
	<a class="hdrLink" href="CG_Payment_For_List.aspx">月度用款申请</a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif"></td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px"></div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;</td>
                                        <td class="dvtSelectedCell" align="center" nowrap>月度用款申请信息</td>
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
                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('CG_Payment_For_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;">&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('CG_Payment_For_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                        <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="通过" OnClick="btn_Chcek_Click"  />&nbsp;
                                        <asp:Button ID="Button1" runat="server" class="crmbutton small edit" Text="不通过"  OnClick="Button1_Click" />&nbsp;

                                                    </td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create" onclick="PageGo('CG_Payment_For_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')" name="Duplicate" value="复制">&nbsp;
                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">

                                                        

        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopLeft.gif"></td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px"></div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Label1"></asp:Label>&nbsp;</span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;</td>
                                        <td class="dvtSelectedCell" align="center" nowrap>月度用款申请信息</td>
                                        <td class="dvtTabCache" style="width: 10px">&nbsp;</td>
                                        <td class="dvtTabCache" style="width: 100%">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">

                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                    </td>
                                                </tr>
                                        <tr>
                                             <td width="16%" align="right" class="dvtCellLabel">编号：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                            <pc:PTextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ></pc:PTextBox></td>

                                            <td width="16%" align="right" class="dvtCellLabel">标题：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Title" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox></td>

                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">时间：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Stime" Width="180px" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></pc:PTextBox>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">负责人：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson"></asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">金额：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Money" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="120px" ValidType="String"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="right" class="dvtCellLabel">简介：
                                            </td>
                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="600px" Height="40px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                                    <td colspan="4" class="detailedViewHeader"><b>用款单信息</b>
                                                    </td>
                                                </tr>
                                        <tr>
                                            <td align="left">子项：</td>
                                            <td colspan="3" align="right" Height="30px">                    
                                                <span id="templateSeletor" runat="server" style="display: none" >
                                                <asp:DropDownList runat="server" ID="Ddl_Template"></asp:DropDownList>
                                                   </span>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="dvtCellInfo" colspan="4">
                                                <table cellpadding="2" class="ListDetails" align="center" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td class="ListHead">编号</td>
                                                        <td class="ListHead">用途</td>
                                                        <td class="ListHead">收款人</td>
                                                        <td class="ListHead">用款日期</td>
                                                        <td class="ListHead">用款人</td>
                                                        <td class="ListHead">金额</td>
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
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif" /></td>
            </tr>
        </table>

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
                                    <td align="left" style="padding-left:10px;border-bottom:1px dotted #CCCCCC;">
                                    <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                        <asp:Label runat="server" ID="Lbl_LinkPay"></asp:Label>
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
                    <img src="/themes/softed/images/showPanelTopRight.gif"></td>

            </tr>
        </table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

    