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
    
    public partial class CajaMovimiento_
    {
        public int idCaja { get; set; }
        public int secuencia { get; set; }
        public Nullable<int> idTipoMoviento { get; set; }
        public Nullable<int> idTipoMedioPago { get; set; }
        public Nullable<decimal> monto { get; set; }
    
        public virtual Caja_ Caja { get; set; }
        public virtual CajaTipoMoviento_ CajaTipoMoviento { get; set; }
    }
}
