
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MyKosHub
{
    public partial class Form1 : Form
    {
        private dbConnect dbcon = new dbConnect();
        Penghuni penghuni = new Penghuni(null, null, null, null,  null);
        Pemilik pemilik = new Pemilik(null, null, null, null, null);

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            panelInputKode.Visible = false;
            label9.Visible = false;
        }

        private void loginTransfer_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputName.Text) &&
                !string.IsNullOrWhiteSpace(inputEmail.Text) &&
                !string.IsNullOrWhiteSpace(inputPhone.Text) &&
                !string.IsNullOrWhiteSpace(inputPassword.Text) &&
                (pemilikButton.Checked || penghuniButton.Checked))
            {

                if (!inputEmail.Text.Contains("@") || !inputEmail.Text.Contains("."))
                {
                    MessageBox.Show("Format email tidak valid. Harus mengandung '@' dan '.'", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!long.TryParse(inputPhone.Text, out _))
                {
                    MessageBox.Show("Nomor telepon harus berisi angka.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dbcon.checkEmail(inputEmail.Text))
                {
                    MessageBox.Show("Email sudah terdaftar, gunakan email lain!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (pemilikButton.Checked)
                {
                    Pemilik pemilik = new Pemilik(
                        dbcon.generateId(),
                        inputName.Text,
                        inputEmail.Text,
                        inputPhone.Text,
                        inputPassword.Text
                    );

                    dbcon.addPemilik(pemilik);

                    MessageBox.Show("Sign Up berhasil!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
                else if (penghuniButton.Checked)
                {
                    if (string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        MessageBox.Show("Masukkan kode undangan!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string idKamar = null;

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                        {
                            conn.Open();
                            string query = "SELECT id_kamar FROM Kamar WHERE kode_unik = @kode";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@kode", textBox1.Text);
                                object result = cmd.ExecuteScalar();
                                if (result != null)
                                {
                                    idKamar = result.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Kode undangan tidak valid. Silakan cek kembali.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan saat memeriksa kode undangan:\n" + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        string idPenghuni = dbcon.generateIdPenghuni();
                        Penghuni penghuni = new Penghuni(
                            idPenghuni,
                            inputName.Text,
                            inputEmail.Text,
                            inputPhone.Text,
                            inputPassword.Text
                        );
                        dbcon.addPenghuni(penghuni);

                        using (SqlConnection conn = new SqlConnection(dbcon.GetConnectionString()))
                        {
                            conn.Open();
                            string queryInsert = "INSERT INTO Sewa (id_sewa, id_penghuni, id_kamar, tanggal_awal, tanggal_akhir) " +
                                                 "VALUES (@id_sewa, @id_penghuni, @id_kamar, @tanggal_awal, NULL)";
                            using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_sewa", dbcon.generateIdSewa());
                                cmd.Parameters.AddWithValue("@id_penghuni", idPenghuni);
                                cmd.Parameters.AddWithValue("@id_kamar", idKamar);
                                cmd.Parameters.AddWithValue("@tanggal_awal", DateTime.Today);
                                cmd.ExecuteNonQuery();
                            }

                            string queryUpdateKodeUnik = "UPDATE Kamar SET kode_unik = NULL WHERE id_kamar = @id_kamar";
                            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdateKodeUnik, conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@id_kamar", idKamar);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            string queryUpdataStatus = "UPDATE Kamar SET status_kamar = 'dihuni' WHERE id_kamar = @id_kamar";
                            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdataStatus, conn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@id_kamar", idKamar);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            decimal hargaSewa = 0;
                            string queryHarga = "SELECT harga FROM Kamar WHERE id_kamar = @id_kamar";
                            using (SqlCommand cmdHarga = new SqlCommand(queryHarga, conn))
                            {
                                cmdHarga.Parameters.AddWithValue("@id_kamar", idKamar);
                                object resultHarga = cmdHarga.ExecuteScalar();
                                if (resultHarga != null)
                                {
                                    hargaSewa = Convert.ToDecimal(resultHarga);
                                }
                            }

                            string idTagihan = dbcon.generateIdTagihan();
                            string idSewa = dbcon.getLastInsertedSewaIdByPenghuni(idPenghuni);
                            DateTime tanggalAwal = DateTime.Today;
                            DateTime jatuhTempo = tanggalAwal.AddMonths(1);

                            string queryInsertTagihan = @"
                INSERT INTO Tagihan (id_tagihan, id_sewa, biaya, status_pembayaran, tanggal_jatuh_tempo)
                VALUES (@id_tagihan, @id_sewa, @biaya, 0, @tanggal_jatuh_tempo)";
                            using (SqlCommand cmdTagihan = new SqlCommand(queryInsertTagihan, conn))
                            {
                                cmdTagihan.Parameters.AddWithValue("@id_tagihan", idTagihan);
                                cmdTagihan.Parameters.AddWithValue("@id_sewa", idSewa);
                                cmdTagihan.Parameters.AddWithValue("@biaya", hargaSewa);
                                cmdTagihan.Parameters.AddWithValue("@tanggal_jatuh_tempo", jatuhTempo);
                                cmdTagihan.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Sign Up berhasil!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login = new Login();
                        login.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan saat proses pendaftaran:\n" + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked)
            {
                inputPassword.UseSystemPasswordChar = true;
            }
            else
            {
                inputPassword.UseSystemPasswordChar = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                signUpButton.PerformClick();
                e.Handled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void penghuniButton_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = true;
            panelInputKode.Visible = true;

        }

        private void pemilikButton_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
            panelInputKode.Visible = false;
        }

        private void inputKode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}