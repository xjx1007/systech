<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_CpbWw_List.aspx.cs"
    Inherits="Procure_CpbWw_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>成品调拨单</title>
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../../Web/DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>单据 > <a class="hdrLink" href="Procure_CpbWw_List.aspx">成品调拨单</a>
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
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 成品委外单..." title="查找 成品委外单..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 成品委外单" title="*导入 成品委外单"
                                                            border="0">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 成品委外单" title="*导出 成品委外单"
                                                            border="0">
                                                    </td>

                                                    <td style="padding-right: 10px">
                                                        <asp:Button ID="BtnSave" runat="server" Text="计算单价" title="计算单价"
                                                            class="crmbutton small save" OnClick="BtnSave_Click" />
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <asp:Button ID="Btn_Show" runat="server" Text="显示全部" title="显示全部"
                                                            class="crmbutton small save" OnClick="Btn_Show_Click" />
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
                <td><%=base.Base_BindViewByTitle("月份","Cg_Order_MaterialDbIN", "Procure_CpbWw_List.aspx","and PBW_Order  in ('0')","WhereID", this.Tbx_WhereID.Text,"&WhereID1="+this.Tbx_WhereID1.Text)%>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <%=base.Base_BindViewByTitle("其他","Cg_Order_MaterialDbIN", "Procure_CpbWw_List.aspx","and PBW_Order not in ('0')","WhereID1", this.Tbx_WhereID1.Text,"&WhereID="+this.Tbx_WhereID.Text)%>
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
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Cg_Order_MaterialDbIN")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                                <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');"
                                    onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                                <img border="0" src="/themes/images/collapse.gif">
                                <div id="selectoperate" class="drop_mnu1" onmouseout="fnHideDrop('selectoperate')"
                                    onmouseover="fnShowDrop('selectoperate')">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                
                                        <tr>
                                            <td>

                                                <asp:Button ID="Btn_Sp" runat="server" Text="批量审批" Width="100%" BorderColor="White" OnClick="Btn_SpSave" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>


                                                <asp:Button ID="Button1" runat="server" Text="批量反审批" Width="100%" BorderColor="White" OnClick="Btn_SpSave1" />
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
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
                                        <asp:TemplateField HeaderText="单号" SortExpression="AllocateNo" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "AllocateNo")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="日期" DataField="AllocateDateTime" DataFormatString="{0:yyyy-MM-dd}"  ReadOnly="True" 
                                            SortExpression="AllocateDateTime">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="出库仓库" SortExpression="HouseNo">
                                            <ItemTemplate>
                                                <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo1").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="入库仓库" SortExpression="HouseNo">
                                            <ItemTemplate>
                                                <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo_int").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="名称" SortExpression="ProductsBarCode">
                                            <ItemTemplate>
                                                <%# base.Base_GetProdutsName(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="型号" SortExpression="ProductsBarCode">
                                            <ItemTemplate>
                                                <%# base.Base_GetProductsPattern(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="料号" SortExpression="ProductsBarCode">
                                            <ItemTemplate>
                                                <%# base.Base_GetProductsCode(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="版本号" SortExpression="ProductsBarCode">
                                            <ItemTemplate>
                                                <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="数量" DataField="allocateAmount"  ReadOnly="True" 
                                            SortExpression="COD_DZNumber">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="单价" SortExpression="Allocate_WwPrice">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="Tbx_NewPrice" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Text='<%# DataBinder.Eval(Container.DataItem, "Allocate_WwPrice").ToString() %>' Width="100px"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "allocateUnitPrice").ToString() %>
                                                <asp:TextBox runat="server" ID="Tbx_Price" CssClass="Custom_Hidden" Text='<%# GetKC(DataBinder.Eval(Container.DataItem, "ID").ToString(),4)%>'></asp:TextBox>
                                                <asp:TextBox runat="server" ID="Tbx_Number" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "allocateAmount").ToString()%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="委外金额" DataField="Allocate_WwMoney"
                                            SortExpression="Allocate_WwMoney"  ReadOnly="True" >
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="状态">
                                            <ItemTemplate>
                                                <%# GetState(DataBinder.Eval(Container.DataItem, "AllocateCheckYN").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="true" HeaderText="修改" EditText="修改" ValidationGroup="88">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                        </asp:CommandField>

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
