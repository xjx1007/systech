/*********************************************************************************
** The contents of this file are subject to the vtiger CRM Public License Version 1.0
* ("License"); You may not use this file except in compliance with the License
* The Original Code is:  vtiger CRM Open Source
* The Initial Developer of the Original Code is vtiger.
* Portions created by vtiger are Copyright (C) vtiger.
* All Rights Reserved.
*
********************************************************************************/


function DelStuff(sid) {
    if (confirm(alert_arr.DELETE)) {
        new Ajax.Request(
        	'index.php',
               	{ queue: { position: 'end', scope: 'command' },
               	    method: 'post',
               	    postBody: 'module=Home&action=HomeAjax&file=HomestuffAjax&homestuffid=' + sid,
               	    onComplete: function (response) {
               	        var responseVal = response.responseText;
               	        if (response.responseText.indexOf('SUCCESS') > -1) {
               	            var delchild = $('stuff_' + sid);
               	            odeletedChild = $('MainMatrix').removeChild(delchild);
               	            $('seqSettings').innerHTML = '<table cellpadding="10" cellspacing="0" border="0" width="100%" class="vtResultPop small"><tr><td align="center">Stuff deleted sucessfully.</td></tr></table>';
               	            LocateObj($('seqSettings'))
               	            Effect.Appear('seqSettings');
               	            setTimeout(hideSeqSettings, 3000);
               	        } else {
               	            alert("Error while deleting.Please try again.")
               	        }
               	    }
               	}
         	);
    }
}

function loadStuff(stuffid, stufftype) {
    $('refresh_' + stufftype + stuffid).innerHTML = $('vtbusy_homeinfo').innerHTML;
    var randomCode = 0; var oldrandomCode = 0
    randomCode = parseInt(Math.random() * 10000);
    oldrandomCode = parseInt(Math.random() * 10000);
    new Ajax.Request(
						'../include/attachment/GetDeskInfo.ashx',
						{ queue: { position: 'end', scope: 'command' },
						    method: 'post',
						    postBody: 'ID=' + stuffid + '&Type=' + stufftype + '&' + randomCode + '=' + oldrandomCode,
						    onComplete: function (response) {
						        var responseVal = response.responseText;
						        $('stuffcont_' + stufftype + stuffid).innerHTML = responseVal;
						        $('refresh_' + stufftype + stuffid).innerHTML = '';
						    }
						}
		);
}



function fnRemoveWindow() {
    var tagName = document.getElementById('createConfigBlockDiv').style.display = 'none';
}

function fnShowWindow() {
    var tagName = document.getElementById('createConfigBlockDiv').style.display = 'block';
}
function positionDivTocenter(targetDiv) {
    //Gets the browser's viewport dimension
    getViewPortDimension();
    //Gets the Target DIV's width & height in pixels using parseInt function
    divWidth = (parseInt(document.getElementById(targetDiv).style.width)) / 2;
    //divHeight=(parseInt(document.getElementById(targetDiv).style.height))/2;
    //calculate horizontal and vertical locations relative to Viewport's dimensions
    mx = parseInt(XX / 2) - parseInt(divWidth);
    //my = parseInt(YY/2)-parseInt(divHeight);
    //Prepare the DIV and show in the center of the screen.
    document.getElementById(targetDiv).style.left = mx + "px";
    document.getElementById(targetDiv).style.top = "150px";
}

function getViewPortDimension() {
    if (!document.all) {
        XX = self.innerWidth;
        YY = self.innerHeight;
    }
    else if (document.all) {
        XX = document.documentElement.clientWidth;
        YY = document.documentElement.clientHeight;

    }
}
function positionDivInAccord(targetDiv, stuffwidth) {
    if (stuffwidth != "") {
        document.getElementById(targetDiv).style.width = stuffwidth;
    }
    else {
        mainX = parseInt(document.getElementById("MainMatrix").style.width);
        dx = mainX * 31 / 100;
        document.getElementById(targetDiv).style.width = dx + "%";
    }

}
function hideSeqSettings() {
    Effect.Fade('seqSettings');
}
function verify_data(form) {
    x = form.stuffid.length;
    var y = 0;
    idstring = "";
    if (x == undefined) {

        if (form.stuffid.checked) {
            idstring = form.stuffid.value;
            y = 1;
        }
        else {
            alert(alert_arr.SELECT);
            return false;
        }
    }
    else {
        y = 0;
        for (i = 0; i < x; i++) {
            if (form.stuffid[i].checked) {
                idstring = form.stuffid[i].value + ";" + idstring;

                y = y + 1;
            }
        }
    }
    if (y != 0) {
        form.idlist.value = idstring;
    }
    else {
        alert(alert_arr.SELECT);
        return false;
    }
    return true;
}
function back_to_read_only() {
    //Set to read only
    var textArea_id = document.getElementById('ajotpad');
    textArea_id.readOnly = true;
    textArea_id.style.borderColor = '000000';
    textArea_id.style.fontSize = '12px';
    textArea_id.style.fontFamily = 'Verdana';
    textArea_id.style.color = '000000';
    textArea_id.style.backgroundColor = 'FFFFFF';
    //show saving message
    $('vtbusy_homeinfo').style.display = 'inline';
    new Ajax.Request(
						'index.php',
						{ queue: { position: 'end', scope: 'command' },
						    method: 'post',
						    postBody: 'module=Home&action=HomeAjax&file=SaveNotePad&textData=' + textArea_id.value,
						    onComplete: function (response) {
						        var responseVal = response.responseText;
						        if ('SUCCESS' == responseVal) {
						            $('vtbusy_homeinfo').style.display = 'none';
						        }
						    }
						}
		);
    //xajax_updateNotes(textArea_id, textArea_id.value);
}

function change_to_text_area() {
    //set to text area
    var textArea_id = document.getElementById('ajotpad');
    textArea_id.readOnly = false;
    textArea_id.style.borderColor = '000000';
    textArea_id.style.fontSize = '12px';
    textArea_id.style.fontFamily = 'Arial';
    textArea_id.style.color = '000000';
    //textArea_id.style.backgroundColor ='ECE9D8';
    textArea_id.focus();
}


