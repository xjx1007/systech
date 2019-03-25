<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_WareHouse_DirectOut_Add.aspx.cs" Inherits="Knet_Web_WareHouse_KNet_WareHouse_DirectOut_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <title>出库添加</title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();

            var temp = window.open("../Common/SelectSalesShipList.aspx?ID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");

            //var temp = window.showModalDialog("../Common/SelectSalesShipList.aspx?ID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        }
        function SetReturnValueInOpenner_SalesShip(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('OutWareNoSelectValue').value = ss[0];
                document.all('OutWareNoName').value = ss[1];
                document.all("Money").value = ss[6];
            }
            else {
                document.all('OutWareNoSelectValue').value = "";
                document.all('OutWareNoName').value = "";
            }
        }
        function GetNumber() {
            var v_Num = document.all('Tbx_Num').value;
            var v_TotalNumber = document.all('Tbx_MainNumber').value;
            for (var i = 0; i < parseInt(v_Num) ; i++) {
                var v_NeedNumber = document.all('BomNumber_' + i + '').value
                document.all('Number_' + i + '').value = v_NeedNumber * v_TotalNumber;
            }

        }

    </script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JAVASCRIPT">
        function btnGetProducts_onclick() {
            //alert('如果此次操作需要上传附件，请先上传附件再选择产品！如果不需要附件请继续操作！')
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            if (document.getElementById("Chk_IsSuppNo").checked) {
                var temp = window.open("SelectProducts.aspx?HouseNo=" + document.all("HouseNo").value + "&&" + "Chk_IsSuppNo=true", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }
            else {
                var tempd = window.open("SelectProducts.aspx?HouseNo=" + document.all("HouseNo").value + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }
            //var tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&HouseNo=" + document.all("HouseNo").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");

        }
        function SetReturnValueInOpenner_Products(tempd) {

            if (tempd != undefined) {
                var i_num1 = parseInt(document.all('Tbx_Num').value);
                var ss, ss1, s_Value, i_row;
                ss1 = tempd.split("|");
                s_ID = document.all("Xs_ProductsCode").value;
                var moneycount = 0;
                document.getElementById("moneycount").innerText = moneycount;

                var count = 0;
                document.getElementById("count").innerText = count;
                for (var i = 0; i < ss1.length - 1; i++) {
                    var ss = ss1[i].split(",");
                    i_row = myTable.rows.length;
                    var objRow = myTable.insertRow(i_row);
                    i_num1 = parseInt(document.all('Tbx_Num').value) + parseInt(i)
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsName_' + i_num1 + '\" value=' + ss[0] + '>' + ss[0];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode_' + i_num1 + '\" value=' + ss[1] + '>' + ss[1];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern_' + i_num1 + '\" value=' + ss[2] + '>' + ss[2];
                    objCel.className = "ListHeadDetails";

                    //var objCel = objRow.insertCell();
                    //objCel.innerHTML = '<input style=\"display:none\" Name=\"KCNumber_' + i_num1 + '\" value=' + ss[8] + '>';
                    //objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Number_' + i_num1 + '\" value=' + ss[3] + ' >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Price_' + i_num1 + '\" value=' + ss[4] + ' >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Money_' + i_num1 + '\" value=' + ss[5] + ' >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"BPrice_' + i_num1 + '\"  value=' + ss[6] + ' >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"BMoney_' + i_num1 + '\" value=' + ss[7] + ' >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;"  Name=\"Remarks_' + i_num1 + '\"    >';
                    objCel.className = "ListHeadDetails";
                    moneycount = eval(moneycount + "+" + ss[5]);
                    count = eval(count + "+" + ss[3]);
                    //alert(moneycount)
                    i_row = i_row + 1;
                    s_ID = s_ID + ss[0] + ",";
                }
                //document.all('moneycount').value = moneycount;
                document.getElementById("moneycount").innerText = moneycount;
                document.getElementById("count").innerText = parseInt(document.getElementById("count").innerText) + count;
                document.all('Tbx_Num').value = parseInt(document.all('Tbx_Num').value) + ss1.length - 1;;

                document.all("Xs_ProductsCode").value = s_ID;
            }
        }
        ///计算
        function ChangPrice() {
            var num = document.all('Tbx_Num').value;
            var moneycount = 0;
            var count = 0;
            for (var i = 0; i < num; i++) {
                //var CPBZNumber = document.all("CPBZNumber_" + i).value;
                // var BZNumber = document.all("BZNumber_" + i).value;
                //if ((CPBZNumber != 0) && (BZNumber != 0)) {
                //document.all("Number_" + i).value = CPBZNumber * BZNumber;
                document.all("Money_" + i).value = document.all("Price_" + i).value * document.all("Number_" + i).value
                //moneycount += document.all("Money_" + i).value;
                moneycount = eval(moneycount + "+" + document.all("Money_" + i).value);
                count = eval(count + "+" + document.all("Number_" + i).value);
                //document.all("HandMoney_" + i).value = document.all("HandPrice_" + i).value * document.all("Number_" + i).value
                //}
                //else {
                //    document.all("Money_" + i).value = document.all("Price_" + i).value * document.all("Number_" + i).value
                //    document.all("HandMoney_" + i).value = document.all("HandPrice_" + i).value * document.all("Number_" + i).value
                //}
                //TextisNaN(CPBZNumber);
                //TextisNaN(BZNumber);
                //TextisNaN(document.all("Number_" + i).value);
            }
            //document.all('moneycount').value = moneycount;
            document.getElementById("moneycount").innerText = moneycount;
            document.getElementById("count").innerText = count;
        }
        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            ChangPrice();
            var bm_num = "";
            var v_Num = document.all("Tbx_Num").value;
            for (i = 0; i < v_Num; i++) {
                bm_num += document.all("ProductsBarCode_" + i + "").value + ",";
            }
            document.all("Xs_ProductsCode").value = bm_num;
        }
        function btnGetReturnValue_onclick1() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Customer(tempd) {
            if (tempd == undefined) {
                tempd = window.returnValue;
            }
            var sel = document.getElementById("Ddl_DutyPerson");
            var length = sel.length;
            for (var i = length - 1; i >= 0; i--) {
                sel.remove(i);
            }
            var opt = new Option("", "");
            sel.options.add(opt);
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('CustomerValue').value = ss[0];
                document.all('CustomerValueName').value = ss[1];
                var st, sw;
                st = ss[3].split("|");
                if (st.length > 0) {
                    for (var i = 0; i < st.length - 1; i++) {
                        sw = st[i].split(",");
                        var opt = new Option(sw[1] + sw[2], sw[0]);
                        sel.options.add(opt);
                    }
                }

            }
            else {
                document.all('CustomerValue').value = "";
                document.all('CustomerValueName').value = "";
                var length = sel.length;
                for (var i = length - 1; i >= 0; i--) {
                    sel.remove(i);
                }
            }
        }
        function Submitcheck() {
            debugger;
            var v_Num = "";
            v_Num = document.all("Tbx_Num").value;
            debugger;
            if (v_Num != "") {
                var v_Right = "";
                for (var i = 0; i < parseInt(v_Num) ; i++) {
                    if ($("KCNumber_" + i.toString() + "") != null) {
                        var KcNumber = $("KCNumber_" + i.toString() + "").value;
                        var Number = $("Number_" + i.toString() + "").value

                        if (parseInt(KcNumber) < parseInt(Number)) {
                            //v_Right = "1"
                            alert("不能小于库存数，请先补足库存！");
                            return false;
                        }
                    }
                }
                if (v_Right == "1") {
                    alert("不能小于库存数，请先补足库存！");
                    return false;
                }
            }
        }
        function btnSelectOrder_onclick() {

            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectOrder.aspx?WhereID=220", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=550px");
            var temp = window.open("../CG/Order/SelectOrder.aspx?WhereID=31", "选择订单", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Order(temp) {
            if (temp != undefined) {
                document.all('OrderFaterNo').value = temp;
            }
            else {
                document.all('OrderFaterNo').value = "";
            }
        }
        function Submitcheck() {
            var suppno = document.all('Remarks').value;
            if (suppno == "") {
                alert('备注说明不能为空！！！');
                return false;
            }
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>仓库 > <a class="hdrLink" href="KNet_WareHouse_DirectOut_Manage.aspx">领用单添加</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Text="" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" Style="display: none"></asp:TextBox>

                    <asp:TextBox ID="Tbx_FaterBarCode" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>领用单信息
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
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;出库单号:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="DirectInNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="出库单号不能为空"
                                                    ControlToValidate="DirectInNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">出库日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="DirectInDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="出库日期非空"
                                                    ControlToValidate="DirectInDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;出库仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="HouseNo" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="仓库不能为空" ControlToValidate="HouseNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;用于项目:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Project" runat="server" Width="150px"></asp:DropDownList>
                                                (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="项目能为空"
                                                ControlToValidate="Ddl_Project" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;主产品:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_MainProducts" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="337px" Enabled="false"></asp:TextBox>
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;数量:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_MainNumber" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetNumber()"
                                                    Width="150px" Text="1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;客户:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <input type="hidden" name="CustomerValue" id="CustomerValue" runat="server" />
                                                <pc:PTextBox ID="CustomerValueName" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                                <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetReturnValue_onclick1()" />
                                            </td>
                                            <td class="dvtCellLabel">联系人:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;供应商承担:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <%--  <asp:CheckBox runat="server" ID="Chk_IsSuppNo" />--%>
                                                <input type="checkbox" runat="server" id="Chk_IsSuppNo" />
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;OEM:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList runat="server" ID="Ddl_SuppNo">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;领用用途:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList runat="server" ID="Ddl_LyType">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;订单号:
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="OrderFaterNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" MaxLength="48" Width="150px" AutoPostBack="True"></asp:TextBox>
                                                <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnSelectOrder_onclick()" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">附件:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="KPS_InvoiceUrl1" runat="server" Text="" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="KPS_Invoice1" runat="server" Text="" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:Label runat="server" ID="Lbl_Details1"></asp:Label><input id="uploadFile2"
                                                    type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button2" type="button"
                                                        value="上传" runat="server" class="crmbutton small save" onserverclick="button2_OnServerClick" causesvalidation="false" />

                                            </td>
                                            <td class="dvtCellLabel">备注说明:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Remarks" TextMode="MultiLine" runat="server" Text="" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                        runat="server" ControlToValidate="Remarks" ValidationExpression="^(\s|\S){0,500}$"
                                                        ErrorMessage="备注说明太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                        class="crmTable" style="height: 28px">
                                        <tr>
                                            <td colspan="10" class="dvInnerHeader">
                                                <b>产品详细信息</b>
                                                <a style="color: brown">总数量：</a>
                                                <a style="color: brown" id="count"></a>&nbsp; &nbsp;   
                                            <a style="color: red">总金额：</a>
                                                <a style="color: red" id="moneycount"></a>
                                            </td>
                                        </tr>
                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                    </table>
                                    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                        <!-- Add Product Button -->
                                        <tr>
                                            <td colspan="3"><%--①选择产品:--%>
                                            <%--<input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />--%>
                                                <div style="float: left">
                                                  ①选择产品: <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
                                                </div>
                                                <div style="float: right">
                                                  ②批量导入: <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <input type="button" runat="server" id="Btn_Create" value="确   定" onserverclick="Btn_Create_OnServerClick" class="crmbutton small create" />
                                                </div>
                                                <div class="clearfloat" style="clear: both"></div>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <input type="text" id="Total_Price" style="display: none" runat="server" />
                            <tr>
                                <td colspan="4" align="center">&nbsp;
                                <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClientClick="return Submitcheck(); " OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                        type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
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
