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
    public partial class Products : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SimpleBillingCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public Products()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProName.Text == "")
            {
                MessageBox.Show("Please Enter Product Name");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO TblProducts (ProName,ProPrice)VALUES ('" + txtProName.Text + "','"+txtPrice.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product Information Saved.....");
                    fillGrid();
                    cleartext();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void fillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("select * from TblProducts order by ProName asc  ", con);
            con.Close();
            SqlCommandBuilder cd = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            fillGrid();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            cleartext();
        }
        int i;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            txtProID.Text = row.Cells[0].Value.ToString();
            txtProName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProID.Text == "")
            {
                MessageBox.Show("Please Select Product to Update");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE TblProducts SET ProName='" + txtProName.Text + "',ProPrice='"+txtPrice.Text+"' where ProID='" + txtProID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product Info Updated");
                    fillGrid();
                    cleartext();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void cleartext()
        {
            txtProID.Text = "";
            txtProName.Text = "";
            txtPrice.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtProID.Text == "")
            {
                MessageBox.Show("Select Product to Delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Delete From TblProducts where ProID='" + txtProID.Text + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product Info Deleted...");
                    fillGrid();
                    cleartext();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
