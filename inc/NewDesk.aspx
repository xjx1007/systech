<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewDesk.aspx.cs" Inherits="NewDesk"
    Title="" %>

<%@ Register Assembly="Container" Namespace="FanG" TagPrefix="cc1" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../themes/softed/style.css" type="text/css" />
    <link rel="stylesheet" href="../themes/softed/index.css" type="text/css" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=2.0, user-scalable=yes" />--%>
    <script language="javascript" type="text/javascript" src="../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../include/scriptaculous/dom-drag.js"></script>
    <script language="text/javascrip" type="text/javascript" src="../include/js/Homestuff.js"></script>
    <title></title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div id="vtbusy_homeinfo" style="display: none;">
            <img src="../themes/softed/images/vtbusy.gif" border="0">
        </div>
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" width="10%" class="moduleName"
                        nowrap>工作台&gt; <a class="hdrLink" href="NewDesk.aspx">工作台</a>
                    </td>
                    <td width="40%" nowrap>
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="sep1" style="width: 1px;"></td>
                                <td class="small">
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <table border="0" cellspacing="0" cellpadding="5">
                                                    <tr>
                                                        <td style="padding-right: 5px; padding-left: 5px;">
                                                            <img src="../themes/softed/images/btnL3Add-Faded.gif" border="0">
                                                        </td>
                                                        <td style="padding-right: 5px">
                                                            <img src="../themes/softed/images/btnL3Search-Faded.gif" border="0">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 20px;">&nbsp;
                                </td>
                                <td class="small">
                                    <table border="0" cellspacing="0" cellpadding="5">
                                        <tr>
                                            <td style="padding-right: 5px">
                                                <a href="javascript:;" onclick='return window.open("../Web/Message/System_Message_List.aspx","Chat","width=600,height=450,resizable=1,scrollbars=1");'>
                                                    <img src="../themes/softed/images/tbarChat.gif" alt="短消息..." title="短消息..." border="0"></a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 20px;">&nbsp;
                                </td>
                                <td class="small">
                                    <table border="0" cellspacing="0" cellpadding="5">
                                        <tr>
                                            <td style="padding-right: 5px; padding-left: 10px;">
                                                <img src="../themes/softed/images/tbarImport-Faded.gif" border="0">
                                            </td>
                                            <td style="padding-right: 5px">
                                                <img src="../themes/softed/images/tbarExport-Faded.gif" border="0">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 20px;">&nbsp;
                                </td>
                                <td class="small" style="display: none;">
                                    <table border="0" cellspacing="0" cellpadding="5">
                                        <tr>
                                            <td style="padding-right: 5px; padding-left: 10px;">
                                                <img onclick='fnAddWindow();' src="../themes/softed/images/btnL3CreateWindow.gif"
                                                    border="0" title="定制首页组件" alt="定制首页组件" style="cursor: pointer;">
                                            </td>
                                            <td style="padding-right: 5px">
                                                <div id="vtbusy_info" style="display: none;">
                                                    <img src="../themes/softed/images/status.gif" border="0">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <div id='createConfigBlockDiv' style='display: none; width: 80%'>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="2" cellspacing="2" border="0" class="small showPanelBg"
                align="center" valign="top">
                <tr>
                    <td width="100%" align="center" valign="top" height="300">
                        <div id="MainMatrix" style="padding: 5px; width: 100%;">
                            <div id="weekreport" class="portlet" runat="server" style="overflow-y: auto; overflow-x: hidden; height=280px; width: 98%; float: left; position: relative;">
                                <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_topper"
                                    style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                    <tr id="Tr3">
                                        <td align="left" style="height: 20px;" nowrap width="80%">
                                            <b>&nbsp;本月销售统计</b>
                                        </td>
                                        <td align="right" style="height: 20px;" width="5%">
                                            <span id="Span1" style="position: relative;">&nbsp;&nbsp;</span>
                                        </td>
                                        <td align="right" style="height: 20px;" width="15%" nowrap>
                                            <input type="hidden" id="Hidden6" value="1" />
                                            <input type="hidden" id="Hidden7" value="SalesYearTotal" />
                                            <input type="hidden" id="Hidden8" value="SalesYearTotal1" class="portlet_stufftype_value" />
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_content"
                                    style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                    <tr id="Tr4">
                                        <td>
                                            <div id="Div5" style="overflow-y: auto; overflow-x: hidden; width: 100%; height: 100%; cursor: auto;">
                                                <asp:Label runat="server" ID="Lbl_WeekTotal"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="Div1" style="padding: 5px; width: 100%;">
                                <div id="CgMonth" class="portlet" runat="server" style="overflow-y: auto; overflow-x: hidden; height=280px; width: 98%; float: left; position: relative;">
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_topper"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="Tr1">
                                            <td align="left" style="height: 20px;" nowrap width="80%">
                                                <b>&nbsp;本月采购统计</b>
                                            </td>
                                            <td align="right" style="height: 20px;" width="5%">
                                                <span id="Span2" style="position: relative;">&nbsp;&nbsp;</span>
                                            </td>
                                            <td align="right" style="height: 20px;" width="15%" nowrap>
                                                <input type="hidden" id="Hidden4" value="1" />
                                                <input type="hidden" id="Hidden5" value="SalesYearTotal" />
                                                <input type="hidden" id="Hidden9" value="SalesYearTotal1" class="portlet_stufftype_value" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_content"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="Tr2">
                                            <td>
                                                <div id="Div3" style="overflow-y: auto; overflow-x: hidden; width: 100%; height: 100%; cursor: auto;">
                                                    <asp:Label runat="server" ID="Lbl_CgDetails"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>


                                <div id="stuff_Account" class="portlet" runat="server" style="overflow-y: auto; overflow-x: hidden; height=280px; width: 32%; float: left; position: relative;">
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_topper"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="Tr5">
                                            <td align="left" style="height: 20px;" nowrap width="60%">
                                                <b>&nbsp;公司资金状况</b>
                                            </td>
                                            <td align="right" style="height: 20px;" width="5%">
                                                <span id="Span3" style="position: relative;">&nbsp;&nbsp;</span>
                                            </td>
                                            <td align="right" style="height: 20px;" width="35%" nowrap>
                                                <input type="hidden" id="Hidden10" value="1" />
                                                <input type="hidden" id="Hidden11" value="Account" />
                                                <input type="hidden" id="Hidden12" value="Account" class="portlet_stufftype_value" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_content"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="maincont_row_Account">
                                            <td>
                                                <div id="stuffcont_Account" style="overflow-y: auto; overflow-x: hidden; width: 100%; height: 100%; cursor: auto;">

                                                    <asp:Label runat="server" ID="Lbl_Account"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <script language="javascript">
                                        window.onresize = function () { positionDivInAccord('stuff_Account', '32%'); };
                                        positionDivInAccord('stuff_Account', '32%');
                                    </script>
                                </div>


                                <div id="stuff_Receive" class="portlet" runat="server" style="overflow-y: auto; overflow-x: hidden; height=280px; width: 32%; float: left; position: relative;">
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_topper"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="Tr8">
                                            <td align="left" style="height: 20px;" nowrap width="60%">
                                                <b>&nbsp;公司应收款信息</b>
                                            </td>
                                            <td align="right" style="height: 20px;" width="5%">
                                                <span id="Span5" style="position: relative;">&nbsp;&nbsp;</span>
                                            </td>
                                            <td align="right" style="height: 20px;" width="35%" nowrap>
                                                <input type="hidden" id="Hidden16" value="1" />
                                                <input type="hidden" id="Hidden17" value="Receive" />
                                                <input type="hidden" id="Hidden18" value="Receive" class="portlet_stufftype_value" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_content"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="maincont_row_Receive">
                                            <td>
                                                <div id="stuffcont_Receive" style="overflow-y: auto; overflow-x: hidden; width: 100%; height: 100%; cursor: auto;">

                                                    <asp:Label runat="server" ID="Lbl_Receive"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <script language="javascript">
                                        window.onresize = function () { positionDivInAccord('stuff_Receive', '32%'); };
                                        positionDivInAccord('stuff_Receive', '32%');
                                    </script>
                                </div>


                                <div id="stuff_Report" class="portlet" runat="server" style="overflow-y: auto; overflow-x: hidden; height=280px; width: 32%; float: left; position: relative;">
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_topper"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="headerrow_Report">
                                            <td align="left" style="height: 20px;" nowrap width="60%">
                                                <b>&nbsp;日/周/月报</b>
                                            </td>
                                            <td align="right" style="height: 20px;" width="5%">
                                                <span id="refresh_Report" style="position: relative;">&nbsp;&nbsp;</span>
                                            </td>
                                            <td align="right" style="height: 20px;" width="35%" nowrap>
                                                <input type="hidden" id="portlet_stuffid_Report" value="1" />
                                                <input type="hidden" id="portlet_stufftype_Report" value="SalesOpp" />
                                                <input type="hidden" id="Hidden3" value="Report" class="portlet_stufftype_value" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" cellpadding="0" cellspacing="0" class="small portlet_content"
                                        style="padding-right: 0px; padding-left: 0px; padding-top: 0px;">
                                        <tr id="maincont_row_Report">
                                            <td>
                                                <div id="stuffcont_Report" style="overflow-y: auto; overflow-x: hidden; width: 100%; height: 100%; cursor: auto;">

                                                    <asp:Label runat="server" ID="Lbl_ReportDetails"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <script language="javascript">
                                        window.onresize = function () { positionDivInAccord('stuff_Report', '32%'); };
                                        positionDivInAccord('stuff_Report', '32%');
                                    </script>
                                </div>
                                <asp:Label runat="server" ID="Lbl_ShowDetails"></asp:Label>

                            </div>
                    </td>
                </tr>
            </table>
            <script>
                var is_admin = "off";
                var showhomeid = "";


                initHomePage = function () {
                    Sortable.create(
        "MainMatrix",
        {
            constraint: false, tag: 'div', overlap: 'Horizontal', handle: 'portlet_topper',
            onUpdate: function () {
                //			matrixarr = Sortable.serialize('MainMatrix').split("&");
                //			matrixseqarr=new Array();
                //			seqarr=new Array();var portlet_name;
                //			var portlet_stuffid = '';var portlet_stufftype = '';
                //			for(x=0;x<matrixarr.length;x++){
                //				portlet_name = matrixarr[x].split("=")[1];
                //				portlet_stuffid = document.getElementById("portlet_stuffid_"+portlet_name).value;
                //				portlet_stufftype = document.getElementById("portlet_stufftype_"+portlet_name).value;
                //				matrixseqarr[x] = portlet_stuffid+","+portlet_stufftype;
                //			}
                //			BlockSorting(matrixseqarr);

                var inputels = $$('.portlet_stufftype_value');
                var inputelval = '';
                var searchobj = {}
                searchobj['saveportlet'] = '1';
                for (var i = 1; i <= inputels.length; i++) {
                    var inputel = inputels[i - 1];
                    inputelval = $F(inputel);
                    searchobj["portlet_stuffid_" + i] = document.getElementById("portlet_stuffid_" + inputelval).value;
                    searchobj["portlet_stufftype_" + i] = document.getElementById("portlet_stufftype_" + inputelval).value;
                }
                searchobj['for_i'] = i;
                BlockSorting(searchobj);
            }
        }
    );
                }
                if (is_admin == 'on') {
                    initHomePage();
                    //	if(showhomeid > 0){
                    //		fnAddhometemplates();	
                    //	}
                }


            </script>
        </div>
    </form>
</body>
</html>
