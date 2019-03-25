<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Freight_List.aspx.cs" Inherits="Xs_Sales_Freight_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>运费承担列表</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div id="sharerecorddiv" runat="server" class="layerPopup" style="display: none; width: 250px;">
            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
                <tr>
                    <td width="99%" style="cursor: move;" id="sharerecord_div_title" class="layerPopupHeading"
                        align="left">共享
                    </td>
                    <td align="right" width="40%">
                        <img onclick="fninvsh('sharerecorddiv');" title="关闭" alt="关闭" style="cursor: pointer;"
                            src="/themes/softed/images/close.gif" align="absmiddle" border="0">
                    </td>
                </tr>
            </table>
            <%=Base_GetBaseShare(" ", "  ")%>
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
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售管理 > <a class="hdrLink" href="Xs_Sales_Freight_List.aspx">
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
                                                        <a href="javascript:;" onclick="PageGo('Xs_Sales_Freight_Add.aspx')">
                                                            <img src="/themes/softed/images/btnL3Add.gif" alt="创建 运费承担..." title="创建 运费承担..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px;">
                                                        <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="/themes/softed/images/btnL3Delete.gif"
                                                            OnClick="Btn_Del_Click" />
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="/themes/softed/images/btnL3Search.gif" alt="查找 运费承担..." title="查找 运费承担..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="/themes/softed/images/tbarImport.gif" alt="*导入 运费承担" title="*导入 运费承担"
                                                            border="0">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <img src="/themes/softed/images/tbarExport.gif" alt="*导出 运费承担" title="*导出 运费承担"
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

        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <%=base.Base_BindView("Xs_Sales_Freight", "Xs_Sales_Freight_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Knet_Procure_OrdersList")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                            <td style="padding-right: 20px" align="left" nowrap>查看范围:<asp:DropDownList runat="server" ID="Ddl_Batch" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged"></asp:DropDownList>
                                <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');"
                                    onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                                <img border="0" src="/themes/images/collapse.gif">
                                <div id="selectoperate" class="drop_mnu" onmouseout="fnHideDrop('selectoperate')"
                                    onmouseover="fnShowDrop('selectoperate')">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <a href="#" onclick="javascript:return fnvshobj(this,'sharerecorddiv');" class="drop_down">共享</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="Custom_DgMain" EmptyDataText="&lt;div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'&gt; &lt;table border='0' cellpadding='5' cellspacing='0' width='98%'&gt;&lt;tr&gt; &lt;td rowspan='2' width='25%'&gt;&lt;img src='/themes/softed/images/empty.jpg' height='60' width='61'&gt;&lt;/td&gt; &lt;td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'&gt;&lt;span class='genHeaderSmall'&gt;记录为空&lt;/span&gt;&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt; &lt;/div&gt;" IsShowEmptyTemplate="true" PageSize="10" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="left" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40px">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" onclick="selectAll(this)" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chbk" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="编号" ItemStyle-HorizontalAlign="Left" SortExpression="XSF_Code">
                                                    <ItemTemplate>
                                                        <a href='Xs_Sales_Freight_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSF_ID") %>'>
                                                            <%# DataBinder.Eval(Container.DataItem, "XSF_Code")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="来源" ItemStyle-HorizontalAlign="Left" SortExpression="XSF_Code">
                                                    <ItemTemplate>
                                                        <a href='../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSF_FID") %>'>
                                                            <%# DataBinder.Eval(Container.DataItem, "XSF_FID")%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="XSF_Stime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="日期" HtmlEncode="false" SortExpression="XSF_Stime">
                                                    <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="类型" ItemStyle-HorizontalAlign="Left" SortExpression="XSF_Type">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("755",DataBinder.Eval(Container.DataItem, "XSF_Type").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetShipDetailProductsPatten(DataBinder.Eval(Container.DataItem, "XSF_FID").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="供应商" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%#base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "XSF_CustomerValue").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="客户名称" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%#GetCustomer(DataBinder.Eval(Container.DataItem, "XSF_FID").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="XSF_TotalNumber" HeaderText="数量" HtmlEncode="false" SortExpression="XSF_TotalNumber">
                                                    <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="XSF_TotalMoney" HeaderText="总金额" HtmlEncode="false" SortExpression="XSF_TotalMoney">
                                                    <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="XSF_FMoney" HeaderText="供应商承担" HtmlEncode="false" SortExpression="XSF_FMoney">
                                                    <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="XSF_Money" HeaderText="士腾承担" HtmlEncode="false" SortExpression="XSF_Money">
                                                    <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="物流公司" SortExpression="XSF_FSuppNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "XSF_FSuppNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="XSF_KDCode" HeaderText="单号" HtmlEncode="false" SortExpression="XSF_Money">
                                                    <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                
                                        <asp:TemplateField HeaderText="状态" SortExpression="XSF_ID" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
           <%# GetKDSateName(DataBinder.Eval(Container.DataItem, "XSF_ID").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                    
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" HeaderText="修改">
                                                    <ItemTemplate>
                                                        <a href='Xs_Sales_Freight_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSF_ID") %>'>
                                                            <asp:Image ID="Image1" runat="server" border="0" ImageUrl="/images/Edit.gif" ToolTip="修改" />
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="center" HeaderText="审核" ItemStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# GetCheckYN(DataBinder.Eval(Container.DataItem, "XSF_ID"))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="colHeader" />
                                            <RowStyle CssClass="listTableRow" />
                                            <AlternatingRowStyle BackColor="#E3EAF2" />
                                            <PagerStyle CssClass="Custom_DgPage" />
                                        </cc1:MyGridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <!--GridView-->


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
