var userAgent = navigator.userAgent.toLowerCase();
window.$ = function (selector) {
    var o = new $.fn.init(selector);
    return o
};
$.version = "2012.12.14 power by yemin.me";
$.fn = $.prototype = {
    elem: null,
    style: null,
    top: 0,
    left: 0,
    width: 0,
    height: 0,
    length: 0,
    id: null,
    tag: null,
    title: null,
    src: null,
    selector: null,
    exp: {
        A: /^#[\w-\$]+\s{1}\w+$/,
        B: /^#[\w-\$]+\.[\w\s-]+$/,
        C: /^#[\w-\$]+\>\.{0,1}[\w\s-]+$/,
        D: /^\.{0,1}[\w\s-]+$/,
        E: /^#[\w-\$]+$/
    },
    init: function (selector) {
        this.selector = selector;
        if (typeof (selector) == "string") {
            var arr;
            var elems;
            if (this.exp.A.test(selector)) {
                arr = selector.substring(1).split(' ');
                return this.find(arr[1], document.getElementById(arr[0]), null, this)
            }
            else if (this.exp.B.test(selector)) {
                arr = selector.substring(1).split('.');
                return this.find("." + arr[1], document.getElementById(arr[0]), null, this)
            }
            else if (this.exp.C.test(selector)) {
                arr = selector.substring(1).split('>');
                return this.find(arr[1], document.getElementById(arr[0]), true, this)
            }
            else if (this.exp.D.test(selector)) {
                return this.find(selector, document)
            }
            else if (this.exp.E.test(selector)) this.elem = this[0] = document.getElementById(selector.substring(1));
            else this.elem = this[0] = null
        }
        else this.elem = this[0] = selector; if (this[0] == document) this.length = 1;
        if (this.elem != null && this.elem != document) {
            var o = this.elem;
            this.top = o.style.top == "" ? 0 : parseInt(o.style.top);
            this.left = o.style.left == "" ? 0 : parseInt(o.style.left);
            this.width = o.offsetWidth;
            this.height = o.offsetHeight;
            this.id = o.id;
            this.tag = o.tagName;
            this.title = o.title;
            this.src = o.src;
            this.style = o.style;
            this.length = 1
        }
        return this
    },
    find: function (selector, context, onlyChild, obj) {
        var elems;
        var len = 0;
        context = context == null ? this[0] : context;
        onlyChild = onlyChild == null ? false : onlyChild;
        if (obj) {
            obj.selector = this.selector
        }
        else {
            obj = new $();
            obj.selector = selector
        } if (selector.substring(0, 1) == ".") {
            elems = onlyChild == false ? context.getElementsByTagName("*") : context.childNodes;
            for (var i = 0; i < elems.length; i++) {
                var s = selector.substring(1);
                var classname = elems[i].className;
                if (classname != s && classname.indexOf(" " + s) < 0 && classname.indexOf(s + " ") < 0) continue;
                obj[len] = elems[i];
                len++
            }
            obj.length = len
        }
        else {
            if (onlyChild == false) {
                elems = context.getElementsByTagName(selector);
                obj.length = elems.length;
                for (var i = 0; i < elems.length; i++) {
                    obj[i] = elems[i]
                }
            }
            else {
                elems = context.childNodes;
                for (var i = 0; i < elems.length; i++) {
                    if (elems[i].tagName && elems[i].tagName.toLowerCase() == selector.toLowerCase()) {
                        obj[len] = elems[i];
                        len++
                    }
                }
                obj.length = len
            }
        }
        return obj
    },
    parent: function (tag) {
        if (this.elem) {
            if (tag == null) return $(this.elem.parentNode);
            else {
                while (this.elem = this.elem.parentNode) {
                    if (this.elem.tagName == tag.toUpperCase()) return $(this.elem)
                }
                return null
            }
        }
    },
    match: function (obj) {
        var list = $(this.selector);
        for (var i = 0; i < list.length; i++) {
            if (list[i] == obj) return obj
        }
        return null
    },
    html: function (value) {
        if (this.elem) {
            if (value == null) return this.elem.innerHTML;
            else this.elem.innerHTML = value
        }
    },
    getStyle: function (attribute) {
        var obj = this[0];
        return obj.currentStyle ? obj.currentStyle[attribute] : document.defaultView.getComputedStyle(obj, false)[attribute]
    },
    createFragment: function (html) {
        var doc = this[0].ownerDocument || document;
        return $.parseHTML(html, doc.createDocumentFragment())
    },
    append: function (el) {
        if (typeof (el) == "string") {
            el = this.createFragment(el)
        }
        this[0].appendChild(el.elem ? el.elem : el)
    },
    remove: function (el) {
        if (el == null) this[0].parentNode.removeChild(this[0]);
        else this.elem.removeChild(el.elem ? el.elem : el)
    },
    insert: function (el, index) {
        var p = index == null ? this[0].firstChild : this[0].childNodes[index];
        if (typeof (el) == "string") {
            el = this.createFragment(el)
        }
        this[0].insertBefore(el.elem ? el.elem : el, p)
    },
    insertBefore: function (el) {
        if (typeof (el) == "string") {
            el = this.createFragment(el)
        }
        this[0].parentNode.insertBefore(el.elem ? el.elem : el, this[0])
    },
    insertAfter: function (el) {
        if (typeof (el) == "string") {
            el = this.createFragment(el)
        }
        var p = this.elem.parentNode;
        if (p.lastChild == this.elem) p.appendChild(el.elem ? el.elem : el);
        else p.insertBefore(el.elem ? el.elem : el, this.elem.nextSibling)
    },
    val: function (value) {
        if (value == null) return this[0].value;
        for (var i = 0; i < this.length; i++) {
            this[i].value = value
        }
    },
    selectedText: function () {
        var o = this[0];
        return o.options[o.selectedIndex].innerHTML
    },
    clearOptions: function () {
        this[0].length = 0
    },
    getOptions: function () {
        var arr = new Array();
        var slt = this[0];
        for (var i = 0; i < slt.length; i++) {
            var o = slt.options[i];
            arr[o.value] = o.innerHTML
        }
        return arr
    },
    selectedOptions: function () {
        var right = this[0];
        var val = "";
        var text = "";
        for (var i = 0; i < right.length; i++) {
            var o = right.options[i];
            val += o.value + ",";
            text += o.innerHTML + ","
        }
        if (val == "") return {
            val: "",
            text: ""
        };
        val = val.substring(0, val.length - 1);
        text = text.substring(0, text.length - 1);
        return {
            "val": val,
            "text": text
        }
    },
    bindOptions: function (arr, selectedvalue) {
        this.clearOptions();
        var html = '';
        for (var i = 0; i < arr.length; i++) {
            var selected = selectedvalue == null ? '' : ' selected="selected"';
            html += '<option value="' + arr[i][0] + '"' + selected + '>' + arr[i][1] + '</options>'
        }
        this.append(html)
    },
    attr: function (name, value) {
        for (var i = 0; i < this.length; i++) {
            if (value == null) return this[i].getAttribute(name);
            else this[i].setAttribute(name, value)
        }
    },
    css: function (value) {
        for (var i = 0; i < this.length; i++) {
            if (value == null) return this[i].className;
            else this[i].className = value
        }
    },
    addCss: function (value) {
        for (var i = 0; i < this.length; i++) {
            var v = this[i].className;
            if (v == "") this[i].className = value;
            else this[i].className = v + " " + value
        }
    },
    removeCss: function (value) {
        for (var i = 0; i < this.length; i++) {
            this[i].className = this[i].className.replace(value, '').trim()
        }
    },
    show: function (value, callback) {
        for (var i = 0; i < this.length; i++) {
            var s = this[i].style;
            value == null ? s.display = "" : s.visibility = "visible"
        }
        if (callback) callback()
    },
    hide: function (value) {
        for (var i = 0; i < this.length; i++) {
            var s = this[i].style;
            value == null ? s.display = "none" : s.visibility = "hidden"
        }
    },
    isHidden: function (value) {
        if (this.elem) {
            var s = this.elem.style;
            return (value == null) ? s.display == "none" : s.visibility == "hidden"
        }
    },
    disable: function (value) {
        for (var i = 0; i < this.length; i++) {
            this[i].disabled = value
        }
    },
    checked: function (value) {
        if (value == null) return this[0].checked;
        for (var i = 0; i < this.length; i++) {
            this[i].checked = value
        }
    },
    click: function () {
        if ($.browser.msie) this[0].click();
        else {
            var evt = document.createEvent("MouseEvents");
            evt.initEvent("click", true, true);
            this[0].dispatchEvent(evt)
        }
    },
    opacity: function (value) {
        var s = this[0].style;
        if (value != null) {
            for (var i = 0; i < this.length; i++) {
                s = this[i].style;
                s.filter = "alpha(opacity=" + value * 100 + ")";
                s.opacity = value
            }
        }
        else {
            var v = 1.0;
            if ($.browser.msie) {
                if (s.filter == "") return v;
                var str = s.filter.match(/\d+/);
                v = parseInt(str) / 100
            }
            else {
                if (s.opacity == "") return v;
                v = parseFloat(s.opacity)
            }
            return v
        }
    },
    contains: function (elem) {
        while (elem != null && typeof (elem[0].tagName) != "undefined") {
            if (elem[0] == this[0]) return true;
            elem[0] = elem[0].parentNode
        }
        return false
    },
    size: function (width, height) {
        if (width == null && height == null) return {
            width: parseInt(this.style.width),
            height: parseInt(this.style.height)
        };
        for (var i = 0; i < this.length; i++) {
            var s = this[0].style;
            if (width) s.width = typeof (width) == "string" ? width : width + "px";
            if (height) s.height = typeof (height) == "string" ? height : height + "px"
        }
    },
    position: function (top, left, isReturn) {
        var s = this.style;
        if (top) s.top = top + "px";
        if (left) s.left = left + "px";
        isReturn = isReturn == null ? false : isReturn;
        if (isReturn || (top == null && left == null)) {
            var o = this.elem;
            var left = o.offsetLeft;
            var top = o.offsetTop;
            while (o = o.offsetParent) {
                left += o.offsetLeft;
                top += o.offsetTop
            }
            return {
                left: left,
                top: top
            }
        }
    },
    bindEvent: function (type, eventHandler) {
        if ($.browser.mobile == false && type == "tap") type = "click";
        if (window.addEventListener) {
            if (type == "propertychange") type = "oninput";
            for (var i = 0; i < this.length; i++) {
                this[i].addEventListener(type, eventHandler, false)
            }
        }
        else if (window.attachEvent) {
            for (var i = 0; i < this.length; i++) {
                eval("var temp" + i + " = this[" + i + "]");
                eval("temp" + i + ".attachEvent('on' + type, function() { eventHandler.apply(temp" + i + ", arguments); })")
            }
        }
    },
    removeEvent: function (type, eventHandler) {
        if ($.browser.mobile == false && type == "tap") type = "click";
        if (window.attachEvent) {
            for (var i = 0; i < this.length; i++) {
                eval("var temp" + i + " = this[" + i + "]");
                eval("temp" + i + ".detachEvent('on' + type, function() { eventHandler.apply(temp" + i + ", arguments); })")
            }
        }
        else if (window.addEventListener) {
            for (var i = 0; i < this.length; i++) {
                this[i].removeEventListener(type, eventHandler, false)
            }
        }
    },
    live: function (type, eventHandler) {
        if ($.browser.mobile == false && type == "tap") type = "click";
        var selector = this.selector;
        $.liveEventArray[selector] = eventHandler;
        if ($.liveEventEnable) return;
        if (window.addEventListener) {
            document.addEventListener(type, function (e) {
                var e = e || window.event;
                var obj = e.target || e.srcElement;
                for (var o in $.liveEventArray) {
                    var list = $(o);
                    var handler = $.liveEventArray[o];
                    for (var i = 0; i < list.length; i++) {
                        if (list[i] == obj) {
                            handler.apply(list[i], arguments);
                            break
                        }
                        else if ($.contains(list[i], obj)) {
                            handler.apply(list[i], arguments);
                            break
                        }
                    }
                }
            }, false)
        }
        else {
            document.attachEvent('on' + type, function () {
                var e = window.event;
                var obj = e.target || e.srcElement;
                for (var o in $.liveEventArray) {
                    var list = $(o);
                    var handler = $.liveEventArray[o];
                    for (var i = 0; i < list.length; i++) {
                        if (list[i] == obj) {
                            handler.apply(list[i], arguments);
                            break
                        }
                        else if ($.contains(list[i], obj)) {
                            handler.apply(list[i], arguments);
                            break
                        }
                    }
                }
            })
        }
        $.liveEventEnable = true
    },
    insertRow: function (cells, index, className) {
        if (this.elem.tagName != "TBODY") return;
        var row = this.elem.insertRow(index == null ? this.elem.rows.length : index);
        if (className != null) row.className = className;
        var cell;
        for (var i = 0; i < cells.length; + i++) {
            cell = row.insertCell(i);
            if (cells[i].className != null) cell.className = cells[i].className;
            if (cells[i].text != null) cell.innerHTML = cells[i].text;
            else cell.innerHTML = cells[i];
            row.appendChild(cell)
        }
    },
    deleteRow: function (index) {
        if (this.elem.tagName != "TBODY") return;
        this.elem.deleteRow(index)
    },
    clearRow: function () {
        if (this.elem.tagName != "TBODY") return;
        for (var i = this.elem.rows.length - 1; i >= 0; i--) {
            this.elem.deleteRow(i)
        }
    },
    sort: function (standardTable, setRank, selectedClassName) {
        var tdlist;
        if (standardTable == 0) tdlist = this.elem.getElementsByTagName("thead")[0].getElementsByTagName("th");
        else tdlist = this.elem.getElementsByTagName("tr")[0].getElementsByTagName("td");
        for (var i = 0; i < tdlist.length; i++) {
            var chks = tdlist[i].getElementsByTagName("input");
            if (chks.length > 0 && chks[0].type == "checkbox") continue;
            eval("tdlist[" + i + "].onclick = function() { UI.sortTD(this, " + i + ", " + standardTable + ", setRank, selectedClassName); }")
        }
    },
    serialize: function () {
        var list = null;
        if (this[0].tagName == "FORM") list = this[0].elements;
        else list = this[0].getElementsByTagName("*");
        var data = "";
        var pars = new Array();
        for (var i = 0; i <= list.length - 1; i++) {
            var el = list[i];
            if (el.type == undefined || el.type.indexOf("script") > -1) continue;
            if (el.name == undefined) continue;
            switch (el.type) {
                case "radio":
                    if (el.checked == true) {
                        data += el.name + "=" + el.value + "&"
                    };
                    break;
                case "checkbox":
                    if (el.checked == false) break;
                    if (pars[el.name] == null) {
                        pars[el.name] = el.value
                    }
                    else {
                        pars[el.name] += "," + el.value
                    };
                    break;
                default:
                    data += el.name + "=" + encodeURIComponent(el.value) + "&";
                    break
            }
        }
        var chk = $.array.serialize(pars);
        if (chk && chk != "") {
            data += chk;
            return data
        }
        else if (data != "") return data.substring(0, data.length - 1);
        else return ""
    },
    post: function (callback, url, async) {
        url = (url == null ? this[0].action : url);
        new _Ajax().open(url, this.serialize(), "POST", callback, async)
    },
    updateData: function (arr) {
        var x = this[0].getElementsByTagName("*");
        for (var o in arr) {
            var list = new Array();
            for (var i = 0; i < x.length; i++) {
                if (x[i].className.toLowerCase().indexOf("{" + o + "}") > -1) list.push(x[i])
            }
            if (list.length == 0) continue;
            if (list.length == 1) list.value = arr[o];
            var vals = arr[o].split(',');
            for (var i = 0; i < vals.length; i++) {
                list[i].innerHTML = vals[i]
            }
        }
    },
    verifyForm: function (type, blur) {
        type = type == null ? 0 : 1;
        blur = blur == null ? true : blur;
        var form = this[0];
        var ipt = form.getElementsByTagName("*");
        for (var i = 0; i < ipt.length; i++) {
            var item = ipt[i];
            if (item.tagName != "INPUT" && item.tagName != "TEXTAREA" && item.tagName != "SELECT") continue;
            var verity = item.getAttribute("verify");
            var must = item.getAttribute("must");
            if (verity == null && (must == null || must == "0")) continue;
            if (item.className.indexOf("ke-username") > -1 || item.className.indexOf("ke-orgname") > -1 || item.className.indexOf("ke-deptname") > -1 || item.className.indexOf("ke-posname") > -1 || item.className.indexOf("ke-customername") > -1) return true;
            if (blur) $(item).bindEvent("change", function () {
                $.verifyElement(this, type)
            })
        }
        form.onsubmit = function () {
            var v = true;
            ipt = form.getElementsByTagName("INPUT");
            for (var k = 0; k < ipt.length; k++) {
                var item = ipt[k];
                if (item.type == "hidden") continue;
                var verity = item.getAttribute("verify");
                var must = item.getAttribute("must");
                if (verity == null && (must == null || must == "0")) continue;
                if (!$.verifyElement(item, type)) return false
            }
            ipt = form.getElementsByTagName("TEXTAREA");
            for (var k = 0; k < ipt.length; k++) {
                var item = ipt[k];
                var verity = item.getAttribute("verify");
                var must = item.getAttribute("must");
                if (verity == null && (must == null || must == "0")) continue;
                if (!$.verifyElement(item, type)) return false
            }
            ipt = form.getElementsByTagName("SELECT");
            for (var k = 0; k < ipt.length; k++) {
                var item = ipt[k];
                var verity = item.getAttribute("verify");
                var must = item.getAttribute("must");
                if (verity == null && (must == null || must == "0")) continue;
                if (!$.verifyElement(item, type)) return false
            }
            return v
        }
    },
    drag: function (aim, type, minX, maxX, minY, maxY) {
        this.style.cursor = "move";
        var one = true;
        var a = "d";
        var o = aim == null ? this : (typeof (aim) == "string" ? $("#" + aim) : aim);
        o.style.position = (o.style.position == "") ? "relative" : "absolute";
        this.elem.onmousedown = function (e) {
            var pos = o.position();
            pos.left = (o.style.position == "absolute") ? pos.left : 0;
            pos.top = (o.style.position == "absolute") ? pos.top : 0;
            var _x = 0,
             _y = 0;
            e = e || window.event;
            var d = document;
            var x = e.clientX;
            var y = e.clientY;
            document.onmousemove = function (e) {
                (o.elem.setCapture) ? o.elem.setCapture() : window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP);
                e = e || window.event;
                _x = e.clientX - x + o.left;
                _y = e.clientY - y + o.top;
                if (o.left == 0) _x += pos.left;
                if (o.top == 0) _y += pos.top;
                _x = (_x > maxX) ? maxX : ((_x < minX) ? minX : _x);
                _y = (_y > maxY) ? maxY : ((_y < minY) ? minY : _y);
                switch (type) {
                    case 1:
                        o.position(null, _x);
                        break;
                    case 2:
                        o.position(_y, null);
                        break;
                    default:
                        o.position(_y, _x);
                        break
                }
            };
            document.onmouseup = function () {
                switch (type) {
                    case 1:
                        o.left = _x;
                        break;
                    case 2:
                        o.top = _y;
                        break;
                    default:
                        o.left = _x;
                        o.top = _y;
                        break
                }
                one = false;
                (o.elem.releaseCapture) ? o.elem.releaseCapture() : window.captureEvents(Event.MOUSEMOVE | Event.MOUSEUP);
                document.onmousemove = null;
                document.onmouseup = null
            }
        }
    },
    fx: function (duration, a, size, position, opacity, callback) {
        var init_size = this.size();
        var init_position = this.position();
        var init_pacity = this.opacity();
        var x_size = 0.5 * a.size * duration * duration;
        var s_width = (size.width - init_size.width);
        var v_width = (s_width - x_size) / duration;
        var s_height = (size.height - init_size.height);
        var v_height = (s_height - x_size) / duration;
        var x_position = 0.5 * a.position * duration * duration;
        var s_top = (position.top - init_position.top);
        var v_top = (s_top - x_position) / duration;
        var s_left = (position.left - init_position.left);
        var v_left = (s_left - x_position) / duration;
        var s_opacity = (opacity - init_pacity);
        var v_opacity = s_opacity / duration;
        var interval = setInterval(loop, 40);
        var s = this[0].style;
        var self = this;
        var time = 0;
        var tmp_size = tmp_pos = {};
        var tmp_opacity;
        function loop() {
            time += 40;
            x_size = 0.5 * a.size * time * time;
            tmp_size.width = init_size.width + v_width * time + x_size;
            tmp_size.height = init_size.height + v_height * time + x_size;
            x_position = 0.5 * a.position * time * time;
            tmp_pos.top = init_position.top + v_top * time + x_position;
            tmp_pos.left = init_position.left + v_left * time + x_position;
            tmp_opacity = init_pacity + v_opacity * time;
            if ((s_width > 0 && tmp_size.width >= size.width) || (s_width < 0 && tmp_size.width <= size.width)) tmp_size.width = size.width;
            if ((s_height > 0 && tmp_size.height >= size.height) || (s_height < 0 && tmp_size.height <= size.height)) tmp_size.height = size.height;
            if ((s_top > 0 && tmp_pos.top >= position.top) || (s_top < 0 && tmp_pos.top <= position.top)) tmp_pos.top = position.top;
            if ((s_left > 0 && tmp_pos.left >= position.left) || (s_left < 0 && tmp_pos.left <= position.left)) tmp_pos.left = position.left;
            self.opacity(tmp_opacity);
            s.width = (tmp_size.width > 0 ? tmp_size.width : 0) + "px";
            s.height = (tmp_size.height > 0 ? tmp_size.height : 0) + "px";
            s.left = (tmp_size.left > 0 ? tmp_size.left : 0) + "px";
            s.top = (tmp_size.top > 0 ? tmp_size.top : 0) + "px";
            if (tmp_size.width == size.width && tmp_size.height == size.height && tmp_pos.left == position.left && tmp_pos.top == position.top && tmp_opacity == opacity) {
                clearInterval(interval);
                if (callback) callback()
            }
        }
    }
};
$.fn.init.prototype = $.fn;
$.liveEventArray = new Array();
$.liveEventEnable = false;
$.scroll = {
    top: function () {
        return document.documentElement.scrollTop || document.body.scrollTop
    },
    left: function () {
        return document.documentElement.scrollLeft || document.body.scrollLeft
    },
    width: function () {
        return document.documentElement.scrollWidth || document.body.scrollWidth
    },
    height: function () {
        return document.documentElement.scrollHeight || document.body.scrollHeight
    }
};
$.browser = {
    version: (userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/) || [])[1],
    safari: /webkit/.test(userAgent),
    opera: /opera/.test(userAgent),
    msie: /msie/.test(userAgent) && !/opera/.test(userAgent),
    mozilla: /mozilla/.test(userAgent) && !/(compatible|webkit)/.test(userAgent),
    mobile: /ipad|iphone|blackberry|android/.test(userAgent)
};
$.year = new Array();
for (var i = new Date().getFullYear(); i > 1900; i--) {
    $.year.push(i)
};
$.month = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
$.day = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
$.event = {
    src: function (e) {
        e = e || window.event;
        var obj = e.target || e.srcElement;
        return $(obj)
    },
    to: function (e) {
        e = e || window.event;
        var obj = e.relatedTarget || e.toElement;
        return $(obj)
    },
    key: function (e) {
        e = e || window.event;
        return e.keyCode
    },
    cancleBubble: function (event) {
        if (window.event) window.event.cancelBubble = true;
        else event.stopPropagation()
    },
    mousePos: function (ev) {
        ev = ev || window.event;
        if (ev.pageX || ev.pageY) {
            return {
                x: ev.pageX,
                y: ev.pageY
            }
        }
        return {
            x: ev.clientX + document.body.scrollLeft - document.body.clientLeft,
            y: ev.clientY + document.body.scrollTop - document.body.clientTop
        }
    }
};
$.contains = function (a, b) {
    while (b != null && typeof (b.tagName) != "undefined") {
        if (b == a) return true;
        b = b.parentNode
    }
    return false
};
$.isPlainObject = function (a) {
    if (!a || Object.prototype.toString.call(a) !== "[object Object]" || a.nodeType || a.setInterval) return false;
    if (a.constructor && !Object.prototype.hasOwnProperty.call(a, "constructor") && !Object.prototype.hasOwnProperty.call(a.constructor.prototype, "isPrototypeOf")) return false;
    var b;
    for (b in a);
    return b === w || aa.call(a, b)
};
$.isArray = function (obj) {
    return Object.prototype.toString.call(obj) === '[object Array]'
};
$.isFunction = function (a) {
    return Object.prototype.toString.call(a) === "[object Function]"
};
$.extend = $.fn.extend = function () {
    var a = arguments[0] || {}, b = 1,
     d = arguments.length,
     f = false,
     e, j, i, o;
    if (typeof a === "boolean") {
        f = a;
        a = arguments[1] || {};
        b = 2
    }
    if (typeof a !== "object" && !$.isFunction(a)) a = {};
    if (d === b) {
        a = this;
        --b
    }
    for (; b < d; b++)
        if ((e = arguments[b]) != null)
            for (j in e) {
                i = a[j];
                o = e[j];
                if (a !== o)
                    if (f && o && ($.isPlainObject(o) || $.isArray(o))) {
                        i = i && ($.isPlainObject(i) || $.isArray(i)) ? i : $.isArray(o) ? [] : {};
                        a[j] = $.extend(f, i, o)
                    }
                    else if (o !== undefined) a[j] = o
            }
    return a
};
$.cookie = {
    set: function (name, value, days) {
        var exp = new Date();
        exp.setTime(exp.getTime() + days * 24 * 60 * 60 * 1000);
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/"
    },
    get: function (name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg)) return unescape(arr[2]);
        else return null
    },
    del: function (name) {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = $.cookie.get(name);
        if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString()
    }
};
$.loadStyle = function (id, url) {
    var css = document.createElement('LINK');
    css.type = "text/css";
    css.rel = "stylesheet";
    css.media = "all";
    css.id = id;
    css.href = url;
    var head = document.getElementsByTagName("HEAD")[0];
    head.appendChild(css)
};
$.removeStyle = function (obj) {
    var head = document.getElementsByTagName("HEAD")[0];
    head.removeChild(obj.elem)
}, $.loadScript = function (id, url, callback) {
    if (!document.getElementById(id)) {
        var script = document.createElement("SCRIPT");
        script.id = url;
        script.src = url;
        script.type = "text/javascript";
        var head = document.getElementsByTagName("HEAD")[0];
        head.appendChild(script);
        if (callback != null) {
            script.onreadystatechange = function () {
                if (script.readyState == "loaded") callback()
            };
            script.onload = function () {
                callback()
            }
        }
    }
    else if (callback != null) callback()
};
$.domReady = (function () {
    var load_events = [],
     load_timer, script, done, exec, old_onload, init = function () {
         done = true;
         clearInterval(load_timer);
         while (exec = load_events.shift()) exec();
         if (script) script.onreadystatechange = ''
     };
    return function (func) {
        if (done) return func();
        if (!load_events[0]) {
            if (document.addEventListener) document.addEventListener("DOMContentLoaded", init, false);
            if (/WebKit/i.test(navigator.userAgent)) {
                load_timer = setInterval(function () {
                    if (/loaded|complete/.test(document.readyState)) init()
                }, 10)
            }
            old_onload = window.onload;
            window.onload = function () {
                init();
                if (old_onload) old_onload()
            }
        }
        load_events.push(func)
    }
})();
$.request = {
    url: location.href.toLowerCase(),
    queryString: function (key) {
        var q = location.search.toLowerCase().substring(1).split('&');
        for (i = 0; i < q.length; i++) {
            var s = q[i].split("=");
            if (s.length == 2) {
                if (s[1].substring(s[1].length - 1) == "#") s[1] = s[1].substring(0, s[1].length - 1);
                if (s[0].toLowerCase() == key.toLowerCase()) return s[1]
            }
        }
        return null
    },
    host: location.hostname
};
$.array = {
    filter: function (array) {
        var MyArray = new Array();
        for (i = 0; i < array.length; i++) {
            var isRepeat = false;
            for (n = 0; n < MyArray.length; n++) {
                if (MyArray[n] == array[i]) isRepeat = true
            }
            if (!isRepeat) MyArray[MyArray.length] = array[i]
        }
        return MyArray
    },
    find: function (arr, o) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] == o) return i
        }
        return -1
    },
    serialize: function (arr) {
        var parms = "";
        var i = 0;
        for (var key in arr) {
            ++i;
            parms += key + "=" + arr[key] + "&"
        };
        if (i > 0) parms = parms.substring(0, parms.length - 1);
        try {
            return parms
        }
        finally {
            parms = null;
            i = null
        }
    }
};
$.body = function () {
    return $(document.body)
};
$.newElement = function (tagName, attr) {
    var el = document.createElement(tagName);
    if (attr == null) return $(el);
    if (attr.className) el.className = attr.className;
    if (attr.id) el.id = attr.id;
    if (attr.html) el.innerHTML = attr.html;
    var s = el.style;
    if (attr.position) s.position = attr.position;
    if (attr.width) s.width = typeof (attr.width) == "string" ? attr.width : attr.width + "px";
    if (attr.height) s.height = typeof (attr.height) == "string" ? attr.height : attr.height + "px";
    if (attr.top) s.top = attr.top + "px";
    if (attr.left) s.left = attr.left + "px";
    return $(el)
};
$.parseHTML = function (htmlStr, fragment) {
    if (fragment == null) {
        fragment = document.createDocumentFragment()
    }
    var div = document.createElement("DIV");
    var reg = /^<(\w+)\s*\/?>$/;
    htmlStr += "";
    var match = reg.exec(htmlStr);
    if (match) {
        return [document.createElement(match[1])]
    }
    var tagWrap = {
        option: ["select"],
        optgroup: ["select"],
        tbody: ["table"],
        thead: ["table"],
        tfoot: ["table"],
        tr: ["table", "tbody"],
        td: ["table", "tbody", "tr"],
        th: ["table", "thead", "tr"],
        legend: ["fieldset"],
        caption: ["table"],
        colgroup: ["table"],
        col: ["table", "colgroup"],
        li: ["ul"],
        link: ["div"]
    };
    for (var param in tagWrap) {
        var tw = tagWrap[param];
        tw.pre = "<" + tw.join("><") + ">";
        tw.post = "</" + tw.reverse().join("></") + ">"
    }
    reg = /<\s*([\w\:]+)/;
    match = reg.exec(htmlStr);
    var tag = match ? match[1].toLowerCase() : "";
    if (match && tagWrap[tag]) {
        var wrap = tagWrap[tag];
        div.innerHTML = wrap.pre + htmlStr + wrap.post;
        n = wrap.length;
        while (--n >= 0) div = div.lastChild
    }
    else {
        div.innerHTML = htmlStr
    } if (tagWrap[tag]) {
        var ownInsert = tagWrap[tag].join('').indexOf("tbody") !== -1,
         tbody = div.getElementsByTagName("tbody"),
         autoInsert = tbody.length > 0;
        if (!ownInsert && autoInsert) {
            for (var i = 0, n = tbody.length; i < n; i++) {
                if (!tbody[i].childNodes.length) tbody[i].parentNode.removeChild(tbody[i])
            }
        }
    }
    reg = /^\s*/;
    match = reg.exec(htmlStr);
    if (match) div.insertBefore(document.createTextNode(match[0]), div.firstChild);
    if (fragment) {
        var firstChild;
        while ((firstChild = div.firstChild)) {
            fragment.appendChild(firstChild)
        }
        return fragment
    }
    return div.children
};
$.setAlphaImage = function (list) {
    if (userAgent.indexOf("msie 6.0") > -1) {
        for (var i = 0; i < list.length; i++) {
            var el = $(list[i]);
            var img = el.getStyle("backgroundImage").replace("url(\"", "").replace("\")", "");
            if (img.indexOf(".png") > -1) {
                el[0].style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod='scale',src='" + img + "')";
                el[0].style.backgroundImage = "none"
            }
        }
    }
};
$.verifyElement = function (item, alertType, checkempty) {
    if (item.style.display == "none" || item.disabled) return true;
    alertType = alertType == null ? 0 : alertType;
    checkempty = checkempty == null ? true : checkempty;
    var verify = item.getAttribute("verify");
    var must = item.getAttribute("must");
    var arr = null;
    var type = null;
    var msg = null;
    if (verify) {
        arr = verify.split(' ');
        type = arr[0];
        msg = arr[1]
    }
    var pattern;
    switch (type) {
        case "number":
            pattern = /^\d+$/;
            msg = msg == null ? "必须是数字" : msg;
            break;
        case "letter":
            pattern = /^[A-Za-z]+$/;
            msg = msg == null ? "必须是字母" : msg;
            break;
        case "numeric":
            msg = msg == null ? "必须是数值" : msg;
            pattern = /^\d+(.\d+)?$/;
            break;
        case "account":
            pattern = /^\w+$/;
            break;
        case "email":
            pattern = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            break;
        case "mobile":
            pattern = /^0*(13|15|18)\d{9}$/;
            break;
        case "phone":
            pattern = /^[0-9]{3,4}\-[0-9]{7,8}$/;
            break;
        case "zip":
            pattern = /^\d{6}$/;
            break;
        case "chinese":
            pattern = /^[\u4e00-\u9fa5]+$/;
            break;
        default:
            pattern = eval(type);
            break
    };
    var v = false;
    if (must == "1" && checkempty) {
        if (item.value == "") {
            v = false;
            msg = "不能为空"
        }
        else if (pattern != null) {
            v = pattern.test(item.value)
        }
        else {
            v = true
        }
    }
    else {
        if (item.value.length > 0 && pattern != null) v = pattern.test(item.value);
        else v = true
    } if (alertType == 1) {
        var arr = $(item.parentNode).find("span");
        var span;
        if (arr.length > 0) {
            span = $(arr[0])
        }
        else {
            span = $.newElement("span");
            $(item).insertAfter(span)
        }
        span.css(v ? "pass" : "alert");
        if (v) {
            span.html("√")
        }
        else {
            span.append(msg);
            item.value = "";
            item.focus()
        }
    }
    else if (!v) {
        alert(msg);
        item.value = "";
        item.focus()
    }
    return v
};
$.moveOption = function (mode, l, r, all) {
    var k = l.selectedIndex;
    if (k == -1 && (all == null || all == false)) return;
    var a;
    switch (mode) {
        case 0:
            {
                var rLen = r.length;
                var html = '';
                for (var i = l.length - 1; i >= 0; i--) {
                    itemL = l.options[i];
                    if (itemL.selected || all) {
                        var tmp = $.findOption(r, itemL.value);
                        if (!tmp) {
                            html = '<option value="' + itemL.value + '">' + itemL.innerHTML + '</option>' + html
                        }
                        l.removeChild(itemL)
                    }
                }
                $(r).append(html)
            }
            break;
        case 1:
            if (k == 0) return;
            a = l.options[k];
            var o = document.createElement("option");
            o.innerHTML = a.innerHTML;
            o.value = a.value;
            var b = l.options[k - 1];
            l.remove(k);
            l.insertBefore(o, b);
            l.selectedIndex = k - 1;
            break;
        case 2:
            a = l.options[k];
            if (k == l.length - 1) return;
            var c = l.options[k + 1];
            l.insertBefore(c, a);
            break
    }
};
$.copyOption = function (l, r, all) {
    var k = l.selectedIndex;
    if (k == -1 && (all == null || all == false)) return;
    var rLen = r.length;
    for (var i = 0; i < l.length; i++) {
        itemL = l.options[i];
        var html = '';
        if (itemL.selected || all) {
            var x = $.findOption(r, itemL.value);
            if (x != null) continue;
            html += '<option value="' + itemL.value + '">' + itemL.innerHTML + '</option>'
        }
        $(r).append(html)
    }
};
$.delOption = function (slt, all) {
    for (var i = slt.length - 1; i >= 0; i--) {
        var item = slt.options[i];
        if (all || item.selected) slt.removeChild(item)
    }
};
$.findOption = function (slt, val) {
    for (var i = slt.length - 1; i >= 0; i--) {
        if (slt.options[i].value == val) return slt.options[i]
    }
    return null
};
var Ajax = {
    get: function (url, callback, pars, async) {
        new _Ajax().open(url, pars, "GET", callback, async)
    },
    getXml: function (url, callback, pars, async) {
        new _Ajax().open(url, pars, "GET", callback, "xml", async)
    },
    post: function (url, callback, pars, resultFormat, async) {
        new _Ajax().open(url, pars, "POST", callback, resultFormat, async)
    },
    postForm: function (formId, callback, async) {
        var obj = document.getElementById(formId);
        new _Ajax().open(obj.action, $(obj).serialize(), "POST", callback, async)
    },
    postDiv: function (url, divId, callback, async) {
        new _Ajax().open(url, $("#" + divId).serialize(), "POST", callback, async)
    }
};
function _Ajax() {}
_Ajax.prototype = {
    open: function (url, parameter, method, callback, resultFormat, async) {
        async = async == null ? true : async;
        var req = (window.XMLHttpRequest) ? new XMLHttpRequest() : (window.ActiveXObject ? new ActiveXObject("Microsoft.XMLHTTP") : false);
        if (req != null) this.xmlHttp = req;
        else return;
        this.callback = callback;
        this.resultFormat = resultFormat == null ? "text" : resultFormat;
        var loader = this;
        this.xmlHttp.onreadystatechange = function () {
            loader.stateChange()
        };
        var data = '';
        if (typeof (parameter) == "string") data = parameter;
        else data = this.arrayToString(parameter); if (method == "GET") url = data == '' ? url : url + "?" + data;
        req.open(method, url, async);
        if (method == "POST") {
            req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
        }
        req.send(data);
        req = null;
        data = null
    },
    arrayToString: function (pars) {
        var parms = "";
        var i = 0;
        for (var key in pars) {
            ++i;
            parms += key + "=" + pars[key] + "&"
        };
        if (i > 0) parms = parms.substring(0, parms.length - 1);
        try {
            return parms
        }
        finally {
            parms = null;
            i = null
        }
    },
    stateChange: function () {
        var req = this.xmlHttp;
        if (req.readyState == 4 && this.callback != null) {
            if (req.status == 200) {
                this.xmlHttp = null;
                switch (this.resultFormat) {
                    case "xml":
                        this.callback(req.responseXML);
                        break;
                    case "text":
                        this.callback(req.responseText);
                        break;
                    case "resultText":
                        this.callback(req.responseText.split('|')[0]);
                        break
                }
            }
            else this.callback(null, req.status)
        }
        req = null
    }
};
String.prototype.toMoney = function (digits) {
    if (digits == null) digits = 2;
    var v = this.replace(/\,/g, "");
    if (v == '') return v;
    else v = parseFloat(v).toFixed(digits);
    var arr = v.split('.');
    var m = arr[0].replace(/(?=(?!\b)(?:\w{3})+$)/g, ",");
    return m + "." + arr[1]
};
Number.prototype.toMoney = function (digits) {
    var s = this.toString();
    return s.toMoney(digits)
};
Number.prototype.toChinese = function () {
    var numberValue = new String(Math.round(this * 100));
    var chineseValue = "";
    var String1 = "零壹贰叁肆伍陆柒捌玖";
    var String2 = "万仟佰拾亿仟佰拾万仟佰拾元角分";
    var len = numberValue.length;
    var Ch1;
    var Ch2;
    var nZero = 0;
    var String3;
    if (len > 15) {
        alert("超出计算范围");
        return ""
    }
    if (numberValue == 0) {
        chineseValue = "零元整";
        return chineseValue
    }
    String2 = String2.substr(String2.length - len, len);
    for (var i = 0; i < len; i++) {
        String3 = parseInt(numberValue.substr(i, 1), 10);
        if (i != (len - 3) && i != (len - 7) && i != (len - 11) && i != (len - 15)) {
            if (String3 == 0) {
                Ch1 = "";
                Ch2 = "";
                nZero = nZero + 1
            }
            else if (String3 != 0 && nZero != 0) {
                Ch1 = "零" + String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0
            }
            else {
                Ch1 = String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0
            }
        }
        else {
            if (String3 != 0 && nZero != 0) {
                Ch1 = "零" + String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0
            }
            else if (String3 != 0 && nZero == 0) {
                Ch1 = String1.substr(String3, 1);
                Ch2 = String2.substr(i, 1);
                nZero = 0
            }
            else if (String3 == 0 && nZero >= 3) {
                Ch1 = "";
                Ch2 = "";
                nZero = nZero + 1
            }
            else {
                Ch1 = "";
                Ch2 = String2.substr(i, 1);
                nZero = nZero + 1
            } if (i == (len - 11) || i == (len - 3)) {
                Ch2 = String2.substr(i, 1)
            }
        }
        chineseValue = chineseValue + Ch1 + Ch2
    }
    if (String3 == 0) {
        chineseValue = chineseValue + "整"
    }
    return chineseValue
};
String.prototype.toChinese = function () {
    var n = parseFloat(this.replace(/\,/g, ""));
    return n.toChinese()
};
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "")
};
String.prototype.checkStrong = function () {
    var password = this;
    if (password.length <= 6) return 0;
    var Modes = 0;
    for (i = 0; i < password.length; i++) {
        Modes |= _CharMode(password.charCodeAt(i))
    }
    return _bitTotal(Modes)
};
String.prototype.isDate = function () {
    var value = this;
    var ereg = /^(\d{1,4})(-|\/)(\d{1,2})(-|\/)(\d{1,2})$/;
    var r = value.match(ereg);
    if (r == null) {
        return false
    }
    var d = new Date(r[1], r[3] - 1, r[5]);
    var result = (d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[5]);
    return result
};
String.prototype.isDateTime = function () {
    var value = this;
    var ereg = /^(\d{1,4})(-|\/)(\d{1,2})(-|\/)(\d{1,2})\s{1}(\d{1,2})(:)(\d{1,2})(:)(\d{1,2})$/;
    return ereg.test(value)
};
String.prototype.toDate = function () {
    var arr = this.split(' ');
    var arr1 = arr[0].split('-');
    var tmp = arr1[1] + "-" + arr1[2] + "-" + arr1[0];
    if (arr.length > 1) tmp = tmp + " " + arr[1];
    return Date.parse(tmp)
};
String.prototype.getLength = function () {
    var cArr = this.match(/[^x00-xff]/ig);
    return this.length + (cArr == null ? 0 : cArr.length)
};
String.prototype.toTime = function () {
    var str = this;
    var a = str.split(':');
    return new Date(0, 0, 0, a[0], a[1], a[2])
};
String.prototype.getTotalSeconds = function () {
    var str = this;
    var t = str.toTime();
    var h = t.getHours() * 3600 + t.getMinutes() * 60 + t.getSeconds();
    return h
};
String.prototype.startWith = function (txt) {
    var s = this;
    if (s.length < txt.length) return false;
    if (s.substring(0, txt.length).toLowerCase() == txt.toLowerCase()) return true;
    else return false
};
String.prototype.padLeft = function (len, str) {
    var s = this;
    var i = len - s.length;
    if (i <= 0) return s;
    var tmp = "";
    for (var x = 0; x < i; x++) tmp += str;
    return tmp + s
};
String.prototype.isNumeric = function () {
    return /^\d+(.\d+)?$/.test(this)
};
String.prototype.isNumber = function () {
    return /^\d+?$/.test(this)
};
String.prototype.isNumberOrNumeric = function () {
    return /^-?\d+(\.\d+)?$/.test(this.replace(/,/g,""))
};
String.prototype.toNumeric = function () {
    return parseFloat(this.replace(/,/g, ''))
};
function _CharMode(iN) {
    if (iN >= 48 && iN <= 57) return 1;
    if (iN >= 65 && iN <= 90) return 2;
    if (iN >= 97 && iN <= 122) return 4;
    else return 8
};
function _bitTotal(num) {
    modes = 0;
    for (i = 0; i < 4; i++) {
        if (num & 1) modes++;
        num >>>= 1
    }
    return modes
};
var UI = {
    selectIndex: 0,
    autoOldValue: null,
    autoOldTime: new Date(),
    createMask: function () {
        var height = Math.max(document.documentElement.scrollHeight, document.body.scrollHeight);
        var m = $.newElement("div", {
            width: "100%",
            height: height,
            id: "simpleMask"
        });
        m.style.background = "#000000";
        m.opacity(0.5);
        $(document.body).append(m);
        this.closeMask = function () {
            document.body.removeChild(document.getElementById("simpleMask"))
        };
        return m
    },
    tabs: function (containerId, tabClassName, contentClassName, eventType) {
        eventType = eventType == null ? "mouseover" : eventType;
        var tabList = $("#" + containerId + "." + tabClassName);
        var divList = $("#" + containerId + "." + contentClassName);
        tabList.bindEvent(eventType, changeTabs);
        function changeTabs(e) {
            divList.hide();
            for (var i = 0; i < tabList.length; i++) {
                var obj = $(tabList[i]);
                obj.removeCss("hover");
                if (obj.contains($.event.src(e))) {
                    obj.addCss("hover");
                    $(divList[i]).show()
                }
            }
        }
    },
    accordion: function (containerId, tagName, openClass) {
        var list = $("#" + containerId + " " + tagName);
        list.bindEvent("click", changeAccordion);
        function changeAccordion(e) {
            for (var i = 0; i < list.length; i++) {
                var obj = $(list[i]);
                var id = obj.id.substring(9);
                var o = $("#" + id);
                if (obj.contains($.event.src(e))) {
                    if (obj.css().indexOf(openClass) > -1) {
                        obj.removeCss(openClass);
                        o.hide()
                    }
                    else {
                        obj.addCss(openClass);
                        o.show()
                    }
                }
            }
        }
    },
    star: function (containerId, onClass, number, clickHandler, showEffect) {
        var list = $("#" + containerId + " span");
        var container = $("#" + containerId);
        setNum(number);
        showEffect = showEffect == null ? true : showEffect;
        if (showEffect) {
            list.bindEvent("mouseover", function (e) {
                setNum($.event.src(e).id.substring(1))
            });
            container.bindEvent("mouseout", setNum)
        }
        function setNum(num) {
            num = typeof (num) == "string" ? num : number;
            for (var i = 0; i < list.length; i++) {
                var o = $(list[i]);
                if (i < num) o.css(onClass);
                else o.css("")
            }
        }
        if (clickHandler != null) list.bindEvent("click", clickHandler)
    }
};
UI.toggle = function (id, type, old, speed, callback) {
    speed = speed == null ? 10 : speed;
    var o = $("#" + id);
    o.status = o.isHidden() ? 0 : 1;
    if (callback != null) callback(o.status);
    var s = setInterval(loop, 5);
    function loop() {
        if (type == 'h') {
            if (o.height < old && o.status == 0) {
                o.show();
                o.height += speed;
                if (o.height >= old) o.height = old;
                o.size(o.width, o.height);
                if (o.height == old) {
                    window.clearInterval(s);
                    o.status = 1
                }
            }
            else if (o.status == 1) {
                o.height -= speed;
                if (o.height <= 1) o.height = 1;
                o.size(o.width, o.height);
                if (o.height == 1) {
                    o.hide();
                    window.clearInterval(s);
                    o.status = 0
                }
            }
        }
        else {
            if (o.width < old && o.status == 0) {
                o.show();
                o.width += speed;
                if (o.width >= old) o.width = old;
                o.size(o.width, o.height);
                if (o.width == old) {
                    window.clearInterval(s);
                    o.status = 1
                }
            }
            else if (o.status == 1) {
                o.width -= speed;
                if (o.width <= 1) o.width = 1;
                o.size(o.width, o.height);
                if (o.width == 1) {
                    o.hide();
                    window.clearInterval(s);
                    o.status = 0
                }
            }
        }
    }
};
UI.openForm = function (width, height, title, content, className, drag, root) {
    var w, h;
    if (/^\d+$/.test(width)) w = width + "px";
    else w = width.toString(); if (/^\d+$/.test(height)) h = height + "px";
    else h = height.toString(); if (className == null) className = "open";
    var tab = $("#tmpopen");
    if (tab[0]) _closeForm();
    var bd = root == null ? $.body() : root;
    var html = '<table class="open" id="tmpopen" style="position: absolute;width:' + w + ' " cellspacing="0" cellpadding="0"><tbody>';
    html += '<tr>';
    html += '<td class="a0"></td>';
    html += '<td class="b0"><div><h5 id="tmpopenh5">' + title + '</h5><a href="javascript:"></a></div></td>';
    html += '<td class="c0"></td>';
    html += '</tr><tr>';
    html += '<td class="a1"></td>';
    html += '<td class="b1" style="height:' + h + ';width:' + w + '">';
    if (typeof (content) == "string") {
        var htmlhead = content.substring(0, 3);
        if (htmlhead == "url") {
            var url = content.substring(4, content.length);
            html += '<iframe src="' + url + '" frameborder="0" scrolling="no" height="100%" width="100%"></iframe>'
        }
        else html += content
    }
    html += '</td>';
    html += '<td class="c1"></td>';
    html += '</tr><tr><td class="a2"></td><td class="b2"></td><td class="c2"></td></tr></tbody></table>';
    bd.append(html);
    if (drag) $("#tmpopenh5").drag("tmpopen");
    tab = $("#tmpopen");
    tab.position((document.documentElement.clientHeight - tab[0].offsetHeight) / 2 + $.scroll.top(), (document.documentElement.clientWidth - tab[0].offsetWidth) / 2);
    if (typeof (content) != "string") {
        $("#tmpopen.b1").insert(content);
        content.show()
    }
    function _closeForm() {
        var bd = $.body();
        if (typeof (content) != "string") {
            content.hide();
            bd.insert(content)
        }
        bd.remove(tab);
        var mask = document.getElementById("simpleMask");
        if (mask) document.body.removeChild(mask);
        $("select").show(0);
        if (typeof (frmMain) != "undefined" && frmMain.contentWindow)
            frmMain.contentWindow.document.body.focus()
        var listInput = window.document.getElementsByTagName("input");
        for (var i = 0; i < listInput.length; i++) {
            if (listInput[i].type != "text") continue;
            if (listInput[i].disabled) continue;
            listInput[i].focus();
        }
    };
    $("#tmpopen a").bindEvent("click", _closeForm);
    this.closeForm = _closeForm
};
UI.bindSelect = function (o, list, value) {
    value == null ? 0 : value;
    o = document.getElementById(o);
    var sObj = $(o);
    var children = 0;
    sObj.clearOptions();
    if (list) {
        for (var i = 0; i < list.length; i++) {
            var x = list[i];
            var item;
            if (x.id) item = new Option(x.name, x.id);
            else item = new Option(x, x); if (x.list) {
                children += 1;
                item.list = x.list
            }
            o.options.add(item)
        }
    }
    if (value) o.value = value;
    if (children > 0) {
        sObj.bindEvent("change", function () {
            var childList = o.options[this.selectedIndex].list;
            if (childList == "") childList = null;
            UI.bindSelect(sObj.attr("child"), childList, (childList == null) ? 0 : childList[0].id)
        })
    }
};
UI.autoCompleter = function (input, hidId, event, url, pars, confirmEvent, offsetX, offsetY) {
    offsetX = offsetX == null ? 0 : offsetX;
    offsetY = offsetY == null ? 0 : offsetY;
    var ul = $("#autobox");
    $(document.body).bindEvent("click", function () {
        ul.hide()
    });
    var oo = $(input);
    oo.bindEvent("blur", function () {
        ul.hide();
        ul.html("");
        if (confirmEvent) confirmEvent()
    });
    var pos = oo.position();
    var list;
    if (ul.elem == null) {
        ul = $.newElement("ul", {
            id: "autobox",
            className: "auto",
            position: "absolute"
        });
        $.body().append(ul)
    }
    else ul.show();
    ul.position(pos.top + oo.height + offsetY, pos.left + offsetX);
    var code = $.event.key(event);
    switch (code) {
        case 13:
            list = ul.find("li");
            input.value = list[UI.selectIndex].innerHTML;
            if (confirmEvent) confirmEvent(list[UI.selectIndex]);
            UI.selectIndex = 0;
            ul.html("");
            $("#autobox").hide();
            break;
        case 38:
            list = ul.find("li");
            if (UI.selectIndex > 0) {
                list.removeCss("hover");
                UI.selectIndex -= 1;
                list[UI.selectIndex].className = "hover";
                input.value = list[UI.selectIndex].innerHTML
            }
            break;
        case 40:
            list = ul.find("li");
            if (UI.selectIndex < list.length - 1) {
                list.removeCss("hover");
                UI.selectIndex += 1;
                list[UI.selectIndex].className = "hover";
                input.value = list[UI.selectIndex].innerHTML
            }
            break;
        default:
            if (hidId) hidId.value = "0";
            ul.html("");
            if (input.value == UI.autoOldValue) return;
            UI.autoOldValue = input.value;
            var timespan = new Date() - UI.autoOldTime;
            if (timespan < 500) setTimeout(postData, 500 - timespan);
            else postData();
            break
    }
    function postData() {
        UI.autoOldTime = new Date();
        Ajax.get(url, function (r) {
            r = eval(r);
            if (r == null || r.length == 0) return;
            for (var a = 0; a < r.length; a++) {
                var li = document.createElement("li");
                li.innerHTML = r[a].text;
                li.val = r[a].id;
                ul.elem.appendChild(li)
            }
            UI.selectIndex = 0;
            list = ul.find("li");
            list[0].className = "hover";
            list.bindEvent("mouseover", function () {
                list.removeCss("hover");
                this.className = "hover";
                input.value = this.innerHTML
            });
            list.bindEvent("mousedown", function () {
                if (confirmEvent) confirmEvent(this);
                ul.html("");
                $("#autobox").hide();
                UI.selectIndex = 0
            })
        }, pars)
    }
};
UI.combRows = function (id) {
    var tr = document.getElementById(id).getElementsByTagName("tr");
    for (var i = tr.length - 1; i > 0; i--) {
        var td = tr[i].getElementsByTagName("td");
        var prev = tr[i - 1].getElementsByTagName("td");
        var len = td.length;
        for (var j = td.length - 1; j >= 0; j--) {
            if (td[j].innerHTML == prev[j].innerHTML) {
                prev[j].setAttribute("rowSpan", parseInt(td[j].getAttribute("rowSpan")) + 1);
                td[j].parentNode.removeChild(td[j])
            }
        }
    }
};
UI.marqueeX = function (container, step, interval, step2, interval2) {
    var marquee = typeof (container) == "string" ? document.getElementById(container) : container;
    var box = marquee.getElementsByTagName("*")[0];
    if (box.offsetWidth < marquee.offsetWidth) return;
    box.innerHTML += box.innerHTML;
    var list = new Array();
    var span = 0;
    var s;
    var w;
    function loop() {
        var time = interval;
        marquee.scrollLeft += step;
        if (marquee.scrollLeft == (list.length * w / 2)) marquee.scrollLeft = 0;
        span += step;
        if (step2) {
            if (span == step2) {
                span = 0;
                time = interval2
            }
        }
        s = setTimeout(loop, time)
    };
    for (var i = 0; i < box.childNodes.length; i++) {
        if (box.childNodes[i].nodeType != 1) continue;
        list.push(box.childNodes[i]);
        box.childNodes[i].onmouseover = function () {
            clearTimeout(s)
        };
        box.childNodes[i].onmouseout = function () {
            loop()
        }
    }
    w = list[0].offsetWidth;
    box.style.width = list.length * (w + 1) + "px";
    loop()
};
UI.marqueeY = function (container, step, interval, step2, interval2) {
    var marquee = typeof (container) == "string" ? document.getElementById(container) : container;
    var box = marquee.getElementsByTagName("*")[0];
    if (box.offsetHeight < marquee.offsetHeight) return;
    box.innerHTML += box.innerHTML;
    var list = new Array();
    var s;
    var h;
    var span = 0;
    function loop() {
        var time = interval;
        marquee.scrollTop += step;
        if (marquee.scrollTop == (list.length * h / 2)) marquee.scrollTop = 0;
        span += step;
        if (step2) {
            if (span == step2) {
                span = 0;
                time = interval2
            }
        }
        s = setTimeout(loop, time)
    };
    for (var i = 0; i < box.childNodes.length; i++) {
        if (box.childNodes[i].nodeType != 1) continue;
        list.push(box.childNodes[i]);
        box.childNodes[i].onmouseover = function () {
            clearTimeout(s)
        };
        box.childNodes[i].onmouseout = function () {
            loop()
        }
    }
    h = list[0].offsetHeight;
    box.style.height = list.length * (h + 1) + "px";
    loop()
};
UI.table = function (id) {
    this.id = id;
    this.obj = $("#" + id);
    this.selectedArray = new Array();
    this.tbody = $(this.obj.find("tbody")[0]);
    this.checkbox = this.tbody.find(".checkbox");
    this.checkboxAll = $($($("#" + id + " thead")[0]).find(".checkbox")[0]);
    var self = this;
    this.checkboxAll.bindEvent("click", function () {
        self.selectedArray = new Array();
        for (var i = 0; i < self.checkbox.length; i++) {
            self.checkbox[i].checked = this.checked;
            self.selectedArray.push(self.checkbox[i].value)
        }
    });
    this.checkbox.bindEvent("click", function () {
        var index = $.array.find(self.selectedArray, this.value);
        if (this.checked) {
            if (index == -1) self.selectedArray.push(this.value)
        }
        else if (index > -1) {
            self.selectedArray.splice(index, 1)
        }
    });
    this.deleteAll = function (url) {
        if (confirm("确定要删除选中的项？") == false) return;
        var s = "";
        for (var i = 0; i < this.selectedArray.length; i++) s += this.selectedArray[i] + (i == this.selectedArray.length - 1 ? "" : ",");
        location.href = url + "&id=" + s + "&url=" + escape(location.href) + "&r=" + Math.random()
    }
};
UI.sortTD = function (td, colIndex, standard, setRank, selectedClassName) {
    standard = standard == null ? 0 : standard;
    var _s = standard == 0;
    td.sort = td.sort || 0;
    var tb = _s ? td.parentNode.parentNode.parentNode : td.parentNode.parentNode;
    var arr = new Array();
    var tbody = _s ? tb.getElementsByTagName("tbody")[0] : tb;
    var rows = tbody.rows;
    var index1 = _s ? 0 : 1;
    var index2 = standard >= 2 ? standard - 1 : 0;
    var rg = new RegExp(/<[^>]+>/g);
    for (var i = index1; i < rows.length - index2; i++) {
        arr[i] = rows[i];
        arr.sort(function (b, c) {
            var x = b.cells[colIndex].innerHTML.replace(rg, "").trim();
            var y = c.cells[colIndex].innerHTML.replace(rg, "").trim();
            var _x = parseFloat(x);
            var _y = parseFloat(y);
            if ((x.isDate() || x.isDateTime()) && (y.isDate() || y.isDateTime())) {
                if (td.sort == 1) return y.toDate() - x.toDate();
                else return x.toDate() - y.toDate()
            }
            else if (x.isNumberOrNumeric() && y.isNumberOrNumeric()) {
                x = x.replace(/,/g, "");
                y = y.replace(/,/g, "");
                if (td.sort == 1) return y - x;
                else return x - y
            }
            else if (_x.toString() != 'NaN' && _y.toString() != 'NaN') {
                if (td.sort == 1) return _y - _x;
                else return _x - _y
            }
            else {
                if (td.sort == 1) return x.localeCompare(y);
                else return y.localeCompare(x)
            }
        })
    }
    if (standard == 3) index2 = 1;
    for (var i = index1; i < arr.length - index2; i++) {
        if (setRank) rows[i].cells[0].innerText = (arr.length - i);
        if (selectedClassName) {
            for (var j = 0; j < arr[i].cells.length; j++) {
                arr[i].cells[j].className = arr[i].cells[j].oldClassName
            }
            arr[i].cells[colIndex].oldClassName = arr[i].cells[colIndex].className;
            arr[i].cells[colIndex].className = arr[i].cells[colIndex].className + " " + selectedClassName
        }
        $(tbody).insert(arr[i], _s ? 0 : 1)
    }
    td.sort = td.sort == 0 ? 1 : 0
};
UI.fixTable = function (tableId, width, height, divHeaderClass, divLeftClass, tdPaddingX, tdPaddingY, borderWidth, fixedColCount) {
    var oldtb = document.getElementById(tableId);
    var yScrollWidth = 0;
    var xScrollWidth = 0;
    if (oldtb.offsetHeight <= height) {
        height = oldtb.offsetHeight
    }
    if (oldtb.scrollWidth > width + 17) height += 17;
    var divTable = document.createElement("div");
    oldtb.parentNode.appendChild(divTable);
    $(divTable).insertBefore(oldtb);
    divTable.appendChild(oldtb);
    divTable.style.width = width + "px";
    divTable.style.height = height + "px";
    divTable.style.overflow = "auto";
    divTable.parentNode.style.position = "relative";
    divTable.parentNode.style.width = width + "px";
    if (divTable.scrollHeight > height) {
        yScrollWidth = 17
    }
    if (divTable.scrollWidth > width) {
        xScrollWidth = 17
    }
    var divHeader = document.createElement("div");
    var divHeaderCol = document.createElement("div");
    divTable.parentNode.appendChild(divHeader);
    divTable.parentNode.appendChild(divHeaderCol);
    divHeader.style.width = (width - yScrollWidth - borderWidth) + "px";
    divHeader.style.overflow = "hidden";
    divHeader.style.position = "absolute";
    divHeader.style.top = "0px";
    divHeader.style.left = ($.browser.msie ? 0 : borderWidth) + "px";
    divHeader.style.zIndex = 99;
    divHeader.className = divHeaderClass;
    divHeaderCol.style.overflow = "hidden";
    divHeaderCol.style.position = "absolute";
    divHeaderCol.style.top = "0px";
    divHeaderCol.style.left = ($.browser.msie ? 0 : borderWidth) + "px";
    divHeaderCol.style.zIndex = 9999;
    divHeaderCol.className = divHeaderClass;
    var tdWidthTemp, fixHeaderWidth, tdNumTemp;
    var htmlTpl, html, tdHtml, fixTdHtml, fixTableHtml;
    tdWidthTemp = fixHeaderWidth = tdNumTemp = 0;
    htmlTpl = html = tdHtml = fixTdHtml = fixTableHtml = "";
    var tdHeader = oldtb.getElementsByTagName("tr")[0].childNodes;
    var headerWidth = (oldtb.offsetWidth + ($.browser.msie ? borderWidth : 0));
    htmlTpl += '<table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;width:[TableWidth]px">';
    htmlTpl += '<tbody>';
    htmlTpl += '<tr>';
    htmlTpl += '[TdContent]';
    htmlTpl += '</tr>';
    htmlTpl += '</tbody>';
    htmlTpl += '</table>';
    for (var i = 0; i < tdHeader.length; i++) {
        if (tdHeader[i].tagName) {
            var colspan = tdHeader[i].getAttribute("colspan");
            colspan = colspan == null ? '' : (' colspan="' + colspan + '" ');
            tdWidthTemp = (tdHeader[i].offsetWidth - tdPaddingX - borderWidth);
            tdHtml += '<td ' + colspan + ' style="width:' + tdWidthTemp + 'px; height:' + (tdHeader[i].offsetHeight - tdPaddingY - borderWidth) + 'px;">' + tdHeader[i].innerHTML + '</td>';
            if (tdNumTemp < fixedColCount) {
                fixHeaderWidth += tdWidthTemp;
                fixTdHtml = tdHtml
            }
            tdNumTemp += 1
        }
    }
    fixHeaderWidth += 2;
    divHeaderCol.style.width = fixHeaderWidth;
    html = htmlTpl.replace("[TableWidth]", headerWidth).replace("[TdContent]", tdHtml);
    fixTableHtml = htmlTpl.replace("[TableWidth]", fixHeaderWidth).replace("[TdContent]", fixTdHtml);
    divHeader.innerHTML = html;
    divHeaderCol.innerHTML = fixTableHtml;
    var divCol = document.createElement("div");
    divTable.parentNode.appendChild(divCol);
    divCol.style.height = (height - xScrollWidth - borderWidth) + "px";
    divCol.style.overflow = "hidden";
    divCol.style.position = "absolute";
    divCol.style.top = $.browser.msie ? "-1px" : "0px";
    divCol.style.left = "0px";
    divCol.className = divLeftClass;
    var tdLeft = $(oldtb).find(".fixedcol");
    html = "";
    html += '<table cellspacing="0" cellpadding="0" border="0" style="border-collapse: collapse;">';
    html += '<tbody>';
    var tmp = 0;
    for (var i = 0; i < tdLeft.length; i++) {
        if (i % fixedColCount == 0) {
            html += '<tr>'
        }
        html += '<td style="width:' + (tdLeft[i].offsetWidth - tdPaddingX - borderWidth) + 'px;height:' + (tdLeft[i].offsetHeight - tdPaddingY - borderWidth) + 'px;' + (i == 0 ? "border-top:none" : "") + '">' + tdLeft[i].innerHTML + '</td>';
        tmp++;
        if (tmp == fixedColCount) {
            html += '</tr>';
            tmp = 0
        }
    }
    html += '</tbody>';
    html += '</table>';
    divCol.innerHTML = html;
    $(divTable).bindEvent("scroll", function (e) {
        divHeader.scrollLeft = this.scrollLeft;
        divCol.scrollTop = this.scrollTop
    })
};
UI.openWindow = function (url, width, height, showscroll) {
    var s = "yes";
    if (showscroll == false) s = "no";
    var l = Math.ceil((window.screen.width - width) / 2);
    var t = Math.ceil((window.screen.height - height) / 2) - 30;
    return window.open(url, "_blank", "left=" + l + ",top=" + t + ",height=" + height + ",width=" + width + ",toolbar=no,status=no,resizable=yes,location=no,scrollbars=" + s)
};
