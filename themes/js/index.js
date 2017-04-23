/// <reference path="jquery/jquery.min.js" />
var timer_sms_mon = null;
var monInterval = 1;
var timer_online_tree_ref = null;
//短信箱自动关闭时间，秒
var smsbox_close_timeout = 5;

var timeLastLoadOnline = 0;
var nextTabId = 0;

var $1 = function (id) { return document.getElementById(id); };
function ViewOnlineUser() {
    var pannelActive = $1('org').className.indexOf('active') >= 0;
    var onlineActive = $1('user_online_tab').className.indexOf('active') >= 0;
    if (pannelActive) {
        if (onlineActive)
            jQuery('#org').click();
        else
            ActiveUserTab(jQuery('user_online_tab'));
    }
    else {
        jQuery('#org').click();
        ActiveUserTab($1('user_online_tab'));
    }
}

jQuery(window).resize(function () { resizeLayout(); });
//-- 组织面板 --
function ActiveUserTab(obj) {
    if (obj.className.indexOf('active') >= 0)
        return;

    jQuery('#org_panel > .head > div >a.active').removeClass('active');
    jQuery(obj).addClass('active');
    jQuery('#user_online').toggle();
    jQuery('#user_all').toggle();
    jQuery('#org_panel').triggerHandler('_show');
}
jQuery(document).ready(function (jQuery) {
    //调整窗口大小
    resizeLayout();
    //组织面板和在线人员
    initOrg();
    //短信箱
    initSmsbox();
    //新短信、在线人员监控和状态栏文字滚动
    //alert($1('smsbox').className.indexOf('active'))
    window.setTimeout(sms_mon, 4000);
    window.setTimeout(online_mon, monInterval.online * 1000);
    // window.setInterval(StatusTextScroll, statusTextScroll * 1000);
});


function resizeLayout() {
    // 主操作区域高度
    var wWidth = (window.innerWidth || (window.document.documentElement.clientWidth || window.document.body.clientWidth));
    var wHeight = (window.innerHeight || (window.document.documentElement.clientHeight || window.document.body.clientHeight));
    var nHeight = 32 + 30 + 29;
    var fHeight = 0;
    jQuery('#ShowMain').height(wHeight - nHeight - fHeight - jQuery('#south').outerHeight());
};

function initOrg() {
    //组织面板和在线人员的显示和隐藏事件
    jQuery('#org_panel').bind('_show', function () { //bind 运行
        if (jQuery('#user_online:visible').length > 0)
            jQuery('#user_online').triggerHandler('_show');
        else
            jQuery('#user_all').triggerHandler('_show');
    });
    jQuery('#org_panel').bind('_hide', function () {
        if (jQuery('#user_online:hidden').length > 0)
            jQuery('#user_online').triggerHandler('_hide');
    });

    //在线人员
    jQuery('#user_online').bind('_show', function () {
        if (timer_online_tree_ref)
            window.clearTimeout(timer_online_tree_ref);

        if ((new Date()).getTime() - timeLastLoadOnline > monInterval.online * 5 * 1000)
            LoadOnlineTree();
    });
    jQuery('#user_online').bind('_hide', function () {
        if (timer_online_tree_ref)
            window.clearTimeout(timer_online_tree_ref);
    });

    //全部人员第一次显示加载全部人员树
    jQuery('#user_all').bind('_show', function () {
        if (jQuery('div.NodeDiv', jQuery(this)).length > 0) {
            jQuery(this).unbind('_show');
            return;
        }
        jQuery('#orgTree').html('<div class="loading">正在加载，请稍候……</div>');
        orgTree.BuildTree();
        //jQuery(this).jscroll({AutoHide:false});
    });
    //点击组织弹出或收起对应面板
    jQuery('#org').click(function () {
        if (jQuery(this).attr('class').indexOf('active') >= 0) {
            jQuery('#org_panel').fadeOut((jQuery.support.msie ? 1 : 300));
            jQuery(this).removeClass('active');
            jQuery('#org_panel').triggerHandler('_hide');
        }
        else {
            jQuery('#smsbox_panel').hide();
            jQuery('#org_panel').fadeIn((jQuery.support.msie ? 1 : 600), function () { jQuery('#org_panel').triggerHandler('_show'); });
            jQuery(this).addClass('active');
            window.setTimeout(checkActive, 300, this.id);
        }
    });
}


function initSmsbox() {
    //无新短信提示
    jQuery('#smsbox_tips').html(jQuery('#no_sms').html()).show();
    jQuery('#smsbox_tips').bind('_show', function () {
        window.setTimeout(function () {
            if (jQuery('#smsbox_tips:visible').length > 0)
                jQuery('#smsbox').triggerHandler('click');
        }, smsbox_close_timeout * 1000);
    });

    //点击短信箱弹出或收起对应面板
    jQuery('#smsbox').click(function () {
        if (jQuery(this).attr('class').indexOf('active') >= 0) {
            jQuery('#smsbox_panel').fadeOut((jQuery.support.msie ? 1 : 300));
            jQuery(this).removeClass('active');
        }
        else {/*
            var wWidth = (window.innerWidth || (window.document.documentElement.clientWidth || window.document.body.clientWidth));
            var wHeight = (window.innerHeight || (window.document.documentElement.clientHeight || window.document.body.clientHeight));
            var left = Math.floor((wWidth - jQuery('#smsbox_panel').outerWidth())/2);
            var top  = Math.floor((wHeight - jQuery('#smsbox_panel').outerHeight())/2);

            jQuery('#smsbox_panel').css({left:left, top:top});*/
            jQuery('#org_panel').hide();
            jQuery('#smsbox_panel').fadeIn((jQuery.support.msie ? 1 : 600));
            jQuery(this).addClass('active');
            window.setTimeout(checkActive, 300, this.id);

            LoadSms();
        }
    });

    //关闭按钮
    var closeBtn = jQuery('#smsbox_panel > .head > .head-center > .head-close');
    closeBtn.hover(
         function () { jQuery(this).addClass('head-close-active'); },
         function () { jQuery(this).removeClass('head-close-active'); }
      );
    closeBtn.click(function () {
        jQuery('#smsbox').triggerHandler('click');
    });

    //分组按钮
    jQuery('#group_by_name,#group_by_type').click(function () {
        if (jQuery(this).hasClass('active'))
            return;

        jQuery('#group_by_name').toggleClass('active');
        jQuery('#group_by_type').toggleClass('active');
        FormatSms();
    });

    //滚动按钮
    jQuery('#smsbox_scroll_up,#smsbox_scroll_down').hover(
         function () { jQuery(this).addClass('active'); },
         function () { jQuery(this).removeClass('active'); }
      );
    jQuery('#smsbox_scroll_up').click(function () {
        var listContainer = jQuery('#smsbox_list_container');
        var blockHeight = jQuery('div.list-block:first', listContainer).outerHeight();
        listContainer.animate({ scrollTop: listContainer.scrollTop() - blockHeight * 3 }, 300);
    });
    jQuery('#smsbox_scroll_down').click(function () {
        var listContainer = jQuery('#smsbox_list_container');
        var blockHeight = jQuery('div.list-block:first', listContainer).outerHeight();
        listContainer.animate({ scrollTop: listContainer.scrollTop() + blockHeight * 3 }, 300);
    });

    //列表内容变化
    jQuery('#smsbox_list_container').bind('_change', function () {
        jQuery('#smsbox_scroll_up,#smsbox_scroll_down').toggle(jQuery(this).outerHeight() < jQuery(this).attr('scrollHeight'));
        if (newSmsArray.length > 0) {
            jQuery('#smsbox_tips').hide();
            jQuery('#no_sms').hide()
            jQuery('#smsbox_list_container > div.list-block:first').trigger('click');
        }
        else {
            jQuery('#smsbox_tips').html(jQuery('#no_sms').html()).show(0, function () { jQuery(this).triggerHandler('_show'); });
        }
    });

    //列表hover效果


    //列表hover效果
    var listBlocks = jQuery('#smsbox_list_container > div.list-block');
    listBlocks.live('mouseenter', function () { jQuery(this).addClass('list-block-hover'); });
    listBlocks.live('mouseleave', function () { jQuery(this).removeClass('list-block-hover'); });

    //列表click事件
    listBlocks.live('click', function () {
        if (jQuery(this).attr('class').indexOf('list-block-active') > 0) return;
        jQuery('#smsbox_list_container > div.list-block').removeClass('list-block-active');
        jQuery(this).addClass('list-block-active');
        jQuery('table', this).removeClass('unread');

        var bGroupByName = jQuery('#group_by_name').attr('class').indexOf('active') >= 0;
        var id = jQuery(this).attr('group_id');
        var html = '';
        selectedRecvSmsIdStr = selectedSendSmsIdStr = '';
        for (var i = 0; i < newSmsArray.length; i++) {
            if (bGroupByName && !(newSmsArray[i].from_id == id && newSmsArray[i].to_id == loginUser.user_id || newSmsArray[i].from_id == loginUser.user_id && newSmsArray[i].to_id == id) || !bGroupByName)//&& newSmsArray[i].type_id != id
                continue;

            //接收的短信
            if (newSmsArray[i].receive)
                selectedRecvSmsIdStr += newSmsArray[i].sms_id + ',';
            else
                selectedSendSmsIdStr += newSmsArray[i].sms_id + ',';

            newSmsArray[i].unread = 0;
            var name = (bGroupByName && newSmsArray[i].receive == 1) ? newSmsArray[i].type_name : newSmsArray[i].from_name;
            var time = newSmsArray[i].send_time.indexOf(' ') > 0 ? newSmsArray[i].send_time.substr(0, 5) : newSmsArray[i].send_time;
            html += CreateMsgBlock({ "sms_id": newSmsArray[i].sms_id, "class": (newSmsArray[i].receive ? "from" : "to"), "user": newSmsArray[i].from_id, "name": name, "time": time, "content": newSmsArray[i].content, "url": newSmsArray[i].url });
        }
        jQuery('#smsbox_msg_container').html(html);
        window.setTimeout(function () {
            jQuery('#smsbox_msg_container').animate({ scrollTop: jQuery('#smsbox_msg_container').attr('scrollHeight') }, 300);
        }, 1);   //延迟1毫秒后取出的scrollHeight就是正确的，奇怪的问题

    });


    //全部已阅
    jQuery('#smsbox_read_all').click(function () {
        var array = GetSmsIds();
        RemoveSms(array.recv, array.send, 0);
    });
    //全部删除
    jQuery('#smsbox_delete_all').click(function () {
        var array = GetSmsIds();
        RemoveSms(array.recv, array.send, 1);
    });
    //全部详情
    jQuery('#smsbox_detail_all').click(function () {
        var sms_id_str = '';
        var sms_id_str0 = '';
        var nav_mail_url = '';
        for (var i = 0; i < newSmsArray.length; i++) {
            if (newSmsArray[i].receive != '1')
                continue;

            nav_mail_url = newSmsArray[i].url;
            sms_id_str += newSmsArray[i].sms_id + ',';
            if (newSmsArray[i].type_id == '0')
                sms_id_str0 += newSmsArray[i].sms_id + ',';
        }
        newSmsArray = [];
        FormatSms();
        jQuery('#smsbox_msg_container').html('');
        openURL('', '', 'themes//nav/?SMS_ID_STR=' + sms_id_str + '&SMS_ID_STR0=' + sms_id_str0 + '&NAV_MAIN_URL=' + encodeURIComponent(nav_mail_url), '1');
        selectedRecvSmsIdStr = selectedSendSmsIdStr = '';
    });

    //已阅
    jQuery('#smsbox_toolbar_read').click(function () {
        RemoveSms(selectedRecvSmsIdStr, selectedSendSmsIdStr, 0);
    });

    //删除
    jQuery('#smsbox_toolbar_delete').click(function () {
        RemoveSms(selectedRecvSmsIdStr, selectedSendSmsIdStr, 1);
    });

    //详情
    jQuery('#smsbox_toolbar_detail').click(function () {
        if (!selectedRecvSmsIdStr) return;
        var sms_id_str0 = '';
        var nav_mail_url = '';
        var array = [];
        for (var i = 0; i < newSmsArray.length; i++) {
            var id = newSmsArray[i].sms_id;
            if (selectedRecvSmsIdStr.indexOf(id + ',') == 0 || selectedRecvSmsIdStr.indexOf(',' + id + ',') > 0) {
                nav_mail_url = newSmsArray[i].url;
                if (newSmsArray[i].type_id == '0')
                    sms_id_str0 += id + ',';
                continue;
            }
            else if (selectedSendSmsIdStr.indexOf(id + ',') == 0 || selectedSendSmsIdStr.indexOf(',' + id + ',') > 0) {
                continue;
            }

            array[array.length] = newSmsArray[i];
        }
        openURL('', '', '/module/nav/?SMS_ID_STR=' + selectedRecvSmsIdStr + '&SMS_ID_STR0=' + sms_id_str0 + '&NAV_MAIN_URL=' + encodeURIComponent(nav_mail_url), '1');
        newSmsArray = array;
        FormatSms();
    });

    //内容块hover效果
    var msgBlocks = jQuery('#smsbox_msg_container > div.msg-block');
    msgBlocks.live('mouseenter', '', function () { jQuery(this).addClass('msg-hover'); });
    msgBlocks.live('mouseleave', '', function () { jQuery(this).removeClass('msg-hover'); });

    //内容块click事件
    msgBlocks.live('click', '', function () {
        jQuery('#smsbox_msg_container > div.msg-block').removeClass('msg-active');
        jQuery(this).addClass('msg-active');
    });

    //回复事件
    jQuery('.head > .operation > a.reply', msgBlocks).live('click','', function () {
        jQuery('#smsbox_textarea').trigger('focus');
    });

    //查看详情事件
    jQuery('.head > .operation > a.detail', msgBlocks).live('click','', function () {
        var sms_id = jQuery(this).attr('sms_id');
        var url = jQuery(this).attr('url');
        RemoveSms(sms_id, '', 0);
       //openURL('', '', url, '1');
    });

    function openURL(id, name, url, open_window) {
        id = !id ? ('w' + (nextTabId++)) : id;
        if (open_window != "1") {
            window.setTimeout(function () { jQuery().addTab(id, name, url, true) }, 1);
        }
        else {
            var mytop = (screen.availHeight - 500) / 2 - 30;
            var myleft = (screen.availWidth - 780) / 2;
            window.open(url, id, "height=548,width=780,status=0,toolbar=no,menubar=yes,location=no,scrollbars=yes,top=" + mytop + ",left=" + myleft + ",resizable=yes");
        }
        jQuery(document).trigger('click');
    }
    //输入框Ctrl + Enter事件
    jQuery('#smsbox_textarea').keypress(function (event) {
        if (event.keyCode == 10 || event.ctrlKey && event.which == 13)
            jQuery('#smsbox_send_msg').triggerHandler('click');
    });

    //发送
    jQuery('#smsbox_send_msg').click(function () {
        var msg = jQuery('#smsbox_textarea').val();
        if (!msg) return;

        var user_id = jQuery('#smsbox_msg_container > div.msg-active:first').attr('user') || jQuery('#smsbox_list_container > div.list-block-active:first').attr('user');
        if (!user_id) {
            alert('请选择发送用户');
            return;
        }

        var reg = /\n/g;
        var content = msg.replace(reg, "<br />");
        var date = new Date();
        var html = CreateMsgBlock({ "sms_id": "send_" + (maxSendSmsId++), "class": "to", "user": loginUser.user_id, "name": loginUser.user_name, "time": date.toTimeString().substr(0, 5), "content": content });
        jQuery('#smsbox_msg_container').append(html);
        window.setTimeout(function () {
            jQuery('#smsbox_msg_container').animate({ scrollTop: jQuery('#smsbox_msg_container').attr('scrollHeight') }, 300);
        }, 1);

        newSmsArray[newSmsArray.length] = { sms_id: "", from_id: loginUser.user_id, from_name: loginUser.user_name, type_id: "0", type_name: "个人短信", send_time: date.toTimeString().substr(0, 5), unread: 0, content: content, url: "", receive: 0 };
        //newSmsArray = jQuery.merge(array, newSmsArray);

        jQuery.ajax({
            type: 'POST',
            url: 'themes/js/attachment/Sms_Send.ashx',
            data: { 'TO_ID': user_id, 'CONTENT': msg, 'charset': 'utf-8' },
            dataType: 'text',
            success: function (data) {
                jQuery('#smsbox_textarea').val("");
            },
            error: function (request, textStatus, errorThrown) {
                alert('短信发送失败：' + textStatus);
            }
        });

        jQuery('#smsbox_textarea').focus();
    });
}

function CreateMsgBlock(msg) {
    var html = '';
    html += '<div class="msg-block ' + msg["class"] + '" sms_id="' + msg["sms_id"] + '" user="' + msg["user"] + '">';
    html += '   <div class="head">';
    html += '      <div class="name">' + msg["name"] + '&nbsp;' + msg["time"] + '</div>';
    if (msg["url"]) {
        html += '   <div class="operation">';
        html += '      <a href="javascript:;" class="reply" hidefocus="hidefocus">回复</a>';
        html += '      <a href="javascript:;" class="detail" sms_id="' + msg["sms_id"] + '" url="' + msg["url"] + '" hidefocus="hidefocus">已阅</a>';
        html += '   </div>';
    }
    html += '   </div>';
    html += '   <div class="msg">' + HtmlDiscode(msg["content"]) + '</div>';
    html += '</div>';
    return html;
}

function HtmlDiscode(theString) {
    theString = theString.replace(/&gt;/g, ">");
    theString = theString.replace(/&lt;/g, "<");
    theString = theString.replace(/&nbsp;/g, " ");
    theString = theString.replace(/&quot;/g, "\"");
    theString = theString.replace(/&#39;/g, "\'");
    //   theString = theString.replace(/<br/>/g, "\n");
    return theString;
}
var documentTitle = document.title;
var blinkTitleInterval = null;
//短消息
function sms_mon() {

        var randomCode = 0; var oldrandomCode = 0
        randomCode = parseInt(Math.random() * 10000);
        oldrandomCode = parseInt(Math.random() * 10000);
        jQuery.ajax({
            type: 'GET',
            url: 'themes/js/attachment/MessageHandler.ashx?' + randomCode + '=' + oldrandomCode,
            data: { 'now': new Date().getTime() },
            success: function (data) {
                //jQuery('new_sms').innerHTML = newSmsHtml;
                if ((data == "1") && ($1('smsbox').className.indexOf('active') == -1)) {
                    jQuery('new_sms_sound').innerHTML = newSmsSoundHtml;
                    if (timer_sms_mon) window.clearTimeout(timer_sms_mon);
                    var wWidth = (window.innerWidth || (window.document.documentElement.clientWidth || window.document.body.clientWidth));
                    var wHeight = (window.innerHeight || (window.document.documentElement.clientHeight || window.document.body.clientHeight));
                    var left = Math.floor((wWidth - jQuery('#new_sms_panel').outerWidth()) / 2);
                    var top = Math.floor((wHeight - jQuery('#new_sms_panel').outerHeight()) / 2) - 100;

                    jQuery('#new_sms_panel').css({ left: left, top: top });
                    jQuery('#new_sms_mask').show();
                    jQuery('#new_sms_panel').show();
                    jQuery('#new_sms_panel').focus();

                    blinkTitleInterval = window.setInterval(BlinkTitle, 1000);
                }
            },
            error: function (msg) {
                //alert(msg.responseText); //输出了出错的信息
            }
        });
        timer_sms_mon = window.setTimeout(sms_mon, monInterval.sms * 1000);
}
function BlinkTitle() {
    document.title = document.title == "　　　　　　　　" ? "您有新的短消息！" : "　　　　　　　　";
}

function ResetTitle() {
    window.clearInterval(blinkTitleInterval);
    document.title = documentTitle;
}

function checkActive(id) {
    if (jQuery('#' + id + '_panel:hidden').length > 0)
        jQuery('#' + id).removeClass('active');
    else
        window.setTimeout(checkActive, 300, id);
};

//-- 在线人员 --
function online_mon() {
    var randomCode = 0; var oldrandomCode = 0
    randomCode = parseInt(Math.random() * 10000);
    oldrandomCode = parseInt(Math.random() * 10000);
    jQuery.ajax({
        type: 'GET',
        url: 'themes/js/attachment/UserCount.ashx?' + randomCode + '=' + oldrandomCode,
        success: function (data) {
            jQuery('user_count').innerHTML = isNaN(parseInt(data)) ? "1" : parseInt(data);
        }
    });
    window.setTimeout(online_mon, monInterval.online * 1000);
}


var maxSendSmsId = 0;
var newSmsArray = [];
var selectedRecvSmsIdStr = selectedSendSmsIdStr = "";
function LoadSms(flag) {
    var randomCode = 0; var oldrandomCode = 0
    randomCode = parseInt(Math.random() * 10000);
    oldrandomCode = parseInt(Math.random() * 10000);
    jQuery('#smsbox_tips').html('<div class="loading">正在加载，请稍候……</div>').show();
    flag = typeof (flag) == "undefined" ? "1" : "0";
    jQuery.ajax({
        type: 'GET',
        url: 'themes/js/attachment/GetMessage.ashx?' + randomCode + '=' + oldrandomCode,
        data: { 'FLAG': flag },
        success: function (data) {
            var array = Text2Object(data);
            if (typeof (array) != "object" || typeof (array.length) != "number" || array.length < 0) {
                jQuery('#smsbox_tips').html('<div class="error">' + array + '</div>').show();
                return;
            }
            else if (array.length == 0) {
                jQuery('#smsbox_tips').html(jQuery('#no_sms').html()).show(0, function () { jQuery(this).triggerHandler('_show'); });
                return;
            }

            for (var i = 0; i < array.length; i++) {
                var sms_id = array[i].sms_id;
                var bFound = false;
                for (var j = 0; j < newSmsArray.length; j++) {
                    if (sms_id == newSmsArray[j].sms_id) {
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                    newSmsArray[newSmsArray.length] = array[i];
            }
            FormatSms();
        },
        error: function (request, textStatus, errorThrown) {
            jQuery('#smsbox_tips').html('<div class="error">获取短消息数据失败(' + request.status + ')：' + textStatus + '</div>').show();
        }
    });
}
function Text2Object(data) {
    try {
        var func = new Function("return " + data);
        return func();
    }
    catch (ex) {
        return '错误：' + ex.description + '，数据：' + data;
    }
}

function FormatSms() {
    var bGroupByName = jQuery('#group_by_name').attr('class').indexOf('active') >= 0;
    var array = new Array();

    var count = 0;
    for (var i = newSmsArray.length - 1; i >= 0; i--) {
        if (newSmsArray[i].receive != '1')
            continue;

        var id = bGroupByName ? newSmsArray[i].from_id : newSmsArray[i].type_id;
        if (typeof (array[id]) != "undefined") {
            array[id].count++;
            continue;
        }

        count++;
        var name = bGroupByName ? newSmsArray[i].from_name : newSmsArray[i].type_name;
        var time = newSmsArray[i].send_time.indexOf(' ') > 0 ? newSmsArray[i].send_time.substr(0, 5) : newSmsArray[i].send_time;
        var unread = array[id] && array[id].unread ? (array[id].unread || newSmsArray[i].unread) : newSmsArray[i].unread;
        array[i] = { name: name, count: 1, time: time, content: newSmsArray[i].content, unread: unread, id: id };
    }
    if (count == 0) {
        jQuery('#smsbox_tips').html(jQuery('#no_sms').html()).show(0, function () { jQuery(this).triggerHandler('_show'); });
        return;
    }
    var html = '';
    for (var i = 0; i < count; i++) {
        //取短信内容的前2行内容显示
        var content = array[i].content;
        var pos = content.indexOf('<br />');
        if (pos >= 0) {
            var pos2 = content.indexOf('<br />', pos + 6);
            if (pos2 >= 0)
                content = content.substr(0, pos2);
        }

        html += '<div class="list-block" group_id="' + array[i].id + '"' + (bGroupByName ? ' user="' + array[i].id + '"' : '') + '>';
        html += '   <table class="' + (array[i].unread ? "unread" : "") + '">';
        html += '      <tr><td class="name">' + array[i].name + '</td><td class="count">' + array[i].count + '</td><td class="time">' + array[i].time + '</td></tr>';
        html += '      <tr><td colspan="3" class="msg">' + HtmlDiscode(content) + '</td></tr>';
        html += '   </table>';
        html += '</div>';
    }
    jQuery('#smsbox_list_container').html(html);
    jQuery('#smsbox_list_container').triggerHandler('_change');
}

//-- 状态栏文字 --
function StatusTextScroll() {
    var obj = jQuery('#status_text');
    var scrollTo = obj.scrollTop() + obj.height();
    if (scrollTo >= obj.attr('scrollHeight'))
        scrollTo = 0;
    obj.animate({ scrollTop: scrollTo }, 300);
}

function LoadOnlineTree() {
    var randomCode = 0; var oldrandomCode = 0
    randomCode = parseInt(Math.random() * 10000);
    oldrandomCode = parseInt(Math.random() * 10000);
    $1('onlineTree').innerHTML = '<div class="loading">正在加载，请稍候……</div>';
    jQuery.ajax({
        type: 'GET',
        url: 'themes/js/attachment/UserOnline.ashx?' + randomCode + '=' + oldrandomCode,
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: { 'TYPE': 1 },
        success: function (data) {
            BulidOnlineTree(data);
            jQuery('#user_online').jscroll();
            timer_online_tree_ref = window.setTimeout(LoadOnlineTree, monInterval.online * 5 * 1000);
            timeLastLoadOnline = (new Date()).getTime();
        },
        error: function (msg) {
            alert(msg.responseText); //输出了出错的信息
        }
        //        error: function (request, textStatus, errorThrown) {
        //            alert(jQuery('onlineTree').innerHTML)
        //            jQuery('onlineTree').innerHTML = "<div class='tips'>刷新人员列表错误：" + request.status + "</div>";
        //            timer_online_tree_ref = window.setTimeout(LoadOnlineTree, monInterval.online * 5 * 1000);
        //        }
    });
}
function BulidOnlineTree(data) {
    if (data.substr(0, 4) != "+OK ") {
        $1('onlineTree').innerHTML = data;
        return;
    }
    data = data.substr(4); //截取字符
    var user_count = data.substr(0, data.indexOf(":"));
    user_count = isNaN(parseInt(user_count)) ? 1 : parseInt(user_count);
    data = data.substr(data.indexOf(":") + 1, data.length);

    tree = new MzTreeView("tree");
    tree.icons = {
        L0: 'transparent.gif',  //┏
        L1: 'transparent.gif',  //┣
        L2: 'transparent.gif',  //┗
        L3: 'transparent.gif',  //━
        L4: 'transparent.gif',  //┃
        empty: 'transparent.gif',     //空白图
        PM0: 'P0.png',  //＋┏
        PM1: 'P0.png',  //＋┣
        PM2: 'P0.png',  //＋┗
        PM3: 'P0.png',  //＋━
        root: 'root.png',   //缺省的根节点图标
        folder: 'folder.png', //缺省的文件夹图标
        file: 'file.png',   //缺省的文件图标
        exit: 'exit.gif',
        U00: 'U00.png',
        U01: 'U01.png',
        U02: 'U02.png',
        U03: 'U03.png',
        U10: 'U10.png',
        U11: 'U11.png',
        U12: 'U12.png',
        U13: 'U13.png'
    };
    tree.iconsExpand = {
        PM0: 'M0.png',     //－┏
        PM1: 'M0.png',     //－┣
        PM2: 'M0.png',     //－┗
        PM3: 'M0.png',     //－━
        folder: 'folderopen.png',
        exit: 'exit.gif'
    };
    tree.setIconPath("web/images/user_list3/");
    tree.nodes['0,TDOA'] = 'type:1;text:' + unit_name + ';';
    eval(data);

    var html = tree.toString();
    if (tree.totalNode <= 1) {
        $1('onlineTree').innerHTML = "<div class='tips'>尚未定义部门，<br>无法显示人员列表</div>";
    }
    else {
        $1('onlineTree').innerHTML = html;
        tree.expandAll();
        tree.initAll(tree.node["0"].childNodes);
        $1('user_count').innerHTML = user_count;
    }
}

function send_sms(TO_ID, TO_NAME) {
    mytop = (document.body.clientHeight - 265) / 3;
    myleft = (document.body.clientWidth - 430) / 3;
    window.open("Web/Message/System_Message_Manage.aspx?TO_ID=" + TO_ID, "", "height=600,width=730,status=0,toolbar=no,menubar=no,location=no,scrollbars=no,top=" + mytop + ",left=" + myleft + ",resizable=yes");
}

function send_email(TO_ID, TO_NAME) {
    openURL('', '', "email/new?TO_ID=" + TO_ID + "&TO_NAME=" + unescape(TO_NAME), "1");
}

function RemoveSms(recvIdStr, sendIdStr, del) {
    var randomCode = 0; var oldrandomCode = 0
    randomCode = parseInt(Math.random() * 10000);
    oldrandomCode = parseInt(Math.random() * 10000);
    if (!recvIdStr) return;
    jQuery.ajax({
        type: 'POST',
        url: 'themes/js/attachment/Sms_Submit.ashx?' + randomCode + '=' + oldrandomCode,
        data: { 'SMS_ID': recvIdStr, 'DEL': del },
        dataType: 'text',
        success: function (data) {
            var array = [];
            for (var i = 0; i < newSmsArray.length; i++) {
                var id = newSmsArray[i].sms_id;
                if (id == recvIdStr || recvIdStr.indexOf(id + ',') == 0 || recvIdStr.indexOf(',' + id + ',') > 0 ||
               id == sendIdStr || sendIdStr.indexOf(id + ',') == 0 || sendIdStr.indexOf(',' + id + ',') > 0)
                    continue;

                array[array.length] = newSmsArray[i];
            }
            newSmsArray = array;


            if (recvIdStr.indexOf(',') > 0) //多条
            {
                selectedRecvSmsIdStr = selectedSendSmsIdStr = '';
                FormatSms();
            }
            else //一条
            {
                jQuery('#smsbox_msg_container > div.msg-block[sms_id="' + recvIdStr + '"]').remove();

                if (selectedRecvSmsIdStr.indexOf(recvIdStr + ',') == 0)
                    selectedRecvSmsIdStr = selectedRecvSmsIdStr.substr(recvIdStr.length + 1);
                if (selectedRecvSmsIdStr.indexOf(',' + recvIdStr + ',') > 0)
                    selectedRecvSmsIdStr = selectedRecvSmsIdStr.replace(',' + recvIdStr + ',', '');

                if (jQuery('#smsbox_msg_container > div.msg-block').length == 0)
                    FormatSms();
            }
        },
        error: function (request, textStatus, errorThrown) {
            alert('操作失败：' + textStatus);
        }
    });
}
//-- 短信提醒和短信箱面板 --
function ViewNewSms() {
    var pannelActive = $1('smsbox').className.indexOf('active') >= 0;
    if (!pannelActive)
        jQuery('#smsbox').click();
    else
        LoadSms();

    CloseRemind();
    ResetTitle();
}
function CloseRemind() {
    jQuery('#new_sms_mask').hide();
    jQuery('#new_sms_panel').hide();
    timer_sms_mon = window.setTimeout(sms_mon, monInterval.sms * 1000);
    ResetTitle();
}
function ResetTitle() {
    window.clearInterval(blinkTitleInterval);
    document.title = documentTitle;
}
function view_user(USER_ID) {

    var mytop = (screen.availHeight - 500) / 2 - 30;
    var myleft = (screen.availWidth - 780) / 2;
    window.open("Web/HR/KNet_HR_Manage_Details.aspx?StaffNo= " + USER_ID, "", "height=548,width=780,status=0,toolbar=no,menubar=yes,location=no,scrollbars=yes,top=" + mytop + ",left=" + myleft + ",resizable=yes");
}