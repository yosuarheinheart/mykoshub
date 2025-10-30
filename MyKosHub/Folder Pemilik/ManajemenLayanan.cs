using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace MyKosHub
{
    public partial class ManajemenLayanan : Form
    {
        public static ManajemenLayanan instance;

        Pemilik pemilik = new Pemilik(null, null, null, null, null);
        private dbConnect dbcon = new dbConnect();
        private Pemilik currentPemilik;
        KelolaPesananLayanan kelolaPesananLayanan;
        public ManajemenLayanan(Pemilik pemilik)
        {
            InitializeComponent();
            this.currentPemilik = pemilik;
            grupTambah.Visible = false;
            grupUpdate.Visible = false;
            loadLayanan();
        }

        private void buttonKelola_Click(object sender, EventArgs e)
        {
            KelolaPesananLayanan kpl = new KelolaPesananLayanan(currentPemilik);
            kpl.KembaliKeManajemenLayanan += (s, args) =>
            {
                this.Show();
            };
            this.Hide();
            kpl.MdiParent = this.MdiParent;
            kpl.Dock = DockStyle.Fill;
            kpl.Show();
            kpl.FormClosed += (s, args) => kpl.Dispose();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            grupTambah.Visible = !grupTambah.Visible;
            grupUpdate.Visible = false;
            grupTambah.BringToFront();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih kamar yang ingin diedit terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string nama = row.Cells["nama"].Value.ToString();
            string harga = row.Cells["biaya"].Value.ToString();
            string deskripsi = row.Cells["deskripsi"].Value.ToString();

            changeNamaLayanan.Text = nama;
            changeBiaya.Text = harga;
            changeDeskripsi.Text = deskripsi;
            grupUpdate.Visible = !grupUpdate.Visible;
            grupTambah.Visible = false;
            grupUpdate.BringToFront();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputNamaLayanan.Text) ||
                string.IsNullOrWhiteSpace(inputBiayaa.Text) || string.IsNullOrWhiteSpace(inputDeskripsi.Text))
            {
                MessageBox.Show("Pastikan seluruh informasi terisi!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
                dbcon.addLayananKeKos(kos.id_kos, inputNamaLayanan.Text, Convert.ToInt32(inputBiayaa.Text), inputDeskripsi.Text);
                MessageBox.Show("Layanan Berhasil Ditambahkan!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grupTambah.Visible = false;
                loadLayanan();
                inputNamaLayanan.Clear();
                inputBiayaa.Clear();
                inputDeskripsi.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tidak ada Layanan yang dipilih untuk diperbarui.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(changeNamaLayanan.Text) ||
                string.IsNullOrWhiteSpace(changeBiaya.Text) ||
                string.IsNullOrWhiteSpace(changeDeskripsi.Text))
            {
                MessageBox.Show("Pastikan seluruh informasi terisi!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id_layanan = dataGridView1.SelectedRows[0].Cells["id_layanan"].Value.ToString();


            try
            {
                string nama = changeNamaLayanan.Text;
                int harga = Convert.ToInt32(changeBiaya.Text);
                string deskripsi = changeDeskripsi.Text;

                dbcon.updateLayanan(id_layanan, nama, harga, deskripsi);
                MessageBox.Show("Data kamar berhasil diperbarui.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadLayanan();

                grupUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadLayanan()
        {
            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
            DataTable dt = dbcon.getAllLayanan(kos.id_kos);
            dataGridView1.DataSource = dt;
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih layanan yang ingin dihapus terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedLayanan = dataGridView1.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => new
                {
                    Id = row.Cells["id_layanan"].Value.ToString(),
                    Nama = row.Cells["nama"].Value.ToString()
                })
                .FirstOrDefault();

            if (selectedLayanan == null)
            {
                MessageBox.Show("Data layanan tidak valid.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus layanan \"{selectedLayanan.Nama}\"?",
                "Sistem",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                    {
                        conn.Open();
                        string query = "DELETE FROM Layanan_Kamar WHERE id_layanan = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedLayanan.Id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Layanan berhasil dihapus.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLayanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus layanan: {ex.Message}", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImpor_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.Title = "Pilih file layanan kamar (.txt)";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
                    string[] lines = File.ReadAllLines(filePath);

                    int sukses = 0, gagal = 0;

                    using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                    {
                        conn.Open();

                        foreach (string line in lines)
                        {
                            string[] parts = line.Split(';');

                            if (parts.Length < 3)
                            {
                                gagal++;
                                continue;
                            }

                            string nama = parts[0].Trim();
                            bool parseHarga = int.TryParse(parts[1].Trim(), out int biaya);
                            string deskripsi = parts[2].Trim();

                            if (!parseHarga || string.IsNullOrWhiteSpace(nama))
                            {
                                gagal++;
                                continue;
                            }

                            string idLayanan = dbcon.generateIdLayanan();

                            string query = @"
                        INSERT INTO Layanan_Kamar (id_layanan, id_kos, nama, biaya, deskripsi)
                        VALUES (@id, @kos, @nama, @biaya, @deskripsi)";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idLayanan);
                            cmd.Parameters.AddWithValue("@kos", kos.id_kos);
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@biaya", biaya);
                            cmd.Parameters.AddWithValue("@deskripsi", deskripsi);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                sukses++;
                            }
                            catch
                            {
                                gagal++;
                            }
                        }
                    }

                    MessageBox.Show($"Import selesai.\nBerhasil: {sukses} data\nGagal: {gagal} data", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLayanan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat impor: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
