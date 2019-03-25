<%@ Page Language="C#" EnableEventValidation="false" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="Select_Sales_OutWareList_AddDetails.aspx.cs" Inherits="Knet_Common_Select_Sales_OutWareList_AddDetails" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
    </script>

    <title>选择发货单产品明细</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="3">
                </td>
            </tr>
        </table>
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="150" background="../images/ktxt1.gif" style="background-color: #F5F5F5;
                    height: 28px; width: 130px; padding-left: 20px;">
                    <div class="TP2">
                        选择发货明细</div>
                </td>
                <td background="../images/ktxt2.gif">
                    &nbsp;<font color="blue">提示:</font><font color="#999999">点击左边<img src="../images/up.jpg"
                        width="20" height="20" />
                        可把发货单往上收缩方便查看明细，点
                        <img src="../images/down.jpg" width="20" height="20" />可把发货单向下展开...</font>&nbsp;</td>
                <td background="../images/ktxt2.gif">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="3">
                </td>
            </tr>
        </table>
        
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
            <tr>
                <td valign="top">
                    <%--发添加的采购单--%>
                    <table width="99%" border="0" align="center" cellpadding="1" cellspacing="1">
                        <tr>
                            <td width="17%" height="25" align="right" class="tableBotcss">
                                <asp:ImageButton ID="ImageButton_down" runat="server" ImageUrl="../images/down.jpg"
                                    Visible="false" CausesValidation="false" OnClick="ImageButton_down_Click" /><asp:ImageButton
                                        ID="ImageButton_up" runat="server" ImageUrl="../images/up.jpg" OnClick="ImageButton_up_Click"
                                        CausesValidation="false" />&nbsp;发货编号:</td>
                            <td width="36%" align="left" class="tableBotcss">
                                <asp:Label ID="OutWareNo" runat="server"></asp:Label>&nbsp;</td>
                            <td width="14%" align="right" class="tableBotcss">
                                发货主题:</td>
                            <td width="33%" align="left" class="tableBotcss">
                                <asp:Label ID="OutWareTopic" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr id="AShow" runat="server">
                            <td width="17%" height="25" align="right" class="tableBotcss">
                                发货日期:</td>
                            <td align="left" class="tableBotcss">
                                <asp:Label ID="OutWareDateTime" runat="server"></asp:Label>&nbsp;</td>
                            <td align="right" class="tableBotcss">
                                原合同编号:</td>
                            <td align="left" class="tableBotcss">
                                <asp:Label ID="ContractNo" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr id="BShow" runat="server">
                            <td width="17%" height="25" align="right" class="tableBotcss">
                                关联客户:</td>
                            <td width="36%" align="left" class="tableBotcss">
                                <asp:Label ID="CustomerValue" runat="server"></asp:Label>&nbsp;</td>
                            <td width="14%" align="right" class="tableBotcss">
                                运输分担:</td>
                            <td width="33%" align="left" class="tableBotcss">
                                <asp:Label ID="ContractTranShare" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr id="CShow" runat="server">
                            <td width="17%" height="25" align="right" class="tableBotcss">
                                发货联系人:</td>
                            <td width="36%" align="left" class="tableBotcss">
                                <asp:Label ID="OutWareOursContact" runat="server"></asp:Label>&nbsp;</td>
                            <td width="14%" align="right" class="tableBotcss">
                                收货联系人:</td>
                            <td width="33%" align="left" class="tableBotcss">
                                <asp:Label ID="OutWareSideContact" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr id="DShow" runat="server">
                            <td width="17%" height="25" align="right" class="tableBotcss">
                                交货地点:</td>
                            <td width="36%" align="left" class="tableBotcss">
                                <asp:Label ID="ContractToAddress" runat="server"></asp:Label>&nbsp;</td>
                            <td width="14%" align="right" class="tableBotcss">
                                交货方式:</td>
                            <td width="33%" align="left" class="tableBotcss">
                                <asp:Label ID="ContractDeliveMethods" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr id="HShow" runat="server">
                            <td width="17%" height="25" align="right" class="tableBotcss">
                                公司:</td>
                            <td align="left" class="tableBotcss">
                                <asp:Label ID="OutWareStaffBranch" runat="server"></asp:Label>&nbsp;</td>
                            <td align="right" class="tableBotcss">
                                部门:</td>
                            <td align="left" class="tableBotcss">
                                <asp:Label ID="OutWareStaffDepart" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr id="IShow" runat="server">
                            <td height="32" align="right" class="tableBotcss">
                                经办(发货)人:</td>
                            <td align="left" class="tableBotcss">
                                <asp:Label ID="OutWareStaffNo" runat="server"></asp:Label>&nbsp;</td>
                            <td align="right" class="tableBotcss">
                                审核人:</td>
                            <td align="left" class="tableBotcss">
                                <asp:Label ID="OutWareCheckStaffNo" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                        <tr id="JShow" runat="server">
                            <td height="25" align="right">
                                备注说明:</td>
                            <td colspan="3" align="left" valign="top">
                                <asp:Label ID="OutWareRemarks" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                    </table>
                    <%--发添加的采购单结束--%>
                </td>
            </tr>
        </table>
        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="3">
                </td>
            </tr>
        </table>
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
            <tr>
                <td valign="top">
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=Blue><br/><br/><B>暂时没有明细记录，或已发货完成.</B><br/><br/></font></div>"
                        GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                        ShowHeader="true" HeaderStyle-Height="25px" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_DataRowBinding">
                        <Columns>
                            <asp:BoundField HeaderText="序" ItemStyle-Height="25px" ItemStyle-Width="25px" HeaderStyle-Font-Size="12px"
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="left">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="选" Font-Size="12px" AutoPostBack="true"
                                        OnCheckedChanged="CheckBox1_CheckedChanged" Height="20px" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chbk" runat="server" /><a href="#" onclick="javascript:window.open('../KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image
                                        ID="Image1" runat="server" ImageUrl="../images/Deitail.gif" ToolTip="查看产品详细信息" /></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName"
                                ReadOnly="true">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductsBarCode" HeaderText="编号(条码)" SortExpression="ProductsBarCode"
                                ReadOnly="true">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductsPattern" HeaderText="产品型号" SortExpression="ProductsPattern"
                                ReadOnly="true">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="100px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="OutWareAmount" HeaderText="发货数量" ItemStyle-ForeColor="blue"
                                SortExpression="OutWareAmount" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="60px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="退货数量" SortExpression="thisNowAmount" HeaderStyle-Font-Size="12px"
                                HeaderStyle-ForeColor="blue" ItemStyle-Width="60px" ControlStyle-Width="60px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:TextBox ID="OrderAmounttxt" runat="server" CssClass="Boxx" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem,"thisNowAmount")%>'></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="JoinNumbera" runat="server" ErrorMessage="正整数!" ControlToValidate="OrderAmounttxt"
                                        Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="正整数!"
                                        ControlToValidate="OrderAmounttxt" ValidationExpression="^\+?[1-9][0-9]*$" Display="Dynamic"
                                        ValidationGroup="88"></asp:RegularExpressionValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="超过数量!"
                                        ValueToCompare='<%# DataBinder.Eval(Container.DataItem,"thisNowAmount") %>' Type="Integer"
                                        Operator="LessThanEqual" ControlToValidate="OrderAmounttxt" Display="Dynamic"></asp:CompareValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="OutWareReceiving" HeaderText="已退货" ItemStyle-ForeColor="blue"
                                SortExpression="OutWareReceiving" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="50px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OutWare_SalesUnitPrice" ReadOnly="true" ItemStyle-Font-Size="12px"
                                SortExpression="OutWare_SalesUnitPrice" HeaderText="销售单价" ItemStyle-Width="60px"
                                HeaderStyle-Font-Size="12px" DataFormatString="{0:N}" HtmlEncode="false">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="LightSteelBlue" />
                        <HeaderStyle BackColor="LightSteelBlue" />
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <PagerStyle HorizontalAlign="Left" />
                    </asp:GridView>
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="WhiteSmoke"
                        style="border-top: 1px solid #A3B2CC;">
                        <tr>
                            <td width="20%" height="25" align="left">
                                &nbsp;<asp:Label ID="DoDinfion" runat="server" Text=""></asp:Label></td>
                            <td width="80%" align="right">
                                <asp:Label ID="HeXinQ" runat="server" Font-Size="13px"></asp:Label>&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <!--分页-->
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                        <tr>
                            <td height="24" bgcolor="#F2F4F9">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="left" OnPageChanged="AspNetPager1_PageChanged"
                                    ShowCustomInfoSection="Left" Width="100%" meta:resourceKey="AspNetPager1" Style="font-size: 13px"
                                    PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
                                    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%"
                                    ShowNavigationToolTip="True" CustomInfoStyle="font-size:13px;padding-top:5px;width:280px;"
                                    TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"
                                    CustomInfoTextAlign="left" ShowPageIndexBox="Always" AlwaysShow="True" FirstPageText="【首页】"
                                    LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                    <!--分页-->
                    <!--底部功能栏-->
                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                        <tr>
                            <td height="30" width="58%">
                                &nbsp;<asp:Button ID="Button2" runat="server" CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                                <asp:Button ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click" />&nbsp;&nbsp;<input
                                    name="button2" type="button" value="关闭窗口" class="Btt" onclick="closeWindow();"></td>
                            <td width="42%" align="right">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <!--底部功能栏-->
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
