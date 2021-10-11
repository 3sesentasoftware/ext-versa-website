using System.Collections.Generic;
using System.Linq;
using Versa_Web.Code.fecades;
using Versa_Web.Models.EntityFramework;

namespace Versa_Web.Models.Objetos
{
	public class ProductoSKUObj
	{
		public static List<sel_productos_sku_Result> ObtProductoSKU()
		{
            var db = DBFecade.dbObj();
			List<sel_productos_sku_Result> dbres_productos_sku = db.sel_productos_sku().ToList();
			return dbres_productos_sku;
		}
	}
}