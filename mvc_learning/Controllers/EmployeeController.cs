using mvc_learning.Data;
using mvc_learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_learning.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly ApplicationDbContext context;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        public ViewResult Index()
        {
            var EmployeeList = context.Employees.ToList();
            return View(EmployeeList);
        }
        public ViewResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(Employee employee)
        {
            if (employee == null) return HttpNotFound();
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var employeeInDb = context.Employees.Find(id);
            if (employeeInDb == null) return HttpNotFound();
            return View(employeeInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (employee == null) return HttpNotFound();
            var employeefromdb = context.Employees.Find(employee.ID);
            if (employeefromdb == null) return HttpNotFound();
            employeefromdb.Name = employee.Name;
            employeefromdb.Address = employee.Address;
            employeefromdb.Age = employee.Age;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int ID)
        {
            var employeeindb = context.Employees.Find(ID);
            if (employeeindb == null) { return HttpNotFound(); }
            return View(employeeindb);
        }
        public ActionResult delete(int ID)
        {
            var employeeindb = context.Employees.Find(ID);
            if (employeeindb == null) { return HttpNotFound(); }
            return View(employeeindb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult delete(Employee employee)
        {
            if(employee == null) { return HttpNotFound();  }
            var employeeindb = context.Employees.Find(employee.ID);
            if (employeeindb == null) { return HttpNotFound();  }
            context.Employees.Remove(employeeindb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult delete_new(int ID)
        {
            var employeeInDb = context.Employees.Find(ID);
            if(employeeInDb == null) { return HttpNotFound();  }
            context.Employees.Remove(employeeInDb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}