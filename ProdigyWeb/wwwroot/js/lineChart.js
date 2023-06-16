const labels = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho"]

const dataLine = {
  labels: labels,
  datasets: [{
    label: 'Faturamento',
    data: [390, 675, 527, 578, 960, 658, 602],
    fill: false,
    borderColor: 'rgba(48, 190, 178, 1)',
    tension: 0.1
  }, {
    label: 'Despesas',
    data: [1000, 840, 457, 598, 349, 296, 450],
    fill: false,
    borderColor: 'rgba(255, 35, 35, 1)',
    tension: 0.1
  }]
};
  
const configLine = {
  type: 'line',
  data: dataLine
};

const lineChart = new Chart(
  document.getElementById('line'),
  configLine
);