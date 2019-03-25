<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Transfer_Cheque_Add.aspx.cs" Inherits="Web_Sales_Xs_Transfer_Cheque_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title></title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
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
        var tempd = window.showModalDialog("SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        if (tempd != undefined) {
            var ss;
            ss = tempd.split("#");
            document.all('Tbx_PayeeValue').value = ss[0];
            document.all('Tbx_PayeeName').value = ss[1];
            document.all('Tbx_BankAccount').value = ss[3];
            document.all('Tbx_BankName').value = ss[4];
            document.all('Tbx_Shen').value = ss[5];
            document.all('Tbx_Shi').value = ss[6];
        }
        else {
            document.all('Tbx_PayeeValue').value = "";
            document.all('Tbx_PayeeName').value = "";
            document.all('Tbx_BankAccount').value = "";
            document.all('Tbx_BankName').value = "";
            document.all('Tbx_Shen').value = "";
            document.all('Tbx_Shi').value = "";
        }
    }
    function btnGetReturnValue_onclick1() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("SelectSuppliers.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        if (tempd != undefined) {
            var ss;
            ss = tempd.split("|");
            document.all('Tbx_PayeeValue').value = ss[0];
            document.all('Tbx_PayeeName').value = ss[1];
            document.all('Tbx_BankAccount').value = ss[6];
            document.all('Tbx_BankName').value = ss[7];
            document.all('Tbx_Shen').value = ss[4];
            document.all('Tbx_Shi').value = ss[5];
            
        }
        else {
            document.all('Tbx_PayeeValue').value = "";
            document.all('Tbx_PayeeName').value = "";
            document.all('Tbx_BankAccount').value = "";
            document.all('Tbx_BankName').value = "";
            document.all('Tbx_Shen').value = "";
            document.all('Tbx_Shi').value = "";
        }
    }
    function Chang() {
        var v_Money, v_chineseNumber;
        v_Money = document.all('Tbx_Money').value;
        v_chineseNumber = nst(v_Money);
        document.all('Tbx_ChineseMoney').value = v_chineseNumber;
    }

    var stmp = "";
    function nst(t) {
        if (t == stmp) return;
        var ms = t.replace(/[^\d\.]/g, "").replace(/(\.\d{2}).+$/, "$1").replace(/^0+([1-9])/, "$1").replace(/^0+$/, "0");

        var txt = ms.split(".");
        while (/\d{4}(,|$)/.test(txt[0]))
            txt[0] = txt[0].replace(/(\d)(\d{3}(,|$))/, "$1,$2");
        t = stmp = txt[0] + (txt.length > 1 ? "." + txt[1] : "");
        return number2num1(ms - 0);

    }
    function number2num1(strg) {
        var number = Math.round(strg * 100) / 100;
        number = number.toString(10).split('.');
        var a = number[0];
        if (a.length > 12)
            return "数值超出范围！支持的最大数值为 999999999999.99";
        var e = "零壹贰叁肆伍陆柒捌玖";
        var num1 = "";
        var len = a.length - 1;
        for (var i = 0 ; i <= len; i++)
            num1 += e.charAt(parseInt(a.charAt(i))) + [["元", "万", "亿"][Math.floor((len - i) / 4)], "拾", "佰", "仟"][(len - i) % 4];

        if (number.length == 2 && number[1] != "") {
            var a = number[1];
            for (var i = 0 ; i < a.length; i++)
                num1 += e.charAt(parseInt(a.charAt(i))) + ["角", "分"][i];
        }
        num1 = num1.replace(/零佰|零拾|零仟|零角/g, "零");

        num1 = num1.replace(/零{2,}/g, "零");
        num1 = num1.replace(/零(?=元|万|亿)/g, "");
        num1 = num1.replace(/亿万/, "亿");
        num1 = num1.replace(/^元零?/, "");
        if (num1 != "" && !/分$/.test(num1))
            num1 += "整";
        return num1;
    }
</script>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>账号支出 > 
	<a class="hdrLink" href="Xs_Transfer_Cheque_List.aspx">账号支出</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopLeft.gif"></td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px"></div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;</td>
                                        <td class="dvtSelectedCell" align="center" nowrap>账号支出信息</td>
                                        <td class="dvtTabCache" style="width: 10px">&nbsp;</td>
                                        <td class="dvtTabCache" style="width: 100%">&nbsp;</td>
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
                                                    <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">支出用途:</td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_UseName" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td class="dvtCellLabel">支出日期:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>

                                                    </td>
                                                    <tr>
                                                        <td class="dvtCellLabel">支票类型:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_Type" CssClass="detailedViewTextBox" runat="server" Width="200px"></asp:DropDownList>
                                                        </td>
                                                        <td class="dvtCellLabel">账户:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_Account" CssClass="detailedViewTextBox" runat="server" Width="200px"></asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="dvtCellLabel">金额:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="Tbx_Money" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';Chang();" Width="150px"></pc:PTextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">大写:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="Tbx_ChineseMoney" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>

                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td width="17%" class="dvtCellLabel">收款人:</td>
                                                        <td class="dvtCellInfo">
                                                            <input type="hidden" name="Tbx_PayeeValue" id="Tbx_PayeeValue" runat="server" style="width: 150px" />
                                                            <pc:PTextBox ID="Tbx_PayeeName" runat="server" AllowEmpty="false" ValidError="收款人不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                            <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                            <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick1()" />
                                                            (<font color="red">*</font>)

                                                        </td>
                                                        <td class="dvtCellLabel">出票人:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px"></asp:DropDownList>(<font color="red">*</font>)
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>



                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">省:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_Shen" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">市:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_Shi" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">开户行:</td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_BankName" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';" Width="150px"></pc:PTextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">账号:</td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_BankAccount" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="dvtCellLabel">票据种类:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList runat="server" ID="Ddl_BillType" CssClass="detailedViewTextBox" Width="150px"></asp:DropDownList>
                                                    </td>
                                                    <td class="dvtCellLabel">票据张数:</td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_BillNumber" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader"><b>附加信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">附加信息:</td>
                                                    <td class="dvtCellInfo" colspan="4">
                                                        <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="600px" Height="40px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">&nbsp;
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick" />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top"><img src="../../themes/softed/images/showPanelTopRight.gif" /></td>
            </tr>
        </table>

    </form>
</body>
</html>
