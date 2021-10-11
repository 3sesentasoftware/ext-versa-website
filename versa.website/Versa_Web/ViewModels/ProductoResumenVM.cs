using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Versa_Web.ViewModels
{
    public class ProductoResumenVM
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string nombre { get; set; }
        public string subnombre { get; set; }
        public string categoria { get; set; }
        public string classname { get; set; }
        public string cat_img { get; set; }
        public string ingrediente_activo { get; set; }
        public string presentacion { get; set; }        
        public string imagen { get; set; }       
    }
}