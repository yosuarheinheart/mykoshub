using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;


namespace MyKosHub
{
    public partial class KelolaKeluhan : Form
    {
        private Pemilik currentPemilik;
        private string selectedKeluhanId;
        private string selectedPhoneNumber;
        private string currentStatusFilter = "semua";
        dbConnect dbcon = new dbConnect();

        public KelolaKeluhan(Pemilik pemilik)
        {
            InitializeComponent();
            this.AutoScroll = true;
            btnChatWA.Visible = false;
            logoWhatsapp.Visible = false;

            this.currentPemilik = pemilik;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            grupKeluhan.Visible = false;
            grupPeriode.Visible = false;
            LoadKeluhan();
        }

        private void KelolaKeluhan_Load(object sender, EventArgs e)
        {
            IsiOpsiTahunBulan();
        }

        private void IsiOpsiTahunBulan()
        {
            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);

            string queryTahun = @"
                                SELECT DISTINCT FORMAT(tanggal_keluhan, 'yyyy') AS Tahun
                                FROM Keluhan_Kos
                                WHERE id_kos = @kos
                                ORDER BY Tahun DESC";

            string queryBulan = @"
                                SELECT DISTINCT FORMAT(tanggal_keluhan, 'MM') AS Bulan
                                FROM Keluhan_Kos
                                WHERE id_kos = @kos
                                ORDER BY Bulan ASC";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(queryTahun, conn))
                    {
                        cmd.Parameters.AddWithValue("@kos", kos.id_kos);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            opsiTahun.Items.Clear();
                            while (reader.Read())
                            {
                                opsiTahun.Items.Add(reader["Tahun"].ToString());
                            }
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(queryBulan, conn))
                    {
                        cmd.Parameters.AddWithValue("@kos", kos.id_kos);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            opsiBulan.Items.Clear();
                            while (reader.Read())
                            {
                                int bulanInt = int.Parse(reader["Bulan"].ToString());
                                string namaBulan = new DateTime(2025, bulanInt, 1).ToString("MMMM");
                                opsiBulan.Items.Add(namaBulan);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data tahun/bulan: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            var row = dataGridView1.SelectedRows[0];
            selectedKeluhanId = row.Cells["id_keluhan"].Value?.ToString();
            var status = row.Cells["status_keluhan"].Value?.ToString();
            optionStatus.SelectedItem = status;
            noteKeluhan.Text = row.Cells["catatan"].Value?.ToString();

            grupKeluhan.Visible = false;

            switch (status)
            {
                case "pending":
                    grupKeluhan.Visible = true;
                    optionStatus.Items.Clear();

                    label3.Visible = true;
                    noteKeluhan.Visible = true;
                    noteKeluhan.ReadOnly = false;
                    label2.Visible = true;
                    optionStatus.Items.AddRange(new string[] { "diproses", "terselesaikan" });
                    btnSubmit.Visible = true;
                    break;

                case "diproses":
                    grupKeluhan.Visible = true;
                    optionStatus.Items.Clear();

                    label3.Visible = true;
                    noteKeluhan.Visible = true;
                    noteKeluhan.ReadOnly = false;
                    label2.Visible = true;
                    optionStatus.Visible = true;
                    optionStatus.Items.AddRange(new string[] { "terselesaikan" });
                    btnSubmit.Visible = true;
                    break;

                case "terselesaikan":
                    grupKeluhan.Visible = false;
                    break;
            }

            selectedPhoneNumber = row.Cells["nomor_telepon"].Value?.ToString();
        }

        private void LoadKeluhan()
        {
            string sql = @"
                SELECT 
                    kk.id_keluhan,
                    kk.tanggal_keluhan,
                    p.nama AS nama_penghuni,
                    p.nomor_telepon,
                    k.nama AS nama_kos,
                    kk.isi_keluhan,
                    kk.status_keluhan,
                    kk.catatan
                FROM Keluhan_Kos kk
                JOIN Penghuni p ON kk.id_penghuni = p.id_penghuni
                JOIN Kos k ON kk.id_kos = k.id_kos
                WHERE k.id_pemilik = @idPemilik
                ORDER BY kk.tanggal_keluhan DESC";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@idPemilik", currentPemilik.id_pemilik);
                da.Fill(dt);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
        }

        private void LoadFilter(string category)
        {
            string sql = @"
                SELECT 
                    kk.id_keluhan,
                    kk.tanggal_keluhan,
                    p.nama AS nama_penghuni,
                    p.nomor_telepon,
                    k.nama AS nama_kos,
                    kk.isi_keluhan,
                    kk.status_keluhan,
                    kk.catatan
                FROM Keluhan_Kos kk
                JOIN Penghuni p ON kk.id_penghuni = p.id_penghuni
                JOIN Kos k ON kk.id_kos = k.id_kos
                WHERE k.id_pemilik = @idPemilik";

            if (category == "pending")
                sql += "  AND kk.status_keluhan = 'pending'";
            else if (category == "diproses")
                sql += "  AND kk.status_keluhan = 'diproses'";
            else
                sql += "  AND kk.status_keluhan = 'terselesaikan'";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@idPemilik", currentPemilik.id_pemilik);
                da.Fill(dt);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
        }   

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedKeluhanId))
            {
                MessageBox.Show("Silakan pilih keluhan dari tabel.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusBaru = optionStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(statusBaru))
            {
                MessageBox.Show("Silakan pilih status baru untuk keluhan.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string catatan = noteKeluhan.Text?.Trim();

            string sql = @"
                UPDATE Keluhan_Kos 
                SET status_keluhan = @status, catatan = @catatan 
                WHERE id_keluhan = @id";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@status", statusBaru);
                cmd.Parameters.AddWithValue("@catatan", (object)catatan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", selectedKeluhanId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Status keluhan berhasil diperbarui.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKeluhan();
                    selectedKeluhanId = null;
                    optionStatus.SelectedIndex = -1;
                    noteKeluhan.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui status keluhan.\n" + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            grupKeluhan.Visible = false;
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            currentStatusFilter = "pending";
            grupPeriode.Visible = true;
            LoadFilter("pending");
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            currentStatusFilter = "diproses";
            grupPeriode.Visible = true;
            LoadFilter("diproses");
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            currentStatusFilter = "terselesaikan";
            grupPeriode.Visible = true;
            LoadFilter("terselesaikan");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            currentStatusFilter = "";
            grupPeriode.Visible = true;
            LoadKeluhan();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnChatWA.Visible = true;
            logoWhatsapp.Visible = true;
        }

        private void btnChatWA_Click(object sender, EventArgs e)
        {
            string phoneNumber = new string(selectedPhoneNumber.Where(char.IsDigit).ToArray());
            if (string.IsNullOrEmpty(selectedPhoneNumber))
            {
                MessageBox.Show("Nomor telepon tidak tersedia.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Nomor telepon tidak valid.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string waUrl = $"https://wa.me/{phoneNumber}";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = waUrl,
                UseShellExecute = true
            });
        }

        private void btnCetakLaporan_Click(object sender, EventArgs e)
        {
            if (opsiTahun.SelectedItem == null || opsiBulan.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih Tahun dan Bulan terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string bulan = opsiBulan.SelectedItem.ToString();
            string tahun= opsiTahun.SelectedItem.ToString();

            LaporanKeluhanViewer view = new LaporanKeluhanViewer(currentPemilik, bulan, tahun, currentStatusFilter);
            view.ShowDialog();
        }

    }
}
