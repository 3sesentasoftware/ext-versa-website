using System;

namespace com.cpc.ext.versa.cms.Models.Entities
{
    public class ConvertEntities
    {
        public static T convertTo<T>(IEntities entity)
        {
            return (T)Convert.ChangeType(entity, typeof(T));
        }

        //public static T convertTo<T>(IEntitiesActualizar entity)
        //{
        //    return (T)Convert.ChangeType(entity, typeof(T));
        //}

        //public static T convertTo<T>(IEntitiesObtener entity)
        //{
        //    return (T)Convert.ChangeType(entity, typeof(T));
        //}
    }

}