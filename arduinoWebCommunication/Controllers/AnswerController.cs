using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace arduinoWebCommunication.Controllers
{
    public class AnswerController : ApiController
    {
        // POST: api/Answer
        Context db = new Context();
        public IHttpActionResult Post(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();
            return Ok();
        }

        public Answer Get(int id)
        {
            return db.Answers.Include(z => z.User).First(z => z.AnswerId == id);
        }
    }
}
