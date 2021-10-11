using System.Collections.Generic;

namespace Versa_Web.Code.filtros
{
	public class Filtrar<T>
	{
		public static List<T> filtrar(List<T> lista, params IFiltro<T>[] filtros)
		{
			foreach(IFiltro<T> filtro in filtros)
			{
				lista = filtro.doIt(lista);
			}
			return lista;
		}
	}
}