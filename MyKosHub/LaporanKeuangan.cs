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

    public partial class LaporanKeuangan : Form
    {
        private string modeLaporan = "";
        private Pemilik currentPemilik;
        dbConnect dbcon = new dbConnect();

        public LaporanKeuangan(Pemilik pemilik)
        {
            InitializeComponent();
            this.AutoScroll = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.currentPemilik = pemilik;

            buttonSeluruh.Click += (s, e) => LoadData(category: null);
            buttonSewa.Click += (s, e) => LoadData(category: "sewa");
            buttonLayanan.Click += (s, e) => LoadData(category: "layanan");
            buttonReset.Click += (s, e) => ResetFilters();



        }

        private void LaporanKeuangan_Load(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void ResetFilters()
        {
            DateTime today = DateTime.Today;
            DateTime firstDay = new DateTime(today.Year, today.Month, 1);
            DateTime lastDay = new DateTime(
                today.Year,
                today.Month,
                DateTime.DaysInMonth(today.Year, today.Month)
            );

            filterAwal.Value = firstDay;
            filterAkhir.Value = lastDay;

            dataGridView1.DataSource = null;
            LoadData(category: null);
        }

        private void LoadData(string category)
        {
            DateTime from = filterAwal.Value.Date;
            DateTime to = filterAkhir.Value.Date.AddDays(1).AddTicks(-1);

            string sql = @"
                            SELECT
                              pb.jumlah,
                              pb.tanggal_pembayaran,
                              pb.bukti,
                              CASE
                                WHEN pb.id_pesanan IS NOT NULL THEN 'layanan'
                                ELSE 'sewa'
                              END AS kategori
                            FROM Pembayaran pb
                            LEFT JOIN Tagihan t ON pb.id_tagihan = t.id_tagihan
                            LEFT JOIN Sewa sw   ON t.id_sewa     = sw.id_sewa
                            LEFT JOIN Kamar km  ON sw.id_kamar    = km.id_kamar
                            LEFT JOIN Kos ks1   ON km.id_kos      = ks1.id_kos
                            LEFT JOIN Pesanan_Layanan pl ON pb.id_pesanan = pl.id_pesanan
                            LEFT JOIN Layanan_Kamar lk   ON pl.id_layanan = lk.id_layanan
                            LEFT JOIN Kos ks2            ON lk.id_kos     = ks2.id_kos
                            WHERE pb.status_pengecekan = 'terverifikasi'
                              AND (ks1.id_pemilik = @idPemilik
                                   OR ks2.id_pemilik = @idPemilik)
                              AND pb.tanggal_pembayaran BETWEEN @from AND @to
                            ";

            if (category == "layanan")
                sql += "  AND pb.id_pesanan IS NOT NULL";

            if (category == "sewa")
                sql += "  AND pb.id_pesanan IS NULL";

            Bind(sql,
                new SqlParameter("@from", from),
                new SqlParameter("@to", to),
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

        private void LoadTahun()
        {
            opsiTahun.Items.Clear();
            using (SqlConnection conn = new SqlConnection(dbcon.cs))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT DISTINCT YEAR(tanggal_pembayaran) AS tahun 
              FROM (
                SELECT tanggal_pembayaran FROM vw_LaporanSewa
                UNION
                SELECT tanggal_pembayaran FROM vw_LaporanLayanan
              ) AS gabungan
              ORDER BY tahun DESC", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    opsiTahun.Items.Add(reader.GetInt32(0).ToString());
                }
            }
        }

        private void LoadKuartal()
        {
            opsiKuartal.Items.Clear();
            opsiKuartal.Items.AddRange(new string[] { "Q1", "Q2", "Q3", "Q4" });
        }

        private void LoadBulan()
        {
            opsiBulan.Items.Clear();
            opsiBulan.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                .Where(m => !string.IsNullOrEmpty(m))
                .Select(m => System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m))
                .ToArray());
        }
        private void btnShowLaporanKuartal_Click(object sender, EventArgs e)
        {
            if (grupPeriode.Visible && modeLaporan == "kuartal")
            {
                grupPeriode.Visible = false;
                modeLaporan = "";
                return;
            }
            modeLaporan = "kuartal";
            grupPeriode.Visible = true;
            opsiTahun.Visible = true;
            labelTahun.Visible = true;
            opsiKuartal.Visible = true;
            labelBulan.Visible = false;
            labelKuartal.Visible = true;
            labelKuartal.BringToFront();
            opsiBulan.Visible = false;
            LoadTahun();
            LoadKuartal();
        }

        private void btnShowLaporanBulan_Click(object sender, EventArgs e)
        {
            if (grupPeriode.Visible && modeLaporan == "bulan")
            {
                grupPeriode.Visible = false;
                modeLaporan = "";
                return;
            }
            modeLaporan = "bulan";
            grupPeriode.Visible = true;
            opsiTahun.Visible = true;
            labelTahun.Visible = true;
            opsiBulan.Visible = true;
            labelBulan.Visible = true;
            labelKuartal.Visible=false;
            opsiKuartal.Visible = false;

            LoadTahun();
            LoadBulan();
        }
        

        private void btnPrintLaporan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(opsiTahun.Text)) return;

            int tahun = int.Parse(opsiTahun.Text);
            int bulanAwal = 1, bulanAkhir = 12;

            if (modeLaporan == "kuartal" && !string.IsNullOrEmpty(opsiKuartal.Text))
            {
                switch (opsiKuartal.Text)
                {
                    case "Q1": bulanAwal = 1; bulanAkhir = 3; break;
                    case "Q2": bulanAwal = 4; bulanAkhir = 6; break;
                    case "Q3": bulanAwal = 7; bulanAkhir = 9; break;
                    case "Q4": bulanAwal = 10; bulanAkhir = 12; break;
                }
            }
            else if (modeLaporan == "bulan" && !string.IsNullOrEmpty(opsiBulan.Text))
            {
                bulanAwal = bulanAkhir = DateTime.ParseExact(opsiBulan.Text, "MMMM", null).Month;
            }

            DateTime startDate = new DateTime(tahun, bulanAwal, 1);
            DateTime endDate = new DateTime(tahun, bulanAkhir, DateTime.DaysInMonth(tahun, bulanAkhir));

            LaporanViewer frm = new LaporanViewer(currentPemilik, startDate, endDate);
            frm.ShowDialog();
            grupPeriode.Visible = false;
        }
    }
}