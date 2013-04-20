$(document).ready(function () {
    InitPage();
});

function InitPage() {
    $("#featured").tabs({
        fx: [{ opacity: "toggle", duration: 'slow' }, { opacity: "toggle", duration: 'normal' }],
        show: function (event, ui) {
            $('#featured .ui-tabs-panel .info').show();
            var infoheight = $('.info', ui.panel).height();
            $('.info', ui.panel).css('height', '0px').animate({ 'height': infoheight }, 500);
        }
    }).tabs("rotate", 5000, true);
    $('#featured').hover(
        function () { $('#featured').tabs('rotate', 0, true); },
        function () { $('#featured').tabs('rotate', 5000, true); }
    );
    $('#featured .ui-tabs-panel a.hideshow').click(function () {
        if ($(this).text() == 'Hide') {
            $(this).parent('.info').animate({ 'height': '0px' }, 500);
            $(this).text('Show');
        }
        else {
            $(this).parent('.info').animate({ 'height': '70px' }, 500);
            $(this).text('Hide');
        }
        return false;
    });
}

function ValidateSubmitNews() {
    debugger;
    if ($('#SelectCategory').val() == "0") {
        $("#pSelectCategory").html("Bạn chưa chọn danh mục tin");
        $("#pSelectCategory").show();
        $('#SelectCategory').focus();
        return false;
    }
    if ($('#flupload').val() == "") {
        $("#pflupload").html("Bạn chưa chọn hình Thumnail");
        $("#pflupload").show();
        $('#flupload').focus();
        return false;
    }
    else {
        if (validate_fileupload($('#flupload').val()) == false) {
            $("#pflupload").html("Hình không đúng định dạng");
            $('#flupload').focus();
            return false;
        }
    }
    $("#pSelectCategory").hide();
    $("#pflupload").hide();
    return true;
}
function validate_fileupload(fileName) {
    var allowed_extensions = new Array("jpg", "png", "gif");
    var file_extension = fileName.split('.').pop(); // split function will split the filename by dot(.), and pop function will pop the last element from the array which will give you the extension as well. If there will be no extension then it will return the filename.
    for (var i = 0; i <= allowed_extensions.length; i++) {
        if (allowed_extensions[i] == file_extension) {

            return true; // valid file extension
        }
    }
    return false;
}