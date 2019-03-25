<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Accounting_Init_Add.aspx.cs"
    Inherits="Cw_Accounting_Init_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title></title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
</head>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
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

    function btnGetSuppValue_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

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
    function btnGetMoney_onclick() {
        var today = new Date();
            var s_Value, s_ProductsInfo, i_row, s_ID, i_num2;
            var Money = document.all("Tbx_Money").value;

            var num = document.all('i_Num').value;
            var Number = 0
            for (var i = 0; i < num; i++) {
                if (document.all("Number_" + i) != null) {
                    Number += parseFloat(document.all("Number_" + i).value);
                }
            }
            if(Number!=0)
            {
                Money = parseFloat(Money) - (Number);
            }
            i_row = myTable.rows.length;
                var objRow = myTable.insertRow(i_row);
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:150px;" Name=\"Number_' + num + '\" value=' + Money + '>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"Wdate\" OnFocus=\"WdatePicker()\" style="width:200px;" Name=\"OutTime_' + num + '\" value="2015-5-31">';
                objCel.className = "dvtCellInfo";


                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:300px;"  Name=\"Remarks_' + num + '\" >';
                objCel.className = "dvtCellInfo";
                document.all('i_Num').value = parseInt(num)+ 1
    }

    function deleteRow(obj) {
        var num = document.all('i_Num').value;
        myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                期初余额 > <a class="hdrLink" href="Cw_Accounting_Init_List.aspx">期初余额</a>
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
                                    <td class="dvtTabCache" style="width: 10px" nowrap>
                                        &nbsp;
                                    </td>
                                    <td class="dvtSelectedCell" align="center" nowrap>
                                        期初余额信息
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
                                                <td class="dvtCellLabel">
                                                    编号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编号不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    摘要:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Title" Text='期初余额' CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="17%" class="dvtCellLabel">
                                        客户:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                            style="width: 150px" />
                                        <pc:PTextBox ID="Tbx_CustomerName" runat="server" 
                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                        <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                    </td>
                                    <td width="17%" height="25" align="right" class="dvtCellLabel">
                                        供应商:
                                    </td>
                                    <td align="left" class="dvtCellInfo">
                                        <input type="hidden" name="SuppNoSelectValue" id="SuppNoSelectValue" runat="server" />
                                        <asp:TextBox ID="SuppNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="48"></asp:TextBox>
                                        <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetSuppValue_onclick()" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        类型:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <asp:DropDownList ID="Ddl_Type" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="dvtCellLabel">
                                        日期:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        责任人:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <asp:DropDownList runat="server" ID="Ddl_DutyPerson">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人"
                                            ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="dvtCellLabel">
                                        期初金额:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <pc:PTextBox runat="server" ID="Tbx_Money" AllowEmpty="false" ValidError="期初金额不能为空"
                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox';btnGetMoney_onclick();" Width="150px"></pc:PTextBox>
                                        (<font color="red">*</font>)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="i_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                        <asp:TextBox runat="server" ID="Lbl_Details1" CssClass="Custom_Hidden"></asp:TextBox>
                                        <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                            <tr>
                                                <td colspan="3">
                                                    <input type="button" name="Button" class="crmbutton small create" value="添加" onclick="btnGetMoney_onclick();" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="detailedViewHeader">
                                        <b>描述信息</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        备注:
                                    </td>
                                    <td class="dvtCellInfo" colspan="4">
                                        <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="300px" Height="40px"></asp:TextBox>
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
                        class="crmbutton small save" OnClick="Btn_SaveOnClick" />
                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                        type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                </td>
            </tr>
            </table> </td>
        </tr>
    </table>
    </td>
    <td valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif">
    </td>
    </tr> </table>
    </form>
</body>
</html>
