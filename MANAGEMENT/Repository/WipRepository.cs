using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MANAGEMENT.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace MANAGEMENT.Repository
{
    public class WipRepository
    {
        public SqlConnection con;

        //To Handle connection related activities      
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBKPI"].ToString();
            con = new SqlConnection(constr);

        }

        public readonly IDbConnection _db;
        public WipRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBKPI"].ConnectionString);
        }
        public List<WIPModels> GetWipDetail(int yyear, int mmonth, int dday, int choice)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Par1", yyear);
                param.Add("@Par2", mmonth);
                param.Add("@Par3", dday);
                if (choice==1)
                    param.Add("@Action", "WAX");
                else if (choice == 2)
                    param.Add("@Action", "DIPPING");
                else if (choice == 3)
                    param.Add("@Action", "CERAMIC");
                else if (choice == 4)
                    param.Add("@Action", "FINISHING");
                else if (choice == 5)
                    param.Add("@Action", "MACHINING");
                else
                    param.Add("@Action", "Nothing");

                connection();
                con.Open();
                IList<WIPModels> OrbList = SqlMapper.Query<WIPModels>(con, "Extranet_PPIC_WIP", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return OrbList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FOHModels> RptFOHDetail(int mmonth, int yyear)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Par1", mmonth);
                param.Add("@Par2", yyear);
                param.Add("@Action", "FOHRpt");

                connection();
                con.Open();
                IList<FOHModels> FOHList = SqlMapper.Query<FOHModels>(con, "sp_Tools", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return FOHList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<TDTIDetail> GetScoreTDTI(int thn, int bln)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Par1", thn);
                param.Add("@Par2", bln);
                param.Add("@Action", "TDTIScore");
                connection();
                con.Open();
                IList<TDTIDetail> TDTIDetailList = SqlMapper.Query<TDTIDetail>(con, "Extranet_sp_ORB", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return TDTIDetailList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<FinishCost> GetAllFinishCostABD(int thn, int bln)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@YEAR", thn);
                param.Add("@MONTH", bln);
                param.Add("@Action", "FinishCostABD");
                connection();
                con.Open();
                IList<FinishCost> FinishCostABDList = SqlMapper.Query<FinishCost>(con, "Extranet_sp_Rpt_mKPI", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return FinishCostABDList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Fixed Asset

        private static double ValRate(string valpar)
        {            
            double valrate = 0;
            switch (valpar)
            {
                case "141.01.01":
                    valrate = 0;
                    break;
                case "141.01.02":
                    valrate = 0.05;
                    break;
                case "141.01.03":
                    valrate = 0.125;
                    break;
                case "141.01.04":
                    valrate = 0.25;
                    break;
                case "141.01.05":
                    valrate = 0.25;
                    break;
                case "141.01.06":
                    valrate = 0.25;
                    break;
                case "141.01.07":
                    valrate = 0.125;
                    break;
                case "141.01.08":
                    valrate = 0.125;
                    break;
                case "141.01.09":
                    valrate = 0.125;
                    break;
                case "141.01.10":
                    valrate = 0.25;
                    break;
                case "141.01.11":
                    valrate = 0.25;
                    break;
                case "141.01.12":
                    valrate = 0.125;
                    break;
                case "141.01.13":
                    valrate = 0.125;
                    break;
                case "141.01.14":
                    valrate = 0.25;
                    break;

            }
            return valrate;
        }

        public class jum
        {
            public string noref { get; set; }

        }

        public string ValRecord(int thn, string col, string parTbl, string desc)
        {
            string refNo = "", sql = "";
            sql = "SELECT RIGHT('000' + CONVERT(varchar(3), (count(" + col + ")+1) % 1000), 3) as noref FROM " + parTbl + " where cArea='" + desc+ "' and year(dmmrdate)="+ thn;

            //--SELECT RIGHT('000' + CONVERT(varchar(5), (count(cinvgroup)+1) % 1000), 3) as noref FROM  tasset where cinvgroup = 'A02'

            var res = _db.Query<jum>(sql).FirstOrDefault();

            if (res.noref != null)
            {
                refNo = res.noref;
            }
            return refNo;
        }


        public List<MMRFixedAsset> viewMMRAsset(int thn, int bln)
        {

            /*
              IList<MMRFixedAsset> FixedAsset = SqlMapper.Query<MMRFixedAsset>(con, "select M.cketerangan,R2.cMMRCOde, convert(varchar,R1.dMMRDate,103) as dMMRDate, R2.cINVCOde,R2.iqty,R2.cDescription,R2.ihargabelirp,I.cinvname, I.cInvTypeKode " +
                    " from mtable M,tmaterialreceiving1 R1, tmaterialreceiving2 R2, minventory I where R1.cMMRCode = R2.cMMRCode and I.cinvcode = R2.cInvCode and M.ckode = I.cinvtypekode " +
                    " and cKeterangan like '141%' and ihargabelirp > 500000 and month(dMMRDate) = @MONTH and year(dMMRDate) =@YEAR", param, commandType: CommandType.Text).ToList();

             */
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@YEAR", thn);
                param.Add("@MONTH", bln);
                connection();
                con.Open();
                IList<MMRFixedAsset> FixedAsset = SqlMapper.Query<MMRFixedAsset>(con, "select M.cketerangan,R2.cMMRCOde, convert(varchar,R1.dMMRDate,103) as dMMRDate, R2.cINVCOde,R2.iqty,R2.cDescription,R2.ihargabelirp,I.cinvname, I.cInvTypeKode " +
                    " from mtable M,tmaterialreceiving1 R1, tmaterialreceiving2 R2, minventory I where R1.cMMRCode = R2.cMMRCode and I.cinvcode = R2.cInvCode and M.ckode = I.cinvtypekode " +
                    " and cKeterangan like '141%' and  month(dMMRDate) = @MONTH and year(dMMRDate) =@YEAR order by R2.cDescription, R1.dMMRDate desc", param, commandType: CommandType.Text).ToList();
                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int insAsset(MMRFixedAsset tbl)
        {
           
            try
            {

                DynamicParameters param;
                var rst=0;
                string sqlcmd;
                string tglA = tbl.dMMRDate.Substring(0, 2);
                string blnA = tbl.dMMRDate.Substring(3, 2);
                string thnA = tbl.dMMRDate.Substring(6, 4);
                string thnB = tbl.dMMRDate.Substring(8, 2);
                string newDate = thnA + "/" + blnA + "/" + tglA;
                string NewCode = tbl.cINVCOde;
                string NewCodeVal = tbl.cINVCOde.Substring(0, 9);

                double valrate = ValRate(NewCodeVal);
                double Newharga = tbl.ihargabelirp;
                int iThnB = Convert.ToInt16(thnA);
                param = new DynamicParameters();
               
                param.Add("@tglmr", newDate);
                param.Add("@item", NewCode);
                param.Add("@tipe", tbl.cInvTypeKode);
                param.Add("@rate", valrate);
                param.Add("@qty", tbl.iQty);
                param.Add("@price", Newharga);

                for (int i = 0; i < tbl.iQty; i++)
                {
                    
                    sqlcmd = "INSERT INTO tAsset(dMMRDate, cInvCode, cInvGroup, iRate, iQty, iHargaperPcs)" +
                                      " VALUES(@tglmr, @item, @tipe, @rate, 1, @price) ";
                    rst = _db.Execute(sqlcmd, param);
                }

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int insManualAsset(MMRFixedAsset tbl)
        {

            try
            {

                DynamicParameters param;
                var rst = 0;
                string sqlcmd;
                string refnomer = "";
                string tglA = tbl.dMMRDate.Substring(0, 2);
                string blnA = tbl.dMMRDate.Substring(3, 2);
                string thnA = tbl.dMMRDate.Substring(6, 4);
                string thnB = tbl.dMMRDate.Substring(8, 2);
                string newDate = thnA + "/" + blnA + "/" + tglA;
                string NewName = tbl.cINVCOde;
                double Newharga = tbl.ihargabelirp;
                string CodeArea = tbl.cArea;
                int iThnB = Convert.ToInt16(thnA);
                string NewCode = tbl.cDescription.Substring(0, 9);
                refnomer = NewCode + '.' + CodeArea + '.' + thnB + ValRecord(iThnB, "cArea", "tAsset", CodeArea);

                param = new DynamicParameters();

                param.Add("@tglmr", newDate);
                param.Add("@item", NewName);
                param.Add("@tipe", tbl.cInvTypeKode);
                param.Add("@rate", tbl.Rate);
                param.Add("@price", Newharga);
                param.Add("@nourut", refnomer);
                param.Add("@carea", CodeArea);

                sqlcmd = "INSERT INTO tAsset(dMMRDate, cInvName, cInvGroup, cArea, iRate, cUrut, iQty, iHargaperPcs, HargaTot, fisMachine)" +
                                    " VALUES(@tglmr,  @item, @tipe, @carea, @rate, @nourut, 1, @price, @price, 0) ";
                rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MMRFixedAsset> viewListAsset(int thn, int bln)
        {
            string Strsql = "";
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@YEAR", thn);
                param.Add("@MONTH", bln);
                connection();
                con.Open();

                if (bln == 6 && thn == 2021)
                {
                    Strsql = "select B.id, convert(varchar, B.dMMRDate,103) as dMMRDate, isnull(B.cInvCode,'') as cInvCode, B.cInvName, B.iQty, B.iRate as Rate, B.iHargaperPcs as ihargabelirp, B.fisDelete as isDelete, convert(varchar, B.dDelete,103) as dDelete, isnull(B.cArea,'') as cArea, B.cInvGroup as cInvTypeKode, isnull(AR.cAreaName,'') as Area, substring(M.cKeterangan,1,9) as cketerangan, isnull(B.cUrut,'') as cUrut  " +
                             "from tasset B left join tAssetArea AR on B.cArea=AR.cArea left join minventory I on B.cInvCode=I.cInvCode left join mtable M on M.cKode=B.cinvgroup where B.cInvCode is null  order by B.cInvGroup, B.dmmrdate";
                } else
                {
                    /*--  ternyata ada user input baru manual dan menyebabkan invcode == null
                     Strsql = "select A.id, convert(varchar, A.dMMRDate,103) as dMMRDate, A.cInvCode, I.cInvName, A.iQty, A.iRate as Rate, A.iHargaperPcs as ihargabelirp, A.fisDelete as isDelete, convert(varchar, dDelete,103) as dDelete, isnull(A.cArea,'') as cArea, cInvGroup as cInvTypeKode,  " +
                        " isnull(M.cAreaName,'') as Area, substring(MM.cKeterangan,1,9) as cketerangan, isnull(cUrut,'') as cUrut from tasset A left join minventory I on A.cInvCode=I.cInvCode left join mtable MM on MM.cKode=A.cinvgroup left join tAssetArea M on A.cArea=M.cArea  where month(A.dMMRDate) = @MONTH and year(A.dMMRDate) =@YEAR and A.cInvCode is not null order by A.cInvGroup, A.dmmrdate";                     
                     ----*/


                    Strsql = "select A.id, convert(varchar, A.dMMRDate,103) as dMMRDate, case when (A.cInvCode is NULL) then '' else A.cInvCode end as cInvCode,  case when (A.cInvCode is NULL) then A.cInvName else I.cInvName end as cInvName, A.iQty, A.iRate as Rate, A.iHargaperPcs as ihargabelirp, A.fisDelete as isDelete, convert(varchar, dDelete,103) as dDelete, isnull(A.cArea,'') as cArea, cInvGroup as cInvTypeKode,  " +
                        " isnull(M.cAreaName,'') as Area, substring(MM.cKeterangan,1,9) as cketerangan, isnull(cUrut,'') as cUrut from tasset A left join minventory I on A.cInvCode=I.cInvCode left join mtable MM on MM.cKode=A.cinvgroup left join tAssetArea M on A.cArea=M.cArea  where month(A.dMMRDate) = @MONTH and year(A.dMMRDate) =@YEAR  order by A.cInvGroup, A.dmmrdate";
                }

                IList<MMRFixedAsset> FixedAsset = SqlMapper.Query<MMRFixedAsset>(con, Strsql, param, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Area> ViewArea()
        {
            try
            {
                connection();
                con.Open();
                List<Area>  VArea = SqlMapper.Query<Area>(con, "select cArea, cAreaName from tAssetArea where status=1" ,commandType: CommandType.Text).ToList();
                con.Close();
                return VArea.ToList();
            } catch (Exception)
            {
                throw;
            }
        }

        public List<Area> ViewGroup()
        {
            try
            {
                connection();
                con.Open();
                List<Area> VArea = SqlMapper.Query<Area>(con, "select cKode as cArea, cKeterangan as cAreaName from mtable where id>=158 and id<=171", commandType: CommandType.Text).ToList();
                con.Close();
                return VArea.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int delAsset(MMRFixedAsset tbl)
        {
            try
            {
                string tglA = tbl.dDelete.Substring(0, 2);
                string blnA = tbl.dDelete.Substring(3, 2);
                string thnA = tbl.dDelete.Substring(6, 4);
                string newDate = thnA + "/" + blnA + "/" + tglA;
                string StartDate = thnA + "/" + blnA + "/01";


                DynamicParameters param;
                string sqlcmd;
                sqlcmd = "update tAsset set fisDelete=1, dDelete=@tgl, dStartDelete=@awaltgl, cBuktiDelete=@bukti  where id=@idnya";


                param = new DynamicParameters();
                param.Add("@idnya", tbl.id);
                param.Add("@tgl", newDate);
                param.Add("@awaltgl", StartDate);
                param.Add("@bukti", tbl.cBuktiDelete);
                var rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int updAssetArea(MMRFixedAsset tbl)
        {
            try
            {
                string refnomer = "";
                string NewCode = tbl.cINVCOde.Substring(0, 9);
                string thnB = tbl.dMMRDate.Substring(8, 2);
                string thnA = tbl.dMMRDate.Substring(6, 4);
                string CodeArea = tbl.cArea;
                int iThnB = Convert.ToInt16(thnA);
                //--tbl.cInvTypeKode = cInvGroup
                refnomer = NewCode + '.' + CodeArea + '.' + thnB + ValRecord(iThnB, "cArea", "tAsset", CodeArea);


                DynamicParameters param;
                string sqlcmd;
                sqlcmd = "update tAsset set cArea=@area, cUrut=@nourut   where id=@idnya";

                param = new DynamicParameters();
                param.Add("@idnya", tbl.id);
                param.Add("@area", tbl.cArea);
                param.Add("@nourut", refnomer);
                var rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Preventive Maintenance
        public List<MMRFixedAsset> viewPreventiveMaintenance()
        {
            string Strsql = "";
            try
            {
               
                Strsql = "select A.id, isnull(A.cInvCode,'') as cINVCOde, A.cInvName as cinvname, A.cArea, T.cAreaName as Area, A.cUrut from tasset A inner join tAssetArea T on A.cArea=T.cArea where A.fismachine = 1 and A.cinvCode is null union  " +
                    " select A.id, isnull(A.cInvCode,'') as cINVCOde, I.cinvname as cinvname, A.cArea, T.cAreaName as Area, A.cUrut from tasset A inner join minventory I on A.cInvcode=I.cInvcode inner join tAssetArea T on A.cArea=T.cArea  where A.fismachine = 1 and A.cInvcode is not null";
                connection();
                con.Open();
                List<MMRFixedAsset> FixedAsset = SqlMapper.Query<MMRFixedAsset>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MMRFixedAsset> viewSelectPM()
        {
            string Strsql = "";
            try
            {

                Strsql = "select A.id, isnull(A.cInvCode,'') as cINVCOde, I.cInvName as cinvname from tasset A inner join minventory I on A.cInvcode=I.cInvcode   " +
                    " where year(A.dMMRDate) > 2021 or (month(A.dMMRDate)>6 and year(A.dMMRDate) = 2021 ) and isnull(A.fisMachine,0) = 0  and A.cInvGroup in ('A03','A09','A10','A04','A05') ";
                connection();
                con.Open();
                List<MMRFixedAsset> FixedAsset = SqlMapper.Query<MMRFixedAsset>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int insPM(MMRFixedAsset tbl)
        {
            try
            {
                DynamicParameters param;
                string sqlcmd;
                sqlcmd = "update tAsset set fisMachine=1   where id=@idnya";

                param = new DynamicParameters();
                param.Add("@idnya", tbl.cINVCOde);
                var rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int insSchedule(PrevHdr tbl)
        {

            try
            {
                DynamicParameters param;
                var rst = 0;
                string sqlcmd;

                param = new DynamicParameters();
                param.Add("@idasset", tbl.idtAsset);

                for (int i = 0; i < tbl.count; i++)
                {

                    sqlcmd = "INSERT INTO tPMHeader(idtAsset, tglPM, statusPM)" +
                                      " VALUES(@idasset, getdate(), 0) ";
                    rst = _db.Execute(sqlcmd, param);
                }

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //scheduleAll
        public List<PrevHdr> scheduleAll()
        {
            string Strsql = "";
            try
            {

                Strsql = "select idHdr, idtAsset,isnull(convert(varchar,tglPM,103),'') as tgl, isnull(convert(varchar,tglActualPM,103),'') as tglActual, statusPM as status from tPMHeader ";
                connection();
                con.Open();
                List<PrevHdr> FixedAsset = SqlMapper.Query<PrevHdr>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PrevHdr> scheduleByYear(int id, int thn)
        {
            string Strsql = "";
            try
            {
                if (thn == 1)
                    Strsql = "select idHdr, idtAsset,isnull(convert(varchar,tglPM,103),'') as tgl, isnull(convert(varchar,tglActualPM,103),'') as tglActual, statusPM as status, case when (statusPM=0) then 'OPEN' else 'CLOSE' end as sts  from tPMHeader where idtAsset=" + id;
                else
                    Strsql = "select idHdr, idtAsset,isnull(convert(varchar,tglPM,103),'') as tgl, isnull(convert(varchar,tglActualPM,103),'') as tglActual, statusPM as status, case when (statusPM=0) then 'OPEN' else 'CLOSE' end as sts  from tPMHeader where idtAsset=" + id + " and year(tglPM)=" + thn;
                connection();
                con.Open();
                List<PrevHdr> FixedAsset = SqlMapper.Query<PrevHdr>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int updateSchedule(PrevHdr tbl)
        {
            try
            {
                string tglA = tbl.tgl.Substring(0, 2);
                string blnA = tbl.tgl.Substring(3, 2);
                string thnA = tbl.tgl.Substring(6, 4);
                string newTgl = thnA + "/" + blnA + "/" + tglA;
                string newActual = "";
                if (tbl.tglActual != "" && tbl.tglActual != null)
                {
                    string tglB = tbl.tglActual.Substring(0, 2);
                    string blnB = tbl.tglActual.Substring(3, 2);
                    string thnB = tbl.tglActual.Substring(6, 4);
                    newActual = thnB + "/" + blnB + "/" + tglB;

                }

                DynamicParameters param;
                string sqlcmd;
                if (tbl.tglActual != "" && tbl.tglActual != null)
                    sqlcmd = "update tPMHeader set tglPM=@tglpm, tglActualPM=@tglactual, statusPM=@sts   where idHdr=@idnya";
                 else
                    sqlcmd = "update tPMHeader set tglPM=@tglpm, tglActualPM=NULL, statusPM=@sts   where idHdr=@idnya";

                param = new DynamicParameters();
                param.Add("@tglpm", newTgl);
                param.Add("@tglactual", newActual);
                param.Add("@idnya", tbl.idHdr);
                param.Add("@sts", tbl.status);
                var rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PrevJOB> viewJobActivity(int id)
        {
            string Strsql = "";
            try
            {

                Strsql = "select idDtl, idHdr, JobDesc, Cost from tpmdetail where idHdr= " + id;
                connection();
                con.Open();
                List<PrevJOB> FixedAsset = SqlMapper.Query<PrevJOB>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int insJOB(PrevJOB tbl)
        {
            try
            {
                DynamicParameters param;
                var rst = 0;
                string sqlcmd;

                param = new DynamicParameters();
                param.Add("@idHdr", tbl.idHdr);
                param.Add("@desc", tbl.JobDesc);
                param.Add("@cost", tbl.Cost);

                sqlcmd = "INSERT INTO tPMDetail(idHdr, JobDesc, Cost)" +
                                  " VALUES(@idHdr, @desc, @cost) ";
                rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int updateJOB(PrevJOB tbl)
        {
            try
            {
                DynamicParameters param;
                var rst = 0;
                string sqlcmd;

                param = new DynamicParameters();
                param.Add("@idDtl", tbl.idDtl);
                param.Add("@idHdr", tbl.idHdr);
                param.Add("@desc", tbl.JobDesc);
                param.Add("@cost", tbl.Cost);

                sqlcmd = "UPDATE tPMDetail SET JobDesc=@desc, Cost=@cost WHERE idDTL=@idDtl";
                rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<calendarColor> ViewColorPM()
        {
            string Strsql = "";
            try
            {

                Strsql = "select P.idHdr as id, A.cInvName as title, convert(varchar,P.tglPM,23) as start, case when (P.tglActualPM is null and tglPM>getdate()) then '#FFA500'   " +
                    "when (P.tglActualPM > P.tglPM ) then '#FF0000' when (P.tglActualPM <= P.tglPM ) then '#00FF00' when (P.tglActualPM is null and P.tglPM<getdate()) then '#FFFF00' else '#FFFFFF' end as color  " +
                    "from tpmheader P inner join tAsset A on A.id=P.idtAsset where P.tglPM is not null ";
                connection();
                con.Open();
                List<calendarColor> FixedAsset = SqlMapper.Query<calendarColor>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public InfoPM InfoCalendarPM(int idhdr)
        {
            string Strsql = "";
            try
            {

                Strsql = "select P.idHdr,  A.cInvName, R.cAreaName, A.cUrut, convert(varchar,P.tglPM,106) as tglPM, isnull(convert(varchar,P.tglActualPM,106),'-') as tglActualPM  " +
                    "from tpmheader P inner join tAsset A on A.id=P.idtAsset inner join tAssetArea R on R.cArea=A.cArea  where P.idHDR="+ idhdr;
                connection();
                con.Open();
                InfoPM FixedAsset = SqlMapper.Query<InfoPM>(con, Strsql, commandType: CommandType.Text).SingleOrDefault();

                con.Close();
                return FixedAsset;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public List<InfoPM> AlertPM()
        {
            string Strsql = "";
            try
            {

                Strsql = "select  A.cInvName,  R.cAreaName, A.cUrut , convert(varchar, T.tglPM,106) as tglPM from tpmHeader T inner join tasset A on T.idTasset=A.id inner join tAssetArea R on R.cArea=A.cArea " +
                    "where (DATEDIFF(day, getdate(), T.tglPM)=2 or DATEDIFF(day, getdate(), T.tglPM)=1) and T.statusPM=0 ";

                connection();
                con.Open();
                List<InfoPM> AlertInfo = SqlMapper.Query<InfoPM>(con, Strsql, commandType: CommandType.Text).ToList();

                con.Close();
                return AlertInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PrevJOB> InfoDetailCalendarPM(int idhdr)
        {
            string Strsql = "";
            try
            {

                Strsql = "select idDtl, JobDesc, Cost from tpmdetail where idHdr= " + idhdr + " order by idDtl  ";
                connection();
                con.Open();
                List<PrevJOB> FixedAsset = SqlMapper.Query<PrevJOB>(con, Strsql, commandType: CommandType.Text).ToList();

                con.Close();
                return FixedAsset;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Curative Maintenance
        public List<MMRFixedAsset> viewCurativeMaintenance()
        {
            string Strsql = "";
            try
            {

                Strsql = "select A.id, isnull(A.cInvCode,'') as cINVCOde, A.cInvName as cinvname, A.cArea, R.cAreaName as Area, A.cUrut from tasset A inner join tAssetArea R on A.cArea=R.cArea where (A.fismachine = 1 or A.cinvgroup = 'A12') and A.cinvCode is null union  " +
                    " select A.id, isnull(A.cInvCode,'') as cINVCOde, I.cinvname as cinvname, A.cArea, R.cAreaName as Area, A.cUrut from tasset A inner join minventory I on I.cinvcode = A.cinvcode inner join tAssetArea R on A.cArea=R.cArea where  A.cInvcode is not null and  (A.fismachine = 1 or A.cinvgroup = 'A12') ";
                connection();
                con.Open();
                List<MMRFixedAsset> FixedAsset = SqlMapper.Query<MMRFixedAsset>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ValCM(int thn, int bln, string col, string parTbl)
        {
            string refNo = "", sql = "";
            sql = "SELECT RIGHT('000' + CONVERT(varchar(3), (count(" + col + ")+1) % 1000), 3) as noref FROM " + parTbl + " where year(tglCM)='" + thn + "' and month(tglCM)=" + bln;


            var res = _db.Query<jum>(sql).FirstOrDefault();

            if (res.noref != null)
            {
                refNo = res.noref;
            }
            return refNo;
        }

        public List<CuraHdr> ViewCM(int id)
        {
            string Strsql = "";
            try
            {

                Strsql = "select C.idHdr, C.CM# as cm, isnull(convert(varchar,C.tglCM,103),'') as tgl, C.UserCM as [user], C.idtAsset, A.cUrut, isnull(convert(varchar,C.tglFollowUp,103),'') as tglFollow " +
                         " from tcmheader C inner join tAsset A on C.idtAsset=A.id where C.idtAsset = " + id;
                connection();
                con.Open();
                List<CuraHdr> FixedAsset = SqlMapper.Query<CuraHdr>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int insCM(CuraHdr tbl)
        {
            try
            {
                DynamicParameters param;
                var rst = 0;
                string sqlcmd;
                string refnomer = "";
                string tglA = tbl.tgl.Substring(0, 2);
                string blnA = tbl.tgl.Substring(3, 2);
                string thnA = tbl.tgl.Substring(6, 4);
                string thnB = tbl.tgl.Substring(8, 2);
                string newTgl = thnA + "/" + blnA + "/" + tglA;

                int iThnB = Convert.ToInt16(thnB);
                int iBlnB = Convert.ToInt16(blnA);
                refnomer = thnB + blnA + ValCM(iThnB, iBlnB, "idHdr", "tcmheader");

                param = new DynamicParameters();
                param.Add("@ref", refnomer);
                param.Add("@tgl", newTgl);
                param.Add("@usr", tbl.user);
                param.Add("@asset", tbl.idtAsset);

                sqlcmd = "INSERT INTO tCMHeader(CM#, TglCM, UserCM, idtAsset)" +
                                  " VALUES(@ref, @tgl, @usr, @asset) ";
                rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int updateCM(CuraHdr tbl)
        {
            try
            {
                string sqlcmd;
                DynamicParameters param;
                var rst = 0;
               

                param = new DynamicParameters();
                param.Add("@usr", tbl.user);
                param.Add("@idHdr", tbl.idHdr);

                sqlcmd = "update tCMHeader set UserCM = @usr where idHdr=@idHdr";
                rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

       

        public List<CuraDtl> ViewCMDetail(int id)
        {
            string Strsql = "";
            try
            {

                Strsql = "select  idDtl, idHdr, Problem, isnull(FollowUp,'') as FollowUp, Cost from tcmdetail where idHdr = " + id;
                connection();
                con.Open();
                List<CuraDtl> FixedAsset = SqlMapper.Query<CuraDtl>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsCMDetail(CuraDtl tbl)
        {
            try
            {
                DynamicParameters param;
                var rst = 0;
                string sqlcmd;

                param = new DynamicParameters();
                param.Add("@idHdr", tbl.idHdr);
                param.Add("@problem", tbl.Problem);

                sqlcmd = "INSERT INTO tCMDetail(idHdr, Problem)" +
                                  " VALUES(@idHdr, @problem) ";
                rst = _db.Execute(sqlcmd, param);

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateCMDetail(CuraDtl tbl)
        {
            try
            {
                DynamicParameters param;
                var rstHdr = 0;
                var rstDtl = 0;
                var rst = 0;
                string sqlcmd, sqlcmdtl;

                param = new DynamicParameters();
                param.Add("@idDtl", tbl.idDtl);
                param.Add("@idHdr", tbl.idHdr);
                param.Add("@follow", tbl.FollowUp);
                param.Add("@cost", tbl.Cost);

                sqlcmd = "update tCMDetail set FollowUp=@follow, Cost=@cost where idDtl=@idDtl ";
                rstHdr = _db.Execute(sqlcmd, param);

                sqlcmdtl = "update tCMHeader set TglFollowUp=getdate() where idHdr=@idHdr ";
                rstDtl = _db.Execute(sqlcmdtl, param);

                rst = rstHdr * rstDtl;

                return rst;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<calendarColor> ViewColorCM()
        {
            string Strsql = "";
            try
            {

                Strsql = "select P.idHdr as id, A.cInvName as title, convert(varchar,P.tglCM,23) as start,    " +
                    "case when (tglCM=getdate()) then '#FFA500'  when (tglCM<getdate()) then '#FF0000' when (P.tglFollowUp is null) then '#0000FF' else '#FFFFFF' end as color  " +
                    "from tcmheader P inner join tAsset A on A.id=P.idtAsset ";
                connection();
                con.Open();
                List<calendarColor> FixedAsset = SqlMapper.Query<calendarColor>(con, Strsql, commandType: CommandType.Text).ToList();


                con.Close();
                return FixedAsset.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public InfoCM InfoCalendarCM(int idhdr)
        {
            string Strsql = "";
            try
            {

                Strsql = "select P.idHdr, A.cInvName, R.cAreaName, A.cUrut, P.cm# as cmno,  convert(varchar,P.tglCM,106) as tglCM, P.userCM, convert(varchar,P.tglFollowUp,106) as tglFollowUp   " +
                    "from tcmheader P inner join tAsset A on A.id=P.idtAsset inner join tAssetArea R on R.cArea=A.cArea where P.idHDR=" + idhdr;
                connection();
                con.Open();
                InfoCM FixedAsset = SqlMapper.Query<InfoCM>(con, Strsql, commandType: CommandType.Text).SingleOrDefault();

                con.Close();
                return FixedAsset;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CuraDtl> InfoDetailCalendarCM(int idhdr)
        {
            string Strsql = "";
            try
            {

                Strsql = "select idDtl, Problem, isnull(FollowUp,'') as FollowUp, Cost from tcmdetail where idHdr= " + idhdr + " order by idDtl  ";
                connection();
                con.Open();
                List<CuraDtl> FixedAsset = SqlMapper.Query<CuraDtl>(con, Strsql, commandType: CommandType.Text).ToList();

                con.Close();
                return FixedAsset;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion
    }
}