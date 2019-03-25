<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_Sampling_View.aspx.cs" Inherits="Web_Products_Procure_Sampling_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <link rel="stylesheet" href="../../themes/softed/style_cn.css" type="text/css" />
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
    <title>查看出入库单</title>
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
                             <%-- <tr>
                                <td width="100%">
                                    <div align="left">
                                        <font size="3"><strong>P-QP-016-002</strong></font>
                                    </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="100%">
                                    <div align="center">
                                        <font size="5"><strong>杭州士腾科技有限公司<br/>
                                            请购入库单</strong></font>
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
                                    <td align="left" width="10%">日期:</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Lbl_Code"></asp:Label></td>
                                    <td align="left" width="10%">制单人</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Lbl_Stime"></asp:Label>
                                    </td>
                                </tr>
                                
                            </table>
                            <br />
                            <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0"
                                width="95%">
                                <tr>
                                    <td width="163">入库产品:</td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table id="table_2" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                                width="95%">
                                <tr>
                                    <%--<td nowrap align="center">序号</td>
                                    <td align="center" nowrap>分类</td>--%>
                                    <td nowrap align="center">序号</td>
                                    <td nowrap align="center">入库单号</td>
                                    <td nowrap align="center">部门</td>
                                    <td nowrap align="center">供应商</td>
                                    <td nowrap align="center">入库仓库</td>
                                    <td nowrap align="center">品名</td>
                                    <td nowrap align="center">数量</td>
                                    <td nowrap align="center" width="50px">单价</td>
                                    <td nowrap align="center" width="50px">金额</td>
                                   <%-- <td nowrap align="center" width="100px">备注</td>--%>
                                    <%--<td nowrap align="center" width="50px">总金额</td>--%>
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
                                
                            </table>
                        </td>
                    </tr>
                   
                   
                </table>
            </b>
        </div>
         <div id="tMater1">
            <table id="table7" align="center" border="0" cellpadding="0" cellspacing="0"
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
                             <%-- <tr>
                                <td width="100%">
                                    <div align="left">
                                        <font size="3"><strong>P-QP-016-002</strong></font>
                                    </div>
                                </td>
                            </tr>--%>
                            <tr>
                                <td width="100%">
                                    <div align="center">
                                        <font size="5"><strong>杭州士腾科技有限公司<br/>
                                            请购出库单</strong></font>
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
                <table id="table" align="center" border="0" cellpadding="0" cellspacing="0"
                    width="95%">
               
                    <tr>
                        <td width="100%">
                            <table id="tables_2" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                                style="font-size: 15pt; " width="95%">
                                <tr>
                                    <td align="left" width="10%">日期:</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Label1"></asp:Label></td>
                                    <td align="left" width="10%">制单人:</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Label2"></asp:Label>
                                    </td>
                                </tr>
                                
                            </table>
                            <br />
                            <table id="tables1" align="center" border="0" cellpadding="0" cellspacing="0"
                                width="95%">
                                <tr>
                                    <td width="163">出库产品:</td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table id="table_3" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                                width="95%">
                                <tr>
                                    <%--<td nowrap align="center">序号</td>
                                    <td align="center" nowrap>分类</td>--%>
                                    <td nowrap align="center">序号</td>
                                    <td nowrap align="center">入库单号</td>
                                    <td nowrap align="center">部门</td>
                                    <td nowrap align="center">供应商</td>
                                    <td nowrap align="center">出库仓库</td>
                                    <td nowrap align="center">品名</td>
                                    <td nowrap align="center">数量</td>
                                    <td nowrap align="center" width="50px">单价</td>
                                    <td nowrap align="center" width="50px">金额</td>
                                   <%-- <td nowrap align="center" width="100px">备注</td>--%>
                                    <%--<td nowrap align="center" width="50px">总金额</td>--%>
                                    <td nowrap align="center">备注</td>
                                </tr>
                                <%=s_MyTable_Detail %>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table id="tables3" align="center" border="0" cellpadding="3" cellspacing="0" class="print1"
                                width="95%">
                                <tr>
                                    <td align="center" width="70px">
                                        <b>合  计</b></td>
                                    <td colspan="8">
                                        <span style="text-align: right">
                                            <asp:Label runat="server" ID="Label3"></asp:Label>
                                            </span>
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
