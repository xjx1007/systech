<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Quotes_Add.aspx.cs" Inherits="Web_Sales_Xs_Sales_Quotes_Add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">

<title></title>
<script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>	
</head>

<SCRIPT LANGUAGE=JAVASCRIPT >
     function btnGetReturnValue_onclick()  
    {   
       /*选择客户*/
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       //var tempd= window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID="+intSeconds+"","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       var tempd = window.open("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
     function SetReturnValueInOpenner_Customer(tempd) {
         if (tempd == undefined) {
             tempd = window.returnValue;
         }
         var sel = document.getElementById("Ddl_LinkMan");
         var length = sel.length;
         for (var i = length - 1; i >= 0; i--) {
             sel.remove(i);
         }
         var opt = new Option("", "");
         sel.options.add(opt);
         if (tempd != undefined) {
             var ss;
             ss = tempd.split("#");
             document.all('Tbx_CustomerValue').value = ss[0];
             document.all('Tbx_CustomerName').value = ss[1];
             var st, sw;
             st = ss[3].split("|");
             if (st.length > 0) {
                 for (var i = 0; i < st.length - 1; i++) {
                     sw = st[i].split(",");
                     var opt = new Option(sw[1], sw[0]);
                     sel.options.add(opt);
                 }

             }

         }
         else {
             document.all('Tbx_CustomerValue').value = "";
             document.all('Tbx_CustomerName').value = "";
             var length = sel.length;
             for (var i = length - 1; i >= 0; i--) {
                 sel.remove(i);
             }
         }
     }
      
     function btnGetReturnValue_onclick1() {
         /*选择客户*/
         var today, seconds;
         today = new Date();
         intSeconds = today.getSeconds();
         //var tempd= window.showModalDialog("/Web/CustomerContent/SelectSalesOpp.aspx?sID="+intSeconds+"","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=800px;dialogHeight=600px");
         var tempd = window.open("/Web/CustomerContent/SelectSalesOpp.aspx?sID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
     }
     function SetReturnValueInOpenner_SalesOpp(tempd) {
         if (tempd == undefined) {
             tempd = window.returnValue;
         }

         if (tempd != undefined) {
             var ss;
             ss = tempd.split("#");
             document.all('Tbx_SalesChanceValue').value = ss[0];
             document.all('Tbx_SalesChanceName').value = ss[1];


         }
         else {
             document.all('Tbx_SalesChanceValue').value = "";
             document.all('Tbx_SalesChanceName').value = "";
         }
     }
    
    
     function btnGetProducts_onclick() {
         /*选择客户*/
         var today, seconds;
         today = new Date();
         intSeconds = today.getSeconds();

         //var tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1200px;dialogHeight=500px");
         var tempd = window.open("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "选择产品", "width=1200px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
     }
     function SetReturnValueInOpenner_Products(tempd) {
         if (tempd != undefined) {

             var ss, s_Value, i_row;

             ss = tempd.split("|");
             i_row = myTable.rows.length;
             s_ID = document.all("Xs_ProductsCode").value;

             for (var i = 0; i < ss.length - 1; i++) {
                 s_Value = ss[i].split(",");

                 var objRow = myTable.insertRow(i_row);

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                 objCel.className = "dvtCellInfo";

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsName\" value=' + s_Value[0] + '>' + s_Value[0];
                 objCel.className = "dvtCellInfo";

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode\" value=' + s_Value[1] + '>' + s_Value[1];
                 objCel.className = "dvtCellInfo";

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern\" value=' + s_Value[2] + '>' + s_Value[2];
                 objCel.className = "dvtCellInfo";

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;" Name=\"Number\" value=' + s_Value[3] + '>';
                 objCel.className = "dvtCellInfo";

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Price\" value=' + s_Value[4] + '>';
                 objCel.className = "dvtCellInfo";

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:70px;" Name=\"Precent\" value=0 >';
                 objCel.className = "dvtCellInfo";
                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:70px;" Name=\"PrecentMoney\" value=' + s_Value[6] + '>';
                 objCel.className = "dvtCellInfo";

                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Remarks\" value=' + s_Value[5] + ' >';
                 objCel.className = "dvtCellInfo";
                 var objCel = objRow.insertCell();
                 objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Money\" value=' + s_Value[6] + ' >';
                 objCel.className = "dvtCellInfo";
                 i_row = i_row + 1;
                 s_ID = s_ID + s_Value[1] + ",";
             }

             document.all("Xs_ProductsCode").value = s_ID;
         }
     }
        
function deleteRow(obj){
   myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
    var Values =document.getElementsByName("ProductsBarCode"); 
    var bm_num="";
    for(i=0;i<Values.length;i++){  
        bm_num += Values[i].value+",";   
    }
    document.all("Xs_ProductsCode").value=bm_num;
    }
    
</SCRIPT>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

<table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>报价单 > 
	<a class="hdrLink" href="Xs_Sales_Quotes_List.aspx">报价单</a>
        </td>
	<td width=100% nowrap>
 <asp:TextBox ID="Tbx_ID" runat="server" style="display:none"></asp:TextBox>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>
    

<table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
   <tr>
   	<td valign="top"><img src="/themes/softed/images/showPanelTopLeft.gif"></td>
	<td class="showPanelBg" valign="top" width="100%">
	     	     <div class="small" style="padding:10px">
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
                <hr noshade size=1>
                                
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>报价单信息</td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>		
                                    <td class="dvtTabCache" style="width:100%">&nbsp;</td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>		
                            <tr>
                            <td>
                            <table border="0" cellspacing="3" cellpadding="3"  width="100%" class="dvtContentSpace">
							
                             <tr>
                                 <td>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >报价单编号:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Code" Enabled="false"  AllowEmpty="true" ValidError="报价单不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            <td  class="dvtCellLabel" >销售机会名称:</td>
                                            <td  class="dvtCellInfo">
                                                 <asp:TextBox ID="Tbx_SalesChanceValue" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <pc:PTextBox ID="Tbx_SalesChanceName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true" ></pc:PTextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick1()" /><br />
                                                
                                        </td>
                                        </tr>
                                        
                                        <tr>
                                        
                                            <td  class="dvtCellLabel" >报价单阶段:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Step" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                            <td  class="dvtCellLabel" > 预计成交日期:</td>
                                            <td  class="dvtCellInfo">
                                            <pc:PTextBox ID="Tbx_STime" runat="server" CssClass="Wdate"  onFocus="WdatePicker()" AllowEmpty="false" ></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            
                                            
                                        </tr>
                                        
                                        </tr>
                                        <tr>
                                            <td width="17%"  class="dvtCellLabel" >客户:</td>
                                            <td  class="dvtCellInfo"  >
                                                <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server" style="width: 150px" />
                                                <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"  CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true" ></pc:PTextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                
                                             </td>
                                             
                                            <td  class="dvtCellLabel" >联系人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_LinkMan" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                        </tr>
                                          

                                        
                                        <tr>
                                            <td  class="dvtCellLabel" >负责人:</td>
                                            <td  class="dvtCellInfo" colspan="3">
                                                <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>(<font color="red">*</font>)
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>付款条件</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >付款条件:</td>
                                        <td  class="dvtCellInfo"  colspan="4" >
                                            <asp:TextBox ID="Tbx_Payment" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" cols="90" rows="8"></asp:TextBox>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>描述信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >备注:</td>
                                        <td  class="dvtCellInfo"  colspan="4" >
                                            <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" cols="90" rows="8"></asp:TextBox>
                                        </td>
                                        </tr>
                                        
                                        </table>
                                        <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <table id="myTable"  width="100%"  border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable" style="height: 28px">
                                               <tr>
	                                            <td colspan="10" class="dvInnerHeader">
		                                            <b>产品详细信息</b>
	                                            </td>
                                               </tr>
                                               <!-- Header for the Product Details -->
                                                <tr valign="top">
                                                <td valign="top" class="ListHead" align="right" nowrap><b>工具</b></td>
                                                <td  class="ListHead" nowrap><b>产品名称</b></td>
                                                <td  class="ListHead" nowrap><b>产品编码</b></td>
                                                <td class="ListHead"  nowrap><b>型号</b></td>
                                                <td class="ListHead" nowrap><b>数量</b></td>
                                                <td class="ListHead" nowrap><b>价格</b></td>
                                                 <td class="ListHead" nowrap><b>折扣（%）</b></td>
                                                 <td class="ListHead" nowrap><b>折扣价格</b></td>
                                                <td   class="ListHead" nowrap><b>备注</b></td>
                                                <td  nowrap class="ListHead" align="right"><b>小计</b></td>
                                                </tr>
                                                <%=s_MyTable_Detail %>
                                            </table>
                                            <table width="100%"  border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                           <!-- Add Product Button -->
                                              <tr>
	                                        <td colspan="3">	
	                                        ①选择产品: <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
	                                       </td>
                                           </tr>
                                           </table>
                                  </td>
                             </tr>
                             
<tr>
  <td colspan="4" align="center" >&nbsp;
  <br />
   <asp:Button ID="Btn_Save" runat="server" Text="保 存" accessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick"   style="width: 55px;height: 33px;" />
   <input title="取消 [Alt+X]" accessKey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
   </td>

</tr>
							</table>
                            </td>
                            </tr>
                </table>
    </td>
    <td valign="top"><img src="/themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>

    </form>
</body>
</html>
