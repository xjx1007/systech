<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Cw_Accounting_Pay_Add.aspx.cs"
    Inherits="Cw_Accounting_Pay_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <title>收款单信息</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
     <script language="javascript">
    function btnGetReturnValue_onclick()  
    { 
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("../Common/SelectCustomer.aspx?ID="+intSeconds+"","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

           if(temp!=undefined)   
           {   
              	 var ss;
              	 ss = temp.split("#");
		         document.all('Tbx_SuppNo').value = ss[0];
		         document.all('Tbx_SuppName').value = ss[1];
            }   
           else
            {
                document.all('Tbx_SuppName').value = "";
                document.all('Tbx_SuppNo').value = ""; 
            }
    }

     </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
        <tr>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td>
                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                    <tr>
                        <td class="showPanelBg" valign="top" width="100%">
                            <span class="lvtHeaderText">
                                <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                            <br>
                            <hr noshade size="1">
                            
                            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr valign="bottom">
                                    <td style="height: 44px">
                                        <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                            <tr>
                                                <td class="dvtTabCache" style="width: 10px" nowrap>
                                                    &nbsp;
                                                </td>
                                                <td class="dvtSelectedCell" align="center" nowrap>
                                                    收款单信息
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
                                        <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                            <tr>
                                                <td>
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr>
                                                            <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_PayID" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_Code" runat="server" Style="display: none" ></asp:TextBox>
                                                            <td colspan="4" class="detailedViewHeader">
                                                                <b>基本信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                编号:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_FID" AllowEmpty="false" ValidError="编号不能为空" CssClass="detailedViewTextBox"
                                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                    Width="150px"></pc:PTextBox>
                                                                (<font color="red">*</font>)
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                负责人:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson">
                                                                </asp:DropDownList>
                                                                (<font color="red">*</font>)
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                客户/供应商:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_SuppName" AllowEmpty="false" ValidError="供应商不能为空"
                                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox> <img src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetReturnValue_onclick()" />
                                                                (<font color="red">*</font>)
                                                                <pc:PTextBox runat="server" ID="Tbx_SuppNo" CssClass="Custom_Hidden" Width="0px"></pc:PTextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                帐号:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <asp:DropDownList runat="server" ID="Ddl_Account">
                                                                </asp:DropDownList>
                                                                (<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator5" runat="server" ErrorMessage="帐号不能为空" ControlToValidate="Ddl_Account"
                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                收款类型:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:DropDownList runat="server" ID="Ddl_Type">
                                                                </asp:DropDownList>
                                                                (<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="收款类型不能为空" ControlToValidate="Ddl_Type"
                                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                收款日期:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_PayTime" AllowEmpty="false" ValidError="收款日期不能为空"
                                                                    CssClass="Wdate" onFocus="WdatePicker();"  Width="180px"></pc:PTextBox>
                                                                (<font color="red">*</font>)
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                收款金额:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_Money"
                                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                票据日期:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_StartDate" AllowEmpty="true" ValidError="收款日期不能为空"
                                                                    CssClass="Wdate" onFocus="WdatePicker();"  Width="180px"></pc:PTextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                到期日期:
                                                            </td>
                                                            <td class="dvtCellInfo">
                                                                <pc:PTextBox runat="server" ID="Tbx_EndDate" AllowEmpty="true" ValidError="收款日期不能为空" ssClass="Wdate" onFocus="WdatePicker();"  Width="180px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                票据单号:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <pc:PTextBox runat="server" ID="Tbx_BillCode" AllowEmpty="true" ValidError="收款日期不能为空"
                                                                     Width="180px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                     <!--   <tr>
                                                            <td class="dvtCellLabel">
                                                                状态:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:DropDownList runat="server" ID="Ddl_State">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>-->
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                摘要:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <pc:PTextBox runat="server" ID="Tbx_Details" TextMode="MultiLine"  CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" Width="280px" Height="50px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="detailedViewHeader" colspan="4">
                                                                <b>应收款信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <cc1:MyGridView ID="MyGridView1" runat="server" AllowSorting="True"
                                                                    IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                                    PageSize="10" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <input type="CheckBox" onclick="selectAll(this)">
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle Height="25px" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="应收款编号" ItemStyle-HorizontalAlign="center"
                                                                            HeaderStyle-HorizontalAlign="center">
                                                                            <ItemTemplate>
                                                                                <a href="Cw_Accounting_Pay_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAP_ID") %>">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "CAP_Code").ToString()%></a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="期次" DataField="CAP_Order"
                                                                            ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="应付金额" DataField="CAP_ReceiveMoney" 
                                                                            ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="应付日期" DataField="CAP_Stime"
                                                                            DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="已付金额" DataField="CAP_PayMoney"
                                                                           ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="当前收款" HeaderStyle-HorizontalAlign="left">
                                                                            <ItemTemplate>
                                                                            <pc:PTextBox runat="server" ID="Tbx_PayMoney"
                                                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px" Text=<%# DataBinder.Eval(Container.DataItem, "CAP_LeftMoney") %>></pc:PTextBox>
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
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        &nbsp;
                                        <br />
                                        <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                            class="crmbutton small save" OnClick="Btn_SaveOnClick" style="width: 55px;height: 33px;" />
                                        <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                            type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
