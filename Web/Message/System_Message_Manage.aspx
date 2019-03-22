<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" CodeFile="System_Message_Manage.aspx.cs" Inherits="System_Message_Manage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
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
            intSeconds = today.getSeconds();
            var temp = window.open("../Common/SelectDeptPerson.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            //if (temp == undefined) {
            //    temp = window.returnValue;
            //}
           
        }
        function SetReturnValueInOpenner_SuppliersPrice(temp) {
            debugger;
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('Tbx_ReceiveID').value = ss[0];
                document.all('Tbx_ReceiveName').value = ss[1];


            }
            else {
                document.all('Tbx_ReceiveID').value = "";
                document.all('Tbx_ReceiveName').value = "";
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
                    短消息发送 > <a class="hdrLink" href="System_Message_List.aspx">短消息发送</a>
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
                                                短消息发送</td>
                                            <td class="dvtTabCache" style="width: 10px">
                                                &nbsp;</td>
                                            <td class="dvtTabCache" style="width: 100%">
                                                &nbsp;</td>
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
                                                           内容：</td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                        
                                                                <asp:TextBox ID="Tbx_Remark" runat="server" Style="display: none;"></asp:TextBox>
                                                                <iframe src='../eWebEditor/ewebeditor.htm?id=Tbx_Remark&style=gray'
                                                                    frameborder='0' scrolling='no' width='620' height='350'></iframe>  
                                                      
                                                      </td>                   </tr>
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="发 送" AccessKey="S" title="发 送 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" style="width: 55px;height: 33px;"  />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
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
