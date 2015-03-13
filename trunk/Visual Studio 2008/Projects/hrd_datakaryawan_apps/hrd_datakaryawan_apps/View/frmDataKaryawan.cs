using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms.Design;

using hrd_datakaryawan_apps.DAO;
using hrd_datakaryawan_apps.Model;

namespace hrd_datakaryawan_apps.View
{
    public partial class frmDataKaryawan : Form, iListener
    {
        //Variabel Global
        private int cmbEmailFlag = 0;
        private int cmbInfoKontakFlag = 0;
        private int cmbInfoPendidikanFlag = 0;
        private int cmbInfoIdentitasFlag = 0;

        private frmMenuUtama frmMU = null;
        private KaryawanDAO dtKDAO = null;

        private Status_PekerjaDAO stPDAO = null;
        private List<string> kodSTP = new List<string>();

        private Jenis_PekerjaDAO jnPDAO = null;
        private List<string> kodJNP = new List<string>();

        private UpahDAO upahDAO = null;
        private List<string> kodUpah = new List<string>();

        private AgamaDAO agamaDAO = null;
        private List<int> idAgama = new List<int>();

        private GradeDAO gradeDAO = null;
        private List<string> kodGrade = new List<string>();

        private LevelDAO levelDAO = null;
        private List<string> kodLevel = new List<string>();

        private Status_PajakDAO stPJDAO = null;
        private List<string> kodSTPJ = new List<string>();

        private List<Karyawan> daftarKry = null;

        private bool resultBool = false;
        private int result = 0;

        private Ukuran_PakaianDAO ukpDAO = null;

        private Informasi_EmailDAO iemDAO = null;
        private List<int> idEmail= new List<int>();

        private Informasi_ResignDAO irsDAO = null;

        private Informasi_KontakDAO iknDAO = null;
        private List<int> idInfoKontak = new List<int>();

        private PendidikanDAO pdkDAO = null;
        private List<int> idPendidikan = new List<int>();

        private IdentitasDAO idtDAO = null;
        private List<string> nomor_identitas = new List<string>();
        

        public frmDataKaryawan(DBConnection conn, frmMenuUtama frmMU)
        {
            InitializeComponent();

            try
            {
                dtKDAO = new KaryawanDAO(conn.GetConnection());
                stPDAO = new Status_PekerjaDAO(conn.GetConnection());
                jnPDAO = new Jenis_PekerjaDAO(conn.GetConnection());
                upahDAO = new UpahDAO(conn.GetConnection());
                agamaDAO = new AgamaDAO(conn.GetConnection());
                gradeDAO = new GradeDAO(conn.GetConnection());
                levelDAO = new LevelDAO(conn.GetConnection());
                stPJDAO = new Status_PajakDAO(conn.GetConnection());

                ukpDAO = new Ukuran_PakaianDAO(conn.GetConnection());
                iemDAO = new Informasi_EmailDAO(conn.GetConnection());
                irsDAO = new Informasi_ResignDAO(conn.GetConnection());
                iknDAO = new Informasi_KontakDAO(conn.GetConnection());
                pdkDAO = new PendidikanDAO(conn.GetConnection());
                idtDAO = new IdentitasDAO(conn.GetConnection());
                                                     
                this.frmMU = frmMU;
                frmMUEnbDis(false);
                setForm();
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmLevel_Constructor");
            }
        }

        private bool IsEnter(System.Windows.Forms.KeyPressEventArgs e)
        {
            return (e.KeyChar == (char)Keys.Return);
        }

        private void frmMUEnbDis(bool ft)
        {
            frmMU.aplikasiToolStripMenuItem.Enabled = ft;
            frmMU.dataKaryawanToolStripMenuItem.Enabled = ft;
            /*
            frmMU.hRDToolStripMenuItem.Enabled = ft;
            frmMU.levelToolStripMenuItem.Enabled = ft;
            frmMU.absensiToolStripMenuItem.Enabled = ft;
            frmMU.gajiToolStripMenuItem.Enabled = ft;
            frmMU.statusPekerjaToolStripMenuItem.Enabled = ft;
            frmMU.jenisPekerjaToolStripMenuItem.Enabled = ft;
            frmMU.upahToolStripMenuItem.Enabled = ft;
            frmMU.agamaToolStripMenuItem.Enabled = ft;
            frmMU.gradeToolStripMenuItem.Enabled = ft;
            frmMU.levelToolStripMenuItem.Enabled = ft;
            frmMU.statusPajakToolStripMenuItem.Enabled = ft;
            */
        }

        private void setForm()
        {            
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;            
        }

        private void clearInfoUtamaGroup(char flag)
        {
            if (flag == 'D')
            {
                txtNIK.Clear();
            }

            txtNama.Clear();
            txtNickName.Clear();
            txtTempatLahir.Clear();
            txtTanggalLahir.Clear();
                        
            txtAsuransi.Clear();
            txtJamsostek.Clear();
            txtNPWP.Clear();

            if (flag == 'A')
            {
                txtNIK.Clear();
                cmbJenisKelamin.Text = null;
                cmbStatusNikah.Text = null;
                cmbKewarganegaraan.Text = null;
                //cmbGolonganDarah.Items.Clear();
                cmbGolonganDarah.Text = null;

                cmbStatusPekerja.Text = null;
                cmbJenisPekerja.Text = null;
                cmbJenisUpah.Text = null;
                cmbAgama.Text = null;
                cmbGrade.Text = null;
                cmbLevel.Text = null;
                //cmbStatusPajak.Items.Clear(); 
                cmbStatusPajak.Text = null;
            }

            defaultFirstFormLoad(false);
        }

        private void defaultFirstFormLoad(bool ft)
        {
            gbUkuran.Enabled = ft;
            gbInfoEmail.Enabled = ft;
            gbInfoResign.Enabled = ft;
            gbInfoKontak.Enabled = ft;
            gbPendidikan.Enabled = ft;
            gbIdentitas.Enabled = ft;
            gbInfoRekruitmen.Enabled = ft;
            gbAlamat.Enabled = ft;
            gbDataKeluarga.Enabled = ft;

            //txtNIK.Focus();
        }

        private void loadDataKaryawan()
        {
            try
            {
                MessageBox.Show("dtKDAO.GetAll() dipanggil.");
                daftarKry = dtKDAO.GetAll();
                MessageBox.Show("dtKDAO.GetAll() selesai dipanggil.");
                //DGV.DataSource = daftarKry.ToArray();
                //DGV.ReadOnly = true;              
                //Set otomatis lebar kolom
                //DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataKaryawan");
            }
        }

        private void loadDataKaryawan2()
        {
            try
            {
                lvwKaryawan.Items.Clear();

                daftarKry = dtKDAO.GetAll();
                foreach (Karyawan kry in daftarKry)
                {
                    FillToListView(kry);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadDataKaryawan");
            }
        }

        private void loadStatusPekerja(ComboBox obj)
        {
            try
            {
                obj.Items.Clear();

                List<Status_Pekerja> daftarStatusPekerja = stPDAO.GetAll();
                foreach (Status_Pekerja sTP in daftarStatusPekerja)
                {
                    kodSTP.Add(sTP.Kode_Status);
                    obj.Items.Add(sTP.Status);
                }                
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadStatusPekerja");
            }
        }

        private void loadJenisPekerja(ComboBox obj)
        {
            try
            {
                obj.Items.Clear();

                List<Jenis_Pekerja> daftarJenisPekerja = jnPDAO.GetAll();
                foreach (Jenis_Pekerja jNP in daftarJenisPekerja)
                {
                    kodJNP.Add(jNP.Kode_Jenis_Pekerja);
                    obj.Items.Add(jNP.Nama_Jenis_Pekerja);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadStatusPekerja");
            }
        }

        private void loadUpah(ComboBox obj)
        {
            try
            {
                obj.Items.Clear();

                List<Upah> daftarUpah = upahDAO.GetAll();
                foreach (Upah upah in daftarUpah)
                {
                    kodUpah.Add(upah.Kode_Upah);
                    obj.Items.Add(upah.Tipe_Upah);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadStatusPekerja");
            }
        }

        private void loadAgama(ComboBox obj)
        {
            try
            {
                obj.Items.Clear();

                List<Agama> daftarAgama = agamaDAO.GetAll();
                foreach (Agama agama in daftarAgama)
                {
                    idAgama.Add(agama.Id_Agama);
                    obj.Items.Add(agama.Nama_Agama);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadAgama");
            }
        }

        private void loadGrade(ComboBox obj)
        {
            try
            {
                obj.Items.Clear();

                List<Grade> daftarGrade = gradeDAO.GetAll();
                foreach (Grade grade in daftarGrade)
                {
                    kodGrade.Add(grade.Kode_Grade);
                    obj.Items.Add(grade.Nama_Grade);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadAgama");
            }
        }

        private void loadLevel(ComboBox obj)
        {
            try
            {
                obj.Items.Clear();

                List<Level> daftarLevel = levelDAO.GetAll();
                foreach (Level level in daftarLevel)
                {
                    kodLevel.Add(level.Kode_Level);
                    obj.Items.Add(level.Nama_Level);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadAgama");
            }
        }

        private void loadStatusPajak(ComboBox obj)
        {
            try
            {
                obj.Items.Clear();

                List<Status_Pajak> daftarSTPJ = stPJDAO.GetAll();
                foreach (Status_Pajak sTPJ in daftarSTPJ)
                {
                    kodSTPJ.Add(sTPJ.Kode_Status_Pajak);
                    obj.Items.Add(sTPJ.Kode_Status_Pajak);
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadAgama");
            }
        }       

        private void loadTxtGB()
        {
            try
            {
                //Group Box Ukuran Pakaian
                Ukuran_Pakaian ukp = ukpDAO.GetByNIK(txtNIK.Text);

                if (ukp != null)
                {
                    txtUkuranBaju.Text = ukp.Ukuran_Baju;
                    txtUkuranCelana.Text = ukp.Ukuran_Celana;
                    txtUkuranSepatu.Text = ukp.Ukuran_Sepatu;
                }
                else
                {
                    txtUkuranBaju.Clear();
                    txtUkuranCelana.Clear();
                    txtUkuranSepatu.Clear();
                }


                //Group Box Informasi Email
                //MessageBox.Show("Enter iemDAO.GetAll()");
                //List<Informasi_Email> daftarIem = iemDAO.GetAll();
                //List<Informasi_Email> daftarIem = iemDAO.GetAll();

                //cmbEmailFlag = 0;
                //loadAlamatEmail(cmbEmail);
                //MessageBox.Show("Finish iemDAO.GetAll()");
                //loadTxtGBEmail();
                //cmbEmailFlag = 1;

                //GroupBox Informasi Resign
                Informasi_Resign irs = irsDAO.GetByNIK(txtNIK.Text);

                if (irs != null)
                {
                    rbStatusResignNO.Checked = false;
                    rbStatusResignYES.Checked = true;

                    rbStatusResignNO.Enabled = false;
                    rbStatusResignYES.Enabled = true;
                }
                else
                {
                    rbStatusResignNO.Checked = true;
                    rbStatusResignYES.Checked = false;

                    rbStatusResignNO.Enabled = true;
                    rbStatusResignYES.Enabled = false;
                }
                              
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "loadTxtGB");
            }
        }

        private void loadTxtGBEmail(ComboBox obj)
        {            
            obj.Items.Clear();

            List<Informasi_Email> daftarEmailByNik = iemDAO.GetByNIK(txtNIK.Text);

            //Count the numbers of emails
            int jmlEmail = daftarEmailByNik.Count();
            
            if (jmlEmail > 0)
            {
                //Load List of Emails Into Combobox
                foreach (Informasi_Email iem in daftarEmailByNik)
                {
                    idEmail.Add(iem.Id);
                    obj.Items.Add(iem.Alamat_Email);
                }
                
                cmbEmail.SelectedItem = daftarEmailByNik[0].Alamat_Email;
                
                                        
                lblJumlahEmail.Text = "Jumlah : " + jmlEmail.ToString();

                if (daftarEmailByNik[0].Kepemilikan_Email.Equals("Pribadi"))
                {
                    rbEmailPribadi.Checked = true;
                    rbEmailPerusahaan.Checked = false;

                    rbEmailPribadi.Enabled = true;
                    rbEmailPerusahaan.Enabled = false;
                }
                else
                {
                    rbEmailPerusahaan.Checked = true;
                    rbEmailPribadi.Checked = false;

                    rbEmailPribadi.Enabled = false;
                    rbEmailPerusahaan.Enabled = true;
                }
            }
            else
            {
                cmbEmail.Text = null;
                lblJumlahEmail.Text = Convert.ToString(0);

                rbEmailPribadi.Checked = false;
                rbEmailPerusahaan.Checked = false;

                rbEmailPribadi.Enabled = false;
                rbEmailPerusahaan.Enabled = false;
            }
        }

        private void loadTxtGBInfoKontak(ComboBox obj)
        {
            obj.Items.Clear();

            List<Informasi_Kontak> daftarInfoKontakByNik = iknDAO.getByNIK(txtNIK.Text);
            
            int jmlNoKontak = daftarInfoKontakByNik.Count();

            lblJumlahKontak.Text = "Jumlah : " + jmlNoKontak.ToString();

            if (jmlNoKontak > 0)
            {
                foreach (Informasi_Kontak ikn in daftarInfoKontakByNik)
                {
                    idInfoKontak.Add(ikn.Id_Inform_Kontak);
                    obj.Items.Add(ikn.Nomor_Kontak);            
                }
                
                cmbNoKontak.SelectedItem = daftarInfoKontakByNik[0].Nomor_Kontak;

                if (daftarInfoKontakByNik[0].Jenis_Kontak.Equals("Telpon"))
                {
                    rbHP.Checked = false;
                    rbHP.Enabled = false;

                    rbTlp.Checked = true;
                    rbTlp.Enabled = true;
                }
                else if (daftarInfoKontakByNik[0].Jenis_Kontak.Equals("HP") || daftarInfoKontakByNik[0].Jenis_Kontak.Equals("Handphone"))
                {
                    rbHP.Checked = true;
                    rbHP.Enabled = true;

                    rbTlp.Checked = false;
                    rbTlp.Enabled = false;
                }
                else
                {
                    rbHP.Checked = false;
                    rbHP.Enabled = false;

                    rbTlp.Checked = false;
                    rbTlp.Enabled = false;
                }
            }
            else
            {
                rbHP.Checked = false;
                rbHP.Enabled = false;

                rbTlp.Checked = false;
                rbTlp.Enabled = false;
            }
        }

        private void loadtxtGBInfoPendidikan(ComboBox obj)
        {
            obj.Items.Clear();

            List<Pendidikan> dftPdk = pdkDAO.getInfoPendidikanByNik(txtNIK.Text);

            int jmlInfoPendidikan = dftPdk.Count();

            if (jmlInfoPendidikan > 0)
            {
                foreach (Pendidikan pdk in dftPdk)
                {
                    idPendidikan.Add(pdk.Id_Pendidikan);
                    obj.Items.Add(pdk.Jenjang_Pendidikan);
                }

                cmbLembaga.SelectedItem = dftPdk[0].Jenjang_Pendidikan;
                
                txtTahunLulus.Text = string.Format("{0:dd/MM/yyyy}", dftPdk[0].Tahun_lulus);
                txtTahunMasuk.Text = string.Format("{0:dd/MM/yyyy}", dftPdk[0].Tahun_masuk);
            }
            else
            {
                //cmbLembaga.SelectedIndex = -1;
                cmbLembaga.Text = null;

                txtTahunMasuk.Text = "";
                txtTahunLulus.Text = "";
            }
        }

        private void loadTxtGBIdentitas(ComboBox obj)
        {
            obj.Items.Clear();

            List<Identitas> dftIdt = idtDAO.getInfoIdentitasByNik(txtNIK.Text);

            int jmlIdentitas = dftIdt.Count();

            if (jmlIdentitas > 0)
            {
                foreach (Identitas idt in dftIdt)
                {
                    nomor_identitas.Add(idt.Nomor_Identitas.Trim());
                    obj.Items.Add(idt.Nomor_Identitas.Trim());
                }

                cmbNoIdent.SelectedItem = dftIdt[0].Nomor_Identitas.Trim();

                txtJenisID.Text = dftIdt[0].Jenis_Identitas;
                txtMasaBerlaku.Text = string.Format("{0:dd/MM/yyyy}", dftIdt[0].Masa_Berlaku);
            }
            else
            {
                cmbNoIdent.Text = null;

                txtJenisID.Text = "";
                txtMasaBerlaku.Text = "";
            }
        }

        private string getKepemilikanEmail(string emailAddr)
        {
            Informasi_Email iem = iemDAO.GetByAlamatEmail(emailAddr);

            return iem.Kepemilikan_Email;            
        }

        private string getJenisKontak(string noKontak)
        {
            Informasi_Kontak ikn = iknDAO.getByNikNByNoKontak(txtNIK.Text, noKontak);
        
            return ikn.Jenis_Kontak;
        }

        private void statusStripMUPanel123(string panel1, string panel2, string panel3, System.Drawing.Color clr1, System.Drawing.Color clr2, System.Drawing.Color clr3)
        {
            //frmMU.mUPanel1.TextAlign = ContentAlignment.MiddleRight;
            //frmMU.mUPanel1.TextAlign = ToolStripStatusLabel.ToolStripItemAccessibleObject
            frmMU.mUPanel1.Text = panel1 + "       ";
            frmMU.mUPanel1.ForeColor = clr1;
            //frmMU.mUPanel1.Alignment = ToolStripItemAlignment.Right;

            frmMU.mUPanel2.Text = panel2 + "       ";
            frmMU.mUPanel2.ForeColor = clr2;

            frmMU.mUPanel3.Text = panel3;
            frmMU.mUPanel3.ForeColor = clr3;
        }

        private void labelDtKry(string str, System.Drawing.Color clr)
        {
            lblStatus2.Text = str;
            lblStatus2.ForeColor = clr;
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
                lvwKaryawan.View = System.Windows.Forms.View.Details;
                lvwKaryawan.FullRowSelect = true;
                lvwKaryawan.GridLines = true;

                lvwKaryawan.Columns.Add("No.", 35, HorizontalAlignment.Left);
                lvwKaryawan.Columns.Add("NIK", 135, HorizontalAlignment.Left);
                lvwKaryawan.Columns.Add("Nama", 130, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Nama Panggilan", 50, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Tempat Lahir", 50, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Tanggal Lahir", 50, HorizontalAlignment.Center);
                //lvwKaryawan.Columns.Add("Jenis kelamin", 25, HorizontalAlignment.Center);
                //lvwKaryawan.Columns.Add("Status Nikah", 50, HorizontalAlignment.Center);
                lvwKaryawan.Columns.Add("Warganegara", 90, HorizontalAlignment.Center);
                //lvwKaryawan.Columns.Add("Golongan Darah", 25, HorizontalAlignment.Center);
                //lvwKaryawan.Columns.Add("Asuransi", 25, HorizontalAlignment.Center);
                //lvwKaryawan.Columns.Add("Jamsostek", 25, HorizontalAlignment.Center);
                //lvwKaryawan.Columns.Add("NPWP", 50, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Status Pekerja", 25, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Jenis Pekerja", 25, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Jenis Upah", 25, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Agama", 25, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Grade", 25, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Level", 25, HorizontalAlignment.Left);
                //lvwKaryawan.Columns.Add("Status Pajak", 25, HorizontalAlignment.Left);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "inisialisasiListView");
            }
        }

        private void FillToListView(Karyawan kry)
        {
            try
            {
                int noUrut = lvwKaryawan.Items.Count + 1;

                ListViewItem item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(kry.NIK);
                item.SubItems.Add(kry.Nama);
                item.SubItems.Add(kry.Kewaganegaraan);

                lvwKaryawan.Items.Add(item);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "FillToListView");
            }
        }

        private void FillTxtBoxKaryawanForm(ListViewItem item)
        {
            //MessageBox.Show("Awal Method FillTxtBoxKaryawanForm(item)");
            
            if (item != null)
            //if (item == null)
            {
                //MessageBox.Show("item != null");

                foreach (Karyawan kry in daftarKry)
                {
                    if (kry.NIK == item.SubItems[1].Text)
                    {
                        txtNIK.Text = kry.NIK;
                        txtNama.Text = kry.Nama;
                        txtNickName.Text = kry.Nick_Name;
                        txtTempatLahir.Text = kry.Tempat_lahir;
                        txtTanggalLahir.Text = kry.Tanggal_Lahir.ToString();
                        cmbJenisKelamin.SelectedItem = kry.Jenis_Kelamin;
                        cmbStatusNikah.SelectedItem = kry.Status_Nikah;
                        cmbKewarganegaraan.SelectedItem = kry.Kewaganegaraan;
                        cmbGolonganDarah.SelectedItem = kry.Golongan_Darah;
                        txtAsuransi.Text = kry.Asuransi;
                        txtJamsostek.Text = kry.Jamsostek;
                        txtNPWP.Text = kry.NPWP;
                        cmbStatusPekerja.SelectedItem = kry.Status_Pekerja.Status;
                        cmbJenisPekerja.SelectedItem = kry.Jenis_Pekerja.Nama_Jenis_Pekerja;
                        cmbJenisUpah.SelectedItem = kry.Upah.Tipe_Upah;
                        cmbAgama.SelectedItem = kry.Agama.Nama_Agama;
                        cmbGrade.SelectedItem = kry.Grade.Nama_Grade;
                        cmbLevel.SelectedItem = kry.Level.Nama_Level;
                        cmbStatusPajak.SelectedItem = kry.Status_Pajak.Kode_Status_Pajak;

                        defaultFirstFormLoad(true);
                    }
                }
            }             
        }

        private void FillTxtBoxKaryawanForm()
        {
            if (txtNIK.Text != "")
            {
                //MessageBox.Show("txtNIK.Text != \"\"" + "\ntxtNIK.Text = " + txtNIK.Text);

                foreach (Karyawan kry in daftarKry)
                {
                    //MessageBox.Show("kry.NIK = " + kry.NIK);

                    //if (kry.NIK == txtNIK.Text)
                    //if (kry.NIK != "1234")
                    if (kry.NIK.Equals(txtNIK.Text)) 
                    {
                        //MessageBox.Show("kry.NIK != txtNIK.Text" + "\nkry.NIK = " + kry.NIK + "\ntxtNIK.Text = " + txtNIK.Text);

                        txtNIK.Text = kry.NIK;
                        txtNama.Text = kry.Nama;
                        txtNickName.Text = kry.Nick_Name;
                        txtTempatLahir.Text = kry.Tempat_lahir;
                        txtTanggalLahir.Text = kry.Tanggal_Lahir.ToString();
                        cmbJenisKelamin.SelectedItem = kry.Jenis_Kelamin;
                        cmbStatusNikah.SelectedItem = kry.Status_Nikah;
                        cmbKewarganegaraan.SelectedItem = kry.Kewaganegaraan;
                        cmbGolonganDarah.SelectedItem = kry.Golongan_Darah;
                        txtAsuransi.Text = kry.Asuransi;
                        txtJamsostek.Text = kry.Jamsostek;
                        txtNPWP.Text = kry.NPWP;
                        cmbStatusPekerja.SelectedItem = kry.Status_Pekerja.Status;
                        cmbJenisPekerja.SelectedItem = kry.Jenis_Pekerja.Nama_Jenis_Pekerja;
                        cmbJenisUpah.SelectedItem = kry.Upah.Tipe_Upah;
                        cmbAgama.SelectedItem = kry.Agama.Nama_Agama;
                        cmbGrade.SelectedItem = kry.Grade.Nama_Grade;
                        cmbLevel.SelectedItem = kry.Level.Nama_Level;
                        cmbStatusPajak.SelectedItem = kry.Status_Pajak.Kode_Status_Pajak;

                        defaultFirstFormLoad(true);
                    }
                }
            }
        }

        private void errorDBox(string str1, string str2)
        {
            MessageBox.Show(str1 + "\n\n" + "Source : frmDataKaryawan\nMethod : " + str2);
            //statusStripUPPanel1("Telah terjadi error.", Color.Red);
            labelDtKry("Telah terjadi error.", Color.Red);
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
                errorDBox(ex.Message.ToString(), "btnTutup_Click");
            }   
        }

        private void frmDataKaryawan_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmMUEnbDis(true);
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "frmDataKaryawan_FormClosed");
            }   
        }

        /*
        private void frmDataKaryawan_MaximumSizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.Size.ToString());
        }

        private void frmDataKaryawan_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.Size.ToString());
        }

        private void frmDataKaryawan_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // MessageBox.Show(this.Size.ToString());
        }
         */


        private void frmDataKaryawan_Load(object sender, EventArgs e)
        {            
            defaultFirstFormLoad(false);
            inisialisasiListView();

            //loadDataKaryawan();
            loadDataKaryawan2();


            
            loadStatusPekerja(cmbStatusPekerja);
            loadJenisPekerja(cmbJenisPekerja);
            loadUpah(cmbJenisUpah);
            loadAgama(cmbAgama);
            loadGrade(cmbGrade);
            loadLevel(cmbLevel);
            loadStatusPajak(cmbStatusPajak); 
        }

        private void lvwKaryawan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvwKaryawan.SelectedItems.Count > 0)
                {
                    cmbEmailFlag = 0;
                    cmbInfoKontakFlag = 0;
                    cmbInfoPendidikanFlag = 0;
                    cmbInfoIdentitasFlag = 0;

                    ListViewItem item = lvwKaryawan.SelectedItems[0];
                    FillTxtBoxKaryawanForm(item);
                    
                    //Textbox GroupBox
                    loadTxtGB();
                    loadTxtGBEmail(cmbEmail);
                    loadTxtGBInfoKontak(cmbNoKontak);
                    loadtxtGBInfoPendidikan(cmbLembaga);    //Karena udah terlanjur nama dari Combobox Lembaga tidak diubah. Namun penggunaannya diubah untuk menampilkan info jenjang pendidikan
                    loadTxtGBIdentitas(cmbNoIdent);

                    cmbEmailFlag = 1;
                    cmbInfoKontakFlag = 1;
                    cmbInfoPendidikanFlag = 1;
                    cmbInfoIdentitasFlag = 1;
                }
                
                txtNIK.Focus();
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "lvwKaryawan_SelectedIndexChanged");
            }
        }

        private void txtNIK_Validated(object sender, EventArgs e)
        {
            try
            {                
                MessageBox.Show("Textbox NIK VALIDATED, Eksekusi dtKDAO.cekRecord");
                resultBool = dtKDAO.cekRecord(txtNIK.Text);
                //MessageBox.Show("Textbox NIK Tervalidasi.");

                if (resultBool == true)
                {
                    FillTxtBoxKaryawanForm(null);
                    //txtNIK.Focus();
                    defaultFirstFormLoad(true);
                                        
                    //txtNIK.Focus();
                }
                else
                {
                    //defaultFirstFormLoad(false);
                    clearInfoUtamaGroup('N');
                    //txtNIK.Focus();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "txtNIK_Validated");
            }    
        }

        private void linkLblClearText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearInfoUtamaGroup('A');
            defaultFirstFormLoad(false);
            
            txtNIK.Focus();
        }        

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNIK.Text.Length != 11)
                {
                    labelDtKry("Jumlah NIK harus 11 Digit.", Color.Yellow);
                }
                else if (txtNIK.Text == "" || txtNama.Text == "" || txtNickName.Text == "" || txtTempatLahir.Text == "" || txtTanggalLahir.Text == "" || cmbStatusNikah.SelectedItem == null || cmbKewarganegaraan.SelectedItem == null || cmbGolonganDarah.SelectedItem == null || txtAsuransi.Text == "" || txtJamsostek.Text == "" || txtNPWP.Text == "" || cmbStatusPekerja.SelectedItem == null || cmbJenisUpah.SelectedItem == null || cmbAgama.Items == null || cmbGrade.SelectedItem == null || cmbLevel.SelectedItem == null || cmbStatusPajak.SelectedItem == null || cmbJenisPekerja.SelectedItem == null || cmbJenisKelamin.SelectedItem == null)
                {
                    labelDtKry("Field Info Utama dan Master tidak boleh kosong !", Color.Yellow);    
                }
                else
                {
                    Karyawan kry = new Karyawan();
                    
                    kry.NIK = txtNIK.Text;
                    kry.Nama = txtNama.Text;
                    kry.Nick_Name = txtNickName.Text;
                    kry.Tempat_lahir = txtTempatLahir.Text;
                    kry.Tanggal_Lahir = DateTime.Parse(txtTanggalLahir.Text);
                    kry.Jenis_Kelamin = cmbJenisKelamin.SelectedItem.ToString();
                    kry.Status_Nikah = cmbStatusNikah.SelectedItem.ToString();
                    kry.Kewaganegaraan = cmbKewarganegaraan.SelectedItem.ToString(); ;
                    kry.Golongan_Darah = cmbGolonganDarah.SelectedItem.ToString();
                    kry.Asuransi = txtAsuransi.Text;
                    kry.Jamsostek = txtJamsostek.Text;
                    kry.NPWP = txtNPWP.Text;
                    kry.Status_Pekerja.Kode_Status = kodSTP[cmbStatusPekerja.SelectedIndex];
                    kry.Jenis_Pekerja.Kode_Jenis_Pekerja = kodJNP[cmbJenisPekerja.SelectedIndex];
                    kry.Upah.Kode_Upah = kodUpah[cmbJenisUpah.SelectedIndex];
                    kry.Agama.Id_Agama = idAgama[cmbAgama.SelectedIndex];
                    kry.Grade.Kode_Grade = kodGrade[cmbGrade.SelectedIndex];
                    kry.Level.Kode_Level = kodLevel[cmbLevel.SelectedIndex];
                    kry.Status_Pajak.Kode_Status_Pajak = kodSTPJ[cmbStatusPajak.SelectedIndex];

                    //Cek Record tabel Karyawan apakah sudah ada NIK terkait ?                    
                    resultBool = dtKDAO.cekRecord(txtNIK.Text);

                    if (resultBool == false)
                    {
                        result = dtKDAO.Save(kry);

                        if (result > 0)
                        {
                            //statusStripMUPanel123("Data berhasil disimpan.", "", "", Color.Green, Color.Black, Color.Black);
                            labelDtKry("Data berhasil disimpan.", Color.Green);
                            clearInfoUtamaGroup('A');

                            loadDataKaryawan2();
                            txtNIK.Focus();
       
                        }
                        else
                        {
                            //statusStripMUPanel123("Data gagal disimpan.", "", "", Color.Red, Color.Black, Color.Black);
                            labelDtKry("Data gagal disimpan.", Color.Red);
                            txtNIK.Focus();
                        }
                    }
                    else   //Meng-update data departemen
                    {
                        if (msgBoxWarning("Anda yakin akan mengubah data Karyawan dengan NIK = " + kry.NIK + " ?") == true)
                        {
                            result = dtKDAO.Update(kry);

                            if (result > 0)
                            {
                                labelDtKry("Data berhasil diubah.", Color.Green);

                                clearInfoUtamaGroup('D');
                                defaultFirstFormLoad(false);

                                loadDataKaryawan2();
                                txtNIK.Focus();
       
                            }
                            else
                            {
                                labelDtKry("Data gagal diubah.", Color.Red);
                                txtNIK.Focus();
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


        private void txtNIK_Validated_2(object sender, EventArgs e)
        {
            //MessageBox.Show("Nilai  txtNIK = " + txtNIK.Text);
            //FillTxtBoxKaryawanForm();
        }

        private void txtNIK_Leave(object sender, EventArgs e)
        {
            //MessageBox.Show("Nilai  txtNIK = " + txtNIK.Text);
            //FillTxtBoxKaryawanForm();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNIK.Text == "")
                {
                    labelDtKry("Tentukan NIK karyawan yang akan dihapus !", Color.Yellow);
                }
                else
                {
                    if (msgBoxWarning("Apakah anda yakin akan menghapus data Karyawan dengan NIK :" + txtNIK.Text + " ?") == true)
                    {
                        result = dtKDAO.Delete(txtNIK.Text);

                        if (result > 0)
                        {
                            labelDtKry("Record Data Karyawan berhasil dihapus.", Color.Green);
                        }
                        else
                        {
                            labelDtKry("Record Data Karyawan gagal dihapus.", Color.Red);
                        }
                    }
                    else
                    {
                        clearInfoUtamaGroup('D');
                    }

                    loadDataKaryawan2();
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), "btnHapus_Click");
            }
        }

        private void txtNIK_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (IsEnter(e)) SendKeys.Send("{Tab}");
        }

        private void txtNIK_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                FillTxtBoxKaryawanForm();   
            }
        }

        private void linkLblAddEditUkuran_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUkuran_Pakaian frmUP = new frmUkuran_Pakaian(txtNIK.Text, ukpDAO);
            frmUP.Listener = this;
            frmUP.ShowDialog();
        }

        private void linkLblInfoEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmbEmailFlag = 0;

            frmInformasi_Email frmIem = new frmInformasi_Email(txtNIK.Text, iemDAO);
            frmIem.Listener = this;
            frmIem.ShowDialog();            
        }
                       
        private void linkLblAddEditInfoResign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInformasi_Resign frmIrs = new frmInformasi_Resign(txtNIK.Text, irsDAO);
            frmIrs.Listener = this;
            frmIrs.ShowDialog();

           // cmbEmailFlag = 0;
        }

        private void linkLblAddEditPendidikan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmbInfoPendidikanFlag = 0;

            frmPendidikan frmPdk = new frmPendidikan(txtNIK.Text, pdkDAO);
            frmPdk.Listener = this;
            frmPdk.ShowDialog();
        }

        private void linkLblAddEditInfoKontak_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmbInfoKontakFlag = 0;

            frmInformasi_Kontak frmIkn = new frmInformasi_Kontak(txtNIK.Text, txtNama.Text, iknDAO);
            frmIkn.Listener = this;
            frmIkn.ShowDialog();

        }

        private void linkLblAddEditIdentitas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmbInfoIdentitasFlag = 0;

            frmIdentitas frmIdt = new frmIdentitas(txtNIK.Text, idtDAO);
            frmIdt.Listener = this;
            frmIdt.ShowDialog();
        }        
        
        private void cmbEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmailFlag != 0)
                {
                    //MessageBox.Show("Selected item : " + cmbEmail.SelectedItem.ToString() + ", " + cmbEmail.SelectedIndex.ToString() + ", " + cmbEmail.SelectedText.ToString() + ", Tes");

                    //string kepemilikanEmailOrig = getKepemilikanEmail(cmbEmail.SelectedItem.ToString());
                    string kepemilikanEmail = Convert.ToString((iemDAO.GetByAlamatEmail(cmbEmail.SelectedItem.ToString())).Kepemilikan_Email);

                    if (kepemilikanEmail.Equals("Pribadi"))
                    {
                        rbEmailPerusahaan.Enabled = false;
                        rbEmailPerusahaan.Checked = false;

                        rbEmailPribadi.Enabled = true;
                        rbEmailPribadi.Checked = true;
                    }
                    else if (kepemilikanEmail.Equals("Perusahaan"))
                    {
                        rbEmailPerusahaan.Enabled = true;
                        rbEmailPerusahaan.Checked = true;

                        rbEmailPribadi.Enabled = false;
                        rbEmailPribadi.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorDBox(ex.Message.ToString(), " cmbEmail_SelectedIndexChanged()");
            }
        }

        private void cmbNoKontak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInfoKontakFlag != 0)
            {
                //MessageBox.Show("Selected item : " + cmbNoKontak.SelectedItem.ToString() + ", " + cmbNoKontak.SelectedIndex.ToString() + ", " + cmbNoKontak.SelectedText.ToString() + ", Tes");
                string jenisKontak = Convert.ToString(iknDAO.getByNikNByNoKontak(txtNIK.Text, cmbNoKontak.SelectedItem.ToString()).Jenis_Kontak);

                Identitas idt = idtDAO.getInfoIdentitasByNoIdentitas(cmbNoIdent.Text);

                if (jenisKontak.Equals("HP") || jenisKontak.Equals("Handphone"))
                {
                    rbHP.Enabled = true;
                    rbHP.Checked = true;

                    rbTlp.Enabled = false;
                    rbTlp.Checked = false;
                }
                else if (jenisKontak.Equals("Telpon"))
                {
                    rbHP.Enabled = false;
                    rbHP.Checked = false;

                    rbTlp.Enabled = true;
                    rbTlp.Checked = true;
                }
            }            
        }

        private void cmbLembaga_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInfoPendidikanFlag != 0)
            {
                Pendidikan pdk = pdkDAO.getInfoPendidikanByJenjang(cmbLembaga.SelectedItem.ToString(), txtNIK.Text);
                //Pendidikan pdk = pdkDAO.getInfoPendidikanByJenjang("SD", "1.1.12.0045");                                
                //MessageBox.Show("Tahun masuk = " + pdk.Lembaga);

                if (pdk != null)
                {
                    txtTahunMasuk.Text = string.Format("{0:dd/MM/yyyy}", pdk.Tahun_masuk);
                    txtTahunLulus.Text = string.Format("{0:dd/MM/yyyy}", pdk.Tahun_lulus);
                }
            }
        }            

        private void cmbNoIdent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbNoIdent.SelectedItem.ToString());  //=> Benar
            //MessageBox.Show(cmbNoIdent.SelectedText);             //=> Salah

            if (cmbInfoIdentitasFlag != 0)
            {
                //MessageBox.Show(cmbNoIdent.SelectedItem.ToString());
            
                Identitas idt = idtDAO.getInfoIdentitasByNoIdentitas(cmbNoIdent.SelectedItem.ToString());

                txtJenisID.Text = idt.Jenis_Identitas;
                txtMasaBerlaku.Text = string.Format("{0:dd/MM/yyyy}", idt.Masa_Berlaku);
                
            } 
        }

        //Implementasi Interface  iListener
        #region iListener Members

        //==============================================================================================
        //Revision. Second Coding
        //===============================================================================================
        public void Ok(object[] data, int genIntNumb, int init)
        {
            if (init == 1) //txtGBInfoPakaian -> Informasi Ukuran Pakaian
            {
                txtUkuranBaju.Text = data[0].ToString();
                txtUkuranCelana.Text = data[1].ToString();
                txtUkuranSepatu.Text = data[2].ToString();
            }
            
            if (init == 2) //txtGBInfoEmail -> Informasi Email
            {
                //loadAlamatEmail(cmbEmail);
                loadTxtGBEmail(cmbEmail);
                
                string email = data[1].ToString();
                //MessageBox.Show(email);

                if (data[1].ToString().Equals("Pribadi"))
                {
                    rbEmailPribadi.Checked = true;
                    rbEmailPerusahaan.Checked = false;

                    rbEmailPribadi.Enabled = true;
                    rbEmailPerusahaan.Enabled = false;
                }
                else
                {
                    rbEmailPerusahaan.Checked = true;
                    rbEmailPribadi.Checked = false;

                    rbEmailPerusahaan.Enabled = true;
                    rbEmailPribadi.Enabled = false;
                }

                /*
                if (data[0] != null)
                {
                    cmbEmail.SelectedItem = data[0].ToString();
                }
                else
                {
                    //cmbEmail.SelectedItem = null;
                }
                */

                //cmbEmail.Items.Insert(0, "Tes");
                lblJumlahEmail.Text = "Jumlah : " + genIntNumb.ToString();
            }
            
            if (init == 3) //txtGBInfoResign -> Informasi Resign
            {
                if (data[0].ToString().Equals("Yes"))
                {
                    rbStatusResignNO.Checked = false;
                    rbStatusResignYES.Checked = true;

                    rbStatusResignNO.Enabled = false;
                    rbStatusResignYES.Enabled = true;
                }
                else
                {
                    rbStatusResignNO.Checked = true;
                    rbStatusResignYES.Checked = false;

                    rbStatusResignNO.Enabled = true;
                    rbStatusResignYES.Enabled = false;
                }
            }

            if (init == 4)
            {                
                if (data[0] != null)
                {
                    //loadTxtGBInfoKontak(cmbNoKontak);
                    //cmbLembaga.SelectedItem = dftPdk[0].Lembaga;
                    cmbNoKontak.SelectedItem = data[2].ToString();

                    if (data[0].ToString().Equals("Telpon"))
                    {
                        rbHP.Enabled = false;
                        rbHP.Checked = false;

                        rbTlp.Enabled = true;
                        rbTlp.Checked = true;
                    }
                    else if (data[0].ToString().Equals("HP") || data[0].Equals("Handphone"))
                    {
                        rbHP.Enabled = true;
                        rbHP.Checked = true;

                        rbTlp.Enabled = false;
                        rbTlp.Checked = false;
                    }
                }
                else
                {
                    cmbNoKontak.SelectedValue = null;

                    rbHP.Enabled = false;
                    rbHP.Checked = false;

                    rbTlp.Enabled = false;
                    rbTlp.Checked = false;
                }
            }
        }

        public void Ok(string[] data, int init)
        {
            if (init == 2) //txtGBInfoEmail -> Fill txtxGBInfoEmail by String[], without access DAO
            {
                //loadAlamatEmail(cmbEmail);
                loadTxtGBEmail(cmbEmail);
                
                //string email = data[1];
                //MessageBox.Show(email);
                if (!(data[0].Equals("")))
                {
                    if (data[1].Equals("Pribadi"))
                    {
                        rbEmailPribadi.Checked = true;
                        rbEmailPerusahaan.Checked = false;

                        rbEmailPribadi.Enabled = true;
                        rbEmailPerusahaan.Enabled = false;
                    }
                    else
                    {
                        rbEmailPerusahaan.Checked = true;
                        rbEmailPribadi.Checked = false;

                        rbEmailPribadi.Enabled = false;
                        rbEmailPerusahaan.Enabled = true;
                    }

                    cmbEmail.SelectedItem = data[0];
                    //cmbEmail.Items.Insert(0, "Tes");
                    //lblJumlahEmail.Text = "Jumlah : " + jmlEmail.ToString();
                }
                else
                {
                    cmbEmail.SelectedIndex = -1;

                    rbEmailPerusahaan.Checked = false;
                    rbEmailPribadi.Checked = false;

                    rbEmailPribadi.Enabled = false;
                    rbEmailPerusahaan.Enabled = false;
                }
            }

            if (init == 4)
            {
                //LoadInfoKontak
                loadTxtGBInfoKontak(cmbNoKontak);

                if (!(data[0].Equals("")))
                {
                    cmbNoKontak.SelectedItem = data[0];

                    if (data[1].ToString().Equals("HP") || data[1].ToString().Equals("Handphone"))
                    {
                        rbHP.Enabled = true;
                        rbHP.Checked = true;

                        rbTlp.Enabled = false;
                        rbTlp.Checked = false;
                    }
                    else if (data[1].ToString().Equals("Telpon"))
                    {
                        rbHP.Enabled = false;
                        rbHP.Checked = false;

                        rbTlp.Enabled = true;
                        rbTlp.Checked = true;
                    }
                }
                else
                {
                    cmbNoKontak.SelectedIndex = -1;

                    rbHP.Enabled = false;
                    rbHP.Checked = false;

                    rbTlp.Enabled = false;
                    rbTlp.Checked = false;
                }
            }

            if (init == 5)
            {
                //loadInfoPendidikan
                loadtxtGBInfoPendidikan(cmbLembaga);

                cmbLembaga.SelectedItem = data[2];
               
                txtTahunMasuk.Text = data[0];
                txtTahunLulus.Text = data[1];
            }

            if (init == 6)
            {
                //loadIdentitas
                loadTxtGBIdentitas(cmbNoIdent);

                //MessageBox.Show(data[0]);

                if (data[0].Equals(""))
                {
                    cmbNoIdent.SelectedIndex = -1;

                    txtJenisID.Text = "";
                    txtMasaBerlaku.Text = "";
                }
                else
                {
                    cmbNoIdent.SelectedItem = data[0];

                    txtJenisID.Text = data[1];
                    txtMasaBerlaku.Text = data[2];
                }
            }
        }

        public void setFlag(int wFlag)
        {
            if (wFlag == 2)
            {
                this.cmbEmailFlag = 2;
            }
            else if (wFlag == 4)
            {
                this.cmbInfoKontakFlag = 4;
            }
            else if (wFlag == 5)
            {
                this.cmbInfoPendidikanFlag = 5;
            }
            else if (wFlag == 6)
            {
                this.cmbInfoIdentitasFlag = 6;
            }
        }
                
               
        //==============================================================================================
        //End of Revision. Second Coding
        //===============================================================================================
        
        #endregion
    }
}
