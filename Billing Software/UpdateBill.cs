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
    public partial class UpdateBill : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SimpleBillingCon);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public UpdateBill()
        {
            InitializeComponent();
        }

        private void UpdateBill_Load(object sender, EventArgs e)
        {
            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From TblRowData where BillNo like ('" + txtBillNo.Text + "%')";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            cmbProduct.Select();

            cmbProduct.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select ProName From TblProducts order by ProName asc";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cmbProduct.Items.Add(dr["ProName"].ToString());
            }
            con.Close();
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            CalAmount();
        }
            public void CalAmount()
            {
                double a1, b1, i;
                double.TryParse(txtPrice.Text, out a1);
                double.TryParse(txtQty.Text, out b1);
                i = a1 * b1;
                if (i > 0)
                {
                    txtAmount.Text = i.ToString("C").Remove(0, 1);
                }
            }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            CalAmount();
        }
        private void LoadSerialNo()
        {
            int i = 1;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i;i++;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LoadSerialNo();
        }
        int i;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[1];
            txtDeleUpdate.Text = row.Cells[0].Value.ToString();
            cmbProduct.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[2].Value.ToString();
            txtQty.Text = row.Cells[3].Value.ToString();
            txtAmount.Text = row.Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow) dataGridView1.Rows.Remove(row);

                LoadSerialNo();
            }
            clearText();
            gridTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtDeleUpdate.Text=="")
            {
                for(int i=0;i<dataGridView1.Rows.Count-1;i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
                DataTable dt = dataGridView1.DataSource as DataTable;

                DataRow row1 = dt.NewRow();
                row1[1] = cmbProduct.Text.ToString();
                row1[2] = txtPrice.Text.ToString();
                row1[3] = txtQty.Text.ToString();
                row1[4] = txtAmount.Text.ToString();
                row1[5] = txtBillNo.Text.ToString();

                cmbProduct.Focus();
                dt.Rows.Add(row1);
            }
            else
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.Cells[1].Value = cmbProduct.Text;
                row.Cells[2].Value = txtPrice.Text;
                row.Cells[3].Value = txtQty.Text;
                row.Cells[4].Value = txtAmount.Text;
                row.Cells[5].Value = txtBillNo.Text;
            }
            clearText();
            gridTotal();
        }
        public void clearText()
        {
            cmbProduct.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtAmount.Text = "";
            txtDeleUpdate.Text = "";
        }
        public void DisCal()
        {
            double a2, b2, i;
            double.TryParse(txtBillTotal.Text, out a2);
            double.TryParse(txtDisAmount.Text, out b2);
            i = a2 - b2;
            if (i > 0)
            {
                txtPay.Text = i.ToString("C").Remove(0, 1);
            }

        }
        public void gridTotal()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txtBillTotal.Text = sum.ToString();

        }

        private void txtBillTotal_TextChanged(object sender, EventArgs e)
        {
            DisCal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete from TblRowData where BillNo='"+txtBillNo.Text+"' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // now save updated bill data
            try
            {
                
                for(int i=0;i<dataGridView1.Rows.Count;i++)
                {
                    
                    SqlCommand cmd1 = new SqlCommand("Insert Into TblRowData (SlNo,ProductName,Price,Qty,Amount,BillNo,Date) values('"+dataGridView1.Rows[i].Cells[0].Value.ToString()+ "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','"+dataGridView1.Rows[i].Cells[6].Value.ToString()+"') ", con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
                
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            //now update bill amount,discount and final amount
            try
            {
                con.Open();
                cmd = new SqlCommand("Update TblHeaderData set BillDate='"+ dateTimePicker1.Value.ToString("MM/dd/yyyy")+"',BillAmount='"+txtBillTotal.Text+"',DisAmount='"+txtDisAmount.Text+"',NetPay='"+txtPay.Text+"' where BillNo='"+txtBillNo.Text+"'  ",con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Bill Updated");

                Class1.strInv = txtBillNo.Text;

                this.Hide();
                BillPrint bp = new BillPrint();
                bp.Show();
                this.Close();
                
                txtBillTotal.Text = "";
                txtDisAmount.Text = "";
                txtPay.Text = "";

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            //hide this window
            this.Hide();
        }
    }
}
