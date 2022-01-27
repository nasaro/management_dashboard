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

        #region Fixed Asset
        public JsonResult viewMMRAsset(string prd)
        {
            string bln = prd.Substring(0, 2);
            string thn = prd.Substring(3, 4);
            int iBln = Convert.ToInt32(bln);
            int iThn = Convert.ToInt32(thn);

            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.viewMMRAsset(iThn, iBln), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int insMMRAsset(MMRFixedAsset tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.insAsset(tbl);
        }

        [HttpPost]
        public int insManualAsset(MMRFixedAsset tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.insManualAsset(tbl);
        }

        public JsonResult viewListAsset(string prd)
        {
            string bln = prd.Substring(0, 2);
            string thn = prd.Substring(3, 4);
            int iBln = Convert.ToInt32(bln);
            int iThn = Convert.ToInt32(thn);

            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.viewListAsset(iThn, iBln), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ViewArea()
        {
            WipRepository Area = new WipRepository();
            return Json(Area.ViewArea(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ViewGroup()
        {
            WipRepository Area = new WipRepository();
            return Json(Area.ViewGroup(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int delAsset(MMRFixedAsset tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.delAsset(tbl);
        }

        [HttpPost]
        public int updAssetArea(MMRFixedAsset tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.updAssetArea(tbl);
        }

        [HttpPost]
        public JsonResult passPrintAsset(string id, string type, char choice)
        {
            int hasil;
            Session["Option"] = id;
            Session["TypePrint"] = type;
            Session["TypeChoice"] = choice;
            hasil = 1;
            return Json(hasil, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Preventive Maintenance

        public JsonResult viewPreventiveMaintenance()
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.viewPreventiveMaintenance(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewSelectPM()
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.viewSelectPM(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int insPM(MMRFixedAsset tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.insPM(tbl);
        }

        [HttpPost]
        public int insSchedule(PrevHdr tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.insSchedule(tbl);
        }

        public JsonResult scheduleAll()
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.scheduleAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult scheduleByYear(int id, int thn)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.scheduleByYear(id, thn), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int updateSchedule(PrevHdr tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.updateSchedule(tbl);
        }

        [HttpPost]
        public JsonResult viewJobActivity(int id)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.viewJobActivity(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int insJOB(PrevJOB tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.insJOB(tbl);
        }

        [HttpPost]
        public int updateJOB(PrevJOB tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.updateJOB(tbl);
        }

        public JsonResult ViewColorPM()
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.ViewColorPM(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult AlertPM()
        {
            WipRepository AlertPM = new WipRepository();
            return Json(AlertPM.AlertPM(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InfoCalendarPM(int thn)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.InfoCalendarPM(thn), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InfoDetailCalendarPM(int thn)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.InfoDetailCalendarPM(thn), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Kurative maintenance
        public JsonResult viewCurativeMaintenance()
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.viewCurativeMaintenance(), JsonRequestBehavior.AllowGet);
        }

       

        [HttpPost]
        public JsonResult ViewCM(int id)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.ViewCM(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int insCM(CuraHdr tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.insCM(tbl);
        }

        [HttpPost]
        public int updateCM(CuraHdr tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.updateCM(tbl);
        }

        [HttpPost]
        public JsonResult ViewCMDetail(int idHdr)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.ViewCMDetail(idHdr), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int InsCMDetail(CuraDtl tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.InsCMDetail(tbl);
        }

        [HttpPost]
        public int UpdateCMDetail(CuraDtl tbl)
        {
            WipRepository FixedAsset = new WipRepository();
            return FixedAsset.UpdateCMDetail(tbl);
        }

        public JsonResult ViewColorCM()
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.ViewColorCM(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InfoCalendarCM(int thn)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.InfoCalendarCM(thn), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InfoDetailCalendarCM(int thn)
        {
            WipRepository FixedAsset = new WipRepository();
            return Json(FixedAsset.InfoDetailCalendarCM(thn), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}