using System.Web;
using System.Web.Mvc;

namespace com.cpc.ext.versa.cms
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
