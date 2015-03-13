namespace PrimeNumbers
{
    partial class Form1
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
            this.btnProses = new System.Windows.Forms.Button();
            this.txtNilain = new System.Windows.Forms.TextBox();
            this.btnTutup = new System.Windows.Forms.Button();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.lnkLblSave = new System.Windows.Forms.LinkLabel();
            this.lblError = new System.Windows.Forms.Label();
            this.txtHasil = new System.Windows.Forms.TextBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.lnkFile = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Batas Bilangan Prima (n)  :";
            // 
            // btnProses
            // 
            this.btnProses.Location = new System.Drawing.Point(15, 145);
            this.btnProses.Name = "btnProses";
            this.btnProses.Size = new System.Drawing.Size(49, 23);
            this.btnProses.TabIndex = 1;
            this.btnProses.Text = "Proses";
            this.btnProses.UseVisualStyleBackColor = true;
            this.btnProses.Click += new System.EventHandler(this.btnProses_Click);
            // 
            // txtNilain
            // 
            this.txtNilain.Location = new System.Drawing.Point(15, 64);
            this.txtNilain.Name = "txtNilain";
            this.txtNilain.ReadOnly = true;
            this.txtNilain.Size = new System.Drawing.Size(98, 20);
            this.txtNilain.TabIndex = 2;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(96, 180);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 3;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "Text files (*.txt)|*.txt";
            // 
            // lnkLblSave
            // 
            this.lnkLblSave.AutoSize = true;
            this.lnkLblSave.Location = new System.Drawing.Point(126, 150);
            this.lnkLblSave.Name = "lnkLblSave";
            this.lnkLblSave.Size = new System.Drawing.Size(42, 13);
            this.lnkLblSave.TabIndex = 5;
            this.lnkLblSave.TabStop = true;
            this.lnkLblSave.Text = "Simpan";
            this.lnkLblSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLblSave_LinkClicked);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Gray;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblError.Location = new System.Drawing.Point(0, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(183, 34);
            this.lblError.TabIndex = 6;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHasil
            // 
            this.txtHasil.Location = new System.Drawing.Point(15, 94);
            this.txtHasil.Multiline = true;
            this.txtHasil.Name = "txtHasil";
            this.txtHasil.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHasil.Size = new System.Drawing.Size(153, 45);
            this.txtHasil.TabIndex = 7;
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "*.txt";
            this.dlgOpen.Filter = "Text files (*.txt)|*.txt";
            // 
            // lnkFile
            // 
            this.lnkFile.AutoSize = true;
            this.lnkFile.Location = new System.Drawing.Point(123, 65);
            this.lnkFile.Name = "lnkFile";
            this.lnkFile.Size = new System.Drawing.Size(44, 13);
            this.lnkFile.TabIndex = 8;
            this.lnkFile.TabStop = true;
            this.lnkFile.Text = "Cari File";
            this.lnkFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFile_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 206);
            this.Controls.Add(this.lnkFile);
            this.Controls.Add(this.txtHasil);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lnkLblSave);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.txtNilain);
            this.Controls.Add(this.btnProses);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prime Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProses;
        private System.Windows.Forms.TextBox txtNilain;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.LinkLabel lnkLblSave;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtHasil;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.LinkLabel lnkFile;
    }
}

