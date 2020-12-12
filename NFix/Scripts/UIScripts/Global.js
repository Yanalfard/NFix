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

const isInStandaloneMode = window.matchMedia('(display-mode: standalone)').matches;
const isSafari = /^((?!chrome|android).)*safari/i.test(navigator.userAgent);
const isIos = /iphone|ipad|ipod/.test(window.navigator.userAgent.toLowerCase());

let deferredPrompt;
const addButtons = document.getElementsByClassName('add-button');
window.addEventListener('beforeinstallprompt', (e) => {
    try {
        // Prevent Chrome 67 and earlier from automatically showing the prompt
        e.preventDefault();
        // Stash the event so it can be triggered later.
        deferredPrompt = e;

        for (let addBtn of addButtons) {
            if (isInStandaloneMode) {
                addBtn.style.display = "none";
            }

            console.log('oi');
            addBtn.addEventListener('click', btnDownloadClick);
        }

    } catch { }
});


function btnDownloadClick(e) {

    if (isInStandaloneMode) {
        UIkit.notification('برنامه نصب شده است');
        return;
    }
    //Is not installed

    if (isSafari && isIos) {
        UIkit.modal(document.getElementById('Modal-PopupIos')).show();
        return;
    }

    try {
        deferredPrompt.prompt();
    } catch (e) {
        console.log(e);
        return;
    }

    // Wait for the user to respond to the prompt
    deferredPrompt.userChoice.then((choiceResult) => {
        deferredPrompt = null;
    });
}

if (isSafari && isIos) {
    setInterval(() => {
        UIkit.modal(document.getElementById('Modal-PopupIos')).show();
    }, 60000 * 2);
}