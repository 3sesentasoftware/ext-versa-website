using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.Entities;
using com.cpc.ext.versa.cms.Models.ServiceInterfaces;
using System;
using System.Web;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
    public class SeccionNosotrosController : Controller
    {
        // Ruta que genera un nuevo elemento
        [HttpPost]
        public ActionResult nuevoCarruselPlanta(HttpPostedFileBase imagen, FormCollection formColl)
        {
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

                IEntitiesNuevo obj = new ESeccionNosotrosCarruselPlantas() { nombreArchivo = nombreArchivo, orden = orden, movil = movil };

                obj.nuevo();
            }
            return vistaPrincipal();
        }

        [HttpPost]
        public ActionResult eliminarCarruselPlanta(FormCollection formColl)
        {
            string idElemento = formColl["id"];

            IEntitiesDesactivar elemento = new ESeccionNosotrosCarruselPlantas() { id = Convert.ToInt32(idElemento) };
            elemento.desactivar();

            return vistaPrincipal();
        }

        public ActionResult editarCarruselPlanta(FormCollection formColl)
        {
            string id = formColl["id"];
            string orden = formColl["orden"];
            string strMovil = formColl["movil"];
            bool movil = false;
            if (string.IsNullOrWhiteSpace(strMovil))
                movil = false;
            else
                movil = true;

            IEntitiesActualizar elemento = new ESeccionNosotrosCarruselPlantas() { id = Convert.ToInt32(id), orden = Convert.ToInt32(orden), movil = movil };
            elemento.actualizar(elemento);

            return vistaPrincipal();
        }

        //  Ruta que actualiza la línea del tiempo
        [HttpPost]
        public ActionResult editarLineaTiempo(HttpPostedFileBase imagen)
        {
            string nombreArchivo = FileServiceInterface.sendPostFile(imagen);

            BDFecade.db().cms_seccionNosotrosLineaTiempoActualizar(nombreArchivo);

            return vistaPrincipal();
        }

        private ActionResult vistaPrincipal()
        {
            return Redirect(Utils.Ruta.rutaVistaSeccionesNosotros.getRedirect());
        }
    }
}