using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stimulsoft.Report;

namespace MANAGEMENT.Report
{
    public partial class WebRptForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeid = 0;
            string typePrint = string.Empty;
            string typeOption = string.Empty;
            string typeChoice = string.Empty;
            var id = Session["id"];
            var toPrint = Session["TypePrint"];
            var toOption = Session["Option"];
            var toChoice = Session["TypeChoice"];
            codeid = Convert.ToInt32(id);
            typePrint = Convert.ToString(toPrint);
            typeOption = Convert.ToString(toOption);
            typeChoice = Convert.ToString(toChoice);
            StiReport report = new StiReport();
            if (typePrint == "NOT1")
                report.Load(Server.MapPath("~/Report/Notulen_1.mrt"));
            else if (typePrint == "PDCA")
                report.Load(Server.MapPath("~/Report/PDCA.mrt"));
            else if (typePrint == "DTL")
                report.Load(Server.MapPath("~/Report/AssetDetail.mrt"));
            else if (typePrint == "RKP")
                report.Load(Server.MapPath("~/Report/AssetRekap.mrt"));
            else if (typePrint == "EXP")
                report.Load(Server.MapPath("~/Report/AssetDetailExport.mrt"));
            else if (typePrint == "DIS")
                report.Load(Server.MapPath("~/Report/AssetDisposal.mrt"));

            report.Compile();
            if (typePrint == "NOT1" || typePrint == "PDCA")
            {
                report["parA"] = codeid;
            }
            else if (typePrint == "DTL" || typePrint == "RKP" || typePrint == "EXP")
            {
                report["parA"] = typeOption;
                report["Variable1"] = typeOption;
            }
            else if (typePrint == "DIS")
            {
                report["parA"] = typeOption;
                report["parB"] = typeChoice;
                if (typeChoice=="A") 
                    report["Variable1"] = typeOption;
                else
                    report["Variable1"] = typeOption.Substring(3,4);
            }
            report.Render();
            StiWebViewer1.Report = report;
        }
    }
}