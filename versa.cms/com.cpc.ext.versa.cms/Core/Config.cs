using System;
using System.Configuration;

namespace com.carzapc.core.web
{
	public class Config
	{
        public enum VariablesWebConfig {
            rutaApiDirectorios,
            tokenApiDirectorios
        }

		// Método que retorna el valor String de una variable del Web.config
		public static string getVarFromConfig(Enum constName)
		{
			return ConfigurationManager.AppSettings.Get(constName.ToString());
		}

		// Método que retorna el valor T de una variable del Web.config
		public static T getVarFromConfig<T>(Enum constName)
		{
			return (T)Convert.ChangeType(getVarFromConfig(constName), typeof(T));
		}
	}
}
