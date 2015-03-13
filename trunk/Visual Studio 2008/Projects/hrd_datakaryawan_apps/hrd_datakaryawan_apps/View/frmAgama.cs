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
    public partial class frmAgama : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private AgamaDAO agDAO = null;
        private bool resultBool = false;
        private int result = 0;

        public frmAgama(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                agDAO = new AgamaDAO(conn.GetConnection());

                loadDataAgama();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmAgama_Constructor");
            }
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.agamaToolStripMenuItem.Enabled = ft;

            /*
            if (frmMU.ActiveMdiChild != null)
            {
                frmMU.toolStripMenuItem1.Enabled = false;
            }
            else
            {
                frmMU.toolStripMenuItem1.Enabled = ft;
            }
            */
        }

        private void statusStripAgPanel1(string strPanel1, System.Drawing.Color clr)
        {
            agamaPanel1.Text = strPanel1;
            agamaPanel1.ForeColor = clr;
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmAgama\nMethod : " + str2);
            statusStripAgPanel1("Telah terjadi error.", Color.Red);
        }

        private void loadDataAgama()
        {
            try
            {
                List<Agama> daftarAg = agDAO.GetAll();
                DGV.DataSource = daftarAg.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataAgama");
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
            txtId.Clear();
            txtNamaAgama.Clear();
            txtId.Text = "Auto";

            txtId.Focus();
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

        private void lblClearText_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNamaAgama.Text == "")
                {
                    statusStripAgPanel1("Pilih daftar Agama yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Agama dengan Nama \"" + txtNamaAgama.Text + "\" ?") == true)
                    {
                        result = agDAO.Delete(int.Parse(txtId.Text));

                        if (result > 0)
                        {
                            statusStripAgPanel1("Daftar Agama berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripAgPanel1("Daftar Agama gagal dihapus.", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataAgama();
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
                Agama ag = null;

                if (txtNamaAgama.Text == "")
                {
                    statusStripAgPanel1("Field Agama tidak boleh kosong !!!", Color.Yellow);
                }
                else if (txtId.Text == "Auto")
                {
                    ag = new Agama();
                    //ag.Id_Agama = int.Parse(txtId.Text);
                    ag.Nama_Agama = txtNamaAgama.Text;

                    resultBool = agDAO.cekRecordNmAg(ag.Nama_Agama);

                    if (resultBool == false) //Data Lokasi Kerja masih kosong jadi bisa disimpan
                    {
                        result = agDAO.SaveAutoID(ag);

                        if (result > 0)
                        {
                            statusStripAgPanel1("Data berhasil disimpan.", Color.Green);
                            loadDataAgama();

                            clearTextBox();
                            txtNamaAgama.Focus();

                            
                        }
                        else
                        {
                            statusStripAgPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else
                    {
                        statusStripAgPanel1("Nama Agama sudah ada di daftar.", Color.Red);
                    }
                /*
                    else
                {
                    Agama ag = new Agama();
                    ag.Id_Agama = int.Parse(txtId.Text);
                    ag.Nama_Agama = txtNamaAgama.Text;

                    resultBool = agDAO.cekRecordNmAg(ag.Nama_Agama);

                    if (resultBool == false) //Data Lokasi Kerja masih kosong jadi bisa disimpan
                    {
                        result = agDAO.Save(ag);

                        if (result > 0)
                        {
                            statusStripAgPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();
                            txtNamaAgama.Focus();

                            loadDataAgama();
                        }
                        else
                        {
                            statusStripAgPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                 * */
                    
                    /*
                     
                     * */
                }
                
                else if (txtId.Text != "Auto")
                {
                    ag = new Agama();
                    ag.Id_Agama = int.Parse(txtId.Text);
                    ag.Nama_Agama = txtNamaAgama.Text;

                    //msgBoxWarning("Belum lewat agDAO.cekRecordIdAg(ag.Id_Agama). resultBool = " + resultBool.ToString());
                    resultBool = agDAO.cekRecordIdAg(ag.Id_Agama);
                    //msgBoxWarning("Sudah lewat agDAO.cekRecordIdAg(ag.Id_Agama). resultBool = " + resultBool.ToString());

                    if (resultBool == true) //Meng-update data lokasi kerja
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Agama dengan Id = " + txtId.Text + " ?") == true)
                        {
                            result = agDAO.Update(ag);

                            if (result > 0)
                            {
                                statusStripAgPanel1("Data berhasil diubah.", Color.Green);
                                loadDataAgama();

                                clearTextBox();
                                txtNamaAgama.Focus();                                
                            }
                            else
                            {
                                statusStripAgPanel1("Data gagal diubah.", Color.Red);
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
            txtId.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtNamaAgama.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void frmAgama_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmAgama_FormClosed");
            }
        }

        private void txtNamaAgama_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                txtNamaAgama.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {                
                result = agDAO.ResetCount();

                if (result > 0)
                {
                    statusStripAgPanel1("Counter Id gagal di Reset.", Color.Red);                    
                }
                else
                {
                    statusStripAgPanel1("Counter Id berhasil di Reset.", Color.Green);
                    clearTextBox();
                    txtNamaAgama.Focus();  
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "lblResetId_Click");
            }
            
        }

        private void frmAgama_Load(object sender, EventArgs e)
        {

        }


    }
}
