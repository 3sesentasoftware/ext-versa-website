using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Versa_Web.Models.EntityFramework
{
    public class ProductosViewModel
    {
        public List<P_Aplicacion> ListAplicaciones { get; set; }
        public P_Aplicacion AplicacionItem { get; set; }

        public List<P_Composicion> ListComposicion { get; set; }
        public P_Composicion ComposicionItem { get; set; }

        public List<P_Tipo> ListTipo { get; set; }
        public P_Tipo TipoItem { get; set; }

        public List<Producto> ListProducto { get; set; }
        public Producto ProductoItem { get; set; }

        public List<P_Documentos> ListDocumentos { get; set; }
        public P_Documentos DocumentosItem { get; set; }
    }
}