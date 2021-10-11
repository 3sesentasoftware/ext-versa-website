using System;
using System.Web.Mvc;

namespace com.carzapc.core.web
{
	public class SysSession
	{
		private const string USER_ID = "USER_ID";

		public static void openSession(Controller context, Object idValue)
		{
			if (IsSessionOpen(context))
				throw new SessionAlreadyOpenException();
			else
			{
				context.Session[USER_ID] = idValue;
			}
		}

		public static void closeSession(Controller context)
		{
			context.Session[USER_ID] = null;
			context.Session.Clear();
		}

		public static T getIdValue<T>(Controller context)
		{
			return (T)context.Session[USER_ID];
		}

		public static bool IsSessionOpen(Controller context)
		{
			return context.Session[USER_ID] != null;
		}

		public static bool IsSessionClose(Controller context)
		{
			return context.Session[USER_ID] == null;
		}

		public static bool IsSessionOpenBy(Controller context, Object idValue)
		{
			return context.Session[USER_ID].Equals(idValue);
		}
	}

	public class SessionAlreadyOpenException : Exception
	{
		public SessionAlreadyOpenException() : base(String.Format("Session is already open"))
		{

		}
	}
}