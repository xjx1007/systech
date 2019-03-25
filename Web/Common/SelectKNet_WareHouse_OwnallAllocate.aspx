<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectKNet_WareHouse_OwnallAllocate.aspx.cs" Inherits="Knet_Common_SelectSelectKNet_WareHouse_OwnallAllocate" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
    </script>
    <title>选择仓库产品</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <!--头部-->
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="150" background="../../images/ktxt1.gif" style="background-color: #F5F5F5; height: 28px; width: 130px; padding-left: 20px;">
                        <div class="TP2">选择仓库产品</div>
                    </td>
                    <td align="left" background="../../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;">&nbsp;&nbsp;<font color="blue">提示:</font><font color="#999999">选择产品后，点确定添加到明细中.</font></td>
                    <td width="10" background="../../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;" align="left"></td>
                </tr>
            </table>
            <div id="ssdd" style="padding: 3px"></div>
            <!--头部-->






            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
                <tr>
                    <td>
                        <!--GridView-->
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>所选仓库  没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px"
                            OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_DataRowBinding">
                            <Columns>


                                <asp:BoundField HeaderText="序" ItemStyle-Height="25px" ItemStyle-Width="25px" HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>


                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="选" Font-Size="12px" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" Height="20px" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" /><a href="#" onclick="javascript:window.open('../KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image1" runat="server" ImageUrl="../../images/Deitail.gif" ToolTip="查看产品详细信息" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-Width="90px" SortExpression="HouseNo" HeaderText="仓库名称" ItemStyle-Height="25px" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <%# GetHouseName(Eval("HouseNo")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsBarCode" HeaderText="编号(条码)" SortExpression="ProductsBarCode">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="110px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsPattern" HeaderText="产品型号" SortExpression="ProductsPattern">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="100px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="出库数量" SortExpression="WareHouseAmount" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue" ItemStyle-Width="60px" ControlStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="OrderAmounttxt" runat="server" CssClass="Boxx" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem,"WareHouseAmount")%>'></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="JoinNumbera" runat="server" ErrorMessage="正整数!" ControlToValidate="OrderAmounttxt" Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="正整数!" ControlToValidate="OrderAmounttxt" ValidationExpression="^\+?[1-9][0-9]*$" Display="Dynamic" ValidationGroup="88"></asp:RegularExpressionValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="超过数量!" ValueToCompare='<%# DataBinder.Eval(Container.DataItem,"WareHouseAmount") %>' Type="Integer" Operator="LessThanEqual" ControlToValidate="OrderAmounttxt" Display="Dynamic"></asp:CompareValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="WareHouseAmount" HeaderText="库存量" SortExpression="WareHouseAmount">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="50px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="入库日期" DataField="StorageTime" ItemStyle-Width="70px" SortExpression="StorageTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="StorageVolume" HeaderText="入库数量" SortExpression="StorageVolume">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="60px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>


                                <%--        <asp:BoundField  DataField="WareHouseAmount"   HeaderText="库存量"  SortExpression="WareHouseAmount" >
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="50px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
       </asp:BoundField>

       <asp:BoundField  DataField="WareHouseTotalNet"  ItemStyle-Font-Size="12px"  SortExpression="WareHouseTotalNet"  HeaderText="库存净值" ItemStyle-Width="70px"   HeaderStyle-Font-Size="12px"  DataFormatString="{0:N}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 

        
        <asp:BoundField  DataField="WareHouseDiscount" ReadOnly="true" ItemStyle-Font-Size="12px"  SortExpression="WareHouseDiscount"  HeaderText="库存计调" ItemStyle-Width="70px"   HeaderStyle-Font-Size="12px"  DataFormatString="{0:N}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> --%>
                            </Columns>

                            <FooterStyle BackColor="LightSteelBlue" />
                            <HeaderStyle BackColor="LightSteelBlue" />
                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                            <PagerStyle HorizontalAlign="Left" />
                        </asp:GridView>
                        <!--GridView-->
                        <!--分页-->
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                            <tr>
                                <td height="28" bgcolor="#F2F4F9">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="left" OnPageChanged="AspNetPager1_PageChanged"
                                        ShowCustomInfoSection="Left" Width="100%" meta:resourceKey="AspNetPager1" Style="font-size: 13px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
                                        CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%"
                                        ShowNavigationToolTip="True" CustomInfoStyle="font-size:13px;padding-top:0px;width:250px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)" CustomInfoTextAlign="left" ShowPageIndexBox="Never" AlwaysShow="True"
                                        FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                        <!--分页-->

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                            <tr>
                                <td height="25" width="40%">
                                    <asp:Button ID="Button2" runat="server" CssClass="Btt" Text="确定选择" OnClick="Button2_Click" />
                                    <asp:Button ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button3_Click" />&nbsp;<asp:Button
                                        ID="Button4" runat="server" Text="完成选择" CssClass="Btt" OnClick="Button4_Click" />&nbsp;<input name="button2" type="button" value="关闭窗口" class="Btt" onclick="closeWindow();"></td>
                                <td width="60%" align="right"><b>库存产品搜索</b>&nbsp;&nbsp;关健词:<asp:TextBox ID="KNetSeachKey" runat="server" Width="150px" CssClass="Boxx"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="确定搜索" CssClass="Btt" OnClick="Button1_Click" Style="width: 55px; height: 33px;" /></td>
                            </tr>
                        </table>
                        <!--底部功能栏-->






                        <asp:GridView ID="GridView2" runat="server" GridLines="None" Width="100%" ItemStyle-Height="25px" HorizontalAlign="center" AutoGenerateColumns="false">
                            <Columns>


                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <img src="../../images/Au1.gif" width="14" height="15" border="0" />
                                    </ItemTemplate>

                                </asp:TemplateField>


                                <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsBarCode" HeaderText="编号(条码)" SortExpression="ProductsBarCode" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="120px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ProductsPattern" HeaderText="产品型号" SortExpression="ProductsPattern" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="数量" SortExpression="AllocateAmount" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">

                                    <ItemTemplate>
                                        <asp:Label ID="Labddfgdel1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"AllocateAmount")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>



                            </Columns>


                            <FooterStyle BackColor="LightSteelBlue" />
                            <HeaderStyle BackColor="LightSteelBlue" />
                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                            <PagerStyle HorizontalAlign="Left" />



                        </asp:GridView>




                    </td>
                </tr>
            </table>
            <!--内部结束-->


        </div>
    </form>
</body>
</html>
