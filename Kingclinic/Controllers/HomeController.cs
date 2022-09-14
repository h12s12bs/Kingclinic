using Kingclinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Community.CsharpSqlite.Sqlite3;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

namespace Kingclinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly KingsClinicEntities db = new KingsClinicEntities();
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection PATIENT)
        {
                /*ViewBag.NAME = PATIENT["NAME"];
                ViewBag.EMAIL = PATIENT["EMAIL"];
                ViewBag.DATE = PATIENT["DATE"];
                ViewBag.PROGRAM = PATIENT["PROGRAM"];
                ViewBag.PHONE = PATIENT["PHONE"];
                ViewBag.MESSAGE = PATIENT["MESSAGE"];*/
            Reservation objArticle = new Reservation();
            objArticle.NAME = PATIENT["NAME"];
            objArticle.EMAIL = PATIENT["EMAIL"];
            objArticle.DATE = PATIENT["DATE"];
            objArticle.PROGRAM = PATIENT["PROGRAM"];
            objArticle.PHONE = PATIENT["PHONE"];
            objArticle.SYMPTOM = PATIENT["SYMPTOM"];

            db.Reservation.Add(objArticle);

            db.SaveChanges();
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}