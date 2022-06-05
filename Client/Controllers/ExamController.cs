using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
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
                model = response.StatusCode == System.Net.HttpStatusCode.OK ? 
                    JsonConvert.DeserializeObject<List<Exam>>(response.Content.ReadAsStringAsync().Result) : 
                    new List<Exam>();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Detail(int id)
        {
            using (HttpClient cl = new HttpClient())
            {
                var response = await cl.GetAsync("https://localhost:44314/api/exam/" + id);
                Exam model;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    model = JsonConvert.DeserializeObject<Exam>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    model = new Exam();
                }

                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            using (HttpClient cl = new HttpClient())
            {
                var response = await cl.GetAsync("https://localhost:44314/api/exam/"+id);
                Exam model;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    model = JsonConvert.DeserializeObject<Exam>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    model = new Exam();
                }

                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            //using (HttpClient cl = new HttpClient())
            //{
            //    var response = await cl.GetAsync("https://localhost:44314/api/exam/"+id);
            //    Exam model;
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        model = JsonConvert.DeserializeObject <Exam>(response.Content.ReadAsStringAsync().Result);
            //    }
            //    else
            //    {
            //        model = new Exam();
            //    }

            //    return View(model);
            //}
            return View(new Exam());
        }

        [HttpGet]
        public async Task<ActionResult> App(int id)
        {
            //using (HttpClient cl = new HttpClient())
            //{
            //    var response = await cl.GetAsync("https://localhost:44314/api/exam/"+id);
            //    Exam model;
            //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //    {
            //        model = JsonConvert.DeserializeObject <Exam>(response.Content.ReadAsStringAsync().Result);
            //    }
            //    else
            //    {
            //        model = new Exam();
            //    }

            //    return View(model);
            //}
            return View(new Exam());
        }
    }
}