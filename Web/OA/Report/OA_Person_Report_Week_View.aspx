<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="OA_Person_Report_Week_View.aspx.cs"
    Inherits="OA_Person_Report_Week_View" %>

<%@ Register Src="../../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register Src="~/Web/OA/Report/UC_ddlCategroy.ascx" TagPrefix="uc1" TagName="UC_ddlCategroy" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <title>周报查看</title>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
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
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif">
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
                                                负责人：<%--<asp:DropDownList runat="server" ID="Ddl_DutyPerson"></asp:DropDownList>--%><uc1:UC_ddlCategroy runat="server" id="UC_ddlCategroy" />
                                                &nbsp;
                                                <asp:Button ID="Button2" runat="server" Text="搜索" AccessKey="S" title="搜索 [Alt+S]"
                                                    class="crmbutton small create" OnClick="Button2_Click" />
                                            </td>
                                        </tr>


                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td class="dvtTabCache" nowrap>&nbsp;
                                                
                                                <asp:Label runat="server" ID="Lbl_Days"></asp:Label>
                                                <asp:Label runat="server" ID="Lbl_PersonDetails"></asp:Label>
                                            </td>
                                            <td class="dvtTabCache">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" class="detailedViewHeader">
                                                <b>1.本周计划：(上周计划)</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellInfo" colspan="8" align="left">

                                                <table class="ListDetails" id="Table2" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">项目详情</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_ThisReport"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" class="detailedViewHeader">
                                                <b>2.本周总结</b>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellInfo" colspan="8" align="left">

                                                <table class="ListDetails" id="Table1" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">项目详情</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                    </tr>
                                                    <asp:Label ID="Tbx_ThisReport" runat="server"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8" class="detailedViewHeader">
                                                <b>3.下周计划</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellInfo" colspan="8" align="left">

                                                <table class="ListDetails" id="Table3" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">项目详情</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                    </tr>
                                                    <asp:Label ID="Tbx_NextReport" runat="server"></asp:Label>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="8" class="detailedViewHeader">
                                                <b>4.附件</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="8" class="dvtCellInfo">
                                                <cc1:MyGridView ID="GridView_Comment" runat="server" AllowPaging="True" AllowSorting="True"
                                                    IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                    PageSize="10" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="名称" DataField="PBA_Name" SortExpression="PBA_Name"
                                                            HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="附件" SortExpression="PBA_URL" HeaderStyle-Font-Size="12px"
                                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <a target="_blank" href="<%#DataBinder.Eval(Container.DataItem, "PBA_URL").ToString()%>"><%# DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%></a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="描述" DataField="PBA_Remarks" SortExpression="PBA_Remarks"
                                                            HtmlEncode="false">
                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="200px" />
                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="创建人" SortExpression="PBA_Creator" HeaderStyle-Font-Size="12px"
                                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <%# GetUserName(DataBinder.Eval(Container.DataItem, "PBA_Creator").ToString())%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="上传时间" DataField="PBA_Ctime" SortExpression="PBA_Ctime"
                                                            HtmlEncode="false">
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
                                        <tr>

                                            <td colspan="8" class="detailedViewHeader">
                                                <b>5.批示和点评</b>
                                            </td>
                                        </tr>

                                        <%-- <tr>
                                            <td colspan="8">
                                                <uc1:CommentList ID="CommentList1" runat="server" CommentFID="0" CommentType="-1" />
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="8">

                                                <tr>
                                                    <td colspan="4" align="left">
                                                        <b>新增批示点评</b>：
                                                    </td>
                                                    <td colspan="4" align="right">
                                                        <%-- OnClientClick="return btnGetFJReturnValue_onclick()"--%>
                                                        <asp:Button runat="server" ID="Btn_Create" Text="新增点评" OnClick="Btn_Create_OnClick" class="crmbutton small create" />
                                                    </td>

                                                </tr>

                                                <div runat="server" id="AddComment">
                                                    <tr>
                                                        <td colspan="8" class="detailedViewHeader">
                                                            <b>添加附件</b>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">标题:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="DdlPBC_Preset" name="DdlPBC_Preset" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlPBC_Preset_OnSelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                        <td class="dvtCellLabel">点评内容:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">操作:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_OnClick" Text="提 交" AccessKey="S" title="保存 [Alt+S]"
                                                                class="crmbutton small save" Style="height: 20px; width: 50px" />
                                                            <asp:Button ID="Button3" runat="server" OnClick="Button3_OnClick" Text="取 消" AccessKey="T" title="取消 [Alt+T]"
                                                                class="crmbutton small save" Style="height: 20px; width: 50px" />

                                                        </td>
                                                    </tr>

                                                </div>

                                                <tr>
                                                    <td colspan="8" class="dvtCellInfo">
                                                        <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                            IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                            PageSize="10" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="点评内容" DataField="PBC_Description" SortExpression="PBC_Description"
                                                                    HtmlEncode="false">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="点评时间" DataField="PBC_CTime" SortExpression="PBC_CTime"
                                                                    HtmlEncode="false">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="点评人" SortExpression="PBC_FromPerson" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# GetUserName(DataBinder.Eval(Container.DataItem, "PBC_FromPerson").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass='colHeader' />
                                                            <RowStyle CssClass='listTableRow' />
                                                            <AlternatingRowStyle BackColor="#E3EAF2" />
                                                            <PagerStyle CssClass='Custom_DgPage' />
                                                        </cc1:MyGridView>
                                                        <asp:HiddenField ID="hidCommentFID" runat="server" />
                                                        <asp:HiddenField ID="hidCommentType" runat="server" />
                                                    </td>
                                                </tr>

                                            </td>

                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_NID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    </div>

                </td>

                <td align="right" valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
