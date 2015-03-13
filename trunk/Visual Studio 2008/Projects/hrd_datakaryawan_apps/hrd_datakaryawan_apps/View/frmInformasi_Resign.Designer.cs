namespace hrd_datakaryawan_apps.View
{
    partial class frmInformasi_Resign
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
            this.lblMsgInfoResign = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbStatusResignYes = new System.Windows.Forms.RadioButton();
            this.rbStatusResignNo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTanggalResign = new System.Windows.Forms.TextBox();
            this.txtAlasanResign = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMsgInfoResign
            // 
            this.lblMsgInfoResign.BackColor = System.Drawing.Color.Gray;
            this.lblMsgInfoResign.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsgInfoResign.Location = new System.Drawing.Point(0, 0);
            this.lblMsgInfoResign.Name = "lblMsgInfoResign";
            this.lblMsgInfoResign.Size = new System.Drawing.Size(332, 43);
            this.lblMsgInfoResign.TabIndex = 70;
            this.lblMsgInfoResign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tanggal Resign :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Alasan Resign :";
            // 
            // rbStatusResignYes
            // 
            this.rbStatusResignYes.AutoSize = true;
            this.rbStatusResignYes.Location = new System.Drawing.Point(10, 26);
            this.rbStatusResignYes.Name = "rbStatusResignYes";
            this.rbStatusResignYes.Size = new System.Drawing.Size(43, 17);
            this.rbStatusResignYes.TabIndex = 0;
            this.rbStatusResignYes.Text = "Yes";
            this.rbStatusResignYes.UseVisualStyleBackColor = true;
            this.rbStatusResignYes.CheckedChanged += new System.EventHandler(this.rbStatusResignYes_CheckedChanged);
            // 
            // rbStatusResignNo
            // 
            this.rbStatusResignNo.AutoSize = true;
            this.rbStatusResignNo.Checked = true;
            this.rbStatusResignNo.Location = new System.Drawing.Point(77, 26);
            this.rbStatusResignNo.Name = "rbStatusResignNo";
            this.rbStatusResignNo.Size = new System.Drawing.Size(39, 17);
            this.rbStatusResignNo.TabIndex = 1;
            this.rbStatusResignNo.TabStop = true;
            this.rbStatusResignNo.Text = "No";
            this.rbStatusResignNo.UseVisualStyleBackColor = true;
            this.rbStatusResignNo.CheckedChanged += new System.EventHandler(this.rbStatusResignNo_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbStatusResignNo);
            this.groupBox1.Controls.Add(this.rbStatusResignYes);
            this.groupBox1.Location = new System.Drawing.Point(7, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 59);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status Resign";
            // 
            // txtTanggalResign
            // 
            this.txtTanggalResign.Location = new System.Drawing.Point(98, 125);
            this.txtTanggalResign.MaxLength = 10;
            this.txtTanggalResign.Name = "txtTanggalResign";
            this.txtTanggalResign.Size = new System.Drawing.Size(109, 20);
            this.txtTanggalResign.TabIndex = 2;
            // 
            // txtAlasanResign
            // 
            this.txtAlasanResign.Location = new System.Drawing.Point(98, 156);
            this.txtAlasanResign.Multiline = true;
            this.txtAlasanResign.Name = "txtAlasanResign";
            this.txtAlasanResign.Size = new System.Drawing.Size(229, 82);
            this.txtAlasanResign.TabIndex = 3;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(7, 250);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 4;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(98, 250);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 5;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(252, 250);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 6;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmInformasi_Resign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 280);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtAlasanResign);
            this.Controls.Add(this.txtTanggalResign);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMsgInfoResign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInformasi_Resign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informasi Resign";
            this.Load += new System.EventHandler(this.frmInformasi_Resign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsgInfoResign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbStatusResignYes;
        private System.Windows.Forms.RadioButton rbStatusResignNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTanggalResign;
        private System.Windows.Forms.TextBox txtAlasanResign;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTutup;
    }
}