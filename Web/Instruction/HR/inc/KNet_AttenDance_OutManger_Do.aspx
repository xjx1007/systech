<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_AttenDance_OutManger_Do.aspx.cs" Inherits="Knet_Web_HR_Inc_KNet_AttenDance_OutManger_Do" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../../themes/softed/style.css" type="text/css" />
    <link rel="alternate icon" type="image/png" href="../../../../images/士腾.png" />
    <script type="text/javascript" src="../../../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../../../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../../include/scriptaculous/dom-drag.js"></script>
    <title>人力资源--考勤审批</title>
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }
    </script>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>


            <%--内容开始--%>

            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
                <tr>
                    <td>

                        <asp:Label ID="IDtxt" runat="server" Text="" Visible="false"></asp:Label>&nbsp;

                        <asp:Label ID="Tbx_StaffNo" runat="server" Text="" Visible="false"></asp:Label>&nbsp;

                            <asp:Panel ID="Pan_Order" runat="server">
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">考勤单:</td>
                                        <td class="dvtCellInfo">状态:<asp:Label ID="ThisState" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                        <td class="dvtCellLabel">申请人:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="StaffName" runat="server" Text=""></asp:Label>&nbsp; &nbsp;卡号:<asp:Label ID="StaffCard" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="dvtCellLabel">类型:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ThisKings" runat="server"></asp:Label>&nbsp;</td>
                                        <td class="dvtCellLabel">申请时间:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="AddDatetime" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">所在部门:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="StaffDepart" runat="server"></asp:Label>&nbsp;</td>
                                        <td class="dvtCellLabel">公司:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="StaffBranch" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="17%" class="dvtCellLabel">开始时间:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="StartDateTime" runat="server" ReadOnly="true"></asp:Label>&nbsp;
                                        </td>

                                        <td class="dvtCellLabel">结束时间:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="EndDatetime" runat="server" ReadOnly="true"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">审批人:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ApprovalStaffNo" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td class="dvtCellLabel">审批时间:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="ApprovalDatetime" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="dvtCellLabel">目的地:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="thisExtendA" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td class="dvtCellLabel">请假类型:</td>
                                        <td class="dvtCellInfo">
                                            <asp:Label ID="Lbl_Type" runat="server"></asp:Label>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td class="dvtCellLabel">请假原因:</td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:Label ID="OutJustificate" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="36%" height="30" align="right" style="border-bottom: #A3B2CC 1px solid;">选择状态:</td>
                                        <td width="64%" style="border-bottom: #A3B2CC 1px solid;" colspan="3">&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">

                                            <asp:ListItem Value="-1">请选择审批情况</asp:ListItem>
                                            <asp:ListItem Value="1">通过审批（同意）</asp:ListItem>
                                            <asp:ListItem Value="2">不通过审核（拨回）</asp:ListItem>
                                            <asp:ListItem Value="0">暂不执行审批</asp:ListItem>
                                        </asp:DropDownList>


                                        </td>
                                    </tr>
                                    <tr>

                                        <td colspan="4" align="center">
                                            <asp:TextBox runat="server" ID="Tbx_SampleID" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:Button ID="Button2" runat="server" Text="确定操作" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Button1_Click" Style="width: 70px; height: 33px;" />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="closeWindow()"
                                                type="button" name="button" value="关 闭" style="width: 70px; height: 33px;">
                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>

                        <table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
                        </table>
        </div>
    </form>
</body>
</html>
