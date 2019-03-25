<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false"
    CodeFile="KNet_Sales_ClientList_Add.aspx.cs" Inherits="Knet_Web_Sales_KNet_Sales_ClientList_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>客户添加</title>
    <script>
        function btnGetReturnValue_onclick1() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.open("/Web/Common/SelectClientProductsList.aspx?sID=" + intSeconds + "", "选择客户", "width=850, height=500,top=100,left=120,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no,alwaysRaised=yes,depended=yes");

        }

        function SetReturnValueInOpenner_Product(tempd) {
            if (tempd != undefined) {

                var ss, s_Value, s_Name, i_row, sd;
                ss = tempd.split("|");
                i_row = myTable.rows.length;
                s_ID = document.all("Xs_MaterID").value;
                for (var i = 0; i < ss.length; i++) {
                    sd = ss[i].split(",");
                    s_ProductsBarCode = sd[0];
                    s_ProductsName = sd[1];
                    s_ProductsPattern = sd[2];
                    var objRow = myTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\" input Name=\"ProductsBarCode\" value=' + s_ProductsBarCode + '>' + s_ProductsBarCode;
                    objCel.className = "dvtCellLabel";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"hidden\"  Name=\"ProductsName\" value=' + s_ProductsName + ' >' + s_ProductsName;
                    objCel.className = "dvtCellLabel";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\" input Name=\"ProductsPattern\" value=' + s_ProductsPattern + '>' + s_ProductsPattern;
                    objCel.className = "dvtCellLabel";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "dvtCellLabel";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_ProductsBarCode + ",";
                }
                document.all("Xs_MaterID").value = s_ID;
            }
        }

        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("ProductsBarCode");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Xs_MaterID").value = bm_num;
        }
        function deleteRow1(obj) {
            FHTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        }
        function changsheng(va) {
            if (va != '') {
                var city = document.getElementById("city");
                city.disabled = false;
                var url = "/Web/Js/Handler.ashx?type=sheng&id=" + va;
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
        function btnGetFH_onclick() {

            i_row = FHTable.rows.length;
            var objRow = FHTable.insertRow(i_row);
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input type=\"input\"  class=\"detailedViewTextBox\" Name=\"FhName\" >';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<textarea  style="height:50px;width:65%;" class=\"detailedViewTextBox\"  Name=\"FhDetails\" >';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<A onclick=\"deleteRow1(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
            objCel.className = "ListHeadDetails";
        }
        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            
            var tempd = window.open("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "选择客户", "width=850, height=500,top=100,left=120,toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, status=no,alwaysRaised=yes,depended=yes");

        }
        function SetReturnValueInOpenner_Customer(tempd) {
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('FaterCode').value = ss[0];
                document.all('FaterCodeName').value = ss[1];
            }
            else {
                document.all('FaterCode').value = "";
                document.all('FaterCodeName').value = "";
            }
        }

        function GetCustomerID() {
            var ID = document.all('Tbx_ID').value;
            var Type = document.all('Tbx_Type').value;
           var faterCode= document.all('FaterCode').value ;
           var CustomerTypes = "01";
          var CustomerClass= "01" ;
          var sheng = document.all('sheng').value;
          var response = Knet_Web_Sales_KNet_Sales_ClientList_Add.GetCustomer(faterCode, CustomerTypes, CustomerClass, sheng)
          document.all('CustomerValue').value = response.value;
          if ((ID != "") && (Type != "") || (ID == ""))
          {
              
              var response = Knet_Web_Sales_KNet_Sales_ClientList_Add.GetCustomer(faterCode, CustomerTypes, CustomerClass, sheng)
              document.all('CustomerValue').value = response.value;
          }
      }
      window.onload = function () { GetCustomerID(); }   
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
                市场 > <a class="hdrLink" href="KNet_Sales_ClientList_Manger.aspx">客户</a>
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
                <img src="/themes/softed/images/showPanelTopLeft.gif">
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
                                            客户信息
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
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        客户名称:
                                                    </td>
                                                    <td class="dvtCellInfo" align="left">
                                                        <asp:TextBox ID="CustomerName" MaxLength="45" runat="server" Width="200px" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>(<font
                                                                color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                    ErrorMessage="名称非空" ControlToValidate="CustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        简称:
                                                    </td>
                                                    <td class="dvtCellInfo" align="left">
                                                        <asp:TextBox ID="Tbx_SampleName" MaxLength="45" runat="server" Width="200px" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="dvtCellLabel">
                                                        客户编号:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="CustomerValue" runat="server" Width="150px" MaxLength="40" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            ReadOnly="true"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                    ErrorMessage="客户编号非空" ControlToValidate="CustomerValue" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        上级单位:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo" nowrap>
                                                        <asp:TextBox ID="FaterCode" runat="server" CssClass="Custom_Hidden" onpropertychange="GetCustomerID()"></asp:TextBox>
                                                        <asp:TextBox ID="FaterCodeName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="200px"  ></asp:TextBox>
                                                        <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)
                                                        <font color="gray">分公司的请选择</font>
                                                        
                                                    </td>
                                                </tr>
                                                <asp:Panel runat="server" Visible="false">
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        渠道信息:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="CustomerClass" runat="server" Width="150px"  OnChange="GetCustomerID()" >
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        业务类型:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="CustomerTypes" runat="server" Width="150px" OnChange="GetCustomerID()" >
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr></asp:Panel>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        客户行业:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="CustomerTrade" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                            runat="server" ErrorMessage="请选择行业" ControlToValidate="CustomerTrade" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        客户来源:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="CustomerSource" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                            runat="server" ErrorMessage="请选择来源" ControlToValidate="CustomerSource" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        客户级别:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_Level" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        客户状态:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_State" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        客户类型:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_Type" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td height="25" align="right" class="dvtCellLabel">
                                                        客户网址:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="CustomerWebsite" runat="server" MaxLength="90" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="250px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        付款方式:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_PayMent" runat="server" Width="400px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                                            runat="server" ErrorMessage="请选择账期" ControlToValidate="Ddl_PayMent" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        开票方式:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_KpType" runat="server" Width="400px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                                                            runat="server" ErrorMessage="请选择开票方式" ControlToValidate="Ddl_KpType" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        销售负责人1:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_DutyPerson" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                                            runat="server" ErrorMessage="请选择销售负责人1" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        销售负责人2:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_DutyPerson1" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        市场负责人1:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="DDL_Auxiliary" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        市场负责人2:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="DDL_Auxiliary1" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    
                                                </tr>
                                                
                                                    <tr>
                                                        <td height="25" align="right" class="dvtCellLabel">
                                                            <b>是否额度客户</b>:
                                                        </td>
                                                        <td colspan="3" align="left" class="dvtCellInfo">
                                                            <asp:CheckBox ID="PlayCycleYN" runat="server" Checked="false" /><font color="gray">（是额度客户请打勾）</font>额度设置：额度金额（元）：
                                                            <asp:TextBox ID="PlayCycleMoney" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" MaxLength="9" Text="0.00" Width="120px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="非空值"
                                                                ControlToValidate="PlayCycleMoney" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="货币形式.如 800000.00"
                                                                ControlToValidate="PlayCycleMoney" ValidationExpression="^(-)?(\d+|,\d{3})+(\.\d{0,3})?$"
                                                                Display="Dynamic"></asp:RegularExpressionValidator>支付周期（天）：<asp:TextBox ID="PlayCycleTime"
                                                                    runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                    OnBlur="this.className='detailedViewTextBox'" MaxLength="4" Width="60px" Text="0"></asp:TextBox><asp:RegularExpressionValidator
                                                                        ID="RegularExpressionValidator4" runat="server" ErrorMessage="正整数或零" ControlToValidate="PlayCycleTime"
                                                                        ValidationExpression="^\+?[0-9][0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" align="right" class="dvtCellLabel" style="height: 24px">
                                                            开户行:
                                                        </td>
                                                        <td width="35%" align="left" class="dvtCellInfo" style="height: 24px">
                                                            <asp:TextBox ID="Tbx_OpeningBank" runat="server" MaxLength="20" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel" style="height: 24px">
                                                            银行账户:
                                                        </td>
                                                        <td width="35%" align="left" class="dvtCellInfo" style="height: 24px">
                                                            <asp:TextBox ID="Tbx_BankAccount" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" align="right" class="dvtCellLabel" style="height: 24px">
                                                            代理费单价:
                                                        </td>
                                                        <td width="35%" align="left" class="dvtCellInfo" style="height: 24px" colspan="3">
                                                            <asp:TextBox ID="Tbx_DlPrice" runat="server"  CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>联系人</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" align="right" class="dvtCellLabel" style="height: 24px">
                                                        首要联系人:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo" style="height: 24px">
                                                        <asp:TextBox ID="CustomerContact" runat="server" MaxLength="20" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="150px"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                ID="RequiredFieldValidator7" runat="server" ErrorMessage="负责人不能为空！" ControlToValidate="CustomerContact"
                                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel" style="height: 24px">
                                                        性 别:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo" style="height: 24px">
                                                        <asp:RadioButtonList ID="CustomerContactSex" runat="server" Width="120px" RepeatLayout="Flow"
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
                                                            <asp:ListItem Value="女">女</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        移动电话:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="CustomerMobile" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="20"></asp:TextBox>(<font
                                                                color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                    ErrorMessage="不能为空！" ControlToValidate="CustomerMobile" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        固定电话:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="CustomerTel" runat="server" MaxLength="20" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="150px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>生产要求</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                        <table id="FHTable" class="ListDetails" width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                            <tr id="tr3">
                                                                <td align="center" class="ListHead">
                                                                    名称
                                                                </td>
                                                                <td align="center" class="ListHead">
                                                                    发货说明
                                                                </td>
                                                                <td align="center" class="ListHead">
                                                                    删除
                                                                </td>
                                                            </tr>
                                                            <%=s_Fh_Detail %>    
                                                        </table>
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3">
                                                
                                                        <input id="Button2" class="crmbutton small create" onclick="return btnGetFH_onclick()"
                                                                     type="button" value="添加" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>地址信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="dvtCellLabel" style="height: 24px">
                                                        <asp:ImageButton ID="ImageButton_down" runat="server" ImageUrl="/images/down.jpg"
                                                            Visible="false" CausesValidation="false" OnClick="ImageButton_down_Click" /><asp:ImageButton
                                                                ID="ImageButton_up" runat="server" ImageUrl="/images/up.jpg" OnClick="ImageButton_up_Click"
                                                                CausesValidation="false" />
                                                        通信地址:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo" style="height: 24px">
                                                        <asp:TextBox ID="CustomerAddress" runat="server" MaxLength="90" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="250px"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="dvtCellLabel">
                                                        电子邮箱:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <asp:TextBox ID="CustomerEmail" runat="server" MaxLength="60" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="150px"></asp:TextBox><asp:RegularExpressionValidator ID="UsersEmail1aa" runat="server"
                                                                ErrorMessage="邮箱输入错误！" ControlToValidate="CustomerEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                        所在省份:
                                                    </td>
                                                    <td width="35%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="sheng" Style="width: 150px" runat="server" OnChange="GetCustomerID()" AutoPostBack="true" OnSelectedIndexChanged="sheng_SelectedIndexChanged" >
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                                            runat="server" ErrorMessage="所在省份不能为空！" ControlToValidate="sheng" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="17%" align="right" class="dvtCellLabel">
                                                        所在城区:
                                                    </td>
                                                    <td width="32%" align="left" class="dvtCellInfo">
                                                        <asp:DropDownList ID="city" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <asp:Panel runat="server" ID="Pan_Other">
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" style="height: 24px">
                                                            联系QQ号:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" style="height: 24px">
                                                            <asp:TextBox ID="CustomerQQ" runat="server" MaxLength="15" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox><asp:RegularExpressionValidator ID="UsersQQ1bb" runat="server"
                                                                    ErrorMessage="QQ输入错误！" ControlToValidate="CustomerQQ" ValidationExpression="^[1-9]*[1-9][0-9]*$"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel" style="height: 24px">
                                                            联系Msn号:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" style="height: 24px">
                                                            <asp:TextBox ID="CustomerMsn" runat="server" MaxLength="50" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                                    runat="server" ErrorMessage="Msn输入错误！" ControlToValidate="CustomerMsn" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td width="16%" align="right" class="dvtCellLabel" style="height: 24px">
                                                            税务登记号:
                                                        </td>
                                                        <td width="35%" align="left" class="dvtCellInfo" style="height: 24px" colspan="3">
                                                            <asp:TextBox ID="Tbx_RegistrationNum" runat="server" MaxLength="20" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">
                                                            传真:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="CustomerFax" runat="server" MaxLength="20" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel" style="height: 24px">
                                                            邮政编码:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" style="height: 24px">
                                                            <asp:TextBox ID="CustomerZipCode" runat="server" MaxLength="8" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="150px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator10"
                                                                    runat="server" ErrorMessage="邮政编码错误！" ControlToValidate="CustomerZipCode" ValidationExpression="^[0-9]\d{5}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="right" class="dvtCellLabel">
                                                            默认积分:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="CustomerIntegral" Text="0" MaxLength="10" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="整数"
                                                                ControlToValidate="CustomerIntegral" ValidationExpression="^\+?[0-9][0-9]*$"
                                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">
                                                            <b>是否保护客户</b>:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:CheckBox ID="CustomerProtect" runat="server" Checked="false" /><font color="gray">（是保护客户请打勾）</font>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td height="25" align="right" class="dvtCellLabel">
                                                            客户简介:
                                                        </td>
                                                        <td colspan="3" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="CustomerIntroduction" runat="server" Style="display: none;"></asp:TextBox>
                                                            <iframe src='../../eWebEditor/ewebeditor.htm?id=CustomerIntroduction&style=gray' frameborder='0'
                                                                scrolling='no' width='620' height='350'></iframe>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <asp:TextBox ID="Xs_MaterID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                    <td
                                                        height="25" align="right" class="dvtCellLabel" rowspan="2">
                                                        选择销售产品:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3">
                                                        <table id="myTable" width="50%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                            <tr id="tr1">
                                                                <td align="center" class="dvtCellLabel">
                                                                    产品编码
                                                                </td>
                                                                <td align="center" class="dvtCellLabel">
                                                                    产品名称
                                                                </td>
                                                                <td align="center" class="dvtCellLabel">
                                                                    产品型号
                                                                </td>
                                                                <td align="center" class="dvtCellLabel">
                                                                    删除
                                                                </td>
                                                            </tr>
                                                            <%=s_MyTable_Detail %>    
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3">
                                                
                                                                    <input id=" btnGetReturnValue" class="crmbutton small create" onclick="return btnGetReturnValue_onclick1()"
                                                                        type="button" value="选择产品" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center" style="height: 30px">
                                                        <asp:Button ID="Button1" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
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
                                <asp:TextBox ID="Tbx_LinkManID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>

                            </td>
                        </tr>
                    </table>
            </td>
            <td align="right" valign="top">
                <img src="/themes/softed/images/showPanelTopRight.gif" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
