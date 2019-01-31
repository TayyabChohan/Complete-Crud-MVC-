using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouCrud.Models;

namespace YouCrud.Controllers
{
    public class HomeController : Controller
    {
        StudentInfoEntities db = new StudentInfoEntities();
        public ActionResult Index()
        {
            var list = db.EmployeeInfoes.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
     
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeInfo tb)
        {
            db.EmployeeInfoes.Add(tb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

           EmployeeInfo emp =db.EmployeeInfoes.Find(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit( EmployeeInfo emp , int id)
        {
            EmployeeInfo employeeInfo = db.EmployeeInfoes.SingleOrDefault(m => m.EmpoyeeID == id);
            employeeInfo.EmpoyeeID = emp.EmpoyeeID;
            employeeInfo.Name = emp.Name;
            employeeInfo.Contact = emp.Contact;
            employeeInfo.About = emp.About;
            employeeInfo.Gender = emp.Gender;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }

            return View(employeeInfo);
        }
        public ActionResult Delete(int id)
        {
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            db.EmployeeInfoes.Remove(employeeInfo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}