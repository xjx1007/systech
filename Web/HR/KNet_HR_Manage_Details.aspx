<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_HR_Manage_Details.aspx.cs"
    Inherits="Knet_Web_HR_KNet_HR_Manage_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetPrint.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title>人员详细信息</title>
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
            <table width="98%" height="241" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="40" colspan="4" align="center" style="border-bottom: #333333 2px solid;"><span class="font18px">人员详细信息</span></td>
                </tr>

                <tr>
                    <td width="16%" height="25" align="right" style="border-bottom: #333333 1px solid;">公司:</td>
                    <td style="border-bottom: #333333 1px solid;" align="left">&nbsp;<asp:Label ID="StaffBranch" runat="server" Text=""></asp:Label></td>
                    <td align="right" style="border-bottom: #333333 1px solid;">所属部门:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffDepart" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td width="16%" height="25" align="right" style="border-bottom: #333333 1px solid;">员工卡号:</td>
                    <td width="34%" style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffCard" runat="server" Text=""></asp:Label></td>
                    <td width="17%" align="right" style="border-bottom: #333333 1px solid;">员工姓名:</td>
                    <td width="33%" style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>


                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">基本工资:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="Staffwages" runat="server" Text=""></asp:Label></td>
                    <td align="right" style="border-bottom: #333333 1px solid;">性别:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffSex" runat="server" Text=""></asp:Label></td>
                </tr>


                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">联系电话:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffTel" runat="server" Text=""></asp:Label></td>


                    <td align="right" style="border-bottom: #333333 1px solid;">电子邮件:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffEmail" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">身份证号:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffIDCard" runat="server" Text=""></asp:Label></td>
                    <td align="right" style="border-bottom: #333333 1px solid;">入职时间:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffAddTime" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">职位:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="Position" runat="server" Text=""></asp:Label></td>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">上级:</td>
                    <td style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="KRS_DepartPerson" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td height="25" align="right" style="border-bottom: #333333 1px solid;">通信地址:</td>
                    <td colspan="3" style="border-bottom: #333333 1px solid;">&nbsp;<asp:Label ID="StaffAddress" runat="server" Text=""></asp:Label></td>
                </tr>

                <tr>
                    <td height="21" align="right" style="border-bottom: #333333 1px solid;">备注:</td>
                    <td colspan="3" style="border-bottom: #333333 1px solid;">
                        <asp:Label ID="StaffRemarks" runat="server" Text=""></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td height="30" align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td colspan="2" align="left">制表人:
          <asp:Label ID="makeMan" runat="server" Text="" Width="100px" CssClass="Boxx"></asp:Label>&nbsp;&nbsp;&nbsp;制表时间:
        <asp:Label ID="makeTime" runat="server" Text="" Width="100px" CssClass="Boxx"></asp:Label>&nbsp;</td>
                </tr>
            </table>
            <!--endprint-->
        </div>
    </form>
</body>
</html>
