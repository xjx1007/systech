<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_LinkMan_Add.aspx.cs"
    Inherits="Web_Sales_KNet_Sales_LinkMan_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>联系人新增</title>
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
</head>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        //var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        var tempd = window.open("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function SetReturnValueInOpenner_Customer(tempd) {
        if (tempd == undefined) {
            tempd = window.returnValue;
        }
        var sel = document.getElementById("Ddl_Manager");
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
            document.all('Tbx_Code').value = ss[2];
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
            document.all('Tbx_Code').value = "";
            var length = sel.length;
            for (var i = length - 1; i >= 0; i--) {
                sel.remove(i);
            }
        }
    }
    function GetAddress()
    {
        var checkText = $("#sheng").find("option:selected").text();
        alert(checkText);
    }
    function ChangeShen() {

        var sel = document.getElementById("city");
        var v_Shen = $('sheng').value;
        var response = Web_Sales_KNet_Sales_LinkMan_Add.GetShen(v_Shen);
        var length = sel.length;
        for (var i = length - 1; i >= 0; i--) {
            sel.remove(i);
        }
        var opt = new Option("", "");
        sel.options.add(opt);
        var st, sw;
        st = response.value.split("|");
        if (st.length > 0) {
            for (var i = 0; i < st.length - 1; i++) {
                sw = st[i].split(",");
                var opt = new Option(sw[1], sw[0]);
                sel.options.add(opt);
            }
        }
        GetAddress();
    }
    function GetCustomerID() {
        var ID = document.all('Tbx_ID').value;
        var Type = document.all('Tbx_Type').value;
        var faterCode = document.all('FaterCode').value;
        var CustomerTypes = document.all('CustomerTypes').value;
        var CustomerClass = document.all('CustomerClass').value;
        var sheng = document.all('sheng').value;
        if ((ID != "") && (Type != "") || (ID == "")) {

            var response = Knet_Web_Sales_KNet_Sales_ClientList_Add.GetCustomer(faterCode, CustomerTypes, CustomerClass, sheng)
            document.all('CustomerValue').value = response.value;
        }
    }

</script>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="detail_info_click('Details1');detail_info_click('Div1');">
    <form id="EditView" runat="server" enctype="multipart/form-data">
        <div id="ssdd" style="padding: 1px">
        </div>

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>联系人 > <a class="hdrLink" href="KNet_Sales_LinkMan_List.aspx">联系人</a>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>联系人信息
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                            <tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_Code" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_Code" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center" class="dvtContentSpace">

                                        <tr style="height: 16px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Div2');">
                                            <!-- windLayerHeadingTr -->
                                            <td colspan="4" class="" valign="middle">&nbsp;&nbsp;基本信息&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 16px; width: 30px;" onclick="detail_info_click('Div2');">
                                                <img align="absmiddle" id="Div2_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                            </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div id="Div2">
                                                    <table width="100%" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="dvtCellLabel">姓名:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Name" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>(<font
                                                                        color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="名称非空"
                                                ControlToValidate="txtXOL_Name" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="dvtCellLabel">称呼:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList ID="Ddl_CallName" runat="server" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">负责业务:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:CheckBoxList ID="Chk_ResPonsible" runat="server" RepeatColumns="5">
                                                                </asp:CheckBoxList>
                                                                <asp:TextBox ID="txtXOL_Responsible" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="17%" class="dvtCellLabel">客户:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                                    style="width: 150px" />
                                                                <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="178px" ReadOnly="true"></asp:TextBox>
                                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                                    onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户"
                                                                    ControlToValidate="Tbx_CustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="dvtCellLabel">负责人:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList ID="Ddl_DutyPerson" runat="server" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">英文名:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan>
                                                                <asp:TextBox ID="tbxXOL_EnglishName" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">经理:
                                                            </td>
                                                            <td class="dvtCellInfo" >
                                                                <asp:DropDownList ID="Ddl_Manager" runat="server" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">手机:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Phone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">传真:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Fax" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">Email:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Mail" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">住宅电话:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Homephone" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">办公电话:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Officephone" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                <img border="0" src="/themes/softed/images/qq.gif" align="middle">
                                                            </td>
                                                            <td class="dvtCellInfo"><asp:TextBox
                                                                    ID="Tbx_QQ" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="16%" height="25" align="right" class="dvtCellLabel">所在省份:
                                                            </td>
                                                            <td width="35%" align="left" class="dvtCellInfo">
                                                                <asp:DropDownList ID="sheng" Style="width: 150px" runat="server" OnChange="ChangeShen()">
                                                                </asp:DropDownList>
                                                                (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                                                    runat="server" ErrorMessage="所在省份不能为空！" ControlToValidate="sheng" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td width="17%" align="right" class="dvtCellLabel">所在城区:
                                                            </td>
                                                            <td width="32%" align="left" class="dvtCellInfo">
                                                                <asp:DropDownList ID="city" runat="server">
                                                                </asp:DropDownList>
                                                                (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                                    runat="server" ErrorMessage="所在城区不能为空！" ControlToValidate="city" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">地址:
                                                            </td>
                                                            <td valign="top" class="dvtCellInfo" colspan="3">
                                                                <asp:TextBox ID="txtXOL_Address" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="700px" Height="40px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="height: 28px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Div1');">
                                            <!-- windLayerHeadingTr -->
                                            <td colspan="4" class="" valign="middle">&nbsp;&nbsp;其他信息&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 30px; width: 30px;" onclick="detail_info_click('Div1');">
                                                <img align="absmiddle" id="Div1_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                            </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div id="Div1">
                                                    <table width="100%" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="dvtCellLabel">学历:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="DdlXOL_Education">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="dvtCellLabel">部门:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="DdlXOL_Duty" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">年龄:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Age" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">性别:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="DdlXOL_Sex">
                                                                    <asp:ListItem Value="男">男</asp:ListItem>
                                                                    <asp:ListItem Value="女">女</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">生日:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Birthday" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">籍贯:
                                                            </td>
                                                            <td width="33%" class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="DdlXOL_Place">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">民族:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="DdlXOL_Nation">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="dvtCellLabel">婚姻:
                                                            </td>
                                                            <td width="33%" class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="DdlXOL_Marriage">
                                                                    <asp:ListItem Value="未婚">未婚</asp:ListItem>
                                                                    <asp:ListItem Value="已婚">已婚</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="height: 28px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Details1');">
                                            <!-- windLayerHeadingTr -->
                                            <td colspan="4" class="" valign="middle">&nbsp;&nbsp;描述信息&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 30px; width: 30px;" onclick="detail_info_click('Details1');">
                                                <img align="absmiddle" id="Details1_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                            </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <div id="Details1">
                                                    <table width="100%" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="dvtCellLabel">爱好/特长:
                                                            </td>
                                                            <td valign="top" class="dvtCellInfo" colspan="3">
                                                                <asp:TextBox ID="txtXOL_Hobby" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="300px" Height="40px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">物流地址:
                                                            </td>
                                                            <td valign="top" class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_LogisticsAddress" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="300px" Height="40px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">评价:
                                                            </td>
                                                            <td valign="top" class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Evaluation" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="300px" Height="40px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">工作履历:
                                                            </td>
                                                            <td valign="top" class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Experience" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="300px" Height="40px"></asp:TextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">备注说明:
                                                            </td>
                                                            <td valign="top" class="dvtCellInfo">
                                                                <asp:TextBox ID="txtXOL_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="300px" Height="40px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
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
                                    <tr>
                                        <td width="15%" height="25" align="left" class="dvtCellInfo" colspan="4"><font
                                                    color="gray">
                                        电话、EMail、QQ等多个以"/"区分连续添加。例如：项洲的手机 18958017483/13456709576<br />
                                        </font>
                                                 </td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                        <%--收货单信息  结束--%>
                    </div>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
                                    
        </table>
    </form>
</body>
</html>
