using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using Versa_Web.Code.fecades;
using Versa_Web.Models.EntityFramework;

namespace Versa_Web.Code.objetos
{
    public class OProducto
	{

		public enum Vistas {
			Index,
			VerCategoria
		}

		public int id { get; set; }
		public string sku { get; set; }
		public string nombre { get; set; }
		public string subnombre { get; set; }
		public string cintillo { get; set; }
		public string categoria { get; set; }
		public string classname { get; set; }
		public int idTipo { get; set; }
		public string descripcion { get; set; }
		public string presentacion { get; set; }
		public string contenido { get; set; }
		public string beneficios { get; set; }
		public string imagen { get; set; }
		public double precio { get; set; }
		public string pdfNombre { get; set; }
		public string imagenLogo { get; set; }
		public string imagenLogoCarpeta { get; set; }
		public string cultivo { get; set; }
		public string classnameImgMobile { get; set; }
		public string imagenLogoBlanco { get; set; }
		public string pie { get; set; }
		public int cmsTablasComposicionId { get; set; }

		public static List<OProducto> get(OProducto.Vistas vista)
		{
			if (vista == Vistas.Index)
			{
				return getParaIndex();
			}
			else if (vista == Vistas.VerCategoria)
			{
				return getParaVerCategoria();
			}
			else
			{
				return null;
			}
		}
		
		private static List<OProducto> getParaIndex()
		{
			List<OProducto> datosObjetos = new List<OProducto>();
			ObjectResult<sel_productos_para_home_index_Result> datos = DBFecade.dbObj().sel_productos_para_home_index();
			foreach (var item in datos)
			{
				OProducto obj = new OProducto()
				{
					id = item.id,
					nombre = item.nombre,
					subnombre = item.subnombre,
					classname = item.classname,
					idTipo = item.id_tipo,
					categoria = item.categoria,
					descripcion = item.descripcion,
					imagenLogo = item.imagen_logo,
					imagenLogoCarpeta = item.imagen_logo_carpeta,
					imagen = item.imagen,
					cintillo = item.Cintillo,
					classnameImgMobile = item.classname_img_mobile,
					imagenLogoBlanco = item.imagen_logo_blanco
				};
				datosObjetos.Add(obj);
			}
			return datosObjetos;
		}

		private static List<OProducto> getParaVerCategoria()
		{
			List<OProducto> datosObjetos = new List<OProducto>();
			ObjectResult<sel_productos_Result> datos = DBFecade.dbObj().sel_productos();
			foreach (var item in datos)
			{
                OProducto obj = new OProducto();
                obj.id = item.id;
                obj.idTipo = item.id_tipo;
                obj.sku = Convert.ToString(item.sku);
                obj.nombre = Convert.ToString(item.nombre);
                obj.subnombre = Convert.ToString(item.subnombre);
                obj.cintillo = Convert.ToString(item.Cintillo);
                obj.descripcion = Convert.ToString(item.descripcion);
                obj.presentacion = Convert.ToString(item.presentacion);
                obj.contenido = Convert.ToString(item.contenido);
                obj.beneficios = Convert.ToString(item.beneficios);
                obj.imagen = Convert.ToString(item.imagen);
                obj.imagenLogo = Convert.ToString(item.imagen_logo);
                obj.imagenLogoCarpeta = Convert.ToString(item.imagen_logo_carpeta);
                obj.imagenLogoBlanco = Convert.ToString(item.imagen_logo_blanco);
                obj.precio = item.precio;
                obj.pdfNombre = Convert.ToString(item.pdf_nombre);
                obj.pie = Convert.ToString(item.pie);
                obj.cmsTablasComposicionId = (item.cms_tablas_composicion_id == null ? 0 : (int)item.cms_tablas_composicion_id);
                obj.classname = Convert.ToString(item.classname);
                obj.categoria = Convert.ToString(item.categoria);
                obj.classnameImgMobile = Convert.ToString(item.classname_img_mobile);
                
				datosObjetos.Add(obj);
			}
			return datosObjetos;
		}
	}
}