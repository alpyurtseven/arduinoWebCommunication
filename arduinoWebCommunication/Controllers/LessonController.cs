using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Models;

namespace arduinoWebCommunication.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public List<Lesson> Index()
        {
            using (Context cn = new Context())
            {
                var lessons = cn.Lessons.ToList();
                return lessons;
            }
        }

        // GET: Lesson/Details/5
        public Lesson Details(int id)
        {
            using (Context cn = new Context())
            {
                return cn.Lessons.Single(x => x.LessonId == id); ;
            }
        }

        // GET: Lesson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lesson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lesson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lesson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Lesson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lesson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
