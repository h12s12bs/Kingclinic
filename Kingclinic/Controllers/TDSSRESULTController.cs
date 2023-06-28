using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kingclinic.Controllers
{
    public class TDSSRESULTController : Controller
    {
        // GET: TDSSRESULT
        public ActionResult IndexCT()
        {
            return View();
        }
        public ActionResult IndexPT()
        {
            return View();
        }
        public ActionResult IndexAT()
        {
            return View();
        }
        public ActionResult IndexESWT()
        {
            return View();
        }
        public ActionResult IndexHA()
        {
            return View();
        }
        public ActionResult IndexPRP()
        {
            return View();
        }
        public ActionResult IndexSI()
        {
            return View();
        }
        public ActionResult IndexNTKA()
        {
            return View();
        }
        public ActionResult IndexTKA()
        {
            return View();
        }
        public ActionResult IndexHAEN()
        {
            return View();
        }
        public ActionResult IndexERROR()
        {
            return View();
        }
        public ActionResult IndexClick()
        {
            Response.Redirect("~/TDSS/Index");
            return View();
        }
    }
}