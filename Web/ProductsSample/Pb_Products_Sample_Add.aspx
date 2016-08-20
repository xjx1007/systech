<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pb_Products_Sample_Add.aspx.cs"
    Inherits="Web_Sales_Pb_Products_Sample_Add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>样品申请</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>

<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick1()  
    {   
       /*选择客户*/
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       
       var tempd= window.showModalDialog("../Common/SelectClientProductsList.aspx?sID="+document.all("Xs_MaterID").value+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
     
       if(tempd!=undefined)   
       {   
      
          	 var ss,s_Value,s_Name,i_row,sd;
	         ss=tempd.split("|");  
	         i_row = myTable.rows.length;
	         s_ID=document.all("Xs_MaterID").value;
	         for(var i=0; i< ss.length;i++)
	         {
	         
	            sd=ss[i].split(",");
                 s_ProductsBarCode=sd[0]; 
                 s_ProductsName=sd[1];   
                 s_ProductsPattern=sd[2];   
	            var objRow = myTable.insertRow(i_row);
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\" input Name=\"ProductsBarCode\" value='+s_ProductsBarCode+'>'+s_ProductsBarCode; 
                objCel.className="dvtCellLabel";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input  type=\"hidden\"  Name=\"ProductsName\" value='+s_ProductsName+' >'+s_ProductsName; 
                objCel.className="dvtCellLabel";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\" input Name=\"ProductsPattern\" value='+s_ProductsPattern+'>'+s_ProductsPattern; 
                objCel.className="dvtCellLabel";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"button\" Name=\"Del\" onclick=\"deleteRow(this)\" value=删除 >';
                objCel.className="dvtCellLabel";
                i_row=i_row+1;
                s_ID =s_ID + s_ProductsBarCode+",";
	         }
	         document.all("Xs_MaterID").value = s_ID;
        }   
    }
    
    
   function deleteRow(obj){
   myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
    var Values =document.getElementsByName("ProductsBarCode"); 
    var bm_num="";
    for(i=0;i<Values.length;i++){  
        bm_num += Values[i].value+",";   
    }
    document.all("Xs_MaterID").value=bm_num;
   }

   


   function btnGetProducts_onclick1() {
       /*选择客户*/
       var today, seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var tempd = window.showModalDialog("SelectProductsDemo.aspx?CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

       if (tempd == undefined) {
           tempd = window.returnValue;
       }
       if (tempd != undefined) {
           ss = tempd.split(",");
           document.all('Tbx_ProductsBarCode').value = ss[0];
           document.all('Tbx_ProductsBarName').value = ss[1];
       }
       else {
           document.all('Tbx_ProductsBarCode').value = "";
           document.all('Tbx_ProductsBarName').value = "";
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


    function btnGetProducts_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();

        var tempd = window.showModalDialog("SelectProducts.aspx?CustomerValue=" + document.all("Tbx_CustomerValue").value + "&BigClass=130071106918679373", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        if (tempd != undefined) {

            var ss, s_Value, i_row;

            ss = tempd.split("|");

            document.all("Tbx_Shell").value = ss[0];
            document.all("Tbx_ShellName").value = ss[1];
        }
    }

    function deleteRow(obj) {
        myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        var Values = document.getElementsByName("ProductsBarCode");
        var bm_num = "";
        for (i = 0; i < Values.length; i++) {
            bm_num += Values[i].value + ",";
        }
        document.all("Xs_ProductsCode").value = bm_num;
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                样品申请 > <a class="hdrLink"  href="Pb_Products_Sample_List.aspx">样品申请</a>
            </td>
            
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="Tbx_Code" runat="server" Style="display: none"></asp:TextBox>
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
                <div class="small" style="padding: 10px">
                </div>
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
                                        样品申请信息
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
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>基本信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    申请主题:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Name" AllowEmpty="false" ValidError="申请主题不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    申请日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    申请人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server"
                                                        Width="100px">
                                                    </asp:DropDownList>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人"
                                                        ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    需要日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_NeedTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                    
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择需要日期"
                                                        ControlToValidate="Tbx_NeedTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="17%" class="dvtCellLabel">
                                                    客户:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                        style="width: 150px" />
                                                    <pc:PTextBox ID="Tbx_CustomerName" Enabled="false" runat="server" CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Width="150px" ></pc:PTextBox>
                                                    <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                        onclick="return btnGetReturnValue_onclick()" />
                                                </td>
                                                <td class="dvtCellLabel">
                                                    联系人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_LinkMan" CssClass="detailedViewTextBox" runat="server"
                                                        Width="100px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    申请状态:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_Dept" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                                    </asp:DropDownList>(<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请选择状态"
                                                        ControlToValidate="Ddl_Dept" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    样品类型:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                    <asp:DropDownList ID="Ddl_Type" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                                    </asp:DropDownList>(<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请选择样品类型"
                                                        ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    选择产品:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                    <input type="hidden" name="Tbx_ProductsBarCode" id="Tbx_ProductsBarCode" runat="server"
                                                        style="width: 150px" />
                                                    <pc:PTextBox ID="Tbx_ProductsBarName" Enabled="false" runat="server" CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Width="150px" ></pc:PTextBox>
                                                    <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                        onclick="return btnGetProducts_onclick1()" />
                                                  <font color="red">如果是客户修改产品，请选择原有产品型号！</font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>样品要求</b>
                                                </td>
                                            </tr>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        外壳:
                                    </td>
                                    <td class="dvtCellInfo">
                                                    <input type="hidden" name="Tbx_Shell" id="Tbx_Shell" runat="server"
                                                        style="width: 150px" />
                                        <pc:PTextBox runat="server" ID="Tbx_ShellName" Enabled="false" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                        onclick="return btnGetProducts_onclick()" />
                                    </td>
                                    <td class="dvtCellLabel">
                                        外形:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <asp:CheckBox runat="server" ID="Chk_Appearance" Text="是否喷漆" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        导电胶:
                                    </td>

                                    <td class="dvtCellInfo">
                                        <pc:PTextBox runat="server" ID="Tbx_Resin" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                    </td>
                                    <td class="dvtCellLabel">
                                        导电胶材料:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <asp:CheckBox runat="server" ID="Chk_ResinMaterial" Text="是否喷油" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        芯片:
                                    </td>
                                    <td class="dvtCellInfo" >
                                        <pc:PTextBox runat="server" ID="Tbx_Chip" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                    </td>
                                    <td class="dvtCellLabel">
                                        申请数量:
                                    </td>
                                    <td class="dvtCellInfo" >
                                        <pc:PTextBox runat="server" ID="Tbx_Number" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'"  Text="1" Width="150px"></pc:PTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel" style="height: 47px">
                                        样品要求:
                                    </td>
                                    <td class="dvtCellInfo" style="height: 47px">
                                        <asp:TextBox ID="Tbx_Requirement" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="300px" Height="80px"></asp:TextBox>
                                    </td>
                                    <td class="dvtCellLabel" style="height: 47px">
                                        样品用途:
                                    </td>
                                    <td class="dvtCellInfo"  style="height: 47px">
                                        <asp:TextBox ID="Tbx_Use" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="300px" Height="80px"></asp:TextBox>
                                    </td>
                                    </tr>
                                <asp:Panel runat="server" ID="Pan_Details" Visible="false">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>产品信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellInfo" colspan="4">
                                        <table id="Table1" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                            class="ListDetails" style="height: 28px">
                                            <!-- Header for the Product Details -->
                                            <tr valign="top">
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>产品</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>样品要求</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>产品参数</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>库存数量</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>未入库采购单</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>处理方式</b>
                                                </td>
                                            </tr>
                                            <asp:Label runat="server" ID="Lbl_ProductsDetails"></asp:Label>
                                        </table>
                                    </td>
                                    </tr>
                                </asp:Panel>
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>资料信息</b>
                                        </td>
                                    </tr>
                                </tr>
                                <asp:TextBox ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                <tr id="AddPic" runat="server">
                                    <td class="dvtCellInfo" colspan="4">
                                        <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                            class="ListDetails" style="height: 28px">

                                            <!-- Header for the Product Details -->
                                            <tr valign="top">
                                                <td valign="top" class="ListHead" align="left" nowrap>
                                                    <b>工具</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>名称</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>资料</b>
                                                </td>
                                            </tr>
                                            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        名称:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <pc:PTextBox runat="server" ID="Tbx_PicName"    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox> 
                                    </td>
                                    <td class="dvtCellLabel">
                                        上传:
                                    </td>
                                    <td class="dvtCellInfo">
                                        <input id="uploadFile" type="file" runat="server" class="Boxx" size="30" />&nbsp;
                                        <input id="button" type="button" value="上传" runat="server" class="crmbutton small save" onserverclick="button_ServerClick"
                                            causesvalidation="false" />
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="4" class="detailedViewHeader">
                                        <b>描述信息</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="dvtCellLabel">
                                        备注:
                                    </td>
                                    <td class="dvtCellInfo" colspan="4">
                                        <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                            Width="300px" Height="40px"></asp:TextBox>
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
                                class="crmbutton small save" OnClick="Btn_SaveOnClick"  style="width: 55px; height: 30px"/>
                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                type="button" name="button" value="取 消" style="width: 55px; height: 30px">
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
    </tr> </table>
    </form>
</body>
</html>
