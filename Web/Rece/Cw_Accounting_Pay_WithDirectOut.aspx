<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Cw_Accounting_Pay_WithDirectOut.aspx.cs"
    Inherits="Cw_Accounting_Pay_WithDirectOut" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <title>收款单核销</title>
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
       var temp= window.showModalDialog("/Web/Common/SelectCustomer.aspx?ID="+intSeconds+"","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

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

    function btnGetShip_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("SelectSalesShipList.aspx?CustomerValue=" + document.all("Tbx_SuppNo").value + "&ID=" + document.all("Tbx_IDs").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1200px;dialogHeight=600px");

        if (tempd != undefined) {
            var ss, s_Name, i_row, s_ID = "", TotalNet = 0;
            i_row = myTable.rows.length;
            var v_Ship = Cw_Accounting_Pay_WithDirectOut.GetDetails(tempd);
            ss = v_Ship.value.split("|");
            var i_num = parseInt(document.all('Tbx_Num').value);
            for (var i = 0; i < ss.length - 1; i++) {
                var Num = i_num + i;
                var v_Value = ss[i].split(",");
                var objRow = myTable.insertRow(i_row);
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                objCel.className = "ListHeadDetails";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  ID=\"ID_' + Num + '\"  Name=\"ID_' + Num + '\" value=' + v_Value[0] + '><input type=\"hidden\"  ID=\"FPOutID_' + Num + '\"  Name=\"FPOutID_' + Num + '\" value=' + v_Value[9] + '>' + v_Value[1];
                objCel.className = "ListHeadDetails";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  ID=\"DirectOutTime_' + Num + '\"  Name=\"DirectOutTime_' + Num + '\" value=' + v_Value[6] + '>' + v_Value[6];
                objCel.className = "ListHeadDetails";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\" ID=\"ProductsBarCode_' + Num + '\"   Name=\"ProductsBarCode_' + Num + '\" value=' + v_Value[2] + '>' + v_Value[3];
                objCel.className = "ListHeadDetails";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input  type=\"hidden\"  class="detailedViewTextBox"  OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="ChangePrice();this.className=&#39;detailedViewTextBox&#39;" width=\"100px\" Name=\"Number_' + Num + '\" value=' + parseInt(v_Value[8]) + ' >' + parseInt(v_Value[8]);
                objCel.className = "ListHeadDetails";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\" ID=\"OldPrice_' + Num + '\"   Name=\"OldPrice_' + Num + '\" value=' + v_Value[5] + '> <input  class="detailedViewTextBox" OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="this.className=&#39;detailedViewTextBox&#39;ChangePrice()" width=\"100px\" Name=\"Price_' + Num + '\" value=' + v_Value[5] + '  type=\"hidden\">' + v_Value[5];
                objCel.className = "ListHeadDetails";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  class="detailedViewTextBox"  readonly OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="this.className=&#39;detailedViewTextBox&#39;sum()" width=\"100px\" Name=\"Money_' + Num + '\" value=' + parseFloat(v_Value[7]) + ' >' + parseFloat(v_Value[7]);
                objCel.className = "ListHeadDetails";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input class="detailedViewTextBox"   OnFocus="this.className=&#39;detailedViewTextBoxOn&#39;" OnBlur="sum()" width=\"100px\" Name=\"Tbx_Money_' + Num + '\" value=' + parseFloat(v_Value[4]) + '>';
                objCel.className = "ListHeadDetails";
                TotalNet += parseFloat(v_Value[7]) ;
                i_row = i_row + 1;
                s_ID = s_ID + v_Value[1] + ",";
            }
            if (s_ID != "") {
                s_ID = s_ID.substring(0, s_ID.length - 1);
            }
            document.all("Tbx_IDs").value = s_ID;
            document.all('Tbx_Num').value = ss.length - 1 + i_num;
            sum();

        }
    }

    function sum()
    {
        var i_num1 = parseInt(document.all('Tbx_Num').value);
        var bm_num = "";
        var Total = 0;
        for (i = 0; i < i_num1; i++) {
            var TotalNum = document.all("Tbx_Money_" + i + "");
            if (TotalNum != null) {
                Total += parseFloat(TotalNum.value);
            }
        }

        var TotalMoney = parseFloat(document.all('Tbx_Money').value);
        document.all('Tbx_DetailsMoney').value = Total.toFixed(2);
        document.all('Tbx_LeftMoney').value = TotalMoney - Total.toFixed(2);
    }
    function deleteRow(obj) {
        myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        sum();
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
                                                        <asp:Panel runat="server" Enabled="false" ID="Pan_Details">
                                                        <tr>
                                                            <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
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
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                票据单号:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <pc:PTextBox runat="server" ID="Tbx_BillCode" AllowEmpty="true" ValidError="收款日期不能为空"
                                                                     Width="180px"></pc:PTextBox>
                                                            </td>
                                                        </tr>
                                            </asp:Panel>
                                                        <tr>
                                                            <td class="dvtCellLabel">
                                                                发货单金额合计:
                                                            </td>
                                                            <td class="dvtCellInfo" >
                                                                <pc:PTextBox runat="server" ID="Tbx_DetailsMoney" AllowEmpty="true" ValidError="收款日期不能为空"
                                                                     Width="180px"></pc:PTextBox>
                                                            </td>
                                                            <td class="dvtCellLabel">
                                                                剩余合计:
                                                            </td>
                                                            <td class="dvtCellInfo" >
                                                                <pc:PTextBox runat="server" ID="Tbx_LeftMoney" AllowEmpty="true" ValidError="收款日期不能为空"
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
                                                            
                                                            <asp:TextBox ID="Tbx_IDs" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:TextBox runat="server" ID="Tbx_Num" Text="0" CssClass="Custom_Hidden"></asp:TextBox><td
                                                                class="dvtCellInfo" colspan="4">
                                                                <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0"
                                                                    class="ListDetails">
                                                                    <tr valign="top">
                                                                        <td align="left" class="ListHead" width="4%">
                                                                            删除
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            发货单号
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            出库日期
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            产品
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            数量
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            单价
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            金额
                                                                        </td>
                                                                        <td align="left" class="ListHead" style="height: 20px">
                                                                            核销金额
                                                                        </td>
                                                                    </tr>
                                                                    <%=s_MyTable_Detail %>
                                                                </table>
                                                                
                                                                <input id="Button4" class="crmbutton small create" onclick="return btnGetShip_onclick()"
                                                                    type="button" value="选择出库单" />
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
