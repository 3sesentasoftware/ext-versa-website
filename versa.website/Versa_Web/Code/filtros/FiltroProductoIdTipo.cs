using System.Collections.Generic;
using System.Linq;
using Versa_Web.Code.objetos;

namespace Versa_Web.Code.filtros
{
	public class FiltroProductoIdTipo : IFiltro<OProducto>
	{
		private int idTipo;

		public FiltroProductoIdTipo(int idTipo)
		{
			this.idTipo = idTipo;
		}

		public List<OProducto> doIt(List<OProducto> lista)
		{
			return (from d in lista where d.idTipo == this.idTipo select d).ToList();
		}
	}
}