using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_Software
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products p = new Products();
            p.MdiParent = this;
            p.Show();
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBill nb = new NewBill();
            nb.MdiParent = this;
            nb.Show();
        }

        private void viewBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBills vb = new ViewBills();
            vb.MdiParent = this;
            vb.Show();
        }

        private void printBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void billPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillPrint bp = new BillPrint();
            bp.MdiParent = this;
            bp.Show();

        }

        private void printSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReport sr = new SalesReport();
            sr.MdiParent = this;
            sr.Show();
        }

        private void billsBetweenSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillsBetweenTwoNo bbtn = new BillsBetweenTwoNo();
            bbtn.MdiParent = this;
            bbtn.Show();
            
        }
    }
}
