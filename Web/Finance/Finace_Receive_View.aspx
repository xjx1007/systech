<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="Finace_Receive_View.aspx.cs" Inherits="Finace_Receive_View" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>应收款</title>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
</head>
<script language="javascript" type="text/javascript" src="../../Web/DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    应收款 > <a class="hdrLink" href="Finace_Receive_View.aspx">应收款</a>
                </td>
            </tr>

            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <%=base.Base_BindView("Finace_Receive_View", "Finace_Receive_View.aspx", Request.QueryString["WhereID"] == null ? "" : Request.QueryString["WhereID"].ToString())%>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                   
                        <tr>
                            <td>
                            <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">
                                                            时间:</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">
                                                            客户名称:</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox ID="Tbx_CustomName" runat="server" CssClass="detailedViewTextBox" Width="150"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                         <tr>
                                                        <td align="right" class="dvtCellLabel">
                                                            产品名称:</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox ID="Tbx_ProductsName" runat="server" CssClass="detailedViewTextBox" Width="150"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">
                                                            产品型号:</td>
                                                        <td class="dvtCellInfo" align="left">
                                                        <asp:TextBox ID="Tbx_Pattern" runat="server" CssClass="detailedViewTextBox" Width="150"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ></asp:TextBox>
                                                            </td>
                                                    </tr>
                                                         <tr>
                                                        <td  colspan="4"  align="center" >
                                                    <asp:Button ID="btnBasicSearch" runat="server" Text="立即查找" AccessKey="F" title="立即查找 [Alt+F]"
                                        class="crmbutton small create" OnClick="btnBasicSearch_Click" />
                                                            <input title="重置 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="PageGo('Finace_Receive_View.aspx')"
                                                                type="button" name="button" value=" 重置 " >
                                          </td>
                                                    </tr>
                                                    </table>
                            </td>
                            </tr>
                        <tr>
                            <td>
                                <!--GridView-->					
        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%"  PageSize="30"  BorderColor="#4974C2" 
            EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关应收款记录</B><br/><br/></font></div>" >
        <Columns>
        
        
         <asp:BoundField   HeaderText="日期"  DataField="DirectOutDateTime"   SortExpression="OrderDateTime"  DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="客户"  SortExpression="KWD_Custmoer" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="产品名称"  SortExpression="ProductsBarCode" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="版本号"  SortExpression="ProductsBarCode" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>

         <asp:BoundField   HeaderText="数量"  DataField="DirectOutAmount"   SortExpression="DirectOutAmount"  DataFormatString="{0:f3}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>

         <asp:BoundField   HeaderText="单价"  DataField="KWD_SalesUnitPrice"   SortExpression="KWD_SalesUnitPrice"  DataFormatString="{0:f3}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
         <asp:BoundField   HeaderText="金额"  DataField="KWD_SalesTotalNet"   SortExpression="KWD_SalesTotalNet"  DataFormatString="{0:f3}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
         <asp:BoundField   HeaderText="出库单号"  DataField="DirectOutNo"   SortExpression="DirectOutNo"  DataFormatString="{0:f3}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px"  />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField>
        
        
        
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
</body>
</html>
