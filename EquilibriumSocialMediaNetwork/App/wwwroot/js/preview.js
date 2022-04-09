var textcontent = document.getElementById('textcontent');

textcontent.onkeyup = textcontent.onkeypress = function () {
    document.getElementById('showtext').innerHTML = this.value;
}

imgInp.onchange = evt => {
    const [file] = imgInp.files
    if (file) {
        show_Image.src = URL.createObjectURL(file)
    }
}