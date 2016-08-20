<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Opp_List.aspx.cs"
    Inherits="Web_Sales_Xs_Sales_Opp_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title></title>
</head>
<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div id="sharerecorddiv" runat="server" class="layerPopup" style="display: none; width: 250px;">
            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
                <tr>
                    <td width="99%" style="cursor: move;" id="sharerecord_div_title" class="layerPopupHeading"
                        align="left">共享
                    </td>
                    <td align="right" width="40%">
                        <img onclick="fninvsh('sharerecorddiv');" title="关闭" alt="关闭" style="cursor: pointer;"
                            src="../../themes/softed/images/close.gif" align="absmiddle" border="0">
                    </td>
                </tr>
            </table>
            <%=Base_GetBaseShare(" and StrucValue in ('129652783822281241','129652783965723459','129652783693249229')", " and IsSale='1' ")%>
            <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerPopupTransport">
                <tr>
                    <td align="center">
                        <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                            class="crmbutton small save" OnClick="Btn_Save_Click" />
                        <input type="button" name="button" class="crmbutton small cancel" value="取消" onclick="fninvsh('sharerecorddiv')">
                    </td>
                </tr>
            </table>
        </div>
        <script>
            Drag.init(document.getElementById("sharerecord_div_title"), document.getElementById("sharerecorddiv"));
        </script>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售机会 > <a class="hdrLink" href="Xs_Sales_Opp_List.aspx">销售机会</a>
                </td>
                <td width="100%" nowrap>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="sep1" style="width: 1px;"></td>
                            <td class="small">
                                <!-- Add and Search -->
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="0" cellpadding="5">
                                                <tr>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <a href="javascript:;" onclick="PageGo('Xs_Sales_Opp_Add.aspx')">
                                                            <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 销售机会..." title="创建 销售机会..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px;">
                                                        <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../themes/softed/images/btnL3Delete.gif"
                                                            OnClick="Btn_Del_Click" />
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv()">
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 销售机会..." title="查找 销售机会..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 销售机会" title="*导入 销售机会"
                                                            border="0">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 销售机会" title="*导出 销售机会"
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
                <td style="height: 2px"></td>
            </tr>
        </table>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div style="text-align: center">
                    <asp:Image runat="server" ID="Imag_Load" ImageUrl="../images/loading.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                                <tr>
                                    <td>
                                        <%=base.Base_BindViewByTitle("销售阶段","Xs_Sales_Opp", "Xs_Sales_Opp_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString(),"and PBW_Order='0'")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%=base.Base_BindViewByTitle("销售过程", "Xs_Sales_Opp", "Xs_Sales_Opp_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString(), "and PBW_Order='1'")%>
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
                                                        <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Xs_Sales_Opp")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                                    <!-- Buttons -->
                                    <td style="padding-right: 20px" align="left" nowrap>查看范围:<asp:DropDownList runat="server" ID="Ddl_Batch" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged">
                                    </asp:DropDownList>
                                        <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');"
                                            onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                                        <img border="0" src="../../themes/images/collapse.gif">
                                        <div id="selectoperate" class="drop_mnu" onmouseout="fnHideDrop('selectoperate')"
                                            onmouseover="fnShowDrop('selectoperate')">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <a href="#" class="drop_down">修改负责人</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="#" onclick="javascript:return fnvshobj(this,'sharerecorddiv');" class="drop_down">共享</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                            IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="CheckBox" onclick="selectAll(this)">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chbk" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Height="25px" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="销售机会名称" SortExpression="XSO_Name" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <a href="Xs_Sales_Opp_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSO_DID") %>">
                                                            <%# DataBinder.Eval(Container.DataItem, "XSO_Name").ToString()%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="客户名称" SortExpression="XSO_CustomerValue" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "XSO_CustomerValue").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="销售阶段" SortExpression="XSO_SalesStep" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("118", DataBinder.Eval(Container.DataItem, "XSO_SalesStep").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="可能性" SortExpression="XSO_Precent" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("154", DataBinder.Eval(Container.DataItem, "XSO_Precent").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="销售过程" SortExpression="XSO_SalesType" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("202", DataBinder.Eval(Container.DataItem, "XSO_SalesType").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="联系人" SortExpression="XSO_LinkMan" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetLinkManValue(DataBinder.Eval(Container.DataItem, "XSO_LinkMan").ToString(),"XOL_Name")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="时间结点" DataField="XSO_PlanDealDate" SortExpression="XSO_PlanDealDate"
                                                    DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="下一步" DataField="XSO_NextPlan" SortExpression="XSO_NextPlan"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="负责人" SortExpression="XSO_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSO_DutyPerson").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="辅助人" SortExpression="XSO_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "XSO_FDutyPerson").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="操作时间" HeaderStyle-HorizontalAlign="center" SortExpression="XSO_CTime">
                                                    <ItemTemplate>
                                                        <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "XSO_MTime").ToString()).ToString()%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <a href="Xs_Sales_Opp_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSO_DID") %>">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="../../images/Edit.gif" border="0"
                                                                ToolTip="修改" /></a>
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
                            <!--分页-->
                            <!--底部功能栏-->
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
