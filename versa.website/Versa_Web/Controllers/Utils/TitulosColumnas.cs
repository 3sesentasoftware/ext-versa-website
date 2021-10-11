using System.Collections.Generic;
using System.Web.Configuration;
using Versa_Web.Models.EntityFramework;

namespace Versa_Web.Controllers.Utils
{
	public class TitulosColumnas
	{

		public static string GetTitulo(int id_columna, List<sel_tabla_aplicacion_titulo_por_id_producto_Result> dbres_tabla_aplicacion_titulo)
		{
			if (id_columna == 1)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 1);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:cultivo"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:cultivo"].ToString();
				}
			}
			else if (id_columna == 2)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 2);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:enfermedad"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:enfermedad"].ToString();
				}
			}
			else if (id_columna == 3)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 3);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:dosis"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:dosis"].ToString();
				}
			}
			else if (id_columna == 4)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 4);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:interseg"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:interseg"].ToString();
				}
			}
			else if (id_columna == 5)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 5);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:observaciones"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:observaciones"].ToString();
				}
			}
			else if (id_columna == 6)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 6);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:epoca"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:epoca"].ToString();
				}
			}
			else if (id_columna == 7)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 7);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:lmrp"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:lmrp"].ToString();
				}
			}
			else if (id_columna == 8)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 8);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:epa"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:epa"].ToString();
				}
			}
			else if (id_columna == 9)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 9);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:estudios"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:estudios"].ToString();
				}
			}
			else if (id_columna == 10)
			{
				sel_tabla_aplicacion_titulo_por_id_producto_Result resultado = dbres_tabla_aplicacion_titulo.Find(s => s.id_columna == 10);
				if (resultado != null)
				{
					if (string.IsNullOrWhiteSpace(resultado.titulo))
					{
						return WebConfigurationManager.AppSettings["titulo:defecto:tolerancias"].ToString();
					}
					else
					{
						return resultado.titulo;
					}
				}
				else
				{
					return WebConfigurationManager.AppSettings["titulo:defecto:tolerancias"].ToString();
				}
			}
			else
			{
				return string.Empty;
			}
		}
	}
}