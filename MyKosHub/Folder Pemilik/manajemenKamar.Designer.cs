namespace MyKosHub
{
    partial class manajemenKamar
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
            this.tambahKamar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.editKamar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hapusKamar = new System.Windows.Forms.Button();
            this.kodeKamar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.updateKamar = new System.Windows.Forms.Button();
            this.hargaKamar = new System.Windows.Forms.TextBox();
            this.tipeKamar = new System.Windows.Forms.TextBox();
            this.noKamar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.editGroup = new System.Windows.Forms.GroupBox();
            this.comboKamar = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnKosongkan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.editGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tambahKamar
            // 
            this.tambahKamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(51)))));
            this.tambahKamar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tambahKamar.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tambahKamar.ForeColor = System.Drawing.Color.Black;
            this.tambahKamar.Location = new System.Drawing.Point(614, 182);
            this.tambahKamar.Name = "tambahKamar";
            this.tambahKamar.Size = new System.Drawing.Size(552, 51);
            this.tambahKamar.TabIndex = 74;
            this.tambahKamar.Text = "Tambah Kamar";
            this.tambahKamar.UseVisualStyleBackColor = false;
            this.tambahKamar.Click += new System.EventHandler(this.tambahKamar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(417, 265);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(954, 173);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // editKamar
            // 
            this.editKamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(225)))), ((int)(((byte)(210)))));
            this.editKamar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editKamar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editKamar.Location = new System.Drawing.Point(995, 456);
            this.editKamar.Name = "editKamar";
            this.editKamar.Size = new System.Drawing.Size(90, 28);
            this.editKamar.TabIndex = 76;
            this.editKamar.Text = "Edit";
            this.editKamar.UseVisualStyleBackColor = false;
            this.editKamar.Click += new System.EventHandler(this.editKamar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(746, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 49);
            this.label1.TabIndex = 79;
            this.label1.Text = "Manajemen Kamar";
            // 
            // hapusKamar
            // 
            this.hapusKamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.hapusKamar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hapusKamar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hapusKamar.Location = new System.Drawing.Point(1111, 456);
            this.hapusKamar.Name = "hapusKamar";
            this.hapusKamar.Size = new System.Drawing.Size(90, 28);
            this.hapusKamar.TabIndex = 80;
            this.hapusKamar.Text = "Hapus";
            this.hapusKamar.UseVisualStyleBackColor = false;
            this.hapusKamar.Click += new System.EventHandler(this.hapusKamar_Click);
            // 
            // kodeKamar
            // 
            this.kodeKamar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(196)))), ((int)(((byte)(127)))));
            this.kodeKamar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.kodeKamar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kodeKamar.Location = new System.Drawing.Point(1218, 456);
            this.kodeKamar.Name = "kodeKamar";
            this.kodeKamar.Size = new System.Drawing.Size(153, 28);
            this.kodeKamar.TabIndex = 81;
            this.kodeKamar.Text = "Generate Code";
            this.kodeKamar.UseVisualStyleBackColor = false;
            this.kodeKamar.Click += new System.EventHandler(this.kodeKamar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MotoGP Text", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(195, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 43);
            this.label2.TabIndex = 82;
            this.label2.Text = "Edit Informasi";
            // 
            // updateKamar
            // 
            this.updateKamar.BackColor = System.Drawing.Color.Lime;
            this.updateKamar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateKamar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateKamar.Location = new System.Drawing.Point(262, 345);
            this.updateKamar.Name = "updateKamar";
            this.updateKamar.Size = new System.Drawing.Size(141, 41);
            this.updateKamar.TabIndex = 89;
            this.updateKamar.Text = "Update";
            this.updateKamar.UseVisualStyleBackColor = false;
            this.updateKamar.Click += new System.EventHandler(this.updateKamar_Click);
            // 
            // hargaKamar
            // 
            this.hargaKamar.Location = new System.Drawing.Point(341, 205);
            this.hargaKamar.Name = "hargaKamar";
            this.hargaKamar.Size = new System.Drawing.Size(227, 22);
            this.hargaKamar.TabIndex = 88;
            // 
            // tipeKamar
            // 
            this.tipeKamar.Location = new System.Drawing.Point(341, 159);
            this.tipeKamar.Name = "tipeKamar";
            this.tipeKamar.Size = new System.Drawing.Size(227, 22);
            this.tipeKamar.TabIndex = 87;
            // 
            // noKamar
            // 
            this.noKamar.Location = new System.Drawing.Point(341, 109);
            this.noKamar.Name = "noKamar";
            this.noKamar.Size = new System.Drawing.Size(227, 22);
            this.noKamar.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 29);
            this.label4.TabIndex = 85;
            this.label4.Text = "Harga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 29);
            this.label3.TabIndex = 84;
            this.label3.Text = "Tipe Kamar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 29);
            this.label5.TabIndex = 83;
            this.label5.Text = "Nomor Kamar";
            // 
            // editGroup
            // 
            this.editGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.editGroup.Controls.Add(this.comboKamar);
            this.editGroup.Controls.Add(this.label6);
            this.editGroup.Controls.Add(this.label2);
            this.editGroup.Controls.Add(this.updateKamar);
            this.editGroup.Controls.Add(this.label5);
            this.editGroup.Controls.Add(this.hargaKamar);
            this.editGroup.Controls.Add(this.label3);
            this.editGroup.Controls.Add(this.tipeKamar);
            this.editGroup.Controls.Add(this.label4);
            this.editGroup.Controls.Add(this.noKamar);
            this.editGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editGroup.Location = new System.Drawing.Point(565, 526);
            this.editGroup.Name = "editGroup";
            this.editGroup.Size = new System.Drawing.Size(636, 401);
            this.editGroup.TabIndex = 90;
            this.editGroup.TabStop = false;
            this.editGroup.Enter += new System.EventHandler(this.editGroup_Enter);
            // 
            // comboKamar
            // 
            this.comboKamar.FormattingEnabled = true;
            this.comboKamar.Location = new System.Drawing.Point(341, 250);
            this.comboKamar.Name = "comboKamar";
            this.comboKamar.Size = new System.Drawing.Size(227, 24);
            this.comboKamar.TabIndex = 91;
            this.comboKamar.SelectedIndexChanged += new System.EventHandler(this.comboKamar_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 29);
            this.label6.TabIndex = 90;
            this.label6.Text = "Status Kamar";
            // 
            // btnKosongkan
            // 
            this.btnKosongkan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnKosongkan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKosongkan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKosongkan.Location = new System.Drawing.Point(847, 456);
            this.btnKosongkan.Name = "btnKosongkan";
            this.btnKosongkan.Size = new System.Drawing.Size(121, 28);
            this.btnKosongkan.TabIndex = 91;
            this.btnKosongkan.Text = "Kosongkan";
            this.btnKosongkan.UseVisualStyleBackColor = false;
            this.btnKosongkan.Click += new System.EventHandler(this.btnKosongkan_Click);
            // 
            // manajemenKamar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.btnKosongkan);
            this.Controls.Add(this.editGroup);
            this.Controls.Add(this.kodeKamar);
            this.Controls.Add(this.hapusKamar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editKamar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tambahKamar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "manajemenKamar";
            this.Text = "manajemenKamar";
            this.Load += new System.EventHandler(this.manajemenKamar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.editGroup.ResumeLayout(false);
            this.editGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button tambahKamar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button editKamar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hapusKamar;
        private System.Windows.Forms.Button kodeKamar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateKamar;
        private System.Windows.Forms.TextBox hargaKamar;
        private System.Windows.Forms.TextBox tipeKamar;
        private System.Windows.Forms.TextBox noKamar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox editGroup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboKamar;
        private System.Windows.Forms.Button btnKosongkan;
    }
}