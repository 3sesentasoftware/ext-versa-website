using System.Web.Mvc;

namespace com.carzapc.core.web
{
	public class Recursos
	{
		public static string obtImagen(string nombreArchivo, WebViewPage contexto)
		{
			return contexto.Url.Content(Utils.Directorios.imagenes + "/" + nombreArchivo);
		}

		public static string obtUrlImagen(string nombreArchivo)
		{
			return "~/" + Utils.Ruta.rutaObtImagen.route + "?ni=" + nombreArchivo;
		}

		public static string obtRutaEstatica(string rutaRelativa, Controller contexto)
		{
			return contexto.Server.MapPath(rutaRelativa);
		}
	}
}