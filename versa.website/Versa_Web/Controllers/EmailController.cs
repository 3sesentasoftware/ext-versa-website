using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using Versa_Web.Code.fecades;

namespace Versa_Web.Controllers
{
	public class EmailController : Controller
    {

        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public JsonResult sendMail(string nombre, string correo, string asunto, string mensaje)
		{
			// Guarda el mensaje en la base de datos
			DBFecade.dbObj().guardarMensajeContacto(nombre, correo, asunto, mensaje);

			//	Prepara las variables de la función
			string senderEmail = string.Empty;
			string senderPassword = string.Empty;
			string recipientEmail = string.Empty;
			string mailServer = string.Empty;
			int puerto = 0;

			// Verifica si el entorno de ejecución es DESARROLLO o PRODUCCION
			string entornoEjecucion = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.ENTORNO_EJECUCION);
			if (entornoEjecucion == Versa_Web.Code.Utils.ENTORNO_EJECUCION.DESARROLLO.ToString())
			{
				// El entorno de ejecución es de desarrollo
				senderEmail = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.DESARROLLO_SENDER_EMAIL);
				senderPassword = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.DESARROLLO_SENDER_PASSWORD);
				mailServer = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.DESARROLLO_MAIL_SERVER);
				string puertoString = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.DESARROLLO_SMTP_PORT);
				recipientEmail = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.DESARROLLO_TO_EMAIL);
				puerto = Convert.ToInt32(puertoString);

				//	Guarda el evento de la aplicación
				DBFecade.dbObj().nuevoEventoAplicacion("Se está preparando un email en entorno de ejecución de desarrollo", 2);
			}
			else
			{
				// El entorno de ejecución es de producción
				senderEmail = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.PRODUCCION_SENDER_EMAIL);
				senderPassword = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.PRODUCCION_SENDER_PASSWORD);
				mailServer = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.PRODUCCION_MAIL_SERVER);
				string puertoString = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.PRODUCCION_SMTP_PORT);
				recipientEmail = Versa_Web.Code.Utils.getVarFromConfig(Code.Utils.ConstantesConfig.PRODUCCION_TO_EMAIL);
				puerto = Convert.ToInt32(puertoString);
				
				//	Guarda el evento de la aplicación
				DBFecade.dbObj().nuevoEventoAplicacion("Se está preparando un email en entorno de ejecución de producción", 2);
			}

			SmtpClient client = new SmtpClient(mailServer, puerto);

			try
			{
				client.EnableSsl = Versa_Web.Code.Utils.getVarFromConfig<bool>(Code.Utils.ConstantesConfig.ENVIO_CORREOS_USO_SSL);
				DBFecade.dbObj().nuevoEventoAplicacion("Se configuró el envío de correos con SSL " + Versa_Web.Code.Utils.getVarFromConfig<bool>(Code.Utils.ConstantesConfig.ENVIO_CORREOS_USO_SSL).ToString(), 2);
			}
			catch (Exception ex)
			{
				DBFecade.dbObj().nuevoEventoAplicacion("Ha ocurrido la siguiente excepción: " + ex.Message + ex.StackTrace, 1);
			}

			client.Timeout = 100000;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential(senderEmail, senderPassword);

			if (entornoEjecucion == Versa_Web.Code.Utils.ENTORNO_EJECUCION.DESARROLLO.ToString())
			{
				// El entorno de ejecución es de desarrollo
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
			}

			//	Arma el cuerpo del correo
			string emailBody = "Nombre del remitente: " + nombre + ", Correo del remitente: " + correo + ", Asunto: " + asunto + ", Cuerpo del mensaje: " + mensaje;

			// Recupera los correos electrónicos
			string[] recipientEmailArray = recipientEmail.Split(';');
			foreach (string el in recipientEmailArray)
			{
				try
				{
					MailMessage mailMessage = new MailMessage(senderEmail, el, "Nuevo mensaje de contacto", emailBody);
					mailMessage.IsBodyHtml = true;
					mailMessage.BodyEncoding = UTF8Encoding.UTF8;

					client.Send(mailMessage);
					DBFecade.dbObj().nuevoEventoAplicacion("Se ha enviado el correo electrónico a la dirección: " + el, 2);
				}
				catch (Exception ex)
				{
					DBFecade.dbObj().nuevoEventoAplicacion("Ha ocurrido la siguiente excepcion: " + ex.Message + ex.StackTrace, 1);
					Console.WriteLine(ex.ToString());
				}
			}
			
			return null;
		}
		
        public JsonResult SendMailToUser(string subject, string body)
        {
            String Result = "";
            Result = SendEmail(subject, body);

            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public String SendEmail(string subject, string emailBody)
        {

            try
            {

                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                string recipientEmail = System.Configuration.ConfigurationManager.AppSettings["toEmail"].ToString();
                string mailServer = System.Configuration.ConfigurationManager.AppSettings["MailServer"].ToString();
                string puertoString = System.Configuration.ConfigurationManager.AppSettings["SMTPport"];
                int puerto = Convert.ToInt32(puertoString);

                SmtpClient client = new SmtpClient(mailServer, puerto);
                client.EnableSsl = false;
                client.Timeout = 100000;
                //Descomentar para pruebas locales
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //Descomentar para puebas locales y cambiar configuración del Web.config
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                client.Send(mailMessage);
              
                return puertoString;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

    }
}