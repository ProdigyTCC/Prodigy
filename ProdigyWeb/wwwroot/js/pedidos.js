const maisProduto = document.querySelector('#maisProduto')
const menosProduto = document.querySelector('#menosProduto')
const qtProduto = document.querySelector('#qtProduto')
const valorCusto = document.querySelector('#valorCusto')
const confirmaProduto = document.querySelector('#confirmaProduto')
const valorTotalPedido = document.querySelector('#valorTotal')
const inputQtProduto = document.querySelector('#inputQtProduto')
const inputValorProduto = document.querySelector('#inputValorProduto')

function adicionarQuantidade()
{
    let textoQuantidade = parseInt(qtProduto.innerHTML)
    textoQuantidade += 1

    qtProduto.innerHTML = textoQuantidade.toString()
}

function subtrairQuantidade()
{
    let textoQuantidade = parseInt(qtProduto.innerHTML)
    textoQuantidade -= 1

    qtProduto.innerHTML = textoQuantidade.toString()
}

function valorTotal()
{
    let textoQuantidade = parseInt(qtProduto.innerHTML)
    let textoValorCusto = parseFloat(valorCusto.innerHTML)
    let total = textoQuantidade * textoValorCusto

    valorTotalPedido.innerHTML = `R$ ${total.toString()}`
    inputQtProduto.value = textoQuantidade.toString()
    inputValorProduto.value = total.toString()
}

maisProduto.addEventListener('click', () => {
    adicionarQuantidade();
})

menosProduto.addEventListener('click', () => {
    subtrairQuantidade();
})

confirmaProduto.addEventListener('click', () => {
    valorTotal();
})