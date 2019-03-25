<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Details.aspx.cs" Inherits="Web_Report_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <title>存货收发结存表（成品）</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            /*选择供应商*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../../Common/SelectSuppliers.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

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
        function OnClick() {
            var StartDate = document.all('StartDate').value;
            var EndDate = document.all('EndDate').value;
            var HouseNo = document.all('HouseNo').value;
            var ProductsEdtion = document.all('Tbx_ProductsEdition').value;
            var ProductsType = document.all('Tbx_ProductsTypeNo').value;
  
            var s_URL = 'List_Details.aspx?StartDate=' + StartDate + '&EndDate=' + EndDate + '';
            s_URL += '&HouseNo=' + HouseNo + '';
            s_URL += '&ProductsEdtion=' + ProductsEdtion + '';
            s_URL += '&ProductsType=' + ProductsType + '';

            window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
        }

    </script>
    <style type="text/css">
        .auto-style1 {
            background: #F7F7F7 url('../../../themes/softed/images/testsidebar.jpg') repeat-y right center;
            border-bottom: 1px solid #DEDEDE;
            border-left: 1px solid #DEDEDE;
            border-right: 1px solid #DEDEDE;
            color: #545454;
            padding-left: 10px;
            padding-right: 10px;
            white-space: nowrap;
            text-align: right;
            height: 30px;
        }
        .auto-style2 {
            padding-left: 10px;
            padding-right: 10px;
            border-bottom: 1px solid #dedede;
            border-right: 1px solid #dedede;
            border-left: 1px solid #dedede;
            text-align: left;
            height: 30px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>单据报表 > <a class="hdrLink" href="Procure_ShipCheck_List.aspx">存货收发结存表（成品）</a>
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


                                        <tr style="height: 28px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Div2');">
                                            <!-- windLayerHeadingTr -->
                                            <td colspan="4"  align="left" valign="middle">&nbsp;&nbsp;计算&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 30px; width: 30px;" onclick="detail_info_click('Div2');">
                                                <img align="absmiddle" id="Div2_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                            </span>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="4">
                                        <div id="Div2" style="display:none;">
                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="16%" align="right" class="dvtCellLabel">年月:
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <asp:TextBox ID="Tbx_Year" runat="server"></asp:TextBox>&nbsp;<asp:TextBox
                                                            ID="Tbx_Month" runat="server"></asp:TextBox>
                                                        <asp:Button ID="Button2" type="button" runat="server" Text="计算" class="crmbutton small save"
                                                            Style="width: 55px; height: 30px" OnClick="Button2_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>查询条件:</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">日期:
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox
                                                    ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>

                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">仓库:</td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:DropDownList ID="HouseNo" runat="server" Width="150px"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="auto-style1">产品版本:
                                            </td>
                                            <td class="auto-style2" align="left">
                                                <asp:TextBox ID="Tbx_ProductsEdition" CssClass="detailedViewTextBox" Width="200px"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                            <td align="right" class="auto-style1">产品分类：
                                            </td>
                                            <td align="left" class="auto-style2">
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
                                <input type="button" class="crmbutton small cancel" value="返回" style="width: 55px; height: 30px"
                                    onclick="window.history.back()">&nbsp;&nbsp;
                                                
                                           <!--    <asp:Button id="Button3" type="button" runat="server" Text="导出全部仓库Excel" class="crmbutton small save" Width="151px"  OnClick="Btn_SaveOnClick" />&nbsp;&nbsp;-->
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
        </td>
    </form>
</body>
</html>
