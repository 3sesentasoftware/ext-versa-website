using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EUsuarioPerfilModuloNivel
	{
		public int moduloId { get; set; }

		public string modulo { get; set; }
		
		public int usuarioPerfilId { get; set; }

		public string usuarioPerfil { get; set; }

		public int nivel { get; set; }
		
		public string nivelDescripcion { get; set; }

		public static void nuevo(int usuarioPerfilId, int moduloNivelId)
		{
			BDFecade.db().fraseguUsuarioPerfilModuloNivelNuevo(usuarioPerfilId, moduloNivelId);
		}

		public static List<EUsuarioPerfilModuloNivel> obtTodos()
		{
			List<fraseguUsuarioPerfilModuloNivelObtenerTodos_Result> dbres = BDFecade.db().fraseguUsuarioPerfilModuloNivelObtenerTodos().ToList();
			List<EUsuarioPerfilModuloNivel> accesos = new List<EUsuarioPerfilModuloNivel>();
			foreach (fraseguUsuarioPerfilModuloNivelObtenerTodos_Result el in dbres)
			{
				accesos.Add(EUsuarioPerfilModuloNivel.convertTo(el));
			}
			return accesos;
		}

		public static EUsuarioPerfilModuloNivel convertTo(fraseguUsuarioPerfilModuloNivelObtenerTodos_Result el)
		{
			return new EUsuarioPerfilModuloNivel() {
				moduloId = el.frasegu_modulo_id,
				modulo = el.modulo,
				usuarioPerfilId = el.frasegu_usuario_perfil_id,
				usuarioPerfil = el.usuario_perfil,
				nivel = el.nivel,
				nivelDescripcion = el.nivel_descripcion
			};
		}
	}
}