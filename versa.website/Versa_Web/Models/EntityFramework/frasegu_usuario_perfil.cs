//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Versa_Web.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class frasegu_usuario_perfil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public frasegu_usuario_perfil()
        {
            this.usuario = new HashSet<usuario>();
            this.frasegu_modulo_nivel = new HashSet<frasegu_modulo_nivel>();
        }
    
        public int frasegu_usuario_perfil_id { get; set; }
        public string descripcion { get; set; }
        public bool activo_inactivo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<frasegu_modulo_nivel> frasegu_modulo_nivel { get; set; }
    }
}
