<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNetSamplingList.aspx.cs" Inherits="Web_Products_KNetSamplingList" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>样品领用</title>
</head>
<link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>

<script type="text/javascript">
    function GPrint(ID) {
        //window.open('Sales_ShipWareOut_Print_Cw.aspx?ID=' + ID, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500')
        var temp = window.showModalDialog("Procure_Xh_View.aspx?ID=" + ID + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        // window.location.reload(); 
    }
    function add()
    {
        var v_Type=document.all("Tbx_Type").value;
        PageGo('KNetSamplingListAdd.aspx?ID=');
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品 > <a class="hdrLink" href="KNetSamplingList.aspx">请购管理</a>
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
                                                        <a href="javascript:;" onclick="add()">
                                                            <img src="../../themes/softed/images/btnL3Add.gif" alt="*创建 样品领用" title="*创建 样品领用"
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px;">
                                                        <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../themes/softed/images/btnL3Delete.gif"
                                                            OnClick="Btn_Del_Click" />
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 样品领用..." title="查找 样品领用..."
                                                                border="0"></a>
                                                    </td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 样品领用" title="*导入 样品领用"
                                                            border="0">
                                                    </td>
                                                    <td style="padding-right: 10px">
                                                        <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 样品领用" title="*导出 样品领用"
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
                    <%=base.Base_BindView("KNetSamplingList.aspx", "KNetSamplingList.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("Sc_Products_MakeMoney")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                            <td style="padding-right: 20px" align="left" nowrap>制单人:
                               <asp:DropDownList runat="server" ID="Ddl_StaffNo" AutoPostBack="true" OnSelectedIndexChanged="Ddl_StaffNo_OnSelectedIndexChanged"></asp:DropDownList>
                                项目组:
                                <asp:DropDownList runat="server" ID="Ddl_GroupType" AutoPostBack="true" OnSelectedIndexChanged="Ddl_GroupType_OnSelectedIndexChanged"></asp:DropDownList>
                                <asp:TextBox runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
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
                                    AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="8"
                                    BorderColor="#4974C2"
                                    EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                    OnRowDataBound="GridView1_DataRowBinding">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chbk" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="请购单号" SortExpression="ID" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>

                                                <a href="KNetSamplingListAdd.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID") %>" target="_blank"><%# DataBinder.Eval(Container.DataItem, "ID").ToString()%></a>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="项目组" SortExpression="ID" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# Base_GetProjectGroup(DataBinder.Eval(Container.DataItem, "ID").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="样品名称" SortExpression="ID" HeaderStyle-Font-Size="12px" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# Base_GetSamplingName(DataBinder.Eval(Container.DataItem, "ID").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="申请数量" HeaderStyle-Font-Size="12px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# Base_GetSamplingNumber(DataBinder.Eval(Container.DataItem, "ID").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="物品单价" HeaderStyle-Font-Size="12px" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# Base_GetSamplingPrice(DataBinder.Eval(Container.DataItem, "ID").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="申请时间" HeaderStyle-Font-Size="12px" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# Base_GetSamplingTime( DataBinder.Eval(Container.DataItem, "ID").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="申请人" SortExpression="ID" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px"
                                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%#  Base_GetProposer(DataBinder.Eval(Container.DataItem, "ID").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="采购状态" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center">
                                                     <ItemTemplate>
                                                     <%# GetBuyStateYN(DataBinder.Eval(Container.DataItem, "ID").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="入库状态" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# GetInState(DataBinder.Eval(Container.DataItem, "ID").ToString()) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="审核状态" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# GetAuditState( DataBinder.Eval(Container.DataItem, "ID").ToString())%>
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
    </form>

    <script type="text/javascript" language="javascript">
      
        $(document).ready(function() {
            //$(docment).on('click','.deleteE', fn())
            $(document).on('click','.UpdateAudit',function() {

                debugger;
                alert($(this).attr("id"));
                $.ajax({

                    type: "POST",
                    url:"ProductsHandler.ashx",
                    data: {
                        deletenum: $(this).attr("id"),
                        action: "UpdateAudit"

                    },
                    success: function(mes) {
                        alert('删除成功');
                        history.go(0);
                    }
                })
            })
        })
        //console.log($(".deleteExpend"));
       

    </script>

</body>
</html>

