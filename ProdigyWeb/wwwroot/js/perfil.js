const inputPerfil = document.querySelector('#inputPerfil');
const botaoEditar = document.getElementById("#botaoEditar");
const botaoConfirmar = document.getElementById("#botaoConfirmar");
let clickBotao = false;

inputPerfil.disabled = true;
botaoConfirmar.style.display = "none";

botaoEditar.addEventListener("click", function editarInput(clickBotao) {
    if (clickBotao) {
        inputPerfil.disabled = false;
        botaoEditar.style.display = "none";
        botaoConfirmar.style.display = "block";
    }
})