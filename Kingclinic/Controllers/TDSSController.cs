using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Text;
using Kingclinic.Models;
using System.Diagnostics;
using Google.OrTools.LinearSolver;
using OrToolsMilpManager;
using Google.OrTools.Algorithms;
using LineBot.Models;
using Accord;
using Accord.Math;
using Accord.Statistics;
using Accord.MachineLearning;

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
        public ActionResult IndexCTDSS()
        {
            return View();

        }
        [HttpPost]
        
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
            ViewBag.FUZZY1 = post["FUZZY1"];
            ViewBag.FUZZY2 = post["FUZZY2"];
            ViewBag.FUZZY3 = post["FUZZY3"];
            ViewBag.FUZZY4 = post["FUZZY4"];
            ViewBag.FUZZY5 = post["FUZZY5"];
            ViewBag.FUZZY6 = post["FUZZY6"];
            ViewBag.FUZZY7 = post["FUZZY7"];
            ViewBag.FUZZY8 = post["FUZZY8"];
            ViewBag.FUZZY9 = post["FUZZY9"];



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
            objArticle.FUZZY1 = post["FUZZY1"];
            objArticle.FUZZY2 = post["FUZZY2"];
            objArticle.FUZZY3 = post["FUZZY3"];
            objArticle.FUZZY4 = post["FUZZY4"];
            objArticle.FUZZY5 = post["FUZZY5"];
            objArticle.FUZZY6 = post["FUZZY6"];
            objArticle.FUZZY7 = post["FUZZY7"];
            objArticle.FUZZY8 = post["FUZZY8"];
            objArticle.FUZZY9 = post["FUZZY9"];

            db.TreatmentSelection.Add(objArticle);
            db.SaveChanges();

            
            // Create the linear solver with the SCIP backend.
            Solver solver = Solver.CreateSolver("AHPMCGPOAknee", "CBC_MIXED_INTEGER_PROGRAMMING");
            if (solver is null)
            {
                Response.Redirect("~/TDDSRESULT/IndexERROR");
            }

            // x and y are integer non-negative variables.
            Variable d1n = solver.MakeNumVar(0.0, double.PositiveInfinity, "d1n");
            Variable d1p = solver.MakeNumVar(0.0, double.PositiveInfinity, "d1p");
            Variable d2n = solver.MakeNumVar(0.0, double.PositiveInfinity, "d2n");
            Variable d2p = solver.MakeNumVar(0.0, double.PositiveInfinity, "d2p");
            Variable d3n = solver.MakeNumVar(0.0, double.PositiveInfinity, "d3n");
            Variable d3p = solver.MakeNumVar(0.0, double.PositiveInfinity, "d3p");
            Variable d4n = solver.MakeNumVar(0.0, double.PositiveInfinity, "d4n");
            Variable d4p = solver.MakeNumVar(0.0, double.PositiveInfinity, "d4p");
            Variable d5n = solver.MakeNumVar(0.0, double.PositiveInfinity, "d5n");
            Variable d5p = solver.MakeNumVar(0.0, double.PositiveInfinity, "d5p");
            Variable d6n = solver.MakeNumVar(0.0, double.PositiveInfinity, "d6n");
            Variable d6p = solver.MakeNumVar(0.0, double.PositiveInfinity, "d6p");
            Variable e1n = solver.MakeNumVar(0.0, double.PositiveInfinity, "e1n");
            Variable e1p = solver.MakeNumVar(0.0, double.PositiveInfinity, "e1p");
            Variable e2n = solver.MakeNumVar(0.0, double.PositiveInfinity, "e2n");
            Variable e2p = solver.MakeNumVar(0.0, double.PositiveInfinity, "e2p");
            Variable e3n = solver.MakeNumVar(0.0, double.PositiveInfinity, "e3n");
            Variable e3p = solver.MakeNumVar(0.0, double.PositiveInfinity, "e3p");
            Variable e4n = solver.MakeNumVar(0.0, double.PositiveInfinity, "e4n");
            Variable e4p = solver.MakeNumVar(0.0, double.PositiveInfinity, "e4p");
            Variable e5n = solver.MakeNumVar(0.0, double.PositiveInfinity, "e5n");
            Variable e5p = solver.MakeNumVar(0.0, double.PositiveInfinity, "e5p");
            Variable e6n = solver.MakeNumVar(0.0, double.PositiveInfinity, "e6n");
            Variable e6p = solver.MakeNumVar(0.0, double.PositiveInfinity, "e6p");
            Variable x1 = solver.MakeBoolVar("x1");
            Variable x2 = solver.MakeBoolVar("x2");
            Variable x3 = solver.MakeBoolVar("x3");
            Variable x4 = solver.MakeBoolVar("x4");
            Variable x5 = solver.MakeBoolVar("x5");
            Variable x6 = solver.MakeBoolVar("x6");
            Variable x7 = solver.MakeBoolVar("x7");
            Variable x8 = solver.MakeBoolVar("x8");
            Variable x9 = solver.MakeBoolVar("x9");
            Variable g1 = solver.MakeNumVar(0.0, double.PositiveInfinity, "g1");
            Variable g2 = solver.MakeNumVar(0.0, double.PositiveInfinity, "g2");
            Variable g3 = solver.MakeNumVar(0.0, double.PositiveInfinity, "g3");
            Variable g4 = solver.MakeNumVar(0.0, double.PositiveInfinity, "g4");
            Variable g5 = solver.MakeNumVar(0.0, double.PositiveInfinity, "g5");
            Variable g6 = solver.MakeNumVar(0.0, double.PositiveInfinity, "g6");
            Variable y1 = solver.MakeNumVar(0.0, double.PositiveInfinity, "y1");
            Variable y2 = solver.MakeNumVar(0.0, double.PositiveInfinity, "y2");
            Variable y3 = solver.MakeNumVar(0.0, double.PositiveInfinity, "y3");
            Variable y4 = solver.MakeNumVar(0.0, double.PositiveInfinity, "y4");
            Variable y5 = solver.MakeNumVar(0.0, double.PositiveInfinity, "y5");
            Variable y6 = solver.MakeNumVar(0.0, double.PositiveInfinity, "y6");
            Variable M1 = solver.MakeNumVar(0.0, double.PositiveInfinity, "M1");
            Variable M2 = solver.MakeNumVar(0.0, double.PositiveInfinity, "M2");
            Variable M3 = solver.MakeNumVar(0.0, double.PositiveInfinity, "M3");





            double g1s = Convert.ToDouble(post["GOAL1"]);
            double g2s = Convert.ToDouble(post["GOAL2"]);
            double g3s = Convert.ToDouble(post["GOAL3"]);
            double g4s = Convert.ToDouble(post["GOAL4"]);
            double g5s = Convert.ToDouble(post["GOAL5"]);
            double g6s = Convert.ToDouble(post["GOAL6"]);
            double FUZZYs1 = Convert.ToDouble(post["FUZZY1"]);
            double FUZZYs2 = Convert.ToDouble(post["FUZZY2"]);
            double FUZZYs3 = Convert.ToDouble(post["FUZZY3"]);
            double FUZZYs4 = Convert.ToDouble(post["FUZZY4"]);
            double FUZZYs5 = Convert.ToDouble(post["FUZZY5"]);
            double FUZZYs6 = Convert.ToDouble(post["FUZZY6"]);
            double FUZZYs7 = Convert.ToDouble(post["FUZZY7"]);
            double FUZZYs8 = Convert.ToDouble(post["FUZZY8"]);
            double FUZZYs9 = Convert.ToDouble(post["FUZZY9"]);

            //goal1
            /*if (Convert.ToDouble(post["GOAL1"]) == 40)
            {
                g1s = 0.4;
            }
            else if (Convert.ToDouble(post["GOAL1"]) < 60 || Convert.ToDouble(post["GOAL1"]) > 40)
            {
                g1s = 0.6 - (0.6 - 0.4) * (Convert.ToDouble(post["GOAL1"]) - 60) / (40 - 60);
            }
            else if (Convert.ToDouble(post["GOAL1"]) == 60)
            {
                g1s = 0.6;
            }
            else if (Convert.ToDouble(post["GOAL1"]) < 80 || Convert.ToDouble(post["GOAL1"]) > 60)
            {
                g1s = 0.8 - (0.8 - 0.6) * (Convert.ToDouble(post["GOAL1"]) - 80) / (60 - 80);
            }
            else if (Convert.ToDouble(post["GOAL1"]) == 80)
            {
                g1s = 0.8;
            }
            else if (Convert.ToDouble(post["GOAL1"]) < 100 || Convert.ToDouble(post["GOAL1"]) > 80)
            {
                g1s = 1 - (1 - 0.8) * (Convert.ToDouble(post["GOAL1"]) - 100) / (80 - 100);
            }
            else if (Convert.ToDouble(post["GOAL1"]) == 100)
            {
                g1s = 1;
            }

            //goal3
            if (Convert.ToDouble(post["GOAL3"]) == 100000)
            {
                g3s = 0.2;
            }
            else if (Convert.ToDouble(post["GOAL3"]) < 100000 || Convert.ToDouble(post["GOAL3"]) > 50000)
            {
                g3s = 0.4 - (0.4 - 0.2) * (Convert.ToDouble(post["GOAL3"]) - 50000) / (100000 - 50000);
            }
            else if (Convert.ToDouble(post["GOAL3"]) == 50000)
            {
                g3s = 0.4;
            }
            else if (Convert.ToDouble(post["GOAL3"]) < 50000 || Convert.ToDouble(post["GOAL3"]) > 30000)
            {
                g3s = 0.8 - (0.8 - 0.4) * (Convert.ToDouble(post["GOAL3"]) - 30000) / (50000 - 30000);
            }
            else if (Convert.ToDouble(post["GOAL3"]) == 300000)
            {
                g3s = 0.8;
            }
            else if (Convert.ToDouble(post["GOAL3"]) < 30000 || Convert.ToDouble(post["GOAL3"]) > 10000)
            {
                g3s = 1 - (1 - 0.8) * (Convert.ToDouble(post["GOAL3"]) - 10000) / (30000 - 10000);
            }
            else if (Convert.ToDouble(post["GOAL3"]) == 10000)
            {
                g3s = 1;
            }*/

            


            //G1:
            // 0.75*x1+0.5*x2+0.4*x3+0.75*x4+0.6*x5+0.5*x6+0.67*x7+0.55*x8+0.85*x9+d1n-d1p=g1
            //g1-e1p+e1n=1;
            //0.6<=g1;
            //g1<=1
            //測試 G1
            /*double g1x1 = 75;
            double g1x2 = 50;
            double g1x3 = 40;
            double g1x4 = 75;
            double g1x5 = 60;
            double g1x6 = 50;
            double g1x7 = 67;
            double g1x8 = 55;
            double g1x9 = 85;
            double g1x1w;
            double g1x2w;
            double g1x3w;
            double g1x4w;
            double g1x5w;
            double g1x6w;
            double g1x7w;
            double g1x8w;
            double g1x9w;
            //membership function at least
            //g1 x1w
            if (g1x1 < g1s)
            {
                g1x1w = 0;
            }
            else if (g1s <= g1x1 && g1x1 < g1x9)
            {
                g1x1w = (g1x1 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x1w = 1;
            }
            //g1 x2 w
            if (g1x2 <= g1s)
            {
                g1x2w = 0;
            }
            else if (g1s < g1x2 && g1x2 < g1x9)
            {
                g1x2w = (g1x2 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x2w = 1;
            }
            //g1 x3 w
            if (g1x3 <= g1s)
            {
                g1x3w = 0;
            }
            else if (g1s < g1x3 && g1x3 < g1x9)
            {
                g1x3w = (g1x3 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x3w = 1;
            }
            //g1 x4 w
            if (g1x4 <= g1s)
            {
                g1x4w = 0;
            }
            else if (g1s < g1x4 && g1x4 < g1x9)
            {
                g1x4w = (g1x4 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x4w = 1;
            }
            //g1 x5 w
            if (g1x5 <= g1s)
            {
                g1x5w = 0;
            }
            else if (g1s < g1x5 && g1x5 < g1x9)
            {
                g1x5w = (g1x5 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x5w = 1;
            }
            //g1 x6 w
            if (g1x6 <= g1s)
            {
                g1x6w = 0;
            }
            else if (g1s < g1x6 && g1x6 < g1x9)
            {
                g1x6w = (g1x6 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x6w = 1;
            }
            //g1 x7 w
            if (g1x7 <= g1s)
            {
                g1x7w = 0;
            }
            else if (g1s < g1x7 && g1x7 < g1x9)
            {
                g1x7w = (g1x7 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x7w = 1;
            }
            //g1 x8 w
            if (g1x8 <= g1s)
            {
                g1x8w = 0;
            }
            else if (g1s < g1x8 && g1x8 < g1x9)
            {
                g1x8w = (g1x8 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x8w = 1;
            }
            //g1 x9 w
            if (g1x9 <= g1s)
            {
                g1x9w = 0;
            }
            else if (g1s < g1x9)
            {
                g1x9w = (g1x9 - g1s) / (g1x9 - g1s);
            }
            else
            {
                g1x9w = 1;
            }
            solver.Add(g1x1w * x1 + g1x2w * x2 + g1x3w * x3 + g1x4w * x4 + g1x5w * x5 + g1x6w * x6 + g1x7w * x7 + g1x8w * x8 + g1x9w * x9 + d1n - d1p == g1);
            solver.Add(g1 - e1p + e1n == 1);
            solver.Add(0 <= g1);
            solver.Add(g1 <= 1);*/
            //原本
            solver.Add(0.75 * x1 + 0.5 * x2 + 0.4 * x3 + 0.75 * x4 + 0.6 * x5 + 0.5 * x6 + 0.67 * x7 + 0.55 * x8 + 0.85 * x9 + d1n - d1p == g1);
            solver.Add(g1 - e1p + e1n == 1);
            solver.Add(g1s <= g1);
            solver.Add(g1 <= 1);

            //G2:
            //0.1 * x1 + 0.17 * x2 + 0.25 * x3 + x4 + 0.5 * x5 + x6 + 0.25 * x7 + 0.7 * x8 + x9 + d2n - d2p = g2;
            //g2 - e2p + e2n = 1;
            //0.5 <= g2;
            //g2 <= 1;
            /*double g2x1 = 4;
            double g2x2 = 8;
            double g2x3 = 12;
            double g2x4 = 52;
            double g2x5 = 26;
            double g2x6 = 52;
            double g2x7 = 12;
            double g2x8 = 36;
            double g2x9 = 52;
            double g2x1w;
            double g2x2w;
            double g2x3w;
            double g2x4w;
            double g2x5w;
            double g2x6w;
            double g2x7w;
            double g2x8w;
            double g2x9w;
            //membership function at least
            //g2 x1w
            if (g2x1 <= g2s)
            {
                g2x1w = 0;
            }
            else if (g2s < g2x1 && g2x1 < g2x9)
            {
                g2x1w = (g2x1 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x1w = 1;
            }
            //g2 x2w
            if (g2x2 <= g2s)
            {
                g2x2w = 0;
            }
            else if (g2s < g2x2 && g2x2 < g2x9)
            {
                g2x2w = (g2x2 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x2w = 1;
            }
            //g2 x3w
            if (g2x3 <= g2s)
            {
                g2x3w = 0;
            }
            else if (g2s < g2x3 && g2x3 < g2x9)
            {
                g2x3w = (g2x3 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x3w = 1;
            }
            //g2 x4w
            if (g2x4 <= g2s)
            {
                g2x4w = 0;
            }
            else if (g2s < g2x4 && g2x4 < g2x9)
            {
                g2x4w = (g2x4 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x4w = 1;
            }
            //g2 x5w
            if (g2x5 <= g2s)
            {
                g2x5w = 0;
            }
            else if (g2s < g2x5 && g2x5 < g2x9)
            {
                g2x5w = (g2x5 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x5w = 1;
            }
            //g2 x6w
            if (g2x6 <= g2s)
            {
                g2x6w = 0;
            }
            else if (g2s < g2x6 && g2x6 < g2x9)
            {
                g2x6w = (g2x6 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x6w = 1;
            }
            //g2 x7w
            if (g2x7 <= g2s)
            {
                g2x7w = 0;
            }
            else if (g2s < g2x7 && g2x7 < g2x9)
            {
                g2x7w = (g2x7 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x7w = 1;
            }
            //g2 x8w
            if (g2x8 <= g2s)
            {
                g2x8w = 0;
            }
            else if (g2s < g2x8 && g2x8 < g2x9)
            {
                g2x8w = (g2x8 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x8w = 1;
            }
            //g2 x9w
            if (g2x9 <= g2s)
            {
                g2x9w = 0;
            }
            else if (g2s < g2x9)
            {
                g2x9w = (g2x9 - g2s) / (g2x9 - g2s);
            }
            else
            {
                g2x9w = 1;
            }
            //測試
            solver.Add(g2x1w * x1 + g2x2w * x2 + g2x3w * x3 + g2x4w * x4 + g2x5w * x5 + g2x6w * x6 + g2x7w * x7 + g2x8w * x8 + g2x9w * x9 + d2n - d2p == g2);
            solver.Add(g2 - e2p + e2n == 1);
            solver.Add(0 <= g2);
            solver.Add(g2 <= 1);*/

            //原本
            solver.Add(0.1 * x1 + 0.17 * x2 + 0.25 * x3 + x4 + 0.5 * x5 + x6 + 0.25 * x7 + 0.7 * x8 + x9 + d2n - d2p == g2);
            solver.Add(g2 - e2p + e2n == 1);
            solver.Add(g2s <= g2);
            solver.Add(g2 <= 1);


            //G3:
            //0.95 * x1 + 0.85 * x2 + 0.9 * x3 + 0.64 * x4 + 0.97 * x5 + 0.62 * x6 + x7 + 0.72 * x8 + 0.2 * x9 + d3n - d3p = g3;
            //g3 - e3p + e3n = 1;
            //0.97 <= g3;
            //g3 <= 1;
            /*double g3x1 = 10000;
            double g3x2 = 20000;
            double g3x3 = 15000;
            double g3x4 = 35000;
            double g3x5 = 8000;
            double g3x6 = 36000;
            double g3x7 = 5000;
            double g3x8 = 30000;
            double g3x9 = 100000;
            double g3x1w;
            double g3x2w;
            double g3x3w;
            double g3x4w;
            double g3x5w;
            double g3x6w;
            double g3x7w;
            double g3x8w;
            double g3x9w;
            //membership function at most
            //g3 x1w
            if (g3x1 >= g3s)
            {
                g3x1w = 0;
            }
            else if (5000 < g3x1 && g3x1 <= g3s)
            {
                g3x1w = (g3s - g3x1) / (g3s - g3x7);
            }
            else
            {
                g3x1w = 1;
            }
            //g3 x2w
            if (g3x2 >= g3s)
            {
                g3x2w = 0;
            }
            else if (5000 < g3x2 && g3x2 < g3s)
            {
                g3x2w = (g3s - g3x2) / (g3s - g3x7);
            }
            else
            {
                g3x2w = 1;
            }
            //g3 x3w
            if (g3x3 >= g3s)
            {
                g3x3w = 0;
            }
            else if (5000 < g3x3 && g3x3 < g3s)
            {
                g3x3w = (g3s - g3x3) / (g3s - g3x7);
            }
            else
            {
                g3x3w = 1;
            }
            //g3 x4w
            if (g3x4 >= g3s)
            {
                g3x4w = 0;
            }
            else if (5000 < g3x4 && g3x4 < g3s)
            {
                g3x4w = (g3s - g3x4) / (g3s - g3x7);
            }
            else
            {
                g3x4w = 1;
            }
            //g3 x5w
            if (g3x5 >= g3s)
            {
                g3x5w = 0;
            }
            else if (5000 < g3x5 && g3x5 < g3s)
            {
                g3x5w = (g3s - g3x5) / (g3s - g3x7);
            }
            else
            {
                g3x5w = 1;
            }
            //g3 x6w
            if (g3x6 >= g3s)
            {
                g3x6w = 0;
            }
            else if (5000 < g3x6 && g3x6 < g3s)
            {
                g3x6w = (g3s - g3x6) / (g3s - g3x7);
            }
            else
            {
                g3x6w = 1;
            }
            //g3 x7w
            if (g3x7 >= g3s)
            {
                g3x7w = 0;
            }
            else if (5000 < g3x7 && g3x7 < g3s)
            {
                g3x7w = (g3s - g3x7) / (g3s - g3x7);
            }
            else
            {
                g3x7w = 1;
            }
            //g3 x8w
            if (g3x8 >= g3s)
            {
                g3x8w = 0;
            }
            else if (5000 < g3x8 && g3x8 < g3s)
            {
                g3x8w = (g3s - g3x8) / (g3s - g3x7);
            }
            else
            {
                g3x8w = 1;
            }
            //g3 x9w
            if (g3x9 >= g3s)
            {
                g3x9w = 0;
            }
            else if (5000 < g3x9 && g3x9 < g3s)
            {
                g3x9w = (g3s - g3x9) / (g3s - g3x7);
            }
            else
            {
                g3x9w = 1;
            }
            //測試
            solver.Add(g3x1w * x1 + g3x2w * x2 + g3x3w * x3 + g3x4w * x4 + g3x5w * x5 + g3x6w * x6 + g3x7w * x7 + g3x8w * x8 + g3x9w * x9 + d3n - d3p == g3);
            solver.Add(g3 - e3p + e3n == 1);
            solver.Add(0 <= g3);
            solver.Add(g3 <= 1);*/
            //原本
            solver.Add(0.95 * x1 + 0.85 * x2 + 0.9 * x3 + 0.64 * x4 + 0.97 * x5 + 0.62 * x6 + x7 + 0.72 * x8 + 0.2 * x9 + d3n - d3p == g3);
            solver.Add(g3 - e3p + e3n == 1);
            solver.Add(g3s <= g3);
            solver.Add(g3 <= 1);

            //G4:
            //x1 + x2 + x3 + x4 + 0.7 * x5 + 0.7 * x6 + 0.7 * x7 + 0.4 * x8 + 0.2 * x9 + d4n - d4p = g4;
            //g4 - e4p + e4n = 1;
            //0.7 <= g4;
            //g4 <= 1;
            /*double g4x1 = 0;
            double g4x2 = 0;
            double g4x3 = 0;
            double g4x4 = 0;
            double g4x5 = 1;
            double g4x6 = 1;
            double g4x7 = 1;
            double g4x8 = 1.5;
            double g4x9 = 2;
            double g4x1w;
            double g4x2w;
            double g4x3w;
            double g4x4w;
            double g4x5w;
            double g4x6w;
            double g4x7w;
            double g4x8w;
            double g4x9w;
            //membership function at most
            //g4 x1w
            if (g4x1 >= g4s)
            {
                g4x1w = 0;
            }
            else if (g4x9 < g4x1 && g4x1 < g4s)
            {
                g4x1w = (g4s - g4x1) / (g4s - g4x9);
            }
            else
            {
                g4x1w = 1;
            }
            //g4 x2w
            if (g4x2 >= g4s)
            {
                g4x2w = 0;
            }
            else if (g4x9 < g4x2 && g4x2 < g4s)
            {
                g4x2w = (g4s - g4x2) / (g4s - g4x9);
            }
            else
            {
                g4x2w = 1;
            }
            //g4 x3w
            if (g4x3 >= g4s)
            {
                g4x3w = 0;
            }
            else if (g4x9 < g4x3 && g4x3 < g4s)
            {
                g4x3w = (g4s - g4x3) / (g4s - g4x9);
            }
            else
            {
                g4x4w = 1;
            }
            //g4 x4w
            if (g4x4 >= g4s)
            {
                g4x4w = 0;
            }
            else if (g4x9 < g4x4 && g4x4 < g4s)
            {
                g4x4w = (g4s - g4x4) / (g4s - g4x9);
            }
            else
            {
                g4x4w = 1;
            }
            //g4 x5w
            if (g4x5 >= g4s)
            {
                g4x5w = 0;
            }
            else if (g4x9 < g4x5 && g4x5 < g4s)
            {
                g4x5w = (g4s - g4x5) / (g4s - g4x9);
            }
            else
            {
                g4x5w = 1;
            }
            //g4 x6w
            if (g4x6 >= g4s)
            {
                g4x6w = 0;
            }
            else if (g4x9 < g4x6 && g4x6 < g4s)
            {
                g4x6w = (g4s - g4x6) / (g4s - g4x9);
            }
            else
            {
                g4x6w = 1;
            }
            //g4 x7w
            if (g4x7 >= g4s)
            {
                g4x7w = 0;
            }
            else if (g4x9 < g4x7 && g4x7 < g4s)
            {
                g4x7w = (g4s - g4x7) / (g4s - g4x9);
            }
            else
            {
                g4x7w = 1;
            }
            //g4 x8w
            if (g4x8 >= g4s)
            {
                g4x8w = 0;
            }
            else if (g4x9 < g4x8 && g4x8 < g4s)
            {
                g4x8w = (g4s - g4x8) / (g4s - g4x9);
            }
            else
            {
                g4x8w = 1;
            }
            //g4 x9w
            if (g4x9 >= g4s)
            {
                g4x9w = 0;
            }
            else if (g4x9 < g4s)
            {
                g4x9w = (g4s - g4x9) / (g4s - g4x9);
            }
            else
            {
                g4x9w = 1;
            }

            solver.Add(g4x1w * x1 + g4x2w * x2 + g4x2w * x3 + g4x4w * x4 + g4x5w * x5 + g4x6w * x6 + g4x7w * x7 + g4x8w * x8 + g4x9w * x9 + d4n - d4p == g4);
            solver.Add(g4 - e4p + e4n == 1);
            solver.Add(0 <= g4);
            solver.Add(g4 <= 1);*/
            solver.Add(x1 + x2 + x3 + x4 + 0.7 * x5 + 0.7 * x6 + 0.7 * x7 + 0.4 * x8 + 0.2 * x9 + d4n - d4p == g4);
            solver.Add(g4 - e4p + e4n == 1);
            solver.Add(g4s <= g4);
            solver.Add(g4 <= 1);

            //G5:
            //0.95 * x1 + 0.91 * x2 + 0.91 * x3 + 0.8 * x4 + 0.87 * x5 + 0.95 * x6 + x7 + 0.65 * x8 + 0.1 * x9 + d5n - d5p = g5;
            //g5 - e5p + e5n = 1;
            //0.87 <= g5;
            //g5 <= 1;
            /*double g5x1 = 1;
            double g5x2 = 1.5;
            double g5x3 = 1.5;
            double g5x4 = 3;
            double g5x5 = 2;
            double g5x6 = 1;
            double g5x7 = 0.25;
            double g5x8 = 6;
            double g5x9 = 12;
            double g5x1w;
            double g5x2w;
            double g5x3w;
            double g5x4w;
            double g5x5w;
            double g5x6w;
            double g5x7w;
            double g5x8w;
            double g5x9w;
            //membership function at most
            //g5 x1w
            if (g5x1 >= g5s)
            {
                g5x1w = 0;
            }
            else if (g5x9 < g5x1 && g5x1 < g5s)
            {
                g5x1w = (g5s - g5x1) / (g5s - g5x9);
            }
            else
            {
                g5x1w = 1;
            }
            //g5 x2w
            if (g5x2 >= g5s)
            {
                g5x2w = 0;
            }
            else if (g5x9 < g5x2 && g5x2 < g5s)
            {
                g5x2w = (g5s - g5x2) / (g5s - g5x9);
            }
            else
            {
                g5x2w = 1;
            }
            //g5 x3w
            if (g5x3 >= g5s)
            {
                g5x3w = 0;
            }
            else if (g5x9 < g5x3 && g5x3 < g5s)
            {
                g5x3w = (g5s - g5x3) / (g5s - g5x9);
            }
            else
            {
                g5x3w = 1;
            }
            //g5 x4w
            if (g5x4 >= g5s)
            {
                g5x4w = 0;
            }
            else if (g5x9 < g5x4 && g5x4 < g5s)
            {
                g5x4w = (g5s - g5x4) / (g5s - g5x9);
            }
            else
            {
                g5x4w = 1;
            }
            //g5 x5w
            if (g5x5 >= g5s)
            {
                g5x5w = 0;
            }
            else if (g5x9 < g5x5 && g5x5 < g5s)
            {
                g5x5w = (g5s - g5x5) / (g5s - g5x9);
            }
            else
            {
                g5x5w = 1;
            }
            //g5 x6w
            if (g5x6 >= g5s)
            {
                g5x6w = 0;
            }
            else if (g5x9 < g5x6 && g5x6 < g5s)
            {
                g5x6w = (g5s - g5x6) / (g5s - g5x9);
            }
            else
            {
                g5x6w = 1;
            }
            //g5 x7w
            if (g5x7 >= g5s)
            {
                g5x7w = 0;
            }
            else if (g5x9 < g5x7 && g5x7 < g5s)
            {
                g5x7w = (g5s - g5x7) / (g5s - g5x9);
            }
            else
            {
                g5x7w = 1;
            }
            //g5 x8w
            if (g5x8 >= g5s)
            {
                g5x8w = 0;
            }
            else if (g5x9 < g5x8 && g5x8 < g5s)
            {
                g5x8w = (g5s - g5x8) / (g5s - g5x9);
            }
            else
            {
                g5x8w = 1;
            }
            //g5 x9w
            if (g5x9 >= g5s)
            {
                g5x9w = 0;
            }
            else if (g5x9 < g5s)
            {
                g5x9w = (g5s - g5x9) / (g5s - g5x9);
            }
            else
            {
                g5x9w = 1;
            }

            solver.Add(g5x1w * x1 + g5x2w * x2 + g5x3w * x3 + g5x4w * x4 + g5x5w * x5 + g5x6w * x6 + g5x7w * x7 + g5x8w * x8 + g5x9w * x9 + d5n - d5p == g5);
            solver.Add(g5 - e5p + e5n == 1);
            solver.Add(0 <= g5);
            solver.Add(g5 <= 1);*/
            solver.Add(0.95 * x1 + 0.91 * x2 + 0.91 * x3 + 0.8 * x4 + 0.87 * x5 + 0.95 * x6 + x7 + 0.65 * x8 + 0.1 * x9 + d5n - d5p == g5);
            solver.Add(g5 - e5p + e5n == 1);
            solver.Add(g5s <= g5);
            solver.Add(g5 <= 1);

            //G6:
            //x1 + x2 + x3 + x4 + x5 + x6 + x7 + 0.2 * x8 + 0.2 * x9 + d6n - d6p = g6;
            //g6 - e6p + e6n = 1;
            //1 <= g6;
            //g6 <= 1;
            /*double g6x1 = 100;
            double g6x2 = 100;
            double g6x3 = 100;
            double g6x4 = 100;
            double g6x5 = 100;
            double g6x6 = 100;
            double g6x7 = 100;
            double g6x8 = 0;
            double g6x9 = 0;
            double g6x1w;
            double g6x2w;
            double g6x3w;
            double g6x4w;
            double g6x5w;
            double g6x6w;
            double g6x7w;
            double g6x8w;
            double g6x9w;
            //membership function at least有問題
            //g6 x1w
            if (g6x1 <= g6s)
            {
                g6x1w = 0;
            }
            else if (g6s < g6x1 && g6x1 < 100)
            {
                g6x1w = (g6x1 - g6s) / (100 - g6s);
            }
            else
            {
                g6x1w = 1;
            }
            //g6 x2 w
            if (g6x2 <= g6s)
            {
                g6x2w = 0;
            }
            else if (g6s < g6x2 && g6x2 < 100)
            {
                g6x2w = (g6x2 - g6s) / (100 - g6s);
            }
            else
            {
                g6x2w = 1;
            }
            //g6 x3 w
            if (g6x3 <= g6s)
            {
                g6x3w = 0;
            }
            else if (g6s < g6x3 && g6x3 < 100)
            {
                g6x3w = (g6x3 - g6s) / (100 - g6s);
            }
            else
            {
                g6x3w = 1;
            }
            //g6 x4 w
            if (g6x4 <= g6s)
            {
                g6x4w = 0;
            }
            else if (g6s < g6x4 && g6x4 < 100)
            {
                g6x4w = (g6x4 - g6s) / (100 - g6s);
            }
            else
            {
                g6x4w = 1;
            }
            //g6 x5 w
            if (g6x5 <= g6s)
            {
                g6x5w = 0;
            }
            else if (g6s < g6x5 && g6x5 < 100)
            {
                g6x5w = (g6x5 - g6s) / (100 - g6s);
            }
            else
            {
                g6x5w = 1;
            }
            //g6 x6 w
            if (g6x6 <= g6s)
            {
                g6x6w = 0;
            }
            else if (g6s < g6x6 && g6x6 < 100)
            {
                g6x6w = (g6x6 - g6s) / (100 - g6s);
            }
            else
            {
                g6x6w = 1;
            }
            //g6 x7 w
            if (g6x7 <= g6s)
            {
                g6x7w = 0;
            }
            else if (g6s < g6x7 && g6x7 < g6x9)
            {
                g6x7w = (g6x7 - g6s) / (100 - g6s);
            }
            else
            {
                g6x7w = 1;
            }
            //g6 x8 w
            if (g6x8 <= g6s)
            {
                g6x8w = 0;
            }
            else if (g6s < g6x8 && g6x8 < 100)
            {
                g6x8w = (g6x8 - g6s) / (100 - g6s);
            }
            else
            {
                g6x8w = 1;
            }
            //g6 x9 w
            if (g6x9 <= g6s)
            {
                g6x9w = 0;
            }
            else if (g6s < g6x9)
            {
                g6x9w = (g6x9 - g6s) / (g6x9 - g6s);
            }
            else
            {
                g6x9w = 1;
            }
            //測試
            solver.Add(g6x1w * x1 + g6x2w * x2 + g6x3w * x3 + g6x4w * x4 + g6x5w * x5 + g6x6w * x6 + g6x7w * x7 + g6x8w * x8 + g6x9w * x9 + d6n - d6p == g6);
            solver.Add(g6 - e6p + e6n == 1);
            solver.Add(0 <= g6);
            solver.Add(g6 <= 1);*/
            //原本
            solver.Add(x1 + x2 + x3 + x4 + x5 + x6 + x7 + 0.2 * x8 + 0.2 * x9 + d6n - d6p == g6);
            solver.Add(g6 - e6p + e6n == 1);
            solver.Add(g6s <= g6);
            solver.Add(g6 <= 1);

            //x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 = 1;
            solver.Add(x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9 == 1);

            solver.Add(x1 >= 0);
            solver.Add(x2 >= 0);
            solver.Add(x3 >= 0);
            solver.Add(x4 >= 0);
            solver.Add(x5 >= 0);
            solver.Add(x6 >= 0);
            solver.Add(x7 >= 0);
            solver.Add(x8 >= 0);
            solver.Add(x9 >= 0);

            solver.Add(g1+d1p-d1n==y1);
            solver.Add(g2 + d2p - d2n == y2);
            solver.Add(g3 + d3p - d3n == y3);
            solver.Add(g4 + d4p - d4n == y4);
            solver.Add(g5 + d5p - d5n == y5);
            solver.Add(g6 + d6p - d6n == y6);
            //G1 slightly important than g2-6
            if (FUZZYs1 == 1 && FUZZYs2 == 1 && FUZZYs3 == 2)
            {
                solver.Add(y1 - y2 >= 0.01 * (1 - M1));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 1 && FUZZYs3 == 3)
            {
                solver.Add(y1 - y3 >= 0.01 * (1 - M1));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 1 && FUZZYs3 == 4)
            {
                solver.Add(y1 - y4 >= 0.01 * (1 - M1));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 1 && FUZZYs3 == 5)
            {
                solver.Add(y1 - y5 >= 0.01 * (1 - M1));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 1 && FUZZYs3 == 6)
            {
                solver.Add(y1 - y6 >= 0.01 * (1 - M1));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Moderately important than g2-6
            else if (FUZZYs1 == 1 && FUZZYs2 == 2 && FUZZYs3 == 2)
            {
                solver.Add(y1 - y2 >= 0.06 * (1 - M1));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 2 && FUZZYs3 == 3)
            {
                solver.Add(y1 - y3 >= 0.06 * (1 - M1));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 2 && FUZZYs3 == 4)
            {
                solver.Add(y1 - y4 >= 0.06 * (1 - M1));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 2 && FUZZYs3 == 5)
            {
                solver.Add(y1 - y5 >= 0.06 * (1 - M1));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 2 && FUZZYs3 == 6)
            {
                solver.Add(y1 - y6 >= 0.06 * (1 - M1));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Highly important than g2-6
            else if (FUZZYs1 == 1 && FUZZYs2 == 3 && FUZZYs3 == 2)
            {
                solver.Add(y1 - y2 >= 0.11 * (1 - M1));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 3 && FUZZYs3 == 3)
            {
                solver.Add(y1 - y3 >= 0.11 * (1 - M1));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 3 && FUZZYs3 == 4)
            {
                solver.Add(y1 - y4 >= 0.11 * (1 - M1));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 3 && FUZZYs3 == 5)
            {
                solver.Add(y1 - y5 >= 0.11 * (1 - M1));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 3 && FUZZYs3 == 6)
            {
                solver.Add(y1 - y6 >= 0.11 * (1 - M1));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Absoltely important than g2-6
            else if (FUZZYs1 == 1 && FUZZYs2 == 4 && FUZZYs3 == 2)
            {
                solver.Add(y1 - y2 >= 0.16 * (1 - M1));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 4 && FUZZYs3 == 3)
            {
                solver.Add(y1 - y3 >= 0.16 * (1 - M1));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 4 && FUZZYs3 == 4)
            {
                solver.Add(y1 - y4 >= 0.16 * (1 - M1));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 4 && FUZZYs3 == 5)
            {
                solver.Add(y1 - y5 >= 0.16 * (1 - M1));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs1 == 1 && FUZZYs2 == 4 && FUZZYs3 == 6)
            {
                solver.Add(y1 - y6 >= 0.16 * (1 - M1));
                solver.Add(y1 - y6 >= 0);
            }
            //G2 slightly important than g1,3-6
            else if (FUZZYs1 == 2 && FUZZYs2 == 1 && FUZZYs3 == 1)
            {
                solver.Add(y2 - y1 >= 0.01 * (1 - M1));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 1 && FUZZYs3 == 3)
            {
                solver.Add(y2 - y3 >= 0.01 * (1 - M1));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 1 && FUZZYs3 == 4)
            {
                solver.Add(y2 - y4 >= 0.01 * (1 - M1));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 1 && FUZZYs3 == 5)
            {
                solver.Add(y2 - y5 >= 0.01 * (1 - M1));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 1 && FUZZYs3 == 6)
            {
                solver.Add(y2 - y6 >= 0.01 * (1 - M1));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Moderately important than g1,3-6
            else if (FUZZYs1 == 2 && FUZZYs2 == 2 && FUZZYs3 == 1)
            {
                solver.Add(y2 - y1 >= 0.06 * (1 - M1));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 2 && FUZZYs3 == 3)
            {
                solver.Add(y2 - y3 >= 0.06 * (1 - M1));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 2 && FUZZYs3 == 4)
            {
                solver.Add(y2 - y4 >= 0.06 * (1 - M1));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 2 && FUZZYs3 == 5)
            {
                solver.Add(y2 - y5 >= 0.06 * (1 - M1));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 2 && FUZZYs3 == 6)
            {
                solver.Add(y2 - y6 >= 0.06 * (1 - M1));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Highly important than g1,3-6
            else if (FUZZYs1 == 2 && FUZZYs2 == 3 && FUZZYs3 == 1)
            {
                solver.Add(y2 - y1 >= 0.11 * (1 - M1));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 3 && FUZZYs3 == 3)
            {
                solver.Add(y2 - y3 >= 0.11 * (1 - M1));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 3 && FUZZYs3 == 4)
            {
                solver.Add(y2 - y4 >= 0.11 * (1 - M1));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 3 && FUZZYs3 == 5)
            {
                solver.Add(y2 - y5 >= 0.11 * (1 - M1));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 3 && FUZZYs3 == 6)
            {
                solver.Add(y2 - y6 >= 0.11 * (1 - M1));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Absolutely important than g1,3-6
            else if (FUZZYs1 == 2 && FUZZYs2 == 4 && FUZZYs3 == 1)
            {
                solver.Add(y2 - y1 >= 0.16 * (1 - M1));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 4 && FUZZYs3 == 3)
            {
                solver.Add(y2 - y3 >= 0.16 * (1 - M1));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 4 && FUZZYs3 == 4)
            {
                solver.Add(y2 - y4 >= 0.16 * (1 - M1));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 4 && FUZZYs3 == 5)
            {
                solver.Add(y2 - y5 >= 0.16 * (1 - M1));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs1 == 2 && FUZZYs2 == 4 && FUZZYs3 == 6)
            {
                solver.Add(y2 - y6 >= 0.16 * (1 - M1));
                solver.Add(y2 - y6 >= 0);
            }
            //G3 slightly important than g1-2,4-6
            else if (FUZZYs1 == 3 && FUZZYs2 == 1 && FUZZYs3 == 1)
            {
                solver.Add(y3 - y1 >= 0.01 * (1 - M1));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 1 && FUZZYs3 == 2)
            {
                solver.Add(y3 - y2 >= 0.01 * (1 - M1));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 1 && FUZZYs3 == 4)
            {
                solver.Add(y3 - y4 >= 0.01 * (1 - M1));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 1 && FUZZYs3 == 5)
            {
                solver.Add(y3 - y5 >= 0.01 * (1 - M1));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 1 && FUZZYs3 == 6)
            {
                solver.Add(y3 - y6 >= 0.01 * (1 - M1));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Moderately important than g1-2,4-6
            else if (FUZZYs1 == 3 && FUZZYs2 == 2 && FUZZYs3 == 1)
            {
                solver.Add(y3 - y1 >= 0.06 * (1 - M1));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 2 && FUZZYs3 == 2)
            {
                solver.Add(y3 - y2 >= 0.06 * (1 - M1));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 2 && FUZZYs3 == 4)
            {
                solver.Add(y3 - y4 >= 0.06 * (1 - M1));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 2 && FUZZYs3 == 5)
            {
                solver.Add(y3 - y5 >= 0.06 * (1 - M1));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 2 && FUZZYs3 == 6)
            {
                solver.Add(y3 - y6 >= 0.06 * (1 - M1));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Highly important than g1-2,4-6
            else if (FUZZYs1 == 3 && FUZZYs2 == 3 && FUZZYs3 == 1)
            {
                solver.Add(y3 - y1 >= 0.11 * (1 - M1));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 3 && FUZZYs3 == 2)
            {
                solver.Add(y3 - y2 >= 0.11 * (1 - M1));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 3 && FUZZYs3 == 4)
            {
                solver.Add(y3 - y4 >= 0.11 * (1 - M1));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 3 && FUZZYs3 == 5)
            {
                solver.Add(y3 - y5 >= 0.11 * (1 - M1));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 3 && FUZZYs3 == 6)
            {
                solver.Add(y3 - y6 >= 0.11 * (1 - M1));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Abosolutely important than g1-2,4-6
            else if (FUZZYs1 == 3 && FUZZYs2 == 4 && FUZZYs3 == 1)
            {
                solver.Add(y3 - y1 >= 0.16 * (1 - M1));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 4 && FUZZYs3 == 2)
            {
                solver.Add(y3 - y2 >= 0.16 * (1 - M1));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 4 && FUZZYs3 == 4)
            {
                solver.Add(y3 - y4 >= 0.16 * (1 - M1));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 4 && FUZZYs3 == 5)
            {
                solver.Add(y3 - y5 >= 0.16 * (1 - M1));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs1 == 3 && FUZZYs2 == 4 && FUZZYs3 == 6)
            {
                solver.Add(y3 - y6 >= 0.16 * (1 - M1));
                solver.Add(y3 - y6 >= 0);
            }
            //G4 slightly important than g1-3,5-6
            else if (FUZZYs1 == 4 && FUZZYs2 == 1 && FUZZYs3 == 1)
            {
                solver.Add(y4 - y1 >= 0.01 * (1 - M1));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 1 && FUZZYs3 == 2)
            {
                solver.Add(y4 - y2 >= 0.01 * (1 - M1));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 1 && FUZZYs3 == 3)
            {
                solver.Add(y4 - y3 >= 0.01 * (1 - M1));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 1 && FUZZYs3 == 5)
            {
                solver.Add(y4 - y5 >= 0.01 * (1 - M1));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 1 && FUZZYs3 == 6)
            {
                solver.Add(y4 - y6 >= 0.01 * (1 - M1));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Moderately important than g1-3,5-6
            else if (FUZZYs1 == 4 && FUZZYs2 == 2 && FUZZYs3 == 1)
            {
                solver.Add(y4 - y1 >= 0.06 * (1 - M1));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 2 && FUZZYs3 == 2)
            {
                solver.Add(y4 - y2 >= 0.06 * (1 - M1));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 2 && FUZZYs3 == 3)
            {
                solver.Add(y4 - y3 >= 0.06 * (1 - M1));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 2 && FUZZYs3 == 5)
            {
                solver.Add(y4 - y5 >= 0.06 * (1 - M1));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 2 && FUZZYs3 == 6)
            {
                solver.Add(y4 - y6 >= 0.06 * (1 - M1));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Highly important than g1-3,5-6
            else if (FUZZYs1 == 4 && FUZZYs2 == 3 && FUZZYs3 == 1)
            {
                solver.Add(y4 - y1 >= 0.11 * (1 - M1));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 3 && FUZZYs3 == 2)
            {
                solver.Add(y4 - y2 >= 0.11 * (1 - M1));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 3 && FUZZYs3 == 3)
            {
                solver.Add(y4 - y3 >= 0.11 * (1 - M1));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 3 && FUZZYs3 == 5)
            {
                solver.Add(y4 - y5 >= 0.11 * (1 - M1));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 3 && FUZZYs3 == 6)
            {
                solver.Add(y4 - y6 >= 0.11 * (1 - M1));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Absolutely important than g1-3,5-6
            else if (FUZZYs1 == 4 && FUZZYs2 == 4 && FUZZYs3 == 1)
            {
                solver.Add(y4 - y1 >= 0.16 * (1 - M1));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 4 && FUZZYs3 == 2)
            {
                solver.Add(y4 - y2 >= 0.16 * (1 - M1));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 4 && FUZZYs3 == 3)
            {
                solver.Add(y4 - y3 >= 0.16 * (1 - M1));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 4 && FUZZYs3 == 5)
            {
                solver.Add(y4 - y5 >= 0.16 * (1 - M1));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs1 == 4 && FUZZYs2 == 4 && FUZZYs3 == 6)
            {
                solver.Add(y4 - y6 >= 0.16 * (1 - M1));
                solver.Add(y4 - y6 >= 0);
            }
            //G5 slightly important than g1-4,6
            else if (FUZZYs1 == 5 && FUZZYs2 == 1 && FUZZYs3 == 1)
            {
                solver.Add(y5 - y1 >= 0.01 * (1 - M1));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 1 && FUZZYs3 == 2)
            {
                solver.Add(y5 - y2 >= 0.01 * (1 - M1));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 1 && FUZZYs3 == 3)
            {
                solver.Add(y5 - y3 >= 0.01 * (1 - M1));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 1 && FUZZYs3 == 4)
            {
                solver.Add(y5 - y4 >= 0.01 * (1 - M1));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 1 && FUZZYs3 == 6)
            {
                solver.Add(y5 - y6 >= 0.01 * (1 - M1));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Moderatey important than g1-4,6
            else if (FUZZYs1 == 5 && FUZZYs2 == 2 && FUZZYs3 == 1)
            {
                solver.Add(y5 - y1 >= 0.06 * (1 - M1));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 2 && FUZZYs3 == 2)
            {
                solver.Add(y5 - y2 >= 0.06 * (1 - M1));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 2 && FUZZYs3 == 3)
            {
                solver.Add(y5 - y3 >= 0.06 * (1 - M1));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 2 && FUZZYs3 == 4)
            {
                solver.Add(y5 - y4 >= 0.06 * (1 - M1));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 2 && FUZZYs3 == 6)
            {
                solver.Add(y5 - y6 >= 0.06 * (1 - M1));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Highly important than g1-4,6
            else if (FUZZYs1 == 5 && FUZZYs2 == 3 && FUZZYs3 == 1)
            {
                solver.Add(y5 - y1 >= 0.11 * (1 - M1));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 3 && FUZZYs3 == 2)
            {
                solver.Add(y5 - y2 >= 0.11 * (1 - M1));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 3 && FUZZYs3 == 3)
            {
                solver.Add(y5 - y3 >= 0.11 * (1 - M1));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 3 && FUZZYs3 == 4)
            {
                solver.Add(y5 - y4 >= 0.11 * (1 - M1));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 3 && FUZZYs3 == 6)
            {
                solver.Add(y5 - y6 >= 0.11 * (1 - M1));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Absolutely important than g1-4,6
            else if (FUZZYs1 == 5 && FUZZYs2 == 4 && FUZZYs3 == 1)
            {
                solver.Add(y5 - y1 >= 0.16 * (1 - M1));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 4 && FUZZYs3 == 2)
            {
                solver.Add(y5 - y2 >= 0.16 * (1 - M1));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 4 && FUZZYs3 == 3)
            {
                solver.Add(y5 - y3 >= 0.16 * (1 - M1));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 4 && FUZZYs3 == 4)
            {
                solver.Add(y5 - y4 >= 0.16 * (1 - M1));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs1 == 5 && FUZZYs2 == 4 && FUZZYs3 == 6)
            {
                solver.Add(y5 - y6 >= 0.16 * (1 - M1));
                solver.Add(y5 - y6 >= 0);
            }
            //G6 slightly important than g1-5
            else if (FUZZYs1 == 6 && FUZZYs2 == 1 && FUZZYs3 == 1)
            {
                solver.Add(y6 - y1 >= 0.01 * (1 - M1));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 1 && FUZZYs3 == 2)
            {
                solver.Add(y6 - y2 >= 0.01 * (1 - M1));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 1 && FUZZYs3 == 3)
            {
                solver.Add(y6 - y3 >= 0.01 * (1 - M1));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 1 && FUZZYs3 == 4)
            {
                solver.Add(y6 - y4 >= 0.01 * (1 - M1));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 1 && FUZZYs3 == 5)
            {
                solver.Add(y6 - y5 >= 0.01 * (1 - M1));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Moderately important than g1-5
            else if (FUZZYs1 == 6 && FUZZYs2 == 2 && FUZZYs3 == 1)
            {
                solver.Add(y6 - y1 >= 0.06 * (1 - M1));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 2 && FUZZYs3 == 2)
            {
                solver.Add(y6 - y2 >= 0.06 * (1 - M1));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 2 && FUZZYs3 == 3)
            {
                solver.Add(y6 - y3 >= 0.06 * (1 - M1));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 2 && FUZZYs3 == 4)
            {
                solver.Add(y6 - y4 >= 0.06 * (1 - M1));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 2 && FUZZYs3 == 5)
            {
                solver.Add(y6 - y5 >= 0.06 * (1 - M1));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Highly important than g1-5
            else if (FUZZYs1 == 6 && FUZZYs2 == 3 && FUZZYs3 == 1)
            {
                solver.Add(y6 - y1 >= 0.11 * (1 - M1));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 3 && FUZZYs3 == 2)
            {
                solver.Add(y6 - y2 >= 0.11 * (1 - M1));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 3 && FUZZYs3 == 3)
            {
                solver.Add(y6 - y3 >= 0.11 * (1 - M1));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 3 && FUZZYs3 == 4)
            {
                solver.Add(y6 - y4 >= 0.11 * (1 - M1));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 3 && FUZZYs3 == 5)
            {
                solver.Add(y6 - y5 >= 0.11 * (1 - M1));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Absolutely important than g1-5
            else if (FUZZYs1 == 6 && FUZZYs2 == 4 && FUZZYs3 == 1)
            {
                solver.Add(y6 - y1 >= 0.16 * (1 - M1));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 4 && FUZZYs3 == 2)
            {
                solver.Add(y6 - y2 >= 0.16 * (1 - M1));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 4 && FUZZYs3 == 3)
            {
                solver.Add(y6 - y3 >= 0.16 * (1 - M1));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 4 && FUZZYs3 == 4)
            {
                solver.Add(y6 - y4 >= 0.16 * (1 - M1));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs1 == 6 && FUZZYs2 == 4 && FUZZYs3 == 5)
            {
                solver.Add(y6 - y5 >= 0.16 * (1 - M1));
                solver.Add(y6 - y5 >= 0);
            }

            //G1 slightly important than g2-6(FUZZYs2)
            if (FUZZYs4 == 1 && FUZZYs5 == 1 && FUZZYs6 == 2)
            {
                solver.Add(y1 - y2 >= 0.01 * (1 - M2));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 1 && FUZZYs6 == 3)
            {
                solver.Add(y1 - y3 >= 0.01 * (1 - M2));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 1 && FUZZYs6 == 4)
            {
                solver.Add(y1 - y4 >= 0.01 * (1 - M2));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 1 && FUZZYs6 == 5)
            {
                solver.Add(y1 - y5 >= 0.01 * (1 - M2));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 1 && FUZZYs6 == 6)
            {
                solver.Add(y1 - y6 >= 0.01 * (1 - M2));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Moderately important than g2-6
            else if (FUZZYs4 == 1 && FUZZYs5 == 2 && FUZZYs6 == 2)
            {
                solver.Add(y1 - y2 >= 0.06 * (1 - M2));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 2 && FUZZYs6 == 3)
            {
                solver.Add(y1 - y3 >= 0.06 * (1 - M2));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 2 && FUZZYs6 == 4)
            {
                solver.Add(y1 - y4 >= 0.06 * (1 - M2));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 2 && FUZZYs6 == 5)
            {
                solver.Add(y1 - y5 >= 0.06 * (1 - M2));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 2 && FUZZYs6 == 6)
            {
                solver.Add(y1 - y6 >= 0.06 * (1 - M2));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Highly important than g2-6
            else if (FUZZYs4 == 1 && FUZZYs5 == 3 && FUZZYs6 == 2)
            {
                solver.Add(y1 - y2 >= 0.11 * (1 - M2));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 3 && FUZZYs6 == 3)
            {
                solver.Add(y1 - y3 >= 0.11 * (1 - M2));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 3 && FUZZYs6 == 4)
            {
                solver.Add(y1 - y4 >= 0.11 * (1 - M2));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 3 && FUZZYs6 == 5)
            {
                solver.Add(y1 - y5 >= 0.11 * (1 - M2));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 3 && FUZZYs6 == 6)
            {
                solver.Add(y1 - y6 >= 0.11 * (1 - M2));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Absoltely important than g2-6
            else if (FUZZYs4 == 1 && FUZZYs5 == 4 && FUZZYs6 == 2)
            {
                solver.Add(y1 - y2 >= 0.16 * (1 - M2));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 4 && FUZZYs6 == 3)
            {
                solver.Add(y1 - y3 >= 0.16 * (1 - M2));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 4 && FUZZYs6 == 4)
            {
                solver.Add(y1 - y4 >= 0.16 * (1 - M2));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 4 && FUZZYs6 == 5)
            {
                solver.Add(y1 - y5 >= 0.16 * (1 - M2));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs4 == 1 && FUZZYs5 == 4 && FUZZYs6 == 6)
            {
                solver.Add(y1 - y6 >= 0.16 * (1 - M2));
                solver.Add(y1 - y6 >= 0);
            }
            //G2 slightly important than g1,3-6
            else if (FUZZYs4 == 2 && FUZZYs5 == 1 && FUZZYs6 == 1)
            {
                solver.Add(y2 - y1 >= 0.01 * (1 - M2));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 1 && FUZZYs6 == 3)
            {
                solver.Add(y2 - y3 >= 0.01 * (1 - M2));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 1 && FUZZYs6 == 4)
            {
                solver.Add(y2 - y4 >= 0.01 * (1 - M2));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 1 && FUZZYs6 == 5)
            {
                solver.Add(y2 - y5 >= 0.01 * (1 - M2));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 1 && FUZZYs6 == 6)
            {
                solver.Add(y2 - y6 >= 0.01 * (1 - M2));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Moderately important than g1,3-6
            else if (FUZZYs4 == 2 && FUZZYs5 == 2 && FUZZYs6 == 1)
            {
                solver.Add(y2 - y1 >= 0.06 * (1 - M2));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 2 && FUZZYs6 == 3)
            {
                solver.Add(y2 - y3 >= 0.06 * (1 - M2));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 2 && FUZZYs6 == 4)
            {
                solver.Add(y2 - y4 >= 0.06 * (1 - M2));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 2 && FUZZYs6 == 5)
            {
                solver.Add(y2 - y5 >= 0.06 * (1 - M2));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 2 && FUZZYs6 == 6)
            {
                solver.Add(y2 - y6 >= 0.06 * (1 - M2));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Highly important than g1,3-6
            else if (FUZZYs4 == 2 && FUZZYs5 == 3 && FUZZYs6 == 1)
            {
                solver.Add(y2 - y1 >= 0.11 * (1 - M2));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 3 && FUZZYs6 == 3)
            {
                solver.Add(y2 - y3 >= 0.11 * (1 - M2));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 3 && FUZZYs6 == 4)
            {
                solver.Add(y2 - y4 >= 0.11 * (1 - M2));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 3 && FUZZYs6 == 5)
            {
                solver.Add(y2 - y5 >= 0.11 * (1 - M2));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 3 && FUZZYs6 == 6)
            {
                solver.Add(y2 - y6 >= 0.11 * (1 - M2));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Absolutely important than g1,3-6
            else if (FUZZYs4 == 2 && FUZZYs5 == 4 && FUZZYs6 == 1)
            {
                solver.Add(y2 - y1 >= 0.16 * (1 - M2));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 4 && FUZZYs6 == 3)
            {
                solver.Add(y2 - y3 >= 0.16 * (1 - M2));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 4 && FUZZYs6 == 4)
            {
                solver.Add(y2 - y4 >= 0.16 * (1 - M2));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 4 && FUZZYs6 == 5)
            {
                solver.Add(y2 - y5 >= 0.16 * (1 - M2));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs4 == 2 && FUZZYs5 == 4 && FUZZYs6 == 6)
            {
                solver.Add(y2 - y6 >= 0.16 * (1 - M2));
                solver.Add(y2 - y6 >= 0);
            }
            //G3 slightly important than g1-2,4-6
            else if (FUZZYs4 == 3 && FUZZYs5 == 1 && FUZZYs6 == 1)
            {
                solver.Add(y3 - y1 >= 0.01 * (1 - M2));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 1 && FUZZYs6 == 2)
            {
                solver.Add(y3 - y2 >= 0.01 * (1 - M2));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 1 && FUZZYs6 == 4)
            {
                solver.Add(y3 - y4 >= 0.01 * (1 - M2));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 1 && FUZZYs6 == 5)
            {
                solver.Add(y3 - y5 >= 0.01 * (1 - M2));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 1 && FUZZYs6 == 6)
            {
                solver.Add(y3 - y6 >= 0.01 * (1 - M2));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Moderately important than g1-2,4-6
            else if (FUZZYs4 == 3 && FUZZYs5 == 2 && FUZZYs6 == 1)
            {
                solver.Add(y3 - y1 >= 0.06 * (1 - M2));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 2 && FUZZYs6 == 2)
            {
                solver.Add(y3 - y2 >= 0.06 * (1 - M2));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 2 && FUZZYs6 == 4)
            {
                solver.Add(y3 - y4 >= 0.06 * (1 - M2));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 2 && FUZZYs6 == 5)
            {
                solver.Add(y3 - y5 >= 0.06 * (1 - M2));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 2 && FUZZYs6 == 6)
            {
                solver.Add(y3 - y6 >= 0.06 * (1 - M2));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Highly important than g1-2,4-6
            else if (FUZZYs4 == 3 && FUZZYs5 == 3 && FUZZYs6 == 1)
            {
                solver.Add(y3 - y1 >= 0.11 * (1 - M2));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 3 && FUZZYs6 == 2)
            {
                solver.Add(y3 - y2 >= 0.11 * (1 - M2));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 3 && FUZZYs6 == 4)
            {
                solver.Add(y3 - y4 >= 0.11 * (1 - M2));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 3 && FUZZYs6 == 5)
            {
                solver.Add(y3 - y5 >= 0.11 * (1 - M2));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 3 && FUZZYs6 == 6)
            {
                solver.Add(y3 - y6 >= 0.11 * (1 - M2));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Abosolutely important than g1-2,4-6
            else if (FUZZYs4 == 3 && FUZZYs5 == 4 && FUZZYs6 == 1)
            {
                solver.Add(y3 - y1 >= 0.16 * (1 - M2));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 4 && FUZZYs6 == 2)
            {
                solver.Add(y3 - y2 >= 0.16 * (1 - M2));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 4 && FUZZYs6 == 4)
            {
                solver.Add(y3 - y4 >= 0.16 * (1 - M2));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 4 && FUZZYs6 == 5)
            {
                solver.Add(y3 - y5 >= 0.16 * (1 - M2));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs4 == 3 && FUZZYs5 == 4 && FUZZYs6 == 6)
            {
                solver.Add(y3 - y6 >= 0.16 * (1 - M2));
                solver.Add(y3 - y6 >= 0);
            }
            //G4 slightly important than g1-3,5-6
            else if (FUZZYs4 == 4 && FUZZYs5 == 1 && FUZZYs6 == 1)
            {
                solver.Add(y4 - y1 >= 0.01 * (1 - M2));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 1 && FUZZYs6 == 2)
            {
                solver.Add(y4 - y2 >= 0.01 * (1 - M2));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 1 && FUZZYs6 == 3)
            {
                solver.Add(y4 - y3 >= 0.01 * (1 - M2));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 1 && FUZZYs6 == 5)
            {
                solver.Add(y4 - y5 >= 0.01 * (1 - M2));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 1 && FUZZYs6 == 6)
            {
                solver.Add(y4 - y6 >= 0.01 * (1 - M2));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Moderately important than g1-3,5-6
            else if (FUZZYs4 == 4 && FUZZYs5 == 2 && FUZZYs6 == 1)
            {
                solver.Add(y4 - y1 >= 0.06 * (1 - M2));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 2 && FUZZYs6 == 2)
            {
                solver.Add(y4 - y2 >= 0.06 * (1 - M2));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 2 && FUZZYs6 == 3)
            {
                solver.Add(y4 - y3 >= 0.06 * (1 - M2));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 2 && FUZZYs6 == 5)
            {
                solver.Add(y4 - y5 >= 0.06 * (1 - M2));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 2 && FUZZYs6 == 6)
            {
                solver.Add(y4 - y6 >= 0.06 * (1 - M2));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Highly important than g1-3,5-6
            else if (FUZZYs4 == 4 && FUZZYs5 == 3 && FUZZYs6 == 1)
            {
                solver.Add(y4 - y1 >= 0.11 * (1 - M2));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 3 && FUZZYs6 == 2)
            {
                solver.Add(y4 - y2 >= 0.11 * (1 - M2));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 3 && FUZZYs6 == 3)
            {
                solver.Add(y4 - y3 >= 0.11 * (1 - M2));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 3 && FUZZYs6 == 5)
            {
                solver.Add(y4 - y5 >= 0.11 * (1 - M2));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 3 && FUZZYs6 == 6)
            {
                solver.Add(y4 - y6 >= 0.11 * (1 - M2));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Absolutely important than g1-3,5-6
            else if (FUZZYs4 == 4 && FUZZYs5 == 4 && FUZZYs6 == 1)
            {
                solver.Add(y4 - y1 >= 0.16 * (1 - M2));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 4 && FUZZYs6 == 2)
            {
                solver.Add(y4 - y2 >= 0.16 * (1 - M2));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 4 && FUZZYs6 == 3)
            {
                solver.Add(y4 - y3 >= 0.16 * (1 - M2));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 4 && FUZZYs6 == 5)
            {
                solver.Add(y4 - y5 >= 0.16 * (1 - M2));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs4 == 4 && FUZZYs5 == 4 && FUZZYs6 == 6)
            {
                solver.Add(y4 - y6 >= 0.16 * (1 - M2));
                solver.Add(y4 - y6 >= 0);
            }
            //G5 slightly important than g1-4,6
            else if (FUZZYs4 == 5 && FUZZYs5 == 1 && FUZZYs6 == 1)
            {
                solver.Add(y5 - y1 >= 0.01 * (1 - M2));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 1 && FUZZYs6 == 2)
            {
                solver.Add(y5 - y2 >= 0.01 * (1 - M2));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 1 && FUZZYs6 == 3)
            {
                solver.Add(y5 - y3 >= 0.01 * (1 - M2));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 1 && FUZZYs6 == 4)
            {
                solver.Add(y5 - y4 >= 0.01 * (1 - M2));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 1 && FUZZYs6 == 6)
            {
                solver.Add(y5 - y6 >= 0.01 * (1 - M2));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Moderatey important than g1-4,6
            else if (FUZZYs4 == 5 && FUZZYs5 == 2 && FUZZYs6 == 1)
            {
                solver.Add(y5 - y1 >= 0.06 * (1 - M2));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 2 && FUZZYs6 == 2)
            {
                solver.Add(y5 - y2 >= 0.06 * (1 - M2));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 2 && FUZZYs6 == 3)
            {
                solver.Add(y5 - y3 >= 0.06 * (1 - M2));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 2 && FUZZYs6 == 4)
            {
                solver.Add(y5 - y4 >= 0.06 * (1 - M2));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 2 && FUZZYs6 == 6)
            {
                solver.Add(y5 - y6 >= 0.06 * (1 - M2));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Highly important than g1-4,6
            else if (FUZZYs4 == 5 && FUZZYs5 == 3 && FUZZYs6 == 1)
            {
                solver.Add(y5 - y1 >= 0.11 * (1 - M2));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 3 && FUZZYs6 == 2)
            {
                solver.Add(y5 - y2 >= 0.11 * (1 - M2));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 3 && FUZZYs6 == 3)
            {
                solver.Add(y5 - y3 >= 0.11 * (1 - M2));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 3 && FUZZYs6 == 4)
            {
                solver.Add(y5 - y4 >= 0.11 * (1 - M2));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 3 && FUZZYs6 == 6)
            {
                solver.Add(y5 - y6 >= 0.11 * (1 - M2));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Absolutely important than g1-4,6
            else if (FUZZYs4 == 5 && FUZZYs5 == 4 && FUZZYs6 == 1)
            {
                solver.Add(y5 - y1 >= 0.16 * (1 - M2));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 4 && FUZZYs6 == 2)
            {
                solver.Add(y5 - y2 >= 0.16 * (1 - M2));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 4 && FUZZYs6 == 3)
            {
                solver.Add(y5 - y3 >= 0.16 * (1 - M2));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 4 && FUZZYs6 == 4)
            {
                solver.Add(y5 - y4 >= 0.16 * (1 - M2));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs4 == 5 && FUZZYs5 == 4 && FUZZYs6 == 6)
            {
                solver.Add(y5 - y6 >= 0.16 * (1 - M2));
                solver.Add(y5 - y6 >= 0);
            }
            //G6 slightly important than g1-5
            else if (FUZZYs4 == 6 && FUZZYs5 == 1 && FUZZYs6 == 1)
            {
                solver.Add(y6 - y1 >= 0.01 * (1 - M2));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 1 && FUZZYs6 == 2)
            {
                solver.Add(y6 - y2 >= 0.01 * (1 - M2));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 1 && FUZZYs6 == 3)
            {
                solver.Add(y6 - y3 >= 0.01 * (1 - M2));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 1 && FUZZYs6 == 4)
            {
                solver.Add(y6 - y4 >= 0.01 * (1 - M2));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 1 && FUZZYs6 == 5)
            {
                solver.Add(y6 - y5 >= 0.01 * (1 - M2));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Moderately important than g1-5
            else if (FUZZYs4 == 6 && FUZZYs5 == 2 && FUZZYs6 == 1)
            {
                solver.Add(y6 - y1 >= 0.06 * (1 - M2));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 2 && FUZZYs6 == 2)
            {
                solver.Add(y6 - y2 >= 0.06 * (1 - M2));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 2 && FUZZYs6 == 3)
            {
                solver.Add(y6 - y3 >= 0.06 * (1 - M2));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 2 && FUZZYs6 == 4)
            {
                solver.Add(y6 - y4 >= 0.06 * (1 - M2));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 2 && FUZZYs6 == 5)
            {
                solver.Add(y6 - y5 >= 0.06 * (1 - M2));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Highly important than g1-5
            else if (FUZZYs4 == 6 && FUZZYs5 == 3 && FUZZYs6 == 1)
            {
                solver.Add(y6 - y1 >= 0.11 * (1 - M2));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 3 && FUZZYs6 == 2)
            {
                solver.Add(y6 - y2 >= 0.11 * (1 - M2));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 3 && FUZZYs6 == 3)
            {
                solver.Add(y6 - y3 >= 0.11 * (1 - M2));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 3 && FUZZYs6 == 4)
            {
                solver.Add(y6 - y4 >= 0.11 * (1 - M2));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 3 && FUZZYs6 == 5)
            {
                solver.Add(y6 - y5 >= 0.11 * (1 - M2));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Absolutely important than g1-5
            else if (FUZZYs4 == 6 && FUZZYs5 == 4 && FUZZYs6 == 1)
            {
                solver.Add(y6 - y1 >= 0.16 * (1 - M2));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 4 && FUZZYs6 == 2)
            {
                solver.Add(y6 - y2 >= 0.16 * (1 - M2));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 4 && FUZZYs6 == 3)
            {
                solver.Add(y6 - y3 >= 0.16 * (1 - M2));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 4 && FUZZYs6 == 4)
            {
                solver.Add(y6 - y4 >= 0.16 * (1 - M2));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs4 == 6 && FUZZYs5 == 4 && FUZZYs6 == 5)
            {
                solver.Add(y6 - y5 >= 0.16 * (1 - M2));
                solver.Add(y6 - y5 >= 0);
            }

            //G1 slightly important than g2-6(FUZZYs3)
            if (FUZZYs7 == 1 && FUZZYs8 == 1 && FUZZYs9 == 2)
            {
                solver.Add(y1 - y2 >= 0.01 * (1 - M3));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 1 && FUZZYs9 == 3)
            {
                solver.Add(y1 - y3 >= 0.01 * (1 - M3));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 1 && FUZZYs9 == 4)
            {
                solver.Add(y1 - y4 >= 0.01 * (1 - M3));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 1 && FUZZYs9 == 5)
            {
                solver.Add(y1 - y5 >= 0.01 * (1 - M3));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 1 && FUZZYs9 == 6)
            {
                solver.Add(y1 - y6 >= 0.01 * (1 - M3));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Moderately important than g2-6
            else if (FUZZYs7 == 1 && FUZZYs8 == 2 && FUZZYs9 == 2)
            {
                solver.Add(y1 - y2 >= 0.06 * (1 - M3));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 2 && FUZZYs9 == 3)
            {
                solver.Add(y1 - y3 >= 0.06 * (1 - M3));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 2 && FUZZYs9 == 4)
            {
                solver.Add(y1 - y4 >= 0.06 * (1 - M3));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 2 && FUZZYs9 == 5)
            {
                solver.Add(y1 - y5 >= 0.06 * (1 - M3));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 2 && FUZZYs9 == 6)
            {
                solver.Add(y1 - y6 >= 0.06 * (1 - M3));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Highly important than g2-6
            else if (FUZZYs7 == 1 && FUZZYs8 == 3 && FUZZYs9 == 2)
            {
                solver.Add(y1 - y2 >= 0.11 * (1 - M3));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 3 && FUZZYs9 == 3)
            {
                solver.Add(y1 - y3 >= 0.11 * (1 - M3));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 3 && FUZZYs9 == 4)
            {
                solver.Add(y1 - y4 >= 0.11 * (1 - M3));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 3 && FUZZYs9 == 5)
            {
                solver.Add(y1 - y5 >= 0.11 * (1 - M3));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 3 && FUZZYs9 == 6)
            {
                solver.Add(y1 - y6 >= 0.11 * (1 - M3));
                solver.Add(y1 - y6 >= 0);
            }
            //G1 Absoltely important than g2-6
            else if (FUZZYs7 == 1 && FUZZYs8 == 4 && FUZZYs9 == 2)
            {
                solver.Add(y1 - y2 >= 0.16 * (1 - M3));
                solver.Add(y1 - y2 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 4 && FUZZYs9 == 3)
            {
                solver.Add(y1 - y3 >= 0.16 * (1 - M3));
                solver.Add(y1 - y3 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 4 && FUZZYs9 == 4)
            {
                solver.Add(y1 - y4 >= 0.16 * (1 - M3));
                solver.Add(y1 - y4 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 4 && FUZZYs9 == 5)
            {
                solver.Add(y1 - y5 >= 0.16 * (1 - M3));
                solver.Add(y1 - y5 >= 0);
            }
            else if (FUZZYs7 == 1 && FUZZYs8 == 4 && FUZZYs9 == 6)
            {
                solver.Add(y1 - y6 >= 0.16 * (1 - M3));
                solver.Add(y1 - y6 >= 0);
            }
            //G2 slightly important than g1,3-6
            else if (FUZZYs7 == 2 && FUZZYs8 == 1 && FUZZYs9 == 1)
            {
                solver.Add(y2 - y1 >= 0.01 * (1 - M3));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 1 && FUZZYs9 == 3)
            {
                solver.Add(y2 - y3 >= 0.01 * (1 - M3));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 1 && FUZZYs9 == 4)
            {
                solver.Add(y2 - y4 >= 0.01 * (1 - M3));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 1 && FUZZYs9 == 5)
            {
                solver.Add(y2 - y5 >= 0.01 * (1 - M3));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 1 && FUZZYs9 == 6)
            {
                solver.Add(y2 - y6 >= 0.01 * (1 - M3));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Moderately important than g1,3-6
            else if (FUZZYs7 == 2 && FUZZYs8 == 2 && FUZZYs9 == 1)
            {
                solver.Add(y2 - y1 >= 0.06 * (1 - M3));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 2 && FUZZYs9 == 3)
            {
                solver.Add(y2 - y3 >= 0.06 * (1 - M3));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 2 && FUZZYs9 == 4)
            {
                solver.Add(y2 - y4 >= 0.06 * (1 - M3));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 2 && FUZZYs9 == 5)
            {
                solver.Add(y2 - y5 >= 0.06 * (1 - M3));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 2 && FUZZYs9 == 6)
            {
                solver.Add(y2 - y6 >= 0.06 * (1 - M3));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Highly important than g1,3-6
            else if (FUZZYs7 == 2 && FUZZYs8 == 3 && FUZZYs9 == 1)
            {
                solver.Add(y2 - y1 >= 0.11 * (1 - M3));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 3 && FUZZYs9 == 3)
            {
                solver.Add(y2 - y3 >= 0.11 * (1 - M3));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 3 && FUZZYs9 == 4)
            {
                solver.Add(y2 - y4 >= 0.11 * (1 - M3));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 3 && FUZZYs9 == 5)
            {
                solver.Add(y2 - y5 >= 0.11 * (1 - M3));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 3 && FUZZYs9 == 6)
            {
                solver.Add(y2 - y6 >= 0.11 * (1 - M3));
                solver.Add(y2 - y6 >= 0);
            }
            //G2 Absolutely important than g1,3-6
            else if (FUZZYs7 == 2 && FUZZYs8 == 4 && FUZZYs9 == 1)
            {
                solver.Add(y2 - y1 >= 0.16 * (1 - M3));
                solver.Add(y2 - y1 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 4 && FUZZYs9 == 3)
            {
                solver.Add(y2 - y3 >= 0.16 * (1 - M3));
                solver.Add(y2 - y3 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 4 && FUZZYs9 == 4)
            {
                solver.Add(y2 - y4 >= 0.16 * (1 - M3));
                solver.Add(y2 - y4 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 4 && FUZZYs9 == 5)
            {
                solver.Add(y2 - y5 >= 0.16 * (1 - M3));
                solver.Add(y2 - y5 >= 0);
            }
            else if (FUZZYs7 == 2 && FUZZYs8 == 4 && FUZZYs9 == 6)
            {
                solver.Add(y2 - y6 >= 0.16 * (1 - M3));
                solver.Add(y2 - y6 >= 0);
            }
            //G3 slightly important than g1-2,4-6
            else if (FUZZYs7 == 3 && FUZZYs8 == 1 && FUZZYs9 == 1)
            {
                solver.Add(y3 - y1 >= 0.01 * (1 - M3));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 1 && FUZZYs9 == 2)
            {
                solver.Add(y3 - y2 >= 0.01 * (1 - M3));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 1 && FUZZYs9 == 4)
            {
                solver.Add(y3 - y4 >= 0.01 * (1 - M3));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 1 && FUZZYs9 == 5)
            {
                solver.Add(y3 - y5 >= 0.01 * (1 - M3));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 1 && FUZZYs9 == 6)
            {
                solver.Add(y3 - y6 >= 0.01 * (1 - M3));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Moderately important than g1-2,4-6
            else if (FUZZYs7 == 3 && FUZZYs8 == 2 && FUZZYs9 == 1)
            {
                solver.Add(y3 - y1 >= 0.06 * (1 - M3));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 2 && FUZZYs9 == 2)
            {
                solver.Add(y3 - y2 >= 0.06 * (1 - M3));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 2 && FUZZYs9 == 4)
            {
                solver.Add(y3 - y4 >= 0.06 * (1 - M3));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 2 && FUZZYs9 == 5)
            {
                solver.Add(y3 - y5 >= 0.06 * (1 - M3));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 2 && FUZZYs9 == 6)
            {
                solver.Add(y3 - y6 >= 0.06 * (1 - M3));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Highly important than g1-2,4-6
            else if (FUZZYs7 == 3 && FUZZYs8 == 3 && FUZZYs9 == 1)
            {
                solver.Add(y3 - y1 >= 0.11 * (1 - M3));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 3 && FUZZYs9 == 2)
            {
                solver.Add(y3 - y2 >= 0.11 * (1 - M3));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 3 && FUZZYs9 == 4)
            {
                solver.Add(y3 - y4 >= 0.11 * (1 - M3));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 3 && FUZZYs9 == 5)
            {
                solver.Add(y3 - y5 >= 0.11 * (1 - M3));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 3 && FUZZYs9 == 6)
            {
                solver.Add(y3 - y6 >= 0.11 * (1 - M3));
                solver.Add(y3 - y6 >= 0);
            }
            //G3 Abosolutely important than g1-2,4-6
            else if (FUZZYs7 == 3 && FUZZYs8 == 4 && FUZZYs9 == 1)
            {
                solver.Add(y3 - y1 >= 0.16 * (1 - M3));
                solver.Add(y3 - y1 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 4 && FUZZYs9 == 2)
            {
                solver.Add(y3 - y2 >= 0.16 * (1 - M3));
                solver.Add(y3 - y2 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 4 && FUZZYs9 == 4)
            {
                solver.Add(y3 - y4 >= 0.16 * (1 - M3));
                solver.Add(y3 - y4 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 4 && FUZZYs9 == 5)
            {
                solver.Add(y3 - y5 >= 0.16 * (1 - M3));
                solver.Add(y3 - y5 >= 0);
            }
            else if (FUZZYs7 == 3 && FUZZYs8 == 4 && FUZZYs9 == 6)
            {
                solver.Add(y3 - y6 >= 0.16 * (1 - M3));
                solver.Add(y3 - y6 >= 0);
            }
            //G4 slightly important than g1-3,5-6
            else if (FUZZYs7 == 4 && FUZZYs8 == 1 && FUZZYs9 == 1)
            {
                solver.Add(y4 - y1 >= 0.01 * (1 - M3));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 1 && FUZZYs9 == 2)
            {
                solver.Add(y4 - y2 >= 0.01 * (1 - M3));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 1 && FUZZYs9 == 3)
            {
                solver.Add(y4 - y3 >= 0.01 * (1 - M3));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 1 && FUZZYs9 == 5)
            {
                solver.Add(y4 - y5 >= 0.01 * (1 - M3));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 1 && FUZZYs9 == 6)
            {
                solver.Add(y4 - y6 >= 0.01 * (1 - M3));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Moderately important than g1-3,5-6
            else if (FUZZYs7 == 4 && FUZZYs8 == 2 && FUZZYs9 == 1)
            {
                solver.Add(y4 - y1 >= 0.06 * (1 - M3));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 2 && FUZZYs9 == 2)
            {
                solver.Add(y4 - y2 >= 0.06 * (1 - M3));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 2 && FUZZYs9 == 3)
            {
                solver.Add(y4 - y3 >= 0.06 * (1 - M3));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 2 && FUZZYs9 == 5)
            {
                solver.Add(y4 - y5 >= 0.06 * (1 - M3));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 2 && FUZZYs9 == 6)
            {
                solver.Add(y4 - y6 >= 0.06 * (1 - M3));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Highly important than g1-3,5-6
            else if (FUZZYs7 == 4 && FUZZYs8 == 3 && FUZZYs9 == 1)
            {
                solver.Add(y4 - y1 >= 0.11 * (1 - M3));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 3 && FUZZYs9 == 2)
            {
                solver.Add(y4 - y2 >= 0.11 * (1 - M3));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 3 && FUZZYs9 == 3)
            {
                solver.Add(y4 - y3 >= 0.11 * (1 - M3));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 3 && FUZZYs9 == 5)
            {
                solver.Add(y4 - y5 >= 0.11 * (1 - M3));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 3 && FUZZYs9 == 6)
            {
                solver.Add(y4 - y6 >= 0.11 * (1 - M3));
                solver.Add(y4 - y6 >= 0);
            }
            //G4 Absolutely important than g1-3,5-6
            else if (FUZZYs7 == 4 && FUZZYs8 == 4 && FUZZYs9 == 1)
            {
                solver.Add(y4 - y1 >= 0.16 * (1 - M3));
                solver.Add(y4 - y1 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 4 && FUZZYs9 == 2)
            {
                solver.Add(y4 - y2 >= 0.16 * (1 - M3));
                solver.Add(y4 - y2 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 4 && FUZZYs9 == 3)
            {
                solver.Add(y4 - y3 >= 0.16 * (1 - M3));
                solver.Add(y4 - y3 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 4 && FUZZYs9 == 5)
            {
                solver.Add(y4 - y5 >= 0.16 * (1 - M3));
                solver.Add(y4 - y5 >= 0);
            }
            else if (FUZZYs7 == 4 && FUZZYs8 == 4 && FUZZYs9 == 6)
            {
                solver.Add(y4 - y6 >= 0.16 * (1 - M3));
                solver.Add(y4 - y6 >= 0);
            }
            //G5 slightly important than g1-4,6
            else if (FUZZYs7 == 5 && FUZZYs8 == 1 && FUZZYs9 == 1)
            {
                solver.Add(y5 - y1 >= 0.01 * (1 - M3));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 1 && FUZZYs9 == 2)
            {
                solver.Add(y5 - y2 >= 0.01 * (1 - M3));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 1 && FUZZYs9 == 3)
            {
                solver.Add(y5 - y3 >= 0.01 * (1 - M3));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 1 && FUZZYs9 == 4)
            {
                solver.Add(y5 - y4 >= 0.01 * (1 - M3));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 1 && FUZZYs9 == 6)
            {
                solver.Add(y5 - y6 >= 0.01 * (1 - M3));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Moderatey important than g1-4,6
            else if (FUZZYs7 == 5 && FUZZYs8 == 2 && FUZZYs9 == 1)
            {
                solver.Add(y5 - y1 >= 0.06 * (1 - M3));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 2 && FUZZYs9 == 2)
            {
                solver.Add(y5 - y2 >= 0.06 * (1 - M3));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 2 && FUZZYs9 == 3)
            {
                solver.Add(y5 - y3 >= 0.06 * (1 - M3));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 2 && FUZZYs9 == 4)
            {
                solver.Add(y5 - y4 >= 0.06 * (1 - M3));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 2 && FUZZYs9 == 6)
            {
                solver.Add(y5 - y6 >= 0.06 * (1 - M3));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Highly important than g1-4,6
            else if (FUZZYs7 == 5 && FUZZYs8 == 3 && FUZZYs9 == 1)
            {
                solver.Add(y5 - y1 >= 0.11 * (1 - M3));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 3 && FUZZYs9 == 2)
            {
                solver.Add(y5 - y2 >= 0.11 * (1 - M3));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 3 && FUZZYs9 == 3)
            {
                solver.Add(y5 - y3 >= 0.11 * (1 - M3));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 3 && FUZZYs9 == 4)
            {
                solver.Add(y5 - y4 >= 0.11 * (1 - M3));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 3 && FUZZYs9 == 6)
            {
                solver.Add(y5 - y6 >= 0.11 * (1 - M3));
                solver.Add(y5 - y6 >= 0);
            }
            //G5 Absolutely important than g1-4,6
            else if (FUZZYs7 == 5 && FUZZYs8 == 4 && FUZZYs9 == 1)
            {
                solver.Add(y5 - y1 >= 0.16 * (1 - M3));
                solver.Add(y5 - y1 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 4 && FUZZYs9 == 2)
            {
                solver.Add(y5 - y2 >= 0.16 * (1 - M3));
                solver.Add(y5 - y2 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 4 && FUZZYs9 == 3)
            {
                solver.Add(y5 - y3 >= 0.16 * (1 - M3));
                solver.Add(y5 - y3 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 4 && FUZZYs9 == 4)
            {
                solver.Add(y5 - y4 >= 0.16 * (1 - M3));
                solver.Add(y5 - y4 >= 0);
            }
            else if (FUZZYs7 == 5 && FUZZYs8 == 4 && FUZZYs9 == 6)
            {
                solver.Add(y5 - y6 >= 0.16 * (1 - M3));
                solver.Add(y5 - y6 >= 0);
            }
            //G6 slightly important than g1-5
            else if (FUZZYs7 == 6 && FUZZYs8 == 1 && FUZZYs9 == 1)
            {
                solver.Add(y6 - y1 >= 0.01 * (1 - M3));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 1 && FUZZYs9 == 2)
            {
                solver.Add(y6 - y2 >= 0.01 * (1 - M3));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 1 && FUZZYs9 == 3)
            {
                solver.Add(y6 - y3 >= 0.01 * (1 - M3));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 1 && FUZZYs9 == 4)
            {
                solver.Add(y6 - y4 >= 0.01 * (1 - M3));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 1 && FUZZYs9 == 5)
            {
                solver.Add(y6 - y5 >= 0.01 * (1 - M3));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Moderately important than g1-5
            else if (FUZZYs7 == 6 && FUZZYs8 == 2 && FUZZYs9 == 1)
            {
                solver.Add(y6 - y1 >= 0.06 * (1 - M3));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 2 && FUZZYs9 == 2)
            {
                solver.Add(y6 - y2 >= 0.06 * (1 - M3));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 2 && FUZZYs9 == 3)
            {
                solver.Add(y6 - y3 >= 0.06 * (1 - M3));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 2 && FUZZYs9 == 4)
            {
                solver.Add(y6 - y4 >= 0.06 * (1 - M3));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 2 && FUZZYs9 == 5)
            {
                solver.Add(y6 - y5 >= 0.06 * (1 - M3));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Highly important than g1-5
            else if (FUZZYs7 == 6 && FUZZYs8 == 3 && FUZZYs9 == 1)
            {
                solver.Add(y6 - y1 >= 0.11 * (1 - M3));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 3 && FUZZYs9 == 2)
            {
                solver.Add(y6 - y2 >= 0.11 * (1 - M3));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 3 && FUZZYs9 == 3)
            {
                solver.Add(y6 - y3 >= 0.11 * (1 - M3));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 3 && FUZZYs9 == 4)
            {
                solver.Add(y6 - y4 >= 0.11 * (1 - M3));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 3 && FUZZYs9 == 5)
            {
                solver.Add(y6 - y5 >= 0.11 * (1 - M3));
                solver.Add(y6 - y5 >= 0);
            }
            //G6 Absolutely important than g1-5
            else if (FUZZYs7 == 6 && FUZZYs8 == 4 && FUZZYs9 == 1)
            {
                solver.Add(y6 - y1 >= 0.16 * (1 - M3));
                solver.Add(y6 - y1 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 4 && FUZZYs9 == 2)
            {
                solver.Add(y6 - y2 >= 0.16 * (1 - M3));
                solver.Add(y6 - y2 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 4 && FUZZYs9 == 3)
            {
                solver.Add(y6 - y3 >= 0.16 * (1 - M3));
                solver.Add(y6 - y3 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 4 && FUZZYs9 == 4)
            {
                solver.Add(y6 - y4 >= 0.16 * (1 - M3));
                solver.Add(y6 - y4 >= 0);
            }
            else if (FUZZYs7 == 6 && FUZZYs8 == 4 && FUZZYs9 == 5)
            {
                solver.Add(y6 - y5 >= 0.16 * (1 - M3));
                solver.Add(y6 - y5 >= 0);
            }




            //Response.Write("Number of variables = " + solver.NumVariables()+ "\n");
            //Response.Write("Number of constraints = " + solver.NumConstraints()+ "\n");

            // Minimize x + 10 * y.
            solver.Minimize(d1n + d1p + d2n + d2p + d3n + d3p + d4n + d4p + d5n + d5p + d6n + d6p + e1p + e1n + e2p + e2n + e3p + e3n + e4p + e4n + e5p + e5n + e6p + e6n + M1 + M2 + M3);

            int resultStatus = solver.Solve();
            

            // Check that the problem has an optimal solution.
            if (resultStatus != Solver.OPTIMAL)
            {
                Response.Write("The problem does not have an optimal solution!");
            }
            //Response.Write("Solution:");
            //Response.Write("Objective value = " + solver.Objective().Value());
            //Response.Write("d1n = " + d1n.SolutionValue());
            //Response.Write("d1p = " + d1p.SolutionValue());
            //Response.Write("x1 = " + x1.SolutionValue()+ "\n");
            //Response.Write("x2 = " + x2.SolutionValue() + "\n");
            //Response.Write("x3 = " + x3.SolutionValue() + "\n");
            //Response.Write("x4 = " + x4.SolutionValue() + "\n");
            //Response.Write("x5 = " + x5.SolutionValue() + "\n");
            //Response.Write("x6 = " + x6.SolutionValue() + "\n");
            //Response.Write("x7 = " + x7.SolutionValue() + "\n");
            //Response.Write("x8 = " + x8.SolutionValue() + "\n");
            //Response.Write("x9 = " + x9.SolutionValue() + "\n");
            ViewBag.G1=g1.SolutionValue();
            ViewBag.G2 = g2.SolutionValue();
            ViewBag.G3 = g3.SolutionValue();
            ViewBag.G4 = g4.SolutionValue();
            ViewBag.G5 = g5.SolutionValue();
            ViewBag.G6 = g6.SolutionValue();


            if (x1.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexCT");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexCT", "TDSSRESULT");
            }
            else if (x2.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexPT");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexPT", "TDSSRESULT");
            }
            else if (x3.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexAT");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexAT", "TDSSRESULT");
            }
            else if (x4.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexESWT");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexESWT", "TDSSRESULT");
            }
            else if (x5.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexHA");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexHAEN", "TDSSRESULT");
            }
            else if (x6.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexPRP");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexPRP", "TDSSRESULT");
            }
            else if (x7.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexSI");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexSI", "TDSSRESULT");
            }
            else if (x8.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexNTKA");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexNTKA", "TDSSRESULT");
            }
            else if (x9.SolutionValue() == 1)
            {
                //Response.Redirect("~/TDSSRESULT/IndexTKA");
                TempData["g1r"] = g1.SolutionValue() * 100;
                TempData["g2r"] = g2.SolutionValue() * 100;
                TempData["g3r"] = g3.SolutionValue() * 100;
                TempData["g4r"] = g4.SolutionValue() * 100;
                TempData["g5r"] = g5.SolutionValue() * 100;
                TempData["g6r"] = g6.SolutionValue() * 100;
                return RedirectToAction("IndexTKA", "TDSSRESULT");
            }
            else 
            {
                return RedirectToAction("IndexERROR", "TDSSRESULT");
            }

            //Response.Write("\nAdvanced usage:");
            //Response.Write("Problem solved in " + solver.WallTime() + " milliseconds");
            //Response.Write("Problem solved in " + solver.Iterations() + " iterations");
            //Response.Write("Problem solved in " + solver.Nodes() + " branch-and-bound nodes");
            return View();
        }
        /*static void Main(FormCollection post)
        {
            // Create the linear solver with the SCIP backend.
            Solver solver = Solver.CreateSolver("AHPMCGPOAknee", "CBC_MIXED_INTEGER_PROGRAMMING");
            if (solver is null)
            {
                return;
            }

            // x and y are integer non-negative variables.
            Variable x = solver.MakeIntVar(0.0, double.PositiveInfinity, "x");
            Variable y = solver.MakeIntVar(0.0, double.PositiveInfinity, "y");

            Console.WriteLine("Number of variables = " + solver.NumVariables());

            // x + 7 * y <= 17.5.
            solver.Add(x + 7 * y <= 17.5);

            // x <= 3.5.
            solver.Add(x <= 3.5);

            Console.WriteLine("Number of constraints = " + solver.NumConstraints());

            // Maximize x + 10 * y.
            solver.Maximize(x + 10 * y);

            int resultStatus = solver.Solve();

            // Check that the problem has an optimal solution.
            if (resultStatus != Solver.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return;
            }
            Console.WriteLine("Solution:");
            Console.WriteLine("Objective value = " + solver.Objective().Value());
            Console.WriteLine("x = " + x.SolutionValue());
            Console.WriteLine("y = " + y.SolutionValue());

            Console.WriteLine("\nAdvanced usage:");
            Console.WriteLine("Problem solved in " + solver.WallTime() + " milliseconds");
            Console.WriteLine("Problem solved in " + solver.Iterations() + " iterations");
            Console.WriteLine("Problem solved in " + solver.Nodes() + " branch-and-bound nodes");
        }*/

    }
    /*public class SimpleMipProgram
    {
        static void Main(FormCollection post)
        {
            // Create the linear solver with the SCIP backend.
            Solver solver = Solver.CreateSolver("AHPMCGPOAknee","CBC_MIXED_INTEGER_PROGRAMMING");
            if (solver is null)
            {
                return;
            }

            // x and y are integer non-negative variables.
            Variable x = solver.MakeIntVar(0.0, double.PositiveInfinity, "x");
            Variable y = solver.MakeIntVar(0.0, double.PositiveInfinity, "y");

            Console.WriteLine("Number of variables = " + solver.NumVariables());

            // x + 7 * y <= 17.5.
            solver.Add(x + 7 * y <= 17.5);

            // x <= 3.5.
            solver.Add(x <= 3.5);

            Console.WriteLine("Number of constraints = " + solver.NumConstraints());

            // Maximize x + 10 * y.
            solver.Maximize(x + 10 * y);

            int resultStatus = solver.Solve();

            // Check that the problem has an optimal solution.
            if (resultStatus != Solver.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return;
            }
            Console.WriteLine("Solution:");
            Console.WriteLine("Objective value = " + solver.Objective().Value());
            Console.WriteLine("x = " + x.SolutionValue());
            Console.WriteLine("y = " + y.SolutionValue());

            Console.WriteLine("\nAdvanced usage:");
            Console.WriteLine("Problem solved in " + solver.WallTime() + " milliseconds");
            Console.WriteLine("Problem solved in " + solver.Iterations() + " iterations");
            Console.WriteLine("Problem solved in " + solver.Nodes() + " branch-and-bound nodes");
        }
    }*/
}
/*namespace LpSolveDotNet.Demo
{
    /// <summary>
    /// This class demonstrates how to reproduce the example model from http://lpsolve.sourceforge.net/5.5/formulate.htm#CS.NET
    /// using LpSolveDotNet.
    /// </summary>
    internal class FormulateSample
    {
        public static int Test()
        {
            LpSolve.Init();

            return Demo();
        }

        private static int Demo()
        {
            // We will build the model row by row
            // So we start with creating a model with 0 rows and 2 columns
            int Ncol = 39; // there are two variables in the model 

            using (LpSolve lp = LpSolve.make_lp(0, Ncol))
            {
                if (lp == null)
                {
                    return 1; // couldn't construct a new model...
                }

                //let us name our variables. Not required, but can be useful for debugging
                lp.set_col_name(1, "d1n");
                lp.set_col_name(2, "d1p");
                lp.set_col_name(3, "d2n");
                lp.set_col_name(4, "d2p");
                lp.set_col_name(5, "d3n");
                lp.set_col_name(6, "d3p");
                lp.set_col_name(7, "d4n");
                lp.set_col_name(8, "d4p");
                lp.set_col_name(9, "d5n");
                lp.set_col_name(10, "d5p");
                lp.set_col_name(11, "d6n");
                lp.set_col_name(12, "d6p");
                lp.set_col_name(13, "e1n");
                lp.set_col_name(14, "e1p");
                lp.set_col_name(15, "e2n");
                lp.set_col_name(16, "e2p");
                lp.set_col_name(17, "e3n");
                lp.set_col_name(18, "e3p");
                lp.set_col_name(19, "e4n");
                lp.set_col_name(20, "e4p");
                lp.set_col_name(21, "e5n");
                lp.set_col_name(22, "e5p");
                lp.set_col_name(23, "e6n");
                lp.set_col_name(24, "e6p");
                lp.set_col_name(25, "x1");
                lp.set_col_name(26, "x2");
                lp.set_col_name(27, "x3");
                lp.set_col_name(28, "x4");
                lp.set_col_name(29, "x5");
                lp.set_col_name(30, "x6");
                lp.set_col_name(31, "x7");
                lp.set_col_name(32, "x8");
                lp.set_col_name(33, "x9");
                lp.set_col_name(34, "g1");
                lp.set_col_name(35, "g2");
                lp.set_col_name(36, "g3");
                lp.set_col_name(37, "g4");
                lp.set_col_name(38, "g5");
                lp.set_col_name(39, "g6");



                //create space large enough for one row
                int[] colno = new int[Ncol];
                double[] row = new double[Ncol];

                // makes building the model faster if it is done rows by row
                lp.set_add_rowmode(true);

                int j = 0;
                //construct first row (120 x + 210 y <= 15000)
                colno[j] = 25; // first column
                row[j++] = 0.75;

                colno[j] = 26; // second column
                row[j++] = 0.5;

                colno[j] = 27; // second column
                row[j++] = 0.4;

                colno[j] = 28; // second column
                row[j++] = 0.75;

                colno[j] = 29; // second column
                row[j++] = 0.6;

                colno[j] = 30; // second column
                row[j++] = 0.5;

                colno[j] = 31; // second column
                row[j++] = 0.67;

                colno[j] = 32; // second column
                row[j++] = 0.55;

                colno[j] = 33; // second column
                row[j++] = 0.85;

                colno[j] = 1; // first column
                row[j++] = 1;

                colno[j] = 2; // first column
                row[j++] = -1;

                colno[j] = 34; // first column
                row[j++] = -1;
                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 0) == false)
                {
                    return 3;
                }

                //construct second row (110 x + 30 y <= 4000)
                j = 0;
                colno[j] = 34; // first column
                row[j++] = 1;

                colno[j] = 14; // second column
                row[j++] = -1;

                colno[j] = 13; // second column
                row[j++] = 1;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 1) == false)
                {
                    return 3;
                }

                //construct third row ( g1 <= 1)
                j = 0;
                colno[j] = 34; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct third row ( g1 >= 0.6)
                j = 0;
                colno[j] = 34; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 0.6) == false)
                {
                    return 3;
                }


                j = 0;
                //construct first row (0.1*x1+0.17*x2+0.25*x3+x4+0.5*x5+x6+0.25*x7+0.7*x8+x9+d2n-d2p=g2)
                colno[j] = 25; // first column
                row[j++] = 0.1;

                colno[j] = 26; // second column
                row[j++] = 0.17;

                colno[j] = 27; // second column
                row[j++] = 0.25;

                colno[j] = 28; // second column
                row[j++] = 1;

                colno[j] = 29; // second column
                row[j++] = 0.5;

                colno[j] = 30; // second column
                row[j++] = 1;

                colno[j] = 31; // second column
                row[j++] = 0.25;

                colno[j] = 32; // second column
                row[j++] = 0.7;

                colno[j] = 33; // second column
                row[j++] = 0.1;

                colno[j] = 3; // first column
                row[j++] = 1;

                colno[j] = 4; // first column
                row[j++] = -1;

                colno[j] = 35; // first column
                row[j++] = -1;
                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 0) == false)
                {
                    return 3;
                }

                //construct second row (g2-e2p+e2n=1;)
                j = 0;
                colno[j] = 35; // first column
                row[j++] = 1;

                colno[j] = 16; // second column
                row[j++] = -1;

                colno[j] = 15; // second column
                row[j++] = 1;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 1) == false)
                {
                    return 3;
                }

                //construct third row ( 1>=g2;)
                j = 0;
                colno[j] = 35; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct third row ( g2 >= 0.5)
                j = 0;
                colno[j] = 35; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 0.5) == false)
                {
                    return 3;
                }


                j = 0;
                //construct first row (0.95*x1+0.85*x2+0.9*x3+0.64*x4+0.97*x5+0.62*x6+x7+0.72*x8+0.2*x9+d3n-d3p=g3;)
                colno[j] = 25; // first column
                row[j++] = 0.95;

                colno[j] = 26; // second column
                row[j++] = 0.85;

                colno[j] = 27; // second column
                row[j++] = 0.9;

                colno[j] = 28; // second column
                row[j++] = 0.64;

                colno[j] = 29; // second column
                row[j++] = 0.97;

                colno[j] = 30; // second column
                row[j++] = 0.62;

                colno[j] = 31; // second column
                row[j++] = 1;

                colno[j] = 32; // second column
                row[j++] = 0.72;

                colno[j] = 33; // second column
                row[j++] = 0.2;

                colno[j] = 5; // first column
                row[j++] = 1;

                colno[j] = 6; // first column
                row[j++] = -1;

                colno[j] = 36; // first column
                row[j++] = -1;
                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 0) == false)
                {
                    return 3;
                }

                //construct second row (g3-e3p+e3n=1)
                j = 0;
                colno[j] = 36; // first column
                row[j++] = 1;

                colno[j] = 18; // second column
                row[j++] = -1;

                colno[j] = 17; // second column
                row[j++] = 1;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 1) == false)
                {
                    return 3;
                }

                //construct third row ( 1>=g3;)
                j = 0;
                colno[j] = 36; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct third row ( g3 >= 0.97)
                j = 0;
                colno[j] = 36; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 0.97) == false)
                {
                    return 3;
                }



                j = 0;
                //construct first row (x1+x2+x3+x4+0.7*x5+0.7*x6+0.7*x7+0.4*x8+0.2*x9+d4n-d4p=g4;)
                colno[j] = 25; // first column
                row[j++] = 1;

                colno[j] = 26; // second column
                row[j++] = 1;

                colno[j] = 27; // second column
                row[j++] = 1;

                colno[j] = 28; // second column
                row[j++] = 1;

                colno[j] = 29; // second column
                row[j++] = 0.7;

                colno[j] = 30; // second column
                row[j++] = 0.7;

                colno[j] = 31; // second column
                row[j++] = 0.7;

                colno[j] = 32; // second column
                row[j++] = 0.4;

                colno[j] = 33; // second column
                row[j++] = 0.2;

                colno[j] = 7; // first column
                row[j++] = 1;

                colno[j] = 8; // first column
                row[j++] = -1;

                colno[j] = 36; // first column
                row[j++] = -1;
                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 0) == false)
                {
                    return 3;
                }

                //construct second row (g4-e4p+e4n=1)
                j = 0;
                colno[j] = 37; // first column
                row[j++] = 1;

                colno[j] = 20; // second column
                row[j++] = -1;

                colno[j] = 19; // second column
                row[j++] = 1;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 1) == false)
                {
                    return 3;
                }

                //construct third row ( 1>=g4;)
                j = 0;
                colno[j] = 37; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct third row ( g4 >= 0.7)
                j = 0;
                colno[j] = 37; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 0.7) == false)
                {
                    return 3;
                }



                j = 0;
                //construct first row (0.95*x1+0.91*x2+0.91*x3+0.8*x4+0.87*x5+0.95*x6+x7+0.65*x8+0.1*x9+d5n-d5p=g5)
                colno[j] = 25; // first column
                row[j++] = 0.95;

                colno[j] = 26; // second column
                row[j++] = 0.91;

                colno[j] = 27; // second column
                row[j++] = 0.91;

                colno[j] = 28; // second column
                row[j++] = 0.8;

                colno[j] = 29; // second column
                row[j++] = 0.87;

                colno[j] = 30; // second column
                row[j++] = 0.95;

                colno[j] = 31; // second column
                row[j++] = 1;

                colno[j] = 32; // second column
                row[j++] = 0.65;

                colno[j] = 33; // second column
                row[j++] = 0.1;

                colno[j] = 9; // first column
                row[j++] = 1;

                colno[j] = 10; // first column
                row[j++] = -1;

                colno[j] = 38; // first column
                row[j++] = -1;
                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 0) == false)
                {
                    return 3;
                }

                //construct second row (g5-e5p+e5n=1)
                j = 0;
                colno[j] = 38; // first column
                row[j++] = 1;

                colno[j] = 22; // second column
                row[j++] = -1;

                colno[j] = 21; // second column
                row[j++] = 1;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 1) == false)
                {
                    return 3;
                }

                //construct third row ( 1>=g5;)
                j = 0;
                colno[j] = 38; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct third row ( g5 >= 0.7)
                j = 0;
                colno[j] = 38; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 0.87) == false)
                {
                    return 3;
                }



                j = 0;
                //construct first row (x1+x2+x3+x4+x5+x6+x7+0.2*x8+0.2*x9+d6n-d6p=g6)
                colno[j] = 25; // first column
                row[j++] = 1;

                colno[j] = 26; // second column
                row[j++] = 1;

                colno[j] = 27; // second column
                row[j++] = 1;

                colno[j] = 28; // second column
                row[j++] = 1;

                colno[j] = 29; // second column
                row[j++] = 1;

                colno[j] = 30; // second column
                row[j++] = 1;

                colno[j] = 31; // second column
                row[j++] = 1;

                colno[j] = 32; // second column
                row[j++] = 0.2;

                colno[j] = 33; // second column
                row[j++] = 0.2;

                colno[j] = 11; // first column
                row[j++] = 1;

                colno[j] = 12; // first column
                row[j++] = -1;

                colno[j] = 39; // first column
                row[j++] = -1;
                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 0) == false)
                {
                    return 3;
                }

                //construct second row (g5-e5p+e5n=1)
                j = 0;
                colno[j] = 39; // first column
                row[j++] = 1;

                colno[j] = 24; // second column
                row[j++] = -1;

                colno[j] = 23; // second column
                row[j++] = 1;

                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 1) == false)
                {
                    return 3;
                }

                //construct third row ( 1>=g6;)
                j = 0;
                colno[j] = 39; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.LE, 1) == false)
                {
                    return 3;
                }
                //construct third row ( g6 >= 1)
                j = 0;
                colno[j] = 39; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.GE, 1) == false)
                {
                    return 3;
                }



                //construct third row ( x1+x2+x3+x4+x5+x6+x7+x8+x9= 1)
                j = 0;
                colno[j] = 25; // first column
                row[j++] = 1;

                colno[j] = 26; // first column
                row[j++] = 1;

                colno[j] = 27; // first column
                row[j++] = 1;

                colno[j] = 28; // first column
                row[j++] = 1;

                colno[j] = 29; // first column
                row[j++] = 1;

                colno[j] = 30; // first column
                row[j++] = 1;

                colno[j] = 31; // first column
                row[j++] = 1;

                colno[j] = 32; // first column
                row[j++] = 1;

                colno[j] = 33; // first column
                row[j++] = 1;



                // add the row to lpsolve
                if (lp.add_constraintex(j, row, colno, lpsolve_constr_types.EQ, 1) == false)
                {
                    return 3;
                }


                lp.set_binary(25, true);
                lp.set_binary(26, true);
                lp.set_binary(27, true);
                lp.set_binary(28, true);
                lp.set_binary(29, true);
                lp.set_binary(30, true);
                lp.set_binary(31, true);
                lp.set_binary(32, true);
                lp.set_binary(33, true);


                //rowmode should be turned off again when done building the model
                lp.set_add_rowmode(false);

                //set the objective function (143 x + 60 y)
                j = 0;
                colno[j] = 1; // first column
                row[j++] = 1;

                colno[j] = 2; // second column
                row[j++] = 14.5;

                colno[j] = 3; // second column
                row[j++] = 1;

                colno[j] = 4; // second column
                row[j++] = 7.95;

                colno[j] = 5; // second column
                row[j++] = 6.12;

                colno[j] = 6; // second column
                row[j++] = 1;

                colno[j] = 7; // second column
                row[j++] = 3.65;

                colno[j] = 8; // second column
                row[j++] = 1;

                colno[j] = 9; // second column
                row[j++] = 3.48;

                colno[j] = 10; // second column
                row[j++] = 1;

                colno[j] = 11; // second column
                row[j++] = 1;

                colno[j] = 12; // second column
                row[j++] = 7.67;

                colno[j] = 13; // second column
                row[j++] = 1;

                colno[j] = 14; // second column
                row[j++] = 1;

                colno[j] = 15; // second column
                row[j++] = 1;

                colno[j] = 16; // second column
                row[j++] = 1;

                colno[j] = 17; // second column
                row[j++] = 1;

                colno[j] = 18; // second column
                row[j++] = 1;

                colno[j] = 19; // second column
                row[j++] = 1;

                colno[j] = 20; // second column
                row[j++] = 1;

                colno[j] = 21; // second column
                row[j++] = 1;

                colno[j] = 22; // second column
                row[j++] = 1;

                colno[j] = 23; // second column
                row[j++] = 1;

                colno[j] = 24; // second column
                row[j++] = 1;

                if (lp.set_obj_fnex(j, row, colno) == false)
                {
                    return 4;
                }

                // set the object direction to minimize
                lp.set_minim();

                // just out of curioucity, now show the model in lp format on screen
                // this only works if this is a console application. If not, use write_lp and a filename
                lp.write_lp("AHP-MCGP OA knee.lp");

                // I only want to see important messages on screen while solving
                lp.set_verbose(lpsolve_verbosity.IMPORTANT);

                // Now let lpsolve calculate a solution
                lpsolve_return s = lp.solve();
                if (s != lpsolve_return.OPTIMAL)
                {
                    return 5;
                }


                // a solution is calculated, now lets get some results

                // objective value
                Debug.WriteLine("Objective value: " + lp.get_objective());

                // variable values
                lp.get_variables(row);
                for (j = 0; j < Ncol; j++)
                {
                    Console.WriteLine(lp.get_col_name(j + 1) + ": " + row[j]);
                }
            }
            return 0;
        } //Demo
    }
}*/
