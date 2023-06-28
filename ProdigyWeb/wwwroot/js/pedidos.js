const maisProduto = document.querySelector('#maisProduto')
const menosProduto = document.querySelector('#menosProduto')
const btnExcluirTabela = document.getElementsByClassName('botao-estoque')

const qtProduto = document.querySelector('#qtProduto')
const valorCusto = document.querySelector('#valorCusto')
const marcaProduto = document.querySelector('#marcaProduto')
const nomeProduto = document.querySelector('#nomeProduto')
const idProduto = document.querySelector('#idProduto')

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

var count = 0
function valorTotal()
{
    const tabelaPedidoResultado = document.querySelector('#tabelaPedidoResultado')

    let textoQuantidade = parseInt(qtProduto.innerHTML)
    let textoValorCusto = parseFloat(valorCusto.innerHTML)
    let total = textoQuantidade * textoValorCusto

    let qtProdutoCurrent = inputQtProduto.value
    let qtTotal = textoQuantidade + parseInt(qtProdutoCurrent)
    inputQtProduto.value = qtTotal.toString()

    let totalCurrent = inputValorProduto.value
    total = total + parseInt(totalCurrent)
    inputValorProduto.value = total.toString()

    let button = document.createElement('button')
    button.setAttribute('type', 'button')
    button.setAttribute('class', 'botao-estoque red-icon-button')
    button.setAttribute('title', 'Excluir pedido')
    button.setAttribute('onclick', 'excluirPedido()')

    let icon = document.createElement('i')
    icon.setAttribute('class', 'fa-solid fa-trash fa-xl')

    button.appendChild(icon);

    let novaLinha = document.createElement("tr")
    novaLinha.setAttribute('class', `linhaPedido${count.toString}`)

    let celula1 = document.createElement("td")
    celula1.textContent = idProduto.innerHTML

    let celula2 = document.createElement("td")
    celula2.textContent = nomeProduto.innerHTML

    let celula3 = document.createElement("td")
    celula3.textContent = marcaProduto.innerHTML

    let celula4 = document.createElement("td")
    celula4.textContent = qtProduto.innerHTML

    let celula5 = document.createElement("td")
    celula5.textContent = `R$ ${valorCusto.innerHTML}`
    
    let celula6 = document.createElement("td")
    celula6.appendChild(button)

    novaLinha.appendChild(celula1)
    novaLinha.appendChild(celula2)
    novaLinha.appendChild(celula3)
    novaLinha.appendChild(celula4)
    novaLinha.appendChild(celula5)
    novaLinha.appendChild(celula6)

    tabelaPedidoResultado.appendChild(novaLinha)
    count++
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

for (var i = 0; i < botoesExcluir.length; i++) 
{
    btnExcluirTabela[i].addEventListener('click', () => {
        
        let linha = document.getElementsByClassName('linhaPedido')
        console.log(excluir)
        tabelaPedidoResultado.removeChild(linha)
        for (var x = 0; x < linha.length; x++)
        {
            const tabelaPedidoResultado = document.querySelector('#tabelaPedidoResultado')
            tabelaPedidoResultado.removeChild(linha[x])
        }
    })
}