const btnEditGeral = document.querySelector("#btnEditGeral")
const btnCancelGeral = document.querySelector("#btnCancelGeral")
const btnConfirmGeral = document.querySelector("#btnConfirmGeral")

const btnEditEndereco = document.querySelector("#btnEditEndereco")
const btnCancelEndereco = document.querySelector("#btnCancelEndereco")
const btnConfirmEndereco = document.querySelector("#btnConfirmEndereco")

const btnEditConta = document.querySelector("#btnEditConta")
const btnCancelConta = document.querySelector("#btnCancelConta")
const btnConfirmConta = document.querySelector("#btnConfirmConta")
const inputNome = document.querySelector("#inputNome")

btnCancelGeral.style.display = "none"
btnConfirmGeral.style.display = "none"
btnEditGeral.style.display = "block"

btnCancelConta.style.display = "none"
btnConfirmConta.style.display = "none"
btnEditConta.style.display = "block"

btnCancelEndereco.style.display = "none"
btnConfirmEndereco.style.display = "none"
btnEditEndereco.style.display = "block"

//BOTOES GERAL
btnEditGeral.addEventListener('click', () => {
    btnCancelGeral.style.display = "block"
    btnConfirmGeral.style.display = "block"
    btnEditGeral.style.display = "none"
})

btnConfirmGeral.addEventListener('click', () => {
    btnCancelGeral.style.display = "none"
    btnConfirmGeral.style.display = "none"
    btnEditGeral.style.display = "block"
})

btnCancelGeral.addEventListener('click', () => {
    btnCancelGeral.style.display = "none"
    btnConfirmGeral.style.display = "none"
    btnEditGeral.style.display = "block"
})
//FIM GERAL

//BOTOES CONTA
const inputCpf = document.querySelector("#inputCpf")
const inputEmail = document.querySelector("#inputEmail")
const inputDtNasc = document.querySelector("#inputDtNasc")
const inputSenha = document.querySelector("#inputSenha")

btnEditConta.addEventListener('click', () => {
    btnCancelConta.style.display = "block"
    btnConfirmConta.style.display = "block"
    btnEditConta.style.display = "none"
    inputNome.disabled = false
    inputCpf.disabled = false
    inputEmail.disabled = false
    inputDtNasc.disabled = false
    inputSenha.disabled = false
})

btnConfirmConta.addEventListener('click', () => {
    btnCancelConta.style.display = "none"
    btnConfirmConta.style.display = "none"
    btnEditConta.style.display = "block"
})

btnCancelConta.addEventListener('click', () => {
    btnCancelConta.style.display = "none"
    btnConfirmConta.style.display = "none"
    btnEditConta.style.display = "block"
})
//FIM CONTA

//BOTOES ENDEREÇO/CONTATO
btnEditEndereco.addEventListener('click', () => {
    btnCancelEndereco.style.display = "block"
    btnConfirmEndereco.style.display = "block"
    btnEditEndereco.style.display = "none"
})

btnConfirmEndereco.addEventListener('click', () => {
    btnCancelEndereco.style.display = "none"
    btnConfirmEndereco.style.display = "none"
    btnEditEndereco.style.display = "block"
})

btnCancelEndereco.addEventListener('click', () => {
    btnCancelEndereco.style.display = "none"
    btnConfirmEndereco.style.display = "none"
    btnEditEndereco.style.display = "block"
})
//FIM ENDEREÇO/CONTATO