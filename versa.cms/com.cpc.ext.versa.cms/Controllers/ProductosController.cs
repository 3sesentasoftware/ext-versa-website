using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using com.cpc.ext.versa.cms.Models.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
    public class ProductosController : Controller
    {
        [HttpPost]
        public ActionResult nuevoSKU(FormCollection formColl)
        {
            string sku = formColl["sku"];

            BDFecade.db().cms_pSkuNuevo(sku);

            return Redirect(Utils.Ruta.rutaVistaNuevoProductos.getRedirect());
        }

        [HttpPost]  // Ruta que recibe los datos para crear un producto
        public ActionResult nuevoProducto(FormCollection formColl)
        {
            if (SysSession.IsSessionOpen(this))
            {
                //  LOGICA START
                
                string tipoProducto = formColl["tipo-producto"];
                string skuProducto = formColl["sku-producto"];
                string nombreProducto = formColl["nombre-producto"];
                string subnombreProducto = formColl["subnombre-producto"];

                int idProducto = 0;
                foreach (var el in BDFecade.db().cms_seccionProductosNuevo(Convert.ToInt32(tipoProducto), skuProducto, nombreProducto, subnombreProducto))
                {
                    idProducto = Convert.ToInt32(el);
                }

                //  LOGICA END
                return vistaEditarProducto(idProducto.ToString());
            }
            else
            {
                return vistaLogin();
            }
        }

		[HttpPost]  // Ruta que recibe los datos para editar un producto ya existente
        [ValidateInput(false)]
        public ActionResult editarProducto(FormCollection formColl)
		{
            if (SysSession.IsSessionOpen(this))
            {
                //  LOGICA START

                string producto_id = formColl["ver-intra-nuevo-producto-id"];
                string tipo_producto = formColl["ver-intra-tipo-producto"];
                string sku_producto = formColl["ver-intra-nuevo-producto-sku"];

                string nombre_producto = formColl["ver-intra-nuevo-producto-nombre-producto"];
                nombre_producto = LimpiarParrafos(nombre_producto);

                string subnombre_producto = formColl["ver-intra-nuevo-producto-subnombre-producto"];
                subnombre_producto = LimpiarParrafos(subnombre_producto);

                string descripcion_producto = formColl["ver-intra-nuevo-producto-descripcion"];
                descripcion_producto = LimpiarParrafos(descripcion_producto);

                string presentacion_producto = formColl["ver-intra-nuevo-producto-presentacion"];
                presentacion_producto = LimpiarParrafos(presentacion_producto);

                string contenido_producto = formColl["ver-intra-nuevo-producto-contenido"];
                contenido_producto = LimpiarParrafos(contenido_producto);

                string beneficios_producto = formColl["ver-intra-nuevo-producto-beneficios"];
                beneficios_producto = LimpiarParrafos(beneficios_producto);

                string cintillo_producto = formColl["ver-intra-nuevo-producto-cintillo"];
                cintillo_producto = LimpiarParrafos(cintillo_producto);

                string pie_producto = formColl["ver-intra-nuevo-producto-pie"];
                pie_producto = LimpiarParrafos(pie_producto);

                BDFecade.db().upd_producto(Convert.ToInt32(tipo_producto), sku_producto, nombre_producto, subnombre_producto, descripcion_producto, presentacion_producto, contenido_producto,
                    beneficios_producto, cintillo_producto, pie_producto, Convert.ToInt32(producto_id));
                BDFecade.db().SaveChanges();

                //  LOGICA END
                return vistaEditarProducto(producto_id);
            }
            else
            {
                return vistaLogin();
            }
        }
        
		[HttpPost]  // Ruta para editar la composición porcentual de un producto ya existente
        [ValidateInput(false)]
        public ActionResult editarProductoComposicionPorcentual(FormCollection formColl)
		{
			if (SysSession.IsSessionOpen(this))
			{
				// Envia el ID del usuario
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				// Recupera el ID del producto
				Int32 producto_id = Convert.ToInt32(formColl["ver-intra-prod-edit-comp-porcen-prod-id"]);

				// Recupera los ID de la composición actual
				List<sel_productos_composicion_Fil_id_producto_Result> dbres_producto_composicion = BDFecade.db().sel_productos_composicion_Fil_id_producto(producto_id).ToList();
                
				/*
				 *		Ingredientes activos
				 */
				List<string> dbres_producto_composicion_activos_ids = new List<string>();
				foreach (sel_productos_composicion_Fil_id_producto_Result elemento in dbres_producto_composicion)
				{
					bool tipo = Convert.ToBoolean(elemento.tipo);
					if (tipo)
					{
						dbres_producto_composicion_activos_ids.Add(Convert.ToString(elemento.id));
					}
				}
				// Recupera las colecciones de datos del formulario
				string[] registros_id = formColl.GetValues("ver-intra-prod-edit-comp-id");
				string[] ingredientes = formColl.GetValues("ver-intra-prod-edit-comp-porcen-ingrediente");
				string[] formulas = formColl.GetValues("ver-intra-prod-edit-comp-porcen-formula");
				string[] porcentajes = formColl.GetValues("ver-intra-prod-edit-comp-porcen-porcentaje");
				if (registros_id != null && ingredientes != null && formulas != null && porcentajes != null)
				{
					for (int i = 0; i < registros_id.Length; i++) registros_id[i] = LimpiarParrafos(registros_id[i]);
					for (int i = 0; i < ingredientes.Length; i++) ingredientes[i] = LimpiarParrafos(ingredientes[i]);
					for (int i = 0; i < formulas.Length; i++) formulas[i] = LimpiarParrafos(formulas[i]);
					for (int i = 0; i < porcentajes.Length; i++) porcentajes[i] = LimpiarParrafos(porcentajes[i]);
					// Obtiene los ID que no se encuentran en la nueva colección
					List<string> dbres_producto_composicion_ids_no_encontrados = new List<string>();
					foreach (string elemento in dbres_producto_composicion_activos_ids)
					{
						bool existe = false;
						for (int i = 0; i < registros_id.Length; i++)
						{
							if (registros_id[i] == elemento)
							{
								existe = true;
								break;
							}
						}
						if (!existe)
						{
							dbres_producto_composicion_ids_no_encontrados.Add(elemento);
						}
					}
					// Borra los ID de los elementos no encontrados
					foreach (string elemento in dbres_producto_composicion_ids_no_encontrados)
					{
						BDFecade.db().upd_productos_composicion_inactive(Convert.ToInt32(elemento));
						BDFecade.db().SaveChanges();
					}
					// Agrega o actualiza los nuevos elementos
					for (int i = 0; i < registros_id.Length; i++)
					{
						if (registros_id[i] == "0")
						{
							// El registro es nuevo
							BDFecade.db().ins_productos_composicion(Convert.ToInt32(producto_id), ingredientes[i], formulas[i], true, porcentajes[i]);
							BDFecade.db().SaveChanges();
						}
						else
						{
							// El registro hay que actualizarlo
							BDFecade.db().upd_productos_composicion(ingredientes[i], formulas[i], porcentajes[i], Convert.ToInt32(registros_id[i]));
							BDFecade.db().SaveChanges();
						}
					}

				}
                
				/*
				 *	Ingredientes inertes
				 */
				List<string> dbres_producto_composicion_inertes_ids = new List<string>();
				foreach (sel_productos_composicion_Fil_id_producto_Result elemento in dbres_producto_composicion)
				{
					bool tipo = Convert.ToBoolean(elemento.tipo);
					if (!tipo)
					{
						dbres_producto_composicion_inertes_ids.Add(Convert.ToString(elemento.id));
					}
				}
				// Recupera las colecciones de datos del formulario
				string[] inertes_registros_id = formColl.GetValues("ver-intra-prod-edit-comp-porcen-ingred-intertes-id");
				string[] inertes_ingredientes = formColl.GetValues("ver-intra-prod-edit-comp-porcen-ingred-intertes-ingrediente");
				string[] inertes_formulas = formColl.GetValues("ver-intra-prod-edit-comp-porcen-ingred-intertes-formula");
				string[] inertes_porcentajes = formColl.GetValues("ver-intra-prod-edit-comp-porcen-ingred-intertes-porcentaje");
				if (inertes_registros_id != null && inertes_ingredientes != null && inertes_formulas != null && inertes_porcentajes != null)
				{
					for (int i = 0; i < inertes_registros_id.Length; i++) inertes_registros_id[i] = LimpiarParrafos(inertes_registros_id[i]);
					for (int i = 0; i < inertes_ingredientes.Length; i++) inertes_ingredientes[i] = LimpiarParrafos(inertes_ingredientes[i]);
					for (int i = 0; i < inertes_formulas.Length; i++) inertes_formulas[i] = LimpiarParrafos(inertes_formulas[i]);
					for (int i = 0; i < inertes_porcentajes.Length; i++) inertes_porcentajes[i] = LimpiarParrafos(inertes_porcentajes[i]);
					// Obtiene los ID que no se encuentran en la nueva colección
					List<string> dbres_producto_composicion_inertes_ids_no_encontrados = new List<string>();
					foreach (string elemento in dbres_producto_composicion_inertes_ids)
					{
						bool existe = false;
						for (int i = 0; i < inertes_registros_id.Length; i++)
						{
							if (inertes_registros_id[i] == elemento)
							{
								existe = true;
								break;
							}
						}
						if (!existe)
						{
							dbres_producto_composicion_inertes_ids_no_encontrados.Add(elemento);
						}
					}
					// Borra los ID de los elementos no encontrados
					foreach (string elemento in dbres_producto_composicion_inertes_ids_no_encontrados)
					{
						BDFecade.db().upd_productos_composicion_inactive(Convert.ToInt32(elemento));
						BDFecade.db().SaveChanges();
					}
					// Agrega o actualiza los nuevos elementos
					for (int i = 0; i < inertes_registros_id.Length; i++)
					{
						if (inertes_registros_id[i] == "0")
						{
							// El registro es nuevo
							BDFecade.db().ins_productos_composicion(Convert.ToInt32(producto_id), inertes_ingredientes[i], inertes_formulas[i], false, inertes_porcentajes[i]);
							BDFecade.db().SaveChanges();
						}
						else
						{
							// El registro hay que actualizarlo
							BDFecade.db().upd_productos_composicion(inertes_ingredientes[i], inertes_formulas[i], inertes_porcentajes[i], Convert.ToInt32(inertes_registros_id[i]));
							BDFecade.db().SaveChanges();
						}
					}
				}
                
                return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + producto_id);
            }
			else
			{
				this.Session.Clear();
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

		[HttpPost]  // Ruta para editar la aplicación de un producto
        [ValidateInput(false)]
        public ActionResult editarProductoAplicacionProducto(FormCollection formColl, HttpPostedFileBase tablaAplicacion)
		{
			if (SysSession.IsSessionOpen(this))
			{
				// Envia el ID del usuario
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				// Recupera el ID del producto
				Int32 producto_id = Convert.ToInt32(formColl["apli-prod--prod-id"]);

                string opcionMostrarTabla = formColl["opcion-tabla"];

                /*
				 *		Verifica si se está subiendo una imagen
				 */
                if (tablaAplicacion != null)
                {
                    string nombreArchivo = FileServiceInterface.sendPostFile(tablaAplicacion);

                    // Actualiza la base de datos con el nombre del nuevo fichero
                    BDFecade.db().cms_seccionProductosActualizarImagenTablaAplicacion(nombreArchivo, Convert.ToInt32(producto_id));

                    opcionMostrarTabla = "imagen";
                }
                

                /*
				 *		Verifica si va a mostrar una tabla construida o una imagen de tabla
				 */
                if (opcionMostrarTabla == "imagen")
                {
                    //  Borra la estructura de la tabla
                    BDFecade.db().cms_borrarEstructuraTablaAplicacion(producto_id);
                }
                else
                {
                    //  Borra la imagen de la tabla
                    BDFecade.db().cms_borrarImagenTablaAplicacion(producto_id);
                }



                /*
				 *		Producto aplicación
				 */
                // Recupera las aplicaciones del producto
                List<sel_productos_aplicacion_Fil_id_producto_Result> dbres_aplicacion = BDFecade.db().sel_productos_aplicacion_Fil_id_producto(producto_id).ToList();
				List<int> ids_dbs = new List<int>();
				foreach (sel_productos_aplicacion_Fil_id_producto_Result elemento in dbres_aplicacion)
				{
					ids_dbs.Add(elemento.id);
				}
				// Recupera la data del formulario
				List<sel_productos_aplicacion_Fil_id_producto_Result> dbres_producto_aplicacion = BDFecade.db().sel_productos_aplicacion_Fil_id_producto(Convert.ToInt32(producto_id)).ToList();
				// ID de los registros
				string[] apli_prod_ids = formColl.GetValues("apli-prod--registro-id");
				apli_prod_ids = LimpiarParrafos(apli_prod_ids);
				// Cultivos
				string[] apli_prod_cultivo = formColl.GetValues("apli-prod-input--cultivo");
				apli_prod_cultivo = LimpiarParrafos(apli_prod_cultivo);
				// Enfermedades
				string[] apli_prod_enfermedad = formColl.GetValues("apli-prod-input--enfermedad");
				apli_prod_enfermedad = LimpiarParrafos(apli_prod_enfermedad);
				// Dosis
				string[] apli_prod_dosis = formColl.GetValues("apli-prod-input--dosis");
				apli_prod_dosis = LimpiarParrafos(apli_prod_dosis);
				// Intervalos de seguridad
				string[] apli_prod_inter_seg = formColl.GetValues("apli-prod-input--inter-seg");
				apli_prod_inter_seg = LimpiarParrafos(apli_prod_inter_seg);
				// LMREPA
				string[] apli_prod_lmrepa = formColl.GetValues("apli-prod-input--lmrepa");
				apli_prod_lmrepa = LimpiarParrafos(apli_prod_lmrepa);
				// EPA
				string[] apli_prod_epa = formColl.GetValues("apli-prod-input--epa");
				apli_prod_epa = LimpiarParrafos(apli_prod_epa);
				// Observaciones
				string[] apli_prod_observaciones = formColl.GetValues("apli-prod-input--observaciones");
				apli_prod_observaciones = LimpiarParrafos(apli_prod_observaciones);
				// Estudios
				string[] apli_prod_estudio = formColl.GetValues("apli-prod-input--estudio");
				apli_prod_estudio = LimpiarParrafos(apli_prod_estudio);
				// Epoca
				string[] apli_prod_epoca = formColl.GetValues("apli-prod-input--epoca");
				apli_prod_epoca = LimpiarParrafos(apli_prod_epoca);
				// Agricultura protegida
				string[] apli_prod_agric_proteg = formColl.GetValues("apli-prod--agricultura-protegida");


				// Obtiene los ID que no se encuentran en la nueva colección
				List<int> ids_no_encontrados = new List<int>();
				foreach (int elemento in ids_dbs)
				{
					bool existe = false;
					for (int i = 0; i < apli_prod_ids.Length; i++)
					{
						if (apli_prod_ids[i] == Convert.ToString(elemento))
						{
							existe = true;
							break;
						}
					}
					if (!existe)
						ids_no_encontrados.Add(elemento);
				}

				// Borra los ID de los elementos no encontrados
				foreach (int elemento in ids_no_encontrados)
				{
					BDFecade.db().upd_productos_aplicacion_inactive(Convert.ToInt32(elemento));
					BDFecade.db().SaveChanges();
				}
				// Agrega o actualiza los nuevos elementos
				for (int i = 0; i < apli_prod_ids.Length; i++)
				{
					if (apli_prod_ids[i] == "0")
					{
						bool agricultura_protegida = false;
						if (apli_prod_agric_proteg[i] == "true")
							agricultura_protegida = true;
						// El registro es nuevo
						BDFecade.db().ins_productos_aplicacion(producto_id,
							apli_prod_cultivo[i],
							apli_prod_enfermedad[i],
							apli_prod_dosis[i],
							apli_prod_inter_seg[i],
							apli_prod_observaciones[i],
							apli_prod_epoca[i],
							apli_prod_lmrepa[i],
							apli_prod_epa[i],
							"",
							apli_prod_estudio[i],
							agricultura_protegida
						);
						BDFecade.db().SaveChanges();
					}
					else
					{
						bool agricultura_protegida = false;
						if (apli_prod_agric_proteg[i] == "true")
							agricultura_protegida = true;
						// El registro hay que actualizarlo
						BDFecade.db().upd_productos_aplicacion(
							Convert.ToInt32(apli_prod_ids[i]),
							apli_prod_cultivo[i],
							apli_prod_enfermedad[i],
							apli_prod_dosis[i],
							apli_prod_inter_seg[i],
							apli_prod_observaciones[i],
							apli_prod_epoca[i],
							apli_prod_lmrepa[i],
							apli_prod_epa[i],
							"",
							apli_prod_estudio[i],
							agricultura_protegida
						);
						BDFecade.db().SaveChanges();
					}
				}


				// Títulos de las columnas

				// Columna de cultivo
				string titulo_cultivo = formColl["apli-prod--titulo-columna--cultivo"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 1, @var_titulo = N'" + titulo_cultivo + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de enfermedad
				string titulo_enfermedad = formColl["apli-prod--titulo-columna--enfermedad"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 2, @var_titulo = N'" + titulo_enfermedad + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de dósis
				string titulo_dosis = formColl["apli-prod--titulo-columna--dosis"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 3, @var_titulo = N'" + titulo_dosis + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de intérvalo de seguridad
				string titulo_intervalo_seguridad = formColl["apli-prod--titulo-columna--intseg"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 4, @var_titulo = N'" + titulo_intervalo_seguridad + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de observaciones
				string titulo_observaciones = formColl["apli-prod--titulo-columna--observaciones"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 5, @var_titulo = N'" + titulo_observaciones + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de epoca
				string titulo_epoca = formColl["apli-prod--titulo-columna--epoca"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 6, @var_titulo = N'" + titulo_epoca + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de LMRP
				string titulo_LMRP = formColl["apli-prod--titulo-columna--lmrp"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 7, @var_titulo = N'" + titulo_LMRP + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de EPA
				string titulo_EPA = formColl["apli-prod--titulo-columna--epa"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 8, @var_titulo = N'" + titulo_EPA + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
				// Columna de estudios
				string titulo_estudios = formColl["apli-prod--titulo-columna--estudios"];
				BDFecade.db().Database.ExecuteSqlCommand("EXEC upd_titulo_tabla_aplicacion @var_id_columna = 9, @var_titulo = N'" + titulo_estudios + "', @var_id_producto = " + Convert.ToString(producto_id) + "");
                
                return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + producto_id);
            }
			else
			{
				this.Session.Clear();
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

        //  Ruta para subir el render de un producto
        [HttpPost]
        public ActionResult editarProductoSubirRender(FormCollection form_coll, HttpPostedFileBase fichero)
        {
            // Obtiene el ID del producto
            string producto_id = form_coll["form-files-upload-render-id"];

            string nombreArchivo = FileServiceInterface.sendPostFile(fichero);

            // Actualiza la base de datos con el nombre del nuevo fichero
            BDFecade.db().upd_productos_imagen_render(nombreArchivo, Convert.ToInt32(producto_id));

            // Redirecciona a la misma página de editar producto
            return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + producto_id);
        }

        //  Ruta para subir el logotipo a color
        [HttpPost]
        public ActionResult editarProductoSubirLogoColor(FormCollection form_coll, HttpPostedFileBase fichero)
        {
            // Obtiene el ID del producto
            string producto_id = form_coll["form-files-upload-logo-color-id"];

            string nombreArchivo = FileServiceInterface.sendPostFile(fichero);

            // Actualiza la base de datos con el nombre del nuevo fichero
            BDFecade.db().upd_productos_imagen_color(nombreArchivo, Convert.ToInt32(producto_id));

            // Redirecciona a la misma página de editar producto
            return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + producto_id);
        }

        [HttpPost]  // Ruta para subir el logotipo blanco de un producto
        public ActionResult editarProductoSubirLogoBlanco(FormCollection form_coll, HttpPostedFileBase fichero)
        {
            // Obtiene el ID del producto
            string producto_id = form_coll["form-files-upload-logotipo-blanco-id"];

            //  Envía el documento y obtiene el nuevo nombre
            string nombreArchivo = FileServiceInterface.sendPostFile(fichero);

            // Actualiza la base de datos con el nombre del nuevo fichero
            BDFecade.db().upd_productos_imagen_logo_blanco(nombreArchivo, Convert.ToInt32(producto_id));
            
            // Redirecciona a la misma página de editar producto
            return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + producto_id);
        }

        [HttpGet]   // Ruta para eliminar un producto
        public ActionResult eliminarProducto(string idProducto)
        {
            if (SysSession.IsSessionOpen(this))
            {
                if (!string.IsNullOrEmpty(idProducto))
                {
                    BDFecade.db().cms_seccionProductosEliminar(Convert.ToInt32(idProducto));
                }
                return Redirect(Utils.Ruta.rutaVistaVerProductos.getRedirect());
            }
            else
            {
                this.Session.Clear();
                return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
            }
        }

        [HttpPost]  // Ruta para editar la hoja de seguridad de un producto existente
        public ActionResult editarHojaSeguridad(FormCollection formColl, HttpPostedFileBase fichero)
        {
            if (SysSession.IsSessionOpen(this))
            {
                string hojaSeguridadId = formColl["hoja-seguridad-producto-id"];

                string productoId = formColl["producto-id"];

                string nombreArchivo = FileServiceInterface.sendPostFile(fichero);

                BDFecade.db().cms_seccionProductosDocumentosActualizar(Convert.ToInt32(hojaSeguridadId), nombreArchivo);

                return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + productoId);
            }
            else
            {
                this.Session.Clear();
                return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
            }
        }

        [HttpPost]  // Ruta para editar la ficha técnica de un producto existente
        public ActionResult editarFichaTecnica(FormCollection formColl, HttpPostedFileBase fichero)
        {
            if (SysSession.IsSessionOpen(this))
            {
                string fichaTecnicaId = formColl["ficha-tecnica-producto-id"];

                string productoId = formColl["producto-id"];
                
                string nombreArchivo = FileServiceInterface.sendPostFile(fichero);

                BDFecade.db().cms_seccionProductosDocumentosActualizar(Convert.ToInt32(fichaTecnicaId), nombreArchivo);

                return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + productoId);
            }
            else
            {
                this.Session.Clear();
                return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
            }
        }

        // Función interna que retorna la vista para editar un producto dado
        private ActionResult vistaEditarProducto(string idProducto)
        {
            return Redirect(Utils.Ruta.rutaVistaEditarProductos.getRedirect() + "?productoid=" + idProducto);
        }

        // Función interna que retorna la vista para login
        private ActionResult vistaLogin()
        {
            return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
        }

        // Función interna para limpiar los datos recibidos por el CMS
        private static string LimpiarParrafos(string html)
		{
			html = Limpiar(html);

			return html;
		}

        // Función interna para limpiar los datos recibidos por el CMS
        private static string[] LimpiarParrafos(string[] html_arr)
		{
			for (int i = 0; i < html_arr.Length; i++)
			{
				string html = html_arr[i];

				html = Limpiar(html);

				html_arr[i] = html;
			}
			return html_arr;
		}

        // Función interna para limpiar los datos recibidos por el CMS
        private static string Limpiar(string entrada)
		{
			entrada = entrada.Replace("<div>", "");
			entrada = entrada.Replace("</div>", "");
			entrada = entrada.Replace("<strong></strong>", "");
			return entrada;
		}
	}
}