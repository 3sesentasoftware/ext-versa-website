using System.Web.Mvc;
using System.Web.Routing;

namespace Versa_Web
{
	public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
			// Ruta de inicio
			routes.MapRoute("Website - Get - Inicio", 
				"", new { controller = "Home", action = "Index" });

			// Ruta de contacto
			routes.MapRoute("Website - Get - Contacto", 
				"contacto", new { controller = "Home", action = "Contacto" });

			// Ruta para almacenar el mensaje de contacto
			routes.MapRoute("Website - Post - Contacto", 
				"post/contacto", new { controller = "Email", action = "sendMail" });

			// Ruta de nosotros
			routes.MapRoute("Website - Get - Nosotros", 
				"nosotros", new { controller = "Home", action = "Nosotros" });

			// Ruta de busqueda de producto
			routes.MapRoute("Website - Get - Buscar producto", 
				"buscar-producto", new { controller = "Home", action = "BuscarProducto" });

			// Ruta de ver producto por categoria
			routes.MapRoute("Website - Get - Ver productos por categoria", 
				"ver-categoria", new { controller = "Home", action = "VerCategoria" });

			// Ruta de ver producto
			routes.MapRoute("Website - Ver producto",
				"ver-producto", new { controller = "Home", action = "VerProducto" });
            
			// JSON Enfermedades productos
			routes.MapRoute(
				"Website - GET - JSON - Enfermedades producto",
				"get/json/buscar-producto/enfermedades",
				new { controller = "Home", action = "BuscarProducto_GetJSON_Enfermedades" }
			);

			// POST Filtro productos
			routes.MapRoute(
				"Website - POST - Filter producto",
				"post/buscar-producto/filter",
				new { controller = "Home", action = "BuscarProducto_POST_Filter" }
			);

		}
    }
}