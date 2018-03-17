<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_WareHouse_DirectInto_Add.aspx.cs" Inherits="Knet_Web_WareHouse_KNet_WareHouse_DirectInto_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <title></title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("/Web/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("/Web/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Suppliers(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('SuppNoSelectValue').value = ss[0];
                document.all('SuppNo').value = ss[1];
            }
            else {
                document.all('SuppNoSelectValue').value = "";
                document.all('SuppNo').value = "";
            }
        }
        function btnGetProducts_onclick() {
            var today, seconds, tempd;
            today = new Date();
            intSeconds = today.getSeconds();
            var ReturnNo = document.all("ReturnNo").value;
            if (ReturnNo != "") {
                //tempd = window.showModalDialog("SelectReturnDetails.aspx?sID=" + document.all("Xs_ProductsCode").value + "&ReturnNo=" + document.all("ReturnNo").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
                tempd = window.open("SelectReturnDetails.aspx?sID=" + document.all("Xs_ProductsCode").value + "&ReturnNo=" + document.all("ReturnNo").value + "", "选择产品", "width=1000px, height=600,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }
            else {
                //tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&ProductsMainCategroy=129678733470295462", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
                tempd = window.open("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&ProductsMainCategroy=129678733470295462", "选择产品", "width=1000px, height=600,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }
        }
        function SetReturnValueInOpenner_Products(tempd) {
            if (tempd != undefined) {
                var i_num1 = parseInt(document.all('Tbx_Num').value);
                document.all('Tbx_Num').value = i_num1;
                var ss, s_Value, i_row;
                ss1 = tempd.split("|");
                for (var i = 0; i < parseInt(ss1.length) - 1; i++) {
                    ss = ss1[i].split(",");
                    i_row = myTable.rows.length;
                    s_ID = document.all("Xs_ProductsCode").value;
                    var objRow = myTable.insertRow(i_row);
                    i_num1 = parseInt(i_num1) + 1;
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsName_' + i_num1 + '\" value=' + ss[1] + '>' + ss[1];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode_' + i_num1 + '\" value=' + ss[0] + '>' + ss[0];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern_' + i_num1 + '\" value=' + ss[2] + '>' + ss[2];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\"  class=\"detailedViewTextBox\"  OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Number_' + i_num1 + '\" value=' + ss[3] + ' >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\"  class=\"detailedViewTextBox\"  OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Price_' + i_num1 + '\" value=0 >';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\"  class=\"detailedViewTextBox\"  OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"ChangPrice();this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Money_' + i_num1 + '\" value=0 >';
                    objCel.className = "ListHeadDetails";


                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;"  Name=\"Remarks_' + i_num1 + '\"  >';
                    objCel.className = "ListHeadDetails";
                    i_row = i_row + 1;
                    s_ID = s_ID + ss[0] + ",";
                }
                document.all('Tbx_Num').value = parseInt(document.all('Tbx_Num').value) + parseInt(ss1.length) ;
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
            s_Customer = document.all('SuppNoSelectValue').value;
            if (s_Customer == "")
            {
                alert("请选择供应商！");
                return;
            }
            //var temaap = window.showModalDialog("SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var temaap = window.open("SelectContentPerson.aspx?ID=" + s_Customer, "选择联系人", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ContentPerson(temaap) {
            if (temaap != undefined) {
                var sws;
                sws = temaap.split(",");
                document.all('Tbx_Person').value = sws[0];
                document.all('Tbx_TelPhone').value = sws[1];
                document.all('Tbx_Phone').value = sws[4];
                document.all('Tbx_Address').value = sws[3];
            }
            else {
                document.all('Tbx_Person').value = "";
                document.all('Tbx_Address').value = "";
                document.all('Tbx_TelPhone').value = "";
                document.all('Tbx_Phone').value = "";
            }
        }

        function searchFromSelect(str) {
            var o = document.getElementById("Drop_KD");
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
                    for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex) ; i++) {
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
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>入库管理 > <a class="hdrLink" href="KNet_WareHouse_DirectInto_Manage.aspx">入库添加</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>入库信息
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
                                            <td class="dvtCellLabel">&nbsp;入库单号:</td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="DirectInNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="返修入库单号不能为空" ControlToValidate="DirectInNo" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                            <td class="dvtCellLabel">&nbsp;退货单号:</td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox Enabled="false" ID="ReturnNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">入库日期:</td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="DirectInDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="入库日期非空" ControlToValidate="DirectInDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                            <td class="dvtCellLabel">物品来源:</td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="DirectInSource" runat="server" MaxLength="40" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">供应商:</td>
                                            <td class="dvtCellInfo">
                                                <input type="hidden" name="SuppNoSelectValue" id="SuppNoSelectValue" runat="server" />
                                                <asp:TextBox ID="SuppNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>&nbsp;
        <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
            onclick="return btnGetReturnValue_onclick()" /></td>
                                            <td class="dvtCellLabel">预入仓库:</td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="HouseNo" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="预入仓库不能为空" ControlToValidate="HouseNo" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">快递:</td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Drop_KD" runat="server" Width="150px"></asp:DropDownList>
                                                <input type="text" id="span" onkeyup='searchFromSelect(this.value)'
                                                    onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}' class="detailedViewTextBox"
                                                    style="width: 103px; height: 20; border: 1 solid #0000FF; overflow-y: auto"></input>
                                            </td>
                                            <td class="dvtCellLabel">单号:</td>
                                            <td class="dvtCellInfo">

                                                <pc:PTextBox runat="server" ID="Tbx_Code" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            <td class="dvtCellLabel">联系人:</td>
                                            <td class="dvtCellInfo">
                                                            <asp:TextBox runat="server" ID="Tbx_Person" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                            <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetContentPerson_onclick()" />
                                                </td>
                                            
                                            <td class="dvtCellLabel">电话:</td>
                                            <td class="dvtCellInfo">

                                                <asp:TextBox runat="server" ID="Tbx_TelPhone" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                          
                                            </td>
                                        </tr>
                                        <tr>
                                            
                                            
                                            <td class="dvtCellLabel">手机:</td>
                                            <td class="dvtCellInfo">

                                                <asp:TextBox runat="server" ID="Tbx_Phone" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                         
                                            </td>
                                            <td class="dvtCellLabel">地址:</td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox runat="server" ID="Tbx_Address" TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" Height="50px"></asp:TextBox>
                                         
                                            </td>
                                            
                                            
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">备注说明:</td>
                                            <td colspan="3" class="dvtCellInfo">
                                                <asp:TextBox ID="DirectInRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="DirectInRemarks" ValidationExpression="^(\s|\S){0,300}$" ErrorMessage="备注太多，限少于300个字." Display="dynamic"></asp:RegularExpressionValidator></td>
                                        </tr>
                                    </table>
                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                        class="crmTable" style="height: 28px">
                                        <tr>
                                            <td colspan="8" class="dvInnerHeader">
                                                <b>产品详细信息</b>
                                            </td>
                                        </tr>
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
                                                <b>版本号</b>
                                            </td>
                                            <td class="ListHead" nowrap>
                                                <b>数量</b>
                                            </td>
                                            <td class="ListHead" nowrap>
                                                <b>单价</b>
                                            </td>
                                            <td class="ListHead" nowrap>
                                                <b>金额</b>
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
                                            <td colspan="3">①选择产品:
                                            <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
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
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
