<%@ Page Language="C#" AutoEventWireup="true" CodeFile="State_ProductFile.aspx.cs" Inherits="Web_Upload_State_ProductFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <base target="_self" />
    <title>操作产品附件</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css"/>
    <script type="text/javascript" src="../../themes/js/jquery/jquery.min.js"></script>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="/Web/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script src="../../assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function check1() {
            if (confirm("您确定此操作么")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body marginheight="0" marginwidth="0" leftmargin="0" rightmargin="0" bottommargin="0"
    topmargin="0">
    <form method="post" runat="server">
        <tr id="ProductBom">
            <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
            <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
             <asp:TextBox ID="Type" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
            <asp:TextBox ID="ID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
            <asp:TextBox ID="URL" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
            <td align="left" class="dvtCellInfo" style="text-align: left">
                <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="0"
                    cellspacing="0" class="ListDetails">
                    <tr id="tr3">
                        <td align="center" class="ListHead">序号
                        </td>
                        <td align="center" class="ListHead">操作
                        </td>
                        <td align="center" class="ListHead">料号
                        </td>
                        <td align="center" class="ListHead">产品名称
                        </td>
                        <td align="center" class="ListHead">版本号
                        </td>
                         <td align="center" class="ListHead">现在状态
                        </td>
                    </tr>
                    <%=s_ProductsTable_BomDetail %>
                    <asp:Label runat="server" ID="Lbl_Bom" Visible="false"></asp:Label>


                </table>
            </td>
        </tr>

        <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerPopupTransport">
            <tr>
                <td colspan="2" align="center">
                    <asp:Button
                        ID="save" runat="server" Text="保存" CssClass="crmbutton small save" OnClientClick="return check1();"
                        OnClick="save_Click" Width="55px" Height="33px" />&nbsp;&nbsp;
                <input type="button" name="cancel" value="关闭" class="crmbutton small cancel" onclick="self.close();" style="width: 55px; height: 33px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
