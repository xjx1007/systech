<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_Products_Enclosure_List.aspx.cs" Inherits="KNet_Products_Enclosure_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <title>产品资料</title>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品 > <a class="hdrLink" href="KnetProductsSetting.aspx">
                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label></a>
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
                                                    <td style="padding-right: 0px;">
                                                        <a href="javascript:;" onclick="">
                                                            <asp:ImageButton alt="删除 产品资料..." title="删除 产品资料..." ImageUrl="../../themes/softed/images/btnL3Delete.gif"
                                                                runat="server" ID="Btn_Del" OnClick="Btn_Del_Click" />
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 产品资料..." title="查找 产品资料..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 产品资料" title="*导入 产品资料"
                                                            border="0">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 产品资料" title="*导出 产品资料"
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
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
            <tr>
                <td></td>
            </tr>
        </table>

                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2">
                            <%=base.Base_BindView("PB_Basic_Attachment", "KNet_Products_Enclosure_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
                                <table cellpadding="2" cellspacing="0" width="80%" align="center"
                                    border="0">
                                    <tr>
                                        <td align="center" class="small" width="90%">
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
                                            <hr width="720">
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellspacing="0" cellpadding="5" width="80%" class="searchUIAdv3 small"
                                    align="center">
                                    <tr>
                                        <td align="left" width="40%">
                                            <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("PB_Basic_Attachment")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                        <tr>
                            <td width="14%" valign="top">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                        </td>
                                        <td id="catalog_tab" class="dvtSelectedCell" align="center" nowrap>
                                            <a href="javascript:showProductCatalog()">产品分类</a>
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            
                    <asp:TextBox runat="server" ID="Tbx_Productstype" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer"
                                                NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"
                                                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                                <ParentNodeStyle Font-Bold="False" />
                                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False"
                                                    HorizontalPadding="0px" VerticalPadding="0px" />
                                            </asp:TreeView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="85%" align="left" valign="top" style="border-left: 2px dashed #cccccc;">
                                <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                                    <tr>
                                        <td>

                                            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px" OnRowCommand="GridView1_RowCommand" 
                                                OnRowDataBound="GridView1_DataRowBinding">
                                                <Columns>

                                                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                        <HeaderTemplate>
                                                            <input type="CheckBox" onclick="selectAll(this)" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Chbk" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="附件名称" SortExpression="PBA_Name" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="center">
                                                        <ItemTemplate>
                                                            <a href="KNet_Products_Enclosure_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PBA_ID") %>" target="_blank">
                                                                <%# DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="更新" SortExpression="PBA_Name" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-HorizontalAlign="center">
                                                        <ItemTemplate>
                                                            <a href="KNet_Products_Enclosure_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PBA_UpdateFID") %>" target="_blank">
                                                                <%#GetName( DataBinder.Eval(Container.DataItem, "PBA_UpdateFID").ToString())%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:BoundField DataField="PBA_FileType" HeaderText="附件类型" SortExpression="PBA_FileType" >                                                 
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="类别" SortExpression="PBA_ProductsType" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetBasicCodeName("778",DataBinder.Eval(Container.DataItem, "PBA_ProductsType").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="产品名称" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%#base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ProductsPattern" HeaderText="产品型号" SortExpression="ProductsPattern">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="下载" HeaderStyle-Font-Size="12px"
                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDownload" runat="server" CommandName="Download" CommandArgument='<%#Eval("PBA_ID") %>'>下载</asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="审批" SortExpression="PBA_State" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="Btn_Sp" runat="server" CommandName="Sp" CommandArgument='<%#Eval("PBA_ID") %>'><%#base.Base_GetBasicCodeName("1133 ",DataBinder.Eval(Container.DataItem, "PBA_State").ToString())%></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="添加时间" DataField="PBA_CTime" SortExpression="PBA_CTime" HtmlEncode="false">
                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="添加人" SortExpression="PBA_Creator" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%#base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "PBA_Creator").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="状态" SortExpression="PBA_Del">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="ImageButton1" runat="server"  CommandName="De" CommandArgument='<%#Eval("PBA_ID") %>' OnClientClick="return confirm('确定停用或启用当前附件？')"><%#base.Base_GetBasicCodeName("204 ",DataBinder.Eval(Container.DataItem, "PBA_Del").ToString())%></asp:LinkButton>
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
                            </td>
                        </tr>
                </table>

    </form>
</body>
</html>
