namespace hrd_datakaryawan_apps.View
{
    partial class frmListAllInformasiEmail
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
            this.lvwListAllEmail = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.btnTutup = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwListAllEmail
            // 
            this.lvwListAllEmail.Location = new System.Drawing.Point(2, 12);
            this.lvwListAllEmail.Name = "lvwListAllEmail";
            this.lvwListAllEmail.Size = new System.Drawing.Size(358, 284);
            this.lvwListAllEmail.TabIndex = 0;
            this.lvwListAllEmail.UseCompatibleStateImageBehavior = false;
            this.lvwListAllEmail.SelectedIndexChanged += new System.EventHandler(this.lvwListAllEmail_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCari);
            this.groupBox1.Controls.Add(this.txtNIK);
            this.groupBox1.Location = new System.Drawing.Point(4, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter By NIK";
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(143, 21);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 23);
            this.btnCari.TabIndex = 1;
            this.btnCari.Text = "Filter";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // txtNIK
            // 
            this.txtNIK.Location = new System.Drawing.Point(6, 23);
            this.txtNIK.MaxLength = 11;
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(118, 20);
            this.txtNIK.TabIndex = 0;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(285, 317);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 2;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // frmListAllInformasiEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 357);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwListAllEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmListAllInformasiEmail";
            this.Text = "Daftar Email Karyawan";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmListAllInformasiEmail_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListAllInformasiEmail_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwListAllEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.Button btnTutup;
    }
}