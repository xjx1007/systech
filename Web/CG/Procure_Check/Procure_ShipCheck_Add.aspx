<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_ShipCheck_Add.aspx.cs"
    Inherits="Web_Procure_ShipCheck_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <title>采购对账管理</title>
    <script language="JAVASCRIPT">
        function btnGetSupp_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('Ddl_SuppNo').value = ss[0];
                document.all('SuppNo').value = ss[1];
            }
            else {
                document.all('Ddl_SuppNo').value = "";
                document.all('SuppNo').value = "";
            }
        }
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../Common/SelectSalesShipList.aspx?ID=" + intSeconds + "&State=1", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('ShipNoSelectValue').value = ss[0];
                document.all('Tbx_ShipNoName').value = ss[1];
            }
            else {
                document.all('ShipNoSelectValue').value = "";
                document.all('Tbx_ShipNoName').value = "";
            }
        }
        function btnGetBackValue_onclick() {
            document.all('ContractNoSelectValue').value = "";
            document.all('ContractNoName').value = "";
        }


        //改变价格方法        
        function Keap(ipt) {
            var trs = document.getElementById("MyGridView1");

            var pipt = ipt.parentNode.parentNode;
            var i_row = pipt.rowIndex;
            var i_rows = trs.rows.length;
            var v_Number = trs.rows(i_row).cells(9).childNodes[0].value
            var v_BNumber = trs.rows(i_row).cells(10).childNodes[0].value
            var v_Price = trs.rows(i_row).cells(11).childNodes[0].value

            var v_HandPrice = trs.rows(i_row).cells(12).childNodes[0].value
            if (i_rows > 0) {
                trs.rows(i_row).cells(13).childNodes[0].value = (parseFloat(v_Price) + parseFloat(v_HandPrice)) * (parseFloat(v_Number) + parseFloat(v_BNumber));
            }
            GetTotal1();
        }
        //改变价格方法
        function Keap1(ipt) {
            var trs = document.getElementById("MyGridView2");
            var pipt = ipt.parentNode.parentNode;
            var i_row = pipt.rowIndex;
            var i_rows = trs.rows.length;
            var v_Number = trs.rows(i_row).cells(10).childNodes[0].value
            var v_Price = trs.rows(i_row).cells(11).childNodes[0].value
            if (i_rows > 0) {
                trs.rows(i_row).cells(12).childNodes[0].value = parseFloat(v_Price) * parseFloat(v_Number);
            }
            GetTotal();
        }


        //计算总数量和单价       
        function GetTotal1() {
            var GridView = document.getElementById("MyGridView1");
            var i_Num = 10001 + parseInt(GridView.rows.length);
            var v_TotalNum = 0, v_TotalNet = 0;
            for (var i = 10002; i < i_Num; i++) {
                var v_Index = i % 10000;
                if (v_Index.toString().length == 1) {
                    v_Index = "0" + v_Index.toString();
                }
                var Chbk = document.getElementById("MyGridView1_ctl" + v_Index + "_Chbk1");

                if (Chbk.checked) {
                    var Tbx_Number = document.getElementById("MyGridView1_ctl" + v_Index + "_Tbx_Number");
                    var Tbx_BNumber = document.getElementById("MyGridView1_ctl" + v_Index + "_Tbx_BNumber");
                    var Tbx_Money = document.getElementById("MyGridView1_ctl" + v_Index + "_Tbx_Money");
                    v_TotalNum += parseInt(Tbx_Number.value) + parseInt(Tbx_BNumber.value);
                    v_TotalNet += parseFloat(Tbx_Money.value);
                }
            }

            document.all("Tbx_TotalNet").value = v_TotalNet;
            document.all("Tbx_TotalNum").value = v_TotalNum;
        }
        //计算总数量和单价       
        function GetTotal() {
            var GridView = document.getElementById("MyGridView2");
            var i_Num = 10001 + parseInt(GridView.rows.length);
            var v_TotalNum = 0, v_TotalNet = 0;
            for (var i = 10002; i < i_Num; i++)
            {
                var v_Index = i % 10000;
                if (v_Index.toString().length == 1)
                {
                     v_Index = "0" + v_Index.toString();
                }
                var Chbk = document.getElementById("MyGridView2_ctl" + v_Index + "_Chbk");
                if (Chbk.checked)
                {
                    var Tbx_Number = document.getElementById("MyGridView2_ctl" + v_Index + "_Tbx_Number");
                    var Tbx_Money = document.getElementById("MyGridView2_ctl" + v_Index + "_Tbx_Money");
                    v_TotalNum += parseInt(Tbx_Number.value);
                    v_TotalNet += parseFloat(Tbx_Money.value);
                }
            }

            document.all("Tbx_TotalNet").value = v_TotalNet;
            document.all("Tbx_TotalNum").value = v_TotalNum;
        }

    </script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        #uploadFile {
            width: 379px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">

        <input type="hidden" name="Ddl_SuppNo" id="Ddl_SuppNo" runat="server" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购对账单 > <a class="hdrLink" href="Procure_ShipCheck_List.aspx">采购对账单</a>
                </td>
                <td width="100%" nowrap></td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
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
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                            <tr>
                                <td>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="dvtContentSpace" width="100%">
                                        <tr>
                                            <td class="detailedViewHeader"><b>基本信息</b> </td>
                                        </tr>
                                        <tr>
                                            <td align="right" height="304" valign="top">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" height="261" width="100%">
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" height="25" width="16%">对账单号: </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="Tbx_CheckCode" runat="server" CssClass="detailedViewTextBox" MaxLength="45" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="200px"></asp:TextBox>
                                                            (<font color="red">*</font>)
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Tbx_CheckCode" Display="Dynamic" ErrorMessage="对账单号不能为空"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel" align="right">文件：
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Upload"></asp:Label>
                                                            <input id="uploadFile" type="file" runat="server" />

                                                            <asp:Button
                                                                ID="save" runat="server" Text="上传" CssClass="crmbutton small save"
                                                                OnClick="save_Click" Height="26px" />
                                                        </td>
                                                        <td width="15%" class="dvtCellLabel" align="right">表名：
                                                        </td>
                                                        <td width="20%" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Sheet" runat="server" CssClass="detailedViewTextBox"  Text="Sheet1" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                            <asp:Button ID="Button2" runat="server"  class="crmbutton small save" OnClick="Btn_Serch_Click1" Text="配置" Height="26px"   />

                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" height="25" width="17%">对账日期: </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Stime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                            (<font color="red">*</font>)<br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Tbx_Stime" Display="Dynamic" ErrorMessage="对账日期非空"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">对账类型: </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_Type" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddl_Type_SelectedIndexChanged" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr_HouseNo" runat="server">
                                                        <td align="right" class="dvtCellLabel">出货仓库: </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:DropDownList ID="Ddl_HouseNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddl_HouseNo_SelectedIndexChanged" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr_SuppNo" runat="server">
                                                        <td align="right" class="dvtCellLabel">供应商: </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="SuppNo" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                            <img src="../../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetSupp_onclick()" />

                                                        </td>
                                                    </tr>
                                                    <tr id="Tr1" runat="server">
                                                        <td align="right" class="dvtCellLabel">总数量: </td>
                                                        <td align="left" class="dvtCellInfo" >
                                                            对账单：<asp:TextBox ID="Tbx_TotalNum" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                            <br /> Excel：
                                                            <asp:TextBox ID="Tbx_TotalNumExcel" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">总金额: </td>
                                                        <td align="left" class="dvtCellInfo" >
                                                            对账单：<asp:TextBox ID="Tbx_TotalNet" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                            <br /> Excel：
                                                            <asp:TextBox ID="Tbx_TotalNetExcel" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">日期： </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>
                                                            &nbsp;到<asp:TextBox ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                                                            <asp:Button ID="Btn_Serch" runat="server" AccessKey="S" class="crmbutton small save" OnClick="Btn_Serch_Click" Text="匹配" title="匹配 [Alt+S]" Height="26px"  />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="detailedViewHeader" colspan="4"><b>明细</b> </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" colspan="4" height="39">
                                                            <cc1:MyGridView ID="MyGridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="Custom_DgMain" IsShowEmptyTemplate="true" PageSize="10" Width="100%" OnRowDataBound="GridView1_DataRowBinding">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                                                                        <HeaderTemplate>
                                                                            <input checked onclick="selectAll(this); GetTotal1()" type="CheckBox"> </input>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Chbk1" runat="server"  onclick="GetTotal1()"  />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle Height="25px" HorizontalAlign="Left" Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="出库单号" ItemStyle-HorizontalAlign="Left" SortExpression="DirectOutNo">
                                                                        <ItemTemplate>
                                                                            
                                            <a href="/web/Xs/SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "DirectOutNo")%>"
                                                target="_blank">
                                                <%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="客户名称" ItemStyle-HorizontalAlign="center" SortExpression="KWD_Custmoer">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="出库日期" SortExpression="DirectOutDateTime">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="KWD_ContentPerson" HeaderText="收货人" SortExpression="KWD_ContentPerson">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" Width="40px" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="物流信息" SortExpression="HouseNo">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Wuliu" runat="server" CssClass="detailedViewTextBox" Text='<%# GetWuliu(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString()) %>' Width="100px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_DirectOutID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %>'></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_CustomerValue" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString() %>'></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>' ></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_DirectOutNo" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString() %>' ></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_ProductsEdition" runat="server" CssClass="Custom_Hidden" Text='<%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) %>' ></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_CkNumber" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "DirectOutAmount").ToString() %>' ></asp:TextBox>

                                                                            
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="版本号" SortExpression="HouseNo" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="DirectOutAmount" HeaderText="出库数量" SortExpression="DirectOutAmount">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="dzNumber" HeaderText="已对账" SortExpression="dzNumber" DataFormatString="{0:f0}">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="对账数量">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" Enabled="false" MaxLength="40" onblur="Keap(this)" Text='<%# base.FormatNumber1(DataBinder.Eval(Container.DataItem, "yDirectOutAmount").ToString(),0)%>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="备货数量">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_BNumber" runat="server" CssClass="detailedViewTextBox" Enabled="false" MaxLength="40" onblur="Keap(this)" Text='<%# DataBinder.Eval(Container.DataItem, "KWD_BNumber").ToString() %>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="材料费">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Price" runat="server" CssClass="detailedViewTextBox" MaxLength="40" onblur="Keap(this)" Text='<%# DataBinder.Eval(Container.DataItem, "ProcureunitPrice").ToString() %>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="加工费">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_HandPrice" runat="server" CssClass="detailedViewTextBox" MaxLength="40" onblur="Keap(this)" Text='<%# DataBinder.Eval(Container.DataItem, "HandPrice").ToString() %>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="对账金额">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Money" runat="server" CssClass="detailedViewTextBox" enable="false" MaxLength="40" Text='<%# DataBinder.Eval(Container.DataItem, "Money").ToString() %>' Width="65px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_ICNumber" runat="server" CssClass="Custom_Hidden" MaxLength="40" Text='<%# DataBinder.Eval(Container.DataItem, "yDirectOutAmount").ToString() %>' Width="65px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_IC" runat="server" CssClass="Custom_Hidden" enable="false" MaxLength="40" Text='<%# GetIC(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="备注" SortExpression="HouseNo">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Details" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="回签单" SortExpression="HouseNo">
                                                                        <ItemTemplate>
                                                                            <%#GetHQCode(DataBinder.Eval(Container.DataItem, "DirectOutNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="colHeader" />
                                                                <RowStyle CssClass="listTableRow" />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass="Custom_DgPage" />
                                                            </cc1:MyGridView>
                                                            <cc1:MyGridView ID="MyGridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="Custom_DgMain" IsShowEmptyTemplate="true" PageSize="10" Width="100%" OnRowDataBound="GridView2_DataRowBinding" >
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <input onclick="selectAll(this); GetTotal()" type="CheckBox"> </input>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Chbk" runat="server"  onclick="GetTotal()" />

                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
                                                                    </asp:TemplateField>
                                                                    
                                                <asp:TemplateField HeaderText="采购单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="../Order/Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>" target="_blank">
                                                            <%# DataBinder.Eval(Container.DataItem, "OrderNo") %></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                                    <asp:BoundField DataField="WareHouseNo" HeaderText="入库单号" SortExpression="WareHouseNo">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="入库仓库" ItemStyle-HorizontalAlign="Left" SortExpression="HouseNo">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetHouseName(DataBinder.Eval(Container.DataItem, "HouseNo").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="WareHouseDateTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="入库日期" SortExpression="WareHouseDateTime">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="物流信息">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Wuliu" runat="server" CssClass="detailedViewTextBox" Text='<%# GetWuliu(DataBinder.Eval(Container.DataItem, "OrderNo").ToString()) %>' Width="100px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_DirectOutID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %>' Width="100px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>' Width="100px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_HouseNo" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "HouseNo").ToString() %>' Width="100px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_OrderNo" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "OrderNo").ToString() %>' Width="100px"></asp:TextBox>
                                                                            <asp:TextBox ID="Tbx_ProductsEdition" runat="server" CssClass="Custom_Hidden" Text='<%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString()) %>' ></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="版本号" SortExpression="ProductsBarCode" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate >
                                                                            <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Height="25px" HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="WareHouseAmount" HeaderText="入库数量" SortExpression="WareHouseAmount">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="COD_Number" HeaderText="已对账" SortExpression="COD_Number" DataFormatString="{0:F0}">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="备货数量">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_BNumber" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Enabled="false" Text='<%# base.FormatNumber1(DataBinder.Eval(Container.DataItem, "WareHouseBAmount").ToString(),0) %>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="对账数量">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Number" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Enabled="false" onblur="Keap1(this)" Text='<%# base.FormatNumber1(DataBinder.Eval(Container.DataItem, "yWareHouseAmount").ToString(),0) %>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="单价">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Price" runat="server" CssClass="detailedViewTextBox" MaxLength="40" onblur="Keap1(this)" Text='<%# DataBinder.Eval(Container.DataItem, "WareHouseUnitPrice").ToString() %>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="对账金额">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Money" runat="server" CssClass="detailedViewTextBox" enable="false" MaxLength="40" Text='<%# DataBinder.Eval(Container.DataItem, "Money").ToString() %>' Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="备注">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Details" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="状态">
                                                                        <ItemTemplate>
                                                                            <%# GetPrint(DataBinder.Eval(Container.DataItem, "KPO_QRState").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="colHeader" />
                                                                <RowStyle CssClass="listTableRow" />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass="Custom_DgPage" />
                                                            </cc1:MyGridView>
                                                            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" height="39">备注说明: </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3" valign="top">
                                                            <asp:TextBox ID="Tbx_DirectInRemarks" runat="server" CssClass="detailedViewTextBox" Height="50px" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="4" style="height: 30px">
                                                            <asp:Button ID="Button1" runat="server" AccessKey="S" class="crmbutton small save" OnClick="Btn_Save_Click" Text="保 存" title="保存 [Alt+S]" Style="width: 55px; height: 30px" />
                                                            <input accesskey="X" class="crmbutton small cancel" name="button" onclick="window.history.back()" title="取消 [Alt+X]" type="button" value="取 消" style="width: 55px; height: 30px"> </input>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                </tr>
                        </table>
                        <hr noshade size="1">
                </td>
                <td align="right" valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden" ></asp:TextBox>
        <asp:TextBox ID="Tbx_URL" runat="server" CssClass="Custom_Hidden" Width="0px"></asp:TextBox>
        <asp:TextBox ID="Tbx_RkCode" runat="server" CssClass="Custom_Hidden" Width="0px"></asp:TextBox>


    </form>
</body>
</html>
