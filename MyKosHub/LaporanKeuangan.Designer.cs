namespace MyKosHub
{
    partial class LaporanKeuangan
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSeluruh = new System.Windows.Forms.Button();
            this.buttonSewa = new System.Windows.Forms.Button();
            this.buttonLayanan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.filterAwal = new System.Windows.Forms.DateTimePicker();
            this.filterAkhir = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.btnShowLaporanKuartal = new System.Windows.Forms.Button();
            this.btnShowLaporanBulan = new System.Windows.Forms.Button();
            this.grupPeriode = new System.Windows.Forms.Panel();
            this.labelBulan = new System.Windows.Forms.Label();
            this.labelKuartal = new System.Windows.Forms.Label();
            this.labelTahun = new System.Windows.Forms.Label();
            this.opsiTahun = new System.Windows.Forms.ComboBox();
            this.btnPrintLaporan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.opsiBulan = new System.Windows.Forms.ComboBox();
            this.opsiKuartal = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grupPeriode.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(675, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 62);
            this.label1.TabIndex = 12;
            this.label1.Text = "Laporan Keuangan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(438, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(824, 369);
            this.dataGridView1.TabIndex = 13;
            // 
            // buttonSeluruh
            // 
            this.buttonSeluruh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.buttonSeluruh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSeluruh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeluruh.Location = new System.Drawing.Point(438, 205);
            this.buttonSeluruh.Name = "buttonSeluruh";
            this.buttonSeluruh.Size = new System.Drawing.Size(229, 28);
            this.buttonSeluruh.TabIndex = 97;
            this.buttonSeluruh.Text = "Sewa dan Layanan";
            this.buttonSeluruh.UseVisualStyleBackColor = false;
            // 
            // buttonSewa
            // 
            this.buttonSewa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.buttonSewa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSewa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSewa.Location = new System.Drawing.Point(1162, 205);
            this.buttonSewa.Name = "buttonSewa";
            this.buttonSewa.Size = new System.Drawing.Size(100, 28);
            this.buttonSewa.TabIndex = 99;
            this.buttonSewa.Text = "Sewa";
            this.buttonSewa.UseVisualStyleBackColor = false;
            // 
            // buttonLayanan
            // 
            this.buttonLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.buttonLayanan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLayanan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLayanan.Location = new System.Drawing.Point(1045, 205);
            this.buttonLayanan.Name = "buttonLayanan";
            this.buttonLayanan.Size = new System.Drawing.Size(100, 28);
            this.buttonLayanan.TabIndex = 100;
            this.buttonLayanan.Text = "Layanan";
            this.buttonLayanan.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(464, 648);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 29);
            this.label5.TabIndex = 102;
            this.label5.Text = "Tanggal Awal";
            // 
            // filterAwal
            // 
            this.filterAwal.Location = new System.Drawing.Point(430, 695);
            this.filterAwal.Name = "filterAwal";
            this.filterAwal.Size = new System.Drawing.Size(246, 22);
            this.filterAwal.TabIndex = 103;
            // 
            // filterAkhir
            // 
            this.filterAkhir.Location = new System.Drawing.Point(707, 695);
            this.filterAkhir.Name = "filterAkhir";
            this.filterAkhir.Size = new System.Drawing.Size(246, 22);
            this.filterAkhir.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(749, 648);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 105;
            this.label2.Text = "Tanggal Akhir";
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(1033, 651);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(229, 66);
            this.buttonReset.TabIndex = 106;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            // 
            // btnShowLaporanKuartal
            // 
            this.btnShowLaporanKuartal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnShowLaporanKuartal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowLaporanKuartal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLaporanKuartal.Location = new System.Drawing.Point(574, 763);
            this.btnShowLaporanKuartal.Name = "btnShowLaporanKuartal";
            this.btnShowLaporanKuartal.Size = new System.Drawing.Size(229, 66);
            this.btnShowLaporanKuartal.TabIndex = 107;
            this.btnShowLaporanKuartal.Text = "Tampilkan Laporan Kuartal";
            this.btnShowLaporanKuartal.UseVisualStyleBackColor = false;
            this.btnShowLaporanKuartal.Click += new System.EventHandler(this.btnShowLaporanKuartal_Click);
            // 
            // btnShowLaporanBulan
            // 
            this.btnShowLaporanBulan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnShowLaporanBulan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowLaporanBulan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLaporanBulan.Location = new System.Drawing.Point(870, 763);
            this.btnShowLaporanBulan.Name = "btnShowLaporanBulan";
            this.btnShowLaporanBulan.Size = new System.Drawing.Size(229, 66);
            this.btnShowLaporanBulan.TabIndex = 108;
            this.btnShowLaporanBulan.Text = "Tampilkan Laporan Bulanan";
            this.btnShowLaporanBulan.UseVisualStyleBackColor = false;
            this.btnShowLaporanBulan.Click += new System.EventHandler(this.btnShowLaporanBulan_Click);
            // 
            // grupPeriode
            // 
            this.grupPeriode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grupPeriode.Controls.Add(this.labelBulan);
            this.grupPeriode.Controls.Add(this.labelKuartal);
            this.grupPeriode.Controls.Add(this.labelTahun);
            this.grupPeriode.Controls.Add(this.opsiTahun);
            this.grupPeriode.Controls.Add(this.btnPrintLaporan);
            this.grupPeriode.Controls.Add(this.label3);
            this.grupPeriode.Controls.Add(this.opsiBulan);
            this.grupPeriode.Controls.Add(this.opsiKuartal);
            this.grupPeriode.Location = new System.Drawing.Point(1377, 256);
            this.grupPeriode.Name = "grupPeriode";
            this.grupPeriode.Size = new System.Drawing.Size(344, 369);
            this.grupPeriode.TabIndex = 109;
            this.grupPeriode.Visible = false;
            // 
            // labelBulan
            // 
            this.labelBulan.AutoSize = true;
            this.labelBulan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBulan.Location = new System.Drawing.Point(18, 202);
            this.labelBulan.Name = "labelBulan";
            this.labelBulan.Size = new System.Drawing.Size(85, 22);
            this.labelBulan.TabIndex = 115;
            this.labelBulan.Text = "Bulan    ";
            this.labelBulan.Visible = false;
            // 
            // labelKuartal
            // 
            this.labelKuartal.AutoSize = true;
            this.labelKuartal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKuartal.Location = new System.Drawing.Point(18, 200);
            this.labelKuartal.Name = "labelKuartal";
            this.labelKuartal.Size = new System.Drawing.Size(74, 22);
            this.labelKuartal.TabIndex = 114;
            this.labelKuartal.Text = "Kuartal";
            this.labelKuartal.Visible = false;
            // 
            // labelTahun
            // 
            this.labelTahun.AutoSize = true;
            this.labelTahun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTahun.Location = new System.Drawing.Point(18, 128);
            this.labelTahun.Name = "labelTahun";
            this.labelTahun.Size = new System.Drawing.Size(67, 22);
            this.labelTahun.TabIndex = 110;
            this.labelTahun.Text = "Tahun";
            // 
            // opsiTahun
            // 
            this.opsiTahun.FormattingEnabled = true;
            this.opsiTahun.Location = new System.Drawing.Point(162, 126);
            this.opsiTahun.Name = "opsiTahun";
            this.opsiTahun.Size = new System.Drawing.Size(143, 24);
            this.opsiTahun.TabIndex = 113;
            // 
            // btnPrintLaporan
            // 
            this.btnPrintLaporan.BackColor = System.Drawing.Color.Lime;
            this.btnPrintLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintLaporan.Location = new System.Drawing.Point(106, 287);
            this.btnPrintLaporan.Name = "btnPrintLaporan";
            this.btnPrintLaporan.Size = new System.Drawing.Size(146, 45);
            this.btnPrintLaporan.TabIndex = 110;
            this.btnPrintLaporan.Text = "Ekspor";
            this.btnPrintLaporan.UseVisualStyleBackColor = false;
            this.btnPrintLaporan.Click += new System.EventHandler(this.btnPrintLaporan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(298, 26);
            this.label3.TabIndex = 112;
            this.label3.Text = "Silahkan Pilih Periode     ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // opsiBulan
            // 
            this.opsiBulan.FormattingEnabled = true;
            this.opsiBulan.Location = new System.Drawing.Point(162, 200);
            this.opsiBulan.Name = "opsiBulan";
            this.opsiBulan.Size = new System.Drawing.Size(143, 24);
            this.opsiBulan.TabIndex = 111;
            this.opsiBulan.Visible = false;
            // 
            // opsiKuartal
            // 
            this.opsiKuartal.FormattingEnabled = true;
            this.opsiKuartal.Location = new System.Drawing.Point(162, 200);
            this.opsiKuartal.Name = "opsiKuartal";
            this.opsiKuartal.Size = new System.Drawing.Size(143, 24);
            this.opsiKuartal.TabIndex = 110;
            this.opsiKuartal.Visible = false;
            // 
            // LaporanKeuangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.grupPeriode);
            this.Controls.Add(this.btnShowLaporanBulan);
            this.Controls.Add(this.btnShowLaporanKuartal);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filterAkhir);
            this.Controls.Add(this.filterAwal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonLayanan);
            this.Controls.Add(this.buttonSewa);
            this.Controls.Add(this.buttonSeluruh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LaporanKeuangan";
            this.Text = "LaporanKeuangan";
            this.Load += new System.EventHandler(this.LaporanKeuangan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grupPeriode.ResumeLayout(false);
            this.grupPeriode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSewa;
        private System.Windows.Forms.Button buttonLayanan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker filterAwal;
        private System.Windows.Forms.Button buttonSeluruh;
        private System.Windows.Forms.DateTimePicker filterAkhir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBukti;
        private System.Windows.Forms.Button btnShowLaporanKuartal;
        private System.Windows.Forms.Button btnShowLaporanBulan;
        private System.Windows.Forms.Panel grupPeriode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox opsiBulan;
        private System.Windows.Forms.ComboBox opsiKuartal;
        private System.Windows.Forms.Button btnPrintLaporan;
        private System.Windows.Forms.ComboBox opsiTahun;
        private System.Windows.Forms.Label labelBulan;
        private System.Windows.Forms.Label labelKuartal;
        private System.Windows.Forms.Label labelTahun;
    }
}