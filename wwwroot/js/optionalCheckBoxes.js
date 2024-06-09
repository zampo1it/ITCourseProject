$(document).ready(function () {
    var optionalCheckbox = $("#OptionalCheckbox");
    var optionalFields = $(".optional-field");

    optionalCheckbox.change(function () {
        if (optionalCheckbox.is(":checked")) {
            optionalFields.hide();
        } else {
            optionalFields.show();
        }
    });
});