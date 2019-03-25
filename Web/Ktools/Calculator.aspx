<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calculator.aspx.cs" Inherits="Web_Ktools_DefaultCalendaCalculatorr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title></title>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">



    <div id="ssdd" style="padding: 1px"></div>
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td width="150" background="../../images/ktxt1.gif" style="background-color: #F5F5F5; height: 28px; width: 130px; padding-left: 20px;">
                <div class="TP2">科学计算器</div>
            </td>
            <td background="../../images/ktxt2.gif">&nbsp;</td>
            <td background="../../images/ktxt2.gif">&nbsp;</td>
        </tr>
    </table>

    <div id="Div1" style="padding: 1px"></div>


    <script type="text/javascript">
var TwoLevel_nCnt = 100;
function TwoLevel_IESetup() {
  var aTmp2, i, j, oLI, oTmp;
  var aTmp = xGetElementsByClassName("twolevel", document, "ul");
  if (aTmp.length) {
    for (i=0;i<aTmp.length;i++) {
      aTmp2 = aTmp[i].getElementsByTagName("li");
      for (j=0;j<aTmp2.length;j++) {
        oLI = aTmp2[j];
        if (oTmp = oLI.getElementsByTagName("ul")) {
          oLI.UL = oTmp[0];
          oLI.onmouseenter = function() {
            this.className += " twolevelhover";
          };
          oLI.onmouseleave = function() {
            this.className = this.className.replace(/twolevelhover/,"");
          };
        }
      }
    }
  } else if (TwoLevel_nCnt < 2000) {
    setTimeout("TwoLevel_IESetup()", TwoLevel_nCnt);
    TwoLevel_nCnt *= 2.5;
    TwoLevel_nCnt = parseInt(TwoLevel_nCnt, 10);
  }
}
var TwoLevel_proto = "javascript:void(0)";
if (location.protocol == "https:") TwoLevel_proto = "src=//0";
document.write("<scr"+"ipt id=__ie_onload defer " + TwoLevel_proto + "><\/scr"+"ipt>");
var TwoLevel_script = document.getElementById("__ie_onload");
TwoLevel_script.onreadystatechange = function() {
  if (this.readyState == "complete") {
    TwoLevel_IESetup();
  }
};
function xGetElementsByClassName(clsName, parentEle, tagName) {
  var elements = null;
  var found = new Array();
  var re = new RegExp('\\b'+clsName+'\\b');
  if (!parentEle) parentEle = document;
  if (!tagName) tagName = '*';
  if (parentEle.getElementsByTagName) {elements = parentEle.getElementsByTagName(tagName);}
  else if (document.all) {elements = document.all.tags(tagName);}
  if (elements) {
    for (var i = 0; i < elements.length; ++i) {
      if (elements[i].className.search(re) != -1) {
        found[found.length] = elements[i];
      }
    }
  }
  return found;
}
    </script>



    <script language="javascript">
<!--
var endNumber=true
var mem=0
var carry=10
var hexnum="0123456789abcdef"
var angle="d"
var stack=""
var level="0"
var layer=0


//数字键

function inputkey(key)
{
var index=key.charCodeAt(0);
if ((carry==2 && (index==48 || index==49))
|| (carry==8 && index>=48 && index<=55)
|| (carry==10 && (index>=48 && index<=57 || index==46))
|| (carry==16 && ((index>=48 && index<=57) || (index>=97 && index<=102))))
if(endNumber)
{
endNumber=false
document.calc.display.value = key
}
else if(document.calc.display.value == null || document.calc.display.value == "0")
document.calc.display.value = key
else
document.calc.display.value += key
}

function changeSign()
{
if (document.calc.display.value!="0")
if(document.calc.display.value.substr(0,1) == "-")
document.calc.display.value = document.calc.display.value.substr(1)
else
document.calc.display.value = "-" + document.calc.display.value
}

//函数键

function inputfunction(fun,shiftfun)
{
endNumber=true
if (document.calc.shiftf.checked)
document.calc.display.value=decto(funcalc(shiftfun,(todec(document.calc.display.value,carry))),carry)
else
document.calc.display.value=decto(funcalc(fun,(todec(document.calc.display.value,carry))),carry)
document.calc.shiftf.checked=false
document.calc.hypf.checked=false
inputshift()
}

function inputtrig(trig,arctrig,hyp,archyp)
{
if (document.calc.hypf.checked)
inputfunction(hyp,archyp)
else
inputfunction(trig,arctrig)
}


//运算符

function operation(join,newlevel)
{
endNumber=true
var temp=stack.substr(stack.lastIndexOf("(")+1)+document.calc.display.value
while (newlevel!=0 && (newlevel<=(level.charAt(level.length-1))))
{
temp=parse(temp)
level=level.slice(0,-1)
}
if (temp.match(/^(.*\d[\+\-\*\/\%\^\&\|x])?([+-]?[0-9a-f\.]+)$/))
document.calc.display.value=RegExp.$2
stack=stack.substr(0,stack.lastIndexOf("(")+1)+temp+join
document.calc.operator.value=" "+join+" "
level=level+newlevel

}

//括号

function addbracket()
{
endNumber=true
document.calc.display.value=0
stack=stack+"("
document.calc.operator.value="   "
level=level+0

layer+=1
document.calc.bracket.value="(="+layer
}

function disbracket()
{
endNumber=true
var temp=stack.substr(stack.lastIndexOf("(")+1)+document.calc.display.value
while ((level.charAt(level.length-1))>0)
{
temp=parse(temp)
level=level.slice(0,-1)
}

document.calc.display.value=temp
stack=stack.substr(0,stack.lastIndexOf("("))
document.calc.operator.value="   "
level=level.slice(0,-1)

layer-=1
if (layer>0)
document.calc.bracket.value="(="+layer
else
document.calc.bracket.value=""
}

//等号

function result()
{
endNumber=true
while (layer>0)
disbracket()
var temp=stack+document.calc.display.value
while ((level.charAt(level.length-1))>0)
{
temp=parse(temp)
level=level.slice(0,-1)
}

document.calc.display.value=temp
document.calc.bracket.value=""
document.calc.operator.value=""
stack=""
level="0"
}


//修改键

function backspace()
{
if (!endNumber)
{
if(document.calc.display.value.length>1)
document.calc.display.value=document.calc.display.value.substring(0,document.calc.display.value.length - 1)
else
document.calc.display.value=0
}
}

function clearall()
{
document.calc.display.value=0
endNumber=true
stack=""
level="0"
layer=""
document.calc.operator.value=""
document.calc.bracket.value=""
}


//转换键

function inputChangCarry(newcarry)
{
endNumber=true
document.calc.display.value=(decto(todec(document.calc.display.value,carry),newcarry))
carry=newcarry

document.calc.sin.disabled=(carry!=10)
document.calc.cos.disabled=(carry!=10)
document.calc.tan.disabled=(carry!=10)
document.calc.bt.disabled=(carry!=10)
document.calc.pi.disabled=(carry!=10)
document.calc.e.disabled=(carry!=10)
document.calc.kp.disabled=(carry!=10)

document.calc.k2.disabled=(carry<=2)
document.calc.k3.disabled=(carry<=2)
document.calc.k4.disabled=(carry<=2)
document.calc.k5.disabled=(carry<=2)
document.calc.k6.disabled=(carry<=2)
document.calc.k7.disabled=(carry<=2)
document.calc.k8.disabled=(carry<=8)
document.calc.k9.disabled=(carry<=8)
document.calc.ka.disabled=(carry<=10)
document.calc.kb.disabled=(carry<=10)
document.calc.kc.disabled=(carry<=10)
document.calc.kd.disabled=(carry<=10)
document.calc.ke.disabled=(carry<=10)
document.calc.kf.disabled=(carry<=10)



}

function inputChangAngle(angletype)
{
endNumber=true
angle=angletype
if (angle=="d")
document.calc.display.value=radiansToDegress(document.calc.display.value)
else
document.calc.display.value=degressToRadians(document.calc.display.value)
endNumber=true
}

function inputshift()
{
if (document.calc.shiftf.checked)
{
document.calc.bt.value="deg "
document.calc.ln.value="exp "
document.calc.log.value="expd"

if (document.calc.hypf.checked)
{
document.calc.sin.value="ahs "
document.calc.cos.value="ahc "
document.calc.tan.value="aht "
}
else
{
document.calc.sin.value="asin"
document.calc.cos.value="acos"
document.calc.tan.value="atan"
}

document.calc.sqr.value="x^.5"
document.calc.cube.value="x^.3"

document.calc.floor.value="小数"
}
else
{
document.calc.bt.value="d.ms"
document.calc.ln.value=" ln "
document.calc.log.value="log "

if (document.calc.hypf.checked)
{
document.calc.sin.value="hsin"
document.calc.cos.value="hcos"
document.calc.tan.value="htan"
}
else
{
document.calc.sin.value="sin "
document.calc.cos.value="cos "
document.calc.tan.value="tan "
}

document.calc.sqr.value="x^2 "
document.calc.cube.value="x^3 "

document.calc.floor.value="取整"
}

}
//存储器部分

function clearmemory()
{
mem=0
document.calc.memory.value="   "
}

function getmemory()
{
endNumber=true
document.calc.display.value=decto(mem,carry)
}

function putmemory()
{
endNumber=true
if (document.calc.display.value!=0)
{
mem=todec(document.calc.display.value,carry)
document.calc.memory.value=" M "
}
else
document.calc.memory.value="   "
}

function addmemory()
{
endNumber=true
mem=parseFloat(mem)+parseFloat(todec(document.calc.display.value,carry))
if (mem==0)
document.calc.memory.value="   "
else
document.calc.memory.value=" M "
}

function multimemory()
{
endNumber=true
mem=parseFloat(mem)*parseFloat(todec(document.calc.display.value,carry))
if (mem==0)
document.calc.memory.value="   "
else
document.calc.memory.value=" M "
}

//十进制转换

function todec(num,oldcarry)
{
if (oldcarry==10 || num==0) return(num)
var neg=(num.charAt(0)=="-")
if (neg) num=num.substr(1)
var newnum=0
for (var index=1;index<=num.length;index++)
newnum=newnum*oldcarry+hexnum.indexOf(num.charAt(index-1))
if (neg)
newnum=-newnum
return(newnum)
}

function decto(num,newcarry)
{
var neg=(num<0)
if (newcarry==10 || num==0) return(num)
num=""+Math.abs(num)
var newnum=""
while (num!=0)
{
newnum=hexnum.charAt(num%newcarry)+newnum
num=Math.floor(num/newcarry)
}
if (neg)
newnum="-"+newnum
return(newnum)
}

//表达式解析

function parse(string)
{
if (string.match(/^(.*\d[\+\-\*\/\%\^\&\|x\<])?([+-]?[0-9a-f\.]+)([\+\-\*\/\%\^\&\|x\<])([+-]?[0-9a-f\.]+)$/))
return(RegExp.$1+cypher(RegExp.$2,RegExp.$3,RegExp.$4))
else
return(string)
}

//数学运算和位运算

function cypher(left,join,right)
{
left=todec(left,carry)
right=todec(right,carry)
if (join=="+")
return(decto(parseFloat(left)+parseFloat(right),carry))
if (join=="-")
return(decto(left-right,carry))
if (join=="*")
return(decto(left*right,carry))
if (join=="/" && right!=0)
return(decto(left/right,carry))
if (join=="%")
return(decto(left%right,carry))
if (join=="&")
return(decto(left&right,carry))
if (join=="|")
return(decto(left|right,carry))
if (join=="^")
return(decto(Math.pow(left,right),carry))
if (join=="x")
return(decto(left^right,carry))
if (join=="<")
return(decto(left<<right,carry))
alert("除数不能为零")
return(left)
}

//函数计算

function funcalc(fun,num)
{
with(Math)
{
if (fun=="pi")
return(PI)
if (fun=="e")
return(E)

if (fun=="abs")
return(abs(num))
if (fun=="ceil")
return(ceil(num))
if (fun=="round")
return(round(num))

if (fun=="floor")
return(floor(num))
if (fun=="deci")
return(num-floor(num))


if (fun=="ln" && num>0)
return(log(num))
if (fun=="exp")
return(exp(num))
if (fun=="log" && num>0)
return(log(num)*LOG10E)
if (fun=="expdec")
return(pow(10,num))


if (fun=="cube")
return(num*num*num)
if (fun=="cubt")
return(pow(num,1/3))
if (fun=="sqr")
return(num*num)
if (fun=="sqrt" && num>=0)
return(sqrt(num))

if (fun=="!")
return(factorial(num))

if (fun=="recip" && num!=0)
return(1/num)

if (fun=="dms")
return(dms(num))
if (fun=="deg")
return(deg(num))

if (fun=="~")
return(~num)

if (angle=="d")
{
if (fun=="sin")
return(sin(degressToRadians(num)))
if (fun=="cos")
return(cos(degressToRadians(num)))
if (fun=="tan")
return(tan(degressToRadians(num)))

if (fun=="arcsin" && abs(num)<=1)
return(radiansToDegress(asin(num)))
if (fun=="arccos" && abs(num)<=1)
return(radiansToDegress(acos(num)))
if (fun=="arctan")
return(radiansToDegress(atan(num)))
}
else
{
if (fun=="sin")
return(sin(num))
if (fun=="cos")
return(cos(num))
if (fun=="tan")
return(tan(num))

if (fun=="arcsin" && abs(num)<=1)
return(asin(num))
if (fun=="arccos" && abs(num)<=1)
return(acos(num))
if (fun=="arctan")
return(atan(num))
}

if (fun=="hypsin")
return((exp(num)-exp(0-num))*0.5)
if (fun=="hypcos")
return((exp(num)+exp(-num))*0.5)
if (fun=="hyptan")
return((exp(num)-exp(-num))/(exp(num)+exp(-num)))

if (fun=="ahypsin" | fun=="hypcos" | fun=="hyptan")
{
alert("对不起,公式还没有查到!")
return(num)
}

alert("超出函数定义范围")
return(num)
}
}

function factorial(n)
{
n=Math.abs(parseInt(n))
var fac=1
for (;n>0;n-=1)
fac*=n
return(fac)
}

function dms(n)
{
var neg=(n<0)
with(Math)
{
n=abs(n)
var d=floor(n)
var m=floor(60*(n-d))
var s=(n-d)*60-m
}
var dms=d+m/100+s*0.006
if (neg)
dms=-dms
return(dms)
}

function deg(n)
{
var neg=(n<0)
with(Math)
{
n=abs(n)
var d=floor(n)
var m=floor((n-d)*100)
var s=(n-d)*100-m
}
var deg=d+m/60+s/36
if (neg)
deg=-deg
return(deg)
}

function degressToRadians(degress)
{
return(degress*Math.PI/180)
}

function radiansToDegress(radians)
{
return(radians*180/Math.PI)
}

//界面

//-->
    </script>

    <div id="contain">
        <div id="mainbg">
            <div id="right">
                <div id="ads">
                    <script type="text/javascript"> 
var arrBaiduCproConfig=new Array(); 
arrBaiduCproConfig['uid'] =108720;
arrBaiduCproConfig['n'] ='123chacomcpr';
arrBaiduCproConfig['tm'] =22;
arrBaiduCproConfig['cm'] =46;
arrBaiduCproConfig['um'] =22;
arrBaiduCproConfig['w'] =160;
arrBaiduCproConfig['h'] = 360;
arrBaiduCproConfig['wn'] =1;
arrBaiduCproConfig['hn'] =5;
arrBaiduCproConfig['ta'] ='right';
arrBaiduCproConfig['tl'] ='bottom';
arrBaiduCproConfig['bu'] =0;
arrBaiduCproConfig['bd'] ='#trans';
arrBaiduCproConfig['bg'] ='#trans';
arrBaiduCproConfig['tt'] ='#0000ff';
arrBaiduCproConfig['ct'] ='#444444';
arrBaiduCproConfig['url'] ='#008000';
arrBaiduCproConfig['bdl'] ='#ffffff';
arrBaiduCproConfig['rad'] =1;
                    </script>
                </div>
            </div>
            <div id="center">
                <form name="calc">
                    <table class="tb" cellspacing="1" bordercolordark="#ffffff" cellpadding="2" width="500"
                        align="center" bgcolor="#cccccc" border="0">
                        <tbody>
                            <tr bgcolor="#C6CBDE">
                                <td align="center" style="height: 24px"><strong>实用计算器</strong></td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#f6f6f6" height="40">
                                    <table class="tb" height="40" width="500">
                                        <tbody>
                                            <tr>
                                                <td align="center" width="500">
                                                    <input readonly size="67" value="0"
                                                        name="display" class="Boxx">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#ecf4ec">
                                    <table class="tb" width="500">
                                        <tbody>
                                            <tr>
                                                <td width="320">
                                                    <input onclick="inputChangCarry(16)" type="radio"
                                                        name="carry">
                                                    十六进制
                                                    <input onclick="inputChangCarry(10)" type="radio"
                                                        checked name="carry">
                                                    十进制
                                                    <input onclick="inputChangCarry(8)" type="radio"
                                                        name="carry">
                                                    八进制
                                                    <input onclick="inputChangCarry(2)" type="radio"
                                                        name="carry">
                                                    二进制 </td>
                                                <td width="30"></td>
                                                <td width="150">
                                                    <input onclick="inputChangAngle('d')" type="radio"
                                                        checked value="d" name="angle">
                                                    角度制
                                                    <input
                                                        onclick="inputChangAngle('r')" type="radio" value="r" name="angle">
                                                    弧度制 
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="tb" width="500">
                                        <tbody>
                                            <tr>
                                                <td width="175">
                                                    <input onclick="inputshift()" type="checkbox" value="ON"
                                                        name="shiftf">上档功能
                                                    <input onclick="inputshift()" type="checkbox" value="ON"
                                                        name="hypf">双曲函数 </td>
                                                <td>
                                                    <input style="background-color: lightgrey" readonly size="3"
                                                        name="bracket">
                                                    <input style="background-color: lightgrey" readonly
                                                        size="3" name="memory">
                                                    <input style="background-color: lightgrey"
                                                        readonly size="3" name="operator">
                                                </td>
                                                <td width="183">
                                                    <input style="color: red" onclick="backspace()" type="button" value=" 退格 " class="Btt">
                                                    <input style="color: red" onclick="document.calc.display.value = 0 " type="button" value=" 清屏 " class="Btt">
                                                    <input style="color: red" onclick="clearall()" type="button" value=" 全清" class="Btt">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="tb" width="500">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <table class="tb">
                                                        <tbody>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: blue" onclick="inputfunction('pi','pi')" type="button" value=" PI " name="pi" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputfunction('e','e')" type="button" value=" E  " name="e" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputfunction('dms','deg')" type="button" value="d.ms" name="bt" class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="addbracket()" type="button" value=" (  " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="disbracket()" type="button" value=" )  " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputfunction('ln','exp')" type="button" value=" ln " name="ln" class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputtrig('sin','arcsin','hypsin','ahypsin')" type="button" value="sin " name="sin" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="operation('^',7)" type="button" value="x^y " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputfunction('log','expdec')" type="button" value="log " name="log" class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputtrig('cos','arccos','hypcos','ahypcos')" type="button" value="cos " name="cos" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputfunction('cube','cubt')" type="button" value="x^3 " name="cube" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputfunction('!','!')" type="button" value=" n! " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputtrig('tan','arctan','hyptan','ahyptan')" type="button" value="tan " name="tan" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputfunction('sqr','sqrt')" type="button" value="x^2 " name="sqr" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: #ff00ff" onclick="inputfunction('recip','recip')" type="button" value="1/x " class="Btt">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                                <td width="30"></td>
                                                <td>
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <input style="color: blue" onclick="putmemory()" type="button" value=" 储存 " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input style="color: blue" onclick="getmemory()" type="button" value=" 取存 " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input style="color: blue" onclick="addmemory()" type="button" value=" 累存 " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <input style="color: blue" onclick="multimemory()" type="button" value=" 积存 " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="33">
                                                                    <input style="color: blue" onclick="clearmemory()" type="button" value=" 清存 " class="Btt">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                                <td width="30"></td>
                                                <td>
                                                    <table>
                                                        <tbody>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('7')" type="button" value=" 7 " name="k7" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('8')" type="button" value=" 8 " name="k8" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('9')" type="button" value=" 9 " name="k9" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('/',6)" type="button" value=" / " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('%',6)" type="button" value="取余" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('&amp;',3)" type="button" value=" 与 " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('4')" type="button" value=" 4 " name="k4" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('5')" type="button" value=" 5 " name="k5" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('6')" type="button" value=" 6 " name="k6" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('*',6)" type="button" value=" * " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputfunction('floor','deci')" type="button" value="取整" name="floor" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('|',1)" type="button" value=" 或 " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('1')" type="button" value=" 1 " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('2')" type="button" value=" 2 " name="k2" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('3')" type="button" value=" 3 " name="k3" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('-',5)" type="button" value=" - " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('<',4)" type="button" value="左移" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputfunction('~','~')" type="button" value=" 非 " class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('0')" type="button" value=" 0 " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="changeSign()" type="button" value="+/-" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="inputkey('.')" type="button" value=" . " name="kp" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('+',5)" type="button" value=" + " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="result()" type="button" value=" ＝ " class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" onclick="operation('x',2)" type="button" value="异或" class="Btt">
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <input style="color: blue" disabled onclick="inputkey('a')" type="button" value=" A " name="ka" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" disabled onclick="inputkey('b')" type="button" value=" B " name="kb" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" disabled onclick="inputkey('c')" type="button" value=" C " name="kc" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" disabled onclick="inputkey('d')" type="button" value=" D " name="kd" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" disabled onclick="inputkey('e')" type="button" value=" E" name="ke" class="Btt">
                                                                </td>
                                                                <td>
                                                                    <input style="color: blue" disabled onclick="inputkey('f')" type="button" value=" F" name="kf" class="Btt">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </form>
                <div>

                    <script type="text/javascript"> 
function copyText(obj) 
{ 
var rng = document.body.createTextRange(); 
rng.moveToElementText(obj); 
rng.scrollIntoView(); 
rng.select(); 
rng.execCommand("Copy"); 
rng.collapse(false);} 
                    </script>

                </div>
            </div>
        </div>
    </div>


    <!--底部功能栏-->
    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
        <tr>
            <td height="30">&nbsp;</td>
        </tr>
    </table>
    <!--底部功能栏-->


</body>
</html>
