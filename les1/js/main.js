function goToDetailsPage() {
    window.location.href = "secondpage.html";
}

function goToIndexPage() {
    window.location.href = "index.html";
}

// When the user scrolls down 50px from the top of the document, resize the header's font size
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 30 || document.documentElement.scrollTop > 30) {
        document.getElementById("header").style.height = "4rem";
        document.getElementById("header-img").style.display = "none";
    } else {
        document.getElementById("header").style.height = "6rem";
        document.getElementById("header-img").style.display = "inline";
    }
}

function sendReaction() {
    var name = "Naam: " + document.getElementById("addName").value;
    var comment = "Comment: " + document.getElementById("addComment").value;
    console.log(name + " " + comment);

    event.preventDefault();

    let div = document.createElement("div");
    div.classList.add("commentBox");
    let n = document.createTextNode(name);
    div.appendChild(n);
    document.getElementById("comment").appendChild(div);

    let c = document.createTextNode(comment);
    div.appendChild(c);
    document.getElementById("comment").appendChild(div);

    // document.getElementById("reaction").appendChild
}
