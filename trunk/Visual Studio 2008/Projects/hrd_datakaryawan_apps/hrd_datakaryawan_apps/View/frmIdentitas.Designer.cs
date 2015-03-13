namespace hrd_datakaryawan_apps.View
{
    partial class frmIdentitas
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
            this.lblMsgString = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNik = new System.Windows.Forms.TextBox();
            this.txtNoIdentitas = new System.Windows.Forms.TextBox();
            this.txtMasaBerlaku = new System.Windows.Forms.TextBox();
            this.txtJenisIdentitas = new System.Windows.Forms.TextBox();
            this.lvwIdentitas = new System.Windows.Forms.ListView();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMsgString
            // 
            this.lblMsgString.BackColor = System.Drawing.Color.Olive;
            this.lblMsgString.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsgString.Location = new System.Drawing.Point(0, 0);
            this.lblMsgString.Name = "lblMsgString";
            this.lblMsgString.Size = new System.Drawing.Size(255, 39);
            this.lblMsgString.TabIndex = 0;
            this.lblMsgString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NIK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Identitas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jenis Identitas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Masa Berlaku";
            // 
            // txtNik
            // 
            this.txtNik.Location = new System.Drawing.Point(92, 46);
            this.txtNik.MaxLength = 11;
            this.txtNik.Name = "txtNik";
            this.txtNik.ReadOnly = true;
            this.txtNik.Size = new System.Drawing.Size(121, 20);
            this.txtNik.TabIndex = 1;
            // 
            // txtNoIdentitas
            // 
            this.txtNoIdentitas.Location = new System.Drawing.Point(92, 69);
            this.txtNoIdentitas.MaxLength = 30;
            this.txtNoIdentitas.Name = "txtNoIdentitas";
            this.txtNoIdentitas.Size = new System.Drawing.Size(141, 20);
            this.txtNoIdentitas.TabIndex = 2;
            // 
            // txtMasaBerlaku
            // 
            this.txtMasaBerlaku.Location = new System.Drawing.Point(92, 114);
            this.txtMasaBerlaku.MaxLength = 10;
            this.txtMasaBerlaku.Name = "txtMasaBerlaku";
            this.txtMasaBerlaku.Size = new System.Drawing.Size(72, 20);
            this.txtMasaBerlaku.TabIndex = 4;
            // 
            // txtJenisIdentitas
            // 
            this.txtJenisIdentitas.Location = new System.Drawing.Point(92, 90);
            this.txtJenisIdentitas.MaxLength = 5;
            this.txtJenisIdentitas.Name = "txtJenisIdentitas";
            this.txtJenisIdentitas.Size = new System.Drawing.Size(58, 20);
            this.txtJenisIdentitas.TabIndex = 3;
            // 
            // lvwIdentitas
            // 
            this.lvwIdentitas.Location = new System.Drawing.Point(3, 142);
            this.lvwIdentitas.Name = "lvwIdentitas";
            this.lvwIdentitas.Size = new System.Drawing.Size(247, 108);
            this.lvwIdentitas.TabIndex = 5;
            this.lvwIdentitas.UseCompatibleStateImageBehavior = false;
            this.lvwIdentitas.SelectedIndexChanged += new System.EventHandler(this.lvwIdentitas_SelectedIndexChanged);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(2, 259);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(81, 259);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(190, 259);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(60, 23);
            this.btnTutup.TabIndex = 8;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // frmIdentitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 291);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.lvwIdentitas);
            this.Controls.Add(this.txtJenisIdentitas);
            this.Controls.Add(this.txtMasaBerlaku);
            this.Controls.Add(this.txtNoIdentitas);
            this.Controls.Add(this.txtNik);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMsgString);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmIdentitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identitas";
            this.Load += new System.EventHandler(this.frmIdentitas_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIdentitas_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsgString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNik;
        private System.Windows.Forms.TextBox txtNoIdentitas;
        private System.Windows.Forms.TextBox txtMasaBerlaku;
        private System.Windows.Forms.TextBox txtJenisIdentitas;
        private System.Windows.Forms.ListView lvwIdentitas;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTutup;
    }
}