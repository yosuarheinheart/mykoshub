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
    public partial class LaporanKeluhanViewer : Form
    {
        dbConnect dbcon = new dbConnect();
        Pemilik current;
        string bulan;
        string tahun;
        string status;

        public LaporanKeluhanViewer(Pemilik pemilik, string bulan, string tahun, string status)
        {
            InitializeComponent();
            current = pemilik;
            this.bulan = bulan;
            this.tahun = tahun;
            this.status = status;
        }

        private void LaporanKeluhanViewer_Load(object sender, EventArgs e)
        {
            Kos kos = dbcon.getKosByPemilik(current.id_pemilik);
            string sql = @"
                         SELECT * FROM vw_LaporanKeluhan 
                         WHERE id_kos = @idKos AND bulan = @bulan AND tahun = @tahun
                         ";

            if (status == "pending")
                sql += "  AND status_keluhan = 'pending'";
            else if (status == "diproses")
                sql += "  AND status_keluhan = 'diproses'";
            else if (status == "terselesaikan")
                sql += "  AND status_keluhan = 'terselesaikan'";

            sql += " ORDER BY tanggal_keluhan DESC";

            DataTable dt = new DataTable();
            using (var conn = new SqlConnection(dbcon.cs))
            using (var da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@idKos", kos.id_kos);
                da.SelectCommand.Parameters.AddWithValue("@bulan", bulan);
                da.SelectCommand.Parameters.AddWithValue("@tahun", tahun);
                da.Fill(dt);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada keluhan untuk kos ini.", "Info",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rpt = new LaporanKeluhan();
            rpt.SetDataSource(dt);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
