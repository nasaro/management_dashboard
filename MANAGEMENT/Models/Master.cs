using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MANAGEMENT.Models
{
    public class vAutoComplete
    {
        public string code { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }

    public class FullNameViewModel
    {
        public string FirstName { get; set; }

        public FullNameViewModel() { }

        public FullNameViewModel(string firstName)
        {
            this.FirstName = firstName;
        }

    }
    public class LoginModels
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter the User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? UserRoleId { get; set; }
        public string RoleName { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public int mesin { get; set; }
    }

    public class KPI    {
        public int idkpi { get; set; }
        public int iddesc { get; set; }
        public int year { get; set; }
        public int grade { get; set; }
        public string group { get; set; }
        public int sort { get; set; }
        public string desc { get; set; }
        public string period { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public decimal KPI1 { get; set; }
        public decimal KPI2 { get; set; }
        public decimal KPI3 { get; set; }
        public decimal KPI4 { get; set; }
        public decimal KPI5 { get; set; }
        public decimal KPI6 { get; set; }
        public decimal KPI7 { get; set; }
        public decimal KPI8 { get; set; }
        public decimal KPI9 { get; set; }
        public decimal KPI10 { get; set; }
        public decimal KPI11 { get; set; }
        public decimal KPI12 { get; set; }
        public decimal KPITOT { get; set; }
    }

    public class KPIDept
    {
        public int idkpi { get; set; }
        public int iddesc { get; set; }
        public int year { get; set; }
        public string period { get; set; }
        public string desc { get; set; }
        public string group { get; set; }
        public int sort { get; set; }
        public int grade { get; set; }
        public decimal target { get; set; }
        public decimal targettot { get; set; }
        public decimal graderate { get; set; }
    }

    public class corporate
    {
        public int finGrdRev { get; set; }
        public decimal finTgtRev { get; set; }
        public decimal finActRev { get; set; }
        public int finGrdProdCast { get; set; }
        public decimal finTgtProdCast { get; set; }
        public decimal finActProdCast { get; set; }
        public int finGrdProdMach { get; set; }
        public decimal finTgtProdMach { get; set; }
        public decimal finActProdMach { get; set; }
        public int finGrdCash { get; set; }
        public decimal finTgtCash { get; set; }
        public decimal finActCash { get; set; }
        public int finGrdRedCast { get; set; }
        public decimal finTgtRedCast { get; set; }
        public decimal finActRedCast { get; set; }
        public int finGrdRedMach { get; set; }
        public decimal finTgtRedMach { get; set; }
        public decimal finActRedMach { get; set; }
        public int finGrdRedPurc { get; set; }
        public decimal finTgtRedPurc { get; set; }
        public decimal finActRedPurc { get; set; }
        public int cusGrdDrm { get; set; }
        public decimal cusTgtDrm { get; set; }
        public decimal cusActDrm { get; set; }
        public int cusGrdCsi { get; set; }
        public decimal cusTgtCsi { get; set; }
        public decimal cusActCsi { get; set; }
        public int cusGrdAir { get; set; }
        public decimal cusTgtAir { get; set; }
        public decimal cusActAir { get; set; }
        public int ibpGrdRjtCast { get; set; }
        public decimal ibpTgtRjtCast { get; set; }
        public decimal ibpActRjtCast { get; set; }
        public int ibpGrdRjtMac { get; set; }
        public decimal ibpTgtRjtMac { get; set; }
        public decimal ibpActRjtMac { get; set; }
        public int ibpGrdCN { get; set; }
        public decimal ibpTgtCN { get; set; }
        public decimal ibpActCN { get; set; }
        public int ibpGrdSafe { get; set; }
        public decimal ibpTgtSafe { get; set; }
        public decimal ibpActSafe { get; set; }
        public int lgGrdImp { get; set; }
        public decimal lgTgtImp { get; set; }
        public decimal lgActImp { get; set; }
        public decimal lgAchImp { get; set; }
        public decimal lgScrImp { get; set; }
        public int lgGrdIsCap { get; set; }
        public decimal lgTgtIsCap { get; set; }
        public decimal lgActIsCap { get; set; }
        public int lgGrdTrain { get; set; }
        public decimal lgTgtTrain { get; set; }
        public decimal lgActTrain { get; set; }
        public int lgGrdSkill { get; set; }
        public decimal lgTgtSkill { get; set; }
        public decimal lgActSkill { get; set; }
        public int lgGrdMot { get; set; }
        public decimal lgTgtMot { get; set; }
        public decimal lgActMot { get; set; }
        public decimal TotGrade { get; set; }
        public decimal TotScore { get; set; }
        public decimal TotGradeMonth { get; set; }
        public decimal TotScoreMonth { get; set; }
        public decimal TotGradeSum { get; set; }
        public decimal TotScoreSum { get; set; }
        public decimal PicAchSaf { get; set; }
        public decimal PicScrSaf { get; set; }
        public decimal PicGrdLab { get; set; }
        public decimal PicAchLab { get; set; }
        public decimal PicScrLab { get; set; }
        public decimal PicActLab { get; set; }
        
    }

    public class corpdept
    {
        public decimal MktGrdRev { get; set; }
        public decimal MktTgtRev { get; set; }
        public decimal MktActRev { get; set; }
        public decimal MktGrdAqu { get; set; }
        public decimal MktTgtAqu { get; set; }
        public decimal MktActAqu { get; set; }
        public decimal PicGrdAqu { get; set; }
        public decimal PicTgtAqu { get; set; }
        public decimal PicActAqu { get; set; }
        public decimal PicAchAqu { get; set; }
        public decimal PicScrAqu { get; set; }
        public decimal MktGrdSat { get; set; }
        public decimal MktTgtSat { get; set; }
        public decimal MktActSat { get; set; }
        public decimal PicGrdSat { get; set; }
        public decimal PicTgtSat { get; set; }
        public decimal PicActSat { get; set; }
        public decimal PicAchSat { get; set; }
        public decimal PicScrSat { get; set; }
        public decimal PicGrdRev { get; set; }
        public decimal PicTgtRev { get; set; }
        public decimal PicActRev { get; set; }
        public decimal PicAchRev { get; set; }
        public decimal PicScrRev { get; set; }
        public decimal PicGrdPda { get; set; }
        public decimal PicTgtPda { get; set; }
        public decimal PicActPda { get; set; }
        public decimal PicAchPda { get; set; }
        public decimal PicScrPda { get; set; }
        public decimal PicGrdPdc { get; set; }
        public decimal PicTgtPdc { get; set; }
        public decimal PicActPdc { get; set; }
        public decimal PicAchPdc { get; set; }
        public decimal PicScrPdc { get; set; }
        public decimal PicGrdTvb { get; set; }
        public decimal PicTgtTvb { get; set; }
        public decimal PicActTvb { get; set; }
        public decimal PicAchTvb { get; set; }
        public decimal PicScrTvb { get; set; }
        public decimal PicGrdDpp { get; set; }
        public decimal PicTgtDpp { get; set; }
        public decimal PicActDpp { get; set; }
        public decimal PicAchDpp { get; set; }
        public decimal PicScrDpp { get; set; }
        public decimal PicGrdEme { get; set; }
        public decimal PicTgtEme { get; set; }
        public decimal PicActEme { get; set; }
        public decimal PicAchEme { get; set; }
        public decimal PicScrEme { get; set; }
        public decimal PicGrdSca { get; set; }
        public decimal PicTgtSca { get; set; }
        public decimal PicActSca { get; set; }
        public decimal PicAchSca { get; set; }
        public decimal PicScrSca { get; set; }
        public decimal PicGrdMus { get; set; }
        public decimal PicTgtMus { get; set; }
        public decimal PicActMus { get; set; }
        public decimal PicAchMus { get; set; }
        public decimal PicScrMus { get; set; }
        public decimal PicGrdOth { get; set; }
        public decimal PicTgtOth { get; set; }
        public decimal PicActOth { get; set; }
        public decimal PicAchOth { get; set; }
        public decimal PicScrOth { get; set; }
        public decimal PicGrdAir { get; set; }
        public decimal PicTgtAir { get; set; }
        public decimal PicActAir { get; set; }
        public decimal PicAchAir { get; set; }
        public decimal PicScrAir { get; set; }
        public decimal PicGrdInv { get; set; }
        public decimal PicTgtInv { get; set; }
        public decimal PicActInv { get; set; }
        public decimal PicAchInv { get; set; }
        public decimal PicScrInv { get; set; }
        public decimal PicGrdDrm { get; set; }
        public decimal PicTgtDrm { get; set; }
        public decimal PicActDrm { get; set; }
        public decimal PicAchDrm { get; set; }
        public decimal PicScrDrm { get; set; }
        public decimal PicGrdLab { get; set; }
        public decimal PicTgtLab { get; set; }
        public decimal PicActLab { get; set; }
        public decimal PicAchLab { get; set; }
        public decimal PicScrLab { get; set; }
        public decimal PicGrdRed { get; set; }
        public decimal PicTgtRed { get; set; }
        public decimal PicActRed { get; set; }
        public decimal PicAchRed { get; set; }
        public decimal PicScrRed { get; set; }
        public decimal PicGrdWip { get; set; }
        public decimal PicTgtWip { get; set; }
        public decimal PicActWip { get; set; }
        public decimal PicAchWip { get; set; }
        public decimal PicScrWip { get; set; }
        public decimal PicGrdSaf { get; set; }
        public decimal PicTgtSaf { get; set; }
        public decimal PicActSaf { get; set; }
        public decimal PicAchSaf { get; set; }
        public decimal PicScrSaf { get; set; }
        public decimal PicGrdRjt { get; set; }
        public decimal PicTgtRjt { get; set; }
        public decimal PicActRjt { get; set; }
        public decimal PicAchRjt { get; set; }
        public decimal PicScrRjt { get; set; }

        public decimal PicGrdNon { get; set; }
        public decimal PicTgtNon { get; set; }
        public decimal PicActNon { get; set; }
        public decimal PicAchNon { get; set; }
        public decimal PicScrNon { get; set; }

        public decimal PicGrdBad { get; set; }
        public decimal PicTgtBad { get; set; }
        public decimal PicActBad { get; set; }
        public decimal PicAchBad { get; set; }
        public decimal PicScrBad { get; set; }

        public decimal PicGrdScp { get; set; }
        public decimal PicTgtScp { get; set; }
        public decimal PicActScp { get; set; }
        public decimal PicAchScp { get; set; }
        public decimal PicScrScp { get; set; }

        public decimal PicGrdAly { get; set; }
        public decimal PicTgtAly { get; set; }
        public decimal PicActAly { get; set; }
        public decimal PicAchAly { get; set; }
        public decimal PicScrAly { get; set; }

        public decimal PicGrdSil { get; set; }
        public decimal PicTgtSil { get; set; }
        public decimal PicActSil { get; set; }
        public decimal PicAchSil { get; set; }
        public decimal PicScrSil { get; set; }

        public decimal PicGrdZif { get; set; }
        public decimal PicTgtZif { get; set; }
        public decimal PicActZif { get; set; }
        public decimal PicAchZif { get; set; }
        public decimal PicScrZif { get; set; }

        public decimal PicGrdZis { get; set; }
        public decimal PicTgtZis { get; set; }
        public decimal PicActZis { get; set; }
        public decimal PicAchZis { get; set; }
        public decimal PicScrZis { get; set; }

        public decimal PicGrdMuf { get; set; }
        public decimal PicTgtMuf { get; set; }
        public decimal PicActMuf { get; set; }
        public decimal PicAchMuf { get; set; }
        public decimal PicScrMuf { get; set; }

        public decimal PicGrdMu3 { get; set; }
        public decimal PicTgtMu3 { get; set; }
        public decimal PicActMu3 { get; set; }
        public decimal PicAchMu3 { get; set; }
        public decimal PicScrMu3 { get; set; }

        public decimal PicGrdMu1 { get; set; }
        public decimal PicTgtMu1 { get; set; }
        public decimal PicActMu1 { get; set; }
        public decimal PicAchMu1 { get; set; }
        public decimal PicScrMu1 { get; set; }

        public decimal MktGrdDrm { get; set; }
        public decimal MktTgtDrm { get; set; }
        public decimal MktActDrm { get; set; }
        public decimal MktAchDrm { get; set; }
        public decimal MktScrDrm { get; set; }

        public decimal MktGrdAir { get; set; }
        public decimal MktTgtAir { get; set; }
        public decimal MktActAir { get; set; }
        public decimal MktAchAir { get; set; }
        public decimal MktScrAir { get; set; }

        public decimal PicGrdZae { get; set; }
        public decimal PicTgtZae { get; set; }
        public decimal PicActZae { get; set; }
        public decimal PicAchZae { get; set; }
        public decimal PicScrZae { get; set; }

        public decimal PicGrdTol { get; set; }
        public decimal PicTgtTol { get; set; }
        public decimal PicActTol { get; set; }
        public decimal PicAchTol { get; set; }
        public decimal PicScrTol { get; set; }

        public decimal PicGrdImp { get; set; }
        public decimal PicTgtImp { get; set; }
        public decimal PicActImp { get; set; }
        public decimal PicAchImp { get; set; }
        public decimal PicScrImp { get; set; }

        public decimal TotGrade { get; set; }
        public decimal TotScore { get; set; }

    }

    public class RptKPI
    {
        public int id { get; set; }
        public string Title { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public decimal Nilai { get; set; }
        public decimal NilaiM { get; set; }
        public decimal NilaiY { get; set; }
    }
    public class ViewChart
    {
        public int? bulan { get; set; }
        public decimal? amount { get; set; }
    }

    public class viewTable
    {
        public string remark { get; set; }
        public decimal? jan { get; set; }
        public decimal? feb { get; set; }
        public decimal? mar { get; set; }
        public decimal? apr { get; set; }
        public decimal? may { get; set; }
        public decimal? jun { get; set; }
        public decimal? jul { get; set; }
        public decimal? aug { get; set; }
        public decimal? sep { get; set; }
        public decimal? oct { get; set; }
        public decimal? nov { get; set; }
        public decimal? dec { get; set; }
        public decimal? log { get; set; }
        public decimal? totjan { get; set; }
        public decimal? totfeb { get; set; }
        public decimal? totmar { get; set; }
        public decimal? totapr { get; set; }
        public decimal? totmay { get; set; }
        public decimal? totjun { get; set; }
        public decimal? totjul { get; set; }
        public decimal? totaug { get; set; }
        public decimal? totsep { get; set; }
        public decimal? totoct { get; set; }
        public decimal? totnov { get; set; }
        public decimal? totdec { get; set; }
        public decimal? totlog { get; set; }
        public decimal? tot { get; set; }
        public decimal? grandtot { get; set; }
    }

    public class viewCost
    {
        public string item { get; set; }
        public decimal? C1 { get; set; }
        public decimal? C2 { get; set; }
        public decimal? C3 { get; set; }
        public decimal? C4 { get; set; }
        public decimal? C5 { get; set; }
        public decimal? C6 { get; set; }
        public decimal? C7 { get; set; }
        public decimal? C8 { get; set; }
        public decimal? C9 { get; set; }
        public decimal? C10 { get; set; }
        public decimal? C11 { get; set; }
        public decimal? C12 { get; set; }
        public decimal? C13 { get; set; }
        public decimal? C14 { get; set; }
        public decimal? C15 { get; set; }
        public decimal? C16 { get; set; }
        public decimal? C17 { get; set; }
        public decimal? C18 { get; set; }
        public decimal? C19 { get; set; }
        public decimal? C20 { get; set; }
        public decimal? tot { get; set; }
        public decimal? BS { get; set; }
        public decimal? BA { get; set; }
        public decimal? cost { get; set; }
        public decimal? diff { get; set; }
        public decimal? sumtot { get; set; }
        public decimal? sumcost { get; set; }
        public decimal? sumtotBA { get; set; }
        public decimal? sumtotBS { get; set; }
        public decimal? grandtotBA { get; set; }
        public decimal? grandtotBS { get; set; }
        public decimal? grandtot { get; set; }
        public decimal? variance { get; set; }
        public decimal? totC1 { get; set; }
        public decimal? totC2 { get; set; }
        public decimal? totC3 { get; set; }
        public decimal? totC4 { get; set; }
        public decimal? totC5 { get; set; }
        public decimal? totC6 { get; set; }
        public decimal? totC7 { get; set; }
        public decimal? totC8 { get; set; }
        public decimal? totC9 { get; set; }
        public decimal? totC10 { get; set; }
        public decimal? totC11 { get; set; }
        public decimal? totC12 { get; set; }
        public decimal? totC13 { get; set; }
        public decimal? totC14 { get; set; }
        public decimal? totC15 { get; set; }
        public decimal? totC16 { get; set; }
        public decimal? totC17 { get; set; }
        public decimal? totC18 { get; set; }
        public decimal? totC19 { get; set; }
        public decimal? totC20 { get; set; }

    }

    public class viewPpicControl
    {
        public string cust { get; set; }
        public string item { get; set; }
        public string prodcode { get; set; }
        public string material { get; set; }
        public double? berat { get; set; }
        public double? wax { get; set; }
        public double? dipping { get; set; }
        public double? ceramic { get; set; }
        public double? finishing { get; set; }
        public double? stokawalcasting { get; set; }
        public double? totpdecasting { get; set; }
        public double? totMR { get; set; }
        public double? totmach { get; set; }
        public double? stokawalfinished { get; set; }
        public double? totpdefinished { get; set; }
        public double? totterkirim { get; set; }

        public double? cnctime { get; set; }
        public double? qtyInj { get; set; }
        public double? qtyDip { get; set; }
        public double? qtylost { get; set; }
        public double? qtypour { get; set; }
        public double? qtykirim { get; set; }

        public int? sisaPO { get; set; }
        public string edd { get; set; }
    }

    public class viewCostInv
    {
        public string item { get; set; }
        public decimal? A1 { get; set; }
        public decimal? A2 { get; set; }
        public decimal? A3 { get; set; }
        public decimal? A4 { get; set; }
        public decimal? A5 { get; set; }
        public decimal? A6 { get; set; }
        public decimal? A7 { get; set; }
        public decimal? A8 { get; set; }
        public decimal? A9 { get; set; }
        public decimal? A10 { get; set; }
        public decimal? T1 { get; set; }
        public decimal? T2 { get; set; }
        public decimal? T3 { get; set; }
        public decimal? T4 { get; set; }
        public decimal? T5 { get; set; }
        public decimal? T6 { get; set; }
        public decimal? T7 { get; set; }
        public decimal? T8 { get; set; }
        public decimal? T9 { get; set; }
        public decimal? T10 { get; set; }
        public decimal? T11 { get; set; }
        public decimal? T12 { get; set; }
        public decimal? A11 { get; set; }
        public decimal? A12 { get; set; }
        public decimal? totRowA { get; set; }
        public decimal? totRowT { get; set; }
        public decimal? totSubRowA { get; set; }
        public decimal? totSubRowT { get; set; }
        public decimal? sumtot { get; set; }
        public decimal? grandtotT { get; set; }
        public decimal? grandtotA { get; set; }
        public decimal? variance { get; set; }
        public decimal? totA1 { get; set; }
        public decimal? totA2 { get; set; }
        public decimal? totA3 { get; set; }
        public decimal? totA4 { get; set; }
        public decimal? totA5 { get; set; }
        public decimal? totA6 { get; set; }
        public decimal? totA7 { get; set; }
        public decimal? totA8 { get; set; }
        public decimal? totA9 { get; set; }
        public decimal? totA10 { get; set; }
        public decimal? totA11 { get; set; }
        public decimal? totA12 { get; set; }
        public decimal? totT1 { get; set; }
        public decimal? totT2 { get; set; }
        public decimal? totT3 { get; set; }
        public decimal? totT4 { get; set; }
        public decimal? totT5 { get; set; }
        public decimal? totT6 { get; set; }
        public decimal? totT7 { get; set; }
        public decimal? totT8 { get; set; }
        public decimal? totT9 { get; set; }
        public decimal? totT10 { get; set; }
        public decimal? totT11 { get; set; }
        public decimal? totT12 { get; set; }

    }

    public class viewNotulen
    {
        public int id_1 { get; set; }
        public int id_2 { get; set; }
        public int id_3 { get; set; }
        public string subject { get; set; }
        public string ddate { get; set; }
        public string locate { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string agensi { get; set; }
        public string matter { get; set; }
        public string plann { get; set; }
        public string pic { get; set; }
        public string target { get; set; }
        public string nameprog { get; set; }
        public int pdca { get; set; }
        public int pdca_id { get; set; }



    }

    public class viewPDCA
    {
        public int id { get; set; }
        public string program { get; set; }
        public string masalah { get; set; }
        public string linkDept { get; set; }
        public string tgl { get; set; }
        public string leader { get; set; }
        public string member { get; set; }
        public string dept { get; set; }

    }

    public class viewPlan
    {
        public int id { get; set; }
        public int id_pdca { get; set; }
        public string problem { get; set; }
        public string goal { get; set; }
        public string why1 { get; set; }
        public string why2 { get; set; }
        public string why3 { get; set; }
        public string why4 { get; set; }
        public string why5 { get; set; }
        public string root { get; set; }
        public string count1 { get; set; }
        public string benefit1 { get; set; }
        public string challenge1 { get; set; }
        public string count2 { get; set; }
        public string benefit2 { get; set; }
        public string challenge2 { get; set; }
    }

    public class viewPdca_DO
    {
        public int id { get; set; }
        public int id_pdca { get; set; }
        public int id_pdca_do { get; set; }
        public string containment { get; set; }
        public string criteria { get; set; }
        public string task { get; set; }
        public string pic { get; set; }
        public string dDeadline { get; set; }
        public int completed { get; set; }

    }

    public class viewPdca_Check
    {
        public int id { get; set; }
        public int id_pdca { get; set; }
        public string testResult { get; set; }
        public string success { get; set; }
        public string area { get; set; }

    }

    public class viewPdca_Act
    {
        public int id { get; set; }
        public int id_pdca { get; set; }
        public int id_pdca_act { get; set; }
        public string testSTD { get; set; }
        public string task { get; set; }
        public string pic { get; set; }
        public string dDeadline { get; set; }
        public int completed { get; set; }

    }

    public class viewGrap
    {
        public string tgl {get;set;}
        public double? totbrtpouring { get; set; }
        public double? trgpouring { get; set; }
        public double? totheatpouring { get; set; }
        public double? kumbrtpouring { get; set; }
        public double? kumtrgpouring { get; set; }
        public double? kumheatpouring { get; set; }
        public double? lastrowpouring { get; set; }
        public double? totalpda { get; set; }
        public double? targetpda { get; set; }
        public double? kumpda { get; set; }
        public double? kumtargetpda { get; set; }
        public double? lastrowpda { get; set; }
        public double? totalpdb { get; set; }
        public double? targetpdb { get; set; }
        public double? kumpdb { get; set; }
        public double? kumtargetpdb { get; set; }
        public double? lastrowpdb { get; set; }
        public double? totalwip { get; set; }

    }

    public class viewPODetail
    {
        public string cust { get; set; }
        public int id { get; set; }
        public string item { get; set; }
        public decimal? gross { get; set; }
        public decimal? rate { get; set; }
        public decimal? backlog { get; set; }
        public decimal? C1 { get; set; }
        public decimal? C2 { get; set; }
        public decimal? C3 { get; set; }
        public decimal? C4 { get; set; }
        public decimal? C5 { get; set; }
        public decimal? C6 { get; set; }
        public decimal? C7 { get; set; }
        public decimal? C8 { get; set; }
        public decimal? C9 { get; set; }
        public decimal? C10 { get; set; }
        public decimal? C11 { get; set; }
        public decimal? C12 { get; set; }
        public decimal? C13 { get; set; }
        public decimal? C14 { get; set; }
        public decimal? C15 { get; set; }
        public decimal? tot { get; set; }
        public decimal? grandtot { get; set; }
        public decimal? totBL { get; set; }
        public decimal? totC1 { get; set; }
        public decimal? totC2 { get; set; }
        public decimal? totC3 { get; set; }
        public decimal? totC4 { get; set; }
        public decimal? totC5 { get; set; }
        public decimal? totC6 { get; set; }
        public decimal? totC7 { get; set; }
        public decimal? totC8 { get; set; }
        public decimal? totC9 { get; set; }
        public decimal? totC10 { get; set; }
        public decimal? totC11 { get; set; }
        public decimal? totC12 { get; set; }
        public decimal? totC13 { get; set; }
        public decimal? totC14 { get; set; }
        public decimal? totC15 { get; set; }

    }

    public class viewSurvey
    {
        public int id { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }
        public string dateSurvey { get; set; }
        public string Customer { get; set; }
        public string Section { get; set; }
        public string Question { get; set; }
        public string Comment { get; set; }
        public int? int1 { get; set; }
        public decimal? num1 { get; set; }

    }

    public class viewMargin
    {
        public string code { get; set; }
        public string cust { get; set; }
        public string product { get; set; }

        public decimal? num1 { get; set; }
        public decimal? num2 { get; set; }
        public decimal? num3 { get; set; }
        public decimal? num4 { get; set; }
    }

    public class WIPModels
    {
        public int ProdID { get; set; }
        public string ProdName  { get; set; }
        public decimal Beginning { get; set; }
        public decimal INing { get; set; }
        public decimal NCR { get; set; }
        public decimal OUTing { get; set; }
        public decimal Koreksi { get; set; }
        public decimal Ending { get; set; }
        public decimal Cost { get; set; }
    }

    public class FOHModels
    {
        public string ddate { get; set; }
        public decimal kwhbebanpuncak { get; set; }
        public decimal kwhbebannormal { get; set; }
        public decimal rpbebanpuncak { get; set; }
        public decimal rpbebannormal { get; set; }
        public decimal rpbebann { get; set; }
        public decimal pda { get; set; }
        public decimal avgpda { get; set; }

    }

    //dPDEDate, pda
    public class FOHDetailModels
    {
        public string dPDEDate { get; set; }
        public decimal pda { get; set; }
    }

    public class TDTIDetail
    {
        public string code { get; set; }
        public string cproductname { get; set; }
        public string orbdate { get; set; }
        public string pdedate { get; set; }
        public int tothari { get; set; }
        public int totsubmit { get; set; }
        public int scorehari { get; set; }
        public int scoresubmit { get; set; }
    }

    public class FinishCost
    {
        public string tipepda { get; set; }
        public decimal beratpda { get; set; }
        public decimal cost { get; set; }
    }
    public class PrevJOB
    {
        public int idDtl { get; set; }
        public int idHdr { get; set; }
        public string JobDesc { get; set; }
        public int Cost { get; set; }
        public string sts { get; set; }
    }

    public class calendarColor
    {

        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string color { get; set; }

    }

    public class InfoPM
    {
        public int idHdr { get; set; }
        public int idtAsset { get; set; }
        public string cInvName { get; set; }
        public string cAreaName { get; set; }
        public string cUrut { get; set; }
        public string tglPM { get; set; }
        public string tglActualPM { get; set; }

    }

    public class InfoCM
    {
        public int idHdr { get; set; }
        public int idtAsset { get; set; }
        public string cInvName { get; set; }
        public string cAreaName { get; set; }
        public string userCM { get; set; }
        public string cUrut { get; set; }
        public string tglCM { get; set; }
        public string cmno { get; set; }
        public string tglFollowUp { get; set; }

    }
    public class PrevHdr
    {
        public int idHdr { get; set; }
        public int idtAsset { get; set; }
        public int count { get; set; }
        public string tgl { get; set; }
        public string tglActual { get; set; }
        public byte status { get; set; }
        public string sts { get; set; }
    }

    public class CuraDtl
    {
        public int idHdr { get; set; }
        public int idDtl { get; set; }
        public string Problem { get; set; }
        public string FollowUp { get; set; }
        public int Cost { get; set; }
        public byte status { get; set; }
        public string sts { get; set; }
    }
    public class CuraHdr
    {
        public int idHdr { get; set; }
        public int idtAsset { get; set; }
        public string cUrut { get; set; }        
        public string cm { get; set; }
        public string tgl { get; set; }
        public string user { get; set; }
        public string tglFollow { get; set; }
        public byte status { get; set; }
        public string sts { get; set; }
    }
    public class MMRFixedAsset
    {
        public int id { get; set; }
        public string cketerangan { get; set; }
        public string cMMRCOde { get; set; }
        public string dMMRDate { get; set; }
        public string cINVCOde { get; set; }
        public string cInvTypeKode { get; set; }
        public Int32 iQty { get; set; }
        public string cDescription { get; set; }
        public double ihargabelirp { get; set; }
        public double Rate { get; set; }
        public bool isMachine { get; set; }
        public string cinvname { get; set; }
        public string cArea { get; set; }
        public string Area { get; set; }
        public bool isDelete { get; set; }
        public string dDelete { get; set; }
        public string cBuktiDelete { get; set; }
        public string cUrut { get; set; }

    }

    public class Area
    {
        public string cArea { get; set; }
        public string cAreaName { get; set; }
    }


}