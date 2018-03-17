<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContractListCheckYN.aspx.cs" Inherits="Knet_Web_Sales_pop_ContractListCheckYN" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>订单评审进展操作--审核</title>
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
    </script>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>

            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售管理 > <a class="hdrLink" href="ContractListCheckYN.aspx">订单评审审批</a>
                    </td>
                    <td width="100%" nowrap></td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>



            <%--内容开始--%>

            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                            <tr>
                                <td width="17%" height="25" align="right" class="dvtCellLabel">订单编号：</td>
                                <td width="36%" align="left" class="dvtCellInfo">
                                    <asp:Label ID="ContractNo" runat="server"></asp:Label></td>
                                <td align="right" class="dvtCellLabel">签订日期：</td>
                                <td align="left" class="dvtCellInfo">
                                    <asp:Label ID="ContractDateTime" runat="server"></asp:Label></td>
                            </tr>


                            <tr>
                                <td width="17%" height="25" align="right" class="dvtCellLabel">客户:</td>
                                <td align="left" class="dvtCellInfo">
                                    <asp:Label ID="CustomerName" runat="server"></asp:Label></td>
                                <td width="17%" height="25" align="right" class="dvtCellLabel">责任人:</td>
                                <td align="left" class="dvtCellInfo">
                                    <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label>
                                    <asp:Label ID="UsersNotxt" runat="server" Text="" Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td width="36%" height="30" align="right" class="dvtCellLabel">回复交货期：</td>
                                <td width="64%" class="dvtCellInfo">
                                    <asp:TextBox ID="Tbx_ReDate" runat="server" MaxLength="20" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_OldReDate" runat="server" MaxLength="20" CssClass="Custom_Hidden" onClick="WdatePicker()"></asp:TextBox>
                                    <asp:Label runat="server" ID="Lbl_Date"></asp:Label>
                                </td>

                                <td width="36%" height="30" align="right" class="dvtCellLabel">邮件提醒：</td>
                                <td width="64%" class="dvtCellInfo">
                                    <asp:CheckBox runat="server" ID="Chk_IsShow" Text="是" />
                                </td>
                            </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>合同信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">合同编号:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_FaterCode" runat="server"
                                                                Width="150px" Text=""></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">合同类型:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Type"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                            
                                                    <tr>
                                                        <td class="dvtCellLabel">订单原件:
                                                        </td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                            <tr>
                                <td width="36%" height="30" align="right" class="dvtCellLabel">备注：</td>
                                <td width="64%" class="dvtCellInfo" colspan="3">
                                    <asp:Label runat="server" ID="Lbl_Remarks"></asp:Label>&nbsp;
                                </td>

                            </tr>
                            <tr>
                                <td width="36%" height="30" align="right" class="dvtCellLabel">订单审核选择：</td>
                                <td width="64%" colspan="3" class="dvtCellInfo">&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="-1">请选择审核</asp:ListItem>
        <asp:ListItem Value="1">通过审核</asp:ListItem>
        <asp:ListItem Value="0">不通过审核</asp:ListItem>
        <asp:ListItem Value="3">异常通过</asp:ListItem>
        <asp:ListItem Value="2">订单作废</asp:ListItem>
    </asp:DropDownList>   &nbsp;   <font color="red">*</font>
                                </td>
                            </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>产品明细</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="ListDetails">
                                                                <%=s_MyTable_Detail %>
                                                            </table>
                                                        <asp:TextBox ID="i_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>

                                                        </td>
                                                    </tr>
                            <tr>
                                <td width="36%" height="30" align="right" class="dvtCellLabel">审核意见：</td>
                                <td width="64%" class="dvtCellInfo" colspan="3">
                                    <asp:TextBox runat="server" ID="Tbx_Remark" Text="" TextMode="MultiLine" Width="280px" Height="100px"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td height="30" colspan="4" align="center">&nbsp;<font color="gray"></font>
                                    <asp:Label ID="MyStatStr" runat="server" Text="" Visible="false" ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="30" colspan="4" align="center">&nbsp;
    <asp:Button ID="Button1" runat="server" Text="确定审核" class="crmbutton small save" OnClick="Button1_Click" Style="width: 70px; height: 33px;" />&nbsp;
                                    <input name="button2" type="button" value="关闭本窗口" class="crmbutton small cancel" onclick="closeWindow();" style="width: 70px; height: 33px;">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>



                        <table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">

                            <tr>
                                <td height="30" colspan="2" align="left">
                                    <asp:GridView ID="GridView1" runat="server" Width="99%" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                                        <Columns>
                                            <asp:TemplateField HeaderText="审核人" SortExpression="KSF_ShPerson" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSF_ShPerson").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="所在部门" SortExpression="StaffDepart" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "StaffDepart").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="职位" SortExpression="Position" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetBasicCodeName("105",DataBinder.Eval(Container.DataItem, "Position").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="审核时间" DataField="KSF_Date" ItemStyle-Width="70px" SortExpression="KSF_Date">
                                                <ItemStyle HorizontalAlign="center" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="center" Font-Size="12px" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="审核状态" SortExpression="KSF_State" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# GetFlowName(DataBinder.Eval(Container.DataItem, "KSF_State").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField HeaderText="审核意见" DataField="KSF_Detail" ItemStyle-Width="115px" SortExpression="KSF_Detail">
                                                <ItemStyle HorizontalAlign="center" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="center" Font-Size="12px" />
                                            </asp:BoundField>

                                            <asp:BoundField HeaderText="交货期" DataField="KFS_ReDate" ItemStyle-Width="115px" DataFormatString="{0:yyyy-MM-dd}" SortExpression="KFS_ReDate">
                                                <ItemStyle HorizontalAlign="center" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="center" Font-Size="12px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle CssClass='Custom_DgHead' />
                                        <RowStyle CssClass='Custom_DgItem' />
                                        <AlternatingRowStyle BackColor="#E3EAF2" />
                                        <PagerStyle CssClass='Custom_DgPage' />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>


                        <!--底部功能栏-->
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="30">&nbsp;</td>
                            </tr>
                        </table>
                        <!--底部功能栏-->

                    </td>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
