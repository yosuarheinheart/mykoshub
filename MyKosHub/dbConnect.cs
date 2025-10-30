using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace MyKosHub
{
    internal class dbConnect
    {

        public readonly string cs = "Data Source = ASUSY\\SQLEXPRESS;" +
            "Initial Catalog = mykoshub;" +
            "Integrated Security = true;" +
            "TrustServerCertificate = true";

        public string generateId()
        {
            string newId = "PM0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 Id_Pemilik FROM Pemilik ORDER BY Id_Pemilik DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(2));
                    num++;
                    newId = "PM" + num.ToString("D4");
                }
            }
            return newId;

        }
        public void addPemilik(Pemilik pemilik)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string hashedPassword = HashPassword(pemilik.password);

                string query = "INSERT INTO pemilik (id_pemilik, nama, email, nomor_telepon, password) " +
                    "VALUES (@id, @nama, @email, @notelp, @password)";

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@id", generateId());
                sqlCommand.Parameters.AddWithValue("@nama", pemilik.nama);
                sqlCommand.Parameters.AddWithValue("@email", pemilik.email);
                sqlCommand.Parameters.AddWithValue("@notelp", pemilik.nomor_telepon);
                sqlCommand.Parameters.AddWithValue("@password", hashedPassword);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void addPenghuni(Penghuni penghuni)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string hashedPassword = HashPassword(penghuni.password);

                string query = "INSERT INTO penghuni (id_penghuni, nama, email, nomor_telepon, password) " +
                    "VALUES (@id, @nama, @email, @notelp, @password)";

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@id", generateIdPenghuni());
                sqlCommand.Parameters.AddWithValue("@nama", penghuni.nama);
                sqlCommand.Parameters.AddWithValue("@email", penghuni.email);
                sqlCommand.Parameters.AddWithValue("@notelp", penghuni.nomor_telepon);
                sqlCommand.Parameters.AddWithValue("@password", hashedPassword);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Pemilik getUserPemilik(string email)
        {
            Pemilik pemilik = null;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = @"SELECT 'pemilik' AS role, id_pemilik, nama, email, nomor_telepon, password FROM pemilik WHERE email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    pemilik = new Pemilik(
                        reader["id_pemilik"].ToString(),
                        reader["nama"].ToString(),
                        reader["email"].ToString(),
                        reader["nomor_telepon"].ToString(),
                        reader["password"].ToString()
                    );
                }
            }
            return pemilik;
        }

        public Penghuni getUserPenghuni(string email)
        {
            Penghuni penghuni = null;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = @"SELECT 'penghuni' AS role, id_penghuni, nama, email, nomor_telepon, password FROM penghuni WHERE email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    penghuni = new Penghuni(
                        reader["id_penghuni"].ToString(),
                        reader["nama"].ToString(),
                        reader["email"].ToString(),
                        reader["nomor_telepon"].ToString(),
                        reader["password"].ToString()
                    );
                }
            }
            return penghuni;
        }

        public Admin getAdmin(string email)
        {
            Admin admin = null;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = @"SELECT id_admin, email, nama, password FROM Admin WHERE email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    admin = new Admin(
                        reader["id_admin"].ToString(),
                        reader["email"].ToString(),
                        reader["nama"].ToString(),
                        reader["password"].ToString()
                    );
                }
            }
            return admin;
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public bool checkEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = @"
                    SELECT COUNT(*) FROM (
                        SELECT email FROM pemilik WHERE email = @Email
                        UNION ALL
                        SELECT email FROM penghuni WHERE email = @Email
                    ) AS combined";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public bool checkKosForPemilik(string idpemilik)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = @"
                                SELECT 
                                    CASE 
                                        WHEN EXISTS (
                                            SELECT 1 FROM Kos WHERE id_pemilik = @idpemilik
                                        ) 
                                        THEN 1 
                                        ELSE 0 
                                    END";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idpemilik", idpemilik);

                    connection.Open();
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();

                    return result == 1;
                }
            }
        }

        public void addKos(string idPemilik, Kos kos)
        {
            bool hasKos = checkKosForPemilik(idPemilik);
            if (hasKos)
            {
                throw new InvalidOperationException("Pemilik sudah memiliki kos.");
            }

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "INSERT INTO Kos (id_kos, id_pemilik, nama, alamat) " +
                               "VALUES (@idkos, @idPemilik, @namaKos, @alamat)";

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@idkos", kos.id_kos);
                sqlCommand.Parameters.AddWithValue("@idPemilik", idPemilik);
                sqlCommand.Parameters.AddWithValue("@namaKos", kos.nama);
                sqlCommand.Parameters.AddWithValue("@alamat", kos.alamat);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public string generateIdKos()
        {
            string newId = "KS0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 Id_Kos FROM Kos ORDER BY Id_Kos DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(2));
                    num++;
                    newId = "KS" + num.ToString("D4");
                }
            }
            return newId;

        }

        public string generateIdKamar()
        {
            string newId = "KM0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 Id_Kamar FROM Kamar ORDER BY Id_Kamar DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(2));
                    num++;
                    newId = "KM" + num.ToString("D4");
                }
            }
            return newId;
        }

        public void addKamar(string id_kos, Kamar kamar)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "INSERT INTO Kamar (id_kamar, id_kos, nomor_kamar, tipe_kamar, harga) " +
                               "VALUES (@idkamar, @idkos, @nokamar, @tipekamar, @harga)";

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@idkamar", kamar.id_kamar);
                sqlCommand.Parameters.AddWithValue("@idkos", id_kos);
                sqlCommand.Parameters.AddWithValue("@nokamar", kamar.nomor_kamar);
                sqlCommand.Parameters.AddWithValue("@tipekamar", kamar.tipe_kamar);
                sqlCommand.Parameters.AddWithValue("@harga", kamar.harga);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Kos getKosByPemilik(string idPemilik)
        {
            Kos kos = null;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT TOP 1 * FROM Kos WHERE id_pemilik = @idPemilik";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPemilik", idPemilik);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    kos = new Kos(
                        reader["id_kos"].ToString(),
                        reader["nama"].ToString(),
                        reader["alamat"].ToString()
                    );
                }
            }
            return kos;
        }

        public Kos getKosByPenghuni(string idPenghuni)
        {
            Kos kos = null;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = @"SELECT TOP 1 k.id_kos, k.nama, k.alamat
                             FROM Sewa s
                             JOIN Kamar km ON s.id_kamar = km.id_kamar
                             JOIN Kos k ON km.id_kos = k.id_kos
                             WHERE s.id_penghuni = @idPenghuni";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPenghuni", idPenghuni);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    kos = new Kos(
                        reader["id_kos"].ToString(),
                        reader["nama"].ToString(),
                        reader["alamat"].ToString()
                    );
                }
            }
            return kos;
        }


        public DataTable getAllKamar(string idKos)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT id_kamar, id_kos, nomor_kamar, tipe_kamar, harga, status_kamar, kode_unik FROM Kamar WHERE id_kos = @idKos";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idKos", idKos);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        public void updateKamar(string id_kamar, string nomor_kamar, string tipe_kamar, int harga, string status_kamar)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"UPDATE Kamar SET 
                            nomor_kamar = @nomor, 
                            tipe_kamar = @tipe, 
                            harga = @harga, 
                            status_kamar = @status 
                         WHERE id_kamar = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", nomor_kamar);
                cmd.Parameters.AddWithValue("@tipe", tipe_kamar);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@status", status_kamar);
                cmd.Parameters.AddWithValue("@id", id_kamar);

                cmd.ExecuteNonQuery();
            }
        }

        public string GetConnectionString()
        {
            return cs;
        }

        public bool IsKamarDihuni(string idKamar)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT 1 FROM Kamar WHERE id_kamar = @id AND status_kamar = 'dihuni'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idKamar);

                conn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        public string generateIdLayanan()
        {
            string newId = "LN0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 Id_Layanan FROM Layanan_Kamar ORDER BY Id_Layanan DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(2));
                    num++;
                    newId = "LN" + num.ToString("D4");
                }
            }
            return newId;
        }

        public void addLayananKeKos (string id_kos, string nama, int biaya, string deskripsi)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "INSERT INTO Layanan_Kamar (id_layanan, id_kos, nama, biaya, deskripsi) " +
                               "VALUES (@idlayanan, @idkos, @nama, @biaya, @deskripsi)";

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@idlayanan", generateIdLayanan());
                sqlCommand.Parameters.AddWithValue("@idkos", id_kos);
                sqlCommand.Parameters.AddWithValue("@nama", nama);
                sqlCommand.Parameters.AddWithValue("@biaya", biaya);
                sqlCommand.Parameters.AddWithValue("@deskripsi", deskripsi);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public DataTable getAllLayanan(string idKos)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "SELECT id_layanan, id_kos, nama, biaya, deskripsi FROM Layanan_Kamar WHERE id_kos = @idKos";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idKos", idKos);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            return dt;
        }

        public void updateLayanan(string id_layanan, string nama, int biaya, string deskripsi)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"UPDATE Layanan_Kamar SET 
                            nama = @nama, 
                            biaya = @biaya, 
                            deskripsi = @deskripsi
                         WHERE id_layanan = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@biaya", biaya);
                cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                cmd.Parameters.AddWithValue("@id", id_layanan);

                cmd.ExecuteNonQuery();
            }
        }

        public string generateIdPenghuni()
        {
            string newId = "PN0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 Id_Penghuni FROM Penghuni ORDER BY Id_Penghuni DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(2));
                    num++;
                    newId = "PN" + num.ToString("D4");
                }
            }
            return newId;

        }

        public string generateIdSewa()
        {
            string newId = "S00001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 Id_Sewa FROM Sewa ORDER BY Id_Sewa DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(1));
                    num++;
                    newId = "S" + num.ToString("D5");
                }
            }
            return newId;

        }

        public string generateIdPesananLayanan()
        {
            string newId = "PL0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 id_pesanan FROM Pesanan_Layanan ORDER BY id_pesanan DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(2));
                    num++;
                    newId = "PL" + num.ToString("D4");
                }
            }
            return newId;
        }

        public string generateIdTagihan()
        {
            string newId = "TO0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

 
                string query = "SELECT MAX(CAST(SUBSTRING(id_tagihan, 3, LEN(id_tagihan)) AS INT)) FROM Tagihan WHERE id_tagihan LIKE 'TO%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    int num = Convert.ToInt32(result) + 1;
                    newId = "TO" + num.ToString("D4");
                }
            }
            return newId;
        }

        public string getLastInsertedSewaIdByPenghuni(string idPenghuni)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT TOP 1 id_sewa FROM Sewa WHERE id_penghuni = @id_penghuni ORDER BY tanggal_awal DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_penghuni", idPenghuni);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        public string getStatusHuni(string idPenghuni)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "SELECT status_huni FROM Penghuni WHERE id_penghuni = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idPenghuni);
                    object result = cmd.ExecuteScalar();
                    return result != null ? result.ToString() : "nonaktif";
                }
            }
        }

        public string generateIdKeluhan()
        {
            string newId = "KL0001";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = "SELECT TOP 1 id_keluhan FROM Keluhan_Kos ORDER BY id_keluhan DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int num = int.Parse(lastId.Substring(2));
                    num++;
                    newId = "KL" + num.ToString("D4");
                }
            }
            return newId;

        }

        public string getIdKosByPenghuni(string idPenghuni)
        {
            string idKos = null;

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string query = @"
                    SELECT TOP 1 k.id_kos
                    FROM Sewa s
                    JOIN Kamar k ON s.id_kamar = k.id_kamar
                    WHERE s.id_penghuni = @idPenghuni AND s.tanggal_akhir IS NULL
                    ORDER BY s.tanggal_awal DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idPenghuni", idPenghuni);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            idKos = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Gagal mengambil ID Kos: " + ex.Message, "Error");
                    }
                }
            }

            return idKos;
        }

    }
}