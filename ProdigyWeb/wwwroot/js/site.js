let background = window.location.href;

if (background == 'http://localhost:5157/Home/Planos' ||
    background == 'https://localhost:7202/Home/Planos' ||
    background == 'https://localhost:7202/Index' ||
    background == 'http://localhost:5157/Index') {

    document.body.style.background = "#E2F0EF";

    let navLinks = document.querySelectorAll('.navbar-a');
    navLinks.forEach((navbar) => {
        navbar.style.color = "#1D7870";

        navbar.addEventListener("mouseover", function () {
            navbar.style.opacity = 0.7;
            navbar.style.textDecorationLine = "underline";
        });

        navbar.addEventListener("mouseleave", function () {
            navbar.style.opacity = 1.0;
            navbar.style.textDecorationLine = "none";
        });
    });

}

if (background == 'http://localhost:5157/SHome') {
    document.body.style.background = "#E2F0EF";
}
