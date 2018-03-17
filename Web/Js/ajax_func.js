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
		window.alert("���ܴ���XMLHttpRequest����ʵ����");
		return false;
	}
	if(responseType.toLowerCase()=="text"){
		http_request.onreadystatechange=callback;
	}else{
		
		window.alert("��Ӧ����������");
		return false;
	}
	if(method.toLowerCase()=="get"){
		http_request.open(method,url,true);
	}
	else if(method.toLowerCase()=="post"){
		http_request.open(method,url,true);
http_request.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
	}else{
		window.alert("http��������������");
		return false;
	}
	http_request.send(content);
}
function processTextResponse(){
	if(http_request.readyState==4){
		if(http_request.status==200){
			alert("Text�ĵ���Ӧ");
		}else{
			//alert("���������ҳ�����쳣��");
		}
	}
}
function processXMLResponse(){
	if(http_request.readyState==4){
		if(http_request.status==200){
			alert("XML�ĵ���Ӧ");
		}else{
			//alert("���������ҳ�����쳣��");
		}
	}
}