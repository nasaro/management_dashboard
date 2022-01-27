using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MANAGEMENT.Models;
using BCrypt;
using System.Web.Security;
using System.Web.Helpers;
using System.Collections;

namespace MANAGEMENT.Controllers
{
    public class DashboardController : Controller
    {
        MasterDB kpiDB = new MasterDB();
        DBhrd kpiHRD = new DBhrd();
        DBppic kpiPPIC = new DBppic();
        MixDB kpiMix = new MixDB();

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModels _login)
        {
            if (ModelState.IsValid) //validating the user inputs
            {
                //bool isExist = false;
                string username = _login.UserName.Trim();
                string password = CryptoEngine.Encrypt(_login.Password.Trim());

                List<LoginModels> LogList = kpiHRD.ListMenu(username, password);
                if (LogList.Count == 0)
                {
                    ViewBag.ErrorMsg = "Please enter the valid credentials!...";
                    return View();
                }
                //userroleid = Convert.ToInt32(LogList[0].UserRoleId);
                else
                {

                    FormsAuthentication.SetAuthCookie(LogList[0].UserName, false);  // set the formauthentication cookie
                    Session["LoginCredentials"] = LogList[0];   // Bind the _logincredentials details to "LoginCredentials" session
                    //Session["MenuMaster"] = LogListMenu;        //Bind the _menus list to MenuMaster session
                    Session["UserName"] = LogList[0].UserName;
                    Session["UserIDLogin"] = LogList[0].UserId;
                    Session["UserYear"] = DateTime.Now.Year;
                    Session["UserType"] = LogList[0].CustCode;

                    /*---------- NOT USE
                    useridlogin = Convert.ToInt32(LogList[0].UserId);
                    if (useridlogin > 0)
                    {
                        Session["UserIDLogin"] = useridlogin;
                    }
                    ------------*/
                    if (LogList[0].RoleName == "Management" || LogList[0].RoleName == "ManagementUser")
                    {
                        return RedirectToAction("Index", "Dashboard");
                        //return RedirectToAction("vNotulen", "Dashboard");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Not Management Roles...";
                        return View();
                    }
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {

            Session["UserIDLogin"] = null;
            Session["UserName"] = null;
            Session["UserYear"] = null;
            Session["UserType"] = null;
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login", "Dashboard");
        }


        public ActionResult vMaster()
        {
            return View();
        }
        public JsonResult viewCorporate(int id)
        {
            return Json(kpiDB.viewCorporate( id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult viewCorporateSum()
        {
            return Json(kpiDB.viewCorporateSum(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDkpi(KPI kp, char ch)
        {
            return Json(kpiDB.CRUDkpi(kp, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vCORP(int id)
        {
            return Json(kpiDB.vCORP(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vCORPHRD(int id)
        {
            return Json(kpiHRD.vCORPHRD(id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult vDescription()
        {
            return View();
        }

        public JsonResult viewKPIDesc(char ch, int id)
        {
            return Json(kpiDB.viewKPIDesc(ch, id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDkpiDesc(KPI kp, char ch)
        {
            return Json(kpiDB.CRUDkpiDesc(kp, ch), JsonRequestBehavior.AllowGet);
        }
        //-----------graph finance chart        
        public ActionResult graphFinance()
        {
            return View();
        }
        public ActionResult graphCustomer()
        {
            return View();
        }
        public ActionResult graphIBP()
        {
            return View();
        }
        public ActionResult graphLG()
        {
            return View();
        }
        public JsonResult GraphRevenueAct(int year)
        {
            return Json(kpiDB.GraphRevenueAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphTgt(int year, int chc)
        {
            return Json(kpiDB.GraphTgt(year, chc), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphTgt2(int year, int chc)
        {
            return Json(kpiDB.GraphTgt2(year, chc), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphTgtMilliun(int year, int chc)
        {
            return Json(kpiDB.GraphTgtMilliun(year, chc), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraphTgtThousand(int year, int chc)
        {
            return Json(kpiDB.GraphTgtThousand(year, chc), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraphProdCastAct(int year)
        {
            return Json(kpiDB.GraphProdCastAct(year), JsonRequestBehavior.AllowGet);
        }        
        public JsonResult GraphProdMachAct(int year)
        {
            return Json(kpiDB.GraphProdMachAct(year), JsonRequestBehavior.AllowGet);
        }        
        public JsonResult GraphCashflowAct(int year)
        {
            return Json(kpiDB.GraphCashflowAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphCostRedCastAct(int year)
        {
            return Json(kpiDB.GraphCostRedCastAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphCostRedMachAct(int year)
        {
            return Json(kpiDB.GraphCostRedMachAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphCostRedPurcAct(int year)
        {
            return Json(kpiDB.GraphCostRedPurcAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphDRMAct(int year)
        {
            return Json(kpiDB.GraphDRMAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphAIRAct(int year)
        {
            return Json(kpiDB.GraphAIRAct(year), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraphCSIAct(int year)
        {
            return Json(kpiDB.GraphCSIAct(year), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraphRejCastAct(int year)
        {
            return Json(kpiDB.GraphRejCastAct(year), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraphRejMachAct(int year)
        {
            return Json(kpiDB.GraphRejMachAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphCNAct(int year)
        {
            return Json(kpiDB.GraphCNAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphSafetyAct(int year)
        {
            return Json(kpiHRD.GraphSafetyAct(year), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GraphIsCapAct(int year)
        {
            return Json(kpiDB.GraphIsCapAct(year), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraphTrainingAct(int year)
        {
            return Json(kpiHRD.GraphTrainingAct(year), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GraphSkillAct(int year)
        {
            return Json(kpiHRD.GraphSkillAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphMotAct(int year)
        {
            return Json(kpiDB.GraphMotAct(year), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GraphImpAct(int year)
        {
            return Json(kpiHRD.GraphImpAct(year), JsonRequestBehavior.AllowGet);
        }

        public ActionResult vMarketing()
        {
            return View();
        }

        public ActionResult vKPIDept()
        {
            return View();
        }
        public JsonResult viewCorporateDept()
        {
            return Json(kpiDB.viewCorporateDept(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewCorporateDeptByID(int id)
        {
            return Json(kpiDB.viewCorporateDeptByID(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDkpiDept(KPIDept kp, char ch)
        {
            return Json(kpiDB.CRUDkpiDept(kp, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vCORPDept(int id)
        {
            return Json(kpiDB.vCORPDept(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vCORPDeptMonthly(int id, int bul, char ch)
        {
            return Json(kpiDB.vCORPDeptMonthly(id, bul, ch), JsonRequestBehavior.AllowGet);
        }
        /*------- PPIC -----------*/
        public ActionResult vPPIC()
        {
            return View();
        }

        public JsonResult vPPICDept(int id, int bln)
        {
            return Json(kpiDB.vPPICDept(id, bln), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vPPICDeptSummary(int id, int bul, char ch)
        {
            return Json(kpiDB.vPPICDeptSummary(id, bul, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vCORPv2(int bl, int th, char ch)
        {            
            // ----not use-------
            return Json(kpiDB.vCORPv2(bl, th, ch), JsonRequestBehavior.AllowGet);
        }
        /*------- MACHINING -----------*/
        public ActionResult vMachining()
        {
            return View();
        }

        public JsonResult vMachineDeptSummary(int id, int bul, char ch)
        {
            return Json(kpiDB.vMachineDeptSummary(id, bul, ch), JsonRequestBehavior.AllowGet);
        }


        public JsonResult vMachineDept(int id, int bln)
        {
            return Json(kpiDB.vMachineDept(id, bln), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vMachineDeptHrd(int id, int bln, char ch)
        {
            return Json(kpiHRD.vMachineDeptHrd(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
        /*------- FINISHING -----------*/
        public ActionResult vFinishing()
        {
            return View();
        }

        public JsonResult vFinishingDept(int id, int bln)
        {
            return Json(kpiDB.vFinishingDept(id, bln), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vFinishingDeptSummary(int id, int bul, char ch)
        {
            return Json(kpiDB.vFinishingDeptSummary(id, bul, ch), JsonRequestBehavior.AllowGet);
        }
        /*------- HRDGA -----------  vHrdGADept*/
        public ActionResult vHRDGA()
        {
            return View();
        }
        public JsonResult vHrdGADept(int id, int bln)
        {
            return Json(kpiDB.vHrdGADept(id, bln), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vHrdGADeptSummary(int id, int bln, char ch)
        {
            return Json(kpiDB.vHrdGADeptSummary(id, bln, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult HrdGADept(int id, int bln, char ch)
        {
            return Json(kpiHRD.HrdGADept(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult HrdGADeptYY(int id, int bln, char ch)
        {
            return Json(kpiHRD.HrdGADeptYY(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
        /*------- purchaing ----------- */
        public ActionResult vPurchasing()
        {
            return View();
        }
        public JsonResult vPurchasingDept(int id, int bln)
        {
            return Json(kpiDB.vPurchasingDept(id, bln), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vPurchasingDeptSummary(int id, int bln, char ch)
        {
            return Json(kpiDB.vPurchasingDeptSummary(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
        /*----------cost control---------------------*/
        public ActionResult vCostControl()
        {
            return View();
        }

        public JsonResult vMaterial()
        {
            return Json(kpiDB.vMaterial(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewCostControl(KPI kp, char ch)
        {
            return Json(kpiDB.viewCostControl(kp, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDCostControl(KPI kp,char ch)
        {
            return Json(kpiDB.CRUDCostControl(kp, ch), JsonRequestBehavior.AllowGet);
        }
        /*----------casting--------------------*/
        public ActionResult vCasting()
        {
            return View();
        }

        public JsonResult vCastingDept(int id, int bln)
        {
            return Json(kpiDB.vCastingDept(id, bln), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CastingDept(int id, int bln, char ch)
        {
            return Json(kpiHRD.CastingDept(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vCastingDeptSummary(int id, int bln, char ch)
        {
            return Json(kpiDB.vCastingDeptSummary(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
        /*----------Production OP & LEAN--------------------*/
        public ActionResult vProduction()
        {
            return View();
        }

        public JsonResult vProductionDept(int id, int bln)
        {
            return Json(kpiDB.vProductionDept(id, bln), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProductionDept(int id, int bln, char ch)
        {
            return Json(kpiHRD.ProductionDept(id, bln, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vProductionDeptSummary(int id, int bln, char ch)
        {
            return Json(kpiDB.vProductionDeptSummary(id, bln, ch), JsonRequestBehavior.AllowGet);
        }

        /*---------- Save Report Produksi OP&Lean ------------------*/

        public JsonResult ShowProdOPlean(RptKPI rep, char ch)
        {
            return Json(kpiDB.ShowProdOPlean(rep, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vShowProdOPlean(RptKPI rep, char ch)
        {
            return Json(kpiDB.vShowProdOPlean(rep, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vShowProdOPleanYY(RptKPI rep, char ch)
        {
            return Json(kpiDB.vShowProdOPleanYY(rep, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vShowProdOPleanMM(RptKPI rep, char ch)
        {
            return Json(kpiDB.vShowProdOPleanMM(rep, ch), JsonRequestBehavior.AllowGet);
        }
        /*---------QUALITY--------------------*/

        public ActionResult vQuality()
        {
            return View();
        }
        public JsonResult vQualityDept(int id, int bln)
        {
            return Json(kpiDB.vQualityDept(id, bln), JsonRequestBehavior.AllowGet);
        }

        public JsonResult QualityDept(int id, int bln, char ch)
        {
            return Json(kpiHRD.QualityDept(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
       
       public JsonResult vQualityDeptSummary(int id, int bln, char ch)
       {
           return Json(kpiDB.vQualityDeptSummary(id, bln, ch), JsonRequestBehavior.AllowGet);
       }
        /*---------QUALITY--------------------*/
        public ActionResult vEngineering()
        {
            return View();
        }
       
        public JsonResult vEngineeringDept(int id, int bln)
        {
            return Json(kpiDB.vEngineeringDept(id, bln), JsonRequestBehavior.AllowGet);
        }

       public JsonResult vEngineeringDeptSummary(int id, int bln, char ch)
       {
           return Json(kpiDB.vEngineeringDeptSummary(id, bln, ch), JsonRequestBehavior.AllowGet);
       }

        /*-------------------PIVOT MATERIAL RECEIVING-------------------------------*/
        public ActionResult vMaterialReceiving()
        {
            return View();
        }

        public JsonResult vRptMatRec(int id)
       {
           return Json(kpiDB.vRptMatRec(id), JsonRequestBehavior.AllowGet);
       }
        /*-------------------PIVOT MATERIAL FORECASTING-------------------------------*/
        public ActionResult vMaterialForecasting()
        {
            return View();
        }

        public JsonResult vRptMatForcstng(int id)
        {
            return Json(kpiDB.vRptMatForcstng(id), JsonRequestBehavior.AllowGet);
        }

        /*-------------------PIVOT COST CONTROL CASTING-------------------------------*/
        public ActionResult vRptMaterialCostControl()
        {
            return View();
        }

        public JsonResult vRptCost(int thn, int bln)
        {
            return Json(kpiDB.vRptCost(thn, bln), JsonRequestBehavior.AllowGet);
        }
        /*-------------------PIVOT COST CONTROL INVENTORY-------------------------------*/
        public ActionResult vRptInventoryCostControl()
        {
            return View();
        }

        public JsonResult vRptInvControl(int thn, int bln)
        {
            return Json(kpiDB.vRptInvControl(thn, bln), JsonRequestBehavior.AllowGet);
        }

        /*-------------------MACHINING COST CONTROL-------------------------------*/
        public ActionResult vRptMachiningControl()
        {
            return View();
        }
        public JsonResult vRptMachCostControl(int thn, int bln)
        {
            return Json(kpiDB.vRptMachCostControl(thn, bln), JsonRequestBehavior.AllowGet);
        }

        /*-------------------PPIC CONTROL-------------------------------*/
        public ActionResult vRptPpicControl(int id)
        {
           if (id==1)
            return View( new FullNameViewModel("Non"));
           else
                return View(new FullNameViewModel("Assembly"));

        }

        public JsonResult vRptWarehouseControl(int id)
        {
            return Json(kpiDB.vRptWarehouseControl(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vShowProd(int codeprod)
        {
            return Json(kpiDB.vShowProd(codeprod), JsonRequestBehavior.AllowGet);
        }


        //-----------Maintenance
        public ActionResult vMaintenance()
        {
            return View();
        }

        public JsonResult vMaintenanceDept(int id, int bln)
        {
            return Json(kpiDB.vMaintenanceDept(id, bln), JsonRequestBehavior.AllowGet);
        }

        public JsonResult vMaintenanceDeptSummary(int id, int bln, char ch)
        {
            return Json(kpiDB.vMaintenanceDeptSummary(id, bln, ch), JsonRequestBehavior.AllowGet);
        }
        /*----------mInventory control---------------*/     
        public ActionResult vInvControl()
        {
            return View();
        }

      
        public JsonResult viewInvControl(KPIDept kp, char ch)
        {
            return Json(kpiDB.viewInvControl(kp, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CRUDInvControl(KPIDept kp, char ch)
        {
            return Json(kpiDB.CRUDInvControl(kp, ch), JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult vTitleLink(string ch)
        {
            return Json(kpiDB.vTitleLink(ch), JsonRequestBehavior.AllowGet);
        }
        /*----------mCostControlmachine---------------*/
        public ActionResult vCostControlMachine()
        {
            return View();
        }

        public JsonResult viewCostControlmachine(KPIDept kp, char ch)
        {
            return Json(kpiDB.viewCostControlmachine(kp, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CRUDCostControlMachine(KPIDept kp, char ch)
        {
            return Json(kpiDB.CRUDCostControlMachine(kp, ch), JsonRequestBehavior.AllowGet);
        }

        /*-------------------PPI Control inventory-------------------------------*/
        public ActionResult vRptStockPrPoInv()
        {
            return View();
        }

        public JsonResult vRptStockPrPo()
        {
            return Json(kpiDB.vRptStockPrPo(), JsonRequestBehavior.AllowGet);
        }

        /*-------------------PPI Control Product-------------------------------*/
        public ActionResult vPPICCntrlProduct()
        {
            return View();
        }
        public JsonResult vRptPPICCntrlProduct()
        {
            return Json(kpiDB.vRptPPICCntrlProduct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult vPPICCntrlOutPomat()
        {
            return View();
        }
        public JsonResult vRptPPICCntrlOutPomat(int id)
        {
            return Json(kpiDB.vRptPPICCntrlOutPomat(id), JsonRequestBehavior.AllowGet);
        }

        /*-------------------Outstanding - PO Detail------------------------------*/
        public ActionResult vRptOutPoDetail()
        {
            return View();
        }

        public JsonResult vRptOutPoDetailResult(int thn)
        {
            return Json(kpiDB.vRptOutPoDetailResult(thn), JsonRequestBehavior.AllowGet);
        }       
        /*-------- notulen--------------------*/
        public ActionResult vNotulen()
        {
            return View();
        }
        public JsonResult viewNotulen_1(int id, char opt)
        {
            return Json(kpiPPIC.viewNotulen_1(id, opt), JsonRequestBehavior.AllowGet);
        }
        //
        public JsonResult CRUDnotulen_1(viewNotulen note, char ch)
        {
            return Json(kpiPPIC.CRUDnotulen_1(note, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult viewNotulen_2(int id, char opt)
        {
            return Json(kpiPPIC.viewNotulen_2(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDnotulen_2(viewNotulen note, char ch)
        {
            return Json(kpiPPIC.CRUDnotulen_2(note, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewNotulen_3(int id, char opt)
        {
            return Json(kpiPPIC.viewNotulen_3(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDnotulen_3(viewNotulen note, char ch)
        {
            return Json(kpiPPIC.CRUDnotulen_3(note, ch), JsonRequestBehavior.AllowGet);
        }

        //---------------FOR PRINTING
         public JsonResult passPrintNotulen(int id, string type)
        {
            int hasil;
            Session["id"] = id;
            Session["TypePrint"] = type;
            hasil = 1;
            return Json(hasil, JsonRequestBehavior.AllowGet);
        }

        /*-------- end notulen--------------------*/
        /*-------- PDCA--------------------*/
        public ActionResult vPDCA()
        {
            return View();
        }
        public JsonResult viewPDCA(int id, char opt)
        {
            return Json(kpiPPIC.viewPDCA(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDPDCA(viewPDCA PDCA, char ch)
        {
            return Json(kpiPPIC.CRUDPDCA(PDCA, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult viewPDCAPLAN(int id, char opt)
        {
            return Json(kpiPPIC.viewPDCAPLAN(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDPLAN(viewPlan PDCA, char ch)
        {
            return Json(kpiPPIC.CRUDPLAN(PDCA, ch), JsonRequestBehavior.AllowGet);
        }
        public JsonResult viewPdcaDO_1(int id, char opt)
        {
            return Json(kpiPPIC.viewPdcaDO_1(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDPdcaDO_1(viewPdca_DO PDCA, char ch)
        {
            return Json(kpiPPIC.CRUDPdcaDO_1(PDCA, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewPdcaDO_2(int id, char opt)
        {
            return Json(kpiPPIC.viewPdcaDO_2(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDPdcaDO_2(viewPdca_DO PDCA, char ch)
        {
            return Json(kpiPPIC.CRUDPdcaDO_2(PDCA, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewPdcaCheck(int id, char opt)
        {
            return Json(kpiPPIC.viewPdcaCheck(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDPdcaCheck(viewPdca_Check PDCA, char ch)
        {
            return Json(kpiPPIC.CRUDPdcaCheck(PDCA, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewPdcaAct_1(int id, char opt)
        {
            return Json(kpiPPIC.viewPdcaAct_1(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDPdcaAct_1(viewPdca_Act PDCA, char ch)
        {
            return Json(kpiPPIC.CRUDPdcaAct_1(PDCA, ch), JsonRequestBehavior.AllowGet);
        }

        public JsonResult viewPdcaAct_2(int id, char opt)
        {
            return Json(kpiPPIC.viewPdcaAct_2(id, opt), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CRUDPdcaAct_2(viewPdca_Act PDCA, char ch)
        {
            return Json(kpiPPIC.CRUDPdcaAct_2(PDCA, ch), JsonRequestBehavior.AllowGet);
        }
        /*-------- end PDCA--------------------*/

        /*------------------Graphic Production---------------------------*/
        public ActionResult vGraphPouring()
        {
            return View();
        }
        public JsonResult vGrapOutputPouring(int year, int month)
        {
            return Json(kpiDB.vGrapOutputPouring(year, month), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vLastRowPouring(int year, int month)
        {
            return Json(kpiDB.vLastRowPouring(year, month), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vGrapOutputPda(int year, int month)
        {
            return Json(kpiDB.vGrapOutputPda(year, month), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vLastRowPda(int year, int month)
        {
            return Json(kpiDB.vLastRowPDA(year, month), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vGrapOutputPdb(int year, int month)
        {
            return Json(kpiDB.vGrapOutputPdb(year, month), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vLastRowPdb(int year, int month)
        {
            return Json(kpiDB.vLastRowPDB(year, month), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vGrapOutputWIP(int year, int month)
        {
            return Json(kpiDB.vGrapOutputWIP(year, month), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vGrapPouringVSPda(int year, int month)
        {
            return Json(kpiDB.vGrapPouringVSPda(year, month), JsonRequestBehavior.AllowGet);
        }

        /*------------------End Graphic Production-----------------------*/
        //vRptMargin
        public ActionResult vRptMargin()
        {
            return View();
        }
        [HttpGet]
        public JsonResult vMarginTotal(int year, int month)
        {
            return Json(kpiDB.vMarginTotal(year, month), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult vMarginProsen(int year, int month)
        {
            return Json(kpiDB.vMarginProsen(year, month), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult vMarginDetail(int year, int month)
        {
            return Json(kpiDB.vMarginDetail(year, month), JsonRequestBehavior.AllowGet);
        }
        /*------------------Survey Customer-----------------------*/
        public ActionResult vRptSurvey()
        {
            return View();
        }
        public JsonResult vSurveyPeriod()
        {
            return Json(kpiDB.vSurveyPeriod(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyCount(int id)
        {
            return Json(kpiDB.vSurveyCount(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyCountCust(int id)
        {
            return Json(kpiDB.vSurveyCountCust(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyProsenLog(int id)
        {
            return Json(kpiDB.vSurveyProsenLog(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyScoreAvg(int id)
        {
            return Json(kpiDB.vSurveyScoreAvg(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyScoreGraph(int id)
        {
            return Json(kpiDB.vSurveyScoreGraph(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyScoreThree(int id)
        {
            return Json(kpiDB.vSurveyScoreThree(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyScoreList(int id)
        {
            return Json(kpiDB.vSurveyScoreList(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult vSurveyCommentList(int id)
        {
            return Json(kpiDB.vSurveyCommentList(id), JsonRequestBehavior.AllowGet);
        }
        /*------------------End Survey Customer-----------------------*/

        /*-------------------vFOHRpt------------------------------*/
        public ActionResult vFOHRpt()
        {
            return View();
        }

        public JsonResult RptFOHDetail_original(int bln, int thn)
        {
            return Json(kpiPPIC.RptFOHDetail(bln, thn), JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult RptFOHDetailChild(string ddate)
        {
            string tglA = ddate.Substring(0, 2);
            string blnA = ddate.Substring(3, 2);
            string thnA = ddate.Substring(6, 4);
            string spBegda = thnA + "/" + blnA + "/" + tglA;
            return Json(kpiDB.RptFOHDetailChild(spBegda), JsonRequestBehavior.AllowGet);
        }

        public JsonResult RptFOHDetail(int bln, int thn)
        {
            return Json(kpiMix.RptFOHDetail(bln, thn), JsonRequestBehavior.AllowGet);
        }

        #region Fixed Asset
        public ActionResult vAsset()
        {
            return View();
        }

        public ActionResult vListAsset()
        {
            return View();
        }
        #endregion
        #region Maintenance
        public ActionResult vPreventiveMaintenance()
        {
            return View();
        }
        public ActionResult vCurativeMaintenance()
        {
            return View();
        }
        public ActionResult VCalendarColorPM()
        {
            return View();
        }
        public ActionResult VCalendarColorCM()
        {
            return View();
        }
        #endregion


    }
}