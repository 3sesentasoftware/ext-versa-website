using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EProductoSKU : IEntities
	{
		public string id { get; set; }

		public string sku { get; set; }
		
		public List<IEntities> obtTodos()
		{
			List<IEntities> productosSku = new List<IEntities>();
			foreach (sel_sku_para_intra_ver_productos_Result el in BDFecade.db().sel_sku_para_intra_ver_productos().ToList())
				productosSku.Add(convertir(el));
			return productosSku;
		}

		private EProductoSKU convertir(sel_sku_para_intra_ver_productos_Result el)
		{
			return new EProductoSKU() {
				id = el.id,
				sku = el.sku
			};
		}

		//	# #	# #	# #	# #	# #	# #	# #	# # DEPRECATED 10/02/2020 17:51
		//public static List<sel_productos_sku_Result> ObtProductoSKU()
		//{
		//	List<sel_productos_sku_Result> dbres_productos_sku = BDFecade.db.sel_productos_sku().ToList();
		//	return dbres_productos_sku;
		//}
	}
}