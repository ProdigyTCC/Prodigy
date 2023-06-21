const btnEditConta = document.querySelector("#btnEditConta")
const btnCancelConta = document.querySelector("#btnCancelConta")
const btnConfirmConta = document.querySelector("#btnConfirmConta")

const btnEditEndereco = document.querySelector("#btnEditEndereco")
const btnCancelEndereco = document.querySelector("#btnCancelEndereco")
const btnConfirmEndereco = document.querySelector("#btnConfirmEndereco")

const btnEditEmpresa = document.querySelector("#btnEditEmpresa")
const btnCancelEmpresa = document.querySelector("#btnCancelEmpresa")
const btnConfirmEmpresa = document.querySelector("#btnConfirmEmpresa")



btnCancelConta.style.display = "none"
btnConfirmConta.style.display = "none"
btnEditConta.style.display = "block"

btnCancelEndereco.style.display = "none"
btnConfirmEndereco.style.display = "none"
btnEditEndereco.style.display = "block"

btnCancelEmpresa.style.display = "none"
btnConfirmEmpresa.style.display = "none"
btnEditEmpresa.style.display = "block"

//BOTOES GERAL

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

    let formData = new FormData()

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
            window.location.pathname = '/Usuario/Atualizar' + value
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

    btnCancelEndereco.style.display = "none"
    btnConfirmEndereco.style.display = "none"
    btnEditEndereco.style.display = "block"

    let formData = new FormData()

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
            window.location.pathname = '/Usuario/Atualizar' + value
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

//EMPRESA
const inputRazao = document.querySelector("#inputRazao")
const inputEmailJuridico = document.querySelector("#inputEmailJuridico")
const inputTelefoneJuridico = document.querySelector("#inputTelefoneJuridico")
const inputCnpj = document.querySelector("#inputCnpj")
const inputRegMunicipal = document.querySelector("#inputRegMunicipal")
const inputRegEstadual = document.querySelector("#inputRegEstadual")
const inputNatureza = document.querySelector("#inputNatureza")
const inputDtFundacao = document.querySelector("#inputDtFundacao")

const inputRuaEmpresa = document.querySelector("#inputRuaEmpresa")
const inputNumeroEmpresa = document.querySelector("#inputNumeroEmpresa")
const inputBairroEmpresa = document.querySelector("#inputBairroEmpresa")
const inputComplementoEmpresa = document.querySelector("#inputComplementoEmpresa")
const inputCepEmpresa = document.querySelector("#inputCepEmpresa")
const inputCidadeEmpresa = document.querySelector("#inputCidadeEmpresa")
const inputEstadoEmpresa = document.querySelector("#inputEstadoEmpresa")
const inputPaisEmpresa = document.querySelector("#inputPaisEmpresa")

btnEditEmpresa.addEventListener('click', () => {
    btnCancelEmpresa.style.display = "block"
    btnConfirmEmpresa.style.display = "block"
    btnEditEmpresa.style.display = "none"


    inputRazao.disabled = false
    inputEmailJuridico.disabled = false
    inputTelefoneJuridico.disabled = false
    inputCnpj.disabled = false
    inputRegMunicipal.disabled = false
    inputRegEstadual.disabled = false
    inputNatureza.disabled = false
    inputDtFundacao.disabled = false

    inputRuaEmpresa.disabled = false
    inputNumeroEmpresa.disabled = false
    inputBairroEmpresa.disabled = false
    inputComplementoEmpresa.disabled = false
    inputCepEmpresa.disabled = false
    inputCidadeEmpresa.disabled = false
    inputEstadoEmpresa.disabled = false
    inputPaisEmpresa.disabled = false
})

btnConfirmEmpresa.addEventListener('click', () => {

    btnCancelEmpresa.style.display = "none"
    btnConfirmEmpresa.style.display = "none"
    btnEditEmpresa.style.display = "block"

    let formData = new FormData()

    formData.append("NomeRazaoEmpresa", inputRazao.value)
    formData.append("EmailEmpresa", inputEmailJuridico.value)
    formData.append("TelefoneEmpresa", inputTelefoneJuridico.value)
    formData.append("CnpjEmpresa", inputCnpj.value)
    formData.append("RgMunicipalEmpresa", inputRegMunicipal.value)
    formData.append("RgEstadualEmpresa", inputRegEstadual.value)
    formData.append("NaturezaEmpresa", inputNatureza.value)
    formData.append("DataFundacaoEmpresa", inputDtFundacao.value)

    formData.append("RuaEmpresa", inputRuaEmpresa.value)
    formData.append("NumeroEmpresa", inputNumeroEmpresa.value)
    formData.append("BairroEmpresa", inputBairroEmpresa.value)
    formData.append("ComplementoEmpresa", inputComplementoEmpresa.value)
    formData.append("CepEmpresa", inputCepEmpresa.value)
    formData.append("CidadeEmpresa", inputCidadeEmpresa.value)
    formData.append("EstadoEmpresa", inputEstadoEmpresa.value)
    formData.append("PaisEmpresa", inputPaisEmpresa.value)

    fetch("/Usuario/AtualizarEmpresa", {
        method: "POST",
        body: formData
    })
        .then(function () {
            let value = '/1'
            window.location.pathname = '/Usuario/Atualizar' + value
        })

    inputRazao.disabled = true
    inputEmailJuridico.disabled = true
    inputTelefoneJuridico.disabled = true
    inputCnpj.disabled = true
    inputRegMunicipal.disabled = true
    inputRegEstadual.disabled = true
    inputNatureza.disabled = true
    inputDtFundacao.disabled = true

    inputRuaEmpresa.disabled = true
    inputNumeroEmpresa.disabled = true
    inputBairroEmpresa.disabled = true
    inputComplementoEmpresa.disabled = true
    inputCepEmpresa.disabled = true
    inputCidadeEmpresa.disabled = true
    inputEstadoEmpresa.disabled = true
    inputPaisEmpresa.disabled = true
})

btnCancelEmpresa.addEventListener('click', () => {
    btnCancelEmpresa.style.display = "none"
    btnConfirmEmpresa.style.display = "none"
    btnEditEmpresa.style.display = "block"

    inputRazao.disabled = true
    inputEmailJuridico.disabled = true
    inputTelefoneJuridico.disabled = true
    inputCnpj.disabled = true
    inputRegMunicipal.disabled = true
    inputRegEstadual.disabled = true
    inputNatureza.disabled = true
    inputDtFundacao.disabled = true

    inputRuaEmpresa.disabled = true
    inputNumeroEmpresa.disabled = true
    inputBairroEmpresa.disabled = true
    inputComplementoEmpresa.disabled = true
    inputCepEmpresa.disabled = true
    inputCidadeEmpresa.disabled = true
    inputEstadoEmpresa.disabled = true
    inputPaisEmpresa.disabled = true
})
//FIM EMPRESA