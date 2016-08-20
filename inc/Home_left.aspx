
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home_left.aspx.cs" Inherits="inc_Default_HomeLeft"  %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<style>
.jd{font-family:Webdings,sans-serif; color:#000000;}
body {background-color: #6598D0;}
</style>
</head>

<SCRIPT language=javascript>
function collapse(objid)
{
	var obj = document.getElementById(objid);
	var obj2 = document.getElementById(objid+"_A");
	collapseAll();
	obj.style.display = '';
	obj2.innerHTML = '5';
}
function collapseAll()
{
	for (var i=1; i<20; i++)
	{
		var obj = document.getElementById('g_' + i.toString());
		var obj2 = document.getElementById('g_' + i.toString()+'_A');
		if (obj) obj.style.display = 'none';
		if (obj2) obj2.innerHTML = '6';
	}
}
</SCRIPT>


<body topmargin="0" leftmargin="0" rightmargin="0">
<form id="form1" runat="server">
<table  width="100%"  border="0" cellpadding="0" cellspacing="0" background="../images/admin_left.jpg" >
  <tr>
    <td align="center" valign="top" ><img src="../images/menu_top.gif" width="145" height="14" /></td>
  </tr>
  <tr>
    <td height="29" align="center" valign="top" >
    

<%--常用工具--%>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"   id="LcogA" runat="server"  onClick="collapse('g_1')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">常用工具</font></td>
    <td width="26%"><div id="g_1_A" class="jd">6</div></td>
  </tr>
</table>


<div id="g_1" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">

   <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="http://www.kuaidi100.com/frame/index.html" target="main">快递查询</a></td>
    
  </tr>
   <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Ktools/Calculator.aspx" target="main">常用计算器</a></td>
  </tr>
     <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Ktools/Calendar.aspx" target="main">万年历</a></td>
  </tr>
  
</table>
</div>

<%--报表上传--%>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"   id="Table3" runat="server"  onClick="collapse('g_15')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">报表上传</font></td>
    <td width="26%"><div id="g_15_A" class="jd">6</div></td>
  </tr>
</table>


<div id="g_15" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">

   <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/ReportsSubmit/KNet_Reports_Submit_List.aspx" target="main">报表管理</a><b>|</b><a href="../web/ReportsSubmit/KNet_Reports_Submit_Add.aspx"  target="main">添加</a></td>
    
  </tr>
  
</table>
</div>
<%--采购入库管理--%>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"    id="LcogC" runat="server" onClick="collapse('g_2')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">采购管理</font></td>
    <td width="26%"><div id="g_2_A" class="jd">5</div></td>
  </tr>
</table>

<div id="g_2" >
<table   width="80%"  border="0" align="center"  cellspacing="0" cellpadding="0">
  
    <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Procure/Knet_Procure_AskedPrice_Manage.aspx?Css1=Div22"  target="main">采购询价管理</a></td>
  </tr>

    <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Common/SelectSalesContractList.aspx"  target="main">未采购订单</a></td>
  </tr>

  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Procure/Knet_Procure_OpenBilling_Manage.aspx?Css1=Div22"  target="main">采购管理</a><b>|</b><a href="../web/Procure/Knet_Procure_OpenBilling.aspx?Css6=Div22"  target="main">开单</a></td>
  </tr>
  <!--  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Procure/Knet_Procure_Receiving_Manage.aspx?Css1=Div22"  target="main">收货管理</a><b>|</b><a href="../web/Procure/Knet_Procure_Receiving_Manage_Add.aspx?Css2=Div22"  target="main">开单</a></td>
  </tr>  -->

  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Procure/Knet_Procure_Return_Manage.aspx?Css1=Div22"  target="main">退货管理</a><b>|</b><a href="../web/Procure/Knet_Procure_Return_Manage_Add.aspx?Css2=Div22"  target="main">开单</a></td>
  </tr>

   <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Procure/Knet_Procure_WareHouse_Manage.aspx?Css1=Div22"  target="main">入库管理</a><b>|</b><a href="../web/Procure/Knet_Procure_WareHouse_Manage_Add.aspx?Css2=Div22"  target="main">开单</a></td>
  </tr>
  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Procure_Check/Procure_ShipCheck_List.aspx"  target="main">采购对账</a><b>|</b><a href="../web/Procure_Check/Procure_ShipCheck_Add.aspx"  target="main">开单</a></td>
  </tr>
 
   <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Procure/A_CostManagementDB.aspx?Css1=Div22"  target="main">采购费用管理</a></td>
  </tr>
  

    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Procure/KNet_Procure_Suppliers_Manage.aspx?Css1=Div22"  target="main">供应商管理</a></td>
  </tr>
  
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Procure/BasisSetting_ProcureType.aspx?Css1=Div22"  target="main">采购基本设置</a></td>
  </tr>
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Report/Cg_Report_Base.aspx?Css1=Div22"  target="main">采购报表统计</a></td>
  </tr>
  

</table>
</div>



<!--库存管理 -->
<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"    id="LcogD" runat="server" onClick="collapse('g_3')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">库存管理</font></td>
    <td width="26%"><div id="g_3_A" class="jd">6</div></td>
  </tr>
</table>

<div id="g_3" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_Ownall_New.aspx" target="main">库存总账台</a></td>
  </tr>
  
    <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_Ownall_Water_New.aspx" target="main">库存流水账</a></td>
  </tr>
      <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_DirectInto_Manage.aspx?Css1=Div22" target="main">直接入库</a><b>|</b><a href="../web/WareHouse/KNet_WareHouse_DirectInto_Add.aspx?Css2=Div22" target="main">开单</a></td>
  </tr>
  
     <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_DirectOut_Manage.aspx?Css1=Div22" target="main">直接出库</a><b>|</b><a href="../web/WareHouse/KNet_WareHouse_DirectOut_Add.aspx?Css2=Div22" target="main">开单</a></td>
  </tr>

  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_AllocateList_Manage.aspx?Css1=Div22" target="main">库间调拨</a><b>|</b><a href="../web/WareHouse/KNet_WareHouse_AllocateList_Add.aspx?Css2=Div22" target="main">添加</a></td>
  </tr>
  
    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/WareHouse/KNet_WareHouse_WareCheck_Manage.aspx?Css1=Div22" target="main">库存盘点</a><b>|</b><a href="../web/WareHouse/KNet_WareHouse_WareCheck_Add.aspx?Css2=Div22" target="main">添加</a></td>
  </tr>

   <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_OwnallWarning.aspx" target="main">库存缺货预警</a></td>
  </tr>
  
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Report/Ck_Report_Base.aspx?Css1=Div22"  target="main">库存报表统计</a></td>
  </tr>
  
</table>
</div>



<!--销售管理 -->
<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"   id="LcogE" runat="server"  onClick="collapse('g_4')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">销售管理</font></td>
    <td width="26%"><div id="g_4_A" class="jd">6</div></td>
  </tr>
</table>

<div id="g_4" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Sales/KNet_Sales_ClientList_Manger.aspx?Css1=Div22" target="main">客户管理</a><b>|</b><a href="../web/Sales/KNet_Sales_ClientList_Add.aspx?Css2=Div22" target="main">添加</a></td>
  </tr>
    <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Sales/KNet_Sales_LinkMan_List.aspx" target="main">联系人管理</a><b>|</b><a href="../web/Sales/KNet_Sales_LinkMan_add.aspx?Css2=Div22" target="main">添加</a></td>
  </tr>
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/Knet_Sales_BaoPrice_Manage.aspx?Css1=Div22"  target="main">报价管理</a><b>|</b><a href="../web/Sales/Knet_Sales_BaoPrice_Manage_Add.aspx?Css5=Div22" target="main">添加</a></td>
  </tr>
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/KNet_Sales_ContractList_Manage.aspx?Css1=Div22"  target="main">合同管理</a><b>|</b><a href="../web/Sales/KNet_Sales_ContractList_Manage_Add.aspx?Css5=Div22" target="main">添加</a></td>
  </tr>

  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales_Check/KNet_Sales_ContractList_Manage.aspx?Css1=Div22"  target="main">合同执行情况表</a></td>
  </tr>
  
    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/Knet_Sales_Ship_Manage_Manage.aspx?Css1=Div22"  target="main">发货通知</a><b>|</b><a href="../web/Sales/Knet_Sales_Ship_Manage_Add.aspx?Css5=Div22" target="main">添加</a></td>
  </tr>

    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/Sales_ShipWareOut_Manage.aspx"  target="main">发货出库</a><b>|</b><a href="../web/Sales/Sales_ShipWareOut_Add.aspx?Css5=Div22" target="main">添加</a></td>
    </tr>
  
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/Knet_Sales_Retrun_Manage_Manage.aspx?Css1=Div22"  target="main">退货管理</a><b>|</b><a href="../web/Sales/Knet_Sales_Retrun_Manage_Add.aspx?Css5=Div22" target="main">添加</a></td>
  </tr>
  
  
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/KNet_WareHouse_DirectInto_Manage.aspx?Css1=Div22"  target="main">退货入库</a><b>|</b><a href="../web/Sales/KNet_WareHouse_DirectInto_Add.aspx?Css5=Div22" target="main">添加</a></td>
  </tr>
  

    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sale_Fp/Sales_Fp_List.aspx"  target="main">销售发票</a><b>|</b><a href="../web/Sale_Fp/Sales_Fp_Add.aspx?Css5=Div22" target="main">添加</a></td>
    </tr>
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales_Check/Sales_ShipCheck_List.aspx"  target="main">销售对账</a><b>|</b><a href="../web/Sales_Check/Sales_ShipCheck_Add.aspx" target="main">添加</a></td>
  </tr>
     <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/A_CostManagementDB.aspx?Css1=Div22"  target="main">销售费用管理</a></td>
  </tr>
  
  
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Sales/KNet_Sales_BasisSetting_Class.aspx?Css1=Div22" target="main">销售管理设置</a></td>
  </tr>
  
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Report/Xs_Report_Base.aspx?Css1=Div22" target="main">销售统计报表</a></td>
  </tr>
</table>
</div>



<!--研发平台 -->


<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"   id="LcogM" runat="server"  onClick="collapse('g_9')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">研发平台</font></td>
    <td width="26%"><div id="g_9_A" class="jd">6</div></td>
  </tr>
</table>




<div id="g_9" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Products/KnetProductsSpec_List.aspx"  target="main">产品规格书</a><b>|</b><a href="../web/Products/KnetProductsSpec_Add.aspx" target="main">添加</a></td>
  </tr>
</table>
</div>
<!--售后服务管理 -->

<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"   id="Table1" runat="server"  onClick="collapse('g_10')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">售后管理</font></td>
    <td width="26%"><div id="g_10_A" class="jd">6</div></td>
  </tr>
</table>
<div id="g_10" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
     <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_Ownall_New.aspx" target="main">库存总账台</a></td>
  </tr>
  
    <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_Ownall_Water_New.aspx" target="main">库存流水账</a></td>
  </tr>
  
  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/ProductsModel/KnetProductsSetting.aspx"  target="main">样品管理</a><b>|</b><a href="../web/ProductsModel/KnetProductsSetting_Add.aspx?Css5=Div22" target="main">添加</a></td>
  </tr>
      <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_DirectInto_Manage.aspx?Css1=Div22" target="main">直接入库</a><b>|</b><a href="../web/WareHouse/KNet_WareHouse_DirectInto_Add.aspx?Css2=Div22" target="main">开单</a></td>
  </tr>
  
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/Knet_Sales_Retrun_Manage_Manage.aspx?Css1=Div22"  target="main">退货管理</a><b>|</b><a href="../web/Sales/Knet_Sales_Retrun_Manage_Add.aspx?Css5=Div22" target="main">添加</a></td>
  </tr>
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Sales/KNet_WareHouse_DirectInto_Manage.aspx?Css1=Div22"  target="main">退货入库</a><b>|</b><a href="../web/Sales/KNet_WareHouse_DirectInto_Add.aspx?Css5=Div22" target="main">添加</a></td>

     <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_DirectOut_Manage.aspx?Css1=Div22" target="main">直接出库</a><b>|</b><a href="../web/WareHouse/KNet_WareHouse_DirectOut_Add.aspx?Css2=Div22" target="main">开单</a></td>
  </tr>

  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/WareHouse/KNet_WareHouse_AllocateList_Manage.aspx?Css1=Div22" target="main">库间调拨</a><b>|</b><a href="../web/WareHouse/KNet_WareHouse_AllocateList_Add.aspx?Css2=Div22" target="main">添加</a></td>
  </tr>
  
  </tr>
  
</table>
</div>
    

<!--财务管理 -->
<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"    id="LcogF" runat="server"   onClick="collapse('g_5')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">财务管理</font></td>
    <td width="26%"><div id="g_5_A" class="jd">6</div></td>
  </tr>
</table>

<div id="g_5" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../Web/TransferCheque/Xs_Transfer_Cheque_List.aspx" target="main">支出管理</a><b>|</b><a href="../Web/TransferCheque/Xs_Transfer_Cheque_Add.aspx" target="main">添加</a></td>
  </tr>
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../Web/Financecenter/Cash_BankDetail.aspx?Css1=Div22" target="main">现金银行管理</a></td>
  </tr>
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Financecenter/SalesReceivables_Manger.aspx?Css1=Div22"  target="main">销售回款管理</a></td>
  </tr>
  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Financecenter/SalesReturn_Manger.aspx?Css1=Div22"  target="main">销售退货付款</a></td>
  </tr>
  
   <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Financecenter/A_Deliveryfa.aspx?Css1=Div22"  target="main">销售结账情况</a></td>
  </tr>
  
  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Financecenter/ProcureReceive_Manger.aspx?Css1=Div22"  target="main">采购付款管理</a></td>
  </tr>
    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Financecenter/ProcureReturn_Manger.aspx?Css1=Div22"  target="main">采购退货回款</a></td>
  </tr>

      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Financecenter/Transport_Manger.aspx?Css1=Div22"  target="main">运输分担付款</a></td>
  </tr>
   <!--<tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="..Wage_Detail.aspx?Css1=Div22"  target="main">员工工资管理</a></td>
  </tr>
  
    -->   
       <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../Web/Financecenter/ZRepayment_Detail.aspx?Css1=Div22"  target="main">借款还款管理</a></td>
  </tr>
</table>
</div>



<!--统计报表 -->

<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"     id="LcogG" runat="server"  onClick="collapse('g_6')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">统计报表</font></td>
    <td width="26%"><div id="g_6_A" class="jd">6</div></td>
  </tr>
</table>


<div id="g_6" >
<table  width="80%"  border="0" align="center"  cellspacing="0" cellpadding="0">
  
  <tr>
    <td height="22" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/StatAnalysis/Procure_AllDetail.aspx?Css1=Div22"  target="main">采购入库统计</a></td>
  </tr>
  
  <tr>
    <td width="16%" height="22" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/StatAnalysis/WareHouse_AllDetail.aspx?Css1=Div22" target="main">库存管理统计</a></td>
  </tr>


  
  
<tr>
    <td height="22" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/StatAnalysis/Sales_AllDetail.aspx?Css1=Div22"  target="main">销售管理统计</a></td>
  </tr>
  
   <tr>
    <td height="22" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/StatAnalysis/Finance_AllDetail.aspx?Css1=Div22"  target="main">财务收付统计</a></td>
  </tr>
  
     <tr>
    <td height="22" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/StatAnalysis/Finance_BlankList.aspx?Css1=Div22"  target="main">银行账流统计</a></td>
  </tr>
 

  
</table>
</div>



<!--人力资源 -->
<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"     id="LcogH" runat="server"   onClick="collapse('g_7')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">人力资源</font></td>
    <td width="26%"><div id="g_7_A" class="jd">6</div></td>
  </tr>
</table>

<div id="g_7" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">

  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/HR/KNet_OrganizationalStructure.aspx" target="main">企业组织架构</a></td>
  </tr>
  
  
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/HR/KNet_HR_Manage.aspx" target="main">企业人事管理</a></td>
  </tr>
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/HR/KNet_AttenDance_OutManger.aspx?KCss=AA"  target="main">内部考勤管理</a></td>
  </tr>
</table>
</div>

<!--系统设置 -->



<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"     id="Table2" runat="server"  onClick="collapse('g_11')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">文档中心</font></td>
    <td width="26%"><div id="g_11_A" class="jd">6</div></td>
  </tr>
</table>




<div id="g_11" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/Document/Knet_Document_List.aspx" target="main">文档中心</a><b>|</b><a href="../web/Document/Knet_Document_Add.aspx" target="main">添加</a></td>
  </tr>
</table>
</div>
    
    
    
<table width="90%"   border="0" align="center" cellpadding="0" cellspacing="0" style="cursor:pointer;cursor:hand;background:url(../images/menu_1.gif) no-repeat;"     id="LcogK" runat="server"  onClick="collapse('g_8')">
  <tr>
    <td width="35" align="left">&nbsp;</td>
    <td height="30" align="left"><font size="2">系统设置</font></td>
    <td width="26%"><div id="g_8_A" class="jd">6</div></td>
  </tr>
</table>




<div id="g_8" >
<table width="80%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/System/Config.aspx" target="main">系统参数设置</a></td>
  </tr>
 <tr>
    <td width="16%" height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td width="84%" align="left">&nbsp;<a href="../web/System/CeareData.aspx" target="main">系统初始化</a></td>
  </tr>
  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/System/BasisSetting_Units.aspx?Css1=ww"  target="main">基础设置管理</a></td>
  </tr>
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/System/KnetWarehouse.aspx"  target="main">仓库设置管理</a></td>
  </tr>
  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/System/KnetProductsSetting.aspx"  target="main">产品字典管理</a></td>
  </tr>
  
      <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/System/KnetUserGroup.aspx"  target="main">用户组及权限</a></td>
  </tr>
  
    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/System/KnetUserAuthorityList.aspx"  target="main">用户权限设置</a></td>
  </tr>
  
  <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/System/KnetWarehouse_ToAuth.aspx"  target="main">仓库受权分配</a></td>
  </tr>
    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/System/logs.aspx"  target="main">系统操作日志</a></td>
  </tr>
  
    <tr>
    <td height="24" align="right"><img src="../images/mrr.gif" width="13" height="13" /></td>
    <td align="left">&nbsp;<a href="../web/Message/System_Message_Manage.aspx"  target="main">短消息管理</a></td>
  </tr>
</table>
</div>
    
    
    
    
    
    
</td>
  </tr>
  <tr>
    <td align="center" valign="top" ><img src="../images/menu_bot.gif" width="145" height="14" /></td>
  </tr>
</table>

<div id="StaffCatalogueDiv" runat="server"></div>



</form>
</body>
</html>
