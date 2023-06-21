const btnEditGeral = document.querySelector("#btnEditGeral")
const btnCancelGeral = document.querySelector("#btnCancelGeral")
const btnConfirmGeral = document.querySelector("#btnConfirmGeral")

btnCancelGeral.style.display = "none"
btnConfirmGeral.style.display = "none"
btnEditGeral.style.display = "block"

const lucro = document.querySelector("#lucro")
const credito = document.querySelector("#credito")
const parcela = document.querySelector("#parcela")
const debito = document.querySelector("#debito")
const dinheiro = document.querySelector("#dinheiro")
const formFileConfig = document.querySelector("#formFileConfig")

btnEditGeral.addEventListener('click', () => {
    btnCancelGeral.style.display = "block"
    btnConfirmGeral.style.display = "block"
    btnEditGeral.style.display = "none"

    lucro.disabled = false
    credito.disabled = false
    parcela.disabled = false
    debito.disabled = false
    dinheiro.disabled = false
    formFileConfig.disabled = false
})

btnConfirmGeral.addEventListener('click', () => {
    btnCancelGeral.style.display = "none"
    btnConfirmGeral.style.display = "none"
    btnEditGeral.style.display = "block"

    lucro.disabled = true
    credito.disabled = true
    parcela.disabled = true
    debito.disabled = true
    dinheiro.disabled = true
    formFileConfig.disabled = true
})

btnCancelGeral.addEventListener('click', () => {
    btnCancelGeral.style.display = "none"
    btnConfirmGeral.style.display = "none"
    btnEditGeral.style.display = "block"
    
    lucro.disabled = true
    credito.disabled = true
    parcela.disabled = true
    debito.disabled = true
    dinheiro.disabled = true
    formFileConfig.disabled = true
})