using com.carzapc.core.web;
using System.Data.Entity.Core.Objects;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    public class ELogotipoEmpresa : IEntities, IEntitiesActualizar, IEntitiesObtener
    {
        public int id { get; set; }

        public string nombreArchivo { get; set; }

        public void actualizar(IEntitiesActualizar el)
        {
            ELogotipoEmpresa obj = ConvertEntities.convertTo<ELogotipoEmpresa>(el);
            BDFecade.db().cms_logotipoEmpresaActualizar(obj.nombreArchivo);
        }

        public T obt<T>()
        {
            ObjectResult<string> result = BDFecade.db().cms_logotipoEmpresaObtener();
            string nombreArchivo = string.Empty;
            foreach (string el in result)
                nombreArchivo = el;
            IEntitiesObtener resultado = null;
            resultado = new ELogotipoEmpresa() { nombreArchivo = nombreArchivo };
            return ConvertEntities.convertTo<T>(resultado);
        }
    }
}