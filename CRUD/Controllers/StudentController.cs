using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Context;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        //db_crudEntities dbObj = new db_crudEntities();
        db_crudEntities2 dbObj2 = new db_crudEntities2();
        public ActionResult Student(tbl_student2 obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
           
        }
        [HttpPost]
        public ActionResult AddStudent(tbl_student2 model2)
        {
            
            if (ModelState.IsValid)
            {
                tbl_student2 obj2 = new tbl_student2();
                obj2.ID = model2.ID;
                obj2.Name = model2.Name;
                obj2.Fname = model2.Fname;
                obj2.Email = model2.Email;
                obj2.Mobile = model2.Mobile;
                obj2.Description = model2.Description;

                if (model2.ID == 0)
                {
                    dbObj2.tbl_student2.Add(obj2);
                    dbObj2.SaveChanges();
                }
                else
                {
                    dbObj2.Entry(obj2).State = EntityState.Modified;
                    dbObj2.SaveChanges();
                }

                
            }
            ModelState.Clear();

            return View("Student");
        }

        public ActionResult StudentList()
        {
            var result = dbObj2.tbl_student2.ToList();
            return View(result);
        }
        public ActionResult Delete(int id)
        {
            var result = dbObj2.tbl_student2.Where(x => x.ID == id).First();

            dbObj2.tbl_student2.Remove(result);
            dbObj2.SaveChanges();

            var list = dbObj2.tbl_student2.ToList();
            return View("StudentList",list);
        }

        

    }
}