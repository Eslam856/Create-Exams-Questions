using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Create_Exam.Models;

namespace Create_Exam.Controllers
{
    public class QuestionController : Controller
    {
        OnlineExaminationDBEntities db = new OnlineExaminationDBEntities();
        [HttpGet]
        // GET: Question
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateQuestion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateQuestion(Question q)
        {
            string[] ans = q.AnswerText.Split('|');
            foreach (var item in ans)
            {
                q.Answers.Add(new Answer { Text = item.Replace("#", ""),IsTrueAnswer=item.Trim().StartsWith("#")});
            }
            db.Questions.Add(q);
            db.SaveChanges();
            return RedirectToAction("Index","Exam");
        }

        public ActionResult Details(int id)
        {
            var question = db.Questions.SingleOrDefault(q => q.ID == id);

            return View(question);
        }

        public ActionResult AllQuestions()
        {
            List<Question> Questions = db.Questions.ToList();
            return View(Questions);
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            var question = db.Questions.SingleOrDefault(q => q.ID == id);
            return View(question);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Question question)
        {

            try
            {

                db.Questions.Remove(question);

                return RedirectToAction("Question", "AllQuestions");
            }
            catch (Exception)
            {

                return View();
            }

        }



    }

}