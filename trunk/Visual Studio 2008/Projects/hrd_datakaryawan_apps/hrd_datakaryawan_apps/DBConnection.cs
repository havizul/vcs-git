using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Npgsql;
using System.Configuration;

namespace hrd_datakaryawan_apps
{
    public class DBConnection
    {
        //Variabel Global
        private NpgsqlConnection conn = null;
        private static DBConnection dbConn = null;

        //Constructor. Hanya akan di eksekusi setiap ada objek baru yang dibentuk dari kelas ini.
        //Tujuannya membentuk objek baru dari class ini adalah untuk terhubung ke database / hubungan
        //antara aplikasi ini dengan database terbuka
        private DBConnection()
        {
            //Jika objek conn bernilai null, berarti tidak ada status koneksi ke database, atau koneksi ke database tidak open.
            if (conn == null)
            {
                //Baca informasi di file xml (App.config)
                string server = ConfigurationSettings.AppSettings["Server"];
                string Database = ConfigurationSettings.AppSettings["Database"];
                string Port = ConfigurationSettings.AppSettings["Port"];

                string User = "havizul";
                //string Password = "1q2w3e4r";
                string Password = "12345678";

                string strConn = "Server=" + server + "; Port=" + Port + "; User Id=" + User + "; Password=" + Password + "; Database=" + Database;

                conn = new NpgsqlConnection(strConn);   //Buat objek untuk koneksi ke database
                conn.Open();    //Dengan objek yang baru saja dibuat, gunakan untuk membuka koneksi dengan database
            }
        }

        //Fungsi / Method dari class lain dapat mengakses langsung kelas ini tanpa harus membuat objek
        //dari class DBCOnnection terlebih dahulu
        //Method ini hanyalah berfungsi untuk membangkitkan constructor dari class DBConnection ini, atau
        //membuat objek baru dari class ini yang pada akhirnya variabel conn akan membuat status open dengan database
        public static DBConnection GetInstance()
        {
            if (dbConn == null)
            {
                dbConn = new DBConnection();    //Setelah diketahui bahwa dbConn == null, maka buat objek baru dar class DBConnection dengan tujuan untuk membuka koneksi dengan database
            }

            return dbConn;  //Mengembalikan variabel dbConn = memberikan sebuah variabel yang mereferensikan objek yang telah membangkitkan constructor DBConnection, atau dapat disamakan
                            //bahwa method luar class DBConnection yang telah memanggil mehod ini telah membangkitkan constructor DBConnection
        }

        public NpgsqlConnection GetConnection()
        {
            return this.conn;
        }
    }
}
