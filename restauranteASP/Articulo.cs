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
    
    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
            this.PedidoDetalle = new HashSet<PedidoDetalle>();
        }
    
        public int idArticulo { get; set; }
        public string descipcion { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
        public string sku { get; set; }
        public Nullable<System.DateTime> fechaIngreso { get; set; }
        public Nullable<System.DateTime> fechaCaducidad { get; set; }
        public int idCategoria { get; set; }
        public int idUnidadMedida { get; set; }
        public Nullable<int> idProveedor { get; set; }
        public Nullable<decimal> tarifaImpuesto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
