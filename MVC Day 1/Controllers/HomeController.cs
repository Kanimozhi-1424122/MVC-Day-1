using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Day_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";

            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        [Route("searchbyidandname/{empid}/{name}")]
        public ActionResult edit(int empid, string name)
        {
           if(empid>0)
            {
                return Content("id:"+empid+" "+"name:"+name);
            }
           else
             {
                return Content("no result");
            }
        }
    }
}