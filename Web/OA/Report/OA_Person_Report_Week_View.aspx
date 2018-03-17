<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="OA_Person_Report_Week_View.aspx.cs"
    Inherits="OA_Person_Report_Week_View" %>

<%@ Register Src="../../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/dom-drag.js"></script>
    <title>周报查看</title>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="OA_Person_Report_List.aspx">周报</a>
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
                    <img src="/../themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%" align="center">&nbsp;
                                                
                                            <asp:LinkButton runat="server" ID="Lbl_Pre" Text="<" OnClick="Lbl_Pre_Click"></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label runat="server" ID="Lbl_DDays"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton runat="server" ID="Lbl_Next" Text=">" OnClick="Lbl_Next_Click"></asp:LinkButton>
                                                  <pc:PTextBox ID="Tbx_STime" runat="server" onFocus="WdatePicker()"
                                                      AllowEmpty="false" Visible="false"></pc:PTextBox>
                                                负责人：<asp:DropDownList runat="server" ID="Ddl_DutyPerson"></asp:DropDownList>
                                                &nbsp;
                                                <asp:Button ID="Button2" runat="server" Text="搜索" AccessKey="S" title="搜索 [Alt+S]"
                                                    class="crmbutton small create" OnClick="Button2_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtTabCache" nowrap>&nbsp;
                                                
                                                <asp:Label runat="server" ID="Lbl_Days"></asp:Label>
                                                <asp:Label runat="server" ID="Lbl_PersonDetails"></asp:Label>
                                            </td>
                                            <td class="dvtTabCache">&nbsp;
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
                                                <b>1.本周计划：(上周计划)</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellInfo"  align="left">
                                                
                                                <table class="ListDetails" id="Table2" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">分项</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                    </tr>
                                                <asp:Label runat="server" ID="Lbl_ThisReport"></asp:Label>
                                                    </table>
                                            </td>
                                        </tr>
                                             <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>2.本周总结</b>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellInfo" align="left">
                                                
                                                <table class="ListDetails" id="Table1" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">分项</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                    </tr>
                                                <asp:Label ID="Tbx_ThisReport" runat="server"></asp:Label>
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>3.下周计划</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellInfo"align="left">
                                                
                                                <table class="ListDetails" id="Table3" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">分项</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                    </tr>
                                                <asp:Label ID="Tbx_NextReport" runat="server"></asp:Label>
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>4.附件</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4">
                                                <uc2:CommentList ID="CommentList2" runat="server" CommentFID="" CommentType="-1" />
                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="4" class="detailedViewHeader">
                                                <b>5.批示和点评</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4">
                                                <uc1:CommentList ID="CommentList1" runat="server" CommentFID="" CommentType="-1" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_NID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>

                <td align="right" valign="top">
                    <img src="/../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
