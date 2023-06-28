let background = window.location.pathname;

if (background == '/Home/Planos' || background == '/SHome' || background == '/SEstoque' || background == '/SPedidos/AddPedido' ||
    background == '/SFuncionario' || background == '/SFuncionario/AddFuncionario' || background == '/SFuncionario/Editar' || background == '/Index' ||
    background == '/AddProduto' || background == '/SEstoque/Editar/1' || background == '/SPedidos' || background == '/SCaixa' || background == '/SCaixa/NovaVenda'
    || background == '/SCliente' || background == '/SCliente/AddCliente' || background == '/SFornecedor' || background == '/SFornecedor/AddFornecedor') {

    document.body.style.background = "#E2F0EF";

    document.getElementById('menuNavbar').style.color = "#1D7870"

    let logoProdigy = document.querySelectorAll('.pathProdigy');
    logoProdigy.forEach((path) => {
        path.style.fill = "#1D7870";
    })

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