let username = '';

updateInputState();

// Signal R connection
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build();

bindConnectionMessage(connection);

connection.start();

// Subscribe to new messages
function bindConnectionMessage(connection) {
    var messageCallback = function (message) {
        if (!message) return;

        addMessage(message);

        scrollToBottom();
    };

    connection.on("broadcastMessage", messageCallback);
}

// Add new message html to UI
function addMessage(message) {

    var isMyMessage = (username === message.userName);

    var activeSentiment = message.sentiment.toLowerCase();

    if (!activeSentiment)
    {
        activeSentiment = "neutral";
    }

    var messageHtml = `
            <div class="message ${isMyMessage ? "self" : "other"} ${activeSentiment}">
                <div class="message-info">
                    <span class="message-user">${message.userName}</span>
                </div>
                <div class="message-text-container">
                    <div class="message-text">${message.messageContent}</div>
                    <div class="message-time">${new Date(message.date).toLocaleString()}</div>
                </div>
            </div>
        `;

    $(".message-container").append(messageHtml);
}

// Get inital messages from DB
$('#save-btn').click(function () {

    const enteredUsername = $('#username').val().trim();

    if (enteredUsername) {

        username = enteredUsername;

        $.get("/messages", function (messages) {
            messages.forEach((msg) => {
                addMessage(msg);
            });

            scrollToBottom();
            $('#message').focus();
        })

        updateInputState();
    } else {
        alert('Please enter a username');
    }
});

// Send new message
$('#send-btn').click(function () {
    var payload = { UserName: username, MessageContent: $('#message').val() };

    $('#message').val("");

    connection.send("broadcastMessage", payload);
});
