using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PzojectClassWordFriday.Models;

namespace PzojectClassWordFriday.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        public ActionResult Index()
        {
            Student student = new Student(){StudentName =  "Someone"};
            return View(student);
        }
	}
}