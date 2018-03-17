<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false"
    CodeFile="feedback_View.aspx.cs" Inherits="Knet_Web_feedback_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>问题反馈详情</title>
    <script language="JAVASCRIPT">
        function deleteRow(obj) {
            myTableDetails.deleteRow(obj.parentElement.parentElement.rowIndex);
        }
    </script>
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
                    问题反馈 > <a class="hdrLink" href="feedback_List.aspx">问题反馈详情</a>
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
                                                问题反馈信息</td>
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
                                            <td height="304" align="right" valign="top">
                                                <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                            联系人:</td>
                                                        <td class="dvtCellInfo" align="left">
                                                        <asp:Label runat="server" ID="Lbl_Person"></asp:Label></td>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                            问题类型:</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:Label runat="server" ID="Lbl_Type"></asp:Label>
                                                            </td>
                                                       
                                                    </tr>
                                                <asp:TextBox ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <tr><td height="25" align="right" class="dvtCellLabel">
                                                    附件资料:</td>
                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3"> 
                                                    <table  width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr id="tr5">
                                                            <td align="center" class="dvtCellLabel">
                                                                名称</td>
                                                            <td align="center" class="dvtCellLabel" colspan="2">
                                                                资料</td>
                                                        </tr>
                                                         <tr id="tr4">
                                                            <td colspan="4">
                                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label></td>
                                                        </tr>
                                                     
                                                    </table>
                                                </td>
                                            </tr>   
                                                  
                                                        <tr>
                                                            <td height="25" align="right" class="dvtCellLabel">
                                                                问题反馈简介:</td>
                                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Detail"></asp:Label>
                                                                
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
