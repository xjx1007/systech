<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_AttenDance_OutManger_Report_Add.aspx.cs"
    Inherits="KNet_AttenDance_OutManger_Report_Add" %>

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
    <title></title>
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
                考勤管理 > <a class="hdrLink" href="KNet_AttenDance_OutManger_Report_Add.aspx">考勤管理统计</a>
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
                                        <td width="13%" align="right" class="dvtCellLabel">
                                            起始日期（时间）：
                                        </td>
                                        <td width="30%" align="left" class="dvtCellInfo" >
                                            <asp:TextBox ID="StartDateTime" runat="server" CssClass="Wdate" Width="200px" onfocus="WdatePicker()"></asp:TextBox>
                                        </td>
                                        <td width="13%" align="right" class="dvtCellLabel">
                                            结束日期（时间）：
                                        </td>
                                        <td width="30%" align="left" class="dvtCellInfo">
                                            <asp:TextBox ID="EndDatetime" runat="server" CssClass="Wdate" Width="200px" onfocus="WdatePicker()"></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="13%" align="right" class="dvtCellLabel">
                                            部门：
                                        </td>
                                        <td width="30%" align="left" class="dvtCellInfo" >
                                            <asp:DropDownList runat="server" ID="Ddl_Dept"></asp:DropDownList>
                                        </td>
                                        <td width="13%" align="right" class="dvtCellLabel">
                                            人员：
                                        </td>
                                        <td width="30%" align="left" class="dvtCellInfo" >
                                            <asp:DropDownList runat="server" ID="Ddl_DutyPerson"></asp:DropDownList>
                                        </td>
                                    </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:TextBox runat="server" ID="Tbx_SampleID" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:Button ID="Button2" runat="server" Text="查 询" AccessKey="S" title="查 询 [Alt+S]"
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
