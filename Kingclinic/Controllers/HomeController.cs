using Kingclinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Community.CsharpSqlite.Sqlite3;
using System.Data.SqlClient;

namespace Kingclinic.Controllers
{
    public class HomeController : Controller
    {
        /*private readonly KingsClinicEntities db = new KingsClinicEntities();*/
        public ActionResult Index()
        {
            /*ViewBag.NAME = post["NAME"];
            ViewBag.EMAIL = post["EMAIL"];
            ViewBag.DATE = post["DATE"];
            ViewBag.PROGRAM = post["PROGRAM"];
            ViewBag.PHONE = post["PHONE"];
            ViewBag.SYMPTOM = post["SYMPTOM"];
            Reservation objArticle = new Reservation();
            objArticle.NAME = post["NAME"];
            objArticle.EMAIL = post["EMAIL"];
            objArticle.DATE = Convert.ToDateTime(post["DATE"]);
            objArticle.PROGRAM = post["PROGRAM"];
            objArticle.PHONE = post["PHONE"];
            objArticle.SYMPTOM = post["SYMPTOM"];
          
            db.Reservation.Add(objArticle);

            db.SaveChanges();*/
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