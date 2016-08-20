﻿<!--#include file = "private.asp"-->
<%
'######################################
' eWebEditor V10.0 - Advanced online web based WYSIWYG HTML editor.
' Copyright (c) 2003-2015 eWebSoft.com
'
' For further information go to http://www.ewebeditor.net/
' This copyright notice MUST stay intact for use.
'######################################
%>
<%
If CheckLicense()=False Then
Call GoLicense()
End If
Dim sStyleID, sCurrDir, sDir, sCurrPath, sFSOname
sPosition = sPosition & "上传文件管理"
Call Header()
Call Content()
Call Footer()
Sub Content()
Call InitParam()
Select Case sAction
Case "DELALL"
Call DoDelAll()
Case "DEL"
Call DoDel()
Case "DELFOLDER"
Call DoDelFolder()
End Select
Call ShowList()
End Sub
Sub ShowList()
Dim sCurrPage, nCurrPage, nFileNum, nPageNum, nPageSize
sCurrPage = Trim(Request("page"))
Dim s_ViewMode, s_FormViewMode
s_ViewMode = Trim(Request("d_viewmode"))
s_FormViewMode = InitSelect("d_viewmode", Split("预览模式|列表模式", "|"), Split("|list", "|"), s_ViewMode, "", "onchange=""location.href='?id=" & sStyleID & "&d_viewmode='+this.value+'&dir=" & sDir & "&page=" & sCurrPage & "'""")
Response.Write "<table border=0 cellspacing=1 align=center class=navi>" & _
"<form action='?' method=post name=queryform>" & _
"<tr><th>" & sPosition & "</th></tr>" & _
"<tr><td align=right><b>显示模式：</b>" & s_FormViewMode & " <b>选择样式目录：</b><select name='id' size=1 onchange=""this.form.submit()"">" & InitSelectStyle(sStyleID, "选择...") & "</select></td></tr>" & _
"</form></table><br>"
If sCurrDir = "" Then Exit Sub
Dim s_QueryStr
s_QueryStr = "?id=" & sStyleID & "&d_viewmode=" & s_ViewMode & "&dir=" & sDir
Response.Write "<table border=0 cellspacing=1 class=list align=center>" & _
"<form action='" & s_QueryStr & "&action=del' method=post name=myform>" & _
"<tr align=center>" & _
"<th width='10%'>类型</th>" & _
"<th width='40%'>文件地址</th>" & _
"<th width='10%'>大小</th>" & _
"<th width='15%'>最后访问</th>" & _
"<th width='15%'>上传日期</th>" & _
"<th width='10%'>删除</th>" & _
"</tr>"
nPageSize = 20
If sCurrpage = "" Or Not IsNumeric(sCurrPage) Then
nCurrPage = 1
Else
nCurrPage = CLng(sCurrPage)
End If
Dim oFSO, oUploadFolder, oUploadFiles, oUploadFile, sFileName
Set oFSO = Server.CreateObject(sFSOname)
On Error Resume Next
Set oUploadFolder = oFSO.GetFolder(sCurrDir)
If Err.Number>0 Then
Response.Write "<tr><td colspan=6>无效的目录！</td></tr></table>"
Exit Sub
End If
If sDir <> "" Then
Response.Write "<tr align=center>" & _
"<td><img border=0 src='../sysimage/file/folderback.gif'></td>" & _
"<td align=left colspan=5><a href=""?id=" & sStyleID & "&d_viewmode=" & s_ViewMode & "&dir="
If InstrRev(sDir, "/") > 1 Then
Response.Write Left(sDir, InstrRev(sDir, "/") - 1)
End If
Response.Write """>返回上一级目录</a></td></tr>"
End If
Dim oSubFolder
For Each oSubFolder In oUploadFolder.SubFolders
Response.Write "<tr align=center>" & _
"<td><img border=0 src='../sysimage/file/folder.gif'></td>" & _
"<td align=left colspan=4><a href=""?id=" & sStyleID & "&d_viewmode=" & s_ViewMode & "&dir="
If sDir <> "" Then
Response.Write sDir & "/"
End If
Response.Write oSubFolder.Name & """>" & oSubFolder.Name & "</a></td>" & _
"<td><a href='" & s_QueryStr & "&action=delfolder&foldername=" & oSubFolder.Name & "'>删除</a></td></tr>"
Next
Set oUploadFiles = oUploadFolder.Files
nFileNum = oUploadFiles.Count
nPageNum = Int(nFileNum / nPageSize)
If nFileNum Mod nPageSize > 0 Then
nPageNum = nPageNum+1
End If
If nCurrPage > nPageNum Then
nCurrPage = nPageNum
End If
Dim i, m, n
i = 0
m = 0
n = 0
For Each oUploadFile In oUploadFiles
i = i + 1
If i > (nCurrPage - 1) * nPageSize And i <= nCurrPage * nPageSize Then
sFileName = oUploadFile.Name
If s_ViewMode = "list" Then
Response.Write "<tr align=center>" & _
"<td>" & FileName2Pic(sFileName) & "</td>" & _
"<td align=left><a href=""" & sCurrPath & sFileName & """ target=_blank>" & sFileName & "</a></td>" & _
"<td>" & oUploadFile.size & " B </td>" & _
"<td>" & oUploadFile.datelastaccessed & "</td>" & _
"<td>" & oUploadFile.datecreated & "</td>" & _
"<td><input type=checkbox name=delfilename value=""" & sFileName & """></td></tr>"
Else
n = n + 1
m = n Mod 4
If n = 1 Then
Response.Write "<tr align=center><td colspan=6><table border=0 cellspacing=1 width='98%' class=list>"
End If
If m = 1 Then
Response.Write "<tr>"
End If
Response.Write "<td width='25%' valign=top align=center><table border=0 cellspacing=1>" & _
"<tr><td width=200 height=200 align=center>" & File2Preview(sCurrPath, sFileName) & "</td></tr>" & _
"<tr><td>文件名称：<a href=""" & sCurrPath & sFileName & """ target=_blank>" & sFileName & "</a></td></tr>" & _
"<tr><td>文件大小：" & oUploadFile.size & " B</td></tr>" & _
"<tr><td>最后访问：" & oUploadFile.datelastaccessed & "</td></tr>" & _
"<tr><td>创建日期：" & oUploadFile.datecreated & "</td></tr>" & _
"<tr><td>操作选择：<input type=checkbox name=delfilename value=""" & sFileName & """></td></tr>" & _
"</table></td>"
If m = 0 Then
Response.Write "</tr>"
End If
End If
Elseif i > nCurrPage * nPageSize Then
Exit For
End If
Next
Set oUploadFolder = Nothing
Set oUploadFiles = Nothing
If s_ViewMode <> "list" Then
If n > 0 Then
Dim ii
If m <> 0 Then
For ii = 1 To 4 - m
Response.Write "<td width='25%'>&nbsp;</td>"
Next
Response.Write "</tr>"
End If
Response.Write "</table></td></tr>"
End If
End If
If nFileNum <= 0 Then
Response.Write "<tr><td colspan=6>指定目录下现在还没有文件！</td></tr>"
End If
If nFileNum > 0 Then
Response.Write "<tr><td colspan=6><table border=0 cellpadding=3 cellspacing=0 width='100%'><tr><td>"
If nCurrPage > 1 Then
Response.Write "<a href='" & s_QueryStr & "&page=1'>首页</a>&nbsp;&nbsp;<a href='" & s_QueryStr & "&page="& nCurrPage - 1 & "'>上一页</a>&nbsp;&nbsp;"
Else
Response.Write "首页&nbsp;&nbsp;上一页&nbsp;&nbsp;"
End If
If nCurrPage < nPageNum Then
Response.Write "<a href='" & s_QueryStr & "&page=" & nCurrPage + 1 & "'>下一页</a>&nbsp;&nbsp;<a href='" & s_QueryStr & "&page=" & nPageNum & "'>尾页</a>"
Else
Response.Write "下一页&nbsp;&nbsp;尾页"
End If
Response.Write "&nbsp;&nbsp;&nbsp;&nbsp;共<b>" & nFileNum & "</b>个&nbsp;&nbsp;页次:<b><span class=highlight2>" & nCurrPage & "</span>/" & nPageNum & "</b>&nbsp;&nbsp;<b>" & nPageSize & "</b>个文件/页"
Response.Write "&nbsp;&nbsp;转到:"
Response.Write "<select name='page' size=1 onchange=""location.href='" & s_QueryStr & "&page='+this.options[this.selectedIndex].value;"">"
For n = 1 To nPageNum
Response.Write "<option value='" & n & "'"
If n = nCurrPage Then
Response.Write " selected"
End If
Response.Write ">第" & n & "页</option>"
Next
Response.Write "</select>"
Response.Write "</td><td align=right><input type=checkbox id=b_selectall onclick='doCheckAll(this)'><label for=b_selectall>全选</label>&nbsp; <input type=submit name=b value='删除选定的文件'> <input type=button name=b1 value='清空本目录所有文件' onclick=""javascript:if (confirm('你确定要清空所有文件吗？')) {location.href='" & s_QueryStr & "&action=delall';}""></td></tr></table></td></tr>"
End If
Response.Write "</form></table>"
End Sub
Sub DoDel()
On Error Resume Next
Dim sFileName, oFSO, sMapFileName
Set oFSO = Server.CreateObject(sFSOname)
For Each sFileName In Request.Form("delfilename")
sMapFileName = sCurrDir & sFileName
If oFSO.FileExists(sMapFileName) Then
oFSO.DeleteFile(sMapFileName)
End If
Next
Set oFSO = Nothing
End Sub
Sub DoDelAll()
On Error Resume Next
Dim sFileName, oFSO, sMapFileName, oFolder, oFiles, oFile
Set oFSO = Server.CreateObject(sFSOname)
Set oFolder = oFSO.GetFolder(sCurrDir)
Set oFiles = oFolder.Files
For Each oFile In oFiles
sFileName = oFile.Name
sMapFileName = sCurrDir & sFileName
If oFSO.FileExists(sMapFileName) Then
oFSO.DeleteFile(sMapFileName)
End If
Next
Set oFile = Nothing
Set oFolder = Nothing
Set oFSO = Nothing
End Sub
Sub DoDelFolder()
On Error Resume Next
Dim sFolderName, oFSO, sMapFolderName
Set oFSO = Server.CreateObject(sFSOname)
sFolderName = Trim(Request("foldername"))
sMapFolderName = sCurrDir & sFolderName
If oFSO.FolderExists(sMapFolderName) = True Then
oFSO.DeleteFolder(sMapFolderName)
End If
Set oFSO = Nothing
End Sub
Function IsObjInstalled(strClassString)
On Error Resume Next
IsObjInstalled = False
Err = 0
Dim xTestObj
Set xTestObj = Server.CreateObject(strClassString)
If 0 = Err Then IsObjInstalled = True
Set xTestObj = Nothing
Err = 0
End Function
Function FileName2Pic(sFileName)
Dim sExt, sPicName
sExt = UCase(Mid(sFileName, InstrRev(sFileName, ".")+1))
Select Case sExt
Case "TXT"
sPicName = "txt.gif"
Case "CHM", "HLP"
sPicName = "hlp.gif"
Case "DOC"
sPicName = "doc.gif"
Case "PDF"
sPicName = "pdf.gif"
Case "MDB"
sPicName = "mdb.gif"
Case "GIF"
sPicName = "gif.gif"
Case "JPG", "JPEG"
sPicName = "jpg.gif"
Case "BMP"
sPicName = "bmp.gif"
Case "PNG"
sPicName = "pic.gif"
Case "ASP", "JSP", "JS", "PHP", "PHP3", "ASPX"
sPicName = "code.gif"
Case "HTM", "HTML", "SHTML"
sPicName = "htm.gif"
Case "ZIP"
sPicName = "zip.gif"
Case "RAR"
sPicName = "rar.gif"
Case "EXE"
sPicName = "exe.gif"
Case "AVI"
sPicName = "avi.gif"
Case "MPG", "MPEG", "ASF"
sPicName = "mp.gif"
Case "RA", "RM"
sPicName = "rm.gif"
Case "MP3"
sPicName = "mp3.gif"
Case "MID", "MIDI"
sPicName = "mid.gif"
Case "WAV"
sPicName = "audio.gif"
Case "XLS"
sPicName = "xls.gif"
Case "PPT", "PPS"
sPicName = "ppt.gif"
Case "SWF"
sPicName = "swf.gif"
Case Else
sPicName = "unknow.gif"
End Select
FileName2Pic = "<img border=0 src='../sysimage/file/" & sPicName & "'>"
End Function
Function File2Preview(s_Path, s_File)
Dim s_PathFile
s_PathFile = s_Path & s_File
Dim sExt
sExt = UCase(Mid(s_File, InstrRev(s_File, ".")+1))
Select Case sExt
Case "GIF", "JPG", "JPEG", "BMP", "PNG"
File2Preview = "<a href='" & s_PathFile & "' target='_blank'><img border=0 src='" & s_PathFile & "' width=180 height=180></a>"
Case "SWF"
File2Preview = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0' width=180 height=180>" & _
"<param name='movie' value='" & s_PathFile & "'>" & _
"<param name='quality' value='high'>" & _
"<embed src='" & s_PathFile & "' quality='high' width=180 height=180 type='application/x-shockwave-flash\' pluginspage='http://www.macromedia.com/go/getflashplayer'></embed>" & _
"</object>"
Case Else
File2Preview = FileName2Pic(s_File)
End Select
End Function
Function InitSelectStyle(v_InitValue, s_AllName)
Dim i, aTemp
InitSelectStyle = ""
If s_AllName <> "" Then
InitSelectStyle = InitSelectStyle & "<option value=''>" & s_AllName & "</option>"
End If
For i = 1 To Ubound(aStyle)
aTemp = Split(aStyle(i), "|||")
InitSelectStyle = InitSelectStyle & "<option value='" & i & "'"
If CStr(i) = CStr(v_InitValue) Then
InitSelectStyle = InitSelectStyle & " selected"
End If
InitSelectStyle = InitSelectStyle & ">样式：" & inHTML(aTemp(0)) & "---目录：" & inHTML(aTemp(3)) & "</option>"
Next
End Function
Function InitParam()
Dim i, a_CurrStyle, s_UploadDir, s_BaseUrl
sStyleID = Trim(Request("id"))
s_UploadDir = ""
If IsNumeric(sStyleID) = True Then
If Clng(sStyleID) <= Ubound(aStyle) Then
a_CurrStyle = Split(aStyle(Clng(sStyleID)), "|||")
s_UploadDir = a_CurrStyle(3)	
End If
End If
If s_UploadDir = "" Then
sStyleID = ""
sCurrDir = ""
Exit Function
End If 
sFSOname = a_CurrStyle(21)
If sFSOname = "" Then
sFSOname = "Scripting.FileSystemObject"
End If
If IsObjInstalled(sFSOname) = False Then
Response.Write "此功能要求服务器支持文件系统对象（FSO），而你当前的服务器不支持！"
Exit Function
End If
s_BaseUrl = a_CurrStyle(19)
If s_BaseUrl = "3" Then
sCurrDir = s_UploadDir
sCurrPath = a_CurrStyle(23)
Else
If Left(s_UploadDir,1)<>"/" Then
s_UploadDir = "../" & s_UploadDir
End If 
sCurrDir = Server.MapPath(s_UploadDir)
sCurrPath = s_UploadDir
End If
If CheckValidDir(sCurrDir) = False Then
sCurrDir = ""
Exit Function
End If
If Right(sCurrDir,1)<>"\" Then
sCurrDir = sCurrDir & "\"
End If
If Right(sCurrPath,1)<>"/" Then
sCurrPath = sCurrPath & "/"
End If
sDir = Trim(Request("dir"))
If sDir <> "" Then
Dim s_Dir2
s_Dir2 = Replace(sDir, "/", "\")
If CheckValidDir(sCurrDir & s_Dir2) = True Then
sCurrDir = sCurrDir & s_Dir2 & "\"
sCurrPath = sCurrPath & sDir & "/"
Else
sDir = ""
End If
End If
End Function
Function CheckValidDir(s_Dir)
Dim oFSO
Set oFSO = Server.CreateObject(sFSOname)
CheckValidDir = oFSO.FolderExists(s_Dir)
Set oFSO = Nothing	
End Function
%>