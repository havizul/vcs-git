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
    public partial class frmGrade : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private GradeDAO gdDAO = null;
        private bool resultBool = false;
        private int result = 0;

        public frmGrade(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                gdDAO = new GradeDAO(conn.GetConnection());

                loadDataGrade();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmGrade_Constructor");
            }
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.gradeToolStripMenuItem.Enabled = ft;                        
        }

        private void statusStripGdPanel1(string strPanel1, System.Drawing.Color clr)
        {
            gradePanel1.Text = strPanel1;
            gradePanel1.ForeColor = clr;
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmGrade\nMethod : " + str2);
            statusStripGdPanel1("Telah terjadi error.", Color.Red);
        }

        private void loadDataGrade()
        {
            try
            {
                List<Grade> daftarGd = gdDAO.GetAll();
                DGV.DataSource = daftarGd.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataGrade");
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
            txtKodeGrade.Clear();
            txtNamaGrade.Clear();

            txtKodeGrade.Focus();
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
                if (txtKodeGrade.Text == "")
                {
                    statusStripGdPanel1("Tentukan Kode Grade yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Grade dengan Kode \"" + txtKodeGrade.Text + "\" ?") == true)
                    {
                        result = gdDAO.Delete(txtKodeGrade.Text);

                        if (result > 0)
                        {
                            statusStripGdPanel1("Record Grade berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripGdPanel1("Record Grade gagal dihapus.", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataGrade();
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
                if (txtKodeGrade.Text == "" || txtNamaGrade.Text == "")
                {
                    statusStripGdPanel1("Field Kode Grade dan Nama Grade tidak boleh kosong !!!", Color.Yellow);
                }
                else
                {
                    Grade gd = new Grade();
                    gd.Kode_Grade = txtKodeGrade.Text;
                    gd.Nama_Grade = txtNamaGrade.Text;


                    resultBool = gdDAO.cekRecord(txtKodeGrade.Text);

                    if (resultBool == false) //Data Lokasi Kerja masih kosong jadi bisa disimpan
                    {
                        result = gdDAO.Save(gd);

                        if (result > 0)
                        {
                            statusStripGdPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();
                            txtKodeGrade.Focus();

                            loadDataGrade();
                        }
                        else
                        {
                            statusStripGdPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else //Meng-update data lokasi kerja
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Grade dengan Kode = " + txtKodeGrade.Text + " ?") == true)
                        {
                            result = gdDAO.Update(gd);

                            if (result > 0)
                            {
                                statusStripGdPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();
                                txtKodeGrade.Focus();

                                loadDataGrade();
                            }
                            else
                            {
                                statusStripGdPanel1("Data gagal diubah.", Color.Red);
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
                errorDBox(ex.Message.ToString(), "btn_SImpan_Click");
            }
        }

        private void lblClearText_Click(object sender, EventArgs e)
        {
            clearTextBox();
            statusStripGdPanel1("Standby", Color.Green);
        }

        private void frmGrade_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmGrade_FormClosed");
            }
        }

        private void txtKodeGrade_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtNamaGrade_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                txtKodeGrade.Focus();
            }
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtKodeGrade.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtNamaGrade.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }
    }
}
