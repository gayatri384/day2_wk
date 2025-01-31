using day2_wk.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2_wk.Controllers
{
    public class StudentController : Controller
    {
        Student objStudent=new Student();
        public IActionResult Index()
        {
            objStudent=new Student();
            List<Student> lst = objStudent.getData("");
            return View(lst);
        }
        public IActionResult AddStu()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddStu(Student emp)
        {
            bool res;
            if (ModelState.IsValid)
            { 
                res=objStudent.insert(emp);
                if (res)
                {
                    TempData["msg"] = "Add successfully";
                }
                else
                {
                    TempData["msg"] = "Not Add successfully";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditStu(string id)
        { 
            List<Student> emp=objStudent.getData(id);
            return View(emp.FirstOrDefault());
        }
        [HttpPost]
        public IActionResult EditStu(Student emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.update(emp);
                if (res)
                {
                    TempData["msg"] = "Edit successfully";
                }
                else
                {
                    TempData["msg"] = "Not Edit successfully";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteStu(string id)
        { 
            List<Student> emp=objStudent.getData(id);
            return View(emp.FirstOrDefault());
        }
        

        [HttpPost]
        public IActionResult DeleteStu(Student emp)
        {
            bool res;
            if (ModelState.IsValid)
            {
                res = objStudent.delete(emp);
                if (res)
                {
                    TempData["msg"] = "Delete successfully";
                }
                else
                {
                    TempData["msg"] = "Not Delete successfully";
                }
            }
            return View();
        }
    }
}
