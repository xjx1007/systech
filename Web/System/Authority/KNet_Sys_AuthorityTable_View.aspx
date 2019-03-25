<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sys_AuthorityTable_View.aspx.cs"
    Inherits="KNet_Sys_AuthorityTable_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ register assembly="Container" namespace="HT.Control.WebControl" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <title></title>
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
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
                工作台 > <a class="hdrLink" href="KNet_Sys_AuthorityTable_List.aspx">查看公告</a>
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
                <div class="small" style="padding: 10px">
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
                                            公告信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtUnSelectedCell" align="center" nowrap>
                                            <a href="#">相关信息</a>
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
                                        <td valign="top" align="left">
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                            onclick="PageGo('KNet_Sys_AuthorityTable_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                            name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                            value="&nbsp;共享&nbsp;">&nbsp;
                                                        <input title="" class="crmbutton small edit" onclick="PageGo('KNet_Sys_AuthorityTable_List.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                            onclick="PageGo('KNet_Sys_AuthorityTable_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
                                                            name="Duplicate" value="复制">&nbsp;
                                                        <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                            onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                            rowspan="2">
                                            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="genHeaderSmall">
                                                        操作
                                                    </td>
                                                </tr>
                                                <!-- Module based actions starts -->
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
                                                    <td height="304" align="right" valign="top">
                                                        <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    公告标题：
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label ID="Tbx_Title" runat="server" CssClass="detailedViewLabel" OnFocus="this.className='detailedViewLabelOn'"
                                                                        OnBlur="this.className='detailedViewLabel'"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    公告类型：
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label runat="server" ID="Ddl_Type"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" align="right" class="dvtCellLabel">
                                                                    日期:
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label ID="StartDate" runat="server"></asp:Label>&nbsp;到<asp:Label ID="EndDate"
                                                                        runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    接收人:
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label runat="server" ID="Tbx_ReceiveID" CssClass="Custom_Hidden"></asp:Label>
                                                                    <asp:Label ID="Tbx_ReceiveName" TextMode="MultiLine" runat="server" CssClass="detailedViewLabel"
                                                                        OnFocus="this.className='detailedViewLabelOn'" OnBlur="this.className='detailedViewLabel'"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    内容：
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label ID="Tbx_Remark" runat="server"></asp:Label>
                                                                    <asp:Label ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                                    <asp:Label ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:Label>
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
                        </tr>
                    </table>
                </div>
            </td>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopRight.gif">
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
