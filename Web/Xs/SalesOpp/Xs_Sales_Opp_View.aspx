<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Opp_View.aspx.cs" Inherits="Web_Xs_Sales_Opp_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register Src="../../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<title></title>
<script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
<script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>	
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>销售机会 > 
	<a class="hdrLink" href="Xs_Sales_Opp_List.aspx">销售机会</a>
        </td>
	<td width=100% nowrap>
 <asp:Label ID="Tbx_ID" runat="server" style="display:none"></asp:Label>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>

<table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
   <tr>
   	<td valign="top"><img src="/themes/softed/images/showPanelTopLeft.gif"></td>
	<td class="showPanelBg" valign="top" width="100%">
	     	     <div class="small" style="padding:10px"></div>
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
                <hr noshade size=1>
                                
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>销售机会信息</td>
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
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('Xs_Sales_Opp_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')" name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Xs_Sales_Opp_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;</td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('Xs_Sales_Opp_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
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

                                    <tr>
                                    <td align="left" style="padding-left:10px;">
                                    <img src="/themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <a href="/Web/CustomerContent/Xs_Sales_Content_Add.aspx?CustomerValue=<%=s_CustomerValue %>&LinkMan=<%=s_LinkMan %>&OppID=<%=s_OppID %>" class="webMnu">创建联系记录</a> 
                                    </td>
                                    </tr>
                                    <tr>
                                    <td align="left" style="padding-left:10px;">
                                    <img src="/themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <a href="/Web/SalesQuotes/Xs_Sales_Quotes_Add.aspx?OppID=<%=s_ID %>" class="webMnu">创建报价单</a> 
                                    </td>
                                    </tr>

                                    </table>
                                </td>
                             </tr>
                             <tr>
                                 <td>
                                        <table border=0 cellspacing=0 cellpadding=0 width=100% class="small">
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >销售机会名称:</td>
                                        <td class="dvtCellInfo" colspan="3">
                                        <asp:Label ID="Lbl_Name"  runat="server"  ></asp:Label>
                                        </td>
                                        </tr>

                                        <tr>
                                        <td  class="dvtCellLabel" > 客户:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_CustomerValue"  runat="server"  ></asp:Label></td>
                                        <td  class="dvtCellLabel" >联系人:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_LinkMan"  runat="server"  ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>客户决策链</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="dvtCellInfo">
                                        
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                <tr>
                                                    <td>
                                                        <%= s_Structure %>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        </tr>
                                        
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>销售进展</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td width="17%"  class="dvtCellLabel" >时间结点:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_PlanDealDate" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>

                                        <td  class="dvtCellLabel" >类型:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Type" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td width="17%"  class="dvtCellLabel" >可能性:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Precent" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>
                                                 <td width="17%"  class="dvtCellLabel" >销售阶段:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_SalesStep" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                    </td>
                                        </td>
                                        
                                        </tr>
                                        </tr>
                                        <td  class="dvtCellLabel" >负责人:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_DutyPerson" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >辅助人:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_FDutyPerson" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        
                                        <td   class="dvtCellLabel" >项目背景:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Background" runat="server" ></asp:Label>
                                        </td>
                                   
                                        <td  class="dvtCellLabel" >进攻策略:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_History" runat="server" ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >竞争分析:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Competitor" runat="server" ></asp:Label>
                                        <td  class="dvtCellLabel" >下一步工作计划:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_NextPlan" runat="server"  ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >创建人:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Cretaor" runat="server" ></asp:Label>
                                        </td>
                                        <td   class="dvtCellLabel" >创建时间:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_CTime" runat="server" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >修改人:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Mender" runat="server" ></asp:Label>
                                        </td>
                                        <td   class="dvtCellLabel" >修改时间:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_MTime" runat="server" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>描述信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >备注:</td>
                                        <td  valign="top" class="dvtCellInfo"   colspan="4" >
                                        <asp:Label ID="Lbl_Remarks"  runat="server"></asp:Label></td>
                                        </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <uc1:CommentList ID="CommentList1" runat="server" CommentFID="0" CommentType="0" />
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td colspan="4">
                                                        <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="left">
                                                        <b>联系记录</b>：
                                                    </td>
                                                    <td colspan="2" align="right">
                                                        <input title="新增联系记录" type="button" accesskey="E" class="crmbutton small create"
                                                            onclick="PageGo('../CustomerContent/Xs_Sales_Content_Add.aspx?CustomerValue=<%= s_CustomerValue %>&OppID=<%= s_ID %>')"
                                                            name="Edit" value="&nbsp;新增联系记录&nbsp;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                        <cc1:MyGridView ID="GridView_Contenct" runat="server" AllowPaging="True" AllowSorting="True"
                                                            IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                            PageSize="10" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="主题" SortExpression="XSC_Topic" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <a href="/Web/CustomerContent/Xs_Sales_Content_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSC_ID") %>">
                                                                            <%# DataBinder.Eval(Container.DataItem, "XSC_Topic").ToString()%></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="客户名称" SortExpression="XSC_CustomerValue" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "XSC_CustomerValue").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="联系人" SortExpression="XSC_LinkMan" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetLinkManValue(DataBinder.Eval(Container.DataItem, "XSC_LinkMan").ToString(),"XOL_Name")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="联系类型" SortExpression="XSC_Types" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetBasicCodeName("117",DataBinder.Eval(Container.DataItem, "XSC_Types").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="联系日期" DataField="XSC_Stime" SortExpression="XSC_Stime"
                                                                    DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="负责人" SortExpression="XSC_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSC_DutyPerson").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="创建人" SortExpression="XSC_Creator" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSC_Creator").ToString())%>
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
                                                <tr>
                                                    <td colspan="4" align="left">
                                                        <b>销售机会推进历史：</b>：
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                       
                                                       
    <cc1:MyGridView ID="GridView_Opp" runat="server" AllowPaging="True" AllowSorting="True" IsShowEmptyTemplate="true"
   AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
<Columns>

         <asp:TemplateField HeaderText="销售机会名称"  SortExpression="XSO_Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <a href="Xs_Sales_Opp_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSO_DID") %>"><%# DataBinder.Eval(Container.DataItem, "XSO_Name").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="客户名称"  SortExpression="XSO_CustomerValue" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "XSO_CustomerValue").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="销售阶段"  SortExpression="XSO_SalesStep" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("118", DataBinder.Eval(Container.DataItem, "XSO_SalesStep").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="销售过程"  SortExpression="XSO_SalesType" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("202", DataBinder.Eval(Container.DataItem, "XSO_SalesType").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="可能性"  DataField="XSO_Precent"  SortExpression="XSO_Precent" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="联系人"  SortExpression="XSO_LinkMan" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetLinkManValue(DataBinder.Eval(Container.DataItem, "XSO_LinkMan").ToString(),"XOL_Name")%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="时间结点"  DataField="XSO_PlanDealDate"  SortExpression="XSO_PlanDealDate" DataFormatString="{0:yyyy-MM-dd}"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
         <asp:BoundField  HeaderText="下一步"  DataField="XSO_NextPlan"  SortExpression="XSO_NextPlan" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
      <asp:TemplateField HeaderText="负责人"  SortExpression="XSO_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSO_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="辅助人"  SortExpression="XSO_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSO_FDutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="创建时间" HeaderStyle-HorizontalAlign="center"  SortExpression="XSO_CTime" >
            <ItemTemplate>
                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "XSO_CTime").ToString()).ToString()%>
           </ItemTemplate>
        </asp:TemplateField>
</Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
</cc1:MyGridView>
                                                    </td>
                                                </tr>
                                        </table>
                                  </td>
                             </tr>
							</table>
                            </td>
                            </tr>
                </table>
    </td>
    <td valign="top"><img src="/themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

