<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_ShipCheck_CView.aspx.cs" Inherits="Web_Sales_Procure_ShipCheck_CView" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
<div id="AutoCreateChargesdiv" class="layerPopup" style="display:none;width:520px; left:250px;">
<table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
<tr>
	<td class="layerPopupHeading" align="left" width="80%" style="cursor:move">创建应付款</td>
	<td>&nbsp;</td>
	<td align="right" width="40%"><img onClick="fninvsh('AutoCreateChargesdiv');" title="关闭" alt="关闭" style="cursor:pointer;" src="themes/softed/images/close.gif" align="absmiddle" border="0"></td>
</tr>
</table>
<table border=0 cellspacing=0 cellpadding=5 width=95% align=center> 
	<tr>
		<td class=small>
          <div id="serialinfodiv">
				<table class=" small" width="100%" cellspacing="1" cellpadding="3" border="0">
					<tr class="lvtColData" height="25px;">
						<td colspan="2">①自动创建应付款</td>
					</tr>
					<tr height="25px;">
						<td width="20px;">&nbsp;</td>
						<td>
							应收日期:   <asp:TextBox ID="Tbx_YTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                               ></asp:TextBox>
							&nbsp;
							应收金额:<asp:Label runat="server" ID="Lbl_YMoney"></asp:Label>
						</td>
					</tr>
					<tr height="25px;">
						<td>&nbsp;</td>
						<td style="color:#CC0066;">
						确认后，将自动创建期数为1的应付款，应付金额为订单金额，<br>负责人、供应商与当前订单信息一致
						</td>
					</tr>
					<tr height="25px;">
						<td>&nbsp;</td>
						<td style="color:#CC0066;">
							<input type="button" name="button" class="crmbutton small edit" value=" 确认 " onClick="AutoCrCharges_click(1809);">
							<input type="button" name="button" class="crmbutton small cancel" value=" 取消 " onClick="location.href='index.php?module=PurchaseOrder&action=DetailView&record=1809';fninvsh('AutoCreateChargesdiv');">
						</td>
					</tr>
					<tr class="lvtColData" height="25px;">
						<td colspan="2">②手动创建应付款</td>
					</tr>
					<tr height="25px;">
						<td>&nbsp;</td>
						<td style="color:#CC0066;">
						<a href="" onclick="ManualCrCharges_click();return false;">打开 创建应付款界面</a>
						</td>
					</tr>
				</table>
		  </div>
		</td>
	</tr>
</table>
</div>



<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>采购对账单 > 
	<a class="hdrLink" href="Procure_ShipCheck_List.aspx">采购对账单</a>
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
                                    <td <%=s_OrderStyle%> align="center" nowrap><a href="Procure_ShipCheck_List.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">采购对账单信息</a></td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>										
                                    <td <%=s_DetailsStyle%>  align="center" nowrap>
                                    <a href="Procure_ShipCheck_List.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">相关信息</a></td>
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
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('Procure_ShipCheck_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')" name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    
                                                            <asp:Button ID="Btn_Create" runat="server" Text="创建付款计划" title="创建付款计划"
                                                                class="crmbutton small save" />
                                   <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Procure_ShipCheck_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;
                                   
                                    <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批"  OnClick="btn_Chcek_Click"/></td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('Procure_ShipCheck_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
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
                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <asp:Label runat="server" ID="Lbl_Link"></asp:Label>
                                    
                                    </td>
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
                                        <td  class="dvtCellLabel" >对账单号:</td>
                                        <td class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Code"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >对账日期:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Stime" runat="server" ></asp:Label>
                                        </td>
                                        </tr>

                                        <tr>
                                        <td  class="dvtCellLabel" >日期:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_PreTime"  runat="server"  Width="150px"></asp:Label></td>
                                        <td  class="dvtCellLabel" >对账类型:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Type"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        <tr>
                                        <td  class="dvtCellLabel" >供应商:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Supp"  runat="server"  Width="150px"></asp:Label></td>
                                        <td  class="dvtCellLabel" >仓库:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_House"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >付款单状态:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_IsPayMent"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >发票状态:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_IsFp"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >审核状态:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_CheckYN"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >审核人:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Check"  runat="server"  Width="150px"></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >备注说明:</td>
                                        <td  class="dvtCellInfo"  colspan="3">
                                        <asp:Label ID="Lbl_Remarks" runat="server"   Width="150px"></asp:Label>
                                        </td>
                                        </tr>

                                        <tr><td  class="dvtCellInfo" colspan="4">
                                         <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="crmTable" style="height: 28px">
                                                                <tr>
                                                                    <td colspan="13" class="dvInnerHeader">
                                                                        <b>对账详细信息</b>
                                                                    </td>
                                                                </tr>
                                                                <!-- Header for the Product Details -->
                                                                <tr valign="top">
                                                                    <td class="ListHead" nowrap>
                                                                        <b>发生单号</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>发生日期</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>客户/供应商</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品名称</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品编码</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>版本号</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>数量</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>对账数量</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>备货数量</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>单价</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>加工费单价</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>总金额</b></td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>备注</b></td>
                                                                </tr>
                                                                <%=s_MyTable_Detail %>
                                                            </table>
                                        </table>
                                        
		                    </asp:Panel>					
		                    
                            <asp:Panel ID="Pan_Detail" runat="server"> 
                            
                                        <table border=0 cellspacing=0 cellpadding=0 width=100% class="small">
                                        <tr>
                                        <td>
                                        </td>
                                        </tr>
                                        </table>
		                    </asp:Panel>	
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

