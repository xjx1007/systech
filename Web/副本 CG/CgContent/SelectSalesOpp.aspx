<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectSalesOpp.aspx.cs" Inherits="Knet_Common_SelectSalesOpp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">

<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
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

function set_return_Opp(Return_id, Return_name) {

        if(window.opener != undefined)
        {
            window.opener.returnValue=Return_id+"#"+Return_name;
        }
        else{
            window.returnValue=Return_id+"#"+Return_name;
        }
       
}
</script>
<title>选择客户</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                市场 > <a class="hdrLink" href="SelectSalesOpp.aspx">选择销售机会</a>
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
        
                    <table cellpadding="2" cellspacing="0" width="100%" align="center" class="searchUIAdv2 small"
                        border="0">
<tr>
<td>
销售机会搜索: 关键字：<asp:TextBox ID="SeachKey" runat="server" Width="200px"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" CssClass="Btt" OnClick="Button1_Click1" />
</td>
</tr>
  <tr>
    <td>
<!--GridView-->
        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>

        
        
        <asp:TemplateField HeaderText="销售机会名称" HeaderStyle-Font-Size="12px"  ItemStyle-Height="25px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                        <%# GetLink(DataBinder.Eval(Container.DataItem, "XSO_ID").ToString(), DataBinder.Eval(Container.DataItem, "XSO_Name").ToString())%>
                 </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="客户名称"  SortExpression="XSO_CustomerValue" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "XSO_CustomerValue").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="销售阶段"  SortExpression="XSO_SalesStep" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("118", DataBinder.Eval(Container.DataItem, "XSO_SalesStep").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  HeaderText="可能性"  DataField="XSO_Precent"  SortExpression="XSO_Precent" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:BoundField  HeaderText="预计成交日期"  DataField="XSO_PlanDealDate"  SortExpression="XSO_PlanDealDate" DataFormatString="{0:yyyy-MM-dd}"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
      <asp:TemplateField HeaderText="负责人"  SortExpression="XSO_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSO_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
 
        </Columns>
         
                                                <HeaderStyle CssClass='colHeader' />
                                                <RowStyle CssClass='listTableRow' />
                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>

    </td>
  </tr>
</table>


    </div>
    </form>
</body>
</html>
