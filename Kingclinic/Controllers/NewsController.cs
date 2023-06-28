using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kingclinic.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexESWT()
        { 
            return View();
        }
        public ActionResult IndexOT()
        {
            return View();
        }
        public ActionResult IndexOSP()
        {
            return View();
        }
        public ActionResult IndexPRP()
        {
            return View();
        }
        public ActionResult IndexHA()
        {
            return View();
        }
    }
}