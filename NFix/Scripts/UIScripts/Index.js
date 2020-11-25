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
