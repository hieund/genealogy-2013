/*Creator       :Hoàng Thái Huy
**Des           :library Using common
*/

(function () {
    $('select[data-select="true"]').live('change', function () {
        if (parseInt($(this).find('option:selected').val()) != -1) {
            $(this).css('border-color', '#CCC');
            var parent = $(this).parent();
            if (parent.find('.ui-combobox').length > 0) {
                parent.find('.ui-combobox').find('input').css('border-color', '#CCC');
            }
        }
    });

    $('[data-required="true"]').live('keyup', function () {
        if ($(this).val().length > 0) {
            $(this).removeClass('input-validation-error');
        }
    });

    $('[data-number="true"]').live('keyup', function () {
        objGlobal = new Global();
        if (!objGlobal.isNumber($(this).val().trim())) {
            $(this).val(parseInt($(this).val()));
        }
    });

    $('[data-currency="true"]').live('keyup', function () {
        objGlobal = new Global();
        if (!isNaN(parseFloat($(this).val().replace(/,/gi, '')))) {
            var value = parseFloat($(this).val().replace(/,/gi, '')).toString();
            $(this).val(objGlobal.currencyToString(value, ','));
        }
        else if (parseInt($(this).val().replace(/,/gi, '')) < 0) {
            $(this).val('0');
        }
        else {
            $(this).val('0');
        }

    });

    $('[data-currency="true"]').live('focusout', function () {
        if ($(this).val().toString().trim() == '') {
            $(this).val('0');
        }
    });

    $('[data-key-num="true"]').live('keyup', function () {
        var length = $(this).val().length;
        $('#' + $(this).data('label')).text(length);
    });

    $('[data-filter-java="true"]').live('focusout', function () {
        objGlobal = new Global();
        var strValue = $(this).val().trim();
        strValue = objGlobal.filterJavaScript(strValue);
        $(this).val(strValue);
    });

})();

function Global() { }
Global.prototype.callBack = '';
Global.prototype.isHandlerCallBack = false;
/*kiểm tra mã số thuế có hợp lệ hay không*/
Global.prototype.checkTaxCode = function (strMST) {
    strMST = strMST.substr(0, 10);
    if (!this.isNumber(strMST)) {
        return false;
    }
    else {
        var objArray = [31, 29, 23, 19, 17, 13, 7, 5, 3];
        var intTotal = 0;
        for (var i = 0; i < strMST.length - 1; i++) {
            intTotal += parseInt(strMST.substr(i, 1)) * objArray[i];
        }
        if (parseInt(strMST.substr(9, 1)) == (10 - intTotal % 11)) {
            return true;
        }
        else
            return false;
    }
}

/*kiểm tra 1 chuỗi có phải là số hay không*/
Global.prototype.isNumber = function (strNumber) {
    var regEx = new RegExp(/^ *[0-9]+ *$/);
    if (strNumber.trim().length > 0 && regEx.test(strNumber.trim())) {
        return true;
    }
    else
        return false
}

Global.prototype.isMobile = function (strNumber) {
    var regEx = new RegExp(/^ *[0-9]+ *$/);
    if (strNumber.trim().length > 9 && regEx.test(strNumber.trim())) {
        return true;
    }
    else
        return false
}

Global.prototype.isPID = function (strNumber) {
    var regEx = new RegExp(/^ *[0-9]+ *$/);
    if (strNumber.trim().length > 8 && regEx.test(strNumber.trim())) {
        return true;
    }
    else
        return false
}

/*kiểm tra ràng buộc nhập liêu - nhận vào 1 hoặc 2 tham số đối số 1 là ID element, đối số 2 là chuỗi placeholder của element*/
Global.prototype.requireInput = function () {
    if (arguments.length == 1 && $("#" + arguments[0]).length > 0)
        return $("#" + arguments[0]).val().toString().trim().length > 0;
    else if (arguments.length == 2 && $("#" + arguments[0]).length > 0) {
        return ($("#" + arguments[0]).val().trim() != '' && $("#" + arguments[0]).val().trim() != arguments[1].trim());
    }
    else
        return false;
}
/*chuyển về định dạng tiền tệ */
Global.prototype.currencyToString = function (currency, sepate) {
    if (currency.trim().length > 0) {
        var temp = currency.trim().length;
        var strResult = "";
        var temp1 = currency.trim();
        var temp3 = "";
        while (temp > 3) {
            temp1 = currency.trim().substring(0, temp - 3);
            var inttam = temp - 3;
            var temp2 = currency.trim().substring(inttam, temp);
            temp -= 3;
            var temp3 = strResult;
            strResult = sepate + temp2;
            strResult += temp3;
        }
        temp3 = strResult;
        strResult = temp1 + temp3;
        return strResult;
    }
    else
        return '';
}
/*kiểm tra chuỗi có phải là Email hay không */
Global.prototype.isEmail = function (IDctrl) {
    var regEx = new RegExp(/^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/);
    if ($("#" + IDctrl).length > 0) {
        var str = $("#" + IDctrl).val();
        if (regEx.test(str.trim())) {
            return true;
        }
    }
    return false;
}
/*kiểm tra ký tự đặc biệt */
Global.prototype.checkCharSpecial = function (IDctrl) {
    var regEx = new RegExp(/^ *[a-zA-Z_0-9\s]+ *$/);
    if ($("#" + IDctrl).length > 0) {
        var str = $("#" + IDctrl).val();
        if (regEx.test(str.trim())) {
            return true;
        }
    }
    return false;
}
/*kiểm tra ràng buộc nhập liêu - truyền vào ID các element muốn kiểm tra */
Global.prototype.requireListInput = function () {
    for (var i = 0; i < arguments.length; i++) {
        if (!this.requireInput(arguments[i])) {
            return false;
        }
    }
    return true;
}
Global.prototype.focus = function (obj, temp) {
    if ($(obj).val().trim() == temp)
        $(obj).val('');
}
Global.prototype.blur = function (obj, temp) {
    if ($(obj).val().trim() == '')
        $(obj).val(temp);
}
Global.prototype.showPopup = function (idCtrl, idCtrl1, isCalHeight) {
    if (isCalHeight == true) {
        $('#' + idCtrl1).css({ 'top': ($(window).height() - $('#' + idCtrl1).outerHeight()) / 2 });
    }
    $('#' + idCtrl1).css({ 'left': ($(window).width() - $('#' + idCtrl1).outerWidth()) / 2 });
    $('#' + idCtrl).fadeIn('fast',
    function () {
        $('#' + idCtrl1).fadeIn('fast', function () {
        });
    });
}
Global.prototype.closePopup = function (idCtrl, idCtrl1) {
    $('#' + idCtrl1).fadeOut('fast', function () {
        $('#' + idCtrl).fadeOut('fast');
    });
}
Global.prototype.showMess = function (title, content, isClose) {
    var strResult = '';
    var display = 'style="display:block;"';
    if (isClose == false) {
        display = 'style="display:none;"';
    }
    strResult += '<div class="pu-bg" id="pu-bg">';
    strResult += '</div>';
    strResult += '<div class="pu-main" id="pu-main-content">';
    strResult += '<div class="close-pu" ' + display + ' onclick="closeMessGlobal();">';
    strResult += '</div>';
    strResult += '<div class="j-title" draggable="true">' + title + '</div>';
    strResult += '<div class="j-content">';
    strResult += content;
    strResult += '</div>';
    if (isClose == undefined || isClose == true) {
        strResult += '<div class="j-btn-close">';
        strResult += '<div class="right"> ';
        strResult += '<input type="submit" class="btn" value="Đóng"  onclick="closeMessGlobal();"/>';
        strResult += ' </div>';
        strResult += '<div class="clr">';
        strResult += ' </div>';
        strResult += '</div>';
    }
    strResult += '</div>';
    $('body').append(strResult);
    $('#pu-main-content').css({ 'left': ($(window).width() - $('#pu-main-content').outerWidth()) / 2 });
    $('#pu-bg').fadeIn('fast', function () {
        $('#pu-main-content').fadeIn('fast');
    });
}
/*function nay thay đồi tuy theo object - it dung chung - han che dung - (cach dat tên object)- override function closeMessGlobal() */
function closeMessGlobal() {
    objGlobal.closeMess();
}

Global.prototype.showLoading = function () {
    this.showMess('Thông báo', '<div class="a" style="width:100%;">Đang gửi thông tin...</div><div style="width:100%;text-align:center; margin-top: 5px;"><img src="' + Root + '/Content/images/loading.gif" alt="Vui lòng chờ..." /></div><div class="clr"></div>', false);
}

Global.prototype.closeMess = function () {
    $('#pu-main-content').remove();
    $('#pu-bg').remove();
    if (this.isHandlerCallBack == true) {
        this.callBack();
        this.isHandlerCallBack = false;
    }
}

Global.prototype.deTectBrowser = function () {
    var str = navigator.userAgent;
    if (str.toLowerCase().indexOf('chrome') > -1) {
        return 'chrome';
    }
    else if (str.toLowerCase().indexOf('firefox') > -1) {
        return 'firefox';
    }
    else if (str.toLowerCase().indexOf('opera') > -1) {
        return 'opera';
    }
    else {
        return 'undefined';
    }
}

/*compare lon hon - idctrl hoặc ngày*/
Global.prototype.compareDate = function (idCtrlCompare, idCtrlToCompare, strFormat, separate) {
    if (strFormat == null)
        strFormat = 'dd/mm/yyyy';
    if (separate == null)
        separate = '/';
    strFormat = strFormat.toLowerCase();
    var day = 0;
    var month = 0;
    var year = 0;
    var arrtemplateCompare = strFormat.split(' ');
    var arrtemplate = arrtemplateCompare[0].split(separate);;
    var stringCompare = '';
    var dateCompare;
    var dateToCompare;
    try {
        for (var i = 0; i < arrtemplate.length; i++) {
            if (arrtemplate[i].indexOf('d') > -1) {
                day = i;
            }
            if (arrtemplate[i].indexOf('m') > -1) {
                month = i;
            }
            if (arrtemplate[i].indexOf('y') > -1) {
                year = i;
            }
        }
        if ($('#' + idCtrlCompare).length > 0) {
            stringCompare = $('#' + idCtrlCompare).val();
        }
        else {
            stringCompare = idCtrlCompare;
        }
        arrDateCompare = stringCompare.split(' ');
        var arrDate = arrDateCompare[0].split(separate);
        if (arrDateCompare.length == 1) {
            dateCompare = new Date(arrDate[month] + '/' + arrDate[day] + '/' + arrDate[year]);
        }
        else {
            dateCompare = new Date(arrDate[month] + '/' + arrDate[day] + '/' + arrDate[year] + ' ' + arrDateCompare[1]);
        }
        if (idCtrlToCompare == null) {
            dateToCompare = new Date();
        }
        else {
            if ($('#' + idCtrlToCompare).length > 0) {
                stringCompare = $('#' + idCtrlToCompare).val();
            }
            else {
                stringCompare = idCtrlToCompare;
            }
            arrDateCompare = stringCompare.split(' ');
            var arrDate = arrDateCompare[0].split(separate);
            if (arrDateCompare.length == 1) {
                dateToCompare = new Date(arrDate[month] + '/' + arrDate[day] + '/' + arrDate[year]);
            }
            else {
                dateToCompare = new Date(arrDate[month] + '/' + arrDate[day] + '/' + arrDate[year] + ' ' + arrDateCompare[1]);
            }
        }
        return dateCompare.getTime() >= dateToCompare.getTime();
    }
    catch (e) {
        return false;
    }
}

/*compare lon hon - idctrl hoặc ngày*/
Global.prototype.compareDay = function (idCtrlCompare, idCtrlToCompare, intdate, strFormat, separate) {
    if (strFormat == null)
        strFormat = 'dd/mm/yyyy';
    if (separate == null)
        separate = '/';
    strFormat = strFormat.toLowerCase();
    var day = 0;
    var month = 0;
    var year = 0;
    var arrtemplateCompare = strFormat.split(' ');
    var arrtemplate = arrtemplateCompare[0].split(separate);;
    var stringCompare = '';
    var dayCompare;
    var dayToCompare;
    try {
        for (var i = 0; i < arrtemplate.length; i++) {
            if (arrtemplate[i].indexOf('d') > -1) {
                day = i;
            }
            if (arrtemplate[i].indexOf('m') > -1) {
                month = i;
            }
            if (arrtemplate[i].indexOf('y') > -1) {
                year = i;
            }
        }
        if ($('#' + idCtrlCompare).length > 0) {
            stringCompare = $('#' + idCtrlCompare).val();
        }
        else {
            stringCompare = idCtrlCompare;
        }
        arrtemplateCompare = stringCompare.split(' ');
        arrtemplate = arrtemplateCompare[0].split(separate);
        dayCompare = parseInt((arrtemplate[year] * 365)) + parseInt((arrtemplate[month] * 30)) + parseInt(arrtemplate[day]);
        if ($('#' + idCtrlToCompare).length > 0) {
            stringCompare = $('#' + idCtrlToCompare).val();
        }
        else {
            stringCompare = idCtrlToCompare;
        }
        arrtemplateCompare = stringCompare.split(' ');
        arrtemplate = arrtemplateCompare[0].split(separate);
        dayToCompare = parseInt((arrtemplate[year] * 365)) + parseInt((arrtemplate[month] * 30)) + parseInt(arrtemplate[day]);
        return dayCompare - dayToCompare <= intdate;
    }
    catch (e) {
        return false;
    }
}


Global.prototype.validationSelect = function (arrayIDctrl) {
    var bol = true;
    var index = -1;
    for (var i = 0; i < arrayIDctrl.length; i++) {
        if (parseInt($('#' + arrayIDctrl[i]).find('option:selected').val()) == -1 || $('#' + arrayIDctrl[i]).find('option:selected').val() == undefined) {
            $('#' + arrayIDctrl[i]).css('border-color', 'red');
            var parent = $('#' + arrayIDctrl[i]).parent();
            if (parent.find('.ui-combobox').length > 0) {
                parent.find('.ui-combobox').find('input').css('border-color', 'red');
            }
            bol = false;
            if (i == -1) {
                index = i;
            }
        }
    }
    if (index > -1) {
        $('#' + arrayIDctrl[index]).focus();
    }
    return bol;
}

Global.prototype.validation = function (arrayIDctrl) {
    var bol = true;
    var index = -1;
    for (var i = 0; i < arrayIDctrl.length; i++) {
        if (!this.requireInput(arrayIDctrl[i])) {
            $('#' + arrayIDctrl[i]).addClass('input-validation-error');
            bol = false;
            if (index == -1) {
                index = i;
            }
        }
    }
    if (index > -1) {
        $('#' + arrayIDctrl[index]).focus();
    }
    return bol;
}

Global.prototype.aJaxCall = function (url, dataIni, beginFunc, funcCallBack) {
    if (beginFunc == null || beginFunc == undefined)
        beginFunc = function () {
            return objGlobal.showLoading();
        };
    if (funcCallBack == null || funcCallBack == undefined)
        funcCallBack = function () {
            return objGlobal.closeMess();
        };
    $.ajax({
        type: "POST",
        url: url,
        cache: false,
        beginSend: beginFunc(),
        data: dataIni,
        success: function (arg) { funcCallBack(arg); },
        error: function () {
        },
        statusCode: {
            302: function () {
                reSetLogin();
            },
            0: function () {
                reSetLogin();
            }
        }
    });
}

Global.prototype.colorToRGB = function (color) {
    if (color.substr(0, 1) === '#') {
        return color;
    }
    var digits = /(.*?)rgb\((\d+), (\d+), (\d+)\)/.exec(color);
    var red = parseInt(digits[2]);
    var green = parseInt(digits[3]);
    var blue = parseInt(digits[4]);

    var rgb = blue | (green << 8) | (red << 16);
    return [red, green, blue];
};

Global.prototype.addData = function (lstArray) {
    for (var i = 0; i < lstArray.length; i++) {
        $('#' + lstArray[i][0]).data('data', lstArray[i][1]);
    }
}

Global.prototype.filterJavaScript = function (strContent) {
    var filter = new RegExp(/javacsript|onload|onclick|onblur|onfocus|var|script/gi);
    var arrFilter = ['javacsript', 'onload', 'onclick', 'onblur', 'onfocus', 'var', 'script'];
    while (filter.test(strContent.trim())) {
        for (var i = 0; i < arrFilter.length; i++) {
            if (strContent.toLowerCase().indexOf(arrFilter[i]) > -1) {
                strContent = this.replaceJava(strContent, arrFilter[i], strContent.toLowerCase().indexOf(arrFilter[i]));
            }
        }
    }
    return strContent;
}
Global.prototype.replaceJava = function (strContent, charReplace, index) {
    var tagOpen = 0;
    var indexOpen = index;
    var indexClose = index + charReplace.length;
    for (var i = index; i > 0; i--) {
        if (strContent.substring(i, i - 1) == '<' || strContent.substring(i, i - 1) == '&lt;' || strContent.substring(i, i + 1) == '</' || strContent.substring(i, i + 1) == '/&lt;') {
            indexOpen = i - 1;
            break;
        }
    }
    for (var j = index; j < strContent.length; j++) {
        if (strContent.substring(j, j + 1) == '/>' || strContent.substring(j, j + 1) == '/&gt;') {
            if (tagOpen == 0) {
                indexClose = j + 1;
                break;
            }
        }
    }
    if (indexClose == -1) {
        for (var j = index; j < strContent.length; j++) {
            if (strContent.substring(j, j + 1) == '>' || strContent.substring(j, j + 1) == '&gt;') {
                if (tagOpen == 0) {
                    indexClose = j + 1;
                    break;
                }
            }
        }
    }
    var temp = strContent.substring(indexOpen, indexClose);
    return strContent.replace(temp, '');
}

function Cookie() { }
Cookie.prototype.setCookie = function (key, value, expiredays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + expiredays);
    document.cookie = key + "=" + value + ((expiredays == null) ? "" : "; expires=" + exdate.toUTCString());
}

Cookie.prototype.getCookie = function (key) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(key + "=");
        if (c_start != -1) {
            c_start = c_start + key.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length
            return document.cookie.substring(c_start, c_end);
        }
    }
    return "";
}

Cookie.prototype.updateCookie = function (key, NewValue) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(key + "=");
        if (c_start != -1) {
            c_start = c_start + key.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length
            var value = document.cookie.substring(c_start, c_end);
            document.cookie.replace(value, NewValue);
            var CookieName = key + "=";
            var CookieAfter = document.cookie.substring(c_end, document.cookie.length);
            document.cookie = CookieName + NewValue + CookieAfter;
        }
    }
}

Cookie.prototype.clearCookie = function (key) {
    setCookie(key, "", -1);
}

function Common() {
}
var objGlobal = function () { };
objGlobal.prototype = Global.prototype;
Common.prototype.Global = new objGlobal();
var objCookie = function () { };
objCookie.prototype = Cookie.prototype;
Common.prototype.Cookie = new objCookie();

function JWeblib() {
}

var objCommon = function () { };
objCommon.prototype = Common.prototype;
JWeblib.prototype.common = new objCommon();