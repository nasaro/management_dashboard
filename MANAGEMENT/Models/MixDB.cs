using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.ComponentModel;
using System.Collections;

namespace MANAGEMENT.Models
{
    public class MixDB
    {
        string cs = ConfigurationManager.ConnectionStrings["DBKPI"].ConnectionString;
        string csppic = ConfigurationManager.ConnectionStrings["DBKPIPPIC"].ConnectionString;

        public List<FOHModels> RptFOHDetail(int month, int year)
        {
            decimal val1, val2, val3, val4, val5, val11, valpda;
            decimal totval1 = 0, totval2 = 0, totval3 = 0, totval4 = 0, totval5 = 0, totval11 = 0, totavg = 0;
            String dCheck;
            string strCommand, tglA, blnA, thnA, spBegda;

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

                        /*-----------------
                         * trick for conection another svr
                         * -----------*/
                        val11 = 0;
                        valpda = 0;
                        dCheck = String.Format("{0:dd-MM-yyyy}", rdr["ddate"]);
                        tglA = dCheck.Substring(0, 2);
                        blnA = dCheck.Substring(3, 2);
                        thnA = dCheck.Substring(6, 4);
                        spBegda = thnA + "/" + blnA + "/" + tglA;
                        strCommand = "select dPDEDate, sum(iqty*iWeight) as pda from tProductdeliveryevidence1,tProductDeliveryEvidence3 where tProductdeliveryevidence1.cPDECode = tProductdeliveryevidence3.cPDECode and cPDETYpe = 'PDA' and dPDEDate = '" + spBegda + "' group by dPDEDate order by dPDEDate";
                        using (SqlConnection con80 = new SqlConnection(cs))
                        {
                            SqlCommand com80 = new SqlCommand(strCommand, con80);
                            com80.CommandType = CommandType.Text;
                            try
                            {
                                con80.Open();
                                SqlDataReader rdr80 = com80.ExecuteReader();
                                while (rdr80.Read())
                                {
                                    if (rdr80["pda"] == DBNull.Value)
                                        val11 = 0;
                                    else
                                        val11 = Math.Round(Convert.ToDecimal(rdr80["pda"]), 2);
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                con80.Close();
                                con80.Dispose();
                            }
                        }
                        if (val11 != 0)
                        {
                            valpda = val5 * Convert.ToDecimal(0.88) / val11;
                        }
                        totval11 = totval11 + val11;
                        totavg = totavg + valpda;
                        /*-----------batas-------------*/
                        lst.Add(new FOHModels
                        {
                            ddate = string.Format("{0:dd-MM-yyyy}", rdr["ddate"]),
                            kwhbebanpuncak = val1,
                            kwhbebannormal = val2,
                            rpbebanpuncak = val3,
                            rpbebannormal = val4,
                            rpbebann = val5,
                            pda = val11,
                            avgpda = valpda
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
                            rpbebann = totval5,
                            pda = totval11,
                            avgpda = totavg
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

    }
}