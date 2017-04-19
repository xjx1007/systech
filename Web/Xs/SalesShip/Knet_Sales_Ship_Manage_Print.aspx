<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Sales_Ship_Manage_Print.aspx.cs" Inherits="Knet_Sales_Ship_Manage_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/themes/softed/style_cn.css" type="text/css" />
<style type="text/css">
TABLE.print {vertical-align: middle;BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BORDER-COLLAPSE: collapse
}
TABLE.print TD {
	BORDER-RIGHT: #000000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #000000 1px solid; PADDING-LEFT: 5px; FONT-SIZE: 15px; BORDER-LEFT: #000000 1px solid; LINE-HEIGHT: 20px; BORDER-BOTTOM: #000000 1px solid;
}
TABLE.print .right {
	TEXT-ALIGN: right
}
TABLE.print1 {vertical-align: middle;BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 0px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid; BORDER-COLLAPSE: collapse
}
TABLE.print1 TD {
	BORDER-RIGHT: #000000 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #000000 0px solid; PADDING-LEFT: 5px; FONT-SIZE: 15px; BORDER-LEFT: #000000 1px solid; LINE-HEIGHT: 20px; BORDER-BOTTOM: #000000 1px solid;
}
TABLE.print1 .right {
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
	FONT-SIZE: 13px;
	BORDER-LEFT: #000000 0px solid;
	LINE-HEIGHT: 20px;
	BORDER-BOTTOM: #000000 0px solid;
	padding-bottom: 0px;
}.STYLE1 {
	font-family: "黑体";
	line-height: 30px;
	font-size: 20px;
}</style>
<title>查看发货通知</title>	

    <script language="javascript" type="text/javascript">   
        var LODOP; //声明为全局变量 
	function prn1_preview() {	
		CreateOneFormPage();	
		LODOP.PREVIEW();	
	};
	function prn1_print() {		
		CreateOneFormPage();
		LODOP.PRINT();	
	};
	function prn1_printA() {		
		CreateOneFormPage();
		LODOP.PRINTA(); 	
	};	
	function CreateOneFormPage(){
		LODOP=getLodop(document.getElementById('LODOP_OB'),document.getElementById('LODOP_EM'));  
		LODOP.PRINT_INIT("采购订单");
		LODOP.SET_PRINT_STYLE("FontSize",18);
		LODOP.SET_PRINT_STYLE("Bold",1);
		LODOP.ADD_PRINT_HTM(130, 0,"100%","100%",document.getElementById("tMater").innerHTML);
	};	   
	function OutToFileMoreSheet(){
		LODOP=getLodop(document.getElementById('LODOP_OB'),document.getElementById('LODOP_EM'));  
		LODOP.PRINT_INIT("");
		LODOP.ADD_PRINT_HTM(0,0,"100%","100%",document.documentElement.innerHTML);
		LODOP.SET_SAVE_MODE("PAGE_TYPE",1);
		LODOP.SET_SAVE_MODE("centerHeader","页眉");
		LODOP.SET_SAVE_MODE("centerFooter","第&P页");
		LODOP.SET_SAVE_MODE("Caption","采购订单");					
		LODOP.SET_SAVE_MODE("RETURN_FILE_NAME",1);
		LODOP.SAVE_TO_FILE("采购订单.xls");		
	};	       
</script> 
<script language="javascript" src="/Web/Js/LodopFuncs.js"></script>
<object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width=0 height=0> 
	<embed id="LODOP_EM" type="application/x-print-lodop" width=0 height=0 pluginspage="install_lodop.exe"></embed>
</object> 
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

    <div id="tMater">
        <br />
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="0" width="0">
                                </td>
                                <td width="153">
                                </td>
                                <td width="232">
                                </td>
                                <td width="232">
                                </td>
                            </tr>
                            <tr>
                                <td height="9">
                                </td>
                                <td colspan="2">
                                </td>
                                <td align="left" rowspan="2" valign="top">
                                    </td>
                            </tr>
                            <tr>
                                <td height="20">
                                </td>
                                <td align="left" valign="top">
                                    <img alt="logo英1-2" height="20" src="/images/士兰微芯片订单_22424_image004.png" v:shapes="Picture_x0020_3"
                                        width="153" /></td>
                            </tr>
                        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" class="ke-zeroborder"
            width="100%">
            <tr>
                <td width="100%">
                    <div align="center">
                        <font style="FONT-SIZE: 30px"><strong>发货通知单</strong></font></div>
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="2" class="ke-zeroborder"
            style="font-size: 15pt; font-family: 黑体" width="100%">
            <tr>
            </tr>
        </table>
        <br />
        <div id="zoom" class="init_font">
            <table id="table_1" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                style="font-size: 15pt; font-family: 黑体" width="100%">
                <tr>
                    <td align="left" width="10%">
                        客户:</td>
                    <td align="left" width="30%">
                    <asp:Label runat="server" ID="Lbl_Customer"></asp:Label></td>
                    <td align="left" width="10%">
                        发货单号：</td>
                    <td align="left" width="30%">
                    <asp:Label runat="server" ID="Lbl_Code"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td >
                        收货联系人:</td>
                    <td width="284">
                        <asp:Label runat="server" ID="Lbl_SuppNo"></asp:Label>
                    </td>
                    <td >
                        发货联系人:</td>
                    <td width="365">
                        <asp:Label runat="server" ID="Lbl_FromDetails"></asp:Label></td>
                </tr>
                <tr>
                    <td >
                        联系方式:</td>
                    <td width="284">
                       <asp:Label runat="server" ID="Lbl_Tel"></asp:Label></td>
                    <td >
                        手机:</td>
                    <td width="365"><asp:Label runat="server" ID="Lbl_FromTel"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td >
                        电话:</td>
                    <td width="284">
                        <asp:Label runat="server" ID="Lbl_Fax"></asp:Label></td>
                    <td >
                        发货日期:</td>
                    <td width="365">
                        <asp:Label runat="server" ID="Lbl_STime"></asp:Label></td>
                </tr>
                <tr>
                    <td >
                        预计到货日期:</td>
                    <td width="284">
                        <asp:Label runat="server" ID="Lbl_PreTime"></asp:Label></td>
                    <td >
                        交货方式：</td>
                    <td width="365">
                        <asp:Label runat="server" ID="Lbl_JType"></asp:Label></td>
                </tr>
                <tr>
                    <td >
                        交货地点:</td>
                    <td >
                        <asp:Label runat="server" ID="Lbl_Address"></asp:Label></td>
                    <td >
                        客户型号:</td>
                    <td >
                        <asp:Label runat="server" ID="LBl_ShipType"></asp:Label></td>
                </tr>
                <tr>
                    <td >
                        计划单号:</td>
                    <td >
                        <asp:Label runat="server" ID="Lbl_Plan"></asp:Label></td>
                    <td >
                        发货说明:</td>
                    <td >
                        <asp:Label runat="server" ID="Lbl_FhDetails"></asp:Label></td>
                </tr>
            </table>
            <p>发货产品明细：</p>
            <table id="table_2" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                width="100%">
                <tr>
                    <td align="center"  >
                        序号</td>
                    <td align="center" >
                        名称</td>
                    <td align="center" >
                        规格</td>
                    <td align="center" >
                        单位</td>
                    <td align="center" >
                        数量</td>
                    <td align="center" >
                        备量</td>
                    <td align="center" >
                        计划单号</td>
                    <td align="center" >
                        订单号</td>
                    <td align="center" >
                       客户料号</td>
                    <td align="center" >
                        客户型号</td>
                    <td align="center" >
                       是否随货</td>
                    <td align="center" >
                        备注</td>
                </tr>
                <%=s_MyTable_Detail %>
                </table>
            <p>
               评审明细：</p>
            <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                width="100%">
                <tr>
                    <td align="center">
                        序号</td>
                    <td align="center">
                        审核人</td>
                    <td align="center">
                        所在部门</td>
                    <td align="center" >
                        审核时间</td>
                    <td align="center" >
                        审核状态</td>
                    <td align="center" >
                        审核意见</td>
                    <td align="center" >
                        指定审核人</td>
                </tr>
                <%=s_Flow_Detail %>
                </table>
            <table id="table3" align="center" border="0" cellpadding="3" cellspacing="0" class="print1"
                width="100%">
                <tr>
                    <td align="center" width="70px">
                        <b>合  计</b></td>
                    <td colspan="7">
                        <span style="text-align: right"><asp:Label runat="server" ID="Lbl_AllCount"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                       <b>备  注</b></td>
                    <td class="left" colspan="7">
                        <br /><asp:Label runat="server" ID="Lbl_Remarks"></asp:Label>
                        </td>
                </tr> 
            </table>
            
            <table id="table5" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                width="100%">
                <tr>
                    <td align="right" height="36" width="10%">
                        制单人：
                    </td>
                    <td width="40%"><asp:Label runat="server" ID="Lbl_Staff"></asp:Label></td>
                    
                    <td align="right" height="36" width="20%">
                        物料部：
                    </td>
                    <td width="30%">__________________</td>
                </tr>
                <tr>
                    <td align="right" height="36" width="10%">
                        审核：
                    </td>
                    <td width="40%">__________________</td>
                    <td align="right" height="36" width="20%">
                        仓管：
                    </td>
                    <td width="30%">__________________</td>
                </tr>
            </table>
        </div>
    
    </div>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

