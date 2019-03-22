<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZL_Complain_Manage_List.aspx.cs"
    Inherits="Web_Sales_ZL_Complain_Manage_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css"/>
    <title>客退/客诉</title>
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
    <div id="sharerecorddiv" runat="server" class="layerPopup" style="display: none;
        width: 250px;">
        <table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
            <tr>
                <td width="99%" style="cursor: move;" id="sharerecord_div_title" class="layerPopupHeading"
                    align="left">
                    共享
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
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                客退/客诉 > <a class="hdrLink" href="ZL_Complain_Manage_List.aspx">客退/客诉</a>
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
                                                    <a href="javascript:;" onclick="PageGo('/Web/SalesReturn/Knet_Sales_Retrun_Maintain.aspx')">
                                                        <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 客退/客诉..." title="创建 客退/客诉..."
                                                            border="0"></a>
                                                </td>
                                                <td style="padding-right: 0px;">
                                                    <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../themes/softed/images/btnL3Delete.gif"
                                                        OnClick="Btn_Del_Click" />
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <a href="javascript:;" onclick="ShowDiv()">
                                                        <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 客退/客诉..." title="查找 客退/客诉..."
                                                            border="0"></a>
                                                </td>
                                               
                                                <td style="padding-right: 0px; padding-left: 10px;">
                                                    <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 客退/客诉" title="*导入 客退/客诉"
                                                        border="0">
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 客退/客诉" title="*导出 客退/客诉"
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
    
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
        </tr>
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                    <tr>
                        <td>
                            <%=base.Base_BindViewByTitle("视图","Knet_Sales_Retrun_Maintain", "ZL_Complain_Manage_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString(),"and PBW_Order='0'")%>
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
                                                <input name="matchtype" id="matchtype1" type="radio" runat="server" value="all">&nbsp;匹配以下所有条件</b>
                                        </td>
                                        <td nowrap width="60%" class="small">
                                            <b>
                                                <input name="matchtype" id="matchtype2" type="radio" value="any" runat="server" checked>&nbsp;匹配以下任意条件</b>
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
                                            <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Knet_Sales_Retrun_Maintain")%>','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                        <td style="padding-right: 20px" align="left" nowrap>
                            选择类型:<asp:DropDownList runat="server" ID="Ddl_Type" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Supp_OnSelectedIndexChanged"></asp:DropDownList>
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
                                        <a href="#" onclick="javascript:return fnvshobj(this,'sharerecorddiv');" class="drop_down">
                                                共享</a>
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
                                AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%"  OnRowDataBound="GridView1_DataRowBinding">
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
                                    <asp:TemplateField HeaderText="单号" SortExpression="KSM_MID" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <a href="../SalesReturn/Knet_Sales_Retrun_Maintain.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KSM_MID") %>&&KSM_Type=<%# DataBinder.Eval(Container.DataItem, "KSM_Type") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "KSM_MID").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="类型" SortExpression="KSM_Type" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetBasicCodeName("213", DataBinder.Eval(Container.DataItem, "KSM_Type").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="紧急程度" SortExpression="KSM_Urgency" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetBasicCodeName("214", DataBinder.Eval(Container.DataItem, "KSM_Urgency").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发现时间" SortExpression="KSM_FindTime" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%#  DataBinder.Eval(Container.DataItem, "KSM_FindTime").ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户名称" SortExpression="KSM_SuppNo" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KSM_SuppNo").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="产品型号" SortExpression="KSM_MID" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# GetProductsEdition(DataBinder.Eval(Container.DataItem, "KSM_MID").ToString(),DataBinder.Eval(Container.DataItem, "KSM_Type").ToString(),DataBinder.Eval(Container.DataItem, "KSM_Product").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="操作时间" HeaderStyle-HorizontalAlign="center" SortExpression="KSM_KTime">
                                        <ItemTemplate>
                                            <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "KSM_KTime").ToString()).ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="维修结果" HeaderStyle-HorizontalAlign="center" SortExpression="KSM_WResult">
                                        <ItemTemplate>
                                          <%# base.Base_GetBasicCodeName("1143", DataBinder.Eval(Container.DataItem, "KSM_WResult").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="操作人" SortExpression="KSM_DutyMan" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSM_DutyMan").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="状态" SortExpression="KSM_State" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# GetDState(DataBinder.Eval(Container.DataItem, "KSM_State").ToString())%>
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
                    <%-- <tr>
                        <td>
                            <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
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
                                    <asp:TemplateField HeaderText="客诉单号" SortExpression="ZCM_Code" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <a href="ZL_Complain_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ZCM_ID") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "ZCM_Code").ToString()%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="类型" SortExpression="ZCM_Type" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetBasicCodeName("213", DataBinder.Eval(Container.DataItem, "ZCM_Type").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="紧急程度" SortExpression="ZCM_HurryState" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetBasicCodeName("214", DataBinder.Eval(Container.DataItem, "ZCM_HurryState").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="合同号" SortExpression="ZCM_TimeState" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetBasicCodeName("215", DataBinder.Eval(Container.DataItem, "ZCM_TimeState").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="客户名称" SortExpression="ZCM_CustomerValue" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "ZCM_CustomerValue").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="产品型号" SortExpression="ZCM_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "ZCM_DutyPerson").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="处理时间" HeaderStyle-HorizontalAlign="center" SortExpression="ZCM_CTime">
                                        <ItemTemplate>
                                            <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "ZCM_MTime").ToString()).ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="处理描述" HeaderStyle-HorizontalAlign="center" SortExpression="ZCM_CTime">
                                        <ItemTemplate>
                                            <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "ZCM_MTime").ToString()).ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="文件" HeaderStyle-HorizontalAlign="center" SortExpression="ZCM_CTime">
                                        <ItemTemplate>
                                            <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "ZCM_MTime").ToString()).ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="8D文件" HeaderStyle-HorizontalAlign="center" SortExpression="ZCM_CTime">
                                        <ItemTemplate>
                                            <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "ZCM_MTime").ToString()).ToString()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="处理人" SortExpression="ZCM_D1Leder" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# GetDState(DataBinder.Eval(Container.DataItem, "ZCM_D1Leder"), DataBinder.Eval(Container.DataItem, "ZCM_ID").ToString(), "D1")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="状态" SortExpression="ZCM_D2Finder" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# GetDState(DataBinder.Eval(Container.DataItem, "ZCM_D2Finder"), DataBinder.Eval(Container.DataItem, "ZCM_ID").ToString(), "D2")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <HeaderStyle CssClass='colHeader' />
                                <RowStyle CssClass='listTableRow' />
                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
                        </td>
                    </tr>--%>
                </table>
                <!--分页-->
                <!--底部功能栏-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
