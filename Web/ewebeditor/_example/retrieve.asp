﻿<HTML>
<HEAD>
<TITLE>eWebEditor ： 表单接收示例</TITLE>
<META http-equiv=Content-Type content="text/html; charset=utf-8">
<link rel='stylesheet' type='text/css' href='example.css'>
</HEAD>
<BODY>

<p><b>导航 ： <a href="default.asp">示例首页</a> &gt; 表单接收示例</b></p>
<p>此例演示了如何接收到表单提交过来的HTML代码，并显示它。</p>

<%
Dim sContent1, i

For i = 1 To Request.Form("content1").Count 
	sContent1 = sContent1 & Request.Form("content1")(i) 
Next 

Response.Write "编辑内容如下：<br><br>" & sContent1
Response.Write "<br><br><p><input type=button value=' 后退 ' onclick='history.back()'></p>"
%>

</BODY>
</HTML>