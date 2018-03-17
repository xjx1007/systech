<%@ Page Language="C#" AutoEventWireup="true" CodeFile="System_PhoneMessage_Detail.aspx.cs" Inherits="System_Message_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title></title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="JAVASCRIPT">

        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            var v_Receive = document.all('Tbx_ReceiveID').value;
            var v_ReceiveName = document.all('Tbx_ReceiveName').value;
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
                for (var i = 0; i < s_Receive.length; i++) {
                    if (v_Receive.indexOf(s_Receive[i]) < 0) {
                        v_Receive = v_Receive + "," + s_Receive[i];
                        v_ReceiveName = v_ReceiveName + "," + s_ReceiveName[i];
                    }
                }
                document.all('Tbx_ReceiveID').value = v_Receive.substring(1, v_Receive.length);
                document.all('Tbx_ReceiveName').value = v_ReceiveName.substring(1, v_ReceiveName.length);

            }
            else {
                document.all('Tbx_ReceiveID').value = "";
                document.all('Tbx_ReceiveName').value = "";
            }
        }
    </script>
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
                短消息管理 > <a class="hdrLink" href="System_Message_Manage.aspx?Type=inbox">短消息查看</a>
            </td>
            <td width="100%" nowrap>
                <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
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
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>
                                                &nbsp;
                                            </td>
                                            <td <%=s_OrderStyle%> align="center" nowrap>
                                                <a href="System_Message_Detail.aspx?Type=0&ID=<%= Request.QueryString["ID"].ToString() %>">
                                                    短消息查看</a>
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">
                                                &nbsp;
                                            </td>
                                            <td <%=s_DetailsStyle%> align="center" nowrap>
                                                <a href="System_Message_Detail.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>">
                                                    短消息回复</a>
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                <tr>
                                    <td >
                                        <asp:Panel ID="Pan_Order" runat="server">
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                <tr>
                                                    <td colspan="2" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                        <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发送人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                    <asp:TextBox runat="server" ID="Tbx_SenderID" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:Label ID="Tbx_SenderName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        标题:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_Title1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        内容:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_Detail" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发送时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_SendTime" runat="server"></asp:Label>
                                                    </td>
                                               
                                                </tr>
                                          
                                            </table>
                                        </asp:Panel>
                                        <asp:Panel ID="Pan_Detail" runat="server">
                                        
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Label1"></asp:Label></span>
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
                                                短消息发送</td>
                                            <td class="dvtTabCache" style="width: 10px">
                                                &nbsp;</td>
                                            <td class="dvtTabCache" style="width: 100%">
                                                &nbsp;</td>
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
                                            <td height="304" align="right" valign="top">
                                                <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                            选择发送人:</td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                        <asp:TextBox runat="server" ID="Tbx_ReceiveID" CssClass="Custom_Hidden"></asp:TextBox>
                                                               <asp:TextBox ID="Tbx_ReceiveName" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="400px" Height="50px"></asp:TextBox> 
                    <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetReturnValue_onclick()" />
                                                        </td>
                                                    </tr>
                                                                          <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                            标题：</td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                           <pc:PTextBox ID="Tbx_Title"  runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String" ></pc:PTextBox><font color="red">*</font>

                                                                          </td>
                                                    </tr>
                                                    
                                                                          <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                           回复内容：</td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">  
                                                           <asp:TextBox ID="Tbx_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" Height="100px"></asp:TextBox>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Tbx_Remark"
                                                                ValidationExpression="^(\s|\S){0,1500}$" ErrorMessage="备注说明太多，限少于1500个字." Display="dynamic"></asp:RegularExpressionValidator>
               
                                                    </tr>
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="发 送" AccessKey="S" title="发 送 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
            </tr>
        </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="left">
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" id="Table_Btn" runat="server">
                                            <tr>
                                                <td>
                                                    <input title="回复 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                        onclick="PageGo('System_Message_Detail.aspx?Type=1&ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;回复&nbsp;">&nbsp;
                                                    <input title="关闭" class="crmbutton small edit" onclick="window.close()" type="button" name="Share"
                                                        value="&nbsp;关闭&nbsp;">&nbsp;
                                                </td>
                                                <td align="right">
                                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                        onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
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
                <img src="../../themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>