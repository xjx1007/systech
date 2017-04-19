<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false" CodeFile="KnetProductsSpec_Add.aspx.cs"
    Inherits="Knet_Web_System_KnetProductsSpec_Add" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>产品规格说明书</title>

    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            /*选择产品*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectProduct.aspx", "", "dialogtop=150px;dialogleft=160px; dialogwidth=900px;dialogHeight=600px");
            var temp = window.open("SelectProduct.aspx", "选择产品", "width=900px, height=600px,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Product(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('ProductsBarCode').value = ss[2];
                document.all('ProductsEdition').value = ss[0];
                document.all('ProductsPattern').value = ss[1];
                document.all('Tbx_SpecCode').value = ss[3];
            }
            else {
                document.all('ProductsBarCode').value = "";
                document.all('ProductsEdition').value = "";
                document.all('ProductsPattern').value = "";
                document.all('Tbx_SpecCode').value = "";
            }
        }
    </script>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品 > <a class="hdrLink" href="KnetProductsSetting.aspx">
                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label></a>
                </td>
                <td width="100%" nowrap>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="sep1" style="width: 1px;"></td>
                            <td class="small">
                                <!-- Add and Search -->
                            </td>
                        </tr>
                    </table>
                </td>
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
                        <br>
                        <hr noshade size="1">
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>产品字典信息
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
                                            <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                        </tr>

                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">规格书编号:</td>
                                            <td align="left" class="dvtCellInfo" colspan="3">
                                                <asp:TextBox ID="Tbx_SpecCode" runat="server" CssClass="detailedViewTextBox" Width="200px" MaxLength="40"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="规格书编号非空！" ControlToValidate="Tbx_SpecCode" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                        </tr>



                                        <tr>
                                            <td width="17%" align="right" class="dvtCellLabel" style="height: 33px">选择产品:</td>
                                            <td align="left" class="dvtCellInfo" style="height: 33px" colspan="3">
                                                <input type="hidden" name="ProductsBarCode" id="ProductsBarCode" runat="server" style="width: 150px" />
                                                <input type="hidden" name="ProductsPattern" id="ProductsPattern" runat="server" style="width: 150px" />
                                                <asp:TextBox ID="ProductsEdition" runat="server" CssClass="detailedViewTextBox" Width="350px"></asp:TextBox>(<font color="red">*</font>)
                                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联产品" ControlToValidate="ProductsEdition" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr id="AddPic" runat="server">
                                            <td height="25" align="right" class="dvtCellLabel">请选择规格书:</td>
                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                <asp:LinkButton ID="Lbl_Spce" runat="server" OnClick="Lbl_Spce_Click"></asp:LinkButton><input id="uploadFile" type="file" runat="server" class="Boxx" size="30" />&nbsp;<input id="button" type="button" value="上传说明书" runat="server" class="crmButton small save" onserverclick="button_ServerClick" causesvalidation="false" /></td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="right" class="dvtCellLabel">添加员：</td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="ProductsAddMan" runat="server" CssClass="detailedViewTextBox" ReadOnly="true" Width="150px"></asp:TextBox>
                                                <asp:Label ID="ProductsAddMantxt" runat="server" Visible="false"></asp:Label>
                                            </td>
                                            <td align="right" class="dvtCellLabel">添加时间：</td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="ProductsAddTime" runat="server" CssClass="detailedViewTextBox" ReadOnly="true" Width="150px"></asp:TextBox></td>
                                        </tr>


                                        <tr>
                                            <td align="right" class="dvtCellLabel" style="height: 24px">版本更改明细:</td>
                                            <td align="left" class="dvtCellInfo" style="height: 24px" colspan="3">
                                                <asp:TextBox ID="Tbx_Details" runat="server" CssClass="Boxx" TextMode="MultiLine" Width="440px" Height="50px"></asp:TextBox>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:TextBox runat="server" ID="Tbx_SampleID" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="TextBox1" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:Button ID="Button2" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="4" align="center" class="dvtCellLabel">
                                                <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>&nbsp</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
