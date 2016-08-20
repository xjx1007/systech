function setActiveBG(obj){
	objArr =document.getElementsByTagName("tr");
	for(i=0;i<objArr.length;i++){
		if(objArr[i].style.backgroundColor !=""){
			objArr[i].style.backgroundColor="";
		}
	}
	obj.style.backgroundColor="#FFE5C7";
}