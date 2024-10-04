//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Reservaciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservaciones()
        {
            this.Compras_Servicios_Adicionales = new HashSet<Compras_Servicios_Adicionales>();
        }
    
        public int Reservacion_ID { get; set; }
        public Nullable<int> Cliente_ID { get; set; }
        public Nullable<int> Paquete_ID { get; set; }
        public Nullable<int> Habitacion_ID { get; set; }
        public Nullable<int> Intermediario_ID { get; set; }
        public Nullable<System.DateTime> Fecha_Reservacion { get; set; }
        public string Metodo_Pago { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compras_Servicios_Adicionales> Compras_Servicios_Adicionales { get; set; }
        public virtual Habitaciones Habitaciones { get; set; }
        public virtual Intermediarios Intermediarios { get; set; }
        public virtual Paquetes Paquetes { get; set; }
    }
}
