using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKosHub
{
    public partial class penambahanKamar : Form
    {
        dbConnect dbcon = new dbConnect();
        private Pemilik currentPemilik;
        public event EventHandler KembaliKeManajemenKamar;
        public penambahanKamar(Pemilik pemilik)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.currentPemilik = pemilik;
        }

        private void penambahanKamar_Load(object sender, EventArgs e)
        {

        }

        private void buttonkembali_Click(object sender, EventArgs e)
        {
            this.Close();
            KembaliKeManajemenKamar?.Invoke(this, EventArgs.Empty);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(noKamar.Text) ||
                string.IsNullOrWhiteSpace(tipeKamar.Text) || string.IsNullOrWhiteSpace(hargaKamar.Text))
            {
                MessageBox.Show("Pastikan seluruh informasi terisi!", "Sistem" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
            try
            {
                Kamar newKamar = new Kamar(dbcon.generateIdKamar(), noKamar.Text, tipeKamar.Text, Convert.ToInt32(hargaKamar.Text), "tersedia");
                dbcon.addKamar(kos.id_kos, newKamar);
                MessageBox.Show("Informasi Kamar Berhasil Ditambahkan", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                noKamar.Clear();
                tipeKamar.Clear();
                hargaKamar.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
