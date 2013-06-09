function cleardata() {
    $("#Email").val('');
    $("#Mobile").val('');
    $("#FirstName").val('');
    $("#LastName").val('');
    $("#Birthday").val('');
    $("#BirthPlace").val('');
    $("#SelectProvinceBirth").val('');
    $("#CurrentPlace").val('');
    $("#SelectProvinceCurrent").val('');
    $("#Password").val('');
    $("#ConfirmPassword").val('');
}
function showMessPermission(content) {
    delete time;
    $('#loading').hide();
    $('#loading').html(content);
    $('#loading').css({ 'left': ($(window).width() - $('#loading').outerWidth()) / 2 });
    $('#loading').show();
    time = setTimeout('closeMess("loading")', 6000);
}

function closeMess(isCtrl) {
    $('#' + isCtrl).hide();
}
