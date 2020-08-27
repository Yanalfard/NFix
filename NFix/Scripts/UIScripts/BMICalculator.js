function Calculate(inputId) {
    const height = parseInt(document.getElementById('txtHeight').value);
    const weight = parseInt(document.getElementById('txtWeight').value);

    const txt = document.getElementById(inputId);

    txt.innerText = String(weight / Math.pow(height, 2)).slice(0,5);
}