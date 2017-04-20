<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KNet_WareHouse_Ownall_New.aspx.cs" Inherits="Knet_Web_WareHouse_KNet_WareHouse_Ownall" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <title>库存总账</title>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">

    <form id="form2" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>库存总账 > <a class="hdrLink" href="KNet_WareHouse_Ownall_New.aspx">库存总账</a>
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
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 库存总账信息..." title="查找 库存总账信息..."
                                                                border="0"></a></td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 库存总账信息" title="*导入 库存总账信息"
                                                            border="0"></td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 库存总账信息" title="*导出 库存总账信息"
                                                            border="0"></td>
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
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <%=base.Base_BindView("V_Store", "KNet_WareHouse_Ownall_New.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                                    <b>查找</b></td>
                                <td class="small" nowrap>
                                    <div id="basicsearchcolumns_real">
                                        <asp:DropDownList runat="server" ID="bas_searchfield" class="txtBox">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td class="small">
                                    <asp:TextBox ID="search_text" class="txtBox" runat="server"></asp:TextBox></td>
                                <td class="small" nowrap width="40%">
                                    <asp:Button ID="btnBasicSearch" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small create" OnClick="btnBasicSearch_Click" />&nbsp;
                                    <input name="Btn_submit" type="button" class="crmbutton small edit" onclick="ShowDiv()"
                                        value=" 取消查找 ">&nbsp;
                                </td>
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="ShowDiv()">[x]</td>
                            </tr>
                        </table>
                    </div>
                    <div id="advSearch" style="display: none;" runat="server">
                        <table cellspacing="0" cellpadding="5" width="80%" class="searchUIAdv1 small" align="center"
                            border="0">
                            <tr>
                                <td class="searchUIName small" nowrap align="left">
                                    <span class="moduleName">查找</span><br>
                                    <span class="small"><a href="#" onclick="ShowDiv();fnshow();">基本查找</a></span></td>
                                <td nowrap class="small">
                                    <b>
                                        <input name="matchtype" id="matchtype1" type="radio" runat="server" value="all">&nbsp;匹配以下所有条件</b></td>
                                <td nowrap width="60%" class="small">
                                    <b>
                                        <input name="matchtype" id="matchtype2" type="radio" value="any" runat="server" checked>&nbsp;匹配以下任意条件</b></td>
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="fnshow()">[x]</td>
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
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("V_Store")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <!-- Buttons -->
                            <td style="padding-right: 20px" align="left" nowrap>查看范围:<asp:DropDownList ID="HouseNoDataList" runat="server" Width="150px" OnSelectedIndexChanged="HouseNoDataList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                            </td>
                        </tr>
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
                                <div id="changeowner" class="layerPopup" style="display: none; width: 325px;">
                                    <table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
                                        <tr>
                                            <td class="layerPopupHeading" align="left" width="60%">修改负责人</td>
                                            <td>&nbsp;</td>
                                            <td align="right" width="40%">
                                                <img onclick="fninvsh('changeowner');" title="关闭" alt="关闭" style="cursor: pointer;"
                                                    src="../../themes/softed/images/close.gif" align="absmiddle" border="0"></td>
                                        </tr>
                                    </table>
                                    <table border="0" cellspacing="0" cellpadding="5" width="95%" align="center">
                                        <tr>
                                            <td class="small">
                                                <!-- popup specific content fill in starts -->
                                                <table border="0" celspacing="0" cellpadding="5" width="100%" align="center" bgcolor="white">
                                                    <tr>
                                                        <td width="50%" align="right">
                                                            <b>转移拥有关系:</b></td>
                                                        <td width="50%">
                                                            <asp:DropDownList ID="Ddl_DutyPerson" runat="server" class="detailedViewTextBox">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerPopupTransport">
                                        <tr>
                                            <td align="center">
                                                <input type="button" name="button" class="crmbutton small edit" value="更新负责人" onclick="ajaxChangeStatus('owner')">
                                                <input type="button" name="button" class="crmbutton small cancel" value="取消" onclick="fninvsh('changeowner')">
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <cc1:MyGridView ID="GridView1" PageSize="10" runat="server" AllowSorting="True" AllowPaging="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录，或没有受权使用相关仓库</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                                    <Columns>


                                        <asp:TemplateField HeaderImageUrl="../../images/icon_list_over.gif" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <a href="KNet_WareHouse_Ownall_New.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode") %>">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../../images/Deitail.gif" ToolTip="查看产品库存明细" /></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField SortExpression="HouseNo" HeaderText="仓库名称" ItemStyle-Height="25px" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <%# base.Base_GetHouseName(Eval("HouseNo").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="ProductsName" HeaderText="产品名称" ItemStyle-Height="25px" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <%# base.Base_GetProdutsName_Link(Eval("ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField SortExpression="ProductsBarCode" HeaderText="产品编号" ItemStyle-Height="25px" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <%# base.Base_GetProductsCode(Eval("ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ProductsEdition" HeaderText="版本号" ItemStyle-Height="25px" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <%# base.Base_GetProductsEdition(Eval("ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="WareHouseAmount" HeaderText="库存" SortExpression="WareHouseAmount" DataFormatString="{0:F0}">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="40px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="StorageVolume" HeaderText="入库数" SortExpression="StorageVolume" DataFormatString="{0:F0}">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="40px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="ScQuantity" HeaderText="生产入库" SortExpression="ScQuantity" DataFormatString="{0:F0}">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="60px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="ShippedQuantity" HeaderText="出库" SortExpression="ShippedQuantity" DataFormatString="{0:F0}">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="40px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="XhQuantity" HeaderText="消耗" SortExpression="XhQuantity" DataFormatString="{0:F0}">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="40px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="PdQuantity" HeaderText="盘点" SortExpression="PdQuantity" DataFormatString="{0:F0}">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="40px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="库存均价" SortExpression="WareHouseTotalNet" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# GetPinPrice(DataBinder.Eval(Container.DataItem, "WareHouseTotalNet").ToString(),DataBinder.Eval(Container.DataItem, "WareHouseAmount").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="WareHouseTotalNet" ItemStyle-Font-Size="12px" SortExpression="WareHouseTotalNet" HeaderText="库存净值" ItemStyle-Width="60px" HeaderStyle-Font-Size="12px" DataFormatString="{0:N}" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="缺料" HeaderStyle-Font-Size="12px"
                                            ItemStyle-Width="28px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <%# GetQlNumber(DataBinder.Eval(Container.DataItem, "HouseNo").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="LastHlTime" ItemStyle-Font-Size="12px" SortExpression="LastHlTime" HeaderText="最后耗料" ItemStyle-Width="80px" HeaderStyle-Font-Size="12px" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="明细" HeaderStyle-Font-Size="12px"
                                            ItemStyle-Width="28px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <a href="KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>&HouseNo=<%# DataBinder.Eval(Container.DataItem, "HouseNo")%>" target="_self">明细</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>

                                    <HeaderStyle CssClass='colHeader' />
                                    <RowStyle CssClass='listTableRow' />
                                    <AlternatingRowStyle BackColor="#E3EAF2" />
                                    <PagerStyle CssClass='Custom_DgPage' />
                                </cc1:MyGridView>
                                <asp:Label ID="HeXinQ" runat="server" Font-Size="13px"></asp:Label>
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
