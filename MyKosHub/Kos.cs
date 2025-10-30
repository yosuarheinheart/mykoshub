using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKosHub
{
    public class Kos
    {
        public string id_kos { get; set; }
        public string nama { get; set; }
        public string alamat { get; set; }

        public Kos(string id_kos, string nama, string alamat)
        {
            this.id_kos = id_kos;
            this.nama = nama;
            this.alamat = alamat;
        }
    }
}
