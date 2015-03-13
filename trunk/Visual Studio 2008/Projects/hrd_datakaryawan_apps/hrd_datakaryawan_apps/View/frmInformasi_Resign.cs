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
    public partial class frmInformasi_Resign : Form
    {
        //Variabel Global
        const int init = 3;
        private int rbStatusInit = 2;
        private string txtTanggalResignTemp = "";   //Variable to store temporary string Tanggal Resign
        private string txtAlasanResignTemp = "";    //Variable to store temporary string Alasan Resign

        private string nik = string.Empty;

        private Informasi_ResignDAO irsDAO = null;
        private bool resultBool = false;
        private int result = 0;

        //Constructor
        public frmInformasi_Resign(string nik, Informasi_ResignDAO irsDAO)
        {
            InitializeComponent();

            this.nik = nik;
            this.irsDAO = irsDAO;
        }        

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmInformasi_Email\nMethod : " + str2);
            //statusStripLevelPanel1("Telah terjadi error.", Color.Red);
        }

        private void lblMsgString(string msg, System.Drawing.Color clr)
        {
            lblMsgInfoResign.Text = msg;
            lblMsgInfoResign.ForeColor = clr;
        }

        private void clearTextBox()
        {
            rbStatusResignNo.Checked = false;
            rbStatusResignYes.Checked = false;

            txtTanggalResign.Clear();
            txtAlasanResign.Clear();
        }

        private void fillTextBox(Informasi_Resign irs)
        {
            if (irs.Status_Resign.Equals("Yes"))
            {
                rbStatusResignNo.Checked = false;
                rbStatusResignYes.Checked = true;
            }
            else if (irs.Status_Resign.Equals("No"))
            {
                rbStatusResignNo.Checked = true;
                rbStatusResignYes.Checked = false;
            }  
            
            txtTanggalResign.Text = string.Format("{0:dd/MM/yyyy}", irs.Tanggal_Resign);
            txtAlasanResign.Text = irs.Alasan_Resign;
        }

        private void loadInfoResign()
        {
            try
            {
                Informasi_Resign infoResign = irsDAO.GetByNIK(nik);

                if (infoResign != null)
                {
                    rbStatusResignNo.Checked = false;
                    rbStatusResignYes.Checked = true;

                    //txtTanggalResign.Text = infoResign.Tanggal_Resign.ToString();
                    txtTanggalResign.Text = string.Format("{0:dd/MM/yyyy}", infoResign.Tanggal_Resign);
                    txtAlasanResign.Text = infoResign.Alasan_Resign.ToString();
                }
                else
                {
                    rbStatusResignNo.Checked = true;
                    rbStatusResignYes.Checked = false;

                    txtTanggalResign.Text = "";
                    txtTanggalResign.Enabled = false;

                    txtAlasanResign.Text = "";
                    txtAlasanResign.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadInformasiResign");
            }            
        }

        private iListener _listener;
        public virtual iListener Listener
        {
            set { _listener = value; }
        }

        private void fillTextBoxMainForm(object[] data, int genIntNumb, int init)
        {
            if (this._listener != null)
            {
                this._listener.Ok(data, 0, init);
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

        private void frmInformasi_Resign_Load(object sender, EventArgs e)
        {
            loadInfoResign();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (msgBoxWarning("Apakah anda yakin akan menghapus Informasi Resign karyawan dengan NIK \"" + nik + "\" ?") == true)
                {
                    result = irsDAO.Delete(nik);

                    if (result > 0)
                    {
                        lblMsgString("Data Info Resign Karyawan berhasil dihapus.", Color.Green);
                        clearTextBox();

                        string[] data = new string[] { "No" };
                        fillTextBoxMainForm(data, 0, init);
                    }
                    else
                    {
                        lblMsgString("Data gagal dihapus", Color.Red);
                    }
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
                //MessageBox.Show("Tahap awal memasuki method irsDAO.Save()");

                if (rbStatusResignNo.Checked == false && rbStatusResignYes.Checked == false)
                {
                    lblMsgString("Cek salah satu status resign.", Color.Yellow);
                }
                else if (txtAlasanResign.Text == "" || txtTanggalResign.Text == "")
                {
                    lblMsgString("Isi tanggal resign dan alasan resign !!!", Color.Yellow);
                }
                else
                {
                    //MessageBox.Show("Tahap 2 memasuki method irsDAO.Save()");
                                       
                    resultBool = irsDAO.cekRecord(nik);

                    //MessageBox.Show("Tahap 3 memasuki irsDAO.Save(). irsDAO.CekRecord(nik) = " + resultBool.ToString());

                    if (resultBool == false)  //Record belum ada, maka tambahkan ke database
                    {
                        Informasi_Resign irs = new Informasi_Resign();

                        irs.NIK = nik;
                        if (rbStatusResignNo.Checked == true && rbStatusResignYes.Checked == false)
                        {
                            irs.Status_Resign = rbStatusResignNo.Text;
                        }
                        else if (rbStatusResignNo.Checked == false && rbStatusResignYes.Checked == true)
                        {
                            irs.Status_Resign = rbStatusResignYes.Text;
                        }

                        //MessageBox.Show("Format tanggal yang anda masukkan adalah : '{1}'", txtTanggalResign.Text);

                        irs.Tanggal_Resign = DateTime.ParseExact(txtTanggalResign.Text.Trim(), "dd/MM/yyyy", null); //Use Trim() to remove extra white space
                        irs.Alasan_Resign = txtAlasanResign.Text.Trim(); //Use Trim() to remove extra white space

                        //MessageBox.Show("Hasil Trim() extra white space pada textbox tsb menghasilkan : {1}", irs.Tanggal_Resign.ToString());

                        object[] data = new object[] { irs.Status_Resign };

                        result = irsDAO.Save(irs);

                        //MessageBox.Show("irsDAO.Save telah di eksekusi...");
                        if (result > 0)
                        {
                            lblMsgString("Data berhasil disimpan.", Color.Green);

                            fillTextBox(irs);

                            fillTextBoxMainForm(data, 0, init);
                        }
                        else
                        {
                            lblMsgString("Data gagal disimpan.", Color.Red);
                        }
                    }
                    else
                    {
                        //msgBoxWarning("Data Exist ! Hapus terlebih dahulu data yang ada.");
                        //lblMsgString("Data Exist ! Hapus terlebih dahulu data yang ada.", Color.Yellow);
                        if (msgBoxWarning("Anda yakin akan memperbaharui data Informasi Resign karyawan ini ?") == true)
                        {
                            Informasi_Resign irs = new Informasi_Resign();
                            irs.NIK = nik;
                            irs.Tanggal_Resign = DateTime.ParseExact(txtTanggalResign.Text.Trim(), "dd/MM/yyyy", null);
                            irs.Alasan_Resign = txtAlasanResign.Text.Trim();
                            irs.Status_Resign = rbStatusResignYes.Text;

                            result = irsDAO.Update(irs);

                            if (result > 0)
                            {
                                lblMsgString("Data Informasi Resign berhasil diperbaharui.", Color.Green);


                            }
                            else
                            {
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

        private void rbStatusResignNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStatusInit == 0)
            {
                //MessageBox.Show("RB No Checked.");

                txtTanggalResignTemp = txtTanggalResign.Text;
                txtAlasanResignTemp = txtAlasanResign.Text;

                txtTanggalResign.Clear();
                txtAlasanResign.Clear();

                txtTanggalResign.Enabled = false;
                txtAlasanResign.Enabled = false;

                rbStatusInit = 1;
            }

            if (rbStatusInit == 2)
            {
                rbStatusInit = 0;
            }
        }

        private void rbStatusResignYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStatusInit == 1)
            {
                //MessageBox.Show("RB Yes Checked.");
                txtTanggalResign.Text = txtTanggalResignTemp;
                txtAlasanResign.Text = txtAlasanResignTemp;

                txtTanggalResignTemp = string.Empty;
                txtAlasanResignTemp = string.Empty;

                txtTanggalResign.Enabled = true;
                txtAlasanResign.Enabled = true;

                rbStatusInit = 0;
            }

            if (rbStatusInit == 2) 
            {
                rbStatusInit = 1;
            }
        }        
    }
}
