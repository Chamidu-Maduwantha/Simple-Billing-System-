using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Billing_Software
{
    public partial class SalesReport : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SimpleBillingCon);
        ReportDocument cryrpt = new ReportDocument();
        SqlDataAdapter da;
        public SalesReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblHeaderData where BillDate between '"+dateTimePicker1.Value.ToString("MM/dd/yyyy")+"' and '"+dateTimePicker2.Value.ToString("MM/dd/yyyy")+"' order by BillNo", con);
            DataSet dst = new DataSet();
            da.Fill(dst, "SalesReportPrint");
            cryrpt.Load("SalesReports.rpt");
            cryrpt.SetDataSource(dst);
            crystalReportViewer1.ReportSource = cryrpt;
            con.Close();
        }
    }
}
