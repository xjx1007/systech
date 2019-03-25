<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Content_Add.aspx.cs"
    Inherits="Web_Sales_Xs_Sales_Content_Add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>联系记录</title>
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
</head>
<script language="JAVASCRIPT">

    function btnGetReturnValue_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        if (tempd == undefined) {
            tempd = window.returnValue;
        }
        var sel = document.getElementById("Ddl_LinkMan");
        var length = sel.length;
        for (var i = length - 1; i >= 0; i--) {
            sel.remove(i);
        }
        var opt = new Option("", "");
        sel.options.add(opt);
        if (tempd != undefined) {
            var ss;
            ss = tempd.split("#");
            document.all('Tbx_CustomerValue').value = ss[0];
            document.all('Tbx_CustomerName').value = ss[1];
            var st, sw;
            st = ss[3].split("|");
            if (st.length > 0) {
                for (var i = 0; i < st.length - 1; i++) {
                    sw = st[i].split(",");
                    var opt = new Option(sw[1], sw[0]);
                    sel.options.add(opt);
                }

            }

        }
        else {
            document.all('Tbx_CustomerValue').value = "";
            document.all('Tbx_CustomerName').value = "";
            var length = sel.length;
            for (var i = length - 1; i >= 0; i--) {
                sel.remove(i);
            }
        }
    }

    function btnGetReturnValue_onclick1() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("SelectSalesOpp.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        if (tempd == undefined) {
            tempd = window.returnValue;
        }

        if (tempd != undefined) {
            var ss;
            ss = tempd.split("#");
            document.all('Tbx_SalesChanceValue').value = ss[0];
            document.all('Tbx_SalesChanceName').value = ss[1];


        }
        else {
            document.all('Tbx_SalesChanceValue').value = "";
            document.all('Tbx_SalesChanceName').value = "";
        }
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                联系记录 > <a class="hdrLink" href="Xs_Sales_Content_List.aspx">联系记录</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
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
                <img src="/themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td class="showPanelBg" valign="top" width="100%">
                <div class="small" style="padding: 10px">
                </div>
                <span class="lvtHeaderText">
                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                <br>
                <hr noshade size="1">
                
                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr valign="bottom">
                        <td style="height: 44px">
                            <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                <tr>
                                    <td class="dvtTabCache" style="width: 10px" nowrap>
                                        &nbsp;
                                    </td>
                                    <td class="dvtSelectedCell" align="center" nowrap>
                                        联系记录信息
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
                            <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>基本信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="17%" class="dvtCellLabel">
                                                    供应商:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                        style="width: 150px" />
                                                    <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                                    <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                        onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                </td>
                                                <td class="dvtCellLabel">
                                                    联系人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_LinkMan" CssClass="detailedViewTextBox" runat="server"
                                                        Width="100px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    主题:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Topic" AllowEmpty="false" ValidError="关怀主题不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    联系类型:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_Types" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    联系日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    负责人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server"
                                                        Width="100px">
                                                    </asp:DropDownList>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人"
                                                        ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    内容:
                                                </td>
                                                <td class="dvtCellInfo" colspan="4">
                                                    <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Height="100px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center">
                                                    &nbsp;
                                                    <br />
                                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                        class="crmbutton small save" OnClick="Btn_SaveOnClick" style="width: 55px;height: 33px;"/>
                                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                        type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <img src="/themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
