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
    
    public partial class cms_seccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cms_seccion()
        {
            this.cms_seccion_contenido = new HashSet<cms_seccion_contenido>();
        }
    
        public int cms_seccion_id { get; set; }
        public int website_seccion_id { get; set; }
        public string titulo { get; set; }
        public string descripcion_corta { get; set; }
        public System.DateTime fecha_creado { get; set; }
        public Nullable<System.DateTime> fecha_borrado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cms_seccion_contenido> cms_seccion_contenido { get; set; }
        public virtual website_seccion website_seccion { get; set; }
    }
}
