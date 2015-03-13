namespace AplikasiPayrollDAO.View
{
    partial class frmGolongan
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
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGolongan = new System.Windows.Forms.TextBox();
            this.txtTjSuamiIstri = new System.Windows.Forms.TextBox();
            this.txtTjAnak = new System.Windows.Forms.TextBox();
            this.txtUangMakan = new System.Windows.Forms.TextBox();
            this.txtUangLembur = new System.Windows.Forms.TextBox();
            this.txtAskes = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(291, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Asuransi Kesehatan";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tunjangan Anak";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(291, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Uang Lembur";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(10, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tunjangan Suami Istri";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(291, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Uang Makan";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Golongan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGolongan
            // 
            this.txtGolongan.Location = new System.Drawing.Point(133, 11);
            this.txtGolongan.Name = "txtGolongan";
            this.txtGolongan.Size = new System.Drawing.Size(148, 20);
            this.txtGolongan.TabIndex = 0;
            this.txtGolongan.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtGolongan_PreviewKeyDown);
            // 
            // txtTjSuamiIstri
            // 
            this.txtTjSuamiIstri.Location = new System.Drawing.Point(133, 34);
            this.txtTjSuamiIstri.Name = "txtTjSuamiIstri";
            this.txtTjSuamiIstri.Size = new System.Drawing.Size(148, 20);
            this.txtTjSuamiIstri.TabIndex = 1;
            this.txtTjSuamiIstri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTjSuamiIstri_KeyPress);
            // 
            // txtTjAnak
            // 
            this.txtTjAnak.Location = new System.Drawing.Point(133, 58);
            this.txtTjAnak.Name = "txtTjAnak";
            this.txtTjAnak.Size = new System.Drawing.Size(148, 20);
            this.txtTjAnak.TabIndex = 2;
            this.txtTjAnak.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTjAnak_KeyPress);
            // 
            // txtUangMakan
            // 
            this.txtUangMakan.Location = new System.Drawing.Point(414, 11);
            this.txtUangMakan.Name = "txtUangMakan";
            this.txtUangMakan.Size = new System.Drawing.Size(148, 20);
            this.txtUangMakan.TabIndex = 3;
            this.txtUangMakan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUangMakan_KeyPress);
            // 
            // txtUangLembur
            // 
            this.txtUangLembur.Location = new System.Drawing.Point(414, 34);
            this.txtUangLembur.Name = "txtUangLembur";
            this.txtUangLembur.Size = new System.Drawing.Size(148, 20);
            this.txtUangLembur.TabIndex = 4;
            this.txtUangLembur.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUangLembur_KeyPress);
            // 
            // txtAskes
            // 
            this.txtAskes.Location = new System.Drawing.Point(414, 58);
            this.txtAskes.Name = "txtAskes";
            this.txtAskes.Size = new System.Drawing.Size(148, 20);
            this.txtAskes.TabIndex = 5;
            this.txtAskes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAskes_KeyPress);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(10, 89);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(91, 89);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(172, 89);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 8;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(253, 89);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 9;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(10, 121);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(552, 179);
            this.DGV.TabIndex = 9;
            this.DGV.SelectionChanged += new System.EventHandler(this.DGV_SelectionChanged);
            // 
            // frmGolongan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 309);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtAskes);
            this.Controls.Add(this.txtTjAnak);
            this.Controls.Add(this.txtUangLembur);
            this.Controls.Add(this.txtTjSuamiIstri);
            this.Controls.Add(this.txtUangMakan);
            this.Controls.Add(this.txtGolongan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmGolongan";
            this.Text = "Golongan";
            this.Load += new System.EventHandler(this.frmGolongan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGolongan;
        private System.Windows.Forms.TextBox txtTjSuamiIstri;
        private System.Windows.Forms.TextBox txtTjAnak;
        private System.Windows.Forms.TextBox txtUangMakan;
        private System.Windows.Forms.TextBox txtUangLembur;
        private System.Windows.Forms.TextBox txtAskes;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.DataGridView DGV;
    }
}