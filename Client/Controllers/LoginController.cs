﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using Data.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;


namespace Client.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

       // POST: Login
         [HttpPost]
         public async Task<JsonResult> Index(User user)
        {
            if (ModelState.IsValid)
            {
                using (Data.Models.Context cn = new Data.Models.Context())
                {
                    using (HttpClient cl = new HttpClient())
                    {
                        var response = await cl.GetAsync("https://localhost:44314/api/user/");

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var model = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
                            var loggedInUser = model.Where(a => a.UserNumber.Equals(user.UserNumber) && a.Password.Equals(user.Password)).FirstOrDefault();

                            if (loggedInUser != null)
                            {
                                FormsAuthentication.SetAuthCookie(loggedInUser.Name, false);

                                Session["UserType"] = loggedInUser.Name;

                                return Json(new { redirectToUrl = Url.Action("Index", "Home"), userRole = loggedInUser.Role , userNumber = loggedInUser.UserId , userName = loggedInUser.Name, userSurname = loggedInUser.Surname});
                            }
                        }
                    }
                }
            }

            return Json(new { redirectToUrl = Url.Action("Index", "Login") });
        }
    }
}