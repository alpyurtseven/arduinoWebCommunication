using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace arduinoWebCommunication.Controllers
{
    public class UserController : ApiController
    {
        // GET: User
        public List<User> Get()
        {
            using (Context cn = new Context())
            {
                var users = cn.Users.ToList();
                return users;
            }
        }

        // GET: User/Details/5
        [System.Web.Http.HttpGet]
        public string Get(int id)
        {
            using (Context cn = new Context())
            {
               var user =  cn.Users.Single(x => x.UserId == id);
                return user.Name;
            }
        }
    }
}
