<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CW_Bank_Bill_Add.aspx.cs" Inherits="CW_Bank_Bill_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="pc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>银行转账</title>
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
</head>

<script language="JAVASCRIPT">
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
        if (v_Money != "") {
            v_chineseNumber = nst(v_Money);
            document.all('Tbx_ChineseMoney').value = v_chineseNumber;
        }
        else {
            document.all('Tbx_ChineseMoney').value = "";
        }
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>财务 > 
	<a class="hdrLink" href="CG_Payment_For_List.aspx">银行转账</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_FID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Code" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopLeft.gif"></td>
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
                                        <td class="dvtSelectedCell" align="center" nowrap>银行转账信息</td>
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
                                                    <td class="dvtCellLabel">转出帐号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList runat="server" ID="Ddl_OutAccount" >
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator5" runat="server" ErrorMessage="转出帐号不能为空" ControlToValidate="Ddl_OutAccount"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">转入帐号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList runat="server" ID="Ddl_InAccount">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="转入帐号不能为空" ControlToValidate="Ddl_InAccount"
                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">日期:</td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                        (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="申请日期不能为空"
                                                ControlToValidate="Tbx_STime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">金额:</td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Money" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';Chang();" Width="200px"></pc:PTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                            <tr>
                                                                <td class="dvtCellLabel">摘要:
                                                                </td>
                                                                <td class="dvtCellInfo" colspan="3">
                                                                    <pc:PTextBox runat="server" ID="Tbx_Details" TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="280px" Height="50px"></pc:PTextBox>
                                                                </td>
                                                            </tr>
                                                    <td colspan="4" align="center">&nbsp;
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                                        <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                                    </td>

                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td valign="top">
                                <img src="/themes/softed/images/showPanelTopRight.gif" /></td>
                        </tr>
                    </table>
    </form>
</body>
</html>
