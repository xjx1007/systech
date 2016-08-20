<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_SuppliersRC_Price_View.aspx.cs" Inherits="Web_Sales_Knet_Procure_SuppliersRC_Price_View" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
<title>BOM产品报价</title>
<script type="text/javascript" src="../../Js/ajax_func.js"></script>
<script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>	
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>BOM报价 > 
	<a class="hdrLink" href="Knet_Procure_SuppliersRC_Price.aspx">BOM报价</a>
        </td>
	<td width=100% nowrap>
 <asp:Label ID="Tbx_ID" runat="server" style="display:none"></asp:Label>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>



<table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
   <tr>
   	<td valign="top"><img src="../../../themes/softed/images/showPanelTopLeft.gif"></td>
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
                                    <td <%=s_OrderStyle%> align="center" nowrap><a href="Knet_Procure_OpenBilling_View.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">BOM报价信息</a></td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>										
                                    <td <%=s_DetailsStyle%>  align="center" nowrap>
                                    <a href="Knet_Procure_OpenBilling_View.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">相关信息</a></td>
                                    <td class="dvtTabCache" style="width:100%" >&nbsp;</td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>		
                            <tr>
                            <td>
                            <table border=0 cellspacing=3 cellpadding=3  width=100% class="dvtContentSpace">
							
                            <tr>
                                <td valign=top align=left >
                                    <table border=0 cellspacing=0 cellpadding=0 width=100% id="Table_Btn" runat="server"><tr><td>
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('Knet_Procure_SuppliersRC_Price_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')" name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Procure_SuppliersRC_Price.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;

                                    <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审核"  OnClick="btn_Chcek_Click"/></td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('Knet_Procure_SuppliersRC_Price_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
                                    <input title="刪除 [Alt+D]" type="button" accessKey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除" >&nbsp;
                                    </td></tr>
                                    </table>
                                </td>
                                <td width=22% valign=top style="border-left:2px dashed #cccccc;padding:13px" rowspan="3">
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
                                    <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <asp:Label runat="server" ID="Lbl_Link"></asp:Label>
                                    
                                    </td>
                                    <tr>
                                    </table>
                                </td>
                             </tr>
                             <tr>
                                 <td>
                            <asp:Panel ID="Pan_Order" runat="server"> 
                                        <table border=0 cellspacing=0 cellpadding=0 width=100% class="small">
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >遥控器:</td>
                                        <td class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Products"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >是否停用该供应商相同产品价格:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_STop" runat="server" ></asp:Label>
                                        </td>
                                        </tr>

                                        <tr>
                                        <td  class="dvtCellLabel" >添加日期:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_CTime"  runat="server"  Width="150px"></asp:Label></td>
                                        <td  class="dvtCellLabel" >添加人员:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_CPerson"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr><td  class="dvtCellInfo" colspan="4">遥控器
                                         <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="crmTable" style="height: 28px">
                                                                <tr>
                                                                    <td colspan="9" class="dvInnerHeader">
                                                                        <b>产品详细信息</b>
                                                                    </td>
                                                                </tr>
                                                                <!-- Header for the Product Details -->
                                                                <tr valign="top">
                                                                    <td class="ListHead" nowrap>
                                                                        <b>报价日期</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品名称</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品编码</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>版本号</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>供应商</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>单价</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>加工费单价</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>状态</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>备注</b></td>
                                                                </tr>
                                                                <%=s_MyTable_Detail %>
                                                            </table>
                                            </td>                
                                        </tr>
                                        
                                        </tr>
                                        <tr><td  class="dvtCellInfo" colspan="4">
                                         <table id="Table1" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="crmTable" style="height: 28px">
                                                                <tr>
                                                                    <td colspan="11" class="dvInnerHeader">
                                                                        <b>配件</b>
                                                                    </td>
                                                                </tr>
                                                                <!-- Header for the Product Details -->
                                                                <tr valign="top">
                                                                    <td class="ListHead" nowrap>
                                                                        <b>报价日期</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品名称</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>料号</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>版本号</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>供应商</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>单价</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>加工费<br />单价</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>数量</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>地址</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>状态</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>备注</b></td>
                                                                </tr>
                                                                <%=s_MyTable_Detail1 %>
                                                            </table>
                                            </td>                
                                        </tr>
                                        </table>
                                        
		                    </asp:Panel>					
		                    
                            <asp:Panel ID="Pan_Detail" runat="server"> 
		                    </asp:Panel>	
                                        </td>
                                        </tr>
							</table>				
                            </td>
                            </tr>
                </table>
    </td>
    <td valign="top"><img src="../../../themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

