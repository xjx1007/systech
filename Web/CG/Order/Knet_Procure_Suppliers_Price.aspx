<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Knet_Procure_Suppliers_Price.aspx.cs" Inherits="Knet_Web_Procure_Knet_Procure_Suppliers_Price" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>采购报价列表</title>
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../../../Web/DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/js/ListView.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购 > <a class="hdrLink" href="Knet_Procure_Suppliers_Price.aspx">
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
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <a href="javascript:;" onclick="PageGo('Knet_Procure_Suppliers_Price_Add.aspx')">
                                                            <img src="../../../themes/softed/images/btnL3Add.gif" alt="创建 供应商报价..." title="创建 供应商报价..."
                                                                border="0"></a></td>
                                                    <td style="padding-right: 0px;">
                                                        <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../../themes/softed/images/btnL3Delete.gif" OnClick="Btn_Del_Click" /></td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="../../../themes/softed/images/btnL3Search.gif" alt="查找 供应商报价..." title="查找 供应商报价..."
                                                                border="0"></a></td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../../themes/softed/images/tbarImport.gif" alt="*导入 供应商报价" title="*导入 供应商报价"
                                                            border="0"></td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../../themes/softed/images/tbarExport.gif" alt="*导出 供应商报价" title="*导出 供应商报价"
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
                            <%=base.Base_BindView("Knet_Procure_SuppliersPrice", "Knet_Procure_Suppliers_Price.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                        <td>
                            <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                                                    <tr>
                        <!-- Buttons -->
                        <td style="padding-right: 20px" align="left" nowrap>
                            供应商：<asp:DropDownList runat="server" ID="Ddl_Supp" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Supp_SelectedIndexChanged"></asp:DropDownList>
                            <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');"
                                onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                            <img border="0" src="../../../themes/images/collapse.gif">
                            <div id="selectoperate" class="drop_mnu" onmouseout="fnHideDrop('selectoperate')"
                                onmouseover="fnShowDrop('selectoperate')">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            
                                        
                                             <asp:Button ID="Btn_Sp" runat="server" Text="批量审批"  width="100%" OnClick="Btn_SpSave" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                                <tr>
                                    
            <td width="14%" valign="top">
                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                    <tr>
                        <td class="dvtTabCache" style="width: 10px" nowrap>
                            &nbsp;
                        </td>
                        <td id="catalog_tab" class="dvtSelectedCell" align="center" nowrap>
                            <a href="javascript:showProductCatalog()">产品分类</a>
                        </td>
                        <td class="dvtTabCache" style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" 
                                NodeIndent="15" onselectednodechanged="TreeView1_SelectedNodeChanged">
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
                                        <cc1:MyGridView ID="GridView1" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px"
                                            AllowPaging="true" PageSize="10" OnRowDataBound="GridView1_DataRowBinding">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                    <HeaderTemplate>

                                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chbk" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="供应商" SortExpression="SuppNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="名称" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:BoundField DataField="v_KSP_Code" HeaderText="料号" SortExpression="v_KSP_Code">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="60px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="v_ProductsEdition" HeaderText="版本号" SortExpression="v_ProductsEdition" >
                                                    <ItemStyle HorizontalAlign="center" Font-Size="12px"  />
                                                    <HeaderStyle HorizontalAlign="center" Font-Size="12px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="ProcureUnitPrice" ItemStyle-Font-Size="12px" HeaderText="单价" ItemStyle-Width="60px" HeaderStyle-Font-Size="12px" SortExpression="ProcureUnitPrice" DataFormatString="{0:F4}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="HandPrice" ItemStyle-Font-Size="12px" HeaderText="加工费" ItemStyle-Width="40px" HeaderStyle-Font-Size="12px" SortExpression="HandPrice" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="状态" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("131", DataBinder.Eval(Container.DataItem, "KPP_Del").ToString()) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:BoundField DataField="KPP_Remarks" ItemStyle-Font-Size="12px" ItemStyle-Width="180px" HeaderText="备注" HeaderStyle-Font-Size="12px" SortExpression="HandPrice" DataFormatString="{0:c}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="ProcureUpdateDateTime" ItemStyle-Font-Size="12px" HeaderText="操作时间" HeaderStyle-Font-Size="12px" SortExpression="ProcureUpdateDateTime" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="审核" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%#GetShState(DataBinder.Eval(Container.DataItem, "KPP_State").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left" DataNavigateUrlFields="ProductsBarCode" DataNavigateUrlFormatString="Knet_Procure_Suppliers_Price.aspx?BarCode={0}" Text="比较" HeaderText="比价" />
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
                        </td>
                    </tr>
                </table>
    </form>
</body>
</html>
