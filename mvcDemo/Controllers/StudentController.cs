using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcDemo.Controllers
{
    public class StudentController : Controller
    {
        StudentDal studentDal = new StudentDal();
        // GET: Student
        public ActionResult Index()
        {
            var Allstudents = studentDal.GetAllStudent();
            return View(Allstudents);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentModel studentModel)
        {
            var id = studentDal.CreateStutent(studentModel);
            if(id==0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

           
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var studentModel = studentDal.GetStudent(Id);
            return View(studentModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel studentModel)
        {
            var stu1 = studentDal.UpdateStutent(studentModel);
            return RedirectToAction("Index");
            
        }

    }
}