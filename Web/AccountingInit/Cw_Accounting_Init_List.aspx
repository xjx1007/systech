﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Accounting_Init_List.aspx.cs" Inherits="Cw_Accounting_Init_List" %>

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
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>期初余额 >
	<a class="hdrLink" href="Cw_Accounting_Init_List.aspx">期初余额</a>
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
				<td style="padding-right:0px;padding-left:10px;"><a href="javascript:;"  onclick="PageGo('Cw_Accounting_Init_Add.aspx')"><img src="/themes/softed/images/btnL3Add.gif" alt="创建 期初余额..." title="创建 期初余额..." border=0></a></td>
				<td style="padding-right:0px;"><asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="/themes/softed/images/btnL3Delete.gif"  OnClick="Btn_Del_Click"/></td>
				<td style="padding-right:10px"><a href="javascript:;" onClick="ShowDiv()" ><img src="/themes/softed/images/btnL3Search.gif" alt="查找 期初余额..." title="查找 期初余额..." border=0></a></td>
				<td style="padding-right:0px;padding-left:10px;"><img src="/themes/softed/images/tbarImport.gif" alt="*导入 期初余额" title="*导入 期初余额" border="0"></td>	
				<td style="padding-right:10px"><img src="/themes/softed/images/tbarExport.gif" alt="*导出 期初余额" title="*导出 期初余额" border="0"></td>
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
    <%=base.Base_BindView("Cw_Accounting_Init", "Cw_Accounting_Init_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
</td>
</tr>

            <tr>
                <td>
                    <div id="Search_basic" style="display: none" runat="server">
                        <table width="80%" cellpadding="5" cellspacing="0" class="searchUIBasic small" align="center"
                            border="0">
                            <tr>
                                <td class="searchUIName small" nowrap align="left">
                                    <span class="moduleName">查找</span><br>
                                    <span class="small"><a href="#" onclick="ShowDiv();fnshow();">高级查找</a></span>
                                </td>
                                <td class="small" nowrap align="right">
                                    <b>查找</b></td>
                                <td class="small" nowrap>
                                    <div id="basicsearchcolumns_real">
                                        <asp:DropDownList runat="server" ID="bas_searchfield" class="txtBox">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td class="small">
                                    <asp:TextBox ID="search_text" class="txtBox" runat="server"></asp:TextBox></td>
                                <td class="small" nowrap width="40%">
                                    <asp:Button ID="btnBasicSearch" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small create" OnClick="btnBasicSearch_Click" />&nbsp;
                                    <input name="Btn_submit" type="button" class="crmbutton small edit" onclick="ShowDiv()"
                                        value=" 取消查找 ">&nbsp;
                                </td>
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="ShowDiv()">
                                    [x]</td>
                            </tr>
                        </table>
                    </div>
                    <div id="advSearch" style="display: none;" runat="server">
                        <table cellspacing="0" cellpadding="5" width="80%" class="searchUIAdv1 small" align="center"
                            border="0">
                            <tr>
                                <td class="searchUIName small" nowrap align="left">
                                    <span class="moduleName">查找</span><br>
                                    <span class="small"><a href="#" onclick="ShowDiv();fnshow();">基本查找</a></span></td>
                                <td nowrap class="small">
                                    <b>
                                        <input name="matchtype" id="matchtype1" type="radio" runat="server" value="all">&nbsp;匹配以下所有条件</b></td>
                                <td nowrap width="60%" class="small">
                                    <b>
                                        <input name="matchtype" id="matchtype2" type="radio" value="any" runat="server" checked>&nbsp;匹配以下任意条件</b></td>
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="fnshow()">
                                    [x]</td>
                            </tr>
                        </table>
                        <table cellpadding="2" cellspacing="0" width="80%" align="center" class="searchUIAdv2 small"
                            border="0">
                            <tr>
                                <td align="center" class="small" width="90%">
                                    <div id="fixed" style="position: relative; width: 95%; height: 80px; padding: 0px;
                                        overflow: auto; border: 1px solid #CCCCCC; background-color: #ffffff" class="small">
                                        <table border="0" width="95%">
                                            <tr>
                                                <td align="left">
                                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" id="adSrc" align="left">
                                                        <tr>
                                                            <td width="31%">
                                                                <asp:DropDownList runat="server" ID="Fields" class="txtBox">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="32%">
                                                                <asp:DropDownList ID="Condition" runat="server" class="txtBox">
                                                                    <asp:ListItem Value="cts">包含</asp:ListItem>
                                                                    <asp:ListItem Value="dcts">不包含</asp:ListItem>
                                                                    <asp:ListItem Value="is">等于</asp:ListItem>
                                                                    <asp:ListItem Value="isn">不等于</asp:ListItem>
                                                                    <asp:ListItem Value="grt">大于</asp:ListItem>
                                                                    <asp:ListItem Value="lst">小于</asp:ListItem>
                                                                    <asp:ListItem Value="grteq">大于等于</asp:ListItem>
                                                                    <asp:ListItem Value="lsteq">小于等于</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="32%">
                                                                <asp:TextBox ID="Srch_value" runat="server" class="detailedViewTextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <%=s_AdvShow %>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <hr width="720">
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellspacing="0" cellpadding="5" width="80%" class="searchUIAdv3 small"
                            align="center">
                            <tr>
                                <td align="left" width="40%">
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Cw_Accounting_Init")%>','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
                                        class="crmbuttom small edit">
                                    <input name="button" type="button" value=" 删除条件 " onclick="delRow()" class="crmbuttom small edit">
                                </td>
                                <td align="left" class="small">
                                    <asp:Button ID="btnAdvancedSearch" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small create" OnClick="btnAdvancedSearch_Click" />&nbsp;
                                    <input type="button" class="crmbutton small edit" value=" 取消查找 " onclick="fnshow();">
                                </td>
                            </tr>
                        </table>
                    </div>
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
        
         <asp:TemplateField HeaderText="编号"  SortExpression="CAI_Code" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <a href="Cw_Accounting_Init_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAI_ID") %>"><%# DataBinder.Eval(Container.DataItem, "CAI_Code").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="客户名称"  SortExpression="CAI_CustomerValue" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "CAI_CustomerValue").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="供应商"  SortExpression="CAI_SuppNo" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "CAI_SuppNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="负责人"  SortExpression="CAI_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "CAI_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="类型"  SortExpression="CAI_CareTypes" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("209",DataBinder.Eval(Container.DataItem, "CAI_Type").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="摘要"  DataField="CAI_Title"  SortExpression="CAI_Title"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="日期"  DataField="CAI_Stime"  SortExpression="CAI_Stime" DataFormatString="{0:yyyy-MM-dd}"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="创建人"  DataField="CAI_CTime"  SortExpression="CAI_CTime" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="center" >
            <ItemTemplate>
                <a href="Cw_Accounting_Init_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAI_ID") %>"><asp:Image ID="Image1" runat="server"  ImageUrl="/images/Edit.gif" border=0 ToolTip="修改" /></a>
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