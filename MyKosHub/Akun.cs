using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKosHub
{
    public class Akun
    {
        public string nama { get; set; }
        public string email { get; set; }
        public string nomor_telepon { get; set; }
        public string password { get; set; }

        public Akun(string nama, string email, string nomor_telepon, string password)
        {
            this.nama = nama;
            this.email = email;
            this.nomor_telepon = nomor_telepon;
            this.password = password;
        }
    }
}
