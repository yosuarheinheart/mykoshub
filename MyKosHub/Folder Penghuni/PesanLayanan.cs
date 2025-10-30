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

namespace MyKosHub
{
    public partial class PesanLayanan : Form
    {
        private string selectedLayananId = "";
        private string selectedLayananNama = "";
        private Penghuni currentPenghuni;
        private dbConnect dbcon = new dbConnect();


        public PesanLayanan(Penghuni penghuni)
        {
            InitializeComponent();
            this.AutoScroll = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            this.currentPenghuni = penghuni;
            LoadLayananKamar();
            grupLayanan.Visible = false;
        }

        private void LoadLayananKamar()
        {
            Kos kosPenghuni = dbcon.getKosByPenghuni(currentPenghuni.id_penghuni);

            if (kosPenghuni == null)
            {
                MessageBox.Show("Data kos tidak ditemukan untuk penghuni ini.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "SELECT id_layanan, nama, biaya, deskripsi FROM Layanan_Kamar WHERE id_kos = @id_kos";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_kos", kosPenghuni.id_kos);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["id_layanan"].Visible = false;
                    dataGridView1.Columns["nama"].HeaderText = "Nama Layanan";
                    dataGridView1.Columns["biaya"].HeaderText = "Biaya (Rp)";
                    dataGridView1.Columns["deskripsi"].HeaderText = "Deskripsi";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnPesan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedLayananId))
            {
                MessageBox.Show("Silakan pilih layanan terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(currentPenghuni.id_penghuni))
            {
                MessageBox.Show("ID Penghuni tidak valid.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string catatan = catatanPesanan.Text.Trim();
            string idPesanan = dbcon.generateIdPesananLayanan();
            string tanggalHariIni = DateTime.Now.ToString("yyyy-MM-dd");

            string query = @"INSERT INTO Pesanan_Layanan 
                             (id_pesanan, id_layanan, id_penghuni, tanggal, status, catatan)
                             VALUES (@id, @id_layanan, @id_penghuni, @tanggal, 'menunggu_pembayaran', @catatan)";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idPesanan);
                    cmd.Parameters.AddWithValue("@id_layanan", selectedLayananId);
                    cmd.Parameters.AddWithValue("@id_penghuni", currentPenghuni.id_penghuni);
                    cmd.Parameters.AddWithValue("@tanggal", tanggalHariIni);
                    cmd.Parameters.AddWithValue("@catatan", catatan);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pesanan layanan berhasil dikirim.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grupLayanan.Visible = false;
                    selectedLayananId = "";
                    selectedLayananNama = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat memesan layanan: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedLayananId = row.Cells["id_layanan"].Value.ToString();
                selectedLayananNama = row.Cells["nama"].Value.ToString();

                namaPesanan.Text = selectedLayananNama;
                catatanPesanan.Text = "";
                grupLayanan.Visible = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void namaPesanan_Click(object sender, EventArgs e)
        {

        }
    }
}
