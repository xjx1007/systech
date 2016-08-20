<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CG_Payment_For_View.aspx.cs" Inherits="Web_CG_Payment_For_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>用款申请</title>
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>用款申请 > 
	<a class="hdrLink" href="CG_Payment_For_List.aspx">用款申请</a>
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
                                        <td class="dvtSelectedCell" align="center" nowrap>用款申请信息</td>
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
                                        <td class="dvtSelectedCell" align="center" nowrap>用款申请信息</td>
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
                                                    <td class="dvtCellLabel">用款用途:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_Used"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">申请日期:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_STime" runat="server" ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">货币类型:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_Currency"  runat="server" ></asp:Label>&nbsp;
                                                        
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">用款方式:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_UseType"  runat="server" ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="dvtCellLabel">金额:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_Money"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';Chang();" ></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">大写:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_ChineseMoney"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ></asp:Label>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="17%" class="dvtCellLabel">收款人:</td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="Tbx_PayeeValue" id="Tbx_PayeeValue" runat="server" style="width: 150px" />
                                                        <asp:Label ID="Tbx_PayeeName" runat="server" AllowEmpty="false" ValidError="收款人不能为空"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></asp:Label>&nbsp;
                                                        
                                                    </td>

                                                    <td class="dvtCellLabel">要求日期:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_YTime" runat="server" ></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">申请人:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_DutyPerson"  runat="server" Width="100px"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">申请部门:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_Depart"  runat="server" Width="100px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">省:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_Shen" runat="server"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">市:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_Shi" runat="server"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">开户行:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_BankName"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';" ></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">账号:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_BankAccount"  OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ></asp:Label>&nbsp;

                                                    </td>
                                                </tr>
                                                
                                        <tr >
                                            <td align="right" class="dvtCellLabel">请选择图片:
                                            </td>
                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                <asp:Image ID="Image1" runat="server" Width="95px" Height="75px" />
                                                </td>
                                            </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader"><b>附加信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">附加信息:</td>
                                                    <td class="dvtCellInfo" colspan="4">
                                                        <asp:Label ID="Tbx_Remarks" runat="server" ></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">备注:</td>
                                                    <td class="dvtCellInfo" colspan="4">
                                                        <asp:Label ID="Tbx_Details" runat="server" ></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                    <tr runat="server" id="Tr_Sp">
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">审批信息：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <pc:PTextBox runat="server" ID="Tbx_SpText" TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="280px" Height="50px"></pc:PTextBox>
                                                        </td>
                                                    </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader"><b>付款单信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                              <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                PageSize="10" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="付款单号" SortExpression="CAA_Code" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="/Web/Pay/Cw_Accounting_Pay_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAA_ID") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "CAA_Code").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="付款金额" DataField="CAA_PayMoney" SortExpression="CAA_PayMoney"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="付款日期" DataField="CAA_Paytime" SortExpression="CAA_Paytime"
                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="账户" SortExpression="CAA_Account" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetBankName(DataBinder.Eval(Container.DataItem, "CAA_Account").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户/供应商" SortExpression="CAA_CustomerValue" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "CAA_CustomerValue").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="摘要" DataField="CAA_Details" SortExpression="CAA_Details"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="负责人" SortExpression="CAA_DutyPerson" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "CAA_DutyPerson").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="创建日期" DataField="CAA_CTime" SortExpression="CAA_CTime"
                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass='colHeader' />
                                <RowStyle CssClass='listTableRow' />
                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
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

