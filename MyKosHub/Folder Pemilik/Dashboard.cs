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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyKosHub
{
    public partial class Dashboard : Form
    {
        //Homepage
        Homepage homepage;


        //Manajemen Kamar
        manajemenKamar manajemenkamar;

        // Manajemen Layanan
        ManajemenLayanan manajemenLayanan;

        //Manajemen Keuangan
        LaporanKeuangan laporanKeuangan;
        KelolaStatus kelolaStatus;

        //Keluhan
        KelolaKeluhan kelolaKeluhan;

        //Profil Pengguna
        UserProfil userProfil;



        dbConnect dbcon = new dbConnect();

        private Pemilik currentPemilik;

        private void mdiProp()
        {
            this.SetBevel(false);
            var mdiClient = Controls.OfType<MdiClient>().FirstOrDefault();
            if (mdiClient != null)
            {
                mdiClient.BackColor = Color.FromArgb(232, 234, 237);
            }

        }

        public void TampilkanForm(Form form)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        public Dashboard(Pemilik current)
        {
            InitializeComponent();
            mdiProp();
            this.currentPemilik = current;
        }
        
        bool menuExpand = false;
        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 52)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    pnHome.Width = sidebar.Width;
                    pnKamar.Width = sidebar.Width;
                    pnServices.Width = sidebar.Width;
                    pnFinance.Width = sidebar.Width;
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
                    pnKamar.Width = sidebar.Width;
                    pnServices.Width = sidebar.Width;
                    pnFinance.Width = sidebar.Width;
                    pnSettings.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
        }


        private void financialMenuTransition_Tick_1(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                financialContainer.Height += 5;
                if(financialContainer.Height >= 163)
                {
                    financialMenuTransition.Stop();
                    menuExpand = true;
                }
            } else
            {
                financialContainer.Height -= 5;
                if(financialContainer.Height <= 48)
                {
                    financialMenuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void Finance_Click(object sender, EventArgs e)
        {
            financialMenuTransition.Start();
        }



        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            buttonHome_Click(sender, e);
        }


        private void buttonFinancialSummary_Click(object sender, EventArgs e)
        {
            if (laporanKeuangan == null)
            {
                laporanKeuangan = new LaporanKeuangan(currentPemilik);
                laporanKeuangan.FormClosed += laporKeuangan_FormClosed;
                laporanKeuangan.MdiParent = this;
                laporanKeuangan.Dock = DockStyle.Fill;
                laporanKeuangan.Show();
            }
            else
            {
                laporanKeuangan.Activate();
            }
        }

        private void laporKeuangan_FormClosed(Object sender, EventArgs e)
        {
            laporanKeuangan = null;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

    

        private void buttonHome_MouseHover(object sender, EventArgs e)
        {
            buttonHome.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void buttonHome_MouseLeave(object sender, EventArgs e)
        {
            buttonHome.BackColor = Color.FromArgb(23, 24, 29);
        }



        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (homepage != null && !homepage.IsDisposed)
            {
                homepage.Close(); 
            }

            homepage = new Homepage(currentPemilik);
            homepage.FormClosed += homepage_FormClosed;
            homepage.MdiParent = this;
            homepage.Dock = DockStyle.Fill;
            homepage.Show();
        }

        private void homepage_FormClosed(object sender, EventArgs e)
        {
            homepage = null;
        }

        private void btnKamar_Click(object sender, EventArgs e)
        {
            if (manajemenkamar == null)
            {
                manajemenkamar = new manajemenKamar(currentPemilik);
                manajemenkamar.FormClosed += manajemenkamar_FormClosed;
                manajemenkamar.MdiParent = this;
                manajemenkamar.Dock = DockStyle.Fill;
                manajemenkamar.Show();
            }
            else
            {
                manajemenkamar.Activate();
            }
        }

        private void manajemenkamar_FormClosed(object sender, EventArgs e)
        {
            manajemenkamar = null;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            if (manajemenLayanan == null)
            {
                manajemenLayanan = new ManajemenLayanan(currentPemilik);
                manajemenLayanan.FormClosed += manajemenLayanan_FormClosed;
                manajemenLayanan.MdiParent = this;
                manajemenLayanan.Dock = DockStyle.Fill;
                manajemenLayanan.Show();
            }
            else
            {
                manajemenLayanan.Activate();
            }
        }

        private void manajemenLayanan_FormClosed(object sender, EventArgs e)
        {
            manajemenLayanan = null;
        }

        private void btnKeluhan_Click(object sender, EventArgs e)
        {
            if (kelolaKeluhan == null)
            {
                kelolaKeluhan = new KelolaKeluhan(currentPemilik);
                kelolaKeluhan.FormClosed += kelolaKeluhan_FormClosed;
                kelolaKeluhan.MdiParent = this;
                kelolaKeluhan.Dock = DockStyle.Fill;
                kelolaKeluhan.Show();
            }
            else
            {
                kelolaKeluhan.Activate();
            }
        }

        private void kelolaKeluhan_FormClosed(Object sender, EventArgs e)
        {
            kelolaKeluhan = null;
        }

        private void btnManageFinance_Click(object sender, EventArgs e)
        {
            if (kelolaStatus == null)
            {
                kelolaStatus = new KelolaStatus(currentPemilik);
                kelolaStatus.FormClosed += kelolaStatus_FormClosed;
                kelolaStatus.MdiParent = this;
                kelolaStatus.Dock = DockStyle.Fill;
                kelolaStatus.Show();
            }
            else
            {
                kelolaStatus.Activate();
            }
        }

        private void kelolaStatus_FormClosed(Object sender, EventArgs e)
        {
            kelolaStatus = null;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (userProfil == null)
            {
                userProfil = new UserProfil(currentPemilik);
                userProfil.FormClosed += userProfil_FormClosed;
                userProfil.MdiParent = this;
                userProfil.Dock = DockStyle.Fill;
                userProfil.Show();
            }
            else
            {
                userProfil.Activate();
            }
        }
        private void userProfil_FormClosed(object sender, EventArgs e)
        {
            userProfil = null;
        }
    }
}
