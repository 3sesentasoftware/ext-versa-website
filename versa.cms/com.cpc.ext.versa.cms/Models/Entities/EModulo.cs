using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EModulo : IEntities, IEntitiesObtenerTodos
	{
		public int id { get; set; }

		public string nombre { get; set; }

		public string descripcion { get; set; }

        public EModulo() { }

        public EModulo(fraseguModuloObtenerTodos_Result el)
        {
            this.id = el.id;
            this.nombre = el.nombre;
            this.descripcion = el.descripcion;
        }

        public List<T> obtTodos<T>()
        {
            List<fraseguModuloObtenerTodos_Result> dbres = BDFecade.db().fraseguModuloObtenerTodos().ToList();
            List<T> resultado = new List<T>();
            dbres.ForEach(
                e => {
                    resultado.Add(ConvertEntities.convertTo<T>(new EModulo(e)));
                }
            );
            return resultado;
        }

	}
}