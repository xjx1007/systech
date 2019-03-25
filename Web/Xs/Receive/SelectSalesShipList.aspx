<%@ Page Language="C#" AutoEventWireup="true"   CodeFile="SelectSalesShipList.aspx.cs" Inherits="Knet_Common_SelectSalesShipList" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
<script type="text/javascript" src="../../js/ajax_func.js"></script>
<script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="../../KDialog/lhgdialog.js"></script>
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }  
</script> 
<title>选择出库单</title>
<base target="_self" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    应付款计划 > 
                            选择出库记录</a>
                </td>
                <td width="100%" nowrap>
                </td>
            </tr>
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
        </table>
                        <hr noshade size="1">
    
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
 
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
          客户名称：<asp:Label runat="server" ID="Tbx_Customer"></asp:Label>
          <hr />
                    <tr>
                        <td>
                            <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关采购单记录</B><br/><br/></font></div>"
                                AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%" >
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input type="CheckBox" onclick="selectAll(this)" Checked />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chbk" runat="server" Checked />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="出库单号" SortExpression="KWD_Custmoer">
                                        <ItemTemplate>
                                            <a href="../SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>"
                                                target="_self">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
               <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="数量" DataField="DirectOutAmount"
                                            SortExpression="DirectOutAmount">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="单价" DataField="KWD_SalesUnitPrice"
                                            SortExpression="KWD_SalesUnitPrice">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="未应收数量" DataField="v_leftNumber"
                                            SortExpression="v_leftNumber">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="金额" DataField="Money"
                                            SortExpression="Money">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                            SortExpression="DirectOutDateTime">
                                            <itemstyle horizontalalign="Left" font-size="12px" />
                                            <headerstyle horizontalalign="Left" font-size="12px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="出库仓库" SortExpression="HouseNo">
                                            <itemtemplate>
               <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="出库人" SortExpression="DirectOutStaffBranch">
                                            <itemtemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DirectOutStaffNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="快递"  HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
           <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem,"KWD_ShipNo"),DataBinder.Eval(Container.DataItem, "DirectOutNo"))%>
          </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态" SortExpression="DirectOutNo" HeaderStyle-Font-Size="12px"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                            <itemtemplate>
           <%# GetKDSateName(DataBinder.Eval(Container.DataItem, "KWD_ShipNo").ToString())%>
          </itemtemplate>
                                        </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass='colHeader' />
                                <RowStyle CssClass='listTableRow' />
                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
                        </td>
                    </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    &nbsp;
                                    <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="确定" AccessKey="S" title="确定 [Alt+S]"
                                        class="crmbutton small save" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                                    <input title="关闭 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.close()"
                                        type="button" name="button" value="  关闭  " >
                                </td>
                            </tr>
                </table>
                <!--分页-->
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
