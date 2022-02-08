using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.ComponentModel;
using System.Collections;

namespace MANAGEMENT.Models
{
    public class NilaiGlobal
    {
        public static decimal TempGradeSaf = 0;
        public static decimal TempTargetSaf = 0;
        public static decimal TotGrade = 0;
        public static decimal TotScore = 0;
        public static decimal TempGradeLab = 0;
        public static decimal TempGradeLabMonth = 0;
        public static decimal TempGradeLabYear = 0;
        public static decimal TempTargetLab = 0;
        public static decimal TempTargetLabMonth = 0;
        public static decimal TempTargetLabYear = 0;
        public static decimal TempActualLab = 0;
        public static decimal TempActualLabMonth = 0;
        public static decimal TempActualLabYear = 0;
        public static decimal TotGradeMonth = 0;
        public static decimal TotScoreMonth = 0;
        public static decimal TotGradeSum = 0;
        public static decimal TotScoreSum = 0;

    }

    public class Question
    {
        public string code { get; set; }
        public string Name { get; set; }
    }
    public class MasterDB
    {
        //declare connection string  
        string cs = ConfigurationManager.ConnectionStrings["DBKPI"].ConnectionString;
        /*---Login  ----*/     
        public List<KPI> viewCorporate(int id)
        {
            decimal kp1, kp2, kp3, kp4, kp5, kp6, kp7, kp8, kp9, kp10, kp11, kp12;
            List<KPI> lst = new List<KPI>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.Parameters.AddWithValue("@ID", id);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "ShowByID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["KPI1"] == DBNull.Value)
                            kp1 = 0;
                        else
                            kp1 = Convert.ToDecimal(rdr["KPI1"]);

                        if (rdr["KPI2"] == DBNull.Value)
                            kp2 = 0;
                        else
                            kp2 = Convert.ToDecimal(rdr["KPI2"]);

                        if (rdr["KPI3"] == DBNull.Value)
                            kp3 = 0;
                        else
                            kp3 = Convert.ToDecimal(rdr["KPI3"]);

                        if (rdr["KPI4"] == DBNull.Value)
                            kp4 = 0;
                        else
                            kp4 = Convert.ToDecimal(rdr["KPI4"]);

                        if (rdr["KPI5"] == DBNull.Value)
                            kp5 = 0;
                        else
                            kp5 = Convert.ToDecimal(rdr["KPI5"]);

                        if (rdr["KPI6"] == DBNull.Value)
                            kp6 = 0;
                        else
                            kp6 = Convert.ToDecimal(rdr["KPI6"]);

                        if (rdr["KPI7"] == DBNull.Value)
                            kp7 = 0;
                        else
                            kp7 = Convert.ToDecimal(rdr["KPI7"]);

                        if (rdr["KPI8"] == DBNull.Value)
                            kp8 = 0;
                        else
                            kp8 = Convert.ToDecimal(rdr["KPI8"]);

                        if (rdr["KPI9"] == DBNull.Value)
                            kp9 = 0;
                        else
                            kp9 = Convert.ToDecimal(rdr["KPI9"]);

                        if (rdr["KPI10"] == DBNull.Value)
                            kp10 = 0;
                        else
                            kp10 = Convert.ToDecimal(rdr["KPI10"]);

                        if (rdr["KPI11"] == DBNull.Value)
                            kp11 = 0;
                        else
                            kp11 = Convert.ToDecimal(rdr["KPI11"]);

                        if (rdr["KPI12"] == DBNull.Value)
                            kp12 = 0;
                        else
                            kp12 = Convert.ToDecimal(rdr["KPI12"]);


                        lst.Add(new KPI
                        {
                            idkpi = Convert.ToInt32(rdr["idkpi"]),
                            iddesc = Convert.ToInt32(rdr["iddesc"]),
                            year = Convert.ToInt32(rdr["year"]),
                            grade = Convert.ToInt32(rdr["grade"]),
                            desc = rdr["desc"].ToString(),
                            group = rdr["group"].ToString(),
                            KPI1 = kp1,
                            KPI2 = kp2,
                            KPI3 = kp3,
                            KPI4 = kp4,
                            KPI5 = kp5,
                            KPI6 = kp6,
                            KPI7 = kp7,
                            KPI8 = kp8,
                            KPI9 = kp9,
                            KPI10 = kp10,
                            KPI11 = kp11,
                            KPI12 = kp12

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<KPI> viewCorporateSum()
        {
            decimal kptot;
            List<KPI> lst = new List<KPI>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Show");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["totHdr"] == DBNull.Value)
                            kptot = 0;
                        else
                            kptot = Convert.ToDecimal(rdr["totHdr"]);


                        lst.Add(new KPI
                        {
                            idkpi = Convert.ToInt32(rdr["idkpi"]),
                            iddesc = Convert.ToInt32(rdr["iddesc"]),
                            year = Convert.ToInt32(rdr["year"]),
                            grade = Convert.ToInt32(rdr["grade"]),
                            desc = rdr["desc"].ToString(),
                            group = rdr["group"].ToString(),
                            KPITOT = kptot

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDkpi(KPI kp, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                com.Parameters.AddWithValue("@IDDESC", kp.iddesc);
                com.Parameters.AddWithValue("@YEAR", kp.year);
                com.Parameters.AddWithValue("@GRADE", kp.grade);
                com.Parameters.AddWithValue("@KPI1", kp.KPI1);
                com.Parameters.AddWithValue("@KPI2", kp.KPI2);
                com.Parameters.AddWithValue("@KPI3", kp.KPI3);
                com.Parameters.AddWithValue("@KPI4", kp.KPI4);
                com.Parameters.AddWithValue("@KPI5", kp.KPI5);
                com.Parameters.AddWithValue("@KPI6", kp.KPI6);
                com.Parameters.AddWithValue("@KPI7", kp.KPI7);
                com.Parameters.AddWithValue("@KPI8", kp.KPI8);
                com.Parameters.AddWithValue("@KPI9", kp.KPI9);
                com.Parameters.AddWithValue("@KPI10", kp.KPI10);
                com.Parameters.AddWithValue("@KPI11", kp.KPI11);
                com.Parameters.AddWithValue("@KPI12", kp.KPI12);
                if (ch=='I')
                    com.Parameters.AddWithValue("@Action", "InsertDtl");
                else if (ch=='U')
                    com.Parameters.AddWithValue("@Action", "UpdateDtl");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "DeleteDtl");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<corporate> vCORP(int id)
        {
            int FINkp1GRD, FINkp2GRD, FINkp3GRD, FINkp4GRD, FINkp51GRD, FINkp52GRD, FINkp53GRD, CUSkp1GRD, CUSkp2GRD, CUSkp3GRD, LGkp1GRD, LGkp2GRD, LGkp3GRD, LGkp4GRD, LGkp5GRD;
            int IBPkp1GRD, IBPkp2GRD, IBPkp3GRD, IBPkp4GRD;
            decimal FINkp1TGT, FINkp1ACT, FINkp2TGT, FINkp2ACT, FINkp3TGT, FINkp3ACT, FINkp4TGT, FINkp4ACT, FINkp51TGT, FINkp51ACT, FINkp52TGT, FINkp52ACT, FINkp53TGT, FINkp53ACT,  CUSkp1TGT, CUSkp1ACT, CUSkp2TGT, CUSkp2ACT, CUSkp3TGT, CUSkp3ACT, LGkp1TGT,  LGkp2TGT, LGkp3TGT, LGkp4TGT, LGkp5TGT, LGkp2ACT, LGkp5ACT;
            decimal IBPkp1TGT, IBPkp1ACT, IBPkp2TGT, IBPkp2ACT, IBPkp3TGT, IBPkp3ACT, IBPkp4TGT;
            string date1 = Convert.ToString(id) + "-01" + "-01";
            string date2 = Convert.ToString(id) + "-31" + "-12";

            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@DATE1", date1);
                com.Parameters.AddWithValue("@DATE2", date2);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "CORP");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // finance revenue
                        if (rdr["finRevGrd"] == DBNull.Value)
                            FINkp1GRD = 0;
                        else
                            FINkp1GRD = Convert.ToInt32(rdr["finRevGrd"]);

                        if (rdr["finRevTrg"] == DBNull.Value)
                            FINkp1TGT = 0;
                        else
                            FINkp1TGT = Convert.ToDecimal(rdr["finRevTrg"]);

                        if (rdr["finRevAct"] == DBNull.Value)
                            FINkp1ACT = 0;
                        else
                            FINkp1ACT = Convert.ToDecimal(rdr["finRevAct"]);
                        // finance production output casting
                        if (rdr["finGrdProdCast"] == DBNull.Value)
                            FINkp2GRD = 0;
                        else
                            FINkp2GRD = Convert.ToInt32(rdr["finGrdProdCast"]);

                        if (rdr["finTgtProdCast"] == DBNull.Value)
                            FINkp2TGT = 0;
                        else
                            FINkp2TGT = Convert.ToDecimal(rdr["finTgtProdCast"]);

                        if (rdr["finActProdCast"] == DBNull.Value)
                            FINkp2ACT = 0;
                        else
                            FINkp2ACT = Convert.ToDecimal(rdr["finActProdCast"]);

                        // finance production output machining
                        if (rdr["finGrdProdMach"] == DBNull.Value)
                            FINkp3GRD = 0;
                        else
                            FINkp3GRD = Convert.ToInt32(rdr["finGrdProdMach"]);

                        if (rdr["finTgtProdMach"] == DBNull.Value)
                            FINkp3TGT = 0;
                        else
                            FINkp3TGT = Convert.ToDecimal(rdr["finTgtProdMach"]);

                        if (rdr["finActProdMach"] == DBNull.Value)
                            FINkp3ACT = 0;
                        else
                            FINkp3ACT = Convert.ToDecimal(rdr["finActProdMach"]);

                        // finance cashflow
                        if (rdr["finGrdCash"] == DBNull.Value)
                            FINkp4GRD = 0;
                        else
                            FINkp4GRD = Convert.ToInt32(rdr["finGrdCash"]);

                        if (rdr["finTgtCash"] == DBNull.Value)
                            FINkp4TGT = 0;
                        else
                            FINkp4TGT = Convert.ToDecimal(rdr["finTgtCash"]);

                        if (rdr["finActCash"] == DBNull.Value)
                            FINkp4ACT = 0;
                        else
                            FINkp4ACT = Convert.ToDecimal(rdr["finActCash"]);

                        // finance reduction casting
                        if (rdr["finGrdRedCast"] == DBNull.Value)
                            FINkp51GRD = 0;
                        else
                            FINkp51GRD = Convert.ToInt32(rdr["finGrdRedCast"]);

                        if (rdr["finTgtRedCast"] == DBNull.Value)
                            FINkp51TGT = 0;
                        else
                            FINkp51TGT = Convert.ToDecimal(rdr["finTgtRedCast"]);

                        if (rdr["finActRedCast"] == DBNull.Value)
                            FINkp51ACT = 0;
                        else
                            FINkp51ACT = Convert.ToDecimal(rdr["finActRedCast"]);

                        // finance reduction machining
                        if (rdr["finGrdRedMach"] == DBNull.Value)
                            FINkp52GRD = 0;
                        else
                            FINkp52GRD = Convert.ToInt32(rdr["finGrdRedMach"]);

                        if (rdr["finTgtRedMach"] == DBNull.Value)
                            FINkp52TGT = 0;
                        else
                            FINkp52TGT = Convert.ToDecimal(rdr["finTgtRedMach"]);

                        if (rdr["finActRedMach"] == DBNull.Value)
                            FINkp52ACT = 0;
                        else
                            FINkp52ACT = Convert.ToDecimal(rdr["finActRedMach"]);

                        // finance reduction purchasing
                        if (rdr["finGrdRedPurc"] == DBNull.Value)
                            FINkp53GRD = 0;
                        else
                            FINkp53GRD = Convert.ToInt32(rdr["finGrdRedPurc"]);

                        if (rdr["finTgtRedPurc"] == DBNull.Value)
                            FINkp53TGT = 0;
                        else
                            FINkp53TGT = Convert.ToDecimal(rdr["finTgtRedPurc"]);

                        if (rdr["finActRedPurc"] == DBNull.Value)
                            FINkp53ACT = 0;
                        else
                            FINkp53ACT = Convert.ToDecimal(rdr["finActRedPurc"]);

                        // cus DRM 
                        if (rdr["cusGrdDrm"] == DBNull.Value)
                            CUSkp1GRD = 0;
                        else
                            CUSkp1GRD = Convert.ToInt32(rdr["cusGrdDrm"]);

                        if (rdr["cusTgtDrm"] == DBNull.Value)
                            CUSkp1TGT = 0;
                        else
                            CUSkp1TGT = Convert.ToDecimal(rdr["cusTgtDrm"]);

                        if (rdr["cusActDrm"] == DBNull.Value)
                            CUSkp1ACT = 0;
                        else
                            CUSkp1ACT = Convert.ToDecimal(rdr["cusActDrm"]);

                        // cus CSI 
                        if (rdr["cusGrdCsi"] == DBNull.Value)
                            CUSkp2GRD = 0;
                        else
                            CUSkp2GRD = Convert.ToInt32(rdr["cusGrdCsi"]);

                        if (rdr["cusTgtCsi"] == DBNull.Value)
                            CUSkp2TGT = 0;
                        else
                            CUSkp2TGT = Convert.ToDecimal(rdr["cusTgtCsi"]);

                        if (rdr["cusActCsi"] == DBNull.Value)
                            CUSkp2ACT = 0;
                        else
                            CUSkp2ACT = Convert.ToDecimal(rdr["cusActCsi"]);

                        // cus AIR 
                        if (rdr["cusGrdAir"] == DBNull.Value)
                            CUSkp3GRD = 0;
                        else
                            CUSkp3GRD = Convert.ToInt32(rdr["cusGrdAir"]);

                        if (rdr["cusTgtAir"] == DBNull.Value)
                            CUSkp3TGT = 0;
                        else
                            CUSkp3TGT = Convert.ToDecimal(rdr["cusTgtAir"]);

                        if (rdr["cusActAir"] == DBNull.Value)
                            CUSkp3ACT = 0;
                        else
                            CUSkp3ACT = Convert.ToDecimal(rdr["cusActAir"]);


                        //-- cus IBP REJECT CASTING
                        if (rdr["ibpGrdRjtCast"] == DBNull.Value)
                            IBPkp1GRD = 0;
                        else
                            IBPkp1GRD = Convert.ToInt32(rdr["ibpGrdRjtCast"]);

                        if (rdr["ibpTgtRjtCast"] == DBNull.Value)
                            IBPkp1TGT = 0;
                        else
                            IBPkp1TGT = Convert.ToDecimal(rdr["ibpTgtRjtCast"]);

                        if (rdr["ibpActRjtCast"] == DBNull.Value)
                            IBPkp1ACT = 0;
                        else
                            IBPkp1ACT = Convert.ToDecimal(rdr["ibpActRjtCast"]);
                        //-- cus IBP REJECT MACHINING
                        if (rdr["ibpGrdRjtMac"] == DBNull.Value)
                            IBPkp2GRD = 0;
                        else
                            IBPkp2GRD = Convert.ToInt32(rdr["ibpGrdRjtMac"]);

                        if (rdr["ibpTgtRjtMac"] == DBNull.Value)
                            IBPkp2TGT = 0;
                        else
                            IBPkp2TGT = Convert.ToDecimal(rdr["ibpTgtRjtMac"]);

                        if (rdr["ibpActRjtMac"] == DBNull.Value)
                            IBPkp2ACT = 0;
                        else
                            IBPkp2ACT = Convert.ToDecimal(rdr["ibpActRjtMac"]);
                        //-- cus IBP CUSTOMER-CN
                        if (rdr["ibpGrdCN"] == DBNull.Value)
                            IBPkp3GRD = 0;
                        else
                            IBPkp3GRD = Convert.ToInt32(rdr["ibpGrdCN"]);

                        if (rdr["ibpTgtCN"] == DBNull.Value)
                            IBPkp3TGT = 0;
                        else
                            IBPkp3TGT = Convert.ToDecimal(rdr["ibpTgtCN"]);

                        if (rdr["ibpActCN"] == DBNull.Value)
                            IBPkp3ACT = 0;
                        else
                            IBPkp3ACT = Convert.ToDecimal(rdr["ibpActCN"]);

                        //-- cus IBP safety index
                        if (rdr["ibpGrdSafe"] == DBNull.Value)
                            IBPkp4GRD = 0;
                        else
                            IBPkp4GRD = Convert.ToInt32(rdr["ibpGrdSafe"]);

                        if (rdr["ibpTgtSafe"] == DBNull.Value)
                            IBPkp4TGT = 0;
                        else
                            IBPkp4TGT = Convert.ToDecimal(rdr["ibpTgtSafe"]);

                        // LG 5-S join HRD
                        if (rdr["lgGrdImp"] == DBNull.Value)
                            LGkp1GRD = 0;
                        else
                            LGkp1GRD = Convert.ToInt32(rdr["lgGrdImp"]);

                        if (rdr["lgTgtImp"] == DBNull.Value)
                            LGkp1TGT = 0;
                        else
                            LGkp1TGT = Convert.ToDecimal(rdr["lgTgtImp"]);

                        // LG IBPT
                        if (rdr["lgGrdIsCap"] == DBNull.Value)
                            LGkp2GRD = 0;
                        else
                            LGkp2GRD = Convert.ToInt32(rdr["lgGrdIsCap"]);

                        if (rdr["lgTgtIsCap"] == DBNull.Value)
                            LGkp2TGT = 0;
                        else
                            LGkp2TGT = Convert.ToDecimal(rdr["lgTgtIsCap"]);

                        if (rdr["lgActIsCap"] == DBNull.Value)
                            LGkp2ACT = 0;
                        else
                            LGkp2ACT = Convert.ToDecimal(rdr["lgActIsCap"]);
                        
                        // LG TRAINING join HRD
                        if (rdr["lgGrdTrain"] == DBNull.Value)
                            LGkp3GRD = 0;
                        else
                            LGkp3GRD = Convert.ToInt32(rdr["lgGrdTrain"]);

                        if (rdr["lgTgtTrain"] == DBNull.Value)
                            LGkp3TGT = 0;
                        else
                            LGkp3TGT = Convert.ToDecimal(rdr["lgTgtTrain"]);
                        // LG SKILL join HRD
                        if (rdr["lgGrdSkill"] == DBNull.Value)
                            LGkp4GRD = 0;
                        else
                            LGkp4GRD = Convert.ToInt32(rdr["lgGrdSkill"]);

                        if (rdr["lgTgtSkill"] == DBNull.Value)
                            LGkp4TGT = 0;
                        else
                            LGkp4TGT = Convert.ToDecimal(rdr["lgTgtSkill"]);
                        // LG MOTIVATION join HRD
                        if (rdr["lgGrdMot"] == DBNull.Value)
                            LGkp5GRD = 0;
                        else
                            LGkp5GRD = Convert.ToInt32(rdr["lgGrdMot"]);

                        if (rdr["lgTgtMot"] == DBNull.Value)
                            LGkp5TGT = 0;
                        else
                            LGkp5TGT = Convert.ToDecimal(rdr["lgTgtMot"]);

                        if (rdr["lgActMot"] == DBNull.Value)
                            LGkp5ACT = 0;
                        else
                            LGkp5ACT = Convert.ToDecimal(rdr["lgActMot"]);


                        lst.Add(new corporate
                        {
                            finGrdRev = FINkp1GRD,
                            finTgtRev = FINkp1TGT,
                            finActRev = FINkp1ACT,

                            finGrdProdCast = FINkp2GRD,
                            finTgtProdCast = FINkp2TGT,
                            finActProdCast = FINkp2ACT,

                            finGrdProdMach = FINkp3GRD,
                            finTgtProdMach = FINkp3TGT,
                            finActProdMach = FINkp3ACT,

                            finGrdCash = FINkp4GRD,
                            finTgtCash = FINkp4TGT,
                            finActCash = FINkp4ACT,

                            finGrdRedCast = FINkp51GRD,
                            finTgtRedCast = FINkp51TGT,
                            finActRedCast = FINkp51ACT,

                            finGrdRedMach = FINkp52GRD,
                            finTgtRedMach = FINkp52TGT,
                            finActRedMach = FINkp52ACT,

                            finGrdRedPurc = FINkp53GRD,
                            finTgtRedPurc = FINkp53TGT,
                            finActRedPurc = FINkp53ACT,

                            cusGrdDrm = CUSkp1GRD,
                            cusTgtDrm = CUSkp1TGT,
                            cusActDrm = CUSkp1ACT,

                            cusGrdCsi = CUSkp2GRD,
                            cusTgtCsi = CUSkp2TGT,
                            cusActCsi = CUSkp2ACT,

                            cusGrdAir = CUSkp3GRD,
                            cusTgtAir = CUSkp3TGT,
                            cusActAir = CUSkp3ACT,

                            ibpGrdRjtCast = IBPkp1GRD,
                            ibpTgtRjtCast = IBPkp1TGT,
                            ibpActRjtCast = IBPkp1ACT,

                            ibpGrdRjtMac = IBPkp2GRD,
                            ibpTgtRjtMac = IBPkp2TGT,
                            ibpActRjtMac = IBPkp2ACT,

                            ibpGrdCN = IBPkp3GRD,
                            ibpTgtCN = IBPkp3TGT,
                            ibpActCN = IBPkp3ACT,

                            ibpGrdSafe = IBPkp4GRD,
                            ibpTgtSafe = IBPkp4TGT,

                            lgGrdImp = LGkp1GRD,
                            lgTgtImp = LGkp1TGT,

                            lgGrdIsCap = LGkp2GRD,
                            lgTgtIsCap = LGkp2TGT,
                            lgActIsCap = LGkp2ACT,

                            lgGrdTrain = LGkp3GRD,
                            lgTgtTrain = LGkp3TGT,

                            lgGrdSkill = LGkp4GRD,
                            lgTgtSkill = LGkp4TGT,

                            lgGrdMot = LGkp5GRD,
                            lgTgtMot = LGkp5TGT,
                            lgActMot = LGkp5ACT
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDkpiDesc(KPI kp, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDDESC", kp.iddesc);
                com.Parameters.AddWithValue("@GROUP", kp.group);
                com.Parameters.AddWithValue("@DESC", kp.desc);
                com.Parameters.AddWithValue("@SORT", kp.sort);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "InsertHdr");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "UpdateHdr");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "DeleteHdr");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<KPI> viewKPIDesc(char ch, int id)
        {
            int rows;
            List<KPI> lst = new List<KPI>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.Parameters.AddWithValue("@IDDESC", id);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'S')
                    com.Parameters.AddWithValue("@Action", "ShowHdr");
                else if (ch == 'B')
                {
                    com.Parameters.AddWithValue("@Action", "ShowByIDHdr");
                }
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["sort"] == DBNull.Value)
                            rows = 0;
                        else
                            rows = Convert.ToInt32(rdr["sort"]);
                        lst.Add(new KPI
                        {
                            iddesc = Convert.ToInt32(rdr["iddesc"]),
                            desc = rdr["desc"].ToString(),
                            group = rdr["group"].ToString(),
                            sort = rows
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }
        //----graph
        public List<ViewChart> GraphRevenueAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "RevenueAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);

                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai/1000000,2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphProdCastAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "CastingAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai / 1000, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphProdMachAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "MachineAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai / 1000000,2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphCashflowAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "CashflowAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai / 1000000, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphCostRedCastAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "CostReducCastAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);

                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai / 1000000, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphCostRedMachAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "CostReducMachAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);

                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai / 1000, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphCostRedPurcAct(int iyear)
        {
            string date1 = Convert.ToString(iyear) + "-01" + "-01";
            string date2 = Convert.ToString(iyear) + "-12" + "-01";

            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@DATE1", date1);
                com.Parameters.AddWithValue("@DATE2", date2);
                com.Parameters.AddWithValue("@Action", "CostReducPurcAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);

                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai / 1000, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphDRMAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "DRMAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);

                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai,2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphAIRAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "AIRAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphCSIAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "CSIAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphIsCapAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "IsCapAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphMotAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "MotAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }



        public List<ViewChart> GraphRejCastAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "REJCASTAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai,2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphRejMachAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "REJMACHAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphCNAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "CNAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }


        public List<ViewChart> GraphTgt(int iyear, int choice)
        {
            decimal jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec;
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                if (choice == 1)
                    com.Parameters.AddWithValue("@Action", "RevenueTgt");
                else if (choice == 2)
                    com.Parameters.AddWithValue("@Action", "CastingTgt");
                else if (choice == 3)
                    com.Parameters.AddWithValue("@Action", "MachineTgt");
                else if (choice == 4)
                    com.Parameters.AddWithValue("@Action", "CashflowTgt");
                else if (choice == 5)
                    com.Parameters.AddWithValue("@Action", "CostReducTgt");
                else if (choice == 6)
                    com.Parameters.AddWithValue("@Action", "DRMTgt");
                else if (choice == 7)
                    com.Parameters.AddWithValue("@Action", "AIRTgt");
                else if (choice == 8)
                    com.Parameters.AddWithValue("@Action", "REJCASTTgt");
                else if (choice == 9)
                    com.Parameters.AddWithValue("@Action", "REJMACHTgt");
                else if (choice == 10)
                    com.Parameters.AddWithValue("@Action", "CNTgt");
                else if (choice == 11)
                    com.Parameters.AddWithValue("@Action", "SafetyTgt");
                else if (choice == 12)
                    com.Parameters.AddWithValue("@Action", "AveTgt");
                else if (choice == 13)
                    com.Parameters.AddWithValue("@Action", "ISTgt");
                else if (choice == 14)
                    com.Parameters.AddWithValue("@Action", "TrainTgt");
                else if (choice == 15)
                    com.Parameters.AddWithValue("@Action", "SkillTgt");
                else if (choice == 16)
                    com.Parameters.AddWithValue("@Action", "AwareTgt");
                else if (choice == 17)
                    com.Parameters.AddWithValue("@Action", "CSITgt");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["KPI1"] == DBNull.Value)
                            jan = 0;
                        else
                            jan = Convert.ToDecimal(rdr["KPI1"]);
                        if (rdr["KPI2"] == DBNull.Value)
                            feb = 0;
                        else
                            feb = Convert.ToDecimal(rdr["KPI2"]);
                        if (rdr["KPI3"] == DBNull.Value)
                            mar = 0;
                        else
                            mar = Convert.ToDecimal(rdr["KPI3"]);
                        if (rdr["KPI4"] == DBNull.Value)
                            apr = 0;
                        else
                            apr = Convert.ToDecimal(rdr["KPI4"]);
                        if (rdr["KPI5"] == DBNull.Value)
                            may = 0;
                        else
                            may = Convert.ToDecimal(rdr["KPI5"]);
                        if (rdr["KPI6"] == DBNull.Value)
                            jun = 0;
                        else
                            jun = Convert.ToDecimal(rdr["KPI6"]);
                        if (rdr["KPI7"] == DBNull.Value)
                            jul = 0;
                        else
                            jul = Convert.ToDecimal(rdr["KPI7"]);
                        if (rdr["KPI8"] == DBNull.Value)
                            aug = 0;
                        else
                            aug = Convert.ToDecimal(rdr["KPI8"]);
                        if (rdr["KPI9"] == DBNull.Value)
                            sep = 0;
                        else
                            sep = Convert.ToDecimal(rdr["KPI9"]);
                        if (rdr["KPI10"] == DBNull.Value)
                            oct = 0;
                        else
                            oct = Convert.ToDecimal(rdr["KPI10"]);
                        if (rdr["KPI11"] == DBNull.Value)
                            nov = 0;
                        else
                            nov = Convert.ToDecimal(rdr["KPI11"]);
                        if (rdr["KPI12"] == DBNull.Value)
                            dec = 0;
                        else
                            dec = Convert.ToDecimal(rdr["KPI12"]);

                        lst.Add(new ViewChart
                        {
                            bulan = 1,
                            amount = jan
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 2,
                            amount = feb
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 3,
                            amount = mar
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 4,
                            amount = apr
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 5,
                            amount = may
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 6,
                            amount = jun
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 7,
                            amount = jul
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 8,
                            amount = aug
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 9,
                            amount = sep
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 10,
                            amount = oct
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 11,
                            amount = nov
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 12,
                            amount = dec
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<ViewChart> GraphTgt2(int iyear, int choice)
        {
            decimal jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec;
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                if (choice == 1)
                    com.Parameters.AddWithValue("@Action", "RevenueTgt");
                else if (choice == 2)
                    com.Parameters.AddWithValue("@Action", "CastingTgt");
                else if (choice == 3)
                    com.Parameters.AddWithValue("@Action", "MachineTgt");
                else if (choice == 4)
                    com.Parameters.AddWithValue("@Action", "CashflowTgt");
                else if (choice == 5)
                    com.Parameters.AddWithValue("@Action", "CostReducTgt");
                else if (choice == 6)
                    com.Parameters.AddWithValue("@Action", "DRMTgt");
                else if (choice == 7)
                    com.Parameters.AddWithValue("@Action", "AIRTgt");
                else if (choice == 8)
                    com.Parameters.AddWithValue("@Action", "REJCASTTgt");
                else if (choice == 9)
                    com.Parameters.AddWithValue("@Action", "REJMACHTgt");
                else if (choice == 10)
                    com.Parameters.AddWithValue("@Action", "CNTgt");
                else if (choice == 11)
                    com.Parameters.AddWithValue("@Action", "SafetyTgt");
                else if (choice == 12)
                    com.Parameters.AddWithValue("@Action", "AveTgt");
                else if (choice == 13)
                    com.Parameters.AddWithValue("@Action", "ISTgt");
                else if (choice == 14)
                    com.Parameters.AddWithValue("@Action", "TrainTgt");
                else if (choice == 15)
                    com.Parameters.AddWithValue("@Action", "SkillTgt");
                else if (choice == 16)
                    com.Parameters.AddWithValue("@Action", "AwareTgt");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["KPI1"] == DBNull.Value)
                            jan = 0;
                        else
                            jan = Convert.ToDecimal(rdr["KPI1"]);
                        if (rdr["KPI2"] == DBNull.Value)
                            feb = 0;
                        else
                            feb = Convert.ToDecimal(rdr["KPI2"]);
                        if (rdr["KPI3"] == DBNull.Value)
                            mar = 0;
                        else
                            mar = Convert.ToDecimal(rdr["KPI3"]);
                        if (rdr["KPI4"] == DBNull.Value)
                            apr = 0;
                        else
                            apr = Convert.ToDecimal(rdr["KPI4"]);
                        if (rdr["KPI5"] == DBNull.Value)
                            may = 0;
                        else
                            may = Convert.ToDecimal(rdr["KPI5"]);
                        if (rdr["KPI6"] == DBNull.Value)
                            jun = 0;
                        else
                            jun = Convert.ToDecimal(rdr["KPI6"]);
                        if (rdr["KPI7"] == DBNull.Value)
                            jul = 0;
                        else
                            jul = Convert.ToDecimal(rdr["KPI7"]);
                        if (rdr["KPI8"] == DBNull.Value)
                            aug = 0;
                        else
                            aug = Convert.ToDecimal(rdr["KPI8"]);
                        if (rdr["KPI9"] == DBNull.Value)
                            sep = 0;
                        else
                            sep = Convert.ToDecimal(rdr["KPI9"]);
                        if (rdr["KPI10"] == DBNull.Value)
                            oct = 0;
                        else
                            oct = Convert.ToDecimal(rdr["KPI10"]);
                        if (rdr["KPI11"] == DBNull.Value)
                            nov = 0;
                        else
                            nov = Convert.ToDecimal(rdr["KPI11"]);
                        if (rdr["KPI12"] == DBNull.Value)
                            dec = 0;
                        else
                            dec = Convert.ToDecimal(rdr["KPI12"]);

                        lst.Add(new ViewChart
                        {
                            bulan = 1,
                            amount = jan
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 2,
                            amount = feb
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 3,
                            amount = mar
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 4,
                            amount = apr
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 5,
                            amount = may
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 6,
                            amount = jun
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 7,
                            amount = jul
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 8,
                            amount = aug
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 9,
                            amount = sep
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 10,
                            amount = oct
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 11,
                            amount = nov
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 12,
                            amount = dec
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphTgtThousand(int iyear, int choice)
        {
            decimal jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov, dec;
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                if (choice == 1)
                    com.Parameters.AddWithValue("@Action", "RevenueTgt");
                else if (choice == 2)
                    com.Parameters.AddWithValue("@Action", "CastingTgt");
                else if (choice == 3)
                    com.Parameters.AddWithValue("@Action", "MachineTgt");
                else if (choice == 4)
                    com.Parameters.AddWithValue("@Action", "CashflowTgt");
                else if (choice == 51)
                    com.Parameters.AddWithValue("@Action", "CostReducCastTgt");
                else if (choice == 52)
                    com.Parameters.AddWithValue("@Action", "CostReducMachTgt");
                else if (choice == 53)
                    com.Parameters.AddWithValue("@Action", "CostReducPurcTgt");
                else if (choice == 6)
                    com.Parameters.AddWithValue("@Action", "DRMTgt");
                else if (choice == 7)
                    com.Parameters.AddWithValue("@Action", "AIRTgt");
                else if (choice == 8)
                    com.Parameters.AddWithValue("@Action", "REJCASTTgt");
                else if (choice == 9)
                    com.Parameters.AddWithValue("@Action", "REJMACHTgt");
                else if (choice == 10)
                    com.Parameters.AddWithValue("@Action", "CNTgt");
                else if (choice == 11)
                    com.Parameters.AddWithValue("@Action", "SafetyTgt");
                else if (choice == 12)
                    com.Parameters.AddWithValue("@Action", "AveTgt");
                else if (choice == 13)
                    com.Parameters.AddWithValue("@Action", "ISTgt");
                else if (choice == 14)
                    com.Parameters.AddWithValue("@Action", "TrainTgt");
                else if (choice == 15)
                    com.Parameters.AddWithValue("@Action", "SkillTgt");
                else if (choice == 16)
                    com.Parameters.AddWithValue("@Action", "AwareTgt");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["KPI1"] == DBNull.Value)
                            jan = 0;
                        else
                            jan = Convert.ToDecimal(rdr["KPI1"]) / 1000;
                        if (rdr["KPI2"] == DBNull.Value)
                            feb = 0;
                        else
                            feb = Convert.ToDecimal(rdr["KPI2"]) / 1000;
                        if (rdr["KPI3"] == DBNull.Value)
                            mar = 0;
                        else
                            mar = Convert.ToDecimal(rdr["KPI3"]) / 1000;
                        if (rdr["KPI4"] == DBNull.Value)
                            apr = 0;
                        else
                            apr = Convert.ToDecimal(rdr["KPI4"]) / 1000;
                        if (rdr["KPI5"] == DBNull.Value)
                            may = 0;
                        else
                            may = Convert.ToDecimal(rdr["KPI5"]) / 1000;
                        if (rdr["KPI6"] == DBNull.Value)
                            jun = 0;
                        else
                            jun = Convert.ToDecimal(rdr["KPI6"]) / 1000;
                        if (rdr["KPI7"] == DBNull.Value)
                            jul = 0;
                        else
                            jul = Convert.ToDecimal(rdr["KPI7"]) / 1000;
                        if (rdr["KPI8"] == DBNull.Value)
                            aug = 0;
                        else
                            aug = Convert.ToDecimal(rdr["KPI8"]) / 1000;
                        if (rdr["KPI9"] == DBNull.Value)
                            sep = 0;
                        else
                            sep = Convert.ToDecimal(rdr["KPI9"]) / 1000;
                        if (rdr["KPI10"] == DBNull.Value)
                            oct = 0;
                        else
                            oct = Convert.ToDecimal(rdr["KPI10"]) / 1000;
                        if (rdr["KPI11"] == DBNull.Value)
                            nov = 0;
                        else
                            nov = Convert.ToDecimal(rdr["KPI11"]) / 1000;
                        if (rdr["KPI12"] == DBNull.Value)
                            dec = 0;
                        else
                            dec = Convert.ToDecimal(rdr["KPI12"]) / 1000;

                        lst.Add(new ViewChart
                        {
                            bulan = 1,
                            amount = Math.Round(jan,2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 2,
                            amount = Math.Round(feb, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 3,
                            amount = Math.Round(mar, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 4,
                            amount = Math.Round(apr, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 5,
                            amount = Math.Round(may, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 6,
                            amount = Math.Round(jun, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 7,
                            amount = Math.Round(jul, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 8,
                            amount = Math.Round(aug, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 9,
                            amount = Math.Round(sep, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 10,
                            amount = Math.Round(oct, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 11,
                            amount = Math.Round(nov, 2)
                        });
                        lst.Add(new ViewChart
                        {
                            bulan = 12,
                            amount = Math.Round(dec, 2)
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<ViewChart> GraphTgtMilliun(int iyear, int choice)
        {
            decimal jan, feb, mar, apr, may, jun, jul, aug, sep, oct, nov,dec;
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                if (choice==1)
                    com.Parameters.AddWithValue("@Action", "RevenueTgt");
                else if (choice == 2)                    
                    com.Parameters.AddWithValue("@Action", "CastingTgt");
                else if (choice == 3)
                    com.Parameters.AddWithValue("@Action", "MachineTgt");
                else if (choice == 4)
                    com.Parameters.AddWithValue("@Action", "CashflowTgt");
                else if (choice == 51)
                    com.Parameters.AddWithValue("@Action", "CostReducCastTgt");
                else if (choice == 52)
                    com.Parameters.AddWithValue("@Action", "CostReducMachTgt");
                else if (choice == 53)
                    com.Parameters.AddWithValue("@Action", "CostReducPurcTgt");
                else if (choice == 6)
                    com.Parameters.AddWithValue("@Action", "DRMTgt");
                else if (choice == 7)
                    com.Parameters.AddWithValue("@Action", "AIRTgt");
                else if (choice == 8)
                    com.Parameters.AddWithValue("@Action", "REJCASTTgt");
                else if (choice == 9)
                    com.Parameters.AddWithValue("@Action", "REJMACHTgt");
                else if (choice == 10)
                    com.Parameters.AddWithValue("@Action", "CNTgt");
                else if (choice == 11)
                    com.Parameters.AddWithValue("@Action", "SafetyTgt");
                else if (choice == 12)
                    com.Parameters.AddWithValue("@Action", "AveTgt");
                else if (choice == 13)
                    com.Parameters.AddWithValue("@Action", "ISTgt");
                else if (choice == 14)
                    com.Parameters.AddWithValue("@Action", "TrainTgt");
                else if (choice == 15)
                    com.Parameters.AddWithValue("@Action", "SkillTgt");
                else if (choice == 16)
                    com.Parameters.AddWithValue("@Action", "AwareTgt");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["KPI1"] == DBNull.Value)
                            jan = 0;
                        else
                            jan = Convert.ToDecimal(rdr["KPI1"]) / 1000000;
                        if (rdr["KPI2"] == DBNull.Value)
                            feb = 0;
                        else
                            feb = Convert.ToDecimal(rdr["KPI2"]) / 1000000;
                        if (rdr["KPI3"] == DBNull.Value)
                            mar = 0;
                        else
                            mar = Convert.ToDecimal(rdr["KPI3"]) / 1000000;
                        if (rdr["KPI4"] == DBNull.Value)
                            apr = 0;
                        else
                            apr = Convert.ToDecimal(rdr["KPI4"]) / 1000000;
                        if (rdr["KPI5"] == DBNull.Value)
                            may = 0;
                        else
                            may = Convert.ToDecimal(rdr["KPI5"]) / 1000000;
                        if (rdr["KPI6"] == DBNull.Value)
                            jun = 0;
                        else
                            jun = Convert.ToDecimal(rdr["KPI6"]) / 1000000;
                        if (rdr["KPI7"] == DBNull.Value)
                            jul = 0;
                        else
                            jul = Convert.ToDecimal(rdr["KPI7"]) / 1000000;
                        if (rdr["KPI8"] == DBNull.Value)
                            aug = 0;
                        else
                            aug = Convert.ToDecimal(rdr["KPI8"]) / 1000000;
                        if (rdr["KPI9"] == DBNull.Value)
                            sep = 0;
                        else
                            sep = Convert.ToDecimal(rdr["KPI9"]) / 1000000;
                        if (rdr["KPI10"] == DBNull.Value)
                            oct = 0;
                        else
                            oct = Convert.ToDecimal(rdr["KPI10"]) / 1000000;
                        if (rdr["KPI11"] == DBNull.Value)
                            nov = 0;
                        else
                             nov = Convert.ToDecimal(rdr["KPI11"]) / 1000000;
                        if (rdr["KPI12"] == DBNull.Value)
                            dec = 0;
                        else
                            dec = Convert.ToDecimal(rdr["KPI12"]) / 1000000;

                        lst.Add(new ViewChart
                            {
                                bulan = 1,
                                amount = Math.Round(jan,2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 2,
                                amount = Math.Round(feb, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 3,
                                amount = Math.Round(mar, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 4,
                                amount = Math.Round(apr, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 5,
                                amount = Math.Round(may, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 6,
                                amount = Math.Round(jun, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 7,
                                amount = Math.Round(jul, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 8,
                                amount = Math.Round(aug, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 9,
                                amount = Math.Round(sep, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 10,
                                amount = Math.Round(oct, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 11,
                                amount = Math.Round(nov, 2)
                            });
                            lst.Add(new ViewChart
                            {
                                bulan = 12,
                                amount = Math.Round(dec, 2)
                            });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public int CRUDkpiDept(KPIDept kp, char ch)
        {
            int i;
            string spBegda=null;
            if (ch != 'D')
            {
                string tglA = "01";
                string blnA = kp.period.Substring(0, 2);
                string thnA = kp.period.Substring(3, 4);
                spBegda = thnA + "/" + blnA + "/" + tglA;
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                com.Parameters.AddWithValue("@IDDESC", kp.iddesc);
                com.Parameters.AddWithValue("@DDATE", spBegda);
                com.Parameters.AddWithValue("@GRADE", kp.grade);
                com.Parameters.AddWithValue("@TARGET", kp.target);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "InsertDtl");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "UpdateDtl");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "DeleteDtl");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<KPIDept> viewCorporateDept()
        {
            decimal kp;
            List<KPIDept> lst = new List<KPIDept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Show");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["target"] == DBNull.Value)
                            kp = 0;
                        else
                            kp = Convert.ToDecimal(rdr["target"]);

                        //if (rdr["RATE"] == DBNull.Value)
                        //    rate = 0;
                        //else
                        //    rate = Math.Round(Convert.ToDecimal(rdr["RATE"])/12,2);

                        lst.Add(new KPIDept
                        {
                            idkpi = Convert.ToInt32(rdr["idkpi"]),
                            iddesc = Convert.ToInt32(rdr["iddesc"]),
                            period = string.Format("{0:MM-yyyy }", rdr["period"]),
                            grade = Convert.ToInt32(rdr["grade"]),
                            desc = rdr["desc"].ToString(),
                            group = rdr["group"].ToString(),
                            target = kp

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<KPIDept> viewCorporateDeptByID(int id)
        {
            decimal kp1;
            List<KPIDept> lst = new List<KPIDept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@ID", id);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "ShowByID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["target"] == DBNull.Value)
                            kp1 = 0;
                        else
                            kp1 = Convert.ToDecimal(rdr["target"]);



                        lst.Add(new KPIDept
                        {
                            idkpi = Convert.ToInt32(rdr["idkpi"]),
                            iddesc = Convert.ToInt32(rdr["iddesc"]),
                            period = string.Format("{0:MM-yyyy }", rdr["period"]),
                            grade = Convert.ToInt32(rdr["grade"]),
                            desc = rdr["desc"].ToString(),
                            group = rdr["group"].ToString(),
                            target = kp1,

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vCORPDept(int id)
        {
            decimal MktRevGrd , MktRevTrg, MktRevAct, MktCusGrd, MktCusTrg, MktCusAct, MktSatGrd, MktSatTrg, MktSatAct;
            decimal MktRevAch, TmpMktRevAch, MktCusAch,TmpMktCusAct, MktSatAch, TmpMktSatAct;
            decimal MktRevScr, MktCusScr, MktSatScr;
            decimal MktDrmGrd, MktDrmTrg, MktDrmAct, MktDrmAch, TmpMktDrmAct, MktDrmScr, MktAirGrd, MktAirTrg, MktAirAct, MktAirAch, TmpMktAirAch, MktAirScr;
            double dMktSatAct;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "CORP");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // marketing revenue
                        if (rdr["MktRevGrd"] == DBNull.Value)
                            MktRevGrd = 0;
                        else
                            MktRevGrd = Math.Round(Convert.ToDecimal(rdr["MktRevGrd"]) / 12, 2);

                        if (rdr["MktRevTrg"] == DBNull.Value)
                            MktRevTrg = 0;
                        else
                            MktRevTrg = Convert.ToDecimal(rdr["MktRevTrg"]);

                        if (rdr["MktRevAct"] == DBNull.Value)
                            MktRevAct = 0;
                        else
                            MktRevAct = Convert.ToDecimal(rdr["MktRevAct"]);

                        if (MktRevTrg > 0)
                            MktRevAch = MktRevAct / MktRevTrg * 100;
                        else
                            MktRevAch = 0;
                        TmpMktRevAch = 0;
                        /* rumus 2021
                        if (MktRevAch > 110)
                            TmpMktRevAch = 120;
                        else if (MktRevAch > 103 && MktRevAch <= 110)
                            TmpMktRevAch = 110;
                        else if (MktRevAch > 95 && MktRevAch <= 103)
                            TmpMktRevAch = 100;
                        else if (MktRevAch >= 90 && MktRevAch <= 95)
                            TmpMktRevAch = 90;
                        else if (MktRevAch < 90)
                            TmpMktRevAch = 60;
                         */
                        if (MktRevAch >= 103)
                            TmpMktRevAch = 110;
                        else if (MktRevAch >= 97 && MktRevAch < 103)
                            TmpMktRevAch = 100;
                        else if (MktRevAch >= 91 && MktRevAch < 97)
                            TmpMktRevAch = 90;
                        else if (MktRevAch < 91)
                            TmpMktRevAch = 60;

                        MktRevScr = MktRevGrd * TmpMktRevAch / 100;

                        // marketing new customer
                        if (rdr["MktCusGrd"] == DBNull.Value)
                            MktCusGrd = 0;
                        else
                            MktCusGrd = Math.Round(Convert.ToDecimal(rdr["MktCusGrd"]) / 12, 2);

                        if (rdr["MktCusTrg"] == DBNull.Value)
                            MktCusTrg = 0;
                        else
                            MktCusTrg = Convert.ToDecimal(rdr["MktCusTrg"]);

                        if (rdr["MktCusAct"] == DBNull.Value)
                            MktCusAct = 0;
                        else
                            MktCusAct = Convert.ToDecimal(rdr["MktCusAct"]);

                        if (MktCusTrg > 0)
                            MktCusAch = MktCusAct / MktCusTrg * 100;
                        else
                            MktCusAch = 0;
                        TmpMktCusAct= 0;
                        /*rumus 2021
                        if (MktCusAct > 4)
                            TmpMktCusAct = 120;
                        else if (MktCusAct == 4)
                            TmpMktCusAct = 110;
                        else if (MktCusAct == 3)
                            TmpMktCusAct = 100;
                        else if (MktCusAct == 2)
                            TmpMktCusAct = 90;
                        else if (MktCusAct < 2)
                            TmpMktCusAct = 60;
                         */
                        if (MktCusAct > 1)
                            TmpMktCusAct = 110;
                        else if (MktCusAct == 1)
                            TmpMktCusAct = 100;
                        else if (MktCusAct < 1)
                            TmpMktCusAct = 0;

                        MktCusScr = MktCusGrd * TmpMktCusAct / 100;

                        // DRM MktDrmGrd, MktDrmTrg, MktDrmAct
                        if (rdr["MktDrmGrd"] == DBNull.Value)
                            MktDrmGrd = 0;
                        else
                            MktDrmGrd = Math.Round(Convert.ToDecimal(rdr["MktDrmGrd"]) / 12, 2);

                        if (rdr["MktDrmTrg"] == DBNull.Value)
                            MktDrmTrg = 0;
                        else
                            MktDrmTrg = Convert.ToDecimal(rdr["MktDrmTrg"]);

                        if (rdr["MktDrmAct"] == DBNull.Value)
                            MktDrmAct = 0;
                        else
                            MktDrmAct = Convert.ToDecimal(rdr["MktDrmAct"]);

                        if (MktDrmTrg > 0)
                            MktDrmAch = MktDrmAct / MktDrmTrg * 100;
                        else
                            MktDrmAch = 0;
                        TmpMktDrmAct = 0;
                        if (MktDrmAct > 95)
                            TmpMktDrmAct = 110;
                        else if (MktDrmAct > 85 && MktDrmAct<= 95)
                            TmpMktDrmAct = 100;
                        else if (MktDrmAct >= 80 && MktDrmAct <= 85)
                            TmpMktDrmAct = 90;
                        else if (MktDrmAct < 80)
                            TmpMktDrmAct = 60;
                        MktDrmScr = MktDrmGrd * TmpMktDrmAct / 100;

                        // Air MktAirGrd, MktAirTrg, MktAirAct
                        if (rdr["MktAirGrd"] == DBNull.Value)
                            MktAirGrd = 0;
                        else
                            MktAirGrd = Math.Round(Convert.ToDecimal(rdr["MktAirGrd"]) / 12, 2);

                        if (rdr["MktAirTrg"] == DBNull.Value)
                            MktAirTrg = 0;
                        else
                            MktAirTrg = Convert.ToDecimal(rdr["MktAirTrg"]);

                        if (rdr["MktAirAct"] == DBNull.Value)
                            MktAirAct = 0;
                        else
                            MktAirAct = Convert.ToDecimal(rdr["MktAirAct"]);

                        if (MktAirTrg > 0)
                            MktAirAch = MktAirAct / MktAirTrg * 100;
                        else
                            MktAirAch = 0;
                        TmpMktAirAch = 0;
                        if (MktAirAch < 95)
                            TmpMktAirAch = 110;
                        else if (MktAirAch >= 95 && MktAirAch <= 99)
                            TmpMktAirAch = 100;
                        else if (MktAirAch > 99 && MktAirAch <= 102)
                            TmpMktAirAch = 90;
                        else if (MktAirAch > 102)
                            TmpMktAirAch = 60;
                        MktAirScr = MktAirGrd * TmpMktAirAch / 100;

                        // Customer Satisfaction Index
                        if (rdr["MktSatGrd"] == DBNull.Value)
                            MktSatGrd = 0;
                        else
                            MktSatGrd = Math.Round(Convert.ToDecimal(rdr["MktSatGrd"]) / 12, 2);

                        if (rdr["MktSatTrg"] == DBNull.Value)
                            MktSatTrg = 0;
                        else
                            MktSatTrg = Convert.ToDecimal(rdr["MktSatTrg"]);

                        if (rdr["MktSatAct"] == DBNull.Value)
                            MktSatAct = 0;
                        else
                            MktSatAct = Convert.ToDecimal(rdr["MktSatAct"]);

                       
                        if (MktSatTrg > 0)
                            MktSatAch = MktSatAct / MktSatTrg * 100;
                        else
                            MktSatAch = 0;
                        TmpMktSatAct = 0;
                        dMktSatAct = Convert.ToDouble(MktSatAct);
                        /*- rumus 2021
                        if (dMktSatAct > 3.7)
                            TmpMktSatAct = 120;
                        else if (dMktSatAct > 3.4 && dMktSatAct <= 3.7)
                            TmpMktSatAct = 110;
                        else if (dMktSatAct > 3.2 && dMktSatAct <= 3.4)
                            TmpMktSatAct = 100;
                        else if (dMktSatAct >= 3 && dMktSatAct <= 3.2)
                            TmpMktSatAct = 90;
                        else if (dMktSatAct < 3)
                            TmpMktSatAct = 60;
                          */
                        if (dMktSatAct >= 3.8)
                            TmpMktSatAct = 120;
                        else if (dMktSatAct >= 3.5 && dMktSatAct < 3.8)
                            TmpMktSatAct = 100;
                        else if (dMktSatAct >= 3 && dMktSatAct < 3.5)
                            TmpMktSatAct = 90;
                        else if (dMktSatAct < 3)
                            TmpMktSatAct = 60;

                        MktSatScr = MktSatGrd * TmpMktSatAct / 100;


                        lst.Add(new corpdept
                        {
                            PicGrdRev = MktRevGrd,
                            PicTgtRev = MktRevTrg,
                            PicActRev = MktRevAct,
                            PicAchRev = MktRevAch,
                            PicScrRev = MktRevScr,

                            PicGrdAqu = MktCusGrd,
                            PicTgtAqu = MktCusTrg,
                            PicActAqu = MktCusAct,
                            PicAchAqu = MktCusAch,
                            PicScrAqu = MktCusScr,

                            MktGrdDrm = MktDrmGrd,
                            MktTgtDrm = MktDrmTrg,
                            MktActDrm = MktDrmAct,
                            MktAchDrm = MktDrmAch,
                            MktScrDrm = MktDrmScr,

                            MktGrdAir = MktAirGrd,
                            MktTgtAir = MktAirTrg,
                            MktActAir = MktAirAct,
                            MktAchAir = MktAirAch,
                            MktScrAir = MktAirScr,


                            PicGrdSat = MktSatGrd,
                            PicTgtSat = MktSatTrg,
                            PicActSat = MktSatAct,
                            PicAchSat = MktSatAch,
                            PicScrSat = MktSatScr

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vCORPDeptMonthly(int year, int month, char ch)
        {
            decimal MktRevGrd, MktRevTrg, MktRevAct, MktCusGrd, MktCusTrg, MktCusAct, MktSatGrd, MktSatTrg, MktSatAct;
            decimal MktRevAch, TmpMktRevAch, MktCusAch, TmpMktCusAct, MktSatAch, TmpMktSatAct;
            decimal MktRevScr, MktCusScr, MktSatScr;
            //--decimal MktDrmGrd, MktDrmTrg, MktDrmAct, MktAirGrd, MktAirTrg, MktAirAct;
            decimal MktDrmGrd, MktDrmTrg, MktDrmAct, MktDrmAch, TmpMktDrmAct, MktDrmScr, MktAirGrd, MktAirTrg, MktAirAct, MktAirAch, TmpMktAirAch, MktAirScr;
            double dMktSatAct;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", year);
                com.Parameters.AddWithValue("@MONTH", month);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M')  com.Parameters.AddWithValue("@Action", "CORPMONTHLY");
                else com.Parameters.AddWithValue("@Action", "CORPSUMMARY");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // marketing revenue
                        if (rdr["MktRevGrd"] == DBNull.Value)
                            MktRevGrd = 0;
                        else
                            MktRevGrd = Math.Round(Convert.ToDecimal(rdr["MktRevGrd"]) , 2);

                        if (rdr["MktRevTrg"] == DBNull.Value)
                            MktRevTrg = 0;
                        else
                            MktRevTrg = Convert.ToDecimal(rdr["MktRevTrg"]);

                        if (rdr["MktRevAct"] == DBNull.Value)
                            MktRevAct = 0;
                        else
                            MktRevAct = Convert.ToDecimal(rdr["MktRevAct"]);

                        if (MktRevTrg > 0)
                            MktRevAch = MktRevAct / MktRevTrg * 100;
                        else
                            MktRevAch = 0;
                        TmpMktRevAch = 0;
                        /*--
                        if (MktRevAch > 110)
                            TmpMktRevAch = 120;
                        else if (MktRevAch > 103 && MktRevAch <= 110)
                            TmpMktRevAch = 110;
                        else if (MktRevAch > 95 && MktRevAch <= 103)
                            TmpMktRevAch = 100;
                        else if (MktRevAch >= 90 && MktRevAch <= 95)
                            TmpMktRevAch = 90;
                        else if (MktRevAch < 90)
                            TmpMktRevAch = 60;
                            --*/
                        if (MktRevAch >= 103)
                            TmpMktRevAch = 110;
                        else if (MktRevAch >= 97 && MktRevAch < 103)
                            TmpMktRevAch = 100;
                        else if (MktRevAch >= 91 && MktRevAch < 97)
                            TmpMktRevAch = 90;
                        else if (MktRevAch < 91)
                            TmpMktRevAch = 60;
                        MktRevScr = MktRevGrd * TmpMktRevAch / 100;

                        // marketing new customer
                        if (rdr["MktCusGrd"] == DBNull.Value)
                            MktCusGrd = 0;
                        else
                            MktCusGrd = Math.Round(Convert.ToDecimal(rdr["MktCusGrd"]) , 2);

                        if (rdr["MktCusTrg"] == DBNull.Value)
                            MktCusTrg = 0;
                        else
                            MktCusTrg = Convert.ToDecimal(rdr["MktCusTrg"]);

                        if (rdr["MktCusAct"] == DBNull.Value)
                            MktCusAct = 0;
                        else
                            MktCusAct = Convert.ToDecimal(rdr["MktCusAct"]);

                        if (MktCusTrg > 0)
                            MktCusAch = MktCusAct / MktCusTrg * 100;
                        else
                            MktCusAch = 0;
                        TmpMktCusAct = 0;
                        /*--
                        if (MktCusAct > 4)
                            TmpMktCusAct = 120;
                        else if (MktCusAct == 4)
                            TmpMktCusAct = 110;
                        else if (MktCusAct == 3)
                            TmpMktCusAct = 100;
                        else if (MktCusAct == 2)
                            TmpMktCusAct = 90;
                        else if (MktCusAct < 2)
                            TmpMktCusAct = 60;
                          --  */
                        if (MktCusAct > 1)
                            TmpMktCusAct = 110;
                        else if (MktCusAct == 1)
                            TmpMktCusAct = 100;
                        else if (MktCusAct < 1)
                            TmpMktCusAct = 0;
                        MktCusScr = MktCusGrd * TmpMktCusAct / 100;

                        // DRM MktDrmGrd, MktDrmTrg, MktDrmAct
                        if (rdr["MktDrmGrd"] == DBNull.Value)
                            MktDrmGrd = 0;
                        else
                            MktDrmGrd = Math.Round(Convert.ToDecimal(rdr["MktDrmGrd"]), 2);

                        if (rdr["MktDrmTrg"] == DBNull.Value)
                            MktDrmTrg = 0;
                        else
                            MktDrmTrg = Convert.ToDecimal(rdr["MktDrmTrg"]);

                        if (rdr["MktDrmAct"] == DBNull.Value)
                            MktDrmAct = 0;
                        else
                            MktDrmAct = Convert.ToDecimal(rdr["MktDrmAct"]);

                        if (MktDrmTrg > 0)
                            MktDrmAch = MktDrmAct / MktDrmTrg * 100;
                        else
                            MktDrmAch = 0;
                        TmpMktDrmAct = 0;
                        if (MktDrmAct > 95)
                            TmpMktDrmAct = 110;
                        else if (MktDrmAct > 85 && MktDrmAct <= 95)
                            TmpMktDrmAct = 100;
                        else if (MktDrmAct >= 80 && MktDrmAct <= 85)
                            TmpMktDrmAct = 90;
                        else if (MktDrmAct < 80)
                            TmpMktDrmAct = 60;
                        MktDrmScr = MktDrmGrd * TmpMktDrmAct / 100;

                        // Air MktAirGrd, MktAirTrg, MktAirAct
                        if (rdr["MktAirGrd"] == DBNull.Value)
                            MktAirGrd = 0;
                        else
                            MktAirGrd = Math.Round(Convert.ToDecimal(rdr["MktAirGrd"]), 2);

                        if (rdr["MktAirTrg"] == DBNull.Value)
                            MktAirTrg = 0;
                        else
                            MktAirTrg = Convert.ToDecimal(rdr["MktAirTrg"]);

                        if (rdr["MktAirAct"] == DBNull.Value)
                            MktAirAct = 0;
                        else
                            MktAirAct = Convert.ToDecimal(rdr["MktAirAct"]);

                        if (MktAirTrg > 0)
                            MktAirAch = MktAirAct / MktAirTrg * 100;
                        else
                            MktAirAch = 0;
                        TmpMktAirAch = 0;
                        if (MktAirAch < 95)
                            TmpMktAirAch = 110;
                        else if (MktAirAch >= 95 && MktAirAch <= 99)
                            TmpMktAirAch = 100;
                        else if (MktAirAch > 99 && MktAirAch <= 102)
                            TmpMktAirAch = 90;
                        else if (MktAirAch > 102)
                            TmpMktAirAch = 60;
                        MktAirScr = MktAirGrd * TmpMktAirAch / 100;


                        // Customer Satisfaction Index
                        if (rdr["MktSatGrd"] == DBNull.Value)
                            MktSatGrd = 0;
                        else
                            MktSatGrd = Math.Round(Convert.ToDecimal(rdr["MktSatGrd"]) , 2);

                        if (rdr["MktSatTrg"] == DBNull.Value)
                            MktSatTrg = 0;
                        else
                            MktSatTrg = Convert.ToDecimal(rdr["MktSatTrg"]);

                        if (rdr["MktSatAct"] == DBNull.Value)
                            MktSatAct = 0;
                        else
                            MktSatAct = Convert.ToDecimal(rdr["MktSatAct"]);


                        if (MktSatTrg > 0)
                            MktSatAch = MktSatAct / MktSatTrg * 100;
                        else
                            MktSatAch = 0;
                        TmpMktSatAct = 0;
                        dMktSatAct = Convert.ToDouble(MktSatAct);
                        /*---
                        if (dMktSatAct > 3.7)
                            TmpMktSatAct = 120;
                        else if (dMktSatAct > 3.4 && dMktSatAct <= 3.7)
                            TmpMktSatAct = 110;
                        else if (dMktSatAct > 3.2 && dMktSatAct <= 3.4)
                            TmpMktSatAct = 100;
                        else if (dMktSatAct >= 3 && dMktSatAct <= 3.2)
                            TmpMktSatAct = 90;
                        else if (dMktSatAct < 3)
                            TmpMktSatAct = 60;
                            ---*/
                        if (dMktSatAct >= 3.8)
                            TmpMktSatAct = 120;
                        else if (dMktSatAct >= 3.5 && dMktSatAct < 3.8)
                            TmpMktSatAct = 100;
                        else if (dMktSatAct >= 3 && dMktSatAct < 3.5)
                            TmpMktSatAct = 90;
                        else if (dMktSatAct < 3)
                            TmpMktSatAct = 60;
                        MktSatScr = MktSatGrd * TmpMktSatAct / 100;


                        lst.Add(new corpdept
                        {
                            PicGrdRev = MktRevGrd,
                            PicTgtRev = MktRevTrg,
                            PicActRev = MktRevAct,
                            PicAchRev = MktRevAch,
                            PicScrRev = MktRevScr,

                            PicGrdAqu = MktCusGrd,
                            PicTgtAqu = MktCusTrg,
                            PicActAqu = MktCusAct,
                            PicAchAqu = MktCusAch,
                            PicScrAqu = MktCusScr,

                            MktGrdDrm = MktDrmGrd,
                            MktTgtDrm = MktDrmTrg,
                            MktActDrm = MktDrmAct,
                            MktAchDrm = MktDrmAch,
                            MktScrDrm = MktDrmScr,

                            MktGrdAir = MktAirGrd,
                            MktTgtAir = MktAirTrg,
                            MktActAir = MktAirAct,
                            MktAchAir = MktAirAch,
                            MktScrAir = MktAirScr,

                            PicGrdSat = MktSatGrd,
                            PicTgtSat = MktSatTrg,
                            PicActSat = MktSatAct,
                            PicAchSat = MktSatAch,
                            PicScrSat = MktSatScr

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vPPICDept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct;
            decimal PicTvbGrd, PicTvbTrg, PicTvbAct, PicDppGrd, PicDppTrg, PicDppAct, PicEmeGrd, PicEmeTrg, PicEmeAct, PicScaGrd, PicScaTrg, PicScaAct, PicMusGrd, PicMusTrg, PicMusAct, PicOthGrd, PicOthTrg, PicOthAct;
            decimal PicAirGrd, PicAirTrg, PicAirAct, PicInvGrd, PicInvTrg, PicInvAct;
            string parCom = "";

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                // SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                if (id < 2020)
                    parCom = "Extranet_sp_mKPI_Dept";
                else
                    parCom = "Extranet_sp_mKPI_Dept_20";

                SqlCommand com = new SqlCommand(parCom, con);               
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "PPIC");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // PPIC revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);
                        // ppic pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);
                        // ppic pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);
                        // ppic tvb  
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) / 12, 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);
                        // ppic dp pump 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (id<2020)
                        {
                            // ppic emerson 
                            if (rdr["PicEmeGrd"] == DBNull.Value)
                                PicEmeGrd = 0;
                            else
                                PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                            if (rdr["PicEmeTrg"] == DBNull.Value)
                                PicEmeTrg = 0;
                            else
                                PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                            if (rdr["PicEmeAct"] == DBNull.Value)
                                PicEmeAct = 0;
                            else
                                PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                            // ppic scanjet 
                            if (rdr["PicScaGrd"] == DBNull.Value)
                                PicScaGrd = 0;
                            else
                                PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) / 12, 2);

                            if (rdr["PicScaTrg"] == DBNull.Value)
                                PicScaTrg = 0;
                            else
                                PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                            if (rdr["PicScaAct"] == DBNull.Value)
                                PicScaAct = 0;
                            else
                                PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                            // ppic Musashi 
                            if (rdr["PicMusGrd"] == DBNull.Value)
                                PicMusGrd = 0;
                            else
                                PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]) / 12, 2);

                            if (rdr["PicMusTrg"] == DBNull.Value)
                                PicMusTrg = 0;
                            else
                                PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                            if (rdr["PicMusAct"] == DBNull.Value)
                                PicMusAct = 0;
                            else
                                PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);
                        } else
                        {
                            PicEmeGrd = 0; PicEmeTrg = 0; PicEmeAct = 0; PicScaGrd = 0; PicScaTrg = 0; PicScaAct = 0;
                            PicMusGrd = 0; PicMusTrg = 0; PicMusAct = 0;
                        }

                        // ppic other  
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) / 12, 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);

                        if (rdr["PicOthAct"] == DBNull.Value)
                            PicOthAct = 0;
                        else
                            PicOthAct = Convert.ToDecimal(rdr["PicOthAct"]);
                        // ppic air 
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) / 12, 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);
                        // ppic inventory 
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            PicInvGrd = 0;
                        else
                            PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]) / 12, 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            PicInvTrg = 0;
                        else
                            PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            PicInvAct = 0;
                        else
                            PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,
                            PicActOth = PicOthAct,
                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vPPICDeptSummary(int year, int month, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct;
            decimal PicTvbGrd, PicTvbTrg, PicTvbAct, PicDppGrd, PicDppTrg, PicDppAct, PicEmeGrd, PicEmeTrg, PicEmeAct, PicScaGrd, PicScaTrg, PicScaAct, PicMusGrd, PicMusTrg, PicMusAct, PicOthGrd, PicOthTrg, PicOthAct;
            decimal PicAirGrd, PicAirTrg, PicAirAct, PicInvGrd, PicInvTrg, PicInvAct;
            string parCom;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (year < 2020)
                    parCom = "Extranet_sp_mKPI_Dept";
                else
                    parCom = "Extranet_sp_mKPI_Dept_20";

                SqlCommand com = new SqlCommand(parCom, con);
                com.Parameters.AddWithValue("@YEAR", year);
                com.Parameters.AddWithValue("@MONTH", month);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M') com.Parameters.AddWithValue("@Action", "PPICMONTH");
                else com.Parameters.AddWithValue("@Action", "PPICYEAR");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // PPIC revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]), 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);
                        // ppic pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);
                        // ppic pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);
                        // ppic tvb  
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]), 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);
                        // ppic dp pump 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]), 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);
                        
                        if(year<2020)
                        {
                            // ppic emerson 
                            if (rdr["PicEmeGrd"] == DBNull.Value)
                                PicEmeGrd = 0;
                            else
                                PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]), 2);

                            if (rdr["PicEmeTrg"] == DBNull.Value)
                                PicEmeTrg = 0;
                            else
                                PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                            if (rdr["PicEmeAct"] == DBNull.Value)
                                PicEmeAct = 0;
                            else
                                PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                            // ppic scanjet 
                            if (rdr["PicScaGrd"] == DBNull.Value)
                                PicScaGrd = 0;
                            else
                                PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]), 2);

                            if (rdr["PicScaTrg"] == DBNull.Value)
                                PicScaTrg = 0;
                            else
                                PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                            if (rdr["PicScaAct"] == DBNull.Value)
                                PicScaAct = 0;
                            else
                                PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                            // ppic Musashi 
                            if (rdr["PicMusGrd"] == DBNull.Value)
                                PicMusGrd = 0;
                            else
                                PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]), 2);

                            if (rdr["PicMusTrg"] == DBNull.Value)
                                PicMusTrg = 0;
                            else
                                PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                            if (rdr["PicMusAct"] == DBNull.Value)
                                PicMusAct = 0;
                            else
                                PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);

                        }
                        else
                        {
                            PicEmeGrd = 0; PicEmeTrg = 0; PicEmeAct = 0; PicScaGrd = 0; PicScaTrg = 0; PicScaAct = 0;
                            PicMusGrd = 0; PicMusTrg = 0; PicMusAct = 0;
                        }


                        // ppic other  
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) , 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);

                        if (rdr["PicOthAct"] == DBNull.Value)
                            PicOthAct = 0;
                        else
                            PicOthAct = Convert.ToDecimal(rdr["PicOthAct"]);
                        // ppic air 
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]), 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);
                        // ppic inventory 
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            PicInvGrd = 0;
                        else
                            PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]), 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            PicInvTrg = 0;
                        else
                            PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            PicInvAct = 0;
                        else
                            PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,
                            PicActOth = PicOthAct,
                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct


                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vMachineDept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdcGrd, PicPdcTrg, PicPdcAct, MacDrmGrd, MacDrmTrg, MacDrmAct;
            decimal MacCutGrd, MacCutTrg, MacCutAct, MacRejGrd, MacRejTrg, MacRejAct, MacConGrd, MacConTrg, MacConAct, MacFohGrd, MacFohTrg, MacFohAct;
            decimal MacLabGrd, MacLabTrg, MacLabAct, MacRedGrd, MacRedTrg, MacRedAct, MacInvGrd, MacInvTrg, MacInvAct, MacSafGrd, MacSafTrg;
            decimal MacNonGrd, MacNonTrg, MacNonAct;
            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Machine");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);
                        // drm  
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            MacDrmGrd = 0;
                        else
                            MacDrmGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) / 12, 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            MacDrmTrg = 0;
                        else
                            MacDrmTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            MacDrmAct = 0;
                        else
                            MacDrmAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        // reject rate  
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            MacRejGrd = 0;
                        else
                            MacRejGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            MacRejTrg = 0;
                        else
                            MacRejTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            MacRejAct = 0;
                        else
                            MacRejAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        //cutting tool
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            MacCutGrd = 0;
                        else
                            MacCutGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            MacCutTrg = 0;
                        else
                            MacCutTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            MacCutAct = 0;
                        else
                            MacCutAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        // consumables 
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            MacConGrd = 0;
                        else
                            MacConGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) / 12, 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            MacConTrg = 0;
                        else
                            MacConTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            MacConAct = 0;
                        else
                            MacConAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        // foh electricity 
                        if (rdr["PicMusGrd"] == DBNull.Value)
                            MacFohGrd = 0;
                        else
                            MacFohGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]) / 12, 2);

                        if (rdr["PicMusTrg"] == DBNull.Value)
                            MacFohTrg = 0;
                        else
                            MacFohTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                        if (rdr["PicMusAct"] == DBNull.Value)
                            MacFohAct = 0;
                        else
                            MacFohAct = Convert.ToDecimal(rdr["PicMusAct"]);

                        // Foh Non  
                        if (rdr["PicNonGrd"] == DBNull.Value)
                            MacNonGrd = 0;
                        else
                            MacNonGrd = Math.Round(Convert.ToDecimal(rdr["PicNonGrd"]) / 12, 2);

                        if (rdr["PicNonTrg"] == DBNull.Value)
                            MacNonTrg = 0;
                        else
                            MacNonTrg = Convert.ToDecimal(rdr["PicNonTrg"]);

                        if (rdr["PicNonAct"] == DBNull.Value)
                            MacNonAct = 0;
                        else
                            MacNonAct = Convert.ToDecimal(rdr["PicNonAct"]);

                        // labor   
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            MacLabGrd = 0;
                        else
                            MacLabGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) / 12, 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            MacLabTrg = 0;
                        else
                            MacLabTrg = Convert.ToDecimal(rdr["PicOthTrg"]);

                        if (rdr["PicOthAct"] == DBNull.Value)
                            MacLabAct = 0;
                        else
                            MacLabAct = Convert.ToDecimal(rdr["PicOthAct"]);

                        // reduction
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            MacRedGrd = 0;
                        else
                            MacRedGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) / 12, 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            MacRedTrg = 0;
                        else
                            MacRedTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            MacRedAct = 0;
                        else
                            MacRedAct = Convert.ToDecimal(rdr["PicAirAct"]);
                        // WIP
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            MacInvGrd = 0;
                        else
                            MacInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]) / 12, 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            MacInvTrg = 0;
                        else
                            MacInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            MacInvAct = 0;
                        else
                            MacInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        // Safe
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            MacSafGrd = 0;
                        else
                            MacSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]) / 12, 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            MacSafTrg = 0;
                        else
                            MacSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicGrdTvb = MacDrmGrd,
                            PicTgtTvb = MacDrmTrg,
                            PicActTvb = MacDrmAct,
                            PicGrdDpp = MacRejGrd,
                            PicTgtDpp = MacRejTrg,
                            PicActDpp = MacRejAct,
                            PicGrdEme = MacCutGrd,
                            PicTgtEme = MacCutTrg,
                            PicActEme = MacCutAct,
                            PicGrdSca = MacConGrd,
                            PicTgtSca = MacConTrg,
                            PicActSca = MacConAct,
                            PicGrdMus = MacFohGrd,
                            PicTgtMus = MacFohTrg,
                            PicActMus = MacFohAct,
                            PicGrdOth = MacLabGrd,
                            PicTgtOth = MacLabTrg,
                            PicActOth = MacLabAct,
                            PicGrdAir = MacRedGrd,
                            PicTgtAir = MacRedTrg,
                            PicActAir = MacRedAct,
                            PicGrdInv = MacInvGrd,
                            PicTgtInv = MacInvTrg,
                            PicActInv = MacInvAct,

                            PicGrdNon = MacNonGrd,
                            PicTgtNon = MacNonTrg,
                            PicActNon = MacNonAct,


                            PicGrdSaf = MacSafGrd,
                            PicTgtSaf = MacSafTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vMachineDeptSummary(int id, int bln, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdcGrd, PicPdcTrg, PicPdcAct, MacDrmGrd, MacDrmTrg, MacDrmAct;
            decimal MacCutGrd, MacCutTrg, MacCutAct, MacRejGrd, MacRejTrg, MacRejAct, MacConGrd, MacConTrg, MacConAct, MacFohGrd, MacFohTrg, MacFohAct;
            decimal MacLabGrd, MacLabTrg, MacLabAct, MacRedGrd, MacRedTrg, MacRedAct, MacInvGrd, MacInvTrg, MacInvAct, MacSafGrd, MacSafTrg;
            decimal MacNonGrd, MacNonTrg, MacNonAct;
            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M') com.Parameters.AddWithValue("@Action", "MachineMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "MachineYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) , 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);
                        // drm  
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            MacDrmGrd = 0;
                        else
                            MacDrmGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) , 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            MacDrmTrg = 0;
                        else
                            MacDrmTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            MacDrmAct = 0;
                        else
                            MacDrmAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        // reject rate  
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            MacRejGrd = 0;
                        else
                            MacRejGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) , 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            MacRejTrg = 0;
                        else
                            MacRejTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            MacRejAct = 0;
                        else
                            MacRejAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        //cutting tool
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            MacCutGrd = 0;
                        else
                            MacCutGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) , 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            MacCutTrg = 0;
                        else
                            MacCutTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            MacCutAct = 0;
                        else
                            MacCutAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        // consumables 
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            MacConGrd = 0;
                        else
                            MacConGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) , 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            MacConTrg = 0;
                        else
                            MacConTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            MacConAct = 0;
                        else
                            MacConAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        // foh electricity 
                        if (rdr["PicMusGrd"] == DBNull.Value)
                            MacFohGrd = 0;
                        else
                            MacFohGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]) , 2);

                        if (rdr["PicMusTrg"] == DBNull.Value)
                            MacFohTrg = 0;
                        else
                            MacFohTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                        if (rdr["PicMusAct"] == DBNull.Value)
                            MacFohAct = 0;
                        else
                            MacFohAct = Convert.ToDecimal(rdr["PicMusAct"]);

                        // Foh Non  
                        if (rdr["PicNonGrd"] == DBNull.Value)
                            MacNonGrd = 0;
                        else
                            MacNonGrd = Math.Round(Convert.ToDecimal(rdr["PicNonGrd"]), 2);

                        if (rdr["PicNonTrg"] == DBNull.Value)
                            MacNonTrg = 0;
                        else
                            MacNonTrg = Convert.ToDecimal(rdr["PicNonTrg"]);

                        if (rdr["PicNonAct"] == DBNull.Value)
                            MacNonAct = 0;
                        else
                            MacNonAct = Convert.ToDecimal(rdr["PicNonAct"]);

                        // labor   
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            MacLabGrd = 0;
                        else
                            MacLabGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) , 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            MacLabTrg = 0;
                        else
                            MacLabTrg = Convert.ToDecimal(rdr["PicOthTrg"]);

                        if (rdr["PicOthAct"] == DBNull.Value)
                            MacLabAct = 0;
                        else
                            MacLabAct = Convert.ToDecimal(rdr["PicOthAct"]);

                        // reduction
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            MacRedGrd = 0;
                        else
                            MacRedGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) , 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            MacRedTrg = 0;
                        else
                            MacRedTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            MacRedAct = 0;
                        else
                            MacRedAct = Convert.ToDecimal(rdr["PicAirAct"]);
                        // WIP
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            MacInvGrd = 0;
                        else
                            MacInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]) , 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            MacInvTrg = 0;
                        else
                            MacInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            MacInvAct = 0;
                        else
                            MacInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        // Safe
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            MacSafGrd = 0;
                        else
                            MacSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]) , 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            MacSafTrg = 0;
                        else
                            MacSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicGrdTvb = MacDrmGrd,
                            PicTgtTvb = MacDrmTrg,
                            PicActTvb = MacDrmAct,
                            PicGrdDpp = MacRejGrd,
                            PicTgtDpp = MacRejTrg,
                            PicActDpp = MacRejAct,
                            PicGrdEme = MacCutGrd,
                            PicTgtEme = MacCutTrg,
                            PicActEme = MacCutAct,
                            PicGrdSca = MacConGrd,
                            PicTgtSca = MacConTrg,
                            PicActSca = MacConAct,
                            PicGrdMus = MacFohGrd,
                            PicTgtMus = MacFohTrg,
                            PicActMus = MacFohAct,
                            PicGrdOth = MacLabGrd,
                            PicTgtOth = MacLabTrg,
                            PicActOth = MacLabAct,
                            PicGrdAir = MacRedGrd,
                            PicTgtAir = MacRedTrg,
                            PicActAir = MacRedAct,
                            PicGrdInv = MacInvGrd,
                            PicTgtInv = MacInvTrg,
                            PicActInv = MacInvAct,

                            PicGrdNon = MacNonGrd,
                            PicTgtNon = MacNonTrg,
                            PicActNon = MacNonAct,

                            PicGrdSaf = MacSafGrd,
                            PicTgtSaf = MacSafTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vFinishingDept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct;
            decimal FisDrmGrd, FisDrmTrg, FisDrmAct, FisRejGrd, FisRejTrg, FisRejAct, FisWipGrd, FisWipTrg, FisWipAct;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchDrm, PicAchDrmTmp, PicScrDrm, PicAchRej, PicActRejTmp, PicScrRej, PicAchWip, PicAchWipTmp, PicScrWip;
            double dFisRejAct;
            string parCom;
            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                if (id < 2020)
                    parCom = "Extranet_sp_mKPI_Dept";
                else
                    parCom = "Extranet_sp_mKPI_Dept_20";

                SqlCommand com = new SqlCommand(parCom, con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Finishing");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        if (PicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (PicAchRev > 103 && PicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (PicAchRev > 95 && PicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 90 && PicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 90)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        if (PicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (PicAchPda > 102 && PicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda > 98 && PicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 94 && PicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 94)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        if (id < 2020)
                        {
                            //---- pdc
                            if (rdr["PicPdcGrd"] == DBNull.Value)
                                PicPdcGrd = 0;
                            else
                                PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                            if (rdr["PicPdcTrg"] == DBNull.Value)
                                PicPdcTrg = 0;
                            else
                                PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                            if (rdr["PicPdcAct"] == DBNull.Value)
                                PicPdcAct = 0;
                            else
                                PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                            if (PicPdcTrg > 0)
                                PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                            else
                                PicAchPdc = 0;
                            PicAchPdcTmp = 0;
                            if (PicAchPdc > 110)
                                PicAchPdcTmp = 120;
                            else if (PicAchPdc > 102 && PicAchPdc <= 110)
                                PicAchPdcTmp = 110;
                            else if (PicAchPdc > 98 && PicAchPdc <= 102)
                                PicAchPdcTmp = 100;
                            else if (PicAchPdc >= 94 && PicAchPdc <= 98)
                                PicAchPdcTmp = 90;
                            else if (PicAchPdc < 94)
                                PicAchPdcTmp = 60;
                            PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;
                        }
                        else
                        {
                            //---cost finishing
                            if (rdr["PicFNCgrade"] == DBNull.Value)
                                PicPdcGrd = 0;
                            else
                                PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicFNCgrade"]) / 12, 2);

                            if (rdr["PicFNCTrg"] == DBNull.Value)
                                PicPdcTrg = 0;
                            else
                                PicPdcTrg = Convert.ToDecimal(rdr["PicFNCTrg"]);

                            if (rdr["PicFNCAct"] == DBNull.Value)
                                PicPdcAct = 0;
                            else
                                PicPdcAct = Convert.ToDecimal(rdr["PicFNCAct"]);

                            if (PicPdcTrg > 0)
                                PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                            else
                                PicAchPdc = 0;
                            PicAchPdcTmp = 0;
                            if (PicAchPdc > 110)
                                PicAchPdcTmp = 60;
                            else if (PicAchPdc > 102 && PicAchPdc <= 110)
                                PicAchPdcTmp = 90;
                            else if (PicAchPdc > 94 && PicAchPdc <= 102)
                                PicAchPdcTmp = 100;
                            else if (PicAchPdc >= 90 && PicAchPdc <= 94)
                                PicAchPdcTmp = 110;
                            else if (PicAchPdc < 90)
                                PicAchPdcTmp = 120;
                            PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;
                        }


                        // drm
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            FisDrmGrd = 0;
                        else
                            FisDrmGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) / 12, 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            FisDrmTrg = 0;
                        else
                            FisDrmTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            FisDrmAct = 0;
                        else
                            FisDrmAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (FisDrmTrg > 0)
                            PicAchDrm = FisDrmAct / FisDrmTrg * 100;
                        else
                            PicAchDrm = 0;
                        PicAchDrmTmp = 0;
                        if (PicAchDrm > 100)
                            PicAchDrmTmp = 110;
                        else if (PicAchDrm > 95 && PicAchDrm <= 100)
                            PicAchDrmTmp = 100;
                        else if (PicAchDrm >= 85 && PicAchDrm <= 95)
                            PicAchDrmTmp = 90;
                        else if (PicAchDrm < 85)
                            PicAchDrmTmp = 60;
                        PicScrDrm = FisDrmGrd * PicAchDrmTmp / 100;


                        // reject rate casting
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            FisRejGrd = 0;
                        else
                            FisRejGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            FisRejTrg = 0;
                        else
                            FisRejTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            FisRejAct = 0;
                        else
                            FisRejAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (FisRejTrg > 0)
                            PicAchRej = (1 + ((FisRejTrg - FisRejAct) / FisRejTrg)) * 100;
                        else
                            PicAchRej = 0;
                        PicActRejTmp = 0;
                        dFisRejAct = Convert.ToDouble(FisRejAct);
                        if (dFisRejAct < 3)
                            PicActRejTmp = 120;
                        else if (dFisRejAct >= 3 && dFisRejAct <= 3.8)
                            PicActRejTmp = 110;
                        else if (dFisRejAct > 3.8 && dFisRejAct <= 4)
                            PicActRejTmp = 100;
                        else if (dFisRejAct > 4 && dFisRejAct <= 4.8)
                            PicActRejTmp = 90;
                        else if (dFisRejAct > 4.8)
                            PicActRejTmp = 60;
                        PicScrRej = FisRejGrd * PicActRejTmp / 100;


                        //wip
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            FisWipGrd = 0;
                        else
                            FisWipGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            FisWipTrg = 0;
                        else
                            FisWipTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            FisWipAct = 0;
                        else
                            FisWipAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (FisWipTrg > 0)
                        {
                            if (FisWipAct < (FisWipTrg * 2))
                                PicAchWip = (1 + ((FisWipTrg - FisWipAct) / FisWipTrg)) * 100;
                            else PicAchWip = 0;
                        }
                        else
                            PicAchWip = 0;
                        if (id<2020)
                        {
                            if (FisWipAct == 0)
                                PicScrWip = FisWipTrg;
                            else
                                PicScrWip = FisWipGrd - (FisWipGrd - ((FisWipTrg / FisWipAct) * FisWipGrd));

                        } else
                        {
                            PicAchWipTmp = 0;
                            if (PicAchWip < 50)
                                PicAchWipTmp = 60;
                            else if (PicAchWip >= 50 && PicAchWip <= 90)
                                PicAchWipTmp = 90;
                            else if (PicAchWip > 90 && PicAchWip <= 100)
                                PicAchWipTmp = 100;
                            else if (PicAchWip > 100 && PicAchWip <= 125)
                                PicAchWipTmp = 110;
                            else if (PicAchWip > 125)
                                PicAchWipTmp = 120;
                            PicScrWip = FisWipGrd * PicAchWipTmp / 100;

                        }


                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdDrm = FisDrmGrd,
                            PicTgtDrm = FisDrmTrg,
                            PicActDrm = FisDrmAct,
                            PicAchDrm = PicAchDrm,
                            PicScrDrm = PicScrDrm,

                            PicGrdRed = FisRejGrd,
                            PicTgtRed = FisRejTrg,
                            PicActRed = FisRejAct,
                            PicAchRed = PicAchRej,
                            PicScrRed = PicScrRej,

                            PicGrdWip = FisWipGrd,
                            PicTgtWip = FisWipTrg,
                            PicActWip = FisWipAct,
                            PicAchWip = PicAchWip,
                            PicScrWip = PicScrWip,

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vFinishingDeptSummary(int id, int bln, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct;
            decimal FisDrmGrd, FisDrmTrg, FisDrmAct, FisRejGrd, FisRejTrg, FisRejAct, FisWipGrd, FisWipTrg, FisWipAct;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchDrm, PicAchDrmTmp, PicScrDrm, PicAchRej, PicActRejTmp, PicScrRej, PicAchWip, PicAchWipTmp, PicScrWip;
            double dFisRejAct;
            string parCom;
            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (id < 2020)
                    parCom = "Extranet_sp_mKPI_Dept";
                else
                    parCom = "Extranet_sp_mKPI_Dept_20";

                SqlCommand com = new SqlCommand(parCom, con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M') com.Parameters.AddWithValue("@Action", "FinishingMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "FinishingYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]), 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        if (PicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (PicAchRev > 103 && PicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (PicAchRev > 95 && PicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 90 && PicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 90)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        if (PicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (PicAchPda > 102 && PicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda > 98 && PicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 94 && PicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 94)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        if (id < 2020)
                        {
                            // ---utk 2019 pdc, 2020 cost fininshing
                            if (rdr["PicPdcGrd"] == DBNull.Value)
                                PicPdcGrd = 0;
                            else
                                PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                            if (rdr["PicPdcTrg"] == DBNull.Value)
                                PicPdcTrg = 0;
                            else
                                PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                            if (rdr["PicPdcAct"] == DBNull.Value)
                                PicPdcAct = 0;
                            else
                                PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                            if (PicPdcTrg > 0)
                                PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                            else
                                PicAchPdc = 0;
                            PicAchPdcTmp = 0;
                            if (PicAchPdc > 110)
                                PicAchPdcTmp = 120;
                            else if (PicAchPdc > 102 && PicAchPdc <= 110)
                                PicAchPdcTmp = 110;
                            else if (PicAchPdc > 98 && PicAchPdc <= 102)
                                PicAchPdcTmp = 100;
                            else if (PicAchPdc >= 94 && PicAchPdc <= 98)
                                PicAchPdcTmp = 90;
                            else if (PicAchPdc < 94)
                                PicAchPdcTmp = 60;
                            PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;

                        } else
                        {
                            //---cost finishing
                            if (rdr["PicFNCgrade"] == DBNull.Value)
                                PicPdcGrd = 0;
                            else
                                PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicFNCgrade"]), 2);

                            if (rdr["PicFNCTrg"] == DBNull.Value)
                                PicPdcTrg = 0;
                            else
                                PicPdcTrg = Convert.ToDecimal(rdr["PicFNCTrg"]);

                            if (rdr["PicFNCAct"] == DBNull.Value)
                                PicPdcAct = 0;
                            else
                                PicPdcAct = Convert.ToDecimal(rdr["PicFNCAct"]);

                            if (PicPdcTrg > 0)
                                PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                            else
                                PicAchPdc = 0;

                            PicAchPdcTmp = 0;
                            if (PicAchPdc > 110)
                                PicAchPdcTmp = 60;
                            else if (PicAchPdc > 102 && PicAchPdc <= 110)
                                PicAchPdcTmp = 90;
                            else if (PicAchPdc > 94 && PicAchPdc <= 102)
                                PicAchPdcTmp = 100;
                            else if (PicAchPdc >= 90 && PicAchPdc <= 94)
                                PicAchPdcTmp = 110;
                            else if (PicAchPdc < 90)
                                PicAchPdcTmp = 120;

                            PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;
                        }


                        // drm
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            FisDrmGrd = 0;
                        else
                            FisDrmGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]), 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            FisDrmTrg = 0;
                        else
                            FisDrmTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            FisDrmAct = 0;
                        else
                            FisDrmAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (FisDrmTrg > 0)
                            PicAchDrm = FisDrmAct / FisDrmTrg * 100;
                        else
                            PicAchDrm = 0;
                        PicAchDrmTmp = 0;
                        if (PicAchDrm > 100)
                            PicAchDrmTmp = 110;
                        else if (PicAchDrm > 95 && PicAchDrm <= 100)
                            PicAchDrmTmp = 100;
                        else if (PicAchDrm >= 85 && PicAchDrm <= 95)
                            PicAchDrmTmp = 90;
                        else if (PicAchDrm < 85)
                            PicAchDrmTmp = 60;
                        PicScrDrm = FisDrmGrd * PicAchDrmTmp / 100;


                        // reject rate casting
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            FisRejGrd = 0;
                        else
                            FisRejGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]), 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            FisRejTrg = 0;
                        else
                            FisRejTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            FisRejAct = 0;
                        else
                            FisRejAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (FisRejTrg > 0)
                            PicAchRej = (1 + ((FisRejTrg - FisRejAct) / FisRejTrg)) * 100;
                        else
                            PicAchRej = 0;
                        PicActRejTmp = 0;
                        dFisRejAct = Convert.ToDouble(FisRejAct);
                        if (dFisRejAct < 3)
                            PicActRejTmp = 120;
                        else if (dFisRejAct >= 3 && dFisRejAct <= 3.8)
                            PicActRejTmp = 110;
                        else if (dFisRejAct > 3.8 && dFisRejAct <= 4)
                            PicActRejTmp = 100;
                        else if (dFisRejAct > 4 && dFisRejAct <= 4.8)
                            PicActRejTmp = 90;
                        else if (dFisRejAct > 4.8)
                            PicActRejTmp = 60;
                        PicScrRej = FisRejGrd * PicActRejTmp / 100;


                        //wip
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            FisWipGrd = 0;
                        else
                            FisWipGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]), 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            FisWipTrg = 0;
                        else
                            FisWipTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            FisWipAct = 0;
                        else
                            FisWipAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (FisWipTrg > 0)
                        {
                            if (FisWipAct < (FisWipTrg * 2))
                                PicAchWip = (1 + ((FisWipTrg - FisWipAct) / FisWipTrg)) * 100;
                            else PicAchWip = 0;
                        }
                        else
                            PicAchWip = 0;

                        if (id<2020)
                        {
                            if (FisWipAct == 0)
                                PicScrWip = FisWipTrg;
                            else
                                PicScrWip = FisWipGrd - (FisWipGrd - ((FisWipTrg / FisWipAct) * FisWipGrd));

                        }
                        else
                        {
                            PicAchWipTmp = 0;
                            if (PicAchWip < 50)
                                PicAchWipTmp = 60;
                            else if (PicAchWip >= 50 && PicAchWip <= 90)
                                PicAchWipTmp = 90;
                            else if (PicAchWip > 90 && PicAchWip <= 100)
                                PicAchWipTmp = 100;
                            else if (PicAchWip > 100 && PicAchWip <= 125)
                                PicAchWipTmp = 110;
                            else if (PicAchWip > 125)
                                PicAchWipTmp = 120;
                            PicScrWip = FisWipGrd * PicAchWipTmp / 100;
                        }
                         

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdDrm = FisDrmGrd,
                            PicTgtDrm = FisDrmTrg,
                            PicActDrm = FisDrmAct,
                            PicAchDrm = PicAchDrm,
                            PicScrDrm = PicScrDrm,

                            PicGrdRed = FisRejGrd,
                            PicTgtRed = FisRejTrg,
                            PicActRed = FisRejAct,
                            PicAchRed = PicAchRej,
                            PicScrRed = PicScrRej,

                            PicGrdWip = FisWipGrd,
                            PicTgtWip = FisWipTrg,
                            PicActWip = FisWipAct,
                            PicAchWip = PicAchWip,
                            PicScrWip = PicScrWip,

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }

        }

        public List<corpdept> vHrdGADept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicLabAct;
            decimal PicSafGrd, PicSafTrg, PicTraGrd, PicTraTrg, PicCapGrd, PicCapTrg, PicLabGrd, PicLabTrg, PicOveGrd, PicOveTrg;
           List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "HRD");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        // safety PicSafGrd, PicSafTrg, PicTraGrd, PicTraTrg, PicCapGrd, PicCapTrg, PicLabGrd, PicLabTrg, PicOveGrd, PicOveTrg
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]) / 12, 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        // training
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicTraGrd = 0;
                        else
                            PicTraGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicTraTrg = 0;
                        else
                            PicTraTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        // capability 
                        if (id<2020)
                        {
                            if (rdr["PicEmeGrd"] == DBNull.Value)
                                PicCapGrd = 0;
                            else
                                PicCapGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                            if (rdr["PicEmeTrg"] == DBNull.Value)
                                PicCapTrg = 0;
                            else
                                PicCapTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);
                        }
                        else
                        {
                            PicCapGrd = 0; PicCapTrg = 0;
                        }
                       
                        // labor
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicLabGrd = 0;
                        else
                            PicLabGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) / 12, 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicLabTrg = 0;
                        else
                            PicLabTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicLabAct = 0;
                        else
                            PicLabAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        // overtime 
                        if (rdr["PicMusGrd"] == DBNull.Value)
                            PicOveGrd = 0;
                        else
                            PicOveGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]) / 12, 2);

                        if (rdr["PicMusTrg"] == DBNull.Value)
                            PicOveTrg = 0;
                        else
                            PicOveTrg = Convert.ToDecimal(rdr["PicMusTrg"]);
                        //PicSafGrd, PicSafTrg, PicTraGrd, PicTraTrg, PicCapGrd, PicCapTrg, PicLabGrd, PicLabTrg, PicOveGrd, PicOveTrg
                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg,
                            PicGrdDpp = PicTraGrd,
                            PicTgtDpp = PicTraTrg,
                            PicGrdEme = PicCapGrd,
                            PicTgtEme = PicCapTrg,
                            PicGrdSca = PicLabGrd,
                            PicTgtSca = PicLabTrg,
                            PicActSca = PicLabAct,
                            PicGrdMus = PicOveGrd,
                            PicTgtMus = PicOveTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vHrdGADeptSummary(int id, int bln, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicLabAct;
            decimal PicSafGrd, PicSafTrg, PicTraGrd, PicTraTrg, PicCapGrd, PicCapTrg, PicLabGrd, PicLabTrg, PicOveGrd, PicOveTrg;
            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M') com.Parameters.AddWithValue("@Action", "HRDMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "HRDYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) , 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        // safety 
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]), 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        // training
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicTraGrd = 0;
                        else
                            PicTraGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]), 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicTraTrg = 0;
                        else
                            PicTraTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        // capability 
                        if (id < 2020)
                        {
                            if (rdr["PicEmeGrd"] == DBNull.Value)
                                PicCapGrd = 0;
                            else
                                PicCapGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]), 2);

                            if (rdr["PicEmeTrg"] == DBNull.Value)
                                PicCapTrg = 0;
                            else
                                PicCapTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);
                        }
                        else
                        {
                            PicCapGrd = 0; PicCapTrg = 0;
                        }


                        // labor
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicLabGrd = 0;
                        else
                            PicLabGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]), 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicLabTrg = 0;
                        else
                            PicLabTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicLabAct = 0;
                        else
                            PicLabAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        // overtime 
                        if (rdr["PicMusGrd"] == DBNull.Value)
                            PicOveGrd = 0;
                        else
                            PicOveGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]), 2);

                        if (rdr["PicMusTrg"] == DBNull.Value)
                            PicOveTrg = 0;
                        else
                            PicOveTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg,
                            PicGrdDpp = PicTraGrd,
                            PicTgtDpp = PicTraTrg,
                            PicGrdEme = PicCapGrd,
                            PicTgtEme = PicCapTrg,
                            PicGrdSca = PicLabGrd,
                            PicTgtSca = PicLabTrg,
                            PicActSca = PicLabAct,
                            PicGrdMus = PicOveGrd,
                            PicTgtMus = PicOveTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vPurchasingDept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct;
            decimal PicInvGrd, PicInvTrg, PicInvAct, PicAirGrd, PicAirTrg, PicAirAct, PicDppAct, PicDppGrd, PicDppTrg;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicScaAct,  PicScaGrd, PicScaTrg;
            decimal PicAchRev, PicScrRev, PicAchRevTmp, PicAchPda, PicScrPda, PicAchPdaTmp, PicAchPdc, PicScrPdc, PicAchPdcTmp;
            decimal PicAchInv, PicScrInv, PicActInvTmp, PicAchAir, PicScrAir, PicActAirTmp, PicAchDpp, PicScrDpp, PicActDppTmp;
            decimal PicAchEme, PicScrEme, PicActEmeTmp, PicAchSca, PicScrSca, PicAchScaTmp;
            double dPicInvAct, dPicAchRev, dPicAchPda, dPicAchPdc, dPicAirAct, dPicDppAct, dPicEmeAct, dPicScaAct;
            string date1 = Convert.ToString(id) + "-01" + "-01";
            string date2 = Convert.ToString(id) + "-12" + "-01";
            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.Parameters.AddWithValue("@DATE1", date1);
                com.Parameters.AddWithValue("@DATE2", date2);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Purchase");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0 && PicRevAct > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        dPicAchRev = Convert.ToDouble(PicAchRev);
                        if (dPicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (dPicAchRev > 103 && dPicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (dPicAchRev > 95 && dPicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (dPicAchRev >= 90 && dPicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (dPicAchRev < 90)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);


                        if (PicPdaTrg > 0 && PicPdaAct > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        dPicAchPda = Convert.ToDouble(PicAchPda);
                        if (dPicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (dPicAchPda > 102 && dPicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (dPicAchPda > 98 && dPicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (dPicAchPda >= 94 && dPicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (dPicAchPda < 94)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0 && PicPdcAct > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        dPicAchPdc = Convert.ToDouble(PicAchPdc);
                        if (dPicAchPdc > 110)
                            PicAchPdcTmp = 120;
                        else if (dPicAchPdc > 102 && dPicAchPdc <= 110)
                            PicAchPdcTmp = 110;
                        else if (dPicAchPdc > 98 && dPicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (dPicAchPdc >= 94 && dPicAchPdc <= 98)
                            PicAchPdcTmp = 90;
                        else if (dPicAchPdc < 94)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;


                        // purch
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            PicInvGrd = 0;
                        else
                            PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]) / 12, 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            PicInvTrg = 0;
                        else
                            PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            PicInvAct = 0;
                        else
                            PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        if (PicInvTrg > 0 && PicInvAct > 0)
                            PicAchInv = (1 + ((PicInvTrg - PicInvAct) / PicInvTrg)) * 100;
                        else
                            PicAchInv = 0;
                        PicActInvTmp = 0;
                        dPicInvAct = Convert.ToDouble(PicInvAct);
                        if (dPicInvAct < 33)
                            PicActInvTmp = 110;
                        else if (dPicInvAct >= 33 && dPicInvAct <= 38)
                            PicActInvTmp = 100;
                        else if (dPicInvAct > 38)
                            PicActInvTmp = 90;
                        PicScrInv = PicInvGrd * PicActInvTmp / 100;

                        // drm
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) / 12, 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0 && PicAirAct > 0)
                            PicAchAir = PicAirAct / PicAirTrg * 100;
                        else
                            PicAchAir = 0;
                        PicActAirTmp = 0;
                        dPicAirAct = Convert.ToDouble(PicAirAct);
                        if (dPicAirAct > 97)
                            PicActAirTmp = 110;
                        else if (dPicAirAct >= 93 && dPicAirAct <= 97)
                            PicActAirTmp = 100;
                        else if (dPicAirAct < 93)
                            PicActAirTmp = 90;
                        PicScrAir = PicAirGrd * PicActAirTmp / 100;

                        // qrm 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0 && PicDppAct > 0)
                            PicAchDpp = PicDppAct / PicDppTrg * 100;
                        else
                            PicAchDpp = 0;
                        PicActDppTmp = 0;
                        dPicDppAct = Convert.ToDouble(PicDppAct);
                        if (dPicDppAct > 98)
                            PicActDppTmp = 110;
                        else if (dPicDppAct >= 95 && dPicDppAct <= 98)
                            PicActDppTmp = 100;
                        else if (dPicDppAct < 95)
                            PicActDppTmp = 90;
                        PicScrDpp = PicDppGrd * PicActDppTmp / 100;

                        // reduction 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg > 0 && PicEmeAct > 0)
                            PicAchEme = PicEmeAct / PicEmeTrg * 100;
                        else
                            PicAchEme = 0;
                        PicActEmeTmp = 0;
                        dPicEmeAct = Convert.ToDouble(PicEmeAct);
                        if (dPicEmeAct > 50000000)
                            PicActEmeTmp = 120;
                        else if (dPicEmeAct > 30000000 && dPicEmeAct <= 50000000)
                            PicActEmeTmp = 110;
                        else if (dPicEmeAct >= 20000000 && dPicEmeAct <= 30000000)
                            PicActEmeTmp = 100;
                        else if (dPicEmeAct > 0 && dPicEmeAct <= 20000000)
                            PicActEmeTmp = 90;
                        else if (dPicEmeAct < 0)
                            PicActEmeTmp = 60;
                        PicScrEme = PicEmeGrd * PicActEmeTmp / 100;

                        // payment 
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicScaGrd = 0;
                        else
                            PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) / 12, 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicScaTrg = 0;
                        else
                            PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicScaAct = 0;
                        else
                            PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        if (PicScaTrg > 0 && PicScaAct > 0)
                            PicAchSca = PicScaAct / PicScaTrg * 100;
                        else
                            PicAchSca = 0;
                        PicAchScaTmp = 0;
                        dPicScaAct = Convert.ToDouble(PicScaAct);
                        if (dPicScaAct > 120)
                            PicAchScaTmp = 120;
                        else if (dPicScaAct > 80 && dPicScaAct <= 120)
                            PicAchScaTmp = 110;
                        else if (dPicScaAct > 70 && dPicScaAct <= 80)
                            PicAchScaTmp = 100;
                        else if (dPicScaAct >= 45 && dPicScaAct <= 70)
                            PicAchScaTmp = 90;
                        else if (dPicScaAct < 45 )
                            PicAchScaTmp = 60;
                        PicScrSca = PicScaGrd * PicAchScaTmp / 100;


                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = PicAchAir,
                            PicScrAir = PicScrAir,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = PicAchDpp,
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vPurchasingDeptSummary(int id, int bln, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct;
            decimal PicInvGrd, PicInvTrg, PicInvAct, PicAirGrd, PicAirTrg, PicAirAct, PicDppAct, PicDppGrd, PicDppTrg;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicScaAct, PicScaGrd, PicScaTrg;
            decimal PicAchRev, PicScrRev, PicAchRevTmp, PicAchPda, PicScrPda, PicAchPdaTmp, PicAchPdc, PicScrPdc, PicAchPdcTmp;
            decimal PicAchInv, PicScrInv, PicActInvTmp, PicAchAir, PicScrAir, PicActAirTmp, PicAchDpp, PicScrDpp, PicActDppTmp;
            decimal PicAchEme, PicScrEme, PicActEmeTmp, PicAchSca, PicScrSca, PicAchScaTmp;
            double dPicInvAct, dPicAchRev, dPicAchPda, dPicAchPdc, dPicAirAct, dPicDppAct, dPicEmeAct, dPicScaAct;
            string date1 = Convert.ToString(id) + "-01" + "-01";
            string date2 = Convert.ToString(id) + "-12" + "-01";

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.Parameters.AddWithValue("@DATE1", date1);
                com.Parameters.AddWithValue("@DATE2", date2);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M') com.Parameters.AddWithValue("@Action", "PurchaseMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "PurchaseYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]), 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0 && PicRevAct > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        dPicAchRev = Convert.ToDouble(PicAchRev);
                        if (dPicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (dPicAchRev > 103 && dPicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (dPicAchRev > 95 && dPicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (dPicAchRev >= 90 && dPicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (dPicAchRev < 90)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);


                        if (PicPdaTrg > 0 && PicPdaAct > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        dPicAchPda = Convert.ToDouble(PicAchPda);
                        if (dPicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (dPicAchPda > 102 && dPicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (dPicAchPda > 98 && dPicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (dPicAchPda >= 94 && dPicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (dPicAchPda < 94)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0 && PicPdcAct > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        dPicAchPdc = Convert.ToDouble(PicAchPdc);
                        if (dPicAchPdc > 110)
                            PicAchPdcTmp = 120;
                        else if (dPicAchPdc > 102 && dPicAchPdc <= 110)
                            PicAchPdcTmp = 110;
                        else if (dPicAchPdc > 98 && dPicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (dPicAchPdc >= 94 && dPicAchPdc <= 98)
                            PicAchPdcTmp = 90;
                        else if (dPicAchPdc < 94)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;


                        // purch
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            PicInvGrd = 0;
                        else
                            PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]), 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            PicInvTrg = 0;
                        else
                            PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            PicInvAct = 0;
                        else
                            PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        if (PicInvTrg > 0 && PicInvAct > 0)
                            PicAchInv = (1 + ((PicInvTrg - PicInvAct) / PicInvTrg)) * 100;
                        else
                            PicAchInv = 0;
                        PicActInvTmp = 0;
                        dPicInvAct = Convert.ToDouble(PicInvAct);
                        if (dPicInvAct < 33)
                            PicActInvTmp = 110;
                        else if (dPicInvAct >= 33 && dPicInvAct <= 38)
                            PicActInvTmp = 100;
                        else if (dPicInvAct > 38)
                            PicActInvTmp = 90;
                        PicScrInv = PicInvGrd * PicActInvTmp / 100;

                        // drm
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]), 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0 && PicAirAct > 0)
                            PicAchAir = PicAirAct / PicAirTrg * 100;
                        else
                            PicAchAir = 0;
                        PicActAirTmp = 0;
                        dPicAirAct = Convert.ToDouble(PicAirAct);
                        if (dPicAirAct > 97)
                            PicActAirTmp = 110;
                        else if (dPicAirAct >= 93 && dPicAirAct <= 97)
                            PicActAirTmp = 100;
                        else if (dPicAirAct < 93)
                            PicActAirTmp = 90;
                        PicScrAir = PicAirGrd * PicActAirTmp / 100;

                        // qrm 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]), 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0 && PicDppAct > 0)
                            PicAchDpp = PicDppAct / PicDppTrg * 100;
                        else
                            PicAchDpp = 0;
                        PicActDppTmp = 0;
                        dPicDppAct = Convert.ToDouble(PicDppAct);
                        if (dPicDppAct > 98)
                            PicActDppTmp = 110;
                        else if (dPicDppAct >= 95 && dPicDppAct <= 98)
                            PicActDppTmp = 100;
                        else if (dPicDppAct < 95)
                            PicActDppTmp = 90;
                        PicScrDpp = PicDppGrd * PicActDppTmp / 100;

                        // reduction 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]), 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg > 0 && PicEmeAct > 0)
                            PicAchEme = PicEmeAct / PicEmeTrg * 100;
                        else
                            PicAchEme = 0;
                        PicActEmeTmp = 0;
                        dPicEmeAct = Convert.ToDouble(PicEmeAct);
                        if (dPicEmeAct > 50000000)
                            PicActEmeTmp = 120;
                        else if (dPicEmeAct > 30000000 && dPicEmeAct <= 50000000)
                            PicActEmeTmp = 110;
                        else if (dPicEmeAct >= 20000000 && dPicEmeAct <= 30000000)
                            PicActEmeTmp = 100;
                        else if (dPicEmeAct > 0 && dPicEmeAct <= 20000000)
                            PicActEmeTmp = 90;
                        else if (dPicEmeAct < 0)
                            PicActEmeTmp = 60;
                        PicScrEme = PicEmeGrd * PicActEmeTmp / 100;

                        // payment 
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicScaGrd = 0;
                        else
                            PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]), 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicScaTrg = 0;
                        else
                            PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicScaAct = 0;
                        else
                            PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        if (PicScaTrg > 0 && PicScaAct > 0)
                            PicAchSca = PicScaAct / PicScaTrg * 100;
                        else
                            PicAchSca = 0;
                        PicAchScaTmp = 0;
                        dPicScaAct = Convert.ToDouble(PicScaAct);
                        if (dPicScaAct > 120)
                            PicAchScaTmp = 120;
                        else if (dPicScaAct > 80 && dPicScaAct <= 120)
                            PicAchScaTmp = 110;
                        else if (dPicScaAct > 70 && dPicScaAct <= 80)
                            PicAchScaTmp = 100;
                        else if (dPicScaAct >= 45 && dPicScaAct <= 70)
                            PicAchScaTmp = 90;
                        else if (dPicScaAct < 45)
                            PicAchScaTmp = 60;
                        PicScrSca = PicScaGrd * PicAchScaTmp / 100;


                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = PicAchAir,
                            PicScrAir = PicScrAir,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = PicAchDpp,
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }
        public List<corporate> vCORPv2(int bl, int th, char ch)
        {
            int FINkp1GRD, FINkp2GRD, FINkp3GRD ;
            decimal FINkp1TGT, FINkp1ACT, FINkp2TGT, FINkp2ACT, FINkp3TGT, FINkp3ACT;

            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.Parameters.AddWithValue("@YEAR", th);
                com.Parameters.AddWithValue("@MONTH", bl);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M') com.Parameters.AddWithValue("@Action", "CORPDeptYear");
                else com.Parameters.AddWithValue("@Action", "CORPDeptMonth");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // finance revenue
                        if (rdr["finRevGrd"] == DBNull.Value)
                            FINkp1GRD = 0;
                        else
                            FINkp1GRD = Convert.ToInt32(rdr["finRevGrd"]);

                        if (rdr["finRevTrg"] == DBNull.Value)
                            FINkp1TGT = 0;
                        else
                            FINkp1TGT = Convert.ToDecimal(rdr["finRevTrg"]);

                        if (rdr["finRevAct"] == DBNull.Value)
                            FINkp1ACT = 0;
                        else
                            FINkp1ACT = Convert.ToDecimal(rdr["finRevAct"]);
                        // finance production output casting
                        if (rdr["finGrdProdCast"] == DBNull.Value)
                            FINkp2GRD = 0;
                        else
                            FINkp2GRD = Convert.ToInt32(rdr["finGrdProdCast"]);

                        if (rdr["finTgtProdCast"] == DBNull.Value)
                            FINkp2TGT = 0;
                        else
                            FINkp2TGT = Convert.ToDecimal(rdr["finTgtProdCast"]);

                        if (rdr["finActProdCast"] == DBNull.Value)
                            FINkp2ACT = 0;
                        else
                            FINkp2ACT = Convert.ToDecimal(rdr["finActProdCast"]);

                        // finance production output machining
                        if (rdr["finGrdProdMach"] == DBNull.Value)
                            FINkp3GRD = 0;
                        else
                            FINkp3GRD = Convert.ToInt32(rdr["finGrdProdMach"]);

                        if (rdr["finTgtProdMach"] == DBNull.Value)
                            FINkp3TGT = 0;
                        else
                            FINkp3TGT = Convert.ToDecimal(rdr["finTgtProdMach"]);

                        if (rdr["finActProdMach"] == DBNull.Value)
                            FINkp3ACT = 0;
                        else
                            FINkp3ACT = Convert.ToDecimal(rdr["finActProdMach"]);

                        lst.Add(new corporate
                        {
                            finGrdRev = FINkp1GRD,
                            finTgtRev = FINkp1TGT,
                            finActRev = FINkp1ACT,

                            finGrdProdCast = FINkp2GRD,
                            finTgtProdCast = FINkp2TGT,
                            finActProdCast = FINkp2ACT,

                            finGrdProdMach = FINkp3GRD,
                            finTgtProdMach = FINkp3TGT,
                            finActProdMach = FINkp3ACT

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }
        public List<corpdept> vCastingDept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicTvbGrd, PicTvbTrg, PicTvbAct, PicRjtGrd;
            decimal PicInvGrd, PicInvTrg, PicInvAct, PicAirGrd, PicAirTrg, PicAirAct, PicDppAct, PicDppGrd, PicDppTrg, PicMusGrd, PicMusTrg, PicMusAct;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicScaAct, PicScaGrd, PicScaTrg,  PicOthGrd;
            decimal PicSafGrd, PicSafTrg, PicAchSca, PicAchScaTmp, PicScrSca, PicAchInv, PicAchInvTmp, PicScrInv, PicAchDpp, PicAchDppTmp, PicScrDpp;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda,  PicAchAir, PicAchAirTmp, PicScrAir, PicAchOthTmp, PicScrOth;
            decimal PicAchEme, PicAchEmeTmp, PicScrEme, PicAchTvb,  PicAchTvbTmp, PicScrTvb,  PicAchRjtTmp, PicScrRjt, PicAchMusTmp, PicScrMus, PicScrPdc, PicAchPdcTmp;
            double PicAchOth, PicAchRjt, PicAchMus, PicRjtAct, PicRjtTrg, PicOthAct, PicOthTrg, PicAchPdc;
            decimal PicBadGrd, PicScrBad, PicAchBadTmp;
            decimal PicScpAct, PicScpGrd, PicScpTrg, PicAchScp, PicAchScpTmp, PicScrScp;
            decimal PicAlyGrd, PicAchAlyTmp, PicScrAly;
            decimal PicSilAct, PicSilGrd, PicSilTrg, PicAchSil, PicAchSilTmp, PicScrSil;
            decimal PicZifGrd, PicAchZifTmp, PicScrZif;
            decimal PicZisGrd, PicAchZisTmp, PicScrZis;
            decimal PicMufAct, PicMufGrd, PicMufTrg, PicAchMuf, PicAchMufTmp, PicScrMuf;
            decimal PicMu3Act, PicMu3Grd, PicMu3Trg, PicAchMu3, PicAchMu3Tmp, PicScrMu3;
            decimal PicMu1Act, PicMu1Grd, PicMu1Trg, PicAchMu1, PicAchMu1Tmp, PicScrMu1;
            decimal PicNonAct, PicNonGrd, PicNonTrg, PicAchNon, PicAchNonTmp, PicScrNon;
            double PicAchBad, PicAchAly, PicAchZif, PicAchZis;
            double PicBadAct, PicBadTrg, PicAlyAct, PicAlyTrg, PicZisAct, PicZisTrg, PicZifAct, PicZifTrg;
            string date1 = Convert.ToString(id) + "-01" + "-01";
            string date2 = Convert.ToString(id) + "-12" + "-31";

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V2", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.Parameters.AddWithValue("@DATE1", date1);
                com.Parameters.AddWithValue("@DATE2", date2);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Casting");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;

                        if (PicAchRev < 0)
                            PicAchRev = 0;
                        PicAchRevTmp = 0;

                        /*--
                        if (PicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (PicAchRev > 103 && PicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (PicAchRev > 95 && PicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 90 && PicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 90)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;
                       --*/
                        if (PicAchRev >= 103)
                            PicAchRevTmp = 110;
                        else if (PicAchRev >= 97 && PicAchRev < 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 91 && PicAchRev < 97)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 91)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;

                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;

                        if (PicAchPda < 0)
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        /*--
                        if (PicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (PicAchPda > 102 && PicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda > 98 && PicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 94 && PicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 94)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;
                        --*/
                        if (PicAchPda >= 103)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda >= 97 && PicAchPda < 103)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 91 && PicAchPda < 97)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 91)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // consumables
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            PicInvGrd = 0;
                        else
                            PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]) / 12, 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            PicInvTrg = 0;
                        else
                            PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            PicInvAct = 0;
                        else
                            PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        if (PicInvTrg > 0)
                            PicAchInv = (1 + ((PicInvTrg - PicInvAct) / PicInvTrg)) * 100;
                        else
                            PicAchInv = 0;

                        if (PicAchInv < 0)
                            PicAchInv = 0;
                        PicAchInvTmp = 0;
                        /*--
                        if (PicAchInv > 105)
                            PicAchInvTmp = 120;
                        else if (PicAchInv > 100 && PicAchInv <= 105)
                            PicAchInvTmp = 110;
                        else if (PicAchInv > 90 && PicAchInv <= 100)
                            PicAchInvTmp = 100;
                        else if (PicAchInv >= 80 && PicAchInv <= 90)
                            PicAchInvTmp = 90;
                        else if (PicAchInv < 80)
                            PicAchInvTmp = 60;
                        --*/
                        if (PicAchInv < 95)
                            PicAchInvTmp = 60;
                        else if (PicAchInv >= 95 && PicAchInv <= 99)
                            PicAchInvTmp = 90;
                        else if (PicAchInv > 99 && PicAchInv <= 102)
                            PicAchInvTmp = 100;
                        else if (PicAchInv > 102)
                            PicAchInvTmp = 110;

                        PicScrInv = PicInvGrd * PicAchInvTmp / 100;
                        // drm
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) / 12, 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0)
                            PicAchAir = PicAirAct / PicAirTrg * 100;
                        else
                            PicAchAir = 0;
                        if (PicAchAir < 0)
                            PicAchAir = 0;
                        PicAchAirTmp = 0;
                        if (PicAchAir > 100)
                            PicAchAirTmp = 110;
                        else if (PicAchAir > 95 && PicAchAir <= 100)
                            PicAchAirTmp = 100;
                        else if (PicAchAir >= 85 && PicAchAir <= 95)
                            PicAchAirTmp = 90;
                        else if (PicAchAir < 85)
                            PicAchAirTmp = 60;
                        PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        // foh 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;
                        if (PicAchDpp < 0)
                            PicAchDpp = 0;
                        PicAchDppTmp = 0;
                        /*--
                        if (PicAchDpp > 105)
                            PicAchDppTmp = 120;
                        else if (PicAchDpp > 100 && PicAchDpp <= 105)
                            PicAchDppTmp = 110;
                        else if (PicAchDpp > 90 && PicAchDpp <= 100)
                            PicAchDppTmp = 100;
                        else if (PicAchDpp >= 80 && PicAchDpp <= 90)
                            PicAchDppTmp = 90;
                        else if (PicAchDpp < 80)
                            PicAchDppTmp = 60;
                        --*/
                        if (PicAchDpp < 95)
                            PicAchDppTmp = 60;
                        else if (PicAchDpp >= 95 && PicAchDpp <= 99)
                            PicAchDppTmp = 90;
                        else if (PicAchDpp > 99 && PicAchDpp <= 102)
                            PicAchDppTmp = 100;
                        else if (PicAchDpp > 102)
                            PicAchDppTmp = 110;
                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;


                        //---------- cost reduction 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg == 0)
                        {
                            PicAchEme = 0;
                            PicScrEme = 0;
                        }
                        else
                        {
                            //replace PicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                            PicAchEme = PicEmeAct / PicEmeTrg * 100;                                
                            if (PicEmeAct <= 0)
                                PicAchEme = 0;
                            PicAchEmeTmp = 0;
                            if (PicAchEme > 110)
                                PicAchEmeTmp = 120;
                            else if (PicAchEme > 100 && PicAchEme <= 110)
                                PicAchEmeTmp = 110;
                            else if (PicAchEme > 95 && PicAchEme <= 100)
                                PicAchEmeTmp = 100;
                            else if (PicAchEme >= 90 && PicAchEme <= 95)
                                PicAchEmeTmp = 90;
                            else if (PicAchEme < 90)
                                PicAchEmeTmp = 60;
                            PicScrEme = PicEmeGrd * PicAchEmeTmp / 100;
                        }
                        // wip control
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicScaGrd = 0;
                        else
                            PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) / 12, 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicScaTrg = 0;
                        else
                            PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicScaAct = 0;
                        else
                            PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        if (PicScaTrg > 0)
                            PicAchSca = (1 + ((PicScaTrg - PicScaAct) / PicScaTrg)) * 100;
                        else
                            PicAchSca = 0;

                        if (id < 2020)
                        {

                            if (PicAchSca < 0) { PicAchScaTmp = 0; PicAchSca = 0; }
                            else { PicAchScaTmp = PicAchSca; }
                            //PicScrSca = PicScaGrd * PicAchScaTmp / 100;
                            if (PicScaAct == 0)
                                PicScrSca = PicScaTrg;
                            else
                                PicScrSca = PicScaGrd - (PicScaGrd - ((PicScaTrg / PicScaAct) * PicScaGrd));
                        }
                        else
                        {
                            if(PicScaAct <= 0)
                                PicAchSca = 0;
                            PicAchScaTmp = 0;
                            /*---
                            if (PicAchSca < 50)
                                PicAchScaTmp = 60;
                            else if (PicAchSca >= 50 && PicAchSca <= 90)
                                PicAchScaTmp = 90;
                            else if (PicAchSca > 90 && PicAchSca <= 100)
                                PicAchScaTmp = 100;
                            else if (PicAchSca > 100 && PicAchSca <= 125)
                                PicAchScaTmp = 110;
                            else if (PicAchSca >125)
                                PicAchScaTmp = 120;
                            ---*/
                            if (PicAchSca < 95)
                                PicAchScaTmp = 60;
                            else if (PicAchSca >= 95 && PicAchSca <= 99)
                                PicAchScaTmp = 90;
                            else if (PicAchSca > 99 && PicAchSca <= 102)
                                PicAchScaTmp = 100;
                            else if (PicAchSca > 102)
                                PicAchScaTmp = 110;
                            PicScrSca = PicScaGrd * PicAchScaTmp / 100;
                        }

                         // reject rate casting AT MFG
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) / 12, 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDouble(rdr["PicOthTrg"]);

                        if (rdr["PicOthAct"] == DBNull.Value)
                            PicOthAct = 0;
                        else
                            PicOthAct = Convert.ToDouble(rdr["PicOthAct"]);

                        if (PicOthTrg > 0)
                            PicAchOth = (1 + ((PicOthTrg - PicOthAct) / PicOthTrg)) * 100;
                        else
                            PicAchOth = 0;
                        if (PicAchOth < 0)
                            PicAchOth = 0;
                        PicAchOthTmp = 0;
                        /*--
                        if (PicOthAct < 4)
                            PicAchOthTmp = 120;
                        else if (PicOthAct >= 4 && PicOthAct <= 4.8)
                            PicAchOthTmp = 110;
                        else if (PicOthAct > 4.8 && PicOthAct <= 5)
                            PicAchOthTmp = 100;
                        else if (PicOthAct > 5 && PicOthAct <= 5.8)
                            PicAchOthTmp = 90;
                        else if (PicOthAct > 5.8)
                            PicAchOthTmp = 60;
                         --*/
                        if (PicOthAct <= 4.5)
                            PicAchOthTmp = 110;
                        else if (PicOthAct > 4.5 && PicOthAct <= 5)
                            PicAchOthTmp = 100;
                        else if (PicOthAct > 5 && PicOthAct <= 6)
                            PicAchOthTmp = 90;
                        else if (PicOthAct > 6)
                            PicAchOthTmp = 60;
                        PicScrOth = PicOthGrd * PicAchOthTmp / 100;

                        // safety Index
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]) / 12, 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        NilaiGlobal.TempGradeSaf = PicSafGrd;
                        NilaiGlobal.TempTargetSaf = PicSafTrg;

                       
                        // labor cost  
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);
                        /*------- not use
                        NilaiGlobal.TempGradeLab = PicPdcGrd;
                        NilaiGlobal.TempTargetLab = PicPdcTrg;
                        NilaiGlobal.TempActualLab = PicPdcAct;
                        -------*/
                        if (PicPdcTrg > 0)
                            PicAchPdc = Convert.ToDouble((1 + ((PicPdcTrg - PicPdcAct) / PicPdcTrg)) * 100);
                        else
                            PicAchPdc = 0;
                        if (PicAchPdc < 0)
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        /*---
                        if (PicAchPdc < 80)
                            PicAchPdcTmp = 60;
                        else if (PicAchPdc >= 80 && PicAchPdc <= 90)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc > 90 && PicAchPdc <= 100)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc > 100 && PicAchPdc <= 105)
                            PicAchPdcTmp = 110;
                        else if (PicAchPdc > 105)
                            PicAchPdcTmp = 120;
                        --*/
                        if (PicAchPdc < 95)
                            PicAchPdcTmp = 60;
                        else if (PicAchPdc >= 95 && PicAchPdc <= 99)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc > 99 && PicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc > 102)
                            PicAchPdcTmp = 110;

                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;

                        // OUTPUT POURING
                        if (id<2020)
                        {
                            if (rdr["PicTvbGrd"] == DBNull.Value)
                                PicTvbGrd = 0;
                            else
                                PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) / 12, 2);

                            if (rdr["PicTvbTrg"] == DBNull.Value)
                                PicTvbTrg = 0;
                            else
                                PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                            if (rdr["PicTvbAct"] == DBNull.Value)
                                PicTvbAct = 0;
                            else
                                PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                            if (PicTvbTrg > 0)
                                PicAchTvb = PicTvbAct / PicTvbTrg * 100;
                            else
                                PicAchTvb = 0;
                            if (PicAchTvb < 0)
                                PicAchTvb = 0;
                            PicAchTvbTmp = 0;
                            if (PicAchTvb > 110)
                                PicAchTvbTmp = 120;
                            else if (PicAchTvb > 102 && PicAchTvb <= 110)
                                PicAchTvbTmp = 110;
                            else if (PicAchTvb > 95 && PicAchTvb <= 102)
                                PicAchTvbTmp = 100;
                            else if (PicAchTvb >= 90 && PicAchTvb <= 95)
                                PicAchTvbTmp = 90;
                            else if (PicAchTvb < 90)
                                PicAchTvbTmp = 60;
                            PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;
                        }
                        else
                        {
                            PicTvbGrd = 0; PicTvbTrg = 0; PicTvbAct = 0; PicAchTvb = 0; PicScrTvb = 0;
                        }

                        // reject rate at customer
                        if (rdr["PicRjtGrd"] == DBNull.Value)
                            PicRjtGrd = 0;
                        else
                            PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]) / 12, 2);

                        if (rdr["PicRjtTrg"] == DBNull.Value)
                            PicRjtTrg = 0;
                        else
                            PicRjtTrg = Convert.ToDouble(rdr["PicRjtTrg"]);

                        if (rdr["PicRjtAct"] == DBNull.Value)
                            PicRjtAct = 0;
                        else
                            PicRjtAct = Convert.ToDouble(rdr["PicRjtAct"]);

                        if (PicRjtTrg > 0)
                            PicAchRjt = (1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100;
                        else
                            PicAchRjt = 0;
                        if (PicAchRjt < 0)
                            PicAchRjt = 0;
                        PicAchRjtTmp = 0;
                        if (PicRjtAct < 0.6)
                            PicAchRjtTmp = 120;
                        else if (PicRjtAct >= 0.6 && PicRjtAct <= 0.8)
                            PicAchRjtTmp = 110;
                        else if (PicRjtAct > 0.8 && PicRjtAct <= 1)
                            PicAchRjtTmp = 100;
                        else if (PicRjtAct > 1 && PicRjtAct <= 1.2)
                            PicAchRjtTmp = 90;
                        else if (PicRjtAct > 1.2)
                            PicAchRjtTmp = 60;
                        PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;

                        // prod cost cont material
                        if (rdr["PicMusGrd"] == DBNull.Value)
                            PicMusGrd = 0;
                        else
                            PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]) / 12, 2);

                        if (rdr["PicMusTrg"] == DBNull.Value)
                            PicMusTrg = 0;
                        else
                            PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                        if (rdr["PicMusAct"] == DBNull.Value)
                            PicMusAct = 0;
                        else
                            PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);

                        if (PicMusTrg > 0)
                            PicAchMus = Convert.ToDouble((1 + ((PicMusTrg - PicMusAct) / PicMusTrg)) * 100);
                        else
                            PicAchMus = 0;
                        if (PicAchMus < 0)
                            PicAchMus = 0;
                        PicAchMusTmp = 0;
                        if (PicMusAct < 93)
                            PicAchMusTmp = 120;
                        else if (PicMusAct >= 93 && PicMusAct <= 98)
                            PicAchMusTmp = 110;
                        else if (PicMusAct > 98 && PicMusAct <= 102)
                            PicAchMusTmp = 100;
                        else if (PicMusAct > 102 && PicMusAct <= 107)
                            PicAchMusTmp = 90;
                        else if (PicMusAct > 107)
                            PicAchMusTmp = 60;
                        PicScrMus = PicMusGrd * PicAchMusTmp / 100;
                        /*---TotalGrade---  not use
                        NilaiGlobal.TotGrade = PicRevGrd + PicPdaGrd + PicPdcGrd + PicInvGrd + PicAirGrd + PicDppGrd + PicEmeGrd + PicScaGrd + PicOthGrd + PicSafGrd + PicTvbGrd + PicRjtGrd + PicMusGrd;
                        ---Total Score---
                        NilaiGlobal.TotScore = PicScrRev + PicScrPda +  PicScrInv + PicScrAir + PicScrDpp + PicScrEme + PicScrSca + PicScrOth + PicScrTvb + PicScrRjt + PicScrMus;
                        ------------------*/
                        // foh Non
                        if (rdr["PicNonGrd"] == DBNull.Value)
                            PicNonGrd = 0;
                        else
                            PicNonGrd = Math.Round(Convert.ToDecimal(rdr["PicNonGrd"])/12, 2);

                        if (rdr["PicNonTrg"] == DBNull.Value)
                            PicNonTrg = 0;
                        else
                            PicNonTrg = Convert.ToDecimal(rdr["PicNonTrg"]);

                        if (rdr["PicNonAct"] == DBNull.Value)
                            PicNonAct = 0;
                        else
                            PicNonAct = Convert.ToDecimal(rdr["PicNonAct"]);

                        if (PicNonTrg > 0)
                            PicAchNon = (1 + ((PicNonTrg - PicNonAct) / PicNonTrg)) * 100;
                        else
                            PicAchNon = 0;
                        if (PicAchNon < 0)
                            PicAchNon = 0;
                        PicAchNonTmp = 0;
                        if (PicAchNon < 95)
                            PicAchNonTmp = 60;
                        else if (PicAchNon >= 95 && PicAchNon <= 99)
                            PicAchNonTmp = 90;
                        else if (PicAchNon > 99 && PicAchNon <= 102)
                            PicAchNonTmp = 100;
                        else if (PicAchNon > 102)
                            PicAchNonTmp = 120;
                        PicScrNon = PicNonGrd * PicAchNonTmp / 100;

                        // bad casting 
                        if (rdr["PicBadGrd"] == DBNull.Value)
                            PicBadGrd = 0;
                        else
                            PicBadGrd = Math.Round(Convert.ToDecimal(rdr["PicBadGrd"])/12, 2);

                        if (rdr["PicBadTrg"] == DBNull.Value)
                            PicBadTrg = 0;
                        else
                            PicBadTrg = Convert.ToDouble(rdr["PicBadTrg"]);

                        if (rdr["PicBadAct"] == DBNull.Value)
                            PicBadAct = 0;
                        else
                            PicBadAct = Convert.ToDouble(rdr["PicBadAct"]);

                        if (PicBadTrg > 0)
                            PicAchBad = Convert.ToDouble((1 + ((PicBadTrg - PicBadAct) / PicBadTrg)) * 100);
                        else
                            PicAchBad = 0;
                        if (PicAchBad < 0)
                            PicAchBad = 0;
                        PicAchBadTmp = 0;
                        if (PicBadAct <= 0.8)
                            PicAchBadTmp = 110;
                        else if (PicBadAct > 0.8 && PicBadAct <= 1)
                            PicAchBadTmp = 100;
                        else if (PicBadAct > 1 && PicBadAct <= 1.2)
                            PicAchBadTmp = 90;
                        else if (PicBadAct > 1.2)
                            PicAchBadTmp = 60;
                        PicScrBad = PicBadGrd * PicAchBadTmp / 100;

                        // scrap 
                        if (rdr["PicScpGrd"] == DBNull.Value)
                            PicScpGrd = 0;
                        else
                            PicScpGrd = Math.Round(Convert.ToDecimal(rdr["PicScpGrd"])/12, 2);

                        if (rdr["PicScpTrg"] == DBNull.Value)
                            PicScpTrg = 0;
                        else
                            PicScpTrg = Convert.ToDecimal(rdr["PicScpTrg"]);

                        if (rdr["PicScpAct"] == DBNull.Value)
                            PicScpAct = 0;
                        else
                            PicScpAct = Convert.ToDecimal(rdr["PicScpAct"]);

                        if (PicScpTrg > 0)
                            PicAchScp = (1 + ((PicScpTrg - PicScpAct) / PicScpTrg)) * 100;
                        else
                            PicAchScp = 0;
                        if (PicAchScp < 0)
                            PicAchScp = 0;
                        PicAchScpTmp = 0;
                        if (PicScpAct < 105)
                            PicAchScpTmp = 110;
                        else if (PicScpAct >= 105 && PicScpAct <= 108)
                            PicAchScpTmp = 100;
                        else if (PicScpAct > 108 && PicScpAct <= 110)
                            PicAchScpTmp = 90;
                        else if (PicScpAct > 110)
                            PicAchScpTmp = 60;
                        PicScrScp = PicScpGrd * PicAchScpTmp / 100;

                        // alloy 
                        if (rdr["PicAlyGrd"] == DBNull.Value)
                            PicAlyGrd = 0;
                        else
                            PicAlyGrd = Math.Round(Convert.ToDecimal(rdr["PicAlyGrd"])/12, 2);

                        if (rdr["PicAlyTrg"] == DBNull.Value)
                            PicAlyTrg = 0;
                        else
                            PicAlyTrg = Convert.ToDouble(rdr["PicAlyTrg"]);

                        if (rdr["PicAlyAct"] == DBNull.Value)
                            PicAlyAct = 0;
                        else
                            PicAlyAct = Convert.ToDouble(rdr["PicAlyAct"]);

                        if (PicAlyTrg > 0)
                            PicAchAly = Convert.ToDouble((1 + ((PicAlyTrg - PicAlyAct) / PicAlyTrg)) * 100);
                        else
                            PicAchAly = 0;
                        if (PicAchAly < 0)
                            PicAchAly = 0;
                        PicAchAlyTmp = 0;
                        if (PicAlyAct < 1.8)
                            PicAchAlyTmp = 110;
                        else if (PicAlyAct >= 1.8 && PicAlyAct <= 2)
                            PicAchAlyTmp = 100;
                        else if (PicAlyAct > 2 && PicAlyAct <= 2.2)
                            PicAchAlyTmp = 90;
                        else if (PicAlyAct > 2.2)
                            PicAchAlyTmp = 60;
                        PicScrAly = PicAlyGrd * PicAchAlyTmp / 100;

                        // silica 
                        if (rdr["PicSilGrd"] == DBNull.Value)
                            PicSilGrd = 0;
                        else
                            PicSilGrd = Math.Round(Convert.ToDecimal(rdr["PicSilGrd"])/12, 2);

                        if (rdr["PicSilTrg"] == DBNull.Value)
                            PicSilTrg = 0;
                        else
                            PicSilTrg = Convert.ToDecimal(rdr["PicSilTrg"]);

                        if (rdr["PicSilAct"] == DBNull.Value)
                            PicSilAct = 0;
                        else
                            PicSilAct = Convert.ToDecimal(rdr["PicSilAct"]);

                        if (PicSilTrg > 0)
                            PicAchSil = (1 + ((PicSilTrg - PicSilAct) / PicSilTrg)) * 100;
                        else
                            PicAchSil = 0;
                        if (PicAchSil < 0)
                            PicAchSil = 0;
                        PicAchSilTmp = 0;
                        if (PicSilAct < 27)
                            PicAchSilTmp = 110;
                        else if (PicSilAct >= 27 && PicSilAct <= 30)
                            PicAchSilTmp = 100;
                        else if (PicSilAct > 30 && PicSilAct <= 33)
                            PicAchSilTmp = 90;
                        else if (PicSilAct > 33)
                            PicAchSilTmp = 60;
                        PicScrSil = PicSilGrd * PicAchSilTmp / 100;

                        // zircon flour 
                        if (rdr["PicZifGrd"] == DBNull.Value)
                            PicZifGrd = 0;
                        else
                            PicZifGrd = Math.Round(Convert.ToDecimal(rdr["PicZifGrd"])/12, 2);

                        if (rdr["PicZifTrg"] == DBNull.Value)
                            PicZifTrg = 0;
                        else
                            PicZifTrg = Convert.ToDouble(rdr["PicZifTrg"]);

                        if (rdr["PicZifAct"] == DBNull.Value)
                            PicZifAct = 0;
                        else
                            PicZifAct = Convert.ToDouble(rdr["PicZifAct"]);

                        if (PicZifTrg > 0)
                            PicAchZif = Convert.ToDouble((1 + ((PicZifTrg - PicZifAct) / PicZifTrg)) * 100);
                        else
                            PicAchZif = 0;
                        if (PicAchZif < 0)
                            PicAchZif = 0;
                        PicAchZifTmp = 0;
                        if (PicZifAct < 5.5)
                            PicAchZifTmp = 110;
                        else if (PicZifAct >= 5.5 && PicZifAct <= 6)
                            PicAchZifTmp = 100;
                        else if (PicZifAct > 6 && PicZifAct <= 6.5)
                            PicAchZifTmp = 90;
                        else if (PicZifAct > 6.5)
                            PicAchZifTmp = 60;
                        PicScrZif = PicZifGrd * PicAchZifTmp / 100;

                        // zircon sands
                        if (rdr["PicZisGrd"] == DBNull.Value)
                            PicZisGrd = 0;
                        else
                            PicZisGrd = Math.Round(Convert.ToDecimal(rdr["PicZisGrd"])/12, 2);

                        if (rdr["PicZisTrg"] == DBNull.Value)
                            PicZisTrg = 0;
                        else
                            PicZisTrg = Convert.ToDouble(rdr["PicZisTrg"]);

                        if (rdr["PicZisAct"] == DBNull.Value)
                            PicZisAct = 0;
                        else
                            PicZisAct = Convert.ToDouble(rdr["PicZisAct"]);

                        if (PicZisTrg > 0)
                            PicAchZis = Convert.ToDouble((1 + ((PicZisTrg - PicZisAct) / PicZisTrg)) * 100);
                        else
                            PicAchZis = 0;
                        if (PicAchZis < 0)
                            PicAchZis = 0;
                        PicAchZisTmp = 0;
                        if (PicZisAct < 5.5)
                            PicAchZisTmp = 110;
                        else if (PicZisAct >= 5.5 && PicZisAct <= 6)
                            PicAchZisTmp = 100;
                        else if (PicZisAct > 6 && PicZisAct <= 6.5)
                            PicAchZisTmp = 90;
                        else if (PicZisAct > 6.5)
                            PicAchZisTmp = 60;
                        PicScrZis = PicZisGrd * PicAchZisTmp / 100;

                        // Mullite flour 
                        if (rdr["PicMufGrd"] == DBNull.Value)
                            PicMufGrd = 0;
                        else
                            PicMufGrd = Math.Round(Convert.ToDecimal(rdr["PicMufGrd"])/12, 2);

                        if (rdr["PicMufTrg"] == DBNull.Value)
                            PicMufTrg = 0;
                        else
                            PicMufTrg = Convert.ToDecimal(rdr["PicMufTrg"]);

                        if (rdr["PicMufAct"] == DBNull.Value)
                            PicMufAct = 0;
                        else
                            PicMufAct = Convert.ToDecimal(rdr["PicMufAct"]);

                        if (PicMufTrg > 0)
                            PicAchMuf = (1 + ((PicMufTrg - PicMufAct) / PicMufTrg)) * 100;
                        else
                            PicAchMuf = 0;
                        if (PicAchMuf < 0)
                            PicAchMuf = 0;
                        PicAchMufTmp = 0;
                        if (PicMufAct < 22)
                            PicAchMufTmp = 110;
                        else if (PicMufAct >= 22 && PicMufAct <= 25)
                            PicAchMufTmp = 100;
                        else if (PicMufAct > 25 && PicMufAct <= 28)
                            PicAchMufTmp = 90;
                        else if (PicMufAct > 28)
                            PicAchMufTmp = 60;
                        PicScrMuf = PicMufGrd * PicAchMufTmp / 100;

                        // Mullite Sand 30-80 
                        if (rdr["PicMu3Grd"] == DBNull.Value)
                            PicMu3Grd = 0;
                        else
                            PicMu3Grd = Math.Round(Convert.ToDecimal(rdr["PicMu3Grd"])/12, 2);

                        if (rdr["PicMu3Trg"] == DBNull.Value)
                            PicMu3Trg = 0;
                        else
                            PicMu3Trg = Convert.ToDecimal(rdr["PicMu3Trg"]);

                        if (rdr["PicMu3Act"] == DBNull.Value)
                            PicMu3Act = 0;
                        else
                            PicMu3Act = Convert.ToDecimal(rdr["PicMu3Act"]);

                        if (PicMu3Trg > 0)
                            PicAchMu3 = (1 + ((PicMu3Trg - PicMu3Act) / PicMu3Trg)) * 100;
                        else
                            PicAchMu3 = 0;
                        if (PicAchMu3 < 0)
                            PicAchMu3 = 0;
                        PicAchMu3Tmp = 0;
                        if (PicMu3Act < 13)
                            PicAchMu3Tmp = 110;
                        else if (PicMu3Act >= 13 && PicMu3Act <= 15)
                            PicAchMu3Tmp = 100;
                        else if (PicMu3Act > 15 && PicMu3Act <= 17)
                            PicAchMu3Tmp = 90;
                        else if (PicMu3Act > 17)
                            PicAchMu3Tmp = 60;
                        PicScrMu3 = PicMu3Grd * PicAchMu3Tmp / 100;

                        // Mullite Sands 15 
                        if (rdr["PicMu1Grd"] == DBNull.Value)
                            PicMu1Grd = 0;
                        else
                            PicMu1Grd = Math.Round(Convert.ToDecimal(rdr["PicMu1Grd"])/12, 2);

                        if (rdr["PicMu1Trg"] == DBNull.Value)
                            PicMu1Trg = 0;
                        else
                            PicMu1Trg = Convert.ToDecimal(rdr["PicMu1Trg"]);

                        if (rdr["PicMu1Act"] == DBNull.Value)
                            PicMu1Act = 0;
                        else
                            PicMu1Act = Convert.ToDecimal(rdr["PicMu1Act"]);

                        if (PicMu1Trg > 0)
                            PicAchMu1 = (1 + ((PicMu1Trg - PicMu1Act) / PicMu1Trg)) * 100;
                        else
                            PicAchMu1 = 0;
                        if (PicAchMu1 < 0)
                            PicAchMu1 = 0;
                        PicAchMu1Tmp = 0;
                        if (PicMu1Act < 22)
                            PicAchMu1Tmp = 110;
                        else if (PicMu1Act >= 22 && PicMu1Act <= 25)
                            PicAchMu1Tmp = 100;
                        else if (PicMu1Act > 25 && PicMu1Act <= 28)
                            PicAchMu1Tmp = 90;
                        else if (PicMu1Act > 28)
                            PicAchMu1Tmp = 60;
                        PicScrMu1 = PicMu1Grd * PicAchMu1Tmp / 100;

                        lst.Add(new corpdept
                        {
                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicAchMus = Convert.ToDecimal(PicAchMus),
                            PicScrMus = PicScrMus,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = Convert.ToDecimal(PicAchTvb),
                            PicScrTvb = PicScrTvb,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = Convert.ToDecimal(PicRjtTrg),
                            PicActRjt = Convert.ToDecimal(PicRjtAct),
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicActPdc = PicPdcAct,
                            PicTgtPdc = PicPdcTrg,
                            PicAchPdc = Convert.ToDecimal(PicAchPdc),
                            PicScrPdc = PicScrPdc,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = PicAchAir,
                            PicScrAir = PicScrAir,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = PicAchDpp,
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = Convert.ToDecimal(PicOthTrg),
                            PicActOth = Convert.ToDecimal(PicOthAct),
                            PicAchOth = Convert.ToDecimal(PicAchOth),
                            PicScrOth = PicScrOth,

                            PicGrdNon = PicNonGrd,
                            PicTgtNon = PicNonTrg,
                            PicActNon = PicNonAct,
                            PicAchNon = PicAchNon,
                            PicScrNon = PicScrNon,

                            PicGrdBad = PicBadGrd,
                            PicTgtBad = Convert.ToDecimal(PicBadTrg),
                            PicActBad = Convert.ToDecimal(PicBadAct),
                            PicAchBad = Convert.ToDecimal(PicAchBad),
                            PicScrBad = PicScrBad,

                            PicGrdScp = PicScpGrd,
                            PicTgtScp = PicScpTrg,
                            PicActScp = PicScpAct,
                            PicAchScp = PicAchScp,
                            PicScrScp = PicScrScp,

                            PicGrdAly = PicAlyGrd,
                            PicTgtAly = Convert.ToDecimal(PicAlyTrg),
                            PicActAly = Convert.ToDecimal(PicAlyAct),
                            PicAchAly = Convert.ToDecimal(PicAchAly),
                            PicScrAly = PicScrAly,

                            PicGrdSil = PicSilGrd,
                            PicTgtSil = PicSilTrg,
                            PicActSil = PicSilAct,
                            PicAchSil = PicAchSil,
                            PicScrSil = PicScrSil,

                            PicGrdZif = PicZifGrd,
                            PicTgtZif = Convert.ToDecimal(PicZifTrg),
                            PicActZif = Convert.ToDecimal(PicZifAct),
                            PicAchZif = Convert.ToDecimal(PicAchZif),
                            PicScrZif = PicScrZif,

                            PicGrdZis = PicZisGrd,
                            PicTgtZis = Convert.ToDecimal(PicZisTrg),
                            PicActZis = Convert.ToDecimal(PicZisAct),
                            PicAchZis = Convert.ToDecimal(PicAchZis),
                            PicScrZis = PicScrZis,

                            PicGrdMuf = PicMufGrd,
                            PicTgtMuf = PicMufTrg,
                            PicActMuf = PicMufAct,
                            PicAchMuf = PicAchMuf,
                            PicScrMuf = PicScrMuf,

                            PicGrdMu3 = PicMu3Grd,
                            PicTgtMu3 = PicMu3Trg,
                            PicActMu3 = PicMu3Act,
                            PicAchMu3 = PicAchMu3,
                            PicScrMu3 = PicScrMu3,

                            PicGrdMu1 = PicMu1Grd,
                            PicTgtMu1 = PicMu1Trg,
                            PicActMu1 = PicMu1Act,
                            PicAchMu1 = PicAchMu1,
                            PicScrMu1 = PicScrMu1,

                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vCastingDeptSummary(int id, int bln, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicTvbGrd, PicTvbTrg, PicTvbAct, PicRjtGrd;
            decimal PicInvGrd, PicInvTrg, PicInvAct, PicAirGrd, PicAirTrg, PicAirAct, PicDppAct, PicDppGrd, PicDppTrg, PicMusGrd, PicMusTrg, PicMusAct, PicAchMusTmp, PicScrMus;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicScaAct, PicScaGrd, PicScaTrg, PicOthGrd;
            decimal PicSafGrd, PicSafTrg, PicAchSca, PicAchScaTmp, PicScrSca, PicAchInv, PicAchInvTmp, PicScrInv, PicAchDpp, PicAchDppTmp, PicScrDpp;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda,  PicAchAir, PicAchAirTmp, PicScrAir, PicAchOthTmp, PicScrOth, PicAchPdcTmp, PicScrPdc;
            decimal PicAchEme, PicAchEmeTmp, PicScrEme, PicAchTvb, PicAchTvbTmp, PicScrTvb, PicAchRjtTmp, PicScrRjt;
            double PicAchOth, PicAchRjt, PicAchMus, PicOthAct, PicOthTrg, PicRjtTrg, PicRjtAct, PicAchPdc;
            decimal PicBadGrd, PicScrBad, PicAchBadTmp;
            decimal PicScpAct, PicScpGrd, PicScpTrg, PicAchScp, PicAchScpTmp, PicScrScp;
            decimal PicAlyGrd, PicAchAlyTmp, PicScrAly;
            decimal PicSilAct, PicSilGrd, PicSilTrg, PicAchSil, PicAchSilTmp, PicScrSil;
            decimal PicZifGrd, PicAchZifTmp, PicScrZif;
            decimal PicZisGrd, PicAchZisTmp, PicScrZis;
            decimal PicMufAct, PicMufGrd, PicMufTrg, PicAchMuf, PicAchMufTmp, PicScrMuf;
            decimal PicMu3Act, PicMu3Grd, PicMu3Trg, PicAchMu3, PicAchMu3Tmp, PicScrMu3;
            decimal PicMu1Act, PicMu1Grd, PicMu1Trg, PicAchMu1, PicAchMu1Tmp, PicScrMu1;
            decimal PicNonAct, PicNonGrd, PicNonTrg, PicAchNon, PicAchNonTmp, PicScrNon;
            double PicAchBad, PicAchAly, PicAchZif, PicAchZis;

            double PicBadAct, PicBadTrg, PicAlyAct, PicAlyTrg, PicZisAct, PicZisTrg, PicZifAct, PicZifTrg;


            string date1 = Convert.ToString(id) + "-01" + "-01";
            string date2 = Convert.ToString(id) + "-12" + "-31";

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V2", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.Parameters.AddWithValue("@DATE1", date1);
                com.Parameters.AddWithValue("@DATE2", date2);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M')
                    com.Parameters.AddWithValue("@Action", "CastingMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "CastingYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]), 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        if (PicAchRev < 0)
                            PicAchRev = 0;

                        PicAchRevTmp = 0;
                        if (PicAchRev >= 103)
                            PicAchRevTmp = 110;
                        else if (PicAchRev >= 97 && PicAchRev < 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 91 && PicAchRev < 97)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 91)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        if (PicAchPda < 0)
                            PicAchPda = 0;

                        PicAchPdaTmp = 0;
                        if (PicAchPda >= 103)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda >= 97 && PicAchPda < 103)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 91 && PicAchPda < 97)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 91)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;


                        // consumables
                        if (rdr["PicInvGrd"] == DBNull.Value)
                            PicInvGrd = 0;
                        else
                            PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]), 2);

                        if (rdr["PicInvTrg"] == DBNull.Value)
                            PicInvTrg = 0;
                        else
                            PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                        if (rdr["PicInvAct"] == DBNull.Value)
                            PicInvAct = 0;
                        else
                            PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                        if (PicInvTrg > 0)
                            PicAchInv = (1 + ((PicInvTrg - PicInvAct) / PicInvTrg)) * 100;
                        else
                            PicAchInv = 0;
                        if (PicAchInv < 0)
                            PicAchInv = 0;
                        PicAchInvTmp = 0;
                        if (PicAchInv < 95)
                            PicAchInvTmp = 60;
                        else if (PicAchInv >= 95 && PicAchInv <= 99)
                            PicAchInvTmp = 90;
                        else if (PicAchInv > 99 && PicAchInv <= 102)
                            PicAchInvTmp = 100;
                        else if (PicAchInv > 102)
                            PicAchInvTmp = 110;
                        PicScrInv = PicInvGrd * PicAchInvTmp / 100;
                        // drm
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]), 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0)
                            PicAchAir = PicAirAct / PicAirTrg * 100;
                        else
                            PicAchAir = 0;
                        if (PicAchAir < 0)
                            PicAchAir = 0;

                        PicAchAirTmp = 0;
                        if (PicAchAir > 100)
                            PicAchAirTmp = 110;
                        else if (PicAchAir > 95 && PicAchAir <= 100)
                            PicAchAirTmp = 100;
                        else if (PicAchAir >= 85 && PicAchAir <= 95)
                            PicAchAirTmp = 90;
                        else if (PicAchAir < 85)
                            PicAchAirTmp = 60;
                        PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        // foh 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]), 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;
                        if (PicAchDpp < 0)
                            PicAchDpp = 0;
                        PicAchDppTmp = 0;
                        if (PicAchDpp < 95)
                            PicAchDppTmp = 60;
                        else if (PicAchDpp >= 95 && PicAchDpp <= 99)
                            PicAchDppTmp = 90;
                        else if (PicAchDpp > 99 && PicAchDpp <= 102)
                            PicAchDppTmp = 100;
                        else if (PicAchDpp > 102)
                            PicAchDppTmp = 110;
                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;


                        // cost reduction 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]), 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg == 0)
                        {
                            PicAchEme = 0;
                            PicScrEme = 0;
                        }
                        else
                        {
                            //---not use PicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                            PicAchEme = PicEmeAct / PicEmeTrg * 100;
                            if (PicEmeAct <= 0)
                                PicAchEme = 0;
                            PicAchEmeTmp = 0;
                            if (PicAchEme > 110)
                                PicAchEmeTmp = 120;
                            else if (PicAchEme > 100 && PicAchEme <= 110)
                                PicAchEmeTmp = 110;
                            else if (PicAchEme > 95 && PicAchEme <= 100)
                                PicAchEmeTmp = 100;
                            else if (PicAchEme >= 90 && PicAchEme <= 95)
                                PicAchEmeTmp = 90;
                            else if (PicAchEme < 90)
                                PicAchEmeTmp = 60;
                            PicScrEme = PicEmeGrd * PicAchEmeTmp / 100;
                        }
                        // wip control
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicScaGrd = 0;
                        else
                            PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]), 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicScaTrg = 0;
                        else
                            PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicScaAct = 0;
                        else
                            PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);
                        if (PicScaTrg > 0)
                            PicAchSca = (1 + ((PicScaTrg - PicScaAct) / PicScaTrg)) * 100;
                        else
                            PicAchSca = 0;
                        if (id<2020)
                        {
                            if (PicAchSca < 0) { PicAchScaTmp = 0; PicAchSca = 0; }
                            else { PicAchScaTmp = PicAchSca; }
                            //--PicScrSca = PicScaGrd * PicAchScaTmp / 100;
                            if (PicScaAct == 0)
                                PicScrSca = PicScaGrd;
                            else
                                PicScrSca = PicScaGrd - (PicScaGrd - ((PicScaTrg / PicScaAct) * PicScaGrd));

                        }
                        else
                        {
                            if (PicScaAct <= 0)
                                PicAchSca = 0;
                            PicAchScaTmp = 0;
                            if (PicAchSca < 95)
                                PicAchScaTmp = 60;
                            else if (PicAchSca >= 95 && PicAchSca <= 99)
                                PicAchScaTmp = 90;
                            else if (PicAchSca > 99 && PicAchSca <= 102)
                                PicAchScaTmp = 100;
                            else if (PicAchSca > 102)
                                PicAchScaTmp = 110;
                            PicScrSca = PicScaGrd * PicAchScaTmp / 100;
                        }

                        // reject rate casting MFG
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]), 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDouble(rdr["PicOthTrg"]);

                        if (rdr["PicOthAct"] == DBNull.Value)
                            PicOthAct = 0;
                        else
                            PicOthAct = Convert.ToDouble(rdr["PicOthAct"]);

                        if (PicOthTrg > 0)
                            PicAchOth = (1 + ((PicOthTrg - PicOthAct) / PicOthTrg)) * 100;
                        else
                            PicAchOth = 0;
                        if (PicAchOth < 0)
                            PicAchOth = 0;

                        PicAchOthTmp = 0;
                        if (PicOthAct <= 4.5)
                            PicAchOthTmp = 110;
                        else if (PicOthAct > 4.5 && PicOthAct <= 5)
                            PicAchOthTmp = 100;
                        else if (PicOthAct > 5 && PicOthAct <= 6)
                            PicAchOthTmp = 90;
                        else if (PicOthAct > 6)
                            PicAchOthTmp = 60;
                        PicScrOth = PicOthGrd * PicAchOthTmp / 100;

                        // safety Index
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]), 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        NilaiGlobal.TempGradeSaf = PicSafGrd;
                        NilaiGlobal.TempTargetSaf = PicSafTrg;

                        // labor cost  
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        /*--- not use
                        NilaiGlobal.TempGradeLab = PicPdcGrd;
                        NilaiGlobal.TempTargetLab = PicPdcTrg;
                        if (ch == 'M')
                            NilaiGlobal.TempActualLabMonth = PicPdcAct;
                        else
                            NilaiGlobal.TempActualLabYear = PicPdcAct;
                            ---*/

                        if (PicPdcTrg > 0)
                            PicAchPdc = Convert.ToDouble((1 + ((PicPdcTrg - PicPdcAct) / PicPdcTrg)) * 100);
                        else
                            PicAchPdc = 0;
                        if (PicAchPdc < 0)
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        if (PicAchPdc < 95)
                            PicAchPdcTmp = 60;
                        else if (PicAchPdc >= 95 && PicAchPdc <= 99)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc > 99 && PicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc > 102)
                            PicAchPdcTmp = 110;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;


                        // OUTPUT POURING
                        if (id<2020)
                        {
                            if (rdr["PicTvbGrd"] == DBNull.Value)
                                PicTvbGrd = 0;
                            else
                                PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]), 2);

                            if (rdr["PicTvbTrg"] == DBNull.Value)
                                PicTvbTrg = 0;
                            else
                                PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                            if (rdr["PicTvbAct"] == DBNull.Value)
                                PicTvbAct = 0;
                            else
                                PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                            if (PicTvbTrg > 0)
                                PicAchTvb = PicTvbAct / PicTvbTrg * 100;
                            else
                                PicAchTvb = 0;
                            if (PicAchTvb < 0)
                                PicAchTvb = 0;
                            PicAchTvbTmp = 0;
                            if (PicAchTvb > 110)
                                PicAchTvbTmp = 120;
                            else if (PicAchTvb > 102 && PicAchTvb <= 110)
                                PicAchTvbTmp = 110;
                            else if (PicAchTvb > 95 && PicAchTvb <= 102)
                                PicAchTvbTmp = 100;
                            else if (PicAchTvb >= 90 && PicAchTvb <= 95)
                                PicAchTvbTmp = 90;
                            else if (PicAchTvb < 90)
                                PicAchTvbTmp = 60;
                            PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;
                        }
                        else
                        {
                            PicTvbGrd = 0; PicTvbTrg = 0; PicTvbAct = 0; PicAchTvb = 0; PicScrTvb = 0;
                            
                        }


                        // reject rate at customer
                        if (rdr["PicRjtGrd"] == DBNull.Value)
                                PicRjtGrd = 0;
                        else
                            PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]), 2);

                        if (rdr["PicRjtTrg"] == DBNull.Value)
                            PicRjtTrg = 0;
                        else
                            PicRjtTrg = Convert.ToDouble(rdr["PicRjtTrg"]);

                        if (rdr["PicRjtAct"] == DBNull.Value)
                            PicRjtAct = 0;
                        else
                            PicRjtAct = Convert.ToDouble(rdr["PicRjtAct"]);

                        if (PicRjtTrg > 0)
                            PicAchRjt = (1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100;
                        else
                            PicAchRjt = 0;
                        if (PicAchRjt < 0)
                            PicAchRjt = 0;
                        PicAchRjtTmp = 0;
                        if (PicRjtAct < 0.6)
                            PicAchRjtTmp = 120;
                        else if (PicRjtAct >= 0.6 && PicRjtAct <= 0.8)
                            PicAchRjtTmp = 110;
                        else if (PicRjtAct > 0.8 && PicRjtAct <= 1)
                            PicAchRjtTmp = 100;
                        else if (PicRjtAct > 1 && PicRjtAct <= 1.2)
                            PicAchRjtTmp = 90;
                        else if (PicRjtAct > 1.2)
                            PicAchRjtTmp = 60;
                        PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;
                     

                        // prod cost cont material
                        if (rdr["PicMusGrd"] == DBNull.Value)
                            PicMusGrd = 0;
                        else
                            PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]), 2);

                        if (rdr["PicMusTrg"] == DBNull.Value)
                            PicMusTrg = 0;
                        else
                            PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                        if (rdr["PicMusAct"] == DBNull.Value)
                            PicMusAct = 0;
                        else
                            PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);

                        if (PicMusTrg > 0)
                            PicAchMus = Convert.ToDouble((1 + ((PicMusTrg - PicMusAct) / PicMusTrg)) * 100);
                        else
                            PicAchMus = 0;
                        if (PicAchMus < 0)
                            PicAchMus = 0;
                        PicAchMusTmp = 0;
                        if (PicMusAct < 93)
                            PicAchMusTmp = 120;
                        else if (PicMusAct >= 93 && PicMusAct <= 98)
                            PicAchMusTmp = 110;
                        else if (PicMusAct > 98 && PicMusAct <= 102)
                            PicAchMusTmp = 100;
                        else if (PicMusAct > 102 && PicMusAct <= 107)
                            PicAchMusTmp = 90;
                        else if (PicMusAct > 107)
                            PicAchMusTmp = 60;
                        PicScrMus = PicMusGrd * PicAchMusTmp / 100;
                        /*------------not use
                        if (ch == 'M')
                        { 
                            //---TotalGrade---
                            NilaiGlobal.TotGradeMonth = PicRevGrd + PicPdaGrd + PicPdcGrd + PicInvGrd + PicAirGrd + PicDppGrd + PicEmeGrd + PicScaGrd + PicOthGrd + PicSafGrd + PicTvbGrd + PicRjtGrd + PicMusGrd;
                            //---Total Score---
                            NilaiGlobal.TotScoreMonth = PicScrRev + PicScrPda + PicScrInv + PicScrAir + PicScrDpp + PicScrEme + PicScrSca + PicScrOth + PicScrTvb + PicScrRjt + PicScrMus;
                        }
                        else
                        {

                            //---TotalGrade---
                            NilaiGlobal.TotGradeSum = PicRevGrd + PicPdaGrd + PicPdcGrd + PicInvGrd + PicAirGrd + PicDppGrd + PicEmeGrd + PicScaGrd + PicOthGrd + PicSafGrd + PicTvbGrd + PicRjtGrd + PicMusGrd;
                            //---Total Score---
                            NilaiGlobal.TotScoreSum = PicScrRev + PicScrPda + PicScrInv + PicScrAir + PicScrDpp + PicScrEme + PicScrSca + PicScrOth + PicScrTvb + PicScrRjt + PicScrMus;
                        }
                        ----------------*/

                        // foh Non
                        if (rdr["PicNonGrd"] == DBNull.Value)
                            PicNonGrd = 0;
                        else
                            PicNonGrd = Math.Round(Convert.ToDecimal(rdr["PicNonGrd"]), 2);

                        if (rdr["PicNonTrg"] == DBNull.Value)
                            PicNonTrg = 0;
                        else
                            PicNonTrg = Convert.ToDecimal(rdr["PicNonTrg"]);

                        if (rdr["PicNonAct"] == DBNull.Value)
                            PicNonAct = 0;
                        else
                            PicNonAct = Convert.ToDecimal(rdr["PicNonAct"]);

                        if (PicNonTrg > 0)
                            PicAchNon = (1 + ((PicNonTrg - PicNonAct) / PicNonTrg)) * 100;
                        else
                            PicAchNon = 0;
                        if (PicAchNon < 0)
                            PicAchNon = 0;
                        PicAchNonTmp = 0;
                        if (PicAchNon < 95)
                            PicAchNonTmp = 60;
                        else if (PicAchNon >= 95 && PicAchNon <= 99)
                            PicAchNonTmp = 90;
                        else if (PicAchNon > 99 && PicAchNon <= 102)
                            PicAchNonTmp = 100;
                        else if (PicAchNon > 102)
                            PicAchNonTmp = 110;
                        PicScrNon = PicNonGrd * PicAchNonTmp / 100;

                        // bad casting 
                        if (rdr["PicBadGrd"] == DBNull.Value)
                            PicBadGrd = 0;
                        else
                            PicBadGrd = Math.Round(Convert.ToDecimal(rdr["PicBadGrd"]), 2);

                        if (rdr["PicBadTrg"] == DBNull.Value)
                            PicBadTrg = 0;
                        else
                            PicBadTrg = Convert.ToDouble(rdr["PicBadTrg"]);

                        if (rdr["PicBadAct"] == DBNull.Value)
                            PicBadAct = 0;
                        else
                            PicBadAct = Convert.ToDouble(rdr["PicBadAct"]);

                        if (PicBadTrg > 0)
                            PicAchBad = Convert.ToDouble((1 + ((PicBadTrg - PicBadAct) / PicBadTrg)) * 100);
                        else
                            PicAchBad = 0;
                        if (PicAchBad < 0)
                            PicAchBad = 0;
                        PicAchBadTmp = 0;
                        if (PicBadAct <= 0.8)
                            PicAchBadTmp = 110;
                        else if (PicBadAct > 0.8 && PicBadAct <= 1)
                            PicAchBadTmp = 100;
                        else if (PicBadAct > 1 && PicBadAct <= 1.2)
                            PicAchBadTmp = 90;
                        else if (PicBadAct > 1.2)
                            PicAchBadTmp = 60;
                        PicScrBad = PicBadGrd * PicAchBadTmp / 100;

                        // scrap 
                        if (rdr["PicScpGrd"] == DBNull.Value)
                            PicScpGrd = 0;
                        else
                            PicScpGrd = Math.Round(Convert.ToDecimal(rdr["PicScpGrd"]), 2);

                        if (rdr["PicScpTrg"] == DBNull.Value)
                            PicScpTrg = 0;
                        else
                            PicScpTrg = Convert.ToDecimal(rdr["PicScpTrg"]);

                        if (rdr["PicScpAct"] == DBNull.Value)
                            PicScpAct = 0;
                        else
                            PicScpAct = Convert.ToDecimal(rdr["PicScpAct"]);

                        if (PicScpTrg > 0)
                            PicAchScp = (1 + ((PicScpTrg - PicScpAct) / PicScpTrg)) * 100;
                        else
                            PicAchScp = 0;
                        if (PicAchScp < 0)
                            PicAchScp = 0;
                        PicAchScpTmp = 0;
                        if (PicScpAct < 105)
                            PicAchScpTmp = 110;
                        else if (PicScpAct >= 105 && PicScpAct <= 108)
                            PicAchScpTmp = 100;
                        else if (PicScpAct > 108 && PicScpAct <= 110)
                            PicAchScpTmp = 90;
                        else if (PicScpAct > 110)
                            PicAchScpTmp = 60;
                        PicScrScp = PicScpGrd * PicAchScpTmp / 100;

                        // alloy 
                        if (rdr["PicAlyGrd"] == DBNull.Value)
                            PicAlyGrd = 0;
                        else
                            PicAlyGrd = Math.Round(Convert.ToDecimal(rdr["PicAlyGrd"]), 2);

                        if (rdr["PicAlyTrg"] == DBNull.Value)
                            PicAlyTrg = 0;
                        else
                            PicAlyTrg = Convert.ToDouble(rdr["PicAlyTrg"]);

                        if (rdr["PicAlyAct"] == DBNull.Value)
                            PicAlyAct = 0;
                        else
                            PicAlyAct = Convert.ToDouble(rdr["PicAlyAct"]);

                        if (PicAlyTrg > 0)
                            PicAchAly = Convert.ToDouble((1 + ((PicAlyTrg - PicAlyAct) / PicAlyTrg)) * 100);
                        else
                            PicAchAly = 0;
                        if (PicAchAly < 0)
                            PicAchAly = 0;
                        PicAchAlyTmp = 0;
                        if (PicAlyAct < 1.8)
                            PicAchAlyTmp = 110;
                        else if (PicAlyAct >= 1.8 && PicAlyAct <= 2)
                            PicAchAlyTmp = 100;
                        else if (PicAlyAct > 2 && PicAlyAct <= 2.2)
                            PicAchAlyTmp = 90;
                        else if (PicAlyAct > 2.2)
                            PicAchAlyTmp = 60;
                        PicScrAly = PicAlyGrd * PicAchAlyTmp / 100;

                        // silica 
                        if (rdr["PicSilGrd"] == DBNull.Value)
                            PicSilGrd = 0;
                        else
                            PicSilGrd = Math.Round(Convert.ToDecimal(rdr["PicSilGrd"]), 2);

                        if (rdr["PicSilTrg"] == DBNull.Value)
                            PicSilTrg = 0;
                        else
                            PicSilTrg = Convert.ToDecimal(rdr["PicSilTrg"]);

                        if (rdr["PicSilAct"] == DBNull.Value)
                            PicSilAct = 0;
                        else
                            PicSilAct = Convert.ToDecimal(rdr["PicSilAct"]);

                        if (PicSilTrg > 0)
                            PicAchSil = (1 + ((PicSilTrg - PicSilAct) / PicSilTrg)) * 100;
                        else
                            PicAchSil = 0;
                        if (PicAchSil < 0)
                            PicAchSil = 0;
                        PicAchSilTmp = 0;
                        if (PicSilAct < 27)
                            PicAchSilTmp = 110;
                        else if (PicSilAct >= 27 && PicSilAct <= 30)
                            PicAchSilTmp = 100;
                        else if (PicSilAct > 30 && PicSilAct <= 33)
                            PicAchSilTmp = 90;
                        else if (PicSilAct > 33)
                            PicAchSilTmp = 60;
                        PicScrSil = PicSilGrd * PicAchSilTmp / 100;

                        // zircon flour 
                        if (rdr["PicZifGrd"] == DBNull.Value)
                            PicZifGrd = 0;
                        else
                            PicZifGrd = Math.Round(Convert.ToDecimal(rdr["PicZifGrd"]), 2);

                        if (rdr["PicZifTrg"] == DBNull.Value)
                            PicZifTrg = 0;
                        else
                            PicZifTrg = Convert.ToDouble(rdr["PicZifTrg"]);

                        if (rdr["PicZifAct"] == DBNull.Value)
                            PicZifAct = 0;
                        else
                            PicZifAct = Convert.ToDouble(rdr["PicZifAct"]);

                        if (PicZifTrg > 0)
                            PicAchZif = Convert.ToDouble((1 + ((PicZifTrg - PicZifAct) / PicZifTrg)) * 100);
                        else
                            PicAchZif = 0;
                        if (PicAchZif < 0)
                            PicAchZif = 0;
                        PicAchZifTmp = 0;
                        if (PicZifAct < 5.5)
                            PicAchZifTmp = 110;
                        else if (PicZifAct >= 5.5 && PicZifAct <= 6)
                            PicAchZifTmp = 100;
                        else if (PicZifAct > 6 && PicZifAct <= 6.5)
                            PicAchZifTmp = 90;
                        else if (PicZifAct > 6.5)
                            PicAchZifTmp = 60;
                        PicScrZif = PicZifGrd * PicAchZifTmp / 100;

                        // zircon sands
                        if (rdr["PicZisGrd"] == DBNull.Value)
                            PicZisGrd = 0;
                        else
                            PicZisGrd = Math.Round(Convert.ToDecimal(rdr["PicZisGrd"]), 2);

                        if (rdr["PicZisTrg"] == DBNull.Value)
                            PicZisTrg = 0;
                        else
                            PicZisTrg = Convert.ToDouble(rdr["PicZisTrg"]);

                        if (rdr["PicZisAct"] == DBNull.Value)
                            PicZisAct = 0;
                        else
                            PicZisAct = Convert.ToDouble(rdr["PicZisAct"]);

                        if (PicZisTrg > 0)
                            PicAchZis = Convert.ToDouble((1 + ((PicZisTrg - PicZisAct) / PicZisTrg)) * 100);
                        else
                            PicAchZis = 0;
                        if (PicAchZis < 0)
                            PicAchZis = 0;
                        PicAchZisTmp = 0;
                        if (PicZisAct < 5.5)
                            PicAchZisTmp = 110;
                        else if (PicZisAct >= 5.5 && PicZisAct <= 6)
                            PicAchZisTmp = 100;
                        else if (PicZisAct > 6 && PicZisAct <= 6.5)
                            PicAchZisTmp = 90;
                        else if (PicZisAct > 6.5)
                            PicAchZisTmp = 60;
                        PicScrZis = PicZisGrd * PicAchZisTmp / 100;

                        // Mullite flour 
                        if (rdr["PicMufGrd"] == DBNull.Value)
                            PicMufGrd = 0;
                        else
                            PicMufGrd = Math.Round(Convert.ToDecimal(rdr["PicMufGrd"]), 2);

                        if (rdr["PicMufTrg"] == DBNull.Value)
                            PicMufTrg = 0;
                        else
                            PicMufTrg = Convert.ToDecimal(rdr["PicMufTrg"]);

                        if (rdr["PicMufAct"] == DBNull.Value)
                            PicMufAct = 0;
                        else
                            PicMufAct = Convert.ToDecimal(rdr["PicMufAct"]);

                        if (PicMufTrg > 0)
                            PicAchMuf = (1 + ((PicMufTrg - PicMufAct) / PicMufTrg)) * 100;
                        else
                            PicAchMuf = 0;
                        if (PicAchMuf < 0)
                            PicAchMuf = 0;
                        PicAchMufTmp = 0;
                        if (PicMufAct < 22)
                            PicAchMufTmp = 110;
                        else if (PicMufAct >= 22 && PicMufAct <= 25)
                            PicAchMufTmp = 100;
                        else if (PicMufAct > 25 && PicMufAct <= 28)
                            PicAchMufTmp = 90;
                        else if (PicMufAct > 28)
                            PicAchMufTmp = 60;
                        PicScrMuf = PicMufGrd * PicAchMufTmp / 100;

                        // Mullite Sand 30-80 
                        if (rdr["PicMu3Grd"] == DBNull.Value)
                            PicMu3Grd = 0;
                        else
                            PicMu3Grd = Math.Round(Convert.ToDecimal(rdr["PicMu3Grd"]), 2);

                        if (rdr["PicMu3Trg"] == DBNull.Value)
                            PicMu3Trg = 0;
                        else
                            PicMu3Trg = Convert.ToDecimal(rdr["PicMu3Trg"]);

                        if (rdr["PicMu3Act"] == DBNull.Value)
                            PicMu3Act = 0;
                        else
                            PicMu3Act = Convert.ToDecimal(rdr["PicMu3Act"]);

                        if (PicMu3Trg > 0)
                            PicAchMu3 = (1 + ((PicMu3Trg - PicMu3Act) / PicMu3Trg)) * 100;
                        else
                            PicAchMu3 = 0;
                        if (PicAchMu3 < 0)
                            PicAchMu3 = 0;
                        PicAchMu3Tmp = 0;
                        if (PicMu3Act < 13)
                            PicAchMu3Tmp = 110;
                        else if (PicMu3Act >= 13 && PicMu3Act <= 15)
                            PicAchMu3Tmp = 100;
                        else if (PicMu3Act > 15 && PicMu3Act <= 17)
                            PicAchMu3Tmp = 90;
                        else if (PicMu3Act > 17)
                            PicAchMu3Tmp = 60;
                        PicScrMu3 = PicMu3Grd * PicAchMu3Tmp / 100;

                        // Mullite Sands 15 
                        if (rdr["PicMu1Grd"] == DBNull.Value)
                            PicMu1Grd = 0;
                        else
                            PicMu1Grd = Math.Round(Convert.ToDecimal(rdr["PicMu1Grd"]), 2);

                        if (rdr["PicMu1Trg"] == DBNull.Value)
                            PicMu1Trg = 0;
                        else
                            PicMu1Trg = Convert.ToDecimal(rdr["PicMu1Trg"]);

                        if (rdr["PicMu1Act"] == DBNull.Value)
                            PicMu1Act = 0;
                        else
                            PicMu1Act = Convert.ToDecimal(rdr["PicMu1Act"]);

                        if (PicMu1Trg > 0)
                            PicAchMu1 = (1 + ((PicMu1Trg - PicMu1Act) / PicMu1Trg)) * 100;
                        else
                            PicAchMu1 = 0;
                        if (PicAchMu1 < 0)
                            PicAchMu1 = 0;
                        PicAchMu1Tmp = 0;
                        if (PicMu1Act < 22)
                            PicAchMu1Tmp = 110;
                        else if (PicMu1Act >= 22 && PicMu1Act <= 25)
                            PicAchMu1Tmp = 100;
                        else if (PicMu1Act > 25 && PicMu1Act <= 28)
                            PicAchMu1Tmp = 90;
                        else if (PicMu1Act > 28)
                            PicAchMu1Tmp = 60;
                        PicScrMu1 = PicMu1Grd * PicAchMu1Tmp / 100;


                        lst.Add(new corpdept
                        {
                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicAchMus = Convert.ToDecimal(PicAchMus),
                            PicScrMus = PicScrMus,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = PicAchTvb,
                            PicScrTvb = PicScrTvb,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = Convert.ToDecimal(PicRjtTrg),
                            PicActRjt = Convert.ToDecimal(PicRjtAct),
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = Convert.ToDecimal(PicAchPdc),
                            PicScrPdc = PicScrPdc,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = PicAchAir,
                            PicScrAir = PicScrAir,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = PicAchDpp,
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = Convert.ToDecimal(PicOthTrg),
                            PicActOth = Convert.ToDecimal(PicOthAct),
                            PicAchOth = Convert.ToDecimal(PicAchOth),
                            PicScrOth = PicScrOth,

                            PicGrdNon = PicNonGrd,
                            PicTgtNon = PicNonTrg,
                            PicActNon = PicNonAct,
                            PicAchNon = PicAchNon,
                            PicScrNon = PicScrNon,

                            PicGrdBad = PicBadGrd,
                            PicTgtBad = Convert.ToDecimal(PicBadTrg),
                            PicActBad = Convert.ToDecimal(PicBadAct),
                            PicAchBad = Convert.ToDecimal(PicAchBad),
                            PicScrBad = PicScrBad,

                            PicGrdScp = PicScpGrd,
                            PicTgtScp = PicScpTrg,
                            PicActScp = PicScpAct,
                            PicAchScp = PicAchScp,
                            PicScrScp = PicScrScp,

                            PicGrdAly = PicAlyGrd,
                            PicTgtAly = Convert.ToDecimal(PicAlyTrg),
                            PicActAly = Convert.ToDecimal(PicAlyAct),
                            PicAchAly = Convert.ToDecimal(PicAchAly),
                            PicScrAly = PicScrAly,

                            PicGrdSil = PicSilGrd,
                            PicTgtSil = PicSilTrg,
                            PicActSil = PicSilAct,
                            PicAchSil = PicAchSil,
                            PicScrSil = PicScrSil,

                            PicGrdZif = PicZifGrd,
                            PicTgtZif = Convert.ToDecimal(PicZifTrg),
                            PicActZif = Convert.ToDecimal(PicZifAct),
                            PicAchZif = Convert.ToDecimal(PicAchZif),
                            PicScrZif = PicScrZif,

                            PicGrdZis = PicZisGrd,
                            PicTgtZis = Convert.ToDecimal(PicZisTrg),
                            PicActZis = Convert.ToDecimal(PicZisAct),
                            PicAchZis = Convert.ToDecimal(PicAchZis),
                            PicScrZis = PicScrZis,

                            PicGrdMuf = PicMufGrd,
                            PicTgtMuf = PicMufTrg,
                            PicActMuf = PicMufAct,
                            PicAchMuf = PicAchMuf,
                            PicScrMuf = PicScrMuf,

                            PicGrdMu3 = PicMu3Grd,
                            PicTgtMu3 = PicMu3Trg,
                            PicActMu3 = PicMu3Act,
                            PicAchMu3 = PicAchMu3,
                            PicScrMu3 = PicScrMu3,

                            PicGrdMu1 = PicMu1Grd,
                            PicTgtMu1 = PicMu1Trg,
                            PicActMu1 = PicMu1Act,
                            PicAchMu1 = PicAchMu1,
                            PicScrMu1 = PicScrMu1,

                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }
        
        public List<corpdept> vProductionDept(int id, int bln)
        {
            //PicOthAct
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct,  PicOthGrd, PicOthTrg;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicDppGrd, PicDppTrg;
            decimal PicSafGrd, PicSafTrg;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchEme, PicAchEmeTmp, PicScrEme;


            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V2", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Prod");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        if (PicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (PicAchRev > 103 && PicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (PicAchRev > 95 && PicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 90 && PicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 90)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        if (PicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (PicAchPda > 102 && PicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda > 98 && PicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 95 && PicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 95)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        if (PicAchPdc > 110)
                            PicAchPdcTmp = 120;
                        else if (PicAchPdc > 102 && PicAchPdc <= 110)
                            PicAchPdcTmp = 110;
                        else if (PicAchPdc > 95 && PicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc >= 90 && PicAchPdc <= 95)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc < 90)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;

                        // cost reduction 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg == 0)
                        {
                            PicAchEme = 0;
                            PicScrEme = 0;
                        }
                        else
                        {

                            //PicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                            PicAchEme = PicEmeAct / PicEmeTrg * 100;
                            if (PicEmeAct <= 0)
                                PicAchEme = 0;
                            PicAchEmeTmp = 0;
                            if (PicAchEme > 150)
                                PicAchEmeTmp = 120;
                            else if (PicAchEme > 100 && PicAchEme <= 150)
                                PicAchEmeTmp = 110;
                            else if (PicAchEme > 30 && PicAchEme <= 100)
                                PicAchEmeTmp = 100;
                            else if (PicAchEme >= 0 && PicAchEme <= 30)
                                PicAchEmeTmp = 90;
                            else if (PicAchEme < 0)
                                PicAchEmeTmp = 60;
                            PicScrEme = PicEmeGrd * PicAchEmeTmp / 100;

                        }
                        // safety Index
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]) / 12, 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        NilaiGlobal.TempGradeSaf = PicSafGrd;
                        NilaiGlobal.TempTargetSaf = PicSafTrg;

                        // Implementation 5S
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) / 12, 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);

                        NilaiGlobal.TempGradeLab = PicOthGrd;
                        NilaiGlobal.TempTargetLab = PicOthTrg;

                        //--average score of ppic,machining,casting, 
                        if (id<2020)
                        {
                            if (rdr["PicDppGrd"] == DBNull.Value)
                                PicDppGrd = 0;
                            else
                                PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                            if (rdr["PicDppTrg"] == DBNull.Value)
                                PicDppTrg = 0;
                            else
                                PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);
                        } else {
                            PicDppGrd = 0; PicDppTrg = 0;
                        }

                        //---TotalGrade---
                        NilaiGlobal.TotGrade = PicRevGrd + PicPdaGrd + PicPdcGrd +  PicEmeGrd + PicSafGrd + PicOthGrd + PicDppGrd;
                        //---Total Score---
                        NilaiGlobal.TotScore = PicScrRev + PicScrPda + PicScrPda  + PicScrEme ;

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vProductionDeptSummary(int id, int bln, char ch)
        {
            //PicOthAct
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicOthGrd, PicOthTrg;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg;
            decimal PicSafGrd, PicSafTrg, PicDppGrd, PicDppTrg;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchEme, PicAchEmeTmp, PicScrEme;


            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V2", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M')
                    com.Parameters.AddWithValue("@Action", "ProdMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "ProdYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]), 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        if (PicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (PicAchRev > 103 && PicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (PicAchRev > 95 && PicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 90 && PicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 90)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        if (PicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (PicAchPda > 102 && PicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda > 98 && PicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 95 && PicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 95)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        if (PicAchPdc > 110)
                            PicAchPdcTmp = 120;
                        else if (PicAchPdc > 102 && PicAchPdc <= 110)
                            PicAchPdcTmp = 110;
                        else if (PicAchPdc > 95 && PicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc >= 90 && PicAchPdc <= 95)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc < 90)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;

                        // cost reduction 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]), 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg == 0)
                        {
                            PicAchEme = 0;
                            PicScrEme = 0;
                        }
                        else
                        {

                            //not usePicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                            PicAchEme = PicEmeAct / PicEmeTrg * 100;
                            if (PicEmeAct <= 0)
                                PicAchEme = 0;
                            PicAchEmeTmp = 0;
                            if (PicAchEme > 150)
                                PicAchEmeTmp = 120;
                            else if (PicAchEme > 100 && PicAchEme <= 150)
                                PicAchEmeTmp = 110;
                            else if (PicAchEme > 30 && PicAchEme <= 100)
                                PicAchEmeTmp = 100;
                            else if (PicAchEme >= 0 && PicAchEme <= 30)
                                PicAchEmeTmp = 90;
                            else if (PicAchEme < 0)
                                PicAchEmeTmp = 60;
                            PicScrEme = PicEmeGrd * PicAchEmeTmp / 100;
                        }

                        // safety Index
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]), 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        NilaiGlobal.TempGradeSaf = PicSafGrd;
                        NilaiGlobal.TempTargetSaf = PicSafTrg;

                        // Implementation 5S
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]), 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);


                        if (id<2020)
                        {
                            //--average score of ppic,machining,casting, 
                            if (rdr["PicDppGrd"] == DBNull.Value)
                                PicDppGrd = 0;
                            else
                                PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]), 2);

                            if (rdr["PicDppTrg"] == DBNull.Value)
                                PicDppTrg = 0;
                            else
                                PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);
                        } else
                        {
                            PicDppGrd = 0; PicDppTrg = 0;
                        }

                        if (ch == 'M')
                        {
                            NilaiGlobal.TempGradeLabMonth = PicOthGrd;
                            NilaiGlobal.TempTargetLabMonth = PicOthTrg;
                        }
                        else
                        {
                            NilaiGlobal.TempGradeLabYear = PicOthGrd;
                            NilaiGlobal.TempTargetLabYear = PicOthTrg;

                        }
                        if (ch == 'M')
                        {
                            //---TotalGrade---
                            NilaiGlobal.TotGradeMonth = PicRevGrd + PicPdaGrd + PicPdcGrd + PicEmeGrd + PicSafGrd + PicOthGrd + PicDppGrd;
                            //---Total Score---
                            NilaiGlobal.TotScoreMonth = PicScrRev + PicScrPda + PicScrPda + PicScrEme;
                        }
                        else
                        {
                            //---TotalGrade---
                            NilaiGlobal.TotGradeSum = PicRevGrd + PicPdaGrd + PicPdcGrd + PicEmeGrd + PicSafGrd + PicOthGrd + PicDppGrd;
                            //---Total Score---
                            NilaiGlobal.TotScoreSum = PicScrRev + PicScrPda + PicScrPda + PicScrEme;
                        }

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }


        /*----------master cost control---------------*/
        public List<vAutoComplete> vMaterial()
        {
            List<vAutoComplete> lst = new List<vAutoComplete>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "ShowMaterial");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lst.Add(new vAutoComplete
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            name = rdr["name"].ToString()
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public int CRUDCostControl(KPI kp, char ch)
        {
            int i;
            string spBegda = null;
            if (ch != 'D')
            {
                string tglA = "01";
                string blnA = kp.period.Substring(0, 2);
                string thnA = kp.period.Substring(3, 4);
                spBegda = thnA + "/" + blnA + "/" + tglA;
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                com.Parameters.AddWithValue("@DESC", kp.desc);
                com.Parameters.AddWithValue("@DATE1", spBegda);                
                com.Parameters.AddWithValue("@TYPE", kp.type);
                com.Parameters.AddWithValue("@CONST", kp.KPI1);
                com.Parameters.AddWithValue("@KPI2", kp.KPI2);
                com.Parameters.AddWithValue("@GRADE", kp.grade);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "InsCost");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "UpdCost");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "DelCost");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<KPI> viewCostControl(KPI kp, char ch)
        {
            int material;
            decimal konst, harga;
            string ket;
            List<KPI> lst = new List<KPI>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                if (ch=='A')
                    com.Parameters.AddWithValue("@Action", "ShowCost");
                else com.Parameters.AddWithValue("@Action", "ShowCostID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["mat_id"] == DBNull.Value)
                            material = 0;
                        else
                            material = Convert.ToInt32(rdr["mat_id"]);

                        if (rdr["constanta"] == DBNull.Value)
                            konst = 0;
                        else
                            konst = Convert.ToDecimal(rdr["constanta"]);

                        if (rdr["price"] == DBNull.Value)
                            harga = 0;
                        else
                            harga = Convert.ToDecimal(rdr["price"]);

                        if (rdr["desc"] == DBNull.Value)
                            ket = "";
                        else
                            ket = rdr["desc"].ToString();
                        lst.Add(new KPI
                        {
                            idkpi = Convert.ToInt32(rdr["id"]),                                                  
                            type = rdr["type"].ToString(),
                            name = rdr["name"].ToString(),
                            period = string.Format("{0:MM-yyyy }", rdr["period"]),
                            grade = material,
                            desc = ket,
                            KPI1 = konst,
                            KPI2 = harga

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        /*----------master inventory control---------------*/
     
        public List<KPIDept> viewInvControl(KPIDept kp, char ch)
        {
            decimal target;
            List<KPIDept> lst = new List<KPIDept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                if (ch == 'A')
                    com.Parameters.AddWithValue("@Action", "ShowInvCtrl");
                else com.Parameters.AddWithValue("@Action", "ShowInvCtrlID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        if (rdr["target"] == DBNull.Value)
                            target = 0;
                        else
                            target = Convert.ToDecimal(rdr["target"]);

                        lst.Add(new KPIDept
                        {
                            idkpi = Convert.ToInt32(rdr["id"]),
                            group = rdr["group"].ToString(),
                            desc = rdr["desc"].ToString(),
                            period = string.Format("{0:dd-MM-yyyy }", rdr["tgl"]),
                            target = target

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDInvControl(KPIDept kp, char ch)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                int i;
                SqlCommand com = new SqlCommand("Extranet_sp_mMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                com.Parameters.AddWithValue("@Ddate1", kp.period);
                com.Parameters.AddWithValue("@VC1", kp.group);
                com.Parameters.AddWithValue("@VC2", kp.desc);
                com.Parameters.AddWithValue("@NUM1", kp.target);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "AddInvCtrl");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "EditInvCtrl");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "DeleteInvCtrl");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<vAutoComplete> vTitleLink(string name)
        {
            List<vAutoComplete> lst = new List<vAutoComplete>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mTitleLink", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", name);
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lst.Add(new vAutoComplete
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            name = rdr["COL"].ToString()
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*----------master cost control machine---------------*/
        public List<KPIDept> viewCostControlmachine(KPIDept kp, char ch)
        {
            decimal standard;
            List<KPIDept> lst = new List<KPIDept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                if (ch == 'A')
                    com.Parameters.AddWithValue("@Action", "ShowCosCtrMac");
                else com.Parameters.AddWithValue("@Action", "ShowCosCtrMacID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        if (rdr["std"] == DBNull.Value)
                            standard = 0;
                        else
                            standard = Convert.ToDecimal(rdr["std"]);

                        lst.Add(new KPIDept
                        {
                            idkpi = Convert.ToInt32(rdr["id"]),
                            desc = rdr["desc"].ToString(),
                            period = string.Format("{0:dd-MM-yyyy }", rdr["tgl"]),
                            target = standard

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDCostControlMachine(KPIDept kp, char ch)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                int i;
                SqlCommand com = new SqlCommand("Extranet_sp_mMaster", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", kp.idkpi);
                com.Parameters.AddWithValue("@Ddate1", kp.period);
                com.Parameters.AddWithValue("@VC2", kp.desc);
                com.Parameters.AddWithValue("@NUM1", kp.target);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "AddCosCtrMac");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "EditCosCtrMac");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "DeleteCosCtrMac");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        /*---------- Save Report Produksi OP&Lean ------------------*/
        public int ShowProdOPlean(RptKPI rpt, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_Rpt_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", rpt.id);
                com.Parameters.AddWithValue("@MONTH", rpt.Bulan);
                com.Parameters.AddWithValue("@YEAR", rpt.Tahun);
                com.Parameters.AddWithValue("@TITLE", rpt.Title);
                com.Parameters.AddWithValue("@VAL", rpt.Nilai);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "AvgProdIns");
                else if (ch == 'S')
                    com.Parameters.AddWithValue("@Action", "AvgProdShw");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<RptKPI> vShowProdOPlean(RptKPI rpt, char ch)
        {
            decimal nilVal;
            List<RptKPI> lst = new List<RptKPI>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_Rpt_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MONTH", rpt.Bulan);
                com.Parameters.AddWithValue("@YEAR", rpt.Tahun);
                    com.Parameters.AddWithValue("@Action", "ProdShwNow");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        if (rdr["AVGVAL"] == DBNull.Value)
                            nilVal = 0;
                        else nilVal = Convert.ToDecimal(rdr["AVGVAL"]);

                        lst.Add(new RptKPI
                        {
                            Nilai = nilVal
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<RptKPI> vShowProdOPleanMM(RptKPI rpt, char ch)
        {
            decimal nilVal;
            List<RptKPI> lst = new List<RptKPI>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_Rpt_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MONTH", rpt.Bulan);
                com.Parameters.AddWithValue("@YEAR", rpt.Tahun);
                com.Parameters.AddWithValue("@Action", "ProdShwMonth");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        if (rdr["AVGVAL"] == DBNull.Value)
                            nilVal = 0;
                        else nilVal = Convert.ToDecimal(rdr["AVGVAL"]);

                        lst.Add(new RptKPI
                        {
                            Nilai = nilVal
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<RptKPI> vShowProdOPleanYY(RptKPI rpt, char ch)
        {
            decimal nilVal;
            List<RptKPI> lst = new List<RptKPI>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_Rpt_mKPI", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@MONTH", rpt.Bulan);
                com.Parameters.AddWithValue("@YEAR", rpt.Tahun);
                com.Parameters.AddWithValue("@Action", "ProdShwYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        if (rdr["AVGVAL"] == DBNull.Value)
                            nilVal = 0;
                        else nilVal = Convert.ToDecimal(rdr["AVGVAL"]);

                        lst.Add(new RptKPI
                        {
                            Nilai = nilVal
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*-------------- QUALITY ------------------------*/
        public List<corpdept> vQualityDept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicOthAct, PicOthGrd, PicOthTrg, PicAchOth, PicAchOthTmp, PicScrOth;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicDppGrd, PicDppTrg, PicDppAct, PicAchDpp, PicAchDppTmp, PicScrDpp;
            decimal PicSafGrd, PicSafTrg, PicSafAct, PicAchSaf, PicAchSafTmp, PicScrSaf, PicTvbGrd, PicTvbTrg, PicTvbAct, PicAchTvb, PicAchTvbTmp, PicScrTvb;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchEme, PicAchEmeTmp, PicScrEme, PicRjtGrd, PicRjtTrg, PicRjtAct, PicAchRjtTmp, PicScrRjt, PicAirGrd, PicAirTrg, PicAirAct,  PicAchAirTmp, PicScrAir;
            decimal PicScaGrd, PicScaTrg, PicScaAct, PicAchSca, PicAchScaTmp, PicScrSca, PicInvGrd, PicInvTrg, PicInvAct, PicAchInv, PicAchInvTmp, PicScrInv, PicMusGrd, PicMusTrg, PicMusAct, PicAchMus, PicAchMusTmp, PicScrMus;
            double PicAchRjt, PicAchAir, dPicRjtAct, dPicAirAct;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V2", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Qua");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        /*---
                        if (PicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (PicAchRev > 103 && PicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (PicAchRev > 95 && PicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 90 && PicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 90)
                            PicAchRevTmp = 60;
                        --*/
                        if (PicAchRev >= 103)
                            PicAchRevTmp = 110;
                        else if (PicAchRev >= 97 && PicAchRev < 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 91 && PicAchRev < 97)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 91)
                            PicAchRevTmp = 60;

                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;

                        if (id<2020)
                        {
                            // pda
                            if (rdr["PicPdaGrd"] == DBNull.Value)
                                PicPdaGrd = 0;
                            else
                                PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                            if (rdr["PicPdaTrg"] == DBNull.Value)
                                PicPdaTrg = 0;
                            else
                                PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                            if (rdr["PicPdaAct"] == DBNull.Value)
                                PicPdaAct = 0;
                            else
                                PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                            if (PicPdaTrg > 0)
                                PicAchPda = PicPdaAct / PicPdaTrg * 100;
                            else
                                PicAchPda = 0;
                            PicAchPdaTmp = 0;
                            if (PicAchPda > 110)
                                PicAchPdaTmp = 120;
                            else if (PicAchPda > 102 && PicAchPda <= 110)
                                PicAchPdaTmp = 110;
                            else if (PicAchPda > 98 && PicAchPda <= 102)
                                PicAchPdaTmp = 100;
                            else if (PicAchPda >= 95 && PicAchPda <= 98)
                                PicAchPdaTmp = 90;
                            else if (PicAchPda < 95)
                                PicAchPdaTmp = 60;
                            PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                            // pdc
                            if (rdr["PicPdcGrd"] == DBNull.Value)
                                PicPdcGrd = 0;
                            else
                                PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                            if (rdr["PicPdcTrg"] == DBNull.Value)
                                PicPdcTrg = 0;
                            else
                                PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                            if (rdr["PicPdcAct"] == DBNull.Value)
                                PicPdcAct = 0;
                            else
                                PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                            if (PicPdcTrg > 0)
                                PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                            else
                                PicAchPdc = 0;
                            PicAchPdcTmp = 0;
                            if (PicAchPdc > 110)
                                PicAchPdcTmp = 120;
                            else if (PicAchPdc > 102 && PicAchPdc <= 110)
                                PicAchPdcTmp = 110;
                            else if (PicAchPdc > 95 && PicAchPdc <= 102)
                                PicAchPdcTmp = 100;
                            else if (PicAchPdc >= 90 && PicAchPdc <= 95)
                                PicAchPdcTmp = 90;
                            else if (PicAchPdc < 90)
                                PicAchPdcTmp = 60;
                            PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;
                        } else
                        {
                            PicPdaGrd = 0; PicPdaTrg = 0; PicPdaAct = 0; PicAchPda = 0; PicScrPda = 0;
                            PicPdcGrd = 0; PicPdcTrg = 0; PicPdcAct = 0; PicAchPdc = 0; PicScrPdc = 0;
                        }

                        // Reject Casting 
                        if (rdr["PicRjtGrd"] == DBNull.Value)
                            PicRjtGrd = 0;
                        else
                            PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]) / 12, 2);

                        if (rdr["PicRjtTrg"] == DBNull.Value)
                            PicRjtTrg = 0;
                        else
                            PicRjtTrg = Convert.ToDecimal(rdr["PicRjtTrg"]);

                        if (rdr["PicRjtAct"] == DBNull.Value)
                            PicRjtAct = 0;
                        else
                            PicRjtAct = Convert.ToDecimal(rdr["PicRjtAct"]);

                        if (PicRjtTrg > 0)
                            PicAchRjt = Convert.ToDouble((1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100);
                        else
                            PicAchRjt = 0;
                        if (PicAchRjt < 0)
                            PicAchRjt = 0;
                        PicAchRjtTmp = 0;
                        dPicRjtAct = Convert.ToDouble(PicRjtAct);
                        /*--
                        if (dPicRjtAct < 4)
                            PicAchRjtTmp = 120;
                        else if (dPicRjtAct >= 4 && dPicRjtAct <= 4.8)
                            PicAchRjtTmp = 110;
                        else if (dPicRjtAct > 4.8 && dPicRjtAct <= 5)
                            PicAchRjtTmp = 100;
                        else if (dPicRjtAct > 5 && dPicRjtAct <= 5.8)
                            PicAchRjtTmp = 90;
                        else if (dPicRjtAct > 5.8)
                            PicAchRjtTmp = 60;
                        --*/
                        if (dPicRjtAct <= 4.5)
                            PicAchRjtTmp = 110;
                        else if (dPicRjtAct > 4.5 && dPicRjtAct <= 5)
                            PicAchRjtTmp = 100;
                        else if (dPicRjtAct > 5 && dPicRjtAct <= 6)
                            PicAchRjtTmp = 90;
                        else if (dPicRjtAct > 6)
                            PicAchRjtTmp = 60;
                        PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;

                        // Reject machining 
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) / 12, 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0)
                            PicAchAir = Convert.ToDouble((1 + ((PicAirTrg - PicAirAct) / PicAirTrg)) * 100);
                        else
                            PicAchAir = 0;
                        if (PicAchAir < 0)
                            PicAchAir = 0;
                        PicAchAirTmp = 0;
                        dPicAirAct = Convert.ToDouble(PicAirAct);
                        /*----
                        if (dPicAirAct < 0.6)
                            PicAchAirTmp = 120;
                        else if (dPicAirAct >= 0.6 && dPicAirAct < 0.8)
                            PicAchAirTmp = 110;
                        else if (dPicAirAct >= 0.8 && dPicAirAct <= 1)
                            PicAchAirTmp = 100;
                        else if (dPicAirAct > 1 && dPicAirAct <= 1.2)
                            PicAchAirTmp = 90;
                        else if (dPicAirAct > 1.2)
                            PicAchAirTmp = 60;
                        --*/
                        if (dPicAirAct <= 0.8)
                            PicAchAirTmp = 110;
                        else if (dPicAirAct > 0.8 && dPicAirAct <= 1)
                            PicAchAirTmp = 100;
                        else if (dPicAirAct > 1 && dPicAirAct <= 1.2)
                            PicAchAirTmp = 90;
                        else if (dPicAirAct > 1.2)
                            PicAchAirTmp = 60;
                        PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        // Reject TVB 
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) / 12, 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (PicTvbTrg > 0)
                            PicAchTvb = (1 + ((PicTvbTrg - PicTvbAct) / PicTvbTrg)) * 100;
                        else
                            PicAchTvb = 0;
                        if (PicAchTvb < 0)
                            PicAchTvb = 0;
                        PicAchTvbTmp = 0;
                        /*--
                        if (PicTvbAct < 10000)
                            PicAchTvbTmp = 110;
                        else if (PicTvbAct >= 10000 && PicTvbAct <= 25000)
                            PicAchTvbTmp = 100;
                        else if (PicTvbAct > 25000 && PicTvbAct <= 30000)
                            PicAchTvbTmp = 90;
                        else if (PicTvbAct > 30000)
                            PicAchTvbTmp = 60;
                          --*/
                        if (PicTvbAct < 22000)
                            PicAchTvbTmp = 110;
                        else if (PicTvbAct >= 22000 && PicTvbAct <= 25000)
                            PicAchTvbTmp = 100;
                        else if (PicTvbAct > 25000 && PicTvbAct <= 27000)
                            PicAchTvbTmp = 90;
                        else if (PicTvbAct > 27000)
                            PicAchTvbTmp = 60;
                        PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;

                        // Reject DP Pump 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;
                        if (PicAchDpp < 0)
                            PicAchDpp = 0;
                        PicAchDppTmp = 0;
                        /*--
                        if (PicDppAct < 1000)
                            PicAchDppTmp = 110;
                        else if (PicDppAct >= 1000 && PicDppAct <= 2000)
                            PicAchDppTmp = 100;
                        else if (PicDppAct > 2000 && PicDppAct <= 3000)
                            PicAchDppTmp = 90;
                        else if (PicDppAct > 3000)
                            PicAchDppTmp = 60;
                         ---*/
                        if (PicDppAct < 1800)
                            PicAchDppTmp = 110;
                        else if (PicDppAct >= 1800 && PicDppAct <= 2000)
                            PicAchDppTmp = 100;
                        else if (PicDppAct > 2000 && PicDppAct <= 2200)
                            PicAchDppTmp = 90;
                        else if (PicDppAct > 2200)
                            PicAchDppTmp = 60;

                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;


                        // Emerson 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg > 0)
                            PicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                        else
                            PicAchEme = 0;
                        if (PicAchEme < 0)
                            PicAchEme = 0;
                        PicAchEmeTmp = 0;
                        /*---
                        if (PicEmeAct < 1000)
                            PicAchEmeTmp = 110;
                        else if (PicEmeAct >= 1000 && PicEmeAct <= 2000)
                            PicAchEmeTmp = 100;
                        else if (PicEmeAct > 2000 && PicEmeAct <= 3000)
                            PicAchEmeTmp = 90;
                        else if (PicEmeAct > 3000)
                            PicAchEmeTmp = 60;
                        --*/
                        if (PicEmeAct < 1800)
                            PicAchEmeTmp = 110;
                        else if (PicEmeAct >= 1800 && PicEmeAct <= 2000)
                            PicAchEmeTmp = 100;
                        else if (PicEmeAct > 2000 && PicEmeAct <= 2200)
                            PicAchEmeTmp = 90;
                        else if (PicEmeAct > 2200)
                            PicAchEmeTmp = 60;
                        PicScrEme = PicEmeGrd * PicAchEmeTmp / 100;

                        // Others
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) / 12, 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);
                        if (rdr["PicOthAct"] == DBNull.Value)
                            PicOthAct = 0;
                        else
                            PicOthAct = Convert.ToDecimal(rdr["PicOthAct"]);

                        if (PicOthTrg > 0)
                            PicAchOth = (1 + ((PicOthTrg - PicOthAct) / PicOthTrg)) * 100;
                        else
                            PicAchOth = 0;
                        if (PicAchOth < 0)
                            PicAchOth = 0;
                        PicAchOthTmp = 0;
                        /*---
                        if (PicOthAct < 1000)
                            PicAchOthTmp = 110;
                        else if (PicOthAct >= 1000 && PicOthAct <= 2000)
                            PicAchOthTmp = 100;
                        else if (PicOthAct > 2000 && PicOthAct <= 3000)
                            PicAchOthTmp = 90;
                        else if (PicOthAct > 3000)
                            PicAchOthTmp = 60;
                        --*/
                        if (PicOthAct < 1800)
                            PicAchOthTmp = 110;
                        else if (PicOthAct >= 1800 && PicOthAct <= 2000)
                            PicAchOthTmp = 100;
                        else if (PicOthAct > 2000 && PicOthAct <= 2200)
                            PicAchOthTmp = 90;
                        else if (PicOthAct > 2200)
                            PicAchOthTmp = 60;

                        PicScrOth = PicOthGrd * PicAchOthTmp / 100;

                        // Customer Complain CN
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicScaGrd = 0;
                        else
                            PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) / 12, 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicScaTrg = 0;
                        else
                            PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicScaAct = 0;
                        else
                            PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        if (PicScaTrg > 0)
                            PicAchSca = PicScaAct / PicScaTrg * 100;
                        else
                            PicAchSca = 0;
                        if (PicAchSca < 0)
                            PicAchSca = 0;
                        PicAchScaTmp = 0;
                        /*--
                        if (PicAchSca < 40)
                            PicAchScaTmp = 120;
                        else if (PicAchSca >= 40 && PicAchSca <= 60)
                            PicAchScaTmp = 110;
                        else if (PicAchSca > 60 && PicAchSca <= 100)
                            PicAchScaTmp = 100;
                        else if (PicAchSca > 100 && PicAchSca <= 120)
                            PicAchScaTmp = 90;
                        else if (PicAchSca > 120)
                            PicAchScaTmp = 60;
                        --*/
                        if (PicAchSca < 95)
                            PicAchScaTmp = 110;
                        else if (PicAchSca >= 95 && PicAchSca <= 99)
                            PicAchScaTmp = 100;
                        else if (PicAchSca > 99 && PicAchSca <= 102)
                            PicAchScaTmp = 90;
                        else if (PicAchSca > 120)
                            PicAchScaTmp = 60;
                        PicScrSca = PicScaGrd * PicAchScaTmp / 100;

                        if (id<2020)
                        {
                            // PED
                            if (rdr["PicInvGrd"] == DBNull.Value)
                                PicInvGrd = 0;
                            else
                                PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]) / 12, 2);

                            if (rdr["PicInvTrg"] == DBNull.Value)
                                PicInvTrg = 0;
                            else
                                PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                            if (rdr["PicInvAct"] == DBNull.Value)
                                PicInvAct = 0;
                            else
                                PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                            if (PicInvTrg > 0)
                                PicAchInv = PicInvAct / PicInvTrg * 100;
                            else
                                PicAchInv = 0;
                            if (PicAchInv < 0)
                                PicAchInv = 0;
                            PicAchInvTmp = 0;
                            if (PicAchInv < 80)
                                PicAchInvTmp = 60;
                            else if (PicAchInv >= 80 && PicAchInv <= 95)
                                PicAchInvTmp = 90;
                            else if (PicAchInv > 95 && PicAchInv <= 100)
                                PicAchInvTmp = 100;
                            PicScrInv = PicInvGrd * PicAchInvTmp / 100;


                            // ISO-13485
                            if (rdr["PicMusGrd"] == DBNull.Value)
                                PicMusGrd = 0;
                            else
                                PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]) / 12, 2);

                            if (rdr["PicMusTrg"] == DBNull.Value)
                                PicMusTrg = 0;
                            else
                                PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                            if (rdr["PicMusAct"] == DBNull.Value)
                                PicMusAct = 0;
                            else
                                PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);

                            if (PicMusTrg > 0)
                                PicAchMus = PicMusAct / PicMusTrg * 100;
                            else
                                PicAchMus = 0;
                            if (PicAchMus < 0)
                                PicAchMus = 0;
                            PicAchMusTmp = 0;
                            if (PicAchMus < 80)
                                PicAchMusTmp = 60;
                            else if (PicAchMus >= 80 && PicAchMus <= 95)
                                PicAchMusTmp = 90;
                            else if (PicAchMus > 95 && PicAchMus <= 100)
                                PicAchMusTmp = 100;
                            PicScrMus = PicMusGrd * PicAchMusTmp / 100;
                        } else
                        {
                            PicInvGrd = 0; PicInvTrg = 0; PicInvAct = 0; PicAchInv = 0; PicScrInv = 0;
                            PicMusGrd = 0; PicMusTrg = 0; PicMusAct = 0; PicAchMus = 0; PicScrMus = 0;

                        }

                        // Labor cost
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]) / 12, 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        if (rdr["PicSafAct"] == DBNull.Value)
                            PicSafAct = 0;
                        else
                            PicSafAct = Convert.ToDecimal(rdr["PicSafAct"]);

                        if (PicSafTrg > 0)
                            PicAchSaf = (1 + ((PicSafTrg - PicSafAct) / PicSafTrg)) * 100;
                        else
                            PicAchSaf = 0;

                        if (PicAchSaf < 0)
                            PicAchSaf = 0;
                        PicAchSafTmp = 0;
                        /*---
                        if (PicAchSaf > 0)
                        {
                            if (PicSafAct == 0)
                                PicScrSaf = PicSafGrd;
                            else
                                PicScrSaf = PicSafGrd - (PicSafGrd - ((PicSafTrg / PicSafAct) * PicSafGrd));
                        }
                        else
                        {
                            PicAchSaf = 0;
                            PicScrSaf = 0;
                        }
                        --*/
                        if (PicAchSaf < 95)
                            PicAchSafTmp = 60;
                        else if (PicAchSaf >= 95 && PicAchSaf <= 99)
                            PicAchSafTmp = 90;
                        else if (PicAchSaf > 99 && PicAchSaf <= 102)
                            PicAchSafTmp = 100;
                        else if (PicAchSaf > 102)
                            PicAchSafTmp = 110;
                        PicScrSaf = PicSafGrd * PicAchSafTmp / 100;
                      

                        NilaiGlobal.TempGradeLab = PicSafGrd;
                        NilaiGlobal.TempTargetLab = PicSafTrg;


                        //---TotalGrade---
                        NilaiGlobal.TotGrade = PicRevGrd + PicPdaGrd + PicPdcGrd + PicRjtGrd + PicAirGrd + PicTvbGrd + PicDppGrd + PicEmeGrd +  PicOthGrd + PicScaGrd + PicInvGrd + PicMusGrd + PicSafGrd;
                        NilaiGlobal.TotScore = PicScrRev + PicScrPda + PicScrPdc + PicScrRjt + PicScrAir + PicScrTvb + PicScrDpp + PicScrEme + PicScrOth + PicScrSca + PicScrInv + PicScrMus + PicScrSaf;

                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = PicRjtTrg,
                            PicActRjt = PicRjtAct,
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = Convert.ToDecimal(PicAchAir),
                            PicScrAir = PicScrAir,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = Convert.ToDecimal(PicAchTvb),
                            PicScrTvb = PicScrTvb,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = Convert.ToDecimal(PicAchDpp),
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,
                            PicActOth = PicOthAct,
                            PicAchOth = PicAchOth,
                            PicScrOth = PicScrOth,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicAchMus = PicAchMus,
                            PicScrMus = PicScrMus,

                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg,
                            PicActSaf = PicSafAct,
                            PicAchSaf = PicAchSaf,
                            PicScrSaf = PicScrSaf,

                            TotGrade = NilaiGlobal.TotGrade,
                            TotScore = NilaiGlobal.TotScore

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vQualityDeptSummary(int id, int bln, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicOthAct, PicOthGrd, PicOthTrg, PicAchOth, PicAchOthTmp, PicScrOth;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicDppGrd, PicDppTrg, PicDppAct, PicAchDpp, PicAchDppTmp, PicScrDpp;
            decimal PicSafGrd, PicSafTrg, PicSafAct, PicAchSaf, PicAchSafTmp, PicScrSaf, PicTvbGrd, PicTvbTrg, PicTvbAct, PicAchTvb, PicAchTvbTmp, PicScrTvb;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchEme, PicAchEmeTmp, PicScrEme, PicRjtGrd, PicRjtTrg, PicRjtAct, PicAchRjtTmp, PicScrRjt, PicAirGrd, PicAirTrg, PicAirAct, PicAchAirTmp, PicScrAir;
            decimal PicScaGrd, PicScaTrg, PicScaAct, PicAchSca, PicAchScaTmp, PicScrSca, PicInvGrd, PicInvTrg, PicInvAct, PicAchInv, PicAchInvTmp, PicScrInv, PicMusGrd, PicMusTrg, PicMusAct, PicAchMus, PicAchMusTmp, PicScrMus;
            double PicAchRjt, PicAchAir, dPicRjtAct, dPicAirAct;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V2", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M')
                    com.Parameters.AddWithValue("@Action", "QuaMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "QuaYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]), 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        if (PicAchRev >= 103)
                            PicAchRevTmp = 110;
                        else if (PicAchRev >= 97 && PicAchRev < 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 91 && PicAchRev < 97)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 91)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;

                        if (id<2020)
                        {
                            // pda
                            if (rdr["PicPdaGrd"] == DBNull.Value)
                                PicPdaGrd = 0;
                            else
                                PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                            if (rdr["PicPdaTrg"] == DBNull.Value)
                                PicPdaTrg = 0;
                            else
                                PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                            if (rdr["PicPdaAct"] == DBNull.Value)
                                PicPdaAct = 0;
                            else
                                PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                            if (PicPdaTrg > 0)
                                PicAchPda = PicPdaAct / PicPdaTrg * 100;
                            else
                                PicAchPda = 0;
                            PicAchPdaTmp = 0;
                            if (PicAchPda > 110)
                                PicAchPdaTmp = 120;
                            else if (PicAchPda > 102 && PicAchPda <= 110)
                                PicAchPdaTmp = 110;
                            else if (PicAchPda > 98 && PicAchPda <= 102)
                                PicAchPdaTmp = 100;
                            else if (PicAchPda >= 95 && PicAchPda <= 98)
                                PicAchPdaTmp = 90;
                            else if (PicAchPda < 95)
                                PicAchPdaTmp = 60;
                            PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                            // pdc
                            if (rdr["PicPdcGrd"] == DBNull.Value)
                                PicPdcGrd = 0;
                            else
                                PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                            if (rdr["PicPdcTrg"] == DBNull.Value)
                                PicPdcTrg = 0;
                            else
                                PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                            if (rdr["PicPdcAct"] == DBNull.Value)
                                PicPdcAct = 0;
                            else
                                PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                            if (PicPdcTrg > 0)
                                PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                            else
                                PicAchPdc = 0;
                            PicAchPdcTmp = 0;
                            if (PicAchPdc > 110)
                                PicAchPdcTmp = 120;
                            else if (PicAchPdc > 102 && PicAchPdc <= 110)
                                PicAchPdcTmp = 110;
                            else if (PicAchPdc > 95 && PicAchPdc <= 102)
                                PicAchPdcTmp = 100;
                            else if (PicAchPdc >= 90 && PicAchPdc <= 95)
                                PicAchPdcTmp = 90;
                            else if (PicAchPdc < 90)
                                PicAchPdcTmp = 60;
                            PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;
                        }
                        else
                        {
                            PicPdaGrd = 0; PicPdaTrg = 0; PicPdaAct = 0; PicAchPda = 0; PicScrPda = 0;
                            PicPdcGrd = 0; PicPdcTrg = 0; PicPdcAct = 0; PicAchPdc = 0; PicScrPdc = 0;
                        }
                        // Reject Casting 
                        if (rdr["PicRjtGrd"] == DBNull.Value)
                            PicRjtGrd = 0;
                        else
                            PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]), 2);

                        if (rdr["PicRjtTrg"] == DBNull.Value)
                            PicRjtTrg = 0;
                        else
                            PicRjtTrg = Convert.ToDecimal(rdr["PicRjtTrg"]);

                        if (rdr["PicRjtAct"] == DBNull.Value)
                            PicRjtAct = 0;
                        else
                            PicRjtAct = Convert.ToDecimal(rdr["PicRjtAct"]);

                        if (PicRjtTrg > 0)
                            PicAchRjt = Convert.ToDouble((1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100);
                        else
                            PicAchRjt = 0;
                        if (PicAchRjt < 0)
                            PicAchRjt = 0;
                        PicAchRjtTmp = 0;
                        dPicRjtAct = Convert.ToDouble(PicRjtAct);
                        if (dPicRjtAct <= 4.5)
                            PicAchRjtTmp = 110;
                        else if (dPicRjtAct > 4.5 && dPicRjtAct <= 5)
                            PicAchRjtTmp = 100;
                        else if (dPicRjtAct > 5 && dPicRjtAct <= 6)
                            PicAchRjtTmp = 90;
                        else if (dPicRjtAct > 6)
                            PicAchRjtTmp = 60;
                        PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;

                        // Reject machining 
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]), 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0)
                            PicAchAir = Convert.ToDouble((1 + ((PicAirTrg - PicAirAct) / PicAirTrg)) * 100);
                        else
                            PicAchAir = 0;
                        if (PicAchAir < 0)
                            PicAchAir = 0;
                        PicAchAirTmp = 0;
                        dPicAirAct = Convert.ToDouble(PicAirAct);
                        if (dPicAirAct <= 0.8)
                            PicAchAirTmp = 110;
                        else if (dPicAirAct > 0.8 && dPicAirAct <= 1)
                            PicAchAirTmp = 100;
                        else if (dPicAirAct > 1 && dPicAirAct <= 1.2)
                            PicAchAirTmp = 90;
                        else if (dPicAirAct > 1.2)
                            PicAchAirTmp = 60;
                        PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        // Reject TVB 
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]), 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (PicTvbTrg > 0)
                            PicAchTvb = (1 + ((PicTvbTrg - PicTvbAct) / PicTvbTrg)) * 100;
                        else
                            PicAchTvb = 0;
                        if (PicAchTvb < 0)
                            PicAchTvb = 0;
                        PicAchTvbTmp = 0;
                        if (PicTvbAct < 22000)
                            PicAchTvbTmp = 110;
                        else if (PicTvbAct >= 22000 && PicTvbAct <= 25000)
                            PicAchTvbTmp = 100;
                        else if (PicTvbAct > 25000 && PicTvbAct <= 27000)
                            PicAchTvbTmp = 90;
                        else if (PicTvbAct > 27000)
                            PicAchTvbTmp = 60;
                        PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;

                        // Reject DP Pump 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]), 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;
                        if (PicAchDpp < 0)
                            PicAchDpp = 0;
                        PicAchDppTmp = 0;
                        if (PicDppAct < 1800)
                            PicAchDppTmp = 110;
                        else if (PicDppAct >= 1800 && PicDppAct <= 2000)
                            PicAchDppTmp = 100;
                        else if (PicDppAct > 2000 && PicDppAct <= 2200)
                            PicAchDppTmp = 90;
                        else if (PicDppAct > 2200)
                            PicAchDppTmp = 60;
                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;


                        // Emerson 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]), 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (PicEmeTrg > 0)
                            PicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                        else
                            PicAchEme = 0;
                        if (PicAchEme < 0)
                            PicAchEme = 0;
                        PicAchEmeTmp = 0;
                        if (PicEmeAct < 1800)
                            PicAchEmeTmp = 110;
                        else if (PicEmeAct >= 1800 && PicEmeAct <= 2000)
                            PicAchEmeTmp = 100;
                        else if (PicEmeAct > 2000 && PicEmeAct <= 2200)
                            PicAchEmeTmp = 90;
                        else if (PicEmeAct > 2200)
                            PicAchEmeTmp = 60;
                        PicScrEme = PicEmeGrd * PicAchEmeTmp / 100;

                        // Others
                        if (rdr["PicOthGrd"] == DBNull.Value)
                            PicOthGrd = 0;
                        else
                            PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]), 2);

                        if (rdr["PicOthTrg"] == DBNull.Value)
                            PicOthTrg = 0;
                        else
                            PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);
                        if (rdr["PicOthAct"] == DBNull.Value)
                            PicOthAct = 0;
                        else
                            PicOthAct = Convert.ToDecimal(rdr["PicOthAct"]);

                        if (PicOthTrg > 0)
                            PicAchOth = (1 + ((PicOthTrg - PicOthAct) / PicOthTrg)) * 100;
                        else
                            PicAchOth = 0;
                        if (PicAchOth < 0)
                            PicAchOth = 0;
                        PicAchOthTmp = 0;
                        if (PicOthAct < 1800)
                            PicAchOthTmp = 110;
                        else if (PicOthAct >= 1800 && PicOthAct <= 2000)
                            PicAchOthTmp = 100;
                        else if (PicOthAct > 2000 && PicOthAct <= 2200)
                            PicAchOthTmp = 90;
                        else if (PicOthAct > 2200)
                            PicAchOthTmp = 60;
                        PicScrOth = PicOthGrd * PicAchOthTmp / 100;

                        // Customer Complain CN
                        if (rdr["PicScaGrd"] == DBNull.Value)
                            PicScaGrd = 0;
                        else
                            PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]), 2);

                        if (rdr["PicScaTrg"] == DBNull.Value)
                            PicScaTrg = 0;
                        else
                            PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                        if (rdr["PicScaAct"] == DBNull.Value)
                            PicScaAct = 0;
                        else
                            PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                        if (PicScaTrg > 0)
                            PicAchSca = PicScaAct / PicScaTrg * 100;
                        else
                            PicAchSca = 0;
                        if (PicAchSca < 0)
                            PicAchSca = 0;
                        PicAchScaTmp = 0;
                        if (PicAchSca < 95)
                            PicAchScaTmp = 110;
                        else if (PicAchSca >= 95 && PicAchSca <= 99)
                            PicAchScaTmp = 100;
                        else if (PicAchSca > 99 && PicAchSca <= 102)
                            PicAchScaTmp = 90;
                        else if (PicAchSca > 120)
                            PicAchScaTmp = 60;
                        PicScrSca = PicScaGrd * PicAchScaTmp / 100;

                        if (id<2020)
                        {
                            // PED
                            if (rdr["PicInvGrd"] == DBNull.Value)
                                PicInvGrd = 0;
                            else
                                PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]), 2);

                            if (rdr["PicInvTrg"] == DBNull.Value)
                                PicInvTrg = 0;
                            else
                                PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                            if (rdr["PicInvAct"] == DBNull.Value)
                                PicInvAct = 0;
                            else
                                PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                            if (PicInvTrg > 0)
                                PicAchInv = PicInvAct / PicInvTrg * 100;
                            else
                                PicAchInv = 0;
                            if (PicAchInv < 0)
                                PicAchInv = 0;
                            PicAchInvTmp = 0;
                            if (PicAchInv < 80)
                                PicAchInvTmp = 60;
                            else if (PicAchInv >= 80 && PicAchInv <= 95)
                                PicAchInvTmp = 90;
                            else if (PicAchInv > 95 && PicAchInv <= 100)
                                PicAchInvTmp = 100;
                            PicScrInv = PicInvGrd * PicAchInvTmp / 100;

                            // ISO-13485
                            if (rdr["PicMusGrd"] == DBNull.Value)
                                PicMusGrd = 0;
                            else
                                PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]), 2);

                            if (rdr["PicMusTrg"] == DBNull.Value)
                                PicMusTrg = 0;
                            else
                                PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                            if (rdr["PicMusAct"] == DBNull.Value)
                                PicMusAct = 0;
                            else
                                PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);

                            if (PicMusTrg > 0)
                                PicAchMus = PicMusAct / PicMusTrg * 100;
                            else
                                PicAchMus = 0;
                            if (PicAchMus < 0)
                                PicAchMus = 0;
                            PicAchMusTmp = 0;
                            if (PicAchMus < 80)
                                PicAchMusTmp = 60;
                            else if (PicAchMus >= 80 && PicAchMus <= 95)
                                PicAchMusTmp = 90;
                            else if (PicAchMus > 95 && PicAchMus <= 100)
                                PicAchMusTmp = 100;
                            PicScrMus = PicMusGrd * PicAchMusTmp / 100;
                        }
                        else
                        {
                            PicInvGrd = 0; PicInvTrg = 0; PicInvAct = 0; PicAchInv = 0; PicScrInv = 0;
                            PicMusGrd = 0; PicMusTrg = 0; PicMusAct = 0; PicAchMus = 0; PicScrMus = 0;

                        }

                        // Labor cost
                        if (rdr["PicSafGrd"] == DBNull.Value)
                            PicSafGrd = 0;
                        else
                            PicSafGrd = Math.Round(Convert.ToDecimal(rdr["PicSafGrd"]), 2);

                        if (rdr["PicSafTrg"] == DBNull.Value)
                            PicSafTrg = 0;
                        else
                            PicSafTrg = Convert.ToDecimal(rdr["PicSafTrg"]);

                        if (rdr["PicSafAct"] == DBNull.Value)
                            PicSafAct = 0;
                        else
                            PicSafAct = Convert.ToDecimal(rdr["PicSafAct"]);

                        if (PicSafTrg > 0)
                            PicAchSaf = (1 + ((PicSafTrg - PicSafAct) / PicSafTrg)) * 100;
                        else
                            PicAchSaf = 0;
                        /*--
                        if (PicAchSaf > 0)
                        {
                            if (PicSafAct == 0)
                                PicScrSaf = PicSafGrd;
                            else
                                PicScrSaf = PicSafGrd - (PicSafGrd - ((PicSafTrg / PicSafAct) * PicSafGrd));
                        }
                        else
                        {
                            PicAchSaf = 0;
                            PicScrSaf = 0;
                        }
                        --*/
                        if (PicAchSaf < 0)
                            PicAchSaf = 0;
                        PicAchSafTmp = 0;
                        if (PicAchSaf < 95)
                            PicAchSafTmp = 60;
                        else if (PicAchSaf >= 95 && PicAchSaf <= 99)
                            PicAchSafTmp = 90;
                        else if (PicAchSaf > 99 && PicAchSaf <= 102)
                            PicAchSafTmp = 100;
                        else if (PicAchSaf > 102)
                            PicAchSafTmp = 110;
                        PicScrSaf = PicSafGrd * PicAchSafTmp/100;



                        if (ch == 'M')
                        {
                            NilaiGlobal.TempGradeLabMonth = PicSafGrd;
                            NilaiGlobal.TempTargetLabMonth = PicSafTrg;
                            NilaiGlobal.TotGrade = PicRevGrd + PicPdaGrd + PicPdcGrd + PicRjtGrd + PicAirGrd + PicTvbGrd + PicDppGrd + PicEmeGrd + PicOthGrd + PicScaGrd + PicInvGrd + PicMusGrd + PicSafGrd;
                            NilaiGlobal.TotScore = PicScrRev + PicScrPda + PicScrPdc + PicScrRjt + PicScrAir + PicScrTvb + PicScrDpp + PicScrEme + PicScrOth + PicScrSca + PicScrInv + PicScrMus + PicScrSaf;
                        }
                        else
                        {
                            NilaiGlobal.TempGradeLabYear = PicSafGrd;
                            NilaiGlobal.TempTargetLabYear = PicSafTrg;
                            NilaiGlobal.TotGrade = PicRevGrd + PicPdaGrd + PicPdcGrd + PicRjtGrd + PicAirGrd + PicTvbGrd + PicDppGrd + PicEmeGrd + PicOthGrd + PicScaGrd + PicInvGrd + PicMusGrd + PicSafGrd;
                            NilaiGlobal.TotScore = PicScrRev + PicScrPda + PicScrPdc + PicScrRjt + PicScrAir + PicScrTvb + PicScrDpp + PicScrEme + PicScrOth + PicScrSca + PicScrInv + PicScrMus + PicScrSaf;
                        }


                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = PicRjtTrg,
                            PicActRjt = PicRjtAct,
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = Convert.ToDecimal(PicAchAir),
                            PicScrAir = PicScrAir,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = Convert.ToDecimal(PicAchTvb),
                            PicScrTvb = PicScrTvb,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = Convert.ToDecimal(PicAchDpp),
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,
                            PicActOth = PicOthAct,
                            PicAchOth = PicAchOth,
                            PicScrOth = PicScrOth,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicAchMus = PicAchMus,
                            PicScrMus = PicScrMus,

                            PicGrdSaf = PicSafGrd,
                            PicTgtSaf = PicSafTrg,
                            PicActSaf = PicSafAct,
                            PicAchSaf = PicAchSaf,
                            PicScrSaf = PicScrSaf,

                            TotGrade = NilaiGlobal.TotGrade,
                            TotScore = NilaiGlobal.TotScore
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        /*-------------- ENGINEERING ------------------------*/
        public List<corpdept> vEngineeringDept(int id, int bln)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicOthAct, PicOthGrd, PicOthTrg, PicAchOth, PicAchOthTmp, PicScrOth;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicDppGrd, PicDppTrg, PicDppAct, PicAchDpp,  PicScrDpp;
            decimal  PicTvbGrd, PicTvbTrg, PicTvbAct, PicAchTvb, PicAchTvbTmp, PicScrTvb;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchEme,  PicScrEme, PicRjtGrd, PicRjtTrg, PicRjtAct, PicAchRjtTmp, PicScrRjt, PicAirGrd, PicAirTrg, PicAirAct, PicAchAirTmp, PicScrAir;
            decimal PicScaGrd, PicScaTrg, PicScaAct, PicAchSca, PicAchScaTmp, PicScrSca, PicInvGrd, PicInvTrg, PicInvAct, PicAchInv, PicAchInvTmp, PicScrInv, PicMusGrd, PicMusTrg, PicMusAct, PicAchMus, PicAchMusTmp, PicScrMus;
            double  PicAchRjt, PicAchAir, dPicRjtAct, dPicAirAct;
            decimal PicAchEmeTmp, PicAchDppTmp, PicEmeScr;
            string parCom;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (id < 2020)
                    parCom = "Extranet_sp_mKPI_Dept_V3";
                else
                    parCom = "Extranet_sp_mKPI_Dept_20";

                SqlCommand com = new SqlCommand(parCom, con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Eng");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) / 12, 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;
                        /*--
                        if (PicAchRev > 110)
                            PicAchRevTmp = 120;
                        else if (PicAchRev > 103 && PicAchRev <= 110)
                            PicAchRevTmp = 110;
                        else if (PicAchRev > 95 && PicAchRev <= 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 90 && PicAchRev <= 95)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 90)
                            PicAchRevTmp = 60;
                        --*/
                        if (PicAchRev >= 103)
                            PicAchRevTmp = 110;
                        else if (PicAchRev >= 97 && PicAchRev < 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 91 && PicAchRev < 97)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 91)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;


                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        /*--
                        if (PicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (PicAchPda > 102 && PicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda > 98 && PicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 95 && PicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 95)
                            PicAchPdaTmp = 60;
                        --*/
                        if (PicAchPda >= 103)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda >= 97 && PicAchPda < 103)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 91 && PicAchPda < 97)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 91)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;
                        


                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        /*--
                        if (PicAchPdc > 110)
                            PicAchPdcTmp = 120;
                        else if (PicAchPdc > 102 && PicAchPdc <= 110)
                            PicAchPdcTmp = 110;
                        else if (PicAchPdc > 95 && PicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc >= 90 && PicAchPdc <= 95)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc < 90)
                            PicAchPdcTmp = 60;
                        --*/
                        if (PicAchPdc >= 103)
                            PicAchPdcTmp = 110;
                        else if (PicAchPdc >= 97 && PicAchPdc < 103)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc >= 91 && PicAchPdc < 97)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc < 91)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;


                        if (id<2020)
                        {
                            // Reject Casting 
                            if (rdr["PicRjtGrd"] == DBNull.Value)
                                PicRjtGrd = 0;
                            else
                                PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]) / 12, 2);

                            if (rdr["PicRjtTrg"] == DBNull.Value)
                                PicRjtTrg = 0;
                            else
                                PicRjtTrg = Convert.ToDecimal(rdr["PicRjtTrg"]);

                            if (rdr["PicRjtAct"] == DBNull.Value)
                                PicRjtAct = 0;
                            else
                                PicRjtAct = Convert.ToDecimal(rdr["PicRjtAct"]);

                            if (PicRjtTrg > 0)
                                PicAchRjt = Convert.ToDouble((1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100);
                            else
                                PicAchRjt = 0;
                            if (PicAchRjt < 0)
                                PicAchRjt = 0;
                            PicAchRjtTmp = 0;
                            dPicRjtAct = Convert.ToDouble(PicRjtAct);
                            if (dPicRjtAct < 4)
                                PicAchRjtTmp = 120;
                            else if (dPicRjtAct >= 4 && dPicRjtAct <= 4.8)
                                PicAchRjtTmp = 110;
                            else if (dPicRjtAct > 4.8 && dPicRjtAct <= 5)
                                PicAchRjtTmp = 100;
                            else if (dPicRjtAct > 5 && dPicRjtAct <= 5.8)
                                PicAchRjtTmp = 90;
                            else if (dPicRjtAct > 5.8)
                                PicAchRjtTmp = 60;
                            PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;

                            // Reject machining 
                            if (rdr["PicAirGrd"] == DBNull.Value)
                                PicAirGrd = 0;
                            else
                                PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) / 12, 2);

                            if (rdr["PicAirTrg"] == DBNull.Value)
                                PicAirTrg = 0;
                            else
                                PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                            if (rdr["PicAirAct"] == DBNull.Value)
                                PicAirAct = 0;
                            else
                                PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                            if (PicAirTrg > 0)
                                PicAchAir = Convert.ToDouble((1 + ((PicAirTrg - PicAirAct) / PicAirTrg)) * 100);
                            else
                                PicAchAir = 0;
                            if (PicAchAir < 0)
                                PicAchAir = 0;
                            PicAchAirTmp = 0;
                            dPicAirAct = Convert.ToDouble(PicAirAct);
                            if (dPicAirAct < 0.6)
                                PicAchAirTmp = 120;
                            else if (dPicAirAct >= 0.6 && dPicAirAct < 0.8)
                                PicAchAirTmp = 110;
                            else if (dPicAirAct >= 0.8 && dPicAirAct <= 1)
                                PicAchAirTmp = 100;
                            else if (dPicAirAct > 1 && dPicAirAct <= 1.2)
                                PicAchAirTmp = 90;
                            else if (dPicAirAct > 1.2)
                                PicAchAirTmp = 60;
                            PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        }
                        else
                        {
                            PicRjtGrd = 0; PicRjtTrg = 0; PicRjtAct = 0; PicAchRjt = 0; PicScrRjt = 0;
                            PicAirGrd = 0; PicAirTrg = 0; PicAirAct = 0; PicAchAir = 0; PicScrAir = 0;
                        }

                        // yield 
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) / 12, 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (PicTvbTrg > 0)
                            PicAchTvb =  PicTvbAct / PicTvbTrg * 100;
                        else
                            PicAchTvb = 0;
                        if (PicAchTvb < 0)
                            PicAchTvb = 0;
                        PicAchTvbTmp = 0;
                        /*--
                        if (PicTvbAct < 39)
                            PicAchTvbTmp = 60;
                        else if (PicTvbAct >= 39 && PicTvbAct <= 40)
                            PicAchTvbTmp = 90;
                        else if (PicTvbAct > 40 && PicTvbAct <= 45)
                            PicAchTvbTmp = 100;
                        else if (PicTvbAct > 45 && PicTvbAct <= 48)
                            PicAchTvbTmp = 110;
                        else if (PicTvbAct > 48)
                            PicAchTvbTmp = 120;
                        --*/
                        if (PicTvbAct < 37)
                            PicAchTvbTmp = 60;
                        else if (PicTvbAct >= 37 && PicTvbAct < 39)
                            PicAchTvbTmp = 90;
                        else if (PicTvbAct >= 39  && PicTvbAct < 41)
                            PicAchTvbTmp = 100;
                        else if (PicTvbAct >= 41)
                            PicAchTvbTmp = 110;
                        PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;

                        // new product Submission 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        //if (rdr["PicDppScr"] == DBNull.Value)
                        //    PicDppScr = 0;
                        //else
                        //    PicDppScr = Convert.ToDecimal(rdr["PicDppScr"]);
                        

                        if (PicDppTrg > 0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;
                        if (PicAchDpp < 0)
                            PicAchDpp = 0;
                        PicAchDppTmp = 0;
                        if (PicDppAct > 15)
                            PicAchDppTmp = 60;
                        else if (PicDppAct >= 8 && PicDppAct <= 15)
                            PicAchDppTmp = 90;
                        else if (PicDppAct >= 1 && PicDppAct < 8)
                            PicAchDppTmp = 100;
                        else if (PicDppAct < 1)
                            PicAchDppTmp = 110;
                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;
                        
                        // sample approval success rate 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) / 12, 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (rdr["PicEmeScr"] == DBNull.Value)
                            PicEmeScr = 0;
                        else
                            PicEmeScr = Convert.ToDecimal(rdr["PicEmeScr"]);

                        if (PicEmeTrg > 0)
                            PicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                        else
                            PicAchEme = 0;
                        if (PicAchEme < 0)
                            PicAchEme = 0;
                        PicAchEmeTmp = 0;
                        //if (PicAchEme > 2)
                        //    PicAchEmeTmp = 60;
                        //else if (PicAchEme == 2)
                        //    PicAchEmeTmp = 90;
                        //else if (PicAchEme == 1)
                        //    PicAchEmeTmp = 110;
                        PicScrEme = PicEmeGrd * PicEmeScr / 100;

                        if (id<2020)
                        {
                            // ZENGATE
                            if (rdr["PicOthGrd"] == DBNull.Value)
                                PicOthGrd = 0;
                            else
                                PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]) / 12, 2);

                            if (rdr["PicOthTrg"] == DBNull.Value)
                                PicOthTrg = 0;
                            else
                                PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);
                            if (rdr["PicOthAct"] == DBNull.Value)
                                PicOthAct = 0;
                            else
                                PicOthAct = Convert.ToDecimal(rdr["PicOthAct"]);

                            if (PicOthTrg > 0)
                                PicAchOth = PicOthAct / PicOthTrg * 100;
                            else
                                PicAchOth = 0;
                            if (PicAchOth < 0)
                                PicAchOth = 0;
                            PicAchOthTmp = 0;
                            if (PicAchOth < 80)
                                PicAchOthTmp = 60;
                            else if (PicAchOth >= 80 && PicAchOth <= 95)
                                PicAchOthTmp = 90;
                            else if (PicAchOth > 95)
                                PicAchOthTmp = 100;
                            PicScrOth = PicOthGrd * PicAchOthTmp / 100;

                        }
                        else
                        {
                            if (id > 2021)
                            {
                                PicOthGrd = 0; PicOthTrg = 0; PicOthAct = 0; PicAchOth = 0; PicScrOth = 0;
                            } else
                            {
                                // new product innovation
                                if (rdr["PicNPIGrd"] == DBNull.Value)
                                    PicOthGrd = 0;
                                else
                                    PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicNPIGrd"]) / 12, 2);

                                if (rdr["PicNPITrg"] == DBNull.Value)
                                    PicOthTrg = 0;
                                else
                                    PicOthTrg = Convert.ToDecimal(rdr["PicNPITrg"]);
                                if (rdr["PicNPIAct"] == DBNull.Value)
                                    PicOthAct = 0;
                                else
                                    PicOthAct = Convert.ToDecimal(rdr["PicNPIAct"]);

                                if (PicOthTrg > 0)
                                    PicAchOth = PicOthAct / PicOthTrg * 100;
                                else
                                    PicAchOth = 0;
                                if (PicAchOth < 0)
                                    PicAchOth = 0;
                                PicAchOthTmp = 0;
                                if (PicOthAct == 0)
                                    PicAchOthTmp = 60;
                                else if (PicAchOth == 1)
                                    PicAchOthTmp = 100;
                                else if (PicAchOth == 2)
                                    PicAchOthTmp = 110;
                                PicScrOth = PicOthGrd * PicAchOthTmp / 100;

                            }

                        }


                        if (id<2020)
                        {
                            // ZENPUMP
                            if (rdr["PicScaGrd"] == DBNull.Value)
                                PicScaGrd = 0;
                            else
                                PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]) / 12, 2);

                            if (rdr["PicScaTrg"] == DBNull.Value)
                                PicScaTrg = 0;
                            else
                                PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                            if (rdr["PicScaAct"] == DBNull.Value)
                                PicScaAct = 0;
                            else
                                PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                            if (PicScaTrg > 0)
                                PicAchSca = PicScaAct / PicScaTrg * 100;
                            else
                                PicAchSca = 0;
                            if (PicAchSca < 0)
                                PicAchSca = 0;
                            PicAchScaTmp = 0;
                            if (PicAchSca < 80)
                                PicAchScaTmp = 60;
                            else if (PicAchSca >= 80 && PicAchSca <= 95)
                                PicAchScaTmp = 90;
                            else if (PicAchSca > 95)
                                PicAchScaTmp = 100;
                            PicScrSca = PicScaGrd * PicAchScaTmp / 100;

                            // ZENPUMP+ Loop
                            if (rdr["PicInvGrd"] == DBNull.Value)
                                PicInvGrd = 0;
                            else
                                PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]) / 12, 2);

                            if (rdr["PicInvTrg"] == DBNull.Value)
                                PicInvTrg = 0;
                            else
                                PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                            if (rdr["PicInvAct"] == DBNull.Value)
                                PicInvAct = 0;
                            else
                                PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                            if (PicInvTrg > 0)
                                PicAchInv = PicInvAct / PicInvTrg * 100;
                            else
                                PicAchInv = 0;
                            if (PicAchInv < 0)
                                PicAchInv = 0;
                            PicAchInvTmp = 0;
                            if (PicAchInv < 80)
                                PicAchInvTmp = 60;
                            else if (PicAchInv >= 80 && PicAchInv <= 95)
                                PicAchInvTmp = 90;
                            else if (PicAchInv > 95)
                                PicAchInvTmp = 100;
                            PicScrInv = PicInvGrd * PicAchInvTmp / 100;


                            // ZENGATE+ 100MM W/Actuator
                            if (rdr["PicMusGrd"] == DBNull.Value)
                                PicMusGrd = 0;
                            else
                                PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]) / 12, 2);

                            if (rdr["PicMusTrg"] == DBNull.Value)
                                PicMusTrg = 0;
                            else
                                PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                            if (rdr["PicMusAct"] == DBNull.Value)
                                PicMusAct = 0;
                            else
                                PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);

                            if (PicMusTrg > 0)
                                PicAchMus = PicMusAct / PicMusTrg * 100;
                            else
                                PicAchMus = 0;
                            if (PicAchMus < 0)
                                PicAchMus = 0;
                            PicAchMusTmp = 0;
                            if (PicAchMus < 80)
                                PicAchMusTmp = 60;
                            else if (PicAchMus >= 80 && PicAchMus <= 95)
                                PicAchMusTmp = 90;
                            else if (PicAchMus > 95)
                                PicAchMusTmp = 100;
                            PicScrMus = PicMusGrd * PicAchMusTmp / 100;
                        }
                        else
                        {
                            PicScaGrd = 0; PicScaTrg = 0; PicScaAct = 0; PicAchSca = 0; PicScrSca = 0;
                            PicInvGrd = 0; PicInvTrg = 0; PicInvAct = 0; PicAchInv = 0; PicScrInv = 0;
                            PicMusGrd = 0; PicMusTrg = 0; PicMusAct = 0; PicAchMus = 0; PicScrMus = 0;
                        }

                        //---TotalGrade + SCORE---
                        NilaiGlobal.TotGrade = PicRevGrd + PicPdaGrd + PicPdcGrd + PicRjtGrd + PicAirGrd + PicTvbGrd + PicDppGrd + PicEmeGrd + PicOthGrd + PicScaGrd + PicInvGrd + PicMusGrd ;
                        NilaiGlobal.TotScore = PicScrRev + PicScrPda + PicScrPdc + PicScrRjt + PicScrAir + PicScrTvb + PicScrDpp + PicScrEme + PicScrOth + PicScrSca + PicScrInv + PicScrMus;
                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = PicRjtTrg,
                            PicActRjt = PicRjtAct,
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = Convert.ToDecimal(PicAchAir),
                            PicScrAir = PicScrAir,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = Convert.ToDecimal(PicAchTvb),
                            PicScrTvb = PicScrTvb,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = Convert.ToDecimal(PicAchDpp),
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,
                            PicActOth = PicOthAct,
                            PicAchOth = PicAchOth,
                            PicScrOth = PicScrOth,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicAchMus = PicAchMus,
                            PicScrMus = PicScrMus,
                            TotGrade = NilaiGlobal.TotGrade,
                            TotScore = NilaiGlobal.TotScore


                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vEngineeringDeptSummary(int id, int bln, char ch)
        {
            decimal PicRevGrd, PicRevTrg, PicRevAct, PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct, PicOthAct, PicOthGrd, PicOthTrg, PicAchOth, PicAchOthTmp, PicScrOth;
            decimal PicEmeAct, PicEmeGrd, PicEmeTrg, PicDppGrd, PicDppTrg, PicDppAct, PicAchDpp, PicScrDpp;
            decimal PicTvbGrd, PicTvbTrg, PicTvbAct, PicAchTvb, PicAchTvbTmp, PicScrTvb;
            decimal PicAchRev, PicAchRevTmp, PicScrRev, PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicAchEme, PicScrEme, PicRjtGrd, PicRjtTrg, PicRjtAct, PicAchRjtTmp, PicScrRjt, PicAirGrd, PicAirTrg, PicAirAct, PicAchAirTmp, PicScrAir;
            decimal PicScaGrd, PicScaTrg, PicScaAct, PicAchSca, PicAchScaTmp, PicScrSca, PicInvGrd, PicInvTrg, PicInvAct, PicAchInv, PicAchInvTmp, PicScrInv, PicMusGrd, PicMusTrg, PicMusAct, PicAchMus, PicAchMusTmp, PicScrMus;
            double PicAchRjt, PicAchAir, dPicRjtAct, dPicAirAct;
            decimal PicAchEmeTmp, PicAchDppTmp, PicEmeScr;
            string parCom;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (id < 2020)
                    parCom = "Extranet_sp_mKPI_Dept_V3";
                else
                    parCom = "Extranet_sp_mKPI_Dept_20";

                SqlCommand com = new SqlCommand(parCom, con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M')
                    com.Parameters.AddWithValue("@Action", "EngMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "EngYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //  revenue
                        if (rdr["PicRevGrd"] == DBNull.Value)
                            PicRevGrd = 0;
                        else
                            PicRevGrd = Math.Round(Convert.ToDecimal(rdr["PicRevGrd"]) , 2);

                        if (rdr["PicRevTrg"] == DBNull.Value)
                            PicRevTrg = 0;
                        else
                            PicRevTrg = Convert.ToDecimal(rdr["PicRevTrg"]);

                        if (rdr["PicRevAct"] == DBNull.Value)
                            PicRevAct = 0;
                        else
                            PicRevAct = Convert.ToDecimal(rdr["PicRevAct"]);

                        if (PicRevTrg > 0)
                            PicAchRev = PicRevAct / PicRevTrg * 100;
                        else
                            PicAchRev = 0;
                        PicAchRevTmp = 0;

                        if (PicAchRev >= 103)
                            PicAchRevTmp = 110;
                        else if (PicAchRev >= 97 && PicAchRev < 103)
                            PicAchRevTmp = 100;
                        else if (PicAchRev >= 91 && PicAchRev < 97)
                            PicAchRevTmp = 90;
                        else if (PicAchRev < 91)
                            PicAchRevTmp = 60;
                        PicScrRev = PicRevGrd * PicAchRevTmp / 100;

                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]), 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        if (PicAchPda >= 103)
                            PicAchPdaTmp = 110;
                        else if (PicAchPda >= 97 && PicAchPda < 103)
                            PicAchPdaTmp = 100;
                        else if (PicAchPda >= 91 && PicAchPda < 97)
                            PicAchPdaTmp = 90;
                        else if (PicAchPda < 91)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        if (PicAchPdc >= 103)
                            PicAchPdcTmp = 110;
                        else if (PicAchPdc >= 97 && PicAchPdc < 103)
                            PicAchPdcTmp = 100;
                        else if (PicAchPdc >= 91 && PicAchPdc < 97)
                            PicAchPdcTmp = 90;
                        else if (PicAchPdc < 91)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;

                        if (id < 2020)
                        {
                            // Reject Casting 
                            if (rdr["PicRjtGrd"] == DBNull.Value)
                                PicRjtGrd = 0;
                            else
                                PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]), 2);

                            if (rdr["PicRjtTrg"] == DBNull.Value)
                                PicRjtTrg = 0;
                            else
                                PicRjtTrg = Convert.ToDecimal(rdr["PicRjtTrg"]);

                            if (rdr["PicRjtAct"] == DBNull.Value)
                                PicRjtAct = 0;
                            else
                                PicRjtAct = Convert.ToDecimal(rdr["PicRjtAct"]);

                            if (PicRjtTrg > 0)
                                PicAchRjt = Convert.ToDouble((1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100);
                            else
                                PicAchRjt = 0;
                            if (PicAchRjt < 0)
                                PicAchRjt = 0;
                            PicAchRjtTmp = 0;
                            dPicRjtAct = Convert.ToDouble(PicRjtAct);
                            if (dPicRjtAct < 4)
                                PicAchRjtTmp = 120;
                            else if (dPicRjtAct >= 4 && dPicRjtAct <= 4.8)
                                PicAchRjtTmp = 110;
                            else if (dPicRjtAct > 4.8 && dPicRjtAct <= 5)
                                PicAchRjtTmp = 100;
                            else if (dPicRjtAct > 5 && dPicRjtAct <= 5.8)
                                PicAchRjtTmp = 90;
                            else if (dPicRjtAct > 5.8)
                                PicAchRjtTmp = 60;
                            PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;

                            // Reject machining 
                            if (rdr["PicAirGrd"] == DBNull.Value)
                                PicAirGrd = 0;
                            else
                                PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]), 2);

                            if (rdr["PicAirTrg"] == DBNull.Value)
                                PicAirTrg = 0;
                            else
                                PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                            if (rdr["PicAirAct"] == DBNull.Value)
                                PicAirAct = 0;
                            else
                                PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                            if (PicAirTrg > 0)
                                PicAchAir = Convert.ToDouble((1 + ((PicAirTrg - PicAirAct) / PicAirTrg)) * 100);
                            else
                                PicAchAir = 0;
                            if (PicAchAir < 0)
                                PicAchAir = 0;
                            PicAchAirTmp = 0;
                            dPicAirAct = Convert.ToDouble(PicAirAct);
                            if (dPicAirAct < 0.6)
                                PicAchAirTmp = 120;
                            else if (dPicAirAct >= 0.6 && dPicAirAct < 0.8)
                                PicAchAirTmp = 110;
                            else if (dPicAirAct >= 0.8 && dPicAirAct <= 1)
                                PicAchAirTmp = 100;
                            else if (dPicAirAct > 1 && dPicAirAct <= 1.2)
                                PicAchAirTmp = 90;
                            else if (dPicAirAct > 1.2)
                                PicAchAirTmp = 60;
                            PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        }
                        else
                        {
                            PicRjtGrd = 0; PicRjtTrg = 0; PicRjtAct = 0; PicAchRjt = 0; PicScrRjt = 0;
                            PicAirGrd = 0; PicAirTrg = 0; PicAirAct = 0; PicAchAir = 0; PicScrAir = 0;
                        }



                        // yield 
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]), 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (PicTvbTrg > 0)
                            PicAchTvb = PicTvbAct / PicTvbTrg * 100;
                        else
                            PicAchTvb = 0;
                        if (PicAchTvb < 0)
                            PicAchTvb = 0;
                        PicAchTvbTmp = 0;
                        if (PicTvbAct < 37)
                            PicAchTvbTmp = 60;
                        else if (PicTvbAct >= 37 && PicTvbAct < 39)
                            PicAchTvbTmp = 90;
                        else if (PicTvbAct >= 39 && PicTvbAct < 41)
                            PicAchTvbTmp = 100;
                        else if (PicTvbAct >= 41)
                            PicAchTvbTmp = 110;
                        PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;

                        // new product Submission 
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) , 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);



                        if (PicDppTrg > 0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;
                        if (PicAchDpp < 0)
                            PicAchDpp = 0;
                        PicAchDppTmp = 0;
                        if (PicDppAct > 15)
                            PicAchDppTmp = 60;
                        else if (PicDppAct >= 8 && PicDppAct <= 15)
                            PicAchDppTmp = 90;
                        else if (PicDppAct >= 1 && PicDppAct < 8)
                            PicAchDppTmp = 100;
                        else if (PicDppAct < 1)
                            PicAchDppTmp = 110;
                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;

                        // sample approval success rate 
                        if (rdr["PicEmeGrd"] == DBNull.Value)
                            PicEmeGrd = 0;
                        else
                            PicEmeGrd = Math.Round(Convert.ToDecimal(rdr["PicEmeGrd"]) , 2);

                        if (rdr["PicEmeTrg"] == DBNull.Value)
                            PicEmeTrg = 0;
                        else
                            PicEmeTrg = Convert.ToDecimal(rdr["PicEmeTrg"]);

                        if (rdr["PicEmeAct"] == DBNull.Value)
                            PicEmeAct = 0;
                        else
                            PicEmeAct = Convert.ToDecimal(rdr["PicEmeAct"]);

                        if (rdr["PicEmeScr"] == DBNull.Value)
                            PicEmeScr = 0;
                        else
                            PicEmeScr = Convert.ToDecimal(rdr["PicEmeScr"]);

                        if (PicEmeTrg > 0)
                            PicAchEme = (1 + ((PicEmeTrg - PicEmeAct) / PicEmeTrg)) * 100;
                        else
                            PicAchEme = 0;
                        if (PicAchEme < 0)
                            PicAchEme = 0;

                        PicAchEmeTmp = 0;
                        //if (PicAchEme > 2)
                        //    PicAchEmeTmp = 60;
                        //else if (PicAchEme == 2)
                        //    PicAchEmeTmp = 90;
                        //else if (PicAchEme == 1)
                        //    PicAchEmeTmp = 110;
                        PicScrEme = PicEmeGrd * PicEmeScr / 100;

                        if (id<2020)
                        {
                            // ZENGATE
                            if (rdr["PicOthGrd"] == DBNull.Value)
                                PicOthGrd = 0;
                            else
                                PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicOthGrd"]), 2);

                            if (rdr["PicOthTrg"] == DBNull.Value)
                                PicOthTrg = 0;
                            else
                                PicOthTrg = Convert.ToDecimal(rdr["PicOthTrg"]);
                            if (rdr["PicOthAct"] == DBNull.Value)
                                PicOthAct = 0;
                            else
                                PicOthAct = Convert.ToDecimal(rdr["PicOthAct"]);

                            if (PicOthTrg > 0)
                                PicAchOth = PicOthAct / PicOthTrg * 100;
                            else
                                PicAchOth = 0;
                            if (PicAchOth < 0)
                                PicAchOth = 0;
                            PicAchOthTmp = 0;
                            if (PicAchOth < 80)
                                PicAchOthTmp = 60;
                            else if (PicAchOth >= 80 && PicAchOth <= 95)
                                PicAchOthTmp = 90;
                            else if (PicAchOth > 95)
                                PicAchOthTmp = 100;
                            PicScrOth = PicOthGrd * PicAchOthTmp / 100;
                        }
                        else
                        {
                            // new product innovation
                            if (id > 2021)
                            {
                                PicOthGrd = 0; PicOthTrg = 0; PicOthAct = 0; PicAchOth = 0; PicScrOth = 0;
                            }
                            else
                            {
                                if (rdr["PicNPIGrd"] == DBNull.Value)
                                    PicOthGrd = 0;
                                else
                                    PicOthGrd = Math.Round(Convert.ToDecimal(rdr["PicNPIGrd"]), 2);

                                if (rdr["PicNPITrg"] == DBNull.Value)
                                    PicOthTrg = 0;
                                else
                                    PicOthTrg = Convert.ToDecimal(rdr["PicNPITrg"]);
                                if (rdr["PicNPIAct"] == DBNull.Value)
                                    PicOthAct = 0;
                                else
                                    PicOthAct = Convert.ToDecimal(rdr["PicNPIAct"]);

                                if (PicOthTrg > 0)
                                    PicAchOth = PicOthAct / PicOthTrg * 100;
                                else
                                    PicAchOth = 0;
                                if (PicAchOth < 0)
                                    PicAchOth = 0;
                                PicAchOthTmp = 0;
                                if (PicOthAct == 0)
                                    PicAchOthTmp = 60;
                                else if (PicAchOth == 1)
                                    PicAchOthTmp = 100;
                                else if (PicAchOth == 2)
                                    PicAchOthTmp = 110;
                                PicScrOth = PicOthGrd * PicAchOthTmp / 100;
                            }
                        }

                        if (id<2020)
                        {
                            // ZENPUMP
                            if (rdr["PicScaGrd"] == DBNull.Value)
                                PicScaGrd = 0;
                            else
                                PicScaGrd = Math.Round(Convert.ToDecimal(rdr["PicScaGrd"]), 2);

                            if (rdr["PicScaTrg"] == DBNull.Value)
                                PicScaTrg = 0;
                            else
                                PicScaTrg = Convert.ToDecimal(rdr["PicScaTrg"]);

                            if (rdr["PicScaAct"] == DBNull.Value)
                                PicScaAct = 0;
                            else
                                PicScaAct = Convert.ToDecimal(rdr["PicScaAct"]);

                            if (PicScaTrg > 0)
                                PicAchSca = PicScaAct / PicScaTrg * 100;
                            else
                                PicAchSca = 0;
                            if (PicAchSca < 0)
                                PicAchSca = 0;
                            PicAchScaTmp = 0;
                            if (PicAchSca < 80)
                                PicAchScaTmp = 60;
                            else if (PicAchSca >= 80 && PicAchSca <= 95)
                                PicAchScaTmp = 90;
                            else if (PicAchSca > 95)
                                PicAchScaTmp = 100;
                            PicScrSca = PicScaGrd * PicAchScaTmp / 100;

                            // ZENPUMP+ Loop
                            if (rdr["PicInvGrd"] == DBNull.Value)
                                PicInvGrd = 0;
                            else
                                PicInvGrd = Math.Round(Convert.ToDecimal(rdr["PicInvGrd"]), 2);

                            if (rdr["PicInvTrg"] == DBNull.Value)
                                PicInvTrg = 0;
                            else
                                PicInvTrg = Convert.ToDecimal(rdr["PicInvTrg"]);

                            if (rdr["PicInvAct"] == DBNull.Value)
                                PicInvAct = 0;
                            else
                                PicInvAct = Convert.ToDecimal(rdr["PicInvAct"]);

                            if (PicInvTrg > 0)
                                PicAchInv = PicInvAct / PicInvTrg * 100;
                            else
                                PicAchInv = 0;
                            if (PicAchInv < 0)
                                PicAchInv = 0;
                            PicAchInvTmp = 0;
                            if (PicAchInv < 80)
                                PicAchInvTmp = 60;
                            else if (PicAchInv >= 80 && PicAchInv <= 95)
                                PicAchInvTmp = 90;
                            else if (PicAchInv > 95)
                                PicAchInvTmp = 100;
                            PicScrInv = PicInvGrd * PicAchInvTmp / 100;


                            // ZENGATE+ 100MM W/Actuator
                            if (rdr["PicMusGrd"] == DBNull.Value)
                                PicMusGrd = 0;
                            else
                                PicMusGrd = Math.Round(Convert.ToDecimal(rdr["PicMusGrd"]), 2);

                            if (rdr["PicMusTrg"] == DBNull.Value)
                                PicMusTrg = 0;
                            else
                                PicMusTrg = Convert.ToDecimal(rdr["PicMusTrg"]);

                            if (rdr["PicMusAct"] == DBNull.Value)
                                PicMusAct = 0;
                            else
                                PicMusAct = Convert.ToDecimal(rdr["PicMusAct"]);

                            if (PicMusTrg > 0)
                                PicAchMus = PicMusAct / PicMusTrg * 100;
                            else
                                PicAchMus = 0;
                            if (PicAchMus < 0)
                                PicAchMus = 0;
                            PicAchMusTmp = 0;
                            if (PicAchMus < 80)
                                PicAchMusTmp = 60;
                            else if (PicAchMus >= 80 && PicAchMus <= 95)
                                PicAchMusTmp = 90;
                            else if (PicAchMus > 95)
                                PicAchMusTmp = 100;
                            PicScrMus = PicMusGrd * PicAchMusTmp / 100;

                        }
                        else
                        {
                            PicScaGrd = 0; PicScaTrg = 0; PicScaAct = 0; PicAchSca = 0; PicScrSca = 0;
                            PicInvGrd = 0; PicInvTrg = 0; PicInvAct = 0; PicAchInv = 0; PicScrInv = 0;
                            PicMusGrd = 0; PicMusTrg = 0; PicMusAct = 0; PicAchMus = 0; PicScrMus = 0;
                        }


                        //---TotalGrade + SCORE---
                        NilaiGlobal.TotGrade = PicRevGrd + PicPdaGrd + PicPdcGrd + PicRjtGrd + PicAirGrd + PicTvbGrd + PicDppGrd + PicEmeGrd + PicOthGrd + PicScaGrd + PicInvGrd + PicMusGrd;
                        NilaiGlobal.TotScore = PicScrRev + PicScrPda + PicScrPdc + PicScrRjt + PicScrAir + PicScrTvb + PicScrDpp + PicScrEme + PicScrOth + PicScrSca + PicScrInv + PicScrMus;
                        lst.Add(new corpdept
                        {
                            PicGrdRev = PicRevGrd,
                            PicTgtRev = PicRevTrg,
                            PicActRev = PicRevAct,
                            PicAchRev = PicAchRev,
                            PicScrRev = PicScrRev,

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = PicRjtTrg,
                            PicActRjt = PicRjtAct,
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = Convert.ToDecimal(PicAchAir),
                            PicScrAir = PicScrAir,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = Convert.ToDecimal(PicAchTvb),
                            PicScrTvb = PicScrTvb,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = Convert.ToDecimal(PicAchDpp),
                            PicScrDpp = PicScrDpp,

                            PicGrdEme = PicEmeGrd,
                            PicTgtEme = PicEmeTrg,
                            PicActEme = PicEmeAct,
                            PicAchEme = PicAchEme,
                            PicScrEme = PicScrEme,

                            PicGrdOth = PicOthGrd,
                            PicTgtOth = PicOthTrg,
                            PicActOth = PicOthAct,
                            PicAchOth = PicAchOth,
                            PicScrOth = PicScrOth,

                            PicGrdSca = PicScaGrd,
                            PicTgtSca = PicScaTrg,
                            PicActSca = PicScaAct,
                            PicAchSca = PicAchSca,
                            PicScrSca = PicScrSca,

                            PicGrdInv = PicInvGrd,
                            PicTgtInv = PicInvTrg,
                            PicActInv = PicInvAct,
                            PicAchInv = PicAchInv,
                            PicScrInv = PicScrInv,

                            PicGrdMus = PicMusGrd,
                            PicTgtMus = PicMusTrg,
                            PicActMus = PicMusAct,
                            PicAchMus = PicAchMus,
                            PicScrMus = PicScrMus,
                            TotGrade = NilaiGlobal.TotGrade,
                            TotScore = NilaiGlobal.TotScore


                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        /*-------------------PIVOT MATERIAL RECEIVING-------------------------------*/
        public List<viewTable> vRptMatRec(int year)
        {
            decimal val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12;
            decimal total = 0,grandtot =0;
            decimal totjan = 0, totfeb = 0, totmar = 0, totapr = 0, totmay = 0, totjun = 0, totjul = 0, totaug = 0, totsep = 0, totoct = 0, totnov = 0, totdec = 0;
            string tmp1="", tmp2= "ASSET";
            decimal subjan = 0, subfeb = 0, submar = 0, subapr = 0, submay = 0, subjun = 0, subjul = 0, subaug = 0, subsep = 0, suboct = 0, subnov = 0, subdec = 0;
            decimal Tjan = 0;
            string sSql="";
            int bul=0;
            List<viewTable> lst = new List<viewTable>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Pivot", con);
                com.Parameters.AddWithValue("@YEAR", year);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "PvtMatRec");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();

                    while (rdr.Read())
                    {
                        if (rdr["Jan"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["Jan"]));

                        if (rdr["Feb"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["Feb"]));

                        if (rdr["Mar"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["Mar"]));

                        if (rdr["Apr"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["Apr"]));


                        if (rdr["May"] == DBNull.Value)
                            val5 = 0;
                        else
                            val5 = Math.Round(Convert.ToDecimal(rdr["May"]));

                        if (rdr["Jun"] == DBNull.Value)
                            val6 = 0;
                        else
                            val6 = Math.Round(Convert.ToDecimal(rdr["Jun"]));

                        if (rdr["Jul"] == DBNull.Value)
                            val7 = 0;
                        else
                            val7 = Math.Round(Convert.ToDecimal(rdr["Jul"]));

                        if (rdr["Aug"] == DBNull.Value)
                            val8 = 0;
                        else
                            val8 = Math.Round(Convert.ToDecimal(rdr["Aug"]));

                        if (rdr["Sep"] == DBNull.Value)
                            val9 = 0;
                        else
                            val9 = Math.Round(Convert.ToDecimal(rdr["Sep"]));

                        if (rdr["Oct"] == DBNull.Value)
                            val10 = 0;
                        else
                            val10 = Math.Round(Convert.ToDecimal(rdr["Oct"]));

                        if (rdr["Nov"] == DBNull.Value)
                            val11 = 0;
                        else
                            val11 = Math.Round(Convert.ToDecimal(rdr["Nov"]));

                        if (rdr["Dec"] == DBNull.Value)
                            val12 = 0;
                        else
                            val12 = Math.Round(Convert.ToDecimal(rdr["Dec"]));

                        total = val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12;

                        totjan = totjan + val1;
                        totfeb = totfeb + val2;
                        totmar = totmar + val3;
                        totapr = totapr + val4;
                        totmay = totmay + val5;
                        totjun = totjun + val6;
                        totjul = totjul + val7;
                        totaug = totaug + val8;
                        totsep = totsep + val9;
                        totoct = totoct + val10;
                        totnov = totnov + val11;
                        totdec = totdec + val12;
                        grandtot = grandtot + total;

                        tmp1 = rdr["groups"].ToString();
                        if (tmp1 == tmp2)
                        {
                            subjan = subjan + val1; subjul = subjul + val7;
                            subfeb = subfeb + val2; subaug = subaug + val8;
                            submar = submar + val3; subsep = subsep + val9;
                            subapr = subapr + val4; suboct = suboct + val10;
                            submay = submay + val5; subnov = subnov + val11;
                            subjun = subjun + val6; subdec = subdec + val12;

                            Tjan = Tjan + total;
                        }
                        else
                        {
                            lst.Add(new viewTable
                            {
                                remark = "SUBTOT " + tmp2,
                                jan = subjan,
                                feb = subfeb,
                                mar = submar,
                                apr = subapr,
                                may = submay,
                                jun = subjun,
                                jul = subjul,
                                aug = subaug,
                                sep = subsep,
                                oct = suboct,
                                nov = subnov,
                                dec = subdec,
                                tot = Tjan,
                                grandtot = grandtot,
                                totjan = totjan,
                                totfeb = totfeb,
                                totmar = totmar,
                                totapr = totapr,
                                totmay = totmay,
                                totjun = totjun,
                                totjul = totjul,
                                totaug = totaug,
                                totsep = totsep,
                                totoct = totoct,
                                totnov = totnov,
                                totdec = totdec
                            });

                            subjan = val1; subjul = val7;
                            subfeb = val2; subaug = val8;
                            submar = val3; subsep = val9;
                            subapr = val4; suboct = val10;
                            submay = val5; subnov = val11;
                            subjun = val6; subdec = val12;
                            Tjan = total;
                        }
                        if (tmp2!=tmp1)
                        {
                            lst.Add(new viewTable
                            {
                                remark = rdr["Keterangan"].ToString(),
                                jan = val1,
                                feb = val2,
                                mar = val3,
                                apr = val4,
                                may = val5,
                                jun = val6,
                                jul = val7,
                                aug = val8,
                                sep = val9,
                                oct = val10,
                                nov = val11,
                                dec = val12,
                                tot = total,
                                grandtot = grandtot,
                                totjan = totjan,
                                totfeb = totfeb,
                                totmar = totmar,
                                totapr = totapr,
                                totmay = totmay,
                                totjun = totjun,
                                totjul = totjul,
                                totaug = totaug,
                                totsep = totsep,
                                totoct = totoct,
                                totnov = totnov,
                                totdec = totdec
                            });

                            tmp2 = tmp1;
                        }
                        else
                        {
                            lst.Add(new viewTable
                            {
                                remark = rdr["Keterangan"].ToString(),
                                jan = val1,
                                feb = val2,
                                mar = val3,
                                apr = val4,
                                may = val5,
                                jun = val6,
                                jul = val7,
                                aug = val8,
                                sep = val9,
                                oct = val10,
                                nov = val11,
                                dec = val12,
                                tot = total,
                                grandtot = grandtot,
                                totjan = totjan,
                                totfeb = totfeb,
                                totmar = totmar,
                                totapr = totapr,
                                totmay = totmay,
                                totjun = totjun,
                                totjul = totjul,
                                totaug = totaug,
                                totsep = totsep,
                                totoct = totoct,
                                totnov = totnov,
                                totdec = totdec
                            });

                        }
                    }
                    if (rdr.HasRows)
                    {   
                        //data terakhir tambahkan subtot
                        lst.Add(new viewTable
                        {
                            remark = "SUBTOT " + tmp1,
                            jan = subjan,
                            feb = subfeb,
                            mar = submar,
                            apr = subapr,
                            may = submay,
                            jun = subjun,
                            jul = subjul,
                            aug = subaug,
                            sep = subsep,
                            oct = suboct,
                            nov = subnov,
                            dec = subdec,
                            tot = Tjan,
                            grandtot = grandtot,
                            totjan = totjan,
                            totfeb = totfeb,
                            totmar = totmar,
                            totapr = totapr,
                            totmay = totmay,
                            totjun = totjun,
                            totjul = totjul,
                            totaug = totaug,
                            totsep = totsep,
                            totoct = totoct,
                            totnov = totnov,
                            totdec = totdec
                        });

                        //data terakhir tambahkan grandtot
                        //grandtot=  subjan + subfeb +submar + subapr + submay + subjun + subjul + subaug + subsep + suboct + subnov + subdec;

                        lst.Add(new viewTable
                        {
                            remark = "GRANDTOT ",
                            jan = subjan,
                            feb = subfeb,
                            mar = submar,
                            apr = subapr,
                            may = submay,
                            jun = subjun,
                            jul = subjul,
                            aug = subaug,
                            sep = subsep,
                            oct = suboct,
                            nov = subnov,
                            dec = subdec,
                            tot = Tjan,
                            grandtot = grandtot,
                            totjan = totjan,
                            totfeb = totfeb,
                            totmar = totmar,
                            totapr = totapr,
                            totmay = totmay,
                            totjun = totjun,
                            totjul = totjul,
                            totaug = totaug,
                            totsep = totsep,
                            totoct = totoct,
                            totnov = totnov,
                            totdec = totdec
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                /*----------- SUMM VAT -------------*/
                string cs2 = ConfigurationManager.ConnectionStrings["DBKPI"].ConnectionString;

                subjan = 0; subfeb = 0; submar = 0; subapr = 0; submay = 0; subjun = 0; subjul = 0; subaug = 0; subsep = 0; suboct = 0; subnov = 0; subdec = 0;
                total = 0;  Tjan = 0;
                sSql = "select month(dbuktidate) as bul,round(sum(ivattotalamount),0) as amt from tap where year(dbuktidate) = " + year + " group by month(dbuktidate) order by bul";
                SqlConnection con2 = new SqlConnection(cs2);
                SqlCommand com2 = new SqlCommand(sSql, con2);
                com2.CommandType = CommandType.Text;

                try
                {
                    con2.Open();
                    SqlDataReader rdr2 = com2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        bul = Convert.ToInt32(rdr2["bul"]);
                        total = Convert.ToDecimal(rdr2["amt"]);
                        switch (bul)
                        {
                            case 1:
                                subjan = total;
                                break;
                            case 2:
                                subfeb = total;
                                break;
                            case 3:
                                submar = total;
                                break;
                            case 4:
                                subapr = total;
                                break;
                            case 5:
                                submay = total;
                                break;
                            case 6:
                                subjun = total;
                                break;
                            case 7:
                                subjul = total;
                                break;
                            case 8:
                                subaug = total;
                                break;
                            case 9:
                                subsep = total;
                                break;
                            case 10:
                                suboct = total;
                                break;
                            case 11:
                                subnov = total;
                                break;
                            case 12:
                                subdec = total;
                                break;
                        }
                    }

                    Tjan = subjan + subfeb + submar + subapr + submay + subjun + subjul + subaug + subsep + suboct + subnov + subdec;
                    lst.Add(new viewTable
                    {
                        remark = "VAT",
                        jan = subjan,
                        feb = subfeb,
                        mar = submar,
                        apr = subapr,
                        may = submay,
                        jun = subjun,
                        jul = subjul,
                        aug = subaug,
                        sep = subsep,
                        oct = suboct,
                        nov = subnov,
                        dec = subdec,
                        tot = Tjan

                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    com2.Dispose();
                    com2 = null;
                    con2.Close();
                    con2.Dispose();
                }

                return lst;
            }
        }

        /*-------------------PIVOT MATERIAL FORECASTING-------------------------------*/
        public List<viewTable> vRptMatForcstng(int year)
        {
            decimal val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, valback;
            decimal total = 0, grandtot = 0;
            decimal totjan = 0, totfeb = 0, totmar = 0, totapr = 0, totmay = 0, totjun = 0, totjul = 0, totaug = 0, totsep = 0, totoct = 0, totnov = 0, totdec = 0, totback = 0;
            string tmp1 = "", tmp2 = "ASSET";
            decimal subjan = 0, subfeb = 0, submar = 0, subapr = 0, submay = 0, subjun = 0, subjul = 0, subaug = 0, subsep = 0, suboct = 0, subnov = 0, subdec = 0, subback = 0;
            decimal Tjan = 0;
            string bul = "";
            List<viewTable> lst = new List<viewTable>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Pivot", con);
                com.Parameters.AddWithValue("@YEAR", year);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "PvtMatForCast");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();

                    while (rdr.Read())
                    {
                        if (rdr["Jan"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["Jan"]));

                        if (rdr["Feb"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["Feb"]));

                        if (rdr["Mar"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["Mar"]));

                        if (rdr["Apr"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["Apr"]));


                        if (rdr["May"] == DBNull.Value)
                            val5 = 0;
                        else
                            val5 = Math.Round(Convert.ToDecimal(rdr["May"]));

                        if (rdr["Jun"] == DBNull.Value)
                            val6 = 0;
                        else
                            val6 = Math.Round(Convert.ToDecimal(rdr["Jun"]));

                        if (rdr["Jul"] == DBNull.Value)
                            val7 = 0;
                        else
                            val7 = Math.Round(Convert.ToDecimal(rdr["Jul"]));

                        if (rdr["Aug"] == DBNull.Value)
                            val8 = 0;
                        else
                            val8 = Math.Round(Convert.ToDecimal(rdr["Aug"]));

                        if (rdr["Sep"] == DBNull.Value)
                            val9 = 0;
                        else
                            val9 = Math.Round(Convert.ToDecimal(rdr["Sep"]));

                        if (rdr["Oct"] == DBNull.Value)
                            val10 = 0;
                        else
                            val10 = Math.Round(Convert.ToDecimal(rdr["Oct"]));

                        if (rdr["Nov"] == DBNull.Value)
                            val11 = 0;
                        else
                            val11 = Math.Round(Convert.ToDecimal(rdr["Nov"]));

                        if (rdr["Dec"] == DBNull.Value)
                            val12 = 0;
                        else
                            val12 = Math.Round(Convert.ToDecimal(rdr["Dec"]));

                        if (rdr["BACKLOG"] == DBNull.Value)
                            valback = 0;
                        else
                            valback = Math.Round(Convert.ToDecimal(rdr["BACKLOG"]));


                        total = val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12 + valback;

                        totjan = totjan + val1;
                        totfeb = totfeb + val2;
                        totmar = totmar + val3;
                        totapr = totapr + val4;
                        totmay = totmay + val5;
                        totjun = totjun + val6;
                        totjul = totjul + val7;
                        totaug = totaug + val8;
                        totsep = totsep + val9;
                        totoct = totoct + val10;
                        totnov = totnov + val11;
                        totdec = totdec + val12;
                        totback = totback + valback;
                        grandtot = grandtot + total;

                        tmp1 = rdr["groups"].ToString();
                        if (tmp1 == tmp2)
                        {
                            subjan = subjan + val1; subjul = subjul + val7;
                            subfeb = subfeb + val2; subaug = subaug + val8;
                            submar = submar + val3; subsep = subsep + val9;
                            subapr = subapr + val4; suboct = suboct + val10;
                            submay = submay + val5; subnov = subnov + val11;
                            subjun = subjun + val6; subdec = subdec + val12;
                            subback = subback + valback;

                            Tjan = Tjan + total;
                        }
                        else
                        {
                            lst.Add(new viewTable
                            {
                                remark = "SUBTOT " + tmp2,
                                jan = subjan,
                                feb = subfeb,
                                mar = submar,
                                apr = subapr,
                                may = submay,
                                jun = subjun,
                                jul = subjul,
                                aug = subaug,
                                sep = subsep,
                                oct = suboct,
                                nov = subnov,
                                dec = subdec,
                                log = subback,
                                tot = Tjan,
                                grandtot = grandtot,
                                totjan = totjan,
                                totfeb = totfeb,
                                totmar = totmar,
                                totapr = totapr,
                                totmay = totmay,
                                totjun = totjun,
                                totjul = totjul,
                                totaug = totaug,
                                totsep = totsep,
                                totoct = totoct,
                                totnov = totnov,
                                totdec = totdec,
                                totlog = totback
                            });

                            subjan = val1; subjul = val7;
                            subfeb = val2; subaug = val8;
                            submar = val3; subsep = val9;
                            subapr = val4; suboct = val10;
                            submay = val5; subnov = val11;
                            subjun = val6; subdec = val12;
                            Tjan = total;  subback = valback;
                        }
                        if (tmp2 != tmp1)
                        {
                            lst.Add(new viewTable
                            {
                                remark = rdr["Keterangan"].ToString(),
                                jan = val1,
                                feb = val2,
                                mar = val3,
                                apr = val4,
                                may = val5,
                                jun = val6,
                                jul = val7,
                                aug = val8,
                                sep = val9,
                                oct = val10,
                                nov = val11,
                                dec = val12,
                                log = valback,
                                tot = total,
                                grandtot = grandtot,
                                totjan = totjan,
                                totfeb = totfeb,
                                totmar = totmar,
                                totapr = totapr,
                                totmay = totmay,
                                totjun = totjun,
                                totjul = totjul,
                                totaug = totaug,
                                totsep = totsep,
                                totoct = totoct,
                                totnov = totnov,
                                totdec = totdec,
                                totlog = totback
                            });

                            tmp2 = tmp1;
                        }
                        else
                        {
                            lst.Add(new viewTable
                            {
                                remark = rdr["Keterangan"].ToString(),
                                jan = val1,
                                feb = val2,
                                mar = val3,
                                apr = val4,
                                may = val5,
                                jun = val6,
                                jul = val7,
                                aug = val8,
                                sep = val9,
                                oct = val10,
                                nov = val11,
                                dec = val12,
                                log = valback,
                                tot = total,
                                grandtot = grandtot,
                                totjan = totjan,
                                totfeb = totfeb,
                                totmar = totmar,
                                totapr = totapr,
                                totmay = totmay,
                                totjun = totjun,
                                totjul = totjul,
                                totaug = totaug,
                                totsep = totsep,
                                totoct = totoct,
                                totnov = totnov,
                                totdec = totdec,
                                totlog = totback
                            });

                        }
                    }
                    if (rdr.HasRows)
                    {
                        //data terakhir tambahkan subtot
                        lst.Add(new viewTable
                        {
                            remark = "SUBTOT " + tmp1,
                            jan = subjan,
                            feb = subfeb,
                            mar = submar,
                            apr = subapr,
                            may = submay,
                            jun = subjun,
                            jul = subjul,
                            aug = subaug,
                            sep = subsep,
                            oct = suboct,
                            nov = subnov,
                            dec = subdec,
                            log = subback,
                            tot = Tjan,
                            grandtot = grandtot,
                            totjan = totjan,
                            totfeb = totfeb,
                            totmar = totmar,
                            totapr = totapr,
                            totmay = totmay,
                            totjun = totjun,
                            totjul = totjul,
                            totaug = totaug,
                            totsep = totsep,
                            totoct = totoct,
                            totnov = totnov,
                            totdec = totdec,
                            totlog = totback
                        });

                        //data terakhir tambahkan grandtot
                        //grandtot=  subjan + subfeb +submar + subapr + submay + subjun + subjul + subaug + subsep + suboct + subnov + subdec;

                        lst.Add(new viewTable
                        {
                            remark = "GRANDTOT ",
                            jan = subjan,
                            feb = subfeb,
                            mar = submar,
                            apr = subapr,
                            may = submay,
                            jun = subjun,
                            jul = subjul,
                            aug = subaug,
                            sep = subsep,
                            oct = suboct,
                            nov = subnov,
                            dec = subdec,
                            log = subback,
                            tot = Tjan,
                            grandtot = grandtot,
                            totjan = totjan,
                            totfeb = totfeb,
                            totmar = totmar,
                            totapr = totapr,
                            totmay = totmay,
                            totjun = totjun,
                            totjul = totjul,
                            totaug = totaug,
                            totsep = totsep,
                            totoct = totoct,
                            totnov = totnov,
                            totdec = totdec,
                            totlog = totback
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

                /*----------- SUMM VAT -------------*/
                string cs2 = ConfigurationManager.ConnectionStrings["DBKPI"].ConnectionString;

                subjan = 0; subfeb = 0; submar = 0; subapr = 0; submay = 0; subjun = 0; subjul = 0; subaug = 0; subsep = 0; suboct = 0; subnov = 0; subdec = 0; subback = 0;
                total = 0; Tjan = 0;
                //sSql = "select month(dbuktidate) as bul,round(sum(ivattotalamount),0) as amt from tap where year(dbuktidate) = " + year + " group by month(dbuktidate) order by bul";
                //SqlConnection con2 = new SqlConnection(cs2);
                //SqlCommand com2 = new SqlCommand(sSql, con2);
                //com2.CommandType = CommandType.Text;
                using (SqlConnection con2 = new SqlConnection(cs2))
                {
                    SqlCommand com2 = new SqlCommand("Extranet_Pivot", con2);
                    com2.Parameters.AddWithValue("@YEAR", year);
                    com2.CommandType = CommandType.StoredProcedure;
                    com2.Parameters.AddWithValue("@Action", "VATForecstg");
                    try
                    {
                        con2.Open();
                        SqlDataReader rdr2 = com2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            bul = rdr2["bulan"].ToString();
                            total = Convert.ToDecimal(rdr2["amount"]);
                            switch (bul)
                            {
                                case "1":
                                    subjan = total;
                                    break;
                                case "2":
                                    subfeb = total;
                                    break;
                                case "3":
                                    submar = total;
                                    break;
                                case "4":
                                    subapr = total;
                                    break;
                                case "5":
                                    submay = total;
                                    break;
                                case "6":
                                    subjun = total;
                                    break;
                                case "7":
                                    subjul = total;
                                    break;
                                case "8":
                                    subaug = total;
                                    break;
                                case "9":
                                    subsep = total;
                                    break;
                                case "10":
                                    suboct = total;
                                    break;
                                case "11":
                                    subnov = total;
                                    break;
                                case "12":
                                    subdec = total;
                                    break;
                                case "BACKLOG":
                                    subback = total;
                                    break;
                            }
                        }

                        Tjan = subjan + subfeb + submar + subapr + submay + subjun + subjul + subaug + subsep + suboct + subnov + subdec + subback;
                        lst.Add(new viewTable
                        {
                            remark = "VAT",
                            jan = subjan,
                            feb = subfeb,
                            mar = submar,
                            apr = subapr,
                            may = submay,
                            jun = subjun,
                            jul = subjul,
                            aug = subaug,
                            sep = subsep,
                            oct = suboct,
                            nov = subnov,
                            dec = subdec,
                            log = subback,
                            tot = Tjan

                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        com2.Dispose();
                        com2 = null;
                        con2.Close();
                        con2.Dispose();
                    }
                }
                return lst;
            }
        }


        /*-------------------PIVOT COST CONTROL CASTING-------------------------------*/
        public List<viewCost> vRptCost(int year, int month)
        {
            decimal val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15, val16, val17, val18, val19, val20,  total, totcost, totselisih;
            decimal grandtot = 0, sumtot = 0, sumselisih = 0 ;
            decimal totC1 = 0, totC2 = 0, totC3 = 0, totC4 = 0, totC5 = 0, totC6 = 0, totC7 = 0, totC8 = 0, totC9 = 0, totC10 = 0, totC11 = 0, totC12 = 0, totC13 = 0, totC14 = 0, totC15 = 0, totC16 = 0, totC17 = 0, totC18 = 0, totC19 = 0, totC20 = 0;
            string tmp1 = "", tmp2 = "1. SCRAP";
            decimal subval1 = 0, subval2 = 0, subval3 = 0, subval4 = 0, subval5 = 0, subval6 = 0, subval7 = 0, subval8 = 0, subval9 = 0, subval10 = 0, subval11 = 0, subval12 = 0, subval13 = 0, subval14 = 0, subval15 = 0, subval16 = 0, subval17 = 0, subval18 = 0, subval19 = 0, subval20 = 0; 
            decimal variance =0, Tsub = 0, Tcost=0, Tvariance=0, TProsen=0;
            decimal ba, bs, sumtotBA=0, sumtotBS=0, TvarBA=0, TvarBS=0, TsubBA = 0, TsubBS = 0, grandtotBS=0, grandtotBA=0;

            List<viewCost> lst = new List<viewCost>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Pivot", con);
                com.Parameters.AddWithValue("@year", year);
                com.Parameters.AddWithValue("@month", month);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "PvtCostCtrl");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["C1"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["C1"]));

                        if (rdr["C2"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["C2"]));

                        if (rdr["C3"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["C3"]));

                        if (rdr["C4"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["C4"]));

                        if (rdr["C5"] == DBNull.Value)
                            val5 = 0;
                        else
                            val5 = Math.Round(Convert.ToDecimal(rdr["C5"]));

                        if (rdr["C6"] == DBNull.Value)
                            val6 = 0;
                        else
                            val6 = Math.Round(Convert.ToDecimal(rdr["C6"]));

                        if (rdr["C7"] == DBNull.Value)
                            val7 = 0;
                        else
                            val7 = Math.Round(Convert.ToDecimal(rdr["C7"]));

                        if (rdr["C8"] == DBNull.Value)
                            val8 = 0;
                        else
                            val8 = Math.Round(Convert.ToDecimal(rdr["C8"]));

                        if (rdr["C9"] == DBNull.Value)
                            val9 = 0;
                        else
                            val9 = Math.Round(Convert.ToDecimal(rdr["C9"]));

                        if (rdr["C10"] == DBNull.Value)
                            val10 = 0;
                        else
                            val10 = Math.Round(Convert.ToDecimal(rdr["C10"]));

                        if (rdr["C11"] == DBNull.Value)
                            val11 = 0;
                        else
                            val11 = Math.Round(Convert.ToDecimal(rdr["C11"]));

                        if (rdr["C12"] == DBNull.Value)
                            val12 = 0;
                        else
                            val12 = Math.Round(Convert.ToDecimal(rdr["C12"]));

                        if (rdr["C13"] == DBNull.Value)
                            val13 = 0;
                        else
                            val13 = Math.Round(Convert.ToDecimal(rdr["C13"]));

                        if (rdr["C14"] == DBNull.Value)
                            val14 = 0;
                        else
                            val14 = Math.Round(Convert.ToDecimal(rdr["C14"]));

                        if (rdr["C15"] == DBNull.Value)
                            val15 = 0;
                        else
                            val15 = Math.Round(Convert.ToDecimal(rdr["C15"]));

                        if (rdr["C16"] == DBNull.Value)
                            val16 = 0;
                        else
                            val16 = Math.Round(Convert.ToDecimal(rdr["C16"]));

                        if (rdr["C17"] == DBNull.Value)
                            val17 = 0;
                        else
                            val17 = Math.Round(Convert.ToDecimal(rdr["C17"]));

                        if (rdr["C18"] == DBNull.Value)
                            val18 = 0;
                        else
                            val18 = Math.Round(Convert.ToDecimal(rdr["C18"]));

                        if (rdr["C19"] == DBNull.Value)
                            val19 = 0;
                        else
                            val19 = Math.Round(Convert.ToDecimal(rdr["C19"]));

                        if (rdr["C20"] == DBNull.Value)
                            val20 = 0;
                        else
                            val20 = Math.Round(Convert.ToDecimal(rdr["C20"]));

                        if (rdr["COST"] == DBNull.Value)
                            totcost = 0;
                        else
                            totcost = Math.Round(Convert.ToDecimal(rdr["COST"]));

                        if (rdr["BS"] == DBNull.Value)
                            bs = 0;
                        else
                            bs = Math.Round(Convert.ToDecimal(rdr["BS"]),2);

                        if (rdr["BA"] == DBNull.Value)
                            ba = 0;
                        else
                            ba = Math.Round(Convert.ToDecimal(rdr["BA"]),2);



                        total = val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12 + val13 + val14 + val15 + val16 + val17 + val18 + val19 + val20;
                        totselisih = total - totcost;
                        sumtot = sumtot + total;
                        sumselisih = sumselisih + totcost;
                        grandtot = grandtot + totselisih;
                        TvarBA = ba;
                        TvarBS = bs;
                        sumtotBS = sumtotBS + bs;
                        sumtotBA = sumtotBA + ba;

                        grandtotBS = grandtotBS + bs;
                        grandtotBA = grandtotBA + ba;

                        if (total > 0)
                            variance = totselisih / total * 100;
                        else
                            variance = 0;

                        totC1 = totC1 + val1;
                        totC2 = totC2 + val2;
                        totC3 = totC3 + val3;
                        totC4 = totC4 + val4;
                        totC5 = totC5 + val5;
                        totC6 = totC6 + val6;
                        totC7 = totC7 + val7;
                        totC8 = totC8 + val8;
                        totC9 = totC9 + val9;
                        totC10 = totC10 + val10;
                        totC11 = totC11 + val11;
                        totC12 = totC12 + val12;
                        totC13 = totC13 + val13;
                        totC14 = totC14 + val14;
                        totC15 = totC15 + val15;
                        totC16 = totC16 + val16;
                        totC17 = totC17 + val17;
                        totC18 = totC18 + val18;
                        totC19 = totC19 + val19;
                        totC20 = totC20 + val20;

                        tmp1 = rdr["groups"].ToString();
                        if (tmp1 == tmp2)
                        {
                            // subval1=0, subval2=0, subval3=0, subval4=0, subval5=0, subval6=0, subval7=0, subval8=0, subval9=0, subval10=0, subval11=0, 
                            //subval12 =0, subval13=0, subval14=0, subval15=0, subval16 = 0, subval17=0, subval18=0, subval19=0, subval20=0, 

                            subval1 = subval1 + val1; subval7 = subval7 + val7;
                            subval2 = subval2 + val2; subval8 = subval8 + val8;
                            subval3 = subval3 + val3; subval9 = subval9 + val9;
                            subval4 = subval4 + val4; subval10 = subval10 + val10;
                            subval5 = subval5 + val5; subval11 = subval11 + val11;
                            subval6 = subval6 + val6; subval12 = subval12 + val12;
                            subval13 = subval13 + val13; subval17 = subval17 + val17;
                            subval14 = subval14 + val14; subval18 = subval18 + val18;
                            subval15 = subval15 + val15; subval19 = subval19 + val19;
                            subval16 = subval16 + val16; subval20 = subval20 + val20;

                            Tsub = Tsub + total;
                            Tcost = Tcost + totcost;
                            TsubBA = TsubBA + TvarBA;
                            TsubBS = TsubBS + TvarBS;
                            Tvariance = Tvariance + totselisih;
                            if (Tsub > 0)
                                TProsen = Tvariance / Tsub * 100;
                            else
                                TProsen = 0;
                        }
                        else
                        {                            
                            lst.Add(new viewCost
                            {
                                item = "TOTAL " + tmp2,
                                C1 = subval1,
                                C2 = subval2,
                                C3 = subval3,
                                C4 = subval4,
                                C5 = subval5,
                                C6 = subval6,
                                C7 = subval7,
                                C8 = subval8,
                                C9 = subval9,
                                C10 = subval10,
                                C11 = subval11,
                                C12 = subval12,
                                C13 = subval13,
                                C14 = subval14,
                                C15 = subval15,
                                C16 = subval16,
                                C17 = subval17,
                                C18 = subval18,
                                C19 = subval19,
                                C20 = subval20,
                                tot = Tsub,
                                cost = Tcost,
                                diff = Tvariance,
                                totC1 = totC1,
                                totC2 = totC2,
                                totC3 = totC3,
                                totC4 = totC4,
                                totC5 = totC5,
                                totC6 = totC6,
                                totC7 = totC7,
                                totC8 = totC8,
                                totC9 = totC9,
                                totC10 = totC10,
                                totC11 = totC11,
                                totC12 = totC12,
                                totC13 = totC13,
                                totC14 = totC14,
                                totC15 = totC15,
                                totC16 = totC16,
                                totC17 = totC17,
                                totC18 = totC18,
                                totC19 = totC19,
                                totC20 = totC20,
                                sumtot = sumtot,
                                sumcost = sumselisih,
                                grandtot = grandtot,
                                variance = TProsen,
                                BA = TsubBA,
                                BS = TsubBS,
                                sumtotBA = TsubBA,
                                sumtotBS = TsubBS ,
                                grandtotBA = grandtotBA,
                                grandtotBS = grandtotBS

                            });

                            subval1 = val1; subval7 = val7; subval13 = val13; subval19 = val19;
                            subval2 = val2; subval8 = val8; subval14 = val14; subval20 = val20;
                            subval3 = val3; subval9 = val9; subval15 = val15; 
                            subval4 = val4; subval10 = val10; subval16 = val16; 
                            subval5 = val5; subval11 = val11; subval17 = val17; 
                            subval6 = val6; subval12 = val12; subval18 = val18;
                            Tsub = total;
                            Tcost = totcost;
                            TsubBA =  TvarBA;
                            TsubBS =  TvarBS;
                            Tvariance = totselisih;
                            
                        }

                        if (tmp2 != tmp1)
                        {
                            lst.Add(new viewCost
                            {
                                item = rdr["item"].ToString(),
                                C1 = val1,
                                C2 = val2,
                                C3 = val3,
                                C4 = val4,
                                C5 = val5,
                                C6 = val6,
                                C7 = val7,
                                C8 = val8,
                                C9 = val9,
                                C10 = val10,
                                C11 = val11,
                                C12 = val12,
                                C13 = val13,
                                C14 = val14,
                                C15 = val15,
                                C16 = val16,
                                C17 = val17,
                                C18 = val18,
                                C19 = val19,
                                C20 = val20,
                                tot = total,
                                cost = totcost,
                                diff = totselisih,
                                totC1 = totC1,
                                totC2 = totC2,
                                totC3 = totC3,
                                totC4 = totC4,
                                totC5 = totC5,
                                totC6 = totC6,
                                totC7 = totC7,
                                totC8 = totC8,
                                totC9 = totC9,
                                totC10 = totC10,
                                totC11 = totC11,
                                totC12 = totC12,
                                totC13 = totC13,
                                totC14 = totC14,
                                totC15 = totC15,
                                totC16 = totC16,
                                totC17 = totC17,
                                totC18 = totC18,
                                totC19 = totC19,
                                totC20 = totC20,
                                sumtot = sumtot,
                                sumcost = sumselisih,
                                grandtot = grandtot,
                                variance = variance,
                                BA = TvarBA,
                                BS = TvarBS,
                                sumtotBA = sumtotBA,
                                sumtotBS = sumtotBS,
                                grandtotBA = grandtotBA,
                                grandtotBS = grandtotBS

                            });

                            tmp2 = tmp1;
                        }
                        else
                        {
                            lst.Add(new viewCost
                            {
                                item = rdr["item"].ToString(),
                                C1 = val1,
                                C2 = val2,
                                C3 = val3,
                                C4 = val4,
                                C5 = val5,
                                C6 = val6,
                                C7 = val7,
                                C8 = val8,
                                C9 = val9,
                                C10 = val10,
                                C11 = val11,
                                C12 = val12,
                                C13 = val13,
                                C14 = val14,
                                C15 = val15,
                                C16 = val16,
                                C17 = val17,
                                C18 = val18,
                                C19 = val19,
                                C20 = val20,
                                tot = total,
                                cost = totcost,
                                diff = totselisih,
                                totC1 = totC1,
                                totC2 = totC2,
                                totC3 = totC3,
                                totC4 = totC4,
                                totC5 = totC5,
                                totC6 = totC6,
                                totC7 = totC7,
                                totC8 = totC8,
                                totC9 = totC9,
                                totC10 = totC10,
                                totC11 = totC11,
                                totC12 = totC12,
                                totC13 = totC13,
                                totC14 = totC14,
                                totC15 = totC15,
                                totC16 = totC16,
                                totC17 = totC17,
                                totC18 = totC18,
                                totC19 = totC19,
                                totC20 = totC20,
                                sumtot = sumtot,
                                sumcost = sumselisih,
                                grandtot = grandtot,
                                variance = variance,
                                BA = TvarBA,
                                BS = TvarBS,
                                sumtotBA = sumtotBA,
                                sumtotBS = sumtotBS,
                                grandtotBA = grandtotBA,
                                grandtotBS = grandtotBS
                            });
                        }
                    }

                    if (rdr.HasRows)
                    {
                        lst.Add(new viewCost
                        {
                            item = "TOTAL " + tmp2,
                            C1 = subval1,
                            C2 = subval2,
                            C3 = subval3,
                            C4 = subval4,
                            C5 = subval5,
                            C6 = subval6,
                            C7 = subval7,
                            C8 = subval8,
                            C9 = subval9,
                            C10 = subval10,
                            C11 = subval11,
                            C12 = subval12,
                            C13 = subval13,
                            C14 = subval14,
                            C15 = subval15,
                            C16 = subval16,
                            C17 = subval17,
                            C18 = subval18,
                            C19 = subval19,
                            C20 = subval20,
                            tot = Tsub,
                            cost = Tcost,
                            diff = Tvariance,
                            totC1 = totC1,
                            totC2 = totC2,
                            totC3 = totC3,
                            totC4 = totC4,
                            totC5 = totC5,
                            totC6 = totC6,
                            totC7 = totC7,
                            totC8 = totC8,
                            totC9 = totC9,
                            totC10 = totC10,
                            totC11 = totC11,
                            totC12 = totC12,
                            totC13 = totC13,
                            totC14 = totC14,
                            totC15 = totC15,
                            totC16 = totC16,
                            totC17 = totC17,
                            totC18 = totC18,
                            totC19 = totC19,
                            totC20 = totC20,
                            sumtot = sumtot,
                            sumcost = sumselisih,
                            grandtot = grandtot,
                            variance = TProsen,
                            BA = TvarBA,
                            BS = TvarBS,
                            sumtotBA = TvarBA,
                            sumtotBS = TvarBS,
                            grandtotBA = grandtotBA,
                            grandtotBS = grandtotBS

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        /*-------------------COST CONTROL MACHINING-------------------------------*/
        public List<viewCost> vRptMachCostControl(int thn, int bln)
        {
            List<viewCost> lst = new List<viewCost>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                decimal val1, val2, diff=0;
                double variance=0;
                SqlCommand com = new SqlCommand("Extranet_PPIC_Conrtrol", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEARPAR", thn);
                com.Parameters.AddWithValue("@MONTHPAR", bln);
                com.Parameters.AddWithValue("@Action", "ControlMachining");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["std"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["std"]));

                        if (rdr["amount"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["amount"]));

                        if (rdr["std"] != DBNull.Value && rdr["amount"] != DBNull.Value)
                        {
                            diff = val1 - val2;
                            variance = Convert.ToDouble(diff / val1 * 100);
                        }
                        else
                        {
                            diff = 0;
                            variance = 0;
                        }
                        lst.Add(new viewCost
                        {
                            item = rdr["ket"].ToString(),
                            C1 = val1,
                            C2 = val2,
                            diff = diff,
                            variance = Convert.ToDecimal(Math.Round(variance,2))

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*-------------------PIVOT COST CONTROL INVENTORY-------------------------------*/
        public List<viewCostInv> vRptInvControl(int year, int month)
        {
            decimal val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12;
            decimal TR1, TR2, TR3, TR4, TR5, TR6, TR7, TR8, TR9, TR10, TR11, TR12;
            decimal totalA, totalT, sumtotA = 0, sumtotT = 0;
            decimal totA1 = 0, totA2 = 0, totA3 = 0, totA4 = 0, totA5 = 0, totA6 = 0, totA7 = 0, totA8 = 0, totA9 = 0, totA10 = 0, totA11 = 0, totA12 = 0;
            decimal totT1 = 0, totT2 = 0, totT3 = 0, totT4 = 0, totT5 = 0, totT6 = 0, totT7 = 0, totT8 = 0, totT9 = 0, totT10 = 0, totT11 = 0, totT12 = 0;
            string tmp1 = "", tmp2 = "1. FINISH GOODS";
            decimal subval1 = 0, subval2 = 0, subval3 = 0, subval4 = 0, subval5 = 0, subval6 = 0, subval7 = 0, subval8 = 0, subval9 = 0, subval10 = 0, subval11 = 0, subval12 = 0;
            decimal subTR1 = 0, subTR2 = 0, subTR3 = 0, subTR4 = 0, subTR5 = 0, subTR6 = 0, subTR7 = 0, subTR8 = 0, subTR9 = 0, subTR10 = 0, subTR11 = 0, subTR12 = 0;
            decimal TsubTGT = 0, TsubACT = 0, grandtotA = 0, grandtotT = 0;

            List<viewCostInv> lst = new List<viewCostInv>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Pivot", con);
                com.Parameters.AddWithValue("@year", year);
                com.Parameters.AddWithValue("@month", month);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@Action", "PvtInvCtrl");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //---actual
                        if (rdr["A1"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["A1"]));

                        if (rdr["A2"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["A2"]));

                        if (rdr["A3"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["A3"]));

                        if (rdr["A4"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["A4"]));

                        if (rdr["A5"] == DBNull.Value)
                            val5 = 0;
                        else
                            val5 = Math.Round(Convert.ToDecimal(rdr["A5"]));

                        if (rdr["A6"] == DBNull.Value)
                            val6 = 0;
                        else
                            val6 = Math.Round(Convert.ToDecimal(rdr["A6"]));

                        if (rdr["A7"] == DBNull.Value)
                            val7 = 0;
                        else
                            val7 = Math.Round(Convert.ToDecimal(rdr["A7"]));

                        if (rdr["A8"] == DBNull.Value)
                            val8 = 0;
                        else
                            val8 = Math.Round(Convert.ToDecimal(rdr["A8"]));

                        if (rdr["A9"] == DBNull.Value)
                            val9 = 0;
                        else
                            val9 = Math.Round(Convert.ToDecimal(rdr["A9"]));

                        if (rdr["A10"] == DBNull.Value)
                            val10 = 0;
                        else
                            val10 = Math.Round(Convert.ToDecimal(rdr["A10"]));

                        if (rdr["A11"] == DBNull.Value)
                            val11 = 0;
                        else
                            val11 = Math.Round(Convert.ToDecimal(rdr["A11"]));

                        if (rdr["A12"] == DBNull.Value)
                            val12 = 0;
                        else
                            val12 = Math.Round(Convert.ToDecimal(rdr["A12"]));

                        //---target

                        if (rdr["T1"] == DBNull.Value)
                            TR1 = 0;
                        else
                            TR1 = Math.Round(Convert.ToDecimal(rdr["T1"]));

                        if (rdr["T2"] == DBNull.Value)
                            TR2 = 0;
                        else
                            TR2 = Math.Round(Convert.ToDecimal(rdr["T2"]));

                        if (rdr["T3"] == DBNull.Value)
                            TR3 = 0;
                        else
                            TR3 = Math.Round(Convert.ToDecimal(rdr["T3"]));

                        if (rdr["T4"] == DBNull.Value)
                            TR4 = 0;
                        else
                            TR4 = Math.Round(Convert.ToDecimal(rdr["T4"]));

                        if (rdr["T5"] == DBNull.Value)
                            TR5 = 0;
                        else
                            TR5 = Math.Round(Convert.ToDecimal(rdr["T5"]));

                        if (rdr["T6"] == DBNull.Value)
                            TR6 = 0;
                        else
                            TR6 = Math.Round(Convert.ToDecimal(rdr["T6"]));

                        if (rdr["T7"] == DBNull.Value)
                            TR7 = 0;
                        else
                            TR7 = Math.Round(Convert.ToDecimal(rdr["T7"]));

                        if (rdr["T8"] == DBNull.Value)
                            TR8 = 0;
                        else
                            TR8 = Math.Round(Convert.ToDecimal(rdr["T8"]));

                        if (rdr["T9"] == DBNull.Value)
                            TR9 = 0;
                        else
                            TR9 = Math.Round(Convert.ToDecimal(rdr["T9"]));

                        if (rdr["T10"] == DBNull.Value)
                            TR10 = 0;
                        else
                            TR10 = Math.Round(Convert.ToDecimal(rdr["T10"]));

                        if (rdr["T11"] == DBNull.Value)
                            TR11 = 0;
                        else
                            TR11 = Math.Round(Convert.ToDecimal(rdr["T11"]));

                        if (rdr["T12"] == DBNull.Value)
                            TR12 = 0;
                        else
                            TR12 = Math.Round(Convert.ToDecimal(rdr["T12"]));


                        totalA = val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12 ;
                        totalT = TR1 + TR2 + TR3 + TR4 + TR5 + TR6 + TR7 + TR8 + TR9 + TR10 + TR11 + TR12;
                        sumtotA = sumtotA + totalA;
                        sumtotT = sumtotT + totalT;
                        grandtotA = grandtotA + totalA;
                        grandtotT = grandtotT + totalT;
                        /*-------------
                        sumselisih = sumselisih + totcost;
                        grandtot = grandtot + totselisih;

                        ----------------*/
                        totT1 = totT1 + TR1; totA1 = totA1 + val1;
                        totT2 = totT2 + TR2; totA2 = totA2 + val2;
                        totT3 = totT3 + TR3; totA3 = totA3 + val3;
                        totT4 = totT4 + TR4; totA4 = totA4 + val4;
                        totT5 = totT5 + TR5; totA5 = totA5 + val5;
                        totT6 = totT6 + TR6; totA6 = totA6 + val6;
                        totT7 = totT7 + TR7; totA7 = totA7 + val7;
                        totT8 = totT8 + TR8; totA8 = totA8 + val8;
                        totT9 = totT9 + TR9; totA9 = totA9 + val9;
                        totT10 = totT10 + TR10; totA10 = totA10 + val10;
                        totT11 = totT11 + TR11; totA11 = totA11 + val11;
                        totT12 = totT12 + TR12; totA12 = totA12 + val12;

                        tmp1 = rdr["urutan"].ToString();
                        //masih satu grup
                        if (tmp1 == tmp2)
                        {

                            subval1 = subval1 + val1; subval7 = subval7 + val7;
                            subval2 = subval2 + val2; subval8 = subval8 + val8;
                            subval3 = subval3 + val3; subval9 = subval9 + val9;
                            subval4 = subval4 + val4; subval10 = subval10 + val10;
                            subval5 = subval5 + val5; subval11 = subval11 + val11;
                            subval6 = subval6 + val6; subval12 = subval12 + val12;

                            subTR1 = subTR1 + TR1; subTR7 = subTR7 + TR7;
                            subTR2 = subTR2 + TR2; subTR8 = subTR8 + TR8;
                            subTR3 = subTR3 + TR3; subTR9 = subTR9 + TR9;
                            subTR4 = subTR4 + TR4; subTR10 = subTR10 + TR10;
                            subTR5 = subTR5 + TR5; subTR11 = subTR11 + TR11;
                            subTR6 = subTR6 + TR6; subTR12 = subTR12 + TR12;

                            TsubACT = TsubACT + totalA;
                            TsubTGT = TsubTGT + totalT;

                        }
                        else
                        {
                            lst.Add(new viewCostInv
                            {
                                item = "TOTAL " + tmp2,
                                A1 = subval1,
                                A2 = subval2,
                                A3 = subval3,
                                A4 = subval4,
                                A5 = subval5,
                                A6 = subval6,
                                A7 = subval7,
                                A8 = subval8,
                                A9 = subval9,
                                A10 = subval10,
                                A11 = subval11,
                                A12 = subval12,

                                /*--
                                tot = Tsub,
                                cost = Tcost,
                                diff = Tvariance,
                                --*/
                                T1 = subTR1,
                                T2 = subTR2,
                                T3 = subTR3,
                                T4 = subTR4,
                                T5 = subTR5,
                                T6 = subTR6,
                                T7 = subTR7,
                                T8 = subTR8,
                                T9 = subTR9,
                                T10 = subTR10,
                                T11 = subTR11,
                                T12 = subTR12,

                                totRowA = 0,
                                totRowT = 0,

                                totSubRowA = TsubACT,
                                totSubRowT = TsubTGT,
                                grandtotA = grandtotA,
                                grandtotT = grandtotT

                            });

                            subval1 = val1; subval7 = val7; 
                            subval2 = val2; subval8 = val8; 
                            subval3 = val3; subval9 = val9; 
                            subval4 = val4; subval10 = val10; 
                            subval5 = val5; subval11 = val11; 
                            subval6 = val6; subval12 = val12;

                            subTR1 = TR1; subTR7 = TR7;
                            subTR2 = TR2; subTR8 = TR8;
                            subTR3 = TR3; subTR9 = TR9;
                            subTR4 = TR4; subTR10 = TR10;
                            subTR5 = TR5; subTR11 = TR11;
                            subTR6 = TR6; subTR12 = TR12;


                            TsubACT = totalA;
                            TsubTGT = totalT;

                            /*---
                            Tsub = total;
                            Tcost = totcost;
                            Tvariance = totselisih;
                            ----*/
                        }

                        if (tmp2 != tmp1)
                        {
                            lst.Add(new viewCostInv
                            {
                                item = rdr["ket"].ToString(),
                                A1 = val1,
                                A2 = val2,
                                A3 = val3,
                                A4 = val4,
                                A5 = val5,
                                A6 = val6,
                                A7 = val7,
                                A8 = val8,
                                A9 = val9,
                                A10 = val10,
                                A11 = val11,
                                A12 = val12,

                                T1 = TR1,
                                T2 = TR2,
                                T3 = TR3,
                                T4 = TR4,
                                T5 = TR5,
                                T6 = TR6,
                                T7 = TR7,
                                T8 = TR8,
                                T9 = TR9,
                                T10 = TR10,
                                T11 = TR11,
                                T12 = TR12,

                                totA1 = totA1,
                                totA2 = totA2,
                                totA3 = totA3,
                                totA4 = totA4,
                                totA5 = totA5,
                                totA6 = totA6,
                                totA7 = totA7,
                                totA8 = totA8,
                                totA9 = totA9,
                                totA10 = totA10,
                                totA11 = totA11,
                                totA12 = totA12,

                                totT1 = totT1,
                                totT2 = totT2,
                                totT3 = totT3,
                                totT4 = totT4,
                                totT5 = totT5,
                                totT6 = totT6,
                                totT7 = totT7,
                                totT8 = totT8,
                                totT9 = totT9,
                                totT10 = totT10,
                                totT11 = totT11,
                                totT12 = totT12,

                                totRowA = totalA,
                                totRowT = totalT,

                                totSubRowA = totalA,
                                totSubRowT = totalT,

                                grandtotA = grandtotA,
                                grandtotT = grandtotT

                            });

                            tmp2 = tmp1;
                        }
                        else
                        {
                            lst.Add(new viewCostInv
                            {
                                item = rdr["ket"].ToString(),
                                A1 = val1,
                                A2 = val2,
                                A3 = val3,
                                A4 = val4,
                                A5 = val5,
                                A6 = val6,
                                A7 = val7,
                                A8 = val8,
                                A9 = val9,
                                A10 = val10,
                                A11 = val11,
                                A12 = val12,

                                T1 = TR1,
                                T2 = TR2,
                                T3 = TR3,
                                T4 = TR4,
                                T5 = TR5,
                                T6 = TR6,
                                T7 = TR7,
                                T8 = TR8,
                                T9 = TR9,
                                T10 = TR10,
                                T11 = TR11,
                                T12 = TR12,

                                totA1 = totA1,
                                totA2 = totA2,
                                totA3 = totA3,
                                totA4 = totA4,
                                totA5 = totA5,
                                totA6 = totA6,
                                totA7 = totA7,
                                totA8 = totA8,
                                totA9 = totA9,
                                totA10 = totA10,
                                totA11 = totA11,
                                totA12 = totA12,

                                totT1 = totT1,
                                totT2 = totT2,
                                totT3 = totT3,
                                totT4 = totT4,
                                totT5 = totT5,
                                totT6 = totT6,
                                totT7 = totT7,
                                totT8 = totT8,
                                totT9 = totT9,
                                totT10 = totT10,
                                totT11 = totT11,
                                totT12 = totT12,

                                totRowA = totalA,
                                totRowT = totalT,

                                totSubRowA = totalA,
                                totSubRowT = totalT,

                                grandtotA = grandtotA,
                                grandtotT = grandtotT


                            });
                        }
                    }

                    if (rdr.HasRows)
                    {
                        lst.Add(new viewCostInv
                        {
                            item = "TOTAL " + tmp2,
                            A1 = subval1,
                            A2 = subval2,
                            A3 = subval3,
                            A4 = subval4,
                            A5 = subval5,
                            A6 = subval6,
                            A7 = subval7,
                            A8 = subval8,
                            A9 = subval9,
                            A10 = subval10,
                            A11 = subval11,
                            A12 = subval12,

                            T1 = subTR1,
                            T2 = subTR2,
                            T3 = subTR3,
                            T4 = subTR4,
                            T5 = subTR5,
                            T6 = subTR6,
                            T7 = subTR7,
                            T8 = subTR8,
                            T9 = subTR9,
                            T10 = subTR10,
                            T11 = subTR11,
                            T12 = subTR12,

                            totA1 = totA1,
                            totA2 = totA2,
                            totA3 = totA3,
                            totA4 = totA4,
                            totA5 = totA5,
                            totA6 = totA6,
                            totA7 = totA7,
                            totA8 = totA8,
                            totA9 = totA9,
                            totA10 = totA10,
                            totA11 = totA11,
                            totA12 = totA12,

                            totT1 = totT1,
                            totT2 = totT2,
                            totT3 = totT3,
                            totT4 = totT4,
                            totT5 = totT5,
                            totT6 = totT6,
                            totT7 = totT7,
                            totT8 = totT8,
                            totT9 = totT9,
                            totT10 = totT10,
                            totT11 = totT11,
                            totT12 = totT12,

                            totRowA = 0,
                            totRowT = 0,

                            totSubRowA = TsubACT,
                            totSubRowT = TsubTGT,

                            grandtotA = grandtotA,
                            grandtotT = grandtotT

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        /*-------------- MAINTENANCE ------------------------*/
        public List<corpdept> vMaintenanceDept(int id, int bln)
        {
            decimal PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct ;
            decimal PicDppGrd, PicDppTrg, PicDppAct, PicAchDpp, PicScrDpp, PicAchDppTmp;
            decimal PicTvbGrd, PicTvbTrg, PicTvbAct, PicAchTvb, PicAchTvbTmp, PicScrTvb;
            decimal PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicRjtGrd, PicRjtTrg, PicRjtAct, PicAchRjtTmp, PicAchRjt, PicScrRjt, PicAirGrd, PicAirTrg, PicAirAct, PicAchAir,PicAchAirTmp, PicScrAir;
            double dPicAchPda, dPicAchPdc, dPicAchRjt, dPicAirAct, dPicTvbAct, dPicDppAct;
            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V3", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Mtn");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) / 12, 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0 && PicPdaAct>0 )
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        dPicAchPda = Convert.ToDouble(PicAchPda);
                        if (dPicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (dPicAchPda > 102 && dPicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (dPicAchPda > 98 && dPicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (dPicAchPda >= 95 && dPicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (dPicAchPda < 95)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]) / 12, 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0 && PicPdcAct > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        dPicAchPdc = Convert.ToDouble(PicAchPdc);
                        if (dPicAchPdc > 110)
                            PicAchPdcTmp = 120;
                        else if (dPicAchPdc > 102 && dPicAchPdc <= 110)
                            PicAchPdcTmp = 110;
                        else if (dPicAchPdc > 95 && dPicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (dPicAchPdc >= 90 && dPicAchPdc <= 95)
                            PicAchPdcTmp = 90;
                        else if (dPicAchPdc < 90)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;

                        // Total Request of CM 
                        if (rdr["PicRjtGrd"] == DBNull.Value)
                            PicRjtGrd = 0;
                        else
                            PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]) / 12, 2);

                        if (rdr["PicRjtTrg"] == DBNull.Value)
                            PicRjtTrg = 0;
                        else
                            PicRjtTrg = Convert.ToDecimal(rdr["PicRjtTrg"]);

                        if (rdr["PicRjtAct"] == DBNull.Value)
                            PicRjtAct = 0;
                        else
                            PicRjtAct = Convert.ToDecimal(rdr["PicRjtAct"]);

                        if (PicRjtTrg > 0 && PicRjtAct > 0)
                            PicAchRjt = (1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100;
                        else
                            PicAchRjt = 0;
                        if (PicAchRjt < 0)
                            PicAchRjt = 0;
                        PicAchRjtTmp = 0;
                        dPicAchRjt = Convert.ToDouble(PicAchRjt);
                        if (PicRjtAct < 60)
                            PicAchRjtTmp = 120;
                        else if (PicRjtAct >= 60 && PicRjtAct <= 84)
                            PicAchRjtTmp = 110;
                        else if (PicRjtAct >= 96 && PicRjtAct <= 108)
                            PicAchRjtTmp = 100;
                        else if (PicRjtAct >= 120 && PicRjtAct <= 144)
                            PicAchRjtTmp = 90;
                        else if (PicRjtAct > 144)
                            PicAchRjtTmp = 60;
                        PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;

                        //-- preventive maintenance  
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) / 12, 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0 && PicAirAct>0)
                            PicAchAir =  PicAirAct / PicAirTrg * 100;
                        else
                            PicAchAir = 0;
                        if (PicAchAir < 0)
                            PicAchAir = 0;
                        PicAchAirTmp = 0;
                        dPicAirAct = Convert.ToDouble(PicAirAct);
                        if (dPicAirAct < 90)
                            PicAchAirTmp = 60;
                        else if (dPicAirAct >= 90 && dPicAirAct < 98)
                            PicAchAirTmp = 90;
                        else if (dPicAirAct >= 98 && dPicAirAct <= 100)
                            PicAchAirTmp = 100;
                        PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        //-- total hour machine 
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) / 12, 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (PicTvbTrg > 0 && PicTvbAct>0)
                            PicAchTvb = (1 + ((PicTvbTrg - PicTvbAct) / PicTvbTrg)) * 100;  
                        else
                            PicAchTvb = 0;
                        if (PicAchTvb < 0)
                            PicAchTvb = 0;
                        PicAchTvbTmp = 0;
                        dPicTvbAct = Convert.ToDouble(PicTvbAct);
                        if (dPicTvbAct < 288)
                            PicAchTvbTmp = 120;
                        else if (dPicTvbAct >= 288 && dPicTvbAct <= 360)
                            PicAchTvbTmp = 110;
                        else if (dPicTvbAct > 360 && dPicTvbAct <= 432)
                            PicAchTvbTmp = 100;
                        else if (dPicTvbAct > 432 && dPicTvbAct <= 576)
                            PicAchTvbTmp = 90;
                        else if (dPicTvbAct > 576)
                            PicAchTvbTmp = 60;
                        PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;

                        //--maintenance cost control - sparepart
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) / 12, 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0 && PicDppAct>0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;

                        if (PicAchDpp < 0)
                            PicAchDpp = 0;

                        PicAchDppTmp = 0;
                        dPicDppAct = Convert.ToDouble(PicDppAct);
                        if (dPicDppAct > 720000012)
                            PicAchDppTmp = 60;
                        else if (dPicDppAct >= 600000012 && dPicDppAct <= 720000012)
                            PicAchDppTmp = 90;
                        else if (dPicDppAct >= 420000012 && dPicDppAct < 600000012)
                            PicAchDppTmp = 100;
                        else if (dPicDppAct >= 180000012 && dPicDppAct < 420000012)
                            PicAchDppTmp = 110;
                        else if (dPicDppAct < 180000012)
                            PicAchDppTmp = 120;

                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;


                        //---TotalGrade + SCORE---
                        NilaiGlobal.TotGrade =  PicPdaGrd + PicPdcGrd + PicRjtGrd + PicAirGrd + PicTvbGrd + PicDppGrd ;
                        NilaiGlobal.TotScore =  PicScrPda + PicScrPdc + PicScrRjt + PicScrAir + PicScrTvb + PicScrDpp ;
                        lst.Add(new corpdept
                        {

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = PicRjtTrg,
                            PicActRjt = PicRjtAct,
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = Convert.ToDecimal(PicAchAir),
                            PicScrAir = PicScrAir,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = Convert.ToDecimal(PicAchTvb),
                            PicScrTvb = PicScrTvb,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = Convert.ToDecimal(PicAchDpp),
                            PicScrDpp = PicScrDpp,

                            TotGrade = NilaiGlobal.TotGrade,
                            TotScore = NilaiGlobal.TotScore


                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corpdept> vMaintenanceDeptSummary(int id, int bln, char ch)
        {
            decimal PicPdaGrd, PicPdaTrg, PicPdaAct, PicPdcGrd, PicPdcTrg, PicPdcAct;
            decimal PicDppGrd, PicDppTrg, PicDppAct, PicAchDpp, PicScrDpp, PicAchDppTmp;
            decimal PicTvbGrd, PicTvbTrg, PicTvbAct, PicAchTvb, PicAchTvbTmp, PicScrTvb;
            decimal PicAchPda, PicAchPdaTmp, PicScrPda, PicAchPdc, PicAchPdcTmp, PicScrPdc;
            decimal PicRjtGrd, PicRjtTrg, PicRjtAct, PicAchRjtTmp, PicAchRjt, PicScrRjt, PicAirGrd, PicAirTrg, PicAirAct, PicAchAir, PicAchAirTmp, PicScrAir;
            double dPicAchPda, dPicAchPdc, dPicAchRjt, dPicAirAct, dPicTvbAct, dPicDppAct;

            List<corpdept> lst = new List<corpdept>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI_Dept_V3", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.Parameters.AddWithValue("@MONTH", bln);
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 'M')
                    com.Parameters.AddWithValue("@Action", "MtnMonth");
                else if (ch == 'Y') com.Parameters.AddWithValue("@Action", "MtnYear");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // pda
                        if (rdr["PicPdaGrd"] == DBNull.Value)
                            PicPdaGrd = 0;
                        else
                            PicPdaGrd = Math.Round(Convert.ToDecimal(rdr["PicPdaGrd"]) , 2);

                        if (rdr["PicPdaTrg"] == DBNull.Value)
                            PicPdaTrg = 0;
                        else
                            PicPdaTrg = Convert.ToDecimal(rdr["PicPdaTrg"]);

                        if (rdr["PicPdaAct"] == DBNull.Value)
                            PicPdaAct = 0;
                        else
                            PicPdaAct = Convert.ToDecimal(rdr["PicPdaAct"]);

                        if (PicPdaTrg > 0 && PicPdaAct > 0)
                            PicAchPda = PicPdaAct / PicPdaTrg * 100;
                        else
                            PicAchPda = 0;
                        PicAchPdaTmp = 0;
                        dPicAchPda = Convert.ToDouble(PicAchPda);
                        if (dPicAchPda > 110)
                            PicAchPdaTmp = 120;
                        else if (dPicAchPda > 102 && dPicAchPda <= 110)
                            PicAchPdaTmp = 110;
                        else if (dPicAchPda > 98 && dPicAchPda <= 102)
                            PicAchPdaTmp = 100;
                        else if (dPicAchPda >= 95 && dPicAchPda <= 98)
                            PicAchPdaTmp = 90;
                        else if (dPicAchPda < 95)
                            PicAchPdaTmp = 60;
                        PicScrPda = PicPdaGrd * PicAchPdaTmp / 100;

                        // pdc
                        if (rdr["PicPdcGrd"] == DBNull.Value)
                            PicPdcGrd = 0;
                        else
                            PicPdcGrd = Math.Round(Convert.ToDecimal(rdr["PicPdcGrd"]), 2);

                        if (rdr["PicPdcTrg"] == DBNull.Value)
                            PicPdcTrg = 0;
                        else
                            PicPdcTrg = Convert.ToDecimal(rdr["PicPdcTrg"]);

                        if (rdr["PicPdcAct"] == DBNull.Value)
                            PicPdcAct = 0;
                        else
                            PicPdcAct = Convert.ToDecimal(rdr["PicPdcAct"]);

                        if (PicPdcTrg > 0 && PicPdcAct > 0)
                            PicAchPdc = PicPdcAct / PicPdcTrg * 100;
                        else
                            PicAchPdc = 0;
                        PicAchPdcTmp = 0;
                        dPicAchPdc = Convert.ToDouble(PicAchPdc);
                        if (dPicAchPdc > 110)
                            PicAchPdcTmp = 120;
                        else if (dPicAchPdc > 102 && dPicAchPdc <= 110)
                            PicAchPdcTmp = 110;
                        else if (dPicAchPdc > 95 && dPicAchPdc <= 102)
                            PicAchPdcTmp = 100;
                        else if (dPicAchPdc >= 90 && dPicAchPdc <= 95)
                            PicAchPdcTmp = 90;
                        else if (dPicAchPdc < 90)
                            PicAchPdcTmp = 60;
                        PicScrPdc = PicPdcGrd * PicAchPdcTmp / 100;

                        // Total Request of CM 
                        if (rdr["PicRjtGrd"] == DBNull.Value)
                            PicRjtGrd = 0;
                        else
                            PicRjtGrd = Math.Round(Convert.ToDecimal(rdr["PicRjtGrd"]) , 2);

                        if (rdr["PicRjtTrg"] == DBNull.Value)
                            PicRjtTrg = 0;
                        else
                            PicRjtTrg = Convert.ToDecimal(rdr["PicRjtTrg"]);

                        if (rdr["PicRjtAct"] == DBNull.Value)
                            PicRjtAct = 0;
                        else
                            PicRjtAct = Convert.ToDecimal(rdr["PicRjtAct"]);

                        if (PicRjtTrg > 0 && PicRjtAct > 0)
                            PicAchRjt = (1 + ((PicRjtTrg - PicRjtAct) / PicRjtTrg)) * 100;
                        else
                            PicAchRjt = 0;
                        if (PicAchRjt < 0)
                            PicAchRjt = 0;
                        PicAchRjtTmp = 0;
                        dPicAchRjt = Convert.ToDouble(PicAchRjt);
                        if (PicRjtAct < 5)
                            PicAchRjtTmp = 120;
                        else if (PicRjtAct >= 5 && PicRjtAct <= 7)
                            PicAchRjtTmp = 110;
                        else if (PicRjtAct >= 8 && PicRjtAct <= 9)
                            PicAchRjtTmp = 100;
                        else if (PicRjtAct >= 10 && PicRjtAct <= 12)
                            PicAchRjtTmp = 90;
                        else if (PicRjtAct > 12)
                            PicAchRjtTmp = 60;
                        PicScrRjt = PicRjtGrd * PicAchRjtTmp / 100;

                        //-- preventive maintenance  
                        if (rdr["PicAirGrd"] == DBNull.Value)
                            PicAirGrd = 0;
                        else
                            PicAirGrd = Math.Round(Convert.ToDecimal(rdr["PicAirGrd"]) , 2);

                        if (rdr["PicAirTrg"] == DBNull.Value)
                            PicAirTrg = 0;
                        else
                            PicAirTrg = Convert.ToDecimal(rdr["PicAirTrg"]);

                        if (rdr["PicAirAct"] == DBNull.Value)
                            PicAirAct = 0;
                        else
                            PicAirAct = Convert.ToDecimal(rdr["PicAirAct"]);

                        if (PicAirTrg > 0 && PicAirAct > 0)
                            PicAchAir = PicAirAct / PicAirTrg * 100;
                        else
                            PicAchAir = 0;
                        if (PicAchAir < 0)
                            PicAchAir = 0;
                        PicAchAirTmp = 0;
                        dPicAirAct = Convert.ToDouble(PicAirAct);
                        if (dPicAirAct < 90)
                            PicAchAirTmp = 60;
                        else if (dPicAirAct >= 90 && dPicAirAct < 98)
                            PicAchAirTmp = 90;
                        else if (dPicAirAct >= 98 && dPicAirAct <= 100)
                            PicAchAirTmp = 100;
                        PicScrAir = PicAirGrd * PicAchAirTmp / 100;

                        //-- total hour machine 
                        if (rdr["PicTvbGrd"] == DBNull.Value)
                            PicTvbGrd = 0;
                        else
                            PicTvbGrd = Math.Round(Convert.ToDecimal(rdr["PicTvbGrd"]) , 2);

                        if (rdr["PicTvbTrg"] == DBNull.Value)
                            PicTvbTrg = 0;
                        else
                            PicTvbTrg = Convert.ToDecimal(rdr["PicTvbTrg"]);

                        if (rdr["PicTvbAct"] == DBNull.Value)
                            PicTvbAct = 0;
                        else
                            PicTvbAct = Convert.ToDecimal(rdr["PicTvbAct"]);

                        if (PicTvbTrg > 0 && PicTvbAct > 0)
                            PicAchTvb = (1 + ((PicTvbTrg - PicTvbAct) / PicTvbTrg)) * 100;
                        else
                            PicAchTvb = 0;
                        if (PicAchTvb < 0)
                            PicAchTvb = 0;
                        PicAchTvbTmp = 0;
                        dPicTvbAct = Convert.ToDouble(PicTvbAct);
                        if (dPicTvbAct < 24)
                            PicAchTvbTmp = 120;
                        else if (dPicTvbAct >= 24 && dPicTvbAct <= 30)
                            PicAchTvbTmp = 110;
                        else if (dPicTvbAct > 30 && dPicTvbAct <= 36)
                            PicAchTvbTmp = 100;
                        else if (dPicTvbAct > 36 && dPicTvbAct <= 48)
                            PicAchTvbTmp = 90;
                        else if (dPicTvbAct > 48)
                            PicAchTvbTmp = 60;
                        PicScrTvb = PicTvbGrd * PicAchTvbTmp / 100;

                        //--maintenance cost control - sparepart
                        if (rdr["PicDppGrd"] == DBNull.Value)
                            PicDppGrd = 0;
                        else
                            PicDppGrd = Math.Round(Convert.ToDecimal(rdr["PicDppGrd"]) , 2);

                        if (rdr["PicDppTrg"] == DBNull.Value)
                            PicDppTrg = 0;
                        else
                            PicDppTrg = Convert.ToDecimal(rdr["PicDppTrg"]);

                        if (rdr["PicDppAct"] == DBNull.Value)
                            PicDppAct = 0;
                        else
                            PicDppAct = Convert.ToDecimal(rdr["PicDppAct"]);

                        if (PicDppTrg > 0 && PicDppAct > 0)
                            PicAchDpp = (1 + ((PicDppTrg - PicDppAct) / PicDppTrg)) * 100;
                        else
                            PicAchDpp = 0;

                        if (PicAchDpp < 0)
                            PicAchDpp = 0;

                        PicAchDppTmp = 0;
                        dPicDppAct = Convert.ToDouble(PicDppAct);
                        if (dPicDppAct > 60000001)
                            PicAchDppTmp = 60;
                        else if (dPicDppAct >= 50000001 && dPicDppAct <= 60000001)
                            PicAchDppTmp = 90;
                        else if (dPicDppAct >= 35000001 && dPicDppAct < 50000001)
                            PicAchDppTmp = 100;
                        else if (dPicDppAct >= 15000001 && dPicDppAct < 35000001)
                            PicAchDppTmp = 110;
                        else if (dPicDppAct < 15000000)
                            PicAchDppTmp = 120;

                        PicScrDpp = PicDppGrd * PicAchDppTmp / 100;


                        //---TotalGrade + SCORE---
                        NilaiGlobal.TotGrade = PicPdaGrd + PicPdcGrd + PicRjtGrd + PicAirGrd + PicTvbGrd + PicDppGrd;
                        NilaiGlobal.TotScore = PicScrPda + PicScrPdc + PicScrRjt + PicScrAir + PicScrTvb + PicScrDpp;
                        lst.Add(new corpdept
                        {

                            PicGrdPda = PicPdaGrd,
                            PicTgtPda = PicPdaTrg,
                            PicActPda = PicPdaAct,
                            PicAchPda = PicAchPda,
                            PicScrPda = PicScrPda,

                            PicGrdPdc = PicPdcGrd,
                            PicTgtPdc = PicPdcTrg,
                            PicActPdc = PicPdcAct,
                            PicAchPdc = PicAchPdc,
                            PicScrPdc = PicScrPdc,

                            PicGrdRjt = PicRjtGrd,
                            PicTgtRjt = PicRjtTrg,
                            PicActRjt = PicRjtAct,
                            PicAchRjt = Convert.ToDecimal(PicAchRjt),
                            PicScrRjt = PicScrRjt,

                            PicGrdAir = PicAirGrd,
                            PicTgtAir = PicAirTrg,
                            PicActAir = PicAirAct,
                            PicAchAir = Convert.ToDecimal(PicAchAir),
                            PicScrAir = PicScrAir,

                            PicGrdTvb = PicTvbGrd,
                            PicTgtTvb = PicTvbTrg,
                            PicActTvb = PicTvbAct,
                            PicAchTvb = Convert.ToDecimal(PicAchTvb),
                            PicScrTvb = PicScrTvb,

                            PicGrdDpp = PicDppGrd,
                            PicTgtDpp = PicDppTrg,
                            PicActDpp = PicDppAct,
                            PicAchDpp = Convert.ToDecimal(PicAchDpp),
                            PicScrDpp = PicScrDpp,

                            TotGrade = NilaiGlobal.TotGrade,
                            TotScore = NilaiGlobal.TotScore


                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        /*-------------- WAREHOUSE PPIC CONTROL ------------------------*/
        public List<viewPpicControl> vRptWarehouseControl(int ch)
        {
            //double dberat, dwax, ddipping, dceramic, dfinishing, dstokawalcasting, dtotMR, dtotmach, dstokawalfinished, dtotterkirim, 
            List<viewPpicControl> lst = new List<viewPpicControl>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand com = new SqlCommand("Extranet_PPIC_Conrtrol", con);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                if (ch == 1)
                    com.Parameters.AddWithValue("@Action", "ControlNonAss");
                else if (ch == 2)
                    com.Parameters.AddWithValue("@Action", "ControlAss");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        //if (rdr["igrossweight"] == DBNull.Value)
                        //    dberat = 0;
                        //else
                        //    dberat = Math.Round(Convert.ToDecimal(rdr["igrossweight"]));


                        lst.Add(new viewPpicControl
                        {
                            prodcode = rdr["PRODUCTCODE"].ToString(),
                            cust = rdr["cust"].ToString(),
                            item = rdr["item"].ToString(),
                            material = rdr["cgradematerial"].ToString(),
                            berat = Convert.ToDouble(rdr["igrossweight"]),
                            wax = Convert.ToDouble(rdr["wax"]),
                            dipping = Convert.ToDouble(rdr["dipping"]),
                            ceramic = Convert.ToDouble(rdr["ceramic"]),
                            finishing = Convert.ToDouble(rdr["finishing"]),
                            stokawalcasting = Convert.ToDouble(rdr["stokcasting"]),
                            totMR = Convert.ToDouble(rdr["qtypda"]),
                            totmach = Convert.ToDouble(rdr["wipmach"]),
                            stokawalfinished = Convert.ToDouble(rdr["stokproduct"]),
                            totterkirim = Convert.ToDouble(rdr["qtypdb"]),
                            sisaPO = Convert.ToInt32(rdr["sisaPO"]),
                            edd = string.Format("{0:dd-MM-yyyy }", rdr["EDD"])
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewPpicControl> vShowProd(int code)
        {
            List<viewPpicControl> lst = new List<viewPpicControl>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand com = new SqlCommand("Extranet_PPIC_Conrtrol", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ProdCode", code);
                com.Parameters.AddWithValue("@Action", "ShowProdCode");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPpicControl
                        {
                            item = rdr["code"].ToString(),
                            wax = Convert.ToDouble(rdr["sisa"])
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*-------------------Stock Pr Po Inv-------------------------------*/
        public List<viewPpicControl> vRptStockPrPo()
        {
            List<viewPpicControl> lst = new List<viewPpicControl>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_PPIC_Conrtrol", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "ShowStokPrPo");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPpicControl
                        {
                            item = rdr["Account"].ToString(),
                            prodcode = rdr["ItemName"].ToString(),
                            stokawalcasting = Convert.ToDouble(rdr["Stock"]),
                            stokawalfinished = Convert.ToDouble(rdr["SisaPR"]),
                            totterkirim = Convert.ToDouble(rdr["SisaPO"]),

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*-------------------Stock Pr Po Inv-------------------------------*/
        public List<viewPpicControl> vRptPPICCntrlProduct()
        {
            List<viewPpicControl> lst = new List<viewPpicControl>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_PPIC_Conrtrol", con);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "ALLPRODUCT");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPpicControl
                        {
                            prodcode = rdr["PRODID"].ToString(),
                            item = rdr["PRODNAME"].ToString(),
                            stokawalcasting = Convert.ToDouble(rdr["STOCK"]),
                            stokawalfinished = Convert.ToDouble(rdr["SISAPO"])

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*-------------------PIVOT MATERIAL RECEIVING vRptPPICCntrlOutPomat-------------------------------*/
        public List<viewTable> vRptPPICCntrlOutPomat(int year)
        {
            decimal val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, total=0;
            List<viewTable> lst = new List<viewTable>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_PPIC_Conrtrol", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEARPAR", year);
                com.Parameters.AddWithValue("@Action", "OUTPOMAT");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["Jan"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["Jan"]));

                        if (rdr["Feb"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["Feb"]));

                        if (rdr["Mar"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["Mar"]));

                        if (rdr["Apr"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["Apr"]));


                        if (rdr["May"] == DBNull.Value)
                            val5 = 0;
                        else
                            val5 = Math.Round(Convert.ToDecimal(rdr["May"]));

                        if (rdr["Jun"] == DBNull.Value)
                            val6 = 0;
                        else
                            val6 = Math.Round(Convert.ToDecimal(rdr["Jun"]));

                        if (rdr["Jul"] == DBNull.Value)
                            val7 = 0;
                        else
                            val7 = Math.Round(Convert.ToDecimal(rdr["Jul"]));

                        if (rdr["Aug"] == DBNull.Value)
                            val8 = 0;
                        else
                            val8 = Math.Round(Convert.ToDecimal(rdr["Aug"]));

                        if (rdr["Sep"] == DBNull.Value)
                            val9 = 0;
                        else
                            val9 = Math.Round(Convert.ToDecimal(rdr["Sep"]));

                        if (rdr["Oct"] == DBNull.Value)
                            val10 = 0;
                        else
                            val10 = Math.Round(Convert.ToDecimal(rdr["Oct"]));

                        if (rdr["Nov"] == DBNull.Value)
                            val11 = 0;
                        else
                            val11 = Math.Round(Convert.ToDecimal(rdr["Nov"]));

                        if (rdr["Dec"] == DBNull.Value)
                            val12 = 0;
                        else
                            val12 = Math.Round(Convert.ToDecimal(rdr["Dec"]));

                        total = val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12;

                        lst.Add(new viewTable
                        {
                            remark = rdr["groups"].ToString(),
                            jan = val1,
                            feb = val2,
                            mar = val3,
                            apr = val4,
                            may = val5,
                            jun = val6,
                            jul = val7,
                            aug = val8,
                            sep = val9,
                            oct = val10,
                            nov = val11,
                            dec = val12,
                            tot = total
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        /*-------------------PIVOT Report Outstanding PO Detail vRptOutPoDetailResult-------------------------------*/
        public List<viewPODetail> vRptOutPoDetailResult(int year)
        {
            decimal val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15, total = 0;
            decimal gross, rate, backlog;
            decimal amountBL=0, amountW1=0, amountW2=0, amountW3=0, amountW4=0, amountW5=0, amountW6=0, amountW7=0, amountW8=0, amountW9=0, amountW10=0, amountW11=0, amountW12=0, amountW13=0, amountW14=0, amountW15=0;
            decimal tonaseBL=0, tonaseW1=0, tonaseW2=0, tonaseW3=0, tonaseW4=0, tonaseW5=0, tonaseW6=0, tonaseW7=0, tonaseW8=0, tonaseW9=0, tonaseW10=0, tonaseW11=0, tonaseW12=0, tonaseW13=0, tonaseW14=0, tonaseW15=0;
            decimal amountTot=0, tonaseTot=0;

            List<viewPODetail> lst = new List<viewPODetail>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_PPIC_Conrtrol", con);
                com.CommandTimeout = 0;
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEARPAR", year);
                com.Parameters.AddWithValue("@Action", "OUTPODETAILS");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["Week1"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["Week1"]));

                        if (rdr["Week2"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["Week2"]));

                        if (rdr["Week3"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["Week3"]));

                        if (rdr["Week4"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["Week4"]));


                        if (rdr["Week5"] == DBNull.Value)
                            val5 = 0;
                        else
                            val5 = Math.Round(Convert.ToDecimal(rdr["Week5"]));

                        if (rdr["Week6"] == DBNull.Value)
                            val6 = 0;
                        else
                            val6 = Math.Round(Convert.ToDecimal(rdr["Week6"]));

                        if (rdr["Week7"] == DBNull.Value)
                            val7 = 0;
                        else
                            val7 = Math.Round(Convert.ToDecimal(rdr["Week7"]));

                        if (rdr["Week8"] == DBNull.Value)
                            val8 = 0;
                        else
                            val8 = Math.Round(Convert.ToDecimal(rdr["Week8"]));

                        if (rdr["Week9"] == DBNull.Value)
                            val9 = 0;
                        else
                            val9 = Math.Round(Convert.ToDecimal(rdr["Week9"]));

                        if (rdr["Week10"] == DBNull.Value)
                            val10 = 0;
                        else
                            val10 = Math.Round(Convert.ToDecimal(rdr["Week10"]));

                        if (rdr["Week11"] == DBNull.Value)
                            val11 = 0;
                        else
                            val11 = Math.Round(Convert.ToDecimal(rdr["Week11"]));

                        if (rdr["Week12"] == DBNull.Value)
                            val12 = 0;
                        else
                            val12 = Math.Round(Convert.ToDecimal(rdr["Week12"]));

                        if (rdr["Week13"] == DBNull.Value)
                            val13 = 0;
                        else
                            val13 = Math.Round(Convert.ToDecimal(rdr["Week13"]));

                        if (rdr["Week14"] == DBNull.Value)
                            val14 = 0;
                        else
                            val14 = Math.Round(Convert.ToDecimal(rdr["Week14"]));

                        if (rdr["Week15"] == DBNull.Value)
                            val15 = 0;
                        else
                            val15 = Math.Round(Convert.ToDecimal(rdr["Week15"]));

                        if (rdr["Week15"] == DBNull.Value)
                            val15 = 0;
                        else
                            val15 = Math.Round(Convert.ToDecimal(rdr["Week15"]));

                        if (rdr["igrossweight"] == DBNull.Value)
                            gross = 0;
                        else
                            gross = Math.Round(Convert.ToDecimal(rdr["igrossweight"]));

                        if (rdr["rateprice"] == DBNull.Value)
                            rate = 0;
                        else
                            rate = Math.Round(Convert.ToDecimal(rdr["rateprice"]));

                        if (rdr["BackLog"] == DBNull.Value)
                            backlog = 0;
                        else
                            backlog = Math.Round(Convert.ToDecimal(rdr["BackLog"]));

                        total = backlog +val1 + val2 + val3 + val4 + val5 + val6 + val7 + val8 + val9 + val10 + val11 + val12 + val13 + val14 + val15;

                        amountBL = amountBL + (backlog*rate) ;
                        tonaseBL = tonaseBL + (backlog*gross);
                        amountW1 = amountW1 + (val1 * rate); amountW6 = amountW6 + (val6 * rate); amountW11 = amountW11 + (val11 * rate);
                        tonaseW1 = tonaseW1 + (val1 * gross); tonaseW6 = tonaseW6 + (val6 * gross); tonaseW11 = tonaseW11 + (val11 * gross);
                        amountW2 = amountW2 + (val2 * rate); amountW7 = amountW7 + (val7 * rate); amountW12 = amountW12 + (val12 * rate);
                        tonaseW2 = tonaseW2 + (val2 * gross); tonaseW7 = tonaseW7 + (val7 * gross); tonaseW12 = tonaseW12 + (val12 * gross);
                        amountW3 = amountW3 + (val3 * rate); amountW8 = amountW8 + (val8 * rate); amountW13 = amountW13 + (val13 * rate);
                        tonaseW3 = tonaseW3 + (val3 * gross); tonaseW8 = tonaseW8 + (val8 * gross); tonaseW13 = tonaseW13 + (val13 * gross);
                        amountW4 = amountW4 + (val4 * rate); amountW9 = amountW9 + (val9 * rate); amountW14 = amountW14 + (val14 * rate);
                        tonaseW4 = tonaseW4 + (val4 * gross); tonaseW9 = tonaseW9 + (val9 * gross); tonaseW14 = tonaseW14 + (val14 * gross);
                        amountW5 = amountW5 + (val5 * rate); amountW10 = amountW10 + (val10 * rate); amountW15 = amountW15 + (val15 * rate);
                        tonaseW5 = tonaseW5 + (val5 * gross); tonaseW10 = tonaseW10 + (val10 * gross); tonaseW15 = tonaseW15 + (val15 * gross);


                        lst.Add(new viewPODetail
                        {
                            cust = rdr["cust"].ToString(),
                            id = Convert.ToInt32(rdr["id"]),
                            item = rdr["nama"].ToString(),
                            gross = gross,
                            rate = rate,
                            backlog= backlog,
                            C1 = val1,
                            C2 = val2,
                            C3 = val3,
                            C4 = val4,
                            C5 = val5,
                            C6 = val6,
                            C7 = val7,
                            C8 = val8,
                            C9 = val9,
                            C10 = val10,
                            C11 = val11,
                            C12 = val12,
                            C13 = val13,
                            C14 = val14,
                            C15 = val15,
                            tot = total
                        });

                    }

                    if (rdr.HasRows)
                    {
                        amountTot = amountBL + amountW1 + amountW2 + amountW3 + amountW4 + amountW5 + amountW6 + amountW7 + amountW8 + amountW9 + amountW10 + amountW11 + amountW12 + amountW13 + amountW14 + amountW15;
                        tonaseTot = tonaseBL + tonaseW1 + tonaseW2 + tonaseW3 + tonaseW4 + tonaseW5 + tonaseW6 + tonaseW7 + tonaseW8 + tonaseW9 + tonaseW10 + tonaseW11 + tonaseW12 + tonaseW13 + tonaseW14 + tonaseW15;
                        lst.Add(new viewPODetail
                        {
                            item = "AMOUNT",
                            backlog = amountBL,
                            cust = "",
                            gross = 0,
                            rate = 0,
                            C1 = amountW1,
                            C2 = amountW2,
                            C3 = amountW3,
                            C4 = amountW4,
                            C5 = amountW5,
                            C6 = amountW6,
                            C7 = amountW7,
                            C8 = amountW8,
                            C9 = amountW9,
                            C10 = amountW10,
                            C11 = amountW11,
                            C12 = amountW12,
                            C13 = amountW13,
                            C14 = amountW14,
                            C15 = amountW15,
                            tot = amountTot
                        });
                        lst.Add(new viewPODetail
                        {
                            item = "TONNAGE",
                            backlog = tonaseBL,
                            cust = "",
                            gross = 0,
                            rate = 0,
                            C1 = tonaseW1,
                            C2 = tonaseW2,
                            C3 = tonaseW3,
                            C4 = tonaseW4,
                            C5 = tonaseW5,
                            C6 = tonaseW6,
                            C7 = tonaseW7,
                            C8 = tonaseW8,
                            C9 = tonaseW9,
                            C10 = tonaseW10,
                            C11 = tonaseW11,
                            C12 = tonaseW12,
                            C13 = tonaseW13,
                            C14 = tonaseW14,
                            C15 = tonaseW15,
                            tot = tonaseTot
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*------------------Graphic Production---------------------------*/
        private static string GetMonthName(int month)
        {

            DateTime date = new DateTime(2010, month, 1);
            return date.ToString("MMMM");

        }

        public List<viewGrap> vGrapOutputPouring(int thn, int bln)
        {
            byte iTgl;
            string nmbul, gabbul, cTgl;
            nmbul = GetMonthName(bln).Substring(0,3);  
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "Pouring");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        iTgl = Convert.ToByte(rdr["tgl"]);
                        if (iTgl < 10)
                            cTgl = String.Concat('0', iTgl);
                        else cTgl = iTgl.ToString();
                        gabbul = String.Concat(cTgl, "-", nmbul);
                        lst.Add(new viewGrap
                        {
                            tgl = gabbul,
                            totbrtpouring = Math.Round(Convert.ToDouble(rdr["totalberat"]),2),
                            trgpouring = Math.Round(Convert.ToDouble(rdr["targetpouring"]),2),
                            totheatpouring = Convert.ToDouble(rdr["totalheat"]),
                            kumbrtpouring = Math.Round(Convert.ToDouble(rdr["kumberat"]),2),
                            kumtrgpouring = Math.Round(Convert.ToDouble(rdr["kumtargetpouring"]),2),
                            kumheatpouring = Convert.ToDouble(rdr["kumheat"])

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewGrap> vLastRowPouring(int thn, int bln)
        {
            double kumbrtpouring=0, kumtrgpouring=0, hsllastrow=0;
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "Pouring");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        kumbrtpouring = Convert.ToDouble(rdr["kumberat"]);
                        kumtrgpouring = Convert.ToDouble(rdr["kumtargetpouring"]);
                    }
                    if (rdr.HasRows)
                    {
                        hsllastrow = kumbrtpouring - kumtrgpouring;
                        lst.Add(new viewGrap
                        {
                            
                            lastrowpouring = Math.Round(hsllastrow,2)

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewGrap> vGrapOutputPda(int thn, int bln)
        {
            byte iTgl;
            string nmbul, gabbul, cTgl;
            nmbul = GetMonthName(bln).Substring(0, 3);
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "PDA");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        iTgl = Convert.ToByte(rdr["tgl"]);
                        if (iTgl < 10)
                            cTgl = String.Concat('0', iTgl);
                        else cTgl = iTgl.ToString();
                        gabbul = String.Concat(cTgl, "-", nmbul);
                        lst.Add(new viewGrap
                        {
                            tgl = gabbul,
                            totalpda = Math.Round(Convert.ToDouble(rdr["totalpda"]),2),
                            targetpda = Math.Round(Convert.ToDouble(rdr["targetpda"]),2),
                            kumpda = Math.Round(Convert.ToDouble(rdr["kumpda"]),2),
                            kumtargetpda = Math.Round(Convert.ToDouble(rdr["kumtargetpda"]),2)

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewGrap> vLastRowPDA(int thn, int bln)
        {
            double kumpda = 0, kumtrgppda = 0, hsllastrow = 0;
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "PDA");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        kumpda = Convert.ToDouble(rdr["kumpda"]);
                        kumtrgppda = Convert.ToDouble(rdr["kumtargetpda"]);
                    }
                    if (rdr.HasRows)
                    {
                        hsllastrow = kumpda - kumtrgppda;
                        lst.Add(new viewGrap
                        {

                            lastrowpda = Math.Round(hsllastrow, 2)

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewGrap> vGrapOutputPdb(int thn, int bln)
        {
            byte iTgl;
            string nmbul, gabbul, cTgl;
            nmbul = GetMonthName(bln).Substring(0, 3);
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "PDB");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        iTgl = Convert.ToByte(rdr["tgl"]);
                        if (iTgl < 10)
                            cTgl = String.Concat('0', iTgl);
                        else cTgl = iTgl.ToString();
                        gabbul = String.Concat(cTgl, "-", nmbul);
                        lst.Add(new viewGrap
                        {
                            tgl = gabbul,
                            totalpdb = Math.Round(Convert.ToDouble(rdr["totalpdb"]),2),
                            targetpdb = Math.Round(Convert.ToDouble(rdr["targetpdb"]),2),
                            kumpdb = Math.Round(Convert.ToDouble(rdr["kumpdb"]),2),
                            kumtargetpdb = Math.Round(Convert.ToDouble(rdr["kumtargetpdb"]),2)

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewGrap> vLastRowPDB(int thn, int bln)
        {
            double kumpdb = 0, kumtrgppdb = 0, hsllastrow = 0;
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "PDB");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        kumpdb = Convert.ToDouble(rdr["kumpdb"]);
                        kumtrgppdb = Convert.ToDouble(rdr["kumtargetpdb"]);
                    }
                    if (rdr.HasRows)
                    {
                        hsllastrow = kumpdb - kumtrgppdb;
                        lst.Add(new viewGrap
                        {

                            lastrowpdb = Math.Round(hsllastrow, 2)

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewGrap> vGrapOutputWIP(int thn, int bln)
        {
            byte iTgl;
            string nmbul, gabbul, cTgl;
            nmbul = GetMonthName(bln).Substring(0, 3);
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "WIP");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        iTgl = Convert.ToByte(rdr["hari"]);
                        if (iTgl < 10)
                            cTgl = String.Concat('0', iTgl);
                        else cTgl = iTgl.ToString();
                        gabbul = String.Concat(cTgl, "-", nmbul);
                        lst.Add(new viewGrap
                        {
                            tgl = gabbul,
                            totalwip = Convert.ToDouble(rdr["totwip"])

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewGrap> vGrapPouringVSPda(int thn, int bln)
        {
            byte iTgl;
            string nmbul, gabbul, cTgl;
            nmbul = GetMonthName(bln).Substring(0, 3);
            List<viewGrap> lst = new List<viewGrap>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_Sp_GraphProduksi", con);
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 0;
                com.Parameters.AddWithValue("@year", thn);
                com.Parameters.AddWithValue("@month", bln);
                com.Parameters.AddWithValue("@Action", "PouringVsPDA");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        iTgl = Convert.ToByte(rdr["tgl"]);
                        if (iTgl < 10)
                            cTgl = String.Concat('0', iTgl);
                        else cTgl = iTgl.ToString();
                        gabbul = String.Concat(cTgl, "-", nmbul);
                        lst.Add(new viewGrap
                        {
                            tgl = gabbul,
                            totbrtpouring = Math.Round(Convert.ToDouble(rdr["kumpouring"]),2),
                            totalpda = Math.Round(Convert.ToDouble(rdr["kumpda"]),2),
                            trgpouring = Math.Round(Convert.ToDouble(rdr["actualpouring"]), 2),
                            targetpda = Math.Round(Convert.ToDouble(rdr["actualpda"]), 2),

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        /*------------------End Graphic Production-----------------------*/

        /*------------------Margin Customer-----------------------*/

        /*------------------End Margin Customer-----------------------*/
        public List<viewMargin> vMarginTotal(int thn, int bln)
        {
            decimal val1;
            List<viewMargin> lst = new List<viewMargin>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mMargin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEARPAR", thn);
                com.Parameters.AddWithValue("@MONTHPAR", bln);
                com.Parameters.AddWithValue("@Action", "TOTAL");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["total"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["total"]), 2);

                        lst.Add(new viewMargin
                        {
                            num1 =val1

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewMargin> vMarginProsen(int thn, int bln)
        {
            decimal val1;
            string nm;
            List<viewMargin> lst = new List<viewMargin>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mMargin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEARPAR", thn);
                com.Parameters.AddWithValue("@MONTHPAR", bln);
                com.Parameters.AddWithValue("@Action", "ProsenMargin");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["margin"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["margin"]), 2);

                        if (rdr["Cust"] == DBNull.Value)
                            nm = "";
                        else
                            nm = rdr["Cust"].ToString();

                        lst.Add(new viewMargin
                        {
                            cust = nm,
                            num1 = val1

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<viewMargin> vMarginDetail(int thn, int bln)
        {
            decimal val1, val2, val3, val4;
            string cd,cus,prd;
            List<viewMargin> lst = new List<viewMargin>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mMargin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEARPAR", thn);
                com.Parameters.AddWithValue("@MONTHPAR", bln);
                com.Parameters.AddWithValue("@Action", "DtlMargin");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["qty"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["qty"]), 2);

                        if (rdr["amount"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["amount"]), 2);

                        if (rdr["hpp"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["hpp"]), 2);

                        if (rdr["margin"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["margin"]), 2);


                        if (rdr["code"] == DBNull.Value)
                            cd = "";
                        else
                            cd = rdr["code"].ToString();

                        if (rdr["Cust"] == DBNull.Value)
                            cus = "";
                        else
                            cus = rdr["Cust"].ToString();

                        if (rdr["Product"] == DBNull.Value)
                            prd = "";
                        else
                            prd = rdr["Product"].ToString();


                        lst.Add(new viewMargin
                        {
                            code = cd,
                            cust = cus,
                            product = prd,
                            num1 = val1,
                            num2 = val2,
                            num3 = val3,
                            num4 = val4  

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*------------------Survey Customer-----------------------*/
        public List<viewSurvey> vSurveyPeriod()
        {
            string dateAdd, period1, period2;
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Rpt_ShowPrd");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        period1 = string.Format("{0:dd-MM-yyyy}", rdr["dateStart"]);
                        period2 = string.Format("{0:dd-MM-yyyy}", rdr["dateStop"]);
                        dateAdd = period1 + " s/d " + period2;
                        lst.Add(new viewSurvey
                        {
                            //idsurvey, dateStart, dateStop
                            id = Convert.ToInt32(rdr["idsurvey"]),
                            dateSurvey = dateAdd

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyCount(int idsurvey)
        {
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_CountSurvey");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lst.Add(new viewSurvey
                        {
                            int1 = Convert.ToInt32(rdr["int1"]),

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyCountCust(int idsurvey)
        {
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_CountCust");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lst.Add(new viewSurvey
                        {
                            Customer = rdr["cCustName"].ToString()

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyProsenLog(int idsurvey)
        {
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_ProsenLog");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lst.Add(new viewSurvey
                        {
                            num1 = Math.Round(Convert.ToDecimal(rdr["num1"]),2)

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyScoreAvg(int idsurvey)
        {
            decimal val1;
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_ScoreAvg");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["num1"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["num1"]), 2);
                        
                        lst.Add(new viewSurvey
                        {
                            num1 = val1

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyScoreGraph(int idsurvey)
        {
            decimal val1;
            string str1;
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_ScoreGrph");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["num1"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["num1"]), 2);

                        if (rdr["section"] == DBNull.Value)
                            str1 = "";
                        else
                            str1 = rdr["section"].ToString();

                        lst.Add(new viewSurvey
                        {
                            Section = str1.ToUpper(),
                            num1 = val1

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyScoreThree(int idsurvey)
        {
            decimal val1;
            string str1,str2,str3="";
            //---start array
            ArrayList arrList = new ArrayList();
            arrList.Add(
                new Question
                {
                    code = "q1",
                    Name = "ZAP\'s product quality is higher with other competitors.",
                });
            arrList.Add(
                new Question
                {
                    code = "q2",
                    Name = "Shipments are received with no defect product at your site.",
                });
            arrList.Add(
                new Question
                {
                    code = "q3",
                    Name = "Material testing reports are included with the shipment of product.",
                });
            arrList.Add(
                new Question
                {
                    code = "q4",
                    Name = "If any customer complaint, ZAP responses it within 1 week.",
                });
            arrList.Add(
                new Question
                {
                    code = "q5",
                    Name = "Corrective actions of customer complaint are taken by ZAP are in detail and complete.",
                });
            arrList.Add(
                new Question
                {
                    code = "d1",
                    Name = "Shipments are hit to promised date.",
                });
            arrList.Add(
                new Question
                {
                    code = "d2",
                    Name = "Shipments are received with no lack of quantity against to packing list or delivery note.",
                });
            arrList.Add(
                new Question
                {
                    code = "d3",
                    Name = "Shipments are packed properly.",
                });
            arrList.Add(
                new Question
                {
                    code = "d4",
                    Name = "Shipments are received with the correct order.",
                });
            arrList.Add(
                new Question
                {
                    code = "p1",
                    Name = "ZAP\'s price is quite competitive compared with other competitors.",
                });
            arrList.Add(
                new Question
                {
                    code = "p2",
                    Name = "ZAP\'s price is corresponding to with product quality.",
                });

            
            arrList.Add(
                new Question
                {
                    code = "t1",
                    Name = "ZAP’s website is full resource for technical and product information",
                });
            arrList.Add(
                new Question
                {
                    code = "t2",
                    Name = "ZAP’s engineer is very helpful and knowledgeable for engineering process.",
                });
            arrList.Add(
                new Question
                {
                    code = "t3",
                    Name = "Respond of technical issues are handled by engineer within 1 week.",
                });
            arrList.Add(
                new Question
                {
                    code = "t4",
                    Name = "When calling or email ZAP’s marketing or engineering, I will get the information that I needed.",
                });
            arrList.Add(
                new Question
                {
                    code = "o1",
                    Name = "Quotations are received within 1 week after inquiry sent.",
                });
            arrList.Add(
                new Question
                {
                    code = "o2",
                    Name = "Confirmation orders are received within 2 weeks after PO sent.",
                });
            arrList.Add(
                new Question
                {
                    code = "o3",
                    Name = "Confirmation orders exactly match with the Purchase Order.",
                });
            arrList.Add(
                new Question
                {
                    code = "o4",
                    Name = "Marketing or Sales who in-charge in marketing department is very helpful and all emails or phone conversations are answered promptly and nicely.",
                });
            arrList.Add(
                new Question
                {
                    code = "o5",
                    Name = "ZAP’s extranet is very helpful for tracking progress of order, shipment schedule, tracking documents, and inventory information.",
                });
            arrList.Add(
                new Question
                {
                    code = "o6",
                    Name = "I satisfied with overall performance with all ZAP’s team members or person in charge of my account.",
                });
            //------ ending array
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_ScoreThree");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["score"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["score"]), 2);

                        if (rdr["section"] == DBNull.Value)
                            str1 = "";
                        else
                            str1 = rdr["section"].ToString();

                        if (rdr["pertanyaan"] == DBNull.Value)
                            str2 = "";
                        else {
                                str2 = rdr["pertanyaan"].ToString();

                                var query = from Question tanya in arrList
                                            where tanya.code == str2
                                            select tanya;

                                    foreach (Question s in query)
                                      str3 = s.Name;
                              }
                        lst.Add(new viewSurvey
                        {
                            Section = str1.ToUpper(),
                            Question = str3,
                            num1 = val1

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyScoreList(int idsurvey)
        {
            decimal val1;
            string str1, str2, str3 = "";
            //---start array
            ArrayList arrList = new ArrayList();
            arrList.Add(
                new Question
                {
                    code = "q1",
                    Name = "ZAP\'s product quality is higher with other competitors.",
                });
            arrList.Add(
                new Question
                {
                    code = "q2",
                    Name = "Shipments are received with no defect product at your site.",
                });
            arrList.Add(
                new Question
                {
                    code = "q3",
                    Name = "Material testing reports are included with the shipment of product.",
                });
            arrList.Add(
                new Question
                {
                    code = "q4",
                    Name = "If any customer complaint, ZAP responses it within 1 week.",
                });
            arrList.Add(
                new Question
                {
                    code = "q5",
                    Name = "Corrective actions of customer complaint are taken by ZAP are in detail and complete.",
                });
            arrList.Add(
                new Question
                {
                    code = "d1",
                    Name = "Shipments are hit to promised date.",
                });
            arrList.Add(
                new Question
                {
                    code = "d2",
                    Name = "Shipments are received with no lack of quantity against to packing list or delivery note.",
                });
            arrList.Add(
                new Question
                {
                    code = "d3",
                    Name = "Shipments are packed properly.",
                });
            arrList.Add(
                new Question
                {
                    code = "d4",
                    Name = "Shipments are received with the correct order.",
                });
            arrList.Add(
                new Question
                {
                    code = "p1",
                    Name = "ZAP\'s price is quite competitive compared with other competitors.",
                });
            arrList.Add(
                new Question
                {
                    code = "p2",
                    Name = "ZAP\'s price is corresponding to with product quality.",
                });


            arrList.Add(
                new Question
                {
                    code = "t1",
                    Name = "ZAP’s website is full resource for technical and product information",
                });
            arrList.Add(
                new Question
                {
                    code = "t2",
                    Name = "ZAP’s engineer is very helpful and knowledgeable for engineering process.",
                });
            arrList.Add(
                new Question
                {
                    code = "t3",
                    Name = "Respond of technical issues are handled by engineer within 1 week.",
                });
            arrList.Add(
                new Question
                {
                    code = "t4",
                    Name = "When calling or email ZAP’s marketing or engineering, I will get the information that I needed.",
                });
            arrList.Add(
                new Question
                {
                    code = "o1",
                    Name = "Quotations are received within 1 week after inquiry sent.",
                });
            arrList.Add(
                new Question
                {
                    code = "o2",
                    Name = "Confirmation orders are received within 2 weeks after PO sent.",
                });
            arrList.Add(
                new Question
                {
                    code = "o3",
                    Name = "Confirmation orders exactly match with the Purchase Order.",
                });
            arrList.Add(
                new Question
                {
                    code = "o4",
                    Name = "Marketing or Sales who in-charge in marketing department is very helpful and all emails or phone conversations are answered promptly and nicely.",
                });
            arrList.Add(
                new Question
                {
                    code = "o5",
                    Name = "ZAP’s extranet is very helpful for tracking progress of order, shipment schedule, tracking documents, and inventory information.",
                });
            arrList.Add(
                new Question
                {
                    code = "o6",
                    Name = "I satisfied with overall performance with all ZAP’s team members or person in charge of my account.",
                });
            //------ ending array

            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_ScoreList");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["score"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["score"]), 2);

                        if (rdr["section"] == DBNull.Value)
                            str1 = "";
                        else
                            str1 = rdr["section"].ToString();

                        if (rdr["pertanyaan"] == DBNull.Value)
                            str2 = "";
                        else
                        {
                            str2 = rdr["pertanyaan"].ToString();

                            var query = from Question tanya in arrList
                                        where tanya.code == str2
                                        select tanya;

                            foreach (Question s in query)
                                str3 = s.Name;
                        }
                        lst.Add(new viewSurvey
                        {
                            Section = str1.ToUpper(),
                            Question = str3,
                            num1 = val1

                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }
        public List<viewSurvey> vSurveyCommentList(int idsurvey)
        {
            string commm;
            List<viewSurvey> lst = new List<viewSurvey>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mSurvey", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@IDsurvey", idsurvey);
                com.Parameters.AddWithValue("@Action", "Rpt_CommentList");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        commm = rdr["comment"].ToString();
                        if (commm != "") {
                            lst.Add(new viewSurvey
                            {
                                Customer = rdr["cCustName"].ToString(),
                                Comment = commm

                            });
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*------------------End Survey Customer-----------------------*/

        public List<FOHDetailModels> RptFOHDetailChild(string ddate)
        {
            decimal val11;    //--, val2, val3, val4, val5;
            decimal totval11 = 0; //--, totval2 = 0, totval3 = 0, totval4 = 0, totval5 = 0;

            string strCommand = "select dPDEDate, sum(iqty*iWeight) as pda from tProductdeliveryevidence1,tProductDeliveryEvidence3 where tProductdeliveryevidence1.cPDECode = tProductdeliveryevidence3.cPDECode and cPDETYpe = 'PDA' and dPDEDate = '" + ddate + "' group by dPDEDate order by dPDEDate";

            List<FOHDetailModels> lst = new List<FOHDetailModels>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand com = new SqlCommand(strCommand, con);
                com.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["pda"] == DBNull.Value)
                            val11 = 0;
                        else
                            val11 = Math.Round(Convert.ToDecimal(rdr["pda"]), 2);
                        totval11 = totval11 + val11;


                        lst.Add(new FOHDetailModels
                        {
                            dPDEDate = string.Format("{0:dd-MM-yyyy}", rdr["dPDEDate"]),
                            pda = val11
                        });

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }


        //viewCostControl

    }



    /*-----------------batas --------------------------------------------------------*/


    public class DBhrd
    {
        string cshrd = ConfigurationManager.ConnectionStrings["DBKPIHRD"].ConnectionString;

        public List<LoginModels> ListMenu(string uname, string pname)
        {
            List<LoginModels> lst = new List<LoginModels>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                //NIK, [Name], positionID, position, username, [password]
                //NOT USE  -- UserRoleId = Convert.ToInt32(rdr["RoleId"])
                SqlCommand com = new SqlCommand("sp_mLogin", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Username", uname);
                com.Parameters.AddWithValue("@Password", pname);
                com.Parameters.AddWithValue("@Action", "LoginMG");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new LoginModels
                        {
                            UserId = Convert.ToInt32(rdr["id"]),
                            UserName = rdr["UserName"].ToString(),
                            Password = rdr["Password"].ToString(),
                            UserRoleId = Convert.ToInt32(rdr["RoleId"]),
                            RoleName = rdr["Roles"].ToString(),
                            CustCode = rdr["NIK"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corporate> vCORPHRD(int id)
        {
            decimal LGkp1ACT,  LGkp3ACT, LGkp4ACT,  IBPkp4ACT;
            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                SqlCommand com = new SqlCommand("Extranet_sp_mKPI", con);
                com.Parameters.AddWithValue("@YEAR", id);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "CORP");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        // cus IBP SAFETY INDEX join HRD
                        if (rdr["ibpActSafe"] == DBNull.Value)
                            IBPkp4ACT = 0;
                        else
                            IBPkp4ACT = Convert.ToDecimal(rdr["ibpActSafe"]);
                        // LG IS CAP join HRD
                        //if (rdr["lgActIsCap"] == DBNull.Value)
                        //    LGkp2ACT = 0;
                        //else
                        //    LGkp2ACT = Convert.ToDecimal(rdr["lgActIsCap"]);

                        // LG 5-S Implementation join HRD
                        if (rdr["lgActImp"] == DBNull.Value)
                            LGkp1ACT = 0;
                        else
                            LGkp1ACT = Convert.ToDecimal(rdr["lgActImp"]);


                        // LG TRAINING join HRD
                        if (rdr["lgActTrain"] == DBNull.Value)
                            LGkp3ACT = 0;
                        else
                            LGkp3ACT = Convert.ToDecimal(rdr["lgActTrain"]);

                        // LG SKILL join HRD

                        if (rdr["lgActSkill"] == DBNull.Value)
                            LGkp4ACT = 0;
                        else
                            LGkp4ACT = Convert.ToDecimal(rdr["lgActSkill"]);

                        // LG Motivation join HRD

                        //if (rdr["lgActMot"] == DBNull.Value)
                        //    LGkp5ACT = 0;
                        //else
                        //    LGkp5ACT = Convert.ToDecimal(rdr["lgActMot"]);

                        lst.Add(new corporate
                        {
                            ibpActSafe = Math.Round(IBPkp4ACT, 2),
                            lgActImp = Math.Round(LGkp1ACT, 2),
                            //lgActIsCap = Math.Round(LGkp2ACT, 2),
                            lgActTrain = Math.Round(LGkp3ACT, 2),
                            lgActSkill = Math.Round(LGkp4ACT,2)
                            //lgActMot = Math.Round(LGkp5ACT, 2)
                            

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<ViewChart> GraphImpAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "ImpAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }


        public List<ViewChart> GraphSafetyAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "SafeAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai,2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

      
        public List<ViewChart> GraphTrainingAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "TrainAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        public List<ViewChart> GraphSkillAct(int iyear)
        {
            List<ViewChart> lst = new List<ViewChart>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                int BUL = 1, lBul;
                decimal nilai;
                SqlCommand com = new SqlCommand("[Extranet_sp_GraphKPI]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@YEAR", iyear);
                com.Parameters.AddWithValue("@Action", "SkillAct");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {

                        lBul = BUL;
                        while (lBul < 13)
                        {
                            nilai = 0;
                            if (lBul == Convert.ToInt32(rdr["bulan"]))
                            {
                                if (rdr["nilai"] == DBNull.Value)
                                    nilai = 0;
                                else
                                    nilai = Convert.ToDecimal(rdr["nilai"]);
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = Math.Round(nilai, 2)
                                });
                                BUL = lBul + 1;
                                lBul = 13;
                            }
                            else
                            {
                                lst.Add(new ViewChart
                                {
                                    bulan = lBul,
                                    amount = nilai
                                });
                                lBul++;
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

        /*----------kpi dep ----------------*/

        public List<corporate> vMachineDeptHrd(int thn, int bln, char ch)
        {
            decimal kpidepSafe;
            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                SqlCommand comHRD = new SqlCommand("Extranet_sp_mKPI", con);
                comHRD.Parameters.AddWithValue("@YEAR", thn);
                comHRD.Parameters.AddWithValue("@MONTH", bln);
                comHRD.CommandType = CommandType.StoredProcedure;
                if (ch == 'D')
                    comHRD.Parameters.AddWithValue("@Action", "KPIDep");
                else if (ch == 'M')
                    comHRD.Parameters.AddWithValue("@Action", "KPIDepMonth");
                else if (ch == 'Y')
                    comHRD.Parameters.AddWithValue("@Action", "KPIDepYear");

                try
                {
                    con.Open();
                    SqlDataReader rdr = comHRD.ExecuteReader();
                    while (rdr.Read())
                    {
                        // SAFETY INDEX join HRD
                        if (rdr["ibpActSafe"] == DBNull.Value)
                            kpidepSafe = 0;
                        else
                            kpidepSafe = Convert.ToDecimal(rdr["ibpActSafe"]);


                        lst.Add(new corporate
                        {
                            ibpActSafe = Math.Round(kpidepSafe, 2)

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }


        public List<corporate> HrdGADept(int thn, int bln, char ch)
        {
            decimal kpidepSafe, kpidepTrain, kpidepSkill, kpidepSalary, kpidepOvertime;
            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                SqlCommand comHRD = new SqlCommand("Extranet_sp_mKPI", con);
                comHRD.Parameters.AddWithValue("@YEAR", thn);
                comHRD.Parameters.AddWithValue("@MONTH", bln);
                comHRD.CommandType = CommandType.StoredProcedure;
                if (ch == 'D')
                    comHRD.Parameters.AddWithValue("@Action", "HrdDept");
                else if (ch == 'M')
                    comHRD.Parameters.AddWithValue("@Action", "HrdDeptMonth");
                else if (ch == 'Y')
                    comHRD.Parameters.AddWithValue("@Action", "HrdDeptYear");
                try
                {
                    con.Open();
                    SqlDataReader rdr = comHRD.ExecuteReader();
                    while (rdr.Read())
                    {
                        // SAFETY INDEX 
                        if (rdr["ActSafe"] == DBNull.Value)
                            kpidepSafe = 0;
                        else
                            kpidepSafe = Convert.ToDecimal(rdr["ActSafe"]);
                        // train 
                        if (rdr["ActTrain"] == DBNull.Value)
                            kpidepTrain = 0;
                        else
                            kpidepTrain = Convert.ToDecimal(rdr["ActTrain"]);
                        // skill 
                        if (thn<2020)
                        {
                            if (rdr["ActSkill"] == DBNull.Value)
                                kpidepSkill = 0;
                            else
                                kpidepSkill = Convert.ToDecimal(rdr["ActSkill"]);
                        }
                        else
                        {
                            kpidepSkill = 0;
                        }
                        //Salary
                        if (rdr["ActSalary"] == DBNull.Value)
                            kpidepSalary = 0;
                        else
                            kpidepSalary = Convert.ToDecimal(rdr["ActSalary"]);
                        //Overtime
                        if (rdr["ActOvertime"] == DBNull.Value)
                            kpidepOvertime = 0;
                        else
                            kpidepOvertime = Convert.ToDecimal(rdr["ActOvertime"]);

                        lst.Add(new corporate
                        {
                            ibpActSafe = Math.Round(kpidepSafe, 2),
                            lgActTrain = Math.Round(kpidepTrain, 2),
                            lgActSkill = Math.Round(kpidepSkill, 2),
                            finActCash = Math.Round(kpidepSalary, 2),
                            finActRev = Math.Round(kpidepOvertime, 2)

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corporate> HrdGADeptYY(int thn, int bln, char ch)
        {
            decimal kpidepSafe, kpidepTrain, kpidepSkill, kpidepSalary, kpidepOvertime;
            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                SqlCommand comHRD = new SqlCommand("Extranet_sp_mKPI", con);
                comHRD.Parameters.AddWithValue("@YEAR", thn);
                comHRD.Parameters.AddWithValue("@MONTH", bln);
                comHRD.CommandType = CommandType.StoredProcedure;
                comHRD.Parameters.AddWithValue("@Action", "HrdDeptYear");

                try
                {
                    con.Open();
                    SqlDataReader rdr = comHRD.ExecuteReader();
                    while (rdr.Read())
                    {
                        // SAFETY INDEX 
                        if (rdr["ActSafe"] == DBNull.Value)
                            kpidepSafe = 0;
                        else
                            kpidepSafe = Convert.ToDecimal(rdr["ActSafe"]);
                        // train 
                        if (rdr["ActTrain"] == DBNull.Value)
                            kpidepTrain = 0;
                        else
                            kpidepTrain = Convert.ToDecimal(rdr["ActTrain"]);
                        // skill 
                        if (thn < 2020)
                        {
                            if (rdr["ActSkill"] == DBNull.Value)
                                kpidepSkill = 0;
                            else
                                kpidepSkill = Convert.ToDecimal(rdr["ActSkill"]);
                        }
                        else
                        {
                            kpidepSkill = 0;
                        }
                        //Salary
                        if (rdr["ActSalary"] == DBNull.Value)
                            kpidepSalary = 0;
                        else
                            kpidepSalary = Convert.ToDecimal(rdr["ActSalary"]);
                        //Overtime
                        if (rdr["ActOvertime"] == DBNull.Value)
                            kpidepOvertime = 0;
                        else
                            kpidepOvertime = Convert.ToDecimal(rdr["ActOvertime"]);

                        lst.Add(new corporate
                        {
                            ibpActSafe = Math.Round(kpidepSafe, 2),
                            lgActTrain = Math.Round(kpidepTrain, 2),
                            lgActSkill = Math.Round(kpidepSkill, 2),
                            finActCash = Math.Round(kpidepSalary, 2),
                            finActRev = Math.Round(kpidepOvertime, 2)

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corporate> CastingDept(int thn, int bln, char ch)
        {
            decimal kpidepSafe;
            decimal AchSafe, ScrSafe;


            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                SqlCommand comHRD = new SqlCommand("Extranet_sp_mKPI", con);
                comHRD.Parameters.AddWithValue("@YEAR", thn);
                comHRD.Parameters.AddWithValue("@MONTH", bln);
                comHRD.CommandType = CommandType.StoredProcedure;
                if (ch == 'D')
                    comHRD.Parameters.AddWithValue("@Action", "Casting");
                else if (ch == 'M')
                    comHRD.Parameters.AddWithValue("@Action", "CastingMonth");
                else if (ch == 'Y')
                    comHRD.Parameters.AddWithValue("@Action", "CastingYear");

                try
                {
                    con.Open();
                    SqlDataReader rdr = comHRD.ExecuteReader();
                    while (rdr.Read())
                    {
                        //---TempGradeSaf, TempTargetSaf, TotGrade, TotScore;
                        // SAFETY INDEX 
                        if (rdr["ActSafe"] == DBNull.Value)
                            kpidepSafe = 0;
                        else
                            kpidepSafe = Convert.ToDecimal(rdr["ActSafe"]);

                        if (kpidepSafe==0)
                        {
                            AchSafe = 100;
                            ScrSafe = NilaiGlobal.TempGradeSaf;
                        }
                        else
                        {
                            AchSafe = 0;
                            ScrSafe = Convert.ToDecimal(Convert.ToDouble(NilaiGlobal.TempGradeSaf)* 0.6);
                        }

                        lst.Add(new corporate
                        {
                            ibpActSafe = Math.Round(kpidepSafe, 2),
                            PicAchSaf = Math.Round(AchSafe, 2),
                            PicScrSaf = Math.Round(ScrSafe, 2)

                        });



                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corporate> ProductionDept(int thn, int bln, char ch)
        {
            //AchSafeTemp
            decimal kpidepSafe, kpidepImp ;
            decimal AchSafe, ScrSafe, nilaiScore,  ScrImpl, AchImplTemp;
            decimal nilaiScoreMonth, nilaiScoreSum;
            decimal nilaiGrade, nilaiGradeMonth, nilaiGradeSum;
            double AchImpl, AchImplMonth, AchImplYear, dkpidepImp;

            nilaiGradeMonth = NilaiGlobal.TotGradeMonth;
            nilaiScoreMonth = NilaiGlobal.TotScoreMonth;
            nilaiGradeSum = NilaiGlobal.TotGradeSum;
            nilaiScoreSum = NilaiGlobal.TotScoreSum;
            nilaiGrade = NilaiGlobal.TotGrade;
            nilaiScore = NilaiGlobal.TotScore;
            AchImplTemp = 0;

            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                SqlCommand comHRD = new SqlCommand("Extranet_sp_mKPI", con);
                comHRD.Parameters.AddWithValue("@YEAR", thn);
                comHRD.Parameters.AddWithValue("@MONTH", bln);
                comHRD.CommandType = CommandType.StoredProcedure;
                if (ch == 'D')
                    comHRD.Parameters.AddWithValue("@Action", "Prod");
                else if (ch == 'M')
                    comHRD.Parameters.AddWithValue("@Action", "ProdMonth");
                else if (ch == 'Y')
                    comHRD.Parameters.AddWithValue("@Action", "ProdYear");

                try
                {
                    con.Open();
                    SqlDataReader rdr = comHRD.ExecuteReader();
                    while (rdr.Read())
                    {
                        //---TempGradeSaf, TempTargetSaf, TotGrade, TotScore;
                        // SAFETY INDEX 
                        if (rdr["ActSafe"] == DBNull.Value)
                            kpidepSafe = 0;
                        else
                            kpidepSafe = Convert.ToDecimal(rdr["ActSafe"]);

                        if (kpidepSafe == 0)
                        {
                            AchSafe = 100;
                            ScrSafe = NilaiGlobal.TempGradeSaf;
                        }
                        else
                        {
                            AchSafe = 0;
                            ScrSafe = Convert.ToDecimal(Convert.ToDouble(NilaiGlobal.TempGradeSaf) * 0.6);
                        }

                        if (ch == 'D')
                            nilaiScore = nilaiScore + ScrSafe;
                        if (ch == 'M')
                            nilaiScoreMonth = nilaiScoreMonth + ScrSafe;
                        if (ch == 'Y')
                            nilaiScoreSum = nilaiScoreSum + ScrSafe;

                        //Implementation 5S
                        if (rdr["ActImp"] == DBNull.Value)
                            kpidepImp = 0;
                        else
                            kpidepImp = Convert.ToDecimal(rdr["ActImp"]);

                        AchImpl = 0;
                        AchImplMonth = 0;
                        AchImplYear = 0;
                        dkpidepImp = Convert.ToDouble(kpidepImp);
                        if (ch == 'D')
                        {
                            if (NilaiGlobal.TempTargetLab > 0)
                                AchImpl = Convert.ToDouble(kpidepImp / NilaiGlobal.TempTargetLab * 100);
                            else
                                AchImpl = 0;

                            if (AchImpl < 0)
                                AchImpl = 0;

                            if (dkpidepImp > 4.5)
                                AchImplTemp = 120;
                            else if (dkpidepImp > 3.5 && dkpidepImp <= 4.5)
                                AchImplTemp = 110;
                            else if (dkpidepImp > 3.3 && dkpidepImp <= 3.5)
                                AchImplTemp = 100;
                            else if (dkpidepImp >= 2.5 && dkpidepImp <= 3.3)
                                AchImplTemp = 90;
                            else if (dkpidepImp < 2.5)
                                AchImplTemp = 60;

                            /*
  NilaiGlobal.TempGradeLab = PicOthGrd;
  NilaiGlobal.TempTargetLab = PicOthTrg;
                              */


                            ScrImpl = NilaiGlobal.TempGradeLab * AchImplTemp / 100;
                            nilaiScore = nilaiScore + ScrImpl;
                            lst.Add(new corporate
                            {
                                ibpActSafe = Math.Round(kpidepSafe, 2),
                                lgActImp = Math.Round(kpidepImp, 2),
                                PicAchSaf = Math.Round(AchSafe, 2),
                                PicScrSaf = Math.Round(ScrSafe, 2),
                                PicGrdLab = Math.Round(NilaiGlobal.TempGradeLab, 2),
                                lgGrdImp = Convert.ToInt32(NilaiGlobal.TempTargetLab),
                                lgAchImp = Convert.ToDecimal(Math.Round(AchImpl, 2)),
                                lgScrImp = Convert.ToDecimal(Math.Round(ScrImpl, 2)),
                                TotGrade = Math.Round(NilaiGlobal.TotGrade, 2),
                                TotScore = nilaiScore

                            });
                        }
                        else if (ch == 'M')
                        {
                            if (NilaiGlobal.TempTargetLabMonth > 0)
                                AchImplMonth = Convert.ToDouble(kpidepImp / NilaiGlobal.TempTargetLabMonth * 100);
                            else
                                AchImplMonth = 0;

                            if (AchImplMonth < 0)
                                AchImplMonth = 0;

                            if (dkpidepImp > 4.5)
                                AchImplTemp = 120;
                            else if (dkpidepImp > 3.5 && dkpidepImp <= 4.5)
                                AchImplTemp = 110;
                            else if (dkpidepImp > 3.3 && dkpidepImp <= 3.5)
                                AchImplTemp = 100;
                            else if (dkpidepImp >= 2.5 && dkpidepImp <= 3.3)
                                AchImplTemp = 90;
                            else if (dkpidepImp < 2.5)
                                AchImplTemp = 60;

                            ScrImpl = NilaiGlobal.TempGradeLabMonth * AchImplTemp / 100;
                            nilaiScoreMonth = nilaiScoreMonth + ScrImpl;
                            lst.Add(new corporate
                            {
                                lgActImp = Math.Round(kpidepImp, 2),
                                ibpActSafe = Math.Round(kpidepSafe, 2),
                                PicAchSaf = Math.Round(AchSafe, 2),
                                PicScrSaf = Math.Round(ScrSafe, 2),
                                PicGrdLab = Math.Round(NilaiGlobal.TempGradeLabMonth, 2),
                                lgGrdImp = Convert.ToInt32(NilaiGlobal.TempTargetLabMonth),
                                lgAchImp = Convert.ToDecimal(Math.Round(AchImplMonth, 2)),
                                lgScrImp = Convert.ToDecimal(Math.Round(ScrImpl, 2)),
                                TotGradeMonth = Math.Round(NilaiGlobal.TotGradeMonth, 2),
                                TotScoreMonth = nilaiScoreMonth

                            });
                        }
                        else if (ch == 'Y')
                        {
                            if (NilaiGlobal.TempTargetLabYear > 0)
                                AchImplYear = Convert.ToDouble(kpidepImp / NilaiGlobal.TempTargetLabYear * 100);
                            else
                                AchImplYear = 0;

                            if (AchImplYear < 0)
                                AchImplYear = 0;

                            if (dkpidepImp > 4.5)
                                AchImplTemp = 120;
                            else if (dkpidepImp > 3.5 && dkpidepImp <= 4.5)
                                AchImplTemp = 110;
                            else if (dkpidepImp > 3.3 && dkpidepImp <= 3.5)
                                AchImplTemp = 100;
                            else if (dkpidepImp >= 2.5 && dkpidepImp <= 3.3)
                                AchImplTemp = 90;
                            else if (dkpidepImp < 2.5)
                                AchImplTemp = 60;

                            ScrImpl = NilaiGlobal.TempGradeLabYear * AchImplTemp / 100;
                            nilaiScoreSum = nilaiScoreSum + ScrImpl;
                            lst.Add(new corporate
                            {
                                lgActImp = Math.Round(kpidepImp, 2),
                                ibpActSafe = Math.Round(kpidepSafe, 2),
                                PicAchSaf = Math.Round(AchSafe, 2),
                                PicScrSaf = Math.Round(ScrSafe, 2),
                                PicGrdLab = Math.Round(NilaiGlobal.TempGradeLabYear, 2),
                                lgGrdImp = Convert.ToInt32(NilaiGlobal.TempTargetLabYear),
                                lgAchImp = Convert.ToDecimal(Math.Round(AchImplYear, 2)),
                                lgScrImp = Convert.ToDecimal(Math.Round(ScrImpl, 2)),
                                TotGradeSum = Math.Round(NilaiGlobal.TotGradeSum, 2),
                                TotScoreSum = nilaiScoreSum

                            });
                        }


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public List<corporate> QualityDept(int thn, int bln, char ch)
        {
            decimal kpidepSafe;
            decimal nilaiScoreMonth,  HrdAchLab, HrdScrLab, HrdAchLabMonth, HrdScrLabMonth, HrdAchLabSum, HrdScrLabSum;
            decimal nilaiGradeMonth, nilaiGradeSum;

            nilaiGradeMonth = NilaiGlobal.TotGradeMonth;
            nilaiScoreMonth = NilaiGlobal.TotScoreMonth;
            nilaiGradeSum = NilaiGlobal.TotGradeSum;
            HrdAchLab = 0;
            HrdAchLabMonth = 0;
            HrdAchLabSum = 0;
            HrdScrLabMonth = 0;
            HrdScrLabSum = 0;
            List<corporate> lst = new List<corporate>();
            using (SqlConnection con = new SqlConnection(cshrd))
            {
                SqlCommand comHRD = new SqlCommand("Extranet_sp_mKPI", con);
                comHRD.Parameters.AddWithValue("@YEAR", thn);
                comHRD.Parameters.AddWithValue("@MONTH", bln);
                comHRD.CommandType = CommandType.StoredProcedure;
                if (ch == 'D')
                    comHRD.Parameters.AddWithValue("@Action", "Qua");
                else if (ch == 'M')
                    comHRD.Parameters.AddWithValue("@Action", "QuaMonth");
                else if (ch == 'Y')
                    comHRD.Parameters.AddWithValue("@Action", "QuaYear");

                try
                {
                    con.Open();
                    SqlDataReader rdr = comHRD.ExecuteReader();
                    while (rdr.Read())
                    {
                        //---labor cost
                        if (rdr["ActSafe"] == DBNull.Value)
                            kpidepSafe = 0;
                        else
                            kpidepSafe = Convert.ToDecimal(rdr["ActSafe"]);

                        if (ch == 'D')
                        {  
                            if (NilaiGlobal.TempTargetLab>0)
                                HrdAchLab = (1 + ((NilaiGlobal.TempTargetLab - kpidepSafe) / NilaiGlobal.TempTargetLab)) * 100;
                            if (HrdAchLab > 0)
                            {
                                //--HrdScrLab = NilaiGlobal.TempGradeLab * HrdAchLab / 100;
                                if (kpidepSafe == 0)
                                    HrdScrLab = NilaiGlobal.TempGradeLab;
                                else
                                   HrdScrLab = NilaiGlobal.TempGradeLab - (NilaiGlobal.TempGradeLab - ((NilaiGlobal.TempTargetLab / kpidepSafe) * NilaiGlobal.TempGradeLab));
                            }
                            else
                            {
                                HrdAchLab = 0;
                                HrdScrLab = 0;
                            }
                            lst.Add(new corporate
                            {
                                ibpActSafe = Math.Round(kpidepSafe, 2),
                                PicAchSaf = Math.Round(HrdAchLab, 2),
                                PicScrSaf = Math.Round(HrdScrLab, 2),
                                TotGrade = Math.Round(NilaiGlobal.TotGrade, 2)
                            });
                        }
                        else if (ch == 'M')
                        {
                            if (NilaiGlobal.TempTargetLabMonth > 0)
                                HrdAchLabMonth = (1 + ((NilaiGlobal.TempTargetLabMonth - kpidepSafe) / NilaiGlobal.TempTargetLabMonth)) * 100;
                            if (HrdAchLabMonth > 0)
                            {
                                //--HrdScrLabMonth = NilaiGlobal.TempGradeLabMonth * HrdAchLabMonth / 100;
                                if (kpidepSafe == 0)
                                    HrdScrLabMonth = NilaiGlobal.TempGradeLabMonth;
                                else
                                    HrdScrLabMonth = NilaiGlobal.TempGradeLabMonth - (NilaiGlobal.TempGradeLabMonth - ((NilaiGlobal.TempTargetLabMonth / kpidepSafe) * NilaiGlobal.TempGradeLabMonth));
                            }
                            else
                            {

                                HrdAchLabMonth = 0;
                                HrdScrLabMonth = 0;
                            }
                            lst.Add(new corporate
                            {
                                ibpActSafe = Math.Round(kpidepSafe, 2),
                                PicAchSaf = Math.Round(HrdAchLabMonth, 2),
                                PicScrSaf = Math.Round(HrdScrLabMonth, 2),
                                TotGradeMonth = Math.Round(NilaiGlobal.TotGradeMonth, 2),
                                TotScoreMonth = Math.Round(NilaiGlobal.TotScoreMonth+ HrdScrLabMonth,2)
                            });
                        }
                        else if (ch == 'Y')
                        {
                            if (NilaiGlobal.TempTargetLabYear > 0)
                                HrdAchLabSum = (1 + ((NilaiGlobal.TempTargetLabYear - kpidepSafe) / NilaiGlobal.TempTargetLabYear)) * 100;
                            if (HrdAchLabSum > 0)
                            {
                                //--HrdScrLabSum = NilaiGlobal.TempGradeLabYear * HrdAchLabSum / 100;
                                if (kpidepSafe == 0)
                                    HrdScrLabSum = NilaiGlobal.TempGradeLabYear;
                                else
                                    HrdScrLabSum = NilaiGlobal.TempGradeLabYear - (NilaiGlobal.TempGradeLabYear - ((NilaiGlobal.TempTargetLabYear / kpidepSafe) * NilaiGlobal.TempGradeLabYear));
                            }
                            else
                            {
                                HrdAchLabSum = 0;
                                HrdScrLabSum = 0;
                            }
                            lst.Add(new corporate
                            {
                                ibpActSafe = Math.Round(kpidepSafe, 2),
                                PicAchSaf = Math.Round(HrdAchLabSum, 2),
                                PicScrSaf = Math.Round(HrdScrLabSum, 2),
                                TotGradeSum = Math.Round(NilaiGlobal.TotGradeSum, 2),
                                TotScoreSum = Math.Round(NilaiGlobal.TotScoreSum + HrdScrLabSum, 2)
                            });
                        }


                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }


       

    }

    /*--------------------batas ppic db-------------------------------------------*/
    public class DBppic
    {
        string csppic = ConfigurationManager.ConnectionStrings["DBKPIPPIC"].ConnectionString;

        /*------------------- vFOHRpt-------------------------------*/
        public List<FOHModels> RptFOHDetail(int month, int year)
        {
            decimal val1, val2, val3, val4, val5;
            decimal totval1 = 0, totval2 = 0, totval3 = 0, totval4 = 0, totval5 = 0;

            List<FOHModels> lst = new List<FOHModels>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_Tools", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", month);
                com.Parameters.AddWithValue("@Period", year);
                com.Parameters.AddWithValue("@Action", "FOHRpt");

                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["kwhbebanpuncak"] == DBNull.Value)
                            val1 = 0;
                        else
                            val1 = Math.Round(Convert.ToDecimal(rdr["kwhbebanpuncak"]), 2);
                        totval1 = totval1 + val1;

                        if (rdr["kwhbebannormal"] == DBNull.Value)
                            val2 = 0;
                        else
                            val2 = Math.Round(Convert.ToDecimal(rdr["kwhbebannormal"]), 2);
                        totval2 = totval2 + val2;

                        if (rdr["rpbebanpuncak"] == DBNull.Value)
                            val3 = 0;
                        else
                            val3 = Math.Round(Convert.ToDecimal(rdr["rpbebanpuncak"]));
                        totval3 = totval3 + val3;

                        if (rdr["rpbebannormal"] == DBNull.Value)
                            val4 = 0;
                        else
                            val4 = Math.Round(Convert.ToDecimal(rdr["rpbebannormal"]));
                        totval4 = totval4 + val4;

                        if (rdr["rpbebann"] == DBNull.Value)
                            val5 = 0;
                        else
                            val5 = Math.Round(Convert.ToDecimal(rdr["rpbebann"]));
                        totval5 = totval5 + val5;


                        lst.Add(new FOHModels
                        {
                            ddate = string.Format("{0:dd-MM-yyyy}", rdr["ddate"]),
                            kwhbebanpuncak = val1,
                            kwhbebannormal = val2,
                            rpbebanpuncak = val3,
                            rpbebannormal = val4,
                            rpbebann = val5
                        });

                    }

                    if (rdr.HasRows)
                    {
                        lst.Add(new FOHModels
                        {
                            ddate = "TOTAL",
                            kwhbebanpuncak = totval1,
                            kwhbebannormal = totval2,
                            rpbebanpuncak = totval3,
                            rpbebannormal = totval4,
                            rpbebann = totval5
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;

            }
        }

   
        /*--------Notulen---------------*/
        public List<viewNotulen> viewNotulen_1(int id, char opt)
        {
            string tipe;
            List<viewNotulen> lst = new List<viewNotulen>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mNotulen", con);
                com.CommandType = CommandType.StoredProcedure;
                if (opt == 'A')
                    com.Parameters.AddWithValue("@Action", "vNotulen_1");
                else
                {
                    com.Parameters.AddWithValue("@ID_1", id);
                    com.Parameters.AddWithValue("@Action", "vNotulen_1_ByID");
                }
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["type"] == DBNull.Value)
                            tipe = "";
                        else
                            tipe = rdr["type"].ToString();

                        lst.Add(new viewNotulen
                        {
                            id_1 = Convert.ToInt32(rdr["id"]),
                            ddate = string.Format("{0:dd-MM-yyyy }", rdr["tgl"]),
                            subject = rdr["prihal"].ToString(),
                            locate  = rdr["tempat"].ToString(),
                            type = tipe


                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }
        public int CRUDnotulen_1(viewNotulen Note, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mNotulen", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_1", Note.id_1);
                com.Parameters.AddWithValue("@Desc", Note.subject);
                com.Parameters.AddWithValue("@Ddate", Note.ddate);
                com.Parameters.AddWithValue("@Locate", Note.locate);
                com.Parameters.AddWithValue("@Type", Note.type);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addNotulen_1");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updNotulen_1");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delNotulen_1");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewNotulen> viewNotulen_2(int id, char opt)
        {
            List<viewNotulen> lst = new List<viewNotulen>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mNotulen", con);
                com.CommandType = CommandType.StoredProcedure;
                if (opt == 'A')
                {
                    com.Parameters.AddWithValue("@ID_1", id);
                    com.Parameters.AddWithValue("@Action", "vNotulen_2");
                }
                else
                {
                    com.Parameters.AddWithValue("@ID_2", id);
                    com.Parameters.AddWithValue("@Action", "vNotulen_2_ByID");
                }
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewNotulen
                        {
                            id_1 = Convert.ToInt32(rdr["id_notulen_1"]),
                            id_2 = Convert.ToInt32(rdr["id"]),
                            name = rdr["nama"].ToString(),
                            agensi = rdr["agensi"].ToString()

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDnotulen_2(viewNotulen Note, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mNotulen", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_1", Note.id_1);
                com.Parameters.AddWithValue("@ID_2", Note.id_2);
                com.Parameters.AddWithValue("@Name", Note.name);
                com.Parameters.AddWithValue("@Agensi", Note.agensi);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addNotulen_2");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updNotulen_2");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delNotulen_2");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewNotulen> viewNotulen_3(int id, char opt)
        {
            int pdcaid, pdca;
            string nmprog, tgltarget;
            List<viewNotulen> lst = new List<viewNotulen>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mNotulen", con);
                com.CommandType = CommandType.StoredProcedure;
                if (opt == 'A')
                {
                    com.Parameters.AddWithValue("@ID_1", id);
                    com.Parameters.AddWithValue("@Action", "vNotulen_3");
                }
                else
                {
                    com.Parameters.AddWithValue("@ID_3", id);
                    com.Parameters.AddWithValue("@Action", "vNotulen_3_ByID");
                }
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (opt == 'A')
                        {
                            lst.Add(new viewNotulen
                            {
                                id_1 = Convert.ToInt32(rdr["id_notulen_1"]),
                                id_3 = Convert.ToInt32(rdr["id"]),
                                matter = rdr["bahasan"].ToString(),
                                pic = rdr["pic"].ToString(),
                                target = string.Format("{0:dd-MM-yyyy }", rdr["target"])
                            });
                        } else
                        {
                            if (rdr["pdca"] == DBNull.Value)
                                pdca = 0;
                            else
                                pdca = Convert.ToInt32(rdr["pdca"]);

                            if (rdr["pdca_id"] == DBNull.Value)
                                pdcaid = 0;
                            else
                                pdcaid = Convert.ToInt32(rdr["pdca_id"]);

                            if (rdr["program"] == DBNull.Value)
                                nmprog = "";
                            else
                                nmprog = rdr["program"].ToString();
                            

                            if (rdr["target"] == DBNull.Value)
                                tgltarget = "";
                            else
                                tgltarget = string.Format("{0:dd-MM-yyyy }", rdr["target"]);

                            lst.Add(new viewNotulen
                            {
                                id_1 = Convert.ToInt32(rdr["id_notulen_1"]),
                                id_3 = Convert.ToInt32(rdr["id"]),
                                matter = rdr["bahasan"].ToString(),
                                plann = rdr["rtl"].ToString(),
                                pic = rdr["pic"].ToString(),
                                pdca = pdca,
                                pdca_id = pdcaid,
                                nameprog = nmprog,
                                target = tgltarget
                            });

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }
        public int CRUDnotulen_3(viewNotulen Note, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mNotulen", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_1", Note.id_1);
                com.Parameters.AddWithValue("@ID_3", Note.id_3);
                com.Parameters.AddWithValue("@Bahas", Note.matter);
                com.Parameters.AddWithValue("@Rtl", Note.plann);
                com.Parameters.AddWithValue("@Pic", Note.pic);
                com.Parameters.AddWithValue("@Target", Note.target);
                com.Parameters.AddWithValue("@Pdca", Note.pdca);
                com.Parameters.AddWithValue("@ID_pdca", Note.pdca_id);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addNotulen_3");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updNotulen_3");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delNotulen_3");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        /*--------PDCA---------------*/
        public List<viewPDCA> viewPDCA(int id, char opt)
        {
            string dept;
            List<viewPDCA> lst = new List<viewPDCA>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA", con);
                com.CommandType = CommandType.StoredProcedure;
                if (opt == 'A')
                    com.Parameters.AddWithValue("@Action", "vPDCA");
                else
                {
                    com.Parameters.AddWithValue("@ID", id);
                    com.Parameters.AddWithValue("@Action", "vPDCA_ByID");
                }
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["dept"] == DBNull.Value)
                            dept = "";
                        else
                            dept = rdr["dept"].ToString();

                        lst.Add(new viewPDCA
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            tgl = string.Format("{0:dd-MM-yyyy }", rdr["tgl"]),
                            program = rdr["program"].ToString(),
                            masalah = rdr["masalah"].ToString(),
                            linkDept = rdr["linkDept"].ToString(),
                            leader = rdr["leader"].ToString(),
                            member = rdr["member"].ToString(),
                            dept = dept

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDPDCA(viewPDCA PDCA, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", PDCA.id);
                com.Parameters.AddWithValue("@Program", PDCA.program);
                com.Parameters.AddWithValue("@Ddate", PDCA.tgl);
                com.Parameters.AddWithValue("@Masalah", PDCA.masalah);
                com.Parameters.AddWithValue("@LinkDept", PDCA.linkDept);
                com.Parameters.AddWithValue("@Leader", PDCA.leader);
                com.Parameters.AddWithValue("@Member", PDCA.member);
                com.Parameters.AddWithValue("@Dept", PDCA.dept);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addPDCA");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updPDCA");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delPDCA");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewPlan> viewPDCAPLAN(int id, char opt)
        {
            string w1, w2, w3, w4, w5, root, count1, ben1, chal1, count2, ben2, chal2;
            List<viewPlan> lst = new List<viewPlan>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Plan", con);
                com.CommandType = CommandType.StoredProcedure;
                if (opt == 'A')
                {
                    com.Parameters.AddWithValue("@ID_Pdca", id);
                    com.Parameters.AddWithValue("@Action", "vPlan");
                }
                else
                {
                    com.Parameters.AddWithValue("@ID", id);
                    com.Parameters.AddWithValue("@Action", "vPlan_ByID");
                }
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["why1"] == DBNull.Value)
                            w1 = "";
                        else
                            w1 = rdr["why1"].ToString();

                        if (rdr["why2"] == DBNull.Value)
                            w2 = "";
                        else
                            w2 = rdr["why2"].ToString();

                        if (rdr["why3"] == DBNull.Value)
                            w3 = "";
                        else
                            w3 = rdr["why3"].ToString();

                        if (rdr["why4"] == DBNull.Value)
                            w4 = "";
                        else
                            w4 = rdr["why4"].ToString();

                        if (rdr["why5"] == DBNull.Value)
                            w5 = "";
                        else
                            w5 = rdr["why5"].ToString();

                        if (rdr["rootcause"] == DBNull.Value)
                            root = "";
                        else
                            root = rdr["rootcause"].ToString();

                        if (rdr["countermeasure1"] == DBNull.Value)
                            count1 = "";
                        else
                            count1 = rdr["countermeasure1"].ToString();

                        if (rdr["benefit1"] == DBNull.Value)
                            ben1 = "";
                        else
                            ben1 = rdr["benefit1"].ToString();

                        if (rdr["challenge1"] == DBNull.Value)
                            chal1 = "";
                        else
                            chal1 = rdr["challenge1"].ToString();

                        if (rdr["countermeasure2"] == DBNull.Value)
                            count2 = "";
                        else
                            count2 = rdr["countermeasure2"].ToString();

                        if (rdr["benefit2"] == DBNull.Value)
                            ben2 = "";
                        else
                            ben2 = rdr["benefit2"].ToString();

                        if (rdr["challenge2"] == DBNull.Value)
                            chal2 = "";
                        else
                            chal2 = rdr["challenge2"].ToString();

                        lst.Add(new viewPlan
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            id_pdca = Convert.ToInt32(rdr["id_pdca"]),
                            problem = rdr["problem"].ToString(),
                            goal = rdr["goal"].ToString(),
                            why1 = w1,
                            why2 = w2,
                            why3 = w3,
                            why4 = w4,
                            why5 = w5,
                            root = root,
                            count1 = count1,
                            benefit1 = ben1,
                            challenge1 = chal1,
                            count2 = count2,
                            benefit2 = ben2,
                            challenge2 = chal2

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDPLAN(viewPlan PDCA, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Plan", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", PDCA.id);
                com.Parameters.AddWithValue("@ID_Pdca", PDCA.id_pdca);
                com.Parameters.AddWithValue("@Problem", PDCA.problem);
                com.Parameters.AddWithValue("@Goal", PDCA.goal);
                com.Parameters.AddWithValue("@Why1", PDCA.why1);
                com.Parameters.AddWithValue("@Why2", PDCA.why2);
                com.Parameters.AddWithValue("@Why3", PDCA.why3);
                com.Parameters.AddWithValue("@Why4", PDCA.why4);
                com.Parameters.AddWithValue("@Why5", PDCA.why5);
                com.Parameters.AddWithValue("@Rootcause", PDCA.root);
                com.Parameters.AddWithValue("@CounterMeasure1", PDCA.count1);
                com.Parameters.AddWithValue("@Benefit1", PDCA.benefit1);
                com.Parameters.AddWithValue("@Challenge1", PDCA.challenge1);
                com.Parameters.AddWithValue("@CounterMeasure2", PDCA.count2);
                com.Parameters.AddWithValue("@Benefit2", PDCA.benefit2);
                com.Parameters.AddWithValue("@Challenge2", PDCA.challenge2);

                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addPlan");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updPlan");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delPlan");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewPdca_DO> viewPdcaDO_1(int id, char opt)
        {
            List<viewPdca_DO> lst = new List<viewPdca_DO>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Do", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_Pdca", id);
                com.Parameters.AddWithValue("@ID", id);
                if (opt == 'A')
                    com.Parameters.AddWithValue("@Action", "vPDCA_DO_1");
                else
                    com.Parameters.AddWithValue("@Action", "vPDCA_DO_1_ByID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPdca_DO
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            id_pdca = Convert.ToInt32(rdr["id_pdca"]),
                            containment = rdr["containment"].ToString(),
                            criteria = rdr["criteriaEffective"].ToString()

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDPdcaDO_1(viewPdca_DO PDCA, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Do", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", PDCA.id);
                com.Parameters.AddWithValue("@ID_Pdca", PDCA.id_pdca);
                com.Parameters.AddWithValue("@Containment", PDCA.containment);
                com.Parameters.AddWithValue("@Criteria", PDCA.criteria);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addPDCA_DO_1");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updPDCA_DO_1");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delPDCA_DO_1");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewPdca_DO> viewPdcaDO_2(int id, char opt)
        {
            List<viewPdca_DO> lst = new List<viewPdca_DO>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Do", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_Pdca_Do", id);
                com.Parameters.AddWithValue("@ID", id);
                if (opt == 'A')
                    com.Parameters.AddWithValue("@Action", "vPDCA_DO_2");
                else
                    com.Parameters.AddWithValue("@Action", "vPDCA_DO_2_ByID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPdca_DO
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            id_pdca_do = Convert.ToInt32(rdr["id_pdca_do"]),
                            task = rdr["task"].ToString(),
                            pic = rdr["pic"].ToString(),
                            dDeadline = string.Format("{0:dd-MM-yyyy }", rdr["ddeadline"]),
                            completed = Convert.ToInt16(rdr["completed"])

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDPdcaDO_2(viewPdca_DO PDCA, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Do", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", PDCA.id);
                com.Parameters.AddWithValue("@ID_Pdca_Do", PDCA.id_pdca_do);
                com.Parameters.AddWithValue("@Task", PDCA.task);
                com.Parameters.AddWithValue("@Pic", PDCA.pic);
                com.Parameters.AddWithValue("@dDeadline", PDCA.dDeadline);
                com.Parameters.AddWithValue("@Completed", PDCA.completed);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addPDCA_DO_2");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updPDCA_DO_2");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delPDCA_DO_2");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewPdca_Check> viewPdcaCheck(int id, char opt)
        {
            List<viewPdca_Check> lst = new List<viewPdca_Check>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Check", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_Pdca", id);
                com.Parameters.AddWithValue("@ID", id);
                if (opt == 'A')
                    com.Parameters.AddWithValue("@Action", "vPDCA_Ch");
                else
                    com.Parameters.AddWithValue("@Action", "vPDCA_Ch_ByID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPdca_Check
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            id_pdca = Convert.ToInt32(rdr["id_pdca"]),
                            testResult = rdr["testResult"].ToString(),
                            success = rdr["success"].ToString(),
                            area = rdr["area"].ToString()

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDPdcaCheck(viewPdca_Check PDCA, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Check", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", PDCA.id);
                com.Parameters.AddWithValue("@ID_Pdca", PDCA.id_pdca);
                com.Parameters.AddWithValue("@Testresult", PDCA.testResult);
                com.Parameters.AddWithValue("@Success", PDCA.success);
                com.Parameters.AddWithValue("@Area", PDCA.area);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addPDCA_Ch");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updPDCA_Ch");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delPDCA_Ch");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewPdca_Act> viewPdcaAct_1(int id, char opt)
        {
            List<viewPdca_Act> lst = new List<viewPdca_Act>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Act", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_Pdca", id);
                com.Parameters.AddWithValue("@ID", id);
                if (opt == 'A')
                    com.Parameters.AddWithValue("@Action", "vPDCA_Act_1");
                else
                    com.Parameters.AddWithValue("@Action", "vPDCA_Act_1_ByID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPdca_Act
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            id_pdca = Convert.ToInt32(rdr["id_pdca"]),
                            testSTD = rdr["testSTD"].ToString()

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDPdcaAct_1(viewPdca_Act PDCA, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Act", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", PDCA.id);
                com.Parameters.AddWithValue("@ID_Pdca", PDCA.id_pdca);
                com.Parameters.AddWithValue("@TestSTD", PDCA.testSTD);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addPDCA_Act_1");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updPDCA_Act_1");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delPDCA_Act_1");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

        public List<viewPdca_Act> viewPdcaAct_2(int id, char opt)
        {
            List<viewPdca_Act> lst = new List<viewPdca_Act>();
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Act", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_Pdca_Act", id);
                com.Parameters.AddWithValue("@ID", id);
                if (opt == 'A')
                    com.Parameters.AddWithValue("@Action", "vPDCA_Act_2");
                else
                    com.Parameters.AddWithValue("@Action", "vPDCA_Act_2_ByID");
                try
                {
                    con.Open();
                    SqlDataReader rdr = com.ExecuteReader();
                    while (rdr.Read())
                    {
                        lst.Add(new viewPdca_Act
                        {
                            id = Convert.ToInt32(rdr["id"]),
                            id_pdca_act = Convert.ToInt32(rdr["id_pdca_act"]),
                            task = rdr["task"].ToString(),
                            pic = rdr["pic"].ToString(),
                            dDeadline = string.Format("{0:dd-MM-yyyy }", rdr["ddeadline"]),
                            completed = Convert.ToInt16(rdr["completed"])

                        });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return lst;
            }
        }

        public int CRUDPdcaAct_2(viewPdca_Act PDCA, char ch)
        {
            int i;
            using (SqlConnection con = new SqlConnection(csppic))
            {
                SqlCommand com = new SqlCommand("sp_mPDCA_Act", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", PDCA.id);
                com.Parameters.AddWithValue("@ID_Pdca", PDCA.id_pdca);
                com.Parameters.AddWithValue("@ID_Pdca_Act", PDCA.id_pdca_act);
                com.Parameters.AddWithValue("@Task", PDCA.task);
                com.Parameters.AddWithValue("@Pic", PDCA.pic);
                com.Parameters.AddWithValue("@dDeadline", PDCA.dDeadline);
                com.Parameters.AddWithValue("@Completed", PDCA.completed);
                if (ch == 'I')
                    com.Parameters.AddWithValue("@Action", "addPDCA_Act_2");
                else if (ch == 'U')
                    com.Parameters.AddWithValue("@Action", "updPDCA_Act_2");
                else if (ch == 'D')
                    com.Parameters.AddWithValue("@Action", "delPDCA_Act_2");
                try
                {
                    con.Open();
                    i = com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
                return i;

            }
        }

    }

}


