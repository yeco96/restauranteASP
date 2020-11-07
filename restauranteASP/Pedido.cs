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
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.PedidoDetalle = new HashSet<PedidoDetalle>();
        }
    
        public int idPedido { get; set; }
        public string idCliente { get; set; }
        public string observacion { get; set; }
        public Nullable<decimal> numeroFactura { get; set; }
        public Nullable<int> idMesa { get; set; }
        public int idEstado { get; set; }
        public Nullable<int> idCaja { get; set; }
        public string usuario { get; set; }
        public decimal subTotal { get; set; }
        public decimal descuento { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
    
        public virtual Caja Caja { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Mesa Mesa { get; set; }
        public virtual PedidoEstado PedidoEstado { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}