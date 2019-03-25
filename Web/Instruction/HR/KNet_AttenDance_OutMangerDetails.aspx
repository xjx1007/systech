<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_AttenDance_OutMangerDetails.aspx.cs" Inherits="Knet_Web_HR_KNet_AttenDance_OutMangerDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../css/knetPrint.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <title>考勤详细信息</title>
    <script language="javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            window.document.body.innerHTML = bdhtml;
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="93%" height="30" align="center" style="border-bottom: #333333 1px dotted;">
                        <img src="../../images/print.gif" width="36" height="34" border="0" style="cursor: hand;" onclick="preview();window.close()" /></td>
                    <td width="7%" height="30" align="left" style="border-bottom: #333333 1px dotted;">
                        <img src="../../images/Close.gif" width="32" height="32" border="0" style="cursor: hand;" onclick="window.close()"></td>
                </tr>
            </table>
            <!--startprint-->
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="31" colspan="2" align="left" style="border-bottom: #333333 2px solid;"><span class="font18px">考勤单</span>&nbsp;&nbsp;&nbsp;&nbsp;状态:<asp:Label ID="ThisState" runat="server" Text=""></asp:Label></td>
                    <td height="31" colspan="2" align="right" valign="bottom" style="border-bottom: #333333 2px solid;">申请人:<asp:Label ID="StaffName" runat="server" Text=""></asp:Label>
                        &nbsp;卡号:<asp:Label ID="StaffCard" runat="server" Text=""></asp:Label>&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td width="19%" height="25" align="right" style="border-bottom: #333333 1px solid;">类型：</td>
                    <td width="29%" style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="ThisKings" runat="server" Text=""></asp:Label></td>
                    <td width="21%" align="right" style="border-bottom: #333333 1px solid;">申请时间：</td>
                    <td width="31%" style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="AddDatetime" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">公司： </td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffBranch" runat="server" Text=""></asp:Label></td>
                    <td align="right" style="border-bottom: #333333 1px solid;">所在部门： </td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffDepart" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">开始时间：</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StartDateTime" runat="server" Text=""></asp:Label></td>
                    <td align="right" style="border-bottom: #333333 1px solid;">结束时间： </td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="EndDatetime" runat="server" Text=""></asp:Label></td>
                </tr>


                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">审批人： </td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="ApprovalStaffNo" runat="server" Text=""></asp:Label></td>
                    <td align="right" style="border-bottom: #333333 1px solid;">审批时间：</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="ApprovalDatetime" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr id="ADDsPart" runat="server" visible="false">
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">目的地： </td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="thisExtendA" runat="server" Text=""></asp:Label></td>
                    <td align="right" style="border-bottom: #333333 1px solid;">&nbsp;</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;</td>
                </tr>

                <tr>
                    <td height="35" align="right" style="border-bottom: #333333 1px solid;">原由：</td>
                    <td colspan="3" style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="OutJustificate" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td height="30" colspan="4" align="right">制表人:<asp:TextBox ID="makeMan" runat="server" CssClass="Boxx" Width="100px"></asp:TextBox>制表时间:<asp:TextBox ID="makeTime" runat="server" CssClass="Boxx" Width="100px"></asp:TextBox></td>
                </tr>
            </table>
            <!--endprint-->


        </div>
    </form>
</body>
</html>
