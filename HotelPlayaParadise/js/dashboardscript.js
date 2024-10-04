// Función para obtener datos desde el endpoint
async function fetchData(url) {
    const response = await fetch(url);
    return response.json();
}

 //Función para renderizar estadísticas generales
async function renderGeneralStats() {
    const data = await fetchData('http://localhost:8000/dashboard-general/dashboard-general');

    const generalStats = `
        
           ${data.num_habitaciones}
          ${data.num_clientes}
            ${data.num_intermediarios}
             ${data.num_paquetes}

    `;

    document.getElementById('general-stats').innerHTML = generalStats;
}

// Función para renderizar el gráfico de paquetes más solicitados
async function renderBarPaquete() {
    const data = await fetchData('http://localhost:8000/dashboard-general/dashboard-general');

    Highcharts.chart('bar-paquete', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Paquete Más Solicitado'
        },
        xAxis: {
            categories: data.paquete_mas_solicitado.nombre,
            title: {
                text: 'Paquetes'
            }
        },
        yAxis: {
            title: {
                text: 'Cantidad'
            }
        },
        series: [{
            name: 'Cantidad',
            data: data.paquete_mas_solicitado.cantidad
        }]
    });
}

// Función para renderizar el gráfico de métodos de pago
async function renderBarMetodoPago() {
    const data = await fetchData('http://localhost:8000/dashboard-general/dashboard-general');

    // Definir una paleta de colores
    const colors = ['#7cb5ec', '#434348', '#90ed7d', '#f7a35c', '#8085e9',
        '#f15c80', '#e4d354', '#2b908f', '#f45b5b', '#91e8e1'];

    Highcharts.chart('bar-metodo-pago', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Cantidad de Clientes por Método de Pago'
        },
        xAxis: {
            categories: data.clientes_por_metodo_pago.metodo_pago,
            title: {
                text: 'Método de Pago'
            }
        },
        yAxis: {
            title: {
                text: 'Cantidad'
            }
        },
        series: [{
            name: 'Cantidad',
            data: data.clientes_por_metodo_pago.cantidad,
            colorByPoint: true, // Aplicar colores por punto
            colors: colors // Utilizar la paleta de colores definida
        }]
    });
}


// Función para renderizar el gráfico de nacionalidades
async function renderPieNacionalidad() {
    const data = await fetchData('http://localhost:8000/dashboard-general/clientes-por-nacionalidad');

    Highcharts.chart('pie-nacionalidad', {
        chart: {
            type: 'pie'
        },
        title: {
            text: 'Distribución de Clientes por Nacionalidad'
        },
        series: [{
            name: 'Clientes',
            data: data.map(item => ({
                name: item.nacionalidad,
                y: item.cantidad
            }))
        }]
    });
}

// Función para renderizar el gráfico de capacidad de habitaciones
async function renderBarCapacidad() {
    const data = await fetchData('http://localhost:8000/dashboard-general/habitaciones-por-capacidad');

    // Definir una paleta de colores variada
    const colors = ['#7cb5ec', '#f7a35c', '#90ed7d', '#f15c80', '#2b908f',
        '#f45b5b', '#91e8e1', '#8085e9', '#e4d354', '#434348'];

    Highcharts.chart('bar-capacidad', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Distribución de Habitaciones por Capacidad'
        },
        xAxis: {
            categories: data.map(item => item.capacidad.toString()),
            title: {
                text: 'Capacidad'
            }
        },
        yAxis: {
            title: {
                text: 'Cantidad'
            }
        },
        series: [{
            name: 'Cantidad',
            data: data.map(item => item.cantidad),
            colorByPoint: true, // Aplicar colores por punto
            colors: colors // Utilizar la paleta de colores definida
        }]
    });
}



// Función para renderizar el gráfico de precio promedio por tipo de habitación
async function renderBarPrecioTipoHabitacion() {
    const data = await fetchData('http://localhost:8000/dashboard-general/precio-promedio-por-tipo-habitacion');

    // Definir una paleta de colores pastel
    const colors = ['#a7c5eb', '#f7c9b8', '#d9ead3', '#f4d0e5', '#c7e5e4',
        '#f3d9a6', '#ebf2f5', '#d8d7f3', '#e2d9c6', '#c4c4c4'];

    Highcharts.chart('bar-precio-tipo-habitacion', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Precio Promedio por Tipo de Habitación'
        },
        xAxis: {
            categories: data.map(item => item.tipo_habitacion),
            title: {
                text: 'Tipo de Habitación'
            }
        },
        yAxis: {
            title: {
                text: 'Precio Promedio'
            }
        },
        series: [{
            name: 'Precio Promedio',
            data: data.map(item => item.precio_promedio),
            colorByPoint: true, // Aplicar colores por punto
            colors: colors // Utilizar la paleta de colores pastel
        }]
    });
}


// Función para renderizar el gráfico de reservas por intermediario
async function renderBarIntermediario() {
    const data = await fetchData('http://localhost:8000/dashboard-general/reservas-por-intermediario');

    // Definir una paleta de colores adecuada para varias categorías
    const colors = ['#7cb5ec', '#f7a35c', '#90ed7d', '#f15c80', '#2b908f',
        '#f45b5b', '#91e8e1', '#8085e9', '#e4d354', '#434348',
        '#c7e5e4', '#f3d9a6', '#ebf2f5', '#d8d7f3', '#e2d9c6'];

    Highcharts.chart('bar-intermediario', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Número de Reservas por Intermediario'
        },
        xAxis: {
            categories: data.map(item => item.intermediario),
            title: {
                text: 'Intermediario'
            }
        },
        yAxis: {
            title: {
                text: 'Cantidad'
            }
        },
        series: [{
            name: 'Cantidad',
            data: data.map(item => item.cantidad),
            colorByPoint: true, // Aplicar colores por punto
            colors: colors // Utilizar la paleta de colores definida
        }]
    });
}


// Función para renderizar el gráfico de ingresos por paquete
async function renderBarIngresosPaquete() {
    const data = await fetchData('http://localhost:8000/dashboard-general/ingresos-por-paquete');

    // Definir una paleta de colores para resaltar los paquetes
    const colors = ['#7cb5ec', '#f7a35c', '#90ed7d', '#f15c80', '#2b908f',
        '#f45b5b', '#91e8e1', '#8085e9', '#e4d354', '#434348'];

    Highcharts.chart('bar-ingresos-paquete', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Ingresos Totales por Paquete'
        },
        xAxis: {
            categories: data.map(item => item.paquete),
            title: {
                text: 'Paquete'
            }
        },
        yAxis: {
            title: {
                text: 'Ingresos Totales'
            }
        },
        series: [{
            name: 'Ingresos Totales',
            data: data.map(item => item.ingresos_totales),
            colorByPoint: true, // Aplicar colores por punto
            colors: colors // Utilizar la paleta de colores definida
        }]
    });
}

// Llamar a las funciones para renderizar los gráficos
renderGeneralStats();
renderBarPaquete();
renderBarMetodoPago();
renderPieNacionalidad();
renderBarCapacidad();
renderBarPrecioTipoHabitacion();
renderBarIntermediario();
renderBarIngresosPaquete();
