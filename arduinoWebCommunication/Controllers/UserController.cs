using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace arduinoWebCommunication.Controllers
{
    [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private Context db = new Context();
        public IQueryable<User> Get()
        {
            return db.Users.Include(z=>z.Lessons);
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
