function Calculate(inputId) {
    debugger;
    const age = document.getElementById('txtAge').value;
    const height = parseInt(document.getElementById('txtHeight').value);
    const weight = parseInt(document.getElementById('txtWeight').value);

    const txt = document.getElementById(inputId);

    txt.innerText = weight / Math.pow(height , 2);

}