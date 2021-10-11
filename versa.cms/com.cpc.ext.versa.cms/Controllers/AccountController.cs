using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.Entities;
using com.cpc.ext.versa.cms.Models.IModels;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
	public class AccountController : Controller
    {
		[HttpPost]
		public ActionResult autenticar(FormCollection formColl)
		{
			string correoUsuario = formColl["login-correo-usuario"];
			string passUsuario = formColl["login-password"];

			int usuarioId = EUsuario.autenticar(correoUsuario, passUsuario);
			if (usuarioId > 0)
			{
				// El login fue exitoso

				SysSession.openSession(this, usuarioId);
				IngresoAplicacionHandler.Correcto(usuarioId, this);
				return Redirect(Utils.Ruta.rutaVistaHome.getRedirect());
			}
			else
			{
				//	No fue exitoso el login

				ViewBag.mostrar_error = true;
				SysSession.closeSession(this);
				IngresoAplicacionHandler.Fallido(correoUsuario, passUsuario, this);
				return View(Utils.Vistas.vistaLogin);
			}
		}

		[HttpGet]
		public ActionResult cerrarSesion()
		{
			SysSession.closeSession(this);
			return Redirect(Utils.Ruta.rutaVistaHome.getRedirect());
		}
		
	}

	public class IngresoAplicacionHandler
	{
		public static void Fallido(string correoUsuario, string passUsuario, Controller context)
		{
			IngresoAplicacion.nuevoIngresoAplicacionFallido(correoUsuario, passUsuario, context.Request.UserHostAddress, context.Request.UserAgent, context.Request.Browser.Browser);
		}

		public static void Correcto(int usuarioId, Controller context)
		{
			IngresoAplicacion.nuevoIngresoAplicacion(usuarioId, context.Request.UserHostAddress, context.Request.UserAgent, context.Request.Browser.Browser);
		}
	}

}