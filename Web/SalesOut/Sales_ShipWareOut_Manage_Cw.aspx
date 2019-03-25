<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_ShipWareOut_Manage_Cw.aspx.cs"
    Inherits="Web_Sales_ShipWareOut_Manage_Cw" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title>成品出库单</title>
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<script type="text/javascript">
    function Print(ID) {
        //window.open('Sales_ShipWareOut_Print_Cw.aspx?ID=' + ID, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500')
        var temp = window.showModalDialog("Sales_ShipWareOut_Print_Cw.aspx?ID=" + ID + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        window.location.reload(); 
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>成品出库单 > <a class="hdrLink" href="Sales_ShipWareOut_Manage_Cw.aspx">成品出库单</a>
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
                                                        <a href="javascript:;" onclick="PageGo('Sales_ShipWareOut_Add.aspx')">
                                                            <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 发货通知信息..." title="创建 发货通知信息..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px;">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 发货通知信息..." title="查找 发货通知信息..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 发货通知信息" title="*导入 发货通知信息"
                                                            border="0">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 发货通知信息" title="*导出 发货通知信息"
                                                            border="0">
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

                    <asp:TextBox ID="Tbx_WhereID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_WhereID1" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <tr>
                        <td><%=base.Base_BindViewByTitle("月份","KNet_WareHouse_DirectOutList", "Sales_ShipWareOut_Manage_Cw.aspx","and PBW_Order  in ('100','99')","WhereID", this.Tbx_WhereID.Text,"&WhereID1="+this.Tbx_WhereID1.Text)%>
                  
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=base.Base_BindViewByTitle("其他","KNet_WareHouse_DirectOutList", "Sales_ShipWareOut_Manage_Cw.aspx","and PBW_Order not in ('100','99')","WhereID1", this.Tbx_WhereID1.Text,"&WhereID="+this.Tbx_WhereID.Text)%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="Search_basic" runat="server" style="display: none">
                                <table align="center" border="0" cellpadding="5" cellspacing="0" class="searchUIBasic small" width="80%">
                                    <tr>
                                        <td align="left" class="searchUIName small" nowrap><span class="moduleName">查找</span><br><span class="small"><a href="#" onclick="ShowDiv();fnshow();">高级查找</a></span>
                                            <br>
                                                <br></br>
                                                <br></br>
                                            </br>
                                        </br>
                                        </td>
                                        <td align="right" class="small" nowrap><b>查找</b> </td>
                                        <td class="small" nowrap>
                                            <div id="basicsearchcolumns_real">
                                                <asp:DropDownList ID="bas_searchfield" runat="server" class="txtBox">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                        <td class="small">
                                            <asp:TextBox ID="search_text" runat="server" class="txtBox"></asp:TextBox>
                                        </td>
                                        <td class="small" nowrap width="40%">
                                            <asp:Button ID="btnBasicSearch" runat="server" AccessKey="F" class="crmbutton small create" OnClick="btnBasicSearch_Click" Text="立即查找" title="立即查找 [Alt+F]" />
                                            &nbsp;
                                            <input class="crmbutton small edit" name="Btn_submit" onclick="ShowDiv()" type="button" value=" 取消查找 ">&nbsp; </input>
                                        </td>
                                        <td class="small" onclick="ShowDiv()" onmouseover="this.style.cursor='pointer';" valign="top">[x] </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="advSearch" runat="server" style="display: none;">
                                <table align="center" border="0" cellpadding="5" cellspacing="0" class="searchUIAdv1 small" width="80%">
                                    <tr>
                                        <td align="left" class="searchUIName small" nowrap><span class="moduleName">查找</span><br><span class="small"><a href="#" onclick="ShowDiv();fnshow();">基本查找</a></span>
                                            <br>
                                                <br></br>
                                                <br></br>
                                            </br>
                                        </br>
                                        </td>
                                        <td class="small" nowrap><b>
                                            <input id="matchtype1" runat="server" name="matchtype" type="radio" value="all">&nbsp;匹配以下所有条件</input></b> </td>
                                        <td class="small" nowrap width="60%"><b>
                                            <input id="matchtype2" runat="server" checked name="matchtype" type="radio" value="any">&nbsp;匹配以下任意条件</input></b> </td>
                                        <td class="small" onclick="fnshow()" onmouseover="this.style.cursor='pointer';" valign="top">[x] </td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="2" cellspacing="0" class="searchUIAdv2 small" width="80%">
                                    <tr>
                                        <td align="center" class="small" width="90%">
                                            <div id="fixed" class="small" style="position: relative; width: 95%; height: 80px; padding: 0px; overflow: auto; border: 1px solid #CCCCCC; background-color: #ffffff">
                                                <table border="0" width="95%">
                                                    <tr>
                                                        <td align="left">
                                                            <table id="adSrc" align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td width="31%">
                                                                        <asp:DropDownList ID="Fields" runat="server" class="txtBox">
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
                                            <hr width="720"></hr>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="5" cellspacing="0" class="searchUIAdv3 small" width="80%">
                                    <tr>
                                        <td align="left" width="40%">
                                            <input class="crmbuttom small edit" name="more" onclick='fnAddSrch(&#039;<%=Base_GetBindSearch("KNet_WareHouse_DirectOutList")%>    &#039;,&#039;&lt;option value=\&#039;cts\&#039;&gt;包含&lt;/option&gt;&lt;option value=\&#039;dcts\&#039;&gt;不包含&lt;/option&gt;&lt;option value=\&#039;is\&#039;&gt;等于&lt;/option&gt;&lt;option value=\&#039;isn\&#039;&gt;不等于&lt;/option&gt;&lt;option value=\&#039;bwt\&#039;&gt;开始为&lt;/option&gt;&lt;option value=\&#039;grt\&#039;&gt;大于&lt;/option&gt;&lt;option value=\&#039;lst\&#039;&gt;小于&lt;/option&gt;&lt;option value=\&#039;grteq\&#039;&gt;大于等于&lt;/option&gt;&lt;option value=\&#039;lsteq\&#039;&gt;小于等于&lt;/option&gt;&#039;)' type="button" value=" 增加条件 ">
                                                <input class="crmbuttom small edit" name="button" onclick="delRow()" type="button" value=" 删除条件 "> </input>
                                            </input>
                                        </td>
                                        <td align="left" class="small">
                                            <asp:Button ID="btnAdvancedSearch" runat="server" AccessKey="F" class="crmbutton small create" OnClick="btnAdvancedSearch_Click" Text="立即查找" title="立即查找 [Alt+F]" />
                                            &nbsp;
                                            <input class="crmbutton small edit" onclick="fnshow();" type="button" value=" 取消查找 "> </input>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <tr>
                            <td>
                                <table border="0" cellpadding="2" cellspacing="0" class="small" width="100%">
                                    <tr>
                                        <!-- Buttons -->
                                        <td align="left" nowrap style="padding-right: 20px">查看范围:<asp:DropDownList ID="Ddl_Batch" runat="server" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged1">
                                        </asp:DropDownList>
                                            <a id="moreoperate" href="" onclick="return false;" onmouseout="fnHideDrop('selectoperate');" onmouseover="BatchfnDropDown(this,'selectoperate');" target="main">批量操作</a>
                                            <img border="0" src="../../themes/images/collapse.gif">
                                                <div id="selectoperate" class="drop_mnu1" onmouseout="fnHideDrop('selectoperate')" onmouseover="fnShowDrop('selectoperate')">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">

                                                        <tr>
                                                            <td>

                                                                <asp:Button ID="Btn_Sp" runat="server" Text="批量审批" Width="100%" BorderColor="White" OnClick="Btn_SpSave" />
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                </div>
                                            </img>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="changeowner" class="layerPopup" style="display: none; width: 325px;">
                                                <table border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine" width="100%">
                                                    <tr>
                                                        <td align="left" class="layerPopupHeading" width="60%">修改负责人 </td>
                                                        <td>&nbsp; </td>
                                                        <td align="right" width="40%">
                                                            <img align="absmiddle" alt="关闭" border="0" onclick="fninvsh('changeowner');" src="../../themes/softed/images/close.gif" style="cursor: pointer;" title="关闭"> </img>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table align="center" border="0" cellpadding="5" cellspacing="0" width="95%">
                                                    <tr>
                                                        <td class="small">
                                                            <!-- popup specific content fill in starts -->
                                                            <table align="center" bgcolor="white" border="0" cellpadding="5" celspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="right" width="50%"><b>转移拥有关系:</b> </td>
                                                                    <td width="50%">
                                                                        <asp:DropDownList ID="Ddl_DutyPerson" runat="server" class="detailedViewTextBox">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="5" cellspacing="0" class="layerPopupTransport" width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <input class="crmbutton small edit" name="button" onclick="ajaxChangeStatus('owner')" type="button" value="更新负责人">
                                                                <input class="crmbutton small cancel" name="button" onclick="fninvsh('changeowner')" type="button" value="取消"> </input>
                                                            </input>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CssClass="Custom_DgMain" EmptyDataText="&lt;div align=center&gt;&lt;font color=red&gt;&lt;br/&gt;&lt;br/&gt;&lt;B&gt;没有找到相关记录&lt;/B&gt;&lt;br/&gt;&lt;br/&gt;&lt;/font&gt;&lt;/div&gt;" IsShowEmptyTemplate="true" PageSize="10" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <input onclick="selectAll(this)" type="CheckBox"> </input>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Chbk" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="出库单号" SortExpression="DirectOutNo">
                                                        <ItemTemplate>
                                                            <a href='Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>' target="_self"><%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="通知单号" SortExpression="KWD_ShipNo">
                                                        <ItemTemplate>
                                                            <a href='../SalesShip/Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo")%>' target="_self"><%# DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString()%></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="发货类型" SortExpression="KWD_Custmoer">
                                                        <ItemTemplate>
                                                            <%# GetShipType(DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString(),DataBinder.Eval(Container.DataItem, "KWD_Type").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="结算单位" SortExpression="KWD_Custmoer">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" HeaderText="产品版本" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetShipDetailProductsPatten(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString(),false)%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" HeaderText="数量" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# GetTotalNumber(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString(), "0")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" HeaderText="备品" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <%# GetTotalNumber(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString(), "1")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="KWD_CWOutTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="出库日期" SortExpression="KWD_CWOutTime">
                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="仓库" ItemStyle-Width="50px" SortExpression="HouseNo">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="出库人" SortExpression="DirectOutStaffBranch">
                                                        <ItemTemplate>
                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DirectOutStaffNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" HeaderText="物流部" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <%# GetDirectOutListfollowup( DataBinder.Eval(Container.DataItem, "DirectOutNo"), DataBinder.Eval(Container.DataItem, "DirectOutCheckYN"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" HeaderText="销售部" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px">
                                                        <ItemTemplate>
                                                            <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "KWD_ShipNo"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="Left" HeaderText="状态" ItemStyle-HorizontalAlign="Left" SortExpression="DirectOutNo">
                                                        <ItemTemplate>
                                                            <%# GetKDSateName(DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="center" HeaderText="审核" ItemStyle-HorizontalAlign="center" SortExpression="DirectOutCheckYN">
                                                        <ItemTemplate>
                                                            <%# GetOrderCheckYN(DataBinder.Eval(Container.DataItem, "DirectOutNo"))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Font-Size="12px" HeaderStyle-HorizontalAlign="center" HeaderText="出库单" ItemStyle-HorizontalAlign="center" SortExpression="DirectOutCheckYN">
                                                        <ItemTemplate>
                                                            <a href="#" onclick='Print(<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>)'>
                                                                <asp:Image ID="Image4" runat="server" border="0" ImageUrl="../../images/Print1.gif" ToolTip="查看发货详细信息" />
                                                            </a>(<%# DataBinder.Eval(Container.DataItem, "KWD_PrintNums")%>)
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="colHeader" />
                                                <RowStyle CssClass="listTableRow" />
                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                <PagerStyle CssClass="Custom_DgPage" />
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
