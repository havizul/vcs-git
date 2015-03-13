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
    public partial class frmInformasi_Email : Form
    {
        //Variabel Global
        const int init = 2;
        private string nik = null;
        private frmListAllInformasiEmail fLAIE = null;

        private Informasi_EmailDAO iemDAO = null;
        private List<Informasi_Email> daftarEmail = null;
        //private List<int> jmlEmail = null;

        private bool resultBool = false;
        private int result = 0;

        private bool ubah = false;

        public frmInformasi_Email(string nik, Informasi_EmailDAO iemDAO)
        {
            InitializeComponent();

            this.nik = nik;
            this.iemDAO = iemDAO;
        }

        private iListener _listener;
        public virtual iListener Listener
        {
            set { _listener = value; }
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmInformasi_Email\nMethod : " + str2);
            //statusStripLevelPanel1("Telah terjadi error.", Color.Red);
        }

        private void lblMsgString(string msg, System.Drawing.Color clr)
        {
            lblMsg.Text = msg;
            lblMsg.ForeColor = clr;
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
        
        private void fillTextBox()
        {
            daftarEmail = iemDAO.GetByNIK(txtNIK.Text);

            if (daftarEmail.Count > 0)
            {
                Informasi_Email iem = daftarEmail[0];
                                
                txtAlamatEmailSekarang.Text = iem.Alamat_Email;                
                txtAlamatEmailBaru.Text = "";
                cmbKepemilikanEmail.Text = iem.Kepemilikan_Email;

                txtAlamatEmailBaru.Focus();
            }
            else
            {
                txtAlamatEmailSekarang.Clear();
                txtAlamatEmailBaru.Clear();
                cmbKepemilikanEmail.Text = null;

                lblTambahEmail.Focus();
            }  
        }

        private void fillTextBox(ListViewItem item)
        {
            if (item != null)
            {
                if (this.ubah == false)
                {
                    txtAlamatEmailSekarang.Text = item.SubItems[1].Text;
                    txtAlamatEmailBaru.Text = "";
                    cmbKepemilikanEmail.SelectedItem = item.SubItems[2].Text;
                }
                else
                {
                    txtAlamatEmailSekarang.Text = item.SubItems[1].Text;
                    txtAlamatEmailBaru.Text = txtAlamatEmailSekarang.Text;
                    cmbKepemilikanEmail.SelectedItem = item.SubItems[2].Text;
            
                }
            }   
        }

        private void fillTextBox(Informasi_Email iem)
        {
            txtNIK.Text = iem.NIK;
            txtAlamatEmailSekarang.Text = iem.Alamat_Email;         
            txtAlamatEmailBaru.Text = "";
            cmbKepemilikanEmail.SelectedItem = iem.Kepemilikan_Email.ToString();                   
        }
         
        private void fillTextBoxMainForm(object[] data, int genIntNumb, int init)
        {
            if (this._listener != null)
            {
                this._listener.Ok(data, genIntNumb, init);
                //this._listener.Ok(data, ukuranPakaian, infoEmail, jmlEmail, infoResign);
            }            
        }

        private void fillTextBoxMainFormEM(string[] data, int init)
        {
            if (this._listener != null)
            {
                this._listener.Ok(data, init);
            }
        }

        private void clearTextBox()
        {
            txtAlamatEmailSekarang.Clear();
            txtAlamatEmailBaru.Clear();
            cmbKepemilikanEmail.Text = null;

            txtAlamatEmailSekarang.Focus();
        }

        private void loadListViewEmail()
        {
            try
            {
                lvwInformasiEmail.Items.Clear();

                List<Informasi_Email> daftarIem = iemDAO.GetAll();

                foreach (Informasi_Email email in daftarIem)
                {
                    FillToListView(email);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataKaryawan");
            }
        }

        private void loadDaftarEmailByNik(string nik)
        {
            try
            {
                lvwInformasiEmail.Items.Clear();

                daftarEmail = iemDAO.GetByNIK(nik);

                foreach (Informasi_Email iem in daftarEmail)
                {
                    FillToListView(iem);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDaftarEmailByNik");
            }
        }

        private void inisialisasiListView()
        {
            try
            {
                lvwInformasiEmail.View = System.Windows.Forms.View.Details;
                lvwInformasiEmail.FullRowSelect = true;
                lvwInformasiEmail.GridLines = true;

                lvwInformasiEmail.Columns.Add("ID", 40, HorizontalAlignment.Left);
                lvwInformasiEmail.Columns.Add("Alamat Email", 160, HorizontalAlignment.Left);
                lvwInformasiEmail.Columns.Add("Kepemilikan", 90, HorizontalAlignment.Left);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "inisialisasiListView");
            }
        }

        private void FillToListView(Informasi_Email email)
        {
            try
            {
                //int noUrut = lvwInformasiEmail.Items.Count + 1;

                ListViewItem item = new ListViewItem(email.Id.ToString());
                //item.SubItems.Add(email.Id.ToString());
                item.SubItems.Add(email.Alamat_Email);
                item.SubItems.Add(email.Kepemilikan_Email);

                lvwInformasiEmail.Items.Add(item);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "FillToListView");
            }
        }

        private int countJmlEmailByNIK(string nik)
        {
            daftarEmail = iemDAO.GetByNIK(nik);  //Untuk menghitung jumlah email
            
            int jmlEmail = daftarEmail.Count();

            return jmlEmail;
        }

        private void setTextBoxEmail(bool ubahEmail, bool tambahEmail)
        {
            if (ubahEmail == false && tambahEmail == false) //Normal 
            {
                //Set TextBox Alamat Email
                lblEmailLama.Text = "Alamat Email";
                lblEmailLama.Location = new Point(37, 74);
                txtAlamatEmailSekarang.ReadOnly = true;

                lblEmailBaru2.Visible = false;
                txtAlamatEmailBaru.ReadOnly = true;
            }
           
            if (ubahEmail == true) //Ubah Email
            {
                //Set TextBox Alamat Email
                lblEmailLama.Text = "Email Lama";
                lblEmailLama.Location = new Point(43, 74);
                txtAlamatEmailSekarang.ReadOnly = true;

                lblEmailBaru2.Visible = true;
                txtAlamatEmailBaru.ReadOnly = false;
                txtAlamatEmailBaru.Text = txtAlamatEmailSekarang.Text;
            }
            
            if (tambahEmail == true)   //Tambah Email
            {
                //Set TextBox Alamat Email
                lblEmailLama.Text = "Alamat Email";
                lblEmailLama.Location = new Point(37, 74);
                txtAlamatEmailSekarang.ReadOnly = false;

                lblEmailBaru2.Visible = false;
                txtAlamatEmailBaru.ReadOnly = true;
                txtAlamatEmailBaru.Text = "";
            }
                        
        }

        private void frmInformasi_Email_Load(object sender, EventArgs e)
        {
            inisialisasiListView();

            try
            {
                txtNIK.Text = nik;
                
                fillTextBox();
                loadDaftarEmailByNik(txtNIK.Text);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmInformasi_Email_Load()");
            }

            setTextBoxEmail(false, false);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (txtAlamatEmailSekarang.ReadOnly == true && txtAlamatEmailBaru.ReadOnly == true)
                {
                    lblMsgString("Klik Ubah untuk mengubah data. Dan klik Tambah untuk menambah data.", Color.Yellow);
                }
                else 
                {
                    Informasi_Email iem = new Informasi_Email();                                     

                    if (txtAlamatEmailSekarang.ReadOnly == false && txtAlamatEmailBaru.ReadOnly == true) //Tambah
                    {
                        if (txtAlamatEmailSekarang.Text == "" || cmbKepemilikanEmail.Text == "") //Field harus diisi
                        {
                            lblMsgString("Field Alamat Email dan Kepemilikan Email harus diisi !", Color.Yellow);
                        }
                        else
                        {
                            //MessageBox.Show("iemDAO.cekRecord(" + txtAlamatEmailSekarang.Text + ", " + txtNIK.Text + ")");                            
                            resultBool = iemDAO.cekRecord(txtAlamatEmailSekarang.Text, txtNIK.Text);
                            //MessageBox.Show("resultBool = " + resultBool.ToString());

                            //MessageBox.Show("Enter Method : resultIEM = iemDAO.cekRecordIEM(txtAlamatEmailSekarang.Text, txtNIK.Text);");
                            //Informasi_Email resultIEM = iemDAO.cekRecordIEM(txtAlamatEmailSekarang.Text, txtNIK.Text);
                            //MessageBox.Show("Alamat Email Hasil Cek yang didapat = " + resultIEM.Alamat_Email);
                                                  

                            if (resultBool == false)  //Record belum ada, maka tambahkan ke database
                            {
                                iem.NIK = txtNIK.Text;
                                iem.Alamat_Email = txtAlamatEmailSekarang.Text;
                                iem.Kepemilikan_Email = cmbKepemilikanEmail.Text;

                                object[] data = new object[] { iem.Alamat_Email, iem.Kepemilikan_Email };

                                //resultBool = iemDAO.cekRecord(txtAlamatEmailBaru.Text, txtNIK.Text);

                                result = iemDAO.Save(iem);

                                if (result > 0)
                                {
                                    lblMsgString("Data berhasil disimpan.", Color.Green);
                                    //fillTextBox(iem);
                                    loadDaftarEmailByNik(txtNIK.Text);

                                    int jmlEmail = countJmlEmailByNIK(txtNIK.Text);

                                    fillTextBoxMainForm(data, jmlEmail, init);

                                    //Update View neighbor form
                                    if (fLAIE != null)
                                    {
                                        fLAIE.refreshEmailList();
                                    }
                                                                        
                                }
                                else
                                {
                                    lblMsgString("Data gagal disimpan.", Color.Red);
                                }
                            }
                            else
                            {
                                lblMsgString("Alamat Email sudah ada !", Color.Yellow);
                            }
                        }
                    }
                    else if (txtAlamatEmailSekarang.ReadOnly == true && txtAlamatEmailBaru.ReadOnly == false) //Ubah / Update
                    {                           
                        if (cmbKepemilikanEmail.Text == "") //Field harus diisi
                        {
                            lblMsgString("Informasi kepemilikan email harus diisi !", Color.Yellow);
                        }
                        else
                        {
                            if (msgBoxWarning("Anda yakin akan mengubah data Email Karyawan dengan NIK = " + txtNIK.Text + " ?") == true)
                            {
                                if (txtAlamatEmailSekarang.Text == "") //Field harus isi
                                {
                                    lblMsgString("Field Alamat Email Lama tidak boleh kosong !", Color.Yellow);
                                }
                                else
                                {
                                    if (txtAlamatEmailBaru.Text == "")
                                    {
                                        iem.NIK = txtNIK.Text;
                                        iem.Alamat_Email = txtAlamatEmailSekarang.Text;
                                        iem.Kepemilikan_Email = cmbKepemilikanEmail.Text;
                                    }
                                    else
                                    {
                                        iem.NIK = txtNIK.Text;
                                        iem.Alamat_Email = txtAlamatEmailBaru.Text;
                                        iem.Kepemilikan_Email = cmbKepemilikanEmail.Text;
                                    }

                                    object[] data = new object[] { iem.Alamat_Email, iem.Kepemilikan_Email };

                                    result = iemDAO.Update(iem, txtAlamatEmailSekarang.Text);

                                    if (result > 0)
                                    {
                                        lblMsgString("Data berhasil diubah.", Color.Green);
                                        //fillTextBox(iem);

                                        int jmlEmail = countJmlEmailByNIK(txtNIK.Text);
                                        fillTextBoxMainForm(data, jmlEmail, init);

                                        loadDaftarEmailByNik(txtNIK.Text);

                                        //Refress Email List On Neighbor Form
                                        if (fLAIE != null)
                                        {
                                            fLAIE.refreshEmailList();
                                        }
                                    }
                                    else
                                    {
                                        lblMsgString("Data gagal diubah.", Color.Red);
                                    }                                   
                                }  
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

        private void btnUP_Click(object sender, EventArgs e)
        {
            try
            {
                int noUrut = int.Parse(txtAlamatEmailSekarang.Text);
                string noUrutBaru = (noUrut + 1).ToString();

                txtAlamatEmailSekarang.Text = noUrutBaru;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnUP_Click");
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int noUrut = int.Parse(txtAlamatEmailSekarang.Text);

                if (noUrut < 2)
                {
                    //string noUrutBaru = Convert.ToString(1);
                    string noUrutBaru = noUrut.ToString();

                    txtAlamatEmailSekarang.Text = noUrutBaru;
                }
                else
                {
                    string noUrutBaru = (noUrut - 1).ToString();

                    txtAlamatEmailSekarang.Text = noUrutBaru;
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnUP_Click");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (msgBoxWarning("Apakah anda yakin akan menghapus Email \"" + txtAlamatEmailSekarang.Text + "\" dari karyawan dengan NIK \"" + txtNIK.Text + "\" ?") == true)
                {
                    //result = iemDAO.Delete(int.Parse(txtAlamatEmailSekarang.Text));
                    result = iemDAO.DeleteByNikNEmailAddr(txtNIK.Text, txtAlamatEmailSekarang.Text);

                    if (result > 0)
                    {
                        lblMsgString("Data berhasil dihapus.", Color.Green);
                        fillTextBox();
                        loadDaftarEmailByNik(txtNIK.Text);

                        string[] data = new string[] { "", "", "" };

                        int jmlEmail = countJmlEmailByNIK(txtNIK.Text);
                        //fillTextBoxMainForm(data, jmlEmail, init);
                        fillTextBoxMainFormEM(data, init);

                        //Refresh Email List On Neighbor Form
                        if (fLAIE != null)
                        {
                            fLAIE.refreshEmailList();
                        }
                    }
                    else
                    {
                        lblMsgString("Data gagal dihapus !!!", Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
        }
        
        private void lvwInformasiEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvwInformasiEmail.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvwInformasiEmail.SelectedItems[0];
                    fillTextBox(item);
                    
                    //Update Main Form View
                    string[] data = new string[] { item.SubItems[1].Text, item.SubItems[2].Text };              
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

        private void lblListEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fLAIE = new frmListAllInformasiEmail(iemDAO, this);            
            fLAIE.Show();
        }

        public void nullfLAIE()
        {
            fLAIE = null;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ubah = true;
            setTextBoxEmail(true, false);
        }

        private void lblTambahEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ubah = false;
            setTextBoxEmail(false, true);
        }

        private void frmInformasi_Email_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("Form Closed.");
            this._listener.setFlag(2);
        }
                
    }
}
