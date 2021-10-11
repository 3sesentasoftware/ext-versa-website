using System.Collections.Generic;

namespace Versa_Web.Code.filtros
{
	public interface IFiltro<T>
	{
		List<T> doIt(List<T> lista);
	}
}
