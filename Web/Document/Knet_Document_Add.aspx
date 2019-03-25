<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false"  EnableEventValidation="false"  CodeFile="Knet_Document_Add.aspx.cs"
 Inherits="Knet_Web_System_Knet_Document_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    
<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetReturnValue_onclick() {
        /*选择产品*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("SelectDocument.aspx", "", "dialogtop=150px;dialogleft=160px; dialogwidth=750px;dialogHeight=500px");

        if (temp != undefined) {
            var ss;
            ss = temp.split("#");
            document.all('tbx_FaterId').value = ss[0];
            document.all('Tbx_FaterName').value = ss[1];
        }
        else {
            document.all('tbx_FaterId').value = "";
            document.all('Tbx_FaterName').value = "";
        }
    }
    function Chang() {
        var s_Name = document.all('Tbx_Name').value;
        var response = Knet_Web_System_Knet_Document_Add.GetCode(s_Name);
        document.all('Tbx_Visio').value = response.value;

    }
</SCRIPT>
    <title>文档中心添加</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    文档中心 > <a class="hdrLink" href="Knet_Document_List.aspx">文档中心</a>
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
                                                &nbsp;</td>
                                            <td class="dvtSelectedCell" align="center" nowrap>
                                                文档中心信息</td>
                                            <td class="dvtTabCache" style="width: 10px">
                                                &nbsp;</td>
                                            <td class="dvtTabCache" style="width: 100%">
                                                &nbsp;</td>
                                            <tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b></td>
                                        </tr>
                                        
<tr>

        <td width="16%" height="25" align="right" class="dvtCellLabel">文档编号:</td>
        <td width="35%" align="left" class="dvtCellInfo" ><asp:TextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px"  MaxLength="40"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="文档编号非空！" ControlToValidate="Tbx_Code" Display="Dynamic" ></asp:RequiredFieldValidator></td>
             
        <td width="16%" height="25" align="right" class="dvtCellLabel">文档名称:</td>
              <td align="left" class="dvtCellInfo" style="width: 498px" ><asp:TextBox ID="Tbx_Name" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';Chang()" Width="200px"  MaxLength="40" ></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator2" runat="server" ErrorMessage="文档名称非空！" ControlToValidate="Tbx_Name" Display="Dynamic" ></asp:RequiredFieldValidator></td>
        </tr>
     <tr id="Tr1"  runat="server" >
        <td height="25" align="right" class="dvtCellLabel">文档类型:</td>
        <td align="left" class="dvtCellInfo"><asp:DropDownList runat="Server" ID="Ddl_Type"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Ddl_Type"
            Display="Dynamic" ErrorMessage="文档类型非空"></asp:RequiredFieldValidator></td>
        <td height="25" align="right" class="dvtCellLabel">负责人:</td>
        <td align="left" class="dvtCellInfo"><asp:DropDownList runat="Server" ID="Ddl_DutyPerson"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Ddl_DutyPerson"
            Display="Dynamic" ErrorMessage="负责人"></asp:RequiredFieldValidator></td>
    </tr>
    
     <tr id="Tr3"  runat="server" >
        <td height="25" align="right" class="dvtCellLabel">版本号:</td>
        <td align="left" class="dvtCellInfo"><asp:TextBox ID="Tbx_Visio" runat="server" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px" ></asp:TextBox></td>

        <td height="25" align="right" class="dvtCellLabel">上级文档:</td>
        <td align="left" class="dvtCellInfo">
            <asp:TextBox ID="tbx_FaterId" runat="server" CssClass="Custom_Hidden" Width="200px" ></asp:TextBox>
            <asp:TextBox ID="Tbx_FaterName" runat="server" Enabled="false" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px" ></asp:TextBox>
            <Input  Type="Button" id=" btnGetReturnValue" class="Btt" onclick="return btnGetReturnValue_onclick()" value="选择文档">
        </td>

    </tr>
     <tr id="AddPic" runat="server" >
        <td height="25" align="right" class="dvtCellLabel">文档路径:</td>
        <td align="left" class="dvtCellInfo" colspan="3">
        <asp:LinkButton ID="Lbl_Spce" runat="server" OnClick="Lbl_Spce_Click" ></asp:LinkButton><input id="uploadFile" type="file" runat="server" class="Boxx" size="30" />&nbsp;
        <input id="button" type="button" value="上传文档"  runat="server" class="Btt" onserverclick="button_ServerClick"  causesvalidation="false" /></td>
    </tr>
      <tr>
        <td align="right" class="dvtCellLabel" style="height: 24px">文档内容:</td>
        <td align="left" class="dvtCellInfo" style="height: 24px" colspan="3">
     
        <asp:TextBox ID="Tbx_Details" runat="server" style="display:none;"></asp:TextBox>
        <IFRAME src='../eWebEditor/ewebeditor.htm?id=Tbx_Details&style=coolblue' frameborder='0' scrolling='no' width='98%' height='350'></IFRAME>
        
        </td>
         </tr>
                                                    <tr>
                                                        <td colspan="4" align="center" style="height: 30px">
                                                            <asp:Button ID="Button3" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                                class="crmbutton small save" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                                type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <%--内容块结束--%>
                                </td>
                            </tr>
                        </table>
                </td>
                <td align="right" valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif" />
                    </td>
            </tr>
        </table>
    </form>
</body>
</html>
