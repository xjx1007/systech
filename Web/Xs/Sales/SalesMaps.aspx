<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesMaps.aspx.cs" Inherits="Web_Sales_SalesMaps" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>销售导航</title>
</head>
<body>
    <form id="form1" runat="server">
   <!-- PUBLIC CONTENTS STARTS-->
<div id="ListViewContents" class="small" style="width:80%;position:relative;">
	<table width='780' border=0>
	<tr><td align="center"><img src="/themes/images/sal_01.jpg" border="0"><br>
	<img src="/themes/images/sal_02.jpg" border="0"><br>
	<img src="/themes/images/sal_03.jpg" border="0" usemap='#Map'>
	<td></tr>
	<tr class='lvtColDataHover'>
	<td align="center"><font size="5"><b></b></font></td>
	</tr>
	</table>
	<map name='Map' id='Map'>
<area shape='rect' coords='140, 8, 220, 100' href='../SalesOpp/Xs_Sales_Opp_List.aspx' />
<area shape='rect' coords='360, 8, 440, 100' href='../SalesContract/KNet_Sales_ContractList_Manage.aspx' />
<area shape='rect' coords='565, 8, 645, 100' href='../SalesShip/Knet_Sales_Ship_Manage_Manage.aspx' />
</map>
</div>
    </form>
</body>
</html>
