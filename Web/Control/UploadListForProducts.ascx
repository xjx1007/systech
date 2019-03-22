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
    function btnGetFilePool_onclick() {
        /*新增附件*/
        var webroot = document.location.href;
        webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/'));
        rootpath = "http://" + webroot + "";

        rootpath += "/Web";
        //var tempd = window.showModalDialog(rootpath + "/Upload/UpLoad_AddForProducts.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "Upload", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=700px;dialogHeight=400px");
        var tempd = window.open(rootpath + "/Upload/UpLoad_FilePool.aspx?PBC_FID="+document.getElementById("<%=hidCommentFID.ClientID %>").value, "选择附件", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
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
        var tempd = window.open(rootpath + "/Upload/UpLoad_AddForProducts.aspx?Type=Update&UpdateId=" + id + "&PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "上传附件", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function btnGetFJReturnValue_onclick2(id) {
        /*启用附件*/
        var webroot = document.location.href;
        webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/'));
        rootpath = "http://" + webroot + "";

        rootpath += "/Web";
        //var tempd = window.showModalDialog(rootpath + "/Upload/UpLoad_AddForProducts.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "Upload", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=700px;dialogHeight=400px");
        var tempd = window.open(rootpath + "/Upload/State_ProductFile.aspx?Type=State&UpdateId=" + id + "&PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "上传附件", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function btnGetFJReturnValue_onclick3(id) {
        /*审核附件*/
        var webroot = document.location.href;
        webroot = webroot.substring(webroot.indexOf('//') + 2, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/') + 1) + webroot.substring(webroot.indexOf('/') + 1, webroot.length);
        webroot = webroot.substring(0, webroot.indexOf('/'));
        rootpath = "http://" + webroot + "";

        rootpath += "/Web";
        //var tempd = window.showModalDialog(rootpath + "/Upload/UpLoad_AddForProducts.aspx?PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "Upload", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=700px;dialogHeight=400px");
        var tempd = window.open(rootpath + "/Upload/State_ProductFile.aspx?Type=SpFile&UpdateId=" + id + "&PBC_FID=" + document.getElementById("<%=hidCommentFID.ClientID %>").value + "&PBC_Type=" + document.getElementById("<%=hidCommentType.ClientID %>").value + "", "上传附件", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function SetReturnValueInOpenner_UploadForProducts(tempd) {
        if (tempd != undefined) {
            debugger;
            //window.location.reload();
           
            document.getElementById("<%= Button1.ClientID %>").click();
        }
    }
</script>
<style type="text/css">
    #Button1 {
           
    }
</style>
<head>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
</head>
<table width="100%" border="0" cellpadding="0" cellspacing="0" id="sd">
    <tr>
        <td width="50%" align="left">
            <b>产品相关附件</b>：<font color="red">新建物料必须上传物料说明书和环保资料</font>
        </td>
        <td width="50%" align="right">
            <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
            <asp:TextBox runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
            <asp:CheckBox runat="server" ID="Chk_Details" AutoPostBack="true" />显示全部
             <input type="button" value="选择附件" onclick="return btnGetFilePool_onclick()" class="crmbutton small create" />
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
                    <asp:TemplateField HeaderText="到期时间" SortExpression="PBA_EndTime" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# GetEndTime(DataBinder.Eval(Container.DataItem, "PBA_ID").ToString(),DataBinder.Eval(Container.DataItem, "PBA_ProductsType").ToString(),DataBinder.Eval(Container.DataItem, "PBA_EndTime").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" SortExpression="PBA_EndTime" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "PBA_Remarks").ToString()%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="PDF在线查看" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                               <a href='<%# DataBinder.Eval(Container.DataItem, "PBA_Url").ToString()%>'>
                                  <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%>'></asp:Label>
                               </a>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="下载" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDownload" runat="server" CommandName="Download" CommandArgument='<%#Eval("PBA_ID") %>'>下载</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态" SortExpression="PBA_Del">
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="ImageButton1" runat="server" CommandName="De" CommandArgument='<%#Eval("PBA_ID") %>' OnClientClick='return  btnGetFJReturnValue_onclick2("<%#Eval("PBA_ID") %>")'><%#GetBasicCode("204",DataBinder.Eval(Container.DataItem, "PBA_Del").ToString())%></asp:LinkButton>--%>
                            <%--<asp:Label ID="Label2" runat="server" OnClientClick='return  btnGetFJReturnValue_onclick2("<%#Eval("PBA_ID") %>")' Text='<%#GetBasicCode("204",DataBinder.Eval(Container.DataItem, "PBA_Del").ToString())%>'></asp:Label>--%>
                            <a href="#" onclick="return  btnGetFJReturnValue_onclick2('<%#Eval("PBA_ID") %>')"><%#GetBasicCode("204",DataBinder.Eval(Container.DataItem, "PBA_Del").ToString())%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审批" SortExpression="PBA_State" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="Btn_Sp" runat="server" CommandName="Sp" CommandArgument='<%#Eval("PBA_ID") %>' OnClientClick='return  btnGetFJReturnValue_onclick3("<%#Eval("PBA_ID") %>")'><%#GetAtt(DataBinder.Eval(Container.DataItem, "PBA_State").ToString())%></asp:LinkButton>--%>
                            <%--<asp:Label ID="Label1" runat="server" OnClientClick='return  btnGetFJReturnValue_onclick3("<%#Eval("PBA_ID") %>")' Text='<%#GetAtt(DataBinder.Eval(Container.DataItem, "PBA_State").ToString())%>'></asp:Label>--%>
                            <a href="#" onclick="return btnGetFJReturnValue_onclick3('<%#Eval("PBA_ID") %>')"><%#GetAtt(DataBinder.Eval(Container.DataItem, "PBA_State").ToString())%></a>
                            <%--<input type="button" id="btn1" onclick="return btnGetFJReturnValue_onclick3('<%#Eval("PBA_ID") %>  ')" value='<%#GetAtt(DataBinder.Eval(Container.DataItem, "PBA_State").ToString())%>' />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="更新" HeaderStyle-Font-Size="12px"
                        ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <input type="button" id="btn" onclick="return btnGetFJReturnValue_onclick1('<%#Eval("PBA_ID") %>    ')" value="更新" />
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
 <input type="button" id="Button1" runat="server" style="display: none" OnServerClick="OnServerClick" />
</table>
