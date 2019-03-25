<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_WareHouseList_View.aspx.cs" Inherits="Web_Knet_Procure_WareHouseList_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
<title>采购入库查看</title>
<script type="text/javascript" src="../../Js/ajax_func.js"></script>
<link rel="alternate icon" type="image/png" href="../../../images/士腾.png"/>
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
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>采购入库 > 
	<a class="hdrLink" href="Knet_Procure_WareHouseList_List.aspx">采购入库</a>
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
	     	     <div class="small" style="padding:10px">
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
                <hr noshade size=1>
                                
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>采购入库信息</td>
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
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('Knet_Procure_WareHouseList_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')" name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Procure_WareHouseList_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;
                                        <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批"  OnClick="btn_Chcek_Click"/>&nbsp;
                                        <asp:Button ID="btn_Adjust" runat="server" class="crmbutton small edit" Text="调账" OnClick="btn_Adjust_Click" Visible="false" />

                                                                                               </td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('Knet_Procure_WareHouseList_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
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
                                    <td align="left" style="padding-left:10px;border-bottom:1px dotted #CCCCCC;">
                                    <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>                                    
                                    </td>
                                    </tr>
                                       <tr>
	                                    <td align="left">
		                                    <span class="genHeaderSmall">工具</span><br /> 
	                                    </td>
                                       </tr>
                                          <tr>
	                                    <td align="left" style="padding-left:10px;">
		                                    <img src="../../../themes/softed/images/pointer.gif" hspace="5" />
		                                    <a href="javascript: document.DetailView.return_module.value='Quotes';document.DetailView.return_action.value='DetailView';document.DetailView.module.value='Quotes'; document.DetailView.action.value='CreatePDF';document.DetailView.record.value='1742'; document.DetailView.return_id.value='1742';document.DetailView.submit();" class="webMnu">导出Excel</a> 
	                                    </td>
                                       </tr>   <tr>
	                                    <td align="left" style="padding-left:10px;">
		                                    <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="absmiddle"/>
		                                    <a href="index.php?module=Quotes&action=CreatePDFPrint&record=1742" target="_blank" class="webMnu">打印</a>
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
                                        <td  class="dvtCellLabel" >采购入库编号:</td>
                                        <td class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Code"  runat="server"  ></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >入库日期:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Stime" runat="server" ></asp:Label>
                                            <pc:PTextBox ID="txt_WareHouseDateTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                AllowEmpty="false" Visible="false"></pc:PTextBox>
                                        </td>
                                        </tr>
                                            
                                        <tr>
                                        <td  class="dvtCellLabel">收货日期:</td>
                                        <td  class="dvtCellInfo"  colspan="3">
                                        <asp:Label ID="Lbl_CheckTime" runat="server" ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >采购单号:</td>
                                        <td class="dvtCellInfo">
                                        <asp:Label ID="Lbl_OrderNo"  runat="server"  ></asp:Label>
                                        </td>
                                        <td  class="dvtCellLabel" >供应商:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_SuppNo" runat="server" ></asp:Label>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" > 仓库:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Dept"  runat="server"  ></asp:Label></td>
                                        </td>
                                        <td  class="dvtCellLabel" >确认状态:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_QrState"  runat="server"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >对账状态:</td>
                                        <td  class="dvtCellInfo" colspan="3">
                                        <asp:Label ID="Lbl_DzState"  runat="server"  ></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>描述信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >其他说明 :</td>
                                        <td  valign="top" class="dvtCellInfo"   colspan="4" >
                                        <asp:Label ID="Lbl_Payment"  runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >备注:</td>
                                        <td  valign="top" class="dvtCellInfo"   colspan="4" >
                                        <asp:Label ID="Lbl_Remarks"  runat="server"></asp:Label></td>
                                        </tr>
                                            <tr>
	                                            <td colspan="4" class="detailedViewHeader">
		                                            <b>产品详细信息</b>
	                                            </td>
                                               </tr>
                                        </table>
							          <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <table id="myTable"  width="100%"  border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">
                                   
                                               <!-- Header for the Product Details -->
                                                <tr valign="top">
                                                <td  class="ListHead" nowrap><b>产品名称</b></td>
                                                <td  class="ListHead" nowrap><b>产品编码</b></td>
                                                <td class="ListHead"  nowrap><b>型号</b></td>
                                                <td class="ListHead" nowrap><b>数量</b></td>
                                                <td class="ListHead" nowrap><b>备料数量</b></td>
                                                <td class="ListHead" nowrap><b>单价</b></td>
                                                 <td class="ListHead" nowrap><b>金额</b></td>
                                                <td   class="ListHead" nowrap><b>备注</b></td>
                                                </tr>
                                                <%=s_MyTable_Detail %>
                                            </table>
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

