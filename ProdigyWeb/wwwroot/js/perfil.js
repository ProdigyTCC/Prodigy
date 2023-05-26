const inputProfileName = document.querySelector(".inputProfileName");
const inputProfileDate = document.querySelector(".inputProfileDate");
const buttonEdit = document.getElementById('buttonEdit');
const buttonConfirm = document.getElementById('buttonConfirm');
let clickEdit = false;
let clickConfirm = true;

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

    

inputProfileName.disabled = true;
inputProfileDate.disabled = true;
buttonConfirm.style.display = "none";

buttonEdit.addEventListener("click", function editarInput(clickEdit) {
    if (clickEdit) {
        inputProfileName.disabled = false;
        inputProfileDate.disabled = false;
        buttonEdit.style.display = "none";
        buttonConfirm.style.display = "block";
        clickEdit = true;
    }
})

buttonConfirm.addEventListener("click", function editarInput(clickConfirm) {
    if (clickConfirm) {
        inputProfileName.disabled = true;
        inputProfileDate.disabled = true;
        buttonEdit.style.display = "block";
        buttonConfirm.style.display = "none";
        clickConfirm = false;
    }
})