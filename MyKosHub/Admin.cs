using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyKosHub
{
    public class Admin : Akun
    {
        private dbConnect dbcon = new dbConnect();

        public string id_admin { get; set; }

        public Admin(string id_admin, string email, string nama, string password) : base(nama, email, null, password) 
        {
            this.id_admin = id_admin;
        }

        public bool login(string email, string password)
        {
            Admin user = dbcon.getAdmin(email);

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

        public void tanggapMasalah(string idMasalah, string status, string catatan)
        {
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
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@catatan", (object)catatan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@me", id_admin);
                cmd.Parameters.AddWithValue("@mid", idMasalah);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
