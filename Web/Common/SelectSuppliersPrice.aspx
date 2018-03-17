<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectSuppliersPrice.aspx.cs" Inherits="Knet_Common_SelectSuppliersPrice" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 

<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script>
    function changsheng(va)
    {
    if(va!='0')
        {
        var SmallClass = document.getElementById("SmallClass");
            SmallClass.disabled=false;
            var url="../Js/ProductClassHandler.ashx?type=BigClass&BigNo="+va;
            send_request("GET",url,null,"text",populateClass3);
        }
    }
function populateClass3(){
var f=document.getElementById("SmallClass");
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
	        alert("您所请求的页面有异常.");
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

<title>选择供应商采购报价</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
<!--头部-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">采购产品选择</div></td>
    <td align="left"  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;&nbsp;<font color="blue">提示:</font><font color="#999999">选择产品后，点确定添加到采购明细中，再修改其价格与数量.</font></td>
    <td width="10" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="left"></td>
  </tr>
</table>
<div id="ssdd" style="padding:3px"></div>
<!--头部-->


<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="90" align="center"><asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div11" Width="90px" Height="21px" Font-Size="14px"  Font-Bold="true" ForeColor="MintCream">供应商报价</asp:HyperLink></td>
        <td width="4" align="center"></td>
        
        <td width="90" align="center"><asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div22" Width="90px" Height="21px" Font-Size="14px" >产品字典库</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="right">&nbsp;<input   name="button2"   type="button"   value="关闭窗口"  class="Btt"  onclick="closeWindow();"></td>
      </tr>
</table>



<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <cc1:MyGridView ID="GridView1" AllowPaging="true" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
           >
        <Columns>
        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate>
                    <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server"/>
                  </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  /><a href="#"  onclick="javascript:window.open('../Procure/KNet_Procure_Suppliers_Details.aspx?SuppNoID=<%# DataBinder.Eval(Container.DataItem, "SuppNo")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=750,height=450');"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Deitail.gif"  ToolTip="查看供应商详细信息" /></a>
                 </ItemTemplate>
        </asp:TemplateField>
        

        <asp:TemplateField HeaderText="供应商名称"  SortExpression="SuppNo" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
            <%# base.Base_GetSupplierName(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>

       
        <asp:BoundField  DataField="ProductsName"  HeaderText="产品名称"  SortExpression="ProductsName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
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
               <%# base.Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="ProcureMinShu"   HeaderText="最少采购"  SortExpression="ProcureMinShu">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="60px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProcureUnitPrice" ItemStyle-Font-Size="12px"  ItemStyle-ForeColor="blue"  HeaderText="采购单价" ItemStyle-Width="80px"   HeaderStyle-Font-Size="12px"   SortExpression="ProcureUnitPrice" DataFormatString="{0:F3}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
         <asp:BoundField  DataField="HandPrice" ItemStyle-Font-Size="12px"  ItemStyle-ForeColor="blue"  HeaderText="加工费" ItemStyle-Width="80px"   HeaderStyle-Font-Size="12px"   SortExpression="HandPrice" DataFormatString="{0:F3}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
        
        
         <asp:TemplateField HeaderText="采购数量"   HeaderStyle-Font-Size="12px"  ItemStyle-Width="50px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
          <asp:TextBox ID="Tbx_Number" Width="60px" runat="server" CssClass="Boxx" value=<%# GetNumber(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) %>></asp:TextBox>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
         
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
<!--GridView-->  

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="25" width="25%"><asp:Button ID="Button2" runat="server"  CssClass="Btt" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
     <input id="Button3" type="button" class="Custom_Button" value="全 选" onclick="javascript:selectAllButton(this);"   style="width: 57px; height: 23px"/>&nbsp;
      <td width="75%" align="right" ><select id="BigClass" style="width:140px" runat="server"  onchange="changsheng(this.value)">
    <option value="0">--请选择大类--</option>
</select>
 <select id="SmallClass" runat="server" style="width: 140px" >
	<option value="0">--请选择小类--</option>
</select>关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="100px"></asp:TextBox>&nbsp;<asp:Button  ID="Button1" runat="server" Text="产品筛选" CssClass="Btt" OnClick="Button1_Click1" /></td>
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
