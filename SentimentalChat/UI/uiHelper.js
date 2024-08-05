$('#username').keydown(function (event) {
    var id = event.key || event.which || event.keyCode || 0;
    if (id === "Enter" || id === 13) {
        $('#save-btn').trigger('click');
    }
});

$('#message').keydown(function (event) {
    var id = event.key || event.which || event.keyCode || 0;
    if (id === "Enter" || id === 13) {
        $('#send-btn').trigger('click');
    }
});

function updateInputState() {
    if (username) {
        $('#message').prop('disabled', false);
        $('#send-btn').prop('disabled', false);
        $('#username').prop('disabled', true);
        $('#save-btn').prop('disabled', true);
    } else {
        $('#message').prop('disabled', true);
        $('#send-btn').prop('disabled', true);
        $('#username').prop('disabled', false);
        $('#save-btn').prop('disabled', false);
    }
}

function scrollToBottom() {
    $('#chat-box').scrollTop($('#chat-box')[0].scrollHeight);
};