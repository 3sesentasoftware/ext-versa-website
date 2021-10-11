using com.carzapc.core.web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
    public class CmsCarruselController : Controller
    {
		// GET: CmsCarrusel
		[HttpPost]
		public ActionResult cmsHomeCarruselNuevo(FormCollection formColl, HttpPostedFileBase imagenEscritorio, HttpPostedFileBase imagenMovil)
		{
			if (SysSession.IsSessionOpen(this))
			{
				return View(Utils.Vistas.vistaSeccionHome);
			}
			else
			{
				SysSession.closeSession(this);
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}
    }
}