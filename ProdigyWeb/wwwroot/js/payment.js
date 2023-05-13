// constantes sobre as abas
document.getElementById('pix').style.display = "none"
document.getElementById('boleto').style.display = "none"
document.getElementById('abaCartao').style.display = "none"
document.getElementById('abaPix').style.display = "none"
document.getElementById('abaBoleto').style.display = "none"
// constantes sobre as opções
const botaoAvancar = document.querySelector('#avancarForma')

botaoAvancar.addEventListener("click", () => {
    let opcao = document.getElementsByName("opcaoPagamento");
    let valor
    
    for (let i = 0; i < opcao.length; i++) {
        if(opcao[i].checked) {
            valor = opcao[i].value
        }
    }
    
    switch (valor) {
        case "cartao":
            document.getElementById('abaCartao').style.display = "block";
            // document.getElementById('cartao-container').style.display = "block";
            // document.getElementById('planInfo').style.display = "none";
            document.getElementById('abaFormaPagamento').style.display = "none";
            document.getElementById('avancarForma').style.display = "none";
            break;
            case "pix":
                document.getElementById('abaPix').style.display = "block";
                document.getElementById('avancarForma').style.display = "none";
            document.getElementById('abaFormaPagamento').style.display = "none";
            break;
        case "boleto":
            document.getElementById('abaBoleto').style.display = "block";
            document.getElementById('avancarForma').style.display = "none";
            document.getElementById('abaFormaPagamento').style.display = "none";
            break;
            default:
                window.alert('Selecione uma opção correta')
                break;
    }
}
)

document.getElementById('planInfo').style.display = "none"
document.getElementById('cartao-container').style.display = "block"
document.getElementById('visa').style.display = "none"

document.querySelector('#card-number-input').oninput = () => {
    document.querySelector('.card-number-box').innerHTML = document.querySelector('#card-number-input').value;
}

document.querySelector('#card-name-input').oninput = () => {
    document.querySelector('.card-holder-name').innerHTML = document.querySelector('#card-name-input').value;
}

document.querySelector('#exp-month').oninput = () => {
    document.querySelector('.exp-month').innerHTML = document.querySelector('#exp-month').value;
}

document.querySelector('#exp-year').oninput = () => {
    document.querySelector('.exp-year').innerHTML = document.querySelector('#exp-year').value;
}

const cardRotate = document.getElementById('cvv-input')

cardRotate.addEventListener("click", () => {
    document.querySelector('#front').style.transform = 'perspective(1000px) rotateY(-180deg)'
    document.querySelector('#back').style.transform = 'perspective(1000px) rotateY(0deg)'
})

cardRotate.addEventListener("mouseout", () => {
    document.querySelector('#front').style.transform = 'perspective(1000px) rotateY(0deg)'
    document.querySelector('#back').style.transform = 'perspective(1000px) rotateY(180deg)'
})

document.querySelector('#cvv-input').oninput = () => {
    document.querySelector('.cvv-box').innerHTML = document.querySelector('#cvv-input').value;
}