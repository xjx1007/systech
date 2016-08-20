<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Contract_Manage_Add.aspx.cs"
    Inherits="Xs_Contract_Manage_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>合同评审</title>
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss, fh;
                ss = tempd.split("#");
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];

                var i_row = myFhTable.rows.length;
                var response = Xs_Contract_Manage_Add.GetFhDetails(ss[0]);
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

        function btnGetProducts_onclick() {
            var today = new Date();
            var s_Customer = "";
            s_Customer = document.all('Tbx_CustomerValue').value;
            if (s_Customer == "") {
                alert("请选择客户！")
                return;
            }
            var temp = window.showModalDialog("SelectProducts_Sales.aspx?CustomerValue=" + s_Customer + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no;dialogwidth=1000px;dialogHeight=600px");
            if (temp != undefined) {
                document.all("Xs_ProductsCode").value = "";
                var ss;
                ss = temp.split("|");
                var s_Value, s_ProductsInfo, i_row, s_ID, i_num2;
                s_ID = document.all("Xs_ProductsCode").value;
                i_row = myTable.rows.length;
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split('#');
                    var response = Xs_Contract_Manage_Add.GetProductsInfo(s_Value[0])
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

        function ChangPrice() {
            var num = document.all('i_Num').value;
            for (var i = 0; i < num; i++) {
                document.all("Money_" + i).value = document.all("Price_" + i).value * document.all("Number_" + i).value
            }
        }
        function ChangeCode() {
            var response = Xs_Contract_Manage_Add.GetCode(document.all('Tbx_CustomerValue').value, document.all('DDl_Type').value);
            if (response.value != "") {
                var ss = response.value.split(",");

                document.all('Tbx_Code').value = ss[0];
                document.all('Tbx_OrderNo').value = ss[1];
            }
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="detail_info_click('Details1');">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>合同档案 > <a class="hdrLink" href="Xs_Contract_Manage_List.aspx">合同档案</a>
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
                                        <td class="dvtSelectedCell" align="center" nowrap>合同档案信息
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
                                                    <asp:TextBox ID="Tbx_OrderNo" runat="server" Style="display: none"></asp:TextBox>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编号不能为空" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="200px"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td class="dvtCellLabel">标题:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Title" AllowEmpty="false" ValidError="标题不能为空" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="150px"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">签订日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                        (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="签订日期不能为空"
                                                        ControlToValidate="Tbx_STime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">类型:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="DDl_Type" runat="server" onChange="ChangeCode();">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择类型"
                                                            ControlToValidate="DDl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" class="dvtCellLabel">客户:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                            style="width: 150px" />
                                                        <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="178px" ReadOnly="true"></asp:TextBox>
                                                        <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户"
                                                            ControlToValidate="Tbx_CustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">负责人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_DutyPerson" runat="server" Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="dvtCellLabel">付款方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Drop_Payment" runat="server" Width="300px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="dvtCellLabel">结算方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="ContractToPayment" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td class="dvtCellLabel">发货要求:
                                                    </td>
                                                    <td class="dvtCellInfo">

                                                        <asp:TextBox runat="server" ID="Tbx_FhDetails" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">审批流程:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_Flow" runat="server">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td class="dvtCellLabel">开票方式:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_KpType" runat="server">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                            ErrorMessage="开票方式非空" ControlToValidate="Ddl_KpType" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <asp:TextBox ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <tr>
                                                    <td height="25" align="right" class="dvtCellLabel">附件资料:</td>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="2">
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr id="tr5">

                                                                <td align="center" class="dvtCellLabel">工具</td>
                                                                <td align="center" class="dvtCellLabel">名称</td>
                                                                <td align="center" class="dvtCellLabel" colspan="2">资料</td>
                                                            </tr>
                                                            <tr id="tr4">
                                                                <td colspan="4">
                                                                    <asp:Label runat="server" ID="Lbl_Details"></asp:Label></td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">名称:</td>
                                                    <td class="dvtCellInfo" align="left">
                                                        <asp:TextBox ID="Tbx_Name" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="178px"></asp:TextBox>(<font color="red">*</font>)
                                                    </td>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">附件:</td>
                                                    <td class="dvtCellInfo" align="left">
                                                        <input id="uploadFile" type="file" runat="server" class="detailedViewTextBox"
                                                            onfocus="this.className='detailedViewTextBoxOn'" onblur="this.className='detailedViewTextBox'" style="width: 300px;" />&nbsp;
                                                        <input id="button_Server" type="button" value="上传" runat="server" class="crmbutton small save" onserverclick="button_ServerClick"
                                                            causesvalidation="false" />
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
                                                                    <td class="dvtCellLabel">备货要求:
                                                                    </td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:TextBox runat="server" ID="Tbx_ContractShip" CssClass="detailedViewTextBox"
                                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                            Width="300px"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                        <td class="dvtCellLabel">质量要求:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:TextBox ID="Tbx_QualityRequire" runat="server" CssClass="detailedViewTextBox"
                                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                                Width="300px" Text="1.根据客户要求制作;2.开箱率不合格率不高于0.1%"></asp:TextBox>
                                                                        </td>
                                                                        <td class="dvtCellLabel">质保期:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:TextBox ID="Tbx_WarrantyPeriod" runat="server" CssClass="detailedViewTextBox"
                                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                                Width="300px" Text="12个月"></asp:TextBox>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td class="dvtCellLabel">技术要求:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:TextBox ID="Tbx_Technicalne" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="300px" Text="根据客户要求制作"></asp:TextBox>
                                                                        </td>
                                                                        <td class="dvtCellLabel">产品包装:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:TextBox ID="Tbx_ProductPackaging" runat="server" CssClass="detailedViewTextBox"
                                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                                Width="300px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="25" align="right" class="dvtCellLabel">合同简介:</td>
                                                                        <td colspan="3" align="left" class="dvtCellInfo">
                                                                            <asp:TextBox ID="tbx_Remarks" runat="server" Style="display: none;"></asp:TextBox>
                                                                            <iframe src='/Web/eWebEditor/ewebeditor.htm?id=tbx_Remarks&style=gray'
                                                                                frameborder='0' scrolling='no' width='620' height='350'></iframe>
                                                                        </td>
                                                                    </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>生产要求</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="dvtCellInfo">
                                                        <table id="myFhTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="ListDetails">
                                                            <tr>
                                                                <td class="ListHead" nowrap><b>选择</b></td>
                                                                <td class="ListHead" nowrap><b>名称</b></td>
                                                                <td class="ListHead" nowrap><b>详细</b></td>
                                                            </tr>
                                                            <asp:TextBox ID="FhNum" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <asp:Label runat="server" ID="Lbl_FhDetails"></asp:Label>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="height: 28px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Details1');">
                                                    <!-- windLayerHeadingTr -->
                                                    <td colspan="4" class="" valign="middle">&nbsp;&nbsp;产品信息&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 30px; width: 30px;" onclick="detail_info_click('Details1');">
                                                        <img align="absmiddle" id="Img1" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                                    </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div id="Div1">
                                                            <table width="100%" cellspacing="0" cellpadding="0">
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
                                                        </div>
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
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                        </td>
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
