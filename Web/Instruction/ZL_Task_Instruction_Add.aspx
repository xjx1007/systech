<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ZL_Task_Instruction_Add.aspx.cs"
    Inherits="ZL_Task_Instruction_Add" %>

<%@ Register Src="../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>作业指导书添加</title>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Products/SelectProduct.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsName').value = ss[0];
                document.all('Tbx_ProductsBarCode').value = ss[2];
            }
            else {
                document.all('Tbx_ProductsName').value = "";
                document.all('Tbx_ProductsBarCode').value = "";
            }
        }

    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 ><a class="hdrLink" href="PB_Basic_Where_List.aspx">作业指导书添加</a>
                </td>
                <td width="100%" nowrap></td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>作业指导书
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
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
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>

                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">编号：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="200px" ValidType="String"></pc:PTextBox><font
                                                                    color="red">*</font>
                                                        </td>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">名称：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Name" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="200px" ValidType="String"></pc:PTextBox><font
                                                                    color="red">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">产品：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" >
                                                            <pc:PTextBox ID="Tbx_ProductsName" Width="200px"  CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" runat="server" Enabled="false"></pc:PTextBox>
                                                            <pc:PTextBox ID="Tbx_ProductsBarCode" CssClass="Custom_Hidden"  runat="server"></pc:PTextBox>
                                                 <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />

                                                        </td>
                                                        
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">责任人：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left"  >
                                                            <asp:DropDownList runat="server" ID="Ddl_DutyPerson"></asp:DropDownList>
                                                            <font color="red">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">时间：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_STime" Width="200px" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></pc:PTextBox>
                                                        </td>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">审批流程：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" >
                                                            <asp:DropDownList runat="server" ID="Ddl_Flow"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">备注：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <pc:PTextBox runat="server" ID="Tbx_Remarks" TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="280px" Height="50px"></pc:PTextBox>
                                                        </td>
                                                    </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <uc2:CommentList ID="CommentList2" runat="server" CommentFID="" CommentType="-1" />
                                                    </td>
                                                </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="height: 30px; width: 70px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
    <td align="right" valign="top">
        <img src="/themes/softed/images/showPanelTopRight.gif" />
    </td>
        </tr>
        </table>
    </form>
</body>
</html>
