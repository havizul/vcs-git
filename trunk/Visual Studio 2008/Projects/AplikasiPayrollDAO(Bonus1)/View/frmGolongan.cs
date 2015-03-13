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
    public partial class frmGolongan : Form
    {        
        private GolonganDAO glgDAO = null;
               
        //untuk menampung return value operasi CRUD
        private bool resultBool = false;
        private int result = 0;

        //constructor
        public frmGolongan(DBConnection conn)
        {
            InitializeComponent();
                      
                //buat objek glgDAO untuk mengakses operasi database
                glgDAO = new GolonganDAO(conn.GetConnection());
                         
           
            LoadDataGolongan();
        }

        private void clearTextBox()
        {
            txtGolongan.Clear();
            txtTjSuamiIstri.Clear();
            txtTjAnak.Clear();
            txtUangMakan.Clear();
            txtUangLembur.Clear();
            txtAskes.Clear();

            txtGolongan.Focus();
        }

        private void msgInfo(string prompt)
        {
            MessageBox.Show(prompt, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool msgInfo2(string prompt)
        {
            if (MessageBox.Show(prompt, "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string ConvertToUpper(string kata)
        {
            return kata.ToUpper();
        }
        
        private bool NumericOnly(System.Windows.Forms.KeyPressEventArgs e)
        {
            string strValid = "0123456789";

            if (strValid.IndexOf(e.KeyChar) < 0 && !(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                msgInfo("Masukan Angka !!!.\nDan jumlah maksimum angka yang boleh anda masukan adalah 11 digit !!!");
                return true; //Not valid
            }
            else
            {
                return false; //Valid
            }
        }

        private void frmGolongan_Load(object sender, EventArgs e)
        {
            //LoadDataGolongan();
        }        

        private void LoadDataGolongan()
        {         
            List<Golongan> daftarGlg = glgDAO.GetAll();
            DGV.DataSource = daftarGlg.ToArray();
            DGV.ReadOnly = true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtGolongan.Text == "" || txtTjSuamiIstri.Text == "" || txtTjAnak.Text == "" || txtUangMakan.Text == "" || txtUangLembur.Text == "" || txtAskes.Text == "")
            {
                msgInfo("Data yang anda isikan belum lengkap");
            }           
            else if (txtGolongan.Text.Length > 4 || txtTjSuamiIstri.Text.Length > 11 || txtTjAnak.Text.Length > 11 || txtUangMakan.Text.Length > 11 || txtUangLembur.Text.Length > 11 || txtAskes.Text.Length > 11)
            {
                msgInfo("Kolom Golongan maksimal 4 karakter/digit !!!\nKolom lain tidak boleh lebih dari 11 karakter/digit angka !!! ");
            }
            else
            {                
                Golongan glg = new Golongan();

                glg.Tk_Golongan = txtGolongan.Text;
                glg.TJ_Suami_Istri = int.Parse(txtTjSuamiIstri.Text);
                glg.TJ_Anak = int.Parse(txtTjAnak.Text);
                glg.Uang_Makan = int.Parse(txtUangMakan.Text);
                glg.Uang_Lembur = int.Parse(txtUangLembur.Text);
                glg.Askes = int.Parse(txtAskes.Text);

                resultBool = glgDAO.CheckRecords(txtGolongan.Text);

                if (resultBool == false)
                {
                    result = glgDAO.Save(glg);

                    if (result > 0)
                    {
                        txtGolongan.Focus();
                        msgInfo("Data berhasil disimpan");
                    }
                    else
                    {
                        msgInfo("Data gagal disimpan");
                    }
                }
                else
                {
                    if (msgInfo2("Sudah terdapat Tingkat Golongan " + txtGolongan.Text + ". Apakah anda akan mengupdate data ini ?") == true)
                    {
                        result = glgDAO.Update(glg);

                        if (result > 0)
                        {
                            msgInfo("Data Golongan berhasil di-update");
                        }
                        else
                        {
                            msgInfo("Data Golongan gagal di-update");
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }                          
                }

                LoadDataGolongan();
            }           
        }

        private void txtTjSuamiIstri_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtGolongan.Text == "")
            {
                msgInfo("Isi Kolom Golongan terlebih dahulu !!!");
            }
            else
            {
                if (msgInfo2("Apakah anda yakin akan menghapus data Golongan dengan Kode " + txtGolongan.Text + "?") == true)
                {
                    result = glgDAO.Delete(txtGolongan.Text);

                    if (result > 0)
                    {
                        msgInfo("Data Golongan berhasil dihapus !!!");
                    }
                    else
                    {
                        msgInfo("Data Golongan gagal dihapus !!!");
                    }
                }
                else
                {
                    clearTextBox();
                }

                LoadDataGolongan();
            }
        }       

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtGolongan.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtTjSuamiIstri.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
            txtTjAnak.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[2].Value.ToString();
            txtUangMakan.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[3].Value.ToString();
            txtUangLembur.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[4].Value.ToString();
            txtAskes.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[5].Value.ToString();
        }

        private void txtGolongan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtGolongan.Text = ConvertToUpper(txtGolongan.Text);
                Golongan glg = glgDAO.GetByTkGolongan(txtGolongan.Text);
                if (glg != null)
                {
                    txtTjSuamiIstri.Text = (glg.TJ_Suami_Istri).ToString();
                    txtTjAnak.Text = (glg.TJ_Anak).ToString();
                    txtUangMakan.Text = (glg.Uang_Makan).ToString();
                    txtUangLembur.Text = (glg.Uang_Lembur).ToString();
                    txtAskes.Text = (glg.Askes).ToString();
                }
            }
        }

        private void txtTjAnak_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtUangMakan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtUangLembur_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtAskes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }
    }
}
