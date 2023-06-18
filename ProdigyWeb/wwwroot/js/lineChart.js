const labels = ["JAN", "FEV", "MAR", "ABR", "MAI", "JUN"]

const dataLine = {
  labels: labels,
  datasets: [{
    label: 'Faturamento',
    data: [390, 675, 527, 578, 960, 658, 602],
    fill: false,
    borderColor: 'rgba(48, 190, 178, 1)',
    backgroundColor: 'rgba(48, 190, 178, 1)',
    tension: 0.1
  }, {
    label: 'Despesas',
    data: [1000, 840, 457, 598, 349, 296, 450],
    fill: false,
    borderColor: 'rgb(199, 31, 55)',
    backgroundColor: 'rgb(199, 31, 55)',
    tension: 0.1
  }]
};
  
const configLine = {
  type: 'line',
  data: dataLine
};

const lineChart = new Chart(
  document.querySelectorAll('.line'),
  configLine
);