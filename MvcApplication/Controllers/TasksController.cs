using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            Task task = new Task(1, "test1", new DateTime(2016, 07, 12));
            return View(task);
        }
        [System.Web.Mvc.HttpPost]
        public int Create([FromBody]Task task)
        {
            if (ModelState.IsValid)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}