namespace MyKosHub
{
    partial class KelolaKeluhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KelolaKeluhan));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.noteKeluhan = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.optionStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnProses = new System.Windows.Forms.Button();
            this.btnSelesai = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grupKeluhan = new System.Windows.Forms.GroupBox();
            this.btnChatWA = new System.Windows.Forms.Button();
            this.logoWhatsapp = new System.Windows.Forms.PictureBox();
            this.btnCetakLaporan = new System.Windows.Forms.Button();
            this.grupPeriode = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.opsiTahun = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.opsiBulan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grupKeluhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoWhatsapp)).BeginInit();
            this.grupPeriode.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(774, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 57);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kelola Keluhan";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(98, 314);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(837, 271);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // noteKeluhan
            // 
            this.noteKeluhan.Location = new System.Drawing.Point(130, 108);
            this.noteKeluhan.Name = "noteKeluhan";
            this.noteKeluhan.Size = new System.Drawing.Size(406, 93);
            this.noteKeluhan.TabIndex = 15;
            this.noteKeluhan.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 29);
            this.label2.TabIndex = 16;
            this.label2.Text = "Status";
            // 
            // optionStatus
            // 
            this.optionStatus.FormattingEnabled = true;
            this.optionStatus.Location = new System.Drawing.Point(130, 33);
            this.optionStatus.Name = "optionStatus";
            this.optionStatus.Size = new System.Drawing.Size(217, 24);
            this.optionStatus.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 29);
            this.label3.TabIndex = 18;
            this.label3.Text = "Catatan";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Lime;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(259, 248);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(367, 55);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnPending
            // 
            this.btnPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.btnPending.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPending.Location = new System.Drawing.Point(98, 267);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(145, 28);
            this.btnPending.TabIndex = 104;
            this.btnPending.Text = "Pending";
            this.btnPending.UseVisualStyleBackColor = false;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnProses
            // 
            this.btnProses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.btnProses.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProses.Location = new System.Drawing.Point(249, 267);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(145, 28);
            this.btnProses.TabIndex = 105;
            this.btnProses.Text = "Proses";
            this.btnProses.UseVisualStyleBackColor = false;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // btnSelesai
            // 
            this.btnSelesai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.btnSelesai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelesai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelesai.Location = new System.Drawing.Point(98, 221);
            this.btnSelesai.Name = "btnSelesai";
            this.btnSelesai.Size = new System.Drawing.Size(296, 28);
            this.btnSelesai.TabIndex = 106;
            this.btnSelesai.Text = "Selesai";
            this.btnSelesai.UseVisualStyleBackColor = false;
            this.btnSelesai.Click += new System.EventHandler(this.btnSelesai_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Red;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(672, 207);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(263, 91);
            this.btnReset.TabIndex = 107;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grupKeluhan
            // 
            this.grupKeluhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grupKeluhan.Controls.Add(this.noteKeluhan);
            this.grupKeluhan.Controls.Add(this.label2);
            this.grupKeluhan.Controls.Add(this.label3);
            this.grupKeluhan.Controls.Add(this.optionStatus);
            this.grupKeluhan.Controls.Add(this.btnSubmit);
            this.grupKeluhan.Location = new System.Drawing.Point(98, 626);
            this.grupKeluhan.Name = "grupKeluhan";
            this.grupKeluhan.Size = new System.Drawing.Size(837, 332);
            this.grupKeluhan.TabIndex = 108;
            this.grupKeluhan.TabStop = false;
            // 
            // btnChatWA
            // 
            this.btnChatWA.BackColor = System.Drawing.Color.Lime;
            this.btnChatWA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChatWA.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChatWA.Location = new System.Drawing.Point(1167, 220);
            this.btnChatWA.Name = "btnChatWA";
            this.btnChatWA.Size = new System.Drawing.Size(406, 59);
            this.btnChatWA.TabIndex = 109;
            this.btnChatWA.Text = "Chat Langsung";
            this.btnChatWA.UseVisualStyleBackColor = false;
            this.btnChatWA.Click += new System.EventHandler(this.btnChatWA_Click);
            // 
            // logoWhatsapp
            // 
            this.logoWhatsapp.BackColor = System.Drawing.Color.Lime;
            this.logoWhatsapp.Image = ((System.Drawing.Image)(resources.GetObject("logoWhatsapp.Image")));
            this.logoWhatsapp.Location = new System.Drawing.Point(1178, 228);
            this.logoWhatsapp.Name = "logoWhatsapp";
            this.logoWhatsapp.Size = new System.Drawing.Size(53, 43);
            this.logoWhatsapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoWhatsapp.TabIndex = 110;
            this.logoWhatsapp.TabStop = false;
            // 
            // btnCetakLaporan
            // 
            this.btnCetakLaporan.BackColor = System.Drawing.Color.Lime;
            this.btnCetakLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCetakLaporan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCetakLaporan.Location = new System.Drawing.Point(58, 312);
            this.btnCetakLaporan.Name = "btnCetakLaporan";
            this.btnCetakLaporan.Size = new System.Drawing.Size(274, 39);
            this.btnCetakLaporan.TabIndex = 111;
            this.btnCetakLaporan.Text = "Tampilkan Laporan";
            this.btnCetakLaporan.UseVisualStyleBackColor = false;
            this.btnCetakLaporan.Click += new System.EventHandler(this.btnCetakLaporan_Click);
            // 
            // grupPeriode
            // 
            this.grupPeriode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grupPeriode.Controls.Add(this.label6);
            this.grupPeriode.Controls.Add(this.opsiTahun);
            this.grupPeriode.Controls.Add(this.label5);
            this.grupPeriode.Controls.Add(this.label4);
            this.grupPeriode.Controls.Add(this.opsiBulan);
            this.grupPeriode.Controls.Add(this.btnCetakLaporan);
            this.grupPeriode.Location = new System.Drawing.Point(1158, 347);
            this.grupPeriode.Name = "grupPeriode";
            this.grupPeriode.Size = new System.Drawing.Size(406, 428);
            this.grupPeriode.TabIndex = 112;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 29);
            this.label6.TabIndex = 114;
            this.label6.Text = "Bulan";
            // 
            // opsiTahun
            // 
            this.opsiTahun.FormattingEnabled = true;
            this.opsiTahun.Location = new System.Drawing.Point(178, 131);
            this.opsiTahun.Name = "opsiTahun";
            this.opsiTahun.Size = new System.Drawing.Size(142, 24);
            this.opsiTahun.TabIndex = 115;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 29);
            this.label5.TabIndex = 20;
            this.label5.Text = "Tahun";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 34);
            this.label4.TabIndex = 113;
            this.label4.Text = "Silahkan Pilih Periode";
            // 
            // opsiBulan
            // 
            this.opsiBulan.FormattingEnabled = true;
            this.opsiBulan.Location = new System.Drawing.Point(178, 214);
            this.opsiBulan.Name = "opsiBulan";
            this.opsiBulan.Size = new System.Drawing.Size(142, 24);
            this.opsiBulan.TabIndex = 20;
            // 
            // KelolaKeluhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.grupPeriode);
            this.Controls.Add(this.logoWhatsapp);
            this.Controls.Add(this.btnChatWA);
            this.Controls.Add(this.grupKeluhan);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSelesai);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KelolaKeluhan";
            this.Text = "v";
            this.Load += new System.EventHandler(this.KelolaKeluhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grupKeluhan.ResumeLayout(false);
            this.grupKeluhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoWhatsapp)).EndInit();
            this.grupPeriode.ResumeLayout(false);
            this.grupPeriode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox noteKeluhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox optionStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnProses;
        private System.Windows.Forms.Button btnSelesai;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grupKeluhan;
        private System.Windows.Forms.Button btnChatWA;
        private System.Windows.Forms.PictureBox logoWhatsapp;
        private System.Windows.Forms.Button btnCetakLaporan;
        private System.Windows.Forms.Panel grupPeriode;
        private System.Windows.Forms.ComboBox opsiBulan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox opsiTahun;
        private System.Windows.Forms.Label label5;
    }
}