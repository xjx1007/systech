<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_MaterialIn_List.aspx.cs"
    Inherits="Procure_MaterialIN_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>原材料入库单</title>
</head>
<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>单据 > <a class="hdrLink" href="Procure_MaterialIn_List.aspx">原材料入库单</a>
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
                                                        <a href="javascript:;" onclick="PageGo('../WareHouseIn/KNet_WareHouse_DirectInto_Add.aspx?&Type=5')">
                                                            <img src="/themes/softed/images/btnL3Add.gif" alt="创建 原材料入库单..." title="创建 原材料入库单..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px;">
                                                        <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="/themes/softed/images/btnL3Delete.gif"
                                                            OnClick="Btn_Del_Click" />
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="/themes/softed/images/btnL3Search.gif" alt="查找 原材料入库单..." title="查找 原材料入库单..."
                                                                border="0"></a>
                                                    </td>
                                                    
                                                <td style="padding-right: 10px">
                                                    <asp:ImageButton ImageUrl="../../themes/softed/images/tbarExport.gif"  runat="server" ID="ImgB" OnClick="ImgB_Click" />
                                     
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <asp:Button ID="Btn_Show" runat="server" Text="显示全部" title="显示全部"
                                                            class="crmbutton small save" OnClick="Btn_Show_Click"/>
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

                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                    <td>      <%=base.Base_BindViewByTitle("月份","Procure_MaterialIn", "Procure_MaterialIn_List.aspx","and PBW_Order  in ('100','99')","WhereID", this.Tbx_WhereID.Text,"&WhereID1="+this.Tbx_WhereID1.Text)%>
                  
                    </td>
                </tr>
                                    <tr>
                    <td>
                        <%=base.Base_BindViewByTitle("其他","Procure_MaterialIn", "Procure_MaterialIn_List.aspx","and PBW_Order not in ('100','99')","WhereID1", this.Tbx_WhereID1.Text,"&WhereID="+this.Tbx_WhereID.Text)%>
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
                                            <span class="moduleName">查找</span> <span class="small"><a href="#" onclick="ShowDiv();fnshow();">基本查找</a></span>
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
                                            <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Procure_MaterialIn")%>','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                            
                            查看范围: <asp:DropDownList runat="server" ID="Ddl_House" AutoPostBack="true"  OnTextChanged="Ddl_House_TextChanged"></asp:DropDownList>
                           <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');"
                                onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                            <img border="0" src="/themes/images/collapse.gif">
                            <div id="selectoperate" class="drop_mnu1" onmouseout="fnHideDrop('selectoperate')"
                                onmouseover="fnShowDrop('selectoperate')">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            
                                <asp:Button ID="Btn_Sp" runat="server" Text="批量审批"  width="100%" BorderColor="White" OnClick="Btn_SpSave" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                                <tr>
                                    <td>
                                       <asp:Label runat="server" ID="Lbl_Total"></asp:Label>
                                        <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                            IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关采购单记录</B><br/><br/></font></div>"
                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_Editing">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <input type="CheckBox" onclick="selectAll(this)">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chbk" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="单号" SortExpression="WareHouseNo" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        
                                            <a href="/Web/OrderInWareHouse/Knet_Procure_WareHouseList_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "WareHouseNo") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "WareHouseNo").ToString()%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="入库日期" SortExpression="WareHouseDateTime">
                                                    <ItemTemplate>
                                                        <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "WareHouseDateTime").ToString()).ToShortDateString() %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="供应商" SortExpression="COC_SuppNo">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="入库仓库" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                          <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="产品名称" SortExpression="COD_ProductsBarCOde">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetProdutsName(DataBinder.Eval(Container.DataItem, "ProductsBarCOde").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="产品型号" SortExpression="COD_ProductsBarCOde">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetProductsPattern(DataBinder.Eval(Container.DataItem, "ProductsBarCOde").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="产品版本" SortExpression="COD_ProductsBarCOde">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCOde").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="数量" SortExpression="WareHouseAmount">
                                                    <ItemTemplate>
                                                        <%# base.FormatNumber1(DataBinder.Eval(Container.DataItem, "WareHouseAmount").ToString(),0) %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="单价" SortExpression="WareHouseunitPrice">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "WareHouseunitPrice").ToString() %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="金额" SortExpression="WareHouseTotalNet">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "WareHouseTotalNet").ToString() %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="次数" SortExpression="KWP_NoTaxLag">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "KWP_NoTaxLag").ToString() %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="不含税金额" SortExpression="KWP_NoTaxMoney">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="Tbx_Money" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Text='<%# DataBinder.Eval(Container.DataItem, "KWP_NoTaxMoney").ToString() %>' Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "KWP_NoTaxMoney").ToString() %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowEditButton="true" HeaderText="修改" EditText="修改" ValidationGroup="88">
                                                    <ItemStyle HorizontalAlign="Left"  Font-Size="12px" />
                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                </asp:CommandField>
                                                
                                        <asp:TemplateField HeaderText="审核" SortExpression="DirectOutCheckYN" HeaderStyle-Font-Size="12px"
                                             ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <itemtemplate>
               <%# GetOrderCheckYN(DataBinder.Eval(Container.DataItem, "WareHouseNo"))%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="类型" SortExpression="DirectOutCheckYN" HeaderStyle-Font-Size="12px"
                                             ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                            <itemtemplate>
                                               <%# GetState(DataBinder.Eval(Container.DataItem, "DetailsID").ToString())%>
                                          </itemtemplate>
                                        </asp:TemplateField>
                                                <asp:TemplateField HeaderText="操作人">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KPW_Creator").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="日期" SortExpression="COC_CTime">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "KPW_CTime").ToString() %>
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

                        </td>
                    </tr>
                </table>
        <asp:TextBox ID="Tbx_WhereID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_WhereID1" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
    </form>
</body>
</html>
