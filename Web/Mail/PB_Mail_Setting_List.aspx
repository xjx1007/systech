<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PB_Mail_Setting_List.aspx.cs" Inherits="PB_Mail_Setting_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <title>发件人列表</title>
</head>
<body>
    <form id="form1" runat="server">


        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <%=base.Base_BindView("PB_Basic_Menu", "PB_Basic_Menu_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="Search_basic" style="display: none" runat="server">
                        <table width="80%" cellpadding="5" cellspacing="0" class="searchUIBasic small" align="center"
                            border="0">
                            <tr>
                                <td class="searchUIName small" nowrap align="left">
                                    <span class="moduleName">查找</span><br>
                                    <span class="small"><a href="#" onclick="ShowDiv();fnshow();">高级查找</a></span>
                                </td>
                                <td class="small" nowrap align="right">
                                    <b>查找</b>
                                </td>
                                <td class="small" nowrap>
                                    <div id="basicsearchcolumns_real">
                                        <asp:DropDownList runat="server" ID="bas_searchfield" class="txtBox">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td class="small">
                                    <asp:TextBox ID="search_text" class="txtBox" runat="server"></asp:TextBox>
                                </td>
                                <td class="small" nowrap width="40%">
                                    <asp:Button ID="btnBasicSearch" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small create" OnClick="btnBasicSearch_Click" />&nbsp;
                                <input name="Btn_submit" type="button" class="crmbutton small edit" onclick="ShowDiv()"
                                    value=" 取消查找 ">&nbsp;
                                </td>
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="ShowDiv()">[x]
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="advSearch" style="display: none;" runat="server">
                        <table cellspacing="0" cellpadding="5" width="80%" class="searchUIAdv1 small" align="center"
                            border="0">
                            <tr>
                                <td class="searchUIName small" nowrap align="left">
                                    <span class="moduleName">查找</span><br>
                                    <span class="small"><a href="#" onclick="ShowDiv();fnshow();">基本查找</a></span>
                                </td>
                                <td nowrap class="small">
                                    <b>
                                        <input name="matchtype" id="matchtype1" type="radio" runat="server" value="all">&nbsp;匹配以下所有条件</b>
                                </td>
                                <td nowrap width="60%" class="small">
                                    <b>
                                        <input name="matchtype" id="matchtype2" type="radio" value="any" runat="server" checked>&nbsp;匹配以下任意条件</b>
                                </td>
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="fnshow()">[x]
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="2" cellspacing="0" width="80%" align="center" class="searchUIAdv2 small"
                            border="0">
                            <tr>
                                <td align="center" class="small" width="90%">
                                    <div id="fixed" style="position: relative; width: 95%; height: 80px; padding: 0px; overflow: auto; border: 1px solid #CCCCCC; background-color: #ffffff"
                                        class="small">
                                        <table border="0" width="95%">
                                            <tr>
                                                <td align="left">
                                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" id="adSrc" align="left">
                                                        <tr>
                                                            <td width="31%">
                                                                <asp:DropDownList runat="server" ID="Fields" class="txtBox">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="32%">
                                                                <asp:DropDownList ID="Condition" runat="server" class="txtBox">
                                                                    <asp:ListItem Value="cts">包含</asp:ListItem>
                                                                    <asp:ListItem Value="dcts">不包含</asp:ListItem>
                                                                    <asp:ListItem Value="is">等于</asp:ListItem>
                                                                    <asp:ListItem Value="isn">不等于</asp:ListItem>
                                                                    <asp:ListItem Value="grt">大于</asp:ListItem>
                                                                    <asp:ListItem Value="lst">小于</asp:ListItem>
                                                                    <asp:ListItem Value="grteq">大于等于</asp:ListItem>
                                                                    <asp:ListItem Value="lsteq">小于等于</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="32%">
                                                                <asp:TextBox ID="Srch_value" runat="server" class="detailedViewTextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <%=s_AdvShow %>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <hr width="720">
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellspacing="0" cellpadding="5" width="80%" class="searchUIAdv3 small"
                            align="center">
                            <tr>
                                <td align="left" width="40%">
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Knet_Procure_OrdersList")%>','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
                                        class="crmbuttom small edit">
                                    <input name="button" type="button" value=" 删除条件 " onclick="delRow()" class="crmbuttom small edit">
                                </td>
                                <td align="left" class="small">
                                    <asp:Button ID="btnAdvancedSearch" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small create" OnClick="btnAdvancedSearch_Click" />&nbsp;
                                <input type="button" class="crmbutton small edit" value=" 取消查找 " onclick="fnshow();">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td>
                                <!--GridView-->
                                <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                    BorderColor="#4974C2"
                                    EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SMTP服务器" SortExpression="PMS_Sever" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "PMS_Sever")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SMTP端口" SortExpression="PMS_Port" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "PMS_Port").ToString() %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="EMail" DataField="PMS_EMail" SortExpression="PMS_EMail" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="发送人" DataField="PMS_SendPerson" SortExpression="PMS_SendPerson" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="发送邮件" DataField="PMS_SendEmail" SortExpression="PMS_SendEmail"
                                            HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="发送间隔" DataField="PMS_Seconds" SortExpression="PMS_Seconds"
                                            HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="操作" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <a href="PB_Mail_Setting_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PMS_ID") %>">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../../themes/softed/images/RolesEdit.gif" border="0" /></a>

                                                <a href="PB_Mail_Setting_List.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PMS_ID") %>">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="../../themes/softed/images/RolesDelete.gif" border="0" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass='colHeader' />
                                    <RowStyle CssClass='listTableRow' />
                                    <AlternatingRowStyle BackColor="#E3EAF2" />
                                    <PagerStyle CssClass='Custom_DgPage' />
                                </cc1:MyGridView>
                            </td>
                        </tr>
                    </table>
                    <input title="新增发件人 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                        onclick="PageGo('PB_Mail_Setting_Add.aspx')"
                        name="Edit" value="&nbsp;新增发件人&nbsp;" style="width: 90px; height: 30px">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
