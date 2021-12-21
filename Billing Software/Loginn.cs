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
    public partial class Loginn : Form
    {
        public Loginn()
        {
            InitializeComponent();
        }

        private void Loginn_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            
            if(username=="ADMIN" && password=="admin123")
            {
                Form objMain = new Form();
                objMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Successfully");
            }
            
           
        }
    }
}
