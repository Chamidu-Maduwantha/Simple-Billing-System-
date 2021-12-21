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

namespace Billing_Software
{
    public partial class ViewBills : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SimpleBillingCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public ViewBills()
        {
            InitializeComponent();
        }

        private void ViewBills_Load(object sender, EventArgs e)
        {
            fillGrid();
            totalBillSales();
        }

        private void btnViewBills_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("Select * From TblHeaderData where BillDate between '"+dateTimePicker1.Value.ToString("MM/dd/yyyy")+"' and '"+dateTimePicker2.Value.ToString("MM/dd/yyyy")+"' order by BillNo asc",con);
            DataSet ds = new DataSet();
            da.Fill(ds, "TblHeaderData");
            dataGridView1.DataSource = ds.Tables["TblHeaderData"];
            con.Close();
            totalBillSales();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            textBox1.Text = dr.Cells[0].Value.ToString();
        }

        private void btnDeleteBills_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Select Bill No for Delete");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("You Want to Delete Bill", "Deleting Bill", MessageBoxButtons.YesNo);
            if(dialogResult==DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlCommand cmd1 = new SqlCommand();
                    con.Open();
                    cmd = new SqlCommand("Delete From TblHeaderData where BillNo='"+textBox1.Text+"'",con);
                    cmd1 = new SqlCommand("Delete From TblRowData where BillNo='"+textBox1.Text+"'", con);

                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    fillGrid();
                    totalBillSales();
                }
            else if(dialogResult==DialogResult.No)
                {

                }
            }
        }
        public void fillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from TblHeaderData order by BillNo asc", con);
            con.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void totalBillSales()
        {
            //no.of bills
            txtTotalBills.Text = dataGridView1.Rows.Count.ToString();

            //Total Sales Amount
            double sum = 0;
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);

            }
            txtTotalSales.Text = sum.ToString();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateBill ub = new UpdateBill();
            ub.txtBillNo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ub.txtBillTotal.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ub.txtDisAmount.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            ub.txtPay.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            
            ub.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
