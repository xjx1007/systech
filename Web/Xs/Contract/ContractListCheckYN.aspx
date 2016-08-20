<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContractListCheckYN.aspx.cs" Inherits="Knet_Web_Sales_pop_ContractListCheckYN" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<title>合同进展操作--审核</title>
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }   
  </script>   
  
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>



                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr valign="bottom">
                        <td style="height: 44px">
                            <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                <tr>
                                    <td class="dvtTabCache" style="width: 10px" nowrap>
                                        &nbsp;
                                    </td>
                                    <td class="dvtSelectedCell" align="center" nowrap>
                                        合同档案信息
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
                                                    <asp:TextBox ID="Tbx_State" runat="server"  Style="display: none"></asp:TextBox>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    编号:
                                                </td>
                                                <td class="dvtCellInfo"><asp:Label ID="ContractNo" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    签订日期:
                                                </td>
                                                <td class="dvtCellInfo"><asp:Label ID="ContractDateTime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    客户:
                                                </td>
                                                <td class="dvtCellInfo"><asp:Label ID="CustomerName" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    责任人:
                                                </td>
                                                <td class="dvtCellInfo"><asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    审核状态:
                                                </td>
                                                <td class="dvtCellInfo">
                                                
                                                <asp:DropDownList ID="DropDownList1" runat="server">
                                                   <asp:ListItem Value="-1">请选择审核</asp:ListItem>
                                                   <asp:ListItem Value="1">通过审核</asp:ListItem>
                                                   <asp:ListItem Value="0">不通过审核</asp:ListItem>
                                                   <asp:ListItem Value="3">异常通过</asp:ListItem>
                                                   <asp:ListItem Value="2">合同作废</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    是否发送提醒邮件:
                                                </td>
                                                <td class="dvtCellInfo">
    <asp:CheckBox runat="server" ID="Chk_IsShow" Text="是" Checked="true" />
                                                </td>
                                            </tr>
                                                  
                                            <tr>
                                                <td class="dvtCellLabel" >
                                                    审批意见:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                <asp:TextBox ID="Tbx_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="400px" Height="50px"></asp:TextBox>
                                                </td>
                                            </tr>
       <tr>
           <td height="30" class="dvtCellInfo" colspan="4"align="left" >
                  <asp:GridView ID="GridView1" runat="server" Width="99%"  AllowSorting="True"  GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>
        
        
      <asp:TemplateField HeaderText="审核人"  SortExpression="KSF_ShPerson" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSF_ShPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="所在部门"  SortExpression="StaffDepart" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "StaffDepart").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="职位"  SortExpression="Position" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("105",DataBinder.Eval(Container.DataItem, "Position").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="审核时间"  DataField="KSF_Date"  ItemStyle-Width="70px"  SortExpression="KSF_Date" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="审核状态"  SortExpression="KSF_State" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetFlowName(DataBinder.Eval(Container.DataItem, "KSF_State").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  HeaderText="审核意见"  DataField="KSF_Detail"  ItemStyle-Width="115px"  SortExpression="KSF_Detail" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        
        </Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
        </asp:GridView>
           </td>
      </tr>
                            </table>
    </td> </tr>
    <tr>
        <td colspan="4" align="center">
            &nbsp;
            <br />
            <asp:Button ID="Btn_Save" runat="server" Text="确定审核" AccessKey="S" title="确定审核 [Alt+S]"
                class="crmbutton small save" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.close()"
                type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
        </td>
    </tr>
    </table> </td> </tr> </table>


    </div>
    </form>
</body>
</html>
