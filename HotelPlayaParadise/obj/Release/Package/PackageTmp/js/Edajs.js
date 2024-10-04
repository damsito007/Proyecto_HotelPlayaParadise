
async function fetchData(url) {
    const response = await fetch(url);
    return response.json();
}
async function renderTable() {
    const data = await fetchData('http://localhost:8000/df/test-schema/df');
    const tableBody = document.getElementById('table-body');

    data.forEach(record => {
        const row = document.createElement('tr');
        const columns = [
            'Full Name', 'Nacionalidad', 'Tipo Cliente', 'Método Reserva',
            'Nombre Paquete', 'Descripción Paquete', 'Tipo Habitación',
            'Capacidad Habitación', 'Nombre Intermediario', 'Fecha Reservación',
            'Fecha Check In', 'Fecha Check Out', 'Precio Noche', 'Precio Paquete',
            'Días Ocupación', 'Método Pago'
        ];

        columns.forEach(column => {
            const cell = document.createElement('td');
            cell.textContent = record[column];
            row.appendChild(cell);
        });

        tableBody.appendChild(row);
    });
}

async function renderHistogram() {
    try {
        // Obtener los datos del servidor
        const data = await fetchData('http://localhost:8000/df/test-schema/histograma-precio-noche');

        // Preparar los datos para Highcharts
        const categories = Object.keys(data); // Obtener los tipos de habitación

        // Calcular la frecuencia de cada precio por tipo de habitación
        const seriesData = categories.map(category => {
            const prices = data[category];
            const frequency = {};

            // Contar la frecuencia de cada precio
            prices.forEach(price => {
                if (frequency[price]) {
                    frequency[price]++;
                } else {
                    frequency[price] = 1;
                }
            });

            // Convertir a un formato compatible con Highcharts
            const dataPoints = [];
            Object.keys(frequency).forEach(price => {
                dataPoints.push([parseFloat(price), frequency[price]]);
            });

            // Ordenar los puntos de datos por precio ascendente
            dataPoints.sort((a, b) => a[0] - b[0]);

            return {
                name: category,
                data: dataPoints
            };
        });

        // Configurar el gráfico con Highcharts
        Highcharts.chart('histogram-container', {
            chart: {
                type: 'column'
            },
            title: {
                text: 'Histograma de Precio Noche por Tipo de Habitación'
            },
            xAxis: {
                title: {
                    text: 'Precio Noche'
                }
            },
            yAxis: {
                title: {
                    text: 'Frecuencia'
                }
            },
            series: seriesData
        });

    } catch (error) {
        console.error('Error al obtener los datos:', error);
    }
}


async function renderBoxPlot() {
    try {
        const data = await fetchData('http://localhost:8000/df/test-schema/box-plot');
        console.log(data);

        // Preparar los datos para Highcharts
        const seriesData = Object.keys(data).map(key => ({
            name: key,
            data: [[
                data[key].boxplot[0], // low (mínimo)
                data[key].boxplot[1], // q1 (primer cuartil)
                data[key].boxplot[2], // median (mediana)
                data[key].boxplot[3], // q3 (tercer cuartil)
                data[key].boxplot[4]  // high (máximo)
            ]]
        }));

        // Crear el gráfico de boxplot con Highcharts
        Highcharts.chart('boxplot-container', {
            chart: {
                type: 'boxplot'
            },
            title: {
                text: 'Box Plot'
            },
            xAxis: {
                categories: Object.keys(data),
                title: {
                    text: 'Métricas'
                }
            },
            yAxis: {
                title: {
                    text: 'Valores'
                }
            },
            series: [{
                name: 'Observaciones',
                data: seriesData.map(item => item.data[0])
            }]
        });

    } catch (error) {
        console.error('Error al obtener los datos para el boxplot:', error);
    }
}

async function renderScatterPlot() {
    const data = await fetchData('http://localhost:8000/df/test-schema/scatter-precio-paquete');

    Highcharts.chart('scatter-container', {
        chart: {
            type: 'scatter'
        },
        title: {
            text: 'Scatter Plot de Precio Paquete'
        },
        xAxis: {
            title: {
                text: 'Índice'
            }
        },
        yAxis: {
            title: {
                text: 'Precio Paquete'
            }
        },
        series: [{
            name: 'Precio Paquete',
            data: data
        }]
    });
}

async function renderHeatMap() {
    const data = await fetchData('http://localhost:8000/df/test-schema/heat-map');

    // Mapear categorías a índices
    const xAxisCategories = data.xAxisCategories;
    const yAxisCategories = data.yAxisCategories;

    // Transformar los datos del heatmap a índices
    const heatmapData = data.heatmapData.map(item => ({
        x: xAxisCategories.indexOf(item.x),
        y: yAxisCategories.indexOf(item.y),
        value: item.value
    }));

    Highcharts.chart('heatmap-container', {
        chart: {
            type: 'heatmap'
        },
        title: {
            text: 'Mapa de Calor'
        },
        xAxis: {
            categories: xAxisCategories,
            title: {
                text: 'Atributos'
            }
        },
        yAxis: {
            categories: yAxisCategories,
            title: {
                text: 'Atributos'
            }
        },
        colorAxis: {
            min: 0,
            stops: [
                [0, '#FFFFFF'],
                [0.5, '#FF0000'],
                [1, '#a60602']
            ]
        },
        series: [{
            name: 'Correlación',
            borderWidth: 1,
            data: heatmapData,
            dataLabels: {
                enabled: true,
                color: '#000000'
            }
        }]
    });
}

async function renderCorrelation() {
    const data = await fetchData('http://localhost:8000/df/test-schema/correlation');

    Highcharts.chart('correlation-container', {
        chart: {
            type: 'heatmap'
        },
        title: {
            text: 'Correlación'
        },
        xAxis: {
            categories: data.xAxisCategories,
            title: {
                text: 'Método de Pago'
            }
        },
        yAxis: {
            categories: data.yAxisCategories,
            title: {
                text: 'Tipo de Habitación'
            }
        },
        colorAxis: {
            min: 0,
            stops: [
                [0, '#FFFFFF'],
                [0.5, '#FF0000'],
                [1, '#000000']
            ]
        },
        series: [{
            name: 'Correlación',
            borderWidth: 1,
            data: data.heatmapData,
            dataLabels: {
                enabled: true,
                color: '#000000'
            }
        }]
    });
}

async function renderSummaryStatistics() {
    const data = await fetchData('http://localhost:8000/df/test-schema/summary-statistics');

    let htmlContent = '<table border="1"><tr><th>Estadística</th><th>Valor</th></tr>';
    for (const key in data) {
        htmlContent += `<tr><td>${key}</td><td>${JSON.stringify(data[key])}</td></tr>`;
    }
    htmlContent += '</table>';

    document.getElementById('summary-statistics-container').innerHTML = htmlContent;
}

async function renderJointPlot() {
    const data = await fetchData('http://localhost:8000/df/test-schema/join-plot');

    const { 'Precio Noche': precioNoche, 'Precio Paquete': precioPaquete } = data;

    Highcharts.chart('jointplot-container', {
        chart: {
            type: 'scatter',
            zoomType: 'xy'
        },
        title: {
            text: 'Joint Plot Visualization'
        },
        xAxis: [{
            title: {
                text: 'Precio Noche'
            },
            gridLineWidth: 1
        }, {
            title: {
                text: 'Histograma',
                align: 'high',
                offset: 0,
                opposite: true,
                linkedTo: 0
            },
            gridLineWidth: 0,
            lineWidth: 0,
            tickWidth: 0
        }],
        yAxis: [{
            title: {
                text: 'Precio Paquete'
            },
            gridLineWidth: 1
        }, {
            title: {
                text: 'Histograma',
                align: 'high',
                offset: 0,
                opposite: true,
                linkedTo: 0
            },
            gridLineWidth: 0,
            lineWidth: 0,
            tickWidth: 0
        }],
        legend: {
            enabled: false
        },
        series: [{
            name: 'Precio Noche vs Precio Paquete',
            color: 'rgba(223, 83, 83, .5)',
            data: precioNoche.map((x, i) => [x, precioPaquete[i]]),
            marker: {
                radius: 5
            },
            tooltip: {
                headerFormat: '<b>{series.name}</b><br>',
                pointFormat: 'Precio Noche: {point.x}, Precio Paquete: {point.y}'
            }
        }, {
            type: 'column',
            name: 'Histograma Precio Noche',
            xAxis: 1,
            yAxis: 1,
            data: binData(precioNoche),
            pointPadding: 0,
            groupPadding: 0,
            color: 'rgba(223, 83, 83, .5)'
        }, {
            type: 'column',
            name: 'Histograma Precio Paquete',
            xAxis: 1,
            yAxis: 1,
            data: binData(precioPaquete),
            pointPadding: 0,
            groupPadding: 0,
            color: 'rgba(119, 152, 191, .5)'
        }]
    });
}

function binData(data, bins = 10) {
    const min = Math.min(...data);
    const max = Math.max(...data);
    const binWidth = (max - min) / bins;
    const histogram = Array.from({ length: bins }, (_, i) => ({
        x: min + i * binWidth,
        y: 0
    }));

    data.forEach(value => {
        const binIndex = Math.floor((value - min) / binWidth);
        if (binIndex >= 0 && binIndex < bins) {
            histogram[binIndex].y++;
        }
    });

    return histogram.map(bin => [bin.x, bin.y]);
}

async function renderPairPlot() {
    const data = await fetchData('http://localhost:8000/df/test-schema/pair-plot');

    const { 'Precio Noche': precioNoche, 'Precio Paquete': precioPaquete, 'Dias Ocupacion': diasOcupacion } = data;

    Highcharts.chart('pairplot-container', {
        chart: {
            type: 'scatter',
            zoomType: 'xy'
        },
        title: {
            text: 'Pair Plot Visualization'
        },
        xAxis: {
            title: {
                enabled: true,
                text: 'X Axis'
            },
            startOnTick: true,
            endOnTick: true,
            showLastLabel: true
        },
        yAxis: {
            title: {
                text: 'Y Axis'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'left',
            verticalAlign: 'top',
            x: 100,
            y: 70,
            floating: true,
            backgroundColor: Highcharts.defaultOptions.chart.backgroundColor,
            borderWidth: 1
        },
        plotOptions: {
            scatter: {
                marker: {
                    radius: 5,
                    states: {
                        hover: {
                            enabled: true,
                            lineColor: 'rgb(100,100,100)'
                        }
                    }
                },
                states: {
                    hover: {
                        marker: {
                            enabled: false
                        }
                    }
                },
                tooltip: {
                    headerFormat: '<b>{series.name}</b><br>',
                    pointFormat: '{point.x}, {point.y}'
                }
            }
        },
        series: [{
            name: 'Precio Noche vs Precio Paquete',
            color: 'rgba(223, 83, 83, .5)',
            data: precioNoche.map((x, i) => [x, precioPaquete[i]])
        }, {
            name: 'Precio Noche vs Dias Ocupacion',
            color: 'rgba(119, 152, 191, .5)',
            data: precioNoche.map((x, i) => [x, diasOcupacion[i]])
        }, {
            name: 'Precio Paquete vs Dias Ocupacion',
            color: 'rgba(51, 204, 51, .5)',
            data: precioPaquete.map((x, i) => [x, diasOcupacion[i]])
        }]
    });
}

    renderTable();
    renderHistogram();
    renderBoxPlot();
    renderHeatMap();
    renderCorrelation();
    renderSummaryStatistics();
    renderJointPlot();
    renderPairPlot();
    renderScatterPlot();


