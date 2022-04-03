const getAllMessages = () => {
    return fetch('https://localhost:44366/Messages')
        .then(res => res.json())
}

const getConversation = convId => {
    return fetch(`https://localhost:44366/Conversation/${convId}`)
        .then(res => res.json())
}