using Survey_System.Models;
using Survey_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey_System.Controllers
{

    public class AnswerController : BaseController
    {
        // GET: Answer
        public ActionResult Index()

        {
            return View();
        }
        public ActionResult Create(string Code)

        {
            //hemen alttaki kodun olmamasi gerekli sor
            SurveyEntities db = new SurveyEntities();
            List<SelectListItem> teacherList = (from teacher in db.Teacher
                                               where teacher.Name != Code
                                               select new SelectListItem
                                               {
                                                   Text = teacher.Name,
                                                   Value = teacher.Id.ToString()

                                               }).ToList();
            ViewBag.Teacher = new SelectList(teacherList.OrderBy(m => m.Text), "Value", "Text");

            var questionModel = db.Question.ToList();
            return View(questionModel);
        }

       //hemen alttaki kodun olmamasi gerekli sor
        SurveyEntities db = new SurveyEntities();
        public String SendData(AnswerModel answerModel)


            
        {
            
            var model = db.Answer.FirstOrDefault(m => m.PersonCode == answerModel.Code && m.UserCode == Code);

            if(model != null)
            {
                SaveAnswerLine(answerModel.Question, answerModel.Answer, model.Id);
            }
            else
            {
            Answer answer = new Answer();
            answer.PersonCode = answerModel.Code;
            answer.PersonName = NameSurname;
            answer.UserCode = Code;
            answer.CreateDte = DateTime.Now;
            answer.CreateBy = answerModel.NameSurname ;
            db.Answer.Add(answer);
            db.SaveChanges();
            SaveAnswerLine(answerModel.Question, answerModel.Answer, answer.Id);
            

            }
            return "True";
            
        }
        public void SaveAnswerLine(string question,string answer, int answerId)
        {
            var model = db.AnswerLine.FirstOrDefault(m => m.AnswerId == answerId && m.Question == question);
            if(model != null)
            {
                model.Answer = answer;
                db.SaveChanges();          }
            else
            {
                AnswerLine answerLine = new AnswerLine();
                answerLine.AnswerId = answerId;
                answerLine.Answer = answer;
                answerLine.Question = question;
                db.AnswerLine.Add(answerLine);
                db.SaveChanges();
            }
            
       }

    }
}