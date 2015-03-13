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
    public partial class frmDepartemen : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private DepartemenDAO deptDAO = null;
        private bool resultBool = false;
        private int result = 0;


        //Constructor
        public frmDepartemen(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {

                deptDAO = new DepartemenDAO(conn.GetConnection());

                loadDataDepartemen();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmDepartemen_Constructor");
            }
        }


        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmDepartemen\nMethod : " + str2);
            statusStripDeptPanel1("Telah terjadi Error.", Color.Red);
            
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.absensiToolStripMenuItem.Enabled = ft;
        }

        private void loadDataDepartemen()
        {
            try
            {
                List<Departemen> daftarDept = deptDAO.GetAll();
                DGV.DataSource = daftarDept.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataDepartemen");
            }
        }

        private void statusStripDeptPanel1(string strPanel1, System.Drawing.Color clr)
        {
            deptPanel1.Text = strPanel1;
            deptPanel1.ForeColor = clr;
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
            txtKodeDepartemen.Clear();
            txtNamaDepartemen.Clear();
            txtKodeDepartemen.Focus();
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
                errorDBox(ex.Message.ToString(), "btnBatal_Click");
            }              
        }

        private void frmDepartemen_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmDepartemen_FormClosed");
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeDepartemen.Text == "" || txtNamaDepartemen.Text == "")
                {
                    statusStripDeptPanel1("Field Kode_Departemen atau Nama_Departemen tidak boleh kosong !", Color.Yellow);
                }
                else
                {
                    Departemen dept = new Departemen();
                    dept.Kode_Departemen = txtKodeDepartemen.Text;
                    dept.Nama_Departemen = txtNamaDepartemen.Text;

                    //Cek Record tabel Departemen apakah sudah ada kode_departemen terkait ?
                    resultBool = deptDAO.cekRecord(txtKodeDepartemen.Text);

                    if (resultBool == false)
                    {
                        result = deptDAO.Save(dept);

                        if (result > 0)
                        {
                            statusStripDeptPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();

                            loadDataDepartemen();
                        }
                        else
                        {
                            statusStripDeptPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else   //Meng-update data departemen
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Departemen dengan Kode = " + txtKodeDepartemen.Text + " ?") == true)
                        {
                            result = deptDAO.Update(dept);

                            if (result > 0)
                            {
                                statusStripDeptPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();

                                loadDataDepartemen();
                            }
                            else
                            {
                                statusStripDeptPanel1("Data gagal diubah.", Color.Red);
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
                if (txtKodeDepartemen.Text == "")
                {
                    statusStripDeptPanel1("Tentukan Kode_Departemen yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Departemen dengan Kode \"" + txtKodeDepartemen.Text + "\" ?") == true)
                    {
                        result = deptDAO.Delete(txtKodeDepartemen.Text);

                        if (result > 0)
                        {
                            statusStripDeptPanel1("Data berhasil dihapus !", Color.Green);
                        }
                        else
                        {
                            statusStripDeptPanel1("Data gagal dihapus !", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataDepartemen();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
            
        }

        private void lblClearText_Click(object sender, EventArgs e)
        {
            clearTextBox();
            statusStripDeptPanel1("Standby.", Color.Green);
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtKodeDepartemen.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtNamaDepartemen.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void txtKodeDepartemen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtNamaDepartemen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                txtKodeDepartemen.Focus();
            }
        }
    }
}
