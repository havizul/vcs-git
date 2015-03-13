using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AplikasiPayrollDAO.DAO;
using AplikasiPayrollDAO.Model;
using AplikasiPayrollDAO.View;

namespace AplikasiPayrollDAO
{
    public partial class frmMenuUtama : Form
    {
        private DBConnection conn = null;
        private frmLogin frmMasuk = null;

        //constructor
        public frmMenuUtama()
        {
            InitializeComponent();
          
            //Inisialisasi objek conn
            conn = DBConnection.GetInstance();

            //Menampilkan form login
            frmLogin frmLGN = new frmLogin(this, conn);
            frmMasuk = frmLGN;
            frmMasuk.MdiParent = this;
            frmMasuk.Show();    
        
            //Menampilkan Info di StatusStrip
            statusStripPanel("Kode", " Nama", "Status");
        }

        //Setting Menu
        public void DisEnbMenuItem(bool fil, bool gol, bool jab, bool pot, bool peg, bool pet, bool trans, bool lap, bool util, bool kel, bool mas, bool sel)
        {
            fileToolStripMenuItem.Enabled = fil;
            golonganToolStripMenuItem.Enabled = gol;
            jabatanToolStripMenuItem.Enabled = jab;
            potonganToolStripMenuItem.Enabled = pot;
            pegawaiToolStripMenuItem.Enabled = peg;
            petugasToolStripMenuItem.Enabled = pet;

            transaksiToolStripMenuItem.Enabled = trans;
            laporanToolStripMenuItem.Enabled = lap;
            utilityToolStripMenuItem.Enabled = util;

            keluarToolStripMenuItem.Enabled = kel;
            masukToolStripMenuItem.Enabled = mas;
            selesaiToolStripMenuItem.Enabled = sel;
        }

        //informasi petugas
        public void statusStripPanel(string panel1, string panel2, string panel3)
        {
            Panel1.Text = panel1 + "          ";
            Panel2.Text = panel2 + "          ";
            Panel3.Text = panel3 + "          ";
        }
        
        private void golonganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGolongan fGLG = new frmGolongan(conn);
            fGLG.MdiParent = this;
            fGLG.Show();
        }

        private void jabatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJabatan fJBT = new frmJabatan(conn);
            fJBT.MdiParent = this;            
            fJBT.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasuk.Show();            
        }

        private void keluarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisEnbMenuItem(false, false, false, false, false, false, false, false, false, false, true, true);
            statusStripPanel("Kode", " Nama", "Status");
        }

        private void selesaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
