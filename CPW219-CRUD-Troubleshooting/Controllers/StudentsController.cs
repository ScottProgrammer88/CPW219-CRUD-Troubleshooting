using CPW219_CRUD_Troubleshooting.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219_CRUD_Troubleshooting.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext context;

        public StudentsController(SchoolContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Student> students = await StudentDb.GetStudents(context);
            // check if null

            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student p)
        {
            if (ModelState.IsValid)
            {
                await StudentDb.Add(p, context);
                TempData["Message"] = $"{p.Name} was successfully added!";
                return RedirectToAction("Index");
            }

            //Show web page with errors
            return View(p);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //get the student by id
            Student p = StudentDb.GetStudent(context, id);

            //show it on web page
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student p)
        {
            if (ModelState.IsValid)
            {
                await StudentDb.Update(context, p);
                TempData["Message"] = "Student Updated!";
                return RedirectToAction("Index");
            }
            //return view with errors
            return View(p);
        }

        [HttpGet]
        public  async Task<IActionResult> Delete(int id)
        {
            Student p = StudentDb.GetStudent(context, id);
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //Get Product from database
            Student p = StudentDb.GetStudent(context, id);

            await StudentDb.Delete(context, p);

            //Show message
            TempData["Message"] = $"{p.Name} was deleted!";

            return RedirectToAction("Index");
        }
    }
}
