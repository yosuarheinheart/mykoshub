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
    public partial class LaporanViewer : Form
    {
        dbConnect dbcon = new dbConnect();
        private Pemilik currentPemilik;
        private DateTime? periodeAwal, periodeAkhir;

        public LaporanViewer(Pemilik pemilik, DateTime? awal = null, DateTime? akhir = null)
        {
            InitializeComponent();
            this.currentPemilik = pemilik;
            this.periodeAwal = awal;
            this.periodeAkhir = akhir;
            this.Load += LaporanViewer_Load;
        }

        private void LaporanViewer_Load(object sender, EventArgs e)
        {
            Kos kos = dbcon.getKosByPemilik(currentPemilik.id_pemilik);

            var rpt = new LaporanKeuanganKos(); 
            var ds = new DataSet();

            string filterTanggal = "";
            if (periodeAwal.HasValue && periodeAkhir.HasValue)
            {
                filterTanggal = " AND tanggal_pembayaran BETWEEN @start AND @end ";
            }

            using (var conn = new SqlConnection(dbcon.cs))
            using (var da = new SqlDataAdapter("SELECT * FROM vw_LaporanSewa WHERE id_kos=@id" + filterTanggal, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@id", kos.id_kos);
                if (periodeAwal.HasValue && periodeAkhir.HasValue)
                {
                    da.SelectCommand.Parameters.AddWithValue("@start", periodeAwal.Value);
                    da.SelectCommand.Parameters.AddWithValue("@end", periodeAkhir.Value);
                }
                da.Fill(ds, "vw_LaporanSewa");
            }

            using (var conn = new SqlConnection(dbcon.cs))
            using (var da = new SqlDataAdapter("SELECT * FROM vw_LaporanLayanan WHERE id_kos=@id" + filterTanggal, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@id", kos.id_kos);
                if (periodeAwal.HasValue && periodeAkhir.HasValue)
                {
                    da.SelectCommand.Parameters.AddWithValue("@start", periodeAwal.Value);
                    da.SelectCommand.Parameters.AddWithValue("@end", periodeAkhir.Value);
                }
                da.Fill(ds, "vw_LaporanLayanan");
            }

            rpt.Subreports["Subreport_Sewa"].SetDataSource(ds.Tables["vw_LaporanSewa"]);
            rpt.Subreports["Subreport_Layanan"].SetDataSource(ds.Tables["vw_LaporanLayanan"]);

            rpt.SetParameterValue("p_NamaKos", kos.nama);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.RefreshReport();
        }

    }
}
