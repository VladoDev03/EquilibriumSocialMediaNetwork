const buttons = document.getElementsByClassName('sender')
const idInputs = document.getElementsByClassName('inputaId')
const inputs = document.getElementsByClassName('inputa')

const url = 'https://localhost:44366/createComment'

Object.values(buttons).forEach(button => button.addEventListener('click', (e) => {
    let id = e.target.getAttribute('id').replace('sender-', '')
    let input = document.getElementById('content-' + id).value

    document.getElementById('content-' + id).value = ''

    if (input === '') {
        return
    }

    const comment = {
        Id: id,
        Content: input
    }

    const options = {
        method: 'POST',
        body: JSON.stringify(comment),
        headers: {
            'Content-Type': 'application/json'
        }
    }

    fetch(url, options)
        .then(res => res.json())
        .then(data => generateComment(data, id))
}))

function generateComment(commentResponse, id) {
    let commentDiv = document.createElement('div')
    commentDiv.style.border = '2px solid #808080'
    commentDiv.style.padding = '3px'

    let postUrl = `https://localhost:44366/addPost/${id}`

    fetch(postUrl)
        .then(res => res.json())
        .then(data => {
            let summaryContent = `${data.comments} comments`
            console.log(summaryContent)
            let summary = document.getElementById(`comment-summary-${id}`)
            summary.innerText = summaryContent
        })

    let comment = commentResponse.comment

    let divContent = ''

    if (comment.user) {
        divContent += `<a type="button" href="User/Details/${comment.userId}" style="color:green;text-decoration:none;">${comment.user.firstName} ${comment.user.lastName} (${comment.user.userName})</a>`
    }

    divContent += `<a class="text-danger" href="Comment/DeleteComment/${comment.id}">Delete</a>`

    divContent += `<p class="text-info">${comment.timeCommented}</p>
                                <div style="padding-top: 4px;">${comment.content}</div>`

    commentDiv.innerHTML = divContent;
    document.getElementById('comments-' + id).append(commentDiv)
}