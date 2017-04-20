<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UploadListForProducts.ascx.cs" Inherits="UploadListForProducts" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<script language="JAVASCRIPT">
    function btnGetFJReturnValue_onclick() {
        /*新增附件*/
        var webroot = document.location.href;
        webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/'));
        rootpath = "http://" + webroot + "";

        rootpath += "/Web";
        //var tempd = window.showModalDialog(rootpath + "/Upload/UpLoad_AddForProducts.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "Upload", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=700px;dialogHeight=400px");
        var tempd = window.open(rootpath + "/Upload/UpLoad_AddForProducts.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "上传附件", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function btnGetFJReturnValue_onclick1(id) {
        /*新增附件*/
        var webroot = document.location.href;
        webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/'));
        rootpath = "http://" + webroot + "";

        rootpath += "/Web";
        //var tempd = window.showModalDialog(rootpath + "/Upload/UpLoad_AddForProducts.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "Upload", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=700px;dialogHeight=400px");
        var tempd = window.open(rootpath + "/Upload/UpLoad_AddForProducts.aspx?UpdateId=" + id + "&PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "上传附件", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function SetReturnValueInOpenner_UploadForProducts(tempd) {
        if (tempd != undefined) {
            window.location.reload();
        }
    }
</script>
<head>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
</head>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td width="50%" align="left">
            <b>产品相关附件</b>：
        </td>
        <td width="50%" align="right">
            <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
            <asp:TextBox runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
            <asp:CheckBox runat="server" ID="Chk_Details" AutoPostBack="true" />显示全部
            <input type="button" runat="server" id="Btn_Create" value="新增附件" onclick="return btnGetFJReturnValue_onclick()" class="crmbutton small create" />
        </td>
    </tr>

    <tr>
        <td colspan="2" class="dvtCellInfo">
            <cc1:MyGridView ID="GridView_Comment" runat="server" AllowPaging="True" AllowSorting="True"
                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                PageSize="100" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_DataRowBinding">
                <Columns>

                    <asp:TemplateField HeaderText="附件名称" SortExpression="PBA_Name" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <a href="/Web/Products/KNet_Products_Enclosure_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PBA_ID") %>">
                                <%# DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%></a>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="类别" SortExpression="PBA_ProductsType" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# GetBasicCode("780",DataBinder.Eval(Container.DataItem, "PBA_ProductsType").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="附件" SortExpression="PBA_URL" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <a target="_blank" href="<%#DataBinder.Eval(Container.DataItem, "PBA_URL").ToString()%>"><%# DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="描述" DataField="PBA_Remarks" SortExpression="PBA_Remarks"
                        HtmlEncode="false">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="100px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>--%>

                    <asp:BoundField DataField="PBA_FileType" HeaderText="附件类型" SortExpression="PBA_FileType">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="PBA_Edition" HeaderText="版本号" SortExpression="PBA_Edition">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
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
                    <asp:TemplateField HeaderText="下载" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDownload" runat="server" CommandName="Download" CommandArgument='<%#Eval("PBA_ID") %>'>下载</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="状态" SortExpression="PBA_Del">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="ImageButton1" runat="server"  CommandName="De" CommandArgument='<%#Eval("PBA_ID") %>' OnClientClick="return confirm('确定停用或启用当前附件？')"><%#GetBasicCode("204",DataBinder.Eval(Container.DataItem, "PBA_Del").ToString())%></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审批" SortExpression="PBA_State" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="Btn_Sp" runat="server" CommandName="Sp" CommandArgument='<%#Eval("PBA_ID") %>'><%#GetAtt(DataBinder.Eval(Container.DataItem, "PBA_State").ToString())%></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="更新" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <input type="button" id="btn" onclick="return btnGetFJReturnValue_onclick1('<%#Eval("PBA_ID") %>')" value="更新" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass='colHeader' />
                <RowStyle CssClass='listTableRow' />
                <AlternatingRowStyle BackColor="#E3EAF2" />
                <PagerStyle CssClass='Custom_DgPage' />
            </cc1:MyGridView>
            <asp:HiddenField ID="hidCommentFID" runat="server" />
            <asp:HiddenField ID="hidCommentType" runat="server" />
            <asp:TextBox runat="server" ID="Tbx_CommentFID" CssClass="Custom_Hidden"></asp:TextBox>
            <asp:TextBox runat="server" ID="Tbx_CommentType" CssClass="Custom_Hidden"></asp:TextBox>

        </td>
    </tr>
</table>
