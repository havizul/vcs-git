using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using hrd_datakaryawan_apps.Model;
using hrd_datakaryawan_apps.DAO;

namespace hrd_datakaryawan_apps.View
{
    public partial class frmInformasi_Kontak : Form
    {
        //Global Variable
        const int init = 4;
        private int id_inform_kontak = 0;
        private string nik = string.Empty;
        private string nama = string.Empty;
        private Informasi_KontakDAO iknDAO = null;
        private Informasi_Kontak dftInfoKontak = null;

        private bool resultBool = false;
        private int result = 0;
        
        public frmInformasi_Kontak(string nik, string nama, Informasi_KontakDAO iknDAO)
        {
            InitializeComponent();

            this.nik = nik;
            this.nama = nama;
            this.iknDAO = iknDAO;
        }

        private iListener _listener;
        public virtual iListener Listener
        {
            set { _listener = value; }
        }

        private void refreshMainFormView(object[] data, int genIntNumb, int init)
        {
            if (this._listener != null)
            {
                this._listener.Ok(data, 0, init);
            }
        }

        private void refreshMainFormView(string[] data, int init)
        {
            if (this._listener != null)
            {
                this._listener.Ok(data, init);
            }
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmInformasi_Kontak\nMethod : " + str2);
            //statusStripLevelPanel1("Telah terjadi error.", Color.Red);
        }

        private void lblMsgStringM(string msg, System.Drawing.Color clr)
        {
            lblMsgStr.Text = msg;
            lblMsgStr.ForeColor = clr;
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
            txtNoKontak.Clear();

            rbHandphone.Checked = false;
            rbTelpon.Checked = false;
        }

        private void inisialisasiListView()
        {
            try
            {
                lvwInfoKontak.View = System.Windows.Forms.View.Details;
                lvwInfoKontak.FullRowSelect = true;
                lvwInfoKontak.GridLines = true;

                lvwInfoKontak.Columns.Add("ID", 35, HorizontalAlignment.Left);
                lvwInfoKontak.Columns.Add("Nomor Kontak", 130, HorizontalAlignment.Left);
                lvwInfoKontak.Columns.Add("Jenis Kontak", 75, HorizontalAlignment.Left);

            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "inisialisasiListView");
            }
        }

        private void FillToListView(Informasi_Kontak infoKontak)
        {
            try
            {
                ListViewItem item = new ListViewItem(infoKontak.Id_Inform_Kontak.ToString());
                item.SubItems.Add(infoKontak.Nomor_Kontak);
                item.SubItems.Add(infoKontak.Jenis_Kontak);

                lvwInfoKontak.Items.Add(item);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "FillToListView");
            }
        }

        private void loadListViewInfoKontak()
        {
            try
            {
                lvwInfoKontak.Items.Clear();
                List<Informasi_Kontak> daftarIkn = iknDAO.getByNIK(nik);

                foreach (Informasi_Kontak infoKontak in daftarIkn)
                {
                    FillToListView(infoKontak);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadListViewInfoKontak");
            }
        }

        private void frmInformasi_Kontak_Load(object sender, EventArgs e)
        {
            inisialisasiListView();
            loadListViewInfoKontak();

            txtNama.Text = nama;
            txtNIK.Text = nik;
                        
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoKontak.Text == "")
                {
                    lblMsgStringM("Nomor Kontak belum diisi !", Color.Yellow);
                }
                else if (rbHandphone.Checked == false && rbTelpon.Checked == false)
                {
                    lblMsgStringM("Pilih jenis kontak !", Color.Yellow);
                }
                else if (rbUbah.Checked == false && rbTambah.Checked == false)
                {
                    lblMsgStringM("Pilih operasi Ubah / Tambah !", Color.Yellow);
                }
                else
                {
                    Informasi_Kontak ikn = new Informasi_Kontak();

                    ikn.NIK = txtNIK.Text;
                    ikn.Nomor_Kontak = txtNoKontak.Text;
                    ikn.Id_Inform_Kontak = this.id_inform_kontak;

                    if (rbHandphone.Checked == true && rbTelpon.Checked == false)
                    {
                        ikn.Jenis_Kontak = "Handphone";
                    }

                    if (rbHandphone.Checked == false && rbTelpon.Checked == true)
                    {
                        ikn.Jenis_Kontak = "Telpon";
                    }

                    object[] data = new object[] { ikn.Jenis_Kontak, ikn.Nomor_Kontak };

                    if (rbTambah.Checked == true && rbUbah.Checked == false)    //Operasi Penambahan Record
                    {
                        resultBool = iknDAO.cekRecord(txtNIK.Text, txtNoKontak.Text);

                        //MessageBox.Show("resultBool = " + resultBool.ToString() + ".\nFalse = Record kosong. True = Record Exist");

                        if (resultBool == false)    //Simpan data, karena record masih kosong
                        {
                            result = iknDAO.Save(ikn);

                            if (result > 0)
                            {
                                lblMsgStringM("Data berhasil disimpan.", Color.Green);
                                loadListViewInfoKontak();
                                refreshMainFormView(data, 0, init);
                            }
                            else
                            {
                                lblMsgStringM("Data gagal disimpan !", Color.Red);
                                loadListViewInfoKontak();
                                refreshMainFormView(data, 0, init);
                            }
                        }
                        else   //Meng-update data informasi kontak
                        {
                            lblMsgStringM("Nomor Kontak sudah ada.\nSilahkan masukkan Nomor yang lain !", Color.Yellow);
                        }
                    }

                    if (rbTambah.Checked == false && rbUbah.Checked == true)    //Operasi Pengubahan Record
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah informasi kontak dengan ID = " + id_inform_kontak + "?") == true)
                        {
                            result = iknDAO.Update(ikn);

                            if (result > 0)
                            {
                                lblMsgStringM("Data berhasil diubah.", Color.Green);
                                loadListViewInfoKontak();
                            }
                            else
                            {
                                lblMsgStringM("Data gagal diubah !", Color.Red);
                            }
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
                if (msgBoxWarning("Anda yakin akan menghapus Nomor Kontak " + txtNoKontak.Text.Trim() + " ?") == true)
                {
                    result = iknDAO.Delete(id_inform_kontak);

                    if (result > 0)
                    {
                        string[] data = new string[] { "", "" };

                        lblMsgStringM("Nomor Kontak berhasil dihapus.", Color.Green);
                        loadListViewInfoKontak();
                        //refreshMainFormView(data, 0, init);

                        if (this._listener != null)
                        {
                            this._listener.Ok(data, init);
                        }
                    }
                    else
                    {
                        lblMsgStringM("Nomor Kontak gagal dihapus !", Color.Yellow);
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
        }
        
        //Extra Method
        private void fillTextBox(ListViewItem item)
        {
            if (item != null)
            {
                id_inform_kontak = int.Parse(item.SubItems[0].Text);
                txtNoKontak.Text = item.SubItems[1].Text;

                if (item.SubItems[2].Text.Equals("HP") || item.SubItems[2].Text.Equals("Handphone"))
                {
                    rbHandphone.Enabled = true;
                    rbHandphone.Checked = true;

                    rbTelpon.Enabled = true;
                    rbTelpon.Checked = false;
                }
                else if (item.SubItems[2].Text.Equals("Telpon"))
                {
                    rbHandphone.Enabled = true;
                    rbHandphone.Checked = false;

                    rbTelpon.Enabled = true;
                    rbTelpon.Checked = true;
                }
            }
        }

        private void lvwInfoKontak_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvwInfoKontak.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvwInfoKontak.SelectedItems[0];
                    fillTextBox(item);

                    string[] data = new string[] { item.SubItems[1].Text, item.SubItems[2].Text };
                    refreshMainFormView(data, init);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "lvwInfoKontak_SelectedIndexChanged()");
            }
        }

        private void frmInformasi_Kontak_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._listener.setFlag(4);
        }
        
    }
}
