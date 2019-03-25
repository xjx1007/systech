<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectClientProductsList.aspx.cs" Inherits="Knet_Common_SelectClientProductsList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<base target="_self" />
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<script type="text/javascript" src="../Js/ajax_func.js"></script>
<script type="text/javascript" src="../Js/Global.js"></script>
<script>
    function changsheng(va)
    {
    if(va!='0')
        {
        var city = document.getElementById("city");
            city.disabled=false;
            var url="../Js/Handler.ashx?type=sheng&id="+va;
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
</style>
<title>选择关联产品</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>


    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                产品 > <a class="hdrLink" href="SelectClientProductsList.aspx">选择产品</a>
            </td>
            <td width="100%" nowrap>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
    
        <table border="0" cellspacing="1" cellpadding="0" width="100%" class="lvtBg">
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td width="75%" align="left" colspan="2">
                                关键词:<asp:TextBox ID="SeachKey" runat="server" Width="300px" CssClass="detailedViewTextBox"></asp:TextBox>&nbsp;<asp:Button  ID="Button1" runat="server" Text="产品筛选"  CssClass="crmbutton small create" OnClick="Button1_Click1" />
                            </td>
                        </tr>
                        <tr>
                        
            <td width="14%" valign="top">
                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                    <tr>
                        <td class="dvtTabCache" style="width: 10px" nowrap>
                            &nbsp;
                        </td>
                        <td id="catalog_tab" class="dvtSelectedCell" align="center" nowrap>
                            <a href="javascript:showProductCatalog()">产品分类</a>
                        </td>
                        <td class="dvtTabCache" style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" 
                                NodeIndent="15" onselectednodechanged="TreeView1_SelectedNodeChanged">
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                                    HorizontalPadding="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
            </td>
    <td width="85%" align="left" valign="top" style="border-left: 2px dashed #cccccc;">
                      
                            
        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
         >
        <Columns>
        
       <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <HeaderTemplate >
                    <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server"/>
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  /><a href="#"  onclick="javascript:window.open('../System/KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Deitail.gif"  ToolTip="查看产品详细信息" /></a>
                 </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="ProductsBarCode"  HeaderText="编码"  SortExpression="ProductsName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProductsName"  HeaderText="产品名称"  SortExpression="ProductsName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        <asp:TemplateField HeaderText="大类名称"  SortExpression="ProductsType" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsType(DataBinder.Eval(Container.DataItem, "ProductsType").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField  DataField="ProductsPattern"   HeaderText="产品型号"  SortExpression="ProductsPattern">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:TemplateField HeaderText="单位"  SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"  ItemStyle-Width="50px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
            <asp:Label ID="Lbl_Unit" runat="server"  Width="70px" Text=<%# base.Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%> ></asp:Label>
               </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField  DataField="ProductsEdition"   HeaderText="版本"  SortExpression="ProductsEdition">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
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
<!--分页-->

<!--底部功能栏-->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="25" width="35%"><asp:Button ID="Button2" runat="server"   CssClass="crmbutton small save" Text="确定选择" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
    <asp:Button  ID="Button3" runat="server" Text="取消选择" class="crmbutton small cancel" OnClick="Button2_Click"  style="width: 55px;height: 33px;"  />&nbsp;</td>
     
  </tr>
</table>
<!--底部功能栏-->

<!--内部结束-->


    </div>
    </form>
</body>
</html>
