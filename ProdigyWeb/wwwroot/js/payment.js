// Constantes sobre as abas
const abaCartao = document.getElementById('abaCartao');
const abaPix = document.getElementById('abaPix');
const abaBoleto = document.getElementById('abaBoleto');

abaCartao.style.display = "none";
abaPix.style.display = "none";
abaBoleto.style.display = "none";

// Constante sobre as opções
const botaoAvancar = document.querySelector('#avancarForma');

botaoAvancar.addEventListener("click", () => {
    let opcao = document.getElementsByName("opcaoPagamento");
    let valor;

    for (let i = 0; i < opcao.length; i++) {
        if (opcao[i].checked) {
            valor = opcao[i].value;
            break;
        }
    }

    switch (valor) {
        case "cartao":
            abaCartao.style.display = "block";
            document.getElementById('cartao-container').style.display = "block";
            break;

        case "pix":
            abaPix.style.display = "block";
            document.getElementById('pix').style.display = "block";
            break;

        case "boleto":
            abaBoleto.style.display = "block";
            document.getElementById('boleto').style.display = "block";
            break;

        default:
            window.alert('Selecione uma opção correta');
            break;
    }

    document.getElementById('planoInfo').style.alignItems = "center";
    document.getElementById('planInfo').style.display = "none";
    document.getElementById('abaFormaPagamento').style.display = "none";
    document.getElementById('avancarForma').style.display = "none";
});

// Variáveis de checkout
const planoInfo = document.getElementById('planoInfo');
const planInfo = document.getElementById('planInfo');
const cartaoContainer = document.getElementById('cartao-container');
const pix = document.getElementById('pix');
const boleto = document.getElementById('boleto');
const visa = document.getElementById('visa');

planoInfo.style.alignItems = "start";
planInfo.style.display = "block";
cartaoContainer.style.display = "none";
pix.style.display = "none";
boleto.style.display = "none";
visa.style.display = "none";

document.querySelector('#card-number-input').oninput = () => {
    document.querySelector('.card-number-box').innerHTML = document.querySelector('#card-number-input').value;
};

document.querySelector('#card-name-input').oninput = () => {
    document.querySelector('.card-holder-name').innerHTML = document.querySelector('#card-name-input').value;
};

document.querySelector('#exp-month').oninput = () => {
    document.querySelector('.exp-month').innerHTML = document.querySelector('#exp-month').value;
};

document.querySelector('#exp-year').oninput = () => {
    document.querySelector('.exp-year').innerHTML = document.querySelector('#exp-year').value;
};

const cardRotate = document.getElementById('cvv-input');
const frontElement = document.querySelector('#front');
const backElement = document.querySelector('#back');

cardRotate.addEventListener("focus", () => {
  frontElement.style.transform = 'perspective(1000px) rotateY(-180deg)';
  backElement.style.transform = 'perspective(1000px) rotateY(0deg)';
});

cardRotate.addEventListener("blur", () => {
  frontElement.style.transform = 'perspective(1000px) rotateY(0deg)';
  backElement.style.transform = 'perspective(1000px) rotateY(180deg)';
});

document.querySelector('#cvv-input').oninput = () => {
    document.querySelector('.cvv-box').innerHTML = document.querySelector('#cvv-input').value;
};

const inputCardNumber = document.querySelector('#card-number-input');

inputCardNumber.addEventListener("input", formatarInput);

function formatarInput() {
    const valorAtual = inputCardNumber.value;
    let novoValor = "";

    // Remove todos os caracteres não numéricos
    const numeros = valorAtual.replace(/\D/g, "");

    // Adiciona hífen a cada grupo de dois números
    for (let i = 0; i < numeros.length; i += 4) {
        novoValor += numeros.substr(i, 4) + ".";
    }

    // Remove o último hífen, se houver
    if (novoValor.endsWith(".")) {
        novoValor = novoValor.slice(0, -1);
    }

    // Atualiza o valor do input
    inputCardNumber.value = novoValor;
}

// Obtém o elemento de entrada do CPF
var cpfInput = document.getElementById('card-cpf-input');

// Função para formatar o CPF
function formatarCPF(cpf) {
  // Remove caracteres não numéricos
  cpf = cpf.replace(/\D/g, '');

  // Aplica a formatação do CPF (XXX.XXX.XXX-XX)
  cpf = cpf.replace(/(\d{3})(\d)/, '$1.$2');
  cpf = cpf.replace(/(\d{3})(\d)/, '$1.$2');
  cpf = cpf.replace(/(\d{3})(\d{2})$/, '$1-$2');

  // Retorna o CPF formatado
  return cpf;
}

// Formata o CPF quando ocorrer uma mudança no campo de entrada
cpfInput.addEventListener('input', function() {
  cpfInput.value = formatarCPF(cpfInput.value);
});