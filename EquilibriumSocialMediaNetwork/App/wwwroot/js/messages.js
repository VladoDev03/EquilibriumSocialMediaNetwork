const getAllMessages = () => {
    return fetch('https://equilibriumsocialmedia.herokuapp.com/Messages')
        .then(res => res.json())
}

const getConversation = convId => {
    return fetch(`https://equilibriumsocialmedia.herokuapp.com/Conversation/${convId}`)
        .then(res => res.json())
}