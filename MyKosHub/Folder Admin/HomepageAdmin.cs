using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyKosHub
{
    public partial class HomepageAdmin : Form
    {
        private Admin current;
        private dbConnect dbcon = new dbConnect();

        private string idMasalahPilih;


        public HomepageAdmin(Admin admin)
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.current = admin;
        }

        private void HomepageAdmin_Load(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(dbcon.cs))
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;

                label1.Text = $"Selamat datang {current.nama}";
                optionJenis.Items.AddRange(new string[] { "semua", "teknis", "data", "pengguna", "lain-lain" });
                optionStatus.Items.AddRange(new string[] { "semua", "pending", "diproses", "terselesaikan" });

                optionJenis.SelectedIndex = 0;
                optionStatus.SelectedIndex = 0;

                optionStatus.SelectedIndexChanged += Filters_Changed;
                optionJenis.SelectedIndexChanged += Filters_Changed;

                optionGantiStatus.Visible = false;
                inputCatatan.Visible = false;
                btnKirim.Visible = false;

                loadDashboardStats();
                loadMasalah();

                this.WindowState = FormWindowState.Maximized;
                LoadChartData();
            }
        }

        private void Filters_Changed(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void LoadChartData()
        {
            using (var conn = new SqlConnection(dbcon.cs))
            {
                conn.Open();

                string sqlPemilik = @"
                    SELECT FORMAT(tanggal_daftar, 'MMMM yyyy') AS Bulan, COUNT(*) AS Jumlah
                    FROM Pemilik
                    GROUP BY FORMAT(tanggal_daftar, 'MMMM yyyy')
                    ORDER BY MIN(tanggal_daftar)";
                using (var cmd = new SqlCommand(sqlPemilik, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var series = chartPemilik.Series[0];
                    series.Points.Clear();
                    series.IsValueShownAsLabel = true;
                    chartPemilik.Legends[0].Title = "Pemilik per Bulan";

                    while (reader.Read())
                    {
                        string bulan = reader["Bulan"].ToString();
                        int jumlah = (int)reader["Jumlah"];
                        var pointIndex = series.Points.AddXY(bulan, jumlah);
                        series.Points[pointIndex].Label = jumlah.ToString();
                        series.Points[pointIndex].LegendText = bulan;
                    }
                }

                string sqlPenghuni = @"
                    SELECT FORMAT(tanggal_daftar, 'MMMM yyyy') AS Bulan, COUNT(*) AS Jumlah
                    FROM Penghuni
                    GROUP BY FORMAT(tanggal_daftar, 'MMMM yyyy')
                    ORDER BY MIN(tanggal_daftar)";
                using (var cmd = new SqlCommand(sqlPenghuni, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var series = chartPenghuni.Series[0];
                    series.Points.Clear();
                    series.IsValueShownAsLabel = true;
                    chartPenghuni.Legends[0].Title = "Penghuni per Bulan";

                    while (reader.Read())
                    {
                        string bulan = reader["Bulan"].ToString();
                        int jumlah = (int)reader["Jumlah"];
                        var pointIndex = series.Points.AddXY(bulan, jumlah);
                        series.Points[pointIndex].Label = jumlah.ToString();
                        series.Points[pointIndex].LegendText = bulan;
                    }
                }

                string sqlMasalah = @"
                    SELECT FORMAT(tanggal_masalah, 'MMMM yyyy') AS Bulan, COUNT(*) AS Jumlah
                    FROM Masalah_Aplikasi
                    GROUP BY FORMAT(tanggal_masalah, 'MMMM yyyy')
                    ORDER BY MIN(tanggal_masalah)";
                using (var cmd = new SqlCommand(sqlMasalah, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    var series = chartMasalah.Series[0];
                    series.Points.Clear();
                    series.IsValueShownAsLabel = true;
                    chartMasalah.Legends[0].Title = "Masalah Aplikasi per Bulan";

                    while (reader.Read())
                    {
                        string bulan = reader["Bulan"].ToString();
                        int jumlah = (int)reader["Jumlah"];
                        var pointIndex = series.Points.AddXY(bulan, jumlah);
                        series.Points[pointIndex].Label = jumlah.ToString();
                        series.Points[pointIndex].LegendText = bulan;
                    }
                }

                conn.Close();
            }
        }
    


        private void loadDashboardStats()
        {
            DateTime today = DateTime.Today;
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);

            using (var conn = new SqlConnection(dbcon.cs))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();

                cmd.CommandText = "SELECT COUNT(*) FROM Pemilik";
                totalPemilik.Text = cmd.ExecuteScalar().ToString() + " pemilik";

                cmd.CommandText = @"SELECT COUNT(*) 
                                    FROM Pemilik 
                                    WHERE tanggal_daftar >= @startOfMonth";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@startOfMonth", firstOfMonth);
                pemilikBaru.Text = cmd.ExecuteScalar().ToString() + " pemilik baru";

                cmd.CommandText = "SELECT COUNT(*) FROM Penghuni";
                cmd.Parameters.Clear();
                totalPenghuni.Text = cmd.ExecuteScalar().ToString() + " penghuni";

                cmd.CommandText = @"SELECT COUNT(*) 
                                    FROM Penghuni 
                                    WHERE tanggal_daftar >= @startOfMonth";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@startOfMonth", firstOfMonth);
                penghuniBaru.Text = cmd.ExecuteScalar().ToString() + " penghuni baru";

                cmd.CommandText = "SELECT COUNT(*) FROM Masalah_Aplikasi";
                cmd.Parameters.Clear();
                totalMasalah.Text = cmd.ExecuteScalar().ToString() + " masalah";

                cmd.CommandText = @"SELECT COUNT(*) 
                                    FROM Masalah_Aplikasi
                                    WHERE tanggal_masalah >= @startOfMonth";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@startOfMonth", firstOfMonth);
                masalahBaru.Text = cmd.ExecuteScalar().ToString() + " masalah baru";
            }
        }


     
        private void loadMasalah()
        {
            ApplyFilters();

            optionJenis.Visible = true;
            optionStatus.Visible = true;
            optionGantiStatus.Visible = true;
            inputCatatan.Visible = true;
            btnKirim.Visible = true;
        }

        private void ApplyFilters()
        {
            string sql = @"
                            SELECT id_masalah, jenis_masalah, isi_masalah, status_masalah, catatan, tanggal_masalah
                            FROM Masalah_Aplikasi
                            WHERE (id_admin = @id OR id_admin IS NULL)
                         ";

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", current.id_admin));

            string status = optionStatus.SelectedItem.ToString();
            if (status != "semua")
            {
                sql += " AND status_masalah = @status ";
                parameters.Add(new SqlParameter("@status", status));
            }

            string jenis = optionJenis.SelectedItem.ToString();
            if (jenis != "semua")
            {
                sql += " AND jenis_masalah = @jenis ";
                parameters.Add(new SqlParameter("@jenis", jenis));
            }

            sql += " ORDER BY tanggal_masalah DESC";

            var dt = new DataTable();
            using (var conn = new SqlConnection(dbcon.cs))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                da.Fill(dt);
            }

            dataGridView1.DataSource = dt;
        }


        private void btnKirim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idMasalahPilih))
            {
                MessageBox.Show("Silakan pilih masalah dari tabel.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusBaru = optionGantiStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(statusBaru))
            {
                MessageBox.Show("Silakan pilih status baru untuk masalah.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string catatan = inputCatatan.Text?.Trim();
            string sql = @"
                          UPDATE Masalah_Aplikasi
                          SET status_masalah = @status, 
                              catatan        = @catatan, 
                              id_admin       = @me
                          WHERE id_masalah = @mid
                        ";

            using (var conn = new SqlConnection(dbcon.cs))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@status", statusBaru);
                cmd.Parameters.AddWithValue("@catatan", (object)catatan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@me", current.id_admin);
                cmd.Parameters.AddWithValue("@mid", idMasalahPilih);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Status masalah berhasil diperbarui.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadMasalah();
            idMasalahPilih = null;
            optionGantiStatus.SelectedIndex = -1;
            inputCatatan.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            idMasalahPilih = row.Cells["id_masalah"].Value?.ToString();
            string status = row.Cells["status_masalah"].Value?.ToString();
            optionGantiStatus.SelectedItem = status;

            optionGantiStatus.Items.Clear();
            switch (status)
            {
                case "pending":
                    optionGantiStatus.Items.AddRange(new[] { "diproses", "terselesaikan" });
                    inputCatatan.ReadOnly = false;
                    break;
                case "diproses":
                    optionGantiStatus.Items.Add("terselesaikan");
                    inputCatatan.ReadOnly = false;
                    break;
                case "terselesaikan":
                    optionGantiStatus.Items.Clear();
                    inputCatatan.ReadOnly = true;
                    break;
            }

            optionGantiStatus.SelectedItem = status;
            inputCatatan.Text = row.Cells["catatan"].Value?.ToString();

            optionGantiStatus.Visible = true;
            inputCatatan.Visible = true;
            btnKirim.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            optionJenis.SelectedIndex = 0;
            optionStatus.SelectedIndex = 0;
            loadMasalah();
        }

        
    }
}
