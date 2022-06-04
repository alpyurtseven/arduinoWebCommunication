using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Data.Models;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        public async Task<ActionResult> Index()
        {
            var model = new List<Lesson>();
            if (ModelState.IsValid)
            {
                using (Data.Models.Context cn = new Data.Models.Context())
                {
                    using (HttpClient cl = new HttpClient())
                    {
                        var response = await cl.GetAsync("https://localhost:44314/api/lessons/");

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        { 
                            model = JsonConvert.DeserializeObject<List<Lesson>>(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }


            return PartialView(model);
        }
        public async Task<ActionResult> Detail(int id)
        {
            var model = new Lesson();
            if (ModelState.IsValid)
            {
                using (Data.Models.Context cn = new Data.Models.Context())
                {
                    using (HttpClient cl = new HttpClient())
                    {
                        var response = await cl.GetAsync("https://localhost:44314/api/lessons/"+id);

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            model = JsonConvert.DeserializeObject<Lesson>(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }


            return View(model);
        }
    }
}