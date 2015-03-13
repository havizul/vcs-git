using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace PrimeNumbers
{
    public partial class Form1 : Form
    {
        string namaFile = string.Empty;
        string namaFileBaru = string.Empty;
        ArrayList prima = new ArrayList();
        string strPrime = string.Empty;
        int countElm = 1;  


        public Form1()
        {
            InitializeComponent();
        }
        
        private bool NumericOnly(string isiFile)
        {
            bool hasilNum = false;

            foreach (char c in isiFile)
            {
                if (!Char.IsDigit(c))
                {
                    hasilNum = false;
                }
                else
                {
                    hasilNum = true;
                }
            }

            return hasilNum;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProses_Click(object sender, EventArgs e)
        {

            try
            {                           
               
                int n = int.Parse(txtNilain.Text); //batas atas n dapat diganti dengan bilangan bulat lainnya

                for (int i = 1; i <= n; i++)
                {
                    if (i == 1) { }// not prime, skip
                    else if (i == 2 || i == 3 || i == 5 || i == 7)  //Prima
                    {
                        prima.Add(i.ToString());                        
                        countElm++;
                    } 
                    else if (i % 2 == 0) { } // bukan prima
                    else if (i % 3 == 0) { } // bukan prima
                    else if (i % 5 == 0) { } // bukan prima
                    else if (i % 7 == 0) { } // bukan prima
                    else
                    {                        
                        prima.Add(i.ToString());                       
                        countElm++;
                    } 
                }

                int prmCount = prima.Count;
                
                if (prmCount == 1)
                {                   
                    txtHasil.Text = prima[0].ToString();
                }

                

                if (prmCount > 1)
                {                   
                    for (int i = 0; i <= prmCount - 1; i++)
                    {
                        if (i != prmCount - 1)
                        {
                            strPrime += prima[i] + ", ";
                        }                       

                        if (i == prmCount - 1)
                        {
                            strPrime += "dan " + prima[i];
                        }
                    }

                    txtHasil.Text = strPrime;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error : " + ex.Message.ToString();
                lblError.ForeColor = System.Drawing.Color.Yellow;
            }
        }

        private void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult openFile = dlgOpen.ShowDialog();

            if (openFile == DialogResult.OK)
            {
                namaFile = dlgOpen.FileName;

                int jumlahBaris = File.ReadAllLines(namaFile).Length;
                string isiFile = File.ReadAllText(namaFile);
                bool cekIsiFile = NumericOnly(isiFile);

                if (jumlahBaris > 1)
                {
                    lblError.Text = "File berisi lebih dari 1 baris.\nTidak bisa diproses !!!";
                    lblError.ForeColor = System.Drawing.Color.Yellow;
                    //MessageBox.Show("File berisi lebih dari 1 baris. Tidak bisa diproses.");
                }
                else if(cekIsiFile == true)
                {
                    txtNilain.Text = isiFile;
                }
                else if (cekIsiFile == false)
                {
                    lblError.Text = "File hanya boleh berisi angka !!!";
                    lblError.ForeColor = System.Drawing.Color.Yellow;
                    //MessageBox.Show("File berisi lebih dari 1 baris. Tidak bisa diproses.");
                }

                
            }
        }

        private void lnkLblSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult saveFile = dlgSave.ShowDialog();

            if (saveFile == DialogResult.OK)
            {
                namaFileBaru = dlgSave.FileName;

                if (namaFileBaru.Equals(namaFile))
                {
                    MessageBox.Show("Gunakan nama file berbeda !!");
                }
                else
                {
                    File.WriteAllText(namaFileBaru, txtHasil.Text);
                    lblError.Text = "File berhasil disimpan dengan nama : " + namaFileBaru;
                    lblError.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
    }
}
                  
