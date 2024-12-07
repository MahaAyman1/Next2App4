using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Next2App4.Data;
using Next2App4.Models;
using Next2App4.Models.DataModel;

namespace Next2App4.Controllers
{
    public class EmployeesController : Controller
    {
        private Next2DbContext db;
        public EmployeesController(Next2DbContext _db) { db = _db; }
        public IActionResult Index()
        {
            EmpCourseDataModel model = new EmpCourseDataModel
            {
                Employees = db.Employees.Include(x=>x.Department).ToList(),
                Courses = db.courses.ToList(),
            };
            ViewBag.st = db.Students;
            return View(model);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var data = db.Employees.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");

            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Delete(int ?id)
        {
            if (id ==null)
            {
                return RedirectToAction("Index");
            }
            var data = db.Employees.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");

            }

            return View(data);
        }

        [HttpPost]

        public IActionResult Delete(Employee e , int EmployeeID)
        {
          
            var data = db.Employees.Find(EmployeeID);
            if (data == null)
            {
                return RedirectToAction( nameof(Index));

            }

            db.Employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var data = db.Employees.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }

        /* [HttpPost]
         public ActionResult Edit(Employee e) {
             if (e.EmployeeID == null)
             {
                 return RedirectToAction("Index");   
             }

             var data = db.Employees.Find( e.EmployeeID);

             if (data == null) {

                 return RedirectToAction("Index");

             }

             data.Email = e.Email;
             data.Name = e.Name;
             data.city = e.city;
             data.HDate = e.HDate;
             data.salary = e.salary;
             db.Employees.Update(data);  
             db.SaveChanges();   
             return RedirectToAction("Index");
         }*/
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Update(e);
                db.SaveChanges(); //Commit
                return RedirectToAction("Index");
            }
            return View(e);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee e) {
           if (ModelState.IsValid)
            {
                db.Employees.Add(e);
                db.SaveChanges(); 
                //Commit
                return RedirectToAction("Index");
            }
            return View(e);
        }
    }
}