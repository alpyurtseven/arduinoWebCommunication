using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace arduinoWebCommunication.Controllers
{
    public class ExamController : ApiController
    {
        // GET: Exam
        public List<Exam> Get()
        {
            using (Context cn = new Context())
            {
                var exams = cn.Exams.Include("Lesson").ToList();
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
           /* using (Context cn = new Context())
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
            }*/
        }
    }
}
