using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyKosHub.Properties;

namespace MyKosHub
{
    public partial class DashboardPenghuni : Form
    {
        private Penghuni currentPenghuni;
        dbConnect dbcon = new dbConnect();

        HomepagePenghuni homepage;
        Login login;

        BayarSewaLayanan bayarSewaLayanan;
        PesanLayanan pesanLayanan;
        UserProfil userProfil;


        private void mdiProp()
        {
            this.SetBevel(false);
            var mdiClient = Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                mdiClient.BackColor = Color.FromArgb(232, 234, 237);
            }
        }

        private bool isPenghuniAktif()
        {
            try
            {
                string statusHuni = dbcon.getStatusHuni(currentPenghuni.id_penghuni);
                if (statusHuni.ToLower() == "nonaktif")
                {
                    MessageBox.Show("Mohon maaf, untuk saat ini Anda belum terhubung dengan kos manapun.\nBila Anda telah memasuki kos lain, mohon mengisi Kode Invitasi pada bagian Settings", "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengecek status hunian: " + ex.Message, "Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void TampilkanForm(Form form)
        {

            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        public DashboardPenghuni(Penghuni current)
        {
            InitializeComponent();
            mdiProp();
            this.currentPenghuni = current;
        }

        bool menuExpand = false;
        bool sidebarExpand = true;

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        
   

        private void userProfil_FormClosed(object sender, EventArgs e)
        {
            userProfil = null;
        }


        private void buttonHome_Click_1(object sender, EventArgs e)
        {
            if (!isPenghuniAktif()) return;

            if (homepage == null)
            {
                homepage = new HomepagePenghuni(currentPenghuni);
                homepage.FormClosed += homepage_FormClosed;
                TampilkanForm(homepage);
            }
            else
            {
                homepage.Activate();
            }
        }

        private void homepage_FormClosed(object sender, EventArgs e)
        {
            homepage = null;
        }

        private void manageKosTransition_Tick(object sender, EventArgs e)
        {

        }

        

        private void buttonPesanLayanan_Click(object sender, EventArgs e)
        {

            if(!isPenghuniAktif()) return;

            if (pesanLayanan == null)
            {
                pesanLayanan = new PesanLayanan(currentPenghuni);
                pesanLayanan.FormClosed += pesanLayanan_FormClosed;
                TampilkanForm(pesanLayanan);
            }
            else
            {
                pesanLayanan.Activate();
            }
        }

        private void pesanLayanan_FormClosed(object sender, EventArgs e)
        {
            pesanLayanan = null;
        }

        private void buttonBill_Click(object sender, EventArgs e)
        {
            if(!isPenghuniAktif()) return;

            if (bayarSewaLayanan == null)
            {
                bayarSewaLayanan = new BayarSewaLayanan(currentPenghuni);
                bayarSewaLayanan.FormClosed += pesanLayanan_FormClosed;
                TampilkanForm(bayarSewaLayanan);
            }
            else
            {
                bayarSewaLayanan.Activate();
            }
        }

        private void bayarSewaLayanan_FormClosed(object sender, EventArgs e)
        {
            bayarSewaLayanan = null;
        }

        private void DashboardPenghuni_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            buttonHome_Click_1(sender, e);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {

            if (userProfil != null && !userProfil.IsDisposed)
            {
                userProfil.Close();
            }

            userProfil = new UserProfil(currentPenghuni);
            userProfil.FormClosed += userProfil_FormClosed;
            userProfil.MdiParent = this;
            userProfil.Dock = DockStyle.Fill;
            userProfil.Show();
            
        }
        private void s_FormClosed(object sender, EventArgs e)
        {
            userProfil = null;
        }

        private void sidebarTransition_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 52)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    pnHome.Width = sidebar.Width;
                    pnRent.Width = sidebar.Width;
                    pnSettings.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 226)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnHome.Width = sidebar.Width;
                    pnRent.Width = sidebar.Width;
                    pnSettings.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
        }
    }
}
