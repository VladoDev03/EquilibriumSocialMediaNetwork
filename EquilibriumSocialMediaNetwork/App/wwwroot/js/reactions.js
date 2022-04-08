const likes = document.getElementsByClassName('likes')
const dislikes = document.getElementsByClassName('dislikes')

const reactionUrl = 'https://localhost:44366/addReaction'

Object.values(likes).forEach(like => like.addEventListener('click', (e) => {
    let id = e.target.getAttribute('id').replace('like-sender-', '')

    const reaction = {
        PostId: id,
        Name: 'like'
    }

    const options = {
        method: 'POST',
        body: JSON.stringify(reaction),
        headers: {
            'Content-Type': 'application/json'
        }
    }

    fetch(reactionUrl, options)
        .then(res => res.json())
        .then(data => generateReaction(data, id))
}))

Object.values(dislikes).forEach(dislike => dislike.addEventListener('click', (e) => {
    let id = e.target.getAttribute('id').replace('dislike-sender-', '')

    const reaction = {
        PostId: id,
        Name: 'dislike'
    }

    const options = {
        method: 'POST',
        body: JSON.stringify(reaction),
        headers: {
            'Content-Type': 'application/json'
        }
    }

    fetch(reactionUrl, options)
        .then(res => res.json())
        .then(data => generateReaction(data, id))
}))

function generateReaction(reactionResponse, id) {
    let reactionDiv = document.createElement('div')
    reactionDiv.style.border = '2px solid #808080'
    reactionDiv.style.padding = '3px'

    let reaction = reactionResponse.reaction
    let divContent = ''

    if (reaction.user) {
        divContent += `<a type="button" asp-controller="User" asp-action="Details" asp-route-id="${reaction.id}" style="color:green;text-decoration:none;">${reaction.user.firstName} ${reaction.user.lastName} (${reaction.user.userName})</a>`
    }

    divContent += `<div style="padding-top: 4px;">${reaction.name}</div>`

    reactionDiv.innerHTML = divContent;
    document.getElementById('reactions-' + id).append(reactionDiv)
}