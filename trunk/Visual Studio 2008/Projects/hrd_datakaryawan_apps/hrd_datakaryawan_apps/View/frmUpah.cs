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
    public partial class frmUpah : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private UpahDAO upDAO = null;
        private bool resultBool = false;
        private int result = 0;

        public frmUpah(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                upDAO = new UpahDAO(conn.GetConnection());

                loadDataUpah();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmUpah_Constructor");
            }
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.upahToolStripMenuItem.Enabled = ft;            
        }

        private void statusStripUPPanel1(string strPanel1, System.Drawing.Color clr)
        {
            upahPanel1.Text = strPanel1;
            upahPanel1.ForeColor = clr;
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmUpah\nMethod : " + str2);
            statusStripUPPanel1("Telah terjadi error.", Color.Red);
        }

        private void loadDataUpah()
        {
            try
            {
                List<Upah> daftarUP = upDAO.GetAll();
                DGV.DataSource = daftarUP.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataUpah");
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
            txtTipeUpah.Clear();

            txtKode.Focus();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if (frmMU.CountAllActiveChildForm() == 1)
                {
                    //MessageBox.Show("Jumlah ChildForm yang aktif = " + frmMU.CountAllActiveChildForm().ToString());
                    frmMU.toolStripMenuItem1.Enabled = true;
                }
                */
                //frmMUEnbDis(true);
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
                    statusStripUPPanel1("Tentukan Kode Upah yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Upah dengan Kode \"" + txtKode.Text + "\" ?") == true)
                    {
                        result = upDAO.Delete(txtKode.Text);

                        if (result > 0)
                        {
                            statusStripUPPanel1("Record Upah berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripUPPanel1("Record Upah gagal dihapus.", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataUpah();
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
                if (txtKode.Text == "" || txtTipeUpah.Text == "")
                {
                    statusStripUPPanel1("Field Kode dan Tipe Upah tidak boleh kosong !!!", Color.Yellow);
                }
                else
                {
                    Upah up = new Upah();
                    up.Kode_Upah = txtKode.Text;
                    up.Tipe_Upah = txtTipeUpah.Text;
                                        

                    resultBool = upDAO.cekRecord(txtKode.Text);

                    if (resultBool == false) //Data Lokasi Kerja masih kosong jadi bisa disimpan
                    {
                        result = upDAO.Save(up);

                        if (result > 0)
                        {
                            statusStripUPPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();
                            txtKode.Focus();

                            loadDataUpah();
                        }
                        else
                        {
                            statusStripUPPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else //Meng-update data lokasi kerja
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Upah dengan Kode = " + txtKode.Text + " ?") == true)
                        {
                            result = upDAO.Update(up);

                            if (result > 0)
                            {
                                statusStripUPPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();
                                txtKode.Focus();

                                loadDataUpah();
                            }
                            else
                            {
                                statusStripUPPanel1("Data gagal diubah.", Color.Red);
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

        private void frmUpah_Load(object sender, EventArgs e)
        {            
        }

        private void lblClearText_Click(object sender, EventArgs e)
        {
            clearTextBox();
            statusStripUPPanel1("Standby", Color.Green);
        }

        private void frmUpah_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmUpah_FormClosed");
            }
        }

        private void txtKode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtTipeUpah_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtKode.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtTipeUpah.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }
    }
}
