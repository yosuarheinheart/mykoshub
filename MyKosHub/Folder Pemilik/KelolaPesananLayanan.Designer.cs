namespace MyKosHub
{
    partial class KelolaPesananLayanan
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnManajemen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.optionRiwayat = new System.Windows.Forms.ComboBox();
            this.btnProses = new System.Windows.Forms.Button();
            this.btnEksporCSV = new System.Windows.Forms.Button();
            this.btnEksporTXT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(399, 389);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(929, 150);
            this.dataGridView1.TabIndex = 87;
            // 
            // btnManajemen
            // 
            this.btnManajemen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.btnManajemen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManajemen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManajemen.Location = new System.Drawing.Point(399, 267);
            this.btnManajemen.Name = "btnManajemen";
            this.btnManajemen.Size = new System.Drawing.Size(235, 43);
            this.btnManajemen.TabIndex = 85;
            this.btnManajemen.Text = "Manajemen Layanan";
            this.btnManajemen.UseVisualStyleBackColor = false;
            this.btnManajemen.Click += new System.EventHandler(this.btnManajemen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(692, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 79);
            this.label1.TabIndex = 84;
            this.label1.Text = "Daftar Pesanan";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.Lime;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirm.Location = new System.Drawing.Point(1058, 569);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(238, 42);
            this.buttonConfirm.TabIndex = 88;
            this.buttonConfirm.Text = "Konfirmasi";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.btnRiwayat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRiwayat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRiwayat.Location = new System.Drawing.Point(1184, 267);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(144, 43);
            this.btnRiwayat.TabIndex = 89;
            this.btnRiwayat.Text = "Histori";
            this.btnRiwayat.UseVisualStyleBackColor = false;
            this.btnRiwayat.Click += new System.EventHandler(this.btnRiwayat_Click);
            // 
            // optionRiwayat
            // 
            this.optionRiwayat.FormattingEnabled = true;
            this.optionRiwayat.Location = new System.Drawing.Point(1184, 336);
            this.optionRiwayat.Name = "optionRiwayat";
            this.optionRiwayat.Size = new System.Drawing.Size(144, 24);
            this.optionRiwayat.TabIndex = 90;
            this.optionRiwayat.SelectedIndexChanged += new System.EventHandler(this.optionRiwayat_SelectedIndexChanged);
            // 
            // btnProses
            // 
            this.btnProses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.btnProses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProses.Location = new System.Drawing.Point(829, 267);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(135, 43);
            this.btnProses.TabIndex = 91;
            this.btnProses.Text = "Proses";
            this.btnProses.UseVisualStyleBackColor = false;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // btnEksporCSV
            // 
            this.btnEksporCSV.BackColor = System.Drawing.Color.Aqua;
            this.btnEksporCSV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEksporCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEksporCSV.Location = new System.Drawing.Point(737, 569);
            this.btnEksporCSV.Name = "btnEksporCSV";
            this.btnEksporCSV.Size = new System.Drawing.Size(242, 42);
            this.btnEksporCSV.TabIndex = 92;
            this.btnEksporCSV.Text = "Ekspor CSV";
            this.btnEksporCSV.UseVisualStyleBackColor = false;
            this.btnEksporCSV.Click += new System.EventHandler(this.btnEkspor_Click);
            // 
            // btnEksporTXT
            // 
            this.btnEksporTXT.BackColor = System.Drawing.Color.Aqua;
            this.btnEksporTXT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEksporTXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEksporTXT.Location = new System.Drawing.Point(399, 569);
            this.btnEksporTXT.Name = "btnEksporTXT";
            this.btnEksporTXT.Size = new System.Drawing.Size(242, 42);
            this.btnEksporTXT.TabIndex = 93;
            this.btnEksporTXT.Text = "Ekspor TXT";
            this.btnEksporTXT.UseVisualStyleBackColor = false;
            this.btnEksporTXT.Click += new System.EventHandler(this.btnEksporTXT_Click);
            // 
            // KelolaPesananLayanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.btnEksporTXT);
            this.Controls.Add(this.btnEksporCSV);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.optionRiwayat);
            this.Controls.Add(this.btnRiwayat);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnManajemen);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "KelolaPesananLayanan";
            this.Text = "KelolaPesananLayanan";
            this.Load += new System.EventHandler(this.KelolaPesananLayanan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnManajemen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button btnRiwayat;
        private System.Windows.Forms.ComboBox optionRiwayat;
        private System.Windows.Forms.Button btnProses;
        private System.Windows.Forms.Button btnEksporCSV;
        private System.Windows.Forms.Button btnEksporTXT;
    }
}