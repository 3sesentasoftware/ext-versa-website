using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EProductoTipo : IEntities
	{
		public int id { get; set; }

		public string nombre { get; set; }

		public string imagen { get; set; }

		public string alias { get; set; }

		public string classNameImgMobile { get; set; }
		
		public List<IEntities> obtTodos()
		{
			List<IEntities> productosTipos = new List<IEntities>();

			foreach (cms_pTipoObtenerTodos_Result el in BDFecade.db().cms_pTipoObtenerTodos().ToList())
			{
				productosTipos.Add(convertir(el));
			}

			return productosTipos;
		}

		public void nuevo(string nombre, string imagen, string alias, string classNameImgMobile)
		{
			BDFecade.db().cms_pTipoNuevo(nombre, imagen, alias, classNameImgMobile);
		}

		public void actualizar(int id, string nombre, string imagen, string alias, string classNameImgMobile)
		{
			BDFecade.db().cms_pTipoActualizar(id, nombre, imagen, alias, classNameImgMobile);
		}

		public void eliminar(int id)
		{
			BDFecade.db().cms_pTipoEliminar(id);
		}

		private EProductoTipo convertir(cms_pTipoObtenerTodos_Result el)
		{
			return new EProductoTipo() {
				id = el.id,
				nombre = el.nombre,
				alias = el.alias,
				imagen = el.imagen,
				classNameImgMobile = el.classname_img_mobile
			};
		}
		
	}
}