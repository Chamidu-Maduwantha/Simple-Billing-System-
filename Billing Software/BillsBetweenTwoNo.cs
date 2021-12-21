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
    public partial class BillsBetweenTwoNo : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SimpleBillingCon);
        ReportDocument cryrpt = new ReportDocument();
        SqlDataAdapter da;
        public BillsBetweenTwoNo()
        {
            InitializeComponent();
        }

        private void BillsBetweenTwoNo_Load(object sender, EventArgs e)
        {

        }

        private void btnFindBills_Click(object sender, EventArgs e)
        {

           
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"select TblHeaderData.BillNo,TblHeaderData.BillDate,TblHeaderData.BillAmount,TblHeaderData.DisAmount,TblHeaderData.NetPay, TblRowData.SlNo,TblRowData.ProductName,TblRowData.Price,TblRowData.Qty,TblRowData.Amount,TblRowData.BillNo from TblHeaderData inner join TblRowData on TblHeaderData.BillNo=TblRowData.BillNo where  TblHeaderData.BillNo between '"+textBox1.Text+"' and '"+textBox2.Text+"' ", con);
                DataSet dst = new DataSet();
                da.Fill(dst, "BillPrint");
                cryrpt.Load("billsbetweentwonumbers.rpt");
                cryrpt.SetDataSource(dst);
                crystalReportViewer1.ReportSource = cryrpt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
