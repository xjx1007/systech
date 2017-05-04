<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_Sales_ContractList_Add.aspx.cs"
    Inherits="Knet_Web_Salese_KNet_Sales_ContractList_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>新增订单评审</title>
    <base target="_self" />
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectSalesClientList.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss, fh;
                ss = tempd.split("|");
                document.all('CustomerValue').value = ss[0];
                document.all('CustomerValueName').value = ss[1];
                document.all('ContractToAddress').value = ss[2];

                var i_row = myFhTable.rows.length;
                var response = Knet_Web_Salese_KNet_Sales_ContractList_Add.GetFhDetails(ss[0]);
                var i_NRow = document.all('FhNum').value;
                fh = response.value.split("#");
                for (var i = 0; i < fh.length - 1; i++) {
                    var i_num = parseInt(i_NRow) + parseInt(i)
                    var vfh = fh[i].split("|");
                    var objRow = myFhTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type="CheckBox" id=\"Chk_' + i_num + '\" Name=\"Chk_' + i_num + '\"  checked>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"input\" style="height:50px;width:65%;display:none" Name=\"FhName_' + i_num + '\"  value=\"' + vfh[0] + '\" >' + vfh[0];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"input\"  style="height:50px;width:65%;display:none"  Name=\"FhDetails_' + i_num + '\" value=\"' + vfh[1] + '\"  >' + vfh[1];
                    objCel.className = "ListHeadDetails";
                }
                document.all("Lbl_FhDetails1").value = document.all("Lbl_FhDetails").innerHTML;
                document.all('FhNum').value = parseInt(document.all('FhNum').value) + parseInt(fh.length - 1);
                objSelect = document.getElementById("Drop_Payment")
                objSelect1 = document.getElementById("Ddl_DutyPerson")
                for (var i = 0; i < objSelect.options.length; i++) {
                    if (objSelect.options[i].value == ss[5]) {
                        objSelect.options[i].selected = true;
                        isExit = true;
                    }
                }
                for (var i = 0; i < objSelect1.options.length; i++) {
                    if (objSelect1.options[i].value == ss[6]) {
                        objSelect1.options[i].selected = true;
                        isExit = true;
                    }
                }
            }
            else {
                document.all('CustomerValue').value = "";
                document.all('CustomerValueName').value = "";
                document.all('ContractToAddress').value = "";
            }
        }
        function btnGetBaoPriceValue_onclick() {
            var todayff, secondssss;
            todayff = new Date();
            secondssss = todayff.getSeconds();
            var temaap = window.showModalDialog("/Web/Common/SelectBaoPriceList.aspx?sdID=" + secondssss + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=800px");
            if (temaap != undefined) {
                var sws;
                sws = temaap.split("|");
                document.all('BaoPriceNo').value = sws[0];
                document.all('BaoPriceNoName').value = sws[1];
            }
            else {
                document.all('BaoPriceNo').value = "";
                document.all('BaoPriceNoName').value = "";
            }
        }
        function btnGetContentPerson_onclick() {
            var s_Customer = "";
            s_Customer = document.all('CustomerValue').value;
            var temaap = window.showModalDialog("/Web/Common/SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            if (temaap != undefined) {
                var sws;
                sws = temaap.split(",");
                document.all('Tbx_ContentPerson').value = sws[0];
                document.all('Tbx_Telephone').value = sws[1];
            }
            else {
                document.all('Tbx_ContentPerson').value = "";
                document.all('Tbx_Telephone').value = "";
            }
        }
        function btnGetProducts_onclick() {
            var today = new Date();
            var s_Customer = "";
            s_Customer = document.all('CustomerValue').value;
            if (s_Customer == "") {
                alert("请选择客户！")
                return;
            }
            var temp = window.showModalDialog("SelectProducts_Sales.aspx?CustomerValue=" + s_Customer + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no;dialogwidth=1200px;dialogHeight=600px");
            if (temp != undefined) {
                document.all("Xs_ProductsCode").value = "";
                var ss;
                ss = temp.split("|");
                var s_Value, s_ProductsInfo, i_row, s_ID, i_num2;
                s_ID = document.all("Xs_ProductsCode").value;
                i_row = myTable.rows.length;
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split('#');
                    var response = Knet_Web_Salese_KNet_Sales_ContractList_Add.GetProductsInfo(s_Value[0])
                    s_ProductsInfo = response.value.split('#');
                    var objRow = myTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";
                    i_num2 = i + parseInt(document.all("i_Num").value);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = s_ProductsInfo[0];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode_' + i_num2 + '\" value=' + s_Value[0] + '>' + s_Value[0];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = s_ProductsInfo[1];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;" Name=\"LeftTotalBhNumber_' + i_num2 + '\" value=' + s_Value[11] + '>';
                    objCel.className = "ListHeadDetails";
                    var v_Checked = s_Value[12];
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\" Name=\"HxState_' + i_num2 + '\" value=' + v_Checked + '><input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;" Name=\"HxNumber_' + i_num2 + '\" value="">';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:50px;" Name=\"Number_' + i_num2 + '\" value=' + s_Value[1] + '>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:50px;" Name=\"BNumber_' + i_num2 + '\" value=' + s_Value[2] + '>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\"  class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'"detailedViewTextBox\'\" style="width:50px;"  Name=\"Price_' + i_num2 + '\" value=' + s_Value[3] + '>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;" readonly  Name=\"Money_' + i_num2 + '\" value=' + s_Value[4] + ' >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;"   Name=\"PlanNumber_' + i_num2 + '\" value=' + s_Value[5] + ' >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;"   Name=\"OrderNumber_' + i_num2 + '\" value=' + s_Value[6] + ' >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;"   Name=\"MaterNumber_' + i_num2 + '\" value=' + s_Value[7] + ' >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;"   Name=\"MaterPattern_' + i_num2 + '\" value=' + s_Value[8] + ' >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\"  OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:50px;"   Name=\"IsFollow_' + i_num2 + '\" value=' + s_Value[9] + ' >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;"  Name=\"Remarks_' + i_num2 + '\" value=' + s_Value[10] + ' >';
                    objCel.className = "ListHeadDetails";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[i] + ",";

                }
                document.all('i_Num').value = parseInt(document.all('i_Num').value) + ss.length - 1;
                document.all("Xs_ProductsCode").value = s_ID;
                document.all("Lbl_ContractDetails1").value = document.all("Lbl_ContractDetails").innerHTML;

            }
            else {
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
        function Detelte() {
            document.all("Lbl_Details").innerHTML = "";
        }
        function ChangPrice() {
            var num = document.all('i_Num').value;
            for (var i = 0; i < num; i++) {
                if (document.all("Money_" + i) != null)
                {
                    document.all("Money_" + i).value = document.all("Price_" + i).value * document.all("Number_" + i).value
                }
            }
            ChangeNumber();
        }

        function ChangeNumber() {
            var num = document.all('i_Num').value;
            for (var i = 0; i < num; i++) {
                
                if (document.all("HxState_" + i) != null) {
                    var v_HxState = document.all("HxState_" + i).value;
                    if (v_HxState == "1") {

                        var v_LeftTotalBhNumber = document.all("LeftTotalBhNumber_" + i).value == "" ? "0" : document.all("LeftTotalBhNumber_" + i).value;
                        var v_number = document.all("Number_" + i).value == "" ? "0" : document.all("Number_" + i).value;
                        var v_Bnumber = document.all("BNumber_" + i).value == "" ? "0" : document.all("BNumber_" + i).value;
                        var v_Hxnumber = parseInt(v_number) + parseInt(v_Bnumber);
                        if (parseInt(v_Hxnumber) > parseInt(v_LeftTotalBhNumber)) {

                            document.all("HxNumber_" + i).value = v_LeftTotalBhNumber;
                        }
                        else {
                            document.all("HxNumber_" + i).value = v_Hxnumber;
                        }
                    }
                }
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"
        defer="defer"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="detail_info_click('Details1');">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>订单评审 > <a class="hdrLink" href="KNet_Sales_ContractList_List.aspx">订单评审</a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                    </div>

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label>
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
                                                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                                                    <asp:TextBox ID="Tbx_Hx" runat="server" Style="display: none"></asp:TextBox>
                                                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                                                    <asp:TextBox ID="Tbx_ContractState" runat="server" Style="display: none"></asp:TextBox>
                                                    <asp:TextBox ID="Tbx_ContractCheckYN" runat="server" Style="display: none"></asp:TextBox>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">&nbsp; 编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="ContractNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="合同编号不能为空"
                                                            ControlToValidate="ContractNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">签订日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="ContractDateTime" runat="server" MaxLength="20" CssClass="Wdate"
                                                            onClick="WdatePicker()"></asp:TextBox>(<font color="red"><span style="color: #ff0066">*</span></font>)<br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="签订日期非空"
                                                            ControlToValidate="ContractDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">客户:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="CustomerValue" id="CustomerValue" runat="server" style="width: 150px" />
                                                        <asp:TextBox ID="CustomerValueName" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="350px"></asp:TextBox>(<font color="red">*</font>)
                                                    <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择客户" title="选择客户"
                                                        onclick="return btnGetReturnValue_onclick()" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户"
                                                            ControlToValidate="CustomerValueName" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">责任人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList runat="Server" ID="Ddl_DutyPerson">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Ddl_DutyPerson"
                                                            Display="Dynamic" ErrorMessage="责任人非空"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">地址:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="ContractToAddress" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300"></asp:TextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">交货方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="ContractDeliveMethods" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">联系人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_ContentPerson" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="350px"></asp:TextBox>&nbsp;
                                                    <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择联系人" title="选择联系人"
                                                        onclick="return btnGetContentPerson_onclick()" />
                                                    </td>
                                                    <td class="dvtCellLabel">电话:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_Telephone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="130px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">开始日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="ContractStarDateTime" runat="server" MaxLength="20" CssClass="Wdate"
                                                            onFocus="var ContractEndtDateTime=$dp.$('ContractEndtDateTime');WdatePicker({onpicked:function(){ContractEndtDateTime.focus();},maxDate:'#F{$dp.$D(\'ContractEndtDateTime\')}'})"></asp:TextBox>(<font
                                                                color="red">*</font>)<br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="开始日期非空"
                                                            ControlToValidate="ContractStarDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">交货日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="ContractToDeliDate" runat="server" MaxLength="20" CssClass="Wdate"
                                                            onClick="WdatePicker()"></asp:TextBox>(<font
                                                                color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="交货日期非空"
                                                        ControlToValidate="ContractToDeliDate" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <asp:TextBox ID="ContractEndtDateTime" runat="server" MaxLength="20" Visible="false"
                                                        CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'ContractStarDateTime\')}'})"></asp:TextBox>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">合同分类:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="ContractClass" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="合同分类非空"
                                                        ControlToValidate="ContractClass" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">付款方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Drop_Payment" runat="server" Width="300px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="付款方式非空"
                                                        ControlToValidate="Drop_Payment" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="AddPic" runat="server" visible="false">
                                                    <td class="dvtCellLabel">请选择图片:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">

                                                        <asp:TextBox runat="server" ID="Tbx_ContractShip" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px"></asp:TextBox>
                                                        <asp:CheckBox ID="ProductsPic" runat="server" OnCheckedChanged="ProductsPic_CheckedChanged"
                                                            AutoPostBack="true" /><font color="gray">（上传图片的请打勾）</font>
                                                        <asp:TextBox ID="Tbx_DeliveryRequire" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px"></asp:TextBox>

                                                        <asp:TextBox ID="Tbx_WarrantyPeriod" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px" Text="12个月"></asp:TextBox>

                                                        <asp:TextBox ID="Tbx_QualityRequire" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px" Text="1.根据客户要求制作;2.开箱率不合格率不高于0.1%"></asp:TextBox>

                                                        <asp:TextBox ID="Tbx_ProductPackaging" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px"></asp:TextBox>
                                                        <asp:TextBox ID="Tbx_Technicalne" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="300px" Text="根据客户要求制作"></asp:TextBox>
                                                        <asp:Label ID="Image1Big" runat="server" Text="" Visible="false"></asp:Label>
                                                        <asp:Image ID="Image1" runat="server" Width="95px" Height="75px" />&nbsp;<input id="uploadFile"
                                                            type="file" runat="server" class="Boxx" size="30" />&nbsp;<input id="button" type="button"
                                                                value="上传图片" runat="server" class="Btt" onserverclick="button_ServerClick" causesvalidation="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">结算方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="ContractToPayment" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="dvtCellLabel">开票方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_KpType" runat="server">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                            ErrorMessage="开票方式非空" ControlToValidate="Ddl_KpType" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr style="height: 28px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Details1');">
                                                    <!-- windLayerHeadingTr -->
                                                    <td colspan="4" class="" valign="middle">&nbsp;&nbsp;描述信息&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 30px; width: 30px;" onclick="detail_info_click('Details1');">
                                                        <img align="absmiddle" id="Details1_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                                    </span>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td colspan="4">
                                                        <div id="Details1">
                                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                                <tr>

                                                                    <td class="dvtCellLabel">关联报价:
                                                                    </td>
                                                                    <td class="dvtCellInfo">
                                                                        <input type="hidden" name="BaoPriceNo" id="BaoPriceNo" runat="server" />
                                                                        <asp:TextBox ID="BaoPriceNoName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px" ReadOnly="true"></asp:TextBox>&nbsp;<%--(<font color="red">*</font>)--%>
                                                                        <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择报价单" title="选择报价单"
                                                                            onclick="return btnGetBaoPriceValue_onclick()" />
                                                                        <%--(<font color="gray">如没关联报价，明细从仓库选择,有关联报价，明细调用报价明细记录</font>)--%>
                                                                        <%--   <asp:RequiredFieldValidator  ID="RequiredFieldValidator14" runat="server" ErrorMessage="选择关联报价单" ControlToValidate="BaoPriceNoName" Display="Dynamic"></asp:RequiredFieldValidator> --%>
                                                                    </td>

                                                                    <td class="dvtCellLabel">是否邮件提醒责任人:
                                                                    </td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:CheckBox ID="Is_Mail" runat="server" Checked="true" Text="是" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">运输方式:
                                                                    </td>
                                                                    <td class="dvtCellInfo">常规：<asp:DropDownList ID="Drop_RoutineTransport" runat="server" Width="150px">
                                                                    </asp:DropDownList>
                                                                        应急：<asp:DropDownList ID="Drop_WorryTransport" runat="server" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="dvtCellLabel">备注说明:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="ContractRemarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="700px" Height="30px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>订单档案</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">档案编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_OrderNo" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="150px" Text=""></asp:TextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">订单原件:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label><input id="uploadFile1"
                                                            type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button1" type="button"
                                                                value="上传" runat="server" class="crmbutton small save" onserverclick="button_ServerClick1" causesvalidation="false" />
                                                        <input id="button2" type="button"
                                                            value="删除" class="crmbutton small save" onclick="Detelte()" causesvalidation="false" />
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">合同编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="Tbx_FaterID" id="Tbx_FaterID" runat="server" style="width: 150px" />
                                                        <asp:TextBox ID="Tbx_FaterCode" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="150px" Text=""></asp:TextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">合同类型:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="DDl_Type" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>生产要求</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="dvtCellInfo">
                                                            <asp:TextBox ID="FhNum" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                            
                                                        <asp:Label runat="server" ID="Lbl_FhDetails" Name="Lbl_FhDetails"></asp:Label>
                                                        <asp:TextBox runat="server" ID="Lbl_FhDetails1" CssClass="Custom_Hidden"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>产品明细</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label runat="server" ID="Lbl_ContractDetails" Name="Lbl_ContractDetails"></asp:Label>
                                                        <asp:TextBox runat="server" ID="Lbl_ContractDetails1" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                                            <tr>
                                                                <td colspan="3">①选择产品:
                                                                <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:TextBox ID="i_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">&nbsp;
                                        <br />
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Button3_Click" Style="width: 55px; height: 33px;" />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="80px"><div class="height:80px">&nbsp;</div></td>
                                    </tr>
                                </table>
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
