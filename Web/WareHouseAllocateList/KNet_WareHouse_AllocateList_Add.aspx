<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KNet_WareHouse_AllocateList_Add.aspx.cs" Inherits="Knet_Web_WareHouse_KNet_WareHouse_AllocateList_Add" %>
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
    <title>销售调拨添加</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Common/SelectSalesShipList.aspx?ID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
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
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&HouseNo=" + document.all("HouseNo_out").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
            if (tempd != undefined) {
                var i_num1 = parseInt(document.all('Tbx_Num').value);
                document.all('Tbx_Num').value = i_num1;
                var ss, ss1, s_Value, i_row;
                ss1 = tempd.split("|");
                s_ID = document.all("Xs_ProductsCode").value;
                for (var i = 0; i < ss1.length-1; i++) {
                    var ss = ss1[i].split(",");
                    i_row = myTable.rows.length;
                    i_num1 = parseInt(i_num1) + i;
                    var objRow = myTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsName_' + i_num1 + '\" value=' + ss[0] + '>' + ss[0];
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode_' + i_num1 + '\" value=' + ss[1] + '>' + ss[1];
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern_' + i_num1 + '\" value=' + ss[2] + '>' + ss[2];
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Number_' + i_num1 + '\" value=' + ss[3] + ' >';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Price_' + i_num1 + '\"  value=' + ss[4] + ' >';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;" Name=\"Money_' + i_num1 + '\"  >';
                    objCel.className = "dvtCellInfo";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:100px;"  Name=\"Remarks_' + i_num1 + '\"  >';
                    objCel.className = "dvtCellInfo";
                    i_row = i_row + 1;

                    document.all('Tbx_Num').value = parseInt(document.all('Tbx_Num').value) + 1;
                    s_ID = s_ID + ss[0] + ",";
                }
                
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
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                调拨单管理 > <a class="hdrLink" href="KNet_WareHouse_AllocateList_Manage.aspx">调拨单添加</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
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
                                        <td class="dvtTabCache" style="width: 10px" nowrap>
                                            &nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            调拨单信息
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
                                            &nbsp;调拨单号:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="AllocateNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="调拨单号不能为空"
                                                ControlToValidate="AllocateNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            调拨日期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="AllocateDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="调拨日期非空"
                                                ControlToValidate="AllocateDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            &nbsp;调出仓库:
                                        </td>
                                        <td class="dvtCellInfo"><asp:DropDownList ID="HouseNo_out" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="调出仓库不能为空" ControlToValidate="HouseNo_out" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="dvtCellLabel">
                                            调入仓库:
                                        </td>
                                        <td class="dvtCellInfo"><asp:DropDownList ID="HouseNo_int" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="调入仓库不能为空" ControlToValidate="HouseNo_int" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="dvtCellLabel">
                                            调拨原因:
                                        </td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:TextBox ID="AllocateCause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                    runat="server" ControlToValidate="AllocateCause" ValidationExpression="^(\s|\S){0,500}$"
                                                    ErrorMessage="调拨原因太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="dvtCellLabel">
                                            备注说明:
                                        </td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:TextBox ID="AllocateRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                    runat="server" ControlToValidate="AllocateCause" ValidationExpression="^(\s|\S){0,500}$"
                                                    ErrorMessage="调拨原因太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                        </td>
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
                                    class="crmbutton small save" OnClick="Btn_SaveOnClick"  style="width: 55px;height: 33px;"  />
                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
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