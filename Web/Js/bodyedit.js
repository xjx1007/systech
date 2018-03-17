//THT 2004-10-19 11:16
//画left.asp树函数
//例：drawLeft('+','KB1_4','***设置','')
//	  drawLeft('-','KB1_4','***输入','zb_record/i_record.asp');
function drawLeft(type,id,ttl,url)
{
	var sf="";
	switch(type)
	{
		case '+':
			sf+="<a class='a02' href onClick='expandIt(\""+id+"\",\"regular\",1,1); return false;'>";
			sf+="<img id='"+id+"regular_1' src='../pic/toc_plus.gif' border='0' align='absmiddle' WIDTH='11' HEIGHT='11'>";
			sf+="<span id='"+id+"span'>"+ttl+"</span>";
			sf+="</a><br>";
			sf+="<div id='"+id+"regular' class='regular'></div>";
			document.write(sf);
			break;
		case '++':
			var a=id.split('|');
			if(a.length==2)
			{
				var o=document.getElementById(a[0]+"regular");
				if (!o) return;
				sf+="<a class='a02' href onClick='expandIt(\""+a[1]+"\",\"regular\",1,1); return false;'>";
				sf+="<img id='"+a[1]+"regular_1' src='../pic/toc_plus.gif' border='0' align='absmiddle' WIDTH='11' HEIGHT='11'>";
				sf+="<span id='"+id+"span'>"+ttl+"</span>";
				sf+="</a><br>";
				sf+="<div id='"+a[1]+"regular' class='regular'></div>";	
				o.innerHTML+=sf;
			}
			else
				alert("树型不对");
			break;
		case '-':
			var o=document.getElementById(id+"regular");
			if (!o) return;
				sf+="<a class='a02' href='"+url+"'>";
				sf+="<img src='../pic/toc_end.gif' border='0' align='absmiddle' WIDTH='11' HEIGHT='11'>";
				sf+=ttl;
				sf+="</a><br>";
			o.innerHTML+=sf;
			break;
		default:
			var o=document.getElementById(id+"regular");
			sf+="<a class='a02' href='"+url+"'>";
			sf+="<img src='../pic/toc_end.gif' border='0' align='absmiddle' WIDTH='11' HEIGHT='11'>";
			sf+=ttl;
			sf+="</a><br>";
			if (o)
				o.innerHTML+=sf;
			else
				document.write(sf);
			break;
		//default:
		//	alert("树型不对");
		//	break;
	}
}
//THT 2004-12-10 9:22
//从select元素的text中找到最匹配的字符串
// searchFromSelect(select元素,[str])
function searchFromSelect(o,str){
	if(o.tagName=="SELECT"){
		var opts=o.options;
		str=str ? str:event.srcElement.innerText;
		var tmp='';
		var kCode=event.keyCode;

		if(str!=""){
			if (kCode==33 || kCode==38 || kCode==35)//向上翻页，方向键，end
			{
				o.selectedIndex=o.selectedIndex>0 ? o.selectedIndex-1:0;
				if (kCode==35) o.selectedIndex=opts.length-1;
				for(var i=o.selectedIndex;i>=0;i--){
					tmp=opts(i % opts.length).text;
					if(tmp.indexOf(str)>=0){
						o.selectedIndex=i % opts.length;
						return;
					}  
				}
			}
			if (kCode==34 || kCode==40 || kCode==36)//
			{
				o.selectedIndex++;
				if (kCode==36) o.selectedIndex=opts.length-1;
			}
			for(var i=o.selectedIndex;i<(opts.length+o.selectedIndex);i++){
				tmp=opts(i % opts.length).text;
				if(tmp.indexOf(str)>=0){
					o.selectedIndex=i % opts.length;
					return;
				}  
			}
			o.selectedIndex=0;
		}
	}
}

function getItem(el,type,value){
	var temp = el;
	while ((temp != null) && (temp.tagName != "BODY")) {
		if (eval("temp." + type) == value)
			return temp;
		temp = temp.parentElement;
	}
	return temp;
}

function KeyFiltr(type){
	var berr=false;
	switch(type)
	{
		case 'date':
			if (!(event.keyCode == 45 || event.keyCode == 47 || (event.keyCode>=48 && event.keyCode<=58)))
				berr=true;
			break;
		case 'number':
			if (!(event.keyCode>=48 && event.keyCode<=57))
				berr=true;
			break;
		case 'cy':
			if (!(event.keyCode == 46 || (event.keyCode>=48 && event.keyCode<=57)))
				berr=true;
			break;
		case 'long':
			if (!(event.keyCode == 45 || (event.keyCode>=48 && event.keyCode<=57)))
				berr=true;
			break;
		case 'double':
			if (!(event.keyCode == 45 || event.keyCode == 46 || (event.keyCode>=48 && event.keyCode<=57)))
				berr=true;
			break;
		default:
			if (event.keyCode == 35 || event.keyCode == 37 || event.keyCode==38)
				berr=true;
	}
	return !berr;
}

function KeyJudge(type,len){
	var berr=false;
	switch(type)
	{
		case 'date':
			berr=JudgeDate();
			break;
		case 'number':
			berr=JudgeNumber(1,len);
			break;
		case 'cy':
			berr=JudgeNumber(1,len);
			break;
		case 'long':
			berr=JudgeNumber(2,len);
			break;
		case 'double':
			berr=JudgeNumber(2,len);
			break;
		default:
			berr=true;
	}
	return !berr;	
}

function JudgeDate(){
	var ipt=window.event.srcElement;
	var v=ipt.value;
	if (v!=""){
		var reg1=/^\d{4}-((0?[1-9])|(1[0-2]))-((0?[1-9])|([12][0-9])|(3[0-1]))$/;
		if(!reg1.test(v)){
			alert("请输入正确的时间格式(YYYY-MM-DD)");
			ipt.select();
			return false;
		}
	}
	return false;
}

function JudgeNumber(type,len){
	var ipt=window.event.srcElement;
	var v=ipt.value;
	if (v!=""){
		/***** 过滤字符串前面的（0）,防止以八进制数对待 **********/
		v=delZero(v);
		/************* end here **********************************/
		if (!IsNum(v)){
			window.alert ("请输入正确的数字！");
			ipt.select ();
			return false;
		}
		//if(parseFloat(v)<0 && !ipt.negative){
		//	window.alert ("请输入正确的数字！");
		//	ipt.select ();
		//	return false;
		//}
		/*
		if(parseFloat(v)==0 && !ipt.zero){
			window.alert ("请输入正确的数字！");
			ipt.select ();
			return false;
		}
		*/
		if (v==Infinity){
			window.alert ("请输入正确的数字！");
			ipt.select ();
			return false;
		}
		if(len)
			ipt.value=FormatNumber(v,len);
		else
			ipt.value=v;
	}
	return false;
}

function delZero(str){
	var str=new String(str);
	var tStr=parseFloat(str);
	var mStr,i
	var n=str.length;
	if (Math.floor(str)==0 || Math.ceil(str)==0){
		mStr=str.substring(str.indexOf(".")-1,n);
	}else{
		for(i=0;i<n;i++){
			if (parseInt(str.charAt(i))>0) break
		}
		mStr=str.substring(i,n)
	}
	if(tStr<0) 
		mStr="-"+mStr;
	return mStr;
}

function IsNum(num){
	var patten=/^[-]?\d+\.?\d*$/;
	return patten.test(num);
}

function FormatNumber(num,len){
//将num按小数位为len来进行格式化默认为2位小数点
	var dot=0
	var num1=0
	var i=0,nb=1,ndot=0
	if (typeof(len)=="undefined" || len==null || isNaN(parseInt(len))) 
		dot=2
	else
		dot=parseInt(len)
	
	if (isNaN(parseFloat(num)))
		return 0
	else
		num1=parseFloat(num)
		
	nb=Math.pow(10,dot)

	if (nb==1){ 
		var iValue= (num1);
		return iValue;
	}else{
		var iValue=(Math.round(num1*nb))/nb
	}
	var sValue = iValue.toString();
	if (sValue.indexOf(".") == -1)
	{
		sValue = sValue + ".";
		for(i=1;i<=dot;i++){
			sValue +="0"
		}
	}
	else
	{	
		ndot=sValue.length-sValue.indexOf(".")-1
		if (ndot < dot){
			for(i=ndot;i<dot;i++){
				sValue += "0"
			}
		}
	}
	return sValue
}
function tmpFormatNumber(num,len){
//将num按小数位为len来进行格式化默认为2位小数点
	var dot=0
	var num1=0
	var i=0,nb=1,ndot=0
	if (typeof(len)=="undefined" || len==null || isNaN(parseInt(len))) 
		dot=2
	else
		dot=parseInt(len)
	
	if (isNaN(parseFloat(num)))
		return 0
	else
		num1=parseFloat(num)
		
	nb=Math.pow(10,dot)

	if (nb==1){ 
		var iValue= (num1);
		return iValue;
	}else{
		var iValue=(num1*nb)/nb
	}
	var sValue = iValue.toString();
	if (sValue.indexOf(".") == -1)
	{
		sValue = sValue + ".";
		for(i=1;i<=dot;i++){
			sValue +="0"
		}
	}
	else
	{	
		ndot=sValue.length-sValue.indexOf(".")-1
		if (ndot < dot){
			for(i=ndot;i<dot;i++){
				sValue += "0"
			}
		}
	}
	return sValue
}

function Disabled(){
	for(var i=0;i<arguments.length;i++){
		document.all(arguments[i]).disabled=true;
	}
}

function doKeyWown(){
	var element=window.event.srcElement;
	var eleTag=new String(element.tagName);
	eleTag=eleTag.toUpperCase();
	var eleType=new String(element.type)
	eleType=eleType.toUpperCase();
	var key=window.event.keyCode;
	switch(key){
		case 8://退格
			if(!(eleTag=="INPUT" || eleTag=="TEXTAREA")) window.event.returnValue =false;
			break;
		case 13://回车
			if(eleTag=="SELECT" || eleType=="TEXT")	window.event.keyCode=9 ;
			break;
		case 27://ESC
			window.event.returnValue =false;
			break;
		case 222://单引号
			if(!window.event.shiftKey) window.event.returnValue=false;
			break;
	}
	doKeyUp();
}

function doKeyUp(){
	return;
	var element=window.event.srcElement;
	var eleTag=new String(element.tagName);
	eleTag=eleTag.toUpperCase();
	var eleType=new String(element.type)
	eleType=eleType.toUpperCase();
	var key=window.event.keyCode;
	switch(key){
		case 37://左
			if(eleType=="TEXT" || eleTag=="SELECT") MoveLeft(element);
			break;
		case 38://上
			if(eleType=="TEXT") MoveUp(element);
			break;
		case 39://右
			if(eleType=="TEXT" || eleTag=="SELECT") MoveRight(element);
			break;
		case 40://下
			if(eleType=="TEXT") MoveDown(element);
			break;
	}
}

function CheckObject(obj){
	for(var i=0;i<obj.length;i++){
		if(obj[i].tagName=="INPUT" && obj[i].style.display!="none"){
			obj[i].focus();
			obj[i].select();
			return true;
		}else if(obj[i].tagName=="SELECT" && obj[i].style.display!="none"){
			obj[i].focus();
			return true;
		}
	}

}

function MoveLeft(element){
	var T=getItem(element,"tagName","TABLE");
	var R=getItem(element,"tagName","TR");
	var D=getItem(element,"tagName","TD");
	var DI=D.cellIndex;
	var RI=R.rowIndex;
	for(j=DI-1;j>=0;j--){
		if(CheckObject(R.cells(j).children)) break;
	}
}

function MoveUp(element){
	var T=getItem(element,"tagName","TABLE");
	var R=getItem(element,"tagName","TR");
	var D=getItem(element,"tagName","TD");
	var DI=D.cellIndex;
	var RI=R.rowIndex;
	for(j=RI-1;j>=0;j--){
		if(CheckObject(T.rows(j).cells(DI).children)) break;
	}
}

function MoveRight(element){
	var T=getItem(element,"tagName","TABLE");
	var R=getItem(element,"tagName","TR");
	var D=getItem(element,"tagName","TD");
	var DI=D.cellIndex;
	var RI=R.rowIndex;
	for(j=DI+1;j<R.cells.length;j++){
		if(CheckObject(R.cells(j).children)) break;
	}
}

function MoveDown(element){
	var T=getItem(element,"tagName","TABLE");
	var R=getItem(element,"tagName","TR");
	var D=getItem(element,"tagName","TD");
	var DI=D.cellIndex;
	var RI=R.rowIndex;
	for(j=RI+1;j<T.rows.length;j++){
		if(CheckObject(T.rows(j).cells(DI).children)) break;
	}
}

function CheckNull(obj,desc){
	if(obj.value=="" || (obj.className=="number" && obj.value=="0") || (obj.tagName=="SELECT" && (obj.value=="-1" || obj.value=="0"))){
		Warn(obj,desc);
		return false;
	}else{
		return true;
	}
}   

function Warn(obj,desc){
	if(obj.tagName=="SELECT"){
		alert("请在标有'*'框中选择正确值!");
		obj.focus();
	}else{
		alert("请在标有'*'框中输入正确值!");
		obj.select();
	}
}
	
function CheckForm(formObj){
	for(var i=0;i<formObj.length;i++){
		if((formObj[i].nextSibling!=null && typeof(formObj[i].nextSibling)=="object" && formObj[i].nextSibling.tagName=="FONT" && typeof(formObj[i].nextSibling.innerText)=='string' && formObj[i].nextSibling.innerText.indexOf("*")!=-1)||(formObj[i].nextSibling!=null && formObj[i].nextSibling.nextSibling!=null && typeof(formObj[i].nextSibling.nextSibling)=="object" && formObj[i].nextSibling.nextSibling.tagName=="FONT" && typeof(formObj[i].nextSibling.nextSibling.innerText)=='string' && formObj[i].nextSibling.nextSibling.innerText.indexOf("*")!=-1)){
			if(!CheckNull(formObj[i])){
				return false;
			} 
		}
	}
	return true
}

function doPaste(){
	window.event.returnValue=false;
}

function doMenu(){
	var v=new String(window.event.srcElement.tagName)
	v=v.toUpperCase()
	if (v!="INPUT"&&v!="TEXTAREA")
		window.event.returnValue =false
}

//window.document.onpaste=doPaste;
document.onkeydown=doKeyWown;
//document.onkeyup=doKeyUp;
//window.document.oncontextmenu=doMenu;

function timeToMinute(tim){
	if (!tim=="")
	{
		var tims=String(tim).split(':');
		var val=0;
		for(var i=0;i<tims.length;i++)
		{
			switch(i)
			{
				case 0:val+=parseInt(tims[i])*60;break;
				case 1:val+=parseInt(tims[i]);break;
				case 2:val+=parseInt(tims[i])/60.0;break;
			}
		}
		return val;
	}
	else
		return;

}
function minuteToTime(val){
	if (val>=0)
	{
		var v=parseFloat(val);
		var tim="";
		tim=new String(parseInt(v/60));
		tim+=':'+String(100+parseInt(v-parseInt(v/60)*60)).substr(1,2);
		tim+=':'+String(100+parseInt((v-parseInt(v)) * 60)).substr(1,2);
		return tim;
	}
	else
		return;
}