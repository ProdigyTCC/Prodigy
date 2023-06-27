let background = window.location.pathname;

if (background == '/Home/Planos' || background == '/SHome' || background == '/SEstoque/Index' || background == '/SPedidos/AddPedido' ||
    background == '/SFuncionario' || background == '/SFuncionario/AddFuncionario' || background == '/SFuncionario/Editar/{id?}' ||
    background == '/AddProduto' || background == '/SEstoque/Editar/{id?}' || background == '/SPedidos' || background == '/SCaixa' || background == '/SCaixa/NovaVenda'
    || background == '/SCliente' || background == '/SCliente/AddCliente' || background == '/SFornecedor' || background == '/SFornecedor/AddFornecedor') {

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
