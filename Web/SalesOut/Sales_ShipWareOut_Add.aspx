<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_ShipWareOut_Add.aspx.cs"
    Inherits="Web_Sales_Sales_ShipWareOut_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>发货出库管理</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("SelectSalesShipList.aspx?ID=" + intSeconds + "&State=1", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('ShipNoSelectValue').value = ss[0];
                document.all('Tbx_ShipNoName').value = ss[1];
            }
            else {
                document.all('ShipNoSelectValue').value = "";
                document.all('Tbx_ShipNoName').value = "";
            }
        }
        function btnGetReturnValue_onclick1() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
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

        function btnGetReturnValue_onclick2() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
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
                    document.all('Tbx_ShipType').value = TS[6];
                    document.all('Tbx_MaterNumber').value = TS[7];
                    document.all('Tbx_OrderNo').value = TS[8];
                    document.all('Tbx_PlanNo').value = TS[9];

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
        function btnGetBackValue_onclick() {
            document.all('ContractNoSelectValue').value = "";
            document.all('ContractNoName').value = "";
        }
        function btnGetProducts_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectKNet_WareHouse_Ownall.aspx?sID=" + document.all("Xs_ProductsCode").value + "&isModiy=" + document.all("Tbx_ID").value + "&OutWareNo=" + document.all("OutWareNo").value + "&HouseNo=" + document.all("Ddl_HouseNo").value + " ", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=yes; menubar=yes;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");

            if (tempd != undefined) {
                var ss, s_Value, i_row;
                ss = tempd.split("|");
                i_row = myTable.rows.length;
                s_ID = document.all("Xs_ProductsCode").value;
                var v_Num = document.all("Tbx_Num").value;
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split(",");
                    var objRow = myTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ID_' + parseInt(v_Num + i) + '\" value=' + s_Value[7] + '><input type=\"hidden\"  Name=\"ProductsName_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[0] + '\">' + s_Value[0];
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[1] + '\">' + s_Value[1];
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[2] + '\">' + s_Value[2];
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsEdition_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[3] + '\">' + s_Value[3];
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Number_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[4] + '\" >';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"BNumber_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[6] + '\" >';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"PlanNo_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[11] + '\" >';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"OrderNo_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[8] + '\" >';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"MaterNo_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[9] + '\" >';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"CustomerProductsName_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[10] + '\" >';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"IsFollow_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[12] + '\" >';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Remarks_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[5] + '\" >';
                    objCel.className = "dvtCellInfo";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[1] + ",";
                }

                document.all("Tbx_Num").value = v_Num + ss.length - 1;
                document.all("Xs_ProductsCode").value = s_ID;
            }
        }

        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var bm_num = "";
            var v_Num = document.all("Tbx_Num").value;
            for (i = 0; i < v_Num; i++) {
                bm_num += document.all("ProductsBarCode_" + i + "").value + ",";
            }
            document.all("Xs_ProductsCode").value = bm_num;
        }
        function btnGetContentPerson_onclick() {
            var s_Customer = "";
            s_Customer = document.all('Tbx_CustomerValue').value;
            var temaap = window.showModalDialog("../Common/SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

            if (temaap != undefined) {
                var sws;
                sws = temaap.split(",");
                document.all('Tbx_ContentPerson').value = sws[0];
                document.all('Tbx_TelPhone').value = sws[1];
                document.all('Tbx_Address').value = sws[3];
            }
            else {
                document.all('Tbx_ContentPerson').value = "";
                document.all('Tbx_TelPhone').value = "";
                document.all('Tbx_Address').value = "";

            }
        }
        function Btn_Chang() { 

        }

        function searchFromSelect(o, str) {
            if (o.tagName == "SELECT") {
                var opts = o.options;
                str = str ? str : event.srcElement.innerText;

                var tmp = '';
                var kCode = event.keyCode;

                if (str != "") {
                    if (kCode == 33 || kCode == 38 || kCode == 35)//向上翻页，方向键，end
                    {
                        o.selectedIndex = o.selectedIndex > 0 ? o.selectedIndex - 1 : 0;
                        if (kCode == 35) o.selectedIndex = opts.length - 1;
                        for (var i = o.selectedIndex; i >= 0; i--) {
                            tmp = opts(i % opts.length).text;
                            if (tmp.indexOf(str) >= 0) {
                                o.selectedIndex = i % opts.length;
                                return;
                            }
                        }
                    }
                    if (kCode == 34 || kCode == 40 || kCode == 36)//
                    {
                        o.selectedIndex++;
                        if (kCode == 36) o.selectedIndex = opts.length - 1;
                    }
                    for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex); i++) {
                        tmp = opts(i % opts.length).text;
                        if (tmp.indexOf(str) >= 0) {
                            o.selectedIndex = i % opts.length;
                            return;
                        }
                    }
                    o.selectedIndex = 0;
                }
            }
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
                发货出库 > <a class="hdrLink" href="Sales_ShipWareOut_Manage.aspx">发货出库</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
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
                                            出库单信息
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
                                            &nbsp;出库单号:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_DirectInNo" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="40" runat="server"></asp:TextBox>
                                            <asp:TextBox ID="Tbx_CwCode" runat="server" Width="150px" Style="display: none"></asp:TextBox>(<font
                                                color="red">*</font>)唯一性<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="发货单号不能为空"
                                                ControlToValidate="Tbx_DirectInNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            发货单号:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="OutWareNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="150px" ReadOnly="true"></asp:TextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                onclick="return btnGetReturnValue_onclick()" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            出库日期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_DirectInDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="出库日期非空"
                                                ControlToValidate="Tbx_DirectInDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            要求日期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_ReceTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="要求日期非空"
                                                ControlToValidate="Tbx_ReceTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="17%" class="dvtCellLabel">
                                            结算客户:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                onclick="return btnGetReturnValue_onclick1()" />(<font color="red">*</font>)
                                            <pc:PTextBox ID="Tbx_CustomerValue" runat="server" CssClass="Custom_Hidden" />
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            收货客户:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <pc:PTextBox ID="Tbx_SCustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                onclick="return btnGetReturnValue_onclick2()" />(<font color="red">*</font>)
                                            <pc:PTextBox ID="Tbx_SCustomerValue" runat="server" CssClass="Custom_Hidden" />
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
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Ddl_DutyPerson"
                                                Display="Dynamic" ErrorMessage="责任人非空"></asp:RequiredFieldValidator>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            仓库:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList ID="Ddl_HouseNo" runat="server" Width="180px">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="预出仓库不能为空"
                                                ControlToValidate="Ddl_HouseNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            发货联系人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="OutWareOursContact" runat="server" MaxLength="40" Width="180px"
                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>(<font color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="收货联系人不能为空"
                                                ControlToValidate="OutWareOursContact" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            收货联系人:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_ContentPerson" runat="server" CssClass="detailedViewTextBox"
                                                Width="180px" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                MaxLength="48"></asp:TextBox>
                                            <asp:TextBox ID="Tbx_ContentPersonID" runat="server" CssClass="Custom_Hidden" MaxLength="48"></asp:TextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                onclick="return btnGetContentPerson_onclick()" />(<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="收货联系人不能为空"
                                                ControlToValidate="Tbx_ContentPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            交货地点:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_Address" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="300px"></asp:TextBox>
                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="交货地点不能为空"
                                                ControlToValidate="Tbx_Address" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
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
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            联系电话:
                                        </td>
                                        <td class="dvtCellInfo" >
                                            <asp:TextBox ID="Tbx_TelPhone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="300px"></asp:TextBox>
                                            
                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="联系电话不能为空"
                                                ControlToValidate="Tbx_TelPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td width="17%" class="dvtCellLabel">
                                            入库仓库:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList ID="Ddl_RkHouseNo" runat="server" Width="180px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            备注:
                                        </td>
                                        <td class="dvtCellInfo" colspan="4">
                                            <asp:TextBox ID="Tbx_DirectInRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                cols="90" Rows="8"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                    class="ListDetails" style="height: 28px">
                                    <tr>
                                        <td colspan="13" class="dvInnerHeader">
                                            <b>产品详细信息</b>
                                        </td>
                                    </tr>
                                    <!-- Header for the Product Details -->
                                    <tr valign="top">
                                        <td valign="top" class="ListHead" align="right" nowrap>
                                            <b>工具</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>产品名称</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>产品编码</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>型号</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>版本号</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>数量</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>备品数量</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>计划单号</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>订单号</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>客户料号</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>客户型号</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>随货</b>
                                        </td>
                                        <td class="ListHead" nowrap>
                                            <b>备注</b>
                                        </td>
                                    </tr>
                                    <%=s_MyTable_Detail %>
                                </table>
                                <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                    <!-- Add Product Button -->
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
