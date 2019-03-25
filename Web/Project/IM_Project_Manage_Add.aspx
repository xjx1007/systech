<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="IM_Project_Manage_Add.aspx.cs"
    Inherits="IM_Project_Manage_Add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script src="/Web/Js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <title>项目</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_CustomerID').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
            }
            else {

            }
        }

        function btnGetPerson_onclick() {
            var today, seconds;
            today = new Date();
            var v_Receive = document.all('Tbx_ReceiveID').value;
            var v_ReceiveName = document.all('Tbx_ReceiveName').value;
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Common/SelectDeptPerson.aspx?ID=" + v_Receive + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=600px;dialogHeight=500px");
            if (temp == undefined) {
                temp = window.returnValue;
            }
            if (temp != undefined) {
                var ss, s_Receive;
                ss = temp.split("|");
                document.all('Tbx_ReceiveID').value = ss[0];
                document.all('Tbx_ReceiveName').value = ss[1];
            }
            else {
                document.all('Tbx_ReceiveID').value = "";
                document.all('Tbx_ReceiveName').value = "";
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>研发 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">项目</a>
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

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>
                                                <asp:Label runat="server" ID="Lbl_Title"></asp:Label>
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
                                            <pc:PTextBox ID="Tbx_Code" runat="server" CssClass="Custom_Hidden"></pc:PTextBox>
                                            <td width="16%" align="right" class="dvtCellLabel">名称：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Name" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox></td>

                                            <td width="16%" align="right" class="dvtCellLabel">负责人：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">重要程度：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PDropdownList runat="server" ID="Ddl_Import" CodeNum="223" AllowSelect="false"></pc:PDropdownList>
                                            </td>

                                            <td width="16%" height="25" align="right" class="dvtCellLabel">授权查看:</td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:TextBox runat="server" ID="Tbx_ReceiveID" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_ReceiveName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="180px"></asp:TextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetPerson_onclick()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">类别：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PDropdownList runat="server" ID="Ddl_Type" CodeNum="222" AllowSelect="false"></pc:PDropdownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">类型：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PDropdownList runat="server" ID="Ddl_Class" CodeNum="224" AllowSelect="false"></pc:PDropdownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">开始日期：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Stime" Width="180px" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></pc:PTextBox>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">结束日期：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_EndTime" Width="180px" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">工期：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Days" Width="80px" runat="server" AllowEmpty="false" ValidType="Int" ValidError="请输入整数！" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></pc:PTextBox>
                                                <asp:RadioButton ID="RB_DaysType" GroupName="RB_Days" runat="server" Text="日历日期" Checked />
                                                <asp:RadioButton ID="RB_DaysType1" GroupName="RB_Days" runat="server" Text="单休" />
                                                <asp:RadioButton ID="RB_DaysType2" GroupName="RB_Days" runat="server" Text="双休" />
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">状态：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PDropdownList runat="server" ID="Ddl_State" CodeNum="226" AllowSelect="false"></pc:PDropdownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">客户：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                <pc:PTextBox ID="Tbx_CustomerID" runat="server" CssClass="Custom_Hidden"></pc:PTextBox>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">金额：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Money" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="120px" ValidType="String"></pc:PTextBox>
                                                <asp:CheckBox runat="server" ID="Chk_IsDetailsMoney" Text="关联项目合同金额" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="right" class="dvtCellLabel">简介：
                                            </td>
                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="600px" Height="40px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <script type="text/javascript">
                                            var importTxt = '导入模板';
                                            var cancelTxt = '取消';
                                            jQuery(function($) {
                                                $("#Btn_LoadTemplate").click(function () {
                                                    var span = $("#templateSeletor");
                                                    if (this.value == importTxt) {
                                                        this.value = cancelTxt;
                                                        this.style.width = "64px";
                                                        span.show();
                                                    }
                                                    else {
                                                        this.value = importTxt;
                                                        this.style.width = "80px";
                                                        span.hide();
                                                    }
                                                }).val(importTxt);
                                            })
                                    </script>
                                        <tr>
                                            <td align="left">子项：</td>
                                            <td colspan="3" align="right" Height="30px">                    
                                                <span id="templateSeletor" runat="server" style="display: none" >
                                                <asp:DropDownList runat="server" ID="Ddl_Template"></asp:DropDownList>
                                                <asp:Button ID="Btn_Load" CssClass="button" Width="80px" Height="25px" Text="确定"  runat="server" OnClick="Btn_Load_Click" />
                                                   </span>
                                                <input title="导入模板" type="button" accesskey="E" class="button"
                                                    style="width:80px;height:25px"
                                                   id="Btn_LoadTemplate" value="导入模板">
                                                   <input title="保存模板" type="button" accesskey="E" class="button"
                                                    onclick="addTemplate()" style="width:80px;height:25px"
                                                    name="Btn_AddTemplate" id="Btn_AddTemplate" value="保存模板">
                                                
                                                <asp:Button ID="Button1" runat="server" Text="排序" AccessKey="S" title="排序 [Alt+S]"
                                                    class="button" OnClick="Button1_Click" Style="width:80px;height:25px" />
                                                <input title="添加 [Alt+E]" type="button" accesskey="E" class="button"
                                                    onclick="add()" style="width:80px;height:25px"
                                                    name="Btn_AddDetails" id="Btn_AddDetails" value="&nbsp;添加&nbsp;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="dvtCellInfo" colspan="4">
                                                <table cellpadding="2" class="ListDetails" align="center" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td class="ListHead">名称</td>
                                                        <td class="ListHead">工期</td>
                                                        <td class="ListHead">浮动工期</td>
                                                        <td class="ListHead">计划开始</td>
                                                        <td class="ListHead">计划完成</td>
                                                        <td class="ListHead">实际开始</td>
                                                        <td class="ListHead">实际完成</td>
                                                        <td class="ListHead">前置任务</td>
                                                        <td class="ListHead">负责人</td>
                                                        <td class="ListHead">编辑</td>
                                                        <td class="ListHead">子项</td>
                                                        <td class="ListHead">删除</td>
                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <script type="text/javascript">
                                            function add() {
                                                var v_ID = document.all("Tbx_Code").value;
                                                var s = "no";
                                                var l = Math.ceil((window.screen.width - 530) / 3);
                                                var t = Math.ceil((window.screen.height - 800) / 3); //确定网页的坐标 
                                                window.open("Details/IM_Project_Manage_Details_Add.aspx?FID=" + v_ID + "", "_blank", "left=" + l + ",top=" + t + ",height=530,width=800,toolbar=no,status=no,resizable=yes,location=no,scrollbars=" + s);
                                            }
                                        </script>
                                        <script type="text/javascript">
                                            function addTemplate() {
                                                var v_ID = document.all("Tbx_Code").value;
                                                var s = "no";
                                                var l = Math.ceil((window.screen.width - 530) / 3);
                                                var t = Math.ceil((window.screen.height - 800) / 3); //确定网页的坐标 
                                                window.open("Template/IM_Project_Template_Add.aspx?FID=" + v_ID + "", "_blank", "left=" + l + ",top=" + t + ",height=530,width=800,toolbar=no,status=no,resizable=yes,location=no,scrollbars=" + s);
                                            }
                                        </script>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                &nbsp;<input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="height: 30px; width: 70px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_NID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
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
