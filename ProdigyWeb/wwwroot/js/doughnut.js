const data = {
  labels: [
    'Faturamento',
    'Lucro',
    'Despesas'
  ],
  datasets: [{
    label: 'Resumo financeiro',
    data: [570, 50, 100],
    backgroundColor: [
      'rgba(29, 120, 112, 1)',
      'rgba(48, 190, 178, 1)',
      'rgba(255, 35, 35, 1'
    ],
    borderWidth: 0,
    hoverOffset: 4
  }]
};

  const config = {
    type: 'doughnut',
    data: data,
    options: {
      scales: {
        y: {
          beginAtZero: true
        }
      }
    }
  };

  const myChart = new Chart(
    document.getElementById('myChart'),
    config
  );

  