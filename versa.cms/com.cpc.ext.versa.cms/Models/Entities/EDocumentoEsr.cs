using com.carzapc.core.web;
using System.Data.Entity.Core.Objects;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    public class EDocumentoEsr : IEntitiesActualizar, IEntitiesObtener
    {
        public int id { get; set; }

        public string nombreArchivo { get; set; }

        public void actualizar(IEntitiesActualizar el)
        {
            EDocumentoEsr obj = ConvertEntities.convertTo<EDocumentoEsr>(el);
            BDFecade.db().cms_documentoEsrActualizar(obj.nombreArchivo);
        }

        public T obt<T>()
        {
            ObjectResult<string> result = BDFecade.db().cms_documentoEsrObtener();
            string nombreArchivo = string.Empty;
            foreach (string el in result)
                nombreArchivo = el;
            IEntitiesObtener resultado = null;
            resultado = new EDocumentoEsr() { nombreArchivo = nombreArchivo };
            return ConvertEntities.convertTo<T>(resultado);
        }
    }
}