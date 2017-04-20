<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Xs_Sales_Freight_Add.aspx.cs"
    Inherits="Xs_Sales_Freight_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <title>运费承担添加</title>
    <script type="text/javascript">
        function GetMoney() {
            var v_TotalMoney = document.all('Tbx_TotalMoney').value == "" ? "0" : document.all('Tbx_TotalMoney').value;
            var v_TotalNumber = document.all('Tbx_TotalNumber').value == "" ? "0" : document.all('Tbx_TotalNumber').value;
            var v_FMoney = document.all('Tbx_FMoney').value == "" ? "0" : document.all('Tbx_FMoney').value;
            var v_Money = document.all('Tbx_Money').value == "" ? "0" : document.all('Tbx_Money').value;
            if (v_FMoney != "0") {
                var v_Money = parseFloat(v_TotalMoney) - parseFloat(v_FMoney)
                document.all('Tbx_Money').value = v_Money;
                var v_FPercent = parseFloat(v_FMoney) / parseFloat(v_TotalMoney);
                var v_Percent = parseFloat(v_Money) / parseFloat(v_TotalMoney);
                document.all('Tbx_FPercent').value = v_FPercent.toFixed(2);
                document.all('Tbx_Percent').value = v_Percent.toFixed(2);
            }
            if (v_TotalNumber != "0") {
                var v_Price = parseFloat(v_TotalMoney) / parseFloat(v_TotalNumber);
                document.all('Tbx_Price').value = v_Percent.toFixed(2);
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

        function Change() {
            var FSupp = document.all('Ddl_FSupp').value;
            var response = Xs_Sales_Freight_Add.GetKDCode(FSupp);
            document.all('Drop_KD').value = response.value;
        }
        //function btnGetWuliuSupp_onclick() {
        //    var today, seconds;
        //    today = new Date();
        //    intSeconds = today.getSeconds();
        //    //var temp = window.showModalDialog("/Web/Common/SelectSuppliers.aspx?Type=128860697896406251", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
        //    var temp = window.open("/Web/Common/SelectSuppliers.aspx?Type=128860697896406251&callback=SetReturnValueInOpenner_Suppliers1", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        //}
        //function SetReturnValueInOpenner_Suppliers1(temp) {
        //    if (temp != undefined) {
        //        var ss;
        //        ss = temp.split("|");
        //        document.all('Tbx_WuliuSuppNo').value = ss[0];
        //        document.all('Tbx_WuliuSuppName').value = ss[1];
        //    }
        //    else {
        //        document.all('Tbx_WuliuSuppNo').value = "";
        //        document.all('Tbx_WuliuSuppName').value = "";
        //    }
        //}

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
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
            }
            else {
                document.all('Tbx_CustomerValue').value = "";
                document.all('Tbx_CustomerName').value = "";
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售管理 > <a class="hdrLink" href="PB_Basic_Express_List.aspx">运费承担添加</a>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>添加
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
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">编号：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Code" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">日期：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Stime" runat="server"
                                                    CssClass="Wdate" onClick="WdatePicker()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">类型：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <asp:DropDownList ID="Ddl_Type" runat="server" CssClass="detailedViewTextBox" Width="200px">
                                                </asp:DropDownList>
                                                (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="类型不能为空"
                                                            ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">来源：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_FID" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">供应商名称：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_CustomerName" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                                <pc:PTextBox ID="Tbx_CustomerValue" runat="server"
                                                    CssClass="Custom_Hidden" Width="200px">
                                                </pc:PTextBox>
                                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">审批流程：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <asp:DropDownList ID="Ddl_Flow" runat="server" CssClass="detailedViewTextBox" Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">数量：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_TotalNumber" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">单价：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Price" runat="server" ReadOnly="true"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">金额：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_TotalMoney" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">原因：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Description" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">供应商承担：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_FPercent" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';" ReadOnly="true" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">承担金额：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_FMoney" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">士腾承担：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Percent" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">承担金额：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Money" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>物流信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">物流公司:</td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList runat="server" ID="Ddl_FSupp" CssClass="detailedViewTextBox" Width="150px" OnChange="Change()"></asp:DropDownList>
                                                (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="物流公司不能为空"
                                                            ControlToValidate="Ddl_FSupp" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">发货地点:</td>
                                            <td class="dvtCellInfo">
                                                <pc:PTextBox runat="server" ID="Tbx_Address" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="400px"></pc:PTextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">快递:</td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Drop_KD" runat="server" CssClass="detailedViewTextBox" Width="150px"></asp:DropDownList>
                                                <input type="text" id="span" onkeyup='searchFromSelect(this.value)'
                                                    onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}' class="detailedViewTextBox"
                                                    style="width: 103px; height: 20; border: 1 solid #0000FF; overflow-y: auto"></input>
                                            </td>
                                            <td class="dvtCellLabel">单号:</td>
                                            <td class="dvtCellInfo">
                                                <pc:PTextBox runat="server" ID="Tbx_KDCode" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>其他信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">备注：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                <pc:PTextBox ID="Tbx_Remarks" runat="server"
                                                    TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="600px" Height="50px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Save_Click" Style="height: 30px; width: 70px" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px; height: 33px;" style="height: 30px; width: 70px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>


    </form>
</body>
</html>
