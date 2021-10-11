using com.carzapc.core.web;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace com.cpc.ext.versa.cms.Models.ServiceInterfaces
{
    public class FileServiceInterface
    {
        public static string sendPostFile(HttpPostedFileBase file)
        {
            using (var client = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    // Dictionary<string, string> parameters = new Dictionary<string, string>();
                    // parameters.Add("api-key", Config.getVarFromConfig(Config.VariablesWebConfig.tokenApiDirectorios));
                    // HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                    form.Add(new StringContent(Config.getVarFromConfig(Config.VariablesWebConfig.tokenApiDirectorios)), "api-key");
                                       
                    byte[] Bytes = new byte[file.InputStream.Length + 1];
                    file.InputStream.Read(Bytes, 0, Bytes.Length);
                    var fileContent = new ByteArrayContent(Bytes);
                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
                    form.Add(fileContent);

                    var requestUri = Config.getVarFromConfig(Config.VariablesWebConfig.rutaApiDirectorios);
                    var result = client.PostAsync(requestUri, form).Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        JObject m = result.Content.ReadAsAsync<JObject>().Result;
                        string fileName = m["fileName"].ToString();
                        return fileName;
                    }
                    else
                    {
                        return "Failed !" + result.Content.ToString();
                    }
                }
            }
        }
    }
}