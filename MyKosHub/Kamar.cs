using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKosHub
{
    public class Kamar
    {
        public string id_kamar;
        public string nomor_kamar;
        public string tipe_kamar;
        public int harga;
        public string status_kamar;

        public Kamar(string id_kamar, string nomor_kamar, string tipe_kamar, int harga, string status_kamar)
        {
            this.id_kamar = id_kamar;
            this.nomor_kamar = nomor_kamar;
            this.tipe_kamar = tipe_kamar;
            this.harga = harga;
            this.status_kamar = status_kamar;
        }
    }
}
