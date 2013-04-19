function createPagingReport(numberPages, idCtrl) {
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
    if (numberPages > 3) {
        $('#' + idCtrl + ' a[data-role-report="next"]').show();
    }
}