<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectDocument.aspx.cs" Inherits="Knet_Common_SelectDocument" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
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

function set_return(Return_id, Return_name) {

        if(window.opener != undefined)
        {
            window.opener.returnValue=Return_id+"#"+Return_name;
        }
        else{
            window.returnValue=Return_id+"#"+Return_name;
        }
       
}
</script>
<style type="text/css">
.Div11
{
  background-image:url(../../images/midbottonA2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../../images/midbottonB2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>
<title>选择客户</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div class="TitleBar">选择文档</div>

<div id="ssdd" style="padding:2px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
<tr>
<td>
关键字：<asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="Boxx"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" CssClass="Btt" OnClick="Button1_Click1" />
</td>
</tr>
  <tr>
    <td>
<!--GridView-->
        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>
        
        <asp:TemplateField HeaderText="文档名称" HeaderStyle-Font-Size="12px"  ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                    <%# GetLink(DataBinder.Eval(Container.DataItem, "PBM_Code").ToString(), DataBinder.Eval(Container.DataItem, "PBM_Name").ToString(), DataBinder.Eval(Container.DataItem, "PBM_Visio").ToString())%>
                 </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="文档类型"  SortExpression="PBM_Type" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <%# base.Base_GetBasicCodeName("111",DataBinder.Eval(Container.DataItem, "PBM_Type").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField   HeaderText="版本号"  DataField="PBM_Visio"  SortExpression="PBM_Visio"   HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left"  />
            <HeaderStyle  HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:TemplateField HeaderText="负责人"  SortExpression="PBM_DutyPerson"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
             <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "PBM_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField    HeaderText="发布时间"   DataField="PBM_CTime"  HeaderStyle-Font-Size="12px"   SortExpression="PBM_CTime">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        </Columns>
         
            <HeaderStyle CssClass='Custom_DgHead' />
            <RowStyle CssClass='Custom_DgItem' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
<!--GridView-->  
<!--分页-->

<!--底部功能栏-->

    </td>
  </tr>
</table>
<!--内部结束-->


    </form>
</body>
</html>
