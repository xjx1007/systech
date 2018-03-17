// JScript 文件
window.onload = function ()
{
   // $("#tableContainer").style.height = document.body.clientHeight * 0.83;
}
function setDisplay(objID, isShow)
{
    if(isShow == true)
    {
        objID.style.display = "block";
    }    
    else
    {
        objID.style.display = "none";
    }
}
function ShowObj(objID)
{
    setDisplay(objID, true);
}
function HideObj(objID)
{
    setDisplay(objID, false);
}
function initInput()
{
    $(".input_pack").click(function(event){
    var EID ="#" + event.target.id;
    $(EID).offsetParent().addClass("blurred");
    if($(EID).val() == "")
    {
        $(EID).offsetParent().removeClass("filled");
    }
    else
    {
        $(EID).offsetParent().addClass("filled");
    }
  });
  $(".input_pack").keyup(function(event){ 
    var EID ="#" + event.target.id;
    if($(EID).val() == "")
    {
        $(EID).offsetParent().removeClass("filled");
    }
    else
    {
        $(EID).offsetParent().addClass("filled");
    }
  });
  
}


function initInput1() {
    $(".input_pack1").click(function (event) {
        var EID = "#" + event.target.id;
        $(EID).offsetParent().addClass("blurred");
        if ($(EID).val() == "") {
            $(EID).offsetParent().removeClass("filled");
        }
        else {
            $(EID).offsetParent().addClass("filled");
        }
    });
    $(".input_pack1").keyup(function (event) {
        var EID = "#" + event.target.id;
        if ($(EID).val() == "") {
            $(EID).offsetParent().removeClass("filled");
        }
        else {
            $(EID).offsetParent().addClass("filled");
        }
    });

}
//**************************************************//
//全选按钮操作		
function selectAll(obj)
{
	var i,j=0;  
	var elements = document.getElementsByTagName("input");
	//alert(obj.value.replace(/\s+/g,""));
	if(obj.checked)
	{       
		for(i=0;i<elements.length;i++)
		{
			if(elements[i].type=="checkbox"&&elements[i].id.indexOf("Grid")>=0)  //只处理datagrid中的checkbox
			{		
			    if(elements[i].disabled==false)
			    {			    
				    elements[i].checked=true;		
				    j++;
				}							
			}				
		}
		if(j>0)
		{
			obj.nextSibling.nodeValue="消";
		}
	}
	else
	{
		for(i=0;i<elements.length;i++)
		{
			if(elements[i].type=="checkbox"&&elements[i].id.indexOf("Grid")>=0) 
			{					    
				elements[i].checked=false;	
				j++;									
			}								
		}
		if(j>0)
		{
			obj.nextSibling.nodeValue="选";
		}   
     }
}


function selectAllPage(obj) {
    var i, j = 0;
    var elements = document.getElementsByTagName("input");
    //alert(obj.value.replace(/\s+/g,""));
    if (obj.checked) {
        for (i = 0; i < elements.length; i++) {
            if (elements[i].type == "checkbox")  //只处理datagrid中的checkbox
            {
                if (elements[i].disabled == false) {
                    elements[i].checked = true;
                    j++;
                }
            }
        }
    }
    else {
        for (i = 0; i < elements.length; i++) {
            if (elements[i].type == "checkbox" ) {
                elements[i].checked = false;
                j++;
            }
        }
    }
}
function PageGo(url)
{
	window.location.href = url;
}

function PageOpen(url)
{
	window.open(url);
}

//**************************************************//
//全选按钮操作		
function selectAllButton(obj)
{
	var i,j=0;  
	var elements = document.getElementsByTagName("input");
	//alert(obj.value.replace(/\s+/g,""));
	if(obj.value.replace(/\s+/g,"")=="全选")
	{       
		for(i=0;i<elements.length;i++)
		{
			if(elements[i].type=="checkbox"&&((elements[i].id.indexOf("My")>=0)||(elements[i].id.indexOf("Gr")>=0)))  //只处理datagrid中的checkbox
			{		
			    if(elements[i].disabled==false)
			    {			    
				    elements[i].checked=true;		
				    j++;
				}							
			}				
		}
		if(j>0)
		{
			obj.value="全不选";
		}
	}
	else
	{
		for(i=0;i<elements.length;i++)
		{
			if(elements[i].type=="checkbox"&&((elements[i].id.indexOf("My")>=0)||(elements[i].id.indexOf("Gr")>=0))) 
			{					    
				elements[i].checked=false;	
				j++;									
			}								
		}
		if(j>0)
		{
			obj.value="全 选";
		}   
     }
}
	