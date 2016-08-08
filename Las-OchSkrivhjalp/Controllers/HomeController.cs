using Las_OchSkrivhjalp.Models;
using Las_OchSkrivhjalp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Las_OchSkrivhjalp.Controllers {
	public class HomeController : Controller {
		private QuestionRepo repo = new QuestionRepo();

		private TOut[] GetRandomUniqueElementList<TIn, TOut> (List<TIn> source, int length, Func<TIn, TOut> selector){
			if (source.Count() < length) return null;

			TOut[] r = new TOut[length];
			int filled = 0;
			bool unique;
			var rand = new Random();
			while (filled < length) {
				var q = source[rand.Next(0, source.Count())];
				unique = true;
				for (int i = 0; i < filled; i++) if (r[i].Equals(selector(q))) {
					unique = false;
					break;
				}
				if (unique) {
					r[filled] = selector(q);
					filled++;
				}
			}
			return r;
		}

		public ActionResult Index() {
			return View();
		}

		public JsonResult GetQuestions(int cat) {
			var c = repo.GetCategory(cat);
			if (c == null) return null;
			var rList = GetRandomUniqueElementList(c.Questions.ToList(), 2, (q => q.ID));
			return Json(new {Questions = rList}, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetCategories() {
			return Json(new { Categories = repo.GetAllCategories().Select(c => new { Name = c.Name, ID = c.ID}) }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetMixedQuestions() {
			var qs = repo.GetAllQuestions().ToList();
			var rList = GetRandomUniqueElementList(qs, 15, (q => q.ID ));
			return Json(new { Questions = rList }, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Question(int id) {
			return Json(repo.GetQuestion(id), JsonRequestBehavior.AllowGet);
		}

		public ActionResult About() {
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact() {
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}