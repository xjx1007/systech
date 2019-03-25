<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pb_Basic_Notice_View.aspx.cs"
    Inherits="Pb_Basic_Notice_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ register assembly="Container" namespace="HT.Control.WebControl" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title>查看公告</title>
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="JAVASCRIPT">

        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            var v_Receive = document.all('Tbx_ReceiveID').value;
            var v_ReceiveName = document.all('Tbx_ReceiveName').value;
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Common/SelectDeptPerson.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (temp == undefined) {
                temp = window.returnValue;
            }
            if (temp != undefined) {
                var ss, s_Receive;
                ss = temp.split("|");
                s_Receive = ss[0].split(",");
                s_ReceiveName = ss[1].split(",");
                for (var i = 0; i < s_Receive.length; i++) {
                    if (v_Receive.indexOf(s_Receive[i]) < 0) {
                        v_Receive = v_Receive + "," + s_Receive[i];
                        v_ReceiveName = v_ReceiveName + "," + s_ReceiveName[i];
                    }
                }
                document.all('Tbx_ReceiveID').value = v_Receive.substring(1, v_Receive.length);
                document.all('Tbx_ReceiveName').value = v_ReceiveName.substring(1, v_ReceiveName.length);

            }
            else {
                document.all('Tbx_ReceiveID').value = "";
                document.all('Tbx_ReceiveName').value = "";
            }
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                工作台 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">查看公告</a>
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
                <div class="small" style="padding: 10px">
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
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
                                            公告信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtUnSelectedCell" align="center" nowrap>
                                            <a href="#">相关信息</a>
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
                                        <td valign="top" align="left">
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                            onclick="PageGo('Pb_Basic_Notice_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                            name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                            value="&nbsp;共享&nbsp;">&nbsp;
                                                        <input title="" class="crmbutton small edit" onclick="PageGo('Pb_Basic_Notice_List.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                            onclick="PageGo('Pb_Basic_Notice_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
                                                            name="Duplicate" value="复制">&nbsp;
                                                        <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                            onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                            rowspan="2">
                                            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="genHeaderSmall">
                                                        操作
                                                    </td>
                                                </tr>
                                                <!-- Module based actions starts -->
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
                                                        <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    公告标题：
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label ID="Tbx_Title" runat="server" CssClass="detailedViewLabel" OnFocus="this.className='detailedViewLabelOn'"
                                                                        OnBlur="this.className='detailedViewLabel'"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    公告类型：
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label runat="server" ID="Ddl_Type"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" align="right" class="dvtCellLabel">
                                                                    日期:
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label ID="StartDate" runat="server"></asp:Label>&nbsp;&nbsp;到<asp:Label ID="EndDate"
                                                                        runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    接收人:
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label runat="server" ID="Tbx_ReceiveID" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                                    <asp:Label ID="Tbx_ReceiveName" TextMode="MultiLine" runat="server" CssClass="detailedViewLabel"
                                                                        OnFocus="this.className='detailedViewLabelOn'" OnBlur="this.className='detailedViewLabel'"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                                    内容：
                                                                </td>
                                                                <td class="dvtCellInfo" align="left" colspan="3">
                                                                    <asp:Label ID="Tbx_Remark" runat="server"></asp:Label>&nbsp;
                                                                    <asp:Label ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                                    <asp:Label ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                                                                            <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>报表信息</b>
                                                    </td>
                                                </tr>
                                                            <tr>
                                                                <td class="dvtCellInfo" align="left" colspan="4">
                                                                    
    <cc1:MyGridView ID="MyGridView1" runat="server" AllowSorting="True" IsShowEmptyTemplate="true"   EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关报表记录</B><br/><br/></font></div>" 
            AutoGenerateColumns="False" CssClass="Custom_DgMain" PageSize="100" Width="100%">
<Columns>
        
         <asp:TemplateField HeaderText="主题"  SortExpression="KRS_ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <a href="KNet_Reports_Submit_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "KRS_ID") %>"><%# DataBinder.Eval(Container.DataItem, "KRS_Topic").ToString()%></a>
          </ItemTemplate>
        </asp:TemplateField>
        
        
         <asp:BoundField  HeaderText="日期"  DataField="KRS_Stime"  SortExpression="KRS_Stime" DataFormatString="{0:yyyy-MM-dd}"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="上传人"  SortExpression="KRS_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KRS_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="部门"  SortExpression="KRS_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserDept(DataBinder.Eval(Container.DataItem, "KRS_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="职位"  SortExpression="KRS_DutyPerson" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserPosition(DataBinder.Eval(Container.DataItem, "KRS_DutyPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="文档1"  SortExpression="KRS_ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetSpce(DataBinder.Eval(Container.DataItem, "KRS_ID").ToString(),0)%>
          </ItemTemplate>
        </asp:TemplateField>
        
      <asp:TemplateField HeaderText="文档2"  SortExpression="KRS_ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetSpce(DataBinder.Eval(Container.DataItem, "KRS_ID").ToString(),1)%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="文档3"  SortExpression="KRS_ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetSpce(DataBinder.Eval(Container.DataItem, "KRS_ID").ToString(),2)%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="状态"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# GetState(DataBinder.Eval(Container.DataItem, "KRS_ID").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="创建人"  SortExpression="KRS_Creator" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KRS_Creator").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="创建时间"  DataField="KRS_CTime"  SortExpression="KRS_CTime" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
</Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
</cc1:MyGridView>
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
                        </tr>
                    </table>
                </div>
            </td>
            <td valign="top">
                <img src="/themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </td>
    <td align="right" valign="top">
        <img src="/themes/softed/images/showPanelTopRight.gif" />
    </td>
    </tr> </table>
    </form>
</body>
</html>
