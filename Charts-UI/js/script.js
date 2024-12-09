document.addEventListener("DOMContentLoaded", () => {
  const ctx = document.getElementById("myChart").getContext("2d");
  let myChart = null;

  // Veriyi sessionStorage'dan al
  const data = JSON.parse(sessionStorage.getItem("jsonData"));

  if (data === null) {
    console.error("Veri bulunamadı.");
    return;
  }

  const chartTypeSelect = document.getElementById("chartType");

  const generateColors = (count) => {
    const colors = [];
    for (let i = 0; i < count; i++) {
      colors.push(`hsl(${Math.random() * 360}, 100%, 75%)`);
    }
    return colors;
  };

  const updateChart = () => {
    const chartType = chartTypeSelect.value;

    const labels = [];
    const values = [];

    if (data.length > 0) {
      if (data[0].author) {
        data.forEach((item) => {
          labels.push(item.author || item.brand || item.director);
          values.push(item.totalSales || item.totalViews);
        });
      } else {
        data.forEach((item) => {
          labels.push(item.brand || item.director || "Unknown");
          values.push(item.totalSales || item.totalViews);
        });
      }
    }

    if (myChart) {
      myChart.destroy();
    }

    myChart = new Chart(ctx, {
      type: chartType,
      data: {
        labels: labels,
        datasets: [
          {
            label: "Veri",
            data: values,
            backgroundColor: generateColors(labels.length),
            borderColor: generateColors(labels.length),
            borderWidth: 1,
          },
        ],
      },
      options: {
        responsive: true,
        plugins: {
          legend: {
            position: "top",
          },
          tooltip: {
            callbacks: {
              label: function (context) {
                return context.label + ": " + context.raw;
              },
            },
          },
        },
      },
    });
  };

  // Etkinlik dinleyici
  chartTypeSelect.addEventListener("change", updateChart);

  updateChart(); // İlk yükleme
});
