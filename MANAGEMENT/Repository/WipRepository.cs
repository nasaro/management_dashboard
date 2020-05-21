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

     }
}