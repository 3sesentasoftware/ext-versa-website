using com.cpc.ext.versa.cms.Models.EntityFramework;

namespace com.carzapc.core.web
{
	public class BDFecade
	{
		// public static CMSVersaV2Entities db = new CMSVersaV2Entities();
        public static CMSVersaV3Entities db()
        {
            return new CMSVersaV3Entities();
        }
	}
}