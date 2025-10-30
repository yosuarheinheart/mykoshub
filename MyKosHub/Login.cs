using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyKosHub
{
    public partial class Login : Form
    {
        public static Login instance;
        private dbConnect dbcon = new dbConnect();
        Penghuni penghuni = new Penghuni(null, null, null, null, null);
        Pemilik pemilik = new Pemilik(null, null, null, null, null);
        Admin admin = new Admin(null, null, null, null);

        int percobaan = 0;
        DateTime sisaWaktu = DateTime.MinValue;

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Login_KeyDown);
        }

        private void signUpTransfer_Click(object sender, EventArgs e)
        {
            Form1 form1= new Form1();
            form1.Show();
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            if (DateTime.Now < sisaWaktu)
            {
                int secondsLeft = (int)(sisaWaktu - DateTime.Now).TotalSeconds;
                MessageBox.Show($"Terlalu banyak percobaan yang salah, tunggu {secondsLeft} detik untuk melakukan percobaan lagi.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(inputEmail.Text) ||
                string.IsNullOrWhiteSpace(inputPassword.Text))
            {
                MessageBox.Show("Pastikan seluruh informasi terisi!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (penghuni.login(inputEmail.Text, inputPassword.Text))
            {
                Penghuni current = dbcon.getUserPenghuni(inputEmail.Text);
                MessageBox.Show("Login berhasil!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                percobaan = 0;

                DashboardPenghuni dashboardPenghuni = new DashboardPenghuni(current);
                dashboardPenghuni.Show();
                this.Hide();
            }
            else if (pemilik.login(inputEmail.Text, inputPassword.Text))
            {
                Pemilik current = dbcon.getUserPemilik(inputEmail.Text);
                percobaan = 0;

                if (pemilik.hasKos(current.email))
                {
                    MessageBox.Show("Login berhasil!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dashboard db = new Dashboard(pemilik);
                    db.Show();
                } 
                else
                {
                    MessageBox.Show("Login berhasil! Mohon menambahkan Informasi Kos Anda!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BeginPemilik1 begin = new BeginPemilik1(pemilik);
                    begin.Show();
                }
                this.Hide();
            }
            else if (admin.login(inputEmail.Text, inputPassword.Text))
            {
                Admin current = dbcon.getAdmin(inputEmail.Text);
                MessageBox.Show("Login berhasil!", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                percobaan = 0; 
                
                HomepageAdmin home = new HomepageAdmin(current);
                home.Show();
                this.Hide();
            }
            else 
            {
                percobaan++;
                int sisaPercobaan = 5 - percobaan;
                MessageBox.Show($"Login gagal. Sisa {sisaPercobaan}", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (percobaan >= 5)
                {
                    MessageBox.Show("Terlalu banyak percobaan. Silahkan tunggu 30 detik.", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    sisaWaktu = DateTime.Now.AddSeconds(30);
                    percobaan = 0; 
                }
            }


            if (pemilik.login(inputEmail.Text, inputPassword.Text))
            {
                Pemilik current = dbcon.getUserPemilik(inputEmail.Text);
                this.Hide();
                UserProfil userProfil = new UserProfil(current);
            }

            if (penghuni.login(inputEmail.Text, inputPassword.Text))
            {
                Penghuni current = dbcon.getUserPenghuni(inputEmail.Text);
                this.Hide();
                UserProfil userProfil = new UserProfil(current);
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

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
                e.Handled = true;
            }
        }

 
    }
}

