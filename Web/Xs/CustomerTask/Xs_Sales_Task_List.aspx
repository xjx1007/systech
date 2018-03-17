<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Task_List.aspx.cs" Inherits="Web_Sales_Xs_Sales_Task_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<title></title>
</head>
<script type="text/javascript" src="/Web/js/ajax_func.js"></script>
<script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
	<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
	<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
	<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
	<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>	
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>客户任务计划  >
	<a class="hdrLink" href="Xs_Sales_Task_List.aspx">客户任务计划 </a>
        </td>
	<td width=100% nowrap>
		<table border="0" cellspacing="0" cellpadding="0" >
		<tr>
		<td class="sep1" style="width:1px;"></td>
		<td class="small" >
			<!-- Add and Search -->
			<table border=0 cellspacing=0 cellpadding=0>
			<tr>
			<td>
				<table border=0 cellspacing=0 cellpadding=5>
				<tr>
				<td style="padding-right:0px;padding-left:10px;"><a href="javascript:;"  onclick="PageGo('Xs_Sales_Task_Add.aspx')"><img src="/themes/softed/images/btnL3Add.gif" alt="创建 客户任务计划 ..." title="创建 客户任务计划 ..." border=0></a></td>
				<td style="padding-right:0px;"><a href="javascript:;"  onclick="PageGo('')"><img src="/themes/softed/images/btnL3Delete.gif" alt="删除 客户任务计划 ..." title="删除 客户任务计划 ..." border=0></a></td>
				<td style="padding-right:10px"><a href="javascript:;" onClick="ShowDiv()" ><img src="/themes/softed/images/btnL3Search.gif" alt="查找 客户任务计划 ..." title="查找 客户任务计划 ..." border=0></a></td>
				<td style="padding-right:0px;padding-left:10px;"><img src="/themes/softed/images/tbarImport.gif" alt="*导入 客户任务计划 " title="*导入 客户任务计划 " border="0"></td>	
				<td style="padding-right:10px"><img src="/themes/softed/images/tbarExport.gif" alt="*导出 客户任务计划 " title="*导出 客户任务计划 " border="0"></td>
				</tr>
				</table>
			</td>
			</tr>
			</table>
		</td>
		</tr>
		</table>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
<tr>
 <td>
    <%=base.Base_BindView("Xs_Sales_Task", "Xs_Sales_Task_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
</td>
</tr>
  <tr>
    <td>
        
<table border=0 cellspacing=0 cellpadding=2 width=100% class="small">
 <tr>
				<!-- Buttons -->
				<td style="padding-right:20px" align="left" nowrap>				
				查看范围:<asp:DropDownList runat="server" ID="Ddl_Batch" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged"></asp:DropDownList>
				<a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');" onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a> <img border="0" src="/themes/images/collapse.gif">
				<div id="selectoperate" class="drop_mnu" onMouseOut="fnHideDrop('selectoperate')" onMouseOver="fnShowDrop('selectoperate')" >
				<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr><td>
							<a href="#" class="drop_down">修改负责人</a>
							</td></tr>
							<tr><td>
							<a href="#" class="drop_down">共享</a>
							</td></tr>
							<tr><td>
							<asp:LinkButton runat="server" ID="lbtn_Del" class="drop_down" OnClick="Btn_Del_Click" >批量删除</asp:LinkButton>
							</td></tr>
							<tr><td><a href="#"  class="drop_down">批量发短信</a></td></tr>
                    <tr><td>
						<a href="#"  class="drop_down">批量发邮件</a>
					</td></tr>
									</table>
				</div>
				</td>
				</tr>
  <tr>
    <td >
    
    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true"   EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关客户记录</B><br/><br/></font></div>" 
            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
<Columns>

        <asp:TemplateField>
                <HeaderTemplate> 
                 <input type="CheckBox" onclick="selectAll(this)">
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server" />
                 </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle Height="25px" HorizontalAlign="Left" />
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="主题"  SortExpression="XST_Topic" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <a href="Xs_Sales_Task_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XST_ID") %>"><%# DataBinder.Eval(Container.DataItem, "XST_Topic").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
      <asp:TemplateField HeaderText="负责人"  SortExpression="XST_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XST_DutyPerson").ToString())%>
          </ItemTemplate>
     </asp:TemplateField>
        
      <asp:TemplateField HeaderText="状态"  SortExpression="XST_State" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("119", DataBinder.Eval(Container.DataItem, "XST_State").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="认领"  SortExpression="XST_Claim" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("120", DataBinder.Eval(Container.DataItem, "XST_Claim").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  HeaderText="开始日期"  DataField="XST_Begintime"  SortExpression="XST_Begintime" DataFormatString="{0:yyyy-MM-dd}"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="结束日期"  DataField="XST_Endtime"  SortExpression="XST_Endtime" DataFormatString="{0:yyyy-MM-dd}"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
      <asp:TemplateField HeaderText="执行人"  SortExpression="XST_Executor" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserNames(DataBinder.Eval(Container.DataItem, "XST_Executor").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="创建人"  SortExpression="XST_Creator" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XST_Creator").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="center" >
            <ItemTemplate>
                <a href="Xs_Sales_Task_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XST_ID") %>"><asp:Image ID="Image1" runat="server"  ImageUrl="/images/Edit.gif" border=0  ToolTip="修改" /></a>
           </ItemTemplate>
        </asp:TemplateField>
</Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
</cc1:MyGridView>
    </td>
</tr>
</table>
<!--分页-->
<!--底部功能栏-->

    </td>
  </tr>
</table>
    </form>
</body>
</html>