using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
using System.Data;  
using System.Data.SqlClient;  
using crude.net.Models; 

namespace crude.net.Controllers
{
    public class CRUDController : Controller
    {
        /// <summary>  
        /// First Action method called when page loads  
        /// Fetch all the rows from DB and display it  
        /// </summary>  
        /// <returns>Home View</returns>  
        public ActionResult Index()
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.GetAllStudents();
            return View("Home", dt);
        }

        /// <summary>  
        /// Action method, called when the "Add New Record" link clicked  
        /// </summary>  
        /// <returns>Create View</returns>  
        public ActionResult Insert()
        {
            return View("Create");
        }

        /// <summary>  
        /// Action method, called when the user hit "Submit" button  
        /// </summary>  
        /// <param name="frm">Form Collection  Object</param>  
        /// <param name="action">Used to differentiate between "submit" and "cancel"</param>  
        /// <returns></returns>  
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string name = frm["txtName"];
                int age = Convert.ToInt32(frm["txtAge"]);
                string gender = frm["gender"];
                int status = model.InsertStudent(name, gender, age);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>  
        /// Action method called when the user click "Edit" Link  
        /// </summary>  
        /// <param name="StudentID">Student ID</param>  
        /// <returns>Edit View</returns>  
        public ActionResult Edit(int StudentID)
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.GetStudentByID(StudentID);
            return View("Edit", dt);
        }

        /// <summary>  
        /// Actin method, called when user update the record or cancel the update.  
        /// </summary>  
        /// <param name="frm">Form Collection</param>  
        /// <param name="action">Denotes the action</param>  
        /// <returns>Home view</returns>  
        public ActionResult UpdateRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string name = frm["txtName"];
                int age = Convert.ToInt32(frm["txtAge"]);
                string gender = frm["gender"];
                int id = Convert.ToInt32(frm["hdnID"]);
                int status = model.UpdateStudent(id, name, gender, age);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>  
        /// Action method called when the "Delete" link clicked  
        /// </summary>  
        /// <param name="StudentID">Stutend ID to edit</param>  
        /// <returns>Home view</returns>  
        public ActionResult Delete(int StudentID)
        {
            CRUDModel model = new CRUDModel();
            model.DeleteStudent(StudentID);
            return RedirectToAction("Index");
        }
    }
}