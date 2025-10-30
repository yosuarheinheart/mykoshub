using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyKosHub
{
    public partial class KelolaStatus : Form
    {
        private Pemilik currentPemilik;
        private string selectedPembayaranId;
        private string currentCategory = "sewa";
        dbConnect dbcon = new dbConnect();

        public KelolaStatus(Pemilik pemilik)
        {
            InitializeComponent();
            this.AutoScroll = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            groupPembayaran.Visible = false;
            pictureBukti.Visible = false;
            btnHide.Visible = false;
            label3.Visible = false;

            this.currentPemilik = pemilik;

            optionStatus.Items.Clear();
            optionStatus.Items.AddRange(new string[] { "terverifikasi", "ditolak" });

            buttonSewa.Click += (s, e) => LoadData(category: "sewa");
            buttonLayanan.Click += (s, e) => LoadData(category: "layanan");

        }
        private void LoadData(string category)
        {

            string sql = @"
                            SELECT
                                pb.id_pembayaran,
                                pb.jumlah,
                                pb.bukti,
                                pb.tanggal_pembayaran,
                                pb.status_pengecekan,
                                pb.catatan,
                                CASE
                                    WHEN pb.id_pesanan IS NOT NULL THEN 'layanan'
                                    ELSE 'sewa'
                                END AS kategori
                            FROM Pembayaran pb
                            LEFT JOIN Tagihan t ON pb.id_tagihan = t.id_tagihan
                            LEFT JOIN Sewa sw   ON t.id_sewa     = sw.id_sewa
                            LEFT JOIN Kamar km  ON sw.id_kamar   = km.id_kamar
                            LEFT JOIN Kos ks1   ON km.id_kos     = ks1.id_kos
                            LEFT JOIN Pesanan_Layanan pl ON pb.id_pesanan = pl.id_pesanan
                            LEFT JOIN Layanan_Kamar lk   ON pl.id_layanan = lk.id_layanan
                            LEFT JOIN Kos ks2            ON lk.id_kos     = ks2.id_kos
                            WHERE (ks1.id_pemilik = @idPemilik OR ks2.id_pemilik = @idPemilik)
                        ";

            if (category == "layanan")
                sql += "  AND pb.id_pesanan IS NOT NULL";

            if (category == "sewa")
                sql += "  AND pb.id_pesanan IS NULL";

            sql += "  AND (pb.status_pengecekan IS NULL OR pb.status_pengecekan != 'terverifikasi')";

            Bind(sql,
                new SqlParameter("@idPemilik", currentPemilik.id_pemilik)
            );
        }


        private void Bind(string sql, params SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(ps);
                da.Fill(dt);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                selectedPembayaranId = row.Cells["id_pembayaran"].Value?.ToString();
                groupPembayaran.Visible = true;

                pictureBukti.Visible = true;
                btnHide.Visible = true;
                label3.Visible = true;

                if (row.Cells["bukti"] != null && row.Cells["bukti"].Value != DBNull.Value)
                {
                    string buktiRelativePath = row.Cells["bukti"].Value.ToString();
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string imagePath = System.IO.Path.Combine(baseDir, buktiRelativePath.TrimStart('/', '\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        try
                        {
                            using (var stream = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                            {
                                pictureBukti.Image = Image.FromStream(stream);
                                pictureBukti.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                        catch (Exception ex)
                        {
                            pictureBukti.Image = null;
                            MessageBox.Show($"Gagal memuat gambar.\nError: {ex.Message}", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        pictureBukti.Image = null;
                        MessageBox.Show("File gambar tidak ditemukan pada path:\n" + imagePath, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    pictureBukti.Image = null;
                    MessageBox.Show("Tidak ada path gambar bukti pembayaran.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih satu baris pembayaran terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedPembayaranId))
            {
                MessageBox.Show("Tidak ada pembayaran yang dipilih.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusBaru = optionStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(statusBaru))
            {
                MessageBox.Show("Silakan pilih status terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlPembayaran = statusBaru == "ditolak"
                ? @"UPDATE Pembayaran SET status_pengecekan = @status, catatan = @catatan WHERE id_pembayaran = @id"
                : @"UPDATE Pembayaran SET status_pengecekan = @status, catatan = NULL WHERE id_pembayaran = @id";

            using (var conn = new SqlConnection(dbcon.cs))
            {
                conn.Open();
                try
                {
                    using (var cmd = new SqlCommand(sqlPembayaran, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", statusBaru);
                        cmd.Parameters.AddWithValue("@id", selectedPembayaranId);
                        if (statusBaru == "ditolak")
                            cmd.Parameters.AddWithValue("@catatan", isiCatatan.Text);
                        cmd.ExecuteNonQuery();
                    }

                    string idTagihan = null;
                    string idPesanan = null;
                    using (var cmdGet = new SqlCommand(
                        "SELECT id_tagihan, id_pesanan FROM Pembayaran WHERE id_pembayaran = @id", conn))
                    {
                        cmdGet.Parameters.AddWithValue("@id", selectedPembayaranId);
                        using (var reader = cmdGet.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (reader["id_tagihan"] != DBNull.Value)
                                    idTagihan = reader["id_tagihan"].ToString();

                                if (reader["id_pesanan"] != DBNull.Value)
                                    idPesanan = reader["id_pesanan"].ToString();
                            }
                        }
                    }

                    if (idTagihan != null)
                    {
                        using (var cmdUpdateTagihan = new SqlCommand(
                            "UPDATE Tagihan SET status_pembayaran = @st WHERE id_tagihan = @tid", conn))
                        {
                            int st = (statusBaru == "terverifikasi") ? 1 : 0;
                            cmdUpdateTagihan.Parameters.AddWithValue("@st", st);
                            cmdUpdateTagihan.Parameters.AddWithValue("@tid", idTagihan);
                            cmdUpdateTagihan.ExecuteNonQuery();
                        }
                    }

                    if (statusBaru == "terverifikasi" && currentCategory == "sewa" && idTagihan != null)
                    {
                        string idSewa = null;
                        DateTime jatuhTempoLama = DateTime.MinValue;
                        int biaya = 0;

                        using (var cmdGetDetail = new SqlCommand(
                            "SELECT id_sewa, tanggal_jatuh_tempo, biaya FROM Tagihan WHERE id_tagihan = @tid", conn))
                        {
                            cmdGetDetail.Parameters.AddWithValue("@tid", idTagihan);
                            using (var reader = cmdGetDetail.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    idSewa = reader["id_sewa"].ToString();
                                    jatuhTempoLama = Convert.ToDateTime(reader["tanggal_jatuh_tempo"]);
                                    biaya = Convert.ToInt32(reader["biaya"]);
                                }
                            }
                        }

                        if (idSewa != null)
                        {
                            string idTagihanBaru = dbcon.generateIdTagihan();
                            DateTime jatuhTempoBaru = jatuhTempoLama.AddMonths(1);

                            using (var cmdInsertTagihan = new SqlCommand(
                                @"INSERT INTO Tagihan (id_tagihan, id_sewa, biaya, status_pembayaran, tanggal_jatuh_tempo)
                          VALUES (@id, @sewa, @biaya, 0, @tgl)", conn))
                            {
                                cmdInsertTagihan.Parameters.AddWithValue("@id", idTagihanBaru);
                                cmdInsertTagihan.Parameters.AddWithValue("@sewa", idSewa);
                                cmdInsertTagihan.Parameters.AddWithValue("@biaya", biaya);
                                cmdInsertTagihan.Parameters.AddWithValue("@tgl", jatuhTempoBaru);
                                cmdInsertTagihan.ExecuteNonQuery();
                            }
                        }
                    }

                    if (idPesanan != null)
                    {
                        string newStatus = statusBaru == "terverifikasi" ? "diproses"
                                         : statusBaru == "ditolak" ? "batal" : null;

                        if (newStatus != null)
                        {
                            using (var cmdUpdatePesanan = new SqlCommand(
                                "UPDATE Pesanan_Layanan SET status = @newStatus " +
                                "WHERE id_pesanan = @pid AND status = 'menunggu_pembayaran'", conn))
                            {
                                cmdUpdatePesanan.Parameters.AddWithValue("@newStatus", newStatus);
                                cmdUpdatePesanan.Parameters.AddWithValue("@pid", idPesanan);
                                cmdUpdatePesanan.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Status pembayaran berhasil diperbarui.", "Sistem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData(currentCategory);
                    groupPembayaran.Visible = false;   
                    isiCatatan.Clear();
                    pictureBukti.Image = null;
                    label3.Visible = false;
                    btnHide.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Sistem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


  

        private void optionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (optionStatus.SelectedItem?.ToString() == "ditolak")
            {
                isiCatatan.Visible = true;
                label4.Visible = true;
            }
            else
            {
                isiCatatan.Visible = false;
                label4.Visible = false;
            }
        }

        private void pictureBukti_Click(object sender, EventArgs e)
        {

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            pictureBukti.Visible = false;
            btnHide.Visible = false;
            label3.Visible = false;
        }

        private void KelolaStatus_Load(object sender, EventArgs e)
        {

        }
    }
}