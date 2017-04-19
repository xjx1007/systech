<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_OrderIn.aspx.cs" Inherits="Web_Report_OrderIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <title>产品出货统计表</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            /*选择供应商*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("../../Common/SelectSuppliers.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("../../Common/SelectSuppliers.aspx?sID=" + intSeconds + "", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Suppliers(tempd) {
            if (tempd == undefined) {
                tempd = window.returnValue;
            }
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("|");
                document.all('Tbx_SuppNo').value = ss[0];
                document.all('Tbx_SuppName').value = ss[1];
            }
            else {
                document.all('Tbx_SuppNo').value = "";
                document.all('Tbx_SuppName').value = "";
            }
        }

        function btnGetProductsTypeValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
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
        function OnClick() {
            var StartDate = document.all('StartDate').value;
            var EndDate = document.all('EndDate').value;
            var ProductsEidition = document.all('Tbx_ProductsEdition').value;
            var ProductsType = document.all('Tbx_ProductsTypeNo').value;
            var HouseNo = document.all('HouseNo').value;
            
            var s_URL = 'List_OrderIn.aspx?StartDate=' + StartDate + '&EndDate=' + EndDate + '';
            s_URL += '&ProductsEidition=' + ProductsEidition + '';
            s_URL += '&ProductsType=' + ProductsType + '';
            s_URL += '&HouseNo=' + HouseNo + '';
            

            window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                生产报表 > <a class="hdrLink" href="Procure_ShipCheck_List.aspx">产品出货统计表</a>
            </td>
            <td width="100%" nowrap>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
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
                                        <td width="16%" align="right" class="dvtCellLabel">
                                            日期:
                                        </td>
                                        <td class="dvtCellInfo" align="left" colspan="3">
                                            <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox
                                                ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="16%" align="right" class="dvtCellLabel">
                                            仓库:
                                        </td>
                                        <td align="left" class="dvtCellInfo">
                                            <asp:DropDownList ID="HouseNo" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="16%" align="right" class="dvtCellLabel">
                                            产品型号:
                                        </td>
                                        <td class="dvtCellInfo" align="left">
                                            <asp:TextBox ID="Tbx_Type" CssClass="detailedViewTextBox" Width="200px" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="16%" align="right" class="dvtCellLabel">
                                            产品版本:
                                        </td>
                                        <td class="dvtCellInfo" align="left">
                                            <asp:TextBox ID="Tbx_ProductsEdition" CssClass="detailedViewTextBox" Width="200px"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right" class="dvtCellLabel">
                                            产品分类：
                                        </td>
                                        <td align="left" class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_ProductsTypeName" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                MaxLength="48" Width="200px"></asp:TextBox>
                                            <asp:TextBox ID="Tbx_ProductsTypeNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <img src="../../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProductsTypeValue_onclick()" />
                                        </td>
                                    </tr>
                        <tr>
                            <td colspan="4" align="center" style="height: 30px">
                                <input id="Button1" type="button" runat="server" value="确定" class="crmbutton small save"
                                    onclick="OnClick()" style="width: 55px; height: 30px" />&nbsp;&nbsp;
                                <input type="button" class="crmbutton small cancel" value="返回" style="width: 55px;
                                    height: 30px" onclick="window.history.back()">
                            </td>
                        </tr>
                    </table>
            </td>
        </tr>
        </table> </td>
        <td align="right" valign="top">
            <img src="../../../themes/softed/images/showPanelTopRight.gif" />
        </td>
        </tr>
    </table>
    </td>
    </form>
</body>
</html>
