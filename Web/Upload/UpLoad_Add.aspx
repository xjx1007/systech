<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoad_Add.aspx.cs" Inherits="UpLoad_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <base target="_self" />
    <title>添加附件</title>
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
                添加附件
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
                        <td width="30%"  class="dvtCellLabel" align="right">
                           名称：
                        </td>
                        <td width="70%" align="left" class="dvtCellInfo">      
                                        <pc:PTextBox runat="server" ID="Tbx_Name"    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox> 
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择需要日期"
                                                        ControlToValidate="Tbx_Name" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%"  class="dvtCellLabel" align="right">
                            文件：
                        </td>
                        <td width="70%" align="left" class="dvtCellInfo">      
                                        <input id="uploadFile" type="file" runat="server" class="Boxx" size="30" />  
                        </td>
                    </tr>
                    <tr>
                        <td width="30%"  class="dvtCellLabel" align="right">
                            描述：
                        </td>
                        <td align="left" class="dvtCellInfo">
                            <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="txtBox" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
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
                    ID="save" runat="server" Text="上传" cssClass="crmbutton small save" 
                    onclick="save_Click" Width="55px" Height="33px"/>&nbsp;&nbsp;
                <input type="button" name="cancel" value="关闭" class="crmbutton small cancel" onclick="self.close();" style="Width:55px;Height:33px" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
