using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Text;
using Kingclinic.Models;
using LpSolveDotNet;

namespace Kingclinic.Controllers
{
    public class TDSSController : Controller
{
        private readonly KingsClinicEntities db = new KingsClinicEntities();

        // GET: TDSS
        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        //public ActionResult Index(string SEX, string AGE, string WEIGHT, string HEIGHT, string KLSCALE, string GOAL1, string GOAL2, string GOAL3, string GOAL4, string GOAL5, string GOAL6)
        //{
            //var receiveSEX = SEX;
            //var receiveAGE = AGE;
            //var receiveWEIGHT = WEIGHT;
            //var receiveHEIGHT = HEIGHT;
            //var receiveKLSCALE = KLSCALE;
            //var receiveGOAL1 = GOAL1;
            //var receiveGOAL2 = GOAL2;
            //var receiveGOAL3 = GOAL3;
            //var receiveGOAL4 = GOAL4;
            //var receiveGOAL5 = GOAL5;
            //var receiveGOAL6 = GOAL6;




            //return View();
            
        //}
        public ActionResult Index(FormCollection post)
        {
            ViewBag.SEX = post["SEX"];
            ViewBag.AGE = post["AGE"];
            ViewBag.WEIGHT = post["WEIGHT"];
            ViewBag.HEIGHT = post["HEIGHT"];
            ViewBag.KLSCALE = post["KLSCALE"];
            ViewBag.GOAL1 = post["GOAL1"];
            ViewBag.GOAL2 = post["GOAL2"];
            ViewBag.GOAL3 = post["GOAL3"];
            ViewBag.GOAL4 = post["GOAL4"];
            ViewBag.GOAL5 = post["GOAL5"];
            ViewBag.GOAL6 = post["GOAL6"];

            TreatmentSelection objArticle = new TreatmentSelection();
            objArticle.SEX = post["SEX"];
            objArticle.AGE = post["AGE"];
            objArticle.WEIGHT = post["WEIGHT"];
            objArticle.HEIGHT = post["HEIGHT"];
            objArticle.KLSCALE = post["KLSCALE"];
            objArticle.GOAL1 = post["GOAL1"];
            objArticle.GOAL2 = post["GOAL2"];
            objArticle.GOAL3 = post["GOAL3"];
            objArticle.GOAL4 = post["GOAL4"];
            objArticle.GOAL5 = post["GOAL5"];
            objArticle.GOAL6 = post["GOAL6"];
            db.TreatmentSelection.Add(objArticle);
            db.SaveChanges();

            return View();
        }
        
    }
}