using System;
using System.Security.Cryptography;
using System.Text;

namespace com.carzapc.core.web
{
	public class Enc
	{
		// Método que encripta una cadena de texto con SHA1 para generar el nombre de los documentos
		public static string GetSHA1(string texto)
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
