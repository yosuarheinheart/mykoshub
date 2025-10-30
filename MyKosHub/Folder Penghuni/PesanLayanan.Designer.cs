namespace MyKosHub
{
    partial class PesanLayanan
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
            this.btnPesan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.namaPesanan = new System.Windows.Forms.Label();
            this.catatanPesanan = new System.Windows.Forms.RichTextBox();
            this.grupLayanan = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grupLayanan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(747, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesan Layanan";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(486, 227);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(795, 325);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnPesan
            // 
            this.btnPesan.BackColor = System.Drawing.Color.Lime;
            this.btnPesan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPesan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesan.Location = new System.Drawing.Point(192, 269);
            this.btnPesan.Name = "btnPesan";
            this.btnPesan.Size = new System.Drawing.Size(172, 49);
            this.btnPesan.TabIndex = 2;
            this.btnPesan.Text = "Pesan";
            this.btnPesan.UseVisualStyleBackColor = false;
            this.btnPesan.Click += new System.EventHandler(this.btnPesan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pesanan";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Catatan";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // namaPesanan
            // 
            this.namaPesanan.AutoSize = true;
            this.namaPesanan.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaPesanan.Location = new System.Drawing.Point(188, 39);
            this.namaPesanan.Name = "namaPesanan";
            this.namaPesanan.Size = new System.Drawing.Size(152, 23);
            this.namaPesanan.TabIndex = 5;
            this.namaPesanan.Text = "Nama Layanan";
            this.namaPesanan.Click += new System.EventHandler(this.namaPesanan_Click);
            // 
            // catatanPesanan
            // 
            this.catatanPesanan.Location = new System.Drawing.Point(192, 98);
            this.catatanPesanan.Name = "catatanPesanan";
            this.catatanPesanan.Size = new System.Drawing.Size(341, 144);
            this.catatanPesanan.TabIndex = 6;
            this.catatanPesanan.Text = "";
            // 
            // grupLayanan
            // 
            this.grupLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grupLayanan.Controls.Add(this.label2);
            this.grupLayanan.Controls.Add(this.namaPesanan);
            this.grupLayanan.Controls.Add(this.btnPesan);
            this.grupLayanan.Controls.Add(this.label3);
            this.grupLayanan.Controls.Add(this.catatanPesanan);
            this.grupLayanan.Location = new System.Drawing.Point(583, 583);
            this.grupLayanan.Name = "grupLayanan";
            this.grupLayanan.Size = new System.Drawing.Size(558, 328);
            this.grupLayanan.TabIndex = 8;
            // 
            // PesanLayanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1830, 923);
            this.Controls.Add(this.grupLayanan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PesanLayanan";
            this.Text = "PesanLayanan";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grupLayanan.ResumeLayout(false);
            this.grupLayanan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPesan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label namaPesanan;
        private System.Windows.Forms.RichTextBox catatanPesanan;
        private System.Windows.Forms.Panel grupLayanan;
    }
}