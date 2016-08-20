<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SelectContractList.aspx.cs"
    Inherits="Knet_SelectContractList" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" >
    function set_return(ContractNo) {
        if (window.opener != undefined) {
            window.opener.returnValue = ContractNo;
        }
        else {
            window.returnValue = ContractNo;
        }
    }
</script>
    <title></title>
    <base runat="server" />
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    订单评审 > <a class="hdrLink" href="SelectContractList.aspx">订单评审</a>
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
                                                        <a href="javascript:;" onclick="PageGo('KNet_Sales_ContractList_Add.aspx')">
                                                            <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 订单评审..." title="创建 订单评审..."
                                                                border="0" /></a></td>
                                                    <td style="padding-right: 0px;">
                                                        <asp:ImageButton ImageUrl="../../themes/softed/images/btnL3Delete.gif" runat="server"
                                                            ID="Btn_Del" OnClick="Button1_Click"  /></td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv()">
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 订单评审..." title="查找 订单评审..."
                                                                border="0" /></a></td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 订单评审" title="*导入 订单评审"
                                                            border="0" /></td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 订单评审" title="*导出 订单评审"
                                                            border="0" /></td>
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
        	<table border=0 cellspacing=1 cellpadding=0 width=100% class="lvtBg">
				<tr>
				<td>
        <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
            <tr>
                <td>
                    <%=base.Base_BindView("KNet_Sales_ContractList", "SelectContractList.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                                        value=" 取消查找 "/>&nbsp;
                                </td>
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="ShowDiv()">
                                    [x]</td>
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
                                <td class="small" valign="top" onmouseover="this.style.cursor='pointer';" onclick="fnshow()">
                                    [x]</td>
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
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Xs_Sales_Quotes")%>','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
                                        class="crmbuttom small edit">
                                    <input name="button" type="button" value=" 删除条件 " onclick="delRow()" class="crmbuttom small edit">
                                </td>
                                <td align="left" class="small">
                                    <asp:Button ID="btnAdvancedSearch" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small create" OnClick="btnAdvancedSearch_Click" />&nbsp;
                                    <input type="button" class="crmbutton small edit" value=" 取消查找 " onclick="fnshow();" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <!-- Buttons -->
                <td style="padding-right: 20px" align="left" nowrap>
                    查看范围:<asp:DropDownList runat="server" ID="Ddl_Batch" AutoPostBack="True" OnTextChanged="Ddl_Batch_TextChanged">
                    </asp:DropDownList>
                    <a id="moreoperate" href="" target="main" onmouseover="BatchfnDropDown(this,'selectoperate');"
                        onmouseout="fnHideDrop('selectoperate');" onclick="return false;">批量操作</a>
                    <img border="0" src="../../themes/images/collapse.gif" />
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
                                    <a href="#" class="drop_down">共享</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <!--GridView-->
                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        IsShowEmptyTemplate="true" EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                        AutoGenerateColumns="False" PageSize="10" Width="100%" OnRowDataBound="GridView1_DataRowBinding">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="left">
                                <headertemplate>
                 <input type="CheckBox" onclick="selectAll(this)"/>
                 </headertemplate>
                                <itemtemplate>
                     <asp:CheckBox ID="Chbk" runat="server"  />
                 </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="合同编号" SortExpression="ContractNo" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <itemtemplate>
               <%# GetLink(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                          </itemtemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="签订日期" DataField="ContractDateTime" 
                                SortExpression="ContractDateTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                <itemstyle horizontalalign="Left" font-size="12px" />
                                <headerstyle horizontalalign="Left" font-size="12px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="交货日期" DataField="ContractToDeliDate" 
                                SortExpression="ContractToDeliDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                <itemstyle horizontalalign="Left" font-size="12px" />
                                <headerstyle horizontalalign="Left" font-size="12px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="客户名称" SortExpression="CustomerValue" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <itemtemplate>
                                     <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="责任人" SortExpression="ContractStaffNo" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <itemtemplate>
                                       <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
                                  </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="合同分类" SortExpression="ContractClass" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <itemtemplate>
                                   <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "ContractClass").ToString())%>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="产品类型" SortExpression="OrderStaffBranch" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <itemtemplate>
                                   <%# base.Base_GetContractProductsPatten(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="操作日期" DataField="SystemDateTimes" SortExpression="SystemDateTimes"
                                HtmlEncode="false">
                                <itemstyle horizontalalign="Left" font-size="12px" />
                                <headerstyle horizontalalign="Left" font-size="12px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-Width="28px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <itemtemplate>
                                   <a href="#"  onclick="javascript:window.open('../SalesContract/KNet_Sales_ContractList_Manage_PrinterListSettingPrinterPage.aspx?ContractNo=<%# DataBinder.Eval(Container.DataItem, "ContractNo")%>&PrinterModel=128898695453437500','查看详细','top=120,left=150,menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=700,height=450');"><asp:Image ID="Image2" runat="server"  ImageUrl="../../images/View.gif" border=0  ToolTip="查看合同详细信息" /></a>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改" HeaderStyle-Font-Size="12px" ItemStyle-Width="28px"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <itemtemplate>
                                    <%# GetUpdate(DataBinder.Eval(Container.DataItem, "ContractNo").ToString(), DataBinder.Eval(Container.DataItem, "contractStaffNo").ToString())%>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="审核" SortExpression="ContractCheckYN" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                <itemtemplate>
                                   <%# GetBaoPriceCheckYN(DataBinder.Eval(Container.DataItem, "ContractNo"))%>
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="状态" SortExpression="ContractCheckYN" HeaderStyle-Font-Size="12px"
                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                <itemtemplate>
                                   <%# base.GetContractState(DataBinder.Eval(Container.DataItem, "ContractNo").ToString())%>
                                </itemtemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass='colHeader' />
                        <RowStyle CssClass='listTableRow' />
                        <AlternatingRowStyle BackColor="#E3EAF2" />
                        <PagerStyle CssClass='Custom_DgPage' />
                    </cc1:MyGridView>
                    <!--GridView-->
                    <!--分页-->
                    <!--底部功能栏-->
                </td>
            </tr>
        </table>
        </td>
        </tr>
        </table>
    </form>
</body>
</html>
