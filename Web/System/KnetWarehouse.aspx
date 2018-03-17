<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="KnetWarehouse.aspx.cs" Inherits="Knet_Web_System_KnetWarehouse" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<title>仓库设置管理</title>
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
                仓库管理 > <a class="hdrLink" href="KnetWarehouse.aspx">仓库管理</a>
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
                                                    <a href="javascript:;" onclick="PageGo('KnetWarehouse_Add.aspx')">
                                                        <img src="../../themes/softed/images/btnL3Add.gif" alt="创建 仓库信息..." title="创建 仓库信息..."
                                                            border="0"></a>
                                                </td>
                                                <td style="padding-right: 0px;">
                                                    <asp:ImageButton runat="server" ID="Btn_Del" ImageUrl="../../themes/softed/images/btnL3Delete.gif"
                                                       />
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <a href="javascript:;" onclick="ShowDiv();">
                                                        <img src="../../themes/softed/images/btnL3Search.gif" alt="查找 仓库信息..." title="查找 仓库信息..."
                                                            border="0"></a>
                                                </td>
                                                <td style="padding-right: 0px; padding-left: 10px;">
                                                    <img src="../../themes/softed/images/tbarImport.gif" alt="*导入 仓库信息" title="*导入 仓库信息"
                                                        border="0">
                                                </td>
                                                <td style="padding-right: 10px">
                                                    <img src="../../themes/softed/images/tbarExport.gif" alt="*导出 仓库信息" title="*导出 仓库信息"
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
    
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <%=base.Base_BindView("KNet_Sys_WareHouse", "KnetWarehouse.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
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
                                <input type="button" name="more" value=" 增加条件 " onclick="fnAddSrch('<%=Base_GetBindSearch("KNet_Sales_OutWareList")%>','<option value=\'cts\'>包含</option><option value=\'dcts\'>不包含</option><option value=\'is\'>等于</option><option value=\'isn\'>不等于</option><option value=\'bwt\'>开始为</option><option value=\'grt\'>大于</option><option value=\'lst\'>小于</option><option value=\'grteq\'>大于等于</option><option value=\'lsteq\'>小于等于</option>')"
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
                        <td>
                            <div id="changeowner" class="layerPopup" style="display: none; width: 325px;">
                                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="layerHeadingULine">
                                    <tr>
                                        <td class="layerPopupHeading" align="left" width="60%">
                                            修改负责人
                                        </td>
                                        <td>
                                            &nbsp;
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
                            
        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" PageSize="10"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
          OnRowDataBound="GridView1_DataRowBinding"  OnRowDeleting="GridView1_del">
        <Columns>
        
        
        <asp:TemplateField ItemStyle-Width="4%" HeaderText="状态" ItemStyle-Height="25px"  HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                 <ItemTemplate>
                   <asp:Image ID="Image1" runat="server" /><asp:Label ID="StateLabel" runat="server" Text='<%# Eval("HouseYN") %>' Visible="false" ></asp:Label>
                 </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:BoundField  DataField="HouseName"  HeaderText="仓库名称" ControlStyle-CssClass="Boxx" ControlStyle-Width="120px" SortExpression="HouseName">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="HouseTel"   HeaderText="联系电话" ControlStyle-CssClass="Boxx" ControlStyle-Width="90px" SortExpression="HouseTel">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="HouseMan"   HeaderText="联系人" ControlStyle-CssClass="Boxx" ControlStyle-Width="80px" SortExpression="HouseMan">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="HouseAddress"   HeaderText="仓库地址" ControlStyle-CssClass="Boxx" ControlStyle-Width="150px" SortExpression="HouseAddress">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="HouseRemark"   HeaderText="备注说明" ControlStyle-CssClass="Boxx" SortExpression="HouseRemark">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:TemplateField HeaderText="供应商名称"  SortExpression="SuppNo" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="类型"  SortExpression="KSW_Type" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("218", DataBinder.Eval(Container.DataItem, "KSW_Type").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField   HeaderText="建库日期"  DataField="HouseDate"  SortExpression="HouseDate"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  Width="70px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="调回"  SortExpression="KSW_Type" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
              <a href="/Web/WareHouseAllocateList/KNet_WareHouse_AllocateList_Add.aspx?HosueNo=<%# Eval("HouseNO") %>" target="_blank" class="webMnu">原材料调回</a> 
          </ItemTemplate>
        </asp:TemplateField>
        
        
        <asp:HyperLinkField  ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px"  ItemStyle-Width="30px" HeaderStyle-HorizontalAlign="Left"  DataNavigateUrlFields="HouseNo"   DataNavigateUrlFormatString="KnetWarehouse_Add.aspx?ID={0}"   Text="修改"  HeaderText="修改"/>
        
        <asp:CommandField  ShowDeleteButton="True"   HeaderText="删除"  DeleteText="删除">
            <ItemStyle HorizontalAlign="Left" Width="30px" Font-Size="12px"/>
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

<table width="100%" border="0" align="center"   cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td  align="left" height="28px">&nbsp;&nbsp;&nbsp;<img src="../../images/Au1.gif" />表示仓库 <B>开库</B> 中，可以进出货..&nbsp;&nbsp;<img src="../../images/Au2.gif" />表示仓库 <B>关库</B> 中，不可以进出货，只能查看记录。</td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>
