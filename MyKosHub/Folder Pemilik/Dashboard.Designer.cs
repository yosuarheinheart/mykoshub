namespace MyKosHub
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.financialMenuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.pnLogout = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.pnSettings = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.Button();
            this.financialContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnFinance = new System.Windows.Forms.Panel();
            this.Finance = new System.Windows.Forms.Button();
            this.panelFinanceDetail = new System.Windows.Forms.Panel();
            this.btnManageFinance = new System.Windows.Forms.Button();
            this.pnlFinanceSummary = new System.Windows.Forms.Panel();
            this.buttonFinancialSummary = new System.Windows.Forms.Button();
            this.pnServices = new System.Windows.Forms.Panel();
            this.btnService = new System.Windows.Forms.Button();
            this.pnHome = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pnKamar = new System.Windows.Forms.Panel();
            this.btnKamar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKeluhan = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.pnLogout.SuspendLayout();
            this.pnSettings.SuspendLayout();
            this.financialContainer.SuspendLayout();
            this.pnFinance.SuspendLayout();
            this.panelFinanceDetail.SuspendLayout();
            this.pnlFinanceSummary.SuspendLayout();
            this.pnServices.SuspendLayout();
            this.pnHome.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.pnKamar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 0;
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
            // financialMenuTransition
            // 
            this.financialMenuTransition.Interval = 10;
            this.financialMenuTransition.Tick += new System.EventHandler(this.financialMenuTransition_Tick_1);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // pnLogout
            // 
            this.pnLogout.Controls.Add(this.buttonLogout);
            this.pnLogout.Location = new System.Drawing.Point(3, 351);
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
            // pnSettings
            // 
            this.pnSettings.Controls.Add(this.btnSettings);
            this.pnSettings.Location = new System.Drawing.Point(3, 297);
            this.pnSettings.Name = "pnSettings";
            this.pnSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnSettings.Size = new System.Drawing.Size(228, 48);
            this.pnSettings.TabIndex = 6;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(-12, -14);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(262, 79);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "              Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // financialContainer
            // 
            this.financialContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.financialContainer.Controls.Add(this.pnFinance);
            this.financialContainer.Controls.Add(this.panelFinanceDetail);
            this.financialContainer.Controls.Add(this.pnlFinanceSummary);
            this.financialContainer.Location = new System.Drawing.Point(0, 246);
            this.financialContainer.Margin = new System.Windows.Forms.Padding(0);
            this.financialContainer.Name = "financialContainer";
            this.financialContainer.Size = new System.Drawing.Size(228, 48);
            this.financialContainer.TabIndex = 7;
            // 
            // pnFinance
            // 
            this.pnFinance.Controls.Add(this.Finance);
            this.pnFinance.Location = new System.Drawing.Point(0, 0);
            this.pnFinance.Margin = new System.Windows.Forms.Padding(0);
            this.pnFinance.Name = "pnFinance";
            this.pnFinance.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnFinance.Size = new System.Drawing.Size(228, 48);
            this.pnFinance.TabIndex = 6;
            // 
            // Finance
            // 
            this.Finance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.Finance.ForeColor = System.Drawing.Color.White;
            this.Finance.Image = ((System.Drawing.Image)(resources.GetObject("Finance.Image")));
            this.Finance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Finance.Location = new System.Drawing.Point(-12, -14);
            this.Finance.Name = "Finance";
            this.Finance.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Finance.Size = new System.Drawing.Size(262, 79);
            this.Finance.TabIndex = 2;
            this.Finance.Text = "              Detail Keuangan";
            this.Finance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Finance.UseVisualStyleBackColor = false;
            this.Finance.Click += new System.EventHandler(this.Finance_Click);
            // 
            // panelFinanceDetail
            // 
            this.panelFinanceDetail.Controls.Add(this.btnManageFinance);
            this.panelFinanceDetail.Location = new System.Drawing.Point(0, 48);
            this.panelFinanceDetail.Margin = new System.Windows.Forms.Padding(0);
            this.panelFinanceDetail.Name = "panelFinanceDetail";
            this.panelFinanceDetail.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panelFinanceDetail.Size = new System.Drawing.Size(228, 48);
            this.panelFinanceDetail.TabIndex = 7;
            // 
            // btnManageFinance
            // 
            this.btnManageFinance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.btnManageFinance.ForeColor = System.Drawing.Color.White;
            this.btnManageFinance.Image = ((System.Drawing.Image)(resources.GetObject("btnManageFinance.Image")));
            this.btnManageFinance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageFinance.Location = new System.Drawing.Point(-12, -14);
            this.btnManageFinance.Name = "btnManageFinance";
            this.btnManageFinance.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnManageFinance.Size = new System.Drawing.Size(262, 79);
            this.btnManageFinance.TabIndex = 2;
            this.btnManageFinance.Text = "              Manage Pembayaran";
            this.btnManageFinance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageFinance.UseVisualStyleBackColor = false;
            this.btnManageFinance.Click += new System.EventHandler(this.btnManageFinance_Click);
            // 
            // pnlFinanceSummary
            // 
            this.pnlFinanceSummary.Controls.Add(this.buttonFinancialSummary);
            this.pnlFinanceSummary.Location = new System.Drawing.Point(0, 96);
            this.pnlFinanceSummary.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFinanceSummary.Name = "pnlFinanceSummary";
            this.pnlFinanceSummary.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlFinanceSummary.Size = new System.Drawing.Size(228, 48);
            this.pnlFinanceSummary.TabIndex = 8;
            // 
            // buttonFinancialSummary
            // 
            this.buttonFinancialSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.buttonFinancialSummary.ForeColor = System.Drawing.Color.White;
            this.buttonFinancialSummary.Image = ((System.Drawing.Image)(resources.GetObject("buttonFinancialSummary.Image")));
            this.buttonFinancialSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFinancialSummary.Location = new System.Drawing.Point(-12, -14);
            this.buttonFinancialSummary.Name = "buttonFinancialSummary";
            this.buttonFinancialSummary.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonFinancialSummary.Size = new System.Drawing.Size(262, 79);
            this.buttonFinancialSummary.TabIndex = 2;
            this.buttonFinancialSummary.Text = "              Laporan Keuangan";
            this.buttonFinancialSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFinancialSummary.UseVisualStyleBackColor = false;
            this.buttonFinancialSummary.Click += new System.EventHandler(this.buttonFinancialSummary_Click);
            // 
            // pnServices
            // 
            this.pnServices.Controls.Add(this.btnService);
            this.pnServices.Location = new System.Drawing.Point(3, 141);
            this.pnServices.Name = "pnServices";
            this.pnServices.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnServices.Size = new System.Drawing.Size(228, 48);
            this.pnServices.TabIndex = 5;
            // 
            // btnService
            // 
            this.btnService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnService.ForeColor = System.Drawing.Color.White;
            this.btnService.Image = ((System.Drawing.Image)(resources.GetObject("btnService.Image")));
            this.btnService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.Location = new System.Drawing.Point(-12, -14);
            this.btnService.Name = "btnService";
            this.btnService.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnService.Size = new System.Drawing.Size(262, 79);
            this.btnService.TabIndex = 2;
            this.btnService.Text = "              Manage Layanan";
            this.btnService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.UseVisualStyleBackColor = false;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
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
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            this.buttonHome.MouseLeave += new System.EventHandler(this.buttonHome_MouseLeave);
            this.buttonHome.MouseHover += new System.EventHandler(this.buttonHome_MouseHover);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.sidebar.Controls.Add(this.pnHome);
            this.sidebar.Controls.Add(this.pnKamar);
            this.sidebar.Controls.Add(this.pnServices);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.financialContainer);
            this.sidebar.Controls.Add(this.pnSettings);
            this.sidebar.Controls.Add(this.pnLogout);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 51);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.sidebar.Size = new System.Drawing.Size(226, 919);
            this.sidebar.TabIndex = 1;
            // 
            // pnKamar
            // 
            this.pnKamar.Controls.Add(this.btnKamar);
            this.pnKamar.Location = new System.Drawing.Point(3, 87);
            this.pnKamar.Name = "pnKamar";
            this.pnKamar.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnKamar.Size = new System.Drawing.Size(228, 48);
            this.pnKamar.TabIndex = 11;
            // 
            // btnKamar
            // 
            this.btnKamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnKamar.ForeColor = System.Drawing.Color.White;
            this.btnKamar.Image = ((System.Drawing.Image)(resources.GetObject("btnKamar.Image")));
            this.btnKamar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKamar.Location = new System.Drawing.Point(-12, -14);
            this.btnKamar.Name = "btnKamar";
            this.btnKamar.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKamar.Size = new System.Drawing.Size(262, 79);
            this.btnKamar.TabIndex = 2;
            this.btnKamar.Text = "              Manage Kamar";
            this.btnKamar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKamar.UseVisualStyleBackColor = false;
            this.btnKamar.Click += new System.EventHandler(this.btnKamar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnKeluhan);
            this.panel2.Location = new System.Drawing.Point(3, 195);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(228, 48);
            this.panel2.TabIndex = 8;
            // 
            // btnKeluhan
            // 
            this.btnKeluhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnKeluhan.ForeColor = System.Drawing.Color.White;
            this.btnKeluhan.Image = ((System.Drawing.Image)(resources.GetObject("btnKeluhan.Image")));
            this.btnKeluhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKeluhan.Location = new System.Drawing.Point(-12, -14);
            this.btnKeluhan.Name = "btnKeluhan";
            this.btnKeluhan.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnKeluhan.Size = new System.Drawing.Size(262, 79);
            this.btnKeluhan.TabIndex = 2;
            this.btnKeluhan.Text = "              Manage Keluhan";
            this.btnKeluhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKeluhan.UseVisualStyleBackColor = false;
            this.btnKeluhan.Click += new System.EventHandler(this.btnKeluhan_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "Dashboard";
            this.Text = "++++++++++++++++++++++";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.pnLogout.ResumeLayout(false);
            this.pnSettings.ResumeLayout(false);
            this.financialContainer.ResumeLayout(false);
            this.pnFinance.ResumeLayout(false);
            this.panelFinanceDetail.ResumeLayout(false);
            this.pnlFinanceSummary.ResumeLayout(false);
            this.pnServices.ResumeLayout(false);
            this.pnHome.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            this.pnKamar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer financialMenuTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.PictureBox btnHam;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pnLogout;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel pnSettings;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.FlowLayoutPanel financialContainer;
        private System.Windows.Forms.Panel pnFinance;
        private System.Windows.Forms.Button Finance;
        private System.Windows.Forms.Panel panelFinanceDetail;
        private System.Windows.Forms.Button btnManageFinance;
        private System.Windows.Forms.Panel pnlFinanceSummary;
        private System.Windows.Forms.Button buttonFinancialSummary;
        private System.Windows.Forms.Panel pnServices;
        private System.Windows.Forms.Button btnService;
        private System.Windows.Forms.Panel pnHome;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnKeluhan;
        private System.Windows.Forms.Panel pnKamar;
        private System.Windows.Forms.Button btnKamar;
    }
}