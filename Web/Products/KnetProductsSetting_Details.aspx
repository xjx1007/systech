<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KnetProductsSetting_Details.aspx.cs"
    Inherits="Knet_Web_System_KnetProductsSetting_Details" %>
<%@ Register Src="../Control/UploadListForProducts.ascx" TagName="CommentList" TagPrefix="uc2" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            $("#tabNav ul").idTabs("tab1");
        });
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            window.document.body.innerHTML = bdhtml;
        }
        
        function btnGetBomProducts_onclick(ProductsTypeID, Rowi,Details) {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("SelectProductsDemo.aspx?ProductsTypeID=" + ProductsTypeID + "&Details="+Details+"", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {

                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsBomTable.rows.length;
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split(",");
                    var v_ProductsBarCode = s_Value[0];
                    var v_ProductsName = s_Value[1];
                    var v_ProductsEdition = s_Value[3];
                    document.all("ProdoctsBarCode_" + Rowi + "").value =v_ProductsBarCode;
                    document.all("ProductsName_" + Rowi + "").value =v_ProductsName;
                    document.all("ProductsEdition_" + Rowi + "").value = v_ProductsEdition;
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
            }
        }

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
    <title>产品详细信息</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品管理 > <a class="hdrLink" href="KnetProductsSetting.aspx">产品明细</a>
                    </td>
                    <td width="100%" nowrap>
                        <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
                        <asp:Label ID="Tbx_BomNumber" runat="server" Style="display: none"></asp:Label>
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
                            <!--  <tr valign="bottom">
                        <td style="height: 44px">
                                    <table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td <%=s_OrderStyle%> align="center" nowrap><a href="">样品申请信息</a></td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>										
                                    <td <%=s_DetailsStyle%>  align="center" nowrap>
                                    <a href="">相关信息</a></td>
                                    <td class="dvtTabCache" style="width:100%" >&nbsp;</td>
                                    </tr>
                                    </table>
                        </td>
                    </tr>-->
                            <tr>
                                <td>
                                    <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td valign="top" align="left"></td>
                                            <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                                rowspan="2">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="genHeaderSmall">操作
                                                        </td>
                                                    </tr>
                                                    <!-- Module based actions starts -->
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_Create"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_Create1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_Bom"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_BomWithPrice"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_Createsmpale"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_ScProblem"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_Zy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="padding-left: 10px;">
                                                            <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                            <asp:Label runat="server" ID="Lbl_Spce"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Pan_Order" runat="server">
                                                    <div class="demoWrapper">
                                                        <div id="tabNav">
                                                            <ul>
                                                                <li><a href="#tab1">基本信息</a></li>
                                                                <li><a href="#tab2">销售客户</a></li>
                                                                <li><a href="#tab9">导入BOM信息</a></li>
                                                                <li><a href="#tab3">生产问题</a></li>
                                                                <li><a href="#tab4">作业指导书</a></li>
                                                                <li><a href="#tab5">技术文档</a></li>
                                                                <li><a href="#tab7">采购报价信息</a></li>
                                                                <li><a href="#tab6">采购单信息</a></li>
                                                                <li><a href="#tab8">产品成本</a></li>
                                                            </ul>
                                                            <div class="clr"></div>
                                                        </div>

                                                        <div id="tabs">
                                                            <!--基本信息-->
                                                            <div id="tab1" class="tab">

                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <table border="0" cellspacing="0" cellpadding="0" id="Table_Btn" runat="server" width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                                                            onclick="PageGo('KnetProductsSetting_Add.aspx?ID=<%= Request.QueryString["BarCode"].ToString() %>    ')"
                                                                                            name="Edit" value="&nbsp;编辑&nbsp;" style="width: 55px; height: 26px;">&nbsp;

                                                        <input title="" class="crmbutton small edit" onclick="PageGo('KnetProductsSetting.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;" style="width: 70px; height: 26px;">
                                                                                        <input title="升级 [Alt+J]" type="button" accesskey="E" class="crmbutton small edit"
                                                                                            onclick="PageGo('KnetProductsSetting_Add.aspx?ID=<%= Request.QueryString["BarCode"].ToString() %>    &Type=2')"
                                                                                            name="Edit" value="&nbsp;升级&nbsp;" style="width: 55px; height: 26px;">&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="停用"
                class="crmbutton small save" OnClick="Button1_Click" Style="width: 70px; height: 26px;" />
                                                                                        <asp:Button runat="server" ID="Btn_Sh" Text="审批"  class="crmbutton small cancel"  OnClick="Btn_Sh_Click"  Style="width: 70px; height: 26px;"/>&nbsp;

                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                                                            onclick="PageGo('KnetProductsSetting_Add.aspx?ID=<%= Request.QueryString["BarCode"].ToString() %>    &Type=1')"
                                                                                            name="Duplicate" value="复制" style="width: 55px; height: 26px;">&nbsp;

                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>基本信息</b>
                                                                            <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="dvtCellLabel">产品名称:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:Label ID="ProductsName" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td class="dvtCellLabel">编码(条码):
                                                                        </td>
                                                                        <td width="34%" class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsBarCode" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="dvtCellLabel">模具:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:Label ID="Lbl_Mould" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td class="dvtCellLabel">料号:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:Label ID="Lbl_KSPCode" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="dvtCellLabel">产品型号:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:Label ID="ProductsPattern" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td class="dvtCellLabel">版本号:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="Lbl_ProductsEdition" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td class="dvtCellLabel">客户物料名称:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:Label ID="Tbx_CustomerProductsName" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="dvtCellLabel">客户物料代码:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="Tbx_CustomerProductsCode" runat="server" Text=""></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="dvtCellLabel">客户规格型号:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:Label ID="Tbx_CustomerProductsEdition" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="dvtCellLabel">单包装数:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <asp:Label ID="Lbl_BzNumber" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="dvtCellLabel">产品分类:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="Lbl_ProductsType" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td width="17%" class="dvtCellLabel">单 位:
                                                                        </td>
                                                                        <td width="33%" class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsUnits" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="25" class="dvtCellLabel">更新产品:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="Lbl_GProductsEdition" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td height="25" class="dvtCellLabel">新产品确认:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="Lbl_isModiy" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" class="dvtCellLabel">重量（KG）：
                                                                        </td>
                                                                        <td align="left" class="dvtCellInfo">
                                                                            <asp:Label ID="Tbx_Weight" runat="server" Text="0.00" ValidType="Float"></asp:Label>
                                                                        </td>
                                                                        <td align="right" class="dvtCellLabel">体积（M<sup>3</sup>）：
                                                                        </td>
                                                                        <td align="left" class="dvtCellInfo">
                                                                            <asp:Label ID="Tbx_Volume" runat="server" Text="0.00" ValidType="Float"></asp:Label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td height="25" class="dvtCellLabel">厂家建议售价:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsSellingPrice" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td class="dvtCellLabel">采购参考成本:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsCostPrice" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="25" class="dvtCellLabel">是否图片:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsPic" runat="server" Text=""></asp:Label>
                                                                            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" Visible="false">
                                                                                <asp:Image ID="Image1" runat="server" Width="28" Height="24" Visible="false" />
                                                                            </asp:HyperLink>
                                                                        </td>
                                                                        <td class="dvtCellLabel">采购方式:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;
                                                                            <asp:Label ID="CgType" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                            <tr>
                                                                <td height="25" align="right" class="dvtCellLabel">使用方式:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                            <asp:Label ID="Ddl_UseType" runat="server" Text=""></asp:Label>

                                                                </td>
                                                                <td height="25" align="right" class="dvtCellLabel">损耗类别:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                            <asp:Label ID="Lbl_Loss" runat="server" Text=""></asp:Label>

                                                                </td>
                                                            </tr>
                                                                    <tr>
                                                                        <td class="dvtCellLabel">添加操作员:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsAddMan" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td class="dvtCellLabel">操作时间:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsAddTime" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="dvtCellLabel">修改人:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="KSP_Mender" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td class="dvtCellLabel">操作时间:
                                                                        </td>
                                                                        <td class="dvtCellInfo">&nbsp;<asp:Label ID="KSP_MTime" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40" class="dvtCellLabel">参数描述:
                                                                        </td>
                                                                        <td colspan="3" class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsDescription" runat="server" Text=""></asp:Label>
                                                                    </tr>

                                                                    <tr>
                                                                        <td height="41" class="dvtCellLabel">停用说明:
                                                                        </td>
                                                                        <td colspan="3" class="dvtCellInfo">&nbsp;
                                                                            <asp:TextBox ID="Tbx_DelRemarks" runat="server" CssClass="detailedViewTextBox"
                                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                                TextMode="MultiLine" Width="440px" Height="50px"></asp:TextBox>
                                                                            <asp:Label ID="Lbl_DelRemarks" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td height="41" class="dvtCellLabel">详细说明:
                                                                        </td>
                                                                        <td colspan="3" class="dvtCellInfo">&nbsp;<asp:Label ID="ProductsDetailDescription" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                       <tr runat="server" id="Time">
                                                                        <td height="50" class="dvtCellLabel">工时(秒):
                                                                        </td>
                                                                        <td colspan="3" class="dvtCellInfo">&nbsp;<asp:TextBox ID="WorkTime" runat="server"></asp:TextBox>
                                                                             <%--<asp:Button runat="server" ID="SaveWorkTime" OnClick="SaveWorkTime" Text="保 存"  class="crmbutton small cancel"   Style="width: 70px; height: 26px;"/>--%>
                                                                            <asp:Button ID="SaveWorkTime" runat="server" OnClick="SaveWorkTime_OnClick" class="crmbutton small cancel"   Style="width: 70px; height: 26px;" Text="保 存" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>资料信息</b>
                                                                        </td>
                                                                    </tr>
                                                                    <asp:TextBox ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                    <tr id="AddPic" runat="server">
                                                                        <td class="dvtCellInfo" colspan="4">
                                                                            <table id="Table1" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                                class="ListDetails" style="height: 28px">
                                                                                <!-- Header for the Product Details -->
                                                                                <tr valign="top">
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
                                                                    <asp:Panel ID="Pan_Bom" Visible="false" runat="server">
                                                                        <tr>
                                                                            <td colspan="4" class="detailedViewHeader">
                                                                                <b>BOM:</b>
                                                                                <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                                <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="0" class="ListDetails"
                                                                                    cellspacing="0">
                                                                                    <tr id="tr3">
                                                                                        <td align="center" class="ListHead">序号
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">类别
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">产品名称
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">版本号
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">料号
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">数量
                                                                                        </td>
                                                                                        <td align="center" class="ListHead"  width="40px" >位号
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">是否可替代
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">产品停用状态
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">BOM停用状态
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">产品审批
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">采购方式
                                                                                        </td>
                                                                                        <td align="center" class="ListHead">库存
                                                                                        </td>
                                                                                    </tr>
                                                                                    <asp:Label runat="server" ID="Lbl_BomDetails1"></asp:Label>

                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </asp:Panel>


                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>可替代物料:</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3">
                                                                            <asp:TextBox ID="Tbx_AlternativeProductsNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

                                                                            <table id="ProductsAlternativeTable" width="100%" border="0" align="center" cellpadding="0"
                                                                                cellspacing="0" class="ListDetails">
                                                                                <tr id="tr7">
                                                                                    <td align="center" class="ListHead">工具
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">产品名称
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">版本号
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">优先等级
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">是否可替代
                                                                                    </td>
                                                                                </tr>
                                                                                <%=s_AlternativeDetail %>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>采购周期:</b>
                                                                        </td>
                                                                    </tr>


                                                                    <tr>
                                                                        <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                            <table id="Table3" width="100%" border="0" align="center" cellpadding="0" class="ListDetails"
                                                                                cellspacing="0">
                                                                                <tr id="tr5">
                                                                                    <td align="center" class="ListHead">最小值
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">最大值
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">天数
                                                                                    </td>
                                                                                </tr>
                                                                                <%=s_CgDayDetail %>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>适用成品:</b>
                                                                            <asp:TextBox ID="TextBox1" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                            <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="ListDetails">
                                                                                <tr id="tr4">
                                                                                    <td align="center" class="ListHead">序号
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">产品名称
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">版本号
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">单位
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">相关单价
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">数量
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">是否采购
                                                                                    </td>
                                                                                </tr>
                                                                                <%=s_ProductsRC %>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                </table>


                                                            </div>
                                                            <div id="tab9" class="tab">

                                                                
                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                                    <tr>
                                                                        <td colspan="3" class="detailedViewHeader">
                                                                            <b>导入BOM:</b>
                                                                            <asp:TextBox ID="TextBox6" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                        </td>
                                                                        
                                                                                                <td class="detailedViewHeader" align="right" >
                                                                                            <asp:Button ID="Button4" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Button3_Click" Style="width: 55px; height: 33px;" />
                                                                                            
                                                                                                </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td colspan="4">
                                                                                    <asp:TextBox ID="Tbx_ImportNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                                                    <asp:TextBox ID="Tbx_ImportID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                                        <table id="Table5" width="100%" border="0" align="center" cellpadding="0"
                                                                                            cellspacing="0" class="ListDetails">
                                                                                            <tr id="tr6">
                                                                                                <td align="center" class="ListHead">序号
                                                                                                </td>
                                                                                                <td align="center" class="ListHead">物料名称
                                                                                                </td>
                                                                                                <td align="center" class="ListHead">物料型号
                                                                                                </td>
                                                                                                <td align="center" class="ListHead">封装
                                                                                                </td>
                                                                                                <td align="center" class="ListHead">数量
                                                                                                </td>
                                                                                                <td align="center" class="ListHead">备注
                                                                                                </td>
                                                                                                <td align="center" class="ListHead" colspan="2">系统对应产品
                                                                                                </td>
                                                                                            </tr>
                                                                                            <asp:Label runat="server" ID="lbl_BomDetails"></asp:Label>
                                                                                            
                                                                                            <tr id="tr8">
                                                                                                <td align="left" colspan="7">
                                                                                            <asp:Button ID="Button3" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Button3_Click" Style="width: 55px; height: 33px;" />
                                                                                            
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                    </tr>
                                                                    </table>
                                                                </div>
                                                            <div id="tab2" class="tab">
                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>销售客户</b>
                                                                            <asp:TextBox ID="Xs_ClientID" runat="Server" CssClass="Custom_Hidden"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                            <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="ListDetails">
                                                                                <tr id="tr1">
                                                                                    <td align="center" class="ListHead">客户编号
                                                                                    </td>
                                                                                    <td align="center" class="ListHead">客户名称
                                                                                    </td>
                                                                                </tr>
                                                                                <%=s_MyTable_Detail %>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div id="tab3" class="tab">

                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>生产问题</b>
                                                                            <asp:TextBox ID="TextBox2" runat="Server" CssClass="Custom_Hidden"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                                                                BorderColor="#4974C2"
                                                                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"><Columns><asp:TemplateField HeaderText="生产问题名称" SortExpression="ZPP_Title" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="Left"><ItemTemplate><a href="/Web/Zl/Problem/Zl_Produce_Problem_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ZPP_ID") %>" target="_blank"><%# DataBinder.Eval(Container.DataItem, "ZPP_Title") %></a></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="产品型号" SortExpression="ZPP_ProdutsBarCode" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="记录编号" DataField="ZPP_Code" SortExpression="ZPP_Code" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField HeaderText="日期" DataField="ZPP_STime" SortExpression="ZPP_STime"
                                                                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField HeaderText="希望完成日期" DataField="ZPP_HopeDate" SortExpression="ZPP_HopeDate"
                                                                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="生产阶段" SortExpression="ZPP_ScStage" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="类型" SortExpression="ZPP_Type" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="责任人" SortExpression="ZPP_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="责任部门" SortExpression="ZPP_DutyDepart" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField></Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>


                                                            <div id="tab4" class="tab">


                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>作业指导书</b>
                                                                            <asp:TextBox ID="TextBox3" runat="Server" CssClass="Custom_Hidden"> </asp:TextBox>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                                                                BorderColor="#4974C2"
                                                                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"><Columns><asp:TemplateField HeaderText="作业指导书名称" SortExpression="ZTI_Name" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="Left"><ItemTemplate><a href="../Instruction/ZL_Task_Instruction_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ZTI_ID") %>"><%# DataBinder.Eval(Container.DataItem, "ZTI_Name") %></a></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="记录编号" DataField="ZTI_Code" SortExpression="ZTI_Code" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="产品型号" SortExpression="ZTI_ProductsBarCode" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="日期" DataField="ZTI_STime" SortExpression="ZTI_STime"
                                                                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="责任人" SortExpression="ZTI_DutyPerson" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField></Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>


                                                            <div id="tab5" class="tab">


                                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">

                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>样品申请</b>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <cc1:MyGridView ID="MyGridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                IsShowEmptyTemplate="true" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关客户记录</B><br/><br/></font></div>"
                                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="10" Width="100%"><Columns><asp:TemplateField><HeaderTemplate><input type="CheckBox" onclick="selectAll(this)"> </HeaderTemplate><ItemTemplate><asp:CheckBox ID="Chbk" runat="server" /></ItemTemplate><HeaderStyle HorizontalAlign="Left" /><ItemStyle Height="25px" HorizontalAlign="Left" /></asp:TemplateField><asp:TemplateField HeaderText="申请主题" SortExpression="PPS_Name" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate><a href="Pb_Products_Sample_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PPS_ID") %>"></a></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="客户名称" SortExpression="PPS_CustomerValue" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="联系人" SortExpression="PPS_LinkMan" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="类型" SortExpression="PPS_LinkMan" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="需求日期" DataField="PPS_Needtime" SortExpression="PPS_Needtime"
                                                                                        DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField HeaderText="数量" DataField="PPS_Number" SortExpression="PPS_Number"
                                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="打烊情况跟踪" HeaderStyle-Font-Size="12px" ItemStyle-Width="230px"
                                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="负责人" SortExpression="PPS_DutyPeson" ItemStyle-HorizontalAlign="Left"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="创建时间" DataField="PPS_CTime" SortExpression="PPS_CTime"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="状态" SortExpression="PPS_Dept" ItemStyle-HorizontalAlign="center"
                                                                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="修改" HeaderStyle-HorizontalAlign="center"><ItemTemplate><a href="Pb_Products_Sample_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PPS_ID") %>"><asp:Image ID="Image1" runat="server" ImageUrl="../../images/Edit.gif" border="0"
                                                                                                    ToolTip="修改" /></a></ItemTemplate></asp:TemplateField></Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" class="detailedViewHeader">
                                                                            <b>产品规格书</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <cc1:MyGridView ID="MyGridView3" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px"><Columns><asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField DataField="ProductsEdition" HeaderText="版本号" SortExpression="ProductsEdition"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField DataField="XPS_SpceCode" HeaderText="规格号" SortExpression="XPS_SpceCode"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="规格说明书" SortExpression="XPS_SpceName" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate><a href="<%# GetSpce(DataBinder.Eval(Container.DataItem, "XPS_ID").ToString())%>"><%# DataBinder.Eval(Container.DataItem, "XPS_SpceName").ToString()%></a></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="修改明细" DataField="XPS_Details" SortExpression="XPS_Details" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="70px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField HeaderText="添加时间" DataField="XPS_CTime" SortExpression="XPS_CTime" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="70px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField></Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                                        </td>
                                                                    </tr>

                                                                </table>
                                                            </div>

                                                            <div id="tab7" class="tab">
                                                                <asp:Label runat="server" ID="Lbl_PriceLink"></asp:Label>
                                                                <cc1:MyGridView ID="MyGridView4" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px"
                                                                    AllowPaging="true" PageSize="13"><Columns><asp:TemplateField HeaderText="供应商" SortExpression="SuppNo" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate><%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="名称" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center"><ItemTemplate> <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%></ItemTemplate></asp:TemplateField><asp:BoundField DataField="v_KSP_Code" HeaderText="料号" SortExpression="v_KSP_Code"><ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="60px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField DataField="v_ProductsEdition" HeaderText="版本号" SortExpression="v_ProductsEdition"><ItemStyle HorizontalAlign="left" Font-Size="12px" /><HeaderStyle HorizontalAlign="center" Font-Size="12px" /></asp:BoundField><asp:BoundField DataField="ProcureUnitPrice" ItemStyle-Font-Size="12px" HeaderText="单价" ItemStyle-Width="50px" HeaderStyle-Font-Size="12px" SortExpression="ProcureUnitPrice" DataFormatString="{0:F4}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:BoundField DataField="HandPrice" ItemStyle-Font-Size="12px" HeaderText="加工费" ItemStyle-Width="40px" HeaderStyle-Font-Size="12px" SortExpression="HandPrice" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="审核" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><ItemTemplate><%#GetShState(DataBinder.Eval(Container.DataItem, "KPP_State").ToString())%></ItemTemplate></asp:TemplateField><asp:BoundField DataField="ProcureUpdateDateTime" ItemStyle-Font-Size="12px" HeaderText="操作时间" HeaderStyle-Font-Size="12px" SortExpression="ProcureUpdateDateTime" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField></Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                            </div>
                                                                           <div id="tab6" class="tab">
                                                                <cc1:MyGridView ID="Grid_Order" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                                                    BorderColor="#4974C2"
                                                                    EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>">
                                                                    
                                                                    <Columns>
                                                <asp:TemplateField HeaderText="采购单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="/CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>" target="_blank">
                                                            <%# DataBinder.Eval(Container.DataItem, "OrderNo") %></a>
                                                      <asp:TextBox ID="Tbx_OrderNo" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "OrderNo").ToString() %>'></asp:TextBox>
                                                    
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="生产单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="/CG/Order/Knet_Procure_OpenBilling_View_ForSc.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ParentOrderNo") %>" target="_blank">
                                                            <%# DataBinder.Eval(Container.DataItem, "ParentOrderNo") %></a>
                                                        <a href="/CG/Order/Knet_Procure_OpenBilling_Manage.aspx?ScNo=<%# DataBinder.Eval(Container.DataItem, "ParentOrderNo") %>&ScNo1=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>"><font color="green">相同</font></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="采购日期" DataField="OrderDateTime" SortExpression="OrderDateTime"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="要求日期" DataField="ArrivalDate" SortExpression="ArrivalDate"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="交期确认" DataField="OrderPreToDate" SortExpression="OrderPreToDate"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                
                                                <asp:TemplateField HeaderText="供应商" SortExpression="SuppNo" HeaderStyle-Font-Size="12px"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="产品类型" HeaderStyle-Font-Size="12px" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetOrderDetailProductsPatten(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="数量" HeaderStyle-Font-Size="12px" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetOrderDetailNumber(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="未入库" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetOrderDetailWrkNumber(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="已入库" HeaderStyle-Font-Size="12px" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetOrderDetailrkNumber(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px"
                                                    ItemStyle-Width="48px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# CheckView(DataBinder.Eval(Container.DataItem, "ID").ToString(), DataBinder.Eval(Container.DataItem, "OrderType").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="发送"  HeaderStyle-Font-Size="12px"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# GetPrint(DataBinder.Eval(Container.DataItem, "OrderNo").ToString(), int.Parse(DataBinder.Eval(Container.DataItem, "KPO_IsSend").ToString()))%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="确认" SortExpression="KPO_PriceState" HeaderStyle-Font-Size="12px"
                                                    ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetBasicCodeName("771",DataBinder.Eval(Container.DataItem, "KPO_PriceState").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                                                    <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                            </div>



                                                            <div id="tab8" class="tab" runat="server">

                                                                <table id="Table4" width="100%" border="0" align="center" cellpadding="0" class="ListDetails"
                                                                    cellspacing="0">
                                                                    <tr id="tr2">
                                                                        <td align="center" class="ListHead">序号
                                                                        </td>
                                                                        <td align="center" class="ListHead">类别
                                                                        </td>
                                                                        <td align="center" class="ListHead">产品名称
                                                                        </td>
                                                                        <td align="center" class="ListHead">版本号
                                                                        </td>
                                                                        <td align="center" class="ListHead">料号
                                                                        </td>
                                                                        <td align="center" class="ListHead">数量
                                                                        </td>
                                                                        <td align="center" class="ListHead">是否可替代
                                                                        </td>
                                                                        <td align="center" class="ListHead">库存
                                                                        </td>
                                                                        <td align="center" class="ListHead">状态
                                                                        </td>
                                                                        <td align="center" class="ListHead">供应商
                                                                        </td>
                                                                        <td align="center" class="ListHead">最低报价
                                                                        </td>
                                                                    </tr>
                                                                    <%=s_ProductsTable_BomDetail1 %>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:Panel ID="Pan_Detail" runat="server">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr>
                                                            <td class="detailedViewHeader">
                                                                <b></b>
                                                                <asp:Label ID="Label1" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="dvtCellLabel"></td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
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
        </div>
    </form>
</body>
</html>
