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
    public partial class frmLokasiKerja : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private Lokasi_KerjaDAO lkDAO = null;
        private bool resultBool = false;
        private int result = 0;

        //Constructor
        public frmLokasiKerja(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                //Dapatkan status conn.open() dari current sessi aplikasi hrd ini, yang mana conn.open() itu juga berisi string koneksi ke database / strSql.
                //Kemudian buat objek baru dari class Lokasi_KerjaDAO dengan diikuti oleh objek conn.open() ini.
                lkDAO = new Lokasi_KerjaDAO(conn.GetConnection());

                loadDataLokasiKerja();

                this.frmMU = frmMU;
                frmMUEnbDis(false);   
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmLokasiKerja_Constructor");
            }
                     
        }
        
        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : fLokjaFrm\nMethod : " + str2);
            statusStripLokjaPanel1("Telah terjadi error.", Color.Red);
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.hRDToolStripMenuItem.Enabled = ft;
        }

        private void loadDataLokasiKerja()
        {
            try
            {
                List<Lokasi_Kerja> daftarLokJa = lkDAO.GetAll();
                DGV.DataSource = daftarLokJa.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataLokasiKerja");
            }
        }

        private void statusStripLokjaPanel1(string strPanel1, System.Drawing.Color clr)
        {
            LokjaPanel1.Text = strPanel1;
            LokjaPanel1.ForeColor = clr;
            //LokjaPanel1.Font.Italic = fnt;   
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

        private void clearTextBox()
        {
            txtKodeLokasi.Clear();
            txtLokasi.Clear();

            txtKodeLokasi.Focus();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            try
            {
                frmMUEnbDis(true);
                this.Close();  
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnBatal_Click");
            }                      
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeLokasi.Text == "" || txtLokasi.Text == "")
                {
                    statusStripLokjaPanel1("Field Kode Lokasi dan Lokasi tidak boleh kosong !!!", Color.Yellow);
                }
                else
                {
                    Lokasi_Kerja lokJa = new Lokasi_Kerja();
                    lokJa.Kode_Lokasi = txtKodeLokasi.Text;
                    lokJa.Lokasi = txtLokasi.Text;

                    //Cek Record Lokasi Kerja apakah sudah ada atau belum, guna menentukan operasi
                    //Update atau Save
                    resultBool = lkDAO.cekRecord(txtKodeLokasi.Text);

                    if (resultBool == false) //Data Lokasi Kerja masih kosong jadi bisa disimpan
                    {

                        result = lkDAO.Save(lokJa);

                        if (result > 0)
                        {                            
                            statusStripLokjaPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();
                            txtKodeLokasi.Focus();
                            
                            loadDataLokasiKerja();
                        }
                        else
                        {
                            statusStripLokjaPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else //Meng-update data lokasi kerja
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Lokasi Kerja dengan Kode Lokasi = " + txtKodeLokasi.Text + " ?") == true)
                        {
                            result = lkDAO.Update(lokJa);

                            if (result > 0)
                            {                                
                                statusStripLokjaPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();
                                txtKodeLokasi.Focus();
                                
                                loadDataLokasiKerja();
                            }
                            else
                            {
                                statusStripLokjaPanel1("Data gagal diubah.", Color.Red);
                            }
                        }
                        else
                        {
                            clearTextBox();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnSimpan_Click");
            }
        }
                
        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtKodeLokasi.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtLokasi.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void btnubah_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeLokasi.Text == "" || txtLokasi.Text == "")
                {
                    statusStripLokjaPanel1("Field Kode Lokasi dan Lokasi tidak boleh kosong !!!", Color.Yellow);
                }
                else
                {
                    Lokasi_Kerja lokJa = new Lokasi_Kerja();
                    lokJa.Kode_Lokasi = txtKodeLokasi.Text;
                    lokJa.Lokasi = txtLokasi.Text;

                    
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnUbah_Click");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeLokasi.Text == "")
                {
                    statusStripLokjaPanel1("Tentukan Kode_Lokasi yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Lokasi Kerja dengan Kode \"" + txtKodeLokasi.Text + "\" ?") == true)
                    {
                        result = lkDAO.Delete(txtKodeLokasi.Text);

                        if (result > 0)
                        {
                            statusStripLokjaPanel1("Record Lokasi Kerja berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripLokjaPanel1("Record Lokasi Kerja gagal dihapus !!!", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataLokasiKerja();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
            
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
            statusStripLokjaPanel1("Standby", Color.Green);
        }

        private void frmLokasiKerja_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (frmMU.CountAllActiveChildForm() == 1)
                {
                    //MessageBox.Show("Jumlah ChildForm yang aktif = " + frmMU.CountAllActiveChildForm().ToString());
                    frmMU.toolStripMenuItem1.Enabled = true;
                }

                frmMUEnbDis(true);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmLokasiKerja_FormClosed");
            }
        }

        private void DGV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKodeLokasi.Focus();
            }
        }

        private void txtKodeLokasi_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtLokasi_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }
    }
}
