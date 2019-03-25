<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PB_Products_Brand_Add.aspx.cs"
    Inherits="PB_Products_Brand_Add" %>

<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <title>产品品牌添加</title>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript">

        function btnGetBomProducts_onclick1() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            v_newNum = $("Products_BomNum").value;
            //var tempd = window.showModalDialog("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "&callBack=SetReturnValueInOpenner_ProductsDemo1", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }

        function deleteRow2(obj) {
            ProductsBomTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("DemoProdoctsBarCode");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Products_BomID").value = bm_num;
        }

        function SetReturnValueInOpenner_ProductsDemo1(tempd) {
            if (tempd != undefined) {
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsBomTable.rows.length;
                s_ID = document.all("Products_BomID").value + ",";
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split(",");
                    var objRow = ProductsBomTable.insertRow(i_row);
                    v_newNum = parseInt(v_newNum) + i + 1;

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[4];

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[1];

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[3];

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"Remarks_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;width:300px\" value="" >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"BzNumber_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;width:50px\" value=' + s_Value[2] + '  >'

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '&nbsp;<input type=input Name=\"ProductsBarCode_' + v_newNum + '\" style=\"display:none;\" value=' + s_Value[0] + ' >';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '&nbsp;<input type=input Name=\"ProductsEdition_' + v_newNum + '\" style=\"display:none;\" ><A onclick=\"deleteRow2(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                $("Products_BomID").value = s_ID;
                $("Products_BomNum").value = v_newNum;  
            }
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品 ><a class="hdrLink" href="PB_Basic_Where_List.aspx">产品品牌添加</a>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>品牌
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
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top">
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>

                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">品牌名称：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <pc:PTextBox ID="Tbx_Name" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="200px" ValidType="String"></pc:PTextBox><font
                                                                    color="red">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">备注：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left" colspan="3">
                                                            <pc:PTextBox runat="server" ID="Tbx_Remarks" TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="280px" Height="50px"></pc:PTextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td
                                                            height="25" align="right" class="dvtCellLabel">关联产品:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3">

                                                            <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                            <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="2" cellspacing="1" class="ListDetails">
                                                                <tr id="tr2">
                                                                    <td align="center" class="ListHead">料号
                                                                    </td>
                                                                    <td align="center" class="ListHead">产品名称
                                                                    </td>
                                                                    <td align="center" class="ListHead">版本号
                                                                    </td>
                                                                    <td align="center" class="ListHead">备注
                                                                    </td>
                                                                    <td align="center" class="ListHead">包装数
                                                                    </td>
                                                                    <td align="center" class="ListHead">品牌型号
                                                                    </td>
                                                                    <td align="center" class="ListHead">操作
                                                                    </td>
                                                                </tr>

                                                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"></td>
                                                        <td colspan="3" align="left">
                                                            <input id="Button4" runat="server" class="crmbutton small create" onclick="return btnGetBomProducts_onclick1()" type="button" value="选择材料" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="height: 30px; width: 70px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
