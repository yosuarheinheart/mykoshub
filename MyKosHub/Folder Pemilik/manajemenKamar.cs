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
using Microsoft.VisualBasic;

namespace MyKosHub
{
    public partial class manajemenKamar : Form
    {
        private Pemilik currentPemilik;
        dbConnect dbcon = new dbConnect();

        public manajemenKamar(Pemilik pemilik)
        {
            InitializeComponent();
            this.currentPemilik = pemilik;
            editGroup.Visible = false;
            comboKamar.Items.AddRange(new string[] { "tersedia", "dihuni", "diperbaiki" });
            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
            loadKamar();
        }

        private void editKamar_Click(object sender, EventArgs e)
        {
            if (editGroup.Visible)
            {
                editGroup.Visible = false;
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih kamar yang ingin diedit terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string nomorKamar = row.Cells["nomor_kamar"].Value.ToString();
            string tipeKamarVal = row.Cells["tipe_kamar"].Value.ToString();
            string hargaVal = row.Cells["harga"].Value.ToString();
            string statusKamar = row.Cells["status_kamar"].Value.ToString().ToLower();

            noKamar.Text = nomorKamar;
            tipeKamar.Text = tipeKamarVal;
            hargaKamar.Text = hargaVal;

            comboKamar.Items.Clear();
            comboKamar.DropDownStyle = ComboBoxStyle.DropDownList;

            if (statusKamar == "dihuni")
            {
                comboKamar.Items.Add("dihuni");
                comboKamar.SelectedItem = "dihuni";
                comboKamar.Enabled = false;
            }
            else if (statusKamar == "tersedia" || statusKamar == "diperbaiki")
            {
                comboKamar.Items.Add("tersedia");
                comboKamar.Items.Add("diperbaiki");
                comboKamar.SelectedItem = statusKamar;
                comboKamar.Enabled = true;
            }
            else
            {
                comboKamar.Items.Add(statusKamar);
                comboKamar.SelectedItem = statusKamar;
                comboKamar.Enabled = false;
            }

            editGroup.Visible = true;
        }

        private void hapusKamar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih kamar yang ingin dihapus terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedKamar = dataGridView1.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => new
                {
                    Id = row.Cells["id_kamar"].Value.ToString(),
                    Nomor = row.Cells["nomor_kamar"].Value.ToString()
                })
                .FirstOrDefault();

            if (selectedKamar == null)
            {
                MessageBox.Show("Data kamar tidak valid.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus kamar {selectedKamar.Nomor}?",
                "Konfirmasi Penghapusan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
                    DataTable allKamar = dbcon.getAllKamar(kos.id_kos);

                    var kamarStatus = allKamar.AsEnumerable()
                        .Where(row => row.Field<string>("id_kamar") == selectedKamar.Id)
                        .Select(row => row.Field<string>("status_kamar"))
                        .FirstOrDefault();

                    if (kamarStatus == "dihuni")
                    {
                        MessageBox.Show("Tidak dapat menghapus kamar yang sedang dihuni.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                    {
                        conn.Open();
                        string query = "DELETE FROM Kamar WHERE id_kamar = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", selectedKamar.Id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kamar berhasil dihapus.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadKamar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus kamar: {ex.Message}", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kodeKamar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih kamar terlebih dahulu untuk meng-generate kode.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idKamar = dataGridView1.SelectedRows[0].Cells["id_kamar"].Value.ToString();
            string statusKamar = dataGridView1.SelectedRows[0].Cells["status_kamar"].Value.ToString().ToLower();

            if (statusKamar == "dihuni")
            {
                MessageBox.Show("Kamar sedang dihuni. Tidak dapat membuat kode unik untuk kamar yang terisi.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (statusKamar == "diperbaiki")
            {
                MessageBox.Show("Kamar sedang diperbaiki. Tidak dapat membuat kode unik untuk kamar yang terisi.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            simpanKodeKamar(idKamar);
            MessageBox.Show("Kode Unik Berhasil Dibuat!", "Pesan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadKamar();
        }


        private void tambahKamar_Click(object sender, EventArgs e)
        {
            penambahanKamar pk = new penambahanKamar(currentPemilik);
            pk.KembaliKeManajemenKamar += (s, args) =>
            {
                this.Show();
                loadKamar();
            };
            this.Hide();
            pk.MdiParent = this.MdiParent;
            pk.Dock = DockStyle.Fill;
            pk.Show();
            pk.FormClosed += (s, args) => pk.Dispose();
        }



        private void loadKamar()
        {
            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
            DataTable dt = dbcon.getAllKamar(kos.id_kos);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }


        private void updateKamar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Tidak ada kamar yang dipilih untuk diperbarui.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(noKamar.Text) ||
                string.IsNullOrWhiteSpace(tipeKamar.Text) ||
                string.IsNullOrWhiteSpace(hargaKamar.Text) ||
                comboKamar.SelectedItem == null)
            {
                MessageBox.Show("Pastikan seluruh informasi terisi!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id_kamar = dataGridView1.SelectedRows[0].Cells["id_kamar"].Value.ToString();


            try
            {
                string nomor = noKamar.Text;
                string tipe = tipeKamar.Text;
                int harga = Convert.ToInt32(hargaKamar.Text);
                string status = comboKamar.SelectedItem.ToString();

                dbcon.updateKamar(id_kamar, nomor, tipe, harga, status);
                MessageBox.Show("Data kamar berhasil diperbarui.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadKamar();

                editGroup.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editGroup_Enter(object sender, EventArgs e)
        {

        }

        private void comboKamar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string generateKodeKamar(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool checkKodeUnik(string kode)
        {
            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Kamar WHERE kode_unik = @kode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kode", kode);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void simpanKodeKamar(string idKamar)
        {
            string kodeBaru;
            int maxTry = 10;
            int tryCount = 0;

            do
            {
                if (tryCount >= maxTry)
                {
                    MessageBox.Show("Gagal generate kode unik setelah beberapa percobaan.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                kodeBaru = generateKodeKamar();
                tryCount++;
            } while (checkKodeUnik(kodeBaru));

            try
            {
                using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                {
                    conn.Open();
                    string query = "UPDATE Kamar SET kode_unik = @kode WHERE id_kamar = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kode", kodeBaru);
                        cmd.Parameters.AddWithValue("@id", idKamar);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Kode kamar berhasil digenerate: {kodeBaru}", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan kode kamar: {ex.Message}", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void manajemenKamar_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            loadKamar();
        }

        private void btnKosongkan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih kamar yang ingin dikosongkan terlebih dahulu.", "Sistem", MessageBoxButtons.OK);
                return;
            }

            string idKamar = dataGridView1.SelectedRows[0].Cells["id_kamar"].Value.ToString();
            string statusKamar = dataGridView1.SelectedRows[0].Cells["status_kamar"].Value.ToString().ToLower();
            DateTime tanggalSekarang = DateTime.Today;

            if (statusKamar == "tersedia" || statusKamar == "diperbaiki")
            {
                MessageBox.Show("Kamar sedang tidak dihuni sehingga tidak perlu dikosongkan.",
                                "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string updateSewaQuery = @"
                        UPDATE Sewa
                        SET tanggal_akhir = @tanggalSekarang
                        WHERE id_kamar = @idKamar AND tanggal_akhir IS NULL";

                    SqlCommand cmdSewa = new SqlCommand(updateSewaQuery, conn, transaction);
                    cmdSewa.Parameters.AddWithValue("@tanggalSekarang", tanggalSekarang);
                    cmdSewa.Parameters.AddWithValue("@idKamar", idKamar);
                    cmdSewa.ExecuteNonQuery();

                    string updateKamarQuery = "UPDATE Kamar SET status_kamar = 'tersedia' WHERE id_kamar = @idKamar";
                    SqlCommand cmdKamar = new SqlCommand(updateKamarQuery, conn, transaction);
                    cmdKamar.Parameters.AddWithValue("@idKamar", idKamar);
                    cmdKamar.ExecuteNonQuery();

                    string updatePenghuniQuery = @"
                        UPDATE Penghuni
                        SET status_huni = 'nonaktif'
                        WHERE id_penghuni IN (
                            SELECT id_penghuni
                            FROM Sewa
                            WHERE id_kamar = @idKamar AND tanggal_akhir = @tanggalSekarang
                        )";
                    SqlCommand cmdPenghuni = new SqlCommand(updatePenghuniQuery, conn, transaction);
                    cmdPenghuni.Parameters.AddWithValue("@idKamar", idKamar);
                    cmdPenghuni.Parameters.AddWithValue("@tanggalSekarang", tanggalSekarang);
                    cmdPenghuni.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("Kamar berhasil dikosongkan dan status penghuni diperbarui.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadKamar();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Gagal mengosongkan kamar: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEksporLaporanKamar_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
