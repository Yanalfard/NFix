let deferredPrompt;
const addBtn = document.getElementsByClassName('add-button')[0];
const addBtn2 = document.getElementsByClassName('add-button')[1];
window.addEventListener('beforeinstallprompt', (e) => {
    // Prevent Chrome 67 and earlier from automatically showing the prompt
    e.preventDefault();
    // Stash the event so it can be triggered later.
    deferredPrompt = e;

    addBtn.addEventListener('click', btnDownloadClick);
    addBtn2.addEventListener('click', btnDownloadClick);
});

function btnDownloadClick(e) {

    //var isSafari = /^((?!chrome|android).)*safari/i.test(navigator.userAgent);
    //if (isSafari) {
    //    window.location = 'https://stackoverflow.com/questions/49328396/how-to-create-progressive-web-app-apk-any-type-of-file-that-can-be-distributed-i';
    //    return;
    //}

    // Show the prompt
    deferredPrompt.prompt();
    // Wait for the user to respond to the prompt
    deferredPrompt.userChoice.then((choiceResult) => {
        if (choiceResult.outcome === 'accepted') {
            console.log('User accepted the A2HS prompt');
        } else {
            console.log('User dismissed the A2HS prompt');
        }
        deferredPrompt = null;
    });
}


function ModalProduct(id) {
    $.get("/HomeProducts/ModalProduct/" + id, function (result) {
        UIkit.modal(document.getElementById('ModalProduct')).show();
        $("#ModalProduct").html(result);
    });
}


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
