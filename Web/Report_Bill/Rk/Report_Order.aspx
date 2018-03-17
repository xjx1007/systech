<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Order.aspx.cs" Inherits="Web_Report_CG_Report_Order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <title>原材料入库明细和汇总</title>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('SuppNoSelectValue').value = ss[0];
                document.all('SuppNo').value = ss[1];
            }
            else {
                document.all('SuppNoSelectValue').value = "";
                document.all('SuppNo').value = "";
            }
        }

        function OnClick() {
            var StartDate = document.all('StartDate').value;
            var EndDate = document.all('EndDate').value;
            var SuppNo = document.all('SuppNoSelectValue').value;
            var ProductsEdition = document.all('Tbx_ProductsEdition').value;
            var Type = document.all('Ddl_Type').value;
            var House = document.all('Ddl_HouseNo').value;
            var State = document.all('Ddl_State').value;
            

            var s_URL = 'Procure_MaterIn_View.aspx?StartDate=' + StartDate + '&EndDate=' + EndDate + '';
            s_URL += '&Type=' + Type + '';
            
            s_URL += '&ProductsEdition=' + ProductsEdition + '';
            s_URL += '&SuppNo=' + SuppNo + '';
            s_URL += '&House=' + House + '';
            s_URL += '&State=' + State + '';
            window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>原材料入库明细和汇总 > <a class="hdrLink" href="Procure_ShipCheck_List.aspx">原材料入库明细和汇总报表</a>
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
                                            <td width="16%" align="right" class="dvtCellLabel">日期:
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">供应商名称:
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <input type="hidden" name="SuppNoSelectValue" id="SuppNoSelectValue" runat="server" />
                                                <asp:TextBox ID="SuppNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="48"></asp:TextBox>
                                                <img tabindex="8" src="../../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetReturnValue_onclick()" /></td>
                                            <td width="16%" align="right" class="dvtCellLabel">产品型号:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:TextBox ID="Tbx_Type" CssClass="detailedViewTextBox" Width="200px"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">仓库:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                           
                                                <asp:DropDownList runat="server" ID="Ddl_HouseNo">
                                                </asp:DropDownList>

                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">产品版本:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:TextBox ID="Tbx_ProductsEdition" CssClass="detailedViewTextBox" Width="200px"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">状态:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_State">
                                                    <asp:ListItem Value="" Text="所有"></asp:ListItem>
                                                    <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="部门审批"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="财务已审批"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">报表类型:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_Type">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <input id="Button1" type="button" runat="server" value="确定" class="crmbutton small save"
                                                    onclick="OnClick()" style="width: 55px; height: 30px"  />&nbsp;&nbsp; 
                                                                <input type="button" class="crmbutton small cancel" value="返回"
                                                                    onclick="PageGo('../../Report/Bill_Report_Base.aspx')" style="width: 55px; height: 30px">
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
