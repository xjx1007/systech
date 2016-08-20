<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_LinkMan_List.aspx.cs" Inherits="Web_Sales_KNet_Sales_LinkMan_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<title></title>
</head>
<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
	<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>	
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>联系人 >
	<a class="hdrLink" href="KNet_Sales_LinkMan_List.aspx">联系人</a>
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
				<td style="padding-right:0px;padding-left:10px;"><a href="javascript:;"  onclick="PageGo('KNet_Sales_LinkMan_Add.aspx')"><img src="../../themes/softed/images/btnL3Add.gif" alt="创建 联系人..." title="创建 联系人..." border=0></a></td>
				<td style="padding-right:0px;"><a href="javascript:;"  onclick="PageGo('KNet_Sales_ClientList_Delete.aspx')"><img src="../../themes/softed/images/btnL3Delete.gif" alt="删除 联系人..." title="删除 联系人..." border=0></a></td>
				<td style="padding-right:10px"><a href="javascript:;" onClick="ShowDiv()" ><img src="../../themes/softed/images/btnL3Search.gif" alt="查找 联系人..." title="查找 联系人..." border=0></a></td>
				<td style="padding-right:0px;padding-left:10px;"><img src="../../themes/softed/images/tbarImport.gif" alt="*导入 联系人" title="*导入 联系人" border="0"></td>	
				<td style="padding-right:10px"><img src="../../themes/softed/images/tbarExport.gif" alt="*导出 联系人" title="*导出 联系人" border="0"></td>
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
    <%=base.Base_BindView("XS_Compy_LinkMan", "KNet_Sales_LinkMan_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
</td>
</tr>
  <tr>
    <td>
        
<table border=0 cellspacing=0 cellpadding=2 width=100% class="small">
 <tr>
				<!-- Buttons -->
				<td style="padding-right:20px" align="left" nowrap>				
				查看范围:<asp:DropDownList runat="server" ID="Ddl_Batch" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged"></asp:DropDownList>
				<a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');" onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a> <img border="0" src="../../themes/images/collapse.gif">
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
    
    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true"
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
        
          
              <asp:TemplateField HeaderText="姓名"  SortExpression="XOL_Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <a href="KNet_Sales_LinkMan_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XOL_ID") %>"><%# DataBinder.Eval(Container.DataItem, "XOL_Name").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField  DataField="XOL_Code"  HeaderText="编码"  SortExpression="XOL_Code">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
      <asp:TemplateField HeaderText="客户名称"  SortExpression="XOL_Compy" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "XOL_Compy").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="Email"  DataField="XOL_Mail"  SortExpression="XOL_Mail" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="电话"  DataField="XOL_phone"  SortExpression="XOL_phone"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="家里电话"  DataField="XOL_Homephone"  SortExpression="XOL_Homephone" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="负责事务"  DataField="XOL_Responsible"  SortExpression="XOL_Responsible" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="部门"  DataField="XOL_Duty"  SortExpression="XOL_Duty" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="地址"  DataField="XOL_Address"  SortExpression="XOL_Address" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="负责人"  SortExpression="XOL_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XOL_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="center" >
            <ItemTemplate>
                <a href="KNet_Sales_LinkMan_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XOL_ID") %>"><asp:Image ID="Image1" runat="server"  ImageUrl="../../images/Edit.gif" border=0  ToolTip="修改" /></a>
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