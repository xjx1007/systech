var startDate;
var datemenus;

function setDateMenuSelected(i){
	datemenus = radioSelect('menu'+i);
	if(datemenus == 'day'){
		getTheDayDate(myDate);
		updatePageInfo();
	}else if(datemenus == 'week'){
		getTheWeekDate(myDate);
		updatePageInfo();
	}else if(datemenus == 'month'){
		getTheMonthDate(myDate.getFullYear(),myDate.getMonth());
		updatePageInfo();
	}else if(datemenus == 'quarter'){
		getTheQuarterDate(myDate.getFullYear(),myDate.getMonth());
		updatePageInfo();
	}
}

//选择日期
function setDate(){
	var date = $$('DailylogsDayH1').innerHTML;
	var arrDate = date.split("-");  
	uexControl.openDatePicker(arrDate[0],arrDate[1],arrDate[2]);
}
//获取完整格式的月份/日期
function getFullFormat(num){
	if(num < 10){  
        num = "0" + num;  
    }   
	return num;
}

//格式化日期：yyyy-MM-dd  xyyan
function formatDate(date) {   
    var myyear = date.getFullYear();  
    var mymonth = date.getMonth()+1;  
    var myweekday = date.getDate();   
      
    if(mymonth < 10){  
        mymonth = "0" + mymonth;  
    }   
    if(myweekday < 10){  
        myweekday = "0" + myweekday;  
    }  
    return (myyear+"-"+mymonth + "-" + myweekday);   
}    

//修改日期时执行
function changeDate(opCode,dataType,data){
	if(dataType==1){
		var obj = eval('('+data+')');
		var day1 = new Date(myDate.getFullYear(),myDate.getMonth()+1,myDate.getDate());
		var time1 = day1.getTime(); // 当前日期时间戳
		var day2 = new Date(obj.year,obj.month,obj.day);
		var time2 = day2.getTime();//所选日期时间戳
		if(parseInt(time2) > parseInt(time1)){
			return false;
		}
		var dailyLogsDate = obj.year+"-"+getFullFormat(obj.month)+"-"+getFullFormat(obj.day);
		$$('DailylogsDayH1').innerHTML = dailyLogsDate;
		setstorage("dailyLogsDate",dailyLogsDate);
		updateFloatWinInfo();//更新浮动窗口信息
	}
}

//一个窗口有多个日期选择按钮时
function setDateMore(id){
	setstorage("theDateId",id);
	var date = $$(id).value;
	if(!date)
		date = $$(id).innerHTML;
	var arrDate = date.split("-"); 
	if(!arrDate || arrDate==""){
		var tmpdate = new Date();
		arrDate = [tmpdate.getFullYear(),tmpdate.getMonth()+1,tmpdate.getDate()];
	}
	uexControl.openDatePicker(arrDate[0],arrDate[1],arrDate[2]);
}


function changeDateMore(opCode,dataType,data){
	var id = getstorage("theDateId");
	if(dataType==1){
		var obj = eval('('+data+')');
		var theDate = obj.year+"-"+getFullFormat(obj.month)+"-"+getFullFormat(obj.day);
		$$(id).value = theDate;
		$$(id).innerHTML = theDate;
		if(!checkTime()){
			setNewDate(id);
		}
	}
}

//一个窗口有多个时间选择按钮时
function setTimeMore(id){
	setstorage("theTimeId",id);
	var time = $$(id).value;
	var arrTime = time.split(":"); 
	uexControl.openTimePicker(arrTime[0],arrTime[1]);
}

function changeTimeMore(opCode,dataType,data){
	var id = getstorage("theTimeId");
	if(dataType==1){
		var obj = eval('('+data+')');
		var theTime = getFullFormat(obj.hour)+":"+getFullFormat(obj.minute);
		$$(id).value = theTime;
		if(!checkTime()){
			setNewDate(id);
		}
	}
}

//根据日期时间获取下一小时的日期obj
function getNextHours(theDate,theTime){
	 var arrStartDate = theDate.split("-");   
     var arrStartTime = theTime.split(":");   
	 var allStartDate = new Date(arrStartDate[0],arrStartDate[1]-1,arrStartDate[2],arrStartTime[0],arrStartTime[1]);   
     var endDateTimes = allStartDate.getTime()+60*60*1000;
	 var endDate = new Date(endDateTimes);
	 return endDate;
}

//根据日期时间获取上一小时的日期obj
function getLastHours(theDate,theTime){
	 var arrEndDate = theDate.split("-");   
     var arrEndTime = theTime.split(":");   
	 var allEndDate = new Date(arrEndDate[0],arrEndDate[1]-1,arrEndDate[2],arrEndTime[0],arrEndTime[1]);   
     var startDateTimes = allEndDate.getTime()-60*60*1000;
	 var startDate = new Date(startDateTimes);
	 return startDate;
}

//获取上一日/周/月的信息
function getLast(){
	if(datemenus == 'day'){
		getLastDayDate(startDate);
	}else if(datemenus == 'week'){
		getLastWeekDate(startDate);
	}else if(datemenus == 'month'){
		getLastMonthDate(startDate);
	}else if(datemenus == 'quarter'){
		getLastQuarterDate(startDate);
	}else if(datemenus == 'year'){
		getLastYearDate(startDate);
	}
	updatePageInfo();
}

//获取下一日/周/月的信息
function getNext(isCheck){
	if(datemenus == 'day'){
		if(!getNextDayDate(startDate,isCheck)){
			return false;
		}
	}else if(datemenus == 'week'){
		if(!getNextWeekDate(startDate,isCheck)){
			return false;
		}
	}else if(datemenus == 'month'){
		if(!getNextMonthDate(startDate,isCheck)){
			return false;
		}
	}else if(datemenus == 'quarter'){
		if(!getNextQuarterDate(startDate,isCheck)){
			return false;
		}
	}else if(datemenus == 'year'){
		if(!getNextYearDate(startDate,isCheck)){
			return false;
		}
	}
	updatePageInfo();
}

// 设置日期
function getTheDayDate(date){
	startDate = date;
 	setstorage("startDate",formatDate(startDate));
	setstorage("endDate",formatDate(startDate));
}

//获得指定日期上一日
function getLastDayDate(date){
	var yesterday = new Date(date.getTime()-24*60*60*1000);  //上一日
	getTheDayDate(yesterday);
}
 
//获得指定日期下一日
function getNextDayDate(date,isCheck){
	var tomorrow = new Date(date.getTime()+24*60*60*1000);  //下一日
	if (isCheck) {
		var time1 = myDate.getTime(); // 当前日期时间戳
		var time2 = tomorrow.getTime();
		if (parseInt(time2) > parseInt(time1)) {
			return false;
		}
	}
	getTheDayDate(tomorrow);
	return true;
}
//获得本周的周一和周末
function getTheWeekDate(date){
	var currentWeek = date.getDay();
	if(currentWeek == 0){
	   currentWeek = 7;
	}
	startDate = new Date(date.getTime()-(currentWeek-1)*24*60*60*1000);//星期一
	var weekEndDate = new Date(date.getTime()+(7-currentWeek)*24*60*60*1000);  //星期日
 	setstorage("startDate",formatDate(startDate));
	setstorage("endDate",formatDate(weekEndDate));
}

//获得指定日期上周的周一和周末
function getLastWeekDate(date){
	var lastWeekDay = new Date(date.getTime() - 7*24*60*60*1000);
	getTheWeekDate(lastWeekDay);
}
 
//获得指定日期下周的周一至周末
function getNextWeekDate(date,isCheck){
	var currentWeek = date.getDay();
	if(currentWeek == 0){
	   currentWeek = 7;
	}
	var time2 = date.getTime() - (currentWeek - 8) * 24 * 60 * 60 * 1000;
	if (isCheck) {
		var time1 = myDate.getTime(); // 当前日期时间戳
		if (parseInt(time2) > parseInt(time1)) {
			return false;
		}
	}
	var nextWeekDay = new Date(time2);
	getTheWeekDate(nextWeekDay);
	return true;
}

//获得某年某月的月初,月末
function getTheMonthDate(year,month){
	startDate = new Date(year,month, 1);
	var monthEndDate = new Date(startDate);
	monthEndDate.setMonth(startDate.getMonth()+1);
	monthEndDate.setDate(0);
	setstorage("startDate",formatDate(startDate));
	setstorage("endDate",formatDate(monthEndDate));
}

//获得指定日期上月的月初,月末
function getLastMonthDate(date){
	var month = date.getMonth()-1;
	var year = date.getFullYear();
	if(month == -1) {
        year = year-1;
        month = 11;
    }
	getTheMonthDate(year,month);
}
 
//获得指定日期下月的 月初,月末
function getNextMonthDate(date,isCheck){
	var month = date.getMonth()+1;
	var year = date.getFullYear();
	if(month == 12) {
        year = year+1;
        month = 0;
    }
	if (isCheck) {
		var newStartDate = new Date(year, month, 1);
		var time1 = myDate.getTime(); // 当前日期时间戳
		var time2 = newStartDate.getTime();
		if (parseInt(time2) > parseInt(time1)) {
			return false;
		}
	}
	getTheMonthDate(year,month);
	return true;
}

//获得本季度的开始月份     
function getQuarterStartMonth(nowMonth){     
    var quarterStartMonth = 0;     
    if(nowMonth<3){     
       quarterStartMonth = 0;     
    }     
    if(2<nowMonth && nowMonth<6){     
       quarterStartMonth = 3;     
    }     
    if(5<nowMonth && nowMonth<9){     
       quarterStartMonth = 6;     
    }     
    if(nowMonth>8){     
       quarterStartMonth = 9;     
    }     
    return quarterStartMonth;     
} 

//根据年份和月份获取季度的季初,季末
function getTheQuarterDate(year,month){
	var quarterStartMonth = getQuarterStartMonth(month);
	var quarterEndMonth = quarterStartMonth+2;
	startDate = new Date(year,quarterStartMonth, 1);
	var quarterEndDate  = new Date(year,quarterEndMonth, 1);
	quarterEndDate.setMonth(quarterEndDate.getMonth()+1);
	quarterEndDate.setDate(0);
	setstorage("startDate",formatDate(startDate));
	setstorage("endDate",formatDate(quarterEndDate)); 
}

//获得指定日期上 季度的季初,季末
function getLastQuarterDate(date){
	var month = date.getMonth()-1;
	var year = date.getFullYear();
	if(month == -1) {
        year = year-1;
        month = 11;
    }
	getTheQuarterDate(year,month);
}

//获得指定日期下 季度的季初,季末
function getNextQuarterDate(date,isCheck){
	var month = date.getMonth()+3;
	var year = date.getFullYear();
	if(month == 12) {
        year = year+1;
        month = 0;
    }
	if (isCheck) {
		var newStartDate = new Date(year, month, 1);
		var time1 = myDate.getTime(); // 当前日期时间戳
		var time2 = newStartDate.getTime();
		if (parseInt(time2) > parseInt(time1)) {
			return false;
		}
	}
	getTheQuarterDate(year,month);
	return true;
}

//根据年份获取年份的年初 、年末
function getTheYearDate(year){
	startDate = new Date(year,0, 1);
	var yearEndDate  = new Date(year,11, 1);
	yearEndDate.setMonth(yearEndDate.getMonth()+1);
	yearEndDate.setDate(0);
	setstorage("startDate",formatDate(startDate));
	setstorage("endDate",formatDate(yearEndDate)); 
}

//获得指定日期上年份的年初 、年末
function getLastYearDate(date){
	var year = date.getFullYear()-1;
	getTheYearDate(year);
}

//获得指定日期下 年份的年初 、年末
function getNextYearDate(date,isCheck){
	var year = date.getFullYear()+1;
	if (isCheck) {
		var newStartDate = new Date(year, 0, 1);
		var time1 = myDate.getTime(); // 当前日期时间戳
		var time2 = newStartDate.getTime();
		if (parseInt(time2) > parseInt(time1)) {
			return false;
		}
	}
	getTheYearDate(year);
	return true;
}
