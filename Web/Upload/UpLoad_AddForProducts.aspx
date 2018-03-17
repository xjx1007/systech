<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoad_AddForProducts.aspx.cs" Inherits="UpLoad_AddForProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <base target="_self" />
    <title>添加产品附件</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8">
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../themes/js/jquery/jquery.min.js"></script>
    <script type="text/javascript">
        function Change()
        {
            var v_TypeName = document.getElementById("Ddl_Type").value;
            if ((v_TypeName == 6)||(v_TypeName == 2))
            {
                document.getElementById("Tr_Version").style.visibility = "visible";
                document.getElementById("Tr_Version").style.display = "";
            }
            else
            {
                document.getElementById("Tr_Version").style.visibility = "hidden";
                document.getElementById("Tr_Version").style.display = "none";
            }
        }
    </script>
</head>
<body marginheight="0" marginwidth="0" leftmargin="0" rightmargin="0" bottommargin="0"
    topmargin="0">
    <form method="post" runat="server">
        <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerHeadingULine">
            <tr>
                <td class="layerPopupHeading" align="left">添加产品附件
                </td>
                <td width="70%" align="right">&nbsp;
                </td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="5" width="95%" align="center">
            <tr>
                <td class="small">
                    <table border="0" celspacing="0" cellpadding="5" width="100%" align="center" bgcolor="white"
                        class="small">
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">文件：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <input id="uploadFile" type="file" runat="server" class="Boxx" size="30" onchange="FileUpload_onselect(this)" accept=".xls;.xlsx;.csv;.doc;.docx;.pdf;.txt;.zip;.rar" />
                                <div style="margin-top: 6px; color: #999;">仅支持以下文件类型：xls、xlsx、csv、doc、docx、pdf、txt、zip、rar</div>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">名称：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <pc:PTextBox runat="server" ID="Tbx_Name" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" Width="250px"></pc:PTextBox>
                                (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择需要日期"
                                                        ControlToValidate="Tbx_Name" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">类别：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <asp:DropDownList runat="server" ID="Ddl_Type" onchange="Change()"></asp:DropDownList>
                                (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择类别"
                                                        ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="Tr_Version" style="visibility: hidden;display:none">
                            <td width="30%" class="dvtCellLabel" align="right">版本号：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_Version" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">更新文件名：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_UpdateID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="Tbx_UpdateName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" Width="250px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">描述：
                            </td>
                            <td align="left" class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'"  TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
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
                        ID="save" runat="server" Text="上传" CssClass="crmbutton small save"
                        OnClick="save_Click" Width="55px" Height="33px" />&nbsp;&nbsp;
                <input type="button" name="cancel" value="关闭" class="crmbutton small cancel" onclick="self.close();" style="Width: 55px; Height: 33px" />
                </td>
            </tr>
        </table>
    </form>
    <script>
        var fileTypes = [".xls", ".xlsx", ".csv", ".doc", ".docx", ".pdf", ".txt", ".zip", ".rar"];
        function FileUpload_onselect(objFileUpload) {
            var path;
            path = objFileUpload.value;
            var name;
            name = path.split('\\');
            var filetype = name[name.length - 1].split(".")[1].toLowerCase();
            if (fileTypes.toString().indexOf(filetype) > -1) {
                var bb = name[name.length - 1];
                document.getElementById('Tbx_Name').value = bb.substr(0, bb.indexOf('.'));  //AddFile 结果
            } else {
                objFileUpload.value = "";
                alert("不支持的文件类型，请重新上传！");
            }
        }
    </script>
</body>
</html>
