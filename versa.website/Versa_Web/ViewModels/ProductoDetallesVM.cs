using System.Collections.Generic;
using Versa_Web.Models.EntityFramework;

namespace Versa_Web.ViewModels
{
    public class ProductoDetallesVM
    {
        public IEnumerable<Producto> Producto { get; set; }
        public IEnumerable<P_Aplicacion> P_Aplicacion { get; set; }
		public IEnumerable<P_Aplicacion> P_Aplicacion_Agricultura_Protegida { get; set; }
        public IEnumerable<P_Composicion> P_Composicion { get; set; }
        public IEnumerable<P_Documentos> P_Documentos { get; set; }
        public string alias { get; set; }
        public string ingrediente { get; set; }
		public string nombre_categoria { get; set; }
		public List<sel_tabla_composicion_por_id_producto_Result> data_tabla_composicion { get; set; }
		public List<sel_tabla_aplicacion_titulo_por_id_producto_Result> data_tabla_aplicacion_titulo { get; set; }
    }
}



