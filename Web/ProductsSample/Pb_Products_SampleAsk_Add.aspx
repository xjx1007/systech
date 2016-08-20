<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pb_Products_SampleAsk_Add.aspx.cs"
    Inherits="Web_Sales_Pb_Products_Sample_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
</head>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=yes;scrollbars=yes; resizable=no; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        if (tempd == undefined) {
            tempd = window.returnValue;
        }
        var sel = document.getElementById("Ddl_LinkMan");
        var length = sel.length;
        for (var i = length - 1; i >= 0; i--) {
            sel.remove(i);
        }
        var opt = new Option("", "");
        sel.options.add(opt);
        if (tempd != undefined) {
            var ss;
            ss = tempd.split("#");
            document.all('Tbx_CustomerValue').value = ss[0];
            document.all('Tbx_CustomerName').value = ss[1];
            var st, sw;
            st = ss[3].split("|");
            if (st.length > 0) {
                for (var i = 0; i < st.length - 1; i++) {
                    sw = st[i].split(",");
                    var opt = new Option(sw[1], sw[0]);
                    sel.options.add(opt);
                }

            }

        }
        else {
            document.all('Tbx_CustomerValue').value = "";
            document.all('Tbx_CustomerName').value = "";
            var length = sel.length;
            for (var i = length - 1; i >= 0; i--) {
                sel.remove(i);
            }
        }
    }


    function btnGetProducts_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();

        var tempd = window.showModalDialog("SelectProducts.aspx?CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        if (tempd != undefined) {

            var ss, s_Value, i_row;

            ss = tempd.split("|");
            i_row = myTable.rows.length;

            for (var i = 0; i < ss.length - 1; i++) {
                s_Value = ss[i].split(",");

                var objRow = myTable.insertRow(i_row);

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                objCel.className = "dvtCellInfo";

                i_row = i_row + 1;
                s_ID = s_ID + s_Value[1] + ",";
            }

            document.all("Xs_ProductsCode").value = s_ID;
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
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                样品领用申请单 > <a class="hdrLink" href="Pb_Products_Sample_List.aspx">样品领用申请单</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" Style="display: none"></asp:TextBox>
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
                                        样品领用申请单信息
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
                                                    申请单号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="申请单号不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    领用日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    产品名称:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_ProductsName" AllowEmpty="false" ValidError="申请主题不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    产品型号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_ProductsEdition" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    数量:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Number" AllowEmpty="false" ValidError="申请主题不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    产品用途:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_Use" runat="server"  CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    申请人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server"
                                                        Width="100px">
                                                    </asp:DropDownList>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人"
                                                        ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    是否返回:
                                                </td>
                                                <td class="dvtCellInfo">
                                                <asp:CheckBox runat="server" ID="Chk_IsBack" Text="是" />
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    申请状态:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                    <asp:DropDownList ID="Ddl_Dept" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                                    </asp:DropDownList>
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
                </table>
            </td>
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
