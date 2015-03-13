namespace hrd_datakaryawan_apps.View
{
    partial class frmInformasi_Kontak
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoKontak = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTelpon = new System.Windows.Forms.RadioButton();
            this.rbHandphone = new System.Windows.Forms.RadioButton();
            this.lvwInfoKontak = new System.Windows.Forms.ListView();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.lblMsgStr = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTambah = new System.Windows.Forms.RadioButton();
            this.rbUbah = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NIK";
            // 
            // txtNIK
            // 
            this.txtNIK.Location = new System.Drawing.Point(94, 55);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.ReadOnly = true;
            this.txtNIK.Size = new System.Drawing.Size(135, 20);
            this.txtNIK.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(94, 77);
            this.txtNama.Name = "txtNama";
            this.txtNama.ReadOnly = true;
            this.txtNama.Size = new System.Drawing.Size(193, 20);
            this.txtNama.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "No. Kontak";
            // 
            // txtNoKontak
            // 
            this.txtNoKontak.Location = new System.Drawing.Point(94, 99);
            this.txtNoKontak.Name = "txtNoKontak";
            this.txtNoKontak.Size = new System.Drawing.Size(135, 20);
            this.txtNoKontak.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTelpon);
            this.groupBox1.Controls.Add(this.rbHandphone);
            this.groupBox1.Location = new System.Drawing.Point(3, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jenis Kontak";
            // 
            // rbTelpon
            // 
            this.rbTelpon.AutoSize = true;
            this.rbTelpon.Location = new System.Drawing.Point(15, 42);
            this.rbTelpon.Name = "rbTelpon";
            this.rbTelpon.Size = new System.Drawing.Size(58, 17);
            this.rbTelpon.TabIndex = 4;
            this.rbTelpon.TabStop = true;
            this.rbTelpon.Text = "Telpon";
            this.rbTelpon.UseVisualStyleBackColor = true;
            // 
            // rbHandphone
            // 
            this.rbHandphone.AutoSize = true;
            this.rbHandphone.Location = new System.Drawing.Point(15, 23);
            this.rbHandphone.Name = "rbHandphone";
            this.rbHandphone.Size = new System.Drawing.Size(85, 17);
            this.rbHandphone.TabIndex = 3;
            this.rbHandphone.TabStop = true;
            this.rbHandphone.Text = "Hand Phone";
            this.rbHandphone.UseVisualStyleBackColor = true;
            // 
            // lvwInfoKontak
            // 
            this.lvwInfoKontak.Location = new System.Drawing.Point(5, 240);
            this.lvwInfoKontak.Name = "lvwInfoKontak";
            this.lvwInfoKontak.Size = new System.Drawing.Size(282, 103);
            this.lvwInfoKontak.TabIndex = 5;
            this.lvwInfoKontak.UseCompatibleStateImageBehavior = false;
            this.lvwInfoKontak.SelectedIndexChanged += new System.EventHandler(this.lvwInfoKontak_SelectedIndexChanged);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(5, 352);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(86, 353);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(212, 353);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 8;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // lblMsgStr
            // 
            this.lblMsgStr.BackColor = System.Drawing.Color.Olive;
            this.lblMsgStr.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsgStr.Location = new System.Drawing.Point(0, 0);
            this.lblMsgStr.Name = "lblMsgStr";
            this.lblMsgStr.Size = new System.Drawing.Size(292, 42);
            this.lblMsgStr.TabIndex = 12;
            this.lblMsgStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTambah);
            this.groupBox2.Controls.Add(this.rbUbah);
            this.groupBox2.Location = new System.Drawing.Point(94, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 38);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // rbTambah
            // 
            this.rbTambah.AutoSize = true;
            this.rbTambah.Location = new System.Drawing.Point(65, 12);
            this.rbTambah.Name = "rbTambah";
            this.rbTambah.Size = new System.Drawing.Size(64, 17);
            this.rbTambah.TabIndex = 1;
            this.rbTambah.TabStop = true;
            this.rbTambah.Text = "Tambah";
            this.rbTambah.UseVisualStyleBackColor = true;
            // 
            // rbUbah
            // 
            this.rbUbah.AutoSize = true;
            this.rbUbah.Location = new System.Drawing.Point(6, 12);
            this.rbUbah.Name = "rbUbah";
            this.rbUbah.Size = new System.Drawing.Size(51, 17);
            this.rbUbah.TabIndex = 0;
            this.rbUbah.TabStop = true;
            this.rbUbah.Text = "Ubah";
            this.rbUbah.UseVisualStyleBackColor = true;
            // 
            // frmInformasi_Kontak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 381);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblMsgStr);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.lvwInfoKontak);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNoKontak);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInformasi_Kontak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informasi Kontak";
            this.Load += new System.EventHandler(this.frmInformasi_Kontak_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInformasi_Kontak_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsgString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoKontak;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHandphone;
        private System.Windows.Forms.RadioButton rbTelpon;
        private System.Windows.Forms.ListView lvwInfoKontak;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Label lblMsgStr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTambah;
        private System.Windows.Forms.RadioButton rbUbah;
    }
}