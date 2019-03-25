<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Knet_Sales_Ship_Manage_Manage.aspx.cs"
    Inherits="Knet_Sales_Ship_Manage_Manage" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title>发货通知信息</title>
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script>
        function changsheng(va) {
            if (va != '0') {
                var city = document.getElementById("city");
                city.disabled = false;
                var url = "../Web/Js/Handler.ashx?type=sheng&id=" + va;
                send_request("GET", url, null, "text", populateClass3);
            }
        }
        function populateClass3() {
            var f = document.getElementById("city");
            if (http_request.readyState == 4) {
                if (http_request.status == 200) {
                    var list = http_request.responseText;
                    var classList = list.split("|");
                    f.options.length = 1;
                    for (var i = 0; i < classList.length; i++) {
                        var tmp = classList[i].split(",");
                        f.add(new Option(tmp[1], tmp[0]));
                    }
                } else {
                    alert("您所请求的页面有异常。");
                }
            }
        }
    </script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div id="ssdd" style="padding: 1px">
        </div>

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>发货通知信息 > <a class="hdrLink" href="Knet_Sales_Ship_Manage_Manage.aspx">发货通知信息</a>
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
                                                        <a href="javascript:;" onclick="PageGo('Knet_Sales_Ship_Manage_Add.aspx')">
                                                            <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 发货通知信息..." title="创建 发货通知信息..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px;">
                                                        <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../themes/softed/images/btnL3Delete.gif"
                                                            OnClick="Btn_Del_Click" />
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 发货通知信息..." title="查找 发货通知信息..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 发货通知信息..." title="*导入 发货通知信息"
                                                            border="0">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 发货通知信息..." title="*导出 发货通知信息"
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
                <div style="text-align:center">
                    <asp:Image runat="server" ID="Imag_Load" ImageUrl="../images/loading.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <%=base.Base_BindView("KNet_Sales_OutWareList", "Knet_Sales_Ship_Manage_Manage.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                                            <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("KNet_Sales_OutWareList")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                                    <td style="padding-right: 20px" align="left" nowrap>查看范围:<asp:DropDownList runat="server" ID="Ddl_Batch" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged1">
                                    </asp:DropDownList>
                                        <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');"
                                            onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                                        <img border="0" src="../../themes/images/collapse.gif">
                                        <div id="selectoperate" class="drop_mnu" onmouseout="fnHideDrop('selectoperate')"
                                            onmouseover="fnShowDrop('selectoperate')">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <a href="#" onclick="javascript:return quick_edit(this, 'quickedit', 'Accounts');"
                                                            class="drop_down">批量修改</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="#" onclick="javascript:return change(this,'changeowner');" class="drop_down">修改负责人</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="#" class="drop_down">共享</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton runat="server" ID="lbtn_Del" class="drop_down" OnClick="lbtn_Del_Click">批量删除</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="#" class="drop_down">批量发短信</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <a href="#" class="drop_down">批量发邮件</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="changeowner" class="layerPopup" style="display: none; width: 325px;">
                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
                                                <tr>
                                                    <td class="layerPopupHeading" align="left" width="60%">修改负责人
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td align="right" width="40%">
                                                        <img onclick="fninvsh('changeowner');" title="关闭" alt="关闭" style="cursor: pointer;"
                                                            src="../../themes/softed/images/close.gif" align="absmiddle" border="0">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0" cellspacing="0" cellpadding="5" width="95%" align="center">
                                                <tr>
                                                    <td class="small">
                                                        <!-- popup specific content fill in starts -->
                                                        <table border="0" celspacing="0" cellpadding="5" width="100%" align="center" bgcolor="white">
                                                            <tr>
                                                                <td width="50%" align="right">
                                                                    <b>转移拥有关系:</b>
                                                                </td>
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
                                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                            IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="8" Width="100%"
                                            OnRowDataBound="GridView1_DataRowBinding">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                    <HeaderTemplate>
                                                        <input type="CheckBox" onclick="selectAll(this)" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chbk" runat="server"></asp:CheckBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="发货单号" SortExpression="OutWareNo" HeaderStyle-Font-Size="12px"
                                                    ItemStyle-Width="28px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <a href="Knet_Sales_Ship_Manage_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>"
                                                            target="_self">
                                                            <%# DataBinder.Eval(Container.DataItem, "OutWareNo").ToString()%></a>
                                                        <asp:TextBox runat="server" ID="ContractNo" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>'> </asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="发货日期" DataField="OutWareDateTime" SortExpression="OutWareDateTime"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="预到日期" DataField="KSO_PlanOutWareDateTime" SortExpression="KSO_PlanOutWareDateTime"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="出库日期" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# GetCk(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="客户名称" SortExpression="CustomerValue" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString(),true)%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-Width="170px"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetOutWareProductsPatten(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem, "VO_ShipNumber").ToString()%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="已发" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="../SalesShip/Knet_Sales_Ship_Manage_View.aspx?Type=1&ID=<%# DataBinder.Eval(Container.DataItem, "OutWareNo").ToString()%>"
                                                            target="_blank">
                                                            <%# DataBinder.Eval(Container.DataItem, "vo_OutNumber").ToString()%></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="类型" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("145",DataBinder.Eval(Container.DataItem, "KSO_Type").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="物流部" HeaderStyle-Font-Size="12px" ItemStyle-Width="150px"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# GetDirectOutListfollowup(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="销售部" HeaderStyle-Font-Size="12px" ItemStyle-Width="120px"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="状态" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.GetKDSateName(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="发货" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="center"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# GetFhState(DataBinder.Eval(Container.DataItem, "Vo_OutState").ToString(),DataBinder.Eval(Container.DataItem, "OutWareNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="应收款" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="center"
                                                    HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# GetYsString(DataBinder.Eval(Container.DataItem, "OutWareNo").ToString(), DataBinder.Eval(Container.DataItem, "v_State").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-Width="28px"
                                                    ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <a href="#" onclick="javascript:window.open('Knet_Sales_Ship_Manage_Print.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OutWareNo")%>&PrinterModel=128900331899375001','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');">
                                                            <asp:Image ID="Image3" runat="server" ImageUrl="../../images/View.gif" border="0"
                                                                ToolTip="查看发货详细信息" /></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="审核" SortExpression="OutWareCheckYN" HeaderStyle-Font-Size="12px"
                                                    ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# GetBaoPriceCheckYN(DataBinder.Eval(Container.DataItem, "OutWareNo"))%>
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
            </ContentTemplate>
        </asp:UpdatePanel>
        
    </form>
</body>
</html>
