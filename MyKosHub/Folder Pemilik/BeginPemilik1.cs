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
    public partial class BeginPemilik1 : Form
    {
        public static BeginPemilik1 instance;
        Pemilik pemilik = new Pemilik(null, null, null, null, null);
        private dbConnect dbcon = new dbConnect();
        private Pemilik currentPemilik;
        public BeginPemilik1(Pemilik pemilik)
        {
            InitializeComponent();
            this.currentPemilik = pemilik;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inputNamaKos.Text) ||
                string.IsNullOrWhiteSpace(inputAlamatKos.Text))
                {
                    MessageBox.Show("Pastikan seluruh informasi terisi!", "Sistem");
                    return;
                }

                Kos newKos = new Kos(dbcon.generateIdKos(), inputNamaKos.Text, inputAlamatKos.Text);

                if (pemilik.addKosToPemilik(currentPemilik.id_pemilik, currentPemilik.email, newKos))
                {
                    Dashboard db = new Dashboard(currentPemilik);
                    db.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Informasi Gagal Ditambahkan", "Peringatan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Peringatan!");
            }
        }
    }
}
