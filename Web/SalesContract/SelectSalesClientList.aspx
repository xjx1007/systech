<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSalesClientList.aspx.cs" Inherits="Knet_Common_SelectSalesClientList" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <base target="_self" />
    <script>
        function closeWindow() {
            window.opener = null;
            window.close();
        }

        function set_return_Customer(Customer_id) {
            if (window.opener != undefined) {
                window.opener.returnValue = Customer_id;
            }
            else {
                window.returnValue = Customer_id;
            }
        }
    </script>
    <style type="text/css">
</style>
    <title>选择客户</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>

            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>客户 > <a class="hdrLink" href="SelectSalesClientList.aspx">选择客户</a>
                    </td>
                    <td width="100%" nowrap></td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td>&nbsp;客户搜索:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox"
                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                        Width="300px"></asp:TextBox>  <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="crmbutton small create" OnClick="Button1_Click1" /></td>
                </tr>
            </table>
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>
                    <td>
                        <!--GridView-->
                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                            <Columns>


                                <asp:TemplateField HeaderText="客户名称" HeaderStyle-Font-Size="12px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <ItemTemplate>

                                        <%# GetLink(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="省份" SortExpression="CustomerProvinces" HeaderStyle-Font-Size="12px" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetCityName(DataBinder.Eval(Container.DataItem, "CustomerProvinces").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="渠道信息" SortExpression="CustomerClass" HeaderStyle-Font-Size="12px" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "CustomerClass").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="联系人" DataField="CustomerContact" ItemStyle-Font-Size="12px" ItemStyle-Width="70px" HeaderStyle-Font-Size="12px" SortExpression="CustomerContact">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="责任人" SortExpression="KSC_DutyPerson" HeaderStyle-Font-Size="12px" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSC_DutyPerson").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="移动电话" DataField="CustomerMobile" ItemStyle-Font-Size="12px" ItemStyle-Width="90px" HeaderStyle-Font-Size="12px" SortExpression="CustomerMobile">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                                <asp:BoundField HeaderText="固家电话" DataField="CustomerTel" ItemStyle-Font-Size="12px" ItemStyle-Width="90px" HeaderStyle-Font-Size="12px" SortExpression="CustomerTel">
                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                </asp:BoundField>

                            </Columns>

                            <HeaderStyle CssClass='colHeader' />
                            <RowStyle CssClass='listTableRow' />
                            <AlternatingRowStyle BackColor="#E3EAF2" />
                            <PagerStyle CssClass='Custom_DgPage' />
                        </cc1:MyGridView>
                        <!--分页-->

                        <!--底部功能栏-->
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" >
                            <tr>
                                <td align="center">
                                <input name="button2" type="button"  value="关闭窗口" class="crmbutton small cancel"  style="height:33px"  onclick="closeWindow();">
                                    </td>

                            </tr>
                        </table>
                        <!--底部功能栏-->

                    </td>
                </tr>
            </table>
            <!--内部结束-->


        </div>
    </form>
</body>
</html>
