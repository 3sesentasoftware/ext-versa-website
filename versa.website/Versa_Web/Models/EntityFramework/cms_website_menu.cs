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
    
    public partial class cms_website_menu
    {
        public int cms_website_menu_id { get; set; }
        public string url { get; set; }
        public string controlador { get; set; }
        public string accion { get; set; }
        public string texto { get; set; }
        public Nullable<int> cms_website_menu_padre_id { get; set; }
        public System.DateTime fecha_creado { get; set; }
        public Nullable<System.DateTime> fecha_borrado { get; set; }
        public Nullable<int> prioridad { get; set; }
        public string html_control_id { get; set; }
    }
}
