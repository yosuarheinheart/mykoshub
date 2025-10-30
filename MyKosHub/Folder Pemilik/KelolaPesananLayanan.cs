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
using OfficeOpenXml;
using OfficeOpenXml.Style;



namespace MyKosHub
{
    public partial class KelolaPesananLayanan : Form
    {
        public static KelolaPesananLayanan instance;
        private Pemilik currentPemilik;
        private dbConnect dbcon = new dbConnect();
        public event EventHandler KembaliKeManajemenLayanan;
        public KelolaPesananLayanan(Pemilik pemilik)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.currentPemilik = pemilik;
            instance = this;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ManajemenLayanan form = new ManajemenLayanan(currentPemilik);
            form.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void KelolaPesananLayanan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            optionRiwayat.Items.Clear();
            optionRiwayat.Items.Add("selesai");
            optionRiwayat.Items.Add("batal");
            optionRiwayat.SelectedIndex = -1;
            optionRiwayat.Text = "Pilih status";

            loadPesananDiproses();
        }

        private void loadPesananDiproses()
        {
            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);
            string query = @"
                SELECT pl.id_pesanan, pl.id_layanan, lk.nama AS nama_layanan, 
                       pl.id_penghuni, p.nama AS nama_penghuni, 
                       pl.tanggal, pl.status, pl.catatan
                FROM Pesanan_Layanan pl
                JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                JOIN Penghuni p ON pl.id_penghuni = p.id_penghuni
                WHERE pl.status = 'diproses' AND lk.id_kos = @idKos";

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idKos", kos.id_kos);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih pesanan yang ingin diperbarui terlebih dahulu.", "Peringatan");
                return;
            }

            string id_pesanan = dataGridView1.SelectedRows[0].Cells["id_pesanan"].Value.ToString();

            var confirmResult = MessageBox.Show(
                "Apakah Anda yakin ingin menyelesaikan pesanan ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                    {
                        conn.Open();
                        string updateQuery = "UPDATE Pesanan_Layanan SET status = 'selesai' WHERE id_pesanan = @id";
                        SqlCommand cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@id", id_pesanan);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Status pesanan berhasil diperbarui menjadi selesai.", "Sukses");
                    loadPesananDiproses();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat mengupdate status: " + ex.Message, "Error");
                }
            }
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);

            string query = @"
                SELECT pl.id_pesanan, pl.id_layanan, lk.nama AS nama_layanan, 
                       pl.id_penghuni, p.nama AS nama_penghuni, 
                       pl.tanggal, pl.status, pl.catatan
                FROM Pesanan_Layanan pl
                JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                JOIN Penghuni p ON pl.id_penghuni = p.id_penghuni
                WHERE (pl.status = 'selesai' OR pl.status = 'batal') AND lk.id_kos = @idKos";

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idKos", kos.id_kos);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void optionRiwayat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optionRiwayat.SelectedItem == null) return;

            string selectedStatus = optionRiwayat.SelectedItem.ToString();
            if (selectedStatus != "selesai" && selectedStatus != "batal") return;

            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);

            string query = @"
                SELECT pl.id_pesanan, pl.id_layanan, lk.nama AS nama_layanan, 
                       pl.id_penghuni, p.nama AS nama_penghuni, 
                       pl.tanggal, pl.status, pl.catatan
                FROM Pesanan_Layanan pl
                JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                JOIN Penghuni p ON pl.id_penghuni = p.id_penghuni
                WHERE pl.status = @status AND lk.id_kos = @idKos";

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@status", selectedStatus);
                cmd.Parameters.AddWithValue("@idKos", kos.id_kos);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnManajemen_Click(object sender, EventArgs e)
        {
            this.Close();
            KembaliKeManajemenLayanan?.Invoke(this, EventArgs.Empty);
        }

        private void btnProses_Click(object sender, EventArgs e)
        {
            loadPesananDiproses();
        }

        private void btnEkspor_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = optionRiwayat.SelectedItem?.ToString();
            string judul;

            if (status == "selesai")
            {
                judul = "Riwayat_Pesanan_Selesai";
            }
            else if (status == "batal")
            {
                judul = "Riwayat_Pesanan_Dibatalkan";
            }
            else
            {
                judul = "Pesanan_Sedang_Diproses";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = judul + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        List<string> headers = new List<string>();
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            headers.Add(EscapeCsvValue(column.HeaderText));
                        }
                        writer.WriteLine(string.Join(";", headers)); 

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                List<string> cells = new List<string>();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    string value = cell.Value?.ToString() ?? "";
                                    cells.Add(EscapeCsvValue(value));
                                }
                                writer.WriteLine(string.Join(";", cells)); 
                            }
                        }
                    }

                    MessageBox.Show("Data berhasil diekspor ke file CSV (.csv).", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat mengekspor ke file CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string EscapeCsvValue(string value)
        {
            if (value.Contains(";") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return "\"" + value + "\"";
            }
            return value;
        }

        private void btnImpor_Click(object sender, EventArgs e)
        {

        }

        private void btnEksporTXT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diekspor.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string status = optionRiwayat.SelectedItem?.ToString();
            string judul;

            if (status == "selesai")
            {
                judul = "Riwayat_Pesanan_Selesai";
            }
            else if (status == "batal")
            {
                judul = "Riwayat_Pesanan_Dibatalkan";
            }
            else
            {
                judul = "Pesanan_Sedang_Diproses";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (.txt)|.txt",
                FileName = judul + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        List<string> headers = new List<string>();
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            headers.Add(column.HeaderText);
                        }
                        writer.WriteLine(string.Join("\t", headers));

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                List<string> cells = new List<string>();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    string value = cell.Value?.ToString() ?? "";
                                    cells.Add(value);
                                }
                                writer.WriteLine(string.Join("\t", cells));
                            }
                        }
                    }

                    MessageBox.Show("Data berhasil diekspor ke file teks (.txt).", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat mengekspor ke file teks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
