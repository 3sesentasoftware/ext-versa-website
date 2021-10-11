using System.Collections.Generic;
using System.Linq;
using Versa_Web.Code.fecades;
using Versa_Web.Models.EntityFramework;

namespace Versa_Web.Models.Objetos
{
	public class ProductoTipoObj
	{
		public int id { get; set; }

		public string nombre { get; set; }

		public static List<ProductoTipoObj> ObtProductoTipo()
		{
            var db = DBFecade.dbObj();

			List<sel_producto_tipo_Result> dbres_tipos_productos = db.sel_producto_tipo().ToList();

			List<ProductoTipoObj> dbres_tipos_productos_obj = new List<ProductoTipoObj>();

			dbres_tipos_productos_obj.Add(new ProductoTipoObj()
			{
				id = -1,
				nombre = "Seleccione un producto"
			});
			foreach (sel_producto_tipo_Result item in dbres_tipos_productos)
			{
				dbres_tipos_productos_obj.Add(new ProductoTipoObj()
				{
					id = item.id,
					nombre = item.nombre
				});
			}

			return dbres_tipos_productos_obj;
		}
	}
}