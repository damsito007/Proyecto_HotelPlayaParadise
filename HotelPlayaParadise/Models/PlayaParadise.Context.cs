﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelPlayaParadise.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actividades_Empleados> Actividades_Empleados { get; set; }
        public virtual DbSet<Check_in_Out> Check_in_Out { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Comentarios_Valoraciones_Clientes> Comentarios_Valoraciones_Clientes { get; set; }
        public virtual DbSet<Compras_Servicios_Adicionales> Compras_Servicios_Adicionales { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Habitaciones> Habitaciones { get; set; }
        public virtual DbSet<Intermediarios> Intermediarios { get; set; }
        public virtual DbSet<Paquetes> Paquetes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Promociones> Promociones { get; set; }
        public virtual DbSet<Registros_Acceso_Hotel> Registros_Acceso_Hotel { get; set; }
        public virtual DbSet<Registros_Actividad_Cliente> Registros_Actividad_Cliente { get; set; }
        public virtual DbSet<Registros_Actividad_Intermediario> Registros_Actividad_Intermediario { get; set; }
        public virtual DbSet<Reservaciones> Reservaciones { get; set; }
        public virtual DbSet<Servicios_Adicionales> Servicios_Adicionales { get; set; }
        public virtual DbSet<Servicios_Comida_Bebida> Servicios_Comida_Bebida { get; set; }
        public virtual DbSet<Transacciones_Financieras> Transacciones_Financieras { get; set; }
        public virtual DbSet<CMI> CMIs { get; set; }
        public virtual DbSet<Indicador> Indicadors { get; set; }
        public virtual DbSet<Indicador_Dato> Indicador_Dato { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<Objetivo> Objetivoes { get; set; }
        public virtual DbSet<Perspectiva> Perspectivas { get; set; }
        public virtual DbSet<Tipo> Tipoes { get; set; }
    }
}