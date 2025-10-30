namespace MyKosHub
{
    partial class DashboardPenghuni
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardPenghuni));
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnHome = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.pnRent = new System.Windows.Forms.Panel();
            this.buttonPesanLayanan = new System.Windows.Forms.Button();
            this.pnBill = new System.Windows.Forms.Panel();
            this.buttonBill = new System.Windows.Forms.Button();
            this.pnSettings = new System.Windows.Forms.Panel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.pnLogout = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.sidebar.SuspendLayout();
            this.pnHome.SuspendLayout();
            this.pnRent.SuspendLayout();
            this.pnBill.SuspendLayout();
            this.pnSettings.SuspendLayout();
            this.pnLogout.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(226)))), ((int)(((byte)(207)))));
            this.panel1.Controls.Add(this.btnHam);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1848, 51);
            this.panel1.TabIndex = 2;
            // 
            // btnHam
            // 
            this.btnHam.Image = ((System.Drawing.Image)(resources.GetObject("btnHam.Image")));
            this.btnHam.Location = new System.Drawing.Point(12, 8);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(50, 37);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnHam.TabIndex = 7;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Menu";
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.sidebar.Controls.Add(this.pnHome);
            this.sidebar.Controls.Add(this.pnRent);
            this.sidebar.Controls.Add(this.pnBill);
            this.sidebar.Controls.Add(this.pnSettings);
            this.sidebar.Controls.Add(this.pnLogout);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 51);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.sidebar.Size = new System.Drawing.Size(226, 919);
            this.sidebar.TabIndex = 4;
            // 
            // pnHome
            // 
            this.pnHome.Controls.Add(this.buttonHome);
            this.pnHome.Location = new System.Drawing.Point(3, 33);
            this.pnHome.Name = "pnHome";
            this.pnHome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnHome.Size = new System.Drawing.Size(228, 48);
            this.pnHome.TabIndex = 3;
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Image = ((System.Drawing.Image)(resources.GetObject("buttonHome.Image")));
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.Location = new System.Drawing.Point(-12, -14);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonHome.Size = new System.Drawing.Size(262, 79);
            this.buttonHome.TabIndex = 2;
            this.buttonHome.Text = "                 Home";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click_1);
            // 
            // pnRent
            // 
            this.pnRent.Controls.Add(this.buttonPesanLayanan);
            this.pnRent.Location = new System.Drawing.Point(3, 87);
            this.pnRent.Name = "pnRent";
            this.pnRent.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnRent.Size = new System.Drawing.Size(228, 48);
            this.pnRent.TabIndex = 7;
            // 
            // buttonPesanLayanan
            // 
            this.buttonPesanLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.buttonPesanLayanan.ForeColor = System.Drawing.Color.White;
            this.buttonPesanLayanan.Image = ((System.Drawing.Image)(resources.GetObject("buttonPesanLayanan.Image")));
            this.buttonPesanLayanan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPesanLayanan.Location = new System.Drawing.Point(-12, -14);
            this.buttonPesanLayanan.Name = "buttonPesanLayanan";
            this.buttonPesanLayanan.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonPesanLayanan.Size = new System.Drawing.Size(262, 79);
            this.buttonPesanLayanan.TabIndex = 2;
            this.buttonPesanLayanan.Text = "              Pesan Layanan";
            this.buttonPesanLayanan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPesanLayanan.UseVisualStyleBackColor = false;
            this.buttonPesanLayanan.Click += new System.EventHandler(this.buttonPesanLayanan_Click);
            // 
            // pnBill
            // 
            this.pnBill.Controls.Add(this.buttonBill);
            this.pnBill.Location = new System.Drawing.Point(3, 141);
            this.pnBill.Name = "pnBill";
            this.pnBill.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnBill.Size = new System.Drawing.Size(228, 48);
            this.pnBill.TabIndex = 9;
            // 
            // buttonBill
            // 
            this.buttonBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.buttonBill.ForeColor = System.Drawing.Color.White;
            this.buttonBill.Image = ((System.Drawing.Image)(resources.GetObject("buttonBill.Image")));
            this.buttonBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBill.Location = new System.Drawing.Point(-12, -14);
            this.buttonBill.Name = "buttonBill";
            this.buttonBill.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonBill.Size = new System.Drawing.Size(262, 79);
            this.buttonBill.TabIndex = 2;
            this.buttonBill.Text = "              Pembayaran";
            this.buttonBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBill.UseVisualStyleBackColor = false;
            this.buttonBill.Click += new System.EventHandler(this.buttonBill_Click);
            // 
            // pnSettings
            // 
            this.pnSettings.Controls.Add(this.buttonSettings);
            this.pnSettings.Location = new System.Drawing.Point(3, 195);
            this.pnSettings.Name = "pnSettings";
            this.pnSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnSettings.Size = new System.Drawing.Size(228, 48);
            this.pnSettings.TabIndex = 6;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(-12, -14);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonSettings.Size = new System.Drawing.Size(262, 79);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "              Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.buttonLogout);
            this.pnLogout.Location = new System.Drawing.Point(3, 249);
            this.pnLogout.Name = "pnLogout";
            this.pnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnLogout.Size = new System.Drawing.Size(228, 48);
            this.pnLogout.TabIndex = 7;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogout.Image")));
            this.buttonLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.Location = new System.Drawing.Point(-12, -14);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonLogout.Size = new System.Drawing.Size(262, 79);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "              Logout";
            this.buttonLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // DashboardPenghuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "DashboardPenghuni";
            this.Text = "DashboardPenghuni";
            this.Load += new System.EventHandler(this.DashboardPenghuni_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.pnHome.ResumeLayout(false);
            this.pnRent.ResumeLayout(false);
            this.pnBill.ResumeLayout(false);
            this.pnSettings.ResumeLayout(false);
            this.pnLogout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnHam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel pnHome;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel pnBill;
        private System.Windows.Forms.Button buttonBill;
        private System.Windows.Forms.Panel pnRent;
        private System.Windows.Forms.Button buttonPesanLayanan;
        private System.Windows.Forms.Panel pnSettings;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button buttonLogout;
    }
}