<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IM_Project_Manage_Details_View.aspx.cs"
    Inherits="IM_Project_Manage_Details_View" %>

<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <title>任务明细</title>
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>

    <link rel="stylesheet" href="../../css/reset-min.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="../../css/ihwy-2012.css" type="text/css" media="screen" charset="utf-8" />
    <link rel="stylesheet" href="../../cssjquery.listnav-2.1.css" type="text/css" media="screen" charset="utf-8" />
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../js/jquery.cookie.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../js/jquery.idTabs.min.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../js/jquery.listnav-2.1.js" charset="utf-8"></script>
    <script type="text/javascript" charset="utf-8">
        $(function () {
            if (top.location.href.toLowerCase() == self.location.href.toLowerCase()) $('#docLink').show();
            $("#tabNav ul").idTabs("tab2");
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            border: 1px solid #DDDDDD;
            padding: 5px;
            background: #dddcdd url('../../themes/softed/images/inner.gif') repeat-x 50% bottom;
            color: #000000;
            height: 27px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="IM_Project_Manage_List.aspx">查看任务</a>
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
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
                        <br>
                        <hr noshade size="1">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="5" class="small">

                            <tr>
                                <td>

                                    <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                        BorderColor="#4974C2"
                                        EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>">
                                        <Columns>
                                            <asp:TemplateField HeaderText="任务名称" SortExpression="IPMD_Name" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <a href="IM_Project_Manage_Details_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "IPMD_ID") %>">
                                                        <%# DataBinder.Eval(Container.DataItem, "IPMD_Name")%></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="任务类型" SortExpression="IPMD_Type" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetBasicCodeName("224",DataBinder.Eval(Container.DataItem, "IPMD_Type").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="任务类别" SortExpression="IPMD_Type" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetBasicCodeName("222",DataBinder.Eval(Container.DataItem, "IPMD_Type").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="计划开始" DataField="IPMD_EarlyBeginTime" SortExpression="IPMD_Stime"
                                                DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="计划完成" DataField="IPMD_EarlyEndTime" SortExpression="IPMD_Stime"
                                                DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="剩余" DataField="LeftDays" SortExpression="LeftDays" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="工期" DataField="IPMD_Days" SortExpression="IPMD_Days" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="超期" DataField="OverDays" SortExpression="OverDays" HtmlEncode="false">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="状态" SortExpression="IPMD_State" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetBasicCodeName("226",DataBinder.Eval(Container.DataItem, "IPMD_State").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="负责人" SortExpression="IPMD_Executor" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetUserNames(DataBinder.Eval(Container.DataItem, "IPMD_Executor").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass='colHeader' />
                                        <RowStyle CssClass='listTableRow' />
                                        <AlternatingRowStyle BackColor="#E3EAF2" />
                                        <PagerStyle CssClass='Custom_DgPage' />
                                    </cc1:MyGridView>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div class="demoWrapper">

                                        <div id="tabNav">
                                            <ul>
                                                <li><a href="#tab1">基本信息</a></li>
                                                <li><a href="#tab2">任务进度</a></li>
                                                <li><a href="#tab3">任务日志</a></li>
                                                <li><a href="#tab4">任务文档</a></li>
                                                <li><a href="#tab5">任务合同</a></li>
                                                <li><a href="#tab6">操作日志</a></li>
                                            </ul>
                                            <div class="clr"></div>
                                        </div>

                                        <div id="tabs">
                                            <div id="tab1" class="tab">
                                                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                                                    <tr>
                                                        <td class="showPanelBg" valign="top" width="100%">

                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                                                <tr>
                                                                    <td colspan="4" class="auto-style1">
                                                                        <b>基本信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <pc:PTextBox ID="Tbx_Code" runat="server" CssClass="Custom_Hidden"></pc:PTextBox>
                                                                    <td width="16%" align="right" class="dvtCellLabel">名称：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Tbx_Name" runat="server"></asp:Label></td>

                                                                    <td width="16%" align="right" class="dvtCellLabel">负责人：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <pc:PTextBox ID="PTextBox1" runat="server" CssClass="Custom_Hidden"></pc:PTextBox>
                                                                    <td width="16%" align="right" class="dvtCellLabel">类别：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Lbl_Type" runat="server"></asp:Label></td>

                                                                    <td width="16%" align="right" class="dvtCellLabel">状态：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Lbl_State" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>

                                                                    <td width="16%" align="right" class="dvtCellLabel">类型：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Lbl_ProjectType" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="16%" align="right" class="dvtCellLabel">重要程度：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Lbl_Import" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>

                                                                    <td width="16%" align="right" class="dvtCellLabel">计划开始：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="16%" align="right" class="dvtCellLabel">计划结束：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Label2" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>

                                                                    <td width="16%" align="right" class="dvtCellLabel">开始时间：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="16%" align="right" class="dvtCellLabel">结束日期：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Label4" runat="server"></asp:Label></td>
                                                                </tr>

                                                                <tr>

                                                                    <td width="16%" align="right" class="dvtCellLabel">工期：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td width="16%" align="right" class="dvtCellLabel">假期类型：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="Label6" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="right" class="dvtCellLabel">简介：
                                                                    </td>
                                                                    <td colspan="3" align="left" class="dvtCellInfo">
                                                                        <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <script type="text/javascript">
                                                                    var importTxt = '导入模板';
                                                                    var cancelTxt = '取消';
                                                                    jQuery(function ($) {
                                                                        $("#Btn_LoadTemplate").click(function () {
                                                                            var span = $("#templateSeletor");
                                                                            if (this.value == importTxt) {
                                                                                this.value = cancelTxt;
                                                                                this.style.width = "64px";
                                                                                span.show();
                                                                            }
                                                                            else {
                                                                                this.value = importTxt;
                                                                                this.style.width = "80px";
                                                                                span.hide();
                                                                            }
                                                                        }).val(importTxt);
                                                                    })
                                                                </script>
                                                                <script type="text/javascript">
                                                                    function add() {
                                                                        var v_ID = document.all("Tbx_Code").value;
                                                                        var s = "no";
                                                                        var l = Math.ceil((window.screen.width - 530) / 3);
                                                                        var t = Math.ceil((window.screen.height - 800) / 3); //确定网页的坐标 
                                                                        window.open("Details/IM_Project_Manage_Details_Add.aspx?FID=" + v_ID + "", "_blank", "left=" + l + ",top=" + t + ",height=530,width=800,toolbar=no,status=no,resizable=yes,location=no,scrollbars=" + s);
                                                                    }
                                                                </script>
                                                                <script type="text/javascript">
                                                                    function addTemplate() {
                                                                        var v_ID = document.all("Tbx_Code").value;
                                                                        var s = "no";
                                                                        var l = Math.ceil((window.screen.width - 530) / 3);
                                                                        var t = Math.ceil((window.screen.height - 800) / 3); //确定网页的坐标 
                                                                        window.open("Template/IM_Project_Template_Add.aspx?FID=" + v_ID + "", "_blank", "left=" + l + ",top=" + t + ",height=530,width=800,toolbar=no,status=no,resizable=yes,location=no,scrollbars=" + s);
                                                                    }
                                                                </script>
                                                            </table>

                                                        </td>
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:TextBox ID="Tbx_NID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                    </tr>
                                                </table>
                                            </div>


                                            <div id="tab2" class="tab">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">

                                                    <tr>
                                                        <td align="right" colspan="4">
                                                            <asp:Button ID="Button1" runat="server" Text="新增" AccessKey="S" title="新增 [Alt+S]"
                                                                class="button" Style="width: 80px; height: 25px" OnClientClick="addDetails()" />

                                                            <script type="text/javascript">
                                                                function addDetails() {
                                                                    var v_ID = document.all("Tbx_ID").value;
                                                                    var s = "no";
                                                                    var l = Math.ceil((window.screen.width - 530) / 3);
                                                                    var t = Math.ceil((window.screen.height - 800) / 3); //确定网页的坐标 
                                                                    window.open("IM_Project_Manage_Details_Add.aspx?FID=" + v_ID + "", "_blank", "left=" + l + ",top=" + t + ",height=530,width=800,toolbar=no,status=no,resizable=yes,location=no,scrollbars=" + s);
                                                                }
                                                            </script>
                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td align="left" colspan="4">
                                                            <table cellpadding="2" class="ListDetails" align="center" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td class="ListHead">名称</td>
                                                                    <td class="ListHead">前置任务</td>
                                                                    <td class="ListHead">工期</td>
                                                                    <td class="ListHead">开始日期</td>
                                                                    <td class="ListHead">结束日期</td>
                                                                    <td class="ListHead">负责人</td>
                                                                    <td class="ListHead">日志</td>
                                                                    <td class="ListHead">编辑</td>
                                                                    <td class="ListHead">子项</td>
                                                                    <td class="ListHead">删除</td>
                                                                </tr>
                                                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div id="tab3" class="tab">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
                                                    <tr>
                                                        <td align="right" colspan="4">

                                                            <input title="新增" type="button" accesskey="" class="crmbutton small edit"
                                                                onclick="addLogs()"
                                                                name="Edit" value="&nbsp;新增&nbsp;">&nbsp;
                                                                <script type="text/javascript">
                                                                    function addLogs() {
                                                                        var v_ID = document.all("Tbx_ID").value;
                                                                        var s = "no";
                                                                        var l = Math.ceil((window.screen.width - 530) / 3);
                                                                        var t = Math.ceil((window.screen.height - 800) / 3); //确定网页的坐标 
                                                                        window.open("../Logs/IM_Project_Manage_Details_Logs_Add.aspx?FID=" + v_ID + "", "_blank", "left=" + l + ",top=" + t + ",height=530,width=800,toolbar=no,status=no,resizable=yes,location=no,scrollbars=" + s);
                                                                    }
                                                                </script>


                                                            <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                                                BorderColor="#4974C2"
                                                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="left">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Chbk" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="子任务名称" SortExpression="IPMD_Name" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <a href="IM_Project_Manage_Details_Logs_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "IPMD_ID") %>">
                                                                                <%# DataBinder.Eval(Container.DataItem, "IPMD_Name")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="进度说明" SortExpression="IPMD_Type" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetBasicCodeName("224",DataBinder.Eval(Container.DataItem, "IPMD_Type").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="进度日志" SortExpression="IPMD_Type" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetBasicCodeName("222",DataBinder.Eval(Container.DataItem, "IPMD_Type").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="操作人" DataField="IPMD_EarlyBeginTime" SortExpression="IPMD_Stime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="操作时间" DataField="IPMD_EarlyEndTime" SortExpression="IPMD_Stime"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <HeaderStyle CssClass='colHeader' />
                                                                <RowStyle CssClass='listTableRow' />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass='Custom_DgPage' />
                                                            </cc1:MyGridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div id="tab4" class="tab">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">

                                                    <tr>

                                                        <td align="left" colspan="4">

                                                            <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />

                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>

                                    </div>


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
