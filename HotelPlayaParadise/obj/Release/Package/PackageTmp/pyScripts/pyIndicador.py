from flask import Flask, render_template
from flask_cors import CORS
import edaSQL  # conexión a base datos
import pandas as pd
import numpy as np
import seaborn as sns  # visualización
import matplotlib.pyplot as plt  # visualización
from scipy import stats  # Datos atípicos
import io
import base64



app = Flask(__name__, template_folder='../Views/dashboard')
CORS(app)
def get_data():
    try:
        edasql = edaSQL.SQL(printAll=True)

        edasql.connectToDataBase(
            server="LAPTOP-192V3TDJ",
            database="Paradise",
            user="sa",
            password="1234",
            sqlDriver="ODBC Driver 17 for SQL Server"
        )
    except Exception as e:
        print("Ha ocurrido un error con:", e)

    # Definir una función para cargar las tablas a un DataFrame
    def loadTable(table_name):
        query = f"SELECT * FROM {table_name}"
        return pd.read_sql(query, edasql.dbConnection)

    # Función para eliminar duplicados basado en una clave
    def removeDuplicates(df, key):
        if df[key].duplicated().any():
            print(f"Warning: Duplicates found in {key} column of table.")
            df = df.drop_duplicates(subset=[key])
        return df

    # Cargar las tablas en DataFrames
    df_clientes = loadTable("dbo.Dim_Clientes")
    df_fecha = loadTable("dbo.Dim_Fecha")
    df_habitaciones = loadTable("dbo.Dim_Habitaciones")
    df_paquetes = loadTable("dbo.Dim_Paquetes")
    df_intermediarios = loadTable("dbo.Dim_Intermediarios")
    df_actividades_hotel = loadTable("dbo.FactTable_ActividadesHotel")

    # Eliminar duplicados en las tablas de dimensiones basadas en las claves de unión
    df_clientes = removeDuplicates(df_clientes, 'Clientes_id')
    df_fecha = removeDuplicates(df_fecha, 'Fecha_id')
    df_habitaciones = removeDuplicates(df_habitaciones, 'Habitacione_ID')
    df_paquetes = removeDuplicates(df_paquetes, 'Paquete_ID')
    df_intermediarios = removeDuplicates(df_intermediarios, 'Intermediario_ID')

    # Unir las tablas en el DataFrame de hechos
    df_actividades_hotel = df_actividades_hotel \
        .merge(df_clientes, left_on='Clientes_ID', right_on='Clientes_id', how='left', suffixes=('', '_cliente')) \
        .merge(df_paquetes, left_on='Paquetes_ID', right_on='Paquete_ID', how='left', suffixes=('', '_paquete')) \
        .merge(df_habitaciones, left_on='Habitaciones_ID', right_on='Habitacione_ID', how='left', suffixes=('', '_habitacion')) \
        .merge(df_intermediarios, left_on='Intermediarios_ID', right_on='Intermediario_ID', how='left', suffixes=('', '_intermediario')) \
        .merge(df_fecha, left_on='Fecha_Reservacion_ID', right_on='Fecha_id', how='left', suffixes=('', '_fecha'))

    # Combinamos Nombre y apellido de Clientes
    df_actividades_hotel['Nombre_Cliente'] = df_actividades_hotel['Nombre'] + ' ' + df_actividades_hotel['Apellidos']
    df_actividades_hotel.drop(columns=["Nombre", "Apellidos"], inplace=True)

    toRemove = [
        'Paquetes_ID',
        'Habitaciones_ID',
        'Intermediarios_ID',
        'Fecha_Reservacion_ID',
        'Dia',
        'Nombre_dia',
        'Num_mes',
        'Festividad',
        'Periodo',
        'Temporada',
    ]

    # filtrar columas
    columsDrop = [
        col
        for col in df_actividades_hotel.columns
        if col.endswith('Id') or col.endswith('ID') or col.endswith('id')
        or any(keyword in col for keyword in toRemove)
    ]

    # Eliminar las columnas obtenidas del DataFrame original para realizar la limpieza de datos
    df_actividades_hotel.drop(columns=columsDrop, inplace=True)

    columnOrder = [
        'Nombre_Cliente', 'Nacionalidad', 'Tipo_Cliente', 'Metodo_Reserva',  # Clientes
        'Fecha_check_in', 'Fecha_check_out',  # fecha
        'Tipo_Habitacion', 'Capacidad', 'Disponibilidad',  # Habitaciones
        'Nombre_Paquetes', 'Descripcion_Paquete',  # Paquetes
        'Precio_Noche', 'Precio_Paquete', 'Metodo_Pago',  # Reservaciones
    ]

    # Ordenar las columnas del DataFrame
    df_actividades_hotel = df_actividades_hotel[columnOrder]

    df_actividades_hotel = df_actividades_hotel.rename(columns={
        "Nombre_Cliente": "Huesped",
        "Tipo_Cliente": "Tipo de Cliente",
        "Metodo_Reserva": "Metodo de Reservación",
        "Tipo_Habitacion": "Tipo Habitación",
        "Metodo_Pago": "Metodo de Pago",
        "Nombre_Paquete": "Nombre del Paquete a Reservar",
    }
    )

    df_actividades_hotel = df_actividades_hotel.drop_duplicates()

    # Agregar la columna 'Gran total'
    df_actividades_hotel['Gran total'] = df_actividades_hotel['Precio_Noche'] + df_actividades_hotel['Precio_Paquete']

    return df_actividades_hotel

def plot_to_img(fig):
    buf = io.BytesIO()
    fig.savefig(buf, format='png')
    buf.seek(0)
    img_base64 = base64.b64encode(buf.getvalue()).decode('utf-8')
    return img_base64

@app.route('/')
def index():
    df_actividades_hotel = get_data()

    # Gráficos
    sns.set(style="whitegrid")

    # Promedio del costo total por tipo de habitación
    promedio_costo_por_habitacion = df_actividades_hotel.groupby('Tipo Habitación')['Gran total'].sum().reset_index()

    # Crear el bar plot
    fig1, ax1 = plt.subplots(figsize=(12, 8))
    barplot = sns.barplot(x='Tipo Habitación', y='Gran total', data=promedio_costo_por_habitacion, estimator=sum, ci=None, palette="coolwarm", ax=ax1)
    barplot.set_title('Total recaudación por Tipo de Habitación', fontsize=18, fontweight='bold')
    barplot.set_xlabel('Tipo de Habitación', fontsize=14, fontweight='bold')
    barplot.set_ylabel('Gran total', fontsize=14, fontweight='bold')
    plt.xticks(rotation=45, fontsize=12)
    plt.yticks(fontsize=12)
    plt.tight_layout()

    for p in barplot.patches:
        barplot.annotate(format(p.get_height(), '.2f'),
                         (p.get_x() + p.get_width() / 2., p.get_height()),
                         ha='center', va='center',
                         xytext=(0, 10),
                         textcoords='offset points',
                         fontsize=12,
                         color='black',
                         fontweight='bold')

    img1 = plot_to_img(fig1)

    # Distribución de Métodos de Pago
    fig2, ax2 = plt.subplots(figsize=(8, 8))
    df_actividades_hotel['Metodo de Pago'].value_counts().plot.pie(autopct='%1.1f%%', startangle=140, colors=sns.color_palette("pastel"), ax=ax2)
    ax2.set_ylabel('')
    ax2.set_title('Distribución de Métodos de Pago')

    img2 = plot_to_img(fig2)

    # Histograma de los costos totales
    fig3, ax3 = plt.subplots(figsize=(10, 6))
    sns.histplot(df_actividades_hotel['Gran total'], bins=20, kde=True, ax=ax3)
    ax3.set_xlabel('Gran total')
    ax3.set_ylabel('Frecuencia')
    ax3.set_title('Distribución de Totales')

    img3 = plot_to_img(fig3)

    # Boxplot de los costos totales por tipo de habitación
    fig4, ax4 = plt.subplots(figsize=(12, 8))
    sns.boxplot(x='Tipo Habitación', y='Gran total', data=df_actividades_hotel, palette="muted", ax=ax4)
    ax4.set_title('Distribución del Costo Total por Tipo de Habitación', fontsize=18, fontweight='bold')
    ax4.set_xlabel('Tipo Habitación', fontsize=14, fontweight='bold')
    ax4.set_ylabel('Gran total', fontsize=14, fontweight='bold')
    plt.xticks(rotation=45, fontsize=12)
    plt.yticks(fontsize=12)
    plt.tight_layout()

    img4 = plot_to_img(fig4)

    # Tabla de Contingencia
    contingency_table = pd.crosstab(df_actividades_hotel['Tipo Habitación'], df_actividades_hotel['Nacionalidad'])

    # Visualizar la tabla de contingencia usando Heatmap
    fig5, ax5 = plt.subplots(figsize=(14, 10))
    sns.heatmap(contingency_table, annot=True, cmap='coolwarm', linewidths=0.5, fmt='d', ax=ax5)
    ax5.set_title('Tabla de Contingencia entre Tipo de Habitación y Nacionalidad')

    img5 = plot_to_img(fig5)

    return render_template('index.cshtml', img1=img1, img2=img2, img3=img3, img4=img4, img5=img5, df_html=df_actividades_hotel.head().to_html(index=False, classes='table table-striped table-bordered'))

if __name__ == '__main__':
    app.run(debug=True)
