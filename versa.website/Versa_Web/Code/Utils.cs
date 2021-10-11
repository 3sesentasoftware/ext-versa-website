using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Versa_Web.Code
{
	public class Utils
	{
		/*
		 *	En esta sección se definen las variables de configuración utilizadas por la aplicación.
		 *	De esta manera, se puede acceder a dichas variables de manera más sencilla. Sólo llamándolas
		 *	directamente en código sin necesidad de ubicar su correcta nomenclatura en el web.config
		 */
		#region Variables de configuracion
		public enum ConstantesConfig
		{
			ENTORNO_EJECUCION,
			PRODUCCION_SENDER_EMAIL,
			PRODUCCION_TO_EMAIL,
			PRODUCCION_SENDER_PASSWORD,
			PRODUCCION_MAIL_SERVER,
			PRODUCCION_SMTP_PORT,
			DESARROLLO_SENDER_EMAIL,
			DESARROLLO_TO_EMAIL,
			DESARROLLO_SENDER_PASSWORD,
			DESARROLLO_MAIL_SERVER,
			DESARROLLO_SMTP_PORT,
			ENVIO_CORREOS_USO_SSL,
            RUTA_SERVICIO_ARCHIVOS,
            RUTA_ARCHIVOS_ASSETS
        }
		#endregion

		public enum ENTORNO_EJECUCION
		{
			PRODUCCION,
			DESARROLLO
		}

		public static string getVarFromConfig(Utils.ConstantesConfig constName)
		{
			return ConfigurationManager.AppSettings.Get(constName.ToString());
		}

		public static T getVarFromConfig<T>(Utils.ConstantesConfig constName)
		{
			return (T)Convert.ChangeType(getVarFromConfig(constName), typeof(T));
		}

        public static string getUrlFile(string nombreArchivo)
        {
            return Utils.getVarFromConfig(Utils.ConstantesConfig.RUTA_SERVICIO_ARCHIVOS) + nombreArchivo;
        }

        public static string getUrlAssets(string nombreArchivo, WebViewPage context)
        {
            return context.Url.Content(Utils.getVarFromConfig(Utils.ConstantesConfig.RUTA_ARCHIVOS_ASSETS) + nombreArchivo);
        }
	}
}