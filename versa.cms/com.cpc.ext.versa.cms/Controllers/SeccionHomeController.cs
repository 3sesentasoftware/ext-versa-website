using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.ServiceInterfaces;
using System;
using System.Web;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
    public class SeccionHomeController : Controller
    {
        [HttpPost]
        public ActionResult nuevoNoticiasCarrusel(HttpPostedFileBase imagen, FormCollection formColl)
        {
            string urlRedireccion = formColl["url-redireccion"];
            string strOrden = formColl["orden"];
            string strMovil = formColl["movil"];

            int orden = 0;
            if (Int32.TryParse(strOrden, out orden))
            {
                bool movil = false;
                if (string.IsNullOrWhiteSpace(strMovil))
                    movil = false;
                else
                    movil = true;

                string nombreArchivo = FileServiceInterface.sendPostFile(imagen);

                BDFecade.db().cms_seccionHomeNoticiasCarruselNuevo(nombreArchivo, urlRedireccion, orden, movil);
            }

            return vistaPrincipal();
        }

        [HttpGet]
        public ActionResult eliminarNoticiasCarrusel(int idVideo)
        {
            // string idElemento = formColl["idVideo"];

            BDFecade.db().cms_seccionHomeNoticiasCarruselDesactivar(Convert.ToInt32(idVideo));

            return vistaPrincipal();
        }

        [HttpPost]
        public ActionResult editarNoticiasCarrusel(FormCollection formColl)
        {
            string id = formColl["id"];
            string urlRedireccion = formColl["url-redireccion"];
            string orden = formColl["orden"];
            string strMovil = formColl["movil"];
            bool movil = false;
            if (string.IsNullOrWhiteSpace(strMovil))
                movil = false;
            else
                movil = true;

            BDFecade.db().cms_seccionHomeNoticiasCarruselActualizar(Convert.ToInt32(id), urlRedireccion, Convert.ToInt32(orden), movil);

            return vistaPrincipal();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult nuevoEventoVideo(HttpPostedFileBase video, FormCollection formColl)
        {
            string strOrden = formColl["orden"];
            string descripcion = formColl["descripcion"];
            int orden = 0;
            if (Int32.TryParse(strOrden, out orden))
            {
                string nombreArchivo = FileServiceInterface.sendPostFile(video);

                BDFecade.db().cms_seccionHomeVideosEventosNuevoV2(nombreArchivo, orden, descripcion);
            }
            return vistaPrincipal();
        }

        [HttpPost]
        public ActionResult eliminarEventoVideo(FormCollection formColl)
        {
            string idElemento = formColl["id"];

            BDFecade.db().cms_seccionHomeVideosEventosDesactivar(Convert.ToInt32(idElemento));

            return vistaPrincipal();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult editarEventoVideo(FormCollection formColl)
        {
            string idVideo = formColl["id"];
            string descripcion = formColl["descripcion"];

            BDFecade.db().cms_seccionHomeVideosEventosActualizarDescripcion(Convert.ToInt32(idVideo), descripcion);

            return vistaPrincipal();
        }

        [HttpGet]
        public ActionResult getEliminarEventoVideo(int idVideo)
        {
            BDFecade.db().cms_seccionHomeVideosEventosDesactivar(Convert.ToInt32(idVideo));

            return vistaPrincipal();
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult editarSobreNosotros(FormCollection formColl)
        {
            string contenido = formColl["seccion-nosotros-contenido"];

            BDFecade.db().cms_seccionHomeSobreNosotrosActualizar(contenido);

            return vistaPrincipal();
        }

        [HttpPost]
        public ActionResult editarSobreNosotrosImagen(HttpPostedFileBase imagen)
        {
            string nombreArchivo = FileServiceInterface.sendPostFile(imagen);

            BDFecade.db().cms_seccionHomeSobreNosotrosActualizarNombreArchivo(nombreArchivo);

            return vistaPrincipal();
        }

        public ActionResult vistaPrincipal()
        {
            var resultado = BDFecade.db().cms_seccionHomeNoticiasCarruselObtener();
            return Redirect(Utils.Ruta.rutaVistaSeccionesHome.getRedirect());
        }
    }
}