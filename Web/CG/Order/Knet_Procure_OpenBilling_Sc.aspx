<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Knet_Procure_OpenBilling_Sc.aspx.cs" Inherits="Web_Sales_Knet_Procure_OpenBilling_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <title>生成采购订单</title>
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <link rel="stylesheet" href="/Web/css/ihwy-2012.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="/Web/cssjquery.listnav-2.1.css" type="text/css" media="screen" charset="utf-8" />
    <script type="text/javascript" src="/Web/js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.cookie.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.idTabs.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="/Web/js/jquery.listnav-2.1.js" charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            if (top.location.href.toLowerCase() == self.location.href.toLowerCase()) $('#docLink').show();
            $("#tabNav ul").idTabs("tab2");
        });
        $("Btn_Save").click(function(){    $(this).attr("disabled","disabled");    });

        
        function ChangPrice() {
            var num = document.all('Tbx_Num').value;
            for (var i = 0; i < num; i++) {
                var CPBZNumber = document.all("Tbx_CPBZNumber_" + i).value;
                var BZNumber = document.all("Tbx_BZNumber_" + i).value
                if ((CPBZNumber != 0) && (BZNumber != 0)) {
                    document.all("Tbx_Number_" + i).value = CPBZNumber * BZNumber;
                }
            }
        }

        function dpChange() {
            var num = document.all('Tbx_Num').value;
            for (var i = 0; i < num; i++) {
                document.all("Ddl_Price_" + i).value = document.all("Ddl_SuppNo_" + i).value;
                var obj = document.getElementById("Ddl_Price_" + i); //selectid

                var index = obj.selectedIndex; // 选中索引

                var text = obj.options[index].text; // 选中文本

                var valu = obj.options[index].value; // 选中值
                document.all("Pri_" + i).value = text;
            }
        }

        //function dpriceChange(obj) {
        //    var ths = obj;
        //    ths.selectIndex = 0;
        //    alert("不能选单价");
            


        //}

        //function Checkd(obj) {
        //    var ths = obj;
        //    var strna = ths.value;
        //    if (strna == "off") {
        //        strna = "one";
        //        ths.value = strna;
        //    } else {
        //        //strna = strna.substring(0, strna.lastIndexOf('#'));
        //        //ths.name = strna;
        //        strna = "off";
        //        ths.value = strna;
        //    }
        //}
    </script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            border: 1px solid #DDDDDD;
            padding: 5px;
            background: #dddcdd url('/themes/softed/images/inner.gif') repeat-x 50% bottom;
            color: #000000;
            height: 27px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购 > 
	<a class="hdrLink" href="Knet_Procure_OpenBilling_Manage.aspx">生成采购订单</a>
                </td>
                <td width="100%" nowrap>
                    <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>&nbsp;
                    <asp:Label ID="Tbx_SuppNo" runat="server" Style="display: none"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px"></div>
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
                    <br>
                    <hr noshade size="1">

                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">

                        <tr>
                            <td>
                                <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">

                                    <tr>
                                        <td>
                                            <asp:Panel ID="Pan_Order" runat="server">

                                                <div class="demoWrapper">


                                                    <div id="tabNav">
                                                        <ul>
                                                            <li><a href="#tab1">基本信息</a></li>
                                                            <li><a href="#tab2">生成信息</a></li>
                                                        </ul>
                                                        <div class="clr"></div>
                                                    </div>
                                                    <!--基本信息-->
                                                    <div id="tabs">

                                                        <div id="tab1" class="tab">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                <tr>
                                                                    <td valign="top" align="left" colspan="4">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" id="Table_Btn" runat="server">
                                                                            <tr>
                                                                                <td>
                                                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('Knet_Procure_OpenBilling.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;" style="height: 26px; width: 60px">
                                                                                    <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Procure_OpenBilling_Manage.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" style="height: 26px; width: 80px">
                                                                                    &nbsp;

                                                        &nbsp;<asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批" OnClick="btn_Chcek_Click" Style="height: 26px; width: 60px" />

                                                                                </td>
                                                                                <td align="right"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">采购单号:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Code" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="dvtCellLabel">采购日期:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="dvtCellLabel">预到日期:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_PreTime" runat="server" Width="150px"></asp:Label>&nbsp;</td>
                                                                    <td class="dvtCellLabel">供应商:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Supp" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">入库状态:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="lbl_isRuk" runat="server" Width="150px"></asp:Label>&nbsp;</td>
                                                                    <td class="dvtCellLabel">付款单状态:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_IsPayMent" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="17%" class="dvtCellLabel">遥控器订单:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_ParentOrderNo" runat="server" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                                    </td>

                                                                    <td class="dvtCellLabel">合同订单:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_ContractNo" runat="server" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">选择收货供应商:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_SelectSupp" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="dvtCellLabel">采购部门:</td>
                                                                    <td class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Depart" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="dvtCellLabel">采购类型:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_OrderType" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="dvtCellLabel">送货地址:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_Address" runat="server"></asp:Label>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">备注说明:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">生产说明:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_ScDetails" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="dvtCellLabel">PDF:</td>
                                                                    <td class="dvtCellInfo" colspan="3">
                                                                        <asp:Label ID="Lbl_PDF" runat="server" Width="150px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="dvInnerHeader">
                                                                        <b>产品详细信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%" colspan="4">
                                                                        <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                                            class="ListDetails">

                                                                            <tr valign="top">
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>产品名称</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>料号</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>版本号</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>数量</b></td>
                                                                                <td class="ListHead" colspan="2" nowrap>
                                                                                    <b>单价</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>金额</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>未入库数量</b></td>
                                                                                <td class="ListHead" rowspan="2" nowrap>
                                                                                    <b>备注</b></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="ListHead" nowrap>
                                                                                    <b>材料</b></td>
                                                                                <td class="ListHead" nowrap>
                                                                                    <b>加工费</b></td>
                                                                            </tr>
                                                                            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>

                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>

                                                        <div id="tab2" class="tab">

                                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">


                                                                <tr>
                                                                    <td class="dvInnerHeader">
                                                                        <asp:CheckBoxList runat="server" ID="Ddl_Moudle" CssClass="detailedViewTextBox" Width="100%" RepeatColumns="3"></asp:CheckBoxList>
                                                                        <asp:Button ID="Button3" runat="server" class="crmbutton small edit" Text="审批所有订单" OnClick="Button3_Click" Style="height: 33px; width: 100px" />
                                                                        <asp:Button ID="Button4" runat="server" class="crmbutton small edit" Text="反审批所有订单" OnClick="Button6_Click" Style="height: 33px; width: 100px" />

                                                                        <asp:Button ID="Button1" runat="server" class="crmbutton small edit" Text="生成" OnClick="Button1_Click" Style="height: 33px; width: 70px" />

                                                                    </td>
                                                                </tr>
                                                                
                                                                    
                                                                    <tr>
                                                                        <td colspan="2" class="dvInnerHeader">
                                                                            <b>生成分类选择</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">

                                                                            <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                                                class="ListDetails">

                                                                                <tr valign="top">
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>序号</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                    <input type="CheckBox" onclick="selectAllPage(this)" checked>
                                                                                        <b>类别</b></td>
                                                                                </tr>
                                                                                <asp:Label runat="server" ID="Lbl_Type"></asp:Label>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                            </table>
                                                            <asp:Panel ID="Pan_Sc" runat="server" Visible="false">

                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                    <tr>
                                                                        <td colspan="2" class="dvInnerHeader">
                                                                            <b>产品详细信息</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">发件人：
                                                                        </td>
                                                                        <td class="dvtCellInfo" align="left">
                                                                            <asp:DropDownList runat="server" ID="Ddl_SendEmail" CssClass="detailedViewTextBox" Width="400px"></asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">

                                                                            <table width="100%" border="0" align="center" cellpadding="2" cellspacing="0"
                                                                                class="ListDetails">

                                                                                <tr valign="top">
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>序号</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <%--onclick="selectAllPage(this)" checked--%>
                                                                                    <input type="CheckBox">
                                                                                        <b>类别</b>
                                                                                    </td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>BOM序号</b></td>
                                                                                    <td class="ListHead" nowrap width="250px">
                                                                                        <b>版本号</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>包装数</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>小包数</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>数量</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>供应商和单价</b></td>
                                                                                    <td class="ListHead" nowrap width="30px">
                                                                                        <b>单价</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>要求日期</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>预入仓库</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>采购方式</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>库存</b></td>
                                                                                    <td class="ListHead" nowrap>
                                                                                        <b>OEM缺料</b></td>
                                                                                    <td class="ListHead" nowrap width="50px">
                                                                                        <b>操作</b></td>
                                                                                </tr>
                                                                                <asp:Label runat="server" ID="Lbl_SDetail"></asp:Label>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                     
                                                                        <td align="center" style="height: 30px" colspan="2">
                                                                            <asp:Button ID="Btn_Save" runat="server" Text="执行" AccessKey="S" title="执行 [Alt+S]"
                                                                                class="crmbutton small save" OnClick="Btn_Click" Style="width: 55px; height: 30px;" />
                                                                            <asp:Button ID="Button2" runat="server" Text="取消" AccessKey="S" title="取消 [Alt+S]"
                                                                                class="crmbutton small save" OnClick="Button2_Click" Style="width: 55px; height: 30px;" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                    </table>

                </td>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

