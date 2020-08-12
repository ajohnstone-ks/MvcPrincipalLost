using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcPrincipalLost.Business;

namespace MvcApp.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			Login();

			var businessObject = await BusinessObject.Get(Guid.NewGuid());
			businessObject.Name = "Name";
			businessObject = await businessObject.SaveAsync();

			return View(businessObject);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		private void Login()
		{
			Csla.ApplicationContext.User = new CustomPrincipal();
		}
	}
}