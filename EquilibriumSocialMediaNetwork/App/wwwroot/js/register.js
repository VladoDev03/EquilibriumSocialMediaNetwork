const username = document.getElementById('username')
const email = document.getElementById('email')
const errorElementUsername = document.getElementById('username-error')
const errorElementEmail = document.getElementById('email-error')
const form = document.getElementById('form')
const submit = document.getElementById('submit')

fetch("https://localhost:44366/users")
    .then(res => res.json())
    .then(data => {
        users = data.map(user => {
            return { email: user.Email, username: user.UserName }
        })

        console.log(users)
    })

username.addEventListener("input", (e) => {
    let usernameValue = e.target.value.toLowerCase()
    let isValidUsername = users.find(user => user.username.toLowerCase() == usernameValue)

    if (isValidUsername != null) {
        errorElementUsername.innerText = "Username is already taken"
        submit.setAttribute('disabled', 'disabled')
    } else {
        errorElementUsername.innerText = ""
        submit.removeAttribute('disabled')
    }
})

email.addEventListener("input", (e) => {
    const emailValue = e.target.value.toLowerCase()

    let isValidEmail = users.find(user => user.email.toLowerCase() == emailValue)

    if (isValidEmail != null) {
        errorElementEmail.innerText = "Invalid or taken email"
        submit.setAttribute('disabled', 'disabled')
    } else {
        errorElementEmail.innerText = ""
        submit.removeAttribute('disabled')
    }
})
