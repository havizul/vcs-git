using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using hrd_datakaryawan_apps.DAO;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.View
{
    public partial class frmUkuran_Pakaian : Form
    {
        //Variabel Global
        const int init = 1;
        private string nik = null;

        private Ukuran_PakaianDAO ukpDAO = null;
        private bool resultBool = false;
        private int result = 0;


        public frmUkuran_Pakaian(string nik, Ukuran_PakaianDAO ukpDAO)
        {
            InitializeComponent();

            this.nik = nik;
            this.ukpDAO = ukpDAO;

            try
            {
                //ukpDAO = new Ukuran_PakaianDAO(conn.GetConnection());

                //loadDataLevel();

                //this.frmMU = frmMU;
                //frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmUkuran_Pakaian_Constructor");
            }
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmUkuran_Pakaian\nMethod : " + str2);
            //statusStripLevelPanel1("Telah terjadi error.", Color.Red);
        }

        private void lblMsgString(string msg, System.Drawing.Color clr)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = clr;
        }

        private bool msgBoxWarning(string prompt)
        {
            if (MessageBox.Show(prompt, "Peringatan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void fillTextBox(Ukuran_Pakaian ukp)
        {
            txtNIK.Text = ukp.NIK;
            txtUkuranBaju.Text = ukp.Ukuran_Baju;
            txtUkuranCelana.Text = ukp.Ukuran_Celana;
            txtUkuranSepatu.Text = ukp.Ukuran_Sepatu;

            txtUkuranBaju.Focus();
        }

        private iListener _listener;
        public virtual iListener Listener
        {
            set { _listener = value; }
        }
        
        private void fillTextBoxMainForm(object[] data, int genIntNumb, int init)
        {
            if (this._listener != null)
            {
                this._listener.Ok(data, genIntNumb, init);
            }
        }

        private void clearTextBox()
        {
            txtUkuranBaju.Clear();
            txtUkuranCelana.Clear();
            txtUkuranSepatu.Clear();

            txtUkuranBaju.Focus();
        }

        private void loadTxtBox()
        {
                Ukuran_Pakaian ukp = ukpDAO.GetByNIK(txtNIK.Text);

                if (ukp != null)
                {
                    txtUkuranBaju.Text = ukp.Ukuran_Baju;
                    txtUkuranCelana.Text = ukp.Ukuran_Celana;
                    txtUkuranSepatu.Text = ukp.Ukuran_Sepatu;
                }
                else
                {
                    txtUkuranBaju.Clear();
                    txtUkuranCelana.Clear();
                    txtUkuranSepatu.Clear();
                }            
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            try
            {                
                this.Close();
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnTutup_Click");
            }
        }

        private void frmUkuran_Pakaian_Load(object sender, EventArgs e)
        {
            try
            {
                txtNIK.Text = nik;
                txtUkuranBaju.Focus();

                loadTxtBox();
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmUkuran_Pakaian_Load()");
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUkuranBaju.Text == "" || txtUkuranCelana.Text == "" || txtUkuranSepatu.Text == "")
                {
                    lblMsgString("Seluruh Field harus diisi !", Color.Yellow);
                }
                else
                {
                    Ukuran_Pakaian ukp = new Ukuran_Pakaian();

                    ukp.NIK = txtNIK.Text;
                    ukp.Ukuran_Baju = txtUkuranBaju.Text;
                    ukp.Ukuran_Celana = txtUkuranCelana.Text;
                    ukp.Ukuran_Sepatu = txtUkuranSepatu.Text;

                    object[] data = new object[] { ukp.Ukuran_Baju, ukp.Ukuran_Celana, ukp.Ukuran_Sepatu };

                    //Cek Record Ukuran Pakaian apakah sudah ada atau belum, guna menentukan operasi
                    //Update atau Save
                    resultBool = ukpDAO.cekRecord(txtNIK.Text);

                    if (resultBool == false) //Data Level masih kosong jadi bisa disimpan
                    {
                        result = ukpDAO.Save(ukp);

                        if (result > 0)
                        {
                            lblMsgString("Data berhasil disimpan.", Color.Green);
                            fillTextBox(ukp);
                            fillTextBoxMainForm(data, 0, init);
                        }
                        else
                        {
                            lblMsgString("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else //Meng-update data level
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Ukuran Karyawan yang memiliki NIK = " + txtNIK.Text + " ?") == true)
                        {
                            result = ukpDAO.Update(ukp);

                            if (result > 0)
                            {
                                lblMsgString("Data berhasil diubah.", Color.Green);
                                fillTextBox(ukp);
                                fillTextBoxMainForm(data, 0, init);
                            }
                            else
                            {
                                lblMsgString("Data gagal diubah.", Color.Red);
                            }
                        }
                        else
                        {
                            //clearTextBox();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnSimpan_Click");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {                
                if (msgBoxWarning("Apakah anda yakin akan menghapus informasi Ukuran Pakaian karyawan dengan NIK \"" + txtNIK.Text + "\" ?") == true)             
                {
                        result = ukpDAO.Delete(txtNIK.Text);

                        if (result > 0)
                        {
                            lblMsgString("Data berhasil dihapus.", Color.Green);
                            clearTextBox();

                            object[] data = new object[] { "", "", "" };
                            fillTextBoxMainForm(data, 0, init);
                        }
                        else
                        {
                            lblMsgString("Data gagal dihapus !!!", Color.Red);
                        }                    
                }                
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
        }
    }
}
