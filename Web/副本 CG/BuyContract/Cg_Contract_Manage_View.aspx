﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cg_Contract_Manage_View.aspx.cs" Inherits="Web_Cg_Contract_Manage_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
<title></title>
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
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
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>合同档案 > 
	<a class="hdrLink" href="Cg_Contract_Manage_List.aspx">合同档案</a>
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
                                    <td class="dvtSelectedCell" align="center" nowrap>合同档案信息</td>
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
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('Cg_Contract_Manage_Add.aspx?ID=<%=Request.QueryString["ID"].ToString() %>')" name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Cg_Contract_Manage_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;</td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('Cg_Contract_Manage_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
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
                                                <td align="left" style="padding-left: 10px;">
                                                    <img src="../../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                    <a href="../../SalesContract/KNet_Sales_ContractList_Add.aspx?FaterID=<%= Request.QueryString["ID"].ToString() %>" 
                                                        class="webMnu">新增订单评审</a>
                                                </td>
                                    </table>
                                </td>
                             </tr>
                             <tr>
                                 <td>
                                 
                            <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                            <tr>
                                                    <asp:Label ID="Label1" runat="server" Style="display: none"></asp:Label>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    编号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编号不能为空" 
                                                        Width="150px"></asp:Label>
                                                    
                                                </td>
                                                <td class="dvtCellLabel">
                                                    标题:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label runat="server" ID="Tbx_Title" AllowEmpty="false" ValidError="标题不能为空" 
                                                        Width="150px"></asp:Label>
                                                    
                                                </td>
                                                </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    签订日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Tbx_STime" runat="server" ></asp:Label>
                                                    
                                                </td>
                                                <td class="dvtCellLabel">
                                                    类型:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="DDl_Type" runat="server">
                                                    </asp:Label>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="17%" class="dvtCellLabel">
                                                    客户:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Tbx_CustomerName" runat="server" 
                                                        Width="178px" ReadOnly="true"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    负责人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Ddl_DutyPerson" runat="server" Width="100px">
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                            
                                    <tr>
                                        
                                        <td width="17%" class="dvtCellLabel">
                                            结算方式:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ContractToPayment" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            付款方式:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Drop_Payment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            技术要求:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_TechnicalRequire" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            产品包装:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_ProductPackaging" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            质量要求:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_QualityRequire" runat="server"></asp:Label>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            质保期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Tbx_WarrantyPeriod" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                <tr>
                                                    
                                                <td class="dvtCellLabel">
                                                    发货要求:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    
                                                    <asp:Label runat="server" ID="Tbx_FhDetails" ></asp:Label>
                                                    
                                                    </td>
                                                        
                                                    <td class="dvtCellLabel">备货要求:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                    <asp:Label runat="server" ID="Tbx_ContractShip" ></asp:Label>
                                                    </td>

                                                    </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    审批流程:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                    <asp:Label ID="Ddl_Flow" runat="server">
                                                    </asp:Label>
                                                    
                                                </td>
                                            </tr>                       <asp:Label ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:Label>
                                            <tr><td height="25" align="right" class="dvtCellLabel">
                                                    附件资料:</td>
                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="2"> 
                                                    <table  width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr id="tr5">
                                                        
                                                            <td align="center" class="dvtCellLabel">
                                                                工具</td>
                                                            <td align="center" class="dvtCellLabel">
                                                                名称</td>
                                                            <td align="center" class="dvtCellLabel" colspan="2">
                                                                资料</td>
                                                        </tr>
                                                         <tr id="tr4">
                                                            <td colspan="4">
                                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label></td>
                                                        </tr>
                                                     
                                                    </table>
                                                </td>
                                            </tr>   
                                                  
                                                        <tr>
                                                            <td height="25" align="right" class="dvtCellLabel">
                                                                问题反馈简介:</td>
                                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                                <asp:Label ID="tbx_Remarks" runat="server" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                  
                            </table>
    </td> </tr>
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

