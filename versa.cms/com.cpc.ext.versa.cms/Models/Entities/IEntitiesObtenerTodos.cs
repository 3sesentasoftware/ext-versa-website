using System.Collections.Generic;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    interface IEntitiesObtenerTodos : IEntities
    {
        List<T> obtTodos<T>();
    }
}
