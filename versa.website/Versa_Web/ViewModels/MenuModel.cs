using System.Collections.Generic;

namespace Versa_Web.ViewModels
{
	public class MenuModel
	{
		public MenuModel()
		{
			this.hijos = new List<MenuModel>();
		}
		public int id { get; set; }

		public int tipo { get; set; }

		public string link { get; set; }

		public string controlador { get; set; }

		public string accion { get; set; }

		public string texto { get; set; }

		public List<MenuModel> hijos { get; set; }

		public bool padre { get; set; }

		public bool hijo { get; set; }

		public string html_control_id { get; set; }
	}
}