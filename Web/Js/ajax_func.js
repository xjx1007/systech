var http_request = false;
function send_request(method,url,content,responseType,callback){
	http_request=false;
	if(window.XMLHttpRequest){
		http_request=new XMLHttpRequest();
		if(http_request.overrideMimeType){
			http_request.overrideMimeType("text/xml");
		}
	}
	else{
		try{
			http_request=new ActiveXObject("Msxml2.XMLHTTP");
		}catch(e){
			try{
				http_request=new ActiveXObject("Microsoft.XMLHTTP");
			}catch(e){}
		}
	}
	if(!http_request){
		window.alert("不能创建XMLHttpRequest对象实例。");
		return false;
	}
	if(responseType.toLowerCase()=="text"){
		http_request.onreadystatechange=callback;
	}else{
		
		window.alert("响应类别参数错误。");
		return false;
	}
	if(method.toLowerCase()=="get"){
		http_request.open(method,url,true);
	}
	else if(method.toLowerCase()=="post"){
		http_request.open(method,url,true);
http_request.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
	}else{
		window.alert("http请求类别参数错误。");
		return false;
	}
	http_request.send(content);
}
function processTextResponse(){
	if(http_request.readyState==4){
		if(http_request.status==200){
			alert("Text文档响应");
		}else{
			//alert("您所请求的页面有异常。");
		}
	}
}
function processXMLResponse(){
	if(http_request.readyState==4){
		if(http_request.status==200){
			alert("XML文档响应");
		}else{
			//alert("您所请求的页面有异常。");
		}
	}
}