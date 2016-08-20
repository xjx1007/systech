<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SC_Plan_AddDetails.aspx.cs"
    Inherits="SC_Plan_AddDetials" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>客户订单状况添加</title>
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
</head>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="/Web/KDialog/lhgdialog.js"></script>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("/Web/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");

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
    //改变日期
    function Keap1(ipt) {
        var trs = document.getElementById("GridView1");
        var pipt = ipt.parentNode.parentNode;
        var i_row = pipt.rowIndex;
        var i_rows = parseInt(i_row) + 1;
        var v_row = i_rows;
        if (v_row.toString().length == 1) {
            v_row = "0" + i_rows;
        }
        var i_rows = trs.rows.length;
        var BegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_BeginTime").value;
        var EndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value;
        var FBegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_FBeginTime").value;
        var FEndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value;
        var Days = document.getElementById("GridView1_ctl" + v_row + "_Tbx_Days").value;
        if ((BegindateTime != "") && (Days != "")) {
            var i_Days = parseInt(Days);
            var i_Days1 = parseInt(Days) + 2;

            document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value = addTime(i_Days, v_row);
            document.getElementById("GridView1_ctl" + v_row + "_Tbx_FBeginTime").value = addTime(2, v_row);
            document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value = addTime(i_Days1, v_row);
        }

    }

    //改变日期
    function Keap2(ipt) {
        var trs = document.getElementById("GridView1");
        var pipt = ipt.parentNode.parentNode;
        var i_row = pipt.rowIndex;
        var i_rows = parseInt(i_row) + 1;
        var v_row = i_rows;
        if (v_row.toString().length == 1) {
            v_row = "0" + i_rows;
        }
        var i_rows = trs.rows.length;
        var EndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value;
        var FEndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value;
        var Days = document.getElementById("GridView1_ctl" + v_row + "_Tbx_Days").value;
        if ((EndateTime != "") && (Days != "")) {
            var i_Days = parseInt(Days);
            var i_Days1 = parseInt(Days);

            document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value = addTime1(i_Days1, v_row);
        }

    }

    function addTime1(Days, v_row) {
        var i_Day = parseInt(Days);
        var BegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value;
        var v_Time = BegindateTime.replace(/-/g, "/");
        var d_Date = new Date(v_Time);
        d_Date = d_Date.valueOf();
        d_Date = d_Date + i_Day * 24 * 60 * 60 * 1000;
        d_Date = new Date(d_Date);

        var y = d_Date.getFullYear();
        var m = d_Date.getMonth() + 1;
        var d = d_Date.getDate();
        if (m <= 9) m = "0" + m;
        if (d <= 9) d = "0" + d;
        var cdate = y + "-" + m + "-" + d;
        return cdate;
    }
    function addTime(Days, v_row) {
        var i_Day = parseInt(Days);
        var BegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_BeginTime").value;
        var v_Time = BegindateTime.replace(/-/g, "/");
        var d_Date = new Date(v_Time);
        d_Date = d_Date.valueOf();
        d_Date = d_Date + i_Day * 24 * 60 * 60 * 1000;
        d_Date = new Date(d_Date);

        var y = d_Date.getFullYear();
        var m = d_Date.getMonth() + 1;
        var d = d_Date.getDate();
        if (m <= 9) m = "0" + m;
        if (d <= 9) d = "0" + d;
        var cdate = y + "-" + m + "-" + d;
        return cdate;
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>生产 > <a class="hdrLink" href="Sc_Plan_Manage.aspx">客户交期计划</a>
                </td>
            </tr>
            <tr>
                <td style="height: 10px"></td>
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

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">

                                                <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                    class="ListDetails">

                                                    <tr valign="top">
                                                        <td class="ListHead" nowrap>
                                                            <b>订单号</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>销售订单号</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>客户</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>产品</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>订单数量</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>未交货数量</b></td>
                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_SDetail"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>交货计划</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                    class="ListDetails">
                                                    <tr valign="top">
                                                        <td class="ListHead" nowrap>
                                                            <b>要求日期</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>交货数量</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>说明</b></td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td class="ListHeadDetails" nowrap valign="middle" align="center">
                                                            <asp:TextBox ID="Tbx_EndTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox></td>
                                                        <td class="ListHeadDetails" nowrap valign="middle" align="center">
                                                            <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px">
                                                                </asp:TextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" nowrap align="center">
                                                            <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="350px" Height="30px">
                                                                </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                                
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>历史交货计划信息</b>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td colspan="4">
                                                <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                    class="ListDetails">
                                                    <tr valign="top">
                                                        <td class="ListHead" nowrap>
                                                            <b>要求日期</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>交货数量</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>说明</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>创建日期</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>创建人</b></td>
                                                    </tr>
                                                    
                                                    <asp:Label runat="server" ID="Lbl_HistoryDetails"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="304" align="right" valign="top">
                                                <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">

                                                    <tr>
                                                        <td colspan="4" align="center" style="height: 30px">
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
                                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                    
                                    <asp:TextBox ID="Tbx_OrderNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_OrdTime" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
    </form>
</body>
</html>
