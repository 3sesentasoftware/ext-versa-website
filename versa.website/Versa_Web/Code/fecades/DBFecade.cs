using Versa_Web.Models.EntityFramework;

namespace Versa_Web.Code.fecades
{
	public class DBFecade
	{
		// public static WebVersaV2Entities db = new WebVersaV2Entities();

        public static WebVersaV3Entities dbObj()
        {
            return new WebVersaV3Entities();
        }
	}
}