using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.Entities;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
    public class ViewsController : Controller
    {
		[HttpGet]
		public ActionResult obtVistaLogin()
		{
			if (SysSession.IsSessionClose(this))
			{
				return View(Utils.Vistas.vistaLogin);
			}
			else
			{
				return Redirect(Utils.Ruta.rutaVistaHome.getRedirect());
			}
		}

		[HttpGet]
		public ActionResult obtVistaHome()
		{
			if (SysSession.IsSessionOpen(this))
			{
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				return View(Utils.Vistas.vistaHome);
			}
			else
			{
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}
		
		[HttpGet]
		public ActionResult obtVistaVerProductos()
		{
			if (SysSession.IsSessionOpen(this))
			{
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
                ViewBag.productos = Utils.EProducto.obtTodos();
                return View(Utils.Vistas.vistaVerProducto);
			}
			else
			{
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

        // POST: Ver productos - Filtrar productos
        public ActionResult filtroVistaVerProductos(FormCollection form_coll)
        {
            if (SysSession.IsSessionOpen(this))
            {
                ViewBag.usuario_id = SysSession.getIdValue<int>(this);
                ViewBag.productos = Utils.EProducto.obtTodos();

                int producto_tipo = Convert.ToInt32(Convert.ToString(form_coll["form-filtrar-producto-tipo"]));
                string producto_sku = form_coll["form-filtrar-producto-sku"];
                string producto_nombre = form_coll["form-filtrar-producto-nombre"];

                List<sel_productos_para_intra_ver_productos_filtro_Result> dbres = BDFecade.db().sel_productos_para_intra_ver_productos_filtro(producto_tipo, producto_sku, producto_nombre).ToList();
                List<IEntities> dbres_productos = new List<IEntities>();
                foreach (sel_productos_para_intra_ver_productos_filtro_Result item in dbres)
                {
                    dbres_productos.Add(EProducto.Convert(item));
                }

                ViewBag.productos = dbres_productos;
                
                return View(Utils.Vistas.vistaVerProducto);
            }
            else
            {
                return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
            }
        }

        [HttpGet]
		public ActionResult obtVistaEditarProducto(int productoId)
		{
			if (SysSession.IsSessionOpen(this))
			{
				// Envia el ID del usuario
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);

				// Recupera la información del producto START
				List<sel_productos_para_intra_editar_productos_Result> dbres_producto = BDFecade.db().sel_productos_para_intra_editar_productos(productoId).ToList();
				if (dbres_producto.Count() <= 0)
				{
					return Redirect(Utils.Ruta.rutaVistaVerProductos.getRedirect());
				}
				EProducto producto_data = EProducto.Convert(dbres_producto[0]);

				// Recupera la composición de un producto START
				List<sel_productos_composicion_Fil_id_producto_Result> dbres_composicion = BDFecade.db().sel_productos_composicion_Fil_id_producto(productoId).ToList();
				producto_data.composicion = dbres_composicion;

				// Recupera la aplicación de un producto START
				List<sel_productos_aplicacion_Fil_id_producto_Result> dbres_aplicacion = BDFecade.db().sel_productos_aplicacion_Fil_id_producto(productoId).ToList();
				producto_data.aplicacion = dbres_aplicacion;

				ViewBag.producto_data = producto_data;

                ViewBag.imagenTablaAplicacion = BDFecade.db().cms_obtImagenTabla(productoId);

                return View(Utils.Vistas.vistaEditarProducto);
			}
			else
			{
				this.Session.Clear();
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

		[HttpGet]
		public ActionResult obtVistaNuevoProducto()
		{
			if (SysSession.IsSessionOpen(this))
			{
				// Envia el ID del usuario
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				
				// Recupera los tipos de producto START
				List<sel_producto_tipo_Result> dbres = BDFecade.db().sel_producto_tipo().ToList();
				List<EProductoTipo> dbres_obj = new List<EProductoTipo>();
				dbres_obj.Add(new EProductoTipo()
				{
					id = -1,
					nombre = "Seleccione un producto"
				});
				foreach (sel_producto_tipo_Result item in dbres)
				{
					dbres_obj.Add(new EProductoTipo()
					{
						id = item.id,
						nombre = item.nombre
					});
				}
				ViewBag.data_producto_tipo = dbres_obj;
				// Recupera los tipos de producto END

				return View(Utils.Vistas.vistaNuevoProducto);
			}
			else
			{
				this.Session.Clear();
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

		[HttpGet]
		public ActionResult obtVistaVerUsuarios()
		{
			if (SysSession.IsSessionOpen(this))
			{
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				return View(Utils.Vistas.vistaUsuariosVer);
			}
			else
			{
				SysSession.closeSession(this);
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

        [HttpGet]
        public ActionResult obtVistaEditarUsuarios(int usuarioId)
        {
            //  Obtiene la información del usuario
            List<cms_seccionUsuariosObtener_Result> dbres = BDFecade.db().cms_seccionUsuariosObtener(usuarioId).ToList();
            string nombreUsuario = string.Empty;
            string correoElectronico = string.Empty;
            foreach (var el in dbres)
            {
                nombreUsuario = el.nombre;
                correoElectronico = el.correo;
            }

            ViewBag.nombre = nombreUsuario;
            ViewBag.correo = correoElectronico;
            ViewBag.usuarioId = usuarioId;

            return View(Utils.Vistas.vistaUsuariosEditar);
        }

		[HttpGet]
		public ActionResult obtVistaPerfilesUsuarios()
		{
			if (SysSession.IsSessionOpen(this))
			{
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				return View(Utils.Vistas.vistaUsuariosPerfiles);
			}
			else
			{
				SysSession.closeSession(this);
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

		[HttpGet]
		public ActionResult obtVistaSeccionBuscadorProductos()
		{
			if (SysSession.IsSessionOpen(this))
			{
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				return View(Utils.Vistas.vistaSeccionBuscadorProductos);
			}
			else
			{
				SysSession.closeSession(this);
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

		[HttpGet]
		public ActionResult obtVistaSeccionHome()
		{
			if (SysSession.IsSessionOpen(this))
			{
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				return View(Utils.Vistas.vistaSeccionHome);
			}
			else
			{
				SysSession.closeSession(this);
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

		[HttpGet]
		public ActionResult obtVistaSeccionInformacionGeneral()
		{
			if (SysSession.IsSessionOpen(this))
			{
				ViewBag.usuario_id = SysSession.getIdValue<int>(this);
				return View(Utils.Vistas.vistaSeccionInformacionGeneral);
			}
			else
			{
				SysSession.closeSession(this);
				return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
			}
		}

        [HttpGet]
        public ActionResult obtVistaSeccionNosotros()
        {
            if (SysSession.IsSessionOpen(this))
            {
                ViewBag.usuario_id = SysSession.getIdValue<int>(this);
                return View(Utils.Vistas.vistaSeccionNosotros);
            }
            else
            {
                SysSession.closeSession(this);
                return Redirect(Utils.Ruta.rutaVistaLogin.getRedirect());
            }
        }
	}
}