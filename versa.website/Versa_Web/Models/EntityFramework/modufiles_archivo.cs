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
    
    public partial class modufiles_archivo
    {
        public int modufiles_archivo_id { get; set; }
        public string archivo_hash { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_borrado { get; set; }
        public bool existencia_disco { get; set; }
    }
}
