<%@ Page Language="C#" AutoEventWireup="true" CodeFile="副本 Sales_ShipWareOut_Print.aspx.cs"
    Inherits="Web_Sales_Sales_ShipWareOut_Manage" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="JavaScript" src="../Js/Report.js" type="text/javascript"></script>
<script language="javascript" src="../Js/LodopFuncs.js"></script>
    <title>发货单</title>
<script language=javascript>
    function preview() {
        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML = prnhtml;
        window.print();
        window.document.body.innerHTML = bdhtml;
    }
    
    var LODOP; //声明为全局变量 
    function prn1_preview() {	
        CreateOneFormPage();	
        LODOP.PREVIEW();
    }

    function CreateOneFormPage() {

        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
        LODOP.PRINT_INIT("发货单");
        LODOP.SET_PRINT_STYLE("FontSize", 18);
        LODOP.SET_PRINT_STYLE("Bold", 1);
        LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", prnhtml);
    };

    function OutToFileMoreSheet() {

        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
        LODOP.PRINT_INIT("");
        LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", prnhtml);
        LODOP.SET_SAVE_MODE("PAGE_TYPE", 1);
        LODOP.SET_SAVE_MODE("centerHeader", "页眉");
        LODOP.SET_SAVE_MODE("centerFooter", "第&P页");
        LODOP.SET_SAVE_MODE("Caption", "发货单");
        LODOP.SET_SAVE_MODE("RETURN_FILE_NAME", 1);
        LODOP.SAVE_TO_FILE("发货单.xls");
    };	    

</script>
    <style type="text/css">

.font7
	{color:windowtext;
	font-size:18.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:宋体;
	}
.font0
	{color:windowtext;
	font-size:12.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:宋体;
	}
.font8
	{color:windowtext;
	font-size:14.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:宋体;
            text-align: right;
        }
ruby
	{ruby-align:left;}
ruby
	{ruby-align:left;}
rt
	{color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:宋体;
	display:none;
        }
        .style2
        {
            height: 24pt;
            color: windowtext;
            font-size: 10.5pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style3
        {
            width: 737pt;
            height: 42pt;
            color: windowtext;
            font-size: 18.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            padding: 0px;
        }
        .style4
        {
            width: 92pt;
            height: 28.5pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style5
        {
            width: 284pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style6
        {
            width: 104pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style7
        {
            width: 113pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style8
        {
            width: 77pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style10
        {
            width: 125pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 2.0pt double windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style12
        {
            width: 92pt;
            height: 57pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style13
        {
            width: 92pt;
            height: 36pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 2.0pt double windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style14
        {
            width: 683pt;
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
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style15
        {
            height: 27.75pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            width: 92pt;
        }
        .style16
        {
            width: 284pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style17
        {
            width: 104pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style18
        {
            width: 113pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style19
        {
            width: 77pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style20
        {
            width: 123pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style21
        {
            width: 125pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style22
        {
            width: 54pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style23
        {
            width: 92pt;
            height: 21pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style24
        {
            width: 304pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style25
        {
            width: 77pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style26
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style27
        {
            width: 54pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: top;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style28
        {
            width: 92pt;
            height: 21.75pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style29
        {
            width: 304pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style30
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style31
        {
            height: 21pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            width: 92pt;
        }
        .style32
        {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            width: 284pt;
        }
        .style33
        {
            width: 92pt;
            height: 18.75pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style34
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style35
        {
            width: 125pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style36
        {
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style37
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style38
        {
            width: 125pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style39
        {
            width: 92pt;
            height: 18pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style40
        {
            width: 284pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style42
        {
            width: 113pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style43
        {
            width: 123pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style44
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style45
        {
            width: 284pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style47
        {
            width: 113pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style48
        {
            width: 123pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style49
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style51
        {
            width: 92pt;
            height: 12pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style52
        {
            width: 284pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style53
        {
            width: 87pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style55
        {
            width: 113pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style56
        {
            width: 77pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style57
        {
            width: 122pt;
            color: windowtext;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style59
        {
            height: 14.25pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style60
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: 1.0pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 2.0pt double windowtext;
            border-bottom: 2.0pt double windowtext;
            padding: 0px;
        }
        .style61
        {
            width: 122pt;
            color: windowtext;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: normal;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
    </style>
<object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width=0 height=0> 
	<embed id="LODOP_EM" type="application/x-print-lodop" width=0 height=0 pluginspage="install_lodop.exe"></embed>
</object> 
</head>
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
<script type="text/javascript" src="../KDialog/lhgdialog.js"></script>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="93%" height="30" align="center" style="border-bottom:#333333 1px dotted;"><img src="../../images/print.gif" width="36" height="34" border="0" style="cursor:hand;" onClick="preview();window.close()" />
    <img src="../images/excel.gif" height="34" border="0" 
            style="cursor:hand; width: 36px;" 
            onClick="javascript:OutToFileMoreSheet()" /></td>
    <td width="7%" height="30" align="left" style="border-bottom:#333333 1px dotted;">
    <img src="../../images/Close.gif" width="32" height="32" border="0" style="cursor:hand;" onclick="window.close()" >
    </td>
    <td width="7%" height="30" align="left" style="border-bottom:#333333 1px dotted;">
        <asp:Button CssClass="calAddButton" runat="server" ID="Btn_Next"  Text="下一张"
            onclick="Btn_Next_Click" /></td>
  </tr>
</table>
<!--startprint-->
    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
        <colgroup>
            <col span="1" />
            <col span="1" style="WIDTH: 54pt" />
            <col style="WIDTH: 87pt; mso-width-source: userset; mso-width-alt: 3712" 
                " />
            <col style="WIDTH: 104pt; mso-width-source: userset; mso-width-alt: 4416" 
                 />
            <col style="WIDTH: 113pt; mso-width-source: userset; mso-width-alt: 4800" 
                 />
            <col style="mso-width-source: userset; mso-width-alt: 3296" 
                 />
            <col style="WIDTH: 123pt; mso-width-source: userset; mso-width-alt: 5248" 
                 />
            <col style="WIDTH: 125pt; mso-width-source: userset; mso-width-alt: 5344" 
                width="167" />
            <col span="2" style="WIDTH: 54pt"  />
        </colgroup>
        <tr height="20">
            <td colspan="7" height="20">
                 <table cellpadding="0" cellspacing="0"  width="100%" >
                            <tr>
                                <td height="0" width="0">
                                </td>
                                <td >
                                </td>
                                <td >
                                </td>
                                <td >
                                </td>
                            </tr>
                            <tr>
                                <td height="9">
                                </td>
                                <td >
                                </td>
                                <td align="right" rowspan="2" valign="top">
                                    <img alt="logo中1-2" height="29" src="../../images/士兰微芯片订单_22424_image003.png" v:shapes="Picture_x0020_5"
                                       /></td>
                            </tr>
                            <tr>
                                <td height="23">
                                </td>
                                <td align="left" valign="top">
                                    <img alt="logo英1-2" height="20" src="../../images/士兰微芯片订单_22424_image004.png" v:shapes="Picture_x0020_3"
                                        /></td>
                            </tr>
                        </table></td>
        </tr>
        <tr height="32">
            <td class="style2" colspan="7" height="32" style="mso-ignore: colspan">
                地址：杭州市黄姑山路4号 - 310012<span style="mso-spacerun: yes"> </span>电话：0571-88210386<span 
                    style="mso-spacerun: yes"> </span>传真：0571-88216187<span 
                    style="mso-spacerun: yes"> </span>发货人：<asp:Label ID="Lbl_FPerson" 
                    runat="server"></asp:Label>
            &nbsp;电话：88210386<span 
                    style="mso-spacerun: yes"> </span>
            </td>
        </tr>
        <tr height="14">
            <td colspan="7" height="14">
            </td>
        </tr>
        <tr height="56">
            <td class="style3" colspan="8" height="56" width="982">
                发 货 单 <font class="font7">
                <br />
                </font><ruby><font 
                    class="font13"><rt class="font13"></rt></font></ruby></td>
            <td >
            </td>
        </tr>
        <tr >
            <td colspan="7" align="right">
            <font class="font0">编号：<asp:Label ID="Lbl_Code" runat="server"></asp:Label>
                </font></td>
        </tr>
        
        <tr height="38">
            <td class="style4" height="38">
                项目</td>
            <td class="style5"  >
                客户名称</td>
            <td class="style6" >
                客户料号</td>
            <td class="style7">
                客户订单号</td>
            <td class="style8" >
                客户型号</td>
            <td class="style60" >
                产品名称</td>
            <td class="style10" >
                士腾型号</td>
        </tr>
        <tr height="76">
            <td class="style12" height="76">
                1</td>
            <td class="style5"  >
                　<asp:Label ID="Lbl_CustomName" runat="server"></asp:Label>
            </td>
            <td class="style6">
                <asp:Label ID="Lbl_MaterNumber" runat="server"></asp:Label>
                　</td>
            <td class="style7" >
                <asp:Label ID="Lbl_OrderNo" runat="server"></asp:Label>
                　</td>
            <td class="style8">
                <asp:Label ID="Lbl_ShipType" runat="server"></asp:Label>
                　</td>
            <td class="style60">
                <asp:Label ID="Lbl_ProductsName" runat="server"></asp:Label>
                　</td>
            <td class="style10" >
                <asp:Label ID="Lbl_ProductsEdition" runat="server"></asp:Label>
                　</td>
        </tr>
        <tr height="48">
            <td class="style13" height="48" >
                项目</td>
            <td class="style5"  >
                计价只数</td>
            <td class="style6" >
                备品只数</td>
            <td class="style7" >
                发货总只数</td>
            <td class="style8" >
                发货日期</td>
            <td class="style60" >
                计划单号</td>
            <td class="style10" >
                　</td>
        </tr>
        <tr height="38">
            <td class="style4" height="38" >
                1</td>
            <td class="style5" >
                　<asp:Label ID="Lbl_Number" 
                    runat="server"></asp:Label>
            </td>
            <td class="style6">
                <asp:Label ID="Lbl_BNumber" runat="server"></asp:Label>
                　</td>
            <td class="style7" >
                　<asp:Label ID="Lbl_TotalNumber" runat="server"></asp:Label>
            </td>
            <td class="style8">
                　<asp:Label ID="Lbl_CKTime" 
                    runat="server"></asp:Label>
            </td>
            <td class="style60">
                <asp:Label ID="Lbl_PlanNo" runat="server"></asp:Label>
                　</td>
            <td class="style10" >
                　</td>
        </tr>
        <tr height="38">
            <td class="style4" height="38" >
                备注</td>
            <td class="style14" colspan="6" >
                <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>
                　</td>
        </tr>
        <tr height="37">
            <td class="style15"  height="37" style="mso-ignore: colspan">
                收货人信息</td>
            <td class="style16" >
            </td>
            <td class="style17">
            </td>
            <td class="style18">
            </td>
            <td class="style19">
            </td>
            <td class="style61">
            </td>
            <td class="style21">
            </td>
            <td class="style22">
            </td>
        </tr>
        <tr height="28">
            <td class="style23"  height="28" >
                收货单位名称：</td>
            <td class="style24" colspan="3" >
                　<asp:Label ID="Lbl_CustomerName" runat="server"></asp:Label>
            </td>
            <td class="style25" >
                收货人:</td>
            <td class="style26" >
                <asp:Label ID="Lbl_LinkMan" runat="server"></asp:Label>
                　</td>
            <td class="style26" >
            &nbsp;</td>
        </tr>
        <tr height="29">
            <td class="style28"  height="29" >
                收货地址：</td>
            <td class="style29" colspan="3" >
                　<asp:Label ID="Lbl_Address" runat="server"></asp:Label>
            </td>
            <td class="style25" >
                联系方式:</td>
            <td class="style30" >
                <asp:Label ID="Lbl_Tel" runat="server"></asp:Label>
                　</td>
            <td class="style30" >
            </td>
        </tr>
        <tr height="28">
            <td class="style31"  height="28" style="mso-ignore: colspan">
                运输信息</td>
            <td class="style32">
            </td>
            <td class="style17">
            </td>
            <td class="style18" >
            </td>
            <td class="style19">
            </td>
            <td class="style61">
            </td>
            <td class="style21" >
            </td>
        </tr>
        <tr height="25">
            <td class="style33"  height="25" >
                运输公司名称:</td>
            <td class="style24" colspan="3" >
                　<asp:Label ID="Lbl_KDName" 
                    runat="server"></asp:Label>
            </td>
            <td class="style25" >
                联系人:</td>
            <td class="style34" >
                &nbsp;</td>
            <td class="style35" width="167">
                　</td>
        </tr>
        <tr height="28">
            <td class="style23"  height="28" >
                物流/快递单号:</td>
            <td class="style36" colspan="3">
                　<asp:Label ID="Lbl_KDCode" 
                    runat="server"></asp:Label>
            </td>
            <td class="style25" >
                联系方式:</td>
            <td class="style37" >
                &nbsp;</td>
            <td class="style37" width="167">
                　</td>
        </tr>
        <tr height="28">
            <td class="style31"  height="28" style="mso-ignore: colspan">
                签收信息</td>
            <td class="style16" ">
            </td>
            <td class="style17" >
            </td>
            <td class="style18" >
            </td>
            <td class="style19" >
            </td>
            <td class="style20" >
            </td>
            <td class="style61">
            </td>
        </tr>
        <tr height="24">
            <td class="style39"  height="24" >
                收货人签字:</td>
            <td class="style40" ">
                　</td>
            <td class="style41" style="text-underline-style: single;" >
                <u style="VISIBILITY: hidden; mso-ignore: visibility">　</u></td>
            <td class="style42" style="text-underline-style: single;" >
                <u style="VISIBILITY: hidden; mso-ignore: visibility">　</u></td>
            <td  class="style43">
            </td>   <td >
            </td>
            <td class="style43" >
                &nbsp;</td>
            <td class="style44">
                　</td>
        </tr>
        <tr height="28">
            <td class="style23"  height="28" >
                日<span style="mso-spacerun: yes"> </span>期:<span style="mso-spacerun: yes">
                </span>
            </td>
            <td class="style45" ">
                　</td>
            <td class="style46" style="text-underline-style: single;" >
                <u style="VISIBILITY: hidden; mso-ignore: visibility">　</u></td>
            <td class="style47" style="text-underline-style: single;" >
                <u style="VISIBILITY: hidden; mso-ignore: visibility">　</u></td>   <td  class="style43">
            </td>
            <td class="style19" >
                备注</td>
            <td class="style37" style="text-underline-style: single;" >
                <u style="VISIBILITY: hidden; mso-ignore: visibility">　</u></td>
            <td class="style37" style="text-underline-style: single;">
                <u style="VISIBILITY: hidden; mso-ignore: visibility">　</u></td>
        </tr>
        <tr height="16">
            <td class="style51" height="16" >
            </td>
            <td class="style52" >
            </td>
            <td class="style53" ">
            </td>
            <td class="style54" >
            </td>
            <td class="style55" >
            </td>
            <td class="style56" >
            </td>
            <td class="style57" >
            </td>
        </tr>
        <tr height="19">
            <td class="style59" colspan="7" height="19" style="mso-ignore: colspan">
                当您收到上述货物时，请及时回传此发货单给我司（传真号：0571-88216187），谢谢合作！</td>
        </tr>
    </table>
<!--endprint-->
    <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="Tbx_DID" CssClass="Custom_Hidden"></asp:TextBox>
    <asp:TextBox runat="server" ID="Tbx_Number" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
    </form>
</body>
</html>
