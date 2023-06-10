const btnEditConta = document.querySelector("#btnEditConta")
const btnCancelConta = document.querySelector("#btnCancelConta")
const btnConfirmConta = document.querySelector("#btnConfirmConta")

const btnEditGeral = document.querySelector("#btnEditGeral")
const btnCancelGeral = document.querySelector("#btnCancelGeral")
const btnConfirmGeral = document.querySelector("#btnConfirmGeral")

const btnEditEndereco = document.querySelector("#btnEditEndereco")
const btnCancelEndereco = document.querySelector("#btnCancelEndereco")
const btnConfirmEndereco = document.querySelector("#btnConfirmEndereco")

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
const inputNome = document.querySelector("#inputNome")
const inputCpf = document.querySelector("#inputCpf")
const inputEmail = document.querySelector("#inputEmail")
const inputDtNasc = document.querySelector("#inputDtNasc")
const inputTelefoneUsuario = document.querySelector("#inputTelefoneUsuario")
const inputSenha = document.querySelector("#inputSenha")

btnEditConta.addEventListener('click', () => {
    btnCancelConta.style.display = "block"
    btnConfirmConta.style.display = "block"
    btnEditConta.style.display = "none"

    inputNome.disabled = false
    inputCpf.disabled = false
    inputEmail.disabled = false
    inputDtNasc.disabled = false
    inputTelefoneUsuario.disabled = false
    inputSenha.disabled = false
})

btnConfirmConta.addEventListener('click', () => {
    btnCancelConta.style.display = "none"
    btnConfirmConta.style.display = "none"
    btnEditConta.style.display = "block"

    var formData = new FormData()

    formData.append("Nome", inputNome.value)
    formData.append("Cpf", inputCpf.value)
    formData.append("Email", inputEmail.value)
    formData.append("DataNascimento", inputDtNasc.value)
    formData.append("Telefone", inputTelefoneUsuario.value)
    formData.append("Senha", inputSenha.value)

    fetch("/Usuario/AtualizarConta", {
        method: "POST",
        body: formData
    })
        .then(function () {
            let value = '/1'
            window.location.href = 'https://localhost:7202/Usuario/Atualizar' + value
        })

    inputNome.disabled = true
    inputCpf.disabled = true
    inputEmail.disabled = true
    inputDtNasc.disabled = true
    inputTelefoneUsuario.disabled = true
    inputSenha.disabled = true
})

btnCancelConta.addEventListener('click', () => {
    btnCancelConta.style.display = "none"
    btnConfirmConta.style.display = "none"
    btnEditConta.style.display = "block"

    inputNome.disabled = true
    inputCpf.disabled = true
    inputEmail.disabled = true
    inputDtNasc.disabled = true
    inputTelefoneUsuario.disabled = true
    inputSenha.disabled = true
})

//FIM CONTA

//BOTOES ENDEREÇO/CONTATO
const inputRua = document.querySelector("#inputRua")
const inputNumero = document.querySelector("#inputNumero")
const inputBairro = document.querySelector("#inputBairro")
const inputComplemento = document.querySelector("#inputComplemento")
const inputCep = document.querySelector("#inputCep")
const inputCidade = document.querySelector("#inputCidade")
const inputEstado = document.querySelector("#inputEstado")
const inputPais = document.querySelector("#inputPais")

btnEditEndereco.addEventListener('click', () => {
    btnCancelEndereco.style.display = "block"
    btnConfirmEndereco.style.display = "block"
    btnEditEndereco.style.display = "none"


    inputRua.disabled = false
    inputNumero.disabled = false
    inputBairro.disabled = false
    inputComplemento.disabled = false
    inputCep.disabled = false
    inputCidade.disabled = false
    inputEstado.disabled = false
    inputPais.disabled = false
})

btnConfirmEndereco.addEventListener('click', () => {
    let urlCurrent = window.location.href

    btnCancelEndereco.style.display = "none"
    btnConfirmEndereco.style.display = "none"
    btnEditEndereco.style.display = "block"

    var formData = new FormData()

    formData.append("Rua", inputRua.value)
    formData.append("Numero", inputNumero.value)
    formData.append("Bairro", inputBairro.value)
    formData.append("Complemento", inputComplemento.value)
    formData.append("Cep", inputCep.value)
    formData.append("Cidade", inputCidade.value)
    formData.append("Estado", inputEstado.value)
    formData.append("Pais", inputPais.value)

    fetch("/Usuario/AtualizarEndereco", {
        method: "POST",
        body: formData
    })
        .then(function () {
            let value = '/1'
            window.location.href = 'https://localhost:7202/Usuario/Atualizar' + value
        })

    inputRua.disabled = true
    inputNumero.disabled = true
    inputBairro.disabled = true
    inputComplemento.disabled = true
    inputCep.disabled = true
    inputCidade.disabled = true
    inputEstado.disabled = true
    inputPais.disabled = true
})

btnCancelEndereco.addEventListener('click', () => {
    btnCancelEndereco.style.display = "none"
    btnConfirmEndereco.style.display = "none"
    btnEditEndereco.style.display = "block"

    inputRua.disabled = true
    inputNumero.disabled = true
    inputBairro.disabled = true
    inputComplemento.disabled = true
    inputCep.disabled = true
    inputCidade.disabled = true
    inputEstado.disabled = true
    inputPais.disabled = true
})
//FIM ENDEREÇO/CONTATO