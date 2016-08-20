<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Accounting_List.aspx.cs"
    Inherits="Cw_Accounting_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title></title>
</head>
<script type="text/javascript" src="/Web/js/ajax_func.js"></script>
<script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
<script>
    function displaycondtype_click(obj) {
        var condtype_div = document.getElementById('condtype_div');
        condtype_div.style.display = (condtype_div.style.display == 'none') ? '' : 'none';
    }
    function setcondtype_click(objid, objname) {
        document.getElementById('setcondtype').innerHTML = objname + "&nbsp;&nbsp;<img border=0 src='/themes/softed/images/arrow_down.gif'>";
        document.getElementById('condtype_div').style.display = 'none';
        setreset();
    }
    function setreset() {
        document.getElementById("searchValue_div").innerHTML = '';
        document.all('Tbx_CustomerValue').value = "";
        document.all('Tbx_CustomerName').value = "";
    }
    function openCondtype_click() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = "";
        if (document.getElementById('setcondtype').innerHTML.indexOf("户") > 0) {
            tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
        }
        else {
            tempd = window.showModalDialog("/Web/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
        }
        if (tempd == undefined) {
            tempd = window.returnValue;
        }
        if (tempd != undefined) {
            var ss;
            if (document.getElementById('setcondtype').innerHTML.indexOf("户") > 0) {
                ss = tempd.split("#");
            }
            else {
                ss = tempd.split("|");
            }
            document.all('Tbx_CustomerValue').value = ss[0];
            document.all('Tbx_CustomerName').value = ss[1];

        }
        else {
            document.all('Tbx_CustomerValue').value = "";
            document.all('Tbx_CustomerName').value = "";
        }
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                往来帐 > <a class="hdrLink" href="Cw_Accounting_Init_List.aspx">往来帐</a>
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
                                                    <a href="javascript:;" onclick="PageGo('Cw_Accounting_Init_Add.aspx')">
                                                        <img src="/themes/softed/images/btnL3Add.gif" alt="创建 往来帐..." title="创建 往来帐..."
                                                            border="0"></a>
                                                </td>
                                                <td style="padding-right: 0px;">
                                                    <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="/themes/softed/images/btnL3Delete.gif"
                                                        OnClick="Btn_Del_Click" />
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <a href="javascript:;" onclick="ShowDiv()">
                                                        <img src="/themes/softed/images/btnL3Search.gif" alt="查找 往来帐..." title="查找 往来帐..."
                                                            border="0"></a>
                                                </td>
                                                <td style="padding-right: 0px; padding-left: 10px;">
                                                    <img src="/themes/softed/images/tbarImport.gif" alt="*导入 往来帐" title="*导入 往来帐"
                                                        border="0">
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <img src="/themes/softed/images/tbarExport.gif" alt="*导出 往来帐" title="*导出 往来帐"
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
        <tr>
            <td>
                <%=base.Base_BindView("Cw_Accounting_Init", "Cw_Accounting_Init_List.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
            </td>
            <tr>
                <td>
                    <table width="100%" cellpadding="3" cellspacing="0" class="list_table searchUIBasic"
                        align="center" border="0">
                        <tr>
                            <td class="searchUIName small" nowrap align="left">
                                <span class="moduleName">查找</span><br>
                            </td>
                            <td nowrap="nowrap">
                                <input type="hidden" name="condtype" value="account_id" />
                                <a href="" onclick="displaycondtype_click(this);return false;" id="setcondtype" title="变更查询类型">
                                    客户&nbsp;&nbsp;<img border="0" src='/themes/softed/images/arrow_down.gif'>
                                </a>&nbsp;
                                <div style="position: absolute; z-index: 1px; border: 1px #B3B3B3 solid; background-color: #FFF;
                                    display: none; width: 80px; margin-top: 5px;" id="condtype_div">
                                    <div style="padding: 5px; cursor: pointer;" onmouseover="this.className='lvtColDataHover'"
                                        onmouseout="this.className='lvtColData'" onclick="setcondtype_click('account_id','客户');">
                                        客户</div>
                                    <div style="padding: 5px; cursor: pointer;" onmouseover="this.className='lvtColDataHover'"
                                        onmouseout="this.className='lvtColData'" onclick="setcondtype_click('vendor_id','供应商');">
                                        供应商</div>
                                </div>
                            </td>
                            <td nowrap="nowrap">
                                <pc:PTextBox runat="server" ID="Tbx_CustomerName" CssClass="detailedViewTextBox"
                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                    Width="280px"></pc:PTextBox>
                                <pc:PTextBox runat="server" ID="Tbx_CustomerValue" CssClass="Custom_Hidden" Width="0px"></pc:PTextBox>
                                <img align="absmiddle" style="cursor: hand; cursor: pointer" language="javascript"
                                    title="选择" alt="选择" src="/themes/softed/images/select.gif" onclick="openCondtype_click();">
                                <div id="searchValue_div" style="position: absolute; z-index: 1px; border: 1px #B3B3B3 solid;
                                    background-color: #FFF; margin-top: 5px;">
                                </div>
                                <input type="hidden" name="vendor_name" /><input type="hidden" name="vendor_id" value="" />
                                <input type="hidden" name="account_name" id="account_name" />
                                <input type="hidden" name="account_id" id="account_id" value="" />
                            </td>
                            <td nowrap="nowrap">
                                <b>时间</b>
                            </td>
                            <td nowrap="nowrap">
                                <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox
                                    ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                            </td>
                            <td nowrap="nowrap">
                                <b>负责人</b>
                            </td>
                            <td nowrap="nowrap">
                            
                                                    <asp:DropDownList runat="server" ID="Ddl_DutyPerson">
                                                    </asp:DropDownList>
                                       </td>
                            <td nowrap="nowrap" style="display: none;">
                                <input type="hidden" name="amountsearch" value="" />
                                <b><a href="" onclick="displayamount_click(this);return false;" id="setamounttype"
                                    title="变更查询类型">&nbsp;&nbsp;<img border="0" src='/themes/softed/images/arrow_down.gif'>
                                </a></b>&nbsp;
                                <div style="position: absolute; z-index: 1px; border: 1px #B3B3B3 solid; background-color: #FFF;
                                    display: none; width: 80px; margin-top: 5px;" id="amounttype_div">
                                </div>
                                <input type="text" name="firstprict" id="firstprict" class="small detailedViewTextBox"
                                    style="width: 60px; padding-left: 1px;" value="" onkeydown="searchsubmit_keydown(event);" />
                                --
                                <input type="text" name="lastprict" id="lastprict" class="small detailedViewTextBox"
                                    style="width: 60px; padding-left: 1px;" value="" onkeydown="searchsubmit_keydown(event);" />
                            </td>
                            <td class="small" nowrap width="40%">
                                <asp:Button ID="Button1" runat="server" Text="查 询" AccessKey="F" title="查 询 [Alt+F]"
                                    class="crmbutton small create" OnClick="Btn_Q_Click" />&nbsp;
                                <input type="button" class="crmbutton small save" onclick="export_click('');" value=" 导 出 ">&nbsp;
                                <a target="_blank" style="text-decoration: none;" id="forthprint" onclick="print_click();">
                                    <input type="button" class="crmbutton small cancel" value=" 打 印 ">
                                </a>&nbsp;&nbsp;&nbsp;&nbsp;
                                <input type="button" class="crmbutton small save" onclick="OpenBulkCheckout_click();"
                                    value=" 批量结帐 ">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
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
                                <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Cw_Accounting_Init")%>','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                <hr />
                <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                PageSize="30" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="编号" SortExpression="Code" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%#GetCode(DataBinder.Eval(Container.DataItem, "Code").ToString(),DataBinder.Eval(Container.DataItem, "CType").ToString(),DataBinder.Eval(Container.DataItem, "ID").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="摘要" DataField="Type" SortExpression="Type" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="日期" DataField="Stime" SortExpression="Stime" DataFormatString="{0:yyyy-MM-dd}"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="产品名称" SortExpression="ProductsBarCode" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# base.Base_GetProdutsName(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="版本号" SortExpression="ProductsBarCode" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="数量" DataField="Number" SortExpression="Number" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="单价" DataField="Price" SortExpression="Price" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="金额" DataField="Money" SortExpression="Money" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="负责人" SortExpression="CAP_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "CAP_DutyPerson").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="应收金额" DataField="Money" SortExpression="Money" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="开票金额" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# GetKpMoney(DataBinder.Eval(Container.DataItem, "DetailsID").ToString(), 0, DataBinder.Eval(Container.DataItem, "CType").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="开票单号" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# GetKpMoney(DataBinder.Eval(Container.DataItem, "DetailsID").ToString(), 1, DataBinder.Eval(Container.DataItem, "CType").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="帐期内金额" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# GetKpMoney(DataBinder.Eval(Container.DataItem, "DetailsID").ToString(), 2, DataBinder.Eval(Container.DataItem, "CType").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="今天到期金额" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# GetKpMoney(DataBinder.Eval(Container.DataItem, "DetailsID").ToString(), 3, DataBinder.Eval(Container.DataItem, "CType").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="超期金额" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# GetKpMoney(DataBinder.Eval(Container.DataItem, "DetailsID").ToString(), 4, DataBinder.Eval(Container.DataItem, "CType").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="超期明细" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center">
                                        <ItemTemplate>
                                            <%# GetKpMoney(DataBinder.Eval(Container.DataItem, "DetailsID").ToString(), 5, DataBinder.Eval(Container.DataItem, "CType").ToString())%>
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
                <!--底部功能栏-->
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
