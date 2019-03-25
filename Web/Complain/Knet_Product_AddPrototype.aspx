<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Product_AddPrototype.aspx.cs" Inherits="Web_Complain_Knet_Product_AddPrototype" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <script src="../../assets/js/libs/jquery-1.10.2.min.js"></script>
    <title>治具管理</title>
    <script language="JAVASCRIPT">

        function btnGetProducts_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var TxbSuppNo = document.all('SuppNo').value;
            //if (document.all('SamplingID').value=="") {
            var tempd = window.open("../Products/SelectProductsDemo.aspx?sID=&ScNo=&SuppNo=&Contract=&isModiy=", "选择产品", "width=1200px, height=900,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            //} 
            //else {
            //var tempd = window.open("SelectSampling.aspx?SamplingID="+document.all('SamplingID').value+"", "选择样品申请", "width=1200px, height=900,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            //} else {
            //var tempd = window.open("SelectSampling.aspx?SamplingID=", "选择样品申请", "width=1200px, height=900,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            //}

        }
        function SetReturnValueInOpenner_ProductsDemo(tempd) {
            if (tempd != undefined) {
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = myTable.rows.length;
                //s_ID = document.all("Products_BomID").value + ",";
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split("!");
                    var objRow = myTable.insertRow(i_row);
                    //v_newNum = parseInt(v_newNum) + i + 1;
                    v_newNum1 = i;
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '&nbsp;<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ProdoctsBarCode_' + i_row.toString() + '\" style=\"display:none;\" value=' + s_Value[0] + ' >' + s_Value[0];


                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ProdoctName_' +
                        i_row.toString() +
                        '\"  ID=\"ProdoctName_' +
                        i_row.toString() +
                        '\"  style=\"detailedViewTextBox;width:300px\"  onblur=\"onPlaceblur()\"  value=' +
                        s_Value[1] +
                        ' >';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ProdctsEdition_' + i_row.toString() + '\"  ID=\"ProdctsEdition_' + i_row.toString() + '\"  style=\"detailedViewTextBox;width:300px\"    value=' + s_Value[3] + ' >';

                    i_row = i_row + 1;
                    //s_ID = s_ID + s_Value[0] + ",";
                }
                //$("Products_BomID").value = s_ID;
                //alert(v_newNum1);
                document.all('Tbx_Num').value = i_row + 1;
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
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>治具 > <a class="hdrLink" href="Knet_Procure_OpenBilling_Manage.aspx">治具添加</a>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>治具添加信息
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                        </tr>
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
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">编号:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox ID="KPG_KID" MaxLength="45" runat="server" Width="200px" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>(<font
                                                                    color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="采购单号不能为空"
                                                            ControlToValidate="KPG_KID" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">名称:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox ID="KPG_Name" MaxLength="45" runat="server" Width="150px" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">添加日期:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="KPG_Stime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                                color="red">*</font>)<br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="送检日期非空"
                                                                ControlToValidate="KPG_Stime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">添加数量:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox ID="KPG_Number" MaxLength="45" runat="server" Width="150px" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">&nbsp;类别:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="BClass" runat="server"></asp:DropDownList>(<font color="red">*</font>)
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">所在处:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_HouseNo"></asp:DropDownList>
                                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="所在处不能为空"
                                                ControlToValidate="Ddl_HouseNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                         <td class="dvtCellLabel" align="right">上传文件：
                                                        </td>

                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Details1"></asp:Label><input id="uploadFile2"
                                                                type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button2" type="button"
                                                                    value="上传" runat="server" class="crmbutton small save" causesvalidation="false" />

                                                        </td>
                                                       
                                                        <td align="right" class="dvtCellLabel">生产说明:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="KPG_Text" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Height="50px" TextMode="MultiLine"
                                                                Width="500px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="dvInnerHeader" align="left">
                                                            <b>治具适用产品</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" align="left">
                                                            <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_Num" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                            <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="ListDetails" style="height: 28px">
                                                                <!-- Header for the Product Details -->
                                                                <tr valign="top">
                                                                    <td valign="top" class="ListHead" align="right" nowrap>
                                                                        <b>工具</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品编码</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品名称</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>型号</b>
                                                                    </td>


                                                                </tr>
                                                                <%-- <%=s_MyTable_Detail %>--%>
                                                                <asp:Label runat="server" ID="s_MyTable_Detail"></asp:Label>
                                                            </table>
                                                            <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                                                <!-- Add Product Button -->
                                                                <tr>
                                                                    <td colspan="3">①选择产品:
                                                        <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" Style="width: 55px; height: 30px;" OnClick="Btn_Save_OnClick" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px; height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="NumCount" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_OrderNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Title" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Change" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_OldID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Sampling" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="UploadUrl" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="UploadUrlName" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
            </tr>
        </table>
        </td>
    <td align="right" valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif" />
    </td>
        </tr> </table>
    </form>
</body>
</html>
