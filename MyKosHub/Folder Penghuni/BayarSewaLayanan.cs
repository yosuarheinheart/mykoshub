using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKosHub
{
    public partial class BayarSewaLayanan : Form
    {
        private Penghuni currentPenghuni;
        private string pathBukti = "";
        private string selectedTagihanId = null;
        private string selectedPesananId = null;
        private decimal selectedBiaya = 0;

        private dbConnect dbcon = new dbConnect();

        public BayarSewaLayanan(Penghuni penghuni)
        {
            InitializeComponent();
            this.AutoScroll = true;
            currentPenghuni = penghuni;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            grupBayar.Visible = false;
            LoadPembayaran();
        }

        private DataTable GetData(string query)
        {
            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        private void LoadPembayaran()
        {
            string query = @"
                SELECT pb.id_pembayaran, pb.jumlah, pb.tanggal_pembayaran, pb.bukti, 
                       pb.status_pengecekan, pb.catatan
                FROM Pembayaran pb
                INNER JOIN Tagihan t ON pb.id_tagihan = t.id_tagihan
                INNER JOIN Sewa s ON t.id_sewa = s.id_sewa
                WHERE s.id_penghuni = @id_penghuni";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@id_penghuni", currentPenghuni.id_penghuni);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["id_pembayaran"].HeaderText = "ID Pembayaran";
                dataGridView1.Columns["jumlah"].HeaderText = "Jumlah (Rp)";
                dataGridView1.Columns["tanggal_pembayaran"].HeaderText = "Tanggal";
                dataGridView1.Columns["bukti"].HeaderText = "Bukti";
                dataGridView1.Columns["status_pengecekan"].HeaderText = "Status";
                dataGridView1.Columns["catatan"].HeaderText = "Catatan";
            }
        }

        private string GenerateNewPembayaranId()
        {
            string prefix = "PY";
            int lastNumber = 0;

            string query = "SELECT TOP 1 id_pembayaran FROM Pembayaran ORDER BY id_pembayaran DESC";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    string lastId = result.ToString(); 
                    if (lastId.Length > 2)
                    {
                        int.TryParse(lastId.Substring(2), out lastNumber);
                    }
                }
            }

            return prefix + (lastNumber + 1).ToString("D4");
        }

        private void btnSewa_Click(object sender, EventArgs e)
        {
            optionRiwayat.Visible = false;
            grupBayar.Visible = false;

            string query = @"
        SELECT t.id_tagihan, t.biaya, 
       CASE WHEN t.status_pembayaran = 1 THEN 'Lunas' ELSE 'Belum Lunas' END AS status_pembayaran,
       t.tanggal_jatuh_tempo
        FROM Tagihan t
        JOIN Sewa s ON t.id_sewa = s.id_sewa
        WHERE s.id_penghuni = @id_penghuni";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_penghuni", currentPenghuni.id_penghuni);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnLayanan_Click(object sender, EventArgs e)
        {
            optionRiwayat.Visible = false;
            grupBayar.Visible = false;

            string query = @"
        SELECT l.nama AS nama_layanan, l.biaya, 
               p.status, p.tanggal, p.id_pesanan
        FROM Pesanan_Layanan p
        JOIN Layanan_Kamar l ON p.id_layanan = l.id_layanan
        WHERE p.id_penghuni = @id_penghuni AND p.status = 'menunggu_pembayaran'";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_penghuni", currentPenghuni.id_penghuni);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathBukti))
            {
                MessageBox.Show("Silakan upload bukti pembayaran terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string buktiName = Path.GetFileName(pathBukti);
            string destination = Path.Combine(Application.StartupPath, "bukti", buktiName);
            Directory.CreateDirectory(Path.GetDirectoryName(destination));
            File.Copy(pathBukti, destination, true);

            string buktiPath = destination;

            string newId = GenerateNewPembayaranId();

            string query = @"INSERT INTO Pembayaran 
                            (id_pembayaran, id_tagihan, id_pesanan, jumlah, bukti, status_pengecekan, tanggal_pembayaran) 
                            VALUES (@id, @tagihan, @pesanan, @jumlah, @bukti, 'menunggu', @tanggal)";

            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", newId);
                cmd.Parameters.AddWithValue("@tagihan", (object)selectedTagihanId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pesanan", (object)selectedPesananId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@jumlah", selectedBiaya);
                cmd.Parameters.AddWithValue("@bukti", buktiPath);
                cmd.Parameters.AddWithValue("@tanggal", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Pembayaran Berhasil!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPembayaran();
                grupBayar.Visible = false;

                btnRiwayat.PerformClick();

                if (selectedTagihanId != null)
                {
                    optionRiwayat.SelectedItem = "Sewa";
                }
                else if (selectedPesananId != null)
                {
                    optionRiwayat.SelectedItem = "Layanan";
                }
            }
            grupBayar.Visible = false;
        }

     
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                string jenis = "";
                string detail = "";
                string jumlah = "";

                if (dataGridView1.Columns.Contains("id_tagihan") && row.Cells["id_tagihan"].Value != null)
                {
                    selectedTagihanId = row.Cells["id_tagihan"].Value.ToString();
                    selectedPesananId = null;
                    selectedBiaya = Convert.ToDecimal(row.Cells["biaya"].Value);

                    detail = "Tagihan Sewa";
                    jumlah = row.Cells["biaya"].Value?.ToString();
                }
                else if (dataGridView1.Columns.Contains("id_pesanan") && row.Cells["id_pesanan"].Value != null)
                {
                    jenis = "Layanan";
                    selectedPesananId = row.Cells["id_pesanan"].Value.ToString();
                    selectedTagihanId = null;
                    selectedBiaya = Convert.ToDecimal(row.Cells["biaya"].Value);

                    detail = row.Cells["nama_layanan"].Value?.ToString();
                    jumlah = row.Cells["biaya"].Value?.ToString();
                }
                else
                {
                    MessageBox.Show("Data yang dipilih tidak valid.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                grupBayar.Visible = true;
                infoDetailTagihan.Text = $": {jenis}: {detail}";
                totalBiaya.Text = ": Rp " + jumlah;

                pictureBukti.Image = null;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pathBukti = ofd.FileName;
                pictureBukti.Image = Image.FromFile(pathBukti);
                pictureBukti.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBukti.Visible = true;
            }
        }


        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            
            optionRiwayat.Visible = true;
            optionRiwayat.Items.Clear();
            optionRiwayat.Items.Add("Sewa");
            optionRiwayat.Items.Add("Layanan");
        }

        private void optionRiwayat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = optionRiwayat.SelectedItem.ToString();

            if (selected == "Layanan")
            {
                string query = @"
            SELECT l.nama AS nama_layanan, p.jumlah, 
                   p.tanggal_pembayaran, p.status_pengecekan, p.catatan
            FROM Pembayaran p
            JOIN Pesanan_Layanan pl ON p.id_pesanan = pl.id_pesanan
            JOIN Layanan_Kamar l ON pl.id_layanan = l.id_layanan
            WHERE pl.id_penghuni = @id_penghuni";

                using (SqlConnection conn = new SqlConnection(dbcon.cs))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_penghuni", currentPenghuni.id_penghuni);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            else
            {
                string query = @"
            SELECT k.nomor_kamar, p.jumlah, 
                   p.tanggal_pembayaran, p.status_pengecekan, p.catatan
            FROM Pembayaran p
            JOIN Tagihan t ON p.id_tagihan = t.id_tagihan
            JOIN Sewa s ON t.id_sewa = s.id_sewa
            JOIN Kamar k ON s.id_kamar = k.id_kamar
            WHERE s.id_penghuni = @id_penghuni";

                using (SqlConnection conn = new SqlConnection(dbcon.cs))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_penghuni", currentPenghuni.id_penghuni);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void BayarSewaLayanan_Load(object sender, EventArgs e)
        {

        }
    }
}
