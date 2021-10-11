using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
	public class EProducto : IEntities
	{
		public int id { get; set; }

		public int producto_tipo_id { get; set; }

		public string producto_tipo { get; set; }

		public string sku { get; set; }

		public string nombre { get; set; }

		public string descripcion { get; set; }

		public string presentacion { get; set; }

		public string contenido { get; set; }

		public string beneficios { get; set; }

		public string imagen { get; set; }

		public double precio { get; set; }

		public string pdf_nombre { get; set; }

		public Nullable<System.DateTime> created_at { get; set; }

		public Nullable<System.DateTime> deleted_at { get; set; }

		public Nullable<System.DateTime> updated_at { get; set; }

		public Nullable<bool> status { get; set; }

		public string subnombre { get; set; }

		public string Cintillo { get; set; }

		public Nullable<bool> show_index { get; set; }

		public string pie { get; set; }

		public string imagen_logo { get; set; }

		public string imagen_logo_carpeta { get; set; }

		public string imagen_logo_blanco { get; set; }

		public static EProducto Convert(sel_productos_para_intra_ver_productos_Result item)
		{
			EProducto obj = new EProducto();
			obj.id = item.id;
			obj.producto_tipo_id = item.producto_tipo_id;
			obj.producto_tipo = item.producto_tipo;
			obj.sku = item.sku;
			obj.nombre = item.nombre;
			obj.descripcion = item.descripcion;
			obj.presentacion = item.presentacion;
			obj.contenido = item.contenido;
			obj.beneficios = item.beneficios;
			obj.imagen = item.imagen;
			obj.precio = item.precio;
			obj.pdf_nombre = item.pdf_nombre;
			obj.created_at = item.created_at;
			obj.deleted_at = item.deleted_at;
			obj.updated_at = item.updated_at;
			obj.status = item.status;
			obj.subnombre = item.subnombre;
			obj.Cintillo = item.Cintillo;
			obj.show_index = item.show_index;
			obj.pie = item.pie;
			obj.imagen_logo = item.imagen_logo;
			obj.imagen_logo_carpeta = item.imagen_logo_carpeta;
			obj.imagen_logo_blanco = item.imagen_logo_blanco;
			return obj;
		}

		public static EProducto Convert(sel_productos_para_intra_ver_productos_filtro_Result item)
		{
			EProducto obj = new EProducto();
			obj.id = item.id;
			obj.producto_tipo_id = item.producto_tipo_id;
			obj.producto_tipo = item.producto_tipo;
			obj.sku = item.sku;
			obj.nombre = item.nombre;
			obj.descripcion = item.descripcion;
			obj.presentacion = item.presentacion;
			obj.contenido = item.contenido;
			obj.beneficios = item.beneficios;
			obj.imagen = item.imagen;
			obj.precio = item.precio;
			obj.pdf_nombre = item.pdf_nombre;
			obj.created_at = item.created_at;
			obj.deleted_at = item.deleted_at;
			obj.updated_at = item.updated_at;
			obj.status = item.status;
			obj.subnombre = item.subnombre;
			obj.Cintillo = item.Cintillo;
			obj.show_index = item.show_index;
			obj.pie = item.pie;
			obj.imagen_logo = item.imagen_logo;
			obj.imagen_logo_carpeta = item.imagen_logo_carpeta;
			obj.imagen_logo_blanco = item.imagen_logo_blanco;
			return obj;
		}

		public static EProducto Convert(sel_productos_para_intra_editar_productos_Result item)
		{
			EProducto obj = new EProducto();
			obj.id = item.id;
			obj.producto_tipo_id = item.producto_tipo_id;
			obj.producto_tipo = item.producto_tipo;
			obj.sku = item.sku;
			obj.nombre = item.nombre;
			obj.descripcion = item.descripcion;
			obj.presentacion = item.presentacion;
			obj.contenido = item.contenido;
			obj.beneficios = item.beneficios;
			obj.imagen = item.imagen;
			obj.precio = item.precio;
			obj.pdf_nombre = item.pdf_nombre;
			obj.created_at = item.created_at;
			obj.deleted_at = item.deleted_at;
			obj.updated_at = item.updated_at;
			obj.status = item.status;
			obj.subnombre = item.subnombre;
			obj.Cintillo = item.Cintillo;
			obj.show_index = item.show_index;
			obj.pie = item.pie;
			obj.imagen_logo = item.imagen_logo;
			obj.imagen_logo_carpeta = item.imagen_logo_carpeta;
			obj.imagen_logo_blanco = item.imagen_logo_blanco;
			return obj;
		}

		public List<IEntities> obtTodos()
		{
			List<sel_productos_para_intra_ver_productos_Result> dbres = BDFecade.db().sel_productos_para_intra_ver_productos().ToList();

			List<IEntities> productos = new List<IEntities>();

			foreach (sel_productos_para_intra_ver_productos_Result item in dbres)
			{
				productos.Add(EProducto.Convert(item));
			}

			return productos;
		}

		public List<sel_productos_composicion_Fil_id_producto_Result> composicion { get; set; }

		public List<sel_productos_aplicacion_Fil_id_producto_Result> aplicacion { get; set; }
	}
}