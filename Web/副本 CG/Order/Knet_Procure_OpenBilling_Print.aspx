<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_OpenBilling_Print.aspx.cs" Inherits="Web_Sales_Knet_Procure_OpenBilling_Print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=utf-8"/>
    <link rel="stylesheet" href="../../../themes/softed/style_cn.css" type="text/css" />
    <style type="text/css">
        TABLE.print {
            vertical-align: middle;
            BORDER-RIGHT: #000000 1px solid;
            BORDER-TOP: #000000 1px solid;
            BORDER-LEFT: #000000 1px solid;
            BORDER-BOTTOM: #000000 1px solid;
            BORDER-COLLAPSE: collapse;
        }

            TABLE.print TD {
                BORDER-RIGHT: #000000 1px solid;
                PADDING-RIGHT: 5px;
                BORDER-TOP: #000000 1px solid;
                PADDING-LEFT: 5px;
                FONT-SIZE: 15px;
                BORDER-LEFT: #000000 1px solid;
                LINE-HEIGHT: 20px;
                BORDER-BOTTOM: #000000 1px solid;
            }

            TABLE.print .right {
                TEXT-ALIGN: right;
            }

        TABLE.print1 {
            vertical-align: middle;
            BORDER-RIGHT: #000000 1px solid;
            BORDER-TOP: #000000 0px solid;
            BORDER-LEFT: #000000 1px solid;
            BORDER-BOTTOM: #000000 1px solid;
            BORDER-COLLAPSE: collapse;
        }

            TABLE.print1 TD {
                BORDER-RIGHT: #000000 1px solid;
                PADDING-RIGHT: 5px;
                BORDER-TOP: #000000 0px solid;
                PADDING-LEFT: 5px;
                FONT-SIZE: 15px;
                BORDER-LEFT: #000000 1px solid;
                LINE-HEIGHT: 20px;
                BORDER-BOTTOM: #000000 1px solid;
            }

            TABLE.print1 .right {
                TEXT-ALIGN: right;
            }

        .init_font {
            FONT-SIZE: 12px;
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
        }

        .STYLE1 {
            font-family: "黑体";
            line-height: 30px;
            font-size: 20px;
        }
    </style>
    <title>查看订单</title>
    <script language="javascript" src="../../Js/LodopFuncs.js" charset="utf-8"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0" height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>
<body style="zoom: 1.1">
    <form id="form1" runat="server">
        <div id="tMater">
            <br />

            <b>
                <table align="center" border="0" cellpadding="0" cellspacing="0" class="ke-zeroborder" width="95%">
                    <tr>
                        <td height="0" width="0"></td>
                        <td width="153"></td>
                        <td width="232"></td>
                        <td width="232"></td>
                    </tr>
                    <tr>
                        <td height="9"></td>
                        <td colspan="2"></td>
                        <td align="left" rowspan="2" valign="top">
                            <img alt="logo中1-2" height="29" src="../../../images/士兰微芯片订单_22424_image003.png" v:shapes="Picture_x0020_5"
                                width="232" /></td>
                    </tr>
                    <tr>
                        <td height="20"></td>
                        <td align="left" valign="top">
                            <img alt="logo英1-2" height="20" src="../../../images/士兰微芯片订单_22424_image004.png" v:shapes="Picture_x0020_3"
                                width="153" /></td>
                    </tr>
                </table>
                <table align="center" border="0" cellpadding="0" cellspacing="0" class="ke-zeroborder"
                    width="95%">
                    <tr>
                        <td width="100%">
                            <div align="center">
                                <span class="STYLE1" style="font-size: 15pt; font-family: 黑体"><strong>采购订单</strong></span>
                            </div>
                        </td>
                    </tr>
                </table>
                <table align="center" border="0" cellpadding="0" cellspacing="2" class="ke-zeroborder"
                    style="font-size: 15pt; font-family: 黑体" width="95%">
                    <tr>
                    </tr>
                </table>
                <br />
                <div id="zoom" class="init_font">
                    <table id="table_1" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                        style="font-size: 15pt; font-family: 黑体" width="95%">
                        <tr>
                            <td align="left" width="10%">订单编号:</td>
                            <td align="left" width="30%">
                                <asp:Label runat="server" ID="Lbl_Code"></asp:Label></td>
                            <td align="left" width="10%">订单日期</td>
                            <td align="left" width="30%">
                                <asp:Label runat="server" ID="Lbl_Stime"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="163">TO:</td>
                            <td width="284">
                                <asp:Label runat="server" ID="Lbl_SuppNo"></asp:Label>
                            </td>
                            <td width="163">FROM:</td>
                            <td width="365">
                                <asp:Label runat="server" ID="Lbl_FromDetails"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="163">TEL:</td>
                            <td width="284">
                                <asp:Label runat="server" ID="Lbl_Tel"></asp:Label></td>
                            <td width="163">TEL:</td>
                            <td width="365">0571-88210386
                            </td>
                        </tr>
                        <tr>
                            <td width="163">FAX:</td>
                            <td width="284">
                                <asp:Label runat="server" ID="Lbl_Fax"></asp:Label></td>
                            <td width="163">FAX:</td>
                            <td width="365">0571-88216187</td>
                        </tr>
                        <tr>
                            <td width="163">E-MAIL:</td>
                            <td width="284">
                                <asp:Label runat="server" ID="Lbl_Email"></asp:Label></td>
                            <td width="163">E-MAIL:</td>
                            <td width="365">
                                <asp:Label runat="server" ID="Lbl_FromEmail"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="163">OEM订单号:</td>
                            <td width="284">
                                <asp:Label runat="server" ID="Lbl_FOrderNo"></asp:Label></td>
                        </tr>
                    </table>

                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="ke-zeroborder" width="95%">
                        <tr>
                            <td>
                                <p>
                                    尊敬的<span style="line-height: normal; font-family: Arial, Helvetica, sans-serif"><asp:Label runat="server" ID="Lbl_Person"></asp:Label>
                                    </span>
                                    ：您好！现将我司定购产品告知如下，请按交货期出货：
                                </p>
                            </td>
                        </tr>
                    </table>
                    <table id="table_2" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                        width="95%">
                        <tr>
                            <td nowrap align="center">序号</td>
                            <td align="center" nowrap>名称</td>
                            <td nowrap align="center">料号</td>
                            <td nowrap align="center">规格</td>
                            <td nowrap align="center">版本号</td>
                            <td nowrap align="center">数量</td>
                            <td nowrap align="center">单价</td>
                            <td nowrap align="center">加工费</td>
                            <td nowrap align="center">总金额</td>
                            <td nowrap align="center">备注</td>
                        </tr>
                        <%=s_MyTable_Detail %>
                    </table>
                    <table id="table3" align="center" border="0" cellpadding="3" cellspacing="0" class="print1"
                        width="95%">
                        <tr>
                            <td align="center" width="70px">
                                <b>合  计</b></td>
                            <td colspan="8">
                                <span style="text-align: right">
                                    <asp:Label runat="server" ID="Lbl_AllCount"></asp:Label></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <b>交货日期</b></td>
                            <td colspan="8">
                                <asp:Label runat="server" ID="Lbl_PreTime"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <b>交货地址</b></td>
                            <td class="left" colspan="8">
                                <asp:Label runat="server" ID="Lbl_Address"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <b>生产说明</b></td>
                            <td class="left" colspan="8">
                                <asp:Label runat="server" ID="Lbl_ScDetails"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <b>参  数</b></td>
                            <td class="left" colspan="8">
                                <asp:Label runat="server" ID="Lbl_ProductsDetails"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <b>备  注</b></td>
                            <td class="left" colspan="8">
                                <br />
                                <asp:Label runat="server" ID="Lbl_Remarks"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table id="table4" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                        width="95%">
                        <tr>
                            <td>为顺利执行采购双方协商达成如下条款：<br />
                                （一）:出货时请务必将本订单号码在出货单、发票备注栏及所有文件上注明。
                        <br />

                                （二）:请随货附上产品检验报告及产品合格证明书。
                        <br />

                                （三）:若因品质不符或延迟交货致使本公司蒙受损失者，贵公司应付一切之责任。又因潜在瑕疵而日后发生货品变质或损害亦同。逾期未交货者，本公司得 视状况渐行取消之。
                        <br />

                                （四）:贵公司所承认之货品，非经本公司书面之许可，不得转包其他厂商。各项设计蓝图，稿件若有外泄，致影响本公司权益者，须赔偿本公司一切损失。
                        <br />

                                （五）:若有不良品，贵公司在接获通知单后，3日内须派员工至本厂处理，逾期本公司不负保管之责。
                        <br />

                                （六）:交货日期是指收货方收到货物的日期,若供货方未按双方确认的交货日期及时将货物交付至此定单指定的地点，每延误一天按订单总额的0.2%计收罚金。
                        <br />

                                （七）:本定单请于24小时内确认，并传真签回；如无任何确认，将视同接受本单所载之内容。若有疑问，请与采购人员联络。
                        <br />

                                （八）:交货期为到货日期，请充分预留物流时间。
                                 <br />

                                （九）:产品符合RoHS标准。
                            
                            </td>
                        </tr>
                    </table>
                    <br />

                    <table id="table5" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                        width="100%">
                        <tr>
                            <td width="50%">
                                <div style="position:relative;width:100%;height:100%" >
                                    <div style="position:absolute;top: 60px; left: 80px;" > <asp:Image ID="img1" runat="server"  ImageUrl="/Web/CG/Order/士腾印章等比.png" Width="4.27cm" Height="4.31cm" /></div>

                                </div>
                                <table width="100%" >
                                    <tr>
                                        <td align="right" height="36" width="10%">制单人：
                                        </td>
                                        <td width="40%">
                                            <asp:Label runat="server" ID="Lbl_Staff"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td align="right" height="36" width="10%">审核：
                                        </td>
                                        <td width="40%">
                                            <asp:Label runat="server" ID="Lbl_ShStaff"></asp:Label></td>
                                    </tr>



                                    <tr>
                                        <td align="right" height="36" width="10%">签章：
                                        </td>
                                        <td width="40%">__________________</td>
                                    </tr>
                                </table>
                            </td>
                            <td width="50%">

                                <table width="100%">

                                    <tr>
                                        <td align="right" height="36" width="20%">供应商确认：
                                        </td>
                                        <td width="30%">__________________</td>
                                    </tr>
                                    <tr>

                                        <td align="right" height="36" width="20%">供应商审核：
                                        </td>
                                        <td width="30%">__________________</td>
                                    </tr>
                                    <tr>

                                        <td align="right" height="36" width="20%">供应商签章：
                                        </td>
                                        <td width="30%">__________________</td>
                                    </tr>
                                </table>

                            </td>
                        </tr>

                    </table>
            </b>
        </div>

    </form>
</body>
</html>
<%--收货单信息  结束--%>

