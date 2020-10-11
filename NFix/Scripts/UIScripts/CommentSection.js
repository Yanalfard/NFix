if (localStorage.getItem('isCommentSectionVisible') === null) { localStorage.setItem('isCommentSectionVisible', 'true') }
if (localStorage.getItem('isCommentSectionVisible') === 'false') {
    document.getElementById('comments').style.height = "0";
    document.getElementById('makeComment').style.height = "0";
    document.getElementById('btnHideCommentSection').classList.add('rotate-180');
}

function HideElementsByIds(listOfIds) {
    if ((localStorage.getItem('isCommentSectionVisible') == 'true')) {
        for (let id of listOfIds) {
            document.getElementById(id).style.height = "0";
        }
        (localStorage.setItem('isCommentSectionVisible', 'false'))
        document.getElementById('btnHideCommentSection').classList.add('rotate-180');
    }
    else {
        for (let id of listOfIds) {
            document.getElementById(id).style.height = "auto";
        }
        (localStorage.setItem('isCommentSectionVisible', 'true'))
        document.getElementById('btnHideCommentSection').classList.remove('rotate-180');
    }
}