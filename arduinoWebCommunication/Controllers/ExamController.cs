﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace arduinoWebCommunication.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        public List<Exam> Index()
        {
            using (Context cn = new Context())
            {
                var exams = cn.Exams.ToList();
                return exams;
            }
        }

        // GET: Exam/Details/5
        public Exam Details(int id)
        {
            using (Context cn = new Context())
            {
                return cn.Exams.Single(x => x.ExamId == id); ;
            }
        }

        // GET: Exam/Create
        public void Create(Exam exam)
        {
            using (Context cn = new Context())
            {

                p.Tmt = p.Stock * p.Mt;
                if (p.CategoryId == 6)
                {
                    p.mt2 = (p.Width / 1000 * p.Height / 1000);
                    p.Tmt = p.mt2 * p.Stock;

                }
                p.Kg = p.Mkg * p.Tmt;
                p.mt2 = p.Height * p.Width;
                cn.Products.Add(p);
                cn.SaveChanges();
            }
        }

        // POST: Exam/Create
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

        // GET: Exam/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Exam/Edit/5
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

        // GET: Exam/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Exam/Delete/5
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
