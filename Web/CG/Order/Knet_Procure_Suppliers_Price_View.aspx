<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false"
    CodeFile="Knet_Procure_Suppliers_Price_View.aspx.cs" Inherits="Knet_Web_Procure_Knet_Procure_Suppliers_Price_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <title>查看供应商报价</title>
    <script language="javascript" type="text/javascript" src="../../../Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/js/ListView.js"></script>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('KNetSelectValue').value = ss[0];
                document.all('KNetSelectName').value = ss[1];
            }
            else {
                document.all('KNetSelectValue').value = "";
                document.all('KNetSelectName').value = "";
            }
        }
    </script>
    <script>
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "../../Web/Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
                send_request("GET", url, null, "text", populateClass3);
            }
        }
        function populateClass3() {
            var f = document.getElementById("SmallClass");
            if (http_request.readyState == 4) {
                if (http_request.status == 200) {
                    var list = http_request.responseText;
                    var classList = list.split("|");
                    f.options.length = 1;
                    for (var i = 0; i < classList.length; i++) {
                        var tmp = classList[i].split(",");
                        f.add(new Option(tmp[1], tmp[0]));
                    }
                } else {
                    alert("您所请求的页面有异常.");
                }
            }
        }

        function btnGetProductsTypeValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsTypeNo').value = ss[0];
                document.all('Tbx_ProductsTypeName').value = ss[1];
            }
            else {
                document.all('Tbx_ProductsTypeNo').value = "";
                document.all('Tbx_ProductsTypeName').value = "";
            }
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>供应商报价 > <a class="hdrLink" href="Knet_Procure_Suppliers_Price.aspx">供应商报价</a>
                </td>
                <td width="100%" nowrap></td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>供应商报价查看
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                            <tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td valign="top" align="left" colspan="4">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" id="Table_Btn" runat="server">
                                                    <tr>
                                                        <td colspan="3">
                                                            <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('Knet_Procure_Suppliers_Price.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;" style="height: 26px; width: 60px">
                                                            <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Procure_Suppliers_Price.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" style="height: 26px; width: 80px">
                                                            &nbsp;<asp:Button ID="Btn_Sp" runat="server" class="crmbutton small save" Text="审批通过" OnClick="Btn_SpSave" Style="height: 26px; width: 60px" />
                                                            &nbsp;<asp:Button ID="Btn_Sp1" runat="server" class="crmbutton small cancel" Text="不通过" OnClick="Btn_SpSave1" Style="height: 26px; width: 60px" />

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="304" align="right" valign="top">
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">


                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">编号:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Tbx_Code" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">产品:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Tbx_ProductsEdition" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">供应商:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_SuppName" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">最小采购:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_MinCg" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">材料单价:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_UnitPrice" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">加工费单价:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_HandPrice" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">创建人:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Creator" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">创建时间:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_CTime" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">状态:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_State" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">审核状态:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_ShState" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">审核人:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_Shperson" runat="server" CssClass="detailedViewLabel"></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">审核时间:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:Label ID="Lbl_ShTime" runat="server" CssClass="detailedViewLabel"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">明细:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                           &nbsp; <asp:Label ID="Lbl_Remarks" runat="server" CssClass="detailedViewLabel"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                    <asp:Label ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                </td>
                            </tr>
                        </table>
                </td>
                <td align="right" valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
