using Survey_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
       SurveyEntities db = new  SurveyEntities();
        public ActionResult SignIn(string Code, string Password)
        {
            if (Code == null)
            {
                return View();
            }
            else
            {
                //var person = db.Person.FirstOrDefault(m => m.Code == Code && m.Password == Password);
                if(Code == "182523313" && Password == "123")
                {
                    var admin = db.Person.FirstOrDefault(m => m.Code == Code && m.Password == Password);
                    if (admin != null)
                    {
                        Session["Code"] = admin.Code;
                        Session["NameSurname"] = admin.NameSurname;
                        return RedirectToAction("Index", "Person");
                    }
                }

                else
                {
                    ViewBag.Error = "! Kullanici Adı veya Şifre Hatali";
                    return View();
                }
            }
            return View();
        
        }
        public ActionResult SignIn2(string Code, string Password)
        {
            if (Code == null)
            {
                return View();
            }
            else
            {
                var person = db.Person.FirstOrDefault(m => m.Code == Code && m.Password == Password);
                if (person != null)
                {
                    Session["Code"] = person.Code;
                    Session["NameSurname"] = person.NameSurname;
                    return RedirectToAction("Create", "Answer");
                }
                else
                {
                    ViewBag.Error = "! Kullanici Adı veya Şifre Hatali";
                    return View();
                }
            }


        }
        public ActionResult SignOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}