using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
	public class UsuariosController : Controller
	{
		[HttpPost]
		public ActionResult nuevoUsuario(FormCollection formColl)
		{
			string nombre = formColl["nombre"];
			string correo = formColl["email"];
			string clave = formColl["pass"];
			string usuarioPerfilId = formColl["perfil-usuario"];

			EUsuario.nuevoUsuario(nombre, correo, clave, Convert.ToInt32(usuarioPerfilId));

			return Redirect(Utils.Ruta.rutaVistaVerUsuarios.getRedirect());
		}

		[HttpPost]
		public JArray obtNivelesModulos(FormCollection formColl)
		{
			string moduloId = formColl["modulo-id"];

			List<EModuloNivel> niveles = EModuloNivel.obtenerTodosPorModuloId(Convert.ToInt32(moduloId));
			
			return JArray.FromObject(niveles);
		}

		[HttpPost]
		public ActionResult nuevoNivelModulo(FormCollection formColl)
		{
			string perfilUsuario = formColl["perfil-usuario"];
			string nivelId = formColl["nivel"];

			EUsuarioPerfilModuloNivel.nuevo(Convert.ToInt32(perfilUsuario), Convert.ToInt32(nivelId));

			return Redirect(Utils.Ruta.rutaVistaPerfilesUsuarios.getRedirect());
		}

        [HttpPost]
        public ActionResult borrarUsuario(FormCollection formColl)
        {
            int usuarioId = Convert.ToInt32(formColl["usuario-id"]);

            BDFecade.db().cms_usuarioBorrar(usuarioId);

            return Redirect(Utils.Ruta.rutaVistaVerUsuarios.getRedirect());
        }

        [HttpPost]
        public ActionResult editarUsuario(FormCollection formColl)
        {
            int usuarioId = Convert.ToInt32(formColl["usuario-id"]);
            string password = Convert.ToString(formColl["pass-uno"]);

            BDFecade.db().cms_seccionUsuariosEditar(usuarioId, password);

            return Redirect(Utils.Ruta.rutaVistaVerUsuarios.getRedirect());
        }
    }
}