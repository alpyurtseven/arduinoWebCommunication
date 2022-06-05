using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Data.Models;

namespace arduinoWebCommunication.Controllers
{
    [EnableCors(origins: "https://localhost:44315", headers: "*", methods: "*")]
    public class LessonsController : ApiController
    {
        private Context db = new Context();
        
        // GET: api/Lessons
        public IQueryable<Lesson> GetLessons()
        {
            return db.Lessons.Include(z=>z.Users);
        }

        // GET: api/Lessons/5
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult GetLesson(int id)
        {
            Lesson lesson;

            try
            {
                lesson = db.Lessons.Include(z => z.Users).Include(z => z.Exams).First(z => z.LessonId == id);
            }
            catch (Exception e)
            {
                lesson = null;
            }
            
            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }

        // PUT: api/Lessons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLesson(int id, Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lesson.LessonId)
            {
                return BadRequest();
            }

            db.Entry(lesson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Lessons
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult PostLesson(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lessons.Add(lesson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lesson.LessonId }, lesson);
        }

        // DELETE: api/Lessons/5
        [ResponseType(typeof(Lesson))]
        public IHttpActionResult DeleteLesson(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }

            db.Lessons.Remove(lesson);
            db.SaveChanges();

            return Ok(lesson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonExists(int id)
        {
            return db.Lessons.Count(e => e.LessonId == id) > 0;
        }
    }
}