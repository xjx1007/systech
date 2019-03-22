<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CG_Account_Bill_Add.aspx.cs"
    Inherits="CG_Account_Bill_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/../themes/softed/style.css" type="text/css">
    <title>采购发票登记</title>
    <script type="text/javascript" src="/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
     <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/dom-drag.js"></script>
</head>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        //var temp = window.showModalDialog("/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
        var temp = window.open("/Web/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "选择供应商", "width=750px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");

    }
    function SetReturnValueInOpenner_Suppliers(temp) {
        if (temp != undefined) {
            var ss;
            ss = temp.split("|");
            document.all('Tbx_SuppNo').value = ss[0];
            document.all('Tbx_SuppName').value = ss[1];
            var v_CheckNo = document.all('Tbx_CheckNo').value
            var v_SuppNo = document.all('Tbx_SuppNo').value
            var v_Response = CG_Account_Bill_Add.ShowCheckDetails1(v_CheckNo, v_SuppNo, "");
            var ss1;
            ss1 = v_Response.value.split("|");
            objSelect_PayMent = document.getElementById("Ddl_PayMent")
            for (var i = 0; i < objSelect_PayMent.options.length; i++) {
                if (objSelect_PayMent.options[i].value == ss1[0]) {
                    objSelect_PayMent.options[i].selected = true;
                }
            }
            document.all('Tbx_Money').value = ss1[3];
            document.all('Lbl_Details1').value = ss1[2];
            document.getElementById('Lbl_Detail').innerHTML = ss1[2];
            ChangePayMent();
        }
        else {
            document.all('Tbx_SuppNo').value = "";
            document.all('Tbx_SuppName').value = "";
        }
    }
    function ChgDays() {

        var i_num1 = parseInt(document.all('i_Num').value);
        var v_Time1 = document.all('Tbx_Stime').value.replace(/-/g, "/");
        for (i = 0; i < i_num1; i++) {
            var i_Day = parseInt(document.all('D_OutDays_' + i + '').value);
            var d_Date = new Date(v_Time1);
            d_Date = d_Date.valueOf();
            d_Date = d_Date + i_Day * 24 * 60 * 60 * 1000;
            d_Date = new Date(d_Date);
            var y = d_Date.getFullYear();
            var m = d_Date.getMonth() + 1;
            var d = d_Date.getDate();
            if (m <= 9) m = "0" + m;
            if (d <= 9) d = "0" + d;
            var cdate = y + "-" + m + "-" + d;
            document.all('D_OutTime_' + i + '').value = cdate;
        }
    }
    function Change(v_Num) {
        var FPCode = $('Tbx_FpCode_' + v_Num + '').value;
        var i_num1 = parseInt($('DetailsNum').value);
        var i_num2 = parseInt($('DetailsFPNum').value);
        for (var i = 0; i < i_num1; i++) {
            if ($("Tbx_FPCode_" + v_Num + "_" + i + "") != undefined) {

                $("Tbx_FPCode_" + v_Num + "_" + i + "").value = FPCode;
            }
        }
    }

    function Change1(v_Num) {
        var FPCode = $('Tbx_FpHandCode_' + v_Num + '').value;
        var i_num1 = parseInt($('DetailsNum').value);
        for (var i = 0; i < i_num1; i++) {
            if ($("Tbx_FPCode1_" + v_Num + "_" + i + "") != undefined) {

                $("Tbx_FPCode1_" + v_Num + "_" + i + "").value = FPCode;
            }
        }
    }
    function Change2() {
        var FPCode = $('Tbx_ClFpCode').value;
        var i_num1 = parseInt($('DetailsNum').value);
        var i_num2 = parseInt($('DetailsFPNum').value);
        for (var i = 0; i < i_num1; i++) {
            for (j = 1; j <= i_num2; j++) {
                if ($("Tbx_FPCode_" + j + "_" + i + "") != undefined) {

                    $("Tbx_FPCode_" + j + "_" + i + "").value = FPCode;
                }
            }
        }
    }

    function btnGetSuppValue_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        if (document.all('Tbx_CustomerValue').value == "") {
            alert("请选择客户！");
            return;
        }
        var temp = window.showModalDialog("/Common/SelectContractList.aspx?ID=" + intSeconds + "&CustomerValue=" + document.all('Tbx_CustomerValue').value + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1150px;dialogHeight=500px");

        if (temp != undefined) {
            var ss;
            ss = temp.split("|");
            document.all('Tbx_ContractNo').value = ss[0];
        }
        else {
            document.all('Tbx_ContractNo').value = "";
        }
    }

    function deleteRow(obj) {
        myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        ChangePrice()
    }

    function deleteRow1(obj) {
        myTable1.deleteRow(obj.parentElement.parentElement.rowIndex);
    }
    function ChangePrice() {
        var i_num1 = parseInt(document.all('Tbx_Num').value);
        var v_Total = 0;
        for (i = 0; i < i_num1; i++) {
            var Total = 0;
            var Number = document.all("Number_" + i + "");
            var Price = document.all("Price_" + i + "");
            if ((Number != null) && (Price != null)) {
                Total += parseFloat(Number.value) * parseFloat(Price.value);
                v_Total += Total;
                document.all("Money_" + i + "").value = Total;
            }
        }
        document.all("Tbx_Money").value = v_Total.toFixed(3);
    }
    function Sum(obj) {
        var v_Money = document.all("Tbx_Money").value
        var Chk = document.all('Chk_' + obj + '');
        var Money = document.all('Tbx_Money_' + obj + '').value;

        if (Chk.checked) {
            v_Money = parseFloat(v_Money) + parseFloat(Money);
        }
        else {
            v_Money = parseFloat(v_Money) - parseFloat(Money);
        }
        document.all("Tbx_Money").value = v_Money.toFixed(3);
        ChangePayMent();
    }

    function ChangePayMent() {
        var PayMent = document.all('Ddl_PayMent').value;
        var Money = document.all('Tbx_Money').value;
        var STime = document.all('Tbx_STime').value;
        var response = CG_Account_Bill_Add.GetDetails(Money, PayMent, STime);
        var ss;
        ss = response.value.split("$");
        document.all('i_Num').value = ss[0];
        document.getElementById("Lbl_Details").innerHTML = ss[1];
        document.all('Lbl_Details1').value = ss[1];

    }

    function selectAll(obj) {
        var i, j = 0;
        var elements = document.getElementsByTagName("input");
        //alert(obj.value.replace(/\s+/g,""));
        if (obj.checked) {
            for (i = 0; i < elements.length; i++) {
                if (elements[i].disabled == false) {
                    elements[i].checked = true;
                    j++;
                }
            }
        }
        else {
            for (i = 0; i < elements.length; i++) {
                elements[i].checked = false;
                j++;
            }
        }
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="ChangePayMent()">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>发票管理 > <a class="hdrLink" href="CG_Account_Bill_List.aspx">发票管理</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_FID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_URL" runat="server" Style="display: none"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="/../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                    </div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>发票管理信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">&nbsp;
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">&nbsp;
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
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编号不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td width="17%" class="dvtCellLabel">供应商:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="Tbx_SuppNo" id="Tbx_SuppNo" runat="server"
                                                            style="width: 150px" />
                                                        <pc:PTextBox ID="Tbx_SuppName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="200px" ReadOnly="true"></pc:PTextBox>
                                                        <img src="/../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="dvtCellLabel" align="right">文件：
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Lbl_Upload"></asp:Label>
                                                        <input id="uploadFile" type="file" runat="server" />

                                                        <asp:Button
                                                            ID="save" runat="server" Text="上传" CssClass="crmbutton small save"
                                                            OnClick="save_Click" Height="26px" />
                                                    </td>
                                                    <td width="15%" class="dvtCellLabel" align="right">表名：
                                                    </td>
                                                    <td width="20%" align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_Sheet" runat="server" CssClass="detailedViewTextBox" Text="Sheet1" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                        <asp:Button ID="Button2" runat="server" class="crmbutton small save" OnClick="Btn_Serch_Click1" Text="配置" Height="26px" />

                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">付款方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_PayMent" CssClass="detailedViewTextBox" runat="server" onchange="ChangePayMent()"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="dvtCellLabel">票据类型:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_BillType" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>(<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请选择票据类型"
                                                        ControlToValidate="Ddl_BillType" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">开票日期:
                                                    </td>
                                                    <%--<td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker();ChangePayMent()"></asp:TextBox>
                                                        (<font color="red">*</font>)
                                                    </td>--%>
                                                    <td class="dvtCellInfo">
                                                <%--        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>(<font
                                                            color="red">*</font>)<br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="出库日期非空"
                                                            ControlToValidate="Tbx_STime" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                          <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                            (<font color="red">*</font>)<br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Tbx_STime" Display="Dynamic" ErrorMessage="对账日期非空"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">责任人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList runat="server" ID="Ddl_DutyPerson">
                                                        </asp:DropDownList>(<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人"
                                                        ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">票据金额:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Money" AllowEmpty="false" ValidError="票据金额不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px" onchange="ChangePayMent()"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td align="right" class="dvtCellLabel">对账类型: </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_Type" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                        <asp:Button ID="Btn_Serch" runat="server" AccessKey="S" class="crmbutton small save" OnClick="Btn_Serch_Click" Text="匹配" title="匹配 [Alt+S]" Height="26px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">经手人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Brokerage" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">对账编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_CheckNo" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px" Enabled="false"></pc:PTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">发票编号:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <pc:PTextBox runat="server" ID="Tbx_FPCode" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox';Change()" Width="150px"></pc:PTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>帐期</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="i_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <div id="Lbl_Details"></div>
                                                        <asp:TextBox runat="server" ID="Lbl_Details1" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>描述信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">备注:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="4">
                                                        <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px" Height="40px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>产品详细信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label runat="server" ID="Lbl_Detail"></asp:Label>
                                                        <asp:TextBox runat="server" ID="Lbl_Detail1" CssClass="Custom_Hidden"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">&nbsp;
                                        <br />
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                            &nbsp;<input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <img src="/../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
