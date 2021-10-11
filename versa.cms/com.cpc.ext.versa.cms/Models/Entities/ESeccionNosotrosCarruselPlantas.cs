using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    public class ESeccionNosotrosCarruselPlantas : IEntitiesActualizar, IEntitiesObtenerTodos, IEntitiesNuevo, IEntitiesDesactivar
    {
        public int id { get; set; }

        public string nombreArchivo { get; set; }

        public int orden { get; set; }

        public bool movil { get; set; }

        public void actualizar(IEntitiesActualizar el)
        {
            ESeccionNosotrosCarruselPlantas elemento = ConvertEntities.convertTo<ESeccionNosotrosCarruselPlantas>(el);

            BDFecade.db().cms_seccionNosotrosCarruselPlantasActualizarOrden(elemento.id, elemento.orden);

            BDFecade.db().cms_seccionNosotrosCarruselPlantasActualizarMovil(elemento.id, elemento.movil);
        }

        public void desactivar()
        {
            BDFecade.db().cms_seccionNosotrosCarruselPlantasDesactivar(this.id);
        }

        // **
        public void nuevo()
        {
            BDFecade.db().cms_seccionNosotrosCarruselPlantasNuevo(this.nombreArchivo, this.orden, this.movil);
        }

        public List<T> obtTodos<T>()
        {
            List<T> resultado = new List<T>();

            foreach (cms_seccionNosotrosCarruselPlantasObtener_Result el in BDFecade.db().cms_seccionNosotrosCarruselPlantasObtener().ToList())
            {
                resultado.Add(ConvertEntities.convertTo<T>(convertir(el)));
            }
            return resultado;
        }

        private ESeccionNosotrosCarruselPlantas convertir(cms_seccionNosotrosCarruselPlantasObtener_Result el)
        {
            return new ESeccionNosotrosCarruselPlantas()
            {
                id = el.id,
                nombreArchivo = el.nombre_archivo,
                orden = el.orden,
                movil = Convert.ToBoolean(el.movil)
            };
        }

        public int obtUltimoOrden()
        {
            ObjectResult<int?> dbres = BDFecade.db().cms_seccionNosotrosCarruselPlantasObtenerUltimoOrden();
            int resultado = -1;
            foreach (var el in dbres)
                resultado = Convert.ToInt32(el);
            return resultado;
        }

        public void corregirOrden()
        {

        }
    }
}