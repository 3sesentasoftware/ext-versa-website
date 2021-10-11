using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EUsuario
	{
		public int id { get; set; }

		public string nombre { get; set; }

		public string correo { get; set; }

		public string perfilPuesto { get; set; }

		public static string obtNombreUsuario(int usuario_id)
		{
			List<cms_obtNombreUsuario_Result> dbres = BDFecade.db().cms_obtNombreUsuario(usuario_id).ToList();
			string nombre = string.Empty;
			foreach (cms_obtNombreUsuario_Result el in dbres)
				nombre = el.nombre;
			return nombre;
		}

		public static int autenticar(string correoUsuario, string passUsuario)
		{
			List<Nullable<int>> dbres = BDFecade.db().val_login(correoUsuario, passUsuario, "").ToList();

			if (dbres.Count() > 0)
			{
				if (dbres.Count() == 1)
				{
					int identificador = 0;
					foreach (int item in dbres)
					{
						return item;
					}
					return identificador;
				}
				else
				{
					return 0;
				}
			}
			else
			{
				return 0;
			}
		}

		public static void nuevoUsuario(string nombre, string correo, string clave, int usuarioPerfilId)
		{
			BDFecade.db().usuarioNuevo(nombre, correo, clave, usuarioPerfilId);
		}

		public static List<EUsuario> obtTodos()
		{
			List<EUsuario> usuarios = new List<EUsuario>();
			List<usuarioObtTodos_Result> dbres = BDFecade.db().usuarioObtTodos().ToList();
			foreach (usuarioObtTodos_Result el in dbres)
			{
				usuarios.Add(new Entities.EUsuario()
				{
					id = el.id,
					nombre = el.nombre,
					correo = el.correo,
					perfilPuesto = el.perfilPuesto
				});
			}
			return usuarios;
		}
	}
}