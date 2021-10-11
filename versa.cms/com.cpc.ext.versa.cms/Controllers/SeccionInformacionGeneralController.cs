using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.Entities;
using com.cpc.ext.versa.cms.Models.ServiceInterfaces;
using System.Web;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms.Controllers
{
    public class SeccionInformacionGeneralController : Controller
    {
        [HttpPost]
        public ActionResult actualizar(FormCollection formColl)
        {
            string telefonoContacto = formColl["telefono-contacto"];
            string direccionFisica = formColl["direccion-fisica"];
            IEntitiesActualizar obj = new EInformacionContactoEmpresa() {
                telefonoContacto = telefonoContacto,
                direccionFisica = direccionFisica
            };
            obj.actualizar(obj);
            return vistaPrincipal();
        }

        [HttpPost]
        public ActionResult actualizarRedesSociales(FormCollection formColl)
        {
            string paginaFacebook = formColl["pagina-facebook"];
            string canalYoutube = formColl["canal-youtube"];
            IEntitiesActualizar obj = new ERedesSocialesEmpresa()
            {
                urlFacebook = paginaFacebook,
                urlYoutube = canalYoutube
            };
            obj.actualizar(obj);
            return vistaPrincipal();
        }

        [HttpPost]
        public ActionResult actualizarLogotipo(HttpPostedFileBase logotipo)
        {
            string resultado = FileServiceInterface.sendPostFile(logotipo);
            IEntitiesActualizar obj = new ELogotipoEmpresa() { nombreArchivo = resultado };
            obj.actualizar(obj);
            return vistaPrincipal();
        }

        [HttpPost]
        public ActionResult actualizarDocumentoEsr(HttpPostedFileBase documento)
        {
            string resultado = FileServiceInterface.sendPostFile(documento);
            IEntitiesActualizar obj = new EDocumentoEsr() { nombreArchivo = resultado };
            obj.actualizar(obj);
            return vistaPrincipal();
        }

        private ActionResult vistaPrincipal()
        {
            return Redirect(Utils.Ruta.rutaVistaSeccionesInformacionGeneral.getRedirect());
        }
        
    }
}
