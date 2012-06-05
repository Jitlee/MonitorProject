/*var BROWSER = {};
var USERAGENT = navigator.userAgent.toLowerCase();
browserVersion({'ie':'msie','firefox':'','chrome':'','opera':'','safari':'','mozilla':'','webkit':'','maxthon':'','qq':'qqbrowser'});
if(BROWSER.safari) {
BROWSER.firefox = true;
}
BROWSER.opera = BROWSER.opera ? opera.version() : 0;

function browserVersion(types) {
var other = 1;
for(i in types) {
var v = types[i] ? types[i] : i;
if(USERAGENT.indexOf(v) != -1) {
var re = new RegExp(v + '(\\/|\\s)([\\d\\.]+)', 'ig');
var matches = re.exec(USERAGENT);
var ver = matches != null ? matches[2] : 0;
other = ver !== 0 && v != 'mozilla' ? 0 : other;
}else {
var ver = 0;
}
eval('BROWSER.' + i + '= ver');
}
BROWSER.other = other;
}*/

// 添加事件
function _attachEvent(obj, evt, func, eventobj) {
    eventobj = !eventobj ? obj : eventobj;
    if (obj.addEventListener) {
        obj.addEventListener(evt, func, false);
    } else if (eventobj.attachEvent) {
        obj.attachEvent('on' + evt, func);
    }
}

// 移出事件
function _detachEvent(obj, evt, func, eventobj) {
    eventobj = !eventobj ? obj : eventobj;
    if (obj.removeEventListener) {
        obj.removeEventListener(evt, func, false);
    } else if (eventobj.detachEvent) {
        obj.detachEvent('on' + evt, func);
    }
}

function getClientSize() {
    var width = 0, height = 0;
    if (typeof (window.innerWidth) == 'number') {
        //Non-IE
        width = window.innerWidth;
        height = window.innerHeight;
    } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
        //IE 6+ in 'standards compliant mode'
        width = document.documentElement.clientWidth;
        height = document.documentElement.clientHeight;
    } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
        //IE 4 compatible
        width = document.body.clientWidth;
        height = document.body.clientHeight;
    }
    return { "width": width, "height": height };
}

var originStyle = {};
var _obj;
function setFullScreen(obj) {
    _obj = obj;
    var htmls = document.getElementsByTagName('html');
    if (htmls.length > 0) {
        h = htmls[0];
        var originOverflow = h.style.overflow;
        if (!originStyle.isFullScreenMode) {
            originStyle.position = obj.style.position;
            originStyle.top = obj.style.top;
            originStyle.left = obj.style.left;
            originStyle.height = obj.style.height;
            originStyle.width = obj.style.width;

            var clientSize = getClientSize();
            obj.style.position = "absolute";
            obj.style.top = 0;
            obj.style.left = 0;
            obj.style.height = clientSize.height + "px";
            obj.style.width = clientSize.width + "px";
            originStyle.isFullScreenMode = true;
            h.style.overflow = "hidden";

            _attachEvent(window, "resize", onSizeChanged);
        } else {
            obj.style.position = originStyle.position;
            obj.style.top = originStyle.top;
            obj.style.left = originStyle.left;
            obj.style.height = originStyle.height;
            obj.style.width = originStyle.width;
            originStyle.isFullScreenMode = false;
            h.style.overflow = "";
            _detachEvent(window, "resize", onSizeChanged);
        }
    }
}

function onSizeChanged() {
    var clientSize = getClientSize();
    _obj.style.height = clientSize.height + "px";
    _obj.style.width = clientSize.width + "px";
}
