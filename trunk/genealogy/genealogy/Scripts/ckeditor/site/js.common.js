$(document).ready(function () {

    InitPage();
});

function InitPage() {

    $("#featured").tabs({
        fx: [{ opacity: "toggle", duration: 'slow' }, { opacity: "toggle", duration: 'normal' }],
        show: function (event, ui) {
            $('#featured .ui-tabs-panel .info').hide();
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