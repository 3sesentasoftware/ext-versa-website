using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace com.cpc.ext.versa.cms.Core
{
	public class FileSystem
	{
		private const string rutaAbsolutaCarpetaImagenes = "";

		public static string generarNombreCifrado(string id)
		{
			return GetSHA1(id);
		}

		public static string guardarImagen(HttpPostedFileBase archivo, int id)
		{
			return string.Empty;

		}

		public static string guardarImagen(HttpPostedFileBase archivo)
		{
			string rootPath = rutaAbsolutaCarpetaImagenes;
			string nombreFichero = generarNombreCifrado(archivo.FileName) + Path.GetExtension(archivo.FileName);
			string rutaFinal = Path.Combine(rootPath, nombreFichero);
			archivo.SaveAs(rutaFinal);
			return nombreFichero;
		}

		private static string GetSHA1(string texto)
		{
			SHA1 sha1 = SHA1CryptoServiceProvider.Create();
			Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
			Byte[] hash = sha1.ComputeHash(textOriginal);
			StringBuilder cadena = new StringBuilder();
			foreach (byte i in hash)
			{
				cadena.AppendFormat("{0:x2}", i);
			}
			return cadena.ToString();
		}
	}
}