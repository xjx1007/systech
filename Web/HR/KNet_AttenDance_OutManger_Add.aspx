<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_AttenDance_OutManger_Add.aspx.cs"
    Inherits="Knet_Web_HR_KNet_AttenDance_OutManger_Add" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectSuppliers.aspx?sID=" + document.all("Xs_ClientID").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=900px;dialogHeight=550px");

            if (tempd != undefined) {

                var ss, s_Value, s_Name, i_row;
                ss = tempd.split("|");
                s_Value = ss[0].split(",");
                s_Name = ss[1].split(",");
                i_row = myTable.rows.length;
                s_ID = document.all("Xs_ClientID").value;
                for (var i = 0; i < s_Value.length; i++) {
                    var objRow = myTable.insertRow(i_row);

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\" input Name=\"CustomerValue\" value=' + s_Value[i] + '>' + s_Value[i];
                    objCel.className = "dvtCellInfo";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"hidden\"  Name=\"CustomerName\" value=' + s_Name[i] + ' >' + s_Name[i];
                    objCel.className = "dvtCellInfo";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[i] + ",";
                }

                document.all("Xs_ClientID").value = s_ID;
            }
        }
        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("CustomerValue");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Xs_ClientID").value = bm_num;
        }

    </script>
    <title>考勤管理</title>
</head>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    </div>
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                考勤管理 > <a class="hdrLink" href="KNet_AttenDance_OutManger_Add.aspx">考勤管理添加</a>
            </td>
            <td width="100%" nowrap>
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
                                        <td class="dvtTabCache" style="width: 10px" nowrap>
                                            &nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            考勤申请信息
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
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                        <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                    </tr>
                                    <tr>
                                        <td width="15%" height="25" align="right" class="dvtCellLabel">
                                            申请者:
                                        </td>
                                        <td align="left" class="dvtCellInfo"  colspan="3">
                                            <asp:TextBox ID="StaffNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'" Width="300px" MaxLength="40"></asp:TextBox>(<font
                                                    color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                        ErrorMessage="申请者非空！" ControlToValidate="StaffNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="13%" align="right" class="dvtCellLabel">
                                            申请类型：
                                        </td>
                                        <td width="30%" align="left" class="dvtCellInfo"  colspan="3">
                                            <asp:DropDownList ID="DDLThisKings" runat="server" Width="150px" OnSelectedIndexChanged="DDLThisKings_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                runat="server" ErrorMessage="请选择类型" ControlToValidate="DDLThisKings" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <asp:Panel Visible="false" ID="OrderQj" runat="server">
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">
                                                请假类型:
                                            </td>
                                        <td width="30%" align="left" class="dvtCellInfo"  colspan="3">
                                               <asp:DropDownList ID="Ddl_Type" runat="server" Width="150px" OnSelectedIndexChanged="DDLThisKings_SelectedIndexChanged"
                                                AutoPostBack="true">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                runat="server" ErrorMessage="请选择请假类型" ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                          </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td width="13%" align="right" class="dvtCellLabel">
                                            起始日期（时间）：
                                        </td>
                                        <td width="30%" align="left" class="dvtCellInfo" >
                                            <asp:TextBox ID="StartDateTime" runat="server" CssClass="Wdate" Width="200px" onfocus="WdatePicker({dateFmt:'yyyy年MM月dd日 HH时mm分'})"></asp:TextBox>(<font
                                                color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ErrorMessage="请选择起始日期（时间）" ControlToValidate="StartDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    <asp:Panel  ID="Pan_EndTime" runat="server">
                                        <td width="13%" align="right" class="dvtCellLabel">
                                            结束日期（时间）：
                                        </td>
                                        <td width="30%" align="left" class="dvtCellInfo">
                                            <asp:TextBox ID="EndDatetime" runat="server" CssClass="Wdate" Width="200px" onfocus="WdatePicker({dateFmt:'yyyy年MM月dd日 HH时mm分'})"></asp:TextBox>(<font
                                                color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                    ErrorMessage="请选择结束日期（时间）" ControlToValidate="EndDatetime" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </asp:Panel>
                                    </tr>
                                    <asp:Panel Visible="false" ID="OrderDiti" runat="server">
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">
                                                目的地:
                                            </td>
                                            <td align="left" class="dvtCellInfo" >
                                                <asp:TextBox ID="thisExtendA" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px" MaxLength="40"></asp:TextBox>(<font
                                                        color="red">*</font>)
                                            </td>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">
                                                交通工具:
                                            </td>
                                            <td align="left" class="dvtCellInfo" >
                                                <asp:DropDownList ID="Ddl_Traffic" runat="server" Width="150px" >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">
                                                选择客户/供应商:
                                            </td>
                                            <td align="left" class="dvtCellInfo" colspan="2" >
                                        <asp:TextBox ID="Xs_ClientID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr id="tr1">
                                                    <td align="center" class="dvtCellLabel">
                                                        工具
                                                    </td>
                                                    <td align="center" class="dvtCellLabel">
                                                        客户编号
                                                    </td>
                                                    <td align="center" class="dvtCellLabel">
                                                        客户名称
                                                    </td>
                                                </tr>
                                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                            </table>
                                            <input id=" btnGetReturnValue" class="crmbutton small create" onclick="return btnGetReturnValue_onclick()"
                                                type="button" value="选择客户/供应商" />
                                             </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td width="15%" height="25" align="right" class="dvtCellLabel">
                                            说明:
                                        </td>
                                        <td align="left" class="dvtCellInfo" colspan="3">
                                            <asp:TextBox ID="OutJustificate" runat="server" TextMode="MultiLine" Width="440px"
                                                Height="80px" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>(<font color="red">*</font>)<font
                                                    color="gray">600字内.写原因与理由等.</font>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请填写申请原由"
                                                ControlToValidate="OutJustificate" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="OutJustificate"
                                                ValidationExpression="^(\s|\S){0,600}$" ErrorMessage="申请原由字太多" Display="dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="15%" height="25" align="left" class="dvtCellInfo" colspan="4"><font
                                                    color="gray">
                                        外出登记：用于外出不用报销。<br />
                                        出差登记：出差报销，如果拜访客户请选择客户，在这期间内的联系记录将自动核销该出差登记。否则将填写出差报告进行核销。出差日期如果一天请选择到8点之前，下班选择到17：30<br />
                                        上班登记：用于未带卡或卡丢失情况.请在上班之前登记。<br />
                                        下班登记：同上班登记。<br />
                                        晚打卡登记：用于前一天工作较晚，第二天申请晚点打卡。<br />
                                        早打卡登记：用于提前下班申请登记。<br />
                                        </font>
                                                 </td>
                                    </tr>
                                    
                                    
                        <tr>
                            <td colspan="4" align="center">
                                <asp:TextBox runat="server" ID="Tbx_SampleID" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:Button ID="Button2" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                    class="crmbutton small save" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                            </td>
                        </tr>
                    </table>
            </td>
        </tr>
    </table>
    </td>
    <td align="right" valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif">
    </td>
    </tr> </table>
    </form>
</body>
</html>
