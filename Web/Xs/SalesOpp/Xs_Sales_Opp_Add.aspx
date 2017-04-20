<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Opp_Add.aspx.cs" Inherits="Web_Sales_Xs_Sales_Opp_Add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <link rel="stylesheet" href="/css/common.css" />
<title>销售机会</title>
<script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
<script src="../js/jQuery.js" type="text/javascript"></script>
<script src="../js/Global.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            initInput1();
            if ($("#Tbx_Background").Value != "") {
                $("#Tbx_Background").offsetParent().addClass("filled");
            }
            if ($("#Tbx_History").Value != "") {
                $("#Tbx_History").offsetParent().addClass("filled");
            }
            if ($("#Tbx_Competitor").Value != "") {
                $("#Tbx_Competitor").offsetParent().addClass("filled");
            }
            $("#Tbx_Background").blur(function (event) {
                $("#Tbx_Background").offsetParent().removeClass("blurred");
            });
            $("#Tbx_History").blur(function (event) {
                $("#Tbx_History").offsetParent().removeClass("blurred");
            });
            $("#Tbx_Competitor").blur(function (event) {
                $("#Tbx_Competitor").offsetParent().removeClass("blurred");
            });
        });

        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("../../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
            var tempd = window.open("../../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "选择客户", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
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
    </script>
	
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

<table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>销售机会 > 
	<a class="hdrLink" href="Xs_Sales_Opp_List.aspx">销售机会</a>
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
	     	     <div class="small" style="padding:10px"></div>
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
                <hr noshade size=1>
                                
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>销售机会信息</td>
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
                                            <td  class="dvtCellLabel" >销售机会名称:</td>
                                            <td class="dvtCellInfo" >
                                            <pc:PTextBox runat="server" ID="Tbx_Name"  AllowEmpty="true" ValidError="销售机会不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="250px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            <td  class="dvtCellLabel" >销售机会过程:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_SalesType" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                                  <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择销售过程" ControlToValidate="Ddl_SalesType" Display="Dynamic"></asp:RequiredFieldValidator>
                                
                                                (<font color="red">*</font>)
                                            </td>
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
                                        <td colspan=4 class="detailedViewHeader"><b>销售进展</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        
                                            <td  class="dvtCellLabel" > 时间结点:</td>
                                            <td  class="dvtCellInfo">
                                            <pc:PTextBox ID="Tbx_PlanDealDate" runat="server" CssClass="Wdate"  onFocus="WdatePicker()" AllowEmpty="false" ></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            
                                            <td  class="dvtCellLabel" >类型:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Type" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                            
                                        </tr>
                                        

                                        <tr>
                                            
                                            <td  class="dvtCellLabel" >可能性:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Precent" CssClass="detailedViewTextBox" runat="server" Width="150px" >
                                                </asp:DropDownList>
                                            </td>
                                            <td  class="dvtCellLabel" >销售阶段:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_SalesStep" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td  class="dvtCellLabel" >负责人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>(<font color="red">*</font>)
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td  class="dvtCellLabel" >辅助人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_FDutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>(<font color="red">*</font>)
                                                   </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >项目背景:</td>
                                        <td  class="dvtCellInfo" >                                            
                                        <div class="input_pack1">
                                                <label for="Tbx_Background">
                                                    请在市场容量大小、项目启动时间、客户决策因素、项目资金来源等方面进行描述....</label>
                                            <asp:TextBox ID="Tbx_Background" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="50px"></asp:TextBox>
                                        </div>
                                        </td>
                                            
                                        <td   class="dvtCellLabel" >进攻策略:</td>
                                        <td  class="dvtCellInfo"  >
                                        <div class="input_pack1">
                                                <label for="Tbx_History">
                                                    请在产品策略、价格策略、渠道策略等方面进行描述....</label>
                                            <asp:TextBox ID="Tbx_History" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="50px"></asp:TextBox>
                                        </div>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >竞争分析:</td>
                                        <td  class="dvtCellInfo"  >
                                        <div class="input_pack1">
                                                <label for="Tbx_Competitor">
                                                    请在已有对手、潜在竞争对手、对手产品方案、价格方案等方面进行描述....</label>
                                            <asp:TextBox ID="Tbx_Competitor" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="50px"></asp:TextBox>
                                             </div>
                                        </td>
                                            <td  class="dvtCellLabel" >下一步工作计划:</td>
                                            <td  class="dvtCellInfo" >
                                                <pc:PTextBox runat="server" ID="Tbx_NextPlan" TextMode="MultiLine"  Width="300px" Height="50px" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ></pc:PTextBox>
                                         
                                            </td>
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>描述信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >备注:</td>
                                        <td  class="dvtCellInfo"  colspan="4" >
                                            <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="500px" Height="50px"></asp:TextBox>
                                        </td>
                                        </tr>
                                        
                                        </table>
                                  </td>
                             </tr>
                             
<tr>
  <td colspan="4" align="center" >&nbsp;
  <br />
   <asp:Button ID="Btn_Save" runat="server" Text="保 存" accessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick"  />
   <input title="取消 [Alt+X]" accessKey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="width:70px">
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
