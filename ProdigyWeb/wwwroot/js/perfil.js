const inputProfileName = document.querySelector(".inputProfileName");
const inputProfileDate = document.querySelector(".inputProfileDate");
const buttonEdit = document.getElementById('buttonEdit');
const buttonConfirm = document.getElementById('buttonConfirm');
let clickEdit = false;
let clickConfirm = true;

inputProfileName.disabled = true;
inputProfileDate.disabled = true;
buttonConfirm.style.display = "none";

console.log('olá')

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