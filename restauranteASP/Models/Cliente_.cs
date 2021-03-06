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

    public partial class Cliente_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente_()
        {
            this.Pedido = new HashSet<Pedido_>();
        }

        [Required]
        [MinLength(9)]
        [MaxLength(12)]
        [Display(Name = "Identificación")]
        public string idCliente { get; set; }
        [Display(Name = "Nombre Completo")]
        [Required]
        public string nombreCompleto { get; set; }
        [Display(Name = "Correo Electronico")]
        public string correoElectronico { get; set; }
        [Display(Name = "Telefono Celular")]
        [StringLength(8)]
        public string telefonoCelular { get; set; }
        [Display(Name = "Telefono Residencial")]
        [StringLength(8)]
        public string telefonoResidencial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = "Pedido")]
        [JsonIgnore]
        public virtual ICollection<Pedido_> Pedido { get; set; }
    }
}
