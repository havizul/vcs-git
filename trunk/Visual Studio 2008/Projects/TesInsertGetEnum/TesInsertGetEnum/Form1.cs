using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Npgsql;

namespace TesInsertGetEnum
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conn = null;
        string strSql = string.Empty;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent(); 
            
            
            konekPostgre();
        }
       

        private void konekPostgre()
        {
            string server = "172.16.16.125";
            string Database = "havizul";
            string Port = "5432";
            
            string User = "havizul";
            //string Password = "1q2w3e4r";
            string Password = "12345678";

            string strConn = "Server=" + server + "; Port=" + Port + "; User Id=" + User + "; Password=" + Password + "; Database=" + Database;

            conn = new NpgsqlConnection(strConn);   //Buat objek untuk koneksi ke database
            conn.Open();

        }

        private void btnKonek_Click(object sender, EventArgs e)
        {
            //konekPostgre();
            //MessageBox.Show("Berhasil terkoneksi ke database havizul");
        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            //NpgsqlConnection connLoc = konekPostgre();


            string strSql = "SELECT * FROM pegawai";

            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSql, conn);

            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();

            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);

            // since it C# DataSet can handle multiple tables, we will select first
            dt = ds.Tables[0];

            // connect grid to DataTable
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //string strSql = "INSERT INTO pegawai (id, jenis_kelamin) values (5, 'W')";
            string strSql = "INSERT INTO pegawai (id, jenis_kelamin, tanggal_lahir) values (@1, @2, @3)";

            //strSql = "INSERT INTO agama (id_agama, nama_agama) VALUES (DEFAULT, @2)";
            //strSql = "INSERT INTO agama (nama_agama) VALUES (@2)";

            //NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn);
            
            //cmd.ExecuteNonQuery();
                        
            using (NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", 7);
                cmd.Parameters.AddWithValue("@2", 'P');
                cmd.Parameters.AddWithValue("@3", "08/10/2014");

                cmd.ExecuteNonQuery();
            }
            


            /*
            // data adapter making request from our connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSql, conn);

            // i always reset DataSet before i do
            // something with it.... i don't know why :-)
            ds.Reset();

            // filling DataSet with result from NpgsqlDataAdapter
            da.Fill(ds);

            // since it C# DataSet can handle multiple tables, we will select first
            dt = ds.Tables[0];

            // connect grid to DataTable
            dataGridView1.DataSource = dt;
             */
 
        }


    }
}
