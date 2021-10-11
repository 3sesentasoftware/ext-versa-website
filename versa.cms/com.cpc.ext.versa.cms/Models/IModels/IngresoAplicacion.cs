using com.carzapc.core.web;
using System;

namespace com.cpc.ext.versa.cms.Models.IModels
{
	public class IngresoAplicacion
	{
		public static void nuevoIngresoAplicacion(int usuarioId, string sistemaIp, string sistemaOperativo, string sistemaNavegador)
		{
			try
			{
				BDFecade.db().modutrackNuevoIngresoAplicacion(usuarioId, sistemaIp, sistemaOperativo, sistemaNavegador);
			}
			catch (Exception exc)
			{
				EventoAplicacion.nuevaExcepcion(exc);
			}
		}

		public static void nuevoIngresoAplicacionFallido(string correoFallido, string passFallida, string sistemaIp, string sistemaOperativo, string sistemaNavegador)
		{
			try
			{
				BDFecade.db().modutrackNuevoIngresoFallido(correoFallido, passFallida, sistemaIp, sistemaOperativo, sistemaNavegador);
			}
			catch (Exception exc)
			{
				EventoAplicacion.nuevaExcepcion(exc);
			}
		}
	}
}