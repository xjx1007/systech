<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PB_Basic_Code_View.aspx.cs" Inherits="Web_PB_Basic_Code_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<title></title>
<script type="text/javascript" src="../Js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>	
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">



<%--莱单列表结束--%>
<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>系统编码 > 
	<a class="hdrLink" href="PB_Basic_Code_List.aspx">系统编码</a>
        </td>
	<td width=100% nowrap>
 <asp:Label ID="Tbx_ID" runat="server" style="display:none"></asp:Label>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>

<table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
   <tr>
   	<td valign="top"><img src="../../themes/softed/images/showPanelTopLeft.gif"></td>
	<td class="showPanelBg" valign="top" width="100%">
	     	     <div class="small" style="padding:10px"></div>
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
                <hr noshade size=1>
                                <%--固定样式 --%>
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>系统编码信息</td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>										
                                    <td class="dvtUnSelectedCell" align="center" nowrap>
                                    <a href="#">相关信息</a></td>
                                    <td class="dvtTabCache" style="width:100%">&nbsp;</td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>		
                            <tr>
                            <td>
                            <table border=0 cellspacing=3 cellpadding=3  width=100% class="dvtContentSpace">
							
                            <tr>
                                <td valign=top align=left >
                                    <table border=0 cellspacing=0 cellpadding=0 width=100%><tr><td>
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('PB_Basic_Code_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Code=<%= Request.QueryString["Code"].ToString() %>')" name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('PB_Basic_Code_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;</td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('PB_Basic_Code_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Code=<%= Request.QueryString["Code"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
                                    <input title="刪除 [Alt+D]" type="button" accessKey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除" >&nbsp;
                                    </td></tr>
                                    </table>
                                </td>
                                <td width=22% valign=top style="border-left:2px dashed #cccccc;padding:13px" rowspan="2">
                                    <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                    <tr>
                                    <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td align="left" class="genHeaderSmall">操作</td>
                                    </tr>
                                    <!-- Module based actions starts -->


                                    </table>
                                </td>
                             </tr>
                             <tr>
                                 <td>
                                        <table border=0 cellspacing=0 cellpadding=0 width=100% class="small">
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >ID:</td>
                                        <td class="dvtCellInfo">
                                        <asp:Label ID="Lbl_ID"  runat="server"  ></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >Code:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Code" runat="server" ></asp:Label>
                                        </td>
                                        </tr>

                                        <tr>
                                        <td  class="dvtCellLabel" >名称:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Name"  runat="server"  ></asp:Label></td>
                                        <td  class="dvtCellLabel" >排序:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Order"  runat="server"  ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td width="17%"  class="dvtCellLabel" >明细:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Details" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>

                                        <td  class="dvtCellLabel" >中文名称:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_CName" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>
                                        </tr>
                                     
                                     <tr>
                                     <td colspan="4">
                                     其他编码：
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
        
         <asp:TemplateField HeaderText="编号"  SortExpression="PBC_ID" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <a href="PB_Basic_Code_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PBC_ID") %>&Code=<%# DataBinder.Eval(Container.DataItem, "PBC_Code") %>"><%# DataBinder.Eval(Container.DataItem, "PBC_ID").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  HeaderText="Value值"  DataField="PBC_Code"  SortExpression="PBC_Code"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:BoundField  HeaderText="名称"  DataField="PBC_Name"  SortExpression="PBC_Name"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="排序"  DataField="PBC_Order"  SortExpression="PBC_Order"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="明细"  DataField="PBC_Details"  SortExpression="PBC_Details"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="中文名称"  DataField="PBC_CName"  SortExpression="PBC_CName"  ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
</Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
</cc1:MyGridView>
                                     </td></tr>
                                        </table>
                                  </td>
                             </tr>
							</table>
                            </td>
                            </tr>
                </table>
    </td>
    <td valign="top"><img src="../../themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

