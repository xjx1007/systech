<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_CheckList_Add.aspx.cs" Inherits="Web_Xs_Sales_CheckList_Add" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<title></title>
  <SCRIPT LANGUAGE=JAVASCRIPT>
    function btnGetReturnValue_onclick()  
    { 
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("../Common/SelectSalesShipList.aspx?ID="+intSeconds+"&State=1","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(temp!=undefined)   
       {   
          	 var ss;
	         ss=temp.split("|");
             document.all('ShipNoSelectValue').value = ss[0];
             document.all('Tbx_ShipNoName').value =ss[1];
        }   
       else
        {
             document.all('ShipNoSelectValue').value = ""; 
             document.all('Tbx_ShipNoName').value = ""; 
        }
     }
     function btnGetReturnValue_onclick() {
         /*选择客户*/
         var today, seconds;
         today = new Date();
         intSeconds = today.getSeconds();
         var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

         if (tempd == undefined) {
             tempd = window.returnValue;
         }
         if (tempd != undefined) {
             var ss;
             ss = tempd.split("#");
             document.all('Tbx_CustomerValue').value = ss[0];
             document.all('Tbx_CustomerName').value = ss[1];
         }
         else {
             document.all('Tbx_CustomerValue').value = "";
             document.all('Tbx_CustomerName').value = "";
         }
     }
</SCRIPT>
  <SCRIPT LANGUAGE=JAVASCRIPT>
    function btnGetBackValue_onclick()  
    { 
     document.all('ContractNoSelectValue').value = ""; 
     document.all('ContractNoName').value = ""; 
    }
</SCRIPT>
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
                销售对账单 > <a class="hdrLink" href="Sales_ShipCheck_Add.aspx">销售对账单</a>
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
                                        <td class="dvtTabCache" style="width: 10px" nowrap>
                                            &nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            销售对账单信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="304" align="right" valign="top">
                                            <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        对账单号:
                                                    </td>
                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                        <asp:TextBox ID="Tbx_CheckCode" MaxLength="45" runat="server" Width="200px" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>(<font
                                                                color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="对账单号不能为空"
                                                            ControlToValidate="Tbx_CheckCode" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" height="25" align="right" class="dvtCellLabel">
                                                        对账日期:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_Stime" runat="server" CssClass="Wdate" onFocus="var OrderPreToDate=$dp.$('OrderPreToDate');WdatePicker({onpicked:function(){OrderPreToDate.focus();},maxDate:'#F{$dp.$D(\'OrderPreToDate\')}'})"></asp:TextBox>(<font
                                                            color="red">*</font>)<br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="对账日期非空"
                                                            ControlToValidate="Tbx_Stime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                <td width="17%" class="dvtCellLabel">
                                                    客户:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                        style="width: 150px" />
                                                    <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Width="178px" ReadOnly="true"></asp:TextBox>
                                                    <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                        onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户"
                                                        ControlToValidate="Tbx_CustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="dvtCellLabel">
                                                        日期：
                                                    </td>
                                                    <td align="left" class="dvtCellInfo"  colspan="3">
                                                        <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox
                                                            ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                                                        <asp:Button ID="Btn_Serch" runat="server" Text="搜索" AccessKey="S" title="搜索 [Alt+S]"
                                                            class="crmbutton small save" OnClick="Btn_Serch_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>明细</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="39" align="right" class="dvtCellLabel" colspan="4">
                                                        <cc1:MyGridView ID="MyGridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CssClass="Custom_DgMain" IsShowEmptyTemplate="true" PageSize="10" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <input type="CheckBox" onclick="selectAll(this)" checked>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="Chbk" runat="server" Checked="true" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                    <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="出库单号" DataField="DirectOutNo" SortExpression="DirectOutNo">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px"></ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="客户名称" SortExpression="KWD_Custmoer" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetCustomerName(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="出库日期" DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                                                    SortExpression="DirectOutDateTime">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px"></ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="收货人" DataField="KWD_ContentPerson" SortExpression="KWD_ContentPerson">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px"></ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="版本号" SortExpression="HouseNo">
                                                                    <ItemTemplate>
                                                                        <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                          <asp:TextBox ID="Tbx_DirectOutID" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString() %>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_CustomerValue" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString() %>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>'></asp:TextBox>
                                                                  
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="出库数量" DataField="DirectOutAmount" SortExpression="DirectOutAmount">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px"></ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="已对账数量" DataField="dzNumber" SortExpression="dzNumber">
                                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px"></ItemStyle>
                                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px"></HeaderStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="对账数量">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_Number" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                                            Width="65px" Text='<%# DataBinder.Eval(Container.DataItem, "yDirectOutAmount").ToString() %>'
                                                                            onblur="Keap(this)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="备货数量">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_BNumber" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                                            Width="65px" Text='<%# DataBinder.Eval(Container.DataItem, "KWD_BNumber").ToString() %>'
                                                                            onblur="Keap(this)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="材料费">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_Price" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                                            Width="65px" Text='<%# DataBinder.Eval(Container.DataItem, "ProcureunitPrice").ToString() %>'
                                                                            onblur="Keap(this)"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="对账金额">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_Money" MaxLength="40" enable="false" runat="server" CssClass="detailedViewTextBox"
                                                                            Width="65px" Text='<%# DataBinder.Eval(Container.DataItem, "Money").ToString() %>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="备注" SortExpression="HouseNo">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_Details" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                                            Width="65px"></asp:TextBox>
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
                                                    <td height="39" align="right" class="dvtCellLabel">
                                                        备注说明:
                                                    </td>
                                                    <td colspan="3" align="left" valign="top" class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_DirectInRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="400px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center" style="height: 30px">
                                                        <asp:Button ID="Button1" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                            class="crmbutton small save" OnClick="Btn_Save_Click" />
                                                        <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                            type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
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
            <td align="right" valign="top">
                <img src="../../themes/softed/images/showPanelTopRight.gif" />
            </td>
        </tr>
    </table>
    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="TbxID" Width="0px"></asp:TextBox>

    </form>
</body>
</html>
