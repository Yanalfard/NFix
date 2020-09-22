function Calculate(inputId) {
    const height = parseInt(document.getElementById('txtHeight').value);
    const weight = parseInt(document.getElementById('txtWeight').value);

    const txt = document.getElementById(inputId);

    txt.innerText = (weight / ((height / 100) * (height / 100))).toString().slice(0,4);
}