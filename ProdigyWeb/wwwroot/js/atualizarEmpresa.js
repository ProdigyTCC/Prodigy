//BOTOES EMPRESA
const btnEditEmpresa = document.querySelector("#btnEditEmpresa")
const btnCancelEmpresa = document.querySelector("#btnCancelEmpresa")
const btnConfirmEmpresa = document.querySelector("#btnConfirmEmpresa")

const inputRazao = document.querySelector("#inputRazao")
const inputEmailJuridico = document.querySelector("#inputEmailJuridico")
const inputTelefoneJuridico = document.querySelector("#inputTelefoneJuridico")
const inputCnpj = document.querySelector("#inputCnpj")
const inputRegMunicipal = document.querySelector("#inputRegMunicipal")
const inputRegEstadual = document.querySelector("#inputRegEstadual")
const inputNatureza = document.querySelector("#inputNatureza")
const inputDtFundacao = document.querySelector("#inputDtFundacao")
const inputCertificado = document.querySelector("#inputCertificado")

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
    inputCertificado.disabled = false

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
    formData.append("Certificado", inputCertificado.value)
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
            window.location.href = 'https://localhost:7202/Usuario/Atualizar' + value
        })
        .catch(function () {
            let value = '/2'
            window.location.href = 'https://localhost:7202/Usuario/Atualizar' + value
        })

    inputRazao.disabled = true
    inputEmailJuridico.disabled = true
    inputTelefoneJuridico.disabled = true
    inputCnpj.disabled = true
    inputRegMunicipal.disabled = true
    inputRegEstadual.disabled = true
    inputNatureza.disabled = true
    inputDtFundacao.disabled = true
    inputCertificado.disabled = true

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
    inputCertificado.disabled = true

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