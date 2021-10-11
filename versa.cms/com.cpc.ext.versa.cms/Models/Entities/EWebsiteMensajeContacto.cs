using com.carzapc.core.web;
using com.cpc.ext.versa.cms.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    public class EWebsiteMensajeContacto : IEntitiesObtenerTodos
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string email { get; set; }

        public string asunto { get; set; }

        public string mensaje { get; set; }

        public DateTime fechaCreacion { get; set; }

        public List<T> obtTodos<T>()
        {
            List<T> resultado = new List<T>();

            foreach (cms_websiteMensajeContactoObtener_Result el in BDFecade.db().cms_websiteMensajeContactoObtener().ToList())
            {
                resultado.Add(ConvertEntities.convertTo<T>(convertir(el)));
            }

            return resultado;
        }

        private EWebsiteMensajeContacto convertir(cms_websiteMensajeContactoObtener_Result el)
        {
            return new EWebsiteMensajeContacto() {
                id = el.id,
                nombre = el.nombre,
                email = el.email,
                asunto = el.asunto,
                mensaje = el.mensaje,
                fechaCreacion = el.fecha_creacion
            };
        }
    }
}