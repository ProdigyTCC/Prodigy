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


let btnConfirm = document.querySelectorAll('.buttonConfirm');
btnConfirm.forEach((buttonConfirm) => {
    buttonConfirm.style.display = "none";
});

let btnCancel = document.querySelectorAll('.buttonCancel');
btnCancel.forEach((buttonCancel) => {
    buttonCancel.style.display = "none";
});

let btnEdit = document.querySelectorAll(".btnEdit");
let buttonEdit;

for (let i = 0; i < btnEdit.length; i++) {
    if (btnEdit[i].checked) {
        buttonEdit = btnEdit[i];
        break;
    }
}

function editConta() {
    let inputsProfile = document.querySelectorAll('.inputProfile');

    for (let i = 0, len = inputsProfile.length; i < len; i++) {
        inputsProfile[i].disabled = false;
    }

    btnEdit.forEach((buttonEdit) => {
        buttonEdit.style.display = "none";
    });

    btnConfirm.forEach((buttonConfirm) => {
        buttonConfirm.style.display = "block";
    });

    btnCancel.forEach((buttonCancel) => {
        buttonCancel.style.display = "block";
    });
}
btnConfirm.forEach((buttonConfirm) => {
    buttonConfirm.addEventListener('click', () => {
        let inputsProfile = document.querySelectorAll('.inputProfile');
        for (let i = 0, len = inputsProfile.length; i < len; i++) {
            inputsProfile[i].disabled = true;
            const valueInputProfile = inputsProfile[i].value;
            inputsProfile[i].value = valueInputProfile
        }
        btnEdit.forEach((buttonEdit) => {
            buttonEdit.style.display = "block";
        });

        btnConfirm.forEach((buttonConfirm) => {
            buttonConfirm.style.display = "none";
        });

        btnCancel.forEach((buttonCancel) => {
            buttonCancel.style.display = "none";
        });
    });
});
btnCancel.forEach((buttonCancel) => {
    buttonCancel.onclick = function () {
        let inputsProfile = document.querySelectorAll('.inputProfile');
        for (let i = 0, len = inputsProfile.length; i < len; i++) {
            inputsProfile[i].disabled = true;
        }
        btnEdit.forEach((buttonEdit) => {
            buttonEdit.style.display = "block";
        });

        btnConfirm.forEach((buttonConfirm) => {
            buttonConfirm.style.display = "none";
        });

        btnCancel.forEach((buttonCancel) => {
            buttonCancel.style.display = "none";
        });
    };
});
btnEdit.forEach((buttonEdit) => {
    buttonEdit.addEventListener("click", editConta);
});