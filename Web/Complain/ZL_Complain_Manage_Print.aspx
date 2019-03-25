<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZL_Complain_Manage_Print.aspx.cs"
    Inherits="Web_ZL_Complain_Manage_Print" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register Src="../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <title></title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    
    <style type="text/css">
        .styleTopLeft
        {
            width: 92pt;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            padding: 3px;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .styleTop
        {
            width: 141pt;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            padding: 3px;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .styleTopRight
        {
            width: 141pt;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            padding: 3px;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 2.0pt double windowtext;
            border-top:  2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .styleTopMiddel
        {
            width: 141pt;
            padding: 3px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left:2.0pt double windowtext;
            border-right: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .styleLeft
        {
            width: 141pt;
            padding: 3px;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-top:  0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .styleLeft1
        {
            width: 141pt;
            padding: 3px;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-top:  0pt solid windowtext;
            border-bottom: 2.0pt double windowtext;
            
        }
        .style1
        {
            width: 141pt;
            padding: 3px;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-top:  0pt solid windowtext;;
            border-bottom: 2.0pt double windowtext;
            
        }
        .style
        {
            width: 141pt;
            padding: 3px;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-top:  0pt solid windowtext;;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .styleRight
        {
            width: 141pt;
            padding: 3px;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-right: 2.0pt double windowtext;
            border-left:  1.0pt solid windowtext;
            border-top:  0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .styleRight1
        {
            width: 141pt;
            height: 30px;
            padding: 3px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-right: 2.0pt double windowtext;
            border-left:  1.0pt solid windowtext;
            border-top:  0pt solid windowtext;
            border-bottom: 2.0pt double windowtext;
            
        }
        .style3
        {
            width: 1083pt;
            height: 30px;
            color: windowtext;
            padding: 3px;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .style4
        {
            width: 1083pt;
            height: 30px;
            color: windowtext;
            padding: 3px;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-top: 0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .style5
        {
            width: 277pt;
            height: 30px;
            padding: 3px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .style6
        {
            width: 307pt;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            padding: 3px;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .style7
        {
            width: 346pt;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            padding: 3px;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .style8
        {
            width: 126pt;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            padding: 3px;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
        .style9
        {
            width: 126pt;
            height: 30px;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            padding: 3px;
            border-left: 1.0pt solid windowtext;
            border-top: 0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

    
    <table border="0" cellpadding="0" cellspacing="0" width="96%">
    <tr>
    <td colspan="8" align="center" height="30"><font size="6">8D报告</font></td>
    </tr>
        <tr >
            <td class="style3" height="48">
                产品名称
            </td>
            <td class="style8" height="48">
            <asp:Label ID="Tbx_ProductsName" runat="server"  ></asp:Label>
            </td>
            <td class="style5">
                产品型号
            </td>
            <td class="styleTop">
            <asp:Label ID="Lbl_ProductsPattern" runat="server"  ></asp:Label>
            </td>
            <td class="style6">
                投诉日期
            </td>
            <td class="styleTop">
            <asp:Label ID="Tbx_Stime" runat="server"  ></asp:Label>
            </td>
            <td class="style7">
                客户名称
            </td>
            <td class="styleTopRight">
            <asp:Label ID="Tbx_CustomerName" runat="server"  ></asp:Label>
            </td>
            </tr>
            
        <tr >
            <td class="styleTopMiddel" colspan="8">
            <b>D1.使用团队方式解决</b>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            领队
            </td>
            <td class="styleRight" colspan="7" >
               <asp:Label runat="server" ID="Tbx_D1LederName"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            组员
            </td>
            <td class="styleRight" colspan="7" >
               <asp:Label runat="server" ID="Tbx_D1MemberName" ></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleTopMiddel" colspan="8">
            <b>D2.问题描述</b>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            发现人
            </td>
            <td class="style" colspan="2" >
               <asp:Label  runat="server" ID="Tbx_D2Finder"></asp:Label>
            </td>
            <td class="style"  rowspan="3">
            具体问题
            </td>
            <td class="styleRight" rowspan="3" colspan="4"  >
               <asp:Label  runat="server" ID="Tbx_D2FRemarks"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            发现时间
            </td>
            <td class="style" colspan="2" >
               <asp:Label  runat="server"  ID="Tbx_D2Time" ></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            涉及数量
            </td>
            <td class="style" colspan="2"  >
               <asp:Label  runat="server"  ID="Tbx_D2Number" ></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleTopMiddel" colspan="8">
            <b>D3.临时处置对策</b>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            问题产品状态
            </td>
            <td class="style9"  >
               <asp:Label  runat="server"  ID="Tbx_D3QState" ></asp:Label>
            </td>
            <td class="style"  colspan="5">
            处置方式
            </td>
            <td class="styleRight" >
            完成日期
            </td>
        </tr>
        <tr >
            <td class="style4" >
            客户库存
            </td>
            <td class="style9"  >
               <asp:Label  runat="server"  ID="Tbx_D3CustomerNumber" ></asp:Label>
            </td>
            <td class="style" rowspan="4" colspan="5" >
               <asp:Label  runat="server"  ID="Tbx_D3Cause" ></asp:Label>
            </td>
            <td class="styleRight" rowspan="4"  >
               <asp:Label  runat="server"  ID="Tbx_D3Time" ></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            运输数量
            </td>
            <td class="style9"  >
               <asp:Label  runat="server"  ID="Tbx_D3TravelNumber" ></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            本公司成品
            </td>
            <td class="style9"  >
               <asp:Label  runat="server"  ID="Tbx_D3CompyNumber" ></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" >
            相关材料
            </td>
            <td class="style9"  >
               <asp:Label  runat="server"  ID="Tbx_D3MaterialDetails" ></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" colspan="5">
            <b>D4.不良原因分析</b>
            </td>
            <td class="style">
                日期
            </td>
            <td class="styleRight" colspan="2">
                <asp:Label ID="Tbx_D4Time" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleTopMiddel" colspan="8" height="50px">
              <asp:Label ID="Tbx_D4Cause"  runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr >
            <td class="style4" colspan="5">
            <b>D5.改善对策</b>
            </td>
            <td class="style">
                日期
            </td>
            <td class="styleRight" colspan="2">
                <asp:Label ID="Tbx_D5Time" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleTopMiddel" colspan="8" height="50px">
              <asp:Label ID="Tbx_D5Cause"  runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr >
            <td class="style4" colspan="5">
            <b>D6.改善对策验证</b>
            </td>
            <td class="style">
                日期
            </td>
            <td class="styleRight" colspan="2">
                <asp:Label ID="Tbx_D6Time" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleTopMiddel" colspan="8" height="50px">
              <asp:Label ID="Tbx_D6Cause"  runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" colspan="5">
            <b>D7.预防再发生</b>
            </td>
            <td class="style">
                日期
            </td>
            <td class="styleRight" colspan="2">
                <asp:Label ID="Tbx_D7Time" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleTopMiddel" colspan="8" height="50px">
              <asp:Label ID="Tbx_D7Cause"  runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="style4" colspan="5">
            <b>D8.结案</b>
            </td>
            <td class="style">
                日期
            </td>
            <td class="styleRight" colspan="2">
                <asp:Label ID="Tbx_D8Time" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleTopMiddel" colspan="8" height="50px">
              <asp:Label ID="Tbx_D8Cause"  runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="styleLeft" >
            组长审核
            </td>
            <td class="style" colspan="3">
            </td>
            <td class="style">
            日期
            </td>
            <td class="styleRight" colspan="3">
            </td>
        </tr>
        <tr >
            <td class="styleLeft1" >
            客户审核
            </td>
            <td class="style1" colspan="3">
            </td>
            <td class="style1">
            日期
            </td>
            <td class="styleRight1" colspan="3">
            </td>
        </tr>

    </table>
    </form>
</body>
</html>
