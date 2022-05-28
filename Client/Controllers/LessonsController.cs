using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class LessonsController : Controller
    {
        // GET: Lessons
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lesson(int id)
        {
            return View();
        }
    }
}