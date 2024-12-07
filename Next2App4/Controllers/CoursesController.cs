using Microsoft.AspNetCore.Mvc;
using Next2App4.Data;
using Next2App4.Models;

namespace Next2App4.Controllers
{
    public class CoursesController : Controller
    {

        private Next2DbContext db;
        public CoursesController(Next2DbContext _db) { db = _db; }


        public IActionResult Index()
        {
            return View(db.courses);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course c)
        {
            if (ModelState.IsValid)
            {
                db.courses.Add(c);
                db.SaveChanges();
                //Commit
                return RedirectToAction("Index" , "Employees");
            }
            return View(c);
        }

        [HttpGet]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = db.courses.Find(id);
            if (data == null)
            {
                return NotFound();

            }

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(Course e)
        {

            var data = db.courses.Find(e.CourseID );
            if (data == null)
            {
                return RedirectToAction("Index", "Employees");

            }

            db.courses.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }


        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Employees");
            }
            var data = db.courses.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index", "Employees");

            }
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Employees");
            }
            var data = db.courses.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            return View(data);
        }

     
           
        [HttpPost]
        public ActionResult Edit(Course e)
        {
            if (ModelState.IsValid)
            {
                db.courses.Update(e);
                db.SaveChanges(); //Commit
                return RedirectToAction("Index", "Employees");
            }
            return View(e);
        }
    }
}
