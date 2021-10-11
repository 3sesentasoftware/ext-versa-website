using com.carzapc.apis.files.Core;
using com.carzapc.core.web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace com.carzapc.apis.files.Controllers
{
    [RoutePrefix("api/images")]
    public class ImagesController : ApiController
    {
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            var httpRequest = HttpContext.Current.Request;
            string apiToken = httpRequest.Params["api-key"];

            if (apiToken.Equals(Config.getVarFromConfig(Config.VariableNames.apiKey)))
            {
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    string fileName = string.Empty;
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        //	Solicita un ID nuevo
                        int lastId = 0;
                        foreach (var el in BDFecade.bd.cms_modufilesArchivoNuevoId())
                            lastId = Convert.ToInt32(el);

                        //	Genera el hash
                        string hashFileName = Enc.GetSHA1(lastId.ToString());

                        string[] fileNameParts = postedFile.FileName.Split('.');
                        fileName = hashFileName + "." + fileNameParts[fileNameParts.Length - 1];

                        var filePath = HttpContext.Current.Server.MapPath("~/storage/" + fileName);

                        BDFecade.bd.cms_modufilesArchivoNuevo(fileName);

                        postedFile.SaveAs(filePath);

                        docfiles.Add(filePath);
                    }

                    return Request.CreateResponse(HttpStatusCode.Created, new ImagesControllerResponse() { fileName = fileName });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }

    class ImagesControllerResponse
    {
        public string fileName { get; set; }
    }
}