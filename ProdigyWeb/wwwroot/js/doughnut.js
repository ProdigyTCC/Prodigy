const data = {
  datasets: [{
    data: [570, 50, 100],
    backgroundColor: [
      'rgba(29, 120, 112, 1)',
      'rgba(48, 190, 178, 1)',
      'rgb(199, 31, 55)'
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
        xAxes: [{
            gridLines: {
                color: "rgba(0, 0, 0, 0)",
            }
        }],
        yAxes: [{
            gridLines: {
                color: "rgba(0, 0, 0, 0)",
            }   
        }]
      }
    }
  };

  const myChart = new Chart(
    document.getElementById('myChart'),
    config
  );

  