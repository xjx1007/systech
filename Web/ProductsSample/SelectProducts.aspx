<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectProducts.aspx.cs" Inherits="Knet_Common_SelectProducts" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<base target="_self" />
<script type="text/javascript" src="../Js/ajax_func.js"></script>
<script>
    function changsheng(va)
    {
    if(va!='0')
        {
        var SmallClass = document.getElementById("SmallClass");
            SmallClass.disabled=false;
            var url="../Web/Js/ProductClassHandler.ashx?type=BigClass&BigNo="+va;
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

function GetReturn(Value1, Value2) {

    if (window.opener != undefined) {
        window.opener.returnValue = Value1 + "|" + Value2 ;
    }
    else {
        window.returnValue = Value1 + "|" + Value2 ;
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

<title>选择产品</title>
</head>
<body >
    <form id="form1" runat="server">
    <div>
<!--头部-->
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                样品申请 > 选择产品
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<!--GridView-->
        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging=true  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          >
        <Columns>
        <asp:TemplateField HeaderText="产品名称"  SortExpression="ProductsName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center" >
          <ItemTemplate>
               <%# GetReturn(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField  DataField="ProductsBarCode"   HeaderText="编号(条码)"  SortExpression="ProductsBarCode">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProductsPattern"   HeaderText="产品型号"  SortExpression="ProductsPattern">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProductsEdition"   HeaderText="版本号"  SortExpression="ProductsPattern">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="大类名称"  SortExpression="ProductsMainCategory" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetBigCateNane(DataBinder.Eval(Container.DataItem, "ProductsMainCategory").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="单位"  SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  DataField="ProductsCostPrice" ItemStyle-Font-Size="12px"   ItemStyle-ForeColor="blue"  HeaderText="厂家参考成本" ItemStyle-Width="80px"   HeaderStyle-Font-Size="12px"   SortExpression="ProductsCostPrice" DataFormatString="{0:c}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
        
             <asp:BoundField  DataField="ProductsSellingPrice" ItemStyle-Font-Size="12px" ItemStyle-ForeColor="blue"   HeaderText="厂家建议售价" ItemStyle-Width="80px"   HeaderStyle-Font-Size="12px"   SortExpression="ProductsSellingPrice" DataFormatString="{0:c}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>    

        </Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td>
        &nbsp;</td>
      <td style="text-align: right"  >
      <asp:DropDownList runat="server" id="BigClass"></asp:DropDownList>
 <select id="SmallClass" runat="server" style="width: 140px" >
	<option value="0">--请选择小类--</option>
</select>关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="Boxx" Width="100px"></asp:TextBox>&nbsp;
<asp:Button  ID="Button1" runat="server" Text="产品筛选" CssClass="Btt" OnClick="Button1_Click1" />
</td>
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
