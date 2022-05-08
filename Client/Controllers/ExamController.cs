﻿using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Client.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        public async Task<ActionResult> Index()
        {
            using (HttpClient cl = new HttpClient())
            {
                var response = await cl.GetAsync("https://localhost:44314/api/exam");
                List<Exam> model;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    model = JsonConvert.DeserializeObject<List<Exam>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    model = new List<Exam>();
                }

                return View(model);
            }
        }
    }
}