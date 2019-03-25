<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Kc.aspx.cs" Inherits="Web_Report_Xs_Report_Kc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script language="JAVASCRIPT">
        function OnClick() {
            var HouseNo = "";

            var ProductsType = document.all('Tbx_ProductsTypeNo').value;
            var Number = document.all('Ddl_Number').value;
            var ProductsEdition = document.all('Tbx_ProductsEdition').value;
            
            var s_URL = 'List_KCList.aspx?';
            s_URL += '&ProductsType=' + ProductsType + '';
            s_URL += '&ProductsEdition=' + ProductsEdition + '';
            s_URL += '&Number=' + Number + '';
            
            window.open(s_URL, '成品最新成本明细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
        }


        function btnGetProductsTypeValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsClass(temp) {
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
    <title>成品最新成本明细</title>
</head>
<body>
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>财务> <a class="hdrLink" href="Report_Kc.aspx">成品最新成本明细</a>
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
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">

                            <tr>
                                <td align="right" valign="top">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">产品版本号:
                                            </td>
                                            <td class="dvtCellInfo" align="left" >
                                                <asp:TextBox ID="Tbx_ProductsEdition" CssClass="detailedViewTextBox" Width="200px"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">产品名称:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:TextBox ID="Tbx_Type" CssClass="detailedViewTextBox" Width="200px"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right" class="dvtCellLabel">产品分类：
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_ProductsTypeName" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    MaxLength="48" Width="164px"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_ProductsTypeNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <img src="../../../themes/softed/images/select.gif" alt="ѡ��" title="ѡ��" onclick="return btnGetProductsTypeValue_onclick()" />
                                            </td>
                                            <td align="right" class="dvtCellLabel">库存状态
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:DropDownList runat="server" ID="Ddl_Number">

                                                    <asp:ListItem Value="">全部</asp:ListItem>
                                                    <asp:ListItem Value="-1">库存小于0</asp:ListItem>
                                                    <asp:ListItem Value="1">库存大于0</asp:ListItem>
                                                </asp:DropDownList>
                                                    </td>
                                        </tr>
                                        <tr>

                                            <td colspan="4" align="center" style="height: 30px">
                                                <input id="Button2" type="button" runat="server" value="确定" class="crmbutton small save"
                                                    onclick="OnClick()" style="width: 55px; height: 30px" />&nbsp;&nbsp;
                                <input type="button" class="crmbutton small cancel" value="取消" style="width: 55px; height: 30px"
                                    onclick="window.history.back()">
                                            </td>
                                        </tr>
                                    </table>
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

