namespace com.cpc.ext.versa.cms.Models.Entities
{
    public interface IEntitiesObtener : IEntities
    {
        T obt<T>();
    }
}
