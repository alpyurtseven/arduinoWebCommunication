using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Data.Models;

namespace arduinoWebCommunication.Controllers
{
    public class ExamController : ApiController
    {
        private Context db = new Context();

        // GET: api/Exam
        public IQueryable<Exam> GetExams()
        {
            return db.Exams.Include(x => x.Lesson);
        }

        // GET: api/Exam/5
        [ResponseType(typeof(Exam))]
        public IHttpActionResult GetExam(int id)
        {
            Exam exam;
            try
            {
                exam = db.Exams.Include(z => z.Lesson).First(x => x.ExamId == id);
            }
            catch (Exception e)
            {
                exam = null;
            }

            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        // PUT: api/Exam/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExam(int id, Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exam.ExamId)
            {
                return BadRequest();
            }

            db.Entry(exam).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exam
        [ResponseType(typeof(Exam))]
        public IHttpActionResult PostExam(Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exams.Add(exam);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exam.ExamId }, exam);
        }

        // DELETE: api/Exam/5
        [ResponseType(typeof(Exam))]
        public IHttpActionResult DeleteExam(int id)
        {
            var exam = db.Exams.Find(id);
            if (exam == null)
            {
                return NotFound();
            }

            exam.Status = false;

            db.SaveChanges();

            return Ok(exam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamExists(int id)
        {
            return db.Exams.Count(e => e.ExamId == id) > 0;
        }
    }
}