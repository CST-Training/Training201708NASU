using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewData["Message"] = "Good Morning!";
            Models.Class1 model = new Models.Class1();
            model.Message = "モデルでのメッセージ";
            return View(model);

            //return View();
        }
    }
}