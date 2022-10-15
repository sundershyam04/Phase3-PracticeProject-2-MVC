using SchoolMVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMVC_CRUD.Controllers
{
    public class AdminController : Controller
    {

        School_ManagementEntities scl = null;

        public ActionResult StartPage()
        {
            return View();
        }

        public AdminController()
        {
            scl = new School_ManagementEntities();
        }

        // GET: Admin
        public ActionResult Student()
        {
            List<Student> students = new List<Student>();
            foreach (var item in scl.Students)
            {
                students.Add(item);
            }
           
            return View(students);
        }
        // GET: Admin/CreateStudent
        public ActionResult CreateStudent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(Student s)
        {

            scl.Students.Add(s);
            scl.SaveChanges();
            return RedirectToAction("Student");
           
        }
        // first find obj pertaining to id

        //GET: Admin/EditStudent/2
        public ActionResult EditStudent(int id)
        {
            Student found = scl.Students.ToList().Find(s => s.Student_id == id);
            return View(found);
        }

        [HttpPost]
        public ActionResult EditStudent(int id, FormCollection f)
        {
            try
            {
                Student found = scl.Students.ToList().Find(s => s.Student_id == id);

                found.Student_name = Request.Form["Student_name"];

                found.Age = int.Parse(Request["Age"]);

                found.Blood_group = Request["Blood_group"];

                found.Father_s_Name = Request["Father_s_Name"];

                found.Mother_s_Name = Request["Mother_s_Name"];

                found.Grade = int.Parse(Request["Grade"]);

                found.Subject_Id = int.Parse(Request["Subject_Id"]);

                scl.SaveChanges();

                return RedirectToAction("Student");
            }
            catch(Exception e)
            {
                return View();
            }

        }

        //Showdetails GET : Admin/DetailsStudent
        public ActionResult DetailsStudent(int id)
        {
            try
            {
                Student fnd = scl.Students.ToList().Find(s => s.Student_id == id);


                return View(fnd);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        //Delete

        public ActionResult DeleteStudent(int id)
        {
            try
            {
                Student fnd = scl.Students.ToList().Find(s => s.Student_id == id);
                return View(fnd);
              
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]

        public ActionResult DeleteStudent(int id,Student del)
        {
            try
            {
                Student fnd = scl.Students.ToList().Find(s => s.Student_id == id);
                scl.Students.Remove(fnd);
                scl.SaveChanges();
                return RedirectToAction("Student");

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
        //              -------- CLass table ----------

        public ActionResult Class()
        {
            List<@class> classlist = new List<@class>();
            foreach (var item in scl.classes)
            {
                classlist.Add(item);
            }

            return View(classlist);
        }

        // GET: Admin/CreateClass
        public ActionResult CreateClass()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateClass(@class c)
        {

            scl.classes.Add(c);
            scl.SaveChanges();
            return RedirectToAction("Class");

        }

        // GET: Admin/EditClass/6

        public ActionResult EditClass(int id)
        {
            @class found = scl.classes.ToList().Find(s => s.Grade == id);
            return View(found);
        }

        [HttpPost]
        public ActionResult EditClass(int id, @class c)
        {
            try
            {
                @class found = scl.classes.ToList().Find(s => s.Grade == id);

                scl.classes.Remove(found);

                scl.classes.Add(c);

                scl.SaveChanges();

                return RedirectToAction("Class");
            }
            catch (Exception e)
            {
                return View();
            }

        }

        //Showdetails GET : Admin/DetailsClass
        public ActionResult DetailsClass(int id)
        {
            try
            {
                @class fnd = scl.classes.ToList().Find(s => s.Grade == id);


                return View(fnd);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        //Delete class

        public ActionResult DeleteClass(int id)
        {
            try
            {
                @class fnd = scl.classes.ToList().Find(s => s.Grade== id);
                return View(fnd);

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]

        public ActionResult DeleteClass(int id, Student del)
        {
            try
            {
                @class fnd = scl.classes.ToList().Find(s => s.Grade == id);
                scl.classes.Remove(fnd);
                scl.SaveChanges();
                return RedirectToAction("Class");

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        //              -------- Subject table ----------


        public ActionResult Subject()
        {
            List<Subject> sublist = new List<Subject>();
            foreach (var item in scl.Subjects)
            {
                sublist.Add(item);
            }

            return View(sublist);
        }
        //Create subject 
        public ActionResult CreateSubject()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateSubject(Subject c)
        {

            scl.Subjects.Add(c);
            scl.SaveChanges();
            return RedirectToAction("Subject");

        }

        //Edit subject

        public ActionResult EditSubject(int id)
        {
            Subject found = scl.Subjects.ToList().Find(s => s.Subject_Id == id);
            return View(found);
        }

        [HttpPost]
        public ActionResult EditSubject(int id, Subject s)
        {
            try
            {
                Subject found = scl.Subjects.ToList().Find(p => p.Subject_Id == id);

                scl.Subjects.Remove(found);

                scl.Subjects.Add(s);

                scl.SaveChanges();

                return RedirectToAction("Subject");
            }
            catch (Exception e)
            {
                return Content(e.Message, "Error");
            }

        }

        // Details subject GET only

        public ActionResult DetailsSubject(int id)
        {
            Subject found = scl.Subjects.ToList().Find(p => p.Subject_Id == id);

            return View(found);
        }


        //Delete Subject

        public ActionResult DeleteSubject(int id)
        {
            try
            {
                Subject found = scl.Subjects.ToList().Find(p => p.Subject_Id == id);
                return View(found);

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpPost]

        public ActionResult DeleteSubject(int id, Subject del)
        {
            try
            {
                Subject found = scl.Subjects.ToList().Find(p => p.Subject_Id == id);
                scl.Subjects.Remove(found);
                scl.SaveChanges();
                return RedirectToAction("Subject");

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }


    }
}