<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Products_Enclosure_View.aspx.cs"
    Inherits="PB_Basic_Attachment_View" %>

<%@ Register Src="../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title>查看产品附件</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="PB_Basic_Attachment_List.aspx">查看产品附件</a>
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>产品附件信息
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtUnSelectedCell" align="center" nowrap>
                                                <a href="#">相关信息</a>
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
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
                                                        <td>&nbsp;<asp:Button ID="Btn_Sp" runat="server" class="crmbutton small save" Visible="false" Text="审批通过" OnClick="Btn_SpSave" Style="height: 26px; width: 60px" />
                                                            &nbsp;<asp:Button ID="Btn_Sp1" runat="server" class="crmbutton small cancel" Visible="false" Text="反审批" OnClick="Btn_SpSave1" Style="height: 26px; width: 60px" />
                                                            <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>

                                                        </td>
                                                        <td align="right"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                                rowspan="2">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="genHeaderSmall">操作
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
                                                        <td align="right" valign="top">
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>

                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">附件名称：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Tbx_Name" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">分类：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Tbx_TypeName" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">产品：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Lbl_Products" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">附件类型：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label runat="server" ID="Lbl_FileType"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">时间：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Tbx_STime" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">创建人：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label runat="server" ID="Tbx_Person"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">备注：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                                        <asp:Label runat="server" ID="Lbl_Update"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">更新文件：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                                        <asp:Label runat="server" ID="Tbx_Remarks"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="detailedViewHeader">
                                                                        <b>下载记录</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">

                                                                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                                                                            <Columns>



                                                                                <asp:BoundField DataField="PBAD_Time" HeaderText="下载日期" SortExpression="PBAD_Time">
                                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                </asp:BoundField>
                                                                                
                                                                                <asp:TemplateField HeaderText="下载人" SortExpression="PBAD_Creator" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                                    <ItemTemplate>
                                                                                        <%#base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "PBAD_Creator").ToString())%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="PBAD_IP" HeaderText="下载IP" SortExpression="PBAD_IP">
                                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                </asp:BoundField>
                                                                                
                                                                            </Columns>
                                                                            <HeaderStyle CssClass='colHeader' />
                                                                            <RowStyle CssClass='listTableRow' />
                                                                            <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                            <PagerStyle CssClass='Custom_DgPage' />
                                                                        </cc1:MyGridView>
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
    </form>
</body>
</html>
