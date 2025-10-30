using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKosHub
{
    public class Pemilik : Akun
    {
        private dbConnect dbcon = new dbConnect();

        public string id_pemilik { get; set; }

        public Pemilik(string id_pemilik, string nama, string email, string nomor_telepon, string password) : base(nama, email, nomor_telepon, password) 
        {
            this.id_pemilik = id_pemilik;
        }

        public bool signUp(string namaPemilik, string email, string nomor_telepon, string password)
        {
            Pemilik existingUser = dbcon.getUserPemilik(email);

            if (existingUser != null)
            {
                return false;
            }

            return true;
        }

        public bool login(string email, string password)
        {
            Pemilik user = dbcon.getUserPemilik(email);

            if (user != null && VerifyPassword(password, user.password))
            {
                this.id_pemilik = user.id_pemilik;
                this.nama = user.nama;
                this.email = user.email;
                this.nomor_telepon = user.nomor_telepon;
                this.password = user.password;
                return true;
            }
            return false;
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            string hashedInputPassword = dbcon.HashPassword(inputPassword);
            return hashedInputPassword == storedPassword;
        }

        public bool hasKos(string email)
        {
            Pemilik user = dbcon.getUserPemilik(email);
            bool haskos = dbcon.checkKosForPemilik(user.id_pemilik);
            return haskos;
        }

        public bool addKosToPemilik(string id_pemilik, string email, Kos kos)
        {
            if (hasKos(email))
            {
                MessageBox.Show("Pemilik sudah memiliki kos.");
                return false;
            }

            try
            {
                dbcon.addKos(id_pemilik, kos);
                MessageBox.Show("Kos berhasil ditambahkan.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
                return false;
            }
        }


    }
}