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
    public partial class NewBill : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.SimpleBillingCon);
        SqlCommand cmd;
        SqlDataReader dr;
        public NewBill()
        {
            InitializeComponent();
            txtDeleUpdate.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NewBill_Load(object sender, EventArgs e)
        {
            cmbProduct.Select();

            cmbProduct.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select ProName From TblProducts order by ProName asc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                cmbProduct.Items.Add(dr["ProName"].ToString());
            }
            con.Close();
            LoadBillNo();
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }
        public void LoadBillNo()
        {
            int a;
            string constr = (Properties.Settings.Default.SimpleBillingCon);
            con = new SqlConnection(constr);
            con.Open();
            string query = "Select Max(BillNo) From TblHeaderData";
            cmd = new SqlCommand(query, con);

            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                string val = dr[0].ToString();
                if(val=="")
                {
                    txtBillNo.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtBillNo.Text = a.ToString();
                }
                con.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cmbProduct.Text=="")
            {
                MessageBox.Show("Product Name is Empty");
            }
            else if(txtPrice.Text=="")
            {
                MessageBox.Show("Product Price is Empty");
            } else if(txtQty.Text=="")
            {
                MessageBox.Show("Product Qty is Empty");
            }
            else
            {
                if (txtDeleUpdate.Text == "")
                {
                    int row = 0;
                    dataGridView1.Rows.Add();
                    row = dataGridView1.Rows.Count - 1;
                    dataGridView1["ProductName", row].Value = cmbProduct.Text;
                    dataGridView1["Price", row].Value = txtPrice.Text;
                    dataGridView1["Qty", row].Value = txtQty.Text;
                    dataGridView1["Amount", row].Value = txtAmount.Text;
                    dataGridView1["BillNo", row].Value = txtBillNo.Text;
                    dataGridView1["Date", row].Value = dateTimePicker1.Value.ToString("dd-MM-yyyy");

                    dataGridView1.Refresh();
                    cmbProduct.Focus();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1];
                    }

                }
                else

                {
                   
                    int i = 0;
                    DataGridViewRow row = dataGridView1.Rows[i];
                    row.Cells[1].Value = cmbProduct.Text;
                    row.Cells[2].Value = txtPrice.Text;
                    row.Cells[3].Value = txtQty.Text;
                    row.Cells[4].Value = txtAmount.Text;

                    btnAdd.Text = "Add";
                }
                cleartextbox();
                gridTotal();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        int i;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            cmbProduct.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[2].Value.ToString();
            txtQty.Text = row.Cells[3].Value.ToString();
            txtAmount.Text = row.Cells[4].Value.ToString();
            txtDeleUpdate.Text = row.Cells[0].Value.ToString();

            btnAdd.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtDeleUpdate.Text=="")
            {
                MessageBox.Show("Select Product To Delete");
            }
            else
            {
                foreach(DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow) dataGridView1.Rows.Remove(row);
                }
                
            }
            btnAdd.Text = "Add";
            gridTotal();

            cleartextbox();
            
        }
        public void  cleartextbox()
        {
            cmbProduct.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtAmount.Text = "";
            txtDeleUpdate.Text = "";
        }
        public void CalAmount()
        {
            double a1, b1, i;
            double.TryParse(txtPrice.Text,out a1);
            double.TryParse(txtQty.Text, out b1);
            i = a1 * b1;
            if(i>0)
            {
                txtAmount.Text = i.ToString("C").Remove(0,1);
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            CalAmount();
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            CalAmount();
        }
        public void gridTotal()
        {
            double sum = 0;
            for(int i=0;i<dataGridView1.Rows.Count;++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txtBillTotal.Text = sum.ToString();

        }
        public void DisCal()
        {
            double a2, b2, i;
            double.TryParse(txtBillTotal.Text, out a2);
            double.TryParse(txtDisAmount.Text, out b2);
            i = a2 - b2;
            if(i>0)
            {
                txtPay.Text = i.ToString("C").Remove(0, 1);
            }

        }

        private void txtBillTotal_TextChanged(object sender, EventArgs e)
        {
            DisCal();
        }

        private void txtDisAmount_Leave(object sender, EventArgs e)
        {
            DisCal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count<1)
            {
                MessageBox.Show("Add Minimum One Product to Bill");
            }
            else
            {
                //save header data
                con.Open();
                cmd = new SqlCommand("Insert Into TblHeaderData (BillNo,BillDate,BillAmount,DisAmount,NetPay) values('"+txtBillNo.Text+"','"+dateTimePicker1.Value.ToString("MM/dd/yyyy")+"','"+txtBillTotal.Text+"','"+txtDisAmount.Text+"','"+txtPay.Text+"')", con);
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("Insert Into TblRowData (SlNo,ProductName,Price,Qty,Amount,BillNo) values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "')", con);
                    cmd1.ExecuteNonQuery();
                }
                dataGridView1.Rows.Clear();
                MessageBox.Show("Bill Saved");
                con.Close();

                Class1.strInv = txtBillNo.Text;

                LoadBillNo();
                cleartextbox();

                txtBillTotal.Text = "";
                txtDisAmount.Text = "";
                txtPay.Text = "";

                cmbProduct.Select();


                BillPrint bp = new BillPrint();
                bp.ShowDialog();

            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from TblProducts where ProName='"+cmbProduct.Text+"' ",con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                txtPrice.Text = dr[2].ToString();

            }
            con.Close();
        }
    }
}
