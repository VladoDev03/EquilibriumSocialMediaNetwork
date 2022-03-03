const log = document.getElementById('login');
const reg = document.getElementById('register');
const btn = document.getElementById('btn');

function register() {
    log.style.left = '-400px';
    reg.style.left = '50px';
    btn.style.left = '110px';
}
function login() {
    log.style.left = '50px';
    reg.style.left = '450px';
    btn.style.left = '0px';
}

function checkCheckBoxes(theForm) {
    if (!theForm.check1.checked) {
        alert('You have to agree to the terms and conditions!');
        return false;
    } else {
        return true;
    }
}

//var modal = document.getElementById('login-sform');
//window.onclick = function (event) {
//    if (event.target == modal) {
//        modal.style.display = "none";
//    }
//}