namespace MyKosHub
{
    partial class KelolaStatus
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
            this.buttonLayanan = new System.Windows.Forms.Button();
            this.buttonSewa = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.optionStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.isiCatatan = new System.Windows.Forms.RichTextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBukti = new System.Windows.Forms.PictureBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.groupPembayaran = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBukti)).BeginInit();
            this.groupPembayaran.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLayanan
            // 
            this.buttonLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.buttonLayanan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLayanan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLayanan.Location = new System.Drawing.Point(870, 197);
            this.buttonLayanan.Name = "buttonLayanan";
            this.buttonLayanan.Size = new System.Drawing.Size(229, 28);
            this.buttonLayanan.TabIndex = 104;
            this.buttonLayanan.Text = "Layanan";
            this.buttonLayanan.UseVisualStyleBackColor = false;
            // 
            // buttonSewa
            // 
            this.buttonSewa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.buttonSewa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSewa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSewa.Location = new System.Drawing.Point(583, 197);
            this.buttonSewa.Name = "buttonSewa";
            this.buttonSewa.Size = new System.Drawing.Size(229, 28);
            this.buttonSewa.TabIndex = 103;
            this.buttonSewa.Text = "Sewa";
            this.buttonSewa.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(426, 248);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(824, 369);
            this.dataGridView1.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(672, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 62);
            this.label1.TabIndex = 101;
            this.label1.Text = "Kelola Pembayaran";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(1053, 645);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(197, 60);
            this.buttonEdit.TabIndex = 106;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 40);
            this.label2.TabIndex = 107;
            this.label2.Text = "Status";
            // 
            // optionStatus
            // 
            this.optionStatus.FormattingEnabled = true;
            this.optionStatus.Location = new System.Drawing.Point(257, 46);
            this.optionStatus.Name = "optionStatus";
            this.optionStatus.Size = new System.Drawing.Size(230, 24);
            this.optionStatus.TabIndex = 108;
            this.optionStatus.SelectedIndexChanged += new System.EventHandler(this.optionStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1337, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 40);
            this.label3.TabIndex = 109;
            this.label3.Text = "Bukti Pembayaran";
            // 
            // isiCatatan
            // 
            this.isiCatatan.Location = new System.Drawing.Point(257, 114);
            this.isiCatatan.Name = "isiCatatan";
            this.isiCatatan.Size = new System.Drawing.Size(230, 107);
            this.isiCatatan.TabIndex = 113;
            this.isiCatatan.Text = "";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(581, 161);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(197, 60);
            this.btnUpdate.TabIndex = 112;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 40);
            this.label4.TabIndex = 112;
            this.label4.Text = "Catatan";
            // 
            // pictureBukti
            // 
            this.pictureBukti.Location = new System.Drawing.Point(1344, 345);
            this.pictureBukti.Name = "pictureBukti";
            this.pictureBukti.Size = new System.Drawing.Size(230, 178);
            this.pictureBukti.TabIndex = 110;
            this.pictureBukti.TabStop = false;
            this.pictureBukti.Click += new System.EventHandler(this.pictureBukti_Click);
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.Location = new System.Drawing.Point(1365, 557);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(181, 47);
            this.btnHide.TabIndex = 112;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // groupPembayaran
            // 
            this.groupPembayaran.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.groupPembayaran.Controls.Add(this.isiCatatan);
            this.groupPembayaran.Controls.Add(this.label2);
            this.groupPembayaran.Controls.Add(this.btnUpdate);
            this.groupPembayaran.Controls.Add(this.optionStatus);
            this.groupPembayaran.Controls.Add(this.label4);
            this.groupPembayaran.Location = new System.Drawing.Point(426, 729);
            this.groupPembayaran.Name = "groupPembayaran";
            this.groupPembayaran.Size = new System.Drawing.Size(824, 250);
            this.groupPembayaran.TabIndex = 113;
            // 
            // KelolaStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.groupPembayaran);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.pictureBukti);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonLayanan);
            this.Controls.Add(this.buttonSewa);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KelolaStatus";
            this.Text = "KelolaStatus";
            this.Load += new System.EventHandler(this.KelolaStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBukti)).EndInit();
            this.groupPembayaran.ResumeLayout(false);
            this.groupPembayaran.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonLayanan;
        private System.Windows.Forms.Button buttonSewa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox optionStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBukti;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RichTextBox isiCatatan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Panel groupPembayaran;
    }
}