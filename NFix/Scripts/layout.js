function LoadingRun(form) {
    if (!$(form).valid()) return;
    $("#overlay").fadeIn(300);
}
function LoadingEnd(form) {
    $("#overlay").fadeOut(300);
    reloadRech();
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