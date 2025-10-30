using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyKosHub
{
    public partial class HomepagePenghuni : Form
    {
        private Penghuni current;
        dbConnect dbcon = new dbConnect();

        public HomepagePenghuni(Penghuni penghuni)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.current = penghuni;
        }

        private void HomepagePenghuni_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            label2.Text = $"Selamat datang {current.nama}";

            labelNoKeluhan.Text = "Sampaikan keluhan Anda kepada pemilik kos!";
            labelNoMasalah.Text = "Segera laporkan masalah aplikasi yang Anda temukan!";

            var umurHuni = masaHuniTerbaru().AsEnumerable().FirstOrDefault();

            loadTotalPengeluaran();

            if (umurHuni != null)
            {
                int lamaHari = umurHuni.Field<int>("lama_huni_hari");

                int? sisaHariNullable = umurHuni.Field<int?>("sisa_hari_sewa");

                lamaSewa.Text = $"{lamaHari} hari";

                if (sisaHariNullable.HasValue)
                {
                    sisaSewa.Text = $"Jatuh tempo kembali dalam {sisaHariNullable.Value} hari";
                }
                else
                {
                    sisaSewa.Text = "—";    
                }
            }

            statusLayananTerbaru();
            loadKeluhan();
            loadMasalah();
            LoadBulanComboBox(current.id_penghuni);
            LoadChartPengeluaran(current.id_penghuni);
            loadTagihanPenghuni(current.id_penghuni);
        }

        private void loadTotalPengeluaran()
        {
            string sql = @"
                            SELECT 
                                ISNULL(SUM(jumlah), 0)    AS TotalPengeluaran,
                                MAX(tanggal_pembayaran)   AS TanggalTerakhir
                            FROM
                            (
                                SELECT pb.jumlah, pb.tanggal_pembayaran
                                FROM Pembayaran pb
                                JOIN Tagihan t ON pb.id_tagihan = t.id_tagihan
                                JOIN Sewa s   ON t.id_sewa = s.id_sewa
                                WHERE s.id_penghuni = @id_penghuni
                                  AND pb.status_pengecekan = 'terverifikasi'

                                UNION ALL

                                SELECT pb.jumlah, pb.tanggal_pembayaran
                                FROM Pembayaran pb
                                JOIN Pesanan_Layanan pl ON pb.id_pesanan = pl.id_pesanan
                                WHERE pl.id_penghuni = @id_penghuni
                                  AND pb.status_pengecekan = 'terverifikasi'
                            ) AS gab
                        ";

            using (var conn = new SqlConnection(dbcon.GetConnectionString()))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id_penghuni", current.id_penghuni);
                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        decimal total = Convert.ToDecimal(reader["TotalPengeluaran"]);
                        object dtObj = reader["TanggalTerakhir"];

                        totalPengeluaran.Text = $"Rp {total:N0}";

                        if (dtObj != DBNull.Value)
                        {
                            DateTime terakhir = (DateTime)dtObj;
                            tanggalBayar.Text = "Transaksi terakhir pada " + terakhir.ToString("dd MMMM yyyy");

                            tanggalBayar.Visible = true;
                        }
                        else
                        {
                            tanggalBayar.Visible = false;
                        }
                    }
                }
            }
        }

        public DataTable masaHuniTerbaru()
        {
            string sql = @"
                            WITH LastSewa AS (
                              SELECT
                                *,
                                ROW_NUMBER() OVER (PARTITION BY id_penghuni ORDER BY tanggal_awal DESC) AS rn
                              FROM Sewa
                            )
                            SELECT
                              ls.id_penghuni,
                              p.nama           AS nama_penghuni,
                              ls.tanggal_awal,
                              ls.tanggal_akhir,
                              DATEDIFF(
                                DAY,
                                ls.tanggal_awal,
                                CAST(GETDATE() AS DATE)
                              ) AS lama_huni_hari,
                              CASE
                                WHEN DATEDIFF(DAY, ls.tanggal_awal, CAST(GETDATE() AS DATE)) <= 30 
                                  THEN 30 - DATEDIFF(DAY, ls.tanggal_awal, CAST(GETDATE() AS DATE))
                                ELSE 0
                              END AS sisa_hari_sewa
                            FROM LastSewa ls
                            JOIN Penghuni p 
                              ON ls.id_penghuni = p.id_penghuni
                            WHERE ls.rn = 1
                              AND ls.id_penghuni = @idPenghuni;
                        ";

            var dt = new DataTable();
            using (var conn = new SqlConnection(dbcon.cs))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@idPenghuni", current.id_penghuni);
                da.Fill(dt);
            }
            return dt;
        }

        private void statusLayananTerbaru()
        {
            string sql = @"
                            SELECT TOP 1
                                lk.nama,
                                pl.status
                            FROM Pesanan_Layanan pl
                            JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                            WHERE pl.id_penghuni = @id_penghuni
                            ORDER BY pl.tanggal DESC;
                        ";

            using (var conn = new SqlConnection(dbcon.GetConnectionString()))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id_penghuni", current.id_penghuni);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        namaLayanan.Text = reader.GetString(reader.GetOrdinal("nama"));
                        statusLayanan.Text = reader.GetString(reader.GetOrdinal("status"));

                        statusLayanan.Visible = true;
                    }
                    else
                    {
                        namaLayanan.Text = "Belum ada layanan yang dipesan";
                        statusLayanan.Visible = false;
                    }
                }
            }
        }

        private void loadKeluhan()
        {
            string sql = @"SELECT TOP 5 isi_keluhan, status_keluhan, catatan, tanggal_keluhan
                           FROM Keluhan_Kos
                           WHERE id_penghuni = @id
                           ORDER BY tanggal_keluhan DESC";

            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(dbcon.cs))
            using (var cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@id", current.id_penghuni);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                dataGridView1.Visible = true;
                labelNoKeluhan.Visible = false;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.Visible = false;
                labelNoKeluhan.Visible = true;
            }
        }

        private void loadMasalah()
        {
            string sql = @"SELECT TOP 5 jenis_masalah, isi_masalah, status_masalah, catatan, tanggal_masalah
                           FROM Masalah_Aplikasi
                           WHERE email_penghuni = @email
                           ORDER BY tanggal_masalah DESC";

            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(dbcon.cs))
            using (var cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))

            {
                cmd.Parameters.AddWithValue("@email", current.email);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                dataGridView2.Visible = true;
                labelNoMasalah.Visible = false;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dt;
                btnGoProfil.Visible = false;
            }
            else
            {
                dataGridView2.Visible = false;
                labelNoMasalah.Visible = true;
                btnGoProfil.Visible = true;
            }
        }


        private void LoadChartPengeluaran(string id_penghuni)
        {
            if (optionBulan.SelectedItem == null)
                return;

            string bulanTahun = optionBulan.SelectedItem.ToString();
            DateTime tanggalAwal = DateTime.ParseExact("01 " + bulanTahun, "dd MMMM yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime tanggalAkhir = tanggalAwal.AddMonths(1).AddDays(-1);

            int totalSewa = 0;
            int totalLayanan = 0;

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        ISNULL(SUM(t.biaya), 0) AS TotalSewa
                    FROM Pembayaran pb
                    JOIN Tagihan t ON pb.id_tagihan = t.id_tagihan
                    JOIN Sewa s ON t.id_sewa = s.id_sewa
                    WHERE pb.status_pengecekan = 'terverifikasi'
                      AND s.id_penghuni = @id_penghuni
                      AND pb.tanggal_pembayaran BETWEEN @awal AND @akhir;

                    SELECT 
                        ISNULL(SUM(lk.biaya), 0) AS TotalLayanan
                    FROM Pembayaran pb
                    JOIN Pesanan_Layanan pl ON pb.id_pesanan = pl.id_pesanan
                    JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                    WHERE pb.status_pengecekan = 'terverifikasi'
                      AND pl.id_penghuni = @id_penghuni
                      AND pb.tanggal_pembayaran BETWEEN @awal AND @akhir;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_penghuni", id_penghuni);
                    cmd.Parameters.AddWithValue("@awal", tanggalAwal);
                    cmd.Parameters.AddWithValue("@akhir", tanggalAkhir);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalSewa = Convert.ToInt32(reader["TotalSewa"]);
                        }

                        if (reader.NextResult() && reader.Read())
                        {
                            totalLayanan = Convert.ToInt32(reader["TotalLayanan"]);
                        }
                    }
                }
            }

            proporsiPengeluaran.Series.Clear();
            proporsiPengeluaran.Legends.Clear();

            Legend legend = new Legend();
            legend.Docking = Docking.Top;
            legend.Alignment = System.Drawing.StringAlignment.Center;
            proporsiPengeluaran.Legends.Add(legend);

            var series = new Series("Pengeluaran");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;  
            series.LabelForeColor = Color.Black;

            series.Points.Add(new DataPoint() { AxisLabel = "Sewa", YValues = new double[] { totalSewa }, LegendText = $"Sewa: Rp {totalSewa:N0}", Label = $"Rp {totalSewa:N0}" });
            series.Points.Add(new DataPoint() { AxisLabel = "Layanan", YValues = new double[] { totalLayanan }, LegendText = $"Layanan: Rp {totalLayanan:N0}", Label = $"Rp {totalLayanan:N0}" });

            proporsiPengeluaran.Series.Add(series);

            if (totalSewa + totalLayanan == 0)
            {
                proporsiPengeluaran.Visible = false;
                MessageBox.Show("Tidak ada pengeluaran untuk bulan yang dipilih.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                proporsiPengeluaran.Visible = true;
            }
        }


        private void loadTabelTagihan(string id_penghuni)
        {

        }

        private void LoadBulanComboBox(string id_penghuni)
        {
            optionBulan.Items.Clear();
            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
            SELECT DISTINCT 
                FORMAT(pb.tanggal_pembayaran, 'MMMM yyyy') AS BulanTahun,
                YEAR(pb.tanggal_pembayaran) AS Tahun,
                MONTH(pb.tanggal_pembayaran) AS Bulan
            FROM Pembayaran pb
            JOIN Tagihan t ON pb.id_tagihan = t.id_tagihan
            JOIN Sewa s ON t.id_sewa = s.id_sewa
            WHERE pb.status_pengecekan = 'terverifikasi'
              AND s.id_penghuni = @id_penghuni

            UNION

            SELECT DISTINCT 
                FORMAT(pb.tanggal_pembayaran, 'MMMM yyyy') AS BulanTahun,
                YEAR(pb.tanggal_pembayaran) AS Tahun,
                MONTH(pb.tanggal_pembayaran) AS Bulan
            FROM Pembayaran pb
            JOIN Pesanan_Layanan pl ON pb.id_pesanan = pl.id_pesanan
            WHERE pb.status_pengecekan = 'terverifikasi'
              AND pl.id_penghuni = @id_penghuni

            ORDER BY Tahun DESC, Bulan DESC;
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_penghuni", id_penghuni);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string bulanTahun = reader["BulanTahun"].ToString();
                            if (!optionBulan.Items.Contains(bulanTahun)) 
                                optionBulan.Items.Add(bulanTahun);
                        }
                    }
                }
            }

            if (optionBulan.Items.Count > 0)
            {
                optionBulan.SelectedIndex = 0;
            }
        }

        private void optionBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChartPengeluaran(current.id_penghuni);
        }

        private void loadTagihanPenghuni(string id_penghuni)
        {
            DataTable dt = new DataTable();
            int total = 0;

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        'Tagihan Sewa Kamar' AS NamaTagihan,
                        t.biaya AS Jumlah
                    FROM Tagihan t
                    JOIN Sewa s ON t.id_sewa = s.id_sewa
                    WHERE s.id_penghuni = @id_penghuni
                      AND t.status_pembayaran = 0
                      AND DATEDIFF(DAY, GETDATE(), t.tanggal_jatuh_tempo) BETWEEN 0 AND 5

                    UNION ALL

                    SELECT 
                        lk.nama AS NamaTagihan,
                        lk.biaya AS Jumlah
                    FROM Pesanan_Layanan pl
                    JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                    WHERE pl.id_penghuni = @id_penghuni
                      AND NOT EXISTS (
                          SELECT 1 FROM Pembayaran p 
                          WHERE p.id_pesanan = pl.id_pesanan
                            AND p.status_pengecekan = 'terverifikasi'
                      );
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_penghuni", id_penghuni);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToInt32(row["Jumlah"]);
                }
            }

            if (dt.Rows.Count > 0)
            {
                dataGridView3.DataSource = dt;
                dataGridView3.AutoGenerateColumns = true;

                if (dataGridView3.Columns.Contains("NamaTagihan"))
                    dataGridView3.Columns["NamaTagihan"].HeaderText = "Nama Tagihan";

                if (dataGridView3.Columns.Contains("Jumlah"))
                {
                    dataGridView3.Columns["Jumlah"].HeaderText = "Jumlah (Rp)";
                    dataGridView3.Columns["Jumlah"].DefaultCellStyle.Format = "N0";
                }

                labelSelamat.Visible = false;
                labelTagih.Visible = true;
                dataGridView3.Visible = true;
                totalTagihan.Visible = true;
                btnGoPembayaran.Visible = true;

                totalTagihan.Text = $"Total Tagihan: Rp {total:N0}";
            }
            else
            {
                labelSelamat.Visible = true;
                labelTagih.Visible = false;
                dataGridView3.Visible = false;
                totalTagihan.Visible = false;
                btnGoPembayaran.Visible = false;
            }
        }

        private void btnGoPembayaran_Click(object sender, EventArgs e)
        {
            BayarSewaLayanan bsl = new BayarSewaLayanan(current);
            if (this.MdiParent is DashboardPenghuni dp)
            {
                dp.TampilkanForm(bsl);
            }
        }

        private void btnGoProfil_Click(object sender, EventArgs e)
        {
            UserProfil pf = new UserProfil(current);
            if (this.MdiParent is DashboardPenghuni dp)
            {
                dp.TampilkanForm(pf);
            }
        }
    }
}
