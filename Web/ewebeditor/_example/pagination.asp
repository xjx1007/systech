﻿<HTML>
<HEAD>
<TITLE>eWebEditor ： 分页显示处理示例</TITLE>
<META http-equiv=Content-Type content="text/html; charset=utf-8">
<link rel='stylesheet' type='text/css' href='example.css'>
</HEAD>
<BODY>

<p><b>导航 ： <a href="default.asp">示例首页</a> &gt; 分页显示处理示例</b></p>
<p>此例演示了eWebEditor的标准分页模式下，程序对标准分页符的处理方法。您可以查看此页程序源代码，以了解标准分页符结构及使用方法。</p>


<%
' eWebEditor 标准分页符格式定义：
' -------------------------------------------------------------------
' <!--ewebeditor:page title="第N页小标题"-->
' 第N页正文HTML代码
' <!--/ewebeditor:page-->
' -------------------------------------------------------------------





' sContent变量：所编辑的内容，一般是从数据库中取出，以下为模拟数据
Dim sContent
' sContent = rs("field")
sContent = "<!--ewebeditor:page title=""第一页小标题""-->" & vbCrlf & _
           "<style>" & vbCrlf & _
		   ".p1{font-size:14px;color:#000000;}" & vbCrlf & _
		   ".p2{font-size:16px;color:#ff0000;}" & vbCrlf & _
		   ".p3{font-size:18px;color:#0000ff;}" & vbCrlf & _
		   "</style>" & vbCrlf & _
           "<p class=p1>第一页正文</p>" & vbCrlf & _
           "<!--/ewebeditor:page-->" & vbCrlf & _
		   "<!--ewebeditor:page title=""第二页小标题""-->" & vbCrlf & _
           "<p class=p2>第二页正文</p>" & vbCrlf & _
           "<!--/ewebeditor:page-->" & vbCrlf & _
		   "<!--ewebeditor:page title=""第三页小标题""-->" & vbCrlf & _
           "<p class=p3>第三页正文</p>" & vbCrlf & _
           "<!--/ewebeditor:page-->"
'sContent = "<p>只有一页！</p>"



Dim arr, sPage, sOutputTitles, sOutputContent
sPage = Trim(Request("page"))
arr = eWebEditorPagination(sContent, sPage)
sOutputContent = arr(1)
sOutputTitles = arr(2)

' 显示标题列表及分页链接
If sOutputTitles <> "" Then
	Response.Write "<hr size=1>"
	Response.Write sOutputTitles	
End If

' 显示正文
Response.Write "<hr size=1>"
Response.Write sOutputContent






' eWebEditor 标准分页符格式定义：
' -------------------------------------------------------------------
' <!--ewebeditor:page title="第N页小标题"-->
' 第N页正文HTML代码
' <!--/ewebeditor:page-->
' -------------------------------------------------------------------
' eWebEditor标准分页符分析处理函数示列, 可依实际需要修改, 返回多值数组
' -------------------------------------------------------------------
Function eWebEditorPagination(ByVal s_Content, ByVal s_CurrPage)
	' 小标题列表，当前页标题，当前页内容
	Dim s_Titles, s_CurrTitle, s_CurrContent
	s_Titles = ""
	s_CurrTitle = ""
	s_CurrContent = s_Content

	' 页数：0表示没有分页
	Dim n_PageCount
	n_PageCount = 0

	' 当前页
	Dim n_CurrPage
	n_CurrPage = 1

	' 当有分页时，存分页正文和标题的数组，下标从1开始
	Dim a_PageContent(), a_PageTitle()

	' 正则表达式对象
	Dim re, m, ms
	Set re = new RegExp
	re.IgnoreCase  = True
	re.Global = True

	' 分离出内容中的CSS样式部分，然后在各页中合并，使各分页的显示效果不变
	' <style>...</style>
	Dim s_Style
	s_Style = ""
	re.Pattern = "<style[^>]*>([\s\S]+?)</style>"
	Set ms = re.Execute(s_CurrContent)
	If ms.Count>0 Then
		For Each m in ms
			s_Style = vbCrlf & s_Style & m.Value & vbCrlf
		Next
		s_CurrContent = re.Replace(s_CurrContent, "")
	End If

	' 使用正则表达式对分页进行处理
	re.Pattern = "<!--ewebeditor:page title=""([^"">]*)""-->([\s\S]+?)<!--/ewebeditor:page-->"
	Set ms = re.Execute(s_CurrContent)
	For Each m in ms
		n_PageCount = n_PageCount + 1
		ReDim Preserve a_PageTitle(n_PageCount)
		ReDim Preserve a_PageContent(n_PageCount)
		a_PageTitle(n_PageCount) = m.SubMatches(0)
		a_PageContent(n_PageCount) = m.SubMatches(1)
	Next

	If n_PageCount = 0 Then
		' 没有分页
		s_Titles = ""
		s_CurrContent = s_Content
	Else
		' 有分页
		' 从参数判断当前页的有效性
		If IsNumeric(s_CurrPage) = False Then
			n_CurrPage = 1
		Else
			n_CurrPage = CInt(s_CurrPage)
			If n_CurrPage < 1 Or n_CurrPage > n_PageCount Then
				n_CurrPage = 1
			End If
		End If

		Dim i
		' 当有多个页时，显示分页小标题及分页链接
		s_Titles = ""
		For i = 1 To n_PageCount
			If i = n_CurrPage Then
				s_Titles = s_Titles & "<li>" & i & ") " & a_PageTitle(i) & ""
			Else		
				s_Titles = s_Titles & "<li><a href='?page=" & i & "'>" & i & ") " & a_PageTitle(i) & "</a>"
			End If
		Next

		' 当前页标题和内容
		s_CurrTitle = a_PageTitle(n_CurrPage)
		s_CurrContent = s_Style & a_PageContent(n_CurrPage)
	End If

	' 返回值数组，依实际需要修改
	Dim ret(3)
	ret(1) = s_CurrContent		'当前页内容
	ret(2) = s_Titles			'标题列表
	ret(3) = s_CurrTitle		'当前页标题

	eWebEditorPagination = ret
End Function

%>

</BODY>
</HTML>