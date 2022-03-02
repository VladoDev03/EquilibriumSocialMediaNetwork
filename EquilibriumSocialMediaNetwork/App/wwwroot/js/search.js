﻿const userCardTemplate = document.querySelector("[data-user-template]")
const userCardContainer = document.querySelector("[data-user-cards-container]")
const searchInput = document.querySelector("[data-search]")

let users = []

searchInput.addEventListener("input", (e) => {
    const value = e.target.value.toLowerCase()

    users.forEach(user => {
        const isVisible = user.name.toLowerCase().includes(value)
            || user.username.toLowerCase().includes(value)

        user.element.classList.toggle("hide", !isVisible)
    })

    console.log(users)
})

fetch("https://localhost:44366/users")
    .then(res => res.json())
    .then(data => {
        users = data.map(user => {
            const card = userCardTemplate.content.cloneNode(true).children[0]
            const header = card.querySelector("[data-header]")
            const body = card.querySelector("[data-body]")

            let wholeName = `${user.FirstName} ${user.LastName}`

            header.textContent = wholeName
            body.textContent = user.UserName

            userCardContainer.append(card)

            console.log(user)

            return { name: wholeName, username: user.UserName, element: card }
        })
    })