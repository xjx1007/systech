<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Reports_Submit_Type_View.aspx.cs" Inherits="Web_KNet_Reports_Submit_Type_View" %>

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




<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>报表上传 > 
	<a class="hdrLink" href="KNet_Reports_Submit_List.aspx">报表上传</a>
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
                                
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>报表上传信息</td>
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
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('KNet_Reports_Submit_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"  name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('KNet_Reports_Submit_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;</td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('KNet_Reports_Submit_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
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
                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <a href="KNet_Reports_Submit_View.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=IsAndswer" class="webMnu">创建评阅</a> 
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
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >编号:</td>
                                        <td class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Code"  runat="server"  ></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >日期:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Stime" runat="server" ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td width="17%"  class="dvtCellLabel" >上传人:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_DutyPerson" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
                                        </td>

                                        <td  class="dvtCellLabel" >状态:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_State" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>
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
                                        <td colspan=4 class="detailedViewHeader"><b>附件信息</b>
                                        </td>
                                        </tr>
                                        <tr> 
                                        <td  align="center" colspan="4">文件名</td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellInfo"  colspan="4"> <asp:LinkButton id="Lbl_Spce" runat="server" OnClick="Lbl_Spce_Click"></asp:LinkButton> <asp:TextBox runat="server"  CssClass="Custom_Hidden" ID="Tbx_Type"></asp:TextBox></td>

                                        </tr>
                                        <tr>
                                        <td  class="dvtCellInfo"  colspan="4"> <asp:LinkButton id="Lbl_Spce1" runat="server" OnClick="Lbl_Spce1_Click"></asp:LinkButton><asp:TextBox runat="server"  CssClass="Custom_Hidden" ID="Tbx_Type1"></asp:TextBox></td>
                                  
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellInfo"   colspan="4"> <asp:LinkButton id="Lbl_Spce2" runat="server" OnClick="Lbl_Spce2_Click"></asp:LinkButton> <asp:TextBox runat="server"  CssClass="Custom_Hidden" ID="Tbx_Type2"></asp:TextBox>
                                        </td>
                          
                                        </tr>
                                        <tr>
                                        <td colspan="4"> <cc1:MyGridView ID="MyGridView1" runat="server"  AllowSorting="True" IsShowEmptyTemplate="true"  
            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" >
<Columns>

         <asp:BoundField  HeaderText="意见"  DataField="KRV_Remarks"  SortExpression="KRV_Remarks" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="评阅人"  SortExpression="KRV_Creator" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KRV_Creator").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="评阅时间"  DataField="KRV_CTime"  SortExpression="KRV_CTime" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
</Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
</cc1:MyGridView></td></tr>
                                        <tr id="Tr_Andwser" runat="server" visible="false" >
                                        <td  class="dvtCellInfo"  colspan="4"> 
                                           
                                            <table border=0 cellspacing=0 cellpadding=0 width=100% class="small">
                                                <tr>
                                        <td  class="dvtCellLabel" >意见</td>
                                        <td  class="dvtCellInfo" > <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="71px"></asp:TextBox></td>
                                                    
                                        <td  class="dvtCellLabel" >评阅人</td>
                                        <td  class="dvtCellInfo" > 
                                        <asp:Label ID="Lbl_Person"  runat="server"></asp:Label>
                                        </td>
                                                </tr>
                                                <tr>
                                                <td  align="center"colspan="4"><asp:Button ID="Btn_Save" runat="server" Text="保 存" accessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick"  />
   <input title="取消 [Alt+X]" accessKey="X" class="crmbutton small cancel" onclick="PageGo('KNet_Reports_Submit_Add.aspx?ID=<%=Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString() %>')" type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="width:70px">
 </td></tr>
                                            </table>
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
    <td valign="top"><img src="../../themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

