
function keyDown()
{
	if(event.keyCode==13)
	{				
		if(event.srcElement.tagName.toLowerCase() == "textarea") 
		{
			event.keyCode==13
			return true;
		}
		event.keyCode=9;
		return true;
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
function PageClose()
{
	window.opener = null;
	window.close();
}


//**************************************************//
//全选按钮操作		
function selectAll(obj)
{
	var i,j=0;  
	var elements = document.getElementsByTagName("input");
	//alert(obj.value.replace(/\s+/g,""));
	if(obj.value.replace(/\s+/g,"")=="全选")
	{       
		for(i=0;i<elements.length;i++)
		{
			if(elements[i].type=="checkbox"&&elements[i].id.indexOf("Dag")>=0)  //只处理datagrid中的checkbox
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
			if(elements[i].type=="checkbox"&&elements[i].id.indexOf("Dag")>=0) 
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
	
//列表页面删除按钮判断操作
function CheckListDel()
{
	var tag = false;   
	var elements = document.getElementsByTagName("input");
	for(var i=0;i<elements.length;i++)
	{
	    if(elements[i].type=="checkbox"&&elements[i].id.indexOf("Dag")>=0) 
		{
			if(elements[i].checked)
			{ 
				tag = true;
				break;
			}		
		}  
	}  
	if(tag==true)
	{
		return window.confirm("是否删除所选记录?");
	}
	else
	{
		alert("你尚未选择任何记录!");
		return false;
	}      
}
//**************************************************//

//正文编辑按钮操作
function domouseover(id)
{
    if(document.getElementById(id).className=="tbButton")
    {
        document.getElementById(id).className="tbButtonMouseOverUp";
    }
    else
    {
        if(document.getElementById(id).className=="tbButtonDown")
        {
            document.getElementById(id).className="tbButtonMouseOverDown";
        }
    }
}
function domouseout(id)
{
    if(document.getElementById(id).className=="tbButtonMouseOverUp")
    {
        document.getElementById(id).className="tbButton";
    }
    else
    {
        if(document.getElementById(id).className=="tbButtonMouseOverDown")
        {
            document.getElementById(id).className="tbButtonDown";
        }
    }
}

//*********************************************************************************************************