<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Funnel.aspx.cs" Inherits="Web_SalesOpp_Xs_Sales_Funnel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>销售漏斗</title>
</head>
 <body leftmargin=0 topmargin=0 marginheight=0 marginwidth=0 class=small>
    <form id="form1" runat="server">
    <div>
	<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
	<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>	
	<script language="javascript">
           javaCalendarFirstDayOfWeek = 1;
           var userDateFormat = "yyyy-mm-dd";
        </script>
	<TABLE border=0 cellspacing=0 cellpadding=0 width=100% class="hdrNameBg">
	<tr>
		<td valign=top><a href="http://www.c3crm.com" target="_blank"><img src="../../../../themes/softed/images/ecustomer_logo.gif" alt="CRMone" title="CRMone" border=0></a></td>
		<td width=100% align=center>
		
		</td>
		<td class=small nowrap>
			<table border=0 cellspacing=0 cellpadding=0>
			 <tr>
			 <td id="sms" style="padding-left:10px;padding-right:10px" class=small nowrap><a onclick='window.open("index.php?module=Home&action=PopupSms","test","width=700,height=602,resizable=1,scrollbars=1");' href="JavaScript:;;">手机短信</a></td>
                         <td id="approve" style="padding-left:10px;padding-right:10px" class=small nowrap><a onClick='window.open("index.php?module=ApproveStatus&action=PopupListView","test","width=800,height=450,resizable=1,scrollbars=1");' href="JavaScript:;;">我的审批中心</a></td>
                         <td id="reminder" style="padding-left:10px;padding-right:10px" class=small nowrap><a onClick='window.open("index.php?module=CustomReminder&action=PopupReminders","test","width=700,height=602,resizable=1,scrollbars=1");' href="JavaScript:;;">自定义提醒</a></td>
			 <td style="padding-left:10px;padding-right:10px" class=small nowrap><a href="http://www.c3crm.com/forum/" target="_blank">我要提问</a></td>
			 <td style="padding-left:10px;padding-right:10px" class=small nowrap> <a href="index.php?module=Users&action=DetailView&record=37&modechk=prefview">帐号&设置</a></td>
			 <td style="padding-left:10px;padding-right:10px" class=small nowrap> <a href="index.php?module=Users&action=Logout">退出</a> (boss)</td>
			 </tr>
			</table>
		</td>
	</tr>
	</TABLE>
<div id="status" style="position:absolute;display:none;left:930px;top:95px;height:27px;white-space:nowrap;"><img src="../../themes/softed/images/status.gif"></div>
<!-- ActivityReminder Customization for callback -->
<div class="ListHead" id="ActivityRemindercallback" align="left">
</div>
<div id="SelCustomer_popview" class="layerPopup" style="position:absolute;z-index:60;display:none;">
</div><script language="JavaScript" type="text/javascript" src="../../include/js/ListView.js"></script>
<TABLE border=0 cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>销售 > 
	<a class="hdrLink" href="Xs_Sales_Funnel.aspx">销售漏斗</a></td>
	<td width=100% nowrap>		
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</TABLE>

<table border=0 cellspacing=0 cellpadding=0 width=98% align=center>
     
     <tr><td valign=top><img src="../../themes/softed/images/showPanelTopLeft.gif"></td>

	<td class="showPanelBg" valign="top" width=100% style="padding:10px;">
	  <div id="ListViewContents" class="small" style="width:100%;position:relative;">
            
<DIV style="padding-top:5px;">
<table width="80%">
        <tr>
	  <td align="left" colspan="2"><table width='100%' border=0 align='left'><form action='index.php' method='post'><input type='hidden' name='module' value='Funnels'><input type='hidden' name='action' value='ListView'><tr><td colspan='8'>查看范围 : <SELECT NAME='viewscope' id='viewscope' class='small'><option selected value="all_to_me">所有销售漏斗</option><option value="sub_user">下属的销售漏斗</option><option value="current_user">我的销售漏斗</option><optgroup label='销售部'><option  value='G::1'>所有销售部用户</option><option  value='U::23'>mike</option><option  value='U::24'>john</option><option  value='U::27'>andy</option><option  value='U::31'>vivi</option><option  value='U::32'>alan</option><option  value='U::37'>boss</option></optgroup><optgroup label='市场销售部'><option  value='G::2'>所有市场销售部用户</option><option  value='U::36'>lucy</option></optgroup><optgroup label='售后服务部'><option  value='G::3'>所有售后服务部用户</option><option  value='U::28'>kevin</option><option  value='U::30'>cherry</option><option  value='U::35'>Robin</option></optgroup><optgroup label='采购部'><option  value='G::4'>所有采购部用户</option><option  value='U::25'>lily</option><option  value='U::26'>melissa</option></optgroup><optgroup label='物料部（仓库）'><option  value='G::5'>所有物料部（仓库）用户</option><option  value='U::29'>fiona</option></optgroup><optgroup label='财务部'><option  value='G::6'>所有财务部用户</option><option  value='U::34'>helen</option></optgroup></SELECT>&nbsp;日期: <SELECT NAME='datecolumn' id='datecolumn' class='small'><option value='ec_potential.closingdate' selected >预计成交日期</option><option value='ec_potential.createdtime'  >创建时间</option><option value='ec_potential.modifiedtime'  >最新修改日期</option></SELECT><script language="JavaScript" type="text/javaScript">
		function showDateRange_jscal_field( type )
		{
			if (type!="custom")
			{
				    document.getElementById("jscal_field_date_start").readOnly=true
					document.getElementById("jscal_field_date_end").readOnly=true
					//document.getElementById("jscal_field_date_start").style.visibility="hidden"
					//document.getElementById("jscal_field_date_end").style.visibility="hidden"
			}
			else
			{
				    document.getElementById("jscal_field_date_start").readOnly=false
					document.getElementById("jscal_field_date_end").readOnly=false
					//document.getElementById("jscal_field_date_start").style.visibility="visible"
					//document.getElementById("jscal_field_date_end").style.visibility="visible"
			}
			if( type == "today" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-22";
				document.getElementById("jscal_field_date_end").value = "2012-11-22";
			}
			else if( type == "yesterday" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-21";
				document.getElementById("jscal_field_date_end").value = "2012-11-21";
			}
			else if( type == "tomorrow" )
			{

				document.getElementById("jscal_field_date_start").value = "2012-11-23";
				document.getElementById("jscal_field_date_end").value = "2012-11-23";
			}
			else if( type == "thisweek" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-18";
				document.getElementById("jscal_field_date_end").value = "2012-11-24";
			}
			else if( type == "lastweek" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-11";
				document.getElementById("jscal_field_date_end").value = "2012-11-17";
			}
			else if( type == "nextweek" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-25";
				document.getElementById("jscal_field_date_end").value = "2012-12-01";
			}
			else if( type == "thismonth" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-01";
				document.getElementById("jscal_field_date_end").value = "2012-11-30";
			}
			else if( type == "lastmonth" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-10-01";
				document.getElementById("jscal_field_date_end").value = "2012-10-31";
			}
			else if( type == "nextmonth" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-12-01";
				document.getElementById("jscal_field_date_end").value = "2012-12-31";
			}
			else if( type == "next7days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-22";
				document.getElementById("jscal_field_date_end").value = "2012-11-28";
			}
			else if( type == "next30days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-22";
				document.getElementById("jscal_field_date_end").value = "2012-12-21";
			}
			else if( type == "next60days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-22";
				document.getElementById("jscal_field_date_end").value = "2013-01-20";
			}
			else if( type == "next90days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-22";
				document.getElementById("jscal_field_date_end").value = "2013-02-19";
			}
			else if( type == "next120days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-22";
				document.getElementById("jscal_field_date_end").value = "2013-03-21";
			}
			else if( type == "last7days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-11-16";
				document.getElementById("jscal_field_date_end").value =  "2012-11-22";
			}
			else if( type == "last30days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-10-24";
				document.getElementById("jscal_field_date_end").value = "2012-11-22";
			}
			else if( type == "last60days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-09-24";
				document.getElementById("jscal_field_date_end").value = "2012-11-22";
			}
			else if( type == "last90days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-08-25";
				document.getElementById("jscal_field_date_end").value = "2012-11-22";
			}
			else if( type == "last120days" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-07-26";
				document.getElementById("jscal_field_date_end").value = "2012-11-22";
			}
			else if( type == "thisfy" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-01-01";
				document.getElementById("jscal_field_date_end").value = "2012-12-31";
			}
			else if( type == "prevfy" )
			{
				document.getElementById("jscal_field_date_start").value = "2011-01-01";
				document.getElementById("jscal_field_date_end").value = "2011-12-31";
			}
			else if( type == "nextfy" )
			{
				document.getElementById("jscal_field_date_start").value = "2013-01-01";
				document.getElementById("jscal_field_date_end").value = "2013-12-31";
			}
			else if( type == "nextfq" )
			{
				document.getElementById("jscal_field_date_start").value = "2013-01-01";
				document.getElementById("jscal_field_date_end").value = "2013-03-31";
			}
			else if( type == "prevfq" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-07-01";
				document.getElementById("jscal_field_date_end").value = "2012-09-30";
			}
			else if( type == "thisfq" )
			{
				document.getElementById("jscal_field_date_start").value = "2012-10-01";
				document.getElementById("jscal_field_date_end").value = "2012-12-31";
			}
			else
			{
				document.getElementById("jscal_field_date_start").value = "";
				document.getElementById("jscal_field_date_end").value = "";
			}
		}
	</script>&nbsp;<select name="stdDateFilter" class="select" onchange='showDateRange_jscal_field(this.options[this.selectedIndex].value )'><option value="custom">自定义</option><option value="prevfy">上财年</option><option value="thisfy">本财年</option><option value="nextfy">下财年</option><option value="prevfq">上季度</option><option value="thisfq">本季度</option><option value="nextfq">下季度</option><option value="yesterday">昨天</option><option value="today">今天</option><option value="tomorrow">明天</option><option value="lastweek">上星期</option><option value="thisweek">本星期</option><option value="nextweek">下星期</option><option value="lastmonth">上月</option><option selected value="thismonth">本月</option><option value="nextmonth">下月</option><option value="last7days">前7天</option><option value="last30days">前30天</option><option value="last60days">前60天</option><option value="last90days">前90天</option><option value="last120days">前120天</option><option value="next7days">后7天</option><option value="next30days">后30天</option><option value="next60days">后60天</option><option value="next90days">后90天</option><option value="next120days">后120天</option></select>&nbsp;&nbsp;开始时间&nbsp;<input type='text' id='jscal_field_date_start' name='startdate' value='2012-11-01' size='12'>&nbsp;<img src='../../themes/softed/images/calendar.gif' id='jscal_trigger_date_start' onclick="javascript:displayCalendar('jscal_field_date_start',this)">&nbsp;结束时间&nbsp;<input type='text' name='enddate' id='jscal_field_date_end' value='2012-11-30'  size='12'>&nbsp;<img src='../../themes/softed/images/calendar.gif' id='jscal_trigger_date_end' onclick="javascript:displayCalendar('jscal_field_date_end',this)">&nbsp;<input class='small button save' type='submit' name='submit' value='确定'></td></tr></form></table></td>
	</tr>
	<tr>
	  <td align="center" colspan="2" style="color:#cc0000; font-size:18px; font-weight:bolder">销售漏斗</td>
	</tr>
	<tr>
	  <td align="center">各阶段销售机会数量</td>
	  <td align="center">各阶段销售机会金额</td>
	</tr>
	<tr>
	  <td align="center">	<!-- START Code Block for Chart reportChart -->
	<OBJECT classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase=http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"  width="450" height="400" id="reportChart">
		<param name="allowScriptAccess" value="always" />
		<param name="movie" value="../../include/fusioncharts/Charts/FCF_Funnel.swf"/>		
		<param name="FlashVars" value="&chartWidth=450&chartHeight=400&dataXML=<chart caption='' subcaption=''  decimals='1' baseFontSize='11' isSliced='1' streamlinedData='0' isHollow='0' bgColor='EAEAEA' showBorder='0' formatNumberScale='0'><set label='初期沟通' value='0.001' link='javascript:getTabView2(0)' />
<set label='立项评估' value='0.001' link='javascript:getTabView2(1)' />
<set label='需求分析' value='0.001' link='javascript:getTabView2(2)' />
<set label='方案指定' value='0.001' link='javascript:getTabView2(3)' />
<set label='招投标/竞争' value='0.001' link='javascript:getTabView2(4)' />
<set label='商务谈判' value='0.001' link='javascript:getTabView2(5)' />
<set label='谈成结束' value='0.001' link='javascript:getTabView2(6)' />
<styles>
      <definition>
         <style type='font' name='captionFont' size='15' />
      </definition>
      <application>
      <apply toObject='CAPTION' styles='captionFont' />
      </application>
   </styles></chart>" />
		<param name="quality" value="high" />
		<embed src="../../include/fusioncharts/Charts/FCF_Funnel.swf" FlashVars="&chartWidth=450&chartHeight=400&dataXML=<chart caption='' subcaption=''  decimals='1' baseFontSize='11' isSliced='1' streamlinedData='0' isHollow='0' bgColor='EAEAEA' showBorder='0' formatNumberScale='0'><set label='初期沟通' value='0.001' link='javascript:getTabView2(0)' />
<set label='立项评估' value='0.001' link='javascript:getTabView2(1)' />
<set label='需求分析' value='0.001' link='javascript:getTabView2(2)' />
<set label='方案指定' value='0.001' link='javascript:getTabView2(3)' />
<set label='招投标/竞争' value='0.001' link='javascript:getTabView2(4)' />
<set label='商务谈判' value='0.001' link='javascript:getTabView2(5)' />
<set label='谈成结束' value='0.001' link='javascript:getTabView2(6)' />
<styles>
      <definition>
         <style type='font' name='captionFont' size='15' />
      </definition>
      <application>
      <apply toObject='CAPTION' styles='captionFont' />
      </application>
   </styles></chart>" quality="high" width="450" height="400" name="reportChart" allowScriptAccess="always" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
	</object>
	<!-- END Code Block for Chart reportChart --></td>
	  <td align="center">	
	<OBJECT classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0"  width="450" height="400" id="OBJECT1">
		<param name="allowScriptAccess" value="always" />
		<param name="movie" value="../../include/fusioncharts/Charts/FCF_Funnel.swf"/>		
		<param name="FlashVars" value="&chartWidth=450&chartHeight=400&dataXML=<chart caption='' subcaption=''  decimals='2' baseFontSize='11' isSliced='1' streamlinedData='0' isHollow='0' bgColor='EAEAEA' showBorder='0' numberPrefix='￥' formatNumberScale='0' ><set label='初期沟通' value='0.001' link='javascript:getTabView2(0)' />
<set label='立项评估' value='0.001' link='javascript:getTabView2(1)' />
<set label='需求分析' value='0.001' link='javascript:getTabView2(2)' />
<set label='方案指定' value='0.001' link='javascript:getTabView2(3)' />
<set label='招投标/竞争' value='0.001' link='javascript:getTabView2(4)' />
<set label='商务谈判' value='0.001' link='javascript:getTabView2(5)' />
<set label='谈成结束' value='0.001' link='javascript:getTabView2(6)' />
<styles>
      <definition>
         <style type='font' name='captionFont' size='15' />
      </definition>
      <application>
      <apply toObject='CAPTION' styles='captionFont' />
      </application>
   </styles></chart>" />
		<param name="quality" value="high" />
		<embed src="../../include/fusioncharts/Charts/FCF_Funnel.swf" FlashVars="&chartWidth=450&chartHeight=400&dataXML=<chart caption='' subcaption=''  decimals='2' baseFontSize='11' isSliced='1' streamlinedData='0' isHollow='0' bgColor='EAEAEA' showBorder='0' numberPrefix='￥' formatNumberScale='0' ><set label='初期沟通' value='0.001' link='javascript:getTabView2(0)' />
<set label='立项评估' value='0.001' link='javascript:getTabView2(1)' />
<set label='需求分析' value='0.001' link='javascript:getTabView2(2)' />
<set label='方案指定' value='0.001' link='javascript:getTabView2(3)' />
<set label='招投标/竞争' value='0.001' link='javascript:getTabView2(4)' />
<set label='商务谈判' value='0.001' link='javascript:getTabView2(5)' />
<set label='谈成结束' value='0.001' link='javascript:getTabView2(6)' />
<styles>
      <definition>
         <style type='font' name='captionFont' size='15' />
      </definition>
      <application>
      <apply toObject='CAPTION' styles='captionFont' />
      </application>
   </styles></chart>" quality="high" width="450" height="400" name="reportChart" allowScriptAccess="always" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
	</object>
	<!-- END Code Block for Chart reportChart --></td>
	</tr>
	<tr>
		<td align="center">总计: 0</td>
		<td align="center">总计: </td>
	</tr>
</table>
</DIV>

<div id="PotentialContents" class="small" style="width:80%;position:relative;">
</div>
<script>
var stagearr=['初期沟通','立项评估','需求分析','方案指定','招投标/竞争','商务谈判','谈成结束'];
</script>

<script>
	var currentstage='';
	var urlstring='';
	
	function getTabView2(stageindex){
		
		var stage=stagearr[stageindex];
		getTabView(stage);
	}
	function getTabView(stage){
		var startdate=$F('jscal_field_date_start');
		var enddate=$F('jscal_field_date_end');
		var viewscope=$F('viewscope');

		
		currentstage=stage;
		urlstring='';
		$("status").style.display="inline";
		new Ajax.Request(
			'index.php',
			{queue: {position: 'end', scope: 'command'},
				method: 'post',
				postBody: 'module=Funnels&action=FunnelsAjax&file=PotentialListView&startdate='+startdate+'&enddate='+enddate+'&viewscope='+viewscope+'&stage='+stage,
				onComplete: function(response) {
					$("status").style.display="none";
					$("PotentialContents").update(response.responseText);
					
				}
			}
		);
		
		
	 }

	 function getListViewEntries_js(module,url){
		var startdate=$F('jscal_field_date_start');
		var enddate=$F('jscal_field_date_end');
		var viewscope=$F('viewscope');
		var ustring='';
		if(urlstring=='') ustring='';
		else ustring='&'+urlstring;
		$("status").style.display="inline";
		new Ajax.Request(
			'index.php',
			{queue: {position: 'end', scope: 'command'},
				method: 'post',
				postBody: 'module=Funnels&action=FunnelsAjax&file=PotentialListView&startdate='+startdate+'&enddate='+enddate+'&viewscope='+viewscope+'&stage='+currentstage+'&'+url+ustring,
				onComplete: function(response) {
					$("status").style.display="none";
					$("PotentialContents").update(response.responseText);
					
				}
			}
		);
	 }

	 function getListViewEntries_jswithurl(module,url){
		var startdate=$F('jscal_field_date_start');
		var enddate=$F('jscal_field_date_end');
		var viewscope=$F('viewscope');
		urlstring=url;
		$("status").style.display="inline";
		new Ajax.Request(
			'index.php',
			{queue: {position: 'end', scope: 'command'},
				method: 'post',
				postBody: 'module=Funnels&action=FunnelsAjax&file=PotentialListView&startdate='+startdate+'&enddate='+enddate+'&viewscope='+viewscope+'&stage='+currentstage+'&'+url,
				onComplete: function(response) {
					$("status").style.display="none";
					$("PotentialContents").update(response.responseText);
					
				}
			}
		);
	 }

	 function getListViewWithPageNo(module,pageElement)
	{
		//var pageno = document.getElementById('listviewpage').value;
		var pageno = pageElement.options[pageElement.options.selectedIndex].value;
		getListViewEntries_js(module,'start='+pageno);
	}

</script>

     


	  </div>

     </td>
        <td valign=top><img src="../../../../themes/softed/images/showPanelTopRight.gif"></td>
   </tr>
</table>
<script language = 'JavaScript' type='text/javascript' src = '../../include/js/popup.js'></script>
    </div>
    </form>
</body>
</html>
