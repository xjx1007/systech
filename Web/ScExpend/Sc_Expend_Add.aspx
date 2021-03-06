﻿<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Sc_Expend_Add.aspx.cs"
    Inherits="Sc_Expend_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>生产入库</title>
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
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        //var temp = window.showModalDialog("../Common/SelectSuppliers.aspx?ID=" + intSeconds + "&Type=128860698200781250", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
        var temp = window.open("../Common/SelectSuppliers.aspx?ID=" + intSeconds + "&Type=128860698200781250", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function SetReturnValueInOpenner_Suppliers(temp) {
        if (temp != undefined) {
            var ss;
            ss = temp.split("|");
            document.all('SuppNoSelectValue').value = ss[0];
            document.all('SuppNo').value = ss[1];
        }
        else {
            document.all('SuppNoSelectValue').value = "";
            document.all('SuppNo').value = "";
        }
    }

    function ChangPrice(s_Value) {
        var tb = document.getElementById("MyGridView2");
        var rows = tb.rows;
        for (var i = 1; i < rows.length; i++) {
            var Tbx_number = rows[i].cells[9].childNodes[1];
            //alert(Tbx_number);
            var Tbx_LossPercent = rows[i].cells[11].childNodes[1];
            var Tbx_LossNumber = rows[i].cells[12].childNodes[1];
            var Tbx_NeedNumber = rows[i].cells[13].childNodes[1];
            var v_Number = rows[i].cells[6].innerText;
            var v_LossNumber = parseInt(v_Number) * parseInt(s_Value) * parseFloat(Tbx_LossPercent.value) / 100.0
            Tbx_LossNumber.value = Math.round(v_LossNumber);
            Tbx_NeedNumber.value = parseInt(v_Number) * parseInt(s_Value);
            Tbx_number.value = parseInt(v_Number) * parseInt(s_Value) + parseInt(v_LossNumber);
        }
    }

    function Submitcheck() {
        var v_Num = "";

        var v_Right = "";
        var GridView = document.getElementById("MyGridView2");
        var i_Num = 10001 + parseInt(GridView.rows.length);
        var v_TotalNum = 0, v_TotalNet = 0;
        for (var i = 10002; i < i_Num; i++) {
            var v_Index = i % 10000;
            if (v_Index.toString().length == 1) {
                v_Index = "0" + v_Index.toString();
            }
            var Chbk = document.getElementById("MyGridView2_ctl" + v_Index + "_Chbk");
            if (Chbk != null) {
                if (Chbk.checked) {
                    var Tbx_Number = document.getElementById("MyGridView2_ctl" + v_Index + "_Tbx_Number");
                    var Tbx_KcNumber = document.getElementById("MyGridView2_ctl" + v_Index + "_Tbx_KcNumber");

                    if (parseInt(Tbx_KcNumber.value) < parseInt(Tbx_Number.value)) {
                        v_Right = "1";
                    }
                }

            }
        }
        if (v_Right == "1") {
            alert("不能小于库存数，请先补足库存！");
            return false;
        }
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>生产入库 > <a class="hdrLink" href="Sc_Expend_Manage.aspx">生产入库</a>
                </td>
            </tr>
            <tr>
                <td style="height: 10px"></td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>生产入库添加
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
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
                                                        <td width="17%" height="25" align="right" class="dvtCellLabel">编号:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Code" runat="server" Enabled="false" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox>
                                                            (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                                runat="server" ErrorMessage="编号非空" ControlToValidate="Tbx_Code" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td width="17%" height="25" align="right" class="dvtCellLabel">消耗日期:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Stime" runat="server" CssClass="Wdate" Width="150px" onFocus="WdatePicker()"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="17%" height="25" align="right" class="dvtCellLabel">订单号:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Order" runat="server" Enabled="false" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td width="17%" height="25" align="right" class="dvtCellLabel">供应商:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="SuppNoSelectValue" OnSelectedIndexChanged="SuppNoSelectValue_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                            <asp:TextBox ID="DID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>

                                                            (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                                                runat="server" ErrorMessage="加工厂非空" ControlToValidate="SuppNoSelectValue" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%" height="25" align="right" class="dvtCellLabel">负责人:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_Batch">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="dvtCellInfo" colspan="4">明细:
                                                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="45" OnRowDataBound="GridView3_DataRowBinding"
                                                            BorderColor="#4974C2" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关生产入库记录</B><br/><br/></font></div>">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="Chbk" runat="server" Checked></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="采购单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <a href="../Order/Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>">
                                                                            <%# DataBinder.Eval(Container.DataItem, "OrderNo") %></a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="业务员" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "DutyPerson").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="下单日期" SortExpression="OrderDateTime" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "OrderDateTime").ToString()).ToShortDateString() %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="要求交货日期" SortExpression="OrderDateTime" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "OrderPreToDate").ToString()).ToShortDateString()%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="供应商" SortExpression="SuppNo" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString()) %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="产品" SortExpression="SuppNo" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="数量" DataField="OrderAmount" SortExpression="OrderAmount"
                                                                    DataFormatString="{0:f0}" HtmlEncode="false">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="单价" DataField="OrderUnitPrice" SortExpression="OrderUnitPrice"
                                                                    DataFormatString="{0:f3}" HtmlEncode="false">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="加工单价" DataField="HandPrice" SortExpression="HandPrice"
                                                                    DataFormatString="{0:f3}" HtmlEncode="false">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>

                                                                <asp:BoundField HeaderText="已生产数量" DataField="ScNumber" SortExpression="ScNumber"
                                                                    DataFormatString="{0:f0}" HtmlEncode="false">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="生产数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%--OnBlur="ChangPrice(this.value);this.className='detailedViewTextBox'"--%>
                                                                        <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="ChangPrice(this.value);this.className='detailedViewTextBox'"
                                                                             Width="60px" Text='<%# DataBinder.Eval(Container.DataItem, "LeftNumber").ToString()%>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()%>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="入库仓库" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:DropDownList runat="server" ID="Ddl_House">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="情况" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "OrderNo"),"订单号")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="生产日期" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# GetSCDate(DataBinder.Eval(Container.DataItem, "DID").ToString())%>
                                                                        <asp:TextBox ID="Tbx_DID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "DID").ToString()%>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="状态" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <%# GetSCDateState(DataBinder.Eval(Container.DataItem, "DID").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="生产" SortExpression="ProductsBarCode" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <a href='Sc_Expend_Add.aspx?DID=<%# DataBinder.Eval(Container.DataItem, "DID").ToString()%>'>生产</a>
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
                                                        <td runat="server" id="Td1" class="dvtCellInfo" colspan="4"><input type="CheckBox" onclick="" />消耗明细： 总单价：<font color="red"><%=s_TotalPrice%></font>停用物料：<font color="red"><%=s_Code%></font>
                                                            <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="300"
                                                                BorderColor="#4974C2" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关消耗明细记录</B><br/><br/></font></div>"
                                                                OnRowDataBound="GridView1_DataRowBinding">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">

                                                                        <HeaderTemplate>
                                                                            <input type="CheckBox" onclick="selectAll(this)" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Chbk" runat="server" Checked></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Bom编号" DataField="BomOrder" SortExpression="BomOrder" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="产品编码" DataField="KSP_Code" SortExpression="KSP_Code" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="物料名称" DataField="ProductsName" SortExpression="ProductsName" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="替换料" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                           <%# ReplaceNum(DataBinder.Eval(Container.DataItem, "ReplaceNum").ToString()) %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="版本号" DataField="ProductsEdition" SortExpression="ProductsName" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="比例" DataField="XPD_Number" SortExpression="XPD_Number"
                                                                        DataFormatString="{0:f0}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="库存" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%#base.FormatNumber1(GetKC(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()),0)%>
                                                                            <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()%>'></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_ReplaceProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "XPD_ReplaceProductsBarCode").ToString()%>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="仓库" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList runat="server" ID="Ddl_House">
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="消耗数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="100px" Text='<%#GetExpendNum(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(),DataBinder.Eval(Container.DataItem, "TotalNumber").ToString()) %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="损耗类型" DataField="PBC_Name" SortExpression="PBC_Name"
                                                                        DataFormatString="{0:f0}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="损耗比例(%)" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_ShPersent" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="50px" Text='<%#DataBinder.Eval(Container.DataItem, "LossPercent").ToString() %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="损耗数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_ShNumber" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="50px" Text='<%#GetLossNum(DataBinder.Eval(Container.DataItem, "LossNumber").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="需求数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_XqNumber" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="50px" Text='<%#GetNeedNum(DataBinder.Eval(Container.DataItem, "NeedNumber").ToString(),DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField HeaderText="上级物料" DataField="FaterProductsName" SortExpression="FaterProductsName" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="100px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_KcNumber" runat="server" Width="100px" CssClass="Custom_Hidden" Text='<%# GetKC(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>'></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_LossType" runat="server" CssClass="Custom_Hidden" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "KSP_LossType").ToString()%>'></asp:TextBox>
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
                                            <td class="dvtCellLabel">备注:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:TextBox ID="Tbx_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="600px" Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]" Style="width: 55px; height: 33px;"
                                                    class="crmbutton small save" OnClick="Btn_SaveOnClick" OnClientClick="return Submitcheck();" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
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
    </form>
</body>
</html>
