<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Cw_Accounting_Payment_Add.aspx.cs"
    Inherits="Cw_Accounting_Payment_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title>开票通知信息</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");

            if (tempd == undefined) {
                tempd = window.returnValue;
            }
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];

            }
            else {
                document.all('Tbx_CustomerValue').value = "";
                document.all('Tbx_CustomerName').value = "";
            }
        }
        function btnGetReturnValue_onclick1() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");

            if (tempd == undefined) {
                tempd = window.returnValue;
            }
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_KCustomerValue').value = ss[0];
                document.all('Tbx_KCustomerName').value = ss[1];

            }
            else {
                document.all('Tbx_KCustomerValue').value = "";
                document.all('Tbx_KCustomerName').value = "";
            }
        }
        function btnGetShip_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectSalesShipList.aspx?CustomerValue=" + document.all("Tbx_CustomerValue").value + "&ID=" + document.all("Tbx_IDs").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss, s_Name, i_row, s_ID = "", TotalNet = 0;
                i_row = myTable.rows.length;
                var v_Ship = Cw_Accounting_Payment_Add.GetDetails(tempd);
                ss = v_Ship.value.split("|");
                var i_num = parseInt(document.all('Tbx_Num').value);
                for (var i = 0; i < ss.length - 1; i++) {
                    var Num = i_num + i;
                    var v_Value = ss[i].split(",");
                    var objRow = myTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  ID=\"ID_' + Num + '\"  Name=\"ID_' + Num + '\" value=' + v_Value[0] + '>' + v_Value[1];
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  ID=\"DirectOutTime_' + Num + '\"  Name=\"DirectOutTime_' + Num + '\" value=' + v_Value[6] + '>' + v_Value[6];
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\" ID=\"ProductsBarCode_' + Num + '\"   Name=\"ProductsBarCode_' + Num + '\" value=' + v_Value[2] + '>' + v_Value[3];
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  class="detailedViewTextBox"  OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="ChangePrice();this.className=&#39;detailedViewTextBox&#39;" width=\"100px\" Name=\"Number_' + Num + '\" value=' + v_Value[4] + '>';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\" ID=\"OldPrice_' + Num + '\"   Name=\"OldPrice_' + Num + '\" value=' + v_Value[5] + '> <input  class="detailedViewTextBox" OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="this.className=&#39;detailedViewTextBox&#39;ChangePrice()" width=\"100px\" Name=\"Price_' + Num + '\" value=' + v_Value[5] + '>';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  class="detailedViewTextBox"  readonly OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="this.className=&#39;detailedViewTextBox&#39;" width=\"100px\" Name=\"Money_' + Num + '\" value=' + parseFloat(v_Value[5]) * parseFloat(v_Value[4]) + '>';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  class="detailedViewTextBox" OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="this.className=&#39;detailedViewTextBox&#39;" width=\"150px\" Name=\"Remarks_' + Num + '\"> ';
                    objCel.className = "dvtCellInfo";
                    TotalNet += parseFloat(v_Value[5]) * parseFloat(v_Value[4]);
                    i_row = i_row + 1;
                    s_ID = s_ID + v_Value[1] + ",";
                }
                if (s_ID != "") {
                    s_ID = s_ID.substring(0, s_ID.length - 1);
                }
                document.all("Tbx_IDs").value = s_ID;
                document.all('Tbx_Num').value = ss.length - 1 + i_num;
                document.all('Tbx_Money').value = TotalNet;

            }
        }
        function deleteRow(obj) {
            var i_num1 = parseInt(document.all('Tbx_Num').value);
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var bm_num = "";
            var Total = 0;
            for (i = 0; i < i_num1; i++) {
                var TotalNum = document.all("Money_" + i + "");
                if (TotalNum != null) {
                    Total += parseFloat(TotalNum.value);
                }
            }
            document.all('Tbx_Money').value = Total;
        }
        function ChangePrice() {
            var i_num1 = parseInt(document.all('Tbx_Num').value);
            var v_Total = 0;
            for (i = 0; i < i_num1; i++) {
                var Total = 0;
                var Number = document.all("Number_" + i + "");
                var Price = document.all("Price_" + i + "");
                if (Number != null) {
                    Total += parseFloat(Number.value) * parseFloat(Price.value);
                    document.all("Money_" + i + "").value = Total;
                }
                v_Total += Total;
            }
            document.all("Tbx_Money").value = v_Total;
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                财务 > <a class="hdrLink" href="Cw_Accounting_Payment_List.aspx">新增开票通知</a>
            </td>
            <td width="100%" nowrap>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
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
                                <tr valign="bottom">
                                    <td style="height: 44px">
                                        <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                            <tr>
                                                <td class="dvtTabCache" style="width: 10px" nowrap>
                                                    &nbsp;
                                                </td>
                                                <td class="dvtSelectedCell" align="center" nowrap>
                                                    应付款计划信息
                                                </td>
                                                <td class="dvtTabCache" style="width: 10px">
                                                    &nbsp;
                                                </td>
                                                <td class="dvtTabCache" style="width: 100%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                            <tr>
                                                <td>
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr>
                                                            <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                                                            <td colspan="4" class="detailedViewHeader">
                                                                <b>基本信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                开票通知编号:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编号不能为空"
                                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                                (<font color="red">*</font>)
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                客户:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_CustomerName" AllowEmpty="false" ValidError="供应商不能为空"
                                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                                <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                    onclick="return btnGetReturnValue_onclick()" />
                                                                <pc:PTextBox runat="server" ID="Tbx_CustomerValue" CssClass="Custom_Hidden" Width="0px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                应收日期:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox runat="server" ID="Tbx_YTime" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                批次:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="Order">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                            <td class="dvtCellLabel">付款方式:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Drop_Payment" runat="server" Width="300px">
                                                </asp:DropDownList>
                                                (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="付款方式非空"
                                                ControlToValidate="Drop_Payment" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                开票客户:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_KCustomerName" AllowEmpty="false" ValidError="供应商不能为空"
                                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                                <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                    onclick="return btnGetReturnValue_onclick1()" />
                                                                <pc:PTextBox runat="server" ID="Tbx_KCustomerValue" CssClass="Custom_Hidden" Width="0px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                通知开票:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="Ddl_KP">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                票据类型:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="Ddl_KpType">
                                                                </asp:DropDownList>
                                                (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="票据类型非空"
                                                ControlToValidate="Ddl_KpType" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                                            <td class="dvtCellLabel">
                                                                总金额:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_Money" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                是否冲红:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:CheckBox runat="server" ID="Chk_Red" Text="是" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                备注说明:
                                                            </td>
                                                            <td valign="top" class="dvtCellInfo" colspan="3">
                                                                <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="300px" Height="40px"></asp:TextBox>
                                                                    <br />注：如果是本月就修改出库单单价。如果是跨月就冲红字,如果开票单位不是这个请先选择开票单位
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <asp:TextBox ID="Tbx_OutWareNo" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_KPOType" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_ContractNo" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_IDs" runat="server" Style="display: none"></asp:TextBox>
                                                            <td colspan="4" class="detailedViewHeader">
                                                                <b>应收款信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <asp:TextBox runat="server" ID="Tbx_Num" Text="0" CssClass="Custom_Hidden"></asp:TextBox><td
                                                                class="dvtCellInfo" colspan="4">
                                                                <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0"
                                                                    class="ListDetails">
                                                                    <tr valign="top">
                                                                        <td align="left" class="ListHead" width="4%">
                                                                            删除
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            发货单号
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            出库日期
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            产品
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            数量
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            单价
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            金额
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            备注
                                                                        </td>
                                                                    </tr>
                                                                    <%=s_MyTable_Detail %>
                                                                    
                                                                </table>
                                                                <input id="Button4" class="crmbutton small create" onclick="return btnGetShip_onclick()"
                                                                    type="button" value="选择出库单" />
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
                                                        class="crmbutton small save" OnClick="Btn_SaveOnClick" style="width: 55px;height: 33px;" />
                                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                        type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
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
