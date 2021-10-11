using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EUsuarioPerfil
	{
		public int id { get; set; }

		public string descripcion { get; set; }

		public static List<EUsuarioPerfil> obtTodos()
		{
			List<fraseguUsuarioPerfilObtenerTodos_Result> dbres = BDFecade.db().fraseguUsuarioPerfilObtenerTodos().ToList();
			List<EUsuarioPerfil> perfiles = new List<EUsuarioPerfil>();
			foreach (fraseguUsuarioPerfilObtenerTodos_Result el in dbres)
			{
				perfiles.Add(new EUsuarioPerfil() {
					id = el.id,
					descripcion = el.descripcion
				});
			}
			return perfiles;
		}
	}
}