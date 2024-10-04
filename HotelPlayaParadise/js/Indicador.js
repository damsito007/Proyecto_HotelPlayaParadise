// Obtiene los datos del endpoint /growth-indicator y actualiza el gráfico de barrass
async function fetchData(url) {
    const response = await fetch(url);
    return response.json();
}
async function fetchDataAndDrawBarChart() {
    try {
        const response = await fetch('http://localhost:8000/growth-indicator/growth-indicator?year=2023&growth_threshold=5');
        const data = await response.json();

        const quarters = data.map(item => item.quarter);
        const numReservationsGrowth = data.map(item => item.num_reservations_growth);
        const totalIncomeGrowth = data.map(item => item.total_income_growth);

        const ctx = document.getElementById('barChart').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: quarters,
                datasets: [
                    {
                        label: 'Crecimiento Reservaciones (%)',
                        backgroundColor: 'rgba(54, 162, 235, 0.5)',
                        borderColor: 'rgba(54, 162, 235, 1)',
                        borderWidth: 1,
                        data: numReservationsGrowth,
                    },
                    {
                        label: 'Crecimiento Ingresos (%)',
                        backgroundColor: 'rgba(255, 99, 132, 0.5)',
                        borderColor: 'rgba(255, 99, 132, 1)',
                        borderWidth: 1,
                        data: totalIncomeGrowth,
                    },
                ]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        stacked: true,
                    },
                    y: {
                        stacked: true
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

async function fetchDataAndDrawLineChart() {
    try {
        const response = await fetch('http://localhost:8000/growth-indicator/growth-indicator?year=2023&growth_threshold=5');
        const data = await response.json();

        const quarters = data.map(item => item.quarter);
        const numReservationsGrowth = data.map(item => item.num_reservations_growth);
        const totalIncomeGrowth = data.map(item => item.total_income_growth);

        const ctx = document.getElementById('lineChart').getContext('2d');
        new Chart(ctx, {
            type: 'line',
            data: {
                labels: quarters,
                datasets: [
                    {
                        label: 'Crecimiento Reservaciones (%)',
                        borderColor: 'rgba(54, 162, 235, 1)',
                        backgroundColor: 'rgba(54, 162, 235, 0.2)',
                        fill: false,
                        data: numReservationsGrowth,
                    },
                    {
                        label: 'Crecimiento Ingresos (%)',
                        borderColor: 'rgba(255, 99, 132, 1)',
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        fill: false,
                        data: totalIncomeGrowth,
                    },
                ]
            },
            options: {
                responsive: true,
                scales: {
                    x: {
                        stacked: true,
                    },
                    y: {
                        stacked: true
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

document.addEventListener('DOMContentLoaded', () => {
    fetchDataAndDrawBarChart();
    fetchDataAndDrawLineChart();
});

