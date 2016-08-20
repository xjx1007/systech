<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Cw_Accounting_Payment_Simple_Add.aspx.cs"
    Inherits="Cw_Accounting_Payment_Simple_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript">
        if (window != window.parent)
        { var P = window.parent, D = P.loadinndlg(); }

        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var v_num = document.all("Tbx_Num").value;
            var bm_num = "";
            document.all("Tbx_Num").value = parseInt(v_num) - 1;
        }
        function btnGetOrder_onclick() {

            var today = new Date();
            i_row = myTable.rows.length;
            var v_num = document.all("Tbx_Num").value;
            var v_Money = document.all("Tbx_Money").value;
            var v_TotalMoney = 0;
            for (var i = 1; i <= v_num; i++) {
                var v_MoneyDetails = document.all("Money_" + i + "").value;
                v_TotalMoney += parseFloat(v_MoneyDetails);
            }
            if (v_TotalMoney >= v_Money) {
                alert("付款金额不能超出总金额！")
                return;
            }
            v_num = parseInt(v_num) + 1;
            var v_LeftMoney = parseFloat(v_Money) - parseFloat(v_TotalMoney)
            var objRow = myTable.insertRow(i_row);
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
            objCel.className = "dvtCellInfo";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;" Name=\"Order_' + v_num + '\" value=' + v_num + '>';
            objCel.className = "dvtCellInfo";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\';CheckMoney(this);\" style="width:70px;"  Name=\"Money_' + v_num + '\" value=' + parseFloat(v_LeftMoney) + '>';
            objCel.className = "dvtCellInfo";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<td align=\"right\"><input type=\"text\" Class=\"Wdate\" onFocus=\"WdatePicker()\"  style=\"width:100px;\"  Name=\"Time_' + v_num + '\" Value=' + GetDateStr(0) + '>';
            objCel.className = "dvtCellInfo";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:170px;"  Name=\"Remarks\" >';
            objCel.className = "dvtCellInfo";
            i_row = i_row + 1;
            document.all("Tbx_Num").value = v_num;
        }

        function CheckMoney(CheckMoney) {
            var v_Money = document.all("Tbx_Money").value;
            var v_num = document.all("Tbx_Num").value;
            var v_TotalMoney = 0;
            for (var i = 1; i <= v_num; i++) {
                var v_MoneyDetails = document.all("Money_" + i + "").value;
                v_TotalMoney += parseFloat(v_MoneyDetails);
            }
            if (parseInt(v_Money) < parseInt(v_TotalMoney)) {
                alert("付款金额不能超出总金额！");
                CheckMoney.select();
                CheckMoney.focus();
                return;
            }
        }
        function GetDateStr(AddDayCount) {
            var dd = new Date();
            dd.setDate(dd.getDate() + AddDayCount); //获取AddDayCount天后的日期 
            var y = dd.getYear();
            var m = dd.getMonth() + 1; //获取当前月份的日期 
            var d = dd.getDate();
            return y + "/" + m + "/" + d;
        } 
    </script>
    <title>新增应付款计划添加</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
        <tr>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                    <tr>
                        <td class="showPanelBg" valign="top" width="100%">
                            <span class="lvtHeaderText">
                                <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                            <br>
                            <hr noshade size="1">
                            
                            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                            <tr>
                                                <td>
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr>
                                                            <asp:TextBox ID="Tbx_ID1" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_Code1" runat="server" Style="display: none"></asp:TextBox>
                                                            <td colspan="4" class="detailedViewHeader">
                                                                <b>基本信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                供应商:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_SuppName" AllowEmpty="false" ValidError="供应商不能为空"
                                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                                <pc:PTextBox runat="server" ID="Tbx_SuppNo" CssClass="Custom_Hidden" Width="0px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                对账单号:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_CheckNo" AllowEmpty="false" ValidError="名称不能为空"
                                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                总金额:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_Money" Enabled="false" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="150px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                负责人:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <asp:TextBox runat="server" ID="Tbx_Num" Text="1" CssClass="Custom_Hidden"></asp:TextBox><td
                                                                class="dvtCellInfo" colspan="4">
                                                                <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0"
                                                                    class="crmTable">
                                                                    <tr valign="top">
                                                                        <td align="left" class="dvtCellLabel" width="15%">
                                                                            删除
                                                                        </td>
                                                                        <td align="left" class="dvtCellLabel" style="height: 20px">
                                                                            期次
                                                                        </td>
                                                                        <td align="left" class="dvtCellLabel" style="height: 20px">
                                                                            金额
                                                                        </td>
                                                                        <td align="left" class="dvtCellLabel" style="height: 20px">
                                                                            应付日期
                                                                        </td>
                                                                        <td align="left" class="dvtCellLabel" style="height: 20px">
                                                                            备注
                                                                        </td>
                                                                    </tr>
                                                                    <%=s_MyTable_Detail %>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellInfo" colspan="4">
                                                                <input type="button" name="Button" class="crmbutton small create" value="添加" onclick="btnGetOrder_onclick();" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    &nbsp;
                                                    <br />
                                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                        class="crmbutton small save" OnClick="Btn_SaveOnClick" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <img src="../../themes/softed/images/showPanelTopRight.gif">
                        </td>
                    </tr>
                </table>
    </form>
</body>
</html>
