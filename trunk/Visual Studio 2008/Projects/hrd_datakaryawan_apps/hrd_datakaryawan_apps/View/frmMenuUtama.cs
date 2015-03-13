using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using hrd_datakaryawan_apps.Model;
using hrd_datakaryawan_apps.DAO;

namespace hrd_datakaryawan_apps.View
{
    public partial class frmMenuUtama : Form
    {
        //Variabel Global, objek yang akan menghandle status koneksi open terhadap database.
        private DBConnection conn = null;
        Form[] childArray = null;           //Variable Array untuk menampung childForm
      
        //Constructor
        public frmMenuUtama()
        {            
            InitializeComponent();

            try
            {
                //Inisialisasi objek conn. Pastikan bahwa koneksi dengan database ber-status open.
                //Jadi setiap Form Menu Utama di Load, status koneksi ke database harus terbuka / open.
                //Dengan kata lain setiap sebuah sessi aplikasi ini dijalankan, sebuah koneksi ke database akan di buka / terbentuk
                conn = DBConnection.GetInstance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void fillArrayWithActiveChildForm()
        {
            childArray = this.MdiChildren;
        }

        private void CloseAllActiveChildForm()
        {
            fillArrayWithActiveChildForm();
            //MessageBox.Show("Jumlah ChildForm : " + childArray.Length.ToString());

            foreach (Form childForm in childArray)
            {
                childForm.Close();
            }
        }

        public int CountAllActiveChildForm()
        {
            fillArrayWithActiveChildForm();

            return (int)childArray.Length;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hRDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmLokasiKerja fLKj = new frmLokasiKerja(conn, this); //Buka sebuah Form Lokasi Kerja dengan membuat objek baru. Dan Jangan lupa sertakan objek conn yang memiliki status terbuka terhadap database, yang mewakili 1 koneksi ke database untuk 1 aplikasi ini yang dijalankan.
            fLKj.MdiParent = this;
            fLKj.Show();                        
        }

        private void absensiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmDepartemen fDpt = new frmDepartemen(conn, this);
            fDpt.MdiParent = this;
            fDpt.Show();
        }

        private void gajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmJabatan fJbt = new frmJabatan(conn, this);
            fJbt.MdiParent = this;
            fJbt.Show();
        }

        private void statusPekerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmStatus_Pekerja fStP = new frmStatus_Pekerja(conn, this);
            fStP.MdiParent = this;
            fStP.Show();
        }

        private void bantuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }
            */

            frmtes frt = new frmtes();
            frt.MdiParent = this;
            frt.Show();
        }

        private void jenisPekerjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmJenis_Pekerja fJnP = new frmJenis_Pekerja(conn, this);
            fJnP.MdiParent = this;
            fJnP.Show();
        }

        private void upahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmUpah fUP = new frmUpah(conn, this);
            fUP.MdiParent = this;
            fUP.Show();
        }

        private void agamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmAgama fUP = new frmAgama(conn, this);
            fUP.MdiParent = this;
            fUP.Show();
        }

        private void gradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmGrade fGd = new frmGrade(conn, this);
            fGd.MdiParent = this;
            fGd.Show();
        }

        private void levelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmLevel fLv = new frmLevel(conn, this);
            fLv.MdiParent = this;
            fLv.Show();
        }

        private void statusPajakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolStripMenuItem1.Enabled == true)
            {
                this.toolStripMenuItem1.Enabled = false;
            }

            frmStatusPajak fStp = new frmStatusPajak(conn, this);
            fStp.MdiParent = this;
            fStp.Show();
            //fStp.ShowDialog();
        }

        private void dataKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren != null)
            {
                CloseAllActiveChildForm(); //Tutup semua Child Form yang aktif
            }

            /*
            if (this.ActiveMdiChild != null)
            {
                CloseAllActiveChildForm(); //Tutup semua Child Form yang aktif
            }
            */

            frmDataKaryawan fDK = new frmDataKaryawan(conn, this);
            fDK.MdiParent = this;
            fDK.Show();
        }
    }
}
