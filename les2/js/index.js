$(document).ready(function () {

    $('#uitbreidenSection').load("uitbreiden.html");
    $('#mijnSelectieSection').load("mijn_selectie.html");
    $("#alert").hide();
});

function switchTab(tabId, saved) {
    var uitbreiden = document.getElementById("uitbreidenSection");
    var mijnSelectie = document.getElementById("mijnSelectieSection");

    var uitbreidenBtn = document.getElementById("uitbreidenBtn").classList;
    var mijnSelectieBtn = document.getElementById("mijnSelectieBtn").classList;


    if (tabId === 1) {
        uitbreiden.style.display = "block";
        mijnSelectie.style.display = "none";

        mijnSelectieBtn.remove("tab-active");
        mijnSelectieBtn.add("tab-inactive");

        uitbreidenBtn.remove("tab-inactive");
        uitbreidenBtn.add("tab-active");

    } else if (tabId === 2) {
        uitbreiden.style.display = "none";
        mijnSelectie.style.display = "block";

        mijnSelectieBtn.remove("tab-inactive");
        mijnSelectieBtn.add("tab-active");

        uitbreidenBtn.remove("tab-active");
        uitbreidenBtn.add("tab-inactive");
    }

    if (saved === true) {
        document.getElementById("alert").style.display = "block"
    }
}

// function initId(event) {
//     var header = document.getElementById("cards");
//     var cards = header.getElementsByClassName("card");

//     for (var i = 0; i < cards.length; i++) {
//         cards[i].id = "card" + i
//         // console.log(cards[i]);
//     }
//     console.log(event.target.id)
// }

function checkSelectedButton(event) {
    // initId(event);
    // console.log(event.target)

    var k1 = document.getElementById("klas1");
    k1.classList.toggle("activeCard");
}