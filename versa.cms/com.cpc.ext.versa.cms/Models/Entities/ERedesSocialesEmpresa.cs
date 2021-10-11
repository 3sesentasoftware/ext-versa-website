using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    public class ERedesSocialesEmpresa : IEntities, IEntitiesActualizar, IEntitiesObtener
    {
        public int id { get; set; }

        public string urlFacebook { get; set; }

        public string urlYoutube { get; set; }

        public ERedesSocialesEmpresa() { }

        public ERedesSocialesEmpresa(cms_redesSocialesEmpresaObtener_Result el)
        {
            this.id = el.id;
            this.urlFacebook = el.url_facebook;
            this.urlYoutube = el.url_youtube;
        }

        public void actualizar(IEntitiesActualizar el)
        {
            ERedesSocialesEmpresa obj = ConvertEntities.convertTo<ERedesSocialesEmpresa>(el);

            BDFecade.db().cms_redesSocialesEmpresaActualizar(obj.urlFacebook, obj.urlYoutube);
        }

        public T obt<T>()
        {
            List<cms_redesSocialesEmpresaObtener_Result> dbres = BDFecade.db().cms_redesSocialesEmpresaObtener().ToList();
            IEntitiesObtener resultado = null;
            if (dbres.Count > 0)
            {
                dbres.ForEach(
                    e => {
                        resultado = new ERedesSocialesEmpresa(e);
                    }
                );
            }
            else
            {
                resultado = new ERedesSocialesEmpresa() { id = -1 };
            }
            return ConvertEntities.convertTo<T>(resultado);
        }
    }
}