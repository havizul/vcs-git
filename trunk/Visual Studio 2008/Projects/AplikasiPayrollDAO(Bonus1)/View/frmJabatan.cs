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
    public partial class frmJabatan : Form
    {
        private JabatanDAO jbtDAO = null;

        //untuk menampung return value operasi CRUD
        private bool resultBool = false;
        private int result = 0;

        public frmJabatan(DBConnection conn)
        {
            InitializeComponent();

            //buat objek jbtDAO untuk mengakses operasi database
            jbtDAO = new JabatanDAO(conn.GetConnection());

            LoadDataJabatan(); //Tambahkan baris kode ini setelah membuat method LoadDataJabatan()
        }

        //Method LoadDataJabatan()
        private void LoadDataJabatan()
        {
            List<Jabatan> daftarJbt = jbtDAO.GetAll();
            DGV.DataSource = daftarJbt.ToArray();
            DGV.ReadOnly = true;
        }

        //Method msgInfo() dan msgInfo2()
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

        //Method membatalkan input data
        private void clearTextBox()
        {
            txtKodeJbt.Clear();
            txtNamaJbt.Clear();
            txtGajiPokok.Clear();
            txtTJJbt.Clear();

            txtKodeJbt.Focus();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        //Method menyimpan data Jabatan
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtKodeJbt.Text == "" || txtNamaJbt.Text == "" || txtGajiPokok.Text == "" || txtTJJbt.Text == "")
            {
                msgInfo("Data belum lengkap, lengkapi terlebih dahulu...");
            }
            else if(txtKodeJbt.Text.Length > 4 || txtNamaJbt.Text.Length > 20 || txtGajiPokok.Text.Length > 11 || txtTJJbt.Text.Length > 11)
            {
                msgInfo("Kode Jabatan Maks. 4 karakter\n Nama Jabatan Maks. 20 Karakter\n Gaji Pokok Maks. 11 digit angka\n Tunjangan Jabatan Maks. 11 digit angka");
            }
            else
            {
                Jabatan jbt = new Jabatan();

                jbt.Kode_Jabatan = txtKodeJbt.Text;
                jbt.Nama_Jabatan = txtNamaJbt.Text;
                jbt.Gaji_Pokok = int.Parse(txtGajiPokok.Text);
                jbt.TJ_Jabatan = int.Parse(txtTJJbt.Text);

                //cek record tabel Jabatan dengan kode record txtKodeJbt.text
                resultBool = jbtDAO.CheckRecords(txtKodeJbt.Text);
                
                if (resultBool == false)
                {
                    result = jbtDAO.Save(jbt);

                    if (result > 0)
                    {
                        txtKodeJbt.Focus();
                        msgInfo("Data Jabatan berhasil disimpan...");
                    }
                    else
                    {
                        msgInfo("Data Jabatan gagal disimpan...");
                    }
                }
                else
                {
                    if (msgInfo2("Sudah terdapat data dengan Kode Jabatan : " + txtKodeJbt.Text + ". Apakah anda akan meng-update data tersebut ?") == true)
                    {
                        result = jbtDAO.Update(jbt);

                        if (result > 0)
                        {
                            msgInfo("Data Jabatan dengan Kode Jabatan " + txtKodeJbt.Text + " berhasil di-update...");
                        }
                        else
                        {
                            msgInfo("Data Jabatan dengan Kode Jabatan " + txtKodeJbt.Text + " gagal di-update...");
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }
                }

                LoadDataJabatan();
            }
        }

        //Method untuk menghapus record data Jabatan
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtKodeJbt.Text == "")
            {
                msgInfo("Isi Kode Jabatan terlebih dahulu...");
            }
            else
            {
                if (msgInfo2("Apakah anda yakin akan menghapus data Jabatan dengan Kode Jabatan = " + txtKodeJbt.Text + " ?") == true)
                {
                    result = jbtDAO.Delete(txtKodeJbt.Text);

                    if (result > 0)
                    {
                        msgInfo("Data Jabatan dengan Kode Jabatan " + txtKodeJbt.Text + " berhasil dihapus...");
                    }
                    else
                    {
                        msgInfo("Data Jabatan dengan Kode Jabatan " + txtKodeJbt.Text + " gagal dihapus...");
                    }
                }
                else
                {
                    clearTextBox();
                }

                LoadDataJabatan();
            }
        }

        //Menutup Form Jabatan
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method ConvertToUpper() dan NumericOnly()
        private string ConvertToUpper(string kata)
        {
            return kata.ToUpper();
        }

        private bool NumericOnly(System.Windows.Forms.KeyPressEventArgs e)
        {
            string strValid = "012345678";

            if (strValid.IndexOf(e.KeyChar) < 0 && !(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                msgInfo("Masukkan Angka dengan jumlah maks. 11 digit !!!.");
                return true; //Not Valid
            }
            else
            {
                return false;
            }
        }

        //Kode untuk event KeyPress txtGajiPokok dan txtTJJbt
        private void txtGajiPokok_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void txtTJJbt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        //Kode untuk event PreviewKeyDown txtKodeJbt
        private void txtKodeJbt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtKodeJbt.Text = ConvertToUpper(txtKodeJbt.Text);
                Jabatan jbt = jbtDAO.GetByKodeJabatan(txtKodeJbt.Text);

                if (jbt != null)
                {
                    txtNamaJbt.Text = jbt.Nama_Jabatan;
                    txtGajiPokok.Text = (jbt.Gaji_Pokok).ToString();
                    txtTJJbt.Text = (jbt.Gaji_Pokok).ToString();
                }
            }
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtKodeJbt.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtNamaJbt.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtGajiPokok.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtTJJbt.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
        }

    }
}
