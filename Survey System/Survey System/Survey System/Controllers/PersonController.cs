﻿using Survey_System.Models;
using Survey_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey_System.Controllers
{
    public class PersonController : BaseController
    {
        //hemen alttaki kodun olmamasi gerekli sor
        SurveyEntities db = new SurveyEntities();
        public ActionResult Index()
        {
            var model = db.Person.ToList();
            ViewBag.personCount = db.Person.Count();
            return View(model);
        }
        public ActionResult Create(Person person)
        {
            if(person.NameSurname != null)
                {
                person.CreateDate = DateTime.Now;
                person.CreateBy = NameSurname;
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

           
        }
        public ActionResult Edit(int? Id)
        {
            if(Id==null || Id==0){
                return HttpNotFound();
            }
            var model = db.Person.Find(Id);
            return View(model);
       }
       
        [HttpPost]
        public ActionResult Edit(Person person)
        {

            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.Entry(person).Property(e => e.CreateBy).IsModified = false;
            db.Entry(person).Property(e => e.CreateDate).IsModified = false;
            person.ModifyBy = NameSurname;
            person.ModifyDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return HttpNotFound();
            }
            var person = db.Person.Find(Id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}