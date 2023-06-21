const moduloAtivo = document.querySelector("#moduloAtivo")
const moduloLoja = document.querySelector("#moduloLoja")

const btnLoja = document.querySelector("#btnLoja")
const btnAtivo = document.querySelector("#btnAtivo")

moduloLoja.style.display = "block"
moduloAtivo.style.display = "none"

btnLoja.addEventListener('click', () => {
    moduloLoja.style.display = "block"
    moduloAtivo.style.display = "none"
})

btnAtivo.addEventListener('click', () => {
    moduloLoja.style.display = "none"
    moduloAtivo.style.display = "block"
})  