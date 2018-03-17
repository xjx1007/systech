<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sc_Expend_View.aspx.cs" Inherits="Web_Sc_Expend_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>查看生产入库和耗料</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script src="../Js/jquery-1.12.4.js"></script>
    <script src="../Js/jquery-1.7.2.min.js"></script>
    <script language="javascript" type="text/javascript">
        function SetReturnValueInOpenner_Product(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_GProductsEdition').value = ss[1];
                if (ss[2]=="0") {
                    document.all('TXB_Genre').value = "A类"
                    document.all('Consume').value = ss[2];
                    document.all('TXB_Genre_Value').value=0
                }
                if (ss[2]=="0.3") {
                    document.all('TXB_Genre').value = "B类";
                    document.all('Consume').value = ss[2];
                    document.all('TXB_Genre_Value').value=1
                }
                if (ss[2]=="0.5") {
                    document.all('TXB_Genre').value = "C类";
                    document.all('Consume').value = ss[2];
                    document.all('TXB_Genre_Value').value=2
                }
                document.all('SED_ProductsBarCode').value = ss[4];
                document.all('ExpendNum').value = ss[5];
            }
            else {
                document.all('Tbx_GProductsEdition').value = "";
                document.all('ExpendNum').value = "";
                document.all('TXB_Genre').value = "";
                document.all('SED_ProductsBarCode').value = "";
            }
        }
        
        function deleteCurrentRow(obj){
           
            var tr=obj.parentNode.parentNode;
            var tbody=tr.parentNode;
            tbody.removeChild(tr);
            //只剩行首时删除表格
            if(tbody.rows.length==1) {
                tbody.parentNode.removeChild(tbody);
            }
            alert(mes)
            //history.go(0)
            $(that).parent().parent().empty();
              
           
        }
        function btnGetProducts_onclick() {
            var SER_ProductsBarCode=document.getElementById("text1").value;
           
            var tep= window.open("Sc_Expend_View_Add.aspx?HouseNo=" +SER_ProductsBarCode+ "", "width=850px", "height=500px");
           
          
            //var tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&HouseNo=" + document.all("HouseNo").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
           
        }
        function btnGetProducts_onclick1() {
            /*选择产品*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectProduct.aspx", "", "dialogtop=150px;dialogleft=160px; dialogwidth=900px;dialogHeight=500px");
            var temp = window.open("SelectProduct.aspx", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>生产消耗 > <a class="hdrLink" href="Sc_Expend_Manage.aspx">生产消耗</a>
                </td>
                <td width="100%" nowrap>
                    <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
                </td>
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
                    <div class="small" style="padding: 10px">
                    </div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <a color="red">审核通过的不能进行物料的添加删除</a>
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>生产消耗信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">&nbsp;
                                        </td>
                                        <td class="dvtUnSelectedCell" align="center" nowrap>
                                            <a href="#">相关信息</a>
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                    <tr>
                                        <td valign="top" align="left">
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                            onclick="PageGo('Sc_Expend_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')"
                                                            name="Edit" value="&nbsp;编辑&nbsp;" style="width: 55px; height: 33px;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('Sc_Expend_Manage.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;" style="width: 80px; height: 33px;">&nbsp;

                                                       <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批" OnClick="btn_Chcek_Click" Style="width: 80px; height: 33px;" />&nbsp;
                                                       <asp:Button ID="Button1" runat="server" Text="添加物料" class="crmbutton small edit" Style="width: 80px; height: 33px;" OnClick="Button1_Click" />
                                                        <%-- <input value="添加物料" type="button" class="crmbutton small edit" Style="width: 80px; height: 33px;"  onclick="btnGetProducts_onclick()" />--%>
                                                    </td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                            onclick="PageGo('Sc_Expend_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')"
                                                            name="Duplicate" value="复制" style="width: 55px; height: 33px;">&nbsp;
                                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                        onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除" style="width: 55px; height: 33px;">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                        <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">入库编号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_BCode" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">入库日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">供应商:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_SuppNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">客户:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_CustomerName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" class="dvtCellLabel">负责人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_DutyPerson" runat="server" Width="178px" ReadOnly="true"></asp:Label>
                                                    </td>
                                                    <td class="dvtCellLabel">产品型号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Lbl_ProductsEdition" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                                <%--添加物料--%>
                                                <div runat="server" id="AddExpend">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>添加物料</b>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">选择物料:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            
                                                            <asp:TextBox ID="Tbx_GProductsEdition" runat="server" CssClass="detailedViewTextBox" Width="200px"></asp:TextBox>(<font color="red">*</font>)
                                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProducts_onclick1()" />
                                                        </td>

                                                        <td class="dvtCellLabel">料号:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="ExpendNum" runat="server" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">单号:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label ID="OddNumbers" runat="server"></asp:Label>
                                                            <asp:TextBox ID="SED_ProductsBarCode" CssClass="Custom_Hidden" runat="server" Text=""></asp:TextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">类型:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                           <%-- <asp:DropDownList ID="GenreDropDownList" runat="server" OnSelectedIndexChanged="GenreDropDownList_SelectedIndexChanged"></asp:DropDownList>--%>
                                                            <asp:TextBox ID="TXB_Genre" runat="server"></asp:TextBox>
                                                            <asp:TextBox ID="TXB_Genre_Value" CssClass="Custom_Hidden" runat="server" Text=""></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="17%" class="dvtCellLabel">耗损比例:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Consume" runat="server" Text=""></asp:TextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">数量:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="17%" class="dvtCellLabel">添加操作:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Button ID="Button2" runat="server" Text="保 存"  class="crmbutton small edit" style="width: 80px; height: 33px;"  OnClick="Button2_Click" />
                                                        </td>
                                                        
                                                    </tr>
                                                        
                                                   
                                                    
                                                </div>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>成品生产信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="ListDetails">
                                                            <tr valign="top">

                                                                <td class="ListHead" nowrap>
                                                                    <b>入库仓库</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>产品名称</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>料号</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>型号</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>数量</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>单价</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>金额</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>加工费单价</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>加工费</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>材料费单价</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>材料费合计</b>
                                                                </td>
                                                            </tr>
                                                            <%=s_MyTable_Detail %>
                                                        </table>
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>原材料信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="ListDetails" id="ProductsBomTable">
                                                            <tr valign="top">
                                                                <td class="ListHead" nowrap>
                                                                    <b>序号</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>单号</b>
                                                                </td>
                                                                <td class="ListHead" runat="server" id="CZ_Done" nowrap>
                                                                    <b>操作</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>产品名称</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>料号</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>型号</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>仓库</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>类型</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>领料人</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>领料时间</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>数量</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>类型</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>损耗比例</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>损耗数量</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>需求数量</b>
                                                                </td>

                                                                <td class="ListHead" nowrap>
                                                                    <b>计算单价</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>计算金额</b>
                                                                </td>
                                                            </tr>
                                                            <%=s_MyTable_Detail1 %>
                                                        </table>



                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b id="sm">采购入库单</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                            <tr valign="top">
                                                                <td class="ListHead" nowrap>
                                                                    <b>入库单号</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>产品名称</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>产品编码</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>型号</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>仓库</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>入库人</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>入库时间</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>数量</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>单价</b>
                                                                </td>
                                                                <td class="ListHead" nowrap>
                                                                    <b>金额</b>
                                                                </td>
                                                            </tr>
                                                            <%=s_MyTable_Detail2 %>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
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
    <input type="text" id="text1" runat="server" value="" style="display: none" />

    <script type="text/javascript" language="javascript">
        //$(".ListHeadDetails").onClick
        $(document).ready(function() {
            //$(docment).on('click','.deleteE', fn())
            $(document).on('click','.deleteExpend',function() {
               
                var statu = confirm("你确定要删除这条数据么");
                if(!statu){
                    return false;
                }
                var that = this;
                //alert($(this).attr("id"));
                    $.ajax({

                        type: "POST",
                        url: "Sc_Expend_View.ashx",
                        data: {
                            deletenum: $(this).attr("id"),
                            action: "Del_Expend"

                        },
                        success: function(mes) {
                            alert('删除成功');
                            history.go(0);
                        }
                    })
                })
            })
            //console.log($(".deleteExpend"));
       

    </script>
</body>
</html>
<%--收货单信息  结束--%>
