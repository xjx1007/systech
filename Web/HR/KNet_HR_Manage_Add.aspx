<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_HR_Manage_Add.aspx.cs"
    Inherits="Knet_Web_HR_KNet_HR_Manage_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>人员管理</title>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript">

        function btnGetProductsTypeValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("/Web/ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("/Web/ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }

        function Clear() {
            document.all('Tbx_ProductsTypeNo').value = "";
            document.all('Tbx_ProductsTypeName').value = "";
        }
        function SetReturnValueInOpenner_ProductsClass(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                if (document.all('Tbx_ProductsTypeNo').value != "") {
                    document.all('Tbx_ProductsTypeNo').value += "," + ss[0];
                    document.all('Tbx_ProductsTypeName').value += "," + ss[1];
                }
                else {
                    document.all('Tbx_ProductsTypeNo').value = ss[0];
                    document.all('Tbx_ProductsTypeName').value = ss[1];
                }
            }
            else {
                document.all('Tbx_ProductsTypeNo').value = "";
                document.all('Tbx_ProductsTypeName').value = "";
            }
        }
    </script>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>人员管理 > <a class="hdrLink" href="KNet_HR_Manage.aspx">人员管理</a>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>客户信息
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
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="304" align="right" valign="top">
                                                <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">

                                                    <tr>
                                                        <td width="16%" height="25" class="dvtCellLabel" align="left">公司:</td>
                                                        <td align="right" class="dvtCellInfo">&nbsp;<asp:DropDownList ID="StaffBranch1" runat="server" Width="152px" OnSelectedIndexChanged="StaffBranch1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>(<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                            runat="server" ErrorMessage="请选择分部" ControlToValidate="StaffBranch1" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                        <td class="dvtCellLabel" align="left">选择部门:</td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList ID="StaffDepart1" runat="server" Width="152px">
                                                            </asp:DropDownList></td>
                                                    </tr>

                                                    <tr>
                                                        <td width="16%" height="25" class="dvtCellLabel" align="left">员工卡号:</td>
                                                        <td width="35%" align="left" class="dvtCellInfo">&nbsp;
          <asp:TextBox ID="StaffCard1" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="20"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
              ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空！" ControlToValidate="StaffCard1" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td width="17%" class="dvtCellLabel" align="left">员工姓名:</td>
                                                        <td width="32%" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="StaffName1" runat="server" MaxLength="30" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="员工姓名必填" ControlToValidate="StaffName1" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                    </tr>


                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">登陆密码:</td>
                                                        <td align="left" class="dvtCellInfo">&nbsp;
          <asp:TextBox ID="StaffPassword1" TextMode="Password" runat="server" MaxLength="30" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>(<font color="red">*</font>)<font color="gray">(如不修改,请留空)</font><asp:RegularExpressionValidator
              ID="RegularExpressionValidator2" runat="server" ErrorMessage="密码长度在5-18之间的数字与字母组合！" ControlToValidate="StaffPassword1" ValidationExpression="^\w{5,17}$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="dvtCellLabel" align="left">确认密码:</td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="StaffPassword2" TextMode="Password" MaxLength="30" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>(<font color="red">*</font>)<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="确认不正确" ControlToCompare="StaffPassword1" ControlToValidate="StaffPassword2" Display="Dynamic"></asp:CompareValidator></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">基本工资:</td>
                                                        <td align="left" class="dvtCellInfo">&nbsp;
          <asp:TextBox ID="Staffwages1" runat="server" MaxLength="30" Text="1000.00" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
              ID="RegularExpressionValidator1" runat="server" ErrorMessage="货币形式！" ControlToValidate="Staffwages1" ValidationExpression="^(-)?(\d+|,\d{3})+(\.\d{0,3})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="dvtCellLabel" align="left">性别:</td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:RadioButtonList ID="StaffSex1" runat="server" Width="105px" Height="25px" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                                                <asp:ListItem Value="0">女</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>


                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">联系电话:</td>
                                                        <td align="left" class="dvtCellInfo">&nbsp;
          <asp:TextBox ID="StaffTel1" runat="server" MaxLength="20" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
              ID="RegularExpressionValidator4" runat="server" ErrorMessage="电话号码不正确!" ControlToValidate="StaffTel1" ValidationExpression="^(\(\d{3,4}\)|\d{3,4}-)?\d{7,11}$" Display="Dynamic"></asp:RegularExpressionValidator></td>
                                                        <td class="dvtCellLabel" align="left">电子邮件:</td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="StaffEmail1" runat="server" MaxLength="60" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
                                                                ID="StaffEmail1aa" runat="server" ErrorMessage="邮件输入错误！" ControlToValidate="StaffEmail1" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">固定电话:</td>
                                                        <td align="left" class="dvtCellInfo">&nbsp;
          <asp:TextBox ID="Tbx_TelPhone" runat="server" MaxLength="20" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">身份证号:</td>
                                                        <td align="left" class="dvtCellInfo">&nbsp;
          <asp:TextBox ID="StaffIDCard1" MaxLength="30" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
              ID="RegularExpressionValidator5" runat="server" ErrorMessage="身份证号码不正确" ControlToValidate="StaffIDCard1" ValidationExpression="\d{17}[\d|X]|\d{15}" Display="Dynamic"></asp:RegularExpressionValidator></td>
                                                        <td class="dvtCellLabel" align="left">入职时间:</td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="StaffAddTime1" MaxLength="30" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">通信地址:</td>
                                                        <td align="right" class="dvtCellInfo">&nbsp;<asp:TextBox ID="StaffAddress1" runat="server" MaxLength="100" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px"></asp:TextBox></td>
                                                        <td height="25" class="dvtCellLabel" align="left">职位:</td>
                                                        <td align="right" class="dvtCellInfo">&nbsp;<asp:DropDownList ID="Drop_Position" runat="server" CssClass="detailedViewTextBox" Width="150px" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:DropDownList></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">上级领导:</td>
                                                        <td align="right" class="dvtCellInfo">&nbsp;<asp:DropDownList ID="Ddl_Person" runat="server" CssClass="detailedViewTextBox" Width="150px" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:DropDownList></td>
                                                        <td height="25" class="dvtCellLabel" align="left">是否负责销售:</td>
                                                        <td align="right" class="dvtCellInfo">&nbsp;<asp:DropDownList ID="Ddl_IsSale" runat="server" CssClass="detailedViewTextBox" Width="150px" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'">
                                                            <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="是"></asp:ListItem>

                                                        </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" class="dvtCellLabel" align="left">邮件密码:</td>
                                                        <td align="right" class="dvtCellInfo">&nbsp;<asp:TextBox ID="Tbx_MailPassWord" runat="server" MaxLength="100" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px"></asp:TextBox></td>
                                                        <td height="25" class="dvtCellLabel" align="left">是否外网登录:</td>
                                                        <td align="right" class="dvtCellInfo">&nbsp;<asp:DropDownList ID="Ddl_IsWeb" runat="server" CssClass="detailedViewTextBox" Width="150px" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'">
                                                            <asp:ListItem Value="0" Text="否"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="是"></asp:ListItem>
                                                        </asp:DropDownList></td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">负责分类:</td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="Tbx_ProductsTypeName" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                MaxLength="48" Width="200px"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_ProductsTypeNo" runat="server"  CssClass="Custom_Hidden" ></asp:TextBox>
                                                            <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProductsTypeValue_onclick()" />

                                                            <img src="/themes/softed/images/clear_field.gif" alt="清除" title="清除" onclick="return Clear()" />
                                                        </td>

                                                    </tr>

                                                    <tr>
                                                        <td height="50" class="dvtCellLabel" align="left">备注:</td>
                                                        <td colspan="3" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Remarks1" runat="server" Style="display: none;"></asp:TextBox>
                                                            <iframe src='../eWebEditor/ewebeditor.htm?id=Remarks1&style=coolblue' frameborder='0' scrolling='no' width='620' height='350'></iframe>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" align="center" style="height: 30px">
                                                            <asp:Button ID="Button3" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                                class="crmbutton small save" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />
                                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                                type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                    <asp:Label ID="OldPasword" runat="server" Visible="false"></asp:Label>
                                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_LinkManID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>

                                </td>
                            </tr>
                        </table>
                </td>
                <td align="right" valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>



    </form>
</body>
</html>
