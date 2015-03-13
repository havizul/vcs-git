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
    public partial class frmJabatan : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private JabatanDAO jbtDAO = null;
        private bool resultBool = false;
        private int result = 0;

        //Constructor
        public frmJabatan(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {

                jbtDAO = new JabatanDAO(conn.GetConnection());

                loadDataJabatan();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmJabatan_Constructor");
            }
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmJabatan\nMethod : " + str2);
            statusStripJbtPanel1("Telah terjadi Error.", Color.Red);

        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.gajiToolStripMenuItem.Enabled = ft;
        }

        private void loadDataJabatan()
        {
            try
            {
                List<Jabatan> daftarJbt = jbtDAO.GetAll();
                DGV.DataSource = daftarJbt.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataJabatan");
            }
        }

        private void statusStripJbtPanel1(string strPanel1, System.Drawing.Color clr)
        {
            jbtPanel1.Text = strPanel1;
            jbtPanel1.ForeColor = clr;
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
            txtKodeJabatan.Clear();
            txtNamaJabatan.Clear();
            txtKodeJabatan.Focus();
        }

        private void frmJabatan_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmJabatan_FormClosed");
            }
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
                errorDBox(ex.Message.ToString(), "frmJabatan_FormClosed");
            }
        }

        private void lblClearText_Click(object sender, EventArgs e)
        {
            clearTextBox();
            statusStripJbtPanel1("Standby.", Color.Green);

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeJabatan.Text == "" || txtNamaJabatan.Text == "")
                {
                    statusStripJbtPanel1("Field Kode_Jabatan dan Nama_Jabatan tidak boleh kosong !", Color.Yellow);
                }
                else
                {
                    Jabatan jbt = new Jabatan();
                    jbt.Kode_Jabatan = txtKodeJabatan.Text;
                    jbt.Nama_Jabatan = txtNamaJabatan.Text;

                    //Cek Record Tabel Jabatan untuk menentukan apakah operasi Save atau Update yang akan dilakukan
                    resultBool = jbtDAO.cekRecord(txtKodeJabatan.Text);

                    if (resultBool == false)
                    {
                        result = jbtDAO.Save(jbt);

                        if (result > 0)
                        {
                            statusStripJbtPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();

                            loadDataJabatan();
                        }
                        else
                        {
                            statusStripJbtPanel1("Data gagal disimpan !", Color.Red);
                        }
                    }
                    else
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Jabatan dengan Kode = " + jbt.Kode_Jabatan.ToString() + " ?") == true)
                        {
                            result = jbtDAO.Update(jbt);

                            if (result > 0)
                            {
                                statusStripJbtPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();

                                loadDataJabatan();
                            }
                            else
                            {
                                statusStripJbtPanel1("Data gagal diubah.", Color.Red);
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeJabatan.Text == "")
                {
                    statusStripJbtPanel1("Tentukan Kode Jabatan yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data jabatan dengan Kode \"" + txtKodeJabatan.Text + "\" ?") == true)
                    {
                        result = jbtDAO.Delete(txtKodeJabatan.Text);

                        if (result > 0)
                        {
                            statusStripJbtPanel1("Data berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripJbtPanel1("Data gagal dihapus.", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataJabatan();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }            
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtKodeJabatan.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtNamaJabatan.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void txtKodeJabatan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtNamaJabatan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                txtKodeJabatan.Focus();
            }
        }
    }
}
