<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false"
    CodeFile="Knet_Procure_SuppliersRC_Price_Add.aspx.cs" Inherits="Knet_Web_Procure_Knet_Procure_SuppliersRC_Price_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <title>BOM报价</title>
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script language="javascript" type="text/javascript" src="../../../Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/js/ListView.js"></script>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('KNetSelectValue').value = ss[0];
                document.all('KNetSelectName').value = ss[1];
            }
            else {
                document.all('KNetSelectValue').value = "";
                document.all('KNetSelectName').value = "";
            }
        }
    function btnGetProducts_onclick() {

        var tempd = window.showModalDialog("../../Common/SelectProducts.aspx?ProductsMainCategroy=129678733470295462&sID=", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
        if (tempd != undefined) {
            var ss;
            ss = tempd.split(",");
            document.all('Tbx_RcProductsBarCode').value=ss[2];
            document.all('Tbx_RcProductsName').value=ss[0];
        }
    }
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "../../Web/Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
                send_request("GET", url, null, "text", populateClass3);
            }
        }
        function populateClass3() {
            var f = document.getElementById("SmallClass");
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
                    alert("您所请求的页面有异常.");
                }
            }
        }

        function ChangPrice() {
             var tb = document.getElementById("GridView1");
             var rows = tb.rows;
             var zPrice = "0";
             for (var i = 1; i < rows.length; i++) {
                // var Tbx_Price = rows[i].cells[5].childNodes[0];
                // zPrice += parseInt(Tbx_Price.Value);
             }
             document.all('Lbl_ZPrice').value = "总单价: " + zPrice;
             }

    </script>
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
                BOM报价 > <a class="hdrLink" href="Knet_Procure_SuppliersRC_Price.aspx">BOM报价</a>
            </td>
            <td width="100%" nowrap>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
    
    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
        <tr>
            <td valign="top">
                <img src="../../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td class="showPanelBg" valign="top" width="100%">
                <div class="small" style="padding: 20px">
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">
                    
                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>
                                            &nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            BOM报价添加
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">
                                            &nbsp;
                                        </td>
                                        <tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--内容块--%>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="304" align="right" valign="top">
                                            <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
                                             <tr>
                                                    <td width="17%" height="25" align="right" class="dvtCellLabel">
                                                        选择成品:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox  CssClass="Custom_Hidden" runat="server" ID="Tbx_RcProductsBarCode"
                                                                runat="server" />
                                                            <asp:TextBox ID="Tbx_RcProductsName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" MaxLength="48" Width="150px" AutoPostBack="True"></asp:TextBox>
                                                            <img tabindex="8" src="../../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetProducts_onclick()" />
                                                    </td>
                                                    
                                                    <td width="17%" height="25" align="right" class="dvtCellLabel">
                                                        是否停用该供应商相同产品价格:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                    <asp:CheckBox runat="server" ID="Chk_IsStop"  Checked="true"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" height="25" align="right" class="dvtCellLabel">
                                                        产品大类:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <select id="BigClass" style="width: 140px" runat="server">
                                                            <option value="0">--请选择大类--</option>
                                                        </select>
                                                    </td>
                                                    <td align="right" class="dvtCellLabel">
                                                        关键词:
                                                    </td>
                                                    <td width="33%" align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="140px"></asp:TextBox><asp:Button
                                                            ID="Button4" runat="server" Text="产品筛选" class="crmbutton small save" OnClick="Button4_Click"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr> 
                                                
                                                <tr>
                                                    <td align="left" class="dvtCellInfo" colspan="4">
                                                    成品：
                                                        <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="true" PageSize="10" AllowSorting="True"
                                                            EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                            GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                                            ShowHeader="true" HeaderStyle-Height="25px"  OnRowDataBound="MyGridView1_DataRowBinding">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="left">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" Checked />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="产品名称" SortExpression="ProductsName" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="KSP_Code" HeaderText="料号" SortExpression="KSP_Code">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ProductsEdition" HeaderText="版本号" SortExpression="ProductsPattern">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="类名" SortExpression="ProductsType" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetProductsType(DataBinder.Eval(Container.DataItem, "ProductsType"))%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="采购单价" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="70px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="ProcureUnitPrice" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px"  Text='<%#DataBinder.Eval(Container.DataItem, "ProductsCostPrice")%>'
                                                                            MaxLength="9"></asp:TextBox><br />
                                                                        
                                                                        <asp:TextBox ID="OldProcureUnitPrice" runat="server" CssClass="Custom_Hidden"  Text='<%#DataBinder.Eval(Container.DataItem, "ProductsCostPrice")%>'></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="JoinNumberb33b" runat="server" ErrorMessage="正货币形式!"
                                                                            ControlToValidate="ProcureUnitPrice" ValidationExpression="^(\d+|,\d{3})+(\.\d{0,3})?$"
                                                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="ProcureUnitPricessss33" runat="server" ErrorMessage="非空值"
                                                                            ControlToValidate="ProcureUnitPrice" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            
                                                                        <asp:TextBox ID="ProcureMinShu" runat="server" CssClass="Custom_Hidden" Width="50px" Text="0"
                                                                            MaxLength="6"></asp:TextBox>
                                                                        <asp:TextBox ID="Salesprice" runat="server" CssClass="Custom_Hidden" Width="50px" Text="0"
                                                                            MaxLength="6"></asp:TextBox>
                                                                            
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="加工费" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="HandPrice" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px" Text='<%#DataBinder.Eval(Container.DataItem, "HandPrice")%>'
                                                                            MaxLength="9"></asp:TextBox><br />
                                                                        <asp:TextBox ID="OldHandPrice" runat="server" CssClass="Custom_Hidden"  Text='<%#DataBinder.Eval(Container.DataItem, "HandPrice")%>'></asp:TextBox>

                                                                        <asp:RegularExpressionValidator ID="HandPrice33db" runat="server" ErrorMessage="正货币形式!"
                                                                            ControlToValidate="Salesprice" ValidationExpression="^(\d+|,\d{3})+(\.\d{0,3})?$"
                                                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="HandPrice33" runat="server" ErrorMessage="非空值" ControlToValidate="HandPrice"
                                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="备注" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px" Text=''></asp:TextBox><br />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="供应商" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="Ddl_SuppNo" runat="server"></asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="是否采购"   HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                <asp:CheckBox ID="Chb_IsOrder"  runat="server" checked ></asp:CheckBox>
                                                                </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="地址"   HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                <asp:RadioButton runat="server"  ID="RadioButton1" GroupName="Rbtn" Text="发供应商" Checked />
                                                                <asp:RadioButton runat="server"  ID="RadioButton2" GroupName="Rbtn" Text="发客户" />
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
                                                <tr>
                                                    <td align="left" class="dvtCellInfo" colspan="4">
                                                    配件： <asp:Label ID="Lbl_ZPrice" runat="server"></asp:Label>
                                                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" PageSize="30" AllowSorting="True"
                                                            EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                            GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                                            ShowHeader="true" HeaderStyle-Height="25px"  OnRowDataBound="GridView1_DataRowBinding">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="left">
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" Checked />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="名称" SortExpression="ProductsName" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="KSP_Code" HeaderText="料号" SortExpression="KSP_Code">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ProductsEdition" HeaderText="版本号" SortExpression="ProductsEdition" >
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="类名" SortExpression="ProductsType" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetProductsType(DataBinder.Eval(Container.DataItem, "ProductsType"))%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="采购单价" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="70px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="OldProcureUnitPrice" runat="server" CssClass="Custom_Hidden"  Text='<%#DataBinder.Eval(Container.DataItem, "ProductsCostPrice")%>'></asp:TextBox>

                                                                        <asp:TextBox ID="ProcureUnitPrice" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="ChangPrice();this.className='detailedViewTextBox'" Width="60px" Text='<%#DataBinder.Eval(Container.DataItem, "ProductsCostPrice")%>'
                                                                            MaxLength="9"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="JoinNumberb33b" runat="server" ErrorMessage="正货币形式!"
                                                                            ControlToValidate="ProcureUnitPrice" ValidationExpression="^(\d+|,\d{3})+(\.\d{0,3})?$"
                                                                            Display="Dynamic"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="ProcureUnitPricessss33" runat="server" ErrorMessage="非空值"
                                                                            ControlToValidate="ProcureUnitPrice" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="加工费" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="OldHandPrice" runat="server" CssClass="Custom_Hidden"  Text='<%#DataBinder.Eval(Container.DataItem, "HandPrice")%>'></asp:TextBox>
                                                                        <asp:TextBox ID="HandPrice" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px" Text='<%#DataBinder.Eval(Container.DataItem, "HandPrice")%>'
                                                                            MaxLength="9"></asp:TextBox><br />
                                                                        <asp:RegularExpressionValidator ID="HandPrice33db" runat="server" ErrorMessage="正货币形式!"
                                                                            ControlToValidate="Salesprice" ValidationExpression="^(\d+|,\d{3})+(\.\d{0,3})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="HandPrice33" runat="server" ErrorMessage="非空值" ControlToValidate="HandPrice"
                                                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="备注" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px" Text=''></asp:TextBox>
                                                                            
                                                                        <asp:TextBox ID="ProcureMinShu" runat="server" CssClass="Custom_Hidden" Width="50px" Text="0"
                                                                            MaxLength="6"></asp:TextBox>
                                                                        <asp:TextBox ID="Salesprice" runat="server" CssClass="Custom_Hidden" Width="50px" Text="0"
                                                                            MaxLength="6"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="数量" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="70px">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="ChangPrice();this.className='detailedViewTextBox'" Width="60px" Text='1'
                                                                            MaxLength="9"></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%#DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>'
                                                                            MaxLength="9"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="供应商" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList ID="Ddl_SuppNo" runat="server" Width="120px"></asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="是否采购"   HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                <asp:CheckBox ID="Chb_IsOrder"  runat="server" checked ></asp:CheckBox>
                                                                </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="地址"   HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                <asp:RadioButton runat="server"  ID="RadioButton1" GroupName="Rbtn" Text="发供应商" Checked />
                                                                <asp:RadioButton runat="server"  ID="RadioButton2" GroupName="Rbtn" Text="发客户" />
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" style="height: 30px">
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
            </td>
        </tr>
    </table>
    </td>
    <td align="right" valign="top">
        <img src="../../../themes/softed/images/showPanelTopRight.gif" />
    </td>
    </tr> </table>
    </form>
</body>
</html>
