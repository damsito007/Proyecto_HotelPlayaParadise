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
    
    public partial class Objetivo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Objetivo()
        {
            this.Indicadors = new HashSet<Indicador>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Metrica { get; set; }
        public string Ponderacion { get; set; }
        public int CMI_Id { get; set; }
        public int Perspectiva_Id { get; set; }
    
        public virtual CMI CMI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Indicador> Indicadors { get; set; }
        public virtual Perspectiva Perspectiva { get; set; }
    }
}
