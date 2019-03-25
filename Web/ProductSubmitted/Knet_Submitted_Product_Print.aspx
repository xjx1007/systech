<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Submitted_Product_Print.aspx.cs" Inherits="Web_ProductSubmitted_Knet_Submitted_Product_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <link rel="stylesheet" href="../../themes/softed/style_cn.css" type="text/css" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
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
                                        <font size="5"><strong>杭州士腾科技有限公司<br />
                                            送检单</strong></font>
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
                                style="font-size: 15pt;" width="95%">
                                <tr>
                                    <td align="left" width="10%">送检单号:</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Lbl_Code"></asp:Label></td>
                                    <td align="left" width="10%">采购单号</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Lbl_Order"></asp:Label>
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
                                    <td width="163">制单人:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_ToPepole"></asp:Label>
                                    </td>
                                    <td width="163">送检日期:</td>
                                    <td width="365">
                                        <asp:Label runat="server" ID="Lbl_FromPepole"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="163">检验人:</td>
                                    <td width="365" >
                                        <asp:Label runat="server" ID="Lbl_Staff"></asp:Label></td>
                                </tr>
                            </table>
                            <br />
                            <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0"
                                width="95%">
                                <tr>
                                    <td width="163">产品:</td>
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
                                    <td align="center" nowrap>料号</td>
                                    <td nowrap align="center">物料名称</td>
                                    <%--<td nowrap align="center">品牌</td>
                                    <td nowrap align="center">封装</td>
                                    <td nowrap align="center">品牌</td>--%>
                                    <td nowrap align="center">规格型号</td>
                                    <td nowrap align="center">送检数量</td>
                                    <td nowrap align="center" width="50px">抽检数量</td>
                                    <td nowrap align="center" width="50px">不良数量</td>
                                    <td nowrap align="center" width="50px">检验结果</td>
                                    <td nowrap align="center">说明</td>
                                   
                                </tr>
                                <%=s_MyTable_Detail %>
                            </table>
                        </td>
                    </tr>



                </table>
            </b>
        </div>
    </form>
</body>
</html>
