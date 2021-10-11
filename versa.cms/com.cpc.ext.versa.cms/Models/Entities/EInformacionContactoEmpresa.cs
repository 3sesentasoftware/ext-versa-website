using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    public class EInformacionContactoEmpresa : IEntitiesActualizar, IEntitiesObtener
    {
        public int id { get; set; }

        public string telefonoContacto { get; set; }

        public string direccionFisica { get; set; }

        public void actualizar(IEntitiesActualizar el)
        {
            EInformacionContactoEmpresa obj = (EInformacionContactoEmpresa)el;

            BDFecade.db().cms_informacionContactoEmpresaActualizar(obj.telefonoContacto, obj.direccionFisica);
        }

        public T obt<T>()
        {
            EInformacionContactoEmpresa resultado = new EInformacionContactoEmpresa();

            List<cms_informacionContactoEmpresaObtener_Result> dbres = BDFecade.db().cms_informacionContactoEmpresaObtener().ToList();
            if (dbres.Count > 0)
            {
                foreach (var el in dbres)
                {
                    resultado.id = el.id;
                    resultado.telefonoContacto = el.telefono_contacto;
                    resultado.direccionFisica = el.direccion_fisica;
                }
                return (T)Convert.ChangeType(resultado, typeof(T));
            }
            else
            {
                resultado.id = -1;
                return (T)Convert.ChangeType(resultado, typeof(T));
            }
        }
    }
}