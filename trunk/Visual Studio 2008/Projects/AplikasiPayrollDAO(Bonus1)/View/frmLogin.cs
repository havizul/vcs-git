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

namespace AplikasiPayrollDAO.View
{
    public partial class frmLogin : Form
    {
        private LoginDAO lgnDAO = null;
        private frmMenuUtama frmParent = null;

        //untuk menampung return value operasi database
        private char resultChr = 'N';

              
        public frmLogin(frmMenuUtama frmMU, DBConnection conn)
        {
            InitializeComponent();
                       
            //Objek form menu utama
            frmParent = frmMU;

            //disable menu pada form menuutama
            frmParent.DisEnbMenuItem(false, false, false, false, false, false, false, false, false, false, true, true);

            //Buat objek lgnDAO untuk operasi database
            lgnDAO = new LoginDAO(conn.GetConnection());                       
        }

        //Method untuk menghanlde MessageBox.show
        private void msgInfo(string prompt)
        {
            MessageBox.Show(prompt, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Method untuk mengosongkan input
        private void ClearTextBox()
        {
            txtKodePetugas.Clear();
            txtPassword.Clear();

            txtKodePetugas.Focus();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            ClearTextBox();
            this.Hide();
        }

        private void btnMasuk_Click(object sender, EventArgs e)
        {
            if (txtKodePetugas.Text == "" || txtPassword.Text == "")
            {
                msgInfo("Lengkapi terlebih dahulu Kode Petugas dan Password Petugas...");
            }
            else if (txtKodePetugas.Text.Length > 5 || txtPassword.Text.Length > 10)
            {
                msgInfo("Kode Petugas Maksimum 5 Karakter...\nNama Petugas Maksimum 10 Karakter ");
            }
            else
            {
                Petugas lgn = new Petugas();

                lgn.Kode_Petugas = txtKodePetugas.Text;
                lgn.Password_Petugas = txtPassword.Text;

                //msgInfo("Cek Records");
                resultChr = lgnDAO.CheckRecord(txtKodePetugas.Text, txtPassword.Text);

                if (resultChr == 'Y')
                {
                    lgn = lgnDAO.GetByKodePetugas(txtKodePetugas.Text);
                    
                    //Informasi Panel
                    frmParent.statusStripPanel(lgn.Kode_Petugas, lgn.Nama_Petugas, lgn.Status_Petugas);

                    if (lgn.Status_Petugas == "Administrator")
                    {
                        //Setting Menu Administrator
                        frmParent.DisEnbMenuItem(true, true, true, true, true, true, true, true, true, true, false, true);
                    }
                    else
                    {
                        //Setting Menu User
                        frmParent.DisEnbMenuItem(true, true, true, true, false, false, true, true, true, true, false, true);
                    }
                    
                    //Sembunyikan Form Login;  
                    ClearTextBox();
                    this.Hide();
                }
                else
                {
                    msgInfo("Periksa kembali Kode Petugas dan Password yang anda masukkan !!!");                   
                }     
            }
        }
    }
}
