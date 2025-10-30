using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyKosHub
{
    public partial class UserProfil : Form
    {

        dbConnect dbcon = new dbConnect();

        private Pemilik pemilikUser;
        private Penghuni penghuniUser;

        public UserProfil()
        {
            InitializeComponent();
        }

        public UserProfil(Pemilik pemilik)
        {
            InitializeComponent();
            grupLapor.Visible = false;
            editNama.Visible = false;
            editNomor.Visible = false;
            submitProfil.Visible = false;
            grupInvitasi.Visible = false;
            grupKeluhan.Visible = false;
            pemilikUser = pemilik;
            tampilkanDataPemilik();
            btnLaporKeluhan.Visible = false;
        }

        public UserProfil(Penghuni penghuni)
        {
            InitializeComponent();
            grupLapor.Visible = false;
            grupKeluhan.Visible = false;
            editNama.Visible = false;
            editNomor.Visible = false;
            submitProfil.Visible = false;
            penghuniUser = penghuni;
            tampilkanDataPenghuni();
            isPenghuniAktif();
        }

        private void tampilkanDataPemilik()
        {
            namaPengguna.Text = pemilikUser.nama;
            emailPengguna.Text = pemilikUser.email;
            nomorPengguna.Text = pemilikUser.nomor_telepon;
        }

        private void tampilkanDataPenghuni()
        {
            namaPengguna.Text = penghuniUser.nama;
            emailPengguna.Text = penghuniUser.email;
            nomorPengguna.Text = penghuniUser.nomor_telepon;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            grupLapor.Visible = !grupLapor.Visible;
            string[] pilihan = { "teknis", "data", "pengguna", "lain-lain" };

            foreach (string item in pilihan)
            {
                if (!optionMasalah.Items.Contains(item))
                {
                    optionMasalah.Items.Add(item);
                }
            }
        }

        private string GenerateIdMasalah()
        {
            string newId = "MS0001";
            using (var conn = new SqlConnection(dbcon.cs))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT TOP 1 id_masalah FROM Masalah_Aplikasi ORDER BY id_masalah DESC", conn))
                {
                    var r = cmd.ExecuteScalar();
                    if (r != null)
                    {
                        int num = int.Parse(r.ToString().Substring(2)) + 1;
                        newId = "MS" + num.ToString("D4");
                    }
                }
            }
            return newId;
        }

        private void buttonSubmitMasalah_Click(object sender, EventArgs e)
        {
            if (optionMasalah.SelectedIndex < 0)
            {
                MessageBox.Show("Pilih jenis masalah terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string jenis = optionMasalah.SelectedItem.ToString();
            string isi = descMasalah.Text.Trim();
            if (string.IsNullOrWhiteSpace(isi))
            {
                MessageBox.Show("Deskripsi masalah tidak boleh kosong.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email;
            string sql;
            string idMasalah = GenerateIdMasalah();
            DateTime tgl = DateTime.Today;

            MasalahAplikasi ma = new MasalahAplikasi(idMasalah, jenis, isi, "pending", tgl);

            if (penghuniUser != null)
            {
                email = penghuniUser.email;
                sql = @"
                        INSERT INTO Masalah_Aplikasi
                            (id_masalah, email_penghuni, id_admin, jenis_masalah, isi_masalah, tanggal_masalah)
                        VALUES
                            (@id, @email, NULL, @jenis, @isi, @tgl);
                       ";

            } 
            else
            {
                email = pemilikUser.email;
                sql = @"
                        INSERT INTO Masalah_Aplikasi
                            (id_masalah, email_pemilik, id_admin, jenis_masalah, isi_masalah, tanggal_masalah)
                        VALUES
                            (@id, @email, NULL, @jenis, @isi, @tgl);
                       ";
            }
          
            using (var conn = new SqlConnection(dbcon.cs))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", idMasalah);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@jenis", jenis);
                cmd.Parameters.AddWithValue("@isi", isi);
                cmd.Parameters.AddWithValue("@tgl", tgl);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Laporan masalah berhasil dikirim.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            grupLapor.Visible = false;
            optionMasalah.SelectedIndex = -1;
            descMasalah.Clear();
        }

        private void editprofil_Click(object sender, EventArgs e)
        {
            namaPengguna.Visible = false;
            nomorPengguna.Visible = false;

            submitProfil.Visible = true;
            editNama.Visible = true;
            editNomor.Visible = true;

            if (penghuniUser != null)
            {
                editNama.Text = penghuniUser.nama;
                editNomor.Text = penghuniUser.nomor_telepon;
            }
            else
            {
                editNama.Text = pemilikUser.nama;
                editNomor.Text = pemilikUser.nomor_telepon;
            }
        }

        private void submitProfil_Click(object sender, EventArgs e)
        {
            if (penghuniUser != null)
            {
                using (SqlConnection conn = new SqlConnection(dbcon.cs))
                {
                    conn.Open();
                    string query = @"UPDATE Penghuni SET 
                                        nama = @nama, 
                                        nomor_telepon = @hp
                                     WHERE id_penghuni = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", editNama.Text);
                    cmd.Parameters.AddWithValue("@hp", editNomor.Text);
                    cmd.Parameters.AddWithValue("@id", penghuniUser.id_penghuni);
                    cmd.ExecuteNonQuery();

                    penghuniUser.nama = editNama.Text;
                    penghuniUser.nomor_telepon = editNomor.Text;

                    namaPengguna.Text = penghuniUser.nama;
                    nomorPengguna.Text = penghuniUser.nomor_telepon;
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(dbcon.cs))
                {
                    conn.Open();
                    string query = @"UPDATE Pemilik SET 
                                        nama = @nama, 
                                        nomor_telepon = @hp
                                     WHERE id_pemilik = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", editNama.Text);
                    cmd.Parameters.AddWithValue("@hp", editNomor.Text);
                    cmd.Parameters.AddWithValue("@id", pemilikUser.id_pemilik);
                    cmd.ExecuteNonQuery();

                    pemilikUser.nama = editNama.Text;
                    pemilikUser.nomor_telepon = editNomor.Text;

                    namaPengguna.Text = pemilikUser.nama;
                    nomorPengguna.Text = pemilikUser.nomor_telepon;
                }
            }

            MessageBox.Show("Perubahan berhasil dibuat.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);

            submitProfil.Visible = false;
            editNama.Visible = false;
            editNomor.Visible = false;

            namaPengguna.Visible = true;
            nomorPengguna.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UserProfil_Load(object sender, EventArgs e)
        {

        }

        private void isPenghuniAktif()
        {
            try
            {
                string statusHuni = dbcon.getStatusHuni(penghuniUser.id_penghuni);
                if (statusHuni.ToLower() == "nonaktif")
                {
                    grupInvitasi.Visible = true;
                    btnLaporKeluhan.Visible = false;
                }
                else
                {
                    grupInvitasi.Visible = false;
                    btnLaporKeluhan.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengecek status hunian: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLaporKeluhan_Click(object sender, EventArgs e)
        {
            grupKeluhan.Visible = !grupKeluhan.Visible;
            inputKeluhan.Focus();
        }

        private void btnKirimKeluhan_Click(object sender, EventArgs e)
        {
            string isiKeluhan = inputKeluhan.Text.Trim();

            if (string.IsNullOrEmpty(isiKeluhan))
            {
                MessageBox.Show("Silakan isi keluhan terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                string query = @"
                    INSERT INTO Keluhan_Kos (id_keluhan, id_penghuni, id_kos, isi_keluhan, tanggal_keluhan)
                    VALUES (@id_keluhan, @id_penghuni, @id_kos, @isi_keluhan, @tanggal_keluhan)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_keluhan", dbcon.generateIdKeluhan());
                    cmd.Parameters.AddWithValue("@id_penghuni", penghuniUser.id_penghuni);
                    cmd.Parameters.AddWithValue("@id_kos", dbcon.getIdKosByPenghuni(penghuniUser.id_penghuni));
                    cmd.Parameters.AddWithValue("@isi_keluhan", isiKeluhan);
                    cmd.Parameters.AddWithValue("@tanggal_keluhan", DateTime.Now);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Keluhan berhasil dikirim.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        inputKeluhan.Text = "";
                        grupKeluhan.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan saat mengirim keluhan: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnKirimKode_Click(object sender, EventArgs e)
        {
            string kodeUnik = inputKode.Text.Trim();

            if (string.IsNullOrEmpty(kodeUnik))
            {
                MessageBox.Show("Silakan masukkan kode terlebih dahulu.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string selectKamarQuery = @"
                        SELECT TOP 1 id_kamar, id_kos, harga
                        FROM Kamar
                        WHERE kode_unik = @kodeUnik";

                    SqlCommand cmdSelectKamar = new SqlCommand(selectKamarQuery, conn, transaction);
                    cmdSelectKamar.Parameters.AddWithValue("@kodeUnik", kodeUnik);
                    SqlDataReader reader = cmdSelectKamar.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        reader.Close();
                        transaction.Rollback();
                        MessageBox.Show("Kode tidak ditemukan atau sudah tidak berlaku.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    reader.Read();
                    string idKamar = reader["id_kamar"].ToString();
                    string idKos = reader["id_kos"].ToString();
                    int harga = Convert.ToInt32(reader["harga"]);
                    reader.Close();

                    string idSewaBaru = dbcon.generateIdSewa();

                    DateTime tanggalMasuk = DateTime.Now;
                    DateTime jatuhTempo = tanggalMasuk.AddMonths(1);

                    string insertSewaQuery = @"
                        INSERT INTO Sewa (id_sewa, id_penghuni, id_kamar, tanggal_awal)
                        VALUES (@idSewa, @idPenghuni, @idKamar, @tanggalAwal)";
                    SqlCommand cmdInsertSewa = new SqlCommand(insertSewaQuery, conn, transaction);
                    cmdInsertSewa.Parameters.AddWithValue("@idSewa", idSewaBaru);
                    cmdInsertSewa.Parameters.AddWithValue("@idPenghuni", penghuniUser.id_penghuni);
                    cmdInsertSewa.Parameters.AddWithValue("@idKamar", idKamar);
                    cmdInsertSewa.Parameters.AddWithValue("@tanggalAwal", tanggalMasuk);
                    cmdInsertSewa.ExecuteNonQuery();

                    string updateKamarQuery = @"
                        UPDATE Kamar
                        SET status_kamar = 'dihuni', kode_unik = NULL
                        WHERE id_kamar = @idKamar";
                    SqlCommand cmdUpdateKamar = new SqlCommand(updateKamarQuery, conn, transaction);
                    cmdUpdateKamar.Parameters.AddWithValue("@idKamar", idKamar);
                    cmdUpdateKamar.ExecuteNonQuery();

                    string insertTagihanQuery = @"
                        INSERT INTO Tagihan (id_tagihan, id_sewa, biaya, status_pembayaran, tanggal_jatuh_tempo)
                        VALUES (@idTagihan, @idSewa, @jumlah, 0, @jatuhTempo)";
                    string idTagihan = dbcon.generateIdTagihan();
                    SqlCommand cmdInsertTagihan = new SqlCommand(insertTagihanQuery, conn, transaction);
                    cmdInsertTagihan.Parameters.AddWithValue("@idTagihan", idTagihan);
                    cmdInsertTagihan.Parameters.AddWithValue("@idSewa", idSewaBaru);
                    cmdInsertTagihan.Parameters.AddWithValue("@jumlah", harga);
                    cmdInsertTagihan.Parameters.AddWithValue("@jatuhTempo", jatuhTempo);
                    cmdInsertTagihan.ExecuteNonQuery();

                    string updateStatusPenghuniQuery = @"
                        UPDATE Penghuni
                        SET status_huni = 'aktif'
                        WHERE id_penghuni = @idPenghuni";
                    SqlCommand cmdUpdateStatusPenghuni = new SqlCommand(updateStatusPenghuniQuery, conn, transaction);
                    cmdUpdateStatusPenghuni.Parameters.AddWithValue("@idPenghuni", penghuniUser.id_penghuni);
                    cmdUpdateStatusPenghuni.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Berhasil masuk kos. Tagihan pertama juga telah dibuat.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
