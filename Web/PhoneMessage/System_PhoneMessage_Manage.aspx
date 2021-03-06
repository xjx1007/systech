﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="System_PhoneMessage_Manage.aspx.cs"
    Inherits="System_PhoneMessage_Manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../../themes/js/jquery/jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>短消息发送</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            var v_Receive = document.all('Tbx_ReceiveID').value;
            var v_ReceiveName = document.all('Tbx_ReceiveName').value;
            var v_ReceivePhone = document.all('Tbx_ReceivePhone').value;
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../Common/SelectDeptPerson.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (temp == undefined) {
                temp = window.returnValue;
            }
            if (temp != undefined) {
                var ss, s_Receive;
                ss = temp.split("|");
                s_Receive = ss[0].split(",");
                s_ReceiveName = ss[1].split(",");
                s_ReceivePhone = ss[2].split(",");
                for (var i = 0; i < s_Receive.length; i++) {
                    if (v_Receive.indexOf(s_Receive[i]) < 0) {
                        v_Receive = v_Receive + "," + s_Receive[i];
                        v_ReceiveName = v_ReceiveName + "," + s_ReceiveName[i];
                        v_ReceivePhone = v_ReceivePhone + "," + s_ReceivePhone[i];
                    }
                }
                if (v_Receive.substring(0, 1) == ",") {
                    document.all('Tbx_ReceiveID').value = v_Receive.substring(1, v_Receive.length);
                    document.all('Tbx_ReceivePhone').value = v_ReceivePhone.substring(1, v_ReceivePhone.length);
                    document.all('Tbx_ReceiveName').value = v_ReceiveName.substring(1, v_ReceiveName.length);
                }
                else {
                    document.all('Tbx_ReceiveID').value = v_Receive;
                    document.all('Tbx_ReceiveName').value = v_ReceiveName;
                    document.all('Tbx_ReceivePhone').value = v_ReceivePhone;
                }

            }
            else {
                document.all('Tbx_ReceiveID').value = "";
                document.all('Tbx_ReceiveName').value = "";
                document.all('Tbx_ReceivePhone').value = "";
            }
        }
        function checkFieldNum() {
            var sendmessageinfo = document.getElementById('Tbx_Remark').value;
            var contentlen = fucCheckLength2(sendmessageinfo);
            var zishu = 65 - contentlen;
            var str = "你还能输入:<font color=red><b>" + zishu + "</b></font>个字...";
            $("showzishu").update(str);
        }
        function fucCheckLength2(strTemp) {
            var i, sum;
            sum = 0;
            for (i = 0; i < strTemp.length; i++) {
                if ((strTemp.charCodeAt(i) >= 0) && (strTemp.charCodeAt(i) <= 255))
                    sum = sum + 1;
                else
                    sum = sum + 1;
            }
            return sum;
        }

        function btnGetContentPerson_onclick() {
            var s_Customer = "";
            var temaap = window.showModalDialog("../Common/SelectContentPerson.aspx?ID=" , "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (temaap != undefined) {
                var sws;
                sws = temaap.split(",");
                if (document.all('Tbx_ReceivePhone').value != "") {
                    document.all('Tbx_ReceiveName').value += "," ;
                    document.all('Tbx_ReceivePhone').value += "," ;
                }
                document.all('Tbx_ReceiveName').value += sws[0];
                document.all('Tbx_ReceivePhone').value +=  sws[1];
                
            }
        }
    </script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
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
                短消息发送 > <a class="hdrLink" href="System_PhoneMessage_List.aspx">短消息发送</a>
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
                                            短消息发送
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">
                                            &nbsp;
                                        </td>
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
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="304" align="right" valign="top">
                                            <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        联系人:
                                                    </td>
                                                    <td class="dvtCellInfo" width="30%" align="left">
                                                        <asp:TextBox runat="server" ID="Tbx_ReceiveID" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:TextBox ID="Tbx_ReceiveName" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="400px" Height="50px"></asp:TextBox>
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="2">
                                                        <input type="button" style="width: 120px" class="crmbutton small edit" onclick="return btnGetReturnValue_onclick()"
                                                            name="selectcontacts" id="selectcontacts" value="选择联系人" /><br />
                                                        <input type="button" style="width: 120px" class="crmbutton small edit" onclick="return btnGetContentPerson_onclick()"
                                                            name="selectusers" id="selectusers" value="选择客户联系人" /><br />
                                                        <input type="button" style="width: 120px" class="crmbutton small edit" onclick="openDialogs(3);"
                                                            name="selectvcontacts" id="selectvcontacts" value="选择供应商联系人" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        手机号码:
                                                    </td>
                                                    <td class="dvtCellInfo" width="30%" align="left" colspan="3">
                                                        <asp:TextBox ID="Tbx_ReceivePhone" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="400px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        内容：
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <asp:TextBox ID="Tbx_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="400px" Height="50px" onKeyUp="checkFieldNum();"></asp:TextBox>
                                                        <div id="showzishu" class="small">
                                                            你还能输入:<font color="red"><b>65</b></font>个字...</div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" style="height: 30px">
                                            <asp:Button ID="Btn_Save" runat="server" Text="发 送" AccessKey="S" title="发 送 [Alt+S]"
                                                class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 120px" />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="height: 30px; width: 120px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_ToID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
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
