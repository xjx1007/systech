  <%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_OpenBilling_Print.aspx.cs" Inherits="Web_Sales_Knet_Procure_OpenBilling_Print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <link rel="stylesheet" href="../../../themes/softed/style_cn.css" type="text/css" />
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png"/>
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
        .auto-style1 {
            height: 36px;
        }
    </style>
    <title>查看订单</title>
</head>
<body style="zoom: 1.1">
    
    <form id="form1" runat="server">
   <%-- <asp:Button ID="Button1" runat="server" Text="导出Word"  OnClick="Button1_OnClick" />--%>
        <div id="tMater">
            <table id="table6" align="center" border="0" cellpadding="0" cellspacing="0"
                width="95%">
                <tr>
                    <td width="100%">
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
                                <td align="left" rowspan="2" valign="top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20"></td>
                                <td align="left" valign="top">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="100%">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" class="ke-zeroborder"
                            width="95%">
                              <tr>
                                <td width="100%">
                                    <div align="left">
                                        <font size="3"><strong>P-QP-016-002</strong></font>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%">
                                    <div align="center">
                                        <font size="5"><strong>杭州士腾科技有限公司<br/>
                                            采购订单</strong></font>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="100%">
                        <table align="center" border="0" cellpadding="0" cellspacing="2" class="ke-zeroborder"
                            style="font-size: 15pt;" width="95%">
                            <tr>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="zoom" class="init_font">

            <b>
                <table id="table2" align="center" border="0" cellpadding="0" cellspacing="0"
                    width="95%">
               
                    <tr>
                        <td width="100%">
                            <table id="table_1" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                                style="font-size: 15pt; " width="95%">
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
                                        <asp:Label runat="server" ID="Lbl_SuppNo"></asp:Label>（供方） 
                                    </td>
                                    <td width="163">FROM:</td>
                                    <td width="365">
                                        <asp:Label runat="server" ID="Lbl_FromDetails"></asp:Label>（需方）</td>
                                </tr>
                                <tr>
                                    <td width="163">联系人:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_ToPepole"></asp:Label>
                                    </td>
                                    <td width="163">联系人:</td>
                                    <td width="365">
                                        <asp:Label runat="server" ID="Lbl_FromPepole"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="163">TEL:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_Tel"></asp:Label></td>
                                    <td width="163">TEL:</td>
                                    <td width="365">
                                        <asp:Label runat="server" ID="Lbl_FromTel"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="163">手机:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_Tel1"></asp:Label></td>
                                    <td width="163">手机:</td>
                                    <td width="365">
                                        <asp:Label runat="server" ID="Lbl_FromTel1"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="163">FAX:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_Fax"></asp:Label></td>
                                    <td width="163">FAX:</td>
                                    <td width="365">0571-87672166</td>
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
                                    <td width="163">付款条件:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_PayFor"></asp:Label></td>
                                    <td width="163">OEM订单号:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_FOrderNo"></asp:Label></td>
                                </tr>
                            </table>
                            <br />
                            <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0"
                                width="95%">
                                <tr>
                                    <td width="163">订购产品:</td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table id="table_2" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                                width="95%">
                                <tr>
                                    <td nowrap align="center">序号</td>
                                    <td align="center" nowrap>分类</td>
                                    <td nowrap align="center">料号</td>
                                    <td nowrap align="center">规格</td>
                                    <td nowrap align="center">版本号</td>
                                    <td nowrap align="center">品牌</td>
                                    <td nowrap align="center">单位</td>
                                    <td nowrap align="center">数量</td>
                                    <td nowrap align="center" width="50px">单价</td>
                                    <td nowrap align="center" width="50px" runat="server" id="PC">赔偿单价</td>
                                    <td nowrap align="center" width="50px" runat="server" id="Hnad">加工单价</td>
                                    <td nowrap align="center" width="50px">总金额</td>
                                   <%-- <td nowrap align="center" width="50px">未税金额</td>--%>
                                    <td nowrap align="center">备注</td>
                                </tr>
                                <%=s_MyTable_Detail %>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table id="table3" align="center" border="0" cellpadding="3" cellspacing="0" class="print1"
                                width="95%">
                                <tr>
                                    <td align="center" width="70px">
                                        <b>合  计</b></td>
                                    <td colspan="8">
                                        <span style="text-align: right">
                                            <asp:Label runat="server" ID="Lbl_AllCount"></asp:Label>
                                            </span>
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
                                        <b>备  注</b></td>
                                    <td class="left" colspan="8">
                                        <br />
                                        <asp:Label runat="server" ID="Lbl_Remarks"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            
                                        <div style="position: relative; width: 100%; height: 100%">
                                            
                                            
                                    <div style="position:absolute;top: 220px; left: 80px;" > <asp:Image ID="img1" runat="server"  ImageUrl="/Web/CG/Order/123.png" Width="4.27cm" Height="4.31cm" /></div>
                                        </div>
                            <table id="table4" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                                width="95%">
                                <tr>
                                    <td>为顺利执行采购双方协商达成如下条款：<br />
                                        （一）、本订单需方在ERP邮件至供方指定邮箱，供方于24小时内确认，并盖章邮件回传；如无任何确认，将视同接受本单所载之内容。若有疑问，请与需方采购人员联络；
                        <br />

                                        （二）、交货期为到货日期，供方应充分预留物流时间；
                        <br />

                                        （三）、供方应随货附上出货单、产品检验报告及产品合格证明书；
                        <br />

                                        （四）、供方出货时务必将本订单号码、品名、料号在出货单上注明；
                        <br />

                                        （五）、若因品质不符或延迟交货致使需方蒙受损失者，供方应付一切之责任。又因潜在瑕疵而日后发生货品变质或损害亦同。逾期未交货者，需方视状况渐行取消本订单
                        <br />

                                        （六）、需方确认采购之货品，未经需方书面许可，供方不得转包其他厂商；各项设计蓝图，稿件若有外泄，供方须承担一切责任并赔偿需方一切损失。
                        <br />

                                        （七）、若需方发现供方物料出现品质问题，供方在接获通知单后，2日内须派员工至本厂处理，应逾期造成的需方的损失，需方将追究供方责任。
                        <br />

                                        （八）、交货日期是指收货方收到货物的日期,若供方未按双方确认的交货日期及时将货物交付至此定单指定的地点，每延误一天按订单总额的0.2%计收罚金。 
                               <%--  <br />
                                        （九）:交货期为到货日期，供方应充分预留物流时间。 
                                                                         <br />
                                        （十）:在生产过程当中，如造成产品报废，需按照协议照价赔偿。--%>
                                        
                            
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table id="table5" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                                width="100%">
                                <tr>
                                    <td width="50%">
                                        <table width="100%">
                                            <tr>
                                                <td align="right" width="10%" class="auto-style1">制单人：
                                                </td>
                                                <td width="40%" class="auto-style1">
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
                        </td>
                    </tr>
                </table>
            </b>
        </div>
    </form>
</body>
</html>

