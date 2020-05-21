using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using MANAGEMENT.Repository;
using MANAGEMENT.Models;

namespace MANAGEMENT.Controllers
{
    public class WipController : Controller
    {
        // GET: Wip
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vWipDetail()
        {
            return View();
        }

        // GET: Wip/GetWipDetail      
        public JsonResult GetWipDetail(int thn, int bln, int hari, int pil)
        {
            WipRepository wipRepo = new WipRepository();
            return Json(wipRepo.GetWipDetail(thn, bln, hari, pil), JsonRequestBehavior.AllowGet);
        }

        public ActionResult vTDTIScore()
        {
            return View();
        }

        // GET: Wip/GetAllDetailTDTI   
        public JsonResult GetAllScoreTDTI(int thn, int bln)
        {
            WipRepository tdtiRepo = new WipRepository();
            return Json(tdtiRepo.GetScoreTDTI(thn, bln), JsonRequestBehavior.AllowGet);
        }

        public ActionResult vFinishCostABD()
        {
            return View();
        }

        //GET : wip/GetAllFinishCostABD
        public JsonResult GetAllFinishCostABD(int thn, int bln)
        {
            WipRepository FinishABD = new WipRepository();
            return Json(FinishABD.GetAllFinishCostABD(thn, bln), JsonRequestBehavior.AllowGet);
        }
        


    }
}