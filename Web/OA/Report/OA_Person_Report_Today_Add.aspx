<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="OA_Person_Report_Today_Add.aspx.cs"
    Inherits="OA_Person_Report_Add" %>

<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
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
    <title>日报添加</title>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="OA_Person_Report_List.aspx">日报</a>
                </td>
                <td width="100%" nowrap></td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

        <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
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
                                            <td class="dvtSelectedCell" align="center" nowrap>日报
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%" align="center">&nbsp;
                                            <asp:LinkButton runat="server" ID="Lbl_Pre" Text="<" OnClick="Lbl_Pre_Click"></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label runat="server" ID="Lbl_Days"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton runat="server" ID="Lbl_Next" Text=">" OnClick="Lbl_Next_Click"></asp:LinkButton>
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
                                                <b>1.查看计划，撰写今日工作总结</b>

                                                <pc:PTextBox ID="Tbx_STime" runat="server" CssClass="Custom_Hidden" onFocus="WdatePicker()"
                                                    AllowEmpty="false"></pc:PTextBox>
                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson" CssClass="Custom_Hidden"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="6%" height="25" align="right" class="dvtCellLabel">今日计划：
                                            </td>
                                            <td class="dvtCellInfo" width="44%" align="left">
                                                <pc:PTextBox ID="Tbx_NextReport" runat="server" TextMode="MultiLine"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="95%" Height="200px" ValidType="String"></pc:PTextBox>
                                            </td>
                                            <td width="6%" height="25" align="right" class="dvtCellLabel">今日总结：
                                            </td>
                                            <td class="dvtCellInfo" width="44%" align="left">
                                                <pc:PTextBox ID="Tbx_ThisReport" runat="server" TextMode="MultiLine"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="95%" Height="200px" ValidType="String"></pc:PTextBox>
                                            </td>
                                            <%-- <td width="16%" height="25" align="right" class="dvtCellLabel">今日计划：<br>
                                                (昨日计划)
                                            </td>
                                            <td class="dvtCellInfo" width="24%" align="left">
                                                <asp:Label runat="server" ID="Lbl_ThisReport"></asp:Label>
                                            </td>--%>
                                        </tr>
                                        <%-- <tr>
                                            <td colspan="8" class="detailedViewHeader">
                                                <b>2.撰写明日计划</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">明日计划：
                                            </td>
                                            <td class="dvtCellInfo" width="44%" align="left">
                                                <pc:PTextBox ID="Tbx_NextReport" runat="server" TextMode="MultiLine"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="95%" Height="100px" ValidType="String"></pc:PTextBox>
                                            </td>
                                            <td width="16%" height="25" align="right" class="dvtCellInfo"></td>
                                            <td class="dvtCellInfo" width="24%" align="left"></td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="8" class="detailedViewHeader">
                                                <b>3.附件</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="8">
                                                <%-- <uc2:CommentList ID="CommentList2" runat="server" CommentFID="" CommentType="" />--%>
                                                <tr>
                                                    <td colspan="4" align="left">
                                                        <b>相关附件</b>：
                                                    </td>
                                                    <td colspan="4" align="right">
                                                        <%-- OnClientClick="return btnGetFJReturnValue_onclick()"--%>
                                                        <asp:Button runat="server" ID="Btn_Create" Text="新增附件" OnClick="Btn_Create_OnClick" class="crmbutton small create" />
                                                    </td>

                                                </tr>

                                                <div runat="server" id="AddUpload">
                                                    <tr>
                                                        <td colspan="8" class="detailedViewHeader">
                                                            <b>添加附件</b>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">名称:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Name" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">文件:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        </td>
                                                        <td class="dvtCellLabel">说明:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Remarks" runat="server" Text=""></asp:TextBox>

                                                        </td>
                                                        <td class="dvtCellLabel">操作:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Button ID="Button2" runat="server" OnClick="Button2_OnClick" Text="提 交" AccessKey="S" title="保存 [Alt+S]"
                                                                class="crmbutton small save" Style="height: 20px; width: 50px" />
                                                            <asp:Button ID="Button3" runat="server" OnClick="Button3_OnClick" Text="取 消" AccessKey="T" title="取消 [Alt+T]"
                                                                class="crmbutton small save" Style="height: 20px; width: 50px" />

                                                        </td>
                                                    </tr>

                                                </div>

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
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="Custom_Hidden"></asp:TextBox>

                                                    </td>
                                                </tr>

                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="8" align="center" style="height: 30px">
                                                <br />
                                                <asp:Button ID="Btn_Save" runat="server" Text="提 交" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                <asp:Button ID="Button1" runat="server" Text="取 消" AccessKey="T" title="保存 [Alt+T]"
                                                    class="crmbutton small save" Style="height: 30px; width: 70px" OnClick="Button1_Click" />
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
