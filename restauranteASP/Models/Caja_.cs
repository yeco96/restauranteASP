//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace restauranteASP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Caja_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caja_()
        {
            this.CajaMovimiento = new HashSet<CajaMovimiento_>();
            this.Pedido = new HashSet<Pedido_>();
        }
    
        public int idCaja { get; set; }
        public Nullable<System.DateTime> fechaApertura { get; set; }
        public Nullable<System.DateTime> fechaCierre { get; set; }
        public Nullable<decimal> fondo { get; set; }
        public string usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CajaMovimiento_> CajaMovimiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido_> Pedido { get; set; }
    }
}