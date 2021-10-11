using com.cpc.ext.versa.cms.Models.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace com.carzapc.core.web
{
	public class Utils
	{
		/*
		 *	En esta sección se definen las constantes utilizadas por la aplicación.
		 *	La necesidad de agregarlas en esta parte del código es para optimizar la búsqueda de una de ellas
		 *	y poder reemplazar su valor de manera más rápida.
		 */
		#region Constantes
		public class Constantes
		{
			//	public const string sessUserId = "SESSION_USER_ID";
		}
		#endregion

		/*
		 *	En esta sección se definen los directorios de la aplicación.
		 *	Las rutas de los directorios tienen que ser rutas virtuales utilizando el caracter ~
 		 *	
		 */
		#region Directorios
		public class Directorios
		{
			private const string fileStorage = "~/FileStorage";
			public const string recursos = "~/recursos";
			public const string imagenes = fileStorage + "/Images";
			public const string scriptsJs = "/js";
			public const string styleCss = "/css";
			public const string videos = "/vid";
			public const string archivos = "/files";
			public const string vistas = "~/Views/";
		}
		#endregion

		/*
		 *	En esta sección se definen las rutas de las vistas de la aplicación
		 *	Las rutas de las vistas son relativas
		 *	
		 */
		#region Vistas aplicacion
		public class Vistas
		{
			public const string vistaHome = Utils.Directorios.vistas + "Home.cshtml";
			public const string vistaLogin = Utils.Directorios.vistas + "Login.cshtml";
			public const string vistaVerProducto = Utils.Directorios.vistas + "Productos/VerProductos.cshtml";
			public const string vistaEditarProducto = Utils.Directorios.vistas + "Productos/EditarProducto.cshtml";
			public const string vistaNuevoProducto = Utils.Directorios.vistas + "Productos/NuevoProducto.cshtml";
			public const string vistaUsuariosVer = Utils.Directorios.vistas + "Usuarios/Usuarios.cshtml";
			public const string vistaUsuariosPerfiles = Utils.Directorios.vistas + "Usuarios/PerfilesAcceso.cshtml";
            public const string vistaUsuariosEditar = Utils.Directorios.vistas + "Usuarios/UsuariosEditar.cshtml";
            public const string vistaSeccionBuscadorProductos = Utils.Directorios.vistas + "Secciones/BuscadorProductos.cshtml";
			public const string vistaSeccionHome = Utils.Directorios.vistas + "Secciones/Home.cshtml";
			public const string vistaSeccionInformacionGeneral = Utils.Directorios.vistas + "Secciones/InformacionGeneral.cshtml";
            public const string vistaSeccionNosotros = Utils.Directorios.vistas + "Secciones/Nosotros.cshtml";
		}
		#endregion

		/*
		 *	En esta sección se definen las variables de configuración utilizadas por la aplicación.
		 *	De esta manera, se puede acceder a dichas variables de manera más sencilla. Sólo llamándolas
		 *	directamente en código sin necesidad de ubicar su correcta nomenclatura en el web.config
		 */
		#region Variables de configuracion
		public enum ConstantesConfig
		{

		}
		#endregion

		#region Rutas de la aplicación
		public class Ruta
		{
			#region Properties
			public string name;
			public string route;
			public string controller;
			public string action;
			public string routeView;
			public bool sessionNeeded;
			public bool sessionState;
			public string comments;
			#endregion

			public static List<Ruta> routesStack = new List<Ruta>();

			public static int cantidadRutas = 0;

			//	Constructor de la clase Ruta
			public Ruta()
			{
				routesStack.Add(this);
				if (string.IsNullOrWhiteSpace(this.name))
				{
					this.name = cantidadRutas.ToString();
					cantidadRutas = cantidadRutas + 1;
				}
			}

			// Retorna la ruta de redireccionamiento
			public string getRedirect()
			{
				return "~/" + route;
			}

			// Carga la ruta en la colección de rutas
			private static void Load(Ruta route, RouteCollection routes)
			{
				routes.MapRoute(
					name: route.name,
					url: route.route,
					defaults: new { controller = route.controller, action = route.action }
				);
			}

			//	Este método es llamado desde RouteConfig y carga las rutas definidas debajo
			public static void LoadRoutes(RouteCollection routes)
			{
				foreach (Ruta route in routesStack)
				{
					Ruta.Load(route, routes);
				}
			}

			/*
			 *	En esta sección se definen las rutas de la aplicación.
			 *	Estas rutas son las que utiliza la aplicación para poder ejecutarse.
			 *	Se cargan inmediatamente en el momento de que se instancian.
			 */
			#region Vistas
			public static Ruta rutaVistaHome = new Ruta() { name = "Vista Home", route = "", controller = "Views", action = "obtVistaHome" };

			public static Ruta rutaVistaLogin = new Ruta()
			{
				name = "Vista Login",
				route = "login",
				controller = "Views",
				action = "obtVistaLogin"
			};

			//	Productos
			public static Ruta rutaVistaVerProductos = new Ruta()
			{
				name = "Vista ver productos",
				route = "productos/ver",
				controller = "Views",
				action = "obtVistaVerProductos"
			};

            public static Ruta rutaFiltroVistaVerProductos = new Ruta()
            {
                name = "Filtro Vista Ver Productos",
                route = "productos/filtro",
                controller = "Views",
                action = "filtroVistaVerProductos"
            };

			public static Ruta rutaVistaEditarProductos = new Ruta()
			{
				name = "Vista editar productos",
				route = "productos/editar",
				controller = "Views",
				action = "obtVistaEditarProducto"
			};

			public static Ruta rutaVistaNuevoProductos = new Ruta()
			{
				name = "Vista nuevo producto",
				route = "productos/nuevo",
				controller = "Views",
				action = "obtVistaNuevoProducto"
			};

			public static Ruta rutaVistaVerUsuarios = new Ruta()
			{
				name = "Vista ver usuarios",
				route = "usuarios/ver",
				controller = "Views",
				action = "obtVistaVerUsuarios"
			};

            public static Ruta rutaVistaEditarUsuarios = new Ruta()
            {
                name = "Vista editar usuarios",
                route = "usuarios/editar",
                controller = "Views",
                action = "obtVistaEditarUsuarios"
            };

			public static Ruta rutaVistaPerfilesUsuarios = new Ruta()
			{
				name = "Vista perfiles usuarios",
				route = "usuarios/perfiles",
				controller = "Views",
				action = "obtVistaPerfilesUsuarios"
			};

			public static Ruta rutaVistaSeccionesBuscadorProductos = new Ruta()
			{
				name = "Vista secciones buscador productos",
				route = "secciones/buscador-productos",
				controller = "Views",
				action = "obtVistaSeccionBuscadorProductos"
			};

			public static Ruta rutaVistaSeccionesHome = new Ruta()
			{
				name = "Vista secciones home",
				route = "secciones/home",
				controller = "Views",
				action = "obtVistaSeccionHome"
			};

			public static Ruta rutaVistaSeccionesInformacionGeneral = new Ruta()
			{
				name = "Vista secciones informacion general",
				route = "secciones/informacion-general",
				controller = "Views",
				action = "obtVistaSeccionInformacionGeneral"
			};

            public static Ruta rutaVistaSeccionesNosotros = new Ruta()
            {
                name = "Vista secciones nosotros",
                route = "secciones/nosotros",
                controller = "Views",
                action = "obtVistaSeccionNosotros"
            };
			#endregion

			#region Recursos
			public static Ruta rutaObtImagen = new Ruta()
			{
				name = "Obtener imagen",
				route = "img",
				controller = "Recursos",
				action = "obtImg"
			};
			#endregion

			#region AccountController
			public static Ruta rutaPostAutenticar = new Ruta()
			{
				name = "AccountController Post Autenticar",
				route = "post/account/login",
				controller = "Account",
				action = "autenticar"
			};

			public static Ruta rutaGetCerrarSesion = new Ruta()
			{
				name = "AccountController Get CerrarSesion",
				route = "get/account/sesion/cerrar",
				controller = "Account",
				action = "cerrarSesion"
			};
			#endregion

			#region Usuarios
			public static Ruta rutaPostNuevoUsuario = new Ruta()
			{
				name = "UsuarioController Post nuevoUsuario",
				route = "post/usuarios/nuevo",
				controller = "Usuarios",
				action = "nuevoUsuario"
			};

			public static Ruta rutaPostObtenerModuloNivelJson = new Ruta()
			{
				name = "UsuarioController Post JSON obtNivelesModulos",
				route = "post/json/modulos/niveles/obtener",
				controller = "Usuarios",
				action = "obtNivelesModulos"
			};

            public static Ruta rutaPostBorrarUsuario = new Ruta()
            {
                name = "UsuarioController Post borrarUsuario",
                route = "post/usuarios/borrar",
                controller = "Usuarios",
                action = "borrarUsuario"
            };

            public static Ruta rutaPostEditarUsuario = new Ruta()
            {
                name = "UsuarioController Post editarUsuario",
                route = "post/usuarios/editar",
                controller = "Usuarios",
                action = "editarUsuario"
            };
            #endregion

            #region Productos
            public static Ruta rutaPostNuevoSKU = new Ruta()
            {
                name = "SeccionProducto Post Nuevo SKU",
                route = "intra/productos/sku/nuevo",
                controller = "Productos",
                action = "nuevoSKU"
            };

            public static Ruta rutaPostNuevoProducto = new Ruta()
            {
                name = "SeccionProducto Post Nuevo Producto",
                route = "intra/productos/nuevo",
                controller = "Productos",
                action = "nuevoProducto"
            };

            public static Ruta rutaPostEditarProducto = new Ruta()
            {
                name = "SeccionProducto Post Editar Producto",
                route = "intra/productos/editar",
                controller = "Productos",
                action = "editarProducto"
            };

            public static Ruta rutaGetEliminarProducto = new Ruta()
            {
                name = "SeccionProducto Get Eliminar Producto",
                route = "intra/productos/eliminar",
                controller = "Productos",
                action = "eliminarProducto"
            };

            public static Ruta rutaPostActualizarRender = new Ruta()
            {
                name = "SeccionProducto Post SubirRender",
                route = "intra/productos/editar/subir/render",
                controller = "Productos",
                action = "editarProductoSubirRender"
            };

            public static Ruta rutaPostActualizarLogotipoColor = new Ruta()
            {
                name = "SeccionProducto Post SubirLogotipoColor",
                route = "intra/productos/editar/subir/logotipo-color",
                controller = "Productos",
                action = "editarProductoSubirLogoColor"
            };

            public static Ruta rutaPostActualizarLogotipoBlanco = new Ruta()
            {
                name = "SeccionProducto Post SubirLogotipoBlanco",
                route = "intra/productos/editar/subir/logotipo-blanco",
                controller = "Productos",
                action = "editarProductoSubirLogoBlanco"
            };

            public static Ruta rutaPostActualizarFichaTecnica = new Ruta()
            {
                name = "SeccionProducto Post Actualizar Ficha Tecnica",
                route = "intra/productos/editar/subir/ficha-tecnica",
                controller = "Productos",
                action = "editarFichaTecnica"
            };

            public static Ruta rutaPostActualizarHojaSeguridad = new Ruta()
            {
                name = "SeccionProducto Post Actualizar Hoja Seguridad",
                route = "intra/productos/editar/subir/hoja-seguridad",
                controller = "Productos",
                action = "editarHojaSeguridad"
            };

            public static Ruta rutaPostActualizarComposicion = new Ruta()
            {
                name = "SeccionProducto Post Actualizar Composicion",
                route = "intra/productos/editar/composicion",
                controller = "Productos",
                action = "editarProductoComposicionPorcentual"
            };

            public static Ruta rutaPostActualizarAplicaciones = new Ruta()
            {
                name = "SeccionProducto Post Actualizar Aplicaciones",
                route = "intra/productos/editar/aplicaciones",
                controller = "Productos",
                action = "editarProductoAplicacionProducto"
            };
            #endregion

            #region Seccion Informacion General
            public static Ruta rutaPostActualizarInformacionContactoEmpresa = new Ruta()
            {
                name = "SeccionInformacionGeneral Post actualizar",
                route = "post/informacion-contacto-empresa/actualizar",
                controller = "SeccionInformacionGeneral",
                action = "actualizar"
            };

            public static Ruta rutaPostActualizarRedesSocialesEmpresa = new Ruta()
            {
                name = "SeccionInformacionGeneral Post actualizar Redes Sociales",
                route = "post/informacion-contacto-empresa/redes-sociales",
                controller = "SeccionInformacionGeneral",
                action = "actualizarRedesSociales"
            };

            public static Ruta rutaPostActualizarLogotipo = new Ruta()
            {
                name = "SeccionInformacionGeneral Post acctualizar logotipo",
                route = "post/informacion-contacto-empresa/logotipo",
                controller = "SeccionInformacionGeneral",
                action = "actualizarLogotipo"
            };

            public static Ruta rutaPostActualizarDocumentoEsr = new Ruta()
            {
                name = "SeccionInformacionGeneral Post actualizar documento ESR",
                route = "post/informacion-contacto-empresa/documento-esr",
                controller = "SeccionInformacionGeneral",
                action = "actualizarDocumentoEsr"
            };
            #endregion

            #region Seccion Nosotros
            public static Ruta rutaPostNuevoCarruselPlanta = new Ruta()
            {
                name = "SeccionNosotros Post Nuevo Carrusel Planta",
                route = "post/seccion-nosotros/carrusel-planta",
                controller = "SeccionNosotros",
                action = "nuevoCarruselPlanta"
            };

            public static Ruta rutaPostEditarCarruselPlanta = new Ruta()
            {
                name = "SeccionNosotros Post Editar Carrusel Planta",
                route = "post/seccion-nosotros/carrusel-planta/editar",
                controller = "SeccionNosotros",
                action = "editarCarruselPlanta"
            };

            public static Ruta rutaPostEliminarCarruselPlanta = new Ruta()
            {
                name = "SeccionNosotros Post Eliminar Carrusel Planta",
                route = "post/seccion-nosotros/carrusel-planta/eliminar",
                controller = "SeccionNosotros",
                action = "eliminarCarruselPlanta"
            };

            public static Ruta rutaPostEditarLineaTiempo = new Ruta()
            {
                name = "SeccionNosotros Post Editar Linea Tiempo",
                route = "post/seccion-nosotros/linea-tiempo/editar",
                controller = "SeccionNosotros",
                action = "editarLineaTiempo"
            };
            #endregion

            #region Seccion Home
            public static Ruta rutaPostNuevoNoticiasCarrusel = new Ruta()
            {
                name = "SeccionHome Post Nuevo Noticias Carrusel",
                route = "post/seccion-home/noticias-carrusel/nuevo",
                controller = "SeccionHome",
                action = "nuevoNoticiasCarrusel"
            };

            public static Ruta rutaPostEditarNoticiasCarrusel = new Ruta()
            {
                name = "SeccionHome Post Editar Noticias Carrusel",
                route = "post/seccion-home/noticias-carrusel/editar",
                controller = "SeccionHome",
                action = "editarNoticiasCarrusel"
            };

            public static Ruta rutaGetEliminarNoticiasCarrusel = new Ruta()
            {
                name = "SeccionHome Post Eliminar Noticias Carrusel",
                route = "get/seccion-home/noticias-carrusel/eliminar",
                controller = "SeccionHome",
                action = "eliminarNoticiasCarrusel"
            };

            public static Ruta rutaPostNuevoVideoNoticia = new Ruta()
            {
                name = "SeccionHome Post Nuevo Video Noticia",
                route = "post/seccion-home/video-noticia/nuevo",
                controller = "SeccionHome",
                action = "nuevoEventoVideo"
            };

            public static Ruta rutaPostEditarVideoNoticia = new Ruta()
            {
                name = "SeccionHome Post Editar Video Noticia",
                route = "post/seccion-home/video-noticia/editar",
                controller = "SeccionHome",
                action = "editarEventoVideo"
            };

            public static Ruta rutaPostEliminarVideoNoticia = new Ruta()
            {
                name = "SeccionHome Post Eliminar Video Noticia",
                route = "post/seccion-home/video-noticia/eliminar",
                controller = "SeccionHome",
                action = "eliminarEventoVideo"
            };

            public static Ruta rutaGetEliminarVideoNoticia = new Ruta()
            {
                name = "SeccionHome Get Eliminar Video Noticia",
                route = "get/seccion-home/video-noticia/eliminar",
                controller = "SeccionHome",
                action = "getEliminarEventoVideo"
            };

            public static Ruta rutaPostEditarSobreNosotros = new Ruta()
            {
                name = "SeccionHome Post Editar Sobre Nosotros",
                route = "post/seccion-home/sobre-nosotros/editar",
                controller = "SeccionHome",
                action = "editarSobreNosotros"
            };

            public static Ruta rutaPostEditarSobreNosotrosImagen = new Ruta()
            {
                name = "SeccionHome Post Editar Sobre Nosotros Imagen",
                route = "post/seccion-home/sobre-nosotros/imagen/editar",
                controller = "SeccionHome",
                action = "editarSobreNosotrosImagen"
            };
            #endregion

        }
		#endregion

		#region Entidades de la aplicación
		public static EModulo EModulo = new EModulo();

		public static EModuloNivel EModuloNivel = new EModuloNivel();

		public static EProducto EProducto = new EProducto();

		public static EProductoTipo EProductoTipo = new EProductoTipo();

		public static EUsuario EUsuario = new EUsuario();

		public static EUsuarioPerfil EUsuarioPerfil = new EUsuarioPerfil();

		public static EUsuarioPerfilModuloNivel EUsuarioPerfilModuloNivel = new EUsuarioPerfilModuloNivel();

		public static EProductoSKU EProductoSKU = new EProductoSKU();
		#endregion

	}
}