namespace hrd_datakaryawan_apps.View
{
    partial class frmStatusPajak
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.txtKodeStatusPajak = new System.Windows.Forms.TextBox();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.linkLblClearText = new System.Windows.Forms.LinkLabel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuspajakPanel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kode Status Pajak";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Keterangan";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(7, 91);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 2;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(88, 91);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 3;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(231, 91);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 4;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // txtKodeStatusPajak
            // 
            this.txtKodeStatusPajak.Location = new System.Drawing.Point(105, 6);
            this.txtKodeStatusPajak.MaxLength = 5;
            this.txtKodeStatusPajak.Name = "txtKodeStatusPajak";
            this.txtKodeStatusPajak.Size = new System.Drawing.Size(53, 20);
            this.txtKodeStatusPajak.TabIndex = 0;
            this.txtKodeStatusPajak.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtKodeStatusPajak_PreviewKeyDown);
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(105, 32);
            this.txtKeterangan.Multiline = true;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(203, 52);
            this.txtKeterangan.TabIndex = 1;
            this.txtKeterangan.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtKeterangan_PreviewKeyDown);
            // 
            // linkLblClearText
            // 
            this.linkLblClearText.AutoSize = true;
            this.linkLblClearText.Location = new System.Drawing.Point(253, 6);
            this.linkLblClearText.Name = "linkLblClearText";
            this.linkLblClearText.Size = new System.Drawing.Size(55, 13);
            this.linkLblClearText.TabIndex = 6;
            this.linkLblClearText.TabStop = true;
            this.linkLblClearText.Text = "Clear Text";
            this.linkLblClearText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblClearText_LinkClicked);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(7, 120);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(299, 174);
            this.DGV.TabIndex = 5;
            this.DGV.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DGV_PreviewKeyDown);
            this.DGV.SelectionChanged += new System.EventHandler(this.DGV_SelectionChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuspajakPanel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 300);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(318, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuspajakPanel1
            // 
            this.statuspajakPanel1.Name = "statuspajakPanel1";
            this.statuspajakPanel1.Size = new System.Drawing.Size(0, 17);
            // 
            // frmStatusPajak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 322);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.linkLblClearText);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.txtKodeStatusPajak);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmStatusPajak";
            this.Text = "Status Pajak";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStatusPajak_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.TextBox txtKodeStatusPajak;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.LinkLabel linkLblClearText;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel statuspajakPanel1;
    }
}