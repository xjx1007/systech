<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PB_Basic_Express_Add.aspx.cs"
    Inherits="PB_Basic_Express_Add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <title>快递跟踪添加</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("|");
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
                document.all('Tbx_Shen').value = ss[2];
                document.all('Tbx_Shi').value = ss[3];
            }
            else {
                document.all('Tbx_CustomerValue').value = "";
                document.all('Tbx_CustomerName').value = "";
                document.all('Tbx_Shen').value = "";
                document.all('Tbx_Shi').value = "";
            }
        }
        function btnGetPerson_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            Custom = document.all('Tbx_CustomerValue').value;

            var tempd = window.showModalDialog("SelectContentPerson.aspx?ID=" + Custom + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("|");
                document.all('Tbx_LinkMan').value = ss[0];
                document.all('Tbx_LinkManName').value = ss[1];
                document.all('Tbx_Phone').value = ss[2];
                document.all('Tbx_TelPhone').value = ss[3];
                document.all('Tbx_Address').value = ss[4];
            }
            else {
                document.all('Tbx_LinkMan').value = "";
                document.all('Tbx_LinkManName').value = "";
                document.all('Tbx_Phone').value = "";
                document.all('Tbx_TelPhone').value = "";
                document.all('Tbx_Address').value = "";
            }
        }
        function btnGetReReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("|");
                document.all('Tbx_ReCustomerValue').value = ss[0];
                document.all('Tbx_ReCustomerName').value = ss[1];
                document.all('Tbx_ReShen').value = ss[2];
                document.all('Tbx_ReShi').value = ss[3];
            }
            else {
                document.all('Tbx_ReCustomerValue').value = "";
                document.all('Tbx_ReCustomerName').value = "";
                document.all('Tbx_ReShen').value = "";
                document.all('Tbx_ReShi').value = "";
            }
        }
        function btnGetRePerson_onclick() {
            var today, seconds;
            today = new Date();
            Custom = document.all('Tbx_ReCustomerValue').value;

            var tempd = window.showModalDialog("SelectContentPerson.aspx?ID=" + Custom + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("|");
                document.all('Tbx_ReLinkMan').value = ss[0];
                document.all('Tbx_ReLinkManName').value = ss[1];
                document.all('Tbx_RePhone').value = ss[2];
                document.all('Tbx_ReTelPhone').value = ss[3];
                document.all('Tbx_ReAddress').value = ss[4];
            }
            else {
                document.all('Tbx_ReLinkMan').value = "";
                document.all('Tbx_ReLinkManName').value = "";
                document.all('Tbx_RePhone').value = "";
                document.all('Tbx_ReTelPhone').value = "";
                document.all('Tbx_ReAddress').value = "";
            }
        }
        function searchFromSelect(str) {
            var o = document.getElementById("Ddl_KDName");
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
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="PB_Basic_Express_List.aspx">快递跟踪添加</a>
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
                    <img src="../../themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtSelectedCell" align="center" nowrap>快递跟踪添加
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
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">单号：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px" ValidType="String"></pc:PTextBox><font
                                                        color="red">*</font>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">日期:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:TextBox ID="Tbx_Stime" runat="server" CssClass="Wdate"
                                                    onClick="WdatePicker()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">责任人：
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" Width="150px"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>发件人信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">发件人公司：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server" />
                                                <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="发件人公司不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                            </td>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">发件人：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <input type="hidden" name="Tbx_LinkMan" id="Tbx_LinkMan" runat="server" />
                                                <pc:PTextBox ID="Tbx_LinkManName" runat="server" AllowEmpty="false" ValidError="发件人不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetPerson_onclick()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">地址：
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_Shen" AutoPostBack="true" OnSelectedIndexChanged="ddlSheng_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_Shi" AutoPostBack="true" OnSelectedIndexChanged="ddlShi_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_Qu" AutoPostBack="true" OnSelectedIndexChanged="ddlQu_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_Jie"></asp:DropDownList>
                                                        <br />
                                                        <pc:PTextBox ID="Tbx_Address" runat="server" AllowEmpty="false" TextMode="MultiLine" ValidError="地址不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Height="40px" Width="500px"></pc:PTextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">手机：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Phone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                            </td>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">电话：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_TelPhone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>收件人信息</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">收件人公司：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <input type="hidden" name="Tbx_ReCustomerValue" id="Tbx_ReCustomerValue" runat="server" />
                                                <pc:PTextBox ID="Tbx_ReCustomerName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReReturnValue_onclick()" />&nbsp;
                                            </td>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">收件人：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <input type="hidden" name="Tbx_ReLinkMan" id="Tbx_ReLinkMan" runat="server" />
                                                <pc:PTextBox ID="Tbx_ReLinkManName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetRePerson_onclick()" />&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">地址：
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">

                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_ReShen" AutoPostBack="true" OnSelectedIndexChanged="ddlReSheng_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_ReShi" AutoPostBack="true" OnSelectedIndexChanged="ddlReShi_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_ReQu" AutoPostBack="true" OnSelectedIndexChanged="ddlReQu_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:DropDownList CssClass="detailedViewTextBox" Width="150px" runat="server" ID="Ddl_ReJie"></asp:DropDownList>
                                                        <br />
                                                        <pc:PTextBox ID="Tbx_ReAddress" runat="server" AllowEmpty="false" TextMode="MultiLine" ValidError="地址不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Height="40px" Width="500px"></pc:PTextBox>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">手机：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_RePhone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                            </td>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">电话：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_ReTelPhone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>快递信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">快递名称：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_KDName" CssClass="detailedViewTextBox" Width="150px"></asp:DropDownList>
                                                <input type="text" id="span" onchange='Chang()' onkeyup='searchFromSelect(this.value)'
                                                    onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}'
                                                    style="width: 60; height: 20; border: 1 solid #0000FF; overflow-y: auto"></input>
                                            </td>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">快递单号：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_KdCode" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">备注：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Use" runat="server" TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Height="40px" Width="500px"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="height: 30px; width: 70px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
            </tr>
        </table>
        </td>
    <td align="right" valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif" />
    </td>
        </tr> </table>
    </form>
</body>
</html>
