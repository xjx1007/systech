<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNetSamplingListAdd.aspx.cs" Inherits="Web_Products_KNetSamplingListAdd" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

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
    <title runat="server" id="titl">样品申请</title>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>生产 > <a class="hdrLink" runat="server" id="tit" href="KNetSamplingListAdd.aspx">样品领用添加</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="TextBox1" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="UploadUrl" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" Style="display: none"></asp:TextBox>

                    <asp:TextBox ID="Tbx_FaterBarCode" runat="server" Style="display: none"></asp:TextBox>
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
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>样品领用信息
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
                                <td valign="top" align="left">
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td>
                                                <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('UploadKNetSampling.aspx?ID=<%= Request.QueryString["ID"].ToString() %> ')" name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                 
                                    <input title="" class="crmbutton small edit" onclick="PageGo('KNetSamplingList.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                   <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="删除" OnClick="btn_Chcek_OnClick" />

                                            </td>


                                        </tr>
                                    </table>
                                </td>
                                <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px" rowspan="2">
                                    <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="genHeaderSmall">操作</td>
                                        </tr>
                                        <!-- Module based actions starts -->

                                        <tr>
                                            <td align="left" style="padding-left: 10px; border-bottom: 1px dotted #CCCCCC;">
                                                <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                <a href="Knet_Sampling_OpenBilling.aspx?SamlingID=<%= Request.QueryString["ID"].ToString() %>" class="webMnu">创建入库单</a>
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="dvtCellLabel">预到日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="EndTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="出库日期非空"
                                                    ControlToValidate="EndTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;请购级别:
                                            </td>
                                            <td class="dvtCellInfo">
                                               
                                                <asp:DropDownList ID="BuyRank" runat="server"></asp:DropDownList>(<font color="red">*</font>)
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;项目组:
                                            </td>
                                            <td class="dvtCellInfo">
                                               
                                                <asp:DropDownList ID="ProjectGroup" runat="server"></asp:DropDownList>(<font color="red">*</font>)
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;请购类别:
                                            </td>
                                            <td class="dvtCellInfo">
                                              
                                                <asp:DropDownList ID="BuyClass" runat="server"></asp:DropDownList>(<font color="red">*</font>)
                                            </td>
                                          
                                        </tr>

                                      <tr>

                                           <td class="dvtCellLabel" align="right">上传文件：
                                            </td>

                                            <td class="dvtCellInfo">
                                                <asp:Label runat="server" ID="Lbl_Details1"></asp:Label><input id="uploadFile2"
                                                    type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button2" type="button"
                                                        value="上传" runat="server" onserverclick="button_ServerClick2" class="crmbutton small save" causesvalidation="false" />
                                                <%--(<font color="red">*</font>)--%>
                                            </td>
                                        </tr>
                                    </table>

                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>购买信息</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;产品名称:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="SampleName" runat="server" Text=""></asp:TextBox>(<font color="red">*</font>)
      
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;申请数量:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="number" runat="server" Text=""></asp:TextBox>(<font color="red">*</font>)
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="dvtCellLabel">&nbsp;封装:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Packaging" runat="server" Text=""></asp:TextBox><%--(<font color="red">*</font>)--%>
                                            </td>
                                            <td class="dvtCellLabel">备注说明:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:TextBox ID="Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        runat="server" ControlToValidate="Remark" ValidationExpression="^(\s|\S){0,500}$"
                                                        ErrorMessage="备注说明太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>


                                    </table>
                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>

                                </td>
                            </tr>
                            <input type="text" id="Total_Price" style="display: none" runat="server" />
                            <tr>
                                <td colspan="4" align="center">&nbsp;
                                <br />
                                    <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClick="Btn_Save_OnClick" Style="width: 55px; height: 33px;" />
                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                        type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>

        </table>

        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="Custom_DgMain" Width="100%" PageSize="8"
            BorderColor="#4974C2"
            EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>" OnRowDataBound="GridView1_DataRowBinding" >
            <Columns>
                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="Chbk" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="请购单号" SortExpression="ID" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="物品编号" SortExpression="ReID" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "ReID").ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="采购级别" SortExpression="BuyRank" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# base.Base_GetBasicCodeName("1138",DataBinder.Eval(Container.DataItem, "BuyRank").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="采购类别" SortExpression="HouseClass" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# base.Base_GetBasicCodeName("1140",DataBinder.Eval(Container.DataItem, "HouseClass").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="样品名称" SortExpression="SampleName" HeaderStyle-Font-Size="12px" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "SampleName").ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="封装" SortExpression="ID" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px"
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Packaging").ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申请数量" SortExpression="Number" HeaderStyle-Font-Size="12px" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Number").ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="物品单价" SortExpression="Price" HeaderStyle-Font-Size="12px" ItemStyle-Width="140px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Price").ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="文件" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                     <ItemTemplate>
                            <asp:LinkButton ID="btnDownload" runat="server" CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ReID").ToString()%>'> <%# GetUploadFile(DataBinder.Eval(Container.DataItem, "ReID").ToString())%></asp:LinkButton>
                     </ItemTemplate>
                   <%-- <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "UploadFile").ToString()%>
                    </ItemTemplate>--%>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="备注" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# DataBinder.Eval(Container.DataItem, "Remark").ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="入库状态" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# GetInState(DataBinder.Eval(Container.DataItem, "ReID").ToString()) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="审核状态" HeaderStyle-Font-Size="12px" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# GetAuditState( DataBinder.Eval(Container.DataItem, "ReID").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <HeaderStyle CssClass='colHeader' />
            <RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" />
            <PagerStyle CssClass='Custom_DgPage' />
        </cc1:MyGridView>
    </form>
</body>
</html>
