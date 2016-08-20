<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zl_Produce_Problem_List.aspx.cs" Inherits="Zl_Produce_Problem_List" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
<script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/js/ListView.js"></script>
    <title>生产问题列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                工作台 > <a class="hdrLink" href="Zl_Produce_Problem_List.aspx"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></a>
            </td>
            <td width="100%" nowrap>
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="sep1" style="width: 1px;">
                        </td>
                        <td class="small">
                            <!-- Add and Search -->
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="5">
                                            <tr>
                                                <td style="padding-right: 0px; padding-left: 10px;">
                                                    <a href="javascript:;" onclick="PageGo('Zl_Produce_Problem_Add.aspx')">
                                                        <img src="../../../themes/softed/images/btnL3Add.gif" alt="创建 生产问题..." title="创建 生产问题..."
                                                            border="0"></a>
                                                </td>
                                                <td style="padding-right: 0px;">
                                                    <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../../themes/softed/images/btnL3Delete.gif"
                                                        OnClick="Btn_Del_Click" />
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <a href="javascript:;" onclick="ShowDiv();">
                                                        <img src="../../../themes/softed/images/btnL3Search.gif" alt="查找 生产问题..." title="查找 生产问题..."
                                                            border="0"></a>
                                                </td>
                                                <td style="padding-right: 0px; padding-left: 10px;">
                                                    <img src="../../../themes/softed/images/tbarImport.gif" alt="*导入 生产问题" title="*导入 生产问题"
                                                        border="0">
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <img src="../../../themes/softed/images/tbarExport.gif" alt="*导出 生产问题" title="*导出 生产问题"
                                                        border="0">
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
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
    
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <%=base.Base_BindView("Zl_Produce_Problem", "Zl_Produce_Problem_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                            <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="ShowDiv()">
                                [x]
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
                                    <input name="matchtype" id="matchtype1" type="radio" runat="server" value="all">&nbsp;匹配以下所有生产问题</b>
                            </td>
                            <td nowrap width="60%" class="small">
                                <b>
                                    <input name="matchtype" id="matchtype2" type="radio" value="any" runat="server" checked>&nbsp;匹配以下任意生产问题</b>
                            </td>
                            <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="fnshow()">
                                [x]
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="2" cellspacing="0" width="80%" align="center" class="searchUIAdv2 small"
                        border="0">
                        <tr>
                            <td align="center" class="small" width="90%">
                                <div id="fixed" style="position: relative; width: 95%; height: 80px; padding: 0px;
                                    overflow: auto; border: 1px solid #CCCCCC; background-color: #ffffff" class="small">
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
                                <input type="button" name="more" value=" 增加生产问题 " onclick="fnAddSrch('<%=Base_GetBindSearch("Zl_Produce_Problem")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
                                    class="crmbuttom small edit">
                                <input name="button" type="button" value=" 删除生产问题 " onclick="delRow()" class="crmbuttom small edit">
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
            <td>
                <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                    <tr>
                        <td>
                            <!--GridView-->
                            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%"
                                BorderColor="#4974C2"
                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                               OnRowDataBound="GridView1_DataRowBinding">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="left">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chbk" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="生产问题名称" SortExpression="ZPP_Title" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <a href="Zl_Produce_Problem_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ZPP_ID") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "ZPP_Title")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="产品型号" SortExpression="ZPP_ProdutsBarCode" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                                <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ZPP_ProdutsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="记录编号" DataField="ZPP_Code" SortExpression="ZPP_Code" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="日期" DataField="ZPP_STime" SortExpression="ZPP_STime"
                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="希望完成日期" DataField="ZPP_HopeDate" SortExpression="ZPP_HopeDate"
                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="生产阶段" SortExpression="ZPP_ScStage" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                                <%# base.Base_GetBasicCodeName("260",DataBinder.Eval(Container.DataItem, "ZPP_ScStage").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="类型" SortExpression="ZPP_Type" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                                <%# base.Base_GetBasicCodeName("261",DataBinder.Eval(Container.DataItem, "ZPP_Type").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态" SortExpression="ZPP_FlowStep" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                                <%# base.Base_GetBasicCodeName("263",DataBinder.Eval(Container.DataItem, "ZPP_FlowStep").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="责任人" SortExpression="ZPP_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                                <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "ZPP_DutyPerson").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="责任部门" SortExpression="ZPP_DutyDepart" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                                <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "ZPP_DutyDepart").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="处理" SortExpression="ZPP_State" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# GetDState(DataBinder.Eval(Container.DataItem, "ZPP_State"), DataBinder.Eval(Container.DataItem, "ZPP_ID").ToString(), "处理")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="结案" SortExpression="ZPP_ClosedState" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# GetDState(DataBinder.Eval(Container.DataItem, "ZPP_ClosedState"), DataBinder.Eval(Container.DataItem, "ZPP_ID").ToString(), "结案")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="审核" SortExpression="ZPP_ID" ItemStyle-HorizontalAlign="center"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# getShState(DataBinder.Eval(Container.DataItem, "ZPP_ID").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <a href="Zl_Produce_Problem_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ZPP_ID") %>">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="../../../images/Edit.gif" border="0"
                                                    ToolTip="修改" /></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass='colHeader'/>
                                <RowStyle CssClass='listTableRow'/>
                                <AlternatingRowStyle BackColor="#E3EAF2"/>
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
                        </td>
                    </tr>
                </table>
                <!--分页-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
