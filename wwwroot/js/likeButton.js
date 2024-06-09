function sendMessage() {
    var currentUser = '@User.Identity.Name';
    var message = $('#message').val();
    var currentItemId = '@Model.item.Id';
    var test = '@Model.item.Id';

    $.ajax({
        url: '@Url.Action("SendMessage", "Items")',
        type: 'POST',
        data: { user: currentUser, message: message, id: currentItemId },
        success: function (response) {
            location.reload();
        },
        error: function (xhr, status, error) {

        }
    });
}