<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false"  EnableEventValidation="false"  CodeFile="Knet_Document_View.aspx.cs"
 Inherits="Knet_Web_System_Knet_Document_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>

<style type="text/css">
.Div11
{
  background-image:url(../images/KbottonB.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/KbottonA.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>


<SCRIPT LANGUAGE=JAVASCRIPT >
function btnGetReturnValue_onclick()  
    {   
       /*选择产品*/
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("SelectDocument.aspx","","dialogtop=150px;dialogleft=160px; dialogwidth=750px;dialogHeight=500px");
    
       if(temp!=undefined)   
       {   
          	 var ss;
	         ss=temp.split("#");
             document.all('tbx_FaterId').value = ss[0];
             document.all('Tbx_FaterName').value =ss[1];
        }   
       else
        {
             document.all('tbx_FaterId').value = ""; 
             document.all('Tbx_FaterName').value = ""; 
        }
    }
    function Chang()
    {
        var s_Name= document.all('Tbx_Name').value;
        var response=Knet_Web_System_Knet_Document_Add.GetCode(s_Name);
        document.all('Tbx_Visio').value=response.value;
        
    }
</SCRIPT>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<div class="TitleBar">文档中心</div>
<div id="Div1" style="padding:1px"></div>

<%--内容块--%>
<table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
<tr>
        <td width="15%" height="25" align="right" class="tdcss">文档编号:</td>
        <td align="left" class="tableBotcss" style="width: 498px" >
        <asp:Label runat="server" ID="Lbl_Code"></asp:Label>
        </td>
             
        <td width="15%" height="25" align="right" class="tdcss">文档名称:</td>
              <td align="left" class="tableBotcss1" style="width: 498px" >
        <asp:Label runat="server" ID="Lbl_Name"></asp:Label>
              </td>
        </tr>
     <tr  runat="server" >
        <td height="25" align="right" class="tdcss">文档类型:</td>
        <td align="left" class="tableBotcss">
        <asp:Label runat="server" ID="Lbl_Type"></asp:Label></td>
        <td height="25" align="right" class="tdcss">负责人:</td>
        <td align="left" class="tableBotcss1">
        <asp:Label runat="server" ID="Lbl_DutyPerson"></asp:Label></td>
    </tr>
    
     <tr id="Tr1"  runat="server" >
        <td height="25" align="right" class="tdcss">版本号:</td>
        <td align="left" class="tableBotcss">
        <asp:Label runat="server" ID="Lbl_Visio"></asp:Label></td>

        <td height="25" align="right" class="tdcss">上级文档:</td>
        <td align="left" class="tableBotcss">
           
        <asp:Label runat="server" ID="Lbl_FaterName"></asp:Label>        </td>

    </tr>
     <tr id="AddPic" runat="server" >
        <td height="25" align="right" class="tdcss">文档路径:</td>
        <td align="left" class="tableBotcss1" colspan="3">
        <asp:LinkButton ID="Lbl_Spce" runat="server" OnClick="Lbl_Spce_Click" ></asp:LinkButton></td>
    </tr>
      <tr>
        <td align="right" class="tdcss" style="height: 24px">文档内容:</td>
        <td align="left" class="tableBotcss1" style="height: 24px" colspan="3">
        <asp:Label runat="server" ID="Lbl_Details"></asp:Label> 
        </td>
         </tr>
         <tr>
         <td colspan="4" class="tdcss" style="height: 24px">下级文档</td>
         </tr>
         
         <%=s_NextDocumentHtml %>
    </table>
<%--内容块结束--%>


    </form>
</body>
</html>
