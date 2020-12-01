function fallbackCopyTextToClipboard(text) {
    var textArea = document.createElement("textarea");
    textArea.value = text;

    // Avoid scrolling to bottom
    textArea.style.top = "0";
    textArea.style.left = "0";
    textArea.style.position = "fixed";

    document.body.appendChild(textArea);
    textArea.focus();
    textArea.select();

    try {
        var successful = document.execCommand('copy');
    } catch { }

    document.body.removeChild(textArea);
    UIkit.notification("لینک صفحه کپی شد")
}

function LoadingRun(form) {
    if (!$(form).valid()) return;
    $("#overlay").fadeIn(300);
}
function LoadingEnd(form) {
    $("#overlay").fadeOut(300);
    $(form)[0].reset();
}
$(function () {
    countShopCart();
});

function countShopCart() {
    $.get("/Api/Shop", function (res) {

        $("#countShopCart").html(res);
    });
}

function AddToCart(id) {
    $.get("/Api/Shop/" + id, function (res) {
        $("#countShopCart").html(res);
        updateShopCart();
    });
}

function updateShopCart() {
    $("#showCart").load("/ShopCart/ShowCart").fadeOut(800).fadeIn(800);
}