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
    public partial class frmIdentitas : Form
    {
        //Global Variable
        const int init = 6;
        private string nik = string.Empty;
        private IdentitasDAO idtDAO = null;

        private int result = 0;
        private bool resultBool = false;

        public frmIdentitas(string nik,IdentitasDAO idtDAO)
        {
            InitializeComponent();

            this.nik = nik;
            this.idtDAO = idtDAO;
        }

        private void frmIdentitas_Load(object sender, EventArgs e)
        {

            inisialisasiListView();

            txtNik.Text = nik;

            loadDataToListView();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJenisIdentitas.Text == "" || txtNoIdentitas.Text == "" || txtMasaBerlaku.Text == "")
                {
                    lblMsgStringM("Isi seluruh field yang disediakan !", Color.Yellow);
                }
                else
                {
                    Identitas idtC = idtDAO.getInfoIdentitasByNoIdentitas(txtNoIdentitas.Text); //Untuk mengecek record no identitas

                    Identitas idt = new Identitas();

                    idt.Nik = txtNik.Text;
                    idt.Nomor_Identitas = txtNoIdentitas.Text.Trim();
                    idt.Jenis_Identitas = txtJenisIdentitas.Text.Trim();
                    idt.Masa_Berlaku = DateTime.ParseExact(txtMasaBerlaku.Text.Trim(), "dd/MM/yyyy", null);

                    if (idtC == null)    //Record belum ada -> Simpan
                    {
                        //MessageBox.Show(txtNoIdentitas.Text + " ?");
                        //MessageBox.Show(txtNoIdentitas.Text.Trim() + " ?");
                        //MessageBox.Show(idt.Nomor_Identitas + " ?");
                        
                        result = idtDAO.Save(idt);

                        if (result > 0) //Operasi Save berhasil
                        {
                            lblMsgStringM("Data berhasil disimpan.", Color.Green);

                            loadDataToListView();

                            //Change information views in main form
                            string[] data = new string[] { idt.Nomor_Identitas, idt.Jenis_Identitas, string.Format("{0:dd/MM/yyyy}", idt.Masa_Berlaku) };
                            refreshMainFormView(data, init);
                        }
                        else
                        {
                            lblMsgStringM("Data gagal disimpan !", Color.Yellow);
                        }
                    }
                    else    //Record sudah ada -> Ubah
                    {
                        //MessageBox.Show("Anda yakin akan mengubah Informasi Identitas dengan No. Identitas : " + txtNoIdentitas.Text + " ?");
                        result = idtDAO.Update(idt);

                        if (result > 0) //Operasi Update berhasil
                        {
                            lblMsgStringM("Data berhasil di-update.", Color.Green);

                            loadDataToListView();

                            //Change informations viewing in main form
                            string[] data = new string[] { idt.Nomor_Identitas, idt.Jenis_Identitas, string.Format("{0:dd/MM/yyyy}", idt.Masa_Berlaku) };
                            refreshMainFormView(data, init);
                        }
                        else    //Operasi Update gagal
                        {
                            lblMsgStringM("Data gagal di-update.", Color.Red);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message, "btnSimpan_Click()");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoIdentitas.Text == "")
                {
                    lblMsgStringM("Tentukan Nomor Identitas yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Anda yakin akan menghapus record dengan Nomor Identitas : " + txtNoIdentitas.Text + " ?") == true)
                    {
                        result = idtDAO.Delete(txtNoIdentitas.Text);

                        if (result > 0)
                        {
                            lblMsgStringM("Data berhasil dihapus.", Color.Green);

                            loadDataToListView();

                            //Refresh main form view
                            string[] data = new string[] { "", "" };
                            refreshMainFormView(data, init);
                        }
                        else
                        {
                            lblMsgStringM("Data gagal dihapus !", Color.Yellow);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message, "btnHapus_Click");
            }
        }

        private void lvwIdentitas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwIdentitas.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwIdentitas.SelectedItems[0];

                fillTextBoxByItem(item);

                string[] data = new string[] { item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text };   //No Identitas, Jenis, Masa berlaku

                refreshMainFormView(data, init);
            }
        }

        //Extra Method
        private void loadDataToListView()
        {
            lvwIdentitas.Items.Clear();

            List<Identitas> dftIdentitas = idtDAO.getInfoIdentitasByNik(nik);

            foreach (Identitas idt in dftIdentitas)
            {
                FillToListView(idt);
            }
        }

        private void FillToListView(Identitas idt)
        {
            ListViewItem item = new ListViewItem(idt.Nomor_Identitas.Trim());
            item.SubItems.Add(idt.Jenis_Identitas);
            item.SubItems.Add(string.Format("{0:dd/MM/yyyy}", idt.Masa_Berlaku));
         
            lvwIdentitas.Items.Add(item);
        }

        private void inisialisasiListView()
        {
            try
            {
                lvwIdentitas.View = System.Windows.Forms.View.Details;
                lvwIdentitas.FullRowSelect = true;
                lvwIdentitas.GridLines = true;

                lvwIdentitas.Columns.Add("Nomor ID", 100, HorizontalAlignment.Left);
                lvwIdentitas.Columns.Add("Jenis", 55, HorizontalAlignment.Left);
                lvwIdentitas.Columns.Add("Berlaku", 70, HorizontalAlignment.Left);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "inisialisasiListView");
            }
        }

        private iListener _listener;
        public virtual iListener Listener
        {
            set { _listener = value; }
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmIdentitas\nMethod : " + str2);
        }

        private void lblMsgStringM(string msg, System.Drawing.Color clr)
        {
            lblMsgString.Text = msg;
            lblMsgString.ForeColor = clr;
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

        private void fillTextBoxByItem(ListViewItem item)
        {
            if (item != null)
            {
                txtNoIdentitas.Text = item.SubItems[0].Text;
                txtJenisIdentitas.Text = item.SubItems[1].Text;
                txtMasaBerlaku.Text = item.SubItems[2].Text;
            }
        }

        private void refreshMainFormView(string[] data, int init)
        {
            if (this._listener != null)
            {
                this._listener.Ok(data, init);
            }
        }

        private void frmIdentitas_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._listener.setFlag(6);
        }            
    }
}
