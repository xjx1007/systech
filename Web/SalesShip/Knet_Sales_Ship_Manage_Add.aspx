<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Knet_Sales_Ship_Manage_Add.aspx.cs"
    Inherits="Knet_Web_Sales_Knet_Sales_Ship_Manage_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>销售发货管理</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick1() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
                document.all('Tbx_SCustomerValue').value = ss[0];
                document.all('Tbx_SCustomerName').value = ss[1];
                var response = Knet_Web_Sales_Knet_Sales_Ship_Manage_Add.GetLastOutWare(document.all('Tbx_CustomerValue').value);
                if (response.value != "") {
                    var TS = response.value.split(",");
                    document.all('Tbx_ContentPersonID').value = TS[0];
                    document.all('Tbx_ContentPerson').value = TS[1];
                    document.all('Tbx_Phone').value = TS[2];
                    document.all('ContractToAddress').value = TS[3];

                    objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                    for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                        if (objSelect_DutyPerson.options[i].value == TS[4]) {
                            objSelect_DutyPerson.options[i].selected = true;
                        }
                    }
                    objSelect = document.getElementById("ContractDeliveMethods")
                    for (var i = 0; i < objSelect.options.length; i++) {
                        if (objSelect.options[i].value == TS[5]) {
                            objSelect.options[i].selected = true;
                        }
                    }
                }
                else {
                    var Gs = ss[3].split(",");
                    var response = Knet_Web_Sales_Knet_Sales_Ship_Manage_Add.GetLinkMan(Gs[0]);
                    if (response.value != "") {
                        var TS = response.value.split(",");
                        document.all('Tbx_ContentPersonID').value = TS[0];
                        document.all('Tbx_ContentPerson').value = TS[1];
                        document.all('Tbx_Phone').value = TS[2];
                        document.all('ContractToAddress').value = TS[3];
                        objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                        for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                            if (objSelect_DutyPerson.options[i].value == TS[4]) {
                                objSelect_DutyPerson.options[i].selected = true;
                            }
                        }
                    }
                }
            }
            else {
                document.all('Tbx_CustomerValue').value = "";
                document.all('Tbx_CustomerName').value = "";
                document.all('Tbx_Phone').value = "";
                document.all('ContractToAddress').value = "";
                objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                    if (objSelect_DutyPerson.options[i].value == "") {
                        objSelect_DutyPerson.options[i].selected = true;
                    }
                }
                objSelect = document.getElementById("ContractDeliveMethods")
                for (var i = 0; i < objSelect.options.length; i++) {
                    if (objSelect.options[i].value == "") {
                        objSelect.options[i].selected = true;
                    }
                }
            }
        }
        function btnGetReturnValue_onclick2() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_SCustomerValue').value = ss[0];
                document.all('Tbx_SCustomerName').value = ss[1];
                var response = Knet_Web_Sales_Knet_Sales_Ship_Manage_Add.GetLastOutWare(document.all('Tbx_SCustomerValue').value);
                if (response.value != "") {
                    var TS = response.value.split(",");
                    document.all('Tbx_ContentPersonID').value = TS[0];
                    document.all('Tbx_ContentPerson').value = TS[1];
                    document.all('Tbx_Phone').value = TS[2];
                    document.all('ContractToAddress').value = TS[3];

                    objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                    for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                        if (objSelect_DutyPerson.options[i].value == TS[4]) {
                            objSelect_DutyPerson.options[i].selected = true;
                        }
                    }

                    objSelect_GetFHDetails = document.getElementById("Ddl_FhDetails")
                    var list = Knet_Web_Sales_Knet_Sales_Ship_Manage_Add.GetFHDetails(document.all('Tbx_SCustomerValue').value);

                    var classList = list.value.split("|");
                    
                    objSelect_GetFHDetails.options.length = 1;
                    objSelect_GetFHDetails.options.remove(objSelect_GetFHDetails.selectedindex);
                    objSelect_GetFHDetails.selectindex = 0;
                    for (var i = 0; i < classList.length; i++) {
                        var tmp = classList[i].split("#");
                        objSelect_GetFHDetails.add(new Option(tmp[1], tmp[0]));
                    }

                    objSelect = document.getElementById("ContractDeliveMethods")
                    for (var i = 0; i < objSelect.options.length; i++) {
                        if (objSelect.options[i].value == TS[5]) {
                            objSelect.options[i].selected = true;
                        }
                    }
                }
                else {
                    var Gs = ss[3].split(",");
                    var response = Knet_Web_Sales_Knet_Sales_Ship_Manage_Add.GetLinkMan(Gs[0]);

                    objSelect_GetFHDetails = document.getElementById("Ddl_FhDetails")
                    var list = Knet_Web_Sales_Knet_Sales_Ship_Manage_Add.GetFHDetails(Gs[0]);

                    var classList = list.value.split("|");
                    
                    objSelect_GetFHDetails.options.length = 1;
                    for (var i = 0; i < classList.length; i++) {
                        var tmp = classList[i].split(",");
                        objSelect_GetFHDetails.add(new Option(tmp[1], tmp[0]));
                    }
                    if (response.value != "") {
                        var TS = response.value.split(",");
                        document.all('Tbx_ContentPersonID').value = TS[0];
                        document.all('Tbx_ContentPerson').value = TS[1];
                        document.all('Tbx_Phone').value = TS[2];
                        document.all('ContractToAddress').value = TS[3];
                        objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                        for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                            if (objSelect_DutyPerson.options[i].value == TS[4]) {
                                objSelect_DutyPerson.options[i].selected = true;
                            }
                        }
                    }
                }
            }
            else {
                document.all('Tbx_SCustomerValue').value = "";
                document.all('Tbx_SCustomerName').value = "";
                document.all('Tbx_Phone').value = "";
                document.all('ContractToAddress').value = "";
                objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                    if (objSelect_DutyPerson.options[i].value == "") {
                        objSelect_DutyPerson.options[i].selected = true;
                    }
                }
                objSelect = document.getElementById("ContractDeliveMethods")
                for (var i = 0; i < objSelect.options.length; i++) {
                    if (objSelect.options[i].value == "") {
                        objSelect.options[i].selected = true;
                    }
                }
            }
        }
        function ChangPrice() {
            var num = document.all('i_Num').value;
            for (var i = 0; i < num; i++) {
                    var  Number=document.all("Number_" + i)
                    var  LeftNumber=document.all("Number_" + i)
                    if(Number!=null)
                    {
                        if (parseInt(Number.value) > parseInt(LeftNumber.value)) {
                            alert("不能超过合同数或库存数！");
                            document.all("Number_" + i).value = "0";

                        }
                        else {
                            document.all("Money_" + i).value = document.all("Price_" + i).value * document.all("Number_" + i).value
                        }
                }

            }
        }
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            var CustomerValue = document.all('Tbx_CustomerValue').value;
            var v_Contract = document.all("Tbx_ContractNo").value;
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("SelectSalesContractList.aspx?ID=" + intSeconds + "&Type=1&ContractNo=" + v_Contract + "&CustomerValue=" + CustomerValue + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no;dialogwidth=1000px;dialogHeight=600px");
            if (temp != undefined) {
                var i_num1 = parseInt(document.all('i_Num').value);
                var ss;
                ss = temp.split("|");
                document.all('Tbx_ContractNo').value = ss[0];
            }
            else {

            }
        }

        function btnGetContentPerson_onclick() {
            var s_Customer = "";
            s_Customer = document.all('Tbx_SCustomerValue').value;
            var temaap = window.showModalDialog("../Common/SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");

            if (temaap != undefined) {
                var sws;
                sws = temaap.split(",");
                document.all('Tbx_ContentPerson').value = sws[0];
                document.all('Tbx_Phone').value = sws[1];
                document.all('Tbx_ContentPersonID').value = sws[2];
                document.all('ContractToAddress').value = sws[3];
            }
            else {
                document.all('Tbx_ContentPerson').value = "";
                document.all('Tbx_Phone').value = "";
                document.all('Tbx_ContentPersonID').value = "";
                document.all('ContractToAddress').value = "";
            }
        }
        function btnGetProducts_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var v_Contract = document.all("Tbx_ContractNo").value;
            var tempd;
            if (v_Contract == "") {
                tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&CustomerValue=" + document.all("Tbx_CustomerValue").value + "&ContractNo=" + v_Contract + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            }
            else {
                tempd = window.showModalDialog("SelectContractProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&CustomerValue=" + document.all("Tbx_CustomerValue").value + "&ContractNo=" + v_Contract + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            }
            if (tempd != undefined) {
                var i_num1 = parseInt(document.all('i_Num').value);
                document.all('i_Num').value = i_num1;
                var ss, s_Value, i_row;
                ss = tempd.split("|");
                i_row = myTable.rows.length;
                s_ID = document.all("Xs_ProductsCode").value;
                var objRow = myTable.insertRow(i_row);

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ContractNo_' + i_num1 + '\" value=' + ss[9] + '>' + ss[9];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                v_Contract = ss[9];
                if (v_Contract != "") {
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ID_' + i_num1 + '\" value=' + ss[10] + '>';
                }
                objCel.innerHTML += '<input type=\"hidden\"  Name=\"ProductsBarCode_' + i_num1 + '\" value=' + ss[0] + '><input type=\"hidden\"  Name=\"ProductsName_' + i_num1 + '\" value=' + ss[2] + '>' + ss[2];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern_' + i_num1 + '\" value=' + ss[3] + '>' + ss[3];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '' + ss[8] + '';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '' + ss[7] + '';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Style="display:none" Name=\"LeftNumber_' + i_num1 + '\" value=' + ss[7] + ' ><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"  style="width:50px;"  Name=\"Number_' + i_num1 + '\" value=' + ss[4] + ' >';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\"  style="width:50px;"  Name=\"BNumber_' + i_num1 + '\" value=0 >';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:50px;"  Name=\"Price_' + i_num1 + '\" value=' + ss[5] + ' >';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:50px;"  readonly Name=\"Money_' + i_num1 + '\" value=' + ss[6] + '  >';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:50px;"   Name=\"RCOrderNo_' + i_num1 + '\"  >';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:50px;"   Name=\"MaterOrderNo_' + i_num1 + '\"  >';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:50px;"   Name=\"RCMNo_' + i_num1 + '\"  >';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:50px;"   Name=\"MaterMNo_' + i_num1 + '\"  >';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:50px;"   Name=\"IsFollow_' + i_num1 + '\"  >';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:50px;"   Name=\"Remarks_' + i_num1 + '\"  >';
                objCel.className = "dvtCellInfo";
                i_row = i_row + 1;

                document.all('i_Num').value = parseInt(document.all('i_Num').value) + 1;
                if (v_Contract != "") {
                    s_ID = s_ID + ss[10] + ",";
                }
                else {
                    s_ID = s_ID + ss[0] + ",";
                }
                document.all("Xs_ProductsCode").value = s_ID;
            }
        }

        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var v_Num = document.all("i_Num").value
            var bm_num = "";
            for (i = 0; i < parseInt(v_Num); i++) {
                var ProductsBarCode = document.all("ProductsBarCode_" + i);
                var ContractNo = document.all("Tbx_ContractNo").value;
                var ID = document.all("ID_" + i);
                if (ContractNo != "") {
                    if (ID != null) {
                        bm_num += ID.value + ",";
                    }
                }
                else {
                    if (ProductsBarCode != null) {
                        bm_num += ProductsBarCode.value + ",";
                    }
                }
            }
            document.all("Xs_ProductsCode").value = bm_num;
        }
        
    </script>
    <script language="JAVASCRIPT">
        function btnGetBackValue_onclick() {
            document.all('ContractNoSelectValue').value = "";
            document.all('ContractNoName').value = "";
        }
    </script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                发货通知单 > <a class="hdrLink" href="Knet_Sales_Ship_Manage_Add.aspx">发货通知单</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                <asp:TextBox ID="Tbx_OutWareCheckYN" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                <asp:TextBox ID="Tbx_Customer" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                <asp:TextBox ID="Tbx_ProductsBar" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
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
                <img src="../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td class="showPanelBg" valign="top" width="100%">
                <div class="small" style="padding: 10px">
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
                                            发货通知单信息
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
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            &nbsp;发货单号:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="OutWareNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="发货单号不能为空"
                                                ControlToValidate="OutWareNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            &nbsp;发货类型:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList ID="Ddl_ShipType" CssClass="detailedViewTextBox" runat="server"
                                                Width="100px">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="发货类型不能为空"
                                                ControlToValidate="Ddl_ShipType" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            责任人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList runat="Server" ID="Ddl_DutyPerson">
                                            </asp:DropDownList>
                                            邮件提醒:
                                            <asp:CheckBox ID="Is_Mail" runat="server" Checked="true" Text="是" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Ddl_DutyPerson"
                                                Display="Dynamic" ErrorMessage="责任人非空"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            发货通知单阶段:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList ID="Ddl_Step" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            发货日期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="OutWareDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="发货日期非空"
                                                ControlToValidate="OutWareDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            预计到货日期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <pc:PTextBox ID="PlanOutWareDateTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                AllowEmpty="false"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="预计到货日期非空"
                                                ControlToValidate="PlanOutWareDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="17%" class="dvtCellLabel">
                                            结算客户:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server" />
                                            <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="280px" ReadOnly="true"></pc:PTextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                onclick="return btnGetReturnValue_onclick1()" />(<font color="red">*</font>)<br />
                                        </td>
                                        <td class="dvtCellLabel">
                                            发货联系人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="OutWareOursContact" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="17%" class="dvtCellLabel">
                                            收货客户:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <input type="hidden" name="Tbx_SCustomerValue" id="Tbx_SCustomerValue" runat="server"
                                                style="width: 150px" />
                                            <pc:PTextBox ID="Tbx_SCustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="280px" ReadOnly="true"></pc:PTextBox>
                                            <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick2()" />(<font
                                                color="red">*</font>)
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            订单编号:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <pc:PTextBox ID="Tbx_ContractNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="200px" ReadOnly="true"></pc:PTextBox>
                                            <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            发货要求:
                                        </td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:DropDownList ID="Ddl_FhDetails" runat="server" Width="350px">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="发货要求不能为空"
                                                ControlToValidate="ContractDeliveMethods" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            交货方式:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList ID="ContractDeliveMethods" runat="server" Width="150px">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="交货方式不能为空"
                                                ControlToValidate="ContractDeliveMethods" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            收货联系人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_ContentPerson" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="150px"></asp:TextBox>
                                            <asp:TextBox ID="Tbx_ContentPersonID" runat="server" CssClass="Custom_Hidden" Width="150px"></asp:TextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                onclick="return btnGetContentPerson_onclick()" />(<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="联系人不能为空"
                                                ControlToValidate="Tbx_ContentPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            交货地点:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="ContractToAddress" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="300px"></asp:TextBox>
                                        </td>
                                        <td class="dvtCellLabel">
                                            电话号码:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_Phone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            备注:
                                        </td>
                                        <td class="dvtCellInfo" colspan="4">
                                            <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                cols="90" Rows="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="i_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                    class="crmTable" >
                                    <tr>
                                        <td colspan="17"  class="dvInnerHeader" >
                                            <b>产品详细信息</b>
                                        </td>
                                    </tr>
                                    <!-- Header for the Product Details -->
                                    <tr valign="middle" align="center">
                                        <td valign="middle" class="ListHead" align="right"  >
                                            <b>工具</b>
                                        </td>
                                        <td class="ListHead">
                                            <b>合同编号</b>
                                        </td>
                                        <td class="ListHead">
                                            <b>产品名称</b>
                                        </td>
                                        <td class="ListHead"  >
                                            <b>型号</b>
                                        </td>
                                        <td class="ListHead"  >
                                            <b>合同</b>
                                        </td>
                                        <td class="ListHead"  >
                                            <b>未发</b>
                                        </td>
                                        <td class="ListHead"  >
                                            <b>发货</b>
                                        </td>
                                        <td class="ListHead"  >
                                            <b>备品</b>
                                        </td>
                                        <td class="ListHead"  >
                                            <b>单价</b>
                                        </td>
                                        <td  class="ListHead">
                                            <b>金额</b>
                                        </td>
                                        <td class="ListHead"  nowrap>
                                            <b>计划单号</b>
                                        </td>
                                        <td class="ListHead"  nowrap>
                                            <b>订单号</b>
                                        </td>
                                        <td class="ListHead"  nowrap>
                                            <b>客户料号</b>
                                        </td>
                                        <td class="ListHead"  nowrap>
                                            <b>客户型号</b>
                                        </td>
                                        <td class="ListHead"  nowrap>
                                            <b>是否随货</b>
                                        </td>
                                        <td class="ListHead" nowrap  >
                                            <b>备注</b>
                                        </td>
                                    </tr>
                                        
                                    <%=s_MyTable_Detail %>
                                </table>
                                <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                    <tr>
                                        <td colspan="3">
                                            ①选择产品:
                                            <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
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
                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;">
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
