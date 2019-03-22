<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_ShipWareOut_Print.aspx.cs"
    Inherits="Web_Sales_Sales_ShipWareOut_Manage" %>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" src="/Web/Js/Report.js" type="text/javascript"></script>
    <script language="javascript" src="/Web/Js/LodopFuncs.js"></script>
    <title>发货单</title>
    <script language="javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            window.document.body.innerHTML = bdhtml;
        }

        var LODOP; //声明为全局变量 
        function prn1_preview() {
            CreateOneFormPage();
            LODOP.PREVIEW();
        }
        function CreateOneFormPage() {

            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("发货单");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", prnhtml);
        };

        function OutToFileMoreSheet() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("");
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", prnhtml);
            LODOP.SET_SAVE_MODE("PAGE_TYPE", 1);
            LODOP.SET_SAVE_MODE("centerHeader", "页眉");
            LODOP.SET_SAVE_MODE("centerFooter", "第&P页");
            LODOP.SET_SAVE_MODE("Caption", "发货单");
            LODOP.SET_SAVE_MODE("RETURN_FILE_NAME", 1);
            LODOP.SAVE_TO_FILE("发货单.xls");
        };

    </script>

    <link rel="stylesheet" href="/themes/softed/style_cn.css" type="text/css" />
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
                FONT-SIZE: 18px;
                BORDER-LEFT: #000000 1px solid;
                LINE-HEIGHT: 20px;
                BORDER-BOTTOM: #000000 1px solid;
            }

            TABLE.print1 .right {
                TEXT-ALIGN: right;
            }

        .init_font {
            FONT-SIZE: 14px;
        }

        .table_1 {
            BORDER-RIGHT: #000000 0px solid;
            PADDING-RIGHT: 0px;
            BORDER-TOP: #000000 0px solid;
            PADDING-LEFT: 0px;
            FONT-SIZE: 15px;
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
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0" height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>--%>
<%--<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
<script type="text/javascript" src="/Web/KDialog/lhgdialog.js"></script>--%>

<%--<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <b>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" width="983px" align="center">


                <tr height="32">
                    <td colspan="7" height="32" style="mso-ignore: colspan">
                        <b>地址：杭州西湖科技园西园九路7号综合楼四楼 - 310012<span style="mso-spacerun: yes"> </span>电话：0571-88999497-8823 <span
                            style="mso-spacerun: yes"></span>传真：0571-87672166<span
                                style="mso-spacerun: yes"> </span>发货人：<asp:Label ID="Lbl_FPerson"
                                    runat="server"></asp:Label>
                            &nbsp;电话：81061085</b></td>
                </tr>
                <tr height="56">
                    <td colspan="7" height="56">
                        <div align="center">
                            <font style="font-size: 30px"><strong>杭州士腾发货单</strong></font>
                        </div>
                    </td>
                </tr>

                <tr height="20">
                    <td height="15px" align="left" colspan="3" width="45%" nowrap style="font-size: 15px">
                        <b>发货日期：<asp:Label ID="Lbl_CKTime" runat="server"></asp:Label>
                        </b></td>

                    <td colspan="4" align="right" style="font-size: 15px">
                        <b>编号：<asp:Label ID="Lbl_Code" runat="server"></asp:Label></b></td>
                </tr>
                <tr height="30">
                    <td height="15px" align="left" colspan="7" width="45%" style="font-size: 15px">
                        <b>客户：<asp:Label ID="Lbl_Customer" runat="server"></asp:Label></b></td>
                </tr>
                <tr>
                    <td colspan="7">
                        <table id="table_2" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                            width="100%">


                            <tr height="28">
                                <td height="28" align="center" nowrap><b>项目</b></td>
                                <td align="center" nowrap><b>客户料号</b></td>
                                <td align="center" nowrap><b>客户订单号</b></td>
                                <td align="center" nowrap><b>客户型号</b></td>
                                <td align="center" nowrap><b>士腾型号</b></td>
                                <td align="center" nowrap><b>件数</b></td>
                                <td align="center" nowrap><b>发货数</b></td>
                                <td align="center" nowrap><b>备品数</b></td>
                            </tr>

                            <%=s_Tables_Details%>
                        </table>
                        </td>
        </tr>

        
       <tr>
            <td colspan="7">
                <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0"
                    width="100%">

                    <tr height="28">
                        <td>
                            <font style="font-size: 15px"><strong>收货人信息</strong></font>
                        </td>
                    </tr>
                    <tr height="28">
                        <td height="28" align="right" width="15%" style="font-size: 15px">
                            <b>收货单位：</b></td>
                        <td width="35%" align="left" style="border-bottom: #000000 1px solid; font-size: 15px"><b>
                            <asp:Label ID="Lbl_CustomerName" runat="server"></asp:Label></b>
                        </td>
                        <td align="right" width="15%" style="font-size: 15px">
                            <b>收货人：</b></td>
                        <td width="35%" align="left" style="border-bottom: #000000 1px solid; font-size: 15px"><b>
                            <asp:Label ID="Lbl_LinkMan" runat="server"></asp:Label></b>
                        </td>
                    </tr>
                    <tr height="29">
                        <td height="29" align="right" style="font-size: 15px">
                            <b>收货地址：</b></td>
                        <td align="left" style="border-bottom: #000000 1px solid; font-size: 15px"><b>
                            <asp:Label ID="Lbl_Address" runat="server"></asp:Label></b>
                        </td>
                        <td align="right" style="font-size: 15px">
                            <b>联系方式：</b></td>
                        <td align="left" style="border-bottom: #000000 1px solid; font-size: 15px"><b>
                            <asp:Label ID="Lbl_Tel" runat="server"></asp:Label></b>
                        </td>
                    </tr>

                    <tr height="28">
                        <td>
                            <font style="font-size: 15px"><strong>签收信息</strong></font>
                        </td>
                    </tr>
                    <tr height="24">
                        <td height="24" align="right" style="font-size: 15px">
                            <b>收货人签字：</b></td>
                        <td align="left" style="border-bottom: #000000 1px solid; font-size: 15px">&nbsp;</td>
                        <td height="24" align="right" style="font-size: 15px">
                            <b>日期：</b></td>
                        <td align="left" style="border-bottom: #000000 1px solid; font-size: 15px">&nbsp;</td>
                    </tr>
                    <tr height="24">
                        <td align="right">
                            <b>备注：</b></td>
                        <td colspan="3" align="left" style="border-bottom: #000000 1px solid; font-size: 15px">&nbsp;<b>请您签清晰的全名，谢谢！</b>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>

            <tr>
                <td colspan="7" height="19" style="mso-ignore: colspan">
                    <b>当您收到上述货物时，请及时回传此发货单给我司（传真号：0571-87672166），谢谢合作！</b></td>
            </tr>
            </table>
        </b>

        <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="Tbx_DID" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox runat="server" ID="Tbx_Number" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

    </form>

</body>
</html>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
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
                                         <b>地址：杭州西湖科技园西园九路7号综合楼四楼 - 310012<span style="mso-spacerun: yes"> </span>电话：0571-88999497-8823 <span
                            style="mso-spacerun: yes"></span>传真：0571-87672166<span
                                style="mso-spacerun: yes"> </span>发货人：<asp:Label ID="Lbl_FPerson"
                                    runat="server"></asp:Label>
                            &nbsp;电话：81061085</b>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td width="100%">
                                    <div align="center">
                                        <font size="5"><strong>杭州士腾科技有限公司<br/>
                                            发货单</strong></font>
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
                                    <td align="left" width="10%">发货日期:</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Lbl_CKTime"></asp:Label></td>
                                    <td align="left" width="10%">编号</td>
                                    <td align="left" width="30%">
                                        <asp:Label runat="server" ID="Lbl_Code"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="163">TO(客户):</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_Customer"></asp:Label> 
                                    </td>
                                    <td width="163">收货人:</td>
                                    <td width="365">
                                        <asp:Label runat="server" ID="Lbl_LinkMan"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="163">收货地址:</td>
                                    <td width="284">
                                        <asp:Label runat="server" ID="Lbl_Address"></asp:Label>
                                    </td>
                                    <td width="163">联系方式:</td>
                                    <td width="365">
                                        <asp:Label runat="server" ID="Lbl_Tel"></asp:Label></td>
                                </tr>
                    
                         
                               
                            </table>
                            <br />
                            <table id="table1" align="center" border="0" cellpadding="0" cellspacing="0"
                                width="95%">
                                <tr>
                                    <td width="163">发货产品:</td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table id="table_2" align="center" border="0" cellpadding="0" cellspacing="0" class="print ke-zeroborder"
                                width="95%">
                                <tr>
                                 <td height="28" align="center" nowrap><b>项目</b></td>
                                <td align="center" nowrap><b>客户料号</b></td>
                                <td align="center" nowrap><b>客户订单号</b></td>
                                <td align="center" nowrap><b>客户型号</b></td>
                                <td align="center" nowrap><b>士腾型号</b></td>
                                <td align="center" nowrap><b>件数</b></td>
                                <td align="center" nowrap><b>发货数</b></td>
                                <td align="center" nowrap><b>备品数</b></td>
                                </tr>
                                <%=s_MyTable_Detail %>
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
                                                <td align="right" height="36" width="20%">收货人签字：
                                                </td>
                                                <td width="30%">__________________</td>
                                            </tr>
                                            <tr>

                                                <td align="right" height="36" width="20%">备注：
                                                </td>
                                                <td width="30%">__请您签清晰全名__</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="50%">

                                        <table width="100%">

                                            
                                            <tr>

                                                <td align="right" height="36" width="20%">日期：
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
