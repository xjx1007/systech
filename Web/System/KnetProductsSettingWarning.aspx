<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KnetProductsSettingWarning.aspx.cs" Inherits="Knet_Web_System_KnetProductsSettingWarning" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>

<style type="text/css">
.Div11
{
  background-image:url(../images/KbottonB.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/KbottonA.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>

</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">产品字典管理</div></td>
    <td width="550" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;日期从<asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>&nbsp;关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="120px"></asp:TextBox></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"><asp:Button ID="Button4" runat="server" Text="产品检索"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
</table>



<div id="Div1" style="padding:1px"></div>


<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="KnetProductsSetting.aspx"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px">产品列表</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="KnetProductsSetting_Add.aspx"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px">产品添加</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink5" runat="server"  NavigateUrl="KnetProductsSettingWarning.aspx"  CssClass="Div22" Width="78px" Height="21px" Font-Size="14px"  Font-Bold="true" ForeColor="MintCream">预警设置</asp:HyperLink></td>
        
                <td width="4" align="center"></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink4" runat="server"  NavigateUrl="KnetProductsSetting_end.aspx"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px">重复编码</asp:HyperLink></td>
        
        <td align="center">&nbsp;</td>
      </tr>
</table>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding" >
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate >
                 <asp:CheckBox ID="CheckBox1" runat="server" Text="选"  Font-Size="12px" AutoPostBack="true"   OnCheckedChanged="CheckBox1_CheckedChanged"  Height="20px" />
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  /><a href="#"  onclick="javascript:window.open('KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Deitail.gif"  ToolTip="查看产品详细信息" /></a>
                 </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:BoundField  DataField="ProductsName"  HeaderText="产品名称"  SortExpression="ProductsName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProductsBarCode"   HeaderText="编号(条码)"  SortExpression="ProductsBarCode">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="115px"/>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProductsPattern"   HeaderText="产品型号"  SortExpression="ProductsPattern">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="90px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="大类名称"  SortExpression="ProductsMainCategory" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetBigCateNane(DataBinder.Eval(Container.DataItem, "ProductsMainCategory"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="单位"  SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"  ItemStyle-Width="50px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  DataField="ProductsSellingPrice" ItemStyle-Font-Size="12px"   HeaderText="建议售价" ItemStyle-Width="70px"   HeaderStyle-Font-Size="12px"   SortExpression="ProductsSellingPrice" DataFormatString="{0:c}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
         <asp:BoundField  DataField="ProductsCostPrice" ItemStyle-Font-Size="12px"   HeaderText="参考成本" ItemStyle-Width="70px"   HeaderStyle-Font-Size="12px"   SortExpression="ProductsCostPrice" DataFormatString="{0:c}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
        
        
        <asp:BoundField   HeaderText="添加时间"  DataField="ProductsAddTime"  SortExpression="ProductsAddTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  Width="70px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        
      <asp:TemplateField HeaderText="预警数量"  HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="red" ItemStyle-Width="60px"   ControlStyle-Width="60px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
                <asp:TextBox ID="OrderAmounttxt" runat="server" CssClass="Boxx" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem,"ProductsStockAlert")%>'></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="JoinNumbera"  runat="server" ErrorMessage="整数!" ControlToValidate="OrderAmounttxt" Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="整数!" ControlToValidate="OrderAmounttxt" ValidationExpression="^\+?[0-9][0-9]*$" Display="Dynamic" ValidationGroup="88"></asp:RegularExpressionValidator>
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
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="28" bgcolor="#F2F4F9">
    <webdiyer:aspnetpager id="AspNetPager1" runat="server" horizontalalign="left" onpagechanged="AspNetPager1_PageChanged"
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:14px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:14px;padding-top:6px;width:300px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Always" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="14" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="70%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="设置所选项缺货预警" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click"/>&nbsp;提示:设置为 0 表示此产品不启用库存缺货预警.</td>
      <td width="30%" align="right" ><asp:DropDownList ID="ProductsMainCategoryDList" runat="server" OnSelectedIndexChanged="ProductsMainCategoryDList_SelectedIndexChanged" AutoPostBack="true">
          </asp:DropDownList></td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>
