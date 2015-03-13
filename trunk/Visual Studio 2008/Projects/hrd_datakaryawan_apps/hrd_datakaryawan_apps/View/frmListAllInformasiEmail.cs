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
    public partial class frmListAllInformasiEmail : Form
    {
        //Variabel Global
        private Informasi_EmailDAO iemDAO = null;
        private List<Informasi_Email> daftarEmail = null;
        //private List<int> jmlEmail = null;
        private frmInformasi_Email frmIE = null;

        private bool resultBool = false;
        private int result = 0;


        public frmListAllInformasiEmail(Informasi_EmailDAO iemDAO, frmInformasi_Email frmIE)
        {
            InitializeComponent();

            this.iemDAO = iemDAO;
            this.frmIE = frmIE;
        }

        public void refreshEmailList()
        {
            //MessageBox.Show("TES only. To Implements Refresh Email List On ListView. FormListAllInformasiEmail");
            loadEmailListToListView();
        }
                
        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmInformasi_Email\nMethod : " + str2);
            //statusStripLevelPanel1("Telah terjadi error.", Color.Red);
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

        private void inisialisasiListView()
        {
            try
            {
                lvwListAllEmail.View = System.Windows.Forms.View.Details;
                lvwListAllEmail.FullRowSelect = true;
                lvwListAllEmail.GridLines = true;

                lvwListAllEmail.Columns.Add("ID", 35, HorizontalAlignment.Left);
                lvwListAllEmail.Columns.Add("Alamat Email", 130, HorizontalAlignment.Left);
                lvwListAllEmail.Columns.Add("Kepemilikan", 70, HorizontalAlignment.Left);
                lvwListAllEmail.Columns.Add("NIK", 90, HorizontalAlignment.Left);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "inisialisasiListView");
            }
        }

        private void FillToListView(Informasi_Email email)
        {
            ListViewItem item = new ListViewItem(email.Id.ToString());

            item.SubItems.Add(email.Alamat_Email);
            item.SubItems.Add(email.Kepemilikan_Email);
            item.SubItems.Add(email.NIK);

            lvwListAllEmail.Items.Add(item);
        }

        private void loadEmailListToListView()
        {
            lvwListAllEmail.Items.Clear();

            List<Informasi_Email> daftarIem = iemDAO.GetAll();

            foreach (Informasi_Email email in daftarIem)
            {
                FillToListView(email);
            }
        }

        private void fillTextBox(ListViewItem item)
        {
            //lvwListAllEmail.Items.Clear();
            txtNIK.Text = item.SubItems[3].Text;
        }

        private void loadEmailByNIKListToListView()
        {
            lvwListAllEmail.Items.Clear();

            List<Informasi_Email> daftarIem = iemDAO.GetByNIK(txtNIK.Text);

            foreach (Informasi_Email email in daftarIem)
            {
                FillToListView(email);
            }
        }

        public void Ok(object[] data, bool ukuranPakaian, bool infoEmail, int jmlEmail)
        {
            if (infoEmail == true)
            {
                loadEmailListToListView();
            }
        }

        
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();

            frmIE.nullfLAIE();
        }

        private void frmListAllInformasiEmail_Load(object sender, EventArgs e)
        {
            inisialisasiListView();

            try
            {
                loadEmailListToListView();
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataKaryawan");
            }
        }

        private void frmListAllInformasiEmail_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmIE.nullfLAIE();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNIK.Text == "")
                {
                    //MessageBox.Show("Cara Menampilkan Symbol Wilcard = *");
                    loadEmailListToListView();
                }
                else
                {
                    //MessageBox.Show("Cara Menampilkan Symbol Wilcard = *");
                    loadEmailByNIKListToListView();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataKaryawan");
            }
        }

        private void lvwListAllEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvwListAllEmail.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvwListAllEmail.SelectedItems[0];
                    fillTextBox(item);
                }

                //txtNIK.Focus();
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "lvwKaryawan_SelectedIndexChanged");
            }
        }        
    }
}
