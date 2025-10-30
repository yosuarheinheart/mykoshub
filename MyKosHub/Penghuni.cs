using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKosHub
{
    public class Penghuni : Akun
    {
        private dbConnect dbcon = new dbConnect();

        public string id_penghuni { get; set; }

        public Penghuni(string id_penghuni, string nama, string email, string nomor_telepon, string password) : base(nama, email, nomor_telepon, password) 
        {
            this.id_penghuni = id_penghuni;
        }

        public bool signUp(string namaPenghuni, string email, string nomor_telepon, string password)
        {
            Penghuni existingUser = dbcon.getUserPenghuni(email);

            if (existingUser != null)
            {
                return false;
            }

            return true;
        }

        public bool login(string email, string password)
        {
            Penghuni user = dbcon.getUserPenghuni(email);

            if (user != null && VerifyPassword(password, user.password))
            {
                return true;
            }

            return false;
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            string hashedInputPassword = dbcon.HashPassword(inputPassword);
            return hashedInputPassword == storedPassword;
        }

    }
}
