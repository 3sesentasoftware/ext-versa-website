using com.carzapc.core.web;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
	public class RecursosController : Controller
    {
		public ActionResult obtImg()
		{
			string nombreImagen = Request.QueryString["ni"];
			if (!string.IsNullOrWhiteSpace(nombreImagen))
			{
				string rutaFinal = Recursos.obtRutaEstatica(Utils.Directorios.imagenes, this) + "/" + nombreImagen;
				return base.File(rutaFinal, "image/jpeg");
			}
			else
			{
				return Redirect(Utils.Ruta.rutaVistaHome.getRedirect());
			}
		}

		public FileResult obtArch(string nombreArchivo)
		{
			string rutaFinal = Recursos.obtRutaEstatica(Utils.Directorios.imagenes, this);
			string nombreFichero = "Error-404.png";
			byte[] fileBytes = System.IO.File.ReadAllBytes(rutaFinal + "/" + nombreFichero);
			return base.File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, nombreFichero);
		}
    }
}