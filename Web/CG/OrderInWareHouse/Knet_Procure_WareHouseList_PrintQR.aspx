<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_WareHouseList_PrintQR.aspx.cs"
    Inherits="Web_SalesQuotes_Xs_Sales_Quotes_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../../themes/images/style_cn.css">
    <style type="text/css">

TABLE.print {vertical-align: middle;BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BORDER-COLLAPSE: collapse

}

TABLE.print TD {

	BORDER-RIGHT: #000000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #000000 1px solid; PADDING-LEFT: 5px; FONT-SIZE: 12px; BORDER-LEFT: #000000 1px solid; LINE-HEIGHT: 20px; BORDER-BOTTOM: #000000 1px solid;

}

TABLE.print .right {

	TEXT-ALIGN: right

}

.init_font {

	FONT-SIZE: 12px

}

.table_1 {

	BORDER-RIGHT: #000000 0px solid;

	PADDING-RIGHT: 0px;

	BORDER-TOP: #000000 0px solid;

	PADDING-LEFT: 0px;

	FONT-SIZE: 12px;

	BORDER-LEFT: #000000 0px solid;

	LINE-HEIGHT: 20px;

	BORDER-BOTTOM: #000000 0px solid;

	padding-bottom: 0px;

}.STYLE1 {

	font-family: "黑体";

	line-height: 30px;

	font-size: 20px;

}</style>
    <meta name="GENERATOR" content="MSHTML 6.00.6000.16735">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
                                              <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails" style="height: 28px">

                                                    <!-- Header for the Product Details -->
                                                    <tr valign="top">
                                                        <td class="ListHead" nowrap><b>入库单号</b></td>
                                                        <td class="ListHead" nowrap><b>材料订单号</b></td>
                                                        <td class="ListHead" nowrap><b>OEM订单号</b></td>
                                                        <td class="ListHead" nowrap><b>发货日期</b></td>
                                                        <td class="ListHead" nowrap><b>送货供应商</b></td>
                                                        <td class="ListHead" nowrap><b>产品名称</b></td>
                                                        <td class="ListHead" nowrap><b>产品编码</b></td>
                                                        <td class="ListHead" nowrap><b>型号</b></td>
                                                        <td class="ListHead" nowrap><b>数量</b></td>
                                                        <td class="ListHead" nowrap><b>备料</b></td>
                                                        <td class="ListHead" nowrap><b>备注</b></td>
                                                        <td class="ListHead" nowrap><b>确认数量</b></td>
                                                    </tr>
                                                    <%=s_MyTable_Detail %>
                                                </table>
            
        </div>
    </form>
</body>
</html>
