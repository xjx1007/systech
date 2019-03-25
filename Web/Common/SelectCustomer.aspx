<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCustomer.aspx.cs" Inherits="Knet_Common_SelectCustomer" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <base target="_self" />
    <script>   
        function closeWindow()   
        {   
            window.opener=null;   
            window.close();   
        }  
    </script>
    <script>
        function changsheng(va) {
            if (va != "0") {
                var city = document.getElementById("city");
                city.disabled = false;
                var url = "../Js/Handler.ashx?type=sheng&id=" + va;
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

        function set_return_Customer(Customer_id, Customer_name, LinkCode) {
            var response = Knet_Common_SelectCustomer.LinMan_Bind(Customer_id);
        
            var returnValue = "";
            returnValue = Customer_id + "#" + Customer_name + "#" + LinkCode+ "#" + response.value;
       
            if (window.opener != undefined) {
                window.opener.returnValue = returnValue;
             <% if (Request.QueryString["callback"] != null && Request.QueryString["callback"] != "")
                {%>
            window.opener.<%=Request.QueryString["callback"]%>(returnValue);
                <%}
                else
                {%>
            window.opener.SetReturnValueInOpenner_Customer(returnValue);
                <%}%>
        }
        else {
            window.returnValue = returnValue;
        }
    }
    </script>
    <title>选择客户</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
            <tr>
                <td>客户搜索:<asp:DropDownList ID="sheng" runat="server"></asp:DropDownList>
                    关键字：<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox"
                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                        Width="300px"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" CssClass="crmbutton small create" OnClick="Button1_Click1" />
                </td>
            </tr>
            <tr>
                <td>
                    <!--GridView-->
                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                        <Columns>



                            <asp:TemplateField HeaderText="客户名称" HeaderStyle-Font-Size="12px" ItemStyle-Height="25px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                <ItemTemplate>

                                    <%# GetLink(DataBinder.Eval(Container.DataItem, "CustomerValue").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="省份" SortExpression="CustomerProvinces" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# base.Base_GetCityName(DataBinder.Eval(Container.DataItem, "CustomerProvinces").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="渠道信息" SortExpression="CustomerClass" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "CustomerClass").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="客户类型" SortExpression="CustomerTypes" HeaderStyle-Font-Size="12px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# base.Base_GetKClaaName(DataBinder.Eval(Container.DataItem, "CustomerTypes").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField HeaderText="负责人" DataField="CustomerContact" ItemStyle-Font-Size="12px" ItemStyle-Width="50px" HeaderStyle-Font-Size="12px" SortExpression="CustomerContact">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="移动电话" DataField="CustomerMobile" ItemStyle-Font-Size="12px" ItemStyle-Width="60px" HeaderStyle-Font-Size="12px" SortExpression="CustomerMobile">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="编码" DataField="CustomerCode" ItemStyle-Font-Size="12px" ItemStyle-Width="70px" HeaderStyle-Font-Size="12px" SortExpression="CustomerTel">
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>

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
        <!--内部结束-->


        </div>
    </form>
</body>
</html>
