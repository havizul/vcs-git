namespace hrd_datakaryawan_apps.View
{
    partial class frmInformasi_Email
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
            this.lblEmailLama = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.txtAlamatEmailSekarang = new System.Windows.Forms.TextBox();
            this.txtAlamatEmailBaru = new System.Windows.Forms.TextBox();
            this.cmbKepemilikanEmail = new System.Windows.Forms.ComboBox();
            this.lvwInformasiEmail = new System.Windows.Forms.ListView();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.lblListEmail = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblEmailBaru = new System.Windows.Forms.Label();
            this.lblEmailBaru2 = new System.Windows.Forms.Label();
            this.lblTambahEmail = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(301, 39);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmailLama
            // 
            this.lblEmailLama.AutoSize = true;
            this.lblEmailLama.Location = new System.Drawing.Point(43, 74);
            this.lblEmailLama.Name = "lblEmailLama";
            this.lblEmailLama.Size = new System.Drawing.Size(61, 13);
            this.lblEmailLama.TabIndex = 1;
            this.lblEmailLama.Text = "Email Lama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kepemilikan Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "NIK";
            // 
            // txtNIK
            // 
            this.txtNIK.Location = new System.Drawing.Point(110, 45);
            this.txtNIK.MaxLength = 11;
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.ReadOnly = true;
            this.txtNIK.Size = new System.Drawing.Size(97, 20);
            this.txtNIK.TabIndex = 0;
            // 
            // txtAlamatEmailSekarang
            // 
            this.txtAlamatEmailSekarang.Location = new System.Drawing.Point(110, 71);
            this.txtAlamatEmailSekarang.MaxLength = 30;
            this.txtAlamatEmailSekarang.Name = "txtAlamatEmailSekarang";
            this.txtAlamatEmailSekarang.ReadOnly = true;
            this.txtAlamatEmailSekarang.Size = new System.Drawing.Size(121, 20);
            this.txtAlamatEmailSekarang.TabIndex = 1;
            // 
            // txtAlamatEmailBaru
            // 
            this.txtAlamatEmailBaru.Location = new System.Drawing.Point(110, 96);
            this.txtAlamatEmailBaru.MaxLength = 30;
            this.txtAlamatEmailBaru.Name = "txtAlamatEmailBaru";
            this.txtAlamatEmailBaru.ReadOnly = true;
            this.txtAlamatEmailBaru.Size = new System.Drawing.Size(121, 20);
            this.txtAlamatEmailBaru.TabIndex = 2;
            // 
            // cmbKepemilikanEmail
            // 
            this.cmbKepemilikanEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKepemilikanEmail.FormattingEnabled = true;
            this.cmbKepemilikanEmail.Items.AddRange(new object[] {
            "Pribadi",
            "Perusahaan"});
            this.cmbKepemilikanEmail.Location = new System.Drawing.Point(110, 120);
            this.cmbKepemilikanEmail.Name = "cmbKepemilikanEmail";
            this.cmbKepemilikanEmail.Size = new System.Drawing.Size(121, 21);
            this.cmbKepemilikanEmail.TabIndex = 3;
            // 
            // lvwInformasiEmail
            // 
            this.lvwInformasiEmail.Location = new System.Drawing.Point(12, 149);
            this.lvwInformasiEmail.Name = "lvwInformasiEmail";
            this.lvwInformasiEmail.Size = new System.Drawing.Size(277, 150);
            this.lvwInformasiEmail.TabIndex = 7;
            this.lvwInformasiEmail.UseCompatibleStateImageBehavior = false;
            this.lvwInformasiEmail.SelectedIndexChanged += new System.EventHandler(this.lvwInformasiEmail_SelectedIndexChanged);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(12, 312);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(60, 23);
            this.btnSimpan.TabIndex = 8;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(78, 312);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(60, 23);
            this.btnHapus.TabIndex = 9;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(221, 312);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(68, 23);
            this.btnTutup.TabIndex = 10;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // lblListEmail
            // 
            this.lblListEmail.AutoSize = true;
            this.lblListEmail.Location = new System.Drawing.Point(237, 125);
            this.lblListEmail.Name = "lblListEmail";
            this.lblListEmail.Size = new System.Drawing.Size(51, 13);
            this.lblListEmail.TabIndex = 6;
            this.lblListEmail.TabStop = true;
            this.lblListEmail.Text = "List Email";
            this.lblListEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblListEmail_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(237, 99);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(33, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Ubah";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblEmailBaru
            // 
            this.lblEmailBaru.AutoSize = true;
            this.lblEmailBaru.Location = new System.Drawing.Point(42, 107);
            this.lblEmailBaru.Name = "lblEmailBaru";
            this.lblEmailBaru.Size = new System.Drawing.Size(0, 13);
            this.lblEmailBaru.TabIndex = 13;
            // 
            // lblEmailBaru2
            // 
            this.lblEmailBaru2.AutoSize = true;
            this.lblEmailBaru2.Location = new System.Drawing.Point(48, 99);
            this.lblEmailBaru2.Name = "lblEmailBaru2";
            this.lblEmailBaru2.Size = new System.Drawing.Size(57, 13);
            this.lblEmailBaru2.TabIndex = 14;
            this.lblEmailBaru2.Text = "Email Baru";
            // 
            // lblTambahEmail
            // 
            this.lblTambahEmail.AutoSize = true;
            this.lblTambahEmail.Location = new System.Drawing.Point(237, 73);
            this.lblTambahEmail.Name = "lblTambahEmail";
            this.lblTambahEmail.Size = new System.Drawing.Size(46, 13);
            this.lblTambahEmail.TabIndex = 4;
            this.lblTambahEmail.TabStop = true;
            this.lblTambahEmail.Text = "Tambah";
            this.lblTambahEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTambahEmail_LinkClicked);
            // 
            // frmInformasi_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 343);
            this.Controls.Add(this.lblTambahEmail);
            this.Controls.Add(this.lblEmailBaru2);
            this.Controls.Add(this.lblEmailBaru);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblListEmail);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.lvwInformasiEmail);
            this.Controls.Add(this.cmbKepemilikanEmail);
            this.Controls.Add(this.txtAlamatEmailBaru);
            this.Controls.Add(this.txtAlamatEmailSekarang);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEmailLama);
            this.Controls.Add(this.lblMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInformasi_Email";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informasi Email";
            this.Load += new System.EventHandler(this.frmInformasi_Email_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInformasi_Email_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblEmailLama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.TextBox txtAlamatEmailSekarang;
        private System.Windows.Forms.TextBox txtAlamatEmailBaru;
        private System.Windows.Forms.ComboBox cmbKepemilikanEmail;
        private System.Windows.Forms.ListView lvwInformasiEmail;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.LinkLabel lblListEmail;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblEmailBaru;
        private System.Windows.Forms.Label lblEmailBaru2;
        private System.Windows.Forms.LinkLabel lblTambahEmail;
    }
}