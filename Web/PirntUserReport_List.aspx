<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PirntUserReport_List.aspx.cs" Inherits="Web_PirntUserReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../themes/softed/style.css" type="text/css">
    <title>用户报告列表</title>

    
    <script language="javascript" type="text/javascript">   
        
        function prrintALL() {
            var s_ID = document.all("Tbx_ID").value.split(",");
            //全部打印
            for (var j = 0; j < s_ID.length; j++) {
                if (s_ID[j] != "") {
                    GPrint(s_ID[j]);
                }
            }
        }
               
	function GPrint(ID) {
	    //window.open('Sales_ShipWareOut_Print_Cw.aspx?ID=' + ID, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500')
	    var temp = window.showModalDialog("PirntUserReport.aspx?ID=" + ID + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
	    // window.location.reload(); 
	}
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <input type="button" value="打印全部" onclick="javascript: prrintALL()" id="Button3" />
    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>

            <asp:Label ID="Lbl_Details" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
