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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UnidadMedida_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnidadMedida_()
        {
            this.Articulo = new HashSet<Articulo_>();
        }
    
        public int idUnidadMedida { get; set; }
        [Display(Name = "Unidad de Medida")]
        public string descipcion { get; set; }
        public Nullable<bool> activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Articulo_> Articulo { get; set; }
    }
}
