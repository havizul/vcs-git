using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using AplikasiPayrollDAO.Model;

namespace AplikasiPayrollDAO.DAO
{
    public class LoginDAO
    {
        private MySqlConnection conn;
        private string strSql = string.Empty;

        //constructor
        public LoginDAO(MySqlConnection conn)
        {
            this.conn = conn;
        }

        //Buat Method MappingRowToObject
        public Petugas MappingRowToObject(MySqlDataReader dtr)
        {
            Petugas lgn = new Petugas();

            lgn.Kode_Petugas = dtr["Kode_Petugas"] is DBNull ? string.Empty : dtr["Kode_Petugas"].ToString();
            lgn.Nama_Petugas = dtr["Nama_Petugas"] is DBNull ? string.Empty : dtr["Nama_Petugas"].ToString();
            lgn.Password_Petugas = dtr["Password_Petugas"] is DBNull ? string.Empty : dtr["Password_Petugas"].ToString();
            lgn.Status_Petugas = dtr["Status_Petugas"] is DBNull ? string.Empty : dtr["Status_Petugas"].ToString();

            return lgn;
        }

        //Salin record berdasarkan Primary Key di dalam tabel Petugas ke dalam class Login.cs
        public Petugas GetByKodePetugas(string Kode_Petugas)
        {
            Petugas lgn = null;

            strSql = "SELECT * FROM Petugas WHERE Kode_Petugas = @1";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Kode_Petugas);

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.Read())
                    {
                        lgn = MappingRowToObject(dtr);
                    }
                }
            }

            return lgn;
        }

        //Cek tabel Petugas apakah terdapat record dengan Kode_Jabatan yang disebutkan
        public char CheckRecord(string Kode_Petugas, string Password_Petugas)
        {
            char YN = 'N';
            strSql = "SELECT * FROM Petugas WHERE Kode_Petugas = @1 AND Password_Petugas =@2";

            using (MySqlCommand cmd = new MySqlCommand(strSql, conn))
            {
                cmd.Parameters.AddWithValue("@1", Kode_Petugas);
                cmd.Parameters.AddWithValue("@2", Password_Petugas);

                using (MySqlDataReader dtr = cmd.ExecuteReader())
                {
                    if (dtr.HasRows)
                    {
                        YN = 'Y';
                    }
                    else
                    {
                        YN = 'N';
                    }
                }
            }

            return YN;
        }
    }
}
