using System.Web;
using System.Web.Mvc;

namespace Las_OchSkrivhjalp {
	public class FilterConfig {
		public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}
	}
}
