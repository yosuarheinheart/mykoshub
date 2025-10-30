namespace MyKosHub
{
    partial class BayarSewaLayanan
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
            this.btnSewa = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLayanan = new System.Windows.Forms.Button();
            this.btnBayar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBukti = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.infoDetailTagihan = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalBiaya = new System.Windows.Forms.Label();
            this.grupBayar = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnRiwayat = new System.Windows.Forms.Button();
            this.optionRiwayat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBukti)).BeginInit();
            this.grupBayar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(885, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pembayaran";
            // 
            // btnSewa
            // 
            this.btnSewa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSewa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSewa.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSewa.Location = new System.Drawing.Point(217, 260);
            this.btnSewa.Name = "btnSewa";
            this.btnSewa.Size = new System.Drawing.Size(129, 42);
            this.btnSewa.TabIndex = 1;
            this.btnSewa.Text = "Sewa";
            this.btnSewa.UseVisualStyleBackColor = false;
            this.btnSewa.Click += new System.EventHandler(this.btnSewa_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(217, 320);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(726, 462);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnLayanan
            // 
            this.btnLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLayanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLayanan.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayanan.Location = new System.Drawing.Point(393, 260);
            this.btnLayanan.Name = "btnLayanan";
            this.btnLayanan.Size = new System.Drawing.Size(129, 42);
            this.btnLayanan.TabIndex = 3;
            this.btnLayanan.Text = "Layanan";
            this.btnLayanan.UseVisualStyleBackColor = false;
            this.btnLayanan.Click += new System.EventHandler(this.btnLayanan_Click);
            // 
            // btnBayar
            // 
            this.btnBayar.BackColor = System.Drawing.Color.Lime;
            this.btnBayar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBayar.Location = new System.Drawing.Point(184, 490);
            this.btnBayar.Name = "btnBayar";
            this.btnBayar.Size = new System.Drawing.Size(229, 66);
            this.btnBayar.TabIndex = 112;
            this.btnBayar.Text = "Bayar";
            this.btnBayar.UseVisualStyleBackColor = false;
            this.btnBayar.Click += new System.EventHandler(this.btnBayar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 29);
            this.label3.TabIndex = 113;
            this.label3.Text = "Bukti Pembayaran";
            // 
            // pictureBukti
            // 
            this.pictureBukti.Location = new System.Drawing.Point(30, 282);
            this.pictureBukti.Name = "pictureBukti";
            this.pictureBukti.Size = new System.Drawing.Size(595, 183);
            this.pictureBukti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBukti.TabIndex = 114;
            this.pictureBukti.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 29);
            this.label4.TabIndex = 115;
            this.label4.Text = "Detail Tagihan";
            // 
            // infoDetailTagihan
            // 
            this.infoDetailTagihan.AutoSize = true;
            this.infoDetailTagihan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoDetailTagihan.Location = new System.Drawing.Point(259, 32);
            this.infoDetailTagihan.Name = "infoDetailTagihan";
            this.infoDetailTagihan.Size = new System.Drawing.Size(307, 29);
            this.infoDetailTagihan.TabIndex = 116;
            this.infoDetailTagihan.Text = "nomorKamar/namaLayanan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 29);
            this.label6.TabIndex = 117;
            this.label6.Text = "Biaya";
            // 
            // totalBiaya
            // 
            this.totalBiaya.AutoSize = true;
            this.totalBiaya.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalBiaya.Location = new System.Drawing.Point(259, 121);
            this.totalBiaya.Name = "totalBiaya";
            this.totalBiaya.Size = new System.Drawing.Size(117, 29);
            this.totalBiaya.TabIndex = 118;
            this.totalBiaya.Text = "totalBiaya";
            // 
            // grupBayar
            // 
            this.grupBayar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grupBayar.Controls.Add(this.btnUpload);
            this.grupBayar.Controls.Add(this.pictureBukti);
            this.grupBayar.Controls.Add(this.infoDetailTagihan);
            this.grupBayar.Controls.Add(this.btnBayar);
            this.grupBayar.Controls.Add(this.label4);
            this.grupBayar.Controls.Add(this.label6);
            this.grupBayar.Controls.Add(this.label3);
            this.grupBayar.Controls.Add(this.totalBiaya);
            this.grupBayar.Location = new System.Drawing.Point(1061, 260);
            this.grupBayar.Name = "grupBayar";
            this.grupBayar.Size = new System.Drawing.Size(664, 572);
            this.grupBayar.TabIndex = 119;
            this.grupBayar.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Gray;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(280, 208);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(219, 39);
            this.btnUpload.TabIndex = 119;
            this.btnUpload.Text = "Upload Bukti...";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnRiwayat
            // 
            this.btnRiwayat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRiwayat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRiwayat.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRiwayat.Location = new System.Drawing.Point(217, 812);
            this.btnRiwayat.Name = "btnRiwayat";
            this.btnRiwayat.Size = new System.Drawing.Size(129, 42);
            this.btnRiwayat.TabIndex = 120;
            this.btnRiwayat.Text = "Riwayat";
            this.btnRiwayat.UseVisualStyleBackColor = false;
            this.btnRiwayat.Click += new System.EventHandler(this.btnRiwayat_Click);
            // 
            // optionRiwayat
            // 
            this.optionRiwayat.FormattingEnabled = true;
            this.optionRiwayat.Location = new System.Drawing.Point(435, 824);
            this.optionRiwayat.Name = "optionRiwayat";
            this.optionRiwayat.Size = new System.Drawing.Size(121, 24);
            this.optionRiwayat.TabIndex = 121;
            this.optionRiwayat.SelectedIndexChanged += new System.EventHandler(this.optionRiwayat_SelectedIndexChanged);
            // 
            // BayarSewaLayanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1830, 923);
            this.ControlBox = false;
            this.Controls.Add(this.optionRiwayat);
            this.Controls.Add(this.btnRiwayat);
            this.Controls.Add(this.grupBayar);
            this.Controls.Add(this.btnLayanan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSewa);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BayarSewaLayanan";
            this.Text = "BayarSewaLayanan";
            this.Load += new System.EventHandler(this.BayarSewaLayanan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBukti)).EndInit();
            this.grupBayar.ResumeLayout(false);
            this.grupBayar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSewa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLayanan;
        private System.Windows.Forms.Button btnBayar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBukti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label infoDetailTagihan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalBiaya;
        private System.Windows.Forms.GroupBox grupBayar;
        private System.Windows.Forms.Button btnRiwayat;
        private System.Windows.Forms.ComboBox optionRiwayat;
        private System.Windows.Forms.Button btnUpload;
    }
}