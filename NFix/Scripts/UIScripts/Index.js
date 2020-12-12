function ModalProduct(id) {
    $.get("/HomeProducts/ModalProduct/" + id, function (result) {
        UIkit.modal(document.getElementById('ModalProduct')).show();
        $("#ModalProduct").html(result);
    });
}

const floatingCart = document.getElementsByClassName('floating-cart')[0];
floatingCart.style.opacity = "0";
window.addEventListener('scroll', () => {
    if (window.scrollY >= 10) {
        floatingCart.style.opacity = "1";
        floatingCart.style.transition = "0.3s";
        floatingCart.style.transform = "translateY(0)";
    }
    else {
        floatingCart.style.opacity = "0";
        floatingCart.style.transition = "0.3s";
        floatingCart.style.transform = "translateY(100px)";
    }
})

$('#product').owlCarousel({
    loop: true,
    margin: 20,
    autoplay: false,
    autoplayTimeout: 3500,
    autoplayHoverPause: true,
    nav: true,
    responsive: {
        1: {
            items: 1
        },
        800: {
            items: 2
        },
        1200: {
            items: 3
        },
        1600: {
            items: 3
        },
        1700: {
            items: 4
        }
    }
})

$('#blogs').owlCarousel({
    loop: true,
    margin: 20,
    autoplay: false,
    autoplayTimeout: 3500,
    autoplayHoverPause: true,
    nav: true,
    responsive: {
        1: {
            items: 1
        },
        750: {
            items: 2
        },
        1100: {
            items: 3
        },
        1600: {
            items: 3
        },
        1900: {
            items: 4
        }
    }
});

$('#tutors').owlCarousel({
    loop: true,
    margin: 0,
    autoplay: true,
    autoplayTimeout: 3500,
    autoplayHoverPause: true,
    nav: true,
    responsive: {
        1: {
            items: 1
        },
        600: {
            items: 2
        },
        950: {
            items: 3
        },
        1200: {
            items: 4
        },
        1500: {
            items: 5
        }
    }
})

$('#categories').owlCarousel({
    loop: true,
    margin: 20,
    autoplay: false,
    autoplayTimeout: 3500,
    autoplayHoverPause: true,
    nav: true,
    responsive: {
        1: {
            items: 2
        },
        800: {
            items: 3
        },
        1200: {
            items: 4
        },
        1600: {
            items: 5
        },
        1700: {
            items: 6
        }
    }
})
