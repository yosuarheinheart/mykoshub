namespace MyKosHub
{
    partial class penambahanKamar
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.noKamar = new System.Windows.Forms.TextBox();
            this.tipeKamar = new System.Windows.Forms.TextBox();
            this.hargaKamar = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonkembali = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MotoGP Display Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(723, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pendaftaran Kamar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(593, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nomor Kamar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(593, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipe Kamar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(593, 522);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Harga";
            // 
            // noKamar
            // 
            this.noKamar.Location = new System.Drawing.Point(890, 373);
            this.noKamar.Name = "noKamar";
            this.noKamar.Size = new System.Drawing.Size(227, 22);
            this.noKamar.TabIndex = 4;
            // 
            // tipeKamar
            // 
            this.tipeKamar.Location = new System.Drawing.Point(890, 453);
            this.tipeKamar.Name = "tipeKamar";
            this.tipeKamar.Size = new System.Drawing.Size(227, 22);
            this.tipeKamar.TabIndex = 5;
            // 
            // hargaKamar
            // 
            this.hargaKamar.Location = new System.Drawing.Point(890, 529);
            this.hargaKamar.Name = "hargaKamar";
            this.hargaKamar.Size = new System.Drawing.Size(227, 22);
            this.hargaKamar.TabIndex = 6;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.Lime;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(811, 609);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(141, 41);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonkembali
            // 
            this.buttonkembali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(157)))), ((int)(((byte)(35)))));
            this.buttonkembali.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonkembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonkembali.Location = new System.Drawing.Point(773, 151);
            this.buttonkembali.Name = "buttonkembali";
            this.buttonkembali.Size = new System.Drawing.Size(220, 34);
            this.buttonkembali.TabIndex = 8;
            this.buttonkembali.Text = "Kembali";
            this.buttonkembali.UseVisualStyleBackColor = false;
            this.buttonkembali.Click += new System.EventHandler(this.buttonkembali_Click);
            // 
            // penambahanKamar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(1848, 970);
            this.Controls.Add(this.buttonkembali);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.hargaKamar);
            this.Controls.Add(this.tipeKamar);
            this.Controls.Add(this.noKamar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "penambahanKamar";
            this.Text = "penambahanKamar";
            this.Load += new System.EventHandler(this.penambahanKamar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox noKamar;
        private System.Windows.Forms.TextBox tipeKamar;
        private System.Windows.Forms.TextBox hargaKamar;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonkembali;
    }
}