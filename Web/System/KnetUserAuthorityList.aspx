<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KnetUserAuthorityList.aspx.cs" Inherits="Knet_Web_System_KnetKnetUserAuthorityList" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
    <title>用户权限</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">


        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>系统 > <a class="hdrLink" href="KnetUserAuthorityList.aspx">用户权限</a>
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
                                                    <td style="padding-right: 0px;"></td>
                                                    <td style="padding-right: 10px">
                                                        <a href="javascript:;" onclick="ShowDiv();">
                                                            <img src="/themes/softed/images/btnL3Search.gif" alt="查找 用户组权限..." title="查找 用户组权限..."
                                                                border="0"></a></td>
                                                    <td style="padding-right: 0px; padding-left: 10px;">
                                                        <img src="/themes/softed/images/tbarImport.gif" alt="*导入 用户组权限" title="*导入 用户组权限"
                                                            border="0"></td>
                                                    <td style="padding-right: 10px">
                                                        <img src="/themes/softed/images/tbarExport.gif" alt="*导出 用户组权限" title="*导出 用户组权限"
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
                    <%=base.Base_BindView("KNet_Sys_AuthorityUserGroup", "KnetUserGroup.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                                    <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("KNet_Sys_AuthorityUserGroup")%>    ','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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

                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                        <tr>
                            <td>
                                <!--GridView-->

                                <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" PageSize="10" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px"
                                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>

                                        <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" onclick="selectAll(this)" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chbk" runat="server" /><asp:Image ID="Image1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="StaffCard" HeaderText="员工卡号" SortExpression="StaffCard">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="100px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="StaffName" HeaderText="员工姓名" SortExpression="StaffName">
                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="80px" />
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                        </asp:BoundField>


                                        <asp:TemplateField HeaderText="所在部门" SortExpression="StaffDepart" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "StaffDepart").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="已分配用户组" SortExpression="StaffNo" ItemStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="12px">
                                            <ItemTemplate><%# GetKNet_Sys_WareHouseName(Eval("StaffNo").ToString())%></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="True" HeaderText="设置用户组" DeleteText="设置用户组">
                                            <ItemStyle HorizontalAlign="Left" Width="100px" Font-Size="12px" />
                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                        </asp:CommandField>

                                        <asp:CommandField ShowSelectButton="true" HeaderText="取消用户组" SelectText="取消用户组">
                                            <ItemStyle HorizontalAlign="Left" Width="100px" Font-Size="12px" />
                                            <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                        </asp:CommandField>

                                    </Columns>
                                    <HeaderStyle CssClass='colHeader' />
                                    <RowStyle CssClass='listTableRow' />
                                    <AlternatingRowStyle BackColor="#E3EAF2" />
                                    <PagerStyle CssClass='Custom_DgPage' />
                                </cc1:MyGridView>

                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                                    <tr>
                                        <td height="30" width="70%">
                                            <asp:Button ID="Button4" runat="server" CssClass="crmButton small create" Text="禁用所选项" OnClick="Button4_Click" />&nbsp;<asp:Button ID="Button6" runat="server" CssClass="crmButton small cancel" Text="取消禁用" OnClick="Button6_Click" />
                                            <asp:Button ID="Button5" runat="server" Text="取消选择" CssClass="crmButton small save" OnClick="Button5_Click" />&nbsp;&nbsp;<img src="../../images/Au1.gif" />表示用户正常&nbsp;&nbsp;<img src="../../images/Au2.gif" />表示用户被禁用&nbsp;</td>
                                        <td width="30%" align="right">
                                            <asp:DropDownList ID="StrucNameDList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StrucNameDList_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <div style="margin-top: 5px"></div>

        <table width="99%" id="Apant" runat="server" border="0" cellspacing="1" cellpadding="1" class="small" align="center">
            <tr>
                <td width="46%" height="47" valign="top">&nbsp;
      <asp:ListBox ID="AuthWareHouse1" runat="server" Width="300px" Height="150px" SelectionMode="Multiple"></asp:ListBox><br />
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="确定设置所属用户组" CssClass="crmButton small save" OnClick="Button1_Click" Style="width: 70px; height: 33px;" />&nbsp;&nbsp;<asp:Button
                        ID="Button2" runat="server" Text="放弃受权" CssClass="crmButton small cancel" Style="width: 70px; height: 33px;" OnClick="Button2_Click" /></td>
                <td width="54%" valign="top"><font color="#666666">给人员 <font color="red"><b>
                    <asp:Label ID="StaffNo1" runat="server" Text=""></asp:Label></b></font> 受权所属用户组。<br />
                    <br />
                    请在左边选择仓库，按Ctrl可多选。<br />
                    <br />
                    设置所属用户组后该员工就会拥有该用户组所有的操作权限。没有设置用户组的员工没有操作权限！<br />
                    <br />
                    设置用户组的目的就是分配给人员系统的操作权限。</font>
                    <asp:HiddenField ID="HiddenFieldStaffNo1" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
