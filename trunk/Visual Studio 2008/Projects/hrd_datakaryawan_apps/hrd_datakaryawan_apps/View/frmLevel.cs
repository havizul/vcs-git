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
    public partial class frmLevel : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private LevelDAO lvDAO = null;
        private bool resultBool = false;
        private int result = 0;

        public frmLevel(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                lvDAO = new LevelDAO(conn.GetConnection());

                loadDataLevel();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmLevel_Constructor");
            }
        }

        private void statusStripLevelPanel1(string strPanel1, System.Drawing.Color clr)
        {
            levelPanel1.Text = strPanel1;
            levelPanel1.ForeColor = clr; 
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmLevel\nMethod : " + str2);
            statusStripLevelPanel1("Telah terjadi error.", Color.Red);
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.levelToolStripMenuItem.Enabled = ft;
        }

        private void loadDataLevel()
        {
            try
            {
                List<Level> daftarLevel = lvDAO.GetAll();
                DGV.DataSource = daftarLevel.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataLevel");
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
            txtKodeLevel.Clear();
            txtNamaLevel.Clear();

            txtKodeLevel.Focus();
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

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeLevel.Text == "" || txtNamaLevel.Text == "")
                {
                    statusStripLevelPanel1("Field Kode Level dan Nama Level tidak boleh kosong !!!", Color.Yellow);
                }
                else
                {
                    Level lv = new Level();
                    lv.Kode_Level = txtKodeLevel.Text;
                    lv.Nama_Level = txtNamaLevel.Text;

                    //Cek Record Level apakah sudah ada atau belum, guna menentukan operasi
                    //Update atau Save
                    resultBool = lvDAO.cekRecord(txtKodeLevel.Text);

                    if (resultBool == false) //Data Level masih kosong jadi bisa disimpan
                    {

                        result = lvDAO.Save(lv);

                        if (result > 0)
                        {
                            statusStripLevelPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();
                            txtKodeLevel.Focus();

                            loadDataLevel();
                        }
                        else
                        {
                            statusStripLevelPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else //Meng-update data level
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Lokasi Kerja dengan Kode Lokasi = " + txtKodeLevel.Text + " ?") == true)
                        {
                            result = lvDAO.Update(lv);

                            if (result > 0)
                            {
                                statusStripLevelPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();
                                txtKodeLevel.Focus();

                                loadDataLevel();
                            }
                            else
                            {
                                statusStripLevelPanel1("Data gagal diubah.", Color.Red);
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
            txtKodeLevel.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtNamaLevel.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeLevel.Text == "")
                {
                    statusStripLevelPanel1("Tentukan Kode_Level yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Level dengan Kode \"" + txtKodeLevel.Text + "\" ?") == true)
                    {
                        result = lvDAO.Delete(txtKodeLevel.Text);

                        if (result > 0)
                        {
                            statusStripLevelPanel1("Record Level berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripLevelPanel1("Record Level gagal dihapus !!!", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataLevel();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
        }

        private void linkLblClearText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearTextBox();
            statusStripLevelPanel1("Standby", Color.Green);
        }

        private void frmLevel_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmLevel_FormClosed");
            }
        }

        private void txtKodeLevel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtNamaLevel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                txtKodeLevel.Focus();
            }
        }
    }
}
