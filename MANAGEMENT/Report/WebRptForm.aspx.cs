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
            string typePrint = string.Empty; ;
            var id = Session["id"];
            var toPrint = Session["TypePrint"];
            codeid = Convert.ToInt32(id);
            typePrint = Convert.ToString(toPrint);
            StiReport report = new StiReport();
            if (typePrint == "NOT1")
                report.Load(Server.MapPath("~/Report/Notulen_1.mrt"));
            else if (typePrint == "PDCA")
                report.Load(Server.MapPath("~/Report/PDCA.mrt"));

            report.Compile();
            report["parA"] = codeid;
            report.Render();
            StiWebViewer1.Report = report;
        }
    }
}