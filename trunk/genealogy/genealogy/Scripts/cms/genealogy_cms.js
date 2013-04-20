
var objGlobal = new Global();
var time;
var objSearch = {
    'keyword': '',
    'maingroupid': -1,
    'companyid': -1,
    'isclosed': 1,
    'statusOrder': -1,
    'statusDelyvery': -1,
    'ward': '',
    'district': -1,
    'begindatefrom': '',
    'begindateto': '',
    'enddatefrom': '',
    'enddateto': '',
    'isadmind': 0,
    'iscompany': 0,
    "currentPages": 1,
    "rowNum": 10
};
$(document).ready(function () {
    InitPaging();
});

function search(strUrl) {
    objSearch.keyword = $('#keyword').val();
    var data = { strkeyword: objSearch.keyword, PageIndex: 1 };
    if (typesearch == 1) {
        aJaxCalling(strUrl, data, 'NewsCategory');
    }
    else if (typesearch == 2) {
        aJaxCalling(strUrl, data, 'MenuList');
    }
    else if (typesearch == 3) {
        aJaxCalling(strUrl, data, 'AlbumList');
    }
    else if (typesearch == 4) {
        aJaxCalling(strUrl, data, 'AlbumDetailEdit');
    }
    else if (typesearch == 5) {
        aJaxCalling(strUrl, data, 'DocumentDirectoryList');
    }
}
function pagingReport(obj) {
    objSearch.currentPages = parseInt(obj.text());
    var data = { strkeyword: objSearch.keyword, PageIndex: objSearch.currentPages };
    if (typesearch == 1) {
        aJaxCalling(obj.data('url'), data, 'NewsCategory');
    }
    else if (typesearch == 2) {
        aJaxCalling(obj.data('url'), data, 'MenuList');
    }
    else if (typesearch == 3) {
        aJaxCalling(obj.data('url'), data, 'AlbumList');
    }
    else if (typesearch == 4) {
        aJaxCalling(obj.data('url'), data, 'AlbumDetailEdit');
    }
    else if (typesearch == 5) {
        aJaxCalling(obj.data('url'), data, 'DocumentDirectoryList');
    }
}

function createPagingReport(numberPages, idCtrl) {
    debugger;
    $('#' + idCtrl).data('data', numberPages);
    $('#' + idCtrl + ' a').hide();
    var j = 1;
    $('#' + idCtrl + ' a[data-role-report="paging"]').each(function () {
        $(this).text(j);
        j++;
    });
    for (var i = 0; i < numberPages && i < numberPages; i++) {
        $('#' + idCtrl + ' a[data-role-report="paging"]').eq(i).show();
    }
    if (CurrentPage > numberPages - 1) {
        $('#' + idCtrl + ' a[data-role-report="next"]').hide();
        $('#' + idCtrl + ' a[data-role-report="prev"]').show();
    }
    else {
        $('#' + idCtrl + ' a[data-role-report="next"]').show();
        $('#' + idCtrl + ' a[data-role-report="prev"]').hide();
    }
    $('#' + idCtrl + ' li').removeClass('active');
    $('#' + idCtrl + ' li[data-page="' + CurrentPage + '"]').addClass('active');
}


function aJaxCalling(url, dataIni, idCtrlReceive) {
    $.ajax({
        type: "POST",
        url: "/ajax/" + url,
        cache: false,
        beginSend: objGlobal.showLoading(),
        data: $.extend({}, dataIni),
        success: function (data) {
            objGlobal.closeMess();
            $('#' + idCtrlReceive).html(data);
        },
        error: function () {
            objGlobal.closeMess();
        }
    });
}

function InitPaging() {
    $('a[data-role-report="paging"]').bind('click', function () {
        pagingReport($(this));
    });
    $('a[data-role-report="next"]').bind('click', function () {
        debugger;
        $('a[data-role-report="prev"]').show();
        var currentPaging = parseInt($('#pagingReport a[data-role-report="paging"]').last().text());
        var pages = parseInt($('#pagingReport').data('data'));
        $('#pagingReport a[data-role-report="paging"]').hide();
        var j = 0;
        for (var i = currentPaging + 1; i <= pages && i <= currentPaging + 3; i++) {
            $('#pagingReport a[data-role-report="paging"]').eq(j).show().text(i);
            j++;
        }
        if (pages <= currentPaging + 3) {
            $(this).hide();
        }
        pagingReport($('#pagingReport a[data-role-report="paging"]').first());
    });
    $('a[data-role-report="prev"]').bind('click', function () {
        $('a[data-role-report="next"]').show();
        var currentPaging = parseInt($('#pagingReport a[data-role-report="paging"]').first().text());
        $('#pagingReport a[data-role-report="paging"]').hide();
        var j = 2;
        for (var i = currentPaging ; i >= 1 && i >= currentPaging - 2; i--) {
            $('#pagingReport a[data-role-report="paging"]').eq(j).show().text(i);
            j--;
        }
        if (currentPaging - 2 <= 1) {
            $(this).hide();
        }
        pagingReport($('#pagingReport a[data-role-report="paging"]').first());
    });
}