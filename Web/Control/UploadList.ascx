<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadList.ascx.cs" Inherits="UploadList" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetFJReturnValue_onclick() {
        /*新增附件*/
        var webroot = document.location.href;
        webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/'));
        rootpath = "http://" + webroot + "";
        if (webroot.indexOf("local") >= 0)
        {
            rootpath += "/web_Mis";
        }
        rootpath += "/Web";
        var tempd = window.showModalDialog(rootpath+"/Upload/UpLoad_Add.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "Upload", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=500px;dialogHeight=280px");
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
            <b>相关附件</b>：
        </td>
        <td width="50%" align="right">
            <asp:Button runat="server" ID="Btn_Create" Text="新增附件" OnClientClick="return btnGetFJReturnValue_onclick()" class="crmbutton small create" />
        </td>
    </tr>
    <tr>
        <td colspan="2" class="dvtCellInfo">
            <cc1:MyGridView ID="GridView_Comment" runat="server" AllowPaging="True" AllowSorting="True"
                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                PageSize="10" Width="100%">
                <Columns>
                    <asp:BoundField HeaderText="名称" DataField="PBA_Name" SortExpression="PBA_Name"
                        HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="附件" SortExpression="PBA_URL" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                           <a target="_blank" href="<%#DataBinder.Eval(Container.DataItem, "PBA_URL").ToString()%>"><%# DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%></a> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="描述" DataField="PBA_Remarks" SortExpression="PBA_Remarks"
                        HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="200px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="创建人" SortExpression="PBA_Creator" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# GetUserName(DataBinder.Eval(Container.DataItem, "PBA_Creator").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="上传时间" DataField="PBA_Ctime" SortExpression="PBA_Ctime"
                        HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>
                </Columns>
         <HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' />
            <AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' />
            </cc1:MyGridView>
            <asp:HiddenField ID="hidCommentFID" runat="server" />
            <asp:HiddenField ID="hidCommentType" runat="server" />
        </td>
    </tr>
</table>
