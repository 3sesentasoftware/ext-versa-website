using System.Collections.Generic;
using System.Linq;
using Versa_Web.Code.fecades;
using Versa_Web.Models.EntityFramework;

namespace Versa_Web.Models.Objetos
{
	public class UsuarioObj
	{
		public static string ObtUsuarioNombre(int usuario_id)
		{
            var db = DBFecade.dbObj();
			List<usuario> recnomusu_usuario_list = new List<usuario>();
			var recnomusu_dbres = (from U in db.usuario where U.usuario_id == usuario_id select U).ToList();
			string recnomusu_nombre_usuario = string.Empty;
			foreach (var item in recnomusu_dbres)
			{ recnomusu_nombre_usuario = item.nombre; }
			return recnomusu_nombre_usuario;
		}
	}
}