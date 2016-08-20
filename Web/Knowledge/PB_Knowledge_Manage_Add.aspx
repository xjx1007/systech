gzx<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PB_Knowledge_Manage_Add.aspx.cs"
    Inherits="Pb_Basic_Knowledge_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>

<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetProducts_onclick() {
        /*选择产品*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("../Common/SelectProducts.aspx", "", "dialogtop=150px;dialogleft=160px; dialogwidth=750px;dialogHeight=500px");

        if (temp != undefined) {
            var ss;
            ss = temp.split(",");
            document.all('Tbx_ProductsID').value = ss[2];
            document.all('Tbx_ProductsName').value = ss[0];
        }
        else {
            document.all('Tbx_ProductsID').value = "";
            document.all('Tbx_ProductsName').value = "";
        }
    }

    function btnGetCustomer_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
        if (tempd == undefined) {
            tempd = window.returnValue;
        }
        if (tempd != undefined) {
            var ss;
            ss = tempd.split("#");
            document.all('Tbx_CustomerValue').value = ss[0];
            document.all('Tbx_CustomerName').value = ss[1];

        }
        else {
            document.all('Tbx_CustomerValue').value = "";
            document.all('Tbx_CustomerName').value = "";
        }
    }

    function btnGetType_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("../KnowledgeClass/Pb_Basic_KnowledgeClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

        if (temp != undefined) {
            var ss;
            ss = temp.split(",");
            document.all('Tbx_TypeID').value = ss[0];
            document.all('Tbx_TypeName').value = ss[1];
        }
        else {
            document.all('Tbx_TypeID').value = "";
            document.all('Tbx_TypeName').value = "";
        }
    }
</SCRIPT>
    <title>知识库</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                工作台 > <a class="hdrLink" href="PB_Knowledge_Manage_List.aspx">知识库</a>
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
                                            知识库
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
                                <%--内容块--%>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="304" align="right" valign="top">
                                            <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        产品：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left">
                                                        <asp:TextBox runat="server" ID="Tbx_ProductsID" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <pc:PTextBox ID="Tbx_ProductsName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="300px" ValidType="String"></pc:PTextBox>
                                                        <img  src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProducts_onclick()" />
                                                    </td>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        客户：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left">
                                                        <asp:TextBox runat="server" ID="Tbx_CustomerValue" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <pc:PTextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="300px" ValidType="String"></pc:PTextBox>
                                                        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetCustomer_onclick()" />
                                                    </td>
                                                </tr>     
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        状态：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" >
                                                    <asp:DropDownList runat="server" ID="Ddl_State"></asp:DropDownList>
                                                    </td>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        分类：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" >
                                                        <asp:TextBox runat="server" ID="Tbx_TypeID" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <pc:PTextBox ID="Tbx_TypeName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="300px" ValidType="String"></pc:PTextBox>
                                                        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetType_onclick()" />   </td>
                                                </tr>   
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        问题：
                                                     </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                            <asp:TextBox ID="Tbx_Problem" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="400px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        内容：
                                                     </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                                <asp:TextBox ID="Tbx_Remark" runat="server" Style="display: none;"></asp:TextBox>
                                                                <iframe src='../eWebEditor/ewebeditor.htm?id=Tbx_Remark&style=gray'
                                                                    frameborder='0' scrolling='no' width='620' height='350'></iframe>  
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" style="height: 30px">
                                            <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Btn_Send_Click" style="height: 30px;width: 70px"/>
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="height: 30px;width: 70px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
            </td>
        </tr>
    </table>
    </td>
    <td align="right" valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif" />
    </td>
    </tr> </table>
    </form>
</body>
</html>
