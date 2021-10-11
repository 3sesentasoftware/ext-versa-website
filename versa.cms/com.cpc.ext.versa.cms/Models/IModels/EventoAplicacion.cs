using com.carzapc.core.web;
using System;

namespace com.cpc.ext.versa.cms.Models.IModels
{
	public class EventoAplicacion
	{
		private const int EXCEPCION = 1;

		private const int EVENTO = 2;

		public static void nuevaExcepcion(Exception exc)
		{
			try
			{
				BDFecade.db().nuevoEventoAplicacion("Mensaje: " + exc.Message + " Stack: " + exc.StackTrace, EXCEPCION);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + " " + ex.StackTrace, 1);
			}
		}
	}
}