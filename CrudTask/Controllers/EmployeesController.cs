using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CrudTask.Models;
namespace CrudTask.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        TaskEntities db = new TaskEntities();
        public ActionResult GetEmployees()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult createEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createEmp(Employee emp)
        {
            if (emp == null)
                return RedirectToAction("GetEmployees");
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("GetEmployees");

        }
        [HttpGet]
        public ActionResult EditEmp(int id)
        {
            var EmpObject = db.Employees.Where(x=>x.id == id).FirstOrDefault(); 
             return View(EmpObject);

        }
        [HttpPost]
        public ActionResult EditEmp(int id, Employee emp)
        {
            var EmpObject = db.Employees.Where(x=>x.id == id).FirstOrDefault();
            EmpObject.name = emp.name;
            EmpObject.phone = emp.phone;
            db.SaveChanges();
            return RedirectToAction("GetEmployees");


        }
        public ActionResult Delete(int id)
        {
            var EmpObject = db.Employees.Where(x => x.id == id).FirstOrDefault();
            db.Employees.Remove(EmpObject);
            db.SaveChanges();
            return RedirectToAction("GetEmployees");


        }

        public ActionResult Details(int id)
        {
            var emp = db.Employees.Where(x => x.id == id).FirstOrDefault();
            
            return View(emp);


        }


    }
}