<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_WareHouse_AllocateList_Add.aspx.cs" Inherits="Knet_Web_WareHouse_KNet_WareHouse_AllocateList_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <title>库间调拨添加</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("/Web/Common/SelectSalesShipList.aspx?ID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var temp = window.open("/Web/Common/SelectSalesShipList.aspx?ID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_SalesShip(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('OutWareNoSelectValue').value = ss[0];
                document.all('OutWareNoName').value = ss[1];
            }
            else {
                document.all('OutWareNoSelectValue').value = "";
                document.all('OutWareNoName').value = "";
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JAVASCRIPT">

        function btnGetProducts_onclick() {
            //alert('如果此次操作需要上传附件，请先上传附件再选择产品！如果不需要附件请继续操作！');
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&HouseNo=" + document.all("HouseNo_out").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
            var tempd = window.open("SelectProducts.aspx?HouseNo=" + document.all("HouseNo_out").value + "", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }

        function Submitcheck() {
            debugger;
            var v_Num = "";

            v_Num = document.all("Tbx_Num").value;
            var type = document.all("Tbx_Type").value;
            if (v_Num != "") {
                var v_Right = "";
                if (type == "3") {
                    for (var i = 0; i < parseInt(v_Num) ; i++) {

                        if (document.all("KcNumber_" + i.toString()).value != null) {
                            var KcNumber = document.all("KcNumber_" + i.toString()).value;
                            var Number = document.all("Number_" + i.toString()).value;
                            var ryNumber = document.all("YrkNumber_" + i.toString()).value;
                            if ((parseInt(KcNumber) - parseInt(ryNumber)) < parseInt(Number)) {
                                v_Right = "1"
                            }
                        }
                    }
                } else {
                    for (var i = 0; i < parseInt(v_Num) ; i++) {

                        if (document.all("KcNumber_" + i.toString()).value != null) {
                            var KcNumber = document.all("KcNumber_" + i.toString()).value;
                            var Number = document.all("Number_" + i.toString()).value;

                            if (parseInt(KcNumber) < parseInt(Number)) {
                                v_Right = "1"
                            }
                        }
                    }
                }
                if (v_Right == "1") {
                    alert("不能小于库存数，请先补足库存！");
                    return false;
                }
            }
        }
        function SetReturnValueInOpenner_Products(tempd) {
            if (tempd != undefined) {
                debugger;
                var i_num1 = parseInt(document.all('Tbx_Num').value);
                document.all('Tbx_Num').value = i_num1;
                var ss, ss1, s_Value, i_row;
                ss1 = tempd.split("|");
                s_ID = document.all("Xs_ProductsCode").value;
                for (var i = 0; i < ss1.length - 1; i++) {
                    var ss = ss1[i].split(",");
                    i_row = myTable.rows.length;
                    var objRow = myTable.insertRow(i_row);
                    i_num1 = parseInt(i_num1) + parseInt(i);

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
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

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Tbx_CPBZNumber_' + i_num1 + '\" value="0" >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Tbx_BZNumber_' + i_num1 + '\" value="0" >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Number_' + i_num1 + '\" value=' + ss[3] + '  >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;"  Name=\"Remarks_' + i_num1 + '\"  >';
                    objCel.className = "ListHeadDetails";
                    i_row = i_row + 1;

                    document.all('Tbx_Num').value = parseInt(document.all('Tbx_Num').value) + ss1.length - 1;
                    s_ID = s_ID + ss[0] + ",";
                }

                document.all("Xs_ProductsCode").value = s_ID;
            }
        }
        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        }
        function GetNumber() {
            //
            var v_MainTotalNum = document.all("Tbx_Number1").value;
            var v_TotalNum = document.all("Tbx_Num").value;
            var Type = document.all("Chk_Type").checked;
            for (var i_Num1 = 0; i_Num1 < parseInt(v_MainTotalNum) ; i_Num1++) {
                //
                i_flag = 0;
                var v_MainProductsBarCode = document.all("MainProductsBarCode_" + i_Num1 + "").value;
                var v_MainProductsNumber = document.all("MainNumber_" + i_Num1 + "").value;
                for (var i_Num = 0; i_Num < parseInt(v_TotalNum) ; i_Num++) {
                    //
                    var v_FaterBarCode = document.all("FaterBarCode_" + i_Num.toString() + "").value;
                    if (v_MainProductsBarCode == v_FaterBarCode) {
                        var v_BomNumber = document.all("BomNumber_" + i_Num.toString() + "").value;
                        document.all("Number_" + i_Num.toString() + "").value = parseInt(v_BomNumber) * parseInt(v_MainProductsNumber);
                        i_flag = 1;
                    }
                }
                if (parseInt(v_MainTotalNum) == 1)
                { i_flag = 0; }
                if (i_flag == 0) {
                    for (var i_Num = 0; i_Num < parseInt(v_TotalNum) ; i_Num++) {
                        //
                        var v_FaterBarCode = document.all("FaterBarCode_" + i_Num.toString() + "").value
                        var v_BomNumber = document.all("BomNumber_" + i_Num.toString() + "").value;
                        document.all("Number_" + i_Num.toString() + "").value = parseInt(v_BomNumber) * parseInt(v_MainProductsNumber);
                    }
                }
            }
            if (Type == false) {
                ChangPrice();
            }
        }

        function ChangPrice() {
            var num = document.all('Tbx_Num').value;
            var ID = document.all('Tbx_ID').value;
            if (ID == "") {
                for (var i = 0; i < num; i++) {
                    var CPBZNumber = document.all("Tbx_CPBZNumber_" + i).value;
                    var BZNumber = document.all("Tbx_BZNumber_" + i).value
                    if ((CPBZNumber != 0) && (BZNumber != 0)) {
                        document.all("Number_" + i).value = CPBZNumber * BZNumber;
                    }
                }
            }
        }
        function ChangPrice1(i) {
            var ID = document.all('Tbx_ID').value;
            var CPBZNumber = document.all("Tbx_CPBZNumber_" + i).value;
            var BZNumber = document.all("Tbx_BZNumber_" + i).value
            if ((CPBZNumber != 0) && (BZNumber != 0)) {
                document.all("Number_" + i).value = CPBZNumber * BZNumber;
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>仓库 > <a class="hdrLink" href="KNet_WareHouse_AllocateList_Manage.aspx">调拨单添加</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_SuppNo" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="KSP_SID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="SubCode" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Sumb" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtSelectedCell" align="center" nowrap>调拨单信息
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
                                            <td class="dvtCellLabel">&nbsp;调拨单号:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="AllocateNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="调拨单号不能为空"
                                                    ControlToValidate="AllocateNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">调拨日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="AllocateDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="调拨日期非空"
                                                    ControlToValidate="AllocateDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;调出仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="HouseNo_out" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="调出仓库不能为空" ControlToValidate="HouseNo_out" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">调入仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="HouseNo_int" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="调入仓库不能为空" ControlToValidate="HouseNo_int" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">调拨类型:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Type" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="调拨类型不能为空" ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">生产订单号:
                                            </td>
                                            <td class="dvtCellInfo">

                                                <asp:TextBox ID="Tbx_OrderNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="150px"></asp:TextBox><%--Enabled="false"--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">按耗料调拨:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:CheckBox runat="server" ID="Chk_Type" AutoPostBack="true" OnCheckedChanged="Chk_Type_CheckedChanged" />
                                            </td>
                                            <td class="dvtCellLabel">消耗库存:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:CheckBox runat="server" ID="Chk_KC" AutoPostBack="true" OnCheckedChanged="Chk_Type_CheckedChanged" />
                                            </td>
                                        </tr>
                                        <tr>
                                             <td class="dvtCellLabel">是否实物:
                                            </td>
                                            <td class="dvtCellInfo">
                                               <input type="checkbox" runat="server" id="IsEntity" checked="True"/>
                                            </td>
                                            <td class="dvtCellLabel">附件:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="KPS_InvoiceUrl1" runat="server" Text="" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="KPS_Invoice1" runat="server" Text="" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:Label runat="server" ID="Lbl_Details1"></asp:Label><input id="uploadFile2"
                                                    type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button2" type="button"
                                                        value="上传" runat="server" class="crmbutton small save" onserverclick="button2_OnServerClick" causesvalidation="false" />
                                                (<font color="red">*</font>)
                                            </td>
                                        </tr>

                                        <tr>
                                             <td class="dvtCellLabel">调拨原因:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="AllocateCause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        runat="server" ControlToValidate="AllocateCause" ValidationExpression="^(\s|\S){0,500}$"
                                                        ErrorMessage="调拨原因太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="dvtCellLabel">备注说明:
                                            </td>
                                            <td class="dvtCellInfo" >
                                                <asp:TextBox ID="AllocateRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                        runat="server" ControlToValidate="AllocateCause" ValidationExpression="^(\s|\S){0,500}$"
                                                        ErrorMessage="调拨原因太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                            <%-- <td class="dvtCellLabel">送检级别:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:CheckBox runat="server" ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="Chk_Type_CheckedChanged" />
                                            </td>--%>
                                        </tr>
                                        <tr runat="server" id="Tr_Order" visible="false">
                                            <td colspan="4" class="dvInnerHeader">
                                                <b>订单明细</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="Tbx_Number1" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                <table id="myTableMail" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                    class="crmTable" style="height: 28px">
                                                    <asp:Label runat="server" ID="Lbl_DetailsMail"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="dvInnerHeader">
                                                <b>产品详细信息</b>
                                            </td>
                                        </tr>

                                    </table>
                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="KWAD_DirectOutNo" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="TextBox1" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                        class="crmTable" style="height: 28px">
                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                    </table>
                                    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                        <!-- Add Product Button -->
                                        <tr>
                                            <td colspan="3">①选择产品:
                                            <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
                                            </td>
                                        </tr>
                                       <%-- <tr colspan="2">
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <input type="button" runat="server" id="Btn_Create" value="确   定" OnServerClick="Btn_Create_OnServerClick" class="crmbutton small create" />
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">&nbsp;
                                <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClientClick="return Submitcheck();" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                        type="button" name="button" value="取 消" style="width: 55px; height: 33px;"><%--OnClientClick="return Submitcheck();"--%>
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
