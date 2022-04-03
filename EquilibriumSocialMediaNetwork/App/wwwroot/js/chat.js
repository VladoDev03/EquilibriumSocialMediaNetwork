const config = {
    idOne: document.getElementById('userOne').innerText,
    idTwo: document.getElementById('userTwo').innerText,
    conversationId: document.getElementById('conversation-to-find').innerText
};

const attemptChatLogin = () => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:44366/chat")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    }

    connection.onclose(async () => {
        await start();
    });

    connection.on("ReceiveMessage", (message) => {
        const h1 = document.createElement("h1");
        h1.textContent = `${message}`;
        document.getElementById('messages').appendChild(h1);
    });

    document.getElementById('send-button').addEventListener('click', async () => {
        const message = document.getElementById('message').value;

        if (message) {
            await connection.invoke("SendMessage", config.idOne, config.idTwo, message);
            document.getElementById('message').value = "";
        }
    });

    start();
}

const displayChatWrapper = () => {
    document.getElementById('chat-wrapper').style.display = 'block';

    getConversation(config.conversationId)
        .then(conversation => {
            conversation.messages.forEach(message => {
                const h1 = document.createElement("h1");
                h1.textContent = `[${message.usernameOne}] sends ${message.content} to [${message.usernameTwo}]`;
                document.getElementById('messages').appendChild(h1);
            })
        })
}

displayChatWrapper()
attemptChatLogin()