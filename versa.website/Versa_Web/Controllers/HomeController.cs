using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using Versa_Web.Models.EntityFramework;
using Versa_Web.ViewModels;
using Versa_Web.Code.objetos;
using Versa_Web.Code.filtros;
using Versa_Web.Code.fecades;

namespace Versa_Web.Controllers
{
    public class HomeController : Controller
    {
		//  Index.cshtml
		public ActionResult Index()
        {
			List<OProducto> datos = OProducto.get(OProducto.Vistas.Index);
			return View("Index", datos);
		}

		//  Nosotros.cshtml
		public ActionResult Nosotros()
		{
			int seccion_id = 1;
            var db = DBFecade.dbObj();
			ObjectResult<sel_cms_seccion_contenido_Result> dbres = db.sel_cms_seccion_contenido(seccion_id);
			List<CmsContenido> cms_contenido_list = new List<CmsContenido>();
			foreach (sel_cms_seccion_contenido_Result item in dbres)
			{
				cms_contenido_list.Add(
					new CmsContenido() { contenido = item.contenido }
				);
			}
			ViewBag.cms_contenido = cms_contenido_list;
			return View("Nosotros");
		}

		//  Contacto.cshtml
		public ActionResult Contacto()
		{
			return View();
		}

		//  BuscarProducto.cshtml
		public ActionResult BuscarProducto()
		{
            var db = DBFecade.dbObj();

			int id_cultivo = 0;
			int id_enfermedad = 0;
			if (Int32.TryParse(Request.QueryString["ffp--select-cultivos"], out id_cultivo))
			{
				if (Int32.TryParse(Request.QueryString["ffp--select-enfermedades"], out id_enfermedad))
				{
					List<search_productos_filtro_Result> dbres_busqueda = db.search_productos_filtro(id_cultivo, id_enfermedad).ToList();
					ViewBag.dbres_busqueda = dbres_busqueda;
				}
				else
				{
					List<search_productos_filtro_Result> dbres_busqueda = new List<search_productos_filtro_Result>();
					ViewBag.dbres_busqueda = dbres_busqueda;
				}
			}
			else
			{
				List<search_productos_filtro_Result> dbres_busqueda = new List<search_productos_filtro_Result>();
				ViewBag.dbres_busqueda = dbres_busqueda;
			}
			ViewBag.id_cultivo = id_cultivo;
			ViewBag.id_enfermedad = id_enfermedad;

			
			List<ProductoResumenVM> ProductoResumenVMList = new List<ProductoResumenVM>();
			ObjectResult dbres = db.sel_productos_para_producto_buscar();
			foreach (sel_productos_para_producto_buscar_Result item in dbres)
			{
				ProductoResumenVM objpvm = new ProductoResumenVM();
				objpvm.id = item.id;
				objpvm.sku = item.sku;
				objpvm.nombre = item.nombre;
				objpvm.subnombre = item.subnombre;
				objpvm.categoria = item.categoria;
				objpvm.classname = item.classname;
				objpvm.cat_img = item.cat_img;
				objpvm.ingrediente_activo = item.ingrediente;
				objpvm.presentacion = item.presentacion;
				objpvm.imagen = item.imagen;
				ProductoResumenVMList.Add(objpvm);
			}

			// Obtiene los cultivos para el filtro
			List<sel_cultivos_para_filtros_Result> dbres_cultivos = db.sel_cultivos_para_filtros().ToList();
			ViewBag.dbres_cultivos = dbres_cultivos;

			// Obtiene las enfermedades para el filtro
			List<sel_enfermedades_para_filtros_Result> dbres_enfermedades = db.sel_enfermedades_para_filtros().ToList();
			ViewBag.dbres_enfermedades = dbres_enfermedades;


			//return View("BuscarProductov2", ProductoResumenVMList);
			return View("BuscarProducto", ProductoResumenVMList);
		}

        //  VerCategoria.cshtml
        public ActionResult VerCategoria(string q)
        {
            var n = 0;
            var index = (from T in DBFecade.dbObj().P_Tipo where T.alias.Contains(q) select new { T.id }).ToList();
            foreach (var item in index)
            {
                n = item.id;
            }

            List<OProducto> datos = OProducto.get(OProducto.Vistas.VerCategoria);
            datos = Filtrar<OProducto>.filtrar(datos, new FiltroProductoIdTipo(n));
            foreach (var dato in datos)
            {
                string[] palabras = dato.descripcion.Split(' ');
                string resultado = string.Empty;
                int contador = 0;
                foreach (string elemento in palabras)
                {
                    resultado = resultado + elemento + " ";
                    if (contador >= 30)
                        break;
                    contador = contador + 1;
                }
                dato.descripcion = resultado;
                dato.descripcion = dato.descripcion.Replace("<br>", "");
                dato.descripcion = dato.descripcion.Replace("<br >", "");
                dato.descripcion = dato.descripcion.Replace("</br>", "");
                dato.descripcion = dato.descripcion.Replace("</br >", "");
                dato.descripcion = dato.descripcion + " ...";

            }
            return View("VerCategoria", datos);
        }

        //  VerProducto.cshtml
        public ActionResult VerProducto(int q)
        {
            //  Verifica si el producto está vigente o no. Valida el campo deleted_at en la base de datos
            var validezProducto = DBFecade.dbObj().website_sp6(q);
            int contadorBorrado = 0;
            DateTime? fechaBorrado = null;
            foreach (var el in validezProducto)
            {
                fechaBorrado = el;
                contadorBorrado = contadorBorrado + 1;
            }
            if (contadorBorrado == 0)
            {
                return Redirect("~/buscar-producto");
            }
            if (fechaBorrado != null)
            {
                return Redirect("~/buscar-producto");
            }
            
            // Obtiene la información genérica del producto
            List<Producto> productoList = new List<Producto>();
            var producto = DBFecade.dbObj().website_sp1(q);
            foreach (var item in producto)
            {
                Producto objpvm = new Producto();
                objpvm.id = item.id;
                objpvm.id_tipo = item.id_tipo;
                objpvm.sku = item.sku;
                objpvm.nombre = item.nombre;
                objpvm.subnombre = item.subnombre;
                objpvm.Cintillo = item.Cintillo;
                objpvm.descripcion = item.descripcion;
                objpvm.presentacion = item.presentacion;
                objpvm.contenido = item.contenido;
                objpvm.beneficios = item.beneficios;
                objpvm.imagen = item.imagen;
                objpvm.imagen_logo = item.imagen_logo;
                objpvm.imagen_logo_carpeta = item.imagen_logo_carpeta;
                objpvm.precio = item.precio;
                objpvm.pdf_nombre = item.pdf_nombre;
                objpvm.pie = item.pie;
                objpvm.cms_tablas_composicion_id = item.cms_tablas_composicion_id;
                objpvm.imagen_tabla_aplicacion = item.imagen_tabla_aplicacion;
                productoList.Add(objpvm);
            }

            // Obtiene la información relacionada con las aplicaciones del producto
            List<P_Aplicacion> aplicacionList = new List<P_Aplicacion>();
            var aplicacion = DBFecade.dbObj().website_sp2(q);
            foreach (var item in aplicacion)
            {
                P_Aplicacion objpvm = new P_Aplicacion();
                objpvm.id = item.id;
                objpvm.id_producto = item.id_producto;
                objpvm.cultivo = item.cultivo;
                objpvm.enfermedad = item.enfermedad;
                objpvm.dosis = item.dosis;
                objpvm.intervalo_seguridad = item.intervalo_seguridad;
                objpvm.LMRP = item.LMRP;
                objpvm.EPA2 = item.EPA2;
                objpvm.Tolerancias = item.Tolerancias;
                objpvm.obervaciones = item.obervaciones;
                objpvm.epoca = item.epoca;
                aplicacionList.Add(objpvm);
            }

            // Obtiene la información relacionada con las aplicaciones del producto pero de agricultura protegida
            List<P_Aplicacion> aplicacion_agricultura_protegida = new List<P_Aplicacion>();
            var aplicacion_agricultura_protegidas = DBFecade.dbObj().website_sp3(q);
            foreach (var item in aplicacion_agricultura_protegidas)
            {
                P_Aplicacion objpvm = new P_Aplicacion();
                objpvm.id = item.id;
                objpvm.id_producto = item.id_producto;
                objpvm.cultivo = item.cultivo;
                objpvm.enfermedad = item.enfermedad;
                objpvm.dosis = item.dosis;
                objpvm.intervalo_seguridad = item.intervalo_seguridad;
                objpvm.LMRP = item.LMRP;
                objpvm.EPA2 = item.EPA2;
                objpvm.Tolerancias = item.Tolerancias;
                objpvm.obervaciones = item.obervaciones;
                objpvm.epoca = item.epoca;
                aplicacion_agricultura_protegida.Add(objpvm);
            }

            // Obtiene la información de la composición porcentual del producto
            List<P_Composicion> composicionList = new List<P_Composicion>();
            var composicion = DBFecade.dbObj().website_sp4(q);
            foreach (var item in composicion)
            {
                P_Composicion objpvm = new P_Composicion();
                objpvm.id = item.id;
                objpvm.id_Producto = item.id_Producto;
                objpvm.ingrediente = item.ingrediente;
                objpvm.tipo = item.tipo;
                objpvm.formula = item.formula;
                objpvm.porcentaje = item.porcentaje;
                composicionList.Add(objpvm);
            }

            // Obtiene el tipo de tabla de composición que tiene que usar


            List<P_Documentos> documentsList = new List<P_Documentos>();
            var documentos = DBFecade.dbObj().website_sp5(q);
            foreach (var elemento in documentos)
            {
                P_Documentos objpvm = new P_Documentos();
                objpvm.id = elemento.id;
                objpvm.id_Producto = elemento.id_Producto;
                objpvm.id_Tipo = elemento.id_Tipo;
                objpvm.tipo_Documento = elemento.tipo_Documento;
                objpvm.documento = elemento.documento;
                objpvm.ruta = elemento.ruta;
                documentsList.Add(objpvm);
            }

            var baseDeDatos = DBFecade.dbObj();

            var tipo = (from PT in baseDeDatos.P_Tipo
                        join P in baseDeDatos.Producto on PT.id equals P.id_tipo
                        where P.id == q
                        select PT.alias).First();

            var nombre_categoria = (from PT in baseDeDatos.P_Tipo
                                    join P in baseDeDatos.Producto on PT.id equals P.id_tipo
                                    where P.id == q
                                    select PT.nombre).First();

            var sku = (from P in baseDeDatos.Producto
                       where P.id == q
                       select P.sku).First();

            var ingrediente_result = (from C in baseDeDatos.P_Composicion
                                      where C.id_Producto == q
                                      select C.ingrediente);
            var ingrediente = "";
            if (ingrediente_result.Count() > 0)
            {
                ingrediente = (from C in baseDeDatos.P_Composicion
                               where C.id_Producto == q
                               select C.ingrediente).First();
            }

            // Obtiene el tipo de tabla de composición para el producto
            List<sel_tabla_composicion_por_id_producto_Result> dbres_tabla_composicion = DBFecade.dbObj().sel_tabla_composicion_por_id_producto(q).ToList();

            // Obtiene los títulos de las columnas de la tabla de aplicacion
            List<sel_tabla_aplicacion_titulo_por_id_producto_Result> dbres_tabla_aplicacion_titulo = DBFecade.dbObj().sel_tabla_aplicacion_titulo_por_id_producto(q).ToList();
            if (dbres_tabla_aplicacion_titulo == null)
                dbres_tabla_aplicacion_titulo = new List<sel_tabla_aplicacion_titulo_por_id_producto_Result>();


            ProductoDetallesVM final = new ProductoDetallesVM();
            final.Producto = productoList;
            final.P_Aplicacion = aplicacionList;
            final.P_Composicion = composicionList;
            final.P_Documentos = documentsList;
            final.alias = tipo;
            final.nombre_categoria = nombre_categoria;
            final.ingrediente = ingrediente;
            final.P_Aplicacion_Agricultura_Protegida = aplicacion_agricultura_protegida;
            final.data_tabla_composicion = dbres_tabla_composicion;
            final.data_tabla_aplicacion_titulo = dbres_tabla_aplicacion_titulo;

            return View("VerProducto", final);
        }
        
        //Este método retorna el JSON con las enfermedades que usa el filtro de búsqueda para los productos.
        //Una vez que selecciona el cultivo, retorna el JSON con las enfermedades disponibles.
        string str;
		[HttpPost]
		public JsonResult BuscarProducto_GetJSON_Enfermedades(List<string> listIds, string cultivo)
		{
			foreach (var item in listIds)
			{
				str += item + ',';
			}
			str = str.Remove(str.Length - 1);
			var query = DBFecade.dbObj().P_Aplicacion.SqlQuery
			   ("SELECT * FROM P_Aplicacion WHERE id_producto in (" + str + ") AND cultivo LIKE '%" + cultivo + "%'").ToList<P_Aplicacion>();
			List<P_Aplicacion> aplicacionList = new List<P_Aplicacion>();
			foreach (var item in query)
			{
				P_Aplicacion objpvm = new P_Aplicacion();
				objpvm.id_producto = item.id;
				objpvm.enfermedad = item.enfermedad;
				aplicacionList.Add(objpvm);
			}
			return Json(aplicacionList.ToList());
		}
        
		[HttpPost]
		public JsonResult BuscarProducto_POST_Filter([Bind(Include = "cultivo, enfermedad")] P_Aplicacion aplicacion)
		{
			var cultivo = aplicacion.cultivo;
			var enfermedad = aplicacion.enfermedad;

			if (cultivo == "Todos" || cultivo == "null")
			{
				cultivo = "";
			}

			if (enfermedad == "Todos" || enfermedad == "null")
			{
				enfermedad = "";
			}
            
			List<sp_temp_buscador_v1_Result> dbres = DBFecade.dbObj().sp_temp_buscador_v1(cultivo, enfermedad).ToList();

			return Json(dbres);
		}
        
	}
}