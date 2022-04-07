const config = {
    idTwo: document.getElementById('userTwo').innerText,
    conversationId: document.getElementById('conversation-to-find').innerText
};

const attemptChatLogin = () => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:44366/chat")
        .configureLogging(signalR.LogLevel.Information)
        .build()

    async function start() {
        try {
            await connection.start()
            console.log("SignalR Connected.")
        } catch (err) {
            console.log(err)
            setTimeout(start, 5000)
        }
    }

    connection.onclose(async () => {
        await start()
    });

    connection.on("ReceiveMessage", (message) => {
        const h1 = document.createElement("h1")
        h1.textContent = `${message}`
        document.getElementById('messages').appendChild(h1)
        window.scroll(0, document.documentElement.scrollHeight)
    });

    async function sendMessage() {
        const message = document.getElementById('message')
        message.focus()

        if (message.value) {
            await connection.invoke("SendMessage", config.idTwo, message.value);
            document.getElementById('message').value = ""
        }
    }

    document.getElementById('send-button').addEventListener('click', async () => {
        await sendMessage()
    });

    document.getElementById('message').addEventListener('keyup', async e => {
        if (e.key === 'Enter' || e.keyCode === 13) {
            await sendMessage()
        }
    })

    start()
}

const displayChatWrapper = () => {
    document.getElementById('chat-wrapper').style.display = 'block'

    getConversation(config.conversationId)
        .then(conversation => {
            conversation.messages.forEach(message => {
                const h1 = document.createElement("h1")
                h1.textContent = `[${message.usernameOne}] ${message.content}`
                document.getElementById('messages').appendChild(h1)
            })

            const scrollHeight = document.body.scrollHeight;
            window.scrollTo(0, scrollHeight);
        })
}

displayChatWrapper()
attemptChatLogin()