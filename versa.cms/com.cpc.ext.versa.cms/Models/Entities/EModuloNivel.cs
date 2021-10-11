using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EModuloNivel
	{
		public int id { get; set; }

		public int nivel { get; set; }

		public string descripcion { get; set; }

		public static List<EModuloNivel> obtenerTodosPorModuloId(int moduloId)
		{
			List<fraseguModuloNivelObtenerPorModulo_Result> dbres = BDFecade.db().fraseguModuloNivelObtenerPorModulo(moduloId).ToList();
			List<EModuloNivel> niveles = new List<EModuloNivel>();
			foreach (fraseguModuloNivelObtenerPorModulo_Result el in dbres)
			{
				niveles.Add(EModuloNivel.convertTo(el));
			}
			return niveles;
		}

		public static EModuloNivel convertTo(fraseguModuloNivelObtenerPorModulo_Result el)
		{
			return new EModuloNivel() {
				id = el.id,
				nivel = el.nivel,
				descripcion = el.descripcion
			};
		}
	}
}