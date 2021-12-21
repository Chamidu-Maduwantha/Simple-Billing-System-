
namespace Billing_Software
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billPrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSalesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billsBetweenSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.printToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.productToolStripMenuItem.Text = "Product";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBillToolStripMenuItem});
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.billingToolStripMenuItem.Text = "Billing";
            // 
            // newBillToolStripMenuItem
            // 
            this.newBillToolStripMenuItem.Name = "newBillToolStripMenuItem";
            this.newBillToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.newBillToolStripMenuItem.Text = "New Bill";
            this.newBillToolStripMenuItem.Click += new System.EventHandler(this.newBillToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewBillToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewBillToolStripMenuItem
            // 
            this.viewBillToolStripMenuItem.Name = "viewBillToolStripMenuItem";
            this.viewBillToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.viewBillToolStripMenuItem.Text = "View Bill";
            this.viewBillToolStripMenuItem.Click += new System.EventHandler(this.viewBillToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.billPrintToolStripMenuItem,
            this.printSalesReportToolStripMenuItem,
            this.billsBetweenSalesToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // billPrintToolStripMenuItem
            // 
            this.billPrintToolStripMenuItem.Name = "billPrintToolStripMenuItem";
            this.billPrintToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.billPrintToolStripMenuItem.Text = "Bill Print";
            this.billPrintToolStripMenuItem.Click += new System.EventHandler(this.billPrintToolStripMenuItem_Click);
            // 
            // printSalesReportToolStripMenuItem
            // 
            this.printSalesReportToolStripMenuItem.Name = "printSalesReportToolStripMenuItem";
            this.printSalesReportToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.printSalesReportToolStripMenuItem.Text = "Print Sales Report";
            this.printSalesReportToolStripMenuItem.Click += new System.EventHandler(this.printSalesReportToolStripMenuItem_Click);
            // 
            // billsBetweenSalesToolStripMenuItem
            // 
            this.billsBetweenSalesToolStripMenuItem.Name = "billsBetweenSalesToolStripMenuItem";
            this.billsBetweenSalesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.billsBetweenSalesToolStripMenuItem.Text = "Bills Between Dates";
            this.billsBetweenSalesToolStripMenuItem.Click += new System.EventHandler(this.billsBetweenSalesToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 553);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billPrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSalesReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billsBetweenSalesToolStripMenuItem;
    }
}