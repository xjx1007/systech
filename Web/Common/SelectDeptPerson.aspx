<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectDeptPerson.aspx.cs" Inherits="Web_Common_SelectDeptPerson" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <title>选择人员</title>
</head>
<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../js/simple.js"></script>
<script>
    function closeWindow() {
        window.opener = null;
        window.close();
    }
</script>
<base target="_self" />
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" class="small" align="center" >
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>选择人员 >
	<a class="hdrLink" href="SelectCKProducts.aspx">选择人员</a>
                </td>
                <td width="100%" nowrap>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="sep1" style="width: 1px;"></td>
                            <td class="small">
                                <!-- Add and Search -->
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

        <table border="0" align="center" cellpadding="0" cellspacing="0" align="center" style="width: 648px" >
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                        <tr>
                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                            </td>
                            <td class="dvtSelectedCell" align="center" nowrap>选择人员
                            </td>
                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                            </td>
                            <td class="dvtTabCache" align="right" style="width: 100%">&nbsp;
                                            <asp:Button ID="Button2" runat="server" CssClass="crmbutton small save" Text="确定选择" OnClick="Button1_Click" Style="width: 60px; height: 30px;" />
                                <input name="button2" type="button" value="关闭窗口" class="crmbutton small cancel" onclick="closeWindow();" style="width: 60px; height: 30px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <table width="500px" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
            <tr>
                <td class="dvtCellInfo">

                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td width="13%" align="right" class="dvtCellLabel">公司：
                            </td>
                            <td width="30%" align="left" class="dvtCellInfo">
                                <asp:DropDownList ID="StaffBranch" runat="server" Visible="false">
                                </asp:DropDownList>
                                <asp:DropDownList ID="KNetStaffBranch" Width="200px" runat="server"></asp:DropDownList>
                            </td>
                            <td align="right" class="dvtCellLabel">部门:
                            </td>
                            <td align="left" class="dvtCellInfo">
                                <asp:DropDownList ID="KNetStaffDepart" Width="200px" runat="server"></asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                            <td width="13%" align="right" class="dvtCellLabel">关健词:
                            </td>
                            <td width="30%" align="left" class="dvtCellInfo">
                                <asp:TextBox ID="SeachKey" runat="server" Width="200px" CssClass="detailedViewTextBox"
                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                            </td>
                            <td colspan="2" class="dvtCellInfo">
                                <asp:Button ID="Button3" runat="server" Text="查询" CssClass="crmButton small save" Style="width: 60px; height: 26px;" OnClick="Button3_Click" />

                                </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table cellpadding="0" cellspacing="0" style="border-collapse: separate" width="100%">

                                    <tr>
                                        <td style="background: #f0f0f0; border: solid 1px #abadb3; border-bottom: none; padding: 5px 0 3px 3px">待选择项
                                        </td>
                                        <td style="width: 120px;">&nbsp;
                                        </td>
                                        <td style="background: #f0f0f0; border: solid 1px #abadb3; border-bottom: none; padding: 5px 0 3px 3px">已选择项
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <select name="Lst_FName" id="Lst_FName" class="detailedViewTextBox" runat="server" style="height: 330px; width: 100%; border: solid 1px #abadb3;" multiple></select>
                                        </td>
                                        <td align="center" style="width: 120px;">
                                            <p style="margin: 10px 0">
                                                <input name="_ctl0:WorkForm:dlb:_ctl0" type="button" class="button" onclick="moveRight()" value="添 加 →" />
                                            </p>
                                            <p style="margin: 10px 0">
                                                <input name="_ctl0:WorkForm:dlb:_ctl1" type="button" class="button" onclick="moveLeft()" value="删 除 ←" />
                                            </p>
                                            <p style="margin: 10px 0">
                                                <input name="_ctl0:WorkForm:dlb:_ctl2" type="button" class="button" onclick="moveRight(true)" value="全部添加" />
                                            </p>
                                            <p style="margin: 10px 0">
                                                <input name="_ctl0:WorkForm:dlb:_ctl3" type="button" class="button" onclick="moveLeft(true)" value="全部删除" />
                                            </p>
                                            <p style="margin: 10px 0">
                                                <input name="_ctl0:WorkForm:dlb:_ctl4" type="button" class="button" onclick="moveUp()" value="上移 ↑" />
                                            </p>
                                            <p style="margin: 10px 0">
                                                <input name="_ctl0:WorkForm:dlb:_ctl5" type="button" class="button" onclick="moveDown()" value="下移 ↓" />
                                            </p>
                                        </td>
                                        <td>
                                            <select name="Lst_Name" id="Lst_Name" runat="server" style="width: 100%; height: 330px; border: solid 1px #abadb3;" multiple></select>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>


                </td>
            </tr>
        </table>
        
<script type="text/javascript">
    var single = false;
    var left = document.getElementById("Lst_FName");
    var right = document.getElementById("Lst_Name");
    function moveUp() {
        $.moveOption(1, right);
    }
    function moveDown() {
        $.moveOption(2, right);
    }
    function getSelectedValue() {
        return $(right).selectedOptions();
    }
    function getSelectedCount() {
        var count = 0;
        for (var i = 0; i < left.options.length; i++) {
            if (left.options[i].selected)
                count++;
        }
        return count;
    }
    function chkSingle(all) {

        if (!single) return true;
        if (all || getSelectedCount() > 1) {
            alert("只能单选");
            return false;
        }
        if (right.options.length > 0) {
            $.delOption(right, true);
        }
        return true;
    }
    function prev() {
        calcPageIndex("-");
        searchByKey()
    }
    function next() {
        calcPageIndex("+");
        searchByKey()
    }
    function calcPageIndex(type) {
        var pageIndex = parseInt($("#pageIndex").html());
        var pageCount = parseInt($("#pageCount").html());
        if (type == "+")
            pageIndex++;
        else
            pageIndex--;
        if (pageIndex == 0)
            pageIndex = pageCount;
        else if (pageIndex > pageCount)
            pageIndex = 1;
        $("#pageIndex").html(pageIndex);
    }
</script>
<script type="text/javascript">
    function moveRight(all) {

        if (chkSingle(all))
            $.moveOption(0, left, right, all);
    }
    function moveLeft(all) {
        $.moveOption(0, right, left, all);
    }
</script>
    <script type="text/javascript">
        $(left).bindEvent("dblclick", function () { moveRight(false); });
        $(right).bindEvent("dblclick", function () { moveLeft(false); });
        window.onload = function () {
            var l = document.getElementById("Lst_FName");
            var r = document.getElementById("Lst_Name");
            var leftWidth = Math.max(l.clientWidth, l.offsetWidth);
            var rightWidth = Math.max(r.clientWidth, r.offsetWidth);
            var maxWidth = Math.max(leftWidth, rightWidth);
            if (maxWidth < 220) maxWidth = 220;
            l.style.width = maxWidth + "px";
            r.style.width = maxWidth + "px";
        };
</script>
    </form>
</body>
</html>

