<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectSalesClientList.aspx.cs" Inherits="Knet_Common_SelectSalesClientList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../css/knetwork.css" type="text/css">
<base target="_self" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<script>
    function changsheng(va)
    {
    if(va!="0")
        {
        var city = document.getElementById("city");
            city.disabled=false;
            var url="../../Js/Handler.ashx?type=sheng&id="+va;
            send_request("GET",url,null,"text",populateClass3);
        }
    }
function populateClass3(){
var f=document.getElementById("city");
if(http_request.readyState==4){
        if(http_request.status==200){
	        var list=http_request.responseText;
	        var classList=list.split("|");
	        f.options.length=1;
	        for(var i=0;i<classList.length;i++){
		        var tmp=classList[i].split(",");
		        f.add(new Option(tmp[1],tmp[0]));
	        }
        }else{
	        alert("您所请求的页面有异常。");
        }
}
}
</script>
<style type="text/css">
.Div11
{
  background-image:url(../images/midbottonA2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/midbottonB2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>
<title>选择客户</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<!--头部-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">选择客户</div></td>
    <td width="320" align="right"  background="../../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;客户搜索:<asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="Boxx"></asp:TextBox></td>
    <td background="../../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left">&nbsp;<asp:Button ID="Button1" runat="server" Text="搜索" CssClass="Btt" OnClick="Button1_Click1" /></td>
  </tr>
</table>
<div id="ssdd" style="padding:2px"></div>
<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div11" Width="90px" Height="21px" Font-Size="14px"  >保护客户</asp:HyperLink></td>
        <td width="4" align="center"></td>
        
        <td width="90" align="center"><asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div22" Width="90px" Height="21px" Font-Size="14px" Font-Bold="true" ForeColor="MintCream">普通客户</asp:HyperLink></td>
        <td width="4" align="center"></td>

        <td align="right">&nbsp;&nbsp;</td>
      </tr>
</table>
<!--头部-->
<%--内部开始--%>

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
        
        
        <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  /><a href="#"  onclick="javascript:window.open('../Sales/KNet_Sales_ClientList_Details.aspx?CustomerValue=<%# DataBinder.Eval(Container.DataItem, "CustomerValue")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=750,height=450');"><asp:Image ID="Image1" runat="server"  ImageUrl="../../../images/Deitail.gif"  ToolTip="查看详细信息" /></a>
                 </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:BoundField  DataField="CustomerName"  HeaderText="客户名称"  SortExpression="CustomerName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        
         <asp:TemplateField HeaderText="省份"  SortExpression="CustomerProvinces" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetClient_CustomerProvinces(DataBinder.Eval(Container.DataItem, "CustomerProvinces"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="渠道信息"  SortExpression="CustomerClass" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetClient_Name(DataBinder.Eval(Container.DataItem, "CustomerClass"))%>
          </ItemTemplate>
        </asp:TemplateField>
        
        
         <asp:BoundField    HeaderText="联系人"   DataField="CustomerContact" ItemStyle-Font-Size="12px" ItemStyle-Width="70px"   HeaderStyle-Font-Size="12px"   SortExpression="CustomerContact">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
         <asp:TemplateField HeaderText="责任人"  SortExpression="KSC_DutyPerson" HeaderStyle-Font-Size="12px"  ItemStyle-Width="90px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSC_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField   HeaderText="移动电话"  DataField="CustomerMobile" ItemStyle-Font-Size="12px"   ItemStyle-Width="90px"   HeaderStyle-Font-Size="12px"   SortExpression="CustomerMobile">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
        <asp:BoundField   HeaderText="固家电话"  DataField="CustomerTel" ItemStyle-Font-Size="12px"   ItemStyle-Width="90px"   HeaderStyle-Font-Size="12px"   SortExpression="CustomerTel">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
 
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
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:13px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:13px;padding-top:0px;width:250px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Never" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">
    </webdiyer:aspnetpager>
    </td>
</tr>
</table>
<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" width="54%">&nbsp;<asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" CssClass="Btt" OnClick="Button2_Click"/>&nbsp;&nbsp;<input   name="button2"   type="button"   value="关闭窗口"  class="Btt"  onclick="closeWindow();"></td>
      <td width="39%" align="right" ><select id="sheng" style="width:90px" runat="server" onchange="changsheng(this.value)"><option value="0">选择省份</option></select>&nbsp;<select id="city" runat="server" style="width:100px" ><option value="0">--选择城区--</option></select></td>
      <td width="7%" align="left" ><asp:Button ID="Button4" runat="server" Text="筛选" CssClass="Btt" OnClick="Button12_Click1" /></td>
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
