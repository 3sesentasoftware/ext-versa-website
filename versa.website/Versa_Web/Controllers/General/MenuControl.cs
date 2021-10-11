using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using Versa_Web.Code.fecades;
using Versa_Web.Models.EntityFramework;
using Versa_Web.ViewModels;

namespace Versa_Web.Controllers.General
{
    public class MenuControl
	{
		public static List<MenuModel> getDataMenu()
		{
            var db = DBFecade.dbObj();
			ObjectResult<sel_cms_website_menu_Result> dbres_menu = db.sel_cms_website_menu();
			List<MenuModel> lista = new List<MenuModel>();
			foreach (sel_cms_website_menu_Result item in dbres_menu)
			{
				MenuModel mm = new MenuModel();
				mm.id = item.cms_website_menu_id;
				mm.texto = item.texto;
				mm.html_control_id = item.html_control_id;

				if (item.cms_website_menu_padre_id == null)
				{
					if (item.url == null && item.controlador != null && item.accion != null)
					{
						// Es de tipo 1
						mm.hijo = false;
						mm.padre = false;
						mm.tipo = 1;
						mm.link = null;
						mm.controlador = item.controlador;
						mm.accion = item.accion;
					}
					else if (item.url != null && item.controlador == null && item.accion == null)
					{
						// Es de tipo 2
						mm.hijo = false;
						mm.padre = false;
						mm.tipo = 2;
						mm.link = item.url;
						mm.controlador = null;
						mm.accion = null;
					}
					else if (item.url == null && item.controlador == null && item.accion == null)
					{
						mm.hijo = false;
						mm.padre = true;
						mm.tipo = 0;
						mm.link = null;
						mm.controlador = null;
						mm.accion = null;
					}

					lista.Add(mm);
				}
				else
				{
					// Busca al padre
					MenuModel mm_aux = lista.Find(x => x.id == item.cms_website_menu_padre_id);
					if (mm_aux != null)
					{
						mm.hijo = true;
						mm.padre = false;
						mm.tipo = 0;
						mm.link = item.url;
						mm.controlador = null;
						mm.accion = null;
						mm_aux.hijos.Add(mm);
					}
				}
			}
			return lista;
		}
	}
}