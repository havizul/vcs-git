﻿using System;
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
    public partial class frmStatusPajak : Form
    {
        //Variabel Global
        private frmMenuUtama frmMU = null;
        private Status_PajakDAO stPjDAO = null;
        private bool resultBool = false;
        private int result = 0;

        public frmStatusPajak(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                stPjDAO = new Status_PajakDAO(conn.GetConnection());

                loadDataStatusPajak();

                this.frmMU = frmMU;
                frmMUEnbDis(false);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmStatusPajak_Constructor");
            }
        }

        private void statusStripStatusPajakPanel1(string strPanel1, System.Drawing.Color clr)
        {
            statuspajakPanel1.Text = strPanel1;
            statuspajakPanel1.ForeColor = clr;
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmLevel\nMethod : " + str2);
            statusStripStatusPajakPanel1("Telah terjadi error.", Color.Red);
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.statusPajakToolStripMenuItem.Enabled = ft;
        }

        private void loadDataStatusPajak()
        {
            try
            {
                List<Status_Pajak> daftarStatusPajak = stPjDAO.GetAll();
                DGV.DataSource = daftarStatusPajak.ToArray();
                DGV.ReadOnly = true;

                //Set otomatis lebar kolom
                DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataStatusPajak");
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
            txtKodeStatusPajak.Clear();
            txtKeterangan.Clear();

            txtKodeStatusPajak.Focus();
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

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKodeStatusPajak.Text == "")
                {
                    statusStripStatusPajakPanel1("Field Kode Status Pajak tidak boleh kosong !!!", Color.Yellow);
                }
                else
                {
                    Status_Pajak stPj = new Status_Pajak();
                    stPj.Kode_Status_Pajak = txtKodeStatusPajak.Text;
                    stPj.Keterangan = txtKeterangan.Text;

                    //Cek Record Level apakah sudah ada atau belum, guna menentukan operasi
                    //Update atau Save
                    resultBool = stPjDAO.cekRecord(txtKodeStatusPajak.Text);

                    if (resultBool == false) //Data Level masih kosong jadi bisa disimpan
                    {

                        result = stPjDAO.Save(stPj);

                        if (result > 0)
                        {
                            statusStripStatusPajakPanel1("Data berhasil disimpan.", Color.Green);
                            clearTextBox();
                            txtKodeStatusPajak.Focus();

                            loadDataStatusPajak();
                        }
                        else
                        {
                            statusStripStatusPajakPanel1("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else //Meng-update data level
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Status Pajak dengan Kode = " + txtKodeStatusPajak.Text + " ?") == true)
                        {
                            result = stPjDAO.Update(stPj);

                            if (result > 0)
                            {
                                statusStripStatusPajakPanel1("Data berhasil diubah.", Color.Green);
                                clearTextBox();
                                txtKodeStatusPajak.Focus();

                                loadDataStatusPajak();
                            }
                            else
                            {
                                statusStripStatusPajakPanel1("Data gagal diubah.", Color.Red);
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
                if (txtKodeStatusPajak.Text == "")
                {
                    statusStripStatusPajakPanel1("Tentukan Kode_Status_Pajak yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Status Pajak dengan Kode \"" + txtKodeStatusPajak.Text + "\" ?") == true)
                    {
                        result = stPjDAO.Delete(txtKodeStatusPajak.Text);

                        if (result > 0)
                        {
                            statusStripStatusPajakPanel1("Record Level berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            statusStripStatusPajakPanel1("Record Level gagal dihapus !!!", Color.Red);
                        }
                    }
                    else
                    {
                        clearTextBox();
                    }

                    loadDataStatusPajak();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            txtKodeStatusPajak.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[0].Value.ToString();
            txtKeterangan.Text = DGV.Rows[DGV.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void linkLblClearText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearTextBox();
            statusStripStatusPajakPanel1("Standby", Color.Green);
        }

        private void frmStatusPajak_FormClosed(object sender, FormClosedEventArgs e)
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
                errorDBox(ex.Message.ToString(), "frmStatusPajak_FormClosed");
            }
        }

        private void txtKodeStatusPajak_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSimpan_Click(null, null);
            }
        }

        private void txtKeterangan_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    btnSimpan_Click(null, null);
            //}
        }

        private void DGV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
           // {
           //     txtKodeStatusPajak.Focus();
           // }
        }




    }
}
