using Create_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Create_Exam.Controllers
{
    public class ExamController : Controller
    {
        OnlineExaminationDBEntities db = new OnlineExaminationDBEntities();
        // GET: Exam
        
        public ActionResult CreateExam()
        {
            List<Question> allQuestions = new List<Question>()
            {
                new Question{ID=1, Text="Question 1", IsSingleAnswer=true},
                new Question{ID=2, Text="Question 2", IsSingleAnswer=false},
                new Question{ID=3, Text="Question 3", IsSingleAnswer=true},
                new Question{ID=4, Text="Question 4", IsSingleAnswer=true},
                new Question{ID=5, Text="Question 5", IsSingleAnswer=false},
                new Question{ID=6, Text="Question 6", IsSingleAnswer=true},
                new Question{ID=7, Text="Question 7", IsSingleAnswer=true},
                new Question{ID=8, Text="Question 8", IsSingleAnswer=false},
                new Question{ID=9, Text="Question 9", IsSingleAnswer=true}
            };
            return View(allQuestions);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var Questions = db.Questions.ToList();
            ViewBag.questions = Questions;
            return View(ViewBag.questions);
        }
        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            string[] EAns = exam.examAnswers.Split(',');
            foreach (var item in EAns)
            {
                exam.ExamAnswers.Add(new ExamAnswer { ExamID = exam.ID,AnswerID =Convert.ToInt32(item)});
            }
            db.Exams.Add(exam);
            db.SaveChanges();
            return View();
        }

       


    }

}