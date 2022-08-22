//NAVBAR
const logo = document.querySelector(".logo");
const hamburger = document.querySelector(".bi-list");
var nav = document.querySelector(".lower-Nav")

hamburger.addEventListener("click", function () {
    nav.classList.toggle("openNav");
    return true;
});

