namespace hrd_datakaryawan_apps.View
{
    partial class frmPendidikan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtJenjangPendidikan = new System.Windows.Forms.TextBox();
            this.txtLembaga = new System.Windows.Forms.TextBox();
            this.txtJurusan = new System.Windows.Forms.TextBox();
            this.txtTahuMasuk = new System.Windows.Forms.TextBox();
            this.txtTahunLulus = new System.Windows.Forms.TextBox();
            this.txtNik = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNonFormal = new System.Windows.Forms.RadioButton();
            this.rbFormal = new System.Windows.Forms.RadioButton();
            this.lvwInformasiPendidikan = new System.Windows.Forms.ListView();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnHapus = new System.Windows.Forms.Button();
            this.txtTutup = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Olive;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(722, 40);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMsg.UseMnemonic = false;
            // 
            // txtJenjangPendidikan
            // 
            this.txtJenjangPendidikan.Location = new System.Drawing.Point(87, 79);
            this.txtJenjangPendidikan.MaxLength = 3;
            this.txtJenjangPendidikan.Name = "txtJenjangPendidikan";
            this.txtJenjangPendidikan.Size = new System.Drawing.Size(48, 20);
            this.txtJenjangPendidikan.TabIndex = 2;
            // 
            // txtLembaga
            // 
            this.txtLembaga.Location = new System.Drawing.Point(87, 101);
            this.txtLembaga.MaxLength = 50;
            this.txtLembaga.Name = "txtLembaga";
            this.txtLembaga.Size = new System.Drawing.Size(164, 20);
            this.txtLembaga.TabIndex = 4;
            // 
            // txtJurusan
            // 
            this.txtJurusan.Location = new System.Drawing.Point(87, 124);
            this.txtJurusan.MaxLength = 50;
            this.txtJurusan.Name = "txtJurusan";
            this.txtJurusan.Size = new System.Drawing.Size(164, 20);
            this.txtJurusan.TabIndex = 5;
            // 
            // txtTahuMasuk
            // 
            this.txtTahuMasuk.Location = new System.Drawing.Point(87, 149);
            this.txtTahuMasuk.MaxLength = 10;
            this.txtTahuMasuk.Name = "txtTahuMasuk";
            this.txtTahuMasuk.Size = new System.Drawing.Size(86, 20);
            this.txtTahuMasuk.TabIndex = 6;
            // 
            // txtTahunLulus
            // 
            this.txtTahunLulus.Location = new System.Drawing.Point(87, 173);
            this.txtTahunLulus.MaxLength = 10;
            this.txtTahunLulus.Name = "txtTahunLulus";
            this.txtTahunLulus.Size = new System.Drawing.Size(86, 20);
            this.txtTahunLulus.TabIndex = 7;
            // 
            // txtNik
            // 
            this.txtNik.Location = new System.Drawing.Point(87, 57);
            this.txtNik.Name = "txtNik";
            this.txtNik.ReadOnly = true;
            this.txtNik.Size = new System.Drawing.Size(110, 20);
            this.txtNik.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 60);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "NIK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Jenjang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lembaga";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Jurusan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tahun Masuk";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tahun Lulus";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNonFormal);
            this.groupBox1.Controls.Add(this.rbFormal);
            this.groupBox1.Location = new System.Drawing.Point(8, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 49);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jenis Pendidikan";
            // 
            // rbNonFormal
            // 
            this.rbNonFormal.AutoSize = true;
            this.rbNonFormal.Location = new System.Drawing.Point(155, 19);
            this.rbNonFormal.Name = "rbNonFormal";
            this.rbNonFormal.Size = new System.Drawing.Size(79, 17);
            this.rbNonFormal.TabIndex = 9;
            this.rbNonFormal.TabStop = true;
            this.rbNonFormal.Text = "Non Formal";
            this.rbNonFormal.UseVisualStyleBackColor = true;
            // 
            // rbFormal
            // 
            this.rbFormal.AutoSize = true;
            this.rbFormal.Location = new System.Drawing.Point(9, 19);
            this.rbFormal.Name = "rbFormal";
            this.rbFormal.Size = new System.Drawing.Size(56, 17);
            this.rbFormal.TabIndex = 8;
            this.rbFormal.TabStop = true;
            this.rbFormal.Text = "Formal";
            this.rbFormal.UseVisualStyleBackColor = true;
            // 
            // lvwInformasiPendidikan
            // 
            this.lvwInformasiPendidikan.Location = new System.Drawing.Point(259, 57);
            this.lvwInformasiPendidikan.Name = "lvwInformasiPendidikan";
            this.lvwInformasiPendidikan.Size = new System.Drawing.Size(457, 231);
            this.lvwInformasiPendidikan.TabIndex = 13;
            this.lvwInformasiPendidikan.UseCompatibleStateImageBehavior = false;
            this.lvwInformasiPendidikan.SelectedIndexChanged += new System.EventHandler(this.lvwInformasiPendidikan_SelectedIndexChanged);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(8, 265);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 10;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(214, 173);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(37, 20);
            this.txtId.TabIndex = 21;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(89, 265);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 11;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // txtTutup
            // 
            this.txtTutup.Location = new System.Drawing.Point(176, 265);
            this.txtTutup.Name = "txtTutup";
            this.txtTutup.Size = new System.Drawing.Size(75, 23);
            this.txtTutup.TabIndex = 12;
            this.txtTutup.Text = "Tutup";
            this.txtTutup.UseVisualStyleBackColor = true;
            this.txtTutup.Click += new System.EventHandler(this.txtTutup_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(198, 80);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Clear Text";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmPendidikan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 300);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtTutup);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.lvwInformasiPendidikan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNik);
            this.Controls.Add(this.txtTahunLulus);
            this.Controls.Add(this.txtTahuMasuk);
            this.Controls.Add(this.txtJurusan);
            this.Controls.Add(this.txtLembaga);
            this.Controls.Add(this.txtJenjangPendidikan);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPendidikan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pendidikan";
            this.Load += new System.EventHandler(this.frmPendidikan_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPendidikan_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtJenjangPendidikan;
        private System.Windows.Forms.TextBox txtLembaga;
        private System.Windows.Forms.TextBox txtJurusan;
        private System.Windows.Forms.TextBox txtTahuMasuk;
        private System.Windows.Forms.TextBox txtTahunLulus;
        private System.Windows.Forms.TextBox txtNik;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNonFormal;
        private System.Windows.Forms.RadioButton rbFormal;
        private System.Windows.Forms.ListView lvwInformasiPendidikan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button txtTutup;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}