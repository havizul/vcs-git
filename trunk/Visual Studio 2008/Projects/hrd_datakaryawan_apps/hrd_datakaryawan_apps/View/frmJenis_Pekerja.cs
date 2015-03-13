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
    public partial class frmJenis_Pekerja : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private Jenis_PekerjaDAO jpDAO = null;
        private bool resultBool = false;
        private int result = 0;
        
        public frmJenis_Pekerja(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                jpDAO = new Jenis_PekerjaDAO(conn.GetConnection());

                loadDataJenisPekerja();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmJenisPekerja_Constructor");
            }
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.jenisPekerjaToolStripMenuItem.Enabled = ft;
        }

        private void statusStripJPPanel1(string strPanel1, System.Drawing.Color clr)
        {
            jenisPekPanel1.Text = strPanel1;
            jenisPekPanel1.ForeColor = clr;
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmJenisPekerja\nMethod : " + str2);
            statusStripJPPanel1("Telah terjadi error.", Color.Red);
        }

        private void loadDataJenisPekerja()
        {
            try
            {
                List<Jenis_Pekerja> daftarJP = jpDAO.GetAll();
                DGV.DataSource = daftarJP.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataJenisPekerja");
            }
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
            txtKode.Clear();
            txtJenisPekerja.Clear();

            txtKode.Focus();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            try
            {
                frmMUEnbDis(true);
                this.Close();
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnTutup_Click");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKode.Text == "")
                {
                    statusStripJPPanel1("Tentukan Kode_Jenis_Pekerja yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Jenis Pekerja dengan Kode \"" + txtKode.Text + "\" ?") == true)
                    {
                        result = jpDAO.Delete(txtKode.Text);

                        if (result > 0)
                        {
                            statusStripJPPanel1("Record Jenis Pekerja berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripJPPanel1("Record Jenis Pekerja gagal dihapus.", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataJenisPekerja();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKode.Text == "" || txtJenisPekerja.Text == "")
                {
                    statusStripJPPanel1("Field Kode dan Jenis Pekerja tidak boleh kosong !!!", Color.Yellow);
                }
                else
                {
                    Jenis_Pekerja jp = new Jenis_Pekerja();
                    jp.Kode_Jenis_Pekerja = txtKode.Text;
                    jp.Nama_Jenis_Pekerja = txtJenisPekerja.Text;
                                        
                    resultBool = jpDAO.cekRecord(txtKode.Text);

                    if (resultBool == false) //Data Lokasi Kerja masih kosong jadi bisa disimpan
                    {

                        result = jpDAO.Save(jp);

                        if (result > 0)
                        {
                            statusStripJPPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();
                            txtKode.Focus();

                            loadDataJenisPekerja();
                        }
                        else
                        {
                            statusStripJPPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else //Meng-update data lokasi kerja
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Jenis Pekerja dengan Kode = " + txtKode.Text + " ?") == true)
                        {
                            result = jpDAO.Update(jp);

                            if (result > 0)
                            {
                                statusStripJPPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();
                                txtKode.Focus();

                                loadDataJenisPekerja();
                            }
                            else
                            {
                                statusStripJPPanel1("Data gagal diubah.", Color.Red);
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
            txtKode.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtJenisPekerja.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void lblClearText_Click(object sender, EventArgs e)
        {
            clearTextBox();
            statusStripJPPanel1("Standby", Color.Green);
        }

        private void frmJenis_Pekerja_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmJenisPekerja_FormClosed");
            }
        }

        private void txtJenisPekerja_Enter(object sender, EventArgs e)
        {
            //msgBoxWarning("TEST TOMBOL ENTER PRESS");
        }

        private void txtJenisPekerja_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtKode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void DGV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKode.Focus();
            }
        }
    }
}
