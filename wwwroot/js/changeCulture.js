function changeCulture(culture) {
    $.ajax({
        url: '/Home/ChangeCulture',
        type: 'POST',
        data: { culture: culture },
        success: function () {
            location.reload();
        }
    });
}