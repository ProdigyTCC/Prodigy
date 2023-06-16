let background = window.location.pathname;

if (background == '/Home/Planos' || background == '/SHome' || background == '/SEstoque' ||
    background == '/SFuncionario' || background == '/SFuncionario/AddFuncionario' || background == '/SFuncionario/Editar' ||
    background == '/AddProduto' || background == '/SEstoque/Editar/1') {

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

if (background == '/SHome' ||
    background == '/SHome') {
    document.body.style.background = "#E2F0EF";
}