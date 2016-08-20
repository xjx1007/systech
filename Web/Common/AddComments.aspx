<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddComments.aspx.cs" Inherits="Web_Common_AddComments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <base target="_self" />
    <title>添加评论</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8">
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../themes/js/jquery/jquery.min.js"></script>
</head>
<body marginheight="0" marginwidth="0" leftmargin="0" rightmargin="0" bottommargin="0"
    topmargin="0">
    <form method="post" runat="server">
    <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerHeadingULine">
        <tr>
            <td class="layerPopupHeading" align="left">
                添加评论
            </td>
            <td width="70%" align="right">
                &nbsp;
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="5" width="95%" align="center">
        <tr>
            <td class="small">
                <table border="0" celspacing="0" cellpadding="5" width="100%" align="center" bgcolor="white"
                    class="small">
                    <tr>
                        <td width="30%" rowspan="2" class="dvtCellLabel" align="right">
                            评论内容
                        </td>
                        <td width="70%" align="left" class="dvtCellInfo">                            
                            <asp:DropDownList ID="DdlPBC_Preset" name="DdlPBC_Preset" runat="server" onchange="addContent();">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="dvtCellInfo">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerPopupTransport">
        <tr>
            <td colspan="2" align="center">
                <asp:Button
                    ID="save" runat="server" Text="确定" cssClass="crmbutton small save" 
                    onclick="save_Click"/>&nbsp;&nbsp;
                <input type="button" name="cancel" value="关闭" class="crmbutton small cancel" onclick="self.close();" />
            </td>
        </tr>
    </table>
    </form>
    <script>
        function addContent() {
            var contentval = $("#DdlPBC_Preset").find("option:selected").text();
            if ($("#DdlPBC_Preset").val() != '-1') {
                $('#txtDescription').val(contentval);
            } else {
                $('#txtDescription').val("");
            }

        }
    </script>
</body>
</html>
