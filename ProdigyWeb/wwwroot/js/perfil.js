var inputFile = document.getElementById("imagem-perfil");
var btnImage = document.getElementById("btn-imagem");

inputFile.addEventListener("change", () => {
    if (inputFile.files.length === 0) {
        console.log("Nenhum arquivo selecionado.");
        return;
    }

    var file = inputFile.files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        if (reader.result.length === 0) {
            btnImage.style.display = "none"
            console.log("O arquivo está vazio.");
        } else {
            btnImage.style.display = "block"
            console.log("O arquivo não está vazio.");
        }
    };
    reader.readAsText(file);
});


