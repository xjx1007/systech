<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentList.ascx.cs" Inherits="Web_Control_CommentList" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetPLReturnValue_onclick() {

        var webroot = document.location.href;
        webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/'));
        rootpath = "http://" + webroot + "";

        rootpath += "/Web";
        var tempd = window.showModalDialog(rootpath + "/Common/AddComments.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "Add Comments", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=500px;dialogHeight=280px");
        if (tempd != undefined) {
            window.location.reload() ;
        }        
    }
    </SCRIPT>
<head>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
</head>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td width="50%" align="left">            
            <b>相关点评</b>：
        </td>
        <td width="50%" align="right">
            <asp:Button runat="server" ID="Btn_Create" Text="新增评论" OnClientClick="return btnGetPLReturnValue_onclick()" class="crmbutton small create" />

        </td>
    </tr>
    <tr>
        <td colspan="2" class="dvtCellInfo">
            <cc1:MyGridView ID="GridView_Comment" runat="server" AllowPaging="True" AllowSorting="True"
                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                PageSize="10" Width="100%">
                <Columns>
                    <asp:BoundField HeaderText="点评内容" DataField="PBC_Description" SortExpression="PBC_Description"
                        HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="点评时间" DataField="PBC_CTime" SortExpression="PBC_CTime"
                        HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="点评人" SortExpression="PBC_FromPerson" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# GetUserName(DataBinder.Eval(Container.DataItem, "PBC_FromPerson").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
            </cc1:MyGridView>
            <asp:HiddenField ID="hidCommentFID" runat="server" />
            <asp:HiddenField ID="hidCommentType" runat="server" />
        </td>
    </tr>
</table>
