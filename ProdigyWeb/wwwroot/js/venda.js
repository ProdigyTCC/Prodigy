function adicionarInput() {
  var select = document.getElementById("pagamentoVenda");
  var selectedOption = select.options[select.selectedIndex].value;

  if (selectedOption === "pagamentoCredito") {
    var inputContainer = document.getElementsByClassName("group-input-contato")[1];
    var novoCodigo = `
      <div class="group-input-contato" id="parcelamentoInput">
        <p class="label-estoque">Parcelamento</p>
        <div class="input-contato input-group">
          <select class="form-select m-0" aria-label="Default select example">
            <option selected>Escolha o parcelamento</option>
            <option value="1">1x sem juros</option>
            <option value="2">2x sem juros</option>
            <option value="3">3x sem juros</option>
            <option value="4">4x sem juros</option>
            <option value="5">5x sem juros</option>
            <option value="6">6x sem juros</option>
            <option value="7">7x sem juros</option>
            <option value="8">8x sem juros</option>
            <option value="9">9x sem juros</option>
            <option value="10">10x sem juros</option>
          </select>
        </div>
      </div>
    `;

    var newElement = document.createElement("div");
    newElement.innerHTML = novoCodigo;
    inputContainer.parentNode.insertBefore(newElement, inputContainer.nextSibling);
  } else {
    var parcelamentoInput = document.getElementById("parcelamentoInput");
    if (parcelamentoInput) {
      parcelamentoInput.parentNode.removeChild(parcelamentoInput);
    }
  }
}
