<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpLoad_AddForProducts.aspx.cs" Inherits="UpLoad_AddForProducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <base target="_self" />
    <title>添加产品附件</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <script type="text/javascript" src="../../themes/js/jquery/jquery.min.js"></script>

    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script type="text/javascript" src="/Web/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script src="../../assets/js/libs/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        function Change() {
            debugger;
            var myselect = document.getElementById("Ddl_Type");
            var index = myselect.selectedIndex; // selectedIndex代表的是你所选中项的index
            //var value= myselect.options[index].value;//3:拿到选中项options的value：
            var v_TypeName = myselect.options[index].text;//4:拿到选中项options的text：
            //var v_TypeName = document.getElementById("Ddl_Type").text;
            //alert($("#Products_BomID").val);
            if ((v_TypeName == "烧录文件") || (v_TypeName == "制板文件")) {
                document.getElementById("Tr_Version").style.visibility = "visible";
                document.getElementById("Tr_Version").style.display = "";
                document.getElementById("EndTime").style.visibility = "hidden";
                document.getElementById("EndTime").style.display = "none";
            }
            else if (v_TypeName == "环保资料") {
                document.getElementById("EndTime").style.visibility = "visible";
                document.getElementById("EndTime").style.display = "";
                document.getElementById("ProductType").style.visibility = "visible";
                document.getElementById("ProductType").style.display = "";
            }
            else if (v_TypeName == "物料说明书") {
                document.getElementById("ProductType").style.visibility = "visible";
                document.getElementById("ProductType").style.display = "";
                document.getElementById("EndTime").style.visibility = "hidden";
                document.getElementById("EndTime").style.display = "none";
                document.getElementById("Tr_Version").style.visibility = "hidden";
                document.getElementById("Tr_Version").style.display = "none";

            }
            else {
                document.getElementById("Tr_Version").style.visibility = "hidden";
                document.getElementById("Tr_Version").style.display = "none";
                document.getElementById("EndTime").style.visibility = "hidden";
                document.getElementById("EndTime").style.display = "none";
            }
        }
        function btnGetFJReturnValue_onclick() {
            /*新增附件*/
            var webroot = document.location.href;
            webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
            webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
            webroot = webroot.substring(0, webroot.indexOf('/'));
            rootpath = "http://" + webroot + "";

            rootpath += "/Web";

            var tempd = window.open(rootpath + "/Upload/UpLoad_AddForProducts.aspx", "上传附件", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function btnGetBomProducts_onclick1() {
            if (document.all('Tbx_ProductsTypeName').value.length > 0) {
                alert('你已经选择产品分类，不可再选产品');
            } else {
                var today, seconds;
                today = new Date();
                intSeconds = today.getSeconds();
                //v_newNum = $("Products_BomNum").value;
                //var tempd = window.showModalDialog("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
                var tempd = window.open("../Products/SelectProductsDemo.aspx?ID=5&callBack=SetReturnValueInOpenner_ProductsDemo", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }

        }
        function SetReturnValueInOpenner_ProductsDemo(tempd) {
            if (tempd != undefined) {
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsBomTable.rows.length;
                s_ID = document.all("Products_BomID").value;
                ss = tempd.split("|");
                var v_newNum = $("#Products_BomNum").val();
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split("!");
                    var objRow = ProductsBomTable.insertRow(i_row);
                    v_newNum = parseInt(v_newNum) + 1;

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoOrder_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;width:50px\" value=' + v_newNum.toString() + ' >';

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '&nbsp;<A onclick=\"deleteRow2(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[6];

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoProdoctsBarCode_' + v_newNum + '\" style=\"display:none;\" value=' + s_Value[0] + ' >' + s_Value[1];

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[3];

                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                $("#Products_BomID").val(s_ID);
                $("#Products_BomNum").val(v_newNum);
            }
        }
        function deleteRow2(obj) {
            ProductsBomTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var deleteNum = parseInt($("#Products_BomNum").val()) - 1;

            $("#Products_BomNum").val(deleteNum);
        }
        function btnGetProductsTypeValue_onclick() {
            if (document.all('TextBox4').value == "3") {
                return false;
            }//02210268判断是否为编辑，如果为编辑，不能选择产品分类和更改料号
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("/Web/ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("/Web/ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsClass(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsTypeNo').value = ss[0];
                document.all('Tbx_ProductsTypeName').value = ss[1];


            }
            else {
                document.all('Tbx_ProductsTypeNo').value = "";
                document.all('Tbx_ProductsTypeName').value = "";

            }
        }
        function check1() {
            if (document.getElementById("Ddl_Type").value=="") {
                alert("请选择附件分类");
                return false;
            } else {
                
            }
            if (confirm("您确定此操作么")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</head>
<body marginheight="0" marginwidth="0" leftmargin="0" rightmargin="0" bottommargin="0"
    topmargin="0">
    <form method="post" runat="server">
        <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerHeadingULine">
            <tr>
                <td class="layerPopupHeading" align="left">添加产品附件
                </td>
                <td width="70%" align="right">&nbsp;
                </td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="5" width="95%" align="center">
            <tr>
                <td class="small">
                    <table border="0" celspacing="0" cellpadding="5" width="100%" align="center" bgcolor="white"
                        class="small">
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">文件：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <input id="uploadFile" type="file" runat="server" class="Boxx" size="30" onchange="FileUpload_onselect(this)" accept=".xls;.xlsx;.csv;.doc;.docx;.pdf;.txt;.zip;.rar" />
                                <div style="margin-top: 6px; color: #999;">仅支持以下文件类型：xls、xlsx、csv、doc、docx、pdf、txt、zip、rar</div>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">名称：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <pc:PTextBox runat="server" ID="Tbx_Name" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" Width="250px"></pc:PTextBox>
                                (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择需要日期"
                                                        ControlToValidate="Tbx_Name" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">类别：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <asp:DropDownList runat="server" ID="Ddl_Type" onchange="Change()"></asp:DropDownList>
                                (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择类别"
                                                        ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr runat="server" id="EndTime" style="visibility: hidden; display: none">
                            <td width="30%" class="dvtCellLabel" align="right">到期时间：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <pc:PTextBox ID="PBA_EndTime" runat="server" Text="" CssClass="Wdate" onFocus="WdatePicker()"></pc:PTextBox>
                            </td>
                        </tr>
                        <tr id="Tr_Version" style="visibility: hidden; display: none">
                            <td width="30%" class="dvtCellLabel" align="right">版本号：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_Version" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" Width="250px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">更新文件名：
                            </td>
                            <td width="70%" align="left" class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_UpdateID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="Tbx_UpdateName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" Width="250px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td width="30%" class="dvtCellLabel" align="right">描述：
                            </td>
                            <td align="left" class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                    OnBlur="this.className='detailedViewTextBox'" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="ProductType" style="visibility: hidden; display: none">
                            <td align="right" class="dvtCellLabel">产品分类：
                            </td>
                            <td align="left" class="dvtCellInfo">
                                <asp:TextBox ID="Tbx_ProductsTypeName" runat="server" CssClass="detailedViewTextBox"
                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                    MaxLength="48" Width="200px"></asp:TextBox>
                                <asp:TextBox ID="Tbx_ProductsTypeNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProductsTypeValue_onclick()" />
                                (<font color="red">当选择产品分类后，系统会把此分类的所有产品添加当前附件，请慎用！仅供采购部使用</font>)
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <tr id="ProductBom">
            <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
            <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
            <td align="left" class="dvtCellInfo" style="text-align: left">
                <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="0"
                    cellspacing="0" class="ListDetails">
                    <tr id="tr3">
                        <td align="center" class="ListHead">序号
                        </td>
                        <td align="center" class="ListHead">工具
                        </td>
                        <td align="center" class="ListHead">料号
                        </td>
                        <td align="center" class="ListHead">产品名称
                        </td>
                        <td align="center" class="ListHead">版本号
                        </td>

                    </tr>
                    <%=s_ProductsTable_BomDetail %>
                    <asp:Label runat="server" ID="Lbl_Bom" Visible="false"></asp:Label>


                </table>
            </td>
        </tr>
        <tr runat="server" id="tr9">
            <td colspan="4">
                <asp:Label runat="server" ID="Lbl_Error"></asp:Label>
                <input id="Button4" runat="server" class="crmbutton small create" onclick="return btnGetBomProducts_onclick1()" type="button" value="选择共用产品" />
            </td>
        </tr>
        <%--<tr>
            <td align="left" class="dvtCellInfo" style="text-align: left" colspan="2">
                <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="ListDetails">
                    <tr id="tr8">
                         <td align="center" class="ListHead">序号
                        </td>
                        <td align="center" class="ListHead">选择
                        </td>
                        <td align="center" class="ListHead">料号
                        </td>
                        <td align="center" class="ListHead">产品名称
                        </td>
                        <td align="center" class="ListHead">版本号
                        </td>
                       
                    </tr>
                    <asp:Label runat="server" ID="Lbl_ProductsRC"></asp:Label>
                    <asp:TextBox ID="Tbx_RCNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

                </table>
            </td>
        </tr>--%>
        <table border="0" cellspacing="0" cellpadding="5" width="100%" class="layerPopupTransport">
            <tr>
                <td colspan="2" align="center">
                    <asp:Button
                        ID="save" runat="server" Text="上传" CssClass="crmbutton small save" OnClientClick="return check1();"
                        OnClick="save_Click" Width="55px" Height="33px" />&nbsp;&nbsp;
                <input type="button" name="cancel" value="关闭" class="crmbutton small cancel" onclick="self.close();" style="width: 55px; height: 33px" />
                </td>
            </tr>
        </table>
    </form>
    <script>
        var fileTypes = [".xls", ".xlsx", ".csv", ".doc", ".docx", ".pdf", ".PDF", ".txt", ".zip", ".rar",".avi"];
        function FileUpload_onselect(objFileUpload) {
            var path;
            path = objFileUpload.value;
            var name;
            name = path.split('\\');
            var filetype = name[name.length - 1].split(".")[1].toLowerCase();
            if (fileTypes.toString().indexOf(filetype) > -1) {
                var bb = name[name.length - 1];
                document.getElementById('Tbx_Name').value = bb.substr(0, bb.indexOf('.'));  //AddFile 结果
            } else {
                objFileUpload.value = "";
                alert("不支持的文件类型，请重新上传！");
            }
        }
    </script>
</body>
</html>
