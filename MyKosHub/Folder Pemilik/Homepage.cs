using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyKosHub
{
    public partial class Homepage : Form
    {
        private Pemilik current;
        dbConnect dbcon = new dbConnect();
        private LiveCharts.WinForms.PieChart pieChart;

        public Homepage(Pemilik pemilik)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.current = pemilik;
            loadData();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            label1.Text = $"Selamat datang {current.nama}";
            labelNoKeluhan.Text = "Anda belum mendapat keluhan dari penghuni!";
            labelNoMasalah.Text = "Segera laporkan masalah aplikasi yang Anda temukan!";
        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void loadData()
        {
            string namaBulan = DateTime.Now.ToString("MMMM", new System.Globalization.CultureInfo("id-ID"));
            Kos kos = dbcon.getKosByPemilik(current.id_pemilik);
            totalPendapatan.Text = Convert.ToString(getTotalPendapatan(current.id_pemilik));
            bulanSekarang.Text = $"+ {Convert.ToString(getPendapatanSatuBulan(current.id_pemilik))} ({namaBulan})";
            totalPenghuni.Text = Convert.ToString(countPenghuniAktif(current.id_pemilik, kos.id_kos));
            sumPenghuniBaru.Text = $"{Convert.ToString(countPenghuniAktifdalam1Bulan(current.id_pemilik, kos.id_kos))} Penghuni Baru";
            totalTagihan.Text = Convert.ToString(getTotalTagihan(current.id_pemilik));
            sumTelat.Text = $"{Convert.ToString(countPenghuniBelumBayar(current.id_pemilik))} Penghuni Telat bayar";
            loadDataGrid(current.id_pemilik);
            loadBarChart(current.id_pemilik);
            loadPieChart(current.id_pemilik);
            loadLineChart(current.id_pemilik);
            loadMasalahAplikasi(current.email);
        }



        private int getTotalPendapatan(string id_pemilik)
        {
            int totalPendapatan = 0;
            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();
                string querySewa = @"
                    SELECT ISNULL(SUM(p.jumlah), 0) 
                    FROM Pembayaran p
                    JOIN Tagihan t ON p.id_tagihan = t.id_tagihan
                    JOIN Sewa s ON t.id_sewa = s.id_sewa
                    JOIN Kamar k ON s.id_kamar = k.id_kamar
                    JOIN Kos ko ON k.id_kos = ko.id_kos
                    WHERE ko.id_pemilik = @id_pemilik AND p.status_pengecekan = 'terverifikasi';
                ";

                using (SqlCommand cmd = new SqlCommand(querySewa, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    totalPendapatan += (int)cmd.ExecuteScalar();
                }

                string queryLayanan = @"
                    SELECT ISNULL(SUM(p.jumlah), 0) 
                    FROM Pembayaran p
                    JOIN Pesanan_Layanan pl ON p.id_pesanan = pl.id_pesanan
                    JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                    JOIN Kos ko ON lk.id_kos = ko.id_kos
                    WHERE ko.id_pemilik = @id_pemilik AND p.status_pengecekan = 'terverifikasi';
                ";

                using (SqlCommand cmd = new SqlCommand(queryLayanan, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    totalPendapatan += (int)cmd.ExecuteScalar();
                }
            }
            return totalPendapatan;
        }

        private int getPendapatanSatuBulan(string id_pemilik)
        {
            int totalPendapatan = 0;

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();
                string querySewa = @"
                    SELECT ISNULL(SUM(p.jumlah), 0) 
                    FROM Pembayaran p
                    JOIN Tagihan t ON p.id_tagihan = t.id_tagihan
                    JOIN Sewa s ON t.id_sewa = s.id_sewa
                    JOIN Kamar k ON s.id_kamar = k.id_kamar
                    JOIN Kos ko ON k.id_kos = ko.id_kos
                    WHERE ko.id_pemilik = @id_pemilik 
                      AND p.status_pengecekan = 'terverifikasi'
                      AND p.tanggal_pembayaran >= DATEADD(MONTH, -1, GETDATE());
                ";

                using (SqlCommand cmd = new SqlCommand(querySewa, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    totalPendapatan += (int)cmd.ExecuteScalar();
                }

                string queryLayanan = @"
                    SELECT ISNULL(SUM(p.jumlah), 0) 
                    FROM Pembayaran p
                    JOIN Pesanan_Layanan pl ON p.id_pesanan = pl.id_pesanan
                    JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                    JOIN Kos ko ON lk.id_kos = ko.id_kos
                    WHERE ko.id_pemilik = @id_pemilik 
                      AND p.status_pengecekan = 'terverifikasi'
                      AND p.tanggal_pembayaran >= DATEADD(MONTH, -1, GETDATE());
                ";

                using (SqlCommand cmd = new SqlCommand(queryLayanan, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    totalPendapatan += (int)cmd.ExecuteScalar();
                }
            }

            return totalPendapatan;
        }

        private int countPenghuniAktif(string id_pemilik, string id_kos)
        {
            int totalPenghuni = 0;

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(DISTINCT s.id_penghuni)
                    FROM Kos k
                    JOIN Kamar ka ON k.id_kos = ka.id_kos
                    JOIN Sewa s ON ka.id_kamar = s.id_kamar
                    JOIN Penghuni p ON s.id_penghuni = p.id_penghuni
                    WHERE k.id_pemilik = @id_pemilik
                      AND k.id_kos = @id_kos
                      AND p.status_huni = 'aktif';
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    cmd.Parameters.AddWithValue("@id_kos", id_kos);
                    totalPenghuni = (int)cmd.ExecuteScalar();
                }
            }

            return totalPenghuni;
        }

        private int countPenghuniAktifdalam1Bulan(string id_pemilik, string id_kos)
        {
            int totalPenghuni = 0;

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(DISTINCT s.id_penghuni)
                    FROM Sewa s
                    JOIN Penghuni p ON s.id_penghuni = p.id_penghuni
                    JOIN Kamar ka ON s.id_kamar = ka.id_kamar
                    JOIN Kos k ON ka.id_kos = k.id_kos
                    WHERE p.status_huni = 'aktif'
                      AND s.tanggal_awal >= DATEADD(MONTH, -1, GETDATE())
                      AND k.id_pemilik = @id_pemilik
                      AND k.id_kos = @id_kos;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    cmd.Parameters.AddWithValue("@id_kos", id_kos);

                    totalPenghuni = (int)cmd.ExecuteScalar();
                }
            }

            return totalPenghuni;
        }

        private int getTotalTagihan(string id_pemilik)
        {
            int jumlahTagihan = 0;

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM Tagihan t
                    JOIN Sewa s ON t.id_sewa = s.id_sewa
                    JOIN Kamar k ON s.id_kamar = k.id_kamar
                    JOIN Kos ks ON k.id_kos = ks.id_kos
                    WHERE t.status_pembayaran = 0
                      AND ks.id_pemilik = @id_pemilik;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    jumlahTagihan = (int)cmd.ExecuteScalar();
                }
            }

            return jumlahTagihan;
        }

        private int countPenghuniBelumBayar(string id_pemilik)
        {
            int jumlahPenghuni = 0;

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT COUNT(DISTINCT s.id_penghuni)
                    FROM Tagihan t
                    JOIN Sewa s ON t.id_sewa = s.id_sewa
                    JOIN Kamar k ON s.id_kamar = k.id_kamar
                    JOIN Kos ks ON k.id_kos = ks.id_kos
                    WHERE t.status_pembayaran = 0
                      AND ks.id_pemilik = @id_pemilik;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    jumlahPenghuni = (int)cmd.ExecuteScalar();
                }
            }

            return jumlahPenghuni;
        }

        private void loadDataGrid(string id_pemilik)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT TOP 5 kk.isi_keluhan, kk.status_keluhan
                    FROM Keluhan_Kos kk
                    JOIN Kos k ON kk.id_kos = k.id_kos
                    JOIN Penghuni p ON kk.id_penghuni = p.id_penghuni
                    WHERE k.id_pemilik = @id_pemilik
                    ORDER BY kk.tanggal_keluhan DESC;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                labelNoKeluhan.Visible = false;
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dt;
                dataGridView1.AutoGenerateColumns = true;

                if (dataGridView1.Columns.Contains("isi_keluhan"))
                {
                    dataGridView1.Columns["isi_keluhan"].HeaderText = "Isi Keluhan";
                    dataGridView1.Columns["isi_keluhan"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.Columns["isi_keluhan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                if (dataGridView1.Columns.Contains("status_keluhan"))
                {
                    dataGridView1.Columns["status_keluhan"].HeaderText = "Status";
                }
            }
            else
            {
                dataGridView1.Visible = false;
                labelNoKeluhan.Visible = true;
            }
        }

        private void loadBarChart(string id_pemilik)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT TOP 5 nama_penghuni, SUM(total_pengeluaran) AS total_pengeluaran
                    FROM (
                        -- Pengeluaran dari Tagihan Sewa
                        SELECT p.nama AS nama_penghuni, pb.jumlah AS total_pengeluaran
                        FROM Pembayaran pb
                        JOIN Tagihan t ON pb.id_tagihan = t.id_tagihan
                        JOIN Sewa s ON t.id_sewa = s.id_sewa
                        JOIN Kamar k ON s.id_kamar = k.id_kamar
                        JOIN Kos ko ON k.id_kos = ko.id_kos
                        JOIN Penghuni p ON s.id_penghuni = p.id_penghuni
                        WHERE pb.status_pengecekan = 'terverifikasi'
                          AND pb.id_tagihan IS NOT NULL
                          AND ko.id_pemilik = @id_pemilik

                        UNION ALL

                        -- Pengeluaran dari Layanan Kamar
                        SELECT p.nama AS nama_penghuni, pb.jumlah AS total_pengeluaran
                        FROM Pembayaran pb
                        JOIN Pesanan_Layanan pl ON pb.id_pesanan = pl.id_pesanan
                        JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
                        JOIN Kos ko ON lk.id_kos = ko.id_kos
                        JOIN Penghuni p ON pl.id_penghuni = p.id_penghuni
                        WHERE pb.status_pengecekan = 'terverifikasi'
                          AND pb.id_pesanan IS NOT NULL
                          AND ko.id_pemilik = @id_pemilik
                    ) AS PengeluaranGabungan
                    GROUP BY nama_penghuni
                    ORDER BY total_pengeluaran DESC;
                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            proporsiPenghuni.Series.Clear();
            proporsiPenghuni.ChartAreas.Clear();
            proporsiPenghuni.Legends.Clear();
            proporsiPenghuni.Titles.Clear();

            ChartArea chartArea = new ChartArea("ChartArea1");
            chartArea.AxisX.Title = "Nama Penghuni";
            chartArea.AxisY.Title = "Total Pengeluaran (Rp)";
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            proporsiPenghuni.ChartAreas.Add(chartArea);

            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series("Pengeluaran")
            {
                ChartType = SeriesChartType.Bar,
                XValueMember = "nama_penghuni",
                YValueMembers = "total_pengeluaran",
                IsValueShownAsLabel = true,
                Color = Color.SteelBlue,
                Font = new Font("Segoe UI", 9f)
            };

            proporsiPenghuni.Series.Add(series);

            proporsiPenghuni.DataSource = dt;
            proporsiPenghuni.DataBind();

            proporsiPenghuni.Titles.Add("Top 5 Penghuni Berdasarkan Pengeluaran Terverifikasi");
        }

        private void loadPieChart(string id_pemilik)
        {

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();

                string query = @"
            SELECT k.status_kamar, COUNT(*) AS jumlah
            FROM Kamar k
            JOIN Kos ko ON k.id_kos = ko.id_kos
            WHERE ko.id_pemilik = @id_pemilik
            GROUP BY k.status_kamar
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            persentaseKamar.Series.Clear();
            persentaseKamar.ChartAreas.Clear();
            persentaseKamar.Legends.Clear();

            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("PieArea");
            persentaseKamar.ChartAreas.Add(chartArea);

            var legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            persentaseKamar.Legends.Add(legend);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series("StatusKamar");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series.ChartArea = "PieArea";
            series.Legend = legend.Name;
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Arial", 10, FontStyle.Bold);

            int totalJumlah = 0;
            foreach (DataRow row in dt.Rows)
            {
                totalJumlah += Convert.ToInt32(row["jumlah"]);
            }

            foreach (DataRow row in dt.Rows)
            {
                string status = row["status_kamar"].ToString();
                int jumlah = Convert.ToInt32(row["jumlah"]);

                int pointIndex = series.Points.AddY(jumlah);
                var point = series.Points[pointIndex];
                point.LegendText = status;
                double persen = (double)jumlah / totalJumlah;
                point.Label = $"{jumlah} ({persen:P1})";
            }

            persentaseKamar.Series.Add(series);

            persentaseKamar.Invalidate();
        }

        private void loadLineChart(string id_pemilik)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                {
                    conn.Open();

                    string query = @"
        SELECT 
            bulan,
            SUM(total_pendapatan) AS total_pendapatan
        FROM (
            SELECT 
                FORMAT(p.tanggal_pembayaran, 'yyyy-MM') AS bulan,
                SUM(p.jumlah) AS total_pendapatan
            FROM Pembayaran p
            JOIN Tagihan t ON p.id_tagihan = t.id_tagihan
            JOIN Sewa s ON t.id_sewa = s.id_sewa
            JOIN Kamar k ON s.id_kamar = k.id_kamar
            JOIN Kos ko ON k.id_kos = ko.id_kos
            WHERE p.status_pengecekan = 'terverifikasi'
              AND p.id_tagihan IS NOT NULL
              AND ko.id_pemilik = @id_pemilik
            GROUP BY FORMAT(p.tanggal_pembayaran, 'yyyy-MM')

            UNION ALL

            SELECT 
                FORMAT(p.tanggal_pembayaran, 'yyyy-MM') AS bulan,
                SUM(p.jumlah) AS total_pendapatan
            FROM Pembayaran p
            JOIN Pesanan_Layanan pl ON p.id_pesanan = pl.id_pesanan
            JOIN Layanan_Kamar lk ON pl.id_layanan = lk.id_layanan
            JOIN Kos ko ON lk.id_kos = ko.id_kos
            WHERE p.status_pengecekan = 'terverifikasi'
              AND p.id_pesanan IS NOT NULL
              AND ko.id_pemilik = @id_pemilik
            GROUP BY FORMAT(p.tanggal_pembayaran, 'yyyy-MM')
        ) AS GabunganPendapatan
        GROUP BY bulan
        ORDER BY bulan
    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_pemilik", id_pemilik);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                jumlahPendapatan.Series.Clear();
                jumlahPendapatan.ChartAreas.Clear();
                jumlahPendapatan.Legends.Clear();

                var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea");
                chartArea.AxisX.Title = "Bulan";
                chartArea.AxisY.Title = "Pendapatan (Rp)";
                chartArea.AxisY.LabelStyle.Format = "C0";
                jumlahPendapatan.ChartAreas.Add(chartArea);

                var legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
                legend.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
                jumlahPendapatan.Legends.Add(legend);

                var series = new System.Windows.Forms.DataVisualization.Charting.Series("Pendapatan");
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series.ChartArea = "MainArea";
                series.Legend = legend.Name;
                series.IsValueShownAsLabel = true;
                series.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                series.MarkerSize = 8;

                foreach (DataRow row in dt.Rows)
                {
                    string bulan = row["bulan"].ToString();
                    decimal pendapatan = Convert.ToDecimal(row["total_pendapatan"]);

                    int pointIndex = series.Points.AddY(pendapatan);
                    series.Points[pointIndex].AxisLabel = bulan;
                }

                jumlahPendapatan.Series.Add(series);

                jumlahPendapatan.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadMasalahAplikasi(string email)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                {
                    conn.Open();

                    string query = @"
                        SELECT TOP 5 
                            jenis_masalah, 
                            isi_masalah, 
                            status_masalah, 
                            tanggal_masalah
                        FROM Masalah_Aplikasi
                        WHERE email_pemilik = @email_pemilik
                        ORDER BY tanggal_masalah DESC;
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email_pemilik", email);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Visible = true;
                    btnGoProfil.Visible = false;
                    labelNoMasalah.Visible = false;

                    if (dataGridView2.Columns.Contains("jenis_masalah"))
                        dataGridView2.Columns["jenis_masalah"].HeaderText = "Jenis Masalah";

                    if (dataGridView2.Columns.Contains("isi_masalah"))
                    {
                        dataGridView2.Columns["isi_masalah"].HeaderText = "Isi Masalah";
                        dataGridView2.Columns["isi_masalah"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                        dataGridView2.Columns["isi_masalah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (dataGridView2.Columns.Contains("status_masalah"))
                        dataGridView2.Columns["status_masalah"].HeaderText = "Status";

                    if (dataGridView2.Columns.Contains("tanggal_masalah"))
                        dataGridView2.Columns["tanggal_masalah"].HeaderText = "Tanggal";

                    dataGridView2.Refresh();
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Visible = false;
                    btnGoProfil.Visible = true;
                    labelNoMasalah.Visible = true;
                }
            }
            catch (Exception ex)
            {
                dataGridView2.Visible = false;
                MessageBox.Show("Terjadi kesalahan saat memuat data:\n" + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoProfil_Click(object sender, EventArgs e)
        {
            UserProfil pf = new UserProfil(current);
            if (this.MdiParent is Dashboard dp)
            {
                dp.TampilkanForm(pf);
            }
        }
    }
}
