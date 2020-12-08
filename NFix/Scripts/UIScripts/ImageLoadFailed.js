const images = document.getElementsByTagName('img');
for (let image of images) {
    image.setAttribute("onerror", "this.onerror=null;this.src='/Resources/Svg/NoImage.svg'")
}