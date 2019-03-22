<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Product_Prototype_InOut.aspx.cs" Inherits="Web_Complain_Knet_Product_Prototype_InOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link href="../../themes/softed/style.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>

    <script src="../../assets/js/libs/jquery-1.10.2.min.js"></script>
    <title>采购管理</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            debugger;
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            if (document.all('Tbx_OrderNo').value == "") {
                var tempd = window.open("SelectSuppliers.aspx?ID=" + intSeconds + "&callback=SetReturnValueInOpenner_Suppliers1", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }
                //var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            else {
                // alert("dfd")
                var tempd = window.open("SelectSuppliers.aspx?ID=" + intSeconds + "&Tbx_ID=" + document.all('Tbx_OrderNo').value + "&callback=SetReturnValueInOpenner_Suppliers12", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }
        }
        function SetReturnValueInOpenner_Suppliers1(temp) {
            debugger;
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('SuppNoSelectValue').value = ss[0];
                document.all('SuppNo').value = ss[1];
                document.all('OrderNo').value = ss[2];
                //if (ss[5] != "") {
                //    for (var i = 1; i <= ss[5]; i++) {
                //        var aa = ss[6].split(",");
                //        document.all('HandPrice_' + i - 1).value = aa[i - 1];
                //        document.all('HandMoney_' + i - 1).value = document.all('HandMoney_' + i - 1).value * document.all('Number_' + i - 1).value
                //    }
                //}

            }
            else {
                document.all('SuppNoSelectValue').value = "";
                document.all('SuppNo').value = "";
                document.all('OrderNo').value = "";
            }
        }
        function SetReturnValueInOpenner_Suppliers12(temp) {
            debugger;
            if (temp != undefined) {

                var ss;
                ss = temp.split("|");
                if (ss[5] == 0) {
                    alert("所选加工厂对应的产品的加工费还没有报价或者还没审核")
                } else {
                    document.all('SuppNoSelectValue').value = ss[0];
                    document.all('SuppNo').value = ss[1];
                    document.all('OrderNo').value = ss[2];
                    //alert(ss[5])
                    //if (ss[5] != "") {
                    //for (var s = 0; s < ss[5]; i++) {

                    //}
                    var g = 1;
                    var aa = ss[6].split(",");
                    var bb = ss[7].split(",");
                    for (var i = 1; i <= ss[5]; i++) {
                        var vr = document.all('ProductsBarCode_' + (i - 1)).value
                        // if (vr !== bb[i-1]) {
                        // if ((i + 1) >= ss[5]) {

                        document.all('HandPrice_' + (i - 1)).value = aa[i - 1];
                        //alert(aa[i-1]* document.all('Number_' + (i - 1)).value);
                        document
                            .all('HandMoney_' + (i - 1))
                            .value = aa[i - 1] * document.all('Number_' + (i - 1)).value;
                        g = g - 1;

                    }
                    //}
                }


            }
            else {
                document.all('SuppNoSelectValue').value = "";
                document.all('SuppNo').value = "";
                document.all('OrderNo').value = "";
            }
        }
        function TextisNaN(t) {
            if (t == "") {

                alert(t + " 为空不能保存");
            }
            else {
                if (isNaN(t)) {
                    alert(t + " 不是数字");
                }
            }
        }
        function btnSelectOrder_onclick() {

            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectOrder.aspx?WhereID=220", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=550px");
            var temp = window.open("SelectOrder.aspx?WhereID=31", "选择订单", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Order(temp) {
            if (temp != undefined) {
                document.all('OrderFaterNo').value = temp;
            }
            else {
                document.all('OrderFaterNo').value = "";
            }
        }

        function btnGetReturnValue_onclick2() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("SelectSuppliers.aspx?ID=" + intSeconds + "&callback=SetReturnValueInOpenner_Suppliers2", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Suppliers2(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('SuppNoSelectValue2').value = ss[0];
                document.all('SuppNo2').value = ss[1];
                document.all('OrderNo2').value = ss[2];

            }
            else {
                document.all('SuppNoSelectValue2').value = "";
                document.all('SuppNo2').value = "";
                document.all('OrderNo2').value = "";
            }
        }

        function btnGetReturnValue_onclick1() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var vr = "";
            //var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=780px;dialogHeight=550px");
            var temp = window.open("SelectSuppliers.aspx?ID=" + intSeconds + "&selectValue=" + vr + "&Type=128860698200781250&callback=SetReturnValueInOpenner_Suppliers3", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }//129652784259578018
        function SetReturnValueInOpenner_Suppliers3(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.getElementById("Tbx_SuppNo").value = ss[0];
                document.getElementById("Tbx_SuppName").value = ss[1];
                document.all('OrderAddress').value = ss[3].replace(/\$/g, "\n");
                objSelect = document.getElementById("Ddl_HouseNo");

                for (var i = 0; i < objSelect.options.length; i++) {
                    if (objSelect.options[i].value == ss[4]) {
                        objSelect.options[i].selected = true;
                        isExit = true;
                    }
                }
            }
            else {
                document.all('Tbx_SuppNo').value = "";
                document.all('Tbx_SuppName').value = "";
                document.all('OrderAddress').value = "";
            }
        }

        function btnGetReturnOrderValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectSalesContractList.aspx", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            var temp = window.open("SelectSalesContractList.aspx", "选择订单", "width=1000px, height=600px,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ContractList(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('SalesOrderNoSelectValue').value = ss[0];
                document.all('SalesOrderNo').value = ss[1];
                document.all('OrderAddress').value = ss[2].replace(/\$/g, "\n");
                document.all('OrderRemarks').value = ss[3];
                var response = Knet_Web_Procure_Knet_Procure_OrderList.GetScDetails(ss[1]);
                document.all('Tbx_ScDetails').value = response.value;

            }
            else {
                document.all('SalesOrderNoSelectValue').value = "";
                document.all('SalesOrderNo').value = "";
                document.all('OrderAddress').value = "";
                document.all('OrderRemarks').value = "";
                document.all('Tbx_ScDetails').value = "";
            }
        }
        function btnGetProducts_onclick() {
            debugger;
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
           // var TxbSuppNo = document.all('SuppNo').value;
           
            var tempd = window.open("../Complain/SelectGauge.aspx?SuppNo=" + document.all('Ddl_HouseNoOut').value + "", "选择治具", "width=1200px, height=900,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
           
            //var tempd = window.showModalDialog("SelectSuppliersPrice.aspx?sID=" + document.all("Xs_ProductsCode").value + "&SuppNo=" + document.all("SuppNoSelectValue").value + "&Contract=" + document.all("SalesOrderNo").value + "&isModiy=" + document.all("Tbx_ID").value + " ", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");

        }
        function SetReturnValueInOpenner_SuppliersPrice(tempd) {
            if (tempd != undefined) {
                var ss, s_Value, i_row;
                ss = tempd.split("|");
                i_row = myTable.rows.length;
                s_ID = document.all("Xs_ProductsCode").value;
                var v_Num = document.all("Tbx_Num").value;
                var v_SuppNo = "", v_SuppName = "", v_HouseNo = "";
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split(",");
                    var objRow = myTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    var v_NumInt = parseInt(v_Num) + parseInt(i)
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"Code_' + v_NumInt + '\" value=' + s_Value[0] + '>' + s_Value[0];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"Name_' + v_NumInt + '\" value=' + s_Value[1] + '>' + s_Value[1];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"KCount_' + v_NumInt + '\" value=' + s_Value[2] + '>' + s_Value[2];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Number_' + v_NumInt + '\" value="0" >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"BadNumber_' + v_NumInt + '\" value="0" >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:140px;"  Name=\"Remarks_' + v_NumInt + '\" value="" >';
                    objCel.className = "ListHeadDetails";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[1] + ",";
                    v_SuppNo = s_Value[10];
                    v_SuppName = s_Value[11];
                    v_HouseNo = s_Value[12];
                }

                document.all("Tbx_Num").value = parseInt(v_Num) + ss.length - 1;
                document.all("Xs_ProductsCode").value = s_ID;
                if (v_SuppNo != "") {

                    var response = Knet_Web_Procure_Knet_Procure_OrderList.KNetOddNumbers(v_SuppNo, document.all('Tbx_Title').value, document.all('OrderNo').value);
                    document.all('OrderNo').value = response.value;
                }
            }
        }

        function ChangPrice() {
            debugger;
            var num = document.all('Tbx_Num').value;
            for (var i = 0; i < num; i++) {

                document.all("Money_" + i).value = document.all("Price_" + i).value * document.all("Number_" + i).value;

            }
        }
        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("ProductsBarCode");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Xs_ProductsCode").value = bm_num;
        }

    </script>
    <script src="../DatePicker/WdatePicker.js"></script>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>治具库 > <a class="hdrLink" href="Knet_Sampling_OpenBilling.aspx">选择治具</a>
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
                    <img src="../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>治具出入信息
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
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="304" align="right" valign="top">
                                                <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">出入单号:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox ID="TextBox1" MaxLength="45" runat="server" Width="200px" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>(<font
                                                                    color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="采购单号不能为空"
                                                            ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="dvtCellLabel">出入日期:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="KSP_Stime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                                color="red">*</font>)<br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="送检日期非空"
                                                                ControlToValidate="KSP_Stime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td width="17%" height="25" align="right" class="dvtCellLabel">领出处:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_HouseNoOut"></asp:DropDownList>
                                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="所在处不能为空"
                                                ControlToValidate="Ddl_HouseNoOut" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                         <td width="17%" height="25" align="right" class="dvtCellLabel">领入处:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_HouseNoIn"></asp:DropDownList>
                                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="所在处不能为空"
                                                ControlToValidate="Ddl_HouseNoIn" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                       
                                                    </tr>


                                                    <tr>

                                                        <td width="17%" class="dvtCellLabel">领用人:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server"
                                                                Width="100px">
                                                            </asp:DropDownList>
                                                            (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择领用人"
                                                            ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                         <td width="17%" height="25" align="right" class="dvtCellLabel">领出/归还:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_OutOrIn"></asp:DropDownList>
                                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="所在处不能为空"
                                                ControlToValidate="Ddl_OutOrIn" Display="Dynamic"></asp:RequiredFieldValidator>

                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">&nbsp;类别:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="BClass" runat="server"></asp:DropDownList>(<font color="red">*</font>)
                                                        </td>
                                                         <td height="20" align="right" class="dvtCellLabel">备注说明:
                                                        </td>
                                                        <td align="left" valign="top" class="dvtCellInfo">
                                                            <asp:TextBox ID="OrderRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="400px" Height="50px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="OrderRemarks"
                                                                ValidationExpression="^(\s|\S){0,500}$" ErrorMessage="备注说明太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                                            <asp:TextBox ID="OrderCheckStaffNo" runat="server" CssClass="Custom_Hidden" Width="150px"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <asp:Label ID="OrderCheckStaffNotxt" runat="server" Visible="false"></asp:Label>
                                                            <asp:TextBox ID="OrderStaffNo" runat="server" CssClass="Custom_Hidden" Width="150px"
                                                                ReadOnly="true"></asp:TextBox>
                                                            <asp:Label ID="OrderStaffNotxt" runat="server" Text="" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <td colspan="4" class="dvInnerHeader" align="left">
                                                        <b>治具详细信息</b>
                                                    </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="left">
                                                <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_Num" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                    class="ListDetails" style="height: 28px">
                                                    <!-- Header for the Product Details -->
                                                    <tr valign="top">
                                                        <td valign="top" class="ListHead" align="right" nowrap>
                                                            <b>工具</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>治具编号</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>治具名称</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>库存数量</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>申请数量</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>损坏数量</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>备注</b>
                                                        </td>

                                                    </tr>
                                                     <asp:Label runat="server" ID="s_MyTable_Detail"></asp:Label>
                                                </table>
                                                <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                                    <!-- Add Product Button -->
                                                    <tr>
                                                        <td colspan="3">①选择治具:
                                                        <input type="button" name="Button" class="crmbutton small create" value="添加治具" onclick="btnGetProducts_onclick();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center" style="height: 30px">
                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClick="Button1_Click" Style="width: 55px; height: 30px;" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                        type="button" name="button" value="取 消" style="width: 55px; height: 30px">
                                </td>
                            </tr>
                        </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="OrderNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_OrderNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_Title" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_Change" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_OldID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Sampling" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="SamplingID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        </td> </tr> </table> </td>
    <td align="right" valign="top">
        <img src="../../../themes/softed/images/showPanelTopRight.gif" />
    </td>
        </tr> </table>
    </form>
</body>
</html>
