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
    public partial class frmPendidikan : Form
    {
        //Variable Global
        const int init = 5;
        //private int id_pendidikan = 0;
        //private int ubah = 0;   //0 = Simpan, 1 = Ubah
        private string nik = string.Empty;
        private PendidikanDAO pdkDAO = null;

        private int result = 0;


        //Constructor
        public frmPendidikan(string nik, PendidikanDAO pdkDAO)
        {
            InitializeComponent();

            this.nik = nik;
            this.pdkDAO = pdkDAO;
        }

        private void frmPendidikan_Load(object sender, EventArgs e)
        {
            try
            {
                inisialisasiListView();

                fillTextBox();
                fillDaftarPendidikanToListView();

                txtNik.Text = nik;
            }
            catch(Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmPendidikan_load()");
            }
        }

        //Important method
        private void inisialisasiListView()
        {
            lvwInformasiPendidikan.View = System.Windows.Forms.View.Details;
            lvwInformasiPendidikan.FullRowSelect = true;
            lvwInformasiPendidikan.GridLines = true;

            lvwInformasiPendidikan.Columns.Add("ID", 40, HorizontalAlignment.Center);
            lvwInformasiPendidikan.Columns.Add("Jenjang", 60, HorizontalAlignment.Center);
            lvwInformasiPendidikan.Columns.Add("Jurusan", 120, HorizontalAlignment.Center);
            lvwInformasiPendidikan.Columns.Add("Lulus", 120, HorizontalAlignment.Center);
            lvwInformasiPendidikan.Columns.Add("Jenis Pendidikan", 100, HorizontalAlignment.Center);
            lvwInformasiPendidikan.Columns.Add("Lembaga", 0, HorizontalAlignment.Center);
            lvwInformasiPendidikan.Columns.Add("Tahun Masuk", 0, HorizontalAlignment.Center);
        }

        private iListener _listener;
        public virtual iListener Listener
        {
            set { _listener = value; }
        }
        
        //Extra method
        private void fillTextBox()
        {
            //MessageBox.Show("Memasuki pdkDAO.getInfoPendidikanByNik(nik);");
            List<Pendidikan> daftarPendidikan = pdkDAO.getInfoPendidikanByNik(nik);
            //MessageBox.Show("Selesai pdkDAO.getInfoPendidikanByNik(nik);");
            
            if (daftarPendidikan.Count > 0)
            {
                Pendidikan pdk = daftarPendidikan[0];

                txtJenjangPendidikan.Text = pdk.Jenjang_Pendidikan;
                txtLembaga.Text = pdk.Lembaga;
                txtJurusan.Text = pdk.Jurusan;
                txtTahuMasuk.Text = string.Format("{0:dd/MM/yyyy}", pdk.Tahun_masuk); //Convert.ToString(DateTime.ParseExact(pdk.Tahun_masuk.ToString(), "dd/MM/yyyy", null));
                txtTahunLulus.Text = string.Format("{0:dd/MM/yyyy}", pdk.Tahun_lulus); // Convert.ToString(DateTime.ParseExact(pdk.Tahun_lulus.ToString(), "dd/MM/yyyy", null));
                txtNik.Text = pdk.NIK;
                txtId.Text = pdk.Id_Pendidikan.ToString();

                if (pdk.Jenis_Pendidikan.Equals("Formal"))
                {
                    rbFormal.Checked = true;
                    rbNonFormal.Checked = false;
                }

                if (pdk.Jenis_Pendidikan.Equals("Non Formal"))
                {
                    rbFormal.Checked = false;
                    rbNonFormal.Checked = false;
                }
             }
        }

        private void fillTextBoxByItem(ListViewItem item)
        {
            if (item != null)
            {
                txtId.Text = item.SubItems[0].Text;
                txtJenjangPendidikan.Text = item.SubItems[1].Text;
                txtJurusan.Text = item.SubItems[2].Text;
                txtTahunLulus.Text = item.SubItems[3].Text;
                txtLembaga.Text = item.SubItems[5].Text;
                txtTahuMasuk.Text = item.SubItems[6].Text;

                if (item.SubItems[4].Text.Equals("Formal"))
                {
                    rbFormal.Checked = true;
                    rbNonFormal.Checked = false;
                }
                else if (item.SubItems[4].Text.Equals("Non Formal"))
                {
                    rbFormal.Checked = false;
                    rbNonFormal.Checked = true;
                }
            }   
        }

        private void FillToListView(Pendidikan pdk)
        {
            try
            {
                ListViewItem item = new ListViewItem(pdk.Id_Pendidikan.ToString());
                item.SubItems.Add(pdk.Jenjang_Pendidikan);
                item.SubItems.Add(pdk.Jurusan);
                item.SubItems.Add(string.Format("{0:dd/MM/yyyy}", pdk.Tahun_lulus));
                item.SubItems.Add(pdk.Jenis_Pendidikan);

                item.SubItems.Add(pdk.Lembaga);
                item.SubItems.Add(string.Format("{0:dd/MM/yyyy}", pdk.Tahun_masuk));

                lvwInformasiPendidikan.Items.Add(item);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "FillToListView");
            }
        }

        private void fillDaftarPendidikanToListView()
        {
            try
            {
                lvwInformasiPendidikan.Items.Clear();

                List<Pendidikan> daftarPendidikan = pdkDAO.getInfoPendidikanByNik(nik);

                foreach (Pendidikan pdk in daftarPendidikan)
                {
                    FillToListView(pdk);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "fillDaftarPendidikanToListView()");
            }
        }
        
        //Error Message
        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmInformasi_Pendidikan\nMethod : " + str2);
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

        private void lblMsgString(string msg, System.Drawing.Color clr)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = clr;
        }
              
 
        //Event Method
        private void txtTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwInformasiPendidikan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvwInformasiPendidikan.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvwInformasiPendidikan.SelectedItems[0];

                    fillTextBoxByItem(item);


                    //Update Main Form View
                    string[] data = new string[] { item.SubItems[6].Text, item.SubItems[3].Text, item.SubItems[5].Text }; //Tahun masuk, tahun lulus, lembaga
                    //fillTextBoxMainFormEM(data, init);

                    if (this._listener != null)
                    {
                        this._listener.Ok(data, init);
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "lvwKaryawan_SelectedIndexChanged");
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {                
                if (txtJenjangPendidikan.Text == "" || txtLembaga.Text == "" || txtJurusan.Text == "" || txtTahuMasuk.Text == "" || txtTahunLulus.Text == "")
                {
                    lblMsgString("Isi seluruh field yang disediakan !", Color.Yellow);
                }
                else if (rbNonFormal.Checked == false && rbFormal.Checked == false)
                {
                    lblMsgString("Pilih Jenis Pendidikan !", Color.Yellow);
                }
                else
                {
                    Pendidikan pdk = new Pendidikan();

                    pdk.NIK = txtNik.Text;
                    pdk.Jenjang_Pendidikan = txtJenjangPendidikan.Text;
                    pdk.Jurusan = txtJurusan.Text;
                    pdk.Lembaga = txtLembaga.Text;
                    pdk.Tahun_masuk = DateTime.ParseExact(txtTahuMasuk.Text.Trim(), "dd/MM/yyyy", null);
                    pdk.Tahun_lulus = DateTime.ParseExact(txtTahunLulus.Text.Trim(), "dd/MM/yyyy", null);
                 
                    if (rbFormal.Checked == true && rbNonFormal.Checked == false)
                    {
                        pdk.Jenis_Pendidikan = "Formal";
                    }
                    else if (rbFormal.Checked == false && rbNonFormal.Checked == true)
                    {
                        pdk.Jenis_Pendidikan = "Non Formal";
                    }
                    

                    if (txtId.Text == "") //Create Operation -> Save
                    {                        
                        //pdk.Id_Pendidikan = int.Parse(txtId.Text);
                        
                        result = pdkDAO.Save(pdk);

                        if (result > 0)
                        {
                            lblMsgString("Data berhasil disimpan.", Color.Green);

                            //fillTextBox();
                            fillDaftarPendidikanToListView();
                        }
                        else
                        {
                            lblMsgString("Data gagal disimpan !", Color.Yellow);
                        }
                    }
                    else    //Update Operation -> Edit
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah record Informasi Pendidikan dengan id : " + txtId.Text) == true)
                        {
                            pdk.Id_Pendidikan = int.Parse(txtId.Text);
                           
                            result = pdkDAO.Update(pdk);

                            if (result > 0)
                            {
                                lblMsgString("Data berhasil diubah.", Color.Green);

                                //fillTextBox();
                                fillDaftarPendidikanToListView();
                            }
                            else
                            {
                                lblMsgString("Data gagal diubah !", Color.Yellow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message, "btnSimpan_Click");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (msgBoxWarning("Anda yakin akan menghapus record dengan ID : " + txtId.Text + " ?") == true)
                {
                    result = pdkDAO.Delete(int.Parse(txtId.Text));

                    if (result > 0)
                    {
                        lblMsgString("Data berhasil dihapus.", Color.Green);

                        fillTextBox();
                        fillDaftarPendidikanToListView();
                    }
                    else
                    {
                        lblMsgString("Data gagal dihapus !", Color.Yellow);
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "brnHapus_Click");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtId.Clear();
            txtJenjangPendidikan.Clear();
            txtJurusan.Clear();
            txtTahuMasuk.Clear();
            txtTahunLulus.Clear();
            txtLembaga.Clear();
            rbFormal.Checked = false;
            rbNonFormal.Checked = false;
        }

        private void frmPendidikan_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._listener.setFlag(5);
        }
                
    }
}
