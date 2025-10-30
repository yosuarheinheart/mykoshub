using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKosHub
{
    internal class MasalahAplikasi
    {
        public string id_masalah {  get; set; }
        public string jenis_masalah { get; set; }
        public string isi_masalah { get; set; }
        public string status_masalah { get; set; }
        public DateTime tanggal_masalah { get; set; }

        public MasalahAplikasi(string id_masalah, string jenis_masalah, string isi_masalah, string status_masalah, DateTime tanggal_masalah)
        {
            this.id_masalah = id_masalah;
            this.jenis_masalah = jenis_masalah;
            this.isi_masalah = isi_masalah;
            this.status_masalah = status_masalah;
            this.tanggal_masalah = tanggal_masalah.Date;
        }
    }
}
