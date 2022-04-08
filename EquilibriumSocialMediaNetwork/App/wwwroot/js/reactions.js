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

let hasReacted = false

function generateReaction(reactionResponse, id) {
    if (hasReacted) {
        let itemToRemove = document.getElementById('reactions-' + id).lastChild
        document.getElementById('reactions-' + id).removeChild(itemToRemove)
    }

    hasReacted = true

    let postUrl = `https://localhost:44366/post/${id}`

    fetch(postUrl)
        .then(res => res.json())
        .then(data => {
            let summaryContent = `(likes: ${data.likes}) (dislikes: ${data.dislikes})`
            let summary = document.getElementById(`reaction-summary-${reactionResponse.reaction.postId}`)
            summary.innerText = summaryContent

            console.log('like ' + data.isLiked)
            console.log('dislike ' + data.isDisliked)

            if (data.isLiked) {
                document.getElementById('like-sender-' + data.id).classList.add('font-weight-bold')
                document.getElementById('dislike-sender-' + data.id).classList.remove('font-weight-bold')
            } else {
                document.getElementById('like-sender-' + data.id).classList.remove('font-weight-bold')
            }

            if (data.isDisliked) {
                document.getElementById('dislike-sender-' + data.id).classList.add('font-weight-bold')
                document.getElementById('like-sender-' + data.id).classList.remove('font-weight-bold')
            } else {
                document.getElementById('dislike-sender-' + data.id).classList.remove('font-weight-bold')
            }
        })

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
    reactionDiv.id = 'newData-' + reaction.id
    document.getElementById('reactions-' + id).append(reactionDiv)
}