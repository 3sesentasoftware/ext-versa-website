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
    
    public partial class usuario
    {
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public int usuario_perfil_id { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_borrado { get; set; }
        public Nullable<int> usuario_mod { get; set; }
        public string contexto_mod { get; set; }
    
        public virtual frasegu_usuario_perfil frasegu_usuario_perfil { get; set; }
    }
}
