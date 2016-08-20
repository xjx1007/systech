<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectBaoPriceList.aspx.cs" Inherits="Knet_Common_SelectBaoPriceListSelectBaoPriceListtoselects" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<base target="_self" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script>

<title>选择报价</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
        
<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">选择报价单</div></td>
    <td width="250" align="left"  background="../../images/ktxt2.gif" >&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="Boxx"></asp:TextBox></td>
    <td  align="left" background="../../images/ktxt2.gif">&nbsp;<asp:Button ID="Button1zzz" runat="server" Text="报价单检索" CssClass="Btt" OnClick="Button4_Click" /></td>
  </tr>
</table>


<div id="ssdd" style="padding: 2px"></div>
            
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
                <tr>
                    <td>
                        <!--GridView-->
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                            GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                            ShowHeader="true" HeaderStyle-Height="25px" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_DataRowBinding">
                            <Columns>
                                <asp:BoundField HeaderText="序" ItemStyle-Height="25px" ItemStyle-Width="25px" HeaderStyle-Font-Size="12px"
                                    HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px"
                                    ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" /><a href="#" onclick="javascript:window.open('/web/Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=750,height=450');"><asp:Image
                                            ID="Image1" runat="server" ImageUrl="../../images/Deitail.gif" ToolTip="查看详细信息" /></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BaoPriceTopic" HeaderText="报价主题" SortExpression="BaoPriceTopic">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="报价编号" DataField="BaoPriceNo" ItemStyle-Width="115px"
                                    SortExpression="BaoPriceNo">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="报价日期" DataField="BaoPriceDateTime" ItemStyle-Width="80px"
                                    SortExpression="BaoPriceDateTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="客户名称" SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"
                                    ItemStyle-Width="180px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                   <a href="#" onclick="javascript:window.open('/Web/Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><%# GetCustomerValueName(DataBinder.Eval(Container.DataItem, "CustomerValue"))%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="公司" SortExpression="BaoPriceStaffBranch" HeaderStyle-Font-Size="12px"
                                    ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# GetStrucNameNane(DataBinder.Eval(Container.DataItem, "BaoPriceStaffBranch"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态" SortExpression="BaoPriceCheckYN" HeaderStyle-Font-Size="12px"
                                    ItemStyle-Width="30px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <%# GetBaoPriceCheckYN(DataBinder.Eval(Container.DataItem, "BaoPriceNo"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                                        ShowCustomInfoSection="Left" Width="100%" meta:resourceKey="AspNetPager1" Style="font-size: 13px"
                                        PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
                                        CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%"
                                        ShowNavigationToolTip="True" CustomInfoStyle="font-size:13px;padding-top:0px;width:250px;"
                                        TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"
                                        CustomInfoTextAlign="left" ShowPageIndexBox="Never" AlwaysShow="True" FirstPageText="【首页】"
                                        LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                        <!--分页-->
                        <!--底部功能栏-->
<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
  <tr>
   <td width="76%" height="30">&nbsp;<asp:Button ID="Button2" runat="server" CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  /><asp:Button ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click" />&nbsp;&nbsp;<input name="button2" type="button" value="关闭窗口" class="Btt" onclick="closeWindow();">&nbsp;</td>
    <td width="24%" align="right"><asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">请选择状态</asp:ListItem>
                                        <asp:ListItem Value="1">只显示已审核</asp:ListItem>
                                        <asp:ListItem Value="0">只显示未审核</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                        <!--底部功能栏-->
                    </td>
                </tr>
            </table>
            <!--内部结束-->
        </div>
    </form>
</body>
</html>
